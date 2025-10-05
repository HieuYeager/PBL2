using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class HoaDon
    {
        public string MaHD { get; set; }        // varchar(10) PK
        public DateTime? NgayLapHD { get; set; } // datetime
        public decimal? ThanhTien { get; set; }  // decimal
        public int? MaThe { get; set; }         // int
        public string MaNV { get; set; }        // varchar(10) FK -> NhanVien.MaNV
    }
}
