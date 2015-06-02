using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Messaging;
using System.ComponentModel;
using System.ServiceModel;
using System.Threading;

namespace StoreService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    class StoreServ : IStoreServ
    {
        private readonly Dictionary<Guid, IStoreCallback> clients = new Dictionary<Guid, IStoreCallback>();

        public Guid Subscribe()
        {
            IStoreCallback callback = OperationContext.Current.GetCallbackChannel<IStoreCallback>();
            
            Guid clientId = Guid.NewGuid();

            if (callback != null)
            {
                lock (clients)
                {
                    clients.Add(clientId, callback);
                }
            }

            return clientId;
        }

        public void Unsubscribe(Guid clientId)
        {
            lock (clients)
            {
                if (clients.ContainsKey(clientId))
                {
                    clients.Remove(clientId);
                }
            }
        }

        public List<StoreBook> GetBooks()
        {
            return DatabaseLayer.GetBooks();
        }

        public int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin)
        {
            // get desired book
            StoreBook book = DatabaseLayer.GetBook(bookId);

            // if not found, return new order Id as -1
            if (book == null)
            {
                return -1;
            }

            // otherwise, proceed by checking if book has enough stock
            int available = book.quantity;
            double price = book.price;
            float totalPrice = (float)(quantity * price);

            DateTime date = DateTime.Today;
            int stateCode;
            string state;

            // can finish order, state = 3, update quantity
            if (available >= quantity)
            {
                date.AddDays(1);

                stateCode = 3;
                state = "dispatched at " + date.ToString("d-M-yyyy");

                int newQuantity = available - quantity;
                UpdateBookQuantity(bookId, newQuantity);
            }
            else // order must be completed later, state = 1, ask warehouse for more
            {
                int requestQuantity = quantity * 10; //"...for a quantity 10 times the initial order volume."

                stateCode = 1;
                state = "waiting expedition";

                // Request from warehouse.
                MessageQueue warehouseQueue;

                if (MessageQueue.Exists(@".\private$\warehouse"))
                    warehouseQueue = new MessageQueue(@".\private$\warehouse");
                else
                    warehouseQueue = MessageQueue.Create(@".\private$\warehouse");

                Message message = new Message();

                message.Formatter = new BinaryMessageFormatter();
                message.Body = bookId + " " + requestQuantity;
                message.Label = "Store Application";

                warehouseQueue.Send(message);
            }

            // register order
            int orderId = DatabaseLayer.AddOrder(bookId, quantity, totalPrice, clientName, clientAddress, clientEmail, state, stateCode, origin);

            // send email if needed
            if (origin == 1 && stateCode == 3) {
                // MailHelper.SendMail(clientEmail, clientName, orderId, date.ToString("d-M-yyyy"));
            }

            //Printer is client side now, so no need to verify if origin is client's. Ill leave the "if" statement here anyway: if (origin == 0 && stateCode == 2)

            return orderId;
        }

        public StoreOrder GetOrder(string clientEmail, int orderId)
        {
            return DatabaseLayer.GetOrder(clientEmail, orderId);
        }

        public void UpdateBookQuantity(int bookId, int newQuantity)
        {
            DatabaseLayer.UpdateBookQuantity(bookId, newQuantity);

            //Broadcast to all clients
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        List<Guid> disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, IStoreCallback> client in clients)
                        {
                            try
                            {
                                client.Value.OnUpdateBookQuantity(bookId, newQuantity);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key);
                            }

                        }

                        foreach (Guid clientGuid in disconnectedClientGuids)
                            clients.Remove(clientGuid);
                    }
                }
            );
        }


        public bool AddBookQuantity(int bookId, int quantity)
        {
            return DatabaseLayer.AddBookQuantity(bookId, quantity);
        }

        public int addRequest(int bookId, int quantity)
        {
            int id = DatabaseLayer.AddRequest(bookId, quantity);

            //Broadcast to all clients
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        List<Guid> disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, IStoreCallback> client in clients)
                        {
                            try
                            {
                                client.Value.OnAddRequest(id, bookId, quantity);
                            }
                            catch (Exception)
                            {
                                disconnectedClientGuids.Add(client.Key);
                            }

                        }

                        foreach (Guid clientGuid in disconnectedClientGuids)
                            clients.Remove(clientGuid);
                    }
                }
            );

            return id;
        }

        public List<StoreRequest> GetRequests()
        {
            return DatabaseLayer.GetRequests();
        }

        public bool FulfillRequest(int requestId)
        {
            bool success = DatabaseLayer.UpdateRequest(requestId, 1);

            if(success)
            {
                //Broadcast to all clients
                ThreadPool.QueueUserWorkItem
                (
                    delegate
                    {
                        lock (clients)
                        {
                            List<Guid> disconnectedClientGuids = new List<Guid>();

                            foreach (KeyValuePair<Guid, IStoreCallback> client in clients)
                            {
                                try
                                {
                                    client.Value.OnFulfillRequest(requestId);
                                }
                                catch (Exception)
                                {
                                    disconnectedClientGuids.Add(client.Key);
                                }

                            }

                            foreach (Guid clientGuid in disconnectedClientGuids)
                                clients.Remove(clientGuid);
                        }
                    }
                );
            }

            return success;
        }

        public bool DeleteRequest(int requestId)
        {
            return DatabaseLayer.DeleteRequest(requestId);
        }
    }
}
