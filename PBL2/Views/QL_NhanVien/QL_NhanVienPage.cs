//--------------------Hai--------------------
//--------------------Hai--------------------
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_NhanVien;
using PBL2.Views.QL_Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QL_NhanVien
{
    public partial class QL_NhanVienPage : UserControl, IView<QL_NhanVienPresenter, QL_NhanVienPageModel>
    {

        public QL_NhanVienPresenter Presenter { get; set; }

        public QL_NhanVienPageModel Model { get; set; }

        //page phu
        public delegate void LoadPhanCaDelegate(QL_NhanVienPresenter presenter);
        public LoadPhanCaDelegate LoadPhanCaHandler { get; set; }

        public QL_NhanVienPage()
        {
            InitializeComponent();
            this.Presenter = new QL_NhanVienPresenter(this);
            this.Model = this.Presenter.Model;

            this.LoadTableNV();

            // Bắt sự kiện click nút trong DataGridView
            //this.dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            this.dataGridView1.CellClick += dataGridView1_CellContentClick;
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

                this.dataGridView1.Columns["khoa"].HeaderText = "Khóa";
                this.dataGridView1.Columns["khoa"].FillWeight = 40;
                this.dataGridView1.Columns["khoa"].Visible = false;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            string imagePath = Path.Combine(MySQL_DB.projectRoot, "Resources", "edit_icon.png");

            this.dataGridView1.ShowCellToolTips = true;
            //Cột SỬA
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = "EditColumn";
            editButtonColumn.HeaderText = "";
            editButtonColumn.Text = "Sửa";
            editButtonColumn.UseColumnTextForButtonValue = false;
            editButtonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //Cột XÓA
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteColumn";
            deleteButtonColumn.HeaderText = "";
            deleteButtonColumn.Text = "Xóa";
            deleteButtonColumn.UseColumnTextForButtonValue = false;
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

            this.Presenter.search(keyword);

            this.dataGridView1.DataSource = this.Model.Table;
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

                this.DeleteNhanVienDataColumn_Click(maNV, tenNV);
                return;
            }

            //xử lý sự kiện nút SỬA
            if (columnName == "EditColumn")
            {
                this.UpdateNhanVienDataColumn_Click();
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
            try {
                this.txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                this.txtTen.Text = row.Cells["TenNV"].Value.ToString();
                this.comboBox1.SelectedItem = row.Cells["VaiTro"].Value.ToString();
                this.txtSDT.Text = row.Cells["SDT"].Value.ToString();
                this.txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                this.txtMucLuong.Text = row.Cells["MucLuongCoBan"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.panelDetail.Enabled = true;
            this.loadDetails(null);
            //btns
            this.AddSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTen.Focus();
        }

        private void AddNhanVienBtn_Click(object sender, EventArgs e)
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

        private void cancel(object sender, EventArgs e)
        {
            this.cancel();
        }

        private void UpdateNhanVienBtn_Click(object sender, EventArgs e)
        {
            // ktr data
            if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtMucLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //chuyển mức lương sang decimal
            if (!decimal.TryParse(txtMucLuong.Text, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien updateNhanVien = new NhanVien()
            {
                MaNV = this.txtMaNV.Text.Trim(),
                TenNV = txtTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                MucLuongCoBan = mucLuongCoBan,
                VaiTro = this.comboBox1.SelectedItem.ToString() == VaiTro.QuanLy.GetDisplayName() ? VaiTro.QuanLy : VaiTro.NhanVien
            };

            this.Presenter.UpdateNhanVien(updateNhanVien);
            this.LoadTableNV();
            this.cancel();
        }

        //function
        private void UpdateNhanVienDataColumn_Click()
        {
            this.panelDetail.Enabled = true;
            this.loadDetails(this.dataGridView1.SelectedRows[0]);
            //btns
            this.UpdateSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTen.Focus();
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

        private void DeleteNhanVienDataColumn_Click(string maNV, string tenNV)
        {

            //DeleteNhanVienForm deleteForm = new DeleteNhanVienForm(maNV, tenNV);
            //deleteForm.ShowDialog();

            //// Nếu form trả về DialogResult.OK → reload lại bảng
            //if (deleteForm.DialogResult == DialogResult.OK)
            //{
            //    this.LoadTableNV();
            //    this.cancel();
            //}

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên '{tenNV}' (Mã: {maNV})?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                this.Presenter.DeleteNhanVien(maNV);
                this.LoadTableNV();
                this.cancel();
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Vẽ nút như bình thường
                e.PaintContent(e.CellBounds);
                string imagePath = Path.Combine(MySQL_DB.projectRoot, "Resources", "edit_icon.png");
                // Load ảnh icon
                Image icon = Image.FromFile(imagePath); // Đường dẫn tới icon

                // Tính vị trí để căn giữa ảnh
                int x = e.CellBounds.Left + (e.CellBounds.Width - icon.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - icon.Height) / 2;

                // Vẽ ảnh
                e.Graphics.DrawImage(icon, new Point(x, y));

                e.Handled = true;
            }
            if (e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Vẽ nút như bình thường
                e.PaintContent(e.CellBounds);
                string imagePath = Path.Combine(MySQL_DB.projectRoot, "Resources", "close.png");
                // Load ảnh icon
                Image icon = Image.FromFile(imagePath); // Đường dẫn tới icon

                // Tính vị trí để căn giữa ảnh
                int x = e.CellBounds.Left + (e.CellBounds.Width - icon.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - icon.Height) / 2;

                // Vẽ ảnh
                e.Graphics.DrawImage(icon, new Point(x, y));

                e.Handled = true;
            }
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index)
            {
                e.ToolTipText = "Sửa";
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index)
            {
                e.ToolTipText = "Xóa";
            }
        }
        //chuyen trang
        private void btnPhanCa_Click(object sender, EventArgs e)
        {
            this.LoadPhanCaHandler?.Invoke(this.Presenter);
        }
    }
}
