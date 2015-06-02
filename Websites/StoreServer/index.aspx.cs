using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreService;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.ServiceModel;

public partial class index : System.Web.UI.Page
{
    private StoreServClient storeService;
    private BindingList<StoreBook> bookArray;
    private BindingList<StoreOrder> orderArray;

    private class StoreServCallback : IStoreServCallback
    {
        public void OnAddRequest(int id, int book_id, int quantity) {}

        public void OnFulfillRequest(int id) {}

        public void OnUpdateBookQuantity(int bookId, int newQuantity) {}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        storeService = new StoreServClient(new InstanceContext(new StoreServCallback()));
        storeService.Subscribe();

        bookArray = new BindingList<StoreBook>(storeService.GetBooks().ToList());
        bookList.DataSource = bookArray;
        bookList.DataBind();

        orderArray = new BindingList<StoreOrder>();
        orderList.DataSource = orderArray;
        orderList.DataBind();
    }

    protected void submitOrderBtn_Click(object sender, EventArgs e)
    {
        string[] nonEmptyFields = { clientName.Text, clientAddress.Text, clientEmail.Text };
        string[] numberFields = { bookId.Text, bookQuantity.Text };

        if (!CheckNonEmptyFields(nonEmptyFields) || !CheckNumberFields(numberFields))
        {
            submitOrderStatus.Text = "Please complete all fields!";
            return;
        }

        if (!CheckValidEmail(clientEmail.Text))
        {
            submitOrderStatus.Text = "Your email is not valid!";
            return;
        }

        // required fields
        int id = Convert.ToInt32(bookId.Text);
        int quantity = Convert.ToInt32(bookQuantity.Text);
        string name = clientName.Text;
        string address = clientAddress.Text;
        string email = clientEmail.Text;

        // register new order
        int orderId = storeService.AddOrder(id, quantity, name, address, email, 1);

        // book was not found in database
        if (orderId == -1)
        {
            submitOrderStatus.Text = "ID not found or not valid!";
            return;
        }

        // update books list on page
        submitOrderStatus.Text = "Order registered successfully! Your new order has the ID " + orderId + ". You should receive an email with the confirmation in a moment.";
        bookList.DataSource = storeService.GetBooks();
        bookList.DataBind();
    }
    protected void checkOrderBtn_Click(object sender, EventArgs e)
    {
        string[] nonEmptyFields = { orderEmail.Text };
        string[] numberFields = { orderId.Text };

        if (!CheckNonEmptyFields(nonEmptyFields) || !CheckNumberFields(numberFields))
        {
            checkOrderStatus.Text = "Please complete all fields!";
            orderList.Visible = false;
            return;
        }

        // required fields
        string email = orderEmail.Text;
        int id = Convert.ToInt32(orderId.Text);

        // lookup orders
        StoreOrder order = storeService.GetOrder(email, id);

        // no orders found
        if (order == null)
        {
            checkOrderStatus.Text = "Order not found! Are you sure you have the correct email and ID?";
            orderList.Visible = false;
            return;
        }
        
        // update page with results
        orderArray.Add(order);

        orderList.DataBind();
        orderList.Visible = true;
    }

    protected bool CheckNumberFields(string[] fields)
    {
        foreach (string field in fields)
        {
            try
            {
                int number = Convert.ToInt32(field);
            }
            catch (Exception)
            {
                return false;
            }
        }

        return true;
    }

    protected bool CheckNonEmptyFields(string[] fields)
    {
        foreach (string field in fields)
        {
            if (string.IsNullOrEmpty(field))
            {
                return false;
            }          
        }

        return true;
    }

    protected bool CheckValidEmail(string email)
    {
        try
        {
            // since we'll be sending emails using the .NET email library, we should ensure our validation works exactly alike
            // as such, this is safer than a regular regex validation
            MailAddress to = new MailAddress(email);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}