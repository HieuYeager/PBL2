using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class Mon
    {
        public int MaMon { get; set; }             // INT AUTO_INCREMENT PK
        public string TenMon { get; set; }         // varchar(30)
        public decimal GiaBan { get; set; }        // decimal(13,2)
        public string DonVi { get; set; }          // varchar(10)
        public string URL_anh { get; set; }        // varchar(255)

        public List<CongThuc> CongThucs { get; set; } = new List<CongThuc>();
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
        public List<DanhMuc_Mon> DanhMucMons { get; set; } = new List<DanhMuc_Mon>();
    }


}
