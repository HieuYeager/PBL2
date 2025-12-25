using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.QLTonKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    public partial class AddNguyenLieuForm : Form
    {
        private string TenNguyenLieu
        {
            get
            {
                return this.txtTen.Text;
            }
            set { }
        }
        private EnumDonVi DonVi { 
            get
            {
                return (EnumDonVi)this.cbDonVi.SelectedItem;
            }
            set { }
        }
        private decimal muccanhbao {
            get
            {
                return decimal.Parse(this.numMucCB.Value.ToString());
            }
            set { }
        }

        QLTonKhoPresenter presenter;
        public AddNguyenLieuForm(QLTonKhoPresenter qLTonKhoPresenter)
        {
            InitializeComponent();
            this.presenter = qLTonKhoPresenter;
            LoadDonVi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NguyenLieuTonKho nguyenLieuMoi = new NguyenLieuTonKho
            {
                TenNguyenLieu = this.TenNguyenLieu,
                DonVi = this.DonVi,
                SoLuong = 0,
                MucCanhBao = this.muccanhbao,
                NgayCapNhat = DateTime.Now
            };
            if (this.presenter.AddNguyenLieu(nguyenLieuMoi)){
                this.Close();
            }
            else{
                this.TenNguyenLieu = "";
                this.muccanhbao = 0;
                this.cbDonVi.SelectedIndex = -1;
            }
        }

        private void LoadDonVi()
        {
            // Lấy tất cả giá trị trong enum DonViNguyenLieu
            cbDonVi.DataSource = Enum.GetValues(typeof(EnumDonVi));
            cbDonVi.SelectedIndex = -1; // không chọn mặc định
        }
    }
}
