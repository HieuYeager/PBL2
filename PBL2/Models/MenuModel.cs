using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class MenuModel
    {
        public List<MonModel> mons = new List<MonModel>();

        public List<DanhMuc> danhmuc = new List<DanhMuc>();

        public String FindName { get; set; }

        public int FindDanhMucID { get; set; }
    }
}
