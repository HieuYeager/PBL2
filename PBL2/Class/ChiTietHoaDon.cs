using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class ChiTietHoaDon
    {
        public string MaHD { get; set; }    // varchar(10) part of PK, FK -> HoaDon.MaHD
        public string MaMon { get; set; }   // CHAR(36) part of PK, FK -> Mon.MaMon
        public int? SoLuong { get; set; }   // int
        public decimal? DonGia { get; set; } // decimal
        public string TongTien { get; set; } // varchar(30)
    }

}
