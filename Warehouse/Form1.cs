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
        MessageQueue myQueue;   

        public Form1()
        {
            InitializeComponent();

            //Start warehouse queue
            if (MessageQueue.Exists(@".\private$\warehouse"))
                myQueue = new MessageQueue(@".\private$\warehouse");
            else
                myQueue = MessageQueue.Create(@".\private$\warehouse");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Message messagea = myQueue.Receive();
            messagea.Formatter = new BinaryMessageFormatter();

            message.Text = messagea.Body.ToString();
        }
    }
}
