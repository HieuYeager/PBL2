using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QLDon;
namespace PBL2.Views.MenuPage
{
    public partial class DonCTHComp : UserControl
    {
        //presenter
        private QLDonPresenter Presenter {get;set;}
        //modle
        private HoaDon hoaDon { get; set; }

        public DonCTHComp()
        {
            InitializeComponent();
        }
        public DonCTHComp(HoaDon hoaDon, QLDonPresenter menuPagePresenter)
        {
            InitializeComponent();

            this.Presenter = menuPagePresenter;
            this.hoaDon = hoaDon;

            this.labelMaHD.DataBindings.Add("Text", this.hoaDon, "MaHD");
            this.labelThanhTien.DataBindings.Add("Text", this.hoaDon, "ThanhTien", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");
            //this.labelTrangThai.DataBindings.Add("Text", this.hoaDon, "TrangThai");
            this.labelTrangThai.Text = this.hoaDon.TrangThai.GetDisplayName();

        }

        private void ThanhToanBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.loadThanhToanPage(this.hoaDon);
        }
    }
}
