using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class OrderModel
    {
        public string MaHD { get; set; }
        public List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

        public decimal Total
        {
            get { return orderDetails.Sum(x => x.tongTien); }
            private set { }
        }
    }
}
