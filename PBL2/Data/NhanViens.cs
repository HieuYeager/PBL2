using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class NhanViens
    {
        //table name
        public static string TableName = "NhanVien";
        //table fields
        public static string MaNV = "MaNV";
        public static string TenNv = "TenNV";
        public static string VaiTro = "VaiTro";
        public static string SDT = "SDT";
        public static string MucLuongCoBan = "MucLuongCoBan";

        // ADD
        public static int Add(NhanVien nv)
        {
            string sql = $" INSERT INTO {TableName} ({MaNV}, {TenNv}, {VaiTro}, {SDT}, {MucLuongCoBan}) " +
                $" VALUES ('{nv.MaNV}', '{nv.TenNV}', '{nv.VaiTro.GetDisplayName()}', '{nv.SDT}', '{nv.MucLuongCoBan}') ";

            return DB.ExecuteNonQuery(sql);
        }

        // UPDATE
        public static int Update(NhanVien nv)
        {
            string sql = $" UPDATE {TableName} SET " +
            $" {TenNv}='{nv.TenNV}', {VaiTro}='{nv.VaiTro.GetDisplayName()}', {SDT}='{nv.SDT}', {MucLuongCoBan}='{nv.MucLuongCoBan}' " +
            $" WHERE {MaNV}='{nv.MaNV}'; ";

            return DB.ExecuteNonQuery(sql);
        }

        // DELETE
        public static int Delete(NhanVien nv)
        {
            string sql = $" DELETE FROM {TableName} WHERE {MaNV}='{nv.MaNV}' ";

            return DB.ExecuteNonQuery(sql);
        }

        // SELECT ALL
        public static List<NhanVien> GetAll()
        {
            string sql = $"SELECT * FROM {TableName}";
            MySqlDataReader reader = DB.ExecuteReader(sql);
            return ToList(reader);
        }

        // SELECT BY MaNV
        public static NhanVien Get(string maNV)
        {
            return GetAll().Where(x => x.MaNV == maNV).FirstOrDefault();
            //return null;
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

        // data reader to list
        public static List<NhanVien> ToList(MySqlDataReader reader)
        {
            if (reader == null) return null;
            var list = new List<NhanVien>();
            while (reader.Read())
            {
                try
                {
                    // Chuyển đổi string từ DB sang enum
                    string vaiTroStr = reader.IsDBNull(reader.GetOrdinal("VaiTro")) ? null : reader["VaiTro"].ToString();
                    EnumVaiTro vt;
                    if (vaiTroStr == EnumVaiTro.Admin.GetDisplayName()) vt = EnumVaiTro.Admin;
                    else if (vaiTroStr == EnumVaiTro.QuanLy.GetDisplayName()) vt = EnumVaiTro.QuanLy;
                    else vt = EnumVaiTro.NhanVien;

                    list.Add(new NhanVien
                    {
                        MaNV = reader.IsDBNull(reader.GetOrdinal("MaNV")) ? null : reader["MaNV"].ToString(),
                        TenNV = reader.IsDBNull(reader.GetOrdinal("TenNV")) ? null : reader["TenNV"].ToString(),
                        VaiTro = vt,
                        SDT = reader.IsDBNull(reader.GetOrdinal("SDT")) ? null : reader["SDT"].ToString(),
                        MucLuongCoBan = reader.IsDBNull(reader.GetOrdinal("MucLuongCoBan")) ? 0m : reader.GetDecimal(reader.GetOrdinal("MucLuongCoBan"))
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("ToList() - NhanViens error: " + e.Message);
                }
            }
            try { reader.Close(); } catch { }
            return list;
        }

    }
}
