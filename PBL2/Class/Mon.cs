using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class Mon
    {
        public string MaMon { get; set; }   // CHAR(36) PK
        public string TenMon { get; set; }  // varchar(30)
        public decimal? GiaBan { get; set; } // decimal
        public string MaDM { get; set; }    // CHAR(36) FK -> DanhMuc.MaDM
        public string DonVi { get; set; }   // varchar(30)

        public string ImagePath { get; set; } = string.Empty; //ALTER TABLE Mon ADD COLUMN ImagePath TEXT;
    }

}
