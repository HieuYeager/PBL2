using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Hai--------------------
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_NhanVien;

namespace PBL2.Views.QL_NhanVien
{
    public partial class QL_NhanVienPage : UserControl, IView<QL_NhanVienPresenter, QL_NhanVienPageModel>
    {

        public QL_NhanVienPresenter Presenter { get; set; }

        public QL_NhanVienPageModel Model { get; set; }
        public QL_NhanVienPage()
        {
            InitializeComponent();
            this.Presenter = new QL_NhanVienPresenter(this);
            this.Model = this.Presenter.Model;

            this.LoadTableNV();

            // Bắt sự kiện click nút trong DataGridView
            this.dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        public void LoadTableNV()
        {
            this.Presenter.Load();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.Table;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //custom column
            try
            {
                this.dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";

                this.dataGridView1.Columns["TenNV"].HeaderText = "Tên";
                this.dataGridView1.Columns["TenNV"].FillWeight = 100;

                this.dataGridView1.Columns["VaiTro"].HeaderText = "Vai trò";
                this.dataGridView1.Columns["SDT"].HeaderText = "SĐT";

                this.dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
                this.dataGridView1.Columns["DiaChi"].FillWeight = 200;

                this.dataGridView1.Columns["MucLuongCoBan"].HeaderText = "Lương cơ bản";
                //this.dataGridView1.Columns["CaLamViec"].HeaderText = "Ca làm việc";
                this.dataGridView1.Columns["CaLamViec"].Visible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Cột SỬA
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditColumn";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "Sửa";
            editButtonColumn.UseColumnTextForButtonValue = true;
            editButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //Cột XÓA
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteColumn";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Xóa";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            deleteButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Thêm cột vào DataGridView
            this.dataGridView1.Columns.Add(editButtonColumn);
            this.dataGridView1.Columns.Add(deleteButtonColumn);

            // Đảm bảo thiết lập kéo giãn hàng và tắt hàng trống (đã hướng dẫn ở phần trước)
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //load details
            this.loadDetails(dataGridView1.Rows[0]);

            //conboBox
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nhân viên");
            comboBox1.Items.Add("Quản lý");

            if (comboBox1.SelectedItem == null)
                comboBox1.SelectedItem = "Nhân viên";
        }

        private void QL_NhanVienPage_Load(object sender, EventArgs e) {}

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string keyword = FindTxt.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống, tải lại toàn bộ bảng
                this.LoadTableNV();
                return;
            }

            string condition = $"MaNV LIKE '%{keyword}%' OR TenNV LIKE '%{keyword}%' OR SDT LIKE '%{keyword}%'";

            try
            {
                DataTable dt = MySQL_DB.Instance.Select("nhanvien", "*", condition);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return; 
            }
            loadDetails(dataGridView1.Rows[e.RowIndex]);

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Kiểm tra người dùng click vào cột "DeleteColumn"
            if (columnName == "DeleteColumn")
            {
                string maNV = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                string tenNV = dataGridView1.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();

                DeleteNhanVienForm deleteForm = new DeleteNhanVienForm(maNV, tenNV);
                deleteForm.ShowDialog();

                // Nếu form trả về DialogResult.OK → reload lại bảng
                if (deleteForm.DialogResult == DialogResult.OK)
                {
                    this.LoadTableNV();
                }
                return;
            }

            //xử lý sự kiện nút SỬA
            if (columnName == "EditColumn")
            {
                this.UpdateNhanVien();
                return;
            }
            
            this.cancel();
        }

        private void loadDetails(DataGridViewRow row)
        {
            if(row == null)
            {
                this.txtMaNV.Text = this.Presenter.GenerateMaNV();
                this.txtTen.Text = "";
                this.comboBox1.SelectedItem = "Nhân viên";
                this.txtSDT.Text = "";
                this.txtDiaChi.Text = "";
                this.txtMucLuong.Text = "";
                return;
            }

            this.txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
            this.txtTen.Text = row.Cells["TenNV"].Value.ToString();
            this.comboBox1.SelectedItem = row.Cells["VaiTro"].Value.ToString();
            this.txtSDT.Text = row.Cells["SDT"].Value.ToString();
            this.txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            this.txtMucLuong.Text = row.Cells["MucLuongCoBan"].Value.ToString();
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            this.panelDetail.Enabled = true;
            this.loadDetails(null);
            //btns
            this.AddSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTen.Focus();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            NhanVien newNhanVien = new NhanVien()
            {
                MaNV = this.txtMaNV.Text.Trim(),
                TenNV = txtTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                //MucLuongCoBan = Convert.ToDecimal(txtMucLuong.Text.Trim()),
                //VaiTro = comboBox1.SelectedItem.ToString()
                VaiTro = this.comboBox1.SelectedItem.ToString() == VaiTro.QuanLy.GetDisplayName() ? VaiTro.QuanLy : VaiTro.NhanVien
            };

            if (string.IsNullOrEmpty(newNhanVien.TenNV) || string.IsNullOrEmpty(newNhanVien.SDT) || string.IsNullOrEmpty(newNhanVien.DiaChi) || string.IsNullOrEmpty(this.txtMucLuong.Text.ToString()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(this.txtMucLuong.Text, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newNhanVien.MucLuongCoBan = mucLuongCoBan;

            this.Presenter.Add_NhanVien(newNhanVien);
            this.LoadTableNV();
            this.cancel();
        }
        private void UpdateNhanVien()
        {
            this.panelDetail.Enabled = true;
            this.loadDetails(this.dataGridView1.SelectedRows[0]);
            //btns
            this.UpdateSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTen.Focus();
        }
        private void cancel(object sender, EventArgs e)
        {
            this.cancel();
        }

        private void cancel()
        {
            this.panelDetail.Enabled = false;
            this.loadDetails(this.dataGridView1.SelectedRows[0]);
            //btns
            this.AddSubmitBtn.Visible = false;
            this.UpdateSubmitBtn.Visible = false;
            this.CancelBtn.Visible = false;
        }
    }
}
