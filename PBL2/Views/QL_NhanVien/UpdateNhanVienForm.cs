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
    public partial class UpdateNhanVienForm : Form
    {
        public UpdateNhanVienForm()
        {
            InitializeComponent();

            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Nhân viên");
            cboVaiTro.Items.Add("Quản lý");
        }

        public void SetNhanVienInfo(string maNV, string tenNV, string sdt, string diaChi, string mucLuong, string vaitro)
        {
            txtMaNV.Text = maNV;
            txtTen.Text = tenNV;
            txtSDT.Text = sdt;
            txtDiaChi.Text = diaChi;
            txtMucLuong.Text = mucLuong.ToString();

            if (cboVaiTro.Items.Contains(vaitro))
                cboVaiTro.SelectedItem = vaitro;
            else
                cboVaiTro.SelectedItem = "Nhân viên"; // mặc định
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string mucLuong = txtMucLuong.Text.Trim();
            string vaitro = cboVaiTro.SelectedItem?.ToString() ?? "Nhân viên";

            // ktr data
            if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(mucLuong))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //chuyển mức lương sang decimal
            if (!decimal.TryParse(mucLuong, out decimal mucLuongCoBan))
            {
                MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string updates = $"TenNV = '{tenNV}', " +
                                 $"SDT = '{sdt}', " +
                                 $"DiaChi = '{diaChi}', " +
                                 $"MucLuongCoBan = {mucLuongCoBan.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                                 $"VaiTro = '{vaitro}'";

                string condition = $"MaNV = '{maNV}'";

                //update
                bool success = MySQL_DB.Instance.Update("NhanVien", updates, condition) > 0;

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // để form cha reload DataGridView
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
