using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

//--------------------Hai--------------------

using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_NhanVien;

namespace PBL2.Views.QL_NhanVien
{
    
    public partial class AddNhanVienForm : Form
    {
        private QL_NhanVienPresenter Presenter;
        public AddNhanVienForm(QL_NhanVienPresenter presenter)
        {
            InitializeComponent();

            this.Presenter = presenter;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nhân viên");
            comboBox1.Items.Add("Quản lý");

            if (comboBox1.SelectedItem == null)
                comboBox1.SelectedItem = "Nhân viên";
        }

        public AddNhanVienForm()
        {
        }

        private void Label_Click(object sender, EventArgs e)
        {
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private string GenerateMaNV()
        {
            try
            {
                object obj = MySQL_DB.Instance.ExecuteScalar("SELECT MAX(MaNV) FROM NhanVien");

                int nextID = 1;
                 if (obj != null && obj != DBNull.Value)
                {
                    string countStr = obj.ToString();

                    if (countStr.Length > 2 && countStr.StartsWith("NV"))
                    {
                        int currentID = int.Parse(countStr.Substring(2));
                        nextID = currentID + 1;
                    }
                }

                // Mã mới = NV + số thứ tự 3 chữ số (001, 002,...)
                return "NV" + nextID.ToString("D3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã NV: " + ex.Message);
                return "NV001"; // nếu lỗi thì trả về mặc định
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            string maNV = GenerateMaNV();
            string tenNV = txtTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string mucLuong = txtMucLuong.Text.Trim();
            string vaitro = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(mucLuong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(mucLuong, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Dictionary<string, string> Data = new Dictionary<string, string>
                {
                    { "MaNV", maNV },
                    { "TenNV", tenNV },
                    { "SDT", sdt },
                    { "DiaChi", diaChi },
                    { "MucLuongCoBan", mucLuongCoBan.ToString() },
                    { "VaiTro", vaitro } //Mặc định
                    //{ "CaLamViec", "Ca Sáng" }
                };

                bool success = MySQL_DB.Instance.Insert("NhanVien", Data);

                if (success)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //tao acc
                string password = BCrypt.Net.BCrypt.HashPassword("123456");
                Dictionary<string, string> DataAcc = new Dictionary<string, string>
                {
                    { "MaNV", maNV },
                    { "Password", password }, //Mặc định
                    { "khoa",  "0"}

                };

                bool result = MySQL_DB.Instance.Insert("Account", DataAcc);

                if (result)
                {
                    MessageBox.Show("Tạo acc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo acc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
