using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class NguyenLieu
    {
        public string MaNguyenLieu { get; set; } // CHAR(36) PK
        public string TenNguyenLieu { get; set; } // varchar(30)
        public decimal? SoLuong { get; set; }     // decimal
        public DateTime? NgayTao { get; set; }    // datetime
        public DateTime? NgayCapNhat { get; set; } // datetime
    }

}
