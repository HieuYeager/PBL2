
using PBL2.Class;
using PBL2.Models;
using PBL2.Views.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//--------------------Hai--------------------

namespace PBL2.Presenters.QL_NhanVien
{
    public enum CaLamViec
    {
        [Display(Name = "CS")]
        CaSang = 1,
        [Display(Name = "CC")]
        CaChieu = 2,
        [Display(Name = "CT")]
        CaToi = 3
    }
    public class QL_NhanVienPresenter
    {
        public QL_NhanVienPage View { get; set; }
        public QL_NhanVienPageModel Model { get; set; }

        public QL_NhanVienPresenter(QL_NhanVienPage view)
        {
            this.View = view;
            this.Model = new QL_NhanVienPageModel();
        }

        public void Load()
        {
            //DataTable dt = MySQL_DB.Instance.Select("nhanvien", "*");
            DataTable dt = MySQL_DB.Instance.SelectJoin("nhanvien", "nhanvien.*, account.khoa", "JOIN account ON nhanvien.MaNV = account.MaNV");
            this.Model.Table = dt;
        }

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
                    //MessageBox.Show("Tạo acc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Tạo acc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void DeleteNhanVien(string MaNV)
        {
            try
            {
                string condition = $"MaNV = '{MaNV}'";

                //delete account truoc
                bool successAcc = MySQL_DB.Instance.Delete("Account", condition);

                if (successAcc)
                {
                    //MessageBox.Show("Xoá tài khoản nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("Xoá tài khoản nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bool success = MySQL_DB.Instance.Delete("NhanVien", condition);
                if (success)
                {
                    MessageBox.Show("Xóa nhân viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void search(string keyword)
        {

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu ô tìm kiếm trống
                DataTable dt = MySQL_DB.Instance.SelectJoin("nhanvien", "nhanvien.*, account.khoa", "JOIN account ON nhanvien.MaNV = account.MaNV");
                this.Model.Table = dt;
                return;
            }

            string condition = $"JOIN account ON nhanvien.MaNV = account.MaNV WHERE nhanvien.MaNV LIKE '%{keyword}%' OR nhanvien.TenNV LIKE '%{keyword}%' OR nhanvien.SDT LIKE '%{keyword}%' OR nhanvien.DiaChi LIKE '%{keyword}%'";

            try
            {
                DataTable dt = MySQL_DB.Instance.SelectJoin("nhanvien", "nhanvien.*, account.khoa", condition);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                }

                this.Model.Table = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ql phan ca
        public void Load_PhanCa(CaLamViec calamviec)
        {
            //select ma nhan vien, ten nhan vien, ca lam viec
            DataTable dt = MySQL_DB.Instance.Select($"nhanvien ORDER BY CASE WHEN CaLamViec Like '%{calamviec.GetDisplayName()}%' THEN 0  ELSE 1  END, TenNV;", "MaNV, TenNV, CaLamViec");
            this.Model.CaLamViec = dt;
        }

        public void updatePhanCa()
        {
            try
            {
                foreach (DataRow row in this.Model.CaLamViec.Rows)
                {
                    string MaNV = row["MaNV"].ToString();
                    string CaLamViec = row["CaLamViec"].ToString();
                    string updates = $"CaLamViec = '{CaLamViec}'";
                    string condition = $"MaNV = '{MaNV}'";
                    MySQL_DB.Instance.Update("NhanVien", updates, condition);
                }

                MessageBox.Show("Cập nhật phân ca thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phân ca: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //diem danh
        public void Load_DiemDanh(DateTime date, CaLamViec calamviec)
        {
            if(date == DateTime.MinValue) date = DateTime.Now;

            //bool checkExist = MySQL_DB.Instance.Count("diemdanh", $"Ngay Like '{date.ToString("yyyy-MM-dd")}' AND CaLam = '{calamviec.GetDisplayName()}'") > 0;

            if (date.Date == DateTime.Today)
            {
                
                string thu = ConvertToDayOfWeek(date);
                DataTable NvTrongCa = MySQL_DB.Instance.SelectJoin("nhanvien as nv", "nv.MaNV, nv.TenNV, nv.CaLamViec", $"JOIN account acc ON nv.MaNV = acc.MaNV WHERE acc.khoa = 0 AND nv.CaLamViec LIKE '%{thu+calamviec.GetDisplayName()}%' ORDER BY nv.TenNV;");
                foreach (DataRow row in NvTrongCa.Rows)
                {
                    string MaNV = row["MaNV"].ToString();
                    //kiem tra neu chua co trong bang diem danh thi them vao
                    bool checkExist = MySQL_DB.Instance.Count("diemdanh", $"MaNV = '{MaNV}' AND Ngay Like '{date.ToString("yyyy-MM-dd")}' AND CaLam = '{calamviec.GetDisplayName()}'") > 0;
                    if (!checkExist)
                    {
                        string fields = "MaNV, Ngay, CaLam, DiemDanh";
                        string values = $"'{MaNV}', '{date.ToString("yyyy-MM-dd")}', '{calamviec.GetDisplayName()}', '0'";
                        MySQL_DB.Instance.Insert("diemdanh", fields, values);
                    }
                }

                DataTable NvKhongTrongCa = MySQL_DB.Instance.SelectJoin("nhanvien as nv", "nv.MaNV, nv.TenNV, nv.CaLamViec", $"JOIN account acc ON nv.MaNV = acc.MaNV WHERE nv.CaLamViec NOT LIKE '%{thu + calamviec.GetDisplayName()}%';");
                //delete nhan vien khong trong ca
                foreach (DataRow row in NvKhongTrongCa.Rows)
                {
                    //MessageBox.Show(row["MaNV"].ToString());
                    string MaNV = row["MaNV"].ToString();
                    MySQL_DB.Instance.Delete("diemdanh", $"MaNV = '{MaNV}' AND Ngay Like '{date.ToString("yyyy-MM-dd")}' AND CaLam = '{calamviec.GetDisplayName()}'");
                }
            }
            //select ma nhan vien, ten nhan vien, ca lam viec
            DataTable dt = MySQL_DB.Instance.SelectJoin("diemdanh as dd", "dd.MaNV, nv.TenNV, dd.DiemDanh, dd.CaLam, dd.Ngay", $"JOIN NhanVien nv ON dd.MaNV = nv.MaNV WHERE dd.Ngay Like '{date.ToString("yyyy-MM-dd")}' AND dd.CaLam = '{calamviec.GetDisplayName()}';");
            this.Model.DiemDanh = dt;
    }

        public void updateDiemDanh()
        {
            foreach (DataRow row in this.Model.DiemDanh.Rows)
            {
                string MaNV = row["MaNV"].ToString();
                string DiemDanh = Convert.ToBoolean(row["DiemDanh"]) ? "1" : "0";
                string CaLamViec = row["CaLam"].ToString();
                string Ngay = Convert.ToDateTime(row["Ngay"]).ToString("yyyy-MM-dd");
                string updates = $"DiemDanh = '{DiemDanh}'";
                string condition = $"MaNV = '{MaNV}' AND Ngay Like '%{Ngay}%' AND CaLam = '{CaLamViec}'";
                MySQL_DB.Instance.Update("DiemDanh", updates, condition);
            }
        }
       string ConvertToDayOfWeek(DateTime date)
        {
            DayOfWeek DOW = date.DayOfWeek;

            switch(DOW)
            {
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
                case DayOfWeek.Sunday:
                    return "T8";
            }

            return "-1";
        }

    }
}
