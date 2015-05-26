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

namespace Warehouse
{
    public partial class Form1 : MetroForm
    {
        volatile bool shouldStop;
        MessageQueue myQueue;   

        public Form1()
        {
            InitializeComponent();

            //Start request grid
            requestGrid.ColumnCount = 4;
            requestGrid.Columns[0].Name = "id";
            requestGrid.Columns[1].Name = "book_id";
            requestGrid.Columns[2].Name = "quantity";
            requestGrid.Columns[3].Name = "fulfilled";

            //Start warehouse queue
            if (MessageQueue.Exists(@".\private$\warehouse"))
                myQueue = new MessageQueue(@".\private$\warehouse");
            else
                myQueue = MessageQueue.Create(@".\private$\warehouse");

            startReceiving();
        }

        private void startReceiving()
        {
            shouldStop = false;

            new Thread(() =>
            {
                while (!shouldStop)
                {
                    Message message = myQueue.Receive();
                    message.Formatter = new BinaryMessageFormatter();

                    String messageString = message.Body.ToString();
                    String[] messageComponents = messageString.Split(' ');

                    int requestId = Convert.ToInt32(messageComponents[0]);
                    int bookId = Convert.ToInt32(messageComponents[1]);
                    int quantity = Convert.ToInt32(messageComponents[2]);

                    string[] row = new string[] { requestId.ToString(), bookId.ToString(), quantity.ToString(), "0" };
                    requestGrid.Rows.Add(row);
                }
            }).Start();
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            shouldStop = true;
        }

        private void requestGrid_CellMouseDoubleClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            requestGrid.Rows.RemoveAt(e.RowIndex);
        }
    }
}
