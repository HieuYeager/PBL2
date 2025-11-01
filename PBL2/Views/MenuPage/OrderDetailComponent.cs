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
using PBL2.Presenters.Menu;
namespace PBL2.Views.MenuPage
{
    public partial class OrderDetailComponent : UserControl
    {
        //presenter
        private MenuPagePresenter presenter {get;set;}
        //modle
        private OrderDetailModel orderDetailModel;
        public OrderDetailComponent()
        {
            InitializeComponent();
        }
        public OrderDetailComponent(OrderDetailModel orderDetailModel, MenuPagePresenter menuPagePresenter)
        {
            InitializeComponent();

            this.presenter = menuPagePresenter;
            this.orderDetailModel = orderDetailModel;

            this.labelTenMon.DataBindings.Add("Text", this.orderDetailModel.monModel, "TenMon");
            this.labelGia.DataBindings.Add("Text", this.orderDetailModel, "giaBan", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");
            this.labelSoLuong.DataBindings.Add("Text", this.orderDetailModel, "soLuong", true, DataSourceUpdateMode.OnPropertyChanged);
            this.labelSubTotal.DataBindings.Add("Text", this.orderDetailModel, "tongTien", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.orderDetailModel.soLuong++;
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            if(--this.orderDetailModel.soLuong < 1)
            {
                this.presenter.removeMon(this.orderDetailModel);
                this.Dispose();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //this.orderDetailModel.monModel = null;
            if (this.presenter != null)
            {
                this.presenter.removeMon(this.orderDetailModel);
                this.Dispose();
            }
        }
    }
}
