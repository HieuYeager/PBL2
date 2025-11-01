using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public enum HoatDongTonKho
    {
        NhapKho,
        XuatKho
    }

    public class LichSuTonKho
    {
        public int ID { get; set; }                // INT AUTO_INCREMENT PK
        public int MaNguyenLieu { get; set; }      // INT FK -> NguyenLieu
        public string MaNV { get; set; }           // varchar(10) FK -> NhanVien
        public HoatDongTonKho HoatDong { get; set; } // ENUM
        public decimal SoLuong { get; set; }       // decimal(13,2)
        public string GhiChu { get; set; }         // varchar(50)
        public DateTime? Ngay { get; set; }        // datetime
    }

}
