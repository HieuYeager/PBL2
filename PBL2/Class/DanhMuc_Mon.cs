using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class DanhMuc_Mon
    {
        // Composite PK: MaMon + MaDM
        public int MaMon { get; set; }             // INT FK -> Mon
        public int MaDM { get; set; }              // INT FK -> DanhMuc
    }

}
