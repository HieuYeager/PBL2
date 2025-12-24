using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public enum EnumTrangThai
    {
        [Display(Name = "Chưa thanh toán")]
        ChuaThanhToan,
        [Display(Name = "Đang làm")]
        DangLam,
        [Display(Name = "Sẳn sàng")]
        SanSang,
        [Display(Name = "Đã phục vụ")]
        DaPhucVu
    }

    public class HoaDon
    {
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayLapHD { get; set; }
        public decimal ThanhTien { get; set; }
        public int? MaBan { get; set; }
        public EnumTrangThai TrangThai { get; set; }

        // Property phụ để hiển thị tiếng Việt trong DataGridView
        public string TrangThaiStr
        {
            get
            {
                if (TrangThai == EnumTrangThai.ChuaThanhToan) return EnumTrangThai.ChuaThanhToan.GetDisplayName();
                else if (TrangThai == EnumTrangThai.DangLam) return EnumTrangThai.DangLam.GetDisplayName();
                else if (TrangThai == EnumTrangThai.SanSang) return EnumTrangThai.SanSang.GetDisplayName();
                else return EnumTrangThai.DaPhucVu.GetDisplayName();
            }
            private set { }
        }
    }

}
