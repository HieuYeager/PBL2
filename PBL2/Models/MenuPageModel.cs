using PBL2.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class MenuPageModel
    {
        public AccountModel account { get; set; }

        public List<MonModel> mons = new List<MonModel>();

        public List<DanhMuc> danhmuc = new List<DanhMuc>();

        public String FindName { get; set; }

        public int FindDanhMucID { get; set; }

        //order
        //public List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();
        public OrderModel order = new OrderModel();
    }
}
