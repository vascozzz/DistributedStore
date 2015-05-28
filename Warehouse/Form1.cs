using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Messaging;
using System.Threading;
using Warehouse.StoreService;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class Form1 : MetroForm
    {
        volatile bool shouldStop;
        MessageQueue myQueue;
        StoreServClient storeService;

        BindingList<StoreRequest> requestList;

        public Form1()
        {
            InitializeComponent();

            storeService = new StoreServClient();

            //Get current requests from database
            requestList = new BindingList<StoreRequest>(storeService.GetRequests().ToList());
            requestGrid.DataSource = requestList;

            requestGrid.Columns["id"].DisplayIndex = 0;
            requestGrid.Columns["book_id"].DisplayIndex = 1;
            requestGrid.Columns["quantity"].DisplayIndex = 2;
            requestGrid.Columns["fulfilled"].DisplayIndex = 3;

            //Start warehouse queue
            if (MessageQueue.Exists(@".\private$\warehouse"))
                myQueue = new MessageQueue(@".\private$\warehouse");
            else
                myQueue = MessageQueue.Create(@".\private$\warehouse");

            startReceiving();
        }

        public void AddToRequestList(StoreRequest request)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate { AddToRequestList(request); });
                return;
            }

            requestList.Add(request);
        }

        private void startReceiving()
        {
            shouldStop = false;

            new Thread(() =>
            {
                while (!shouldStop)
                {
                    System.Messaging.Message message = myQueue.Receive();
                    message.Formatter = new BinaryMessageFormatter();

                    String messageString = message.Body.ToString();
                    String[] messageComponents = messageString.Split(' ');

                    int bookId = Convert.ToInt32(messageComponents[0]);
                    int quantity = Convert.ToInt32(messageComponents[1]);

                    // Acknowledge Request (Add it to the server database)
                    int requestId = storeService.addRequest(bookId, quantity);

                    // Add it to request grid
                    AddToRequestList(new StoreRequest { id = requestId, book_id = bookId, quantity = quantity });
                }
            }).Start();
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            shouldStop = true;
            System.Windows.Forms.Application.Exit();
        }

        private void requestGrid_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            int requestId = requestList[e.RowIndex].id;
            int fulfilled = requestList[e.RowIndex].fulfilled;

            //Fulfill Request
            if(fulfilled == 0)
            {
                bool fulfillSuccess = storeService.FulfillRequest(requestId);

                if (fulfillSuccess)
                    requestList[e.RowIndex].fulfilled = 1;
            }
        }
    }
}
