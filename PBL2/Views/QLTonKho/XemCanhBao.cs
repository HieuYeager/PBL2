using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Data;

namespace PBL2.Views.QLTonKho
{
    public partial class XemCanhBao : Form
    {
        public XemCanhBao()
        {
            InitializeComponent();
        }

        public void SetDataSource(List<NguyenLieuTonKho> dtCanhBao)
        {
            if (dataGridView1 != null)
            {
                this.dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dtCanhBao;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns["DonVi"].Visible = false;
                dataGridView1.Columns["MaNguyenLieu"].HeaderText = "";
                dataGridView1.Columns["MaNguyenLieu"].FillWeight = 5;
                dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
                dataGridView1.Columns["TenNguyenLieu"].FillWeight = 30;
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
                dataGridView1.Columns["SoLuong"].FillWeight = 20;
                dataGridView1.Columns["DonViStr"].HeaderText = "";
                dataGridView1.Columns["DonViStr"].FillWeight = 5;
                dataGridView1.Columns["MucCanhBao"].HeaderText = "Mức cảnh báo";
                dataGridView1.Columns["MucCanhBao"].FillWeight = 20;
                dataGridView1.Columns["NgayCapNhat"].HeaderText = "Ngày Cập Nhật";
                dataGridView1.Columns["NgayCapNhat"].FillWeight = 20;
            }
            else
            {
                MessageBox.Show("Lỗi: Control dataGridView1 chưa được khởi tạo.");
            }
        }
    }
}
