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
    public partial class EditNguyenLieuForm : Form
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
        NguyenLieuTonKho nguyenLieu;
        public EditNguyenLieuForm(QLTonKhoPresenter qLTonKhoPresenter, NguyenLieuTonKho nguyenLieu)
        {
            InitializeComponent();
            this.presenter = qLTonKhoPresenter;
            LoadDonVi();

            this.nguyenLieu = nguyenLieu;
            this.txtTen.Text = nguyenLieu.TenNguyenLieu;
            this.cbDonVi.SelectedItem = nguyenLieu.DonVi;
            this.numMucCB.Value = nguyenLieu.MucCanhBao;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nguyenLieu.TenNguyenLieu = this.TenNguyenLieu;
            nguyenLieu.DonVi = this.DonVi;
            nguyenLieu.MucCanhBao = this.muccanhbao;

            //MessageBox.Show($"{nguyenLieu.TenNguyenLieu} - {nguyenLieu.DonVi} - {nguyenLieu.MucCanhBao}");

            if (this.presenter.EditNguyenLieu(nguyenLieu)){
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
