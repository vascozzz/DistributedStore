using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace StoreService
{
    class StoreServ : IStoreServ
    {
        public DataTable GetBooks()
        {
            return DatabaseLayer.GetBooks();
        }

        public int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin)
        {
            // get desired book
            DataTable books = DatabaseLayer.GetBook(bookId);

            // if not found, return new order Id as -1
            if (books.Rows.Count < 1)
            {
                return -1;
            }

            // otherwise, proceed by checking if book has enough stock
            DataRow book = books.Rows[0];
            int available = (int)book["quantity"];
            double price = (double)book["price"];
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
                stateCode = 1;
                state = "waiting expedition";

                // request from warehouse
                // DatabaseLayer.AddRequest();
            }

            // register order
            int orderId = DatabaseLayer.AddOrder(bookId, quantity, totalPrice, clientName, clientAddress, clientEmail, state, stateCode, origin);

            // send email if needed
            if (origin == 1 && stateCode == 3) {
                // MailHelper.SendMail(clientEmail, clientName, orderId, date.ToString("d-M-yyyy"));
            }
            
            // or issue receipt if origin = store
            if (origin == 0 && stateCode == 2) {
                // print receipt thingy

            }

            return orderId;
        }

        public DataTable CheckOrder(string clientEmail, int orderId)
        {
            return DatabaseLayer.CheckOrder(clientEmail, orderId);
        }
    }
}
