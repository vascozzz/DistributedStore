using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using StoreApp.StoreService;
using System.Messaging;

namespace StoreApp
{
    public partial class Form1 : MetroForm
    {
        StoreServClient storeService;
        MessageQueue warehouseQueue;

        public Form1()
        {
            InitializeComponent();

            //Start store service
            storeService = new StoreServClient();
            bookGrid.DataSource = storeService.GetBooks();
            requestGrid.DataSource = storeService.GetRequests();

            //Start warehouse queue
            if (MessageQueue.Exists(@".\private$\warehouse"))
                warehouseQueue = new MessageQueue(@".\private$\warehouse");
            else
                warehouseQueue = MessageQueue.Create(@".\private$\warehouse");

            //"Start" Printer
            Console.WriteLine("|=============================================|");
            Console.WriteLine("|===== Distributed Store Printer Service =====|");
            Console.WriteLine("|=============================================|");
            Console.WriteLine("- Initializing Printer...");
            Console.WriteLine("- Status: Online");
        }

        private void bookGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(bookGrid.SelectedRows.Count > 0)
                bookIdField.Text = bookGrid.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void orderSubmitBtn_Click(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt32(bookIdField.Text);
            int quantity = Convert.ToInt32(bookQuantityField.Text);
            string clientName = clientNameField.Text;
            string clientAddress = clientAddressField.Text;
            string clientEmail = clientEmailField.Text;

            int orderId = storeService.AddOrder(bookId, quantity, clientName, clientAddress, clientEmail, 0);
            Console.WriteLine();
            Console.WriteLine("Order of Id " + orderId + " correctly processed.");
            Console.WriteLine("Thank you for your preference.");
            Console.WriteLine("Please consult our website for more details.");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Message message = new Message();

            message.Formatter = new BinaryMessageFormatter();
            message.Body = "Oh yeahhhhh";
            message.Label = "Store Application";

            warehouseQueue.Send(message);
        }
    }
}
