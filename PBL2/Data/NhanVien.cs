using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Database
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public EnumVaiTro VaiTro { get; set; }
        // Property phụ để hiển thị tiếng Việt trong DataGridView
        public string VaiTroStr
        {
            get
            {
                if(VaiTro == EnumVaiTro.Admin) return EnumVaiTro.Admin.GetDisplayName();
                else if(VaiTro == EnumVaiTro.QuanLy) return EnumVaiTro.QuanLy.GetDisplayName();
                else return EnumVaiTro.NhanVien.GetDisplayName();
            }
            private set { }
        }
        public string SDT { get; set; }
        public decimal MucLuongCoBan { get; set; }

    }

    public enum EnumVaiTro
    {
        [Display(Name = "Admin")]
        Admin,
        [Display(Name = "Quản lý")]
        QuanLy,
        [Display(Name = "Nhân viên")]
        NhanVien
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            var attribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? enumValue.ToString();
        }
    }
}
