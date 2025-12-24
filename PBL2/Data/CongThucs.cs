using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Database
{
    public class CongThucs
    {
        // table name
        public static string TableName = "CongThuc";
        // table fields
        public static string MaMon = "MaMon";
        public static string MaNguyenLieu = "MaNguyenLieu";
        public static string SoLuong = "SoLuong";

        // ADD
        public static int Add(CongThuc item)
        {
            string sql = $"INSERT INTO {TableName} ({MaMon}, {MaNguyenLieu}, {SoLuong}) " +
                         $"VALUES ('{item.MaMon}', '{item.MaNguyenLieu}', '{item.SoLuong.ToString(CultureInfo.InvariantCulture)}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(CongThuc item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {SoLuong}='{item.SoLuong.ToString(CultureInfo.InvariantCulture)}' " +
                         $" WHERE {MaMon}='{item.MaMon}' AND {MaNguyenLieu}='{item.MaNguyenLieu}'";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(CongThuc item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaMon}='{item.MaMon}' AND {MaNguyenLieu}='{item.MaNguyenLieu}'";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<CongThuc> GetAll()
        {
            var list = new List<CongThuc>();
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            while (reader.Read())
            {
                try
                {
                    list.Add(new CongThuc
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        MaNguyenLieu = reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("GetAll() - CongThucs error: " + e.Message);
                }
            }
            return list;
        }

        // SELECT BY MaMon + MaNguyenLieu
        public static CongThuc Get(int maMon, int maNguyenLieu)
        {
            CongThuc item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaMon}='{maMon}' AND {MaNguyenLieu}='{maNguyenLieu}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new CongThuc
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        MaNguyenLieu = reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - CongThucs error: " + e.Message);
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
    }

}
