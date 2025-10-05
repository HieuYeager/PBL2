using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class NhanVien
    {
        public string MaNV { get; set; }            // varchar(10) PK
        public string TenNV { get; set; }           // varchar(30)
        public string VaiTro { get; set; }          // varchar(20)
        public string SDT { get; set; }             // varchar(15)
        public string DiaChi { get; set; }          // varchar(200)
        public decimal? MucLuongCoBan { get; set; } // decimal
        public string CaLamViec { get; set; }       // varchar(20)
    }

}
