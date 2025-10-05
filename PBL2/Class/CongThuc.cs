using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class CongThuc
    {
        public string MaMon { get; set; }           // CHAR(36) part of PK, FK -> Mon.MaMon
        public string MaNguyenLieu { get; set; }    // CHAR(36) part of PK, FK -> NguyenLieu.MaNguyenLieu
        public decimal? SoLuong { get; set; }       // decimal
        public string DonVi { get; set; }           // varchar(30)
    }

}
