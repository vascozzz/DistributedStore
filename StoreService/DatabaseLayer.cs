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
        /*public int getStuff()
        {
            int lalala = 0;

            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["StoreDatabase"].ConnectionString);
            c.Open();

            string sql = "SELECT * FROM Lol";
            SqlCommand cmd = new SqlCommand(sql, c);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String name = reader.GetString(1);
                if (name == "ola")
                    lalala = 1337;
            }

            c.Close();

            return n1 + n2 + lalala;
        }

        public DataTable GetTickets(int author)
        {
            DataTable result = new DataTable("TTickets");

            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTs"].ConnectionString))
            {
                try
                {
                    c.Open();
                    string sql = "select Id, Problem, Status, Answer from TTickets where Author=" + author;
                    SqlCommand cmd = new SqlCommand(sql, c);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(result);
                }
                catch (SqlException)
                {
                }
                finally
                {
                    c.Close();
                }
            }
            return result;
        }
         
             public bool Register(string name, string nickname, string password)
    {
        string sql = "SELECT * from user WHERE nickname = @nickname";
        SQLiteCommand command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        SQLiteDataReader data = command.ExecuteReader();

        if (data.Read())
        {
            return false;
        }

        sql = "INSERT INTO USER(name, nickname, password) VALUES(@name, @nickname, @password)";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@nickname", nickname);
        command.Parameters.AddWithValue("@password", password);
        command.ExecuteNonQuery();

        sql = "SELECT user_id FROM user WHERE nickname = @nickname";
        command = new SQLiteCommand(sql, db);
        command.Parameters.AddWithValue("@nickname", nickname);
        data = command.ExecuteReader();
        data.Read();
        int user_id = Convert.ToInt32((long) data["user_id"]);

        for (int i = 0; i < 20; i++)
        {
            sql = "INSERT INTO diginote VALUES(null, @user_id, @value)";
            command = new SQLiteCommand(sql, db);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Parameters.AddWithValue("@value", 1);
            command.ExecuteNonQuery();
        }
 
        return true;
    }


             public DataTable GetTickets(int author) {
      DataTable result = new DataTable("TTickets");
      
      using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["TTs"].ConnectionString)) {
        try {
          c.Open();
          string sql = "select Id, Problem, Status, Answer from TTickets where Author=" + author;
          SqlCommand cmd = new SqlCommand(sql, c);
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          adapter.Fill(result);
        }
        catch (SqlException) {
        }
        finally {
          c.Close();
        }
      }
      return result;
    }
         
         */

        public static bool AddOrder(int bookId, int quantity, float totalPrice, string clientName, string clientAddress, string clientEmail, string state, int stateCode, int origin)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "INSERT INTO ORDER(book_id, quantity, total_price, client_name, client_address, client_email, state, state_code, origin) VALUES(@bookId, @quantity, @totalPrice, @clientName, @clientAddress, @clientEmail, @state, @stateCode, @origin)";

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

                command.ExecuteNonQuery();
            }
            catch(SqlException)
            {
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;
        }

        public static bool AddBook(string title, int quantity, float price)
        {
            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "INSERT INTO BOOK(title, quantity, price) VALUES(@title, @quantity, @price)";

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

        public static DataTable GetBooks()
        {
            DataTable books = new DataTable("Books");

            SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[DBNAME].ConnectionString);

            try
            {
                db.Open();

                string sql = "SELECT * FROM BOOK";

                SqlCommand command = new SqlCommand(sql, db);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(books);
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
    }
}
