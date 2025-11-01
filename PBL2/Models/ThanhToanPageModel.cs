using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class ThanhToanPageModel
    {
        AccountModel acc { get; set; }
        OrderModel order { get; set; }

        public ThanhToanPageModel(AccountModel acc, OrderModel order)
        {
            this.acc = acc;
            this.order = order;
        }
    }
}
