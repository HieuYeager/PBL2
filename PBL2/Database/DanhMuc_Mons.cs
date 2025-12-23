using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Database
{
    public class DanhMuc_Mons
    {
        // table name
        public static string TableName = "DanhMuc_Mon";
        // table fields
        public static string MaMon = "MaMon";
        public static string MaDM = "MaDM";

        // ADD
        public static int Add(DanhMuc_Mon item)
        {
            string sql = $"INSERT INTO {TableName} ({MaMon}, {MaDM}) " +
                         $"VALUES ('{item.MaMon}', '{item.MaDM}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        // bảng này chỉ có 2 khóa chính, Update thường không cần thiết.
        // Ở đây Update sẽ "cập nhật" MaDM (không khuyến nghị thay đổi khóa chính trong thực tế).
        private static int Update(DanhMuc_Mon item)
        {
            string sql = $"UPDATE {TableName} SET {MaDM}='{item.MaDM}' " +
                         $"WHERE {MaMon}='{item.MaMon}' AND {MaDM}='{item.MaDM}'";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(DanhMuc_Mon item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaMon}='{item.MaMon}' AND {MaDM}='{item.MaDM}'";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<DanhMuc_Mon> GetAll()
        {
            var list = new List<DanhMuc_Mon>();
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            while (reader.Read())
            {
                try
                {
                    list.Add(new DanhMuc_Mon
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        MaDM = reader.GetInt32(reader.GetOrdinal("MaDM"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("GetAll() - DanhMuc_Mons error: " + e.Message);
                }
            }
            return list;
        }

        // SELECT BY MaMon + MaDM
        public static DanhMuc_Mon Get(int maMon, int maDM)
        {
            DanhMuc_Mon item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaMon}='{maMon}' AND {MaDM}='{maDM}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new DanhMuc_Mon
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        MaDM = reader.GetInt32(reader.GetOrdinal("MaDM"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - DanhMuc_Mons error: " + e.Message);
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
