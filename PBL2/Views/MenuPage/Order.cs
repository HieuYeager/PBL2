using PBL2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Models;
namespace PBL2.Views.MenuPage
{
    public partial class Order : UserControl
    {
        private OrderModel orderModel = new OrderModel();
        public Order()
        {
            InitializeComponent();
        }

        public void addMon(MonModel mon)
        {
            OrderDetailModel orderDetail = new OrderDetailModel();
            if (mon != null) { 
                orderDetail.monModel = mon;
                orderDetail.soLuong += 1;
                this.orderModel.orderDetails.Add(orderDetail);
                OrderDetail orderDetailView = new OrderDetail(orderDetail);
                this.panelOrder.Controls.Add(orderDetailView);
            }
        }
    }
}
