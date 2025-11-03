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
        private void addBtn_Click_1(object sender, EventArgs e)
        {
            AddNhanVienForm addForm = new AddNhanVienForm(this.Presenter);
            addForm.ShowDialog();
            // Reload the DataGridView after adding a new employee
            this.LoadTableNV();
        }
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
                //this.dataGridView1.Columns["TenNV"].FillWeight = 100;

                this.dataGridView1.Columns["VaiTro"].HeaderText = "Vai trò";
                this.dataGridView1.Columns["SDT"].HeaderText = "SĐT";

                this.dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
                this.dataGridView1.Columns["DiaChi"].FillWeight = 200;

                this.dataGridView1.Columns["MucLuongCoBan"].HeaderText = "Lương cơ bản";
                this.dataGridView1.Columns["CaLamViec"].HeaderText = "Ca làm việc";
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
        }

        private void QL_NhanVienPage_Load(object sender, EventArgs e) {}

        private void Label_Click(object sender, EventArgs e) {}

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
                return;

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
            }

            //xử lý sự kiện nút SỬA
            if (columnName == "EditColumn")
            {
                //lấy thông tin nhân viên từ hàng được chọn
                string maNV = dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
                string tenNV = dataGridView1.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                string sdt = dataGridView1.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
                string diaChi = dataGridView1.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                string mucLuong = dataGridView1.Rows[e.RowIndex].Cells["MucLuongCoBan"].Value.ToString();
                string vaitro = dataGridView1.Rows[e.RowIndex].Cells["VaiTro"].Value.ToString();

                //mở form sửa nhân viên
                UpdateNhanVienForm updateForm = new UpdateNhanVienForm();

                //điền thông tin nhân viên vào form
                updateForm.SetNhanVienInfo(maNV, tenNV, sdt, diaChi, mucLuong, vaitro);

                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    //nếu người dùng lưu thay đổi, reload lại bảng
                    this.LoadTableNV();
                }
            }
        }

        private void FindTxt_TextChanged(object sender, EventArgs e) {}
    }
}
