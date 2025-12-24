using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.Menu;
namespace PBL2.Views.MenuPage
{
    public partial class OrderDetailComponent : UserControl
    {
        //presenter
        private MenuPagePresenter presenter {get;set;}
        //modle
        private ChiTietHoaDon chiTietHoaDon;
        private Mon mon;

        public OrderDetailComponent()
        {
            InitializeComponent();
        }
        public OrderDetailComponent(ChiTietHoaDon chiTietHoaDon, MenuPagePresenter menuPagePresenter)
        {
            InitializeComponent();

            this.presenter = menuPagePresenter;

            this.chiTietHoaDon = chiTietHoaDon;
            this.mon = Mons.Get(this.chiTietHoaDon.MaMon);
            
            this.labelTenMon.DataBindings.Add("Text", mon, "TenMon");
            this.labelSoLuong.DataBindings.Add("Text", chiTietHoaDon, "SoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
            this.labelGia.DataBindings.Add("Text", mon, "GiaBan", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (this.presenter != null)
            {
                this.presenter.addMon(mon);
            }
        }

        private void subBtn_Click(object sender, EventArgs e)
        {
            if(this.presenter != null)
            {
                this.presenter.subMon(this.chiTietHoaDon);
            }
            if (this.chiTietHoaDon.SoLuong == 0)
            {
                this.presenter.removeMon(this.chiTietHoaDon);
                this.Dispose();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //this.orderDetailModel.monModel = null;
            if (this.presenter != null)
            {
                this.presenter.removeMon(this.chiTietHoaDon);
                this.Dispose();
            }
        }

    }
}
