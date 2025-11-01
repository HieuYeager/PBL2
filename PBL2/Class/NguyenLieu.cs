using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public enum DonViNguyenLieu
    {
        Kg,
        g,
        L,
        ml
    }

    public class NguyenLieu
    {
        public int MaNguyenLieu { get; set; }      // INT AUTO_INCREMENT PK
        public string TenNguyenLieu { get; set; }  // varchar(30)
        public DonViNguyenLieu DonVi { get; set; } // ENUM
        public decimal SoLuong { get; set; }       // decimal(13,2)
        public DateTime? NgayCapNhat { get; set; } // datetime

        public List<CongThuc> CongThucs { get; set; } = new List<CongThuc>();
        public List<LichSuTonKho> LichSuTonKhos { get; set; } = new List<LichSuTonKho>();
    }

}
