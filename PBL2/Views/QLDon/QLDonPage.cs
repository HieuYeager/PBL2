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
    public partial class QLDonPage : UserControl
    {
        public QLDonPresenter Presenter { get; set; }
        public QLDonModel Model { get; set; }

        private HoaDon SelectedHoaDon { get; set; }
        //AccountModel
        public AccountModel AccountModel { get; set; }
        //loadPageThanhToan
        public delegate void LoadPageThanhToan(Data.HoaDon hoaDon, Data.NhanVien acc);
        public LoadPageThanhToan loadThanhToan_Handler { get; set; }

        public QLDonPage(AccountModel acc)
        {
            InitializeComponent();
            //presenter = new QLDonPresenter(this);
            this.Presenter = new QLDonPresenter(this);
            this.Model = this.Presenter.Model;

            this.AccountModel = acc;

            this.DangChoBtn.PerformClick();
            //an panel detail
            //this.PanelDetail.Visible = false;
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

        //-----------------
        private void LamXongBtn_Click(object sender, EventArgs e)
        {
            if (this.SelectedHoaDon != null) return;
            this.Presenter.lamXongMon(this.SelectedHoaDon);
        }

        private void dataGridViewMons_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.RowIndex >= this.dataGridViewMons.Rows.Count)
            {
                return;
            }
            int maMon = this.dataGridViewMons.Rows[e.RowIndex].Cells["maMon"].Value != DBNull.Value ?
                Convert.ToInt32(this.dataGridViewMons.Rows[e.RowIndex].Cells["maMon"].Value) : -1;
            if (maMon == -1) return;

            this.Presenter.LoadCongThuc(maMon);
        }
        //load
        public void loadAllDonHang() {

            this.PanelHD.Controls.Clear();
            if (this.Model.HoaDons == null || this.Model.HoaDons.Count == 0)
            {
                return;
            }

            TrangThaiHoaDon trangThai = TrangThaiHoaDon.ChuaThanhToan;
            trangThai = this.Model.HoaDons[0].TrangThai;
            
            if (trangThai == TrangThaiHoaDon.ChuaThanhToan)
            foreach (HoaDon hd in this.Model.HoaDons)
            {
                DonCTTComp donCTHComp = new DonCTTComp(hd, this.Presenter);
                this.PanelHD.Controls.Add(donCTHComp);
            }

            if(trangThai ==  TrangThaiHoaDon.DangLam)
            foreach (HoaDon hd in this.Model.HoaDons)
            {
                DonDLComp donCTHComp_DangLam = new DonDLComp(hd, this.Presenter);
                this.PanelHD.Controls.Add(donCTHComp_DangLam);
            }

            if (trangThai == TrangThaiHoaDon.SanSang)
            foreach (HoaDon hd in this.Model.HoaDons)
            {
                DonDSSComp donCTHComp_SanSang = new DonDSSComp(hd, this.Presenter);
                this.PanelHD.Controls.Add(donCTHComp_SanSang);
            }

            if (trangThai == TrangThaiHoaDon.DaThanhToan)
            foreach (HoaDon hd in this.Model.HoaDons)
            {
                DonDTTComp donCTHComp_DangCho = new DonDTTComp(hd, this.Presenter);
                this.PanelHD.Controls.Add(donCTHComp_DangCho);
            }
        }

        public void loadChiTietDon(HoaDon hd)
        {
            this.SelectedHoaDon = hd;
            //load chi tiet don
            OrderModel orderModel = new OrderModel(hd);
            this.txtMaHD.Text = orderModel.MaHD;
            this.txtSoBan.Text = orderModel.maBan.ToString();

            //load data grid view
            this.dataGridViewMons.Columns.Clear();
            this.dataGridViewMons.DataSource = orderModel.orderDetails;
            try
            {
                this.dataGridViewMons.Columns["monModel"].HeaderText = "Món";
                this.dataGridViewMons.Columns["monModel"].Visible = false;
                //this.dataGridViewMons.Columns["TenMon"].DisplayIndex = 0;
                this.dataGridViewMons.Columns["maMon"].Visible = false;
                this.dataGridViewMons.Columns["TenMon"].HeaderText = "Tên Món";
                this.dataGridViewMons.Columns["giaBan"].HeaderText = "Giá Bán";
                this.dataGridViewMons.Columns["giaBan"].Visible = false;
                this.dataGridViewMons.Columns["soLuong"].HeaderText = "SL";
                this.dataGridViewMons.Columns["soLuong"].FillWeight = 20;
                this.dataGridViewMons.Columns["tongTien"].HeaderText = "Tổng Tiền";
                this.dataGridViewMons.Columns["tongTien"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ClearChiTietDon()
        {
            this.txtMaHD.Text = "";
            this.txtSoBan.Text = "";
            this.dataGridViewMons.Columns.Clear();
        }

        public void loadCongThucMon(DataTable dt)
        {
            this.dataGridViewCongthuc.Columns.Clear();
            this.dataGridViewCongthuc.DataSource = dt;

            try
            {
                //this.dataGridViewCongthuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridViewCongthuc.Columns["MaMon"].Visible = false;
                this.dataGridViewCongthuc.Columns["MaNguyenLieu"].Visible = false;
                this.dataGridViewCongthuc.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
                this.dataGridViewCongthuc.Columns["TenNguyenLieu"].FillWeight = 50;
                this.dataGridViewCongthuc.Columns["SoLuong"].HeaderText = "SL";
                this.dataGridViewCongthuc.Columns["SoLuong"].FillWeight = 30;
                this.dataGridViewCongthuc.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridViewCongthuc.Columns["DonVi"].FillWeight = 20;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        //load thanh toan form component
        public void DonCTHComp_LoadThanhToan(HoaDon hoaDon)
        {
            //chuyen hoa don sang oredermodel
            OrderModel orderModel = new OrderModel(hoaDon);
            //invoke event
            //this.loadThanhToan_Handler?.Invoke(orderModel, this.AccountModel);
        }

    }
}
