using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Database
{
    public class Accounts
    {
        //table name
        public static string TableName = "Account";
        //table fields
        public static string MaNV = "MaNV";
        public static string password = "password";
        public static string khoa = "khoa";

        // ADD
        public static int Add(Account acc)
        {
            string sql = $" INSERT INTO {TableName} ({MaNV}, {password}, {khoa})" +
                $" VALUES ('{acc.MaNV}', '{acc.password}', '{acc.khoa}') ";

            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(Account acc)
        {
            string sql = $" UPDATE {TableName} SET " +
            $" {password}='{acc.password}', {khoa}='{acc.khoa}' " +
            $"  WHERE {MaNV}='{acc.MaNV}' ";

            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(Account acc)
        {
            string sql = $" DELETE FROM {TableName} WHERE {MaNV}='{acc.MaNV}' ";

            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<Account> GetAll()
        {
            var list = new List<Account>();
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            while (reader.Read())
            {
                try
                {
                    list.Add(new Account
                    {
                        MaNV = reader["MaNV"].ToString(),
                        password = reader["password"].ToString(),
                        khoa = reader.GetBoolean(reader.GetOrdinal("khoa"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("GetAll() - Accounts error: " + e.Message);
                }
            }
            return list;
        }

        // SELECT BY MaNV
        public static Account Get(string maNV)
        {
            Account acc = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaNV}='{maNV}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    acc = new Account
                    {
                        MaNV = reader["MaNV"].ToString(),
                        password = reader["password"].ToString(),
                        khoa = reader.GetBoolean(reader.GetOrdinal("khoa"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - Accounts error: " + e.Message);
                }
            }
            return acc;
        }

        // SELECT
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

        public static int Count(String condition)
        {
            string sql = $"SELECT COUNT(*) FROM {TableName} WHERE {condition}";
            return (int)DB.ExecuteScalar(sql);
        }
    }
}
