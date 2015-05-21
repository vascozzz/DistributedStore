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
        }

        private void bookGrid_SelectionChanged(object sender, EventArgs e)
        {
            if(bookGrid.SelectedRows.Count > 0)
                bookIdField.Text = bookGrid.SelectedRows[0].Cells["id"].Value.ToString();
        }
    }
}
