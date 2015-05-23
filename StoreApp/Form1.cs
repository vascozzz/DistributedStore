using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using StoreApp.StoreService;

namespace StoreApp
{
    public partial class Form1 : MetroForm
    {
        StoreServClient storeService;

        public Form1()
        {
            InitializeComponent();

            storeService = new StoreServClient();
            bookGrid.DataSource = storeService.GetBooks();
            requestGrid.DataSource = storeService.GetRequests();
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

            storeService.AddOrder(bookId, quantity, clientName, clientAddress, clientEmail, 0);
        }
    }
}
