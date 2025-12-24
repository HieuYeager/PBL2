//--------------------Hai--------------------

using PBL2.Class;
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
    public partial class ThanhToanPage : UserControl
    {
        private string pre_value = "0.00";
        public ThanhToanPresenter Presenter { get; set; }

        public ThanhToanPageModel Model { get; set; }

        //back to menu
        public delegate void LoadMenuPageDelegate();
        public event LoadMenuPageDelegate LoadMenuPageHandler;

        public delegate void LoadMenuPageDelegate_ClearOrder();
        public event LoadMenuPageDelegate_ClearOrder LoadMenuPageHandler_ClearOrder;

        public ThanhToanPage(AccountModel acc, OrderModel order)
        {
            InitializeComponent();

            this.Presenter = new ThanhToanPresenter(this, acc, order);
            this.Model = this.Presenter.Model;

            Load();

            this.labelTongTien.DataBindings.Add("Text", this.Model.order, "Total", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");

            this.txtTienThanhToan.DataBindings.Add("Text", this.Model, "TienThanhToan", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0");
            this.txtTienThua.DataBindings.Add("Text", this.Model, "TienThua", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0");
            this.txtMaHD.DataBindings.Add("Text", this.Model.order, "MaHD", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericMaBan.DataBindings.Add(new Binding("Value", this.Model.order, "maBan", true, DataSourceUpdateMode.OnPropertyChanged));

        }

        public void Load()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = this.Model.order.orderDetails;
            this.dataGridView1.Columns[0].Visible = false;
            //rename column
            this.dataGridView1.Columns[1].HeaderText = "Mã món";
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[2].HeaderText = "Tên món";
            this.dataGridView1.Columns[2].FillWeight = 40;
            this.dataGridView1.Columns[3].HeaderText = "Giá bán";
            this.dataGridView1.Columns[3].FillWeight = 25;
            this.dataGridView1.Columns[4].HeaderText = "Số lượng";
            this.dataGridView1.Columns[4].FillWeight = 10;
            this.dataGridView1.Columns[5].HeaderText = "Tổng tiền";
            this.dataGridView1.Columns[5].FillWeight = 25;
            //format
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "#,##0.00 VNĐ";
            this.dataGridView1.Columns[5].DefaultCellStyle.Format = "#,##0.00 VNĐ";
            //column width, fill weight
            //this.dataGridView1.Columns[1].FillWeight = 40;
            //this.dataGridView1.Columns[2].FillWeight = 25;
            //this.dataGridView1.Columns[3].FillWeight = 10;
            //this.dataGridView1.Columns[4].FillWeight = 25;

            if (this.Presenter.CheckMaHoaDon(this.Model.order.MaHD))
            {
                Console.WriteLine("Hoá đơn đã tồn tại");
                return;
            }
            this.Presenter.CreateOrder(this.Model.acc.MaNV);
        }

        //event
        private void CheckValidNumber_textChange(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                try
                {
                    if (((TextBox)sender).Text == "") return;

                    decimal a = Convert.ToDecimal(((TextBox)sender).Text);
                }
                catch (Exception ex)
                {
                    ((TextBox)sender).Text = pre_value;
                    return;
                }
                pre_value = ((TextBox)sender).Text;
            }
            else
            {
                return;
            }
        }

        private void thanhToanBtn_click(object sender, EventArgs e)
        {
            if (this.Presenter.CheckThanhToan())
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
    }
}
