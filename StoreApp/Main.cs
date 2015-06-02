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
using System.ServiceModel;
using System.Windows.Forms;

namespace StoreApp
{
    public partial class Main : MetroForm
    {
        StoreServClient storeService;
        BindingList<StoreBook> bookList;
        BindingList<StoreRequest> requestList;
        Guid id;

        public Main()
        {
            InitializeComponent();

            //Start store service
            storeService = new StoreServClient(new InstanceContext(new StoreServCallback(this)));
            id = storeService.Subscribe();

            //Set book grid
            bookList = new BindingList<StoreBook>(storeService.GetBooks().ToList());
            bookGrid.DataSource = bookList;

            bookGrid.Columns["id"].DisplayIndex = 0;
            bookGrid.Columns["title"].DisplayIndex = 1;
            bookGrid.Columns["quantity"].DisplayIndex = 2;
            bookGrid.Columns["price"].DisplayIndex = 3;

            //Set request grid
            requestList = new BindingList<StoreRequest>(storeService.GetRequests().ToList());
            requestGrid.DataSource = requestList;

            requestGrid.Columns["id"].DisplayIndex = 0;
            requestGrid.Columns["book_id"].DisplayIndex = 1;
            requestGrid.Columns["quantity"].DisplayIndex = 2;
            requestGrid.Columns["fulfilled"].DisplayIndex = 3;

            //"Start" Printer
            Console.WriteLine("|=============================================|");
            Console.WriteLine("|===== Distributed Store Printer Service =====|");
            Console.WriteLine("|=============================================|");
            Console.WriteLine("- Initializing Printer...");
            Console.WriteLine("- Status: Online");
        }

        //Events

        private void bookGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (bookGrid.SelectedRows.Count > 0)
                bookIdField.Text = bookList[bookGrid.SelectedRows[0].Index].id.ToString();
        }

        private void orderSubmitBtn_Click(object sender, EventArgs e)
        {
            int bookId = Convert.ToInt32(bookIdField.Text);
            int quantity = Convert.ToInt32(bookQuantityField.Text);
            string clientName = clientNameField.Text;
            string clientAddress = clientAddressField.Text;
            string clientEmail = clientEmailField.Text;

            int orderId = storeService.AddOrder(bookId, quantity, clientName, clientAddress, clientEmail, 0);

            //"Print" Receipt
            Console.WriteLine();
            Console.WriteLine("Order of Id " + orderId + " correctly processed.");
            Console.WriteLine("Thank you for your preference.");
            Console.WriteLine("Please consult our website for more details.");
        }

        private void requestGrid_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            StoreRequest request = requestList[e.RowIndex];

            if(request.fulfilled == 1) //finish request
            {
                storeService.AddBookQuantity(request.book_id, request.quantity);
                storeService.DeleteRequest(request.id);

                foreach (StoreBook book in bookList)
                    if (book.id == request.book_id)
                        book.quantity += request.quantity;

                requestList.RemoveAt(e.RowIndex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            storeService.Unsubscribe(id);
        }

        // Form manipulation

        public void AddRequest(StoreRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { AddRequest(request); });
                return;
            }

            requestList.Add(request);
        }

        public void FulfillRequest(int requestId)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { FulfillRequest(requestId); });
                return;
            }

            foreach (StoreRequest request in requestList)
                if (request.id == requestId)
                    request.fulfilled = 1;
        }


        internal void UpdateBookQuantity(int bookId, int newQuantity)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { UpdateBookQuantity(bookId, newQuantity); });
                return;
            }

            foreach (StoreBook book in bookList)
                if (book.id == bookId)
                    book.quantity = newQuantity;
        }
    }
}
