using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class ChiTietHoaDon
    {
        // Composite PK: MaHD + MaMon
        public string MaHD { get; set; }           // varchar(12) FK -> HoaDon
        public int MaMon { get; set; }             // INT FK -> Mon
        public int SoLuong { get; set; }           // int
        public decimal DonGia { get; set; }        // decimal(13,2)
        public decimal TongTien { get; set; }      // decimal(13,2)
    }

}
