using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class LichSuTonKhos
    {
        // table name
        public static string TableName = "LichSuTonKho";
        // table fields
        public static string ID = "ID";
        public static string MaNV = "MaNV";
        public static string MaNguyenLieu = "MaNguyenLieu";
        public static string HoatDong = "HoatDong";
        public static string SoLuong = "SoLuong";
        public static string ghiChu = "ghiChu";
        public static string Ngay = "Ngay";

        // ADD
        public static int Add(LichSuTonKho item)
        {
            string sql = $"INSERT INTO {TableName} ({MaNV}, {MaNguyenLieu}, {HoatDong}, {SoLuong}, {ghiChu}, {Ngay}) " +
                         $"VALUES ('{item.MaNV}', '{item.MaNguyenLieu}', '{item.HoatDong.GetDisplayName()}', '{item.SoLuong.ToString(CultureInfo.InvariantCulture)}', " +
                         $"{(item.ghiChu != null ? $"'{item.ghiChu}'" : "NULL")}, '{item.Ngay.ToString("yyyy-MM-dd HH:mm:ss")}')";
            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(LichSuTonKho item)
        {
            string sql = $"UPDATE {TableName} SET " +
                         $" {MaNV}='{item.MaNV}', {MaNguyenLieu}='{item.MaNguyenLieu}', {HoatDong}='{item.HoatDong.GetDisplayName()}', " +
                         $" {SoLuong}='{item.SoLuong.ToString(CultureInfo.InvariantCulture)}', {ghiChu}={(item.ghiChu != null ? $"'{item.ghiChu}'" : "NULL")}, " +
                         $" {Ngay}='{item.Ngay.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                         $" WHERE {ID}={item.ID}";
            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(LichSuTonKho item)
        {
            string sql = $"DELETE FROM {TableName} WHERE {ID}={item.ID}";
            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<LichSuTonKho> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY ID
        public static LichSuTonKho Get(int id)
        {
            LichSuTonKho item = null;
            string sql = $"SELECT * FROM {TableName} WHERE {ID}={id} LIMIT 1";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            if (reader.Read())
            {
                try
                {
                    string hoatDongStr = reader["HoatDong"].ToString();
                    EnumHoatDong hd;
                    if (hoatDongStr == EnumHoatDong.NhapKho.GetDisplayName()) hd = EnumHoatDong.NhapKho;
                    else hd = EnumHoatDong.XuatKho;

                    item = new LichSuTonKho
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        MaNV = reader["MaNV"].ToString(),
                        MaNguyenLieu = reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        HoatDong = hd,
                        SoLuong = reader.GetDecimal(reader.GetOrdinal("SoLuong")),
                        ghiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader["ghiChu"].ToString(),
                        Ngay = reader.GetDateTime(reader.GetOrdinal("Ngay"))
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Get() - LichSuTonKhos error: " + e.Message);
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
        public static List<LichSuTonKho> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<LichSuTonKho>();
            while (reader.Read())
            {
                try
                {
                    // Chuyển đổi string từ DB sang enum (an toàn với NULL)
                    string hoatDongStr = reader.IsDBNull(reader.GetOrdinal("HoatDong")) ? null : reader["HoatDong"].ToString();
                    EnumHoatDong hd;
                    if (hoatDongStr == EnumHoatDong.NhapKho.GetDisplayName()) hd = EnumHoatDong.NhapKho;
                    else hd = EnumHoatDong.XuatKho;

                    list.Add(new LichSuTonKho
                    {
                        ID = reader.IsDBNull(reader.GetOrdinal("ID")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID")),
                        MaNV = reader.IsDBNull(reader.GetOrdinal("MaNV")) ? null : reader["MaNV"].ToString(),
                        MaNguyenLieu = reader.IsDBNull(reader.GetOrdinal("MaNguyenLieu")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaNguyenLieu")),
                        HoatDong = hd,
                        SoLuong = reader.IsDBNull(reader.GetOrdinal("SoLuong")) ? 0m : reader.GetDecimal(reader.GetOrdinal("SoLuong")),
                        ghiChu = reader.IsDBNull(reader.GetOrdinal("ghiChu")) ? null : reader["ghiChu"].ToString(),
                        Ngay = reader.IsDBNull(reader.GetOrdinal("Ngay")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("Ngay"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - LichSuTonKhos error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }
    }
}
