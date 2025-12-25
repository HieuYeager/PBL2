using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.QLTonKho;
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

namespace PBL2.Views.QLTonKho
{
    public partial class QLTonKhoPage : UserControl, IQLTonKho
    {
        //private AccountModel Account { get; set; }
        private NhanVien acc;
        private QLTonKhoPresenter presenters;

        public QLTonKhoPage()
        {
            InitializeComponent();
            presenters = new QLTonKhoPresenter(this);
        }
        public QLTonKhoPage(NhanVien account)
        {
            InitializeComponent();
            presenters = new QLTonKhoPresenter(this);
            this.acc = account;

            if(this.acc.VaiTro == EnumVaiTro.NhanVien)
            {
                this.add.Visible = false;
                this.xem.Visible = false;
                this.xemLichSu.Visible = false;
            }

            this.presenters.LoadDanhSachNguyenLieu();
        }

        public void AddActionButtons()
        {
            // Nếu đã có rồi thì không thêm lại
            if (dataGridView1.Columns["btnDelete"] != null)
                dataGridView1.Columns.Remove("btnDelete");

            // Thêm cột Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "";
            btnDelete.Text = "X";
            btnDelete.UseColumnTextForButtonValue = false;
            btnDelete.Width = 50;
            btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //btnDelete.FlatStyle = FlatStyle.Flat;
            //btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.ForeColor = Color.Black;

            // Thêm cột Sửa
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "";
            btnEdit.Text = "✏️";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Width = 50;
            btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnEdit.DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.Columns.Add(btnEdit);
            dataGridView1.Columns.Add(btnDelete);
        }

        //load
        public void LoadNguyenLieu(List<NguyenLieuTonKho> nguyenLieuTonKhos)
        {
            if (nguyenLieuTonKhos != null)
            {
                this.dataGridView1.Columns.Clear();
                dataGridView1.DataSource = nguyenLieuTonKhos;
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

                AddActionButtons(); // thêm cột Xóa và Sửa

                //an cot sua va xoa
                if (acc.VaiTro == EnumVaiTro.NhanVien)
                {
                    dataGridView1.Columns["btnDelete"].Visible = false;
                    dataGridView1.Columns["btnEdit"].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi tải danh sách nguyên liệu.");
            }
        }

        private void CapNhatTongNguyenLieu(int tong)
        {
            lblTongNL.Text = $"{tong}";
        }

        private void CapNhatCanhBao(int countCanhBao)
        {

            lblCB.Text = $"{countCanhBao}";
            lblCB.ForeColor = countCanhBao > 0 ? Color.OrangeRed : Color.Green;
            bool canhBao = countCanhBao > 0;

            // Nếu có nguyên liệu cảnh báo, thêm biểu tượng ⚠ vào nút xem
            if (countCanhBao > 0)
            {
                xem.Text = $"Xem cảnh báo ⚠ ({countCanhBao})";
                xem.Visible = true;
            }
            else
            {
                xem.Text = "";
                xem.Visible = false;
            }

            if (canhBao)
            {
                lblTrangThai.Text = "⚠ Cần nhập kho";
                lblTrangThai.ForeColor = Color.Red;
            }
            else
            {
                lblTrangThai.Text = "Đủ nguyên liệu";
                lblTrangThai.ForeColor = Color.Green;
            }
        }

        private void CapNhatHetHang(int countHetHang)
        {

            // Cập nhật label
            lblHetHang.Text = countHetHang.ToString();
            lblHetHang.ForeColor = countHetHang > 0 ? Color.Red : Color.Green;

            // lblUuTien nếu có nguyên liệu hết
            if (countHetHang > 0)
            {
                lblUuTien.Text = $"{countHetHang > 0} Ưu tiên cao";
                lblUuTien.ForeColor = Color.Red;
            }
            else
            {
                lblUuTien.Text = "✔ Bình thường";
                lblUuTien.ForeColor = Color.Green;
            }
        }
        //

        private void add_Click(object sender, EventArgs e)
        {
            using (AddNguyenLieuForm form = new AddNguyenLieuForm(this.presenters))
            {
                if (form.ShowDialog() == DialogResult.OK)
                { 
                }
            }
        }

        private void xem_Click(object sender, EventArgs e)
        {
            // Mở form cảnh báo
            using (XemCanhBao form = new XemCanhBao())
            {
                // Giả sử form XemCanhBao có sẵn DataGridView tên dgvCanhBao
                form.SetDataSource(this.presenters.GetAllNguyeLieuCanhBao());
                form.StartPosition = FormStartPosition.CenterParent;
                form.Text = "Cảnh Báo Nguyên Liệu Tồn Kho Thấp"; // Đặt tiêu đề form
                form.ShowDialog();
            }
        }

        private void xemLichSu_Click(object sender, EventArgs e)
        {
            using (LichSu form = new LichSu(this.presenters))
            {
                form.StartPosition = FormStartPosition.CenterParent; // mở giữa parent
                form.Text = "Lịch Sử Nguyên Liệu"; // đặt tiêu đề
                form.LoadLichSuTonKho();
                form.ShowDialog();
            }
        }

        private void nhapKho_Click(object sender, EventArgs e)
        {
            using (NhapKhoForm form = new NhapKhoForm(this.acc, presenters))
            {
                form.StartPosition = FormStartPosition.CenterParent; // mở giữa parent
                form.Text = "Nhập Kho Nguyên Liệu"; // tiêu đề form
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Nếu có cập nhật dữ liệu, load lại danh sách
                }
            }
        }

        private void xuatKho_Click(object sender, EventArgs e)
        {
            using (XuatKhoForm form = new XuatKhoForm(this.acc, presenters))
            {
                form.StartPosition = FormStartPosition.CenterParent; // mở giữa parent
                form.Text = "Xuất Kho Nguyên Liệu"; // tiêu đề form
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Nếu có cập nhật dữ liệu, load lại danh sách
                }
            }
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "btnDelete")
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Xóa";
                else if (columnName == "btnEdit")
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Sửa";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            NguyenLieuTonKho nguyenLieu = null;
            try
            {
                nguyenLieu = dataGridView1.Rows[e.RowIndex].DataBoundItem as NguyenLieuTonKho;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (nguyenLieu == null)
            {
                MessageBox.Show("Không tìm thấy nguyên liệu.");
                return;
            }

            if (columnName == "btnDelete")
            {
                // Hiển thị hộp thoại xác nhận xóa
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nguyên liệu '{nguyenLieu.TenNguyenLieu}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    this.presenters.XoaNguyenLieu(nguyenLieu);
                }
            }
            else if (columnName == "btnEdit")
            {
                // Xử lý sự kiện sửa
                using (EditNguyenLieuForm form = new EditNguyenLieuForm(this.presenters, nguyenLieu))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
        }

        //Hieu
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dataGridView1.Columns["btnEdit"].Index && e.RowIndex >= 0)
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
                if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index && e.RowIndex >= 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Interface methods
        public void loadTonKho(List<Data.NguyenLieuTonKho> nguyenLieuTonKhos, int tongNguyenLieu, int canhBao, int hetHang)
        {
            this.LoadNguyenLieu(nguyenLieuTonKhos);
            this.CapNhatTongNguyenLieu(tongNguyenLieu);
            this.CapNhatCanhBao(canhBao);
            this.CapNhatHetHang(hetHang);
        }

        public void loadCanhBao(List<Data.NguyenLieuTonKho> nguyenLieuTonKhos)
        {
            throw new NotImplementedException();
        }

        public void loadLichSu(List<Data.LichSuTonKhos> lichSuTonKhos)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
