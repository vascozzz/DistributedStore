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
    class StoreServ : IStoreServ
    {
        public float Add(float n1, float n2)
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

        public float Multiply(float n1, float n2)
        {
            return n1 * n2;
        }
    }
}
