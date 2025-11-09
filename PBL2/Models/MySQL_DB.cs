using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Models
{
    public class MySQL_DB
    {
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
        public bool InsertNguyenLieu(string table, Dictionary<string, object> data)
        {
            if (string.IsNullOrEmpty(table) || data == null || data.Count == 0)
                return false;

            try
            {
                // Lấy dữ liệu từ dictionary
                string ten = data.ContainsKey("TenNguyenLieu") ? data["TenNguyenLieu"].ToString().Trim() : "";
                string donVi = data.ContainsKey("DonVi") ? data["DonVi"].ToString() : "g";
                double soLuong = data.ContainsKey("SoLuong") ? Convert.ToDouble(data["SoLuong"]) : 0;

                if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(donVi)) 
                    return false;

                // Quy đổi số lượng về gram để cộng dồn
                double soLuongGram = donVi == "kg" ? soLuong * 1000 : soLuong;

                // Kiểm tra nguyên liệu đã tồn tại chưa
                string queryCheck = $"SELECT SoLuong, DonVi FROM {table} WHERE TenNguyenLieu = '{ten.Replace("'", "''")}'";
                DataTable dt = ExecuteQuery(queryCheck);

                // Nếu có rồi → xử lý cộng dồn
                if (dt.Rows.Count > 0)
                {
                    // Đã tồn tại → cộng dồn
                    double soLuongHienTai = Convert.ToDouble(dt.Rows[0]["SoLuong"]); // luôn g
                    string donViHienTai = dt.Rows[0]["DonVi"].ToString();

                    // Quy đổi số lượng mới về đơn vị DB nếu khác
                    double soLuongMoiQuyDoi = soLuongGram;
                    if (donViHienTai == "kg") soLuongMoiQuyDoi /= 1000; // gram -> kg

                    double tongSoLuong = soLuongHienTai + soLuongGram;

                    string queryUpdate = $"UPDATE {table} SET SoLuong = {tongSoLuong}, NgayCapNhat = NOW() WHERE TenNguyenLieu = '{ten.Replace("'", "''")}'";
                    int result = ExecuteNonQuery(queryUpdate);

                    MessageBox.Show($"Nguyên liệu '{ten}' đã tồn tại — số lượng đã được cộng dồn!");
                    return result > 0;
                }
                else
                {
                    string queryInsert = $"INSERT INTO {table} (TenNguyenLieu, DonVi, SoLuong, NgayCapNhat) " +
                                 $"VALUES ('{ten.Replace("'", "''")}', '{donVi}', {soLuongGram}, NOW())";

                    int result = ExecuteNonQuery(queryInsert);

                    MessageBox.Show($"Đã thêm mới nguyên liệu '{ten}'!");
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nguyên liệu: {ex.Message}");
                return false;
            }
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

