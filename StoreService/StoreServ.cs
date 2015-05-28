using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Messaging;
using System.ComponentModel;

namespace StoreService
{
    class StoreServ : IStoreServ
    {
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
                DatabaseLayer.UpdateBookQuantity(bookId, newQuantity);
            }

            // order must be completed later, state = 1, ask warehouse for more
            else
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


        public bool AddBookQuantity(int bookId, int quantity)
        {
            return DatabaseLayer.AddBookQuantity(bookId, quantity);
        }

        public int addRequest(int bookId, int quantity)
        {
            return DatabaseLayer.AddRequest(bookId, quantity);
        }

        public List<StoreRequest> GetRequests()
        {
            return DatabaseLayer.GetRequests();
        }

        public bool FulfillRequest(int requestId)
        {
            return DatabaseLayer.UpdateRequest(requestId, 1);
        }

        public bool DeleteRequest(int requestId)
        {
            return DatabaseLayer.DeleteRequest(requestId);
        }
    }
}
