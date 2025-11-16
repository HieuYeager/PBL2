using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Presenters.QLDon;
using PBL2.Models;
using PBL2.Class;
using PBL2.Views.MenuPage;

namespace PBL2.Views.QLDon
{
    public partial class QLDonPage : UserControl, IView<QLDonPresenter, QLDonModel>
    {
        public QLDonPresenter Presenter { get; set; }
        public QLDonModel Model { get; set; }

        //AccountModel
        public AccountModel AccountModel { get; set; }
        //loadPageThanhToan
        public delegate void LoadPageThanhToan(OrderModel hoaDon, AccountModel acc);
        public LoadPageThanhToan loadThanhToan_Handler { get; set; }

        public QLDonPage(AccountModel acc)
        {
            InitializeComponent();
            //presenter = new QLDonPresenter(this);
            this.Presenter = new QLDonPresenter(this);
            this.Model = this.Presenter.Model;

            this.AccountModel = acc;

            this.ChuaThanhToanBtn.PerformClick();
        }
        //events
        private void ChuaThanhToanBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonChuaThanhToan();
            this.loadAllDonHang();
        }

        private void DangChoBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonDaThanhToan();
            this.loadAllDonHang();
        }

        private void DangLamBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonDangLam();
            this.loadAllDonHang();
        }

        private void SanSangBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonSanSang();
            this.loadAllDonHang();
        }
        //load
        public void loadAllDonHang() {

            if (this.Model.HoaDons == null) return;
            this.PanelHD.Controls.Clear();
            foreach (HoaDon hd in this.Model.HoaDons)
            {
                DonCTHComp donCTHComp = new DonCTHComp(hd, this.Presenter);
                this.PanelHD.Controls.Add(donCTHComp);
            }
        }

        //load thanh toan form component
        public void DonCTHComp_LoadThanhToan(HoaDon hoaDon)
        {
            //chuyen hoa don sang oredermodel
            OrderModel orderModel = new OrderModel(hoaDon);
            //invoke event
            this.loadThanhToan_Handler?.Invoke(orderModel, this.AccountModel);
        }
    }
}
