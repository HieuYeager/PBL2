using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{

    public enum TrangThaiHoaDon
    {
        ChuaThanhToan,
        DaThanhToan,
        DangLam,
        SanSang,
        DaPhucVu
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
