using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace StoreService
{
    static class DatabaseLayer
    {
        private const string DBNAME = "StoreDatabase";

        ///////////
        // Books //
        ///////////

        //Fetches a book by its id
        public static DataTable GetBook(int bookId)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            DataTable books = new DataTable("Books");

            try
            {
                db.Open();

                string sql = "SELECT * FROM Book WHERE id = @bookId";

                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@bookId", bookId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(books);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return books;
        }

        //Adds a new book
        public static bool AddBook(string title, int quantity, float price)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "INSERT INTO Book(title, quantity, price) VALUES(@title, @quantity, @price)";

                SqlCommand command = new SqlCommand(sql, db);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@price", price);

                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }

        //Fetches all books
        public static DataTable GetBooks()
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            DataTable books = new DataTable("Books");

            try
            {
                db.Open();

                string sql = "SELECT * FROM Book";

                SqlCommand command = new SqlCommand(sql, db);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(books);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return books;
        }

        //Updates book quantity to a new given quantity
        public static bool UpdateBookQuantity(int bookId, int newQuantity)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "UPDATE Book SET quantity = @newQuantity WHERE id = @bookId";
                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@newQuantity", newQuantity);
                command.Parameters.AddWithValue("@bookId", bookId);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }

        //Increments book quantity by a given quantity
        public static bool AddBookQuantity(int bookId, int quantity)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "UPDATE Book SET quantity = quantity + @quantity WHERE id = @bookId";
                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@bookId", bookId);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }

        ////////////
        // Orders //
        ////////////

        //Adds a new Order
        public static int AddOrder(int bookId, int quantity, float totalPrice, string clientName, string clientAddress, string clientEmail, string state, int stateCode, int origin)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            int newId;

            try
            {
                db.Open();

                string sql = "INSERT INTO BookOrder(book_id, quantity, total_price, client_name, client_address, client_email, state, state_code, origin) ";
                sql += "VALUES(@bookId, @quantity, @totalPrice, @clientName, @clientAddress, @clientEmail, @state, @stateCode, @origin); ";
                sql += "SELECT SCOPE_IDENTITY()";

                SqlCommand command = new SqlCommand(sql, db);

                command.Parameters.AddWithValue("@bookId", bookId);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@totalPrice", totalPrice);
                command.Parameters.AddWithValue("@clientName", clientName);
                command.Parameters.AddWithValue("@clientAddress", clientAddress);
                command.Parameters.AddWithValue("@clientEmail", clientEmail);
                command.Parameters.AddWithValue("@state", state);
                command.Parameters.AddWithValue("@stateCode", stateCode);
                command.Parameters.AddWithValue("@origin", origin);

                newId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return newId;
        }

        //Fetches an Order by id and client email (for validation purposes)
        public static DataTable CheckOrder(string clientEmail, int orderId)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            DataTable orders = new DataTable("Orders");

            try
            {
                db.Open();

                string sql = "SELECT * FROM BookOrder WHERE client_email = @clientEmail AND id = @orderId";

                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@clientEmail", clientEmail);
                command.Parameters.AddWithValue("@orderId", orderId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(orders);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return orders;
        }

        //////////////
        // Requests //
        //////////////

        //Fetches all book requests
        public static DataTable GetRequests()
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            DataTable requests = new DataTable("Requests");

            try
            {
                db.Open();

                string sql = "SELECT * FROM BookRequest";

                SqlCommand command = new SqlCommand(sql, db);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(requests);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return requests;
        }

        //Sets field "fulfilled" of this request to 1 (true).
        // fulfilled -> 0 = false, 1 = true
        public static bool UpdateRequest(int requestId, int fulfilled)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "UPDATE BookRequest SET fulfilled = @fulfilled WHERE id = @requestId";
                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@fulfilled", fulfilled);
                command.Parameters.AddWithValue("@requestId", requestId);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }

        public static bool DeleteRequest(int requestId)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "DELETE FROM BookRequest WHERE id = @requestId";
                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@requestId", requestId);
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }
    }
}
