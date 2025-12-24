using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class Mons
    {
        // table name
        public static string TableName = "Mon";
        // table fields
        public static string MaMon = "MaMon";
        public static string TenMon = "TenMon";
        public static string GiaBan = "GiaBan";
        public static string DonVi = "DonVi";
        public static string URL_anh = "URL_anh";
        public static string Khoa = "Khoa";

        // ADD (MaMon là AUTO_INCREMENT nên không chèn MaMon)
        public static int Add(Mon item)
        {
            string sql = $"INSERT INTO {TableName} ({TenMon}, {GiaBan}, {DonVi}, {URL_anh}, {Khoa}) " +
                         $"VALUES ('{item.TenMon}', '{item.GiaBan.ToString(CultureInfo.InvariantCulture)}', " +
                         $"{(item.DonVi != null ? $"'{item.DonVi}'" : "NULL")}, " +
                         $"{(item.URL_anh != null ? $"'{item.URL_anh}'" : "NULL")}, '{item.Khoa}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(Mon item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {TenMon}='{item.TenMon}', {GiaBan}='{item.GiaBan.ToString(CultureInfo.InvariantCulture)}', " +
                         $"{DonVi}={(item.DonVi != null ? $"'{item.DonVi}'" : "NULL")}, " +
                         $"{URL_anh}={(item.URL_anh != null ? $"'{item.URL_anh}'" : "NULL")}, " +
                         $"{Khoa}='{item.Khoa}' " +
                         $" WHERE {MaMon}={item.MaMon}";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(Mon item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaMon}={item.MaMon}";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<Mon> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
           
        }

        // SELECT BY MaMon
        public static Mon Get(int maMon)
        {
            Mon item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaMon}={maMon} LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    item = new Mon
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        TenMon = reader["TenMon"].ToString(),
                        GiaBan = reader.GetDecimal(reader.GetOrdinal("GiaBan")),
                        DonVi = reader.IsDBNull(reader.GetOrdinal("DonVi")) ? null : reader["DonVi"].ToString(),
                        URL_anh = reader.IsDBNull(reader.GetOrdinal("URL_anh")) ? null : reader["URL_anh"].ToString(),
                        Khoa = reader.GetBoolean(reader.GetOrdinal("Khoa"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - Mons error: " + e.Message);
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

        //data reader to list
        public static List<Mon> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<Mon>();
            while (reader.Read())
            {
                try
                {
                    list.Add(new Mon
                    {
                        MaMon = reader.GetInt32(reader.GetOrdinal("MaMon")),
                        TenMon = reader["TenMon"].ToString(),
                        GiaBan = reader.GetDecimal(reader.GetOrdinal("GiaBan")),
                        DonVi = reader.IsDBNull(reader.GetOrdinal("DonVi")) ? null : reader["DonVi"].ToString(),
                        URL_anh = reader.IsDBNull(reader.GetOrdinal("URL_anh")) ? null : reader["URL_anh"].ToString(),
                        Khoa = reader.GetBoolean(reader.GetOrdinal("Khoa"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - Mons error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }
    }

}
