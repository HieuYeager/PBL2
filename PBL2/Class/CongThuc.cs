using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{

    public enum DonViCongThuc
    {
        Kg,
        g,
        L,
        ml
    }
    public class CongThuc
    {
        // Composite PK: MaNguyenLieu + MaMon
        public int MaNguyenLieu { get; set; }      // FK -> NguyenLieu
        public int MaMon { get; set; }             // FK -> Mon
        public decimal SoLuong { get; set; }       // decimal(13,2)
        public DonViCongThuc DonVi { get; set; }   // ENUM
    }

}
