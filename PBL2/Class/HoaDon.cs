using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{

    public enum TrangThaiHoaDon
    {
        [Display(Name = "Chưa thanh toán")]
        ChuaThanhToan,

        [Display(Name = "Đã thanh toán")]
        DaThanhToan,

        [Display(Name = "Đang làm")]
        DangLam,

        [Display(Name = "Sẵn sàng")]
        SanSang,

        [Display(Name = "Đã phục vụ")]
        DaPhucVu

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


    public class HoaDon
    {
        public string MaHD { get; set; }           // varchar(12) PK
        public string MaNV { get; set; }           // varchar(10) FK -> NhanVien
        public DateTime? NgayLapHD { get; set; }   // datetime
        public decimal ThanhTien { get; set; }     // decimal(13,2)
        public int? MaBan { get; set; }            // int
        public TrangThaiHoaDon TrangThai { get; set; } // ENUM

        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }

}
