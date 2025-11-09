using PBL2.Models;
using PBL2.Presenters.QLTonKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    public partial class QLTonKhoPage : UserControl
    {
        private QLTonKhoPresenter presenters;

        public QLTonKhoPage()
        {
            InitializeComponent();
            presenters = new QLTonKhoPresenter();
        }

        public void QLTonKhoPage_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            CapNhatTongNguyenLieu();
            CapNhatCanhBao();
            CapNhatThongTinKho();
        }

        public void LoadNguyenLieu()
        {
            DataTable dt = presenters.GetDanhSachNguyenLieu();
            
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridView1.Columns["MaNguyenLieu"].HeaderText = "Mã Nguyên Liệu";
                dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
                dataGridView1.Columns["DonVi"].HeaderText = "Đơn Vị";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
                dataGridView1.Columns["NgayCapNhat"].HeaderText = "Ngày Cập Nhật";

                AddActionButtons(); // thêm cột Xóa và Sửa
            }
            else
            {
                MessageBox.Show("Lỗi khi tải danh sách nguyên liệu.");
            }
        }

        public void AddActionButtons()
        {
            // Nếu đã có rồi thì không thêm lại
            if (dataGridView1.Columns["btnDelete"] != null)
                dataGridView1.Columns.Remove("btnDelete");

            //if (dataGridView1.Columns["btnEdit"] != null)
            //    dataGridView1.Columns.Remove("btnEdit");

            // Thêm cột Xóa
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "";
            btnDelete.Text = "X";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 50;
            btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.BackColor = Color.IndianRed;
            btnDelete.DefaultCellStyle.ForeColor = Color.Black;

            // Thêm cột Sửa
            //DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            //btnEdit.Name = "btnEdit";
            //btnEdit.HeaderText = "";
            //btnEdit.Text = "✏️";
            //btnEdit.UseColumnTextForButtonValue = true;
            //btnEdit.Width = 50;
            //btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //btnEdit.FlatStyle = FlatStyle.Flat;
            //btnEdit.DefaultCellStyle.BackColor = Color.LimeGreen;
            //btnEdit.DefaultCellStyle.ForeColor = Color.Black;

            //dataGridView1.Columns.Add(btnEdit);
            dataGridView1.Columns.Add(btnDelete);
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

            if (columnName == "btnDelete")
            {
                string maNguyenLieu = dataGridView1.Rows[e.RowIndex].Cells["MaNguyenLieu"].Value.ToString();
                string tenNguyenLieu = dataGridView1.Rows[e.RowIndex].Cells["TenNguyenLieu"].Value.ToString();

                //ktr nguyên liệu có đang đc sử dụng trong công thức ko
                int userCount = MySQL_DB.Instance.Count("congthuc", $"MaNguyenLieu = {maNguyenLieu}");

                if (userCount > 0)
                {
                    // Nếu có, hiển thị danh sách món đang dùng nguyên liệu
                    var dt = MySQL_DB.Instance.Select("congthuc", "MaMon, SoLuong, DonVi", $"MaNguyenLieu = {maNguyenLieu}");
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"Nguyên liệu '{tenNguyenLieu}' đang được sử dụng trong {userCount} món:");

                    foreach (DataRow row in dt.Rows)
                    {
                        sb.AppendLine($"- Món ID: {row["MaMon"]}, Số lượng: {row["SoLuong"]} {row["DonVi"]}");
                    }
                    MessageBox.Show(sb.ToString(), "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nguyên liệu '{tenNguyenLieu}'?", 
                    "Xác nhận xóa", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool deleted = MySQL_DB.Instance.Delete("nguyenlieu", $"MaNguyenLieu = {maNguyenLieu}");
                    if (deleted)
                    {
                        LoadNguyenLieu();
                        CapNhatTongNguyenLieu();
                        CapNhatCanhBao();
                        CapNhatThongTinKho();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
            else if (columnName == "btnEdit")
            {
                // Xử lý sự kiện sửa
                string maNguyenLieu = dataGridView1.Rows[e.RowIndex].Cells["MaNguyenLieu"].Value.ToString();

                MessageBox.Show($"Sửa nguyên liệu ID: {maNguyenLieu}");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            using (AddNguyenLieuForm form = new AddNguyenLieuForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Thêm nguyên liệu vào DB
                    var data = new Dictionary<string, string>
                {
                    { "TenNguyenLieu", form.TenNguyenLieu },
                    { "DonVi", form.DonVi.ToString() },
                    { "SoLuong", form.SoLuong.ToString() },
                    { "NgayCapNhat", $"'{DateTime.Now:yyyy-MM-dd HH:mm:ss}'" } // ngày hiện tại
                };

                    bool inserted = MySQL_DB.Instance.Insert("nguyenlieu", data);
                    if (inserted)
                    {
                        MessageBox.Show("Thêm nguyên liệu thành công!");
                        LoadNguyenLieu(); // Load lại DataGridView
                        CapNhatTongNguyenLieu();
                        CapNhatCanhBao();
                        CapNhatThongTinKho();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nguyên liệu thất bại!");
                    }
                }
            }
        }

        private void xem_Click(object sender, EventArgs e)
        {
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "TenNguyenLieu, SoLuong, DonVi");

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nguyên liệu.");
                return;
            }

            // Lọc những nguyên liệu số lượng < 10
            DataTable dtCanhBao = dt.Clone(); // giữ cấu trúc cột
            foreach (DataRow row in dt.Rows)
            {
                double soLuong = Convert.ToDouble(row["SoLuong"]);
                if (soLuong < 10)
                {
                    dtCanhBao.ImportRow(row);
                }
            }

            if (dtCanhBao.Rows.Count == 0)
            {
                MessageBox.Show("Không có nguyên liệu nào dưới mức cảnh báo.");
                return;
            }

            // Mở form cảnh báo
            using (XemCanhBao form = new XemCanhBao())
            {
                // Giả sử form XemCanhBao có sẵn DataGridView tên dgvCanhBao
                form.SetDataSource(dtCanhBao);
                form.StartPosition = FormStartPosition.CenterParent;
                form.Text = "Cảnh Báo Nguyên Liệu Tồn Kho Thấp"; // Đặt tiêu đề form
                form.ShowDialog();
            }
        }
        private void CapNhatTongNguyenLieu()
        {
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "MaNguyenLieu");

            if (dt == null || dt.Rows.Count == 0)
            {
                lblTongNL.Text = "";
                return;
            }

            int tong = dt.Rows.Count;

            lblTongNL.Text = $"{tong}";
        }

        private void CapNhatCanhBao()
        {
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "SoLuong");

            if (dt == null || dt.Rows.Count == 0)
            {
                lblCB.Text = "";
                return;
            }

            bool canhBao = false;

            foreach (DataRow row in dt.Rows)
            {
                double soLuong = 0;
                double.TryParse(row["SoLuong"].ToString(), out soLuong);
                if (soLuong < 10)
                {
                    canhBao = true;
                    break;
                }
            }

            int countCanhBao = 0;
            foreach (DataRow row in dt.Rows)
            {
                double soLuong = 0;
                double.TryParse(row["SoLuong"].ToString(), out soLuong);
                if (soLuong < 10) // mức cảnh báo
                    countCanhBao++;
            }

            lblCB.Text = $"{countCanhBao}";
            lblCB.ForeColor = countCanhBao > 0 ? Color.OrangeRed : Color.Green;

            // Nếu có nguyên liệu cảnh báo, thêm biểu tượng ⚠ vào nút xem
            if (countCanhBao > 0)
                xem.Text = $"Xem cảnh báo ⚠ ({countCanhBao})";
            else
                xem.Text = "Xem";

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

        private void CapNhatThongTinKho()
        {
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "SoLuong");

            if (dt == null || dt.Rows.Count == 0)
            {
                lblCB.Text = "0";      
                lblHetHang.Text = "0";  
                lblTrangThai.Text = "";
                lblUuTien.Text = "";
                return;
            }

            int soLuongCanhBao = 0;
            int soLuongHetHang = 0;
            bool canhBao = false;

            foreach (DataRow row in dt.Rows)
            {
                double soLuong = 0;
                double.TryParse(row["SoLuong"].ToString(), out soLuong);

                if (soLuong < 10 && soLuong > 0)
                {
                    soLuongCanhBao++;
                    canhBao = true;
                }
                else if (soLuong == 0)
                {
                    soLuongHetHang++;
                    canhBao = true;  // cũng tính là cảnh báo
                }
            }

            // Cập nhật label
            lblCB.Text = soLuongCanhBao.ToString();
            lblHetHang.Text = soLuongHetHang.ToString();
            lblHetHang.ForeColor = soLuongHetHang > 0 ? Color.Red : Color.Green;

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

            // lblUuTien nếu có nguyên liệu hết
            if (soLuongHetHang > 0)
            {
                lblUuTien.Text = $"{soLuongHetHang} Ưu tiên cao";
                lblUuTien.ForeColor = Color.Red;
            }
            else
            {
                lblUuTien.Text = "✔ Bình thường";
                lblUuTien.ForeColor = Color.Green;
            }
        }

        private void xemLichSu_Click(object sender, EventArgs e)
        {
            using (LichSu form = new LichSu())
            {
                form.StartPosition = FormStartPosition.CenterParent; // mở giữa parent
                form.Text = "Lịch Sử Nguyên Liệu"; // đặt tiêu đề
                form.LoadLichSuTonKho();
                form.ShowDialog();
            }
        }
        private void nhapKho_Click(object sender, EventArgs e)
        {
            using (NhapKhoForm form = new NhapKhoForm())
            {
                form.StartPosition = FormStartPosition.CenterParent; // mở giữa parent
                form.Text = "Nhập Kho Nguyên Liệu"; // tiêu đề form
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Nếu có cập nhật dữ liệu, load lại danh sách
                    LoadNguyenLieu();
                    CapNhatTongNguyenLieu();
                    CapNhatCanhBao();
                    CapNhatThongTinKho();
                }
            }
        }

        private void lblTongNL_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
