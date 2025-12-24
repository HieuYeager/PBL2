using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class LichLamViecs
    {
        // table name
        public static string TableName = "LichLamViec";
        // table fields
        public static string MaNV = "MaNV";
        public static string Ngay = "Ngay";
        public static string CaLam = "CaLam";
        public static string DiemDanh = "DiemDanh";

        // ADD
        public static int Add(LichLamViec item)
        {
            string sql = $"INSERT INTO {TableName} ({MaNV}, {Ngay}, {CaLam}, {DiemDanh}) " +
                         $"VALUES ('{item.MaNV}', '{item.Ngay.ToString("yyyy-MM-dd HH:mm:ss")}', '{item.CaLam.GetDisplayName()}', '{item.DiemDanh}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        // Khóa chính: (MaNV, Ngay, CaLam)
        public static int Update(LichLamViec item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {DiemDanh}='{item.DiemDanh}' " +
                         $" WHERE {MaNV}='{item.MaNV}' AND {Ngay}='{item.Ngay.ToString("yyyy-MM-dd HH:mm:ss")}' AND {CaLam}='{item.CaLam.GetDisplayName()}'";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(LichLamViec item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaNV}='{item.MaNV}' AND {Ngay}='{item.Ngay.ToString("yyyy-MM-dd HH:mm:ss")}' AND {CaLam}='{item.CaLam.GetDisplayName()}'";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<LichLamViec> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY MaNV + Ngay + CaLam
        public static LichLamViec Get(string maNV, DateTime ngay, EnumCaLam caLam)
        {
            LichLamViec item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaNV}='{maNV}' AND {Ngay}='{ngay.ToString("yyyy-MM-dd HH:mm:ss")}' AND {CaLam}='{caLam.GetDisplayName()}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new LichLamViec
                    {
                        MaNV = reader["MaNV"].ToString(),
                        Ngay = reader.GetDateTime(reader.GetOrdinal("Ngay")),
                        CaLam = caLam,
                        DiemDanh = reader.IsDBNull(reader.GetOrdinal("DiemDanh")) ? false : reader.GetBoolean(reader.GetOrdinal("DiemDanh"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - LichLamViecs error: " + e.Message);
                }
            }
            return item;
        }

        // SELECT (Query builder)
        public static Query select(string[] fields)
        {
            Query query = new Query().Select(fields, TableName);
            query.From(TableName);
            return query;
        }

        // SELECT ALL FIELDS
        public static Query select()
        {
            Query query = new Query().Select(new string[] { "*" }, TableName);
            query.From(TableName);
            return query;
        }

        // COUNT
        public static int Count()
        {
            string sql = $"SELECT COUNT(*) FROM {TableName}";
            return (int)DB.ExecuteScalar(sql);
        }

        public static int Count(string condition)
        {
            string sql = $"SELECT COUNT(*) FROM {TableName} WHERE {condition}";
            return (int)DB.ExecuteScalar(sql);
        }

        // data reader to list
        public static List<LichLamViec> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<LichLamViec>();
            while (reader.Read())
            {
                try
                {
                    // Chuyển đổi string từ DB sang enum (an toàn với NULL)
                    string caLamStr = reader.IsDBNull(reader.GetOrdinal("CaLam")) ? null : reader["CaLam"].ToString();
                    EnumCaLam cl;
                    if (caLamStr == EnumCaLam.CaSang.GetDisplayName()) cl = EnumCaLam.CaSang;
                    else if (caLamStr == EnumCaLam.CaChieu.GetDisplayName()) cl = EnumCaLam.CaChieu;
                    else cl = EnumCaLam.CaToi;

                    list.Add(new LichLamViec
                    {
                        MaNV = reader.IsDBNull(reader.GetOrdinal("MaNV")) ? null : reader["MaNV"].ToString(),
                        Ngay = reader.IsDBNull(reader.GetOrdinal("Ngay")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Ngay")),
                        CaLam = cl,
                        DiemDanh = reader.IsDBNull(reader.GetOrdinal("DiemDanh")) ? false : reader.GetBoolean(reader.GetOrdinal("DiemDanh"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - LichLamViecs error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }
    }
}
