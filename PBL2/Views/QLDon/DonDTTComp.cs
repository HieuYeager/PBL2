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
    public partial class DonDTTComp : UserControl
    {
        //presenter
        private QLDonPresenter Presenter {get;set;}
        //modle
        private HoaDon hoaDon { get; set; }

        public DonDTTComp()
        {
            InitializeComponent();
        }
        public DonDTTComp(HoaDon hoaDon, QLDonPresenter menuPagePresenter)
        {
            InitializeComponent();

            this.Presenter = menuPagePresenter;
            this.hoaDon = hoaDon;

            this.labelMaHD.DataBindings.Add("Text", this.hoaDon, "MaHD");
            this.labelThanhTien.DataBindings.Add("Text", this.hoaDon, "ThanhTien", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");
            //this.labelTrangThai.DataBindings.Add("Text", this.hoaDon, "TrangThai");
            this.labelTrangThai.Text = this.hoaDon.TrangThai.GetDisplayName();

        }

        private void CheBienBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.batDauLamMon(this.hoaDon);
        }

        private void HuyDonBtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này?", "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //update trang thai
                bool result = this.Presenter.huyDon(this.hoaDon);
                if (result)
                {
                    Console.WriteLine("Hủy đơn hàng thành công");
                }              
            }
        }

        private void ChiTietBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.loadChiTietDon(this.hoaDon);
        }
    }
}
