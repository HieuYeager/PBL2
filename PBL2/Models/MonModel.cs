using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBL2.Class;
//--------------------Huy--------------------

namespace PBL2.Models
{
    public class MonModel: IModel
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal GiaBan { get; set; }
        public string DonVi { get; set; }
        public string URLImage { get; set; }

    }
}
