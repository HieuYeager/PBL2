using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Database
{
    public enum EnumHoatDong
    {
        [Display(Name = "Nhập kho")]
        NhapKho,
        [Display(Name = "Xuất kho")]
        XuatKho
    }

    public class LichSuTonKho
    {
        public int ID { get; set; }
        public string MaNV { get; set; }
        public int MaNguyenLieu { get; set; }
        public EnumHoatDong HoatDong { get; set; }

        // Property phụ để hiển thị tiếng Việt trong DataGridView
        public string HoatDongStr
        {
            get
            {
                if (HoatDong == EnumHoatDong.NhapKho) return EnumHoatDong.NhapKho.GetDisplayName();
                else return EnumHoatDong.XuatKho.GetDisplayName();
            }
            private set { }
        }

        public decimal SoLuong { get; set; }
        public string ghiChu { get; set; }
        public DateTime Ngay { get; set; }
    }

}
