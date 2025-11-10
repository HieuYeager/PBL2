using PBL2.Class;
using PBL2.Models;
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
    public partial class AddNguyenLieuForm : Form
    {
        public string TenNguyenLieu { get; set; }
        public DonViNguyenLieu DonVi { get; set; }
        public decimal SoLuong { get; set; }

        public AddNguyenLieuForm()
        {
            InitializeComponent();
            LoadDonVi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenNguyenLieu = txtTen.Text.Trim();       // Tên nguyên liệu
            DonViNguyenLieu donVi = (DonViNguyenLieu)cbDonVi.SelectedItem;    // Đơn vị từ combobox
            decimal soLuongMoi = nudSoLuong.Value;              // số lượng
            DateTime ngayCapNhat = DateTime.Now;

            if (string.IsNullOrEmpty(tenNguyenLieu))
            {
                MessageBox.Show("Tên nguyên liệu không được để trống!");
                txtTen.Focus();
                return;
            }

            if (cbDonVi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị!");
                return;
            }

            try
            {
                // Kiểm tra xem nguyên liệu đã tồn tại chưa
                string checkQuery = $"SELECT SoLuong, DonVi FROM nguyenlieu WHERE TenNguyenLieu = '{tenNguyenLieu.Replace("'", "''")}'";
                DataTable dt = MySQL_DB.Instance.ExecuteQuery(checkQuery);

                if (dt.Rows.Count > 0)
                {
                    // Nguyên liệu đã tồn tại, không thêm
                    MessageBox.Show($"Nguyên liệu '{tenNguyenLieu}' đã tồn tại trong kho. Không thể thêm mới.");
                    return;
                }
                else
                {
                    // Chưa có nguyên liệu, thêm mới
                    Dictionary<string, string> data = new Dictionary<string, string>
                    {
                        { "TenNguyenLieu", tenNguyenLieu },
                        { "DonVi", donVi.ToString() },
                        { "SoLuong", soLuongMoi.ToString() },
                        { "NgayCapNhat", ngayCapNhat.ToString("yyyy-MM-dd HH:mm:ss") }
                    };

                    //show data for test
                    //foreach (var item in data)
                    //{
                    //    Console.WriteLine($"{item.Key}: {item.Value}");
                    //}

                    bool inserted = MySQL_DB.Instance.Insert("nguyenlieu", data);

                    if (inserted)
                    {
                        MessageBox.Show("Thêm nguyên liệu thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nguyên liệu thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nguyên liệu: " + ex.Message);
            }
        }

        private void LoadDonVi()
        {
            // Lấy tất cả giá trị trong enum DonViNguyenLieu
            cbDonVi.DataSource = Enum.GetValues(typeof(DonViNguyenLieu));
            cbDonVi.SelectedIndex = -1; // không chọn mặc định
        }
    }
}
