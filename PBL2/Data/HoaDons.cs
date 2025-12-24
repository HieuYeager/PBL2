using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class HoaDons
    {
        // table name
        public static string TableName = "HoaDon";
        // table fields
        public static string MaHD = "MaHD";
        public static string MaNV = "MaNV";
        public static string NgayLapHD = "NgayLapHD";
        public static string ThanhTien = "ThanhTien";
        public static string MaBan = "MaBan";
        public static string TrangThai = "TrangThai";

        // ADD
        public static int Add(HoaDon hd)
        {
            string maBanValue = hd.MaBan.HasValue ? $"'{hd.MaBan.Value}'" : "NULL";
            string sql = $"INSERT INTO {TableName} ({MaHD}, {MaNV}, {NgayLapHD}, {ThanhTien}, {MaBan}, {TrangThai}) " +
                         $"VALUES ('{hd.MaHD}', '{hd.MaNV}', '{hd.NgayLapHD.ToString("yyyy-MM-dd HH:mm:ss")}', '{hd.ThanhTien.ToString(CultureInfo.InvariantCulture)}', {maBanValue}, '{hd.TrangThai.GetDisplayName()}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(HoaDon hd)
        {
            string maBanValue = hd.MaBan.HasValue ? $"'{hd.MaBan.Value}'" : "NULL";
            string sql = $"UPDATE {TableName} SET " +
                         $" {MaNV}='{hd.MaNV}', {NgayLapHD}='{hd.NgayLapHD.ToString("yyyy-MM-dd HH:mm:ss")}', {ThanhTien}='{hd.ThanhTien.ToString(CultureInfo.InvariantCulture)}', " +
                         $" {MaBan}={maBanValue}, {TrangThai}='{hd.TrangThai.GetDisplayName()}' " +
                         $" WHERE {MaHD}='{hd.MaHD}'";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(HoaDon hd)
        {
            string sql = $"DELETE FROM {TableName} WHERE {MaHD}='{hd.MaHD}'";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<HoaDon> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY MaHD
        public static HoaDon Get(string maHD)
        {
            HoaDon hd = null;
            string sql = $"SELECT * FROM {TableName} WHERE {MaHD}='{maHD}' LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    string trangThaiStr = reader["TrangThai"].ToString();
                    EnumTrangThai tt;
                    if (trangThaiStr == EnumTrangThai.ChuaThanhToan.GetDisplayName()) tt = EnumTrangThai.ChuaThanhToan;
                    else if (trangThaiStr == EnumTrangThai.DangLam.GetDisplayName()) tt = EnumTrangThai.DangLam;
                    else if (trangThaiStr == EnumTrangThai.SanSang.GetDisplayName()) tt = EnumTrangThai.SanSang;
                    else tt = EnumTrangThai.DaPhucVu;

                    int maBanVal = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaBan"));
                    int? maBanNullable = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? (int?)null : maBanVal;

                    hd = new HoaDon
                    {
                        MaHD = reader["MaHD"].ToString(),
                        MaNV = reader["MaNV"].ToString(),
                        NgayLapHD = reader.GetDateTime(reader.GetOrdinal("NgayLapHD")),
                        ThanhTien = reader.GetDecimal(reader.GetOrdinal("ThanhTien")),
                        MaBan = maBanNullable,
                        TrangThai = tt
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - HoaDons error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return hd;
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
        public static List<HoaDon> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<HoaDon>();
            while (reader.Read())
            {
                try
                {
                    // TrangThai (enum) safe mapping
                    string trangThaiStr = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? null : reader["TrangThai"].ToString();
                    EnumTrangThai tt;
                    if (trangThaiStr == EnumTrangThai.ChuaThanhToan.GetDisplayName()) tt = EnumTrangThai.ChuaThanhToan;
                    else if (trangThaiStr == EnumTrangThai.DangLam.GetDisplayName()) tt = EnumTrangThai.DangLam;
                    else if (trangThaiStr == EnumTrangThai.SanSang.GetDisplayName()) tt = EnumTrangThai.SanSang;
                    else tt = EnumTrangThai.DaPhucVu;

                    // MaBan nullable
                    int? maBanNullable = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaBan"));

                    list.Add(new HoaDon
                    {
                        MaHD = reader.IsDBNull(reader.GetOrdinal("MaHD")) ? null : reader["MaHD"].ToString(),
                        MaNV = reader.IsDBNull(reader.GetOrdinal("MaNV")) ? null : reader["MaNV"].ToString(),
                        NgayLapHD = reader.IsDBNull(reader.GetOrdinal("NgayLapHD")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("NgayLapHD")),
                        ThanhTien = reader.IsDBNull(reader.GetOrdinal("ThanhTien")) ? 0m : reader.GetDecimal(reader.GetOrdinal("ThanhTien")),
                        MaBan = maBanNullable,
                        TrangThai = tt
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - HoaDons error: " + e.Message);
                }
            }

            try { reader.Close(); } catch { }
            return list;
        }
    }

}
