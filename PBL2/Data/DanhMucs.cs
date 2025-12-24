using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class DanhMucs
    {
        // table name
        public static string TableName = "DanhMuc";
        // table fields
        public static string MaDM = "MaDM";
        public static string TenDM = "TenDM";

        // ADD (MaDM là AUTO_INCREMENT nên không chèn MaDM)
        public static int Add(DanhMuc item)
        {
            string sql = $"INSERT INTO {TableName} ({TenDM}) VALUES ({(item.TenDM != null ? $"'{item.TenDM}'" : "NULL")})";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(DanhMuc item)
        {
            string sql = $"UPDATE {TableName} SET {TenDM}={(item.TenDM != null ? $"'{item.TenDM}'" : "NULL")} WHERE {MaDM}={item.MaDM}";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(DanhMuc item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaDM}={item.MaDM}";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<DanhMuc> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY MaDM
        public static DanhMuc Get(int maDM)
        {
            DanhMuc item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaDM}={maDM} LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new DanhMuc
                    {
                        MaDM = reader.GetInt32(reader.GetOrdinal("MaDM")),
                        TenDM = reader.IsDBNull(reader.GetOrdinal("TenDM")) ? null : reader["TenDM"].ToString()
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - DanhMucs error: " + e.Message);
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
        public static List<DanhMuc> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<DanhMuc>();
            while (reader.Read())
            {
                try
                {
                    list.Add(new DanhMuc
                    {
                        MaDM = reader.IsDBNull(reader.GetOrdinal("MaDM")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaDM")),
                        TenDM = reader.IsDBNull(reader.GetOrdinal("TenDM")) ? null : reader["TenDM"].ToString()
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - DanhMucs error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }
    }

}
