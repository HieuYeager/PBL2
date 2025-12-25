using MySql.Data.MySqlClient;
using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Hai--------------------


namespace PBL2.Models
{
    public class QL_NhanVienPageModel
    {
        public DataTable Table { get; set; }

        //phan ca
        public DataTable CaLamViec { get; set; }

        //diem danh
        public DataTable DiemDanh { get; set; }

        //code moi
        public List<NhanVien> GetNhanVienTable(NhanVien acc)
        {
            if(acc.VaiTro == EnumVaiTro.Admin)
            {
                MySqlDataReader reader = NhanViens.select().Where($"{NhanViens.VaiTro} != '{EnumVaiTro.Admin.GetDisplayName()}'").ExecuteToDataReader();
                return NhanViens.ToList(reader);
            }
            else if(acc.VaiTro == EnumVaiTro.QuanLy)
            {
                MySqlDataReader reader = NhanViens.select()
                    .Where($"{NhanViens.VaiTro} != '{EnumVaiTro.QuanLy.GetDisplayName()}' AND {NhanViens.VaiTro} != '{EnumVaiTro.Admin.GetDisplayName()}'")
                    .ExecuteToDataReader();
                return NhanViens.ToList(reader);
            }
            else
            {
                return new List<NhanVien>();
            }
        }

        public List<NhanVien> GetNhanVienTable(NhanVien acc, string key)
        {
            string Condition = $" ({NhanViens.TenNv} LIKE '%{key}%' OR {NhanViens.MaNV} LIKE '%{key}%' OR {NhanViens.SDT} LIKE '%{key}%') ";
            if (acc.VaiTro == EnumVaiTro.Admin)
            {
                MySqlDataReader reader = NhanViens.select().Where($"{NhanViens.VaiTro} != '{EnumVaiTro.Admin.GetDisplayName()}' AND {Condition}").ExecuteToDataReader();
                return NhanViens.ToList(reader);
            }
            else if (acc.VaiTro == EnumVaiTro.QuanLy)
            {
                MySqlDataReader reader = NhanViens.select()
                    .Where($"{NhanViens.VaiTro} != '{EnumVaiTro.QuanLy.GetDisplayName()}' AND {NhanViens.VaiTro} != '{EnumVaiTro.Admin.GetDisplayName()}' AND {Condition}")
                    .ExecuteToDataReader();
                return NhanViens.ToList(reader);
            }
            else
            {
                return new List<NhanVien>();
            }
        }

        public bool AddNhanVien(NhanVien nhanVien)
        {
            return NhanViens.Add(nhanVien) > 0;
        }

        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            return NhanViens.Update(nhanVien) > 0;
        }

        public bool DeleteNhanVien(NhanVien nhanVien)
        {
            return NhanViens.Delete(nhanVien) > 0;
        }
    }
}
