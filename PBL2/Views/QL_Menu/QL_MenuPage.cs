using Google.Protobuf.WellKnownTypes;
using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.QL_Menu;
using PBL2.Views.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Bin--------------------

namespace PBL2.Views.QL_Menu
{
    public partial class QL_MenuPage : UserControl
    {
        public QL_MenuPresenter Presenter { get; set; }

        public QL_MenuPageModel Model { get; set; }
        public QL_MenuPage()
        {
            InitializeComponent();
            //presenter
            this.Presenter = new QL_MenuPresenter(this);
            //model
            this.Model = this.Presenter.Model;
            //load
            this.Presenter.LoadMenu();
            this.LoadTable();
            //SetupEventHandlers();
            //load combobox danhmuc
            List<DanhMuc> danhmucs = this.Presenter.loadDM();
            this.ComboBoxDanhMuc.DataSource = danhmucs;
            this.ComboBoxDanhMuc.ValueMember = "MaDM";
            this.ComboBoxDanhMuc.DisplayMember = "TenDM";
            this.ComboBoxDanhMuc.SelectedIndex = 0;
        }

        private string ImagePath { get; set; } = string.Empty;
        //page phu
        //private void cancel() => this.panelDetail.Enabled = false;
        public delegate void LoadQL_ConhThucPageDelegate(QL_CongThucPage qlConhThucPage);
        public LoadQL_ConhThucPageDelegate LoadQL_ConhThucPageHandler { get; set; }

        public delegate void LoadQL_PhanLoaiPageDelegate(QL_PhanLoaiPage qlPhanLoaiPage);
        public LoadQL_PhanLoaiPageDelegate LoadQL_PhanLoaiPageHandler { get; set; }
        //event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            loadDetail(dataGridView1.Rows[e.RowIndex]);

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            // Kiểm tra người dùng click vào cột "DeleteColumn"
            if (columnName == "DeleteColumn")
            {
                string maMon = dataGridView1.Rows[e.RowIndex].Cells["MaMon"].Value.ToString();
                string tenMon = dataGridView1.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();

                //this.DeleteNhanVienDataColumn_Click(maNV, tenNV);
                this.DeleteDishDataColumn_Click(maMon, tenMon);
                return;
            }

            //xử lý sự kiện nút SỬA
            if (columnName == "EditColumn")
            {
                //this.UpdateNhanVienDataColumn_Click();
                this.UpdateDishDataColumn_Click();
                return;
            }

            this.cancel();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            this.panelDetail.Enabled = true;
            this.loadDetail(null);
            //btns
            this.AddSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTenMon.Focus();
        }

