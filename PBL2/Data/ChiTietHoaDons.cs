using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class ChiTietHoaDons
    {
        // table name
        public static string TableName = "ChiTietHoaDon";
        // table fields
        public static string MaHD = "MaHD";
        public static string MaMon = "MaMon";
        public static string SoLuong = "SoLuong";
        public static string DonGia = "DonGia";

        // ADD
        public static int Add(ChiTietHoaDon item)
        {
            string sql = $"INSERT INTO {TableName} ({MaHD}, {MaMon}, {SoLuong}, {DonGia}) " +
                         $"VALUES ('{item.MaHD}', '{item.MaMon}', '{item.SoLuong}', '{item.DonGia.ToString(CultureInfo.InvariantCulture)}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(ChiTietHoaDon item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {SoLuong}='{item.SoLuong}', {DonGia}='{item.DonGia.ToString(CultureInfo.InvariantCulture)}' " +
                         $" WHERE {MaHD}='{item.MaHD}' AND {MaMon}='{item.MaMon}'";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(ChiTietHoaDon item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaHD}='{item.MaHD}' AND {MaMon}='{item.MaMon}'";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<ChiTietHoaDon> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY MaHD + MaMon
        public static ChiTietHoaDon Get(string maHD, int maMon)
        {
            ChiTietHoaDon item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaHD}='{maHD}' AND {MaMon}='{maMon}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new ChiTietHoaDon
                    {
                        MaHD = reader["MaHD"].ToString(),
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                        DonGia = reader.GetDecimal(reader.GetOrdinal("DonGia"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - ChiTietHoaDons error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
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
        public static List<ChiTietHoaDon> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<ChiTietHoaDon>();
            while (reader.Read())
            {
                try
                {
                    list.Add(new ChiTietHoaDon
                    {
                        MaHD = reader.IsDBNull(reader.GetOrdinal("MaHD")) ? null : reader["MaHD"].ToString(),
                        MaMon = reader.IsDBNull(reader.GetOrdinal("MaMon")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaMon")),
                        SoLuong = reader.IsDBNull(reader.GetOrdinal("SoLuong")) ? 0 : reader.GetInt32(reader.GetOrdinal("SoLuong")),
                        DonGia = reader.IsDBNull(reader.GetOrdinal("DonGia")) ? 0m : reader.GetDecimal(reader.GetOrdinal("DonGia"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - ChiTietHoaDons error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }
    }

}
