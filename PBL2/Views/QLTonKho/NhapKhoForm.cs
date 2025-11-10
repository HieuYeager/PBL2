using MySqlX.XDevAPI.Common;
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
    public partial class NhapKhoForm : Form
    {
        private AccountModel currentAccount;
        public NhapKhoForm(AccountModel account)
        {
            InitializeComponent();
            this.currentAccount = account;
            //
            this.txtMaNV.Text = this.currentAccount.MaNV;
            //load comboBox ten nguyen lieu
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "TenNguyenLieu");
            foreach (DataRow row in dt.Rows)
            {
                this.comboBoxTenNL.Items.Add(row["TenNguyenLieu"].ToString());
            }
        }

        // Khi người dùng rời khỏi txtTenMaNL hoặc nhấn Enter
        private void txtMaNL_Leave(object sender, EventArgs e)
        {
            LoadNguyenLieu();
        }

        private void txtMaNL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadNguyenLieu();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LoadNguyenLieu()
        {
            //string input = txtMaNL.Text.Trim();
            string input = comboBoxTenNL.Text.Trim();
            if (string.IsNullOrEmpty(input))
                return;

            string condition = $"TenNguyenLieu = '{input.Replace("'", "''")}' OR MaNguyenLieu = '{input}'";
            DataTable dt = MySQL_DB.Instance.Select("nguyenlieu", "MaNguyenLieu, TenNguyenLieu, DonVi, SoLuong", condition);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Tự động điền thông tin vào form
                txtMaNL.Tag = dt.Rows[0]["MaNguyenLieu"].ToString();
                txtMaNL.Text = dt.Rows[0]["TenNguyenLieu"].ToString();
                txtDonVi.Text = dt.Rows[0]["DonVi"].ToString();
            }
            else
            {
                MessageBox.Show("Nguyên liệu không tồn tại trong kho!");
            }
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void XacNhan_Click(object sender, EventArgs e)
        {
            //string maNL = txtMaNL.Tag?.ToString() ?? ""; // lấy mã nguyên liệu chính xác
            //string tenNL = txtMaNL.Text.Trim();
            string tenNL = comboBoxTenNL.Text.Trim();
            string donVi = txtDonVi.Text.Trim();
            string ghiChu = txtGhiChu.Text.Trim();
            //string maNV = txtMaNV.Text.Trim();
            string maNV = currentAccount.MaNV;
            decimal soLuongNhap = 0;

            string maNL = MySQL_DB.Instance.Select("nguyenlieu", "MaNguyenLieu", $"TenNguyenLieu = '{tenNL}'").Rows[0]["MaNguyenLieu"].ToString();

            //ktr số lượng
            if (!decimal.TryParse(txtSoLuong.Text.Trim(), out soLuongNhap) || soLuongNhap <= 0)
            {
                MessageBox.Show("Số lượng phải > 0");
                return;
            }
            //ktr tên và đơn vị
            if (string.IsNullOrEmpty(tenNL) || string.IsNullOrEmpty(donVi))
            {
                MessageBox.Show("Tên và đơn vị nguyên liệu không được để trống!");
                return;
            }

            if (MySQL_DB.Instance.Count($"NhanVien WHERE MaNV = '{maNV}'") == 0)
            {
                MessageBox.Show($"Nhân viên '{maNV}' không tồn tại!");
                return;
            }

            var data = new Dictionary<string, object>
            {
                { "TenNguyenLieu", tenNL },
                { "DonVi", donVi },
                { "SoLuong", soLuongNhap }
            };

            //bool success = MySQL_DB.Instance.InsertNguyenLieu("nguyenlieu", data);
            string updateQuery = $"UPDATE nguyenlieu SET SoLuong = SoLuong + {soLuongNhap}, NgayCapNhat = NOW() WHERE MaNguyenLieu = '{maNL}'";
            bool success = MySQL_DB.Instance.ExecuteNonQuery(updateQuery) > 0;
            if (!success)
            {
                MessageBox.Show("Nhập kho thất bại!");
                return;
            }

            string query = $"INSERT INTO lichsutonkho (MaNguyenLieu, MaNV, HoatDong, SoLuong, GhiChu, Ngay) " +
                           $"VALUES ('{maNL}', '{maNV}', 'Nhập kho', {soLuongNhap}, '{ghiChu.Replace("'", "''")}', NOW())";

            int result = MySQL_DB.Instance.ExecuteNonQuery(query);

            if (result > 0)
            {
                MessageBox.Show("Nhập kho thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập kho thất bại!");
            }
        }
    }
}
