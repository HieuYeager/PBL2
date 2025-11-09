using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using PBL2.Class;
using System.Windows.Forms;

namespace PBL2.Models
{
     public class MySQL_DB
    {
        private static string startupPath = Application.StartupPath;
        // Lên 2 cấp từ bin/Debug → MyProject
        public static string projectRoot = Directory.GetParent(startupPath).Parent.FullName;
        //----------------Hieu,  Bin, Hai-------------------------------------------------
        private string connectionString = "server=localhost;port=3306;database=pbl;uid=root;pwd=;";
        //-----------------------------------------------------------------
        public static MySQL_DB Instance { get; } = new MySQL_DB();
        private MySQL_DB() { }

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
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
            }
                catch(Exception e)
                {
                    MessageBox.Show("ExecuteQuery error: " + e.Message);
                    return null;
                }
            }
        }

        // Thực hiện INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    MessageBox.Show("ExecuteNonQuery error: "+ e.Message);
                    return -1;
                }
            }
        }

        // Thực hiện truy vấn trả về một giá trị (ví dụ COUNT, MAX, MIN)
        public object ExecuteScalar(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteScalar();
                }
                catch(Exception e) {
                    MessageBox.Show("ExecuteScalar error: " + e.Message);
                    return null;
                }
            }
        }

        //-----------------------------------------------------------------
        //Ham querry select
        public DataTable Select(string table, string fields)
        {
            string query = $"SELECT {fields} FROM {table}";

            return ExecuteQuery(query);

        }

        //Ham querry select voi condition
        public DataTable Select(string table, string fields, string condition)
        {
            string query = $"SELECT {fields} FROM {table} WHERE {condition}";
            //TEST
            //MessageBox.Show(query);
            return ExecuteQuery(query);
        }

        //ham select voi join 
        public DataTable SelectJoin(string table, string fields, string JoinQuerys)
        {
            string query = $"SELECT {fields} FROM {table} {JoinQuerys}";
            //TEST
            //MessageBox.Show(query);
            return ExecuteQuery(query);
        }

        //ham count 
        public int Count(string table, string condition)
        {
            string query = $"SELECT COUNT(*) FROM {table} WHERE {condition}";
            return Convert.ToInt32(ExecuteScalar(query));
        }

        //ham count all
        public int Count(string table)
        {
            string query = $"SELECT COUNT(*) FROM {table}";
            return Convert.ToInt32(ExecuteScalar(query));
        }

        //ham insert
        public int Insert(string table, string fields, string values)
        {
            string query = $"INSERT INTO {table}({fields}) VALUES ({values})";
            return ExecuteNonQuery(query);
            //Ex: string fields = "name, age";
            //string values = "'abc', 20";
            //Insert("table", fields, values);
        }
        public bool Insert(string table, Dictionary<string, string> data)
        {
            if (data == null || data.Count == 0) return false;
            string fields = string.Join(", ", data.Keys);
            string values = string.Join(", ", data.Values.Select(v => $"'{v.Replace("'", "''")}'"));
            string query = $"INSERT INTO {table} ({fields}) VALUES ({values})";

            MessageBox.Show(query);
            int result = ExecuteNonQuery(query);
            
            return result > 0;
        }

        //ham update
        public int Update(string table, string updates, string condition)
        {
            string query = $"UPDATE {table} SET {updates} WHERE {condition}";
            return ExecuteNonQuery(query);
            //Ex: string updates = "name = 'abc', age = 20";
            //Update("table", updates, "id = 1");
        }

        //ham delete
        public bool Delete(string table, string condition)
        {
            string query = $"DELETE FROM {table} WHERE {condition}";
            return ExecuteNonQuery(query) > 0;
            //Ex: Delete("table", "id = 1");
        }
         //public bool Delete(string table, string condition) { string query = $"DELETE FROM {table} WHERE {condition}"; return ExecuteNonQuery(query) > 0; //Ex: Delete("table", "id = 1"); }


        //---------------------------------------------------------------------


    }
}

