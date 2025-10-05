using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace PBL2.Models
{
    internal class MySQL_DB
    {
        private string connectionString = "server=localhost;port=3306;database=pbl;uid=root;pwd=mysql12345;";

        public MySQL_DB() { }

        // Mở kết nối
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Thực hiện SELECT, trả về DataTable
        public DataTable ExecuteQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Thực hiện INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        // Thực hiện truy vấn trả về một giá trị (ví dụ COUNT, MAX, MIN)
        public object ExecuteScalar(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteScalar();
            }
        }

        //Ham querry select
        public DataTable Select(string table, string fields)
        {
            string query = $"SELECT {fields} FROM {table}";

            return ExecuteQuery(query);

        }
    }
}

