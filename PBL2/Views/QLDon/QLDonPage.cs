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
using PBL2.Data;
using PBL2.Views.MenuPage;

namespace PBL2.Views.QLDon
{
    public partial class QLDonPage : UserControl, IQLDonPage
    {
        public QLDonPresenter Presenter { get; set; }

        //loadPageThanhToan
        public delegate void LoadPageThanhToan(Data.HoaDon hoaDon, Data.NhanVien acc);
        public LoadPageThanhToan loadThanhToan_Handler { get; set; }

        private HoaDon SelectedHoaDon { get; set; }

        private NhanVien nhanVien { get; set; }

        //bien
        private string maHD
        {
            get
            {
                return this.txtMaHD.Text;
            }
            set
            {
                this.txtMaHD.Text = value;
            }
        }

        private int soBan
        {
            get
            {
                try
                {
                    return int.Parse(this.txtSoBan.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                this.txtSoBan.Text = value.ToString();
            }
        }
        public QLDonPage(NhanVien acc)
        {
            InitializeComponent();
            //presenter = new QLDonPresenter(this);
            this.Presenter = new QLDonPresenter(this);

            this.nhanVien = acc;

            this.DangLamBtn.PerformClick();
            //an panel detail
            //this.PanelDetail.Visible = false;
        }
        //events
        private void ChuaThanhToanBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonChuaThanhToan();
        }

        private void DangLamBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonDangLam();
        }

        private void SanSangBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.LoadAllHoaDonSanSang();
        }

        //-----------------
        private void LamXongBtn_Click(object sender, EventArgs e)
        {
            if (this.SelectedHoaDon != null) return;
            this.Presenter.lamXongMon(this.SelectedHoaDon);
        }

        private void dataGridViewMons_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= this.dataGridViewMons.Rows.Count)
            {
                return;
            }
            try
            {
                ChiTietHoaDon mon = this.dataGridViewMons.Rows[e.RowIndex].DataBoundItem as ChiTietHoaDon;

                this.Presenter.LoadCongThuc(mon.MaMon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải công thức: " + ex.Message);

            }
        }

        //interface methods
        public void loadTatCaDonHang(List<HoaDon> hoaDons)
        {
            this.PanelHD.Controls.Clear();
            if(hoaDons == null || hoaDons.Count == 0)
            {
                return;
            }
            EnumTrangThai trangThai = EnumTrangThai.ChuaThanhToan;
            trangThai = hoaDons[0].TrangThai;

            if (trangThai == EnumTrangThai.ChuaThanhToan)
                foreach (HoaDon hd in hoaDons)
                {
                    DonCTTComp donCTHComp = new DonCTTComp(hd, this.Presenter);
                    this.PanelHD.Controls.Add(donCTHComp);
                }

            if (trangThai == EnumTrangThai.DangLam)
                foreach (HoaDon hd in hoaDons)
                {
                    DonDLComp donCTHComp_DangLam = new DonDLComp(hd, this.Presenter);
                    this.PanelHD.Controls.Add(donCTHComp_DangLam);
                }

            if (trangThai == EnumTrangThai.SanSang)
                foreach (HoaDon hd in hoaDons)
                {
                    DonDSSComp donCTHComp_SanSang = new DonDSSComp(hd, this.Presenter);
                    this.PanelHD.Controls.Add(donCTHComp_SanSang);
                }
        }

        public void loadChiTietDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons)
        {
            this.maHD = hoaDon.MaHD;
            this.soBan = hoaDon.MaBan.HasValue ? hoaDon.MaBan.Value : 0;
            //load data grid view
            this.dataGridViewMons.Columns.Clear();
            this.dataGridViewMons.DataSource = null;
            this.dataGridViewMons.DataSource = chiTietHoaDons;
            //rename column
            this.dataGridViewMons.Columns["MaHD"].Visible = false;
            this.dataGridViewMons.Columns["MaMon"].Visible = false;
            this.dataGridViewMons.Columns["DonGia"].Visible = false;
            this.dataGridViewMons.Columns["TongTien"].Visible = false;
            this.dataGridViewMons.Columns["TenMon"].HeaderText = "Tên món";
            this.dataGridViewMons.Columns["TenMon"].FillWeight = 80;
            this.dataGridViewMons.Columns["SoLuong"].HeaderText = "Số lượng";
            this.dataGridViewMons.Columns["SoLuong"].FillWeight = 20;
            this.dataGridViewMons.Columns["DonGia"].HeaderText = "Giá bán";
            this.dataGridViewMons.Columns["TongTien"].HeaderText = "Tổng tiền";
            //format
            this.dataGridViewMons.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
            this.dataGridViewMons.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 VNĐ";

        }

        public void loadThanhToanPage(HoaDon hoaDon)
        {
            this.loadThanhToan_Handler?.Invoke(hoaDon, this.nhanVien);
        }

        public void loadCongThuc(List<CongThuc> congThucs)
        {
            this.dataGridViewCongthuc.Columns.Clear();
            this.dataGridViewCongthuc.DataSource = congThucs;

            this.dataGridViewCongthuc.Columns["MaMon"].Visible = false;
            this.dataGridViewCongthuc.Columns["MaNguyenLieu"].Visible = false;
            this.dataGridViewCongthuc.Columns["TenMon"].Visible = false;
            this.dataGridViewCongthuc.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
            this.dataGridViewCongthuc.Columns["TenNguyenLieu"].FillWeight = 60;
            this.dataGridViewCongthuc.Columns["SoLuong"].HeaderText = "Số lượng";
            this.dataGridViewCongthuc.Columns["SoLuong"].FillWeight = 20;
            this.dataGridViewCongthuc.Columns["DonViStr"].HeaderText = "";
            this.dataGridViewCongthuc.Columns["DonViStr"].FillWeight = 10;
        }
    }
}
