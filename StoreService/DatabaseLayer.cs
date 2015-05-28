using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ComponentModel;

namespace StoreService
{
    static class DatabaseLayer
    {
        private const string DBNAME = "StoreDatabase";

        ///////////
        // Books //
        ///////////

        //Adds a new book
        public static int AddBook(string title, int quantity, float price)
        {
            int newId;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "INSERT INTO Book(title, quantity, price) VALUES(@title, @quantity, @price); SELECT SCOPE_IDENTITY()";

                SqlCommand command = new SqlCommand(sql, db);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@price", price);

                newId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException)
            {
                return -1;
            }
            finally
            {
                db.Close();
            }

            return newId;
        }

        //Fetches a book by its id
        public static StoreBook GetBook(int bookId)
        {
            StoreBook book = null;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "SELECT * FROM Book WHERE id = @bookId";

                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@bookId", bookId);

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                
                int id = Convert.ToInt32(reader["id"]);
                string title = reader["title"].ToString();
                int quantity = Convert.ToInt32(reader["quantity"]);
                float price = Convert.ToSingle(reader["price"]);

                book = new StoreBook { id = id, title = title, quantity = quantity, price = price };
            }
            catch (SqlException)
            {
            }
            finally
            {
                db.Close();
            }

            return book;
        }

        //Fetches all books
        public static List<StoreBook> GetBooks()
        {
            List<StoreBook> books = new List<StoreBook>();
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "SELECT * FROM Book";

                SqlCommand command = new SqlCommand(sql, db);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string title = reader["title"].ToString();
                    int quantity = Convert.ToInt32(reader["quantity"]);
                    float price = Convert.ToSingle(reader["price"]);

                    books.Add(new StoreBook { id = id, title = title, quantity = quantity, price = price });
                }
            }
            catch (SqlException)
            {
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
            int newId;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

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
            catch (SqlException)
            {
                return -1;
            }
            finally
            {
                db.Close();
            }

            return newId;
        }

        //Fetches an Order by id and client email (for validation purposes)
        public static StoreOrder GetOrder(string clientEmail, int orderId)
        {
            StoreOrder order = null;
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "SELECT * FROM BookOrder WHERE client_email = @clientEmail AND id = @orderId";

                SqlCommand command = new SqlCommand(sql, db);
                command.Parameters.AddWithValue("@clientEmail", clientEmail);
                command.Parameters.AddWithValue("@orderId", orderId);

                SqlDataReader reader = command.ExecuteReader();

                reader.Read();

                int id = Convert.ToInt32(reader["id"]);
                int book_id = Convert.ToInt32(reader["book_id"]);
                int quantity = Convert.ToInt32(reader["quantity"]);
                float total_price = Convert.ToSingle(reader["total_price"]);
                string client_name = reader["client_name"].ToString();
                string client_address = reader["client_address"].ToString();
                string client_email = reader["client_email"].ToString();
                string state = reader["state"].ToString();
                int state_code = Convert.ToInt32(reader["state_code"]);
                int origin = Convert.ToInt32(reader["origin"]);

                order = new StoreOrder { id = id, book_id = book_id, quantity = quantity, total_price = total_price, client_name = client_name, client_address = client_address, client_email = client_email, state = state, state_code = state_code, origin = origin };
            }
            catch (SqlException)
            {
            }
            finally
            {
                db.Close();
            }

            return order;
        }

        //////////////
        // Requests //
        //////////////

        //Add a new book request
        public static int AddRequest(int bookId, int quantity)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            int newId;

            try
            {
                db.Open();

                string sql = "INSERT INTO BookRequest(book_id, quantity, fulfilled) VALUES(@bookId, @quantity, @fulfilled); SELECT SCOPE_IDENTITY()";

                SqlCommand command = new SqlCommand(sql, db);

                command.Parameters.AddWithValue("@bookId", bookId);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@fulfilled", 0);

                newId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (SqlException)
            {
                return -1;
            }
            finally
            {
                db.Close();
            }

            return newId;
        }

        //Fetches all book requests
        public static List<StoreRequest> GetRequests()
        {
            List<StoreRequest> list = new List<StoreRequest>();

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);
            DataTable requests = new DataTable("Requests");

            try
            {
                db.Open();

                string sql = "SELECT * FROM BookRequest";

                SqlCommand command = new SqlCommand(sql, db);
                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int book_id = Convert.ToInt32(reader["book_id"]);
                    int quantity = Convert.ToInt32(reader["quantity"]);
                    int fulfilled = Convert.ToInt32(reader["fulfilled"]);

                    list.Add(new StoreRequest { id = id, book_id = book_id, quantity = quantity, fulfilled = fulfilled });
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }

            return list;
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
