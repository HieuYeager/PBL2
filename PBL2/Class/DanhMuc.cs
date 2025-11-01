using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{

    public class DanhMuc
    {
        public int MaDM { get; set; }              // INT AUTO_INCREMENT PK
        public string TenDM { get; set; }          // varchar(30)

        public List<DanhMuc_Mon> DanhMucMons { get; set; } = new List<DanhMuc_Mon>();
    }


}
