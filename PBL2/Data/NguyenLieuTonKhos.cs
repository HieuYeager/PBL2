using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class NguyenLieuTonKhos
    {
        // table name
        public static string TableName = "NguyenLieuTonKho";
        // table fields
        public static string MaNguyenLieu = "MaNguyenLieu";
        public static string TenNguyenLieu = "TenNguyenLieu";
        public static string SoLuong = "SoLuong";
        public static string DonVi = "DonVi";
        public static string MucCanhBao = "MucCanhBao";
        public static string NgayCapNhat = "NgayCapNhat";

        // ADD
        public static int Add(NguyenLieuTonKho item)
        {
            string sql = $"INSERT INTO {TableName} ({TenNguyenLieu}, {SoLuong}, {DonVi}, {MucCanhBao}, {NgayCapNhat}) " +
                         $"VALUES ('{item.TenNguyenLieu}', '{item.SoLuong.ToString(CultureInfo.InvariantCulture)}', '{item.DonVi.GetDisplayName()}', " +
                         $"'{item.MucCanhBao.ToString(CultureInfo.InvariantCulture)}', '{item.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(NguyenLieuTonKho item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {TenNguyenLieu}='{item.TenNguyenLieu}', {SoLuong}='{item.SoLuong.ToString(CultureInfo.InvariantCulture)}', " +
                         $" {DonVi}='{item.DonVi.GetDisplayName()}', {MucCanhBao}='{item.MucCanhBao.ToString(CultureInfo.InvariantCulture)}', " +
                         $" {NgayCapNhat}='{item.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                         $" WHERE {MaNguyenLieu}={item.MaNguyenLieu}";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(NguyenLieuTonKho item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaNguyenLieu}={item.MaNguyenLieu}";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<NguyenLieuTonKho> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);

        }

        // SELECT BY ID
        public static NguyenLieuTonKho Get(int id)
        {
            NguyenLieuTonKho item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaNguyenLieu}={id} LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    string donViStr = reader["DonVi"].ToString();
                    EnumDonVi dv;
                    if (donViStr == EnumDonVi.Ml.GetDisplayName()) dv = EnumDonVi.Ml;
                    else if (donViStr == EnumDonVi.G.GetDisplayName()) dv = EnumDonVi.G;
                    else dv = EnumDonVi.Cai;

                    item = new NguyenLieuTonKho
                    {
                        MaNguyenLieu = reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        TenNguyenLieu = reader["TenNguyenLieu"].ToString(),
                        SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong")),
                        DonVi = dv,
                        MucCanhBao = reader.GetDecimal(reader.GetOrdinal("MucCanhBao")),
                        NgayCapNhat = reader.GetDateTime(reader.GetOrdinal("NgayCapNhat"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - NguyenLieuTonKhos error: " + e.Message);
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
            return Convert.ToInt32(DB.ExecuteScalar(sql));
        }

        // data reader to list
        public static List<NguyenLieuTonKho> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<NguyenLieuTonKho>();
            while (reader.Read())
            {
                try
                {
                    // Chuyển đổi string từ DB sang enum
                    string donViStr = reader["DonVi"].ToString();
                    EnumDonVi dv;
                    if (donViStr == EnumDonVi.Ml.GetDisplayName()) dv = EnumDonVi.Ml;
                    else if (donViStr == EnumDonVi.G.GetDisplayName()) dv = EnumDonVi.G;
                    else dv = EnumDonVi.Cai;

                    list.Add(new NguyenLieuTonKho
                    {
                        MaNguyenLieu = reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        TenNguyenLieu = reader["TenNguyenLieu"].ToString(),
                        SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong")),
                        DonVi = dv,
                        MucCanhBao = reader.GetDecimal(reader.GetOrdinal("MucCanhBao")),
                        NgayCapNhat = reader.GetDateTime(reader.GetOrdinal("NgayCapNhat"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - NguyenLieuTonKhos error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }

    }

}
