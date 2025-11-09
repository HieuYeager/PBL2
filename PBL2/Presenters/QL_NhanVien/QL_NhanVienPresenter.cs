
using PBL2.Class;
using PBL2.Models;
using PBL2.Views.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//--------------------Hai--------------------

namespace PBL2.Presenters.QL_NhanVien
{
    public class QL_NhanVienPresenter : IPresenter<QL_NhanVienPage, QL_NhanVienPageModel>
    {
        public QL_NhanVienPage View { get ; set; }
        public QL_NhanVienPageModel Model { get; set; }

        public QL_NhanVienPresenter(QL_NhanVienPage view)
        {
            this.View = view;
            this.Model = new QL_NhanVienPageModel();
        }

        public void Load()
        {
            DataTable dt = MySQL_DB.Instance.Select("nhanvien", "*");
            this.Model.Table = dt;
        }
        //public void addNhanVien(NhanVien nv)
        //{
        //    //string maNV = GenerateMaNV();
        //    //string tenNV = txtTen.Text.Trim();
        //    //string sdt = txtSDT.Text.Trim();
        //    //string diaChi = txtDiaChi.Text.Trim();
        //    //string mucLuong = txtMucLuong.Text.Trim();
        //    //string vaitro = comboBox1.SelectedItem.ToString();

        //    string maNV = GenerateMaNV();
        //    string tenNV = nv.TenNV;
        //    string sdt = nv.
        //    string diaChi = txtDiaChi.Text.Trim();
        //    string mucLuong = txtMucLuong.Text.Trim();
        //    string vaitro = comboBox1.SelectedItem.ToString();

        //    if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(mucLuong))
        //    {
        //        MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (!decimal.TryParse(mucLuong, out decimal mucLuongCoBan))
        //    {
        //        MessageBox.Show("Mức lương không hợp lệ. Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        Dictionary<string, string> Data = new Dictionary<string, string>
        //        {
        //            { "MaNV", maNV },
        //            { "TenNV", tenNV },
        //            { "SDT", sdt },
        //            { "DiaChi", diaChi },
        //            { "MucLuongCoBan", mucLuongCoBan.ToString() },
        //            { "VaiTro", vaitro } //Mặc định
        //            //{ "CaLamViec", "Ca Sáng" }
        //        };

        //        bool success = MySQL_DB.Instance.Insert("NhanVien", Data);

        //        if (success)
        //        {
        //            MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        //tao acc
        //        string password = BCrypt.Net.BCrypt.HashPassword("123456");
        //        Dictionary<string, string> DataAcc = new Dictionary<string, string>
        //        {
        //            { "MaNV", maNV },
        //            { "Password", password }, //Mặc định
        //            { "khoa",  "0"}

        //        };

        //        bool result = MySQL_DB.Instance.Insert("Account", DataAcc);

        //        if (result)
        //        {
        //            MessageBox.Show("Tạo acc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tạo acc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public string GenerateMaNV()
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

        public void Add_NhanVien(NhanVien nv)
        {
            try
            {
                Dictionary<string, string> Data = new Dictionary<string, string>
                {
                    { "MaNV", nv.MaNV },
                    { "TenNV", nv.TenNV },
                    { "SDT", nv.SDT },
                    { "DiaChi", nv.DiaChi },
                    { "MucLuongCoBan", nv.MucLuongCoBan.ToString() },
                    { "VaiTro", nv.VaiTro.GetDisplayName() } //Mặc định
                    //{ "CaLamViec", "Ca Sáng" }
                };

                bool success = MySQL_DB.Instance.Insert("NhanVien", Data);

                if (success)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //tao acc
                string password = BCrypt.Net.BCrypt.HashPassword("123456");
                Dictionary<string, string> DataAcc = new Dictionary<string, string>
                {
                    { "MaNV", nv.MaNV },
                    { "Password", password }, //Mặc định
                    { "khoa",  "0"}

                };

                bool result = MySQL_DB.Instance.Insert("Account", DataAcc);

                if (result)
                {
                    MessageBox.Show("Tạo acc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void UpdateNhanVien(NhanVien nv)
        {
            try
            {
                string updates = $"TenNV = '{nv.TenNV}', " +
                                 $"SDT = '{nv.SDT}', " +
                                 $"DiaChi = '{nv.DiaChi}', " +
                                 $"MucLuongCoBan = {nv.MucLuongCoBan?.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                                 $"VaiTro = '{nv.VaiTro.GetDisplayName()}'";

                string condition = $"MaNV = '{nv.MaNV}'";

                //update
                bool success = MySQL_DB.Instance.Update("NhanVien", updates, condition) > 0;

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK; // để form cha reload DataGridView
                    //this.Close();
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
    }
}
