//--------------------Hai--------------------

using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.ThanhToan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.ThanhToan
{
    public partial class ThanhToanPage : UserControl, IThanhToanPage
    {
        //back to menu
        public delegate void LoadMenuPageDelegate();
        public event LoadMenuPageDelegate LoadMenuPageHandler;

        public delegate void LoadMenuPageDelegate_ClearOrder();
        public event LoadMenuPageDelegate_ClearOrder LoadMenuPageHandler_ClearOrder;

        public ThanhToanPresenter Presenter { get; set; }

        private decimal pre_value = 0;
        private decimal total = 0;
        private string MaHD { 
            get { return this.txtMaHD.Text; } 
            set { this.txtMaHD.Text = value; }
        }
        private decimal TongTien
        {
            get
            {
                return this.total;
            }
            set
            {
                this.labelTongTien.Text = value.ToString("#,##0.00 VNĐ");
                this.total = value;
            }
        }

        private decimal TienThanhToan
        {
            get
            {
                try
                {
                    if (this.txtTienThanhToan.Text == "")
                        return 0;
                    return Decimal.Parse(this.txtTienThanhToan.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                this.txtTienThanhToan.Text = value.ToString();
                //update tien thua
                this.TienThua = value - this.TongTien;
            }
        }

        private decimal TienThua
        {
            get
            {
                try
                {
                    if (this.txtTienThua.Text == "")
                        return 0;
                    return Decimal.Parse(this.txtTienThua.Text);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                this.txtTienThua.Text = value.ToString("#,##0");
            }
        }

        private int MaBan
        {
            get { return (int)this.numericMaBan.Value; }
            set { this.numericMaBan.Value = value; }
        }

        public ThanhToanPage(NhanVien acc, HoaDon order)
        {
            InitializeComponent();

            this.Presenter = new ThanhToanPresenter(this, acc, order);

            this.loadHoaDon(order);
            this.loadChiTietHoaDon(this.Presenter.GetChiTietHoaDons());

        }

        public ThanhToanPage(NhanVien acc, List<ChiTietHoaDon> chiTietHoaDons)
        {
            InitializeComponent();

            this.Presenter = new ThanhToanPresenter(this, acc);
            HoaDon order = this.Presenter.CreateOrder(acc, chiTietHoaDons);

            this.Presenter = new ThanhToanPresenter(this, acc, order);

            this.loadHoaDon(order);
            this.loadChiTietHoaDon(this.Presenter.GetChiTietHoaDons());
            //this.loadChiTietHoaDon(chiTietHoaDons);

        }

        //event
        private void CheckValidNumber_textChange(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                try
                {
                    if (((TextBox)sender).Text == "") return;

                    //decimal a = Convert.ToDecimal(((TextBox)sender).Text);
                    this.TienThanhToan = Convert.ToDecimal(((TextBox)sender).Text);
                    pre_value = this.TienThanhToan;
                }
                catch (Exception ex)
                {
                    //((TextBox)sender).Text = pre_value;
                    this.TienThanhToan = Convert.ToDecimal(pre_value);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void thanhToanBtn_click(object sender, EventArgs e)
        {
            if (this.Presenter.CheckThanhToan(this.TongTien, this.TienThanhToan))
            {
                MessageBox.Show("Thanh toán thành công");
                LoadMenuPageHandler_ClearOrder?.Invoke();
            }
            else
            {
                MessageBox.Show("Thanh toán không thành công");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            LoadMenuPageHandler?.Invoke();

        }

        private void WaitOrderBtn_Click(object sender, EventArgs e)
        {
            LoadMenuPageHandler_ClearOrder?.Invoke();
        }

        private void CancelOrderBtn_Click(object sender, EventArgs e)
        {
            this.Presenter.CancelOrder();
            LoadMenuPageHandler_ClearOrder?.Invoke();
        }

        //Iterface methods
        public void loadChiTietHoaDon(List<ChiTietHoaDon> chiTietHoaDons)
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = chiTietHoaDons;
                //rename column
                this.dataGridView1.Columns["MaHD"].Visible = false;
                this.dataGridView1.Columns["MaMon"].Visible = false;
                this.dataGridView1.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridView1.Columns["TenMon"].FillWeight = 40;
                this.dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                this.dataGridView1.Columns["SoLuong"].FillWeight = 10;
                this.dataGridView1.Columns["DonGia"].HeaderText = "Giá bán";
                this.dataGridView1.Columns["DonGia"].FillWeight = 25;
                this.dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
                this.dataGridView1.Columns["TongTien"].FillWeight = 25;
                //format
                this.dataGridView1.Columns["DonGia"].DefaultCellStyle.Format = "#,##0";
                this.dataGridView1.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 VNĐ";
            }
            catch { }
        }

        public void loadHoaDon(HoaDon hoaDon)
        {
            this.MaHD = hoaDon.MaHD;
            this.TongTien = hoaDon.ThanhTien;
            this.MaBan = hoaDon.MaBan ?? 0;
            this.TienThanhToan = 0;
            this.TienThua = 0;
        }
    }
}
