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
    public partial class menuPage : UserControl
    {
        public delegate void ThanhToan(OrderModel order, AccountModel acc);
        public ThanhToan thanhtoanPage = null;

        //presenter
        MenuPagePresenter Presenter { get;}
        MenuPageModel Model { get; set; }
        public menuPage(AccountModel account)
        {
            InitializeComponent();

            //presenter
            this.Presenter = new MenuPagePresenter(this);
            this.Model = this.Presenter.Model;
            this.Model.account = account;
            //binding data
            this.ComboBoxDanhMuc.DataSource = Model.danhmuc;
            this.ComboBoxDanhMuc.ValueMember = "MaDM";
            this.ComboBoxDanhMuc.DisplayMember = "TenDM";

            this.FindTxt.DataBindings.Add("Text", Model, "FindName");
            this.ComboBoxDanhMuc.DataBindings.Add("SelectedValue", Model, "FindDanhMucID");

            this.loadMon();

        }
        //event

        private void buttonFind_Click(object sender, EventArgs e)
        {
            this.Presenter.timMon();
            this.loadMon();
        }

        private void buttonThanhToan_click(object sender, EventArgs e)
        {
            if(thanhtoanPage == null) return;
            thanhtoanPage?.Invoke(this.Model.order, this.Model.account);
        }
        //funtion
        public void AddOrderDetail(OrderDetailModel orderDetail)
        {
            if (orderDetail == null) return;
            //add giao dien
            OrderDetailComponent orderDetailView = new OrderDetailComponent(orderDetail, this.Presenter) { Dock = DockStyle.Top };

            this.ListOrderDetailsPn.Controls.Add(orderDetailView);
        }
        private void loadMon()
        {
            this.panelMons.Controls.Clear();
            foreach (MonModel mon in Model.mons)
            {
                MonComponent mon1 = new MonComponent(mon, this.Presenter);
                this.panelMons.Controls.Add(mon1);
            }
        }

        public void clearOrder()
        {
            this.Model.order = new OrderModel();
            this.ListOrderDetailsPn.Controls.Clear();
        }
    }
}
