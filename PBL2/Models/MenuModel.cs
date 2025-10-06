using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class MenuModel: IModel
    {
        public List<MonModel> mons = new List<MonModel>();

        public List<DanhMuc> danhmuc = new List<DanhMuc>();

        public String FindName { get; set; }

        public String FindDanhMuc { get; set; }
    }
}
