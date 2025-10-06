using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class MonModel: IModel
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public decimal DonGia { get; set; }
    }
}
