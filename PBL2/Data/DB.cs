using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Data
{
    public class DB
    {
        private static string startupPath = Application.StartupPath;
        // Lên 2 cấp từ bin/Debug → MyProject
        public static string projectRoot = Directory.GetParent(startupPath).Parent.FullName;
        //----------------Hieu,  Bin, Hai-------------------------------------------------
        private static string connectionString = "server=localhost;port=3306;database=pbl;uid=root;pwd=mysql12345;";
        //-----------------------------------------------------------------
        private DB() { }

        // Mở kết nối
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Thực hiện SELECT, trả về DataTable
        public static DataTable ExecuteQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteQuery error: " + e.Message);
                    return null;
                }
            }
        }

        public static DataTable ExecuteQuery(MySqlCommand cmd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteQuery error: " + e.Message);
                    return null;
                }
            }
        }

        // Thực hiện SELECT, trả về MySqlDataReader
        public static MySqlDataReader ExecuteReader(string query)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                Console.WriteLine("ExecuteReader error: " + e.Message);
                conn.Close();
                return null;
            }
        }

        public static MySqlDataReader ExecuteReader(MySqlCommand cmd)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                cmd.Connection = conn;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                Console.WriteLine("ExecuteReader error: " + e.Message);
                conn.Close();
                return null;
            }
        }

        // Thực hiện INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteNonQuery error: " + e.Message);
                    return -1;
                }
            }
        }

        public static int ExecuteNonQuery(MySqlCommand cmd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteNonQuery error: " + e.Message);
                    return -1;
                }
            }
        }

        // Thực hiện truy vấn trả về một giá trị (ví dụ COUNT, MAX, MIN)
        public static object ExecuteScalar(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteScalar error: " + e.Message);
                    return null;
                }
            }
        }

        public static object ExecuteScalar(MySqlCommand cmd)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    return cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ExecuteScalar error: " + e.Message);
                    return null;
                }
            }
        }
    }
}
