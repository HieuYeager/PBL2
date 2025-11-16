using Mysqlx.Crud;
using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class QLDonModel
    {
        public List<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
