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
    public partial class OrderDetail : UserControl
    {
        private OrderDetailModel orderDetailModel;
        public OrderDetail()
        {
            InitializeComponent();
        }
        public OrderDetail(OrderDetailModel orderDetailModel)
        {
            InitializeComponent();

            this.orderDetailModel = orderDetailModel;

            this.labelTenMon.DataBindings.Add("Text", this.orderDetailModel.monModel, "TenMon");
            this.labelGia.DataBindings.Add("Text", this.orderDetailModel.monModel, "DonGia");
            this.labelSoluong.DataBindings.Add("Text", this.orderDetailModel, "SoLuong");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
