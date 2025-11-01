using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public enum VaiTro
    {
        NhanVien,
        QuanLy
    }

    public class NhanVien
    {
        public string MaNV { get; set; }           // varchar(10) PK
        public string TenNV { get; set; }          // varchar(30)
        public VaiTro VaiTro { get; set; }         // ENUM
        public string SDT { get; set; }            // varchar(15)
        public string DiaChi { get; set; }         // varchar(200)
        public decimal? MucLuongCoBan { get; set; } // decimal(13,2)
        public string CaLamViec { get; set; }      // varchar(30)

        // Navigation-like collections (optional for plain POCO)
        public List<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
        public List<LichSuTonKho> LichSuTonKhos { get; set; } = new List<LichSuTonKho>();
    }

}
