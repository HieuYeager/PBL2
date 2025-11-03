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
    public partial class ThanhToanPage : UserControl, IView<ThanhToanPresenter, ThanhToanPageModel>
    {
        private string pre_value = "0.00";
        public ThanhToanPresenter Presenter { get; set; }

        public ThanhToanPageModel Model { get; set; }
        public ThanhToanPage(AccountModel acc, OrderModel order)
        {
            InitializeComponent();

            this.Presenter = new ThanhToanPresenter(this, acc, order);
            this.Model = this.Presenter.Model;

            this.labelTongTien.DataBindings.Add("Text", this.Model.order, "Total", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0.00 VNĐ");
            //
            //Binding binding = new Binding("Text", this.Model, "TienThanhToan", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0");
            //binding.Format += (s, e) => {
            //    if (decimal.TryParse(e.Value?.ToString(), out decimal result))
            //    {
            //        e.Value = result;
            //    }
            //    else
            //    {
            //        e.Value = 0m; // Gán giá trị mặc định là 0 nếu nhập sai
            //    }

            //};

            this.txtTienThanhToan.DataBindings.Add("Text", this.Model, "TienThanhToan", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0");
            this.txtTienThua.DataBindings.Add("Text", this.Model, "TienThua", true, DataSourceUpdateMode.OnPropertyChanged, "0", "#,##0");

            //foreach (OrderDetailModel item in order.orderDetails)
            //{
            //    Console.WriteLine("ten san pham:{0}, so luong: {1}, gia: {2}, tong phu:{3}",
            //        item.TenMon,
            //        item.soLuong,
            //        item.giaBan,
            //        item.tongTien);
            //}
            Load();
        }

        public void Load()
        {
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = this.Model.order.orderDetails;
            this.dataGridView1.Columns[0].Visible = false;
            //rename column
            this.dataGridView1.Columns[1].HeaderText = "Tên món";
            this.dataGridView1.Columns[2].HeaderText = "Giá bán";
            this.dataGridView1.Columns[3].HeaderText = "Số lượng";
            this.dataGridView1.Columns[4].HeaderText = "Tổng tiền";
            //format
            this.dataGridView1.Columns[2].DefaultCellStyle.Format = "#,##0.00 VNĐ";
            this.dataGridView1.Columns[4].DefaultCellStyle.Format = "#,##0.00 VNĐ";
            //column width, fill weight
            this.dataGridView1.Columns[1].FillWeight = 40;
            this.dataGridView1.Columns[2].FillWeight = 25;
            this.dataGridView1.Columns[3].FillWeight = 10;
            this.dataGridView1.Columns[4].FillWeight = 25;

            this.Presenter.CreateOrder(this.Model.acc.MaNV);
        }

        private void CheckValidNumber_textChange(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                try
                {
                    if (((TextBox)sender).Text == "") return;
                    
                    decimal a = Convert.ToDecimal(((TextBox)sender).Text);
                }catch(Exception ex)
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

    }
}