        private void UpdateMonBtn_Click(object sender, EventArgs e)
        {
            // ktr data
            if (string.IsNullOrWhiteSpace(txtMaMon.Text)||string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text) || string.IsNullOrWhiteSpace(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //chuyển mức lương sang decimal
            if (!decimal.TryParse(txtGiaBan.Text, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mon mon = new Mon
            {
                MaMon = int.Parse(txtMaMon.Text),
                TenMon = txtTenMon.Text,
                GiaBan = mucLuongCoBan,
                DonVi = txtDonVi.Text,
                URL_anh = this.pictureBox1.Image != null ? Path.GetFileName(this.pictureBox1.ImageLocation) : ""
            };

            this.Presenter.EditMon(mon);
            this.LoadTable();
            this.cancel();
        }

        private void AddNhanVienBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.txtTenMon.Text) || string.IsNullOrEmpty(this.txtDonVi.Text) || string.IsNullOrEmpty(this.txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(this.txtGiaBan.Text, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Mon newMon = new Mon
            {
                TenMon = this.txtTenMon.Text,
                GiaBan = mucLuongCoBan,
                DonVi = this.txtDonVi.Text,
                URL_anh = this.pictureBox1.Image != null ? Path.GetFileName(this.pictureBox1.ImageLocation) : "",
                Khoa = false
                
            };

            this.Presenter.AddMon(newMon);
            this.LoadTable();
            this.cancel();
        }
        
        private void cancel(object sender, EventArgs e)
        {
            this.cancel();
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                int danhMucId = Convert.ToInt32(this.ComboBoxDanhMuc.SelectedValue);
                this.Presenter.timMon(this.FindTxt.Text, danhMucId);
                this.LoadTable();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //private void uploadImageBtn_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Title = "Chọn ảnh";
        //        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Lấy đường dẫn tệp đã chọn
        //            string selectedFilePath = openFileDialog.FileName;
        //            // Hiển thị ảnh trong PictureBox
        //            this.pictureBox1.Image = Image.FromFile(selectedFilePath);
        //            this.pictureBox1.ImageLocation = selectedFilePath;
        //            // Lưu đường dẫn ảnh tương đối vào thuộc tính ImagePath
        //            this.ImagePath = Path.GetFileName(selectedFilePath);
        //        }
        //    }
        //}

        //chuyen sang trang khac
        private void ConhThucPage_btnClicked(object sender, EventArgs e)
        {
            //this.Hide();
            //selected mon
            int maMon = int.Parse(this.dataGridView1.SelectedRows[0].Cells["MaMon"].Value.ToString());
            this.Model.seletedMaMon = maMon;
            QL_CongThucPage conhThucPage = new QL_CongThucPage(this.Presenter);
            this.LoadQL_ConhThucPageHandler?.Invoke(conhThucPage);
        }

        private void PhanLoaiPage_btnClicked(object sender, EventArgs e)
        {
            QL_PhanLoaiPage phanLoaiPage = new QL_PhanLoaiPage(this.Presenter);
            this.LoadQL_PhanLoaiPageHandler?.Invoke(phanLoaiPage);
        }

        //table load
        public void LoadTable()
        {
            if (this.Model.Table == null || this.Model.Table.Rows.Count == 0) return;
            //this.Presenter.LoadMenu();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.Table;
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
            //custom column
            try
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.Columns["MaMon"].HeaderText = "Mã món";
                this.dataGridView1.Columns["MaMon"].FillWeight = 5;
                this.dataGridView1.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridView1.Columns["TenMon"].FillWeight = 30;
                this.dataGridView1.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridView1.Columns["GiaBan"].FillWeight = 15;
                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridView1.Columns["DonVi"].FillWeight = 15;
                this.dataGridView1.Columns["khoa"].Visible = false;
                this.dataGridView1.Columns["URl_Anh"].Visible = false;
                // them cot anh
                //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                //imageColumn.HeaderText = "Ảnh";
                //imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                //string imagePathDefault = Path.Combine(MySQL_DB.projectRoot, "Resources", "cafe.jpg");
                //imageColumn.Image = Image.FromFile(imagePathDefault);
                //imageColumn.ValueType = typeof(Image);
                //imageColumn.FillWeight = 15;
                //imageColumn.Name = "imageColumn";
                //imageColumn.Visible = false;
                //this.dataGridView1.Columns.Add(imageColumn);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            this.loadDetail(dataGridView1.Rows[0]);
        }

        public void loadDetail(DataGridViewRow row)
        {
            if (row == null)
            {
                this.txtMaMon.Text = this.txtTenMon.Text = this.txtGiaBan.Text = this.txtDonVi.Text = "";
                try
                {
                    string imagePath = Path.Combine(DB.projectRoot, "Resources", "image_icon.png");
                    this.pictureBox1.Image = Image.FromFile(imagePath);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return;
            }
            try
            {
                this.txtMaMon.Text = row.Cells["MaMon"].Value.ToString();
                this.txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                this.txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                this.txtDonVi.Text = row.Cells["DonVi"].Value.ToString();
                //
                if (row.Cells["URl_Anh"].Value != null)
                {
                    string imagePath = "";
                    if(row.Cells["URl_Anh"].Value.ToString() == "")
                    {
                        imagePath = Path.Combine(DB.projectRoot, "Resources", "image_icon.png");
                    }
                    else
                    {
                        imagePath = Path.Combine(DB.projectRoot, "Resources", row.Cells["URl_Anh"].Value.ToString());
                    }
                    this.pictureBox1.Image = Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Vẽ nút như bình thường
                e.PaintContent(e.CellBounds);
                string imagePath = Path.Combine(DB.projectRoot, "Resources", "edit_icon.png");
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
                string imagePath = Path.Combine(DB.projectRoot, "Resources", "close.png");
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
        //btn action
        private void cancel()
        {
            this.panelDetail.Enabled = false;
            this.loadDetail(this.dataGridView1.SelectedRows[0]);
            //btns
            this.AddSubmitBtn.Visible = false;
            this.UpdateSubmitBtn.Visible = false;
            this.CancelBtn.Visible = false;
        }

        private void DeleteDishDataColumn_Click(string maMon, string tenMon)
        {

            //DeleteMonForm deleteForm = new DeleteMonForm(this.Presenter, maNV, tenNV);
            //deleteForm.ShowDialog();

            //// Nếu form trả về DialogResult.OK → reload lại bảng
            //if (deleteForm.DialogResult == DialogResult.OK)
            //{
            //    this.LoadTable();
            //    this.cancel();
            //}

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa món '{tenMon}' (Mã: {maMon})?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                this.Presenter.DeleteMon(maMon);
                this.LoadTable();
                this.cancel();
            }
        }

        private void UpdateDishDataColumn_Click()
        {
            this.panelDetail.Enabled = true;
            this.loadDetail(this.dataGridView1.SelectedRows[0]);
            //btns
            this.UpdateSubmitBtn.Visible = true;
            this.CancelBtn.Visible = true;
            //focus
            this.txtTenMon.Focus();
        }


    }

}
