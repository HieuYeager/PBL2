
using MySql.Data.MySqlClient;
using PBL2.Data;
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
        public IQL_NhanVienPage View { get; set; }
        public QL_NhanVienPageModel Model { get; set; }

        public QL_NhanVienPresenter(IQL_NhanVienPage view)
        {
            this.View = view;
            this.Model = new QL_NhanVienPageModel();
        }

        public void Load(NhanVien acc)
        {
            List<NhanVien> list = this.Model.GetNhanVienTable(acc);
            this.View.loadNhnVienTable(list);

        }

        public string GenerateMaNV(EnumVaiTro vaiTro)
        {
            string ma = "NV";
            if(vaiTro == EnumVaiTro.NhanVien) { }
            else if (vaiTro == EnumVaiTro.QuanLy) { ma = "QL"; }
            try
            {
                int ID = 1;
                string maMoi = ma + ID.ToString("D3");
                while (NhanViens.Get(maMoi) != null)
                {
                    ID += 1;
                    maMoi = ma + ID.ToString("D3");
                }
                int nextID = ID;

                // Mã mới = NV + số thứ tự 3 chữ số (001, 002,...)
                return ma + nextID.ToString("D3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo mã NV: " + ex.Message);
                return ""; // nếu lỗi thì trả về mặc định
            }
        }

        public void Add_NhanVien(NhanVien nv, NhanVien acc)
        {
            if(nv == null)
            {
                this.View.showMessage("Thêm nhân viên thất bại");
                return;
            }

            string maNV = this.GenerateMaNV(nv.VaiTro);
            nv.MaNV = maNV;
            if (this.Model.AddNhanVien(nv))
            {
                if (this.Model.AddAccforNhanVien(nv))
                {
                    this.View.showMessage("Thêm nhân viên thành công");
                    this.Load(acc);
                }
                else
                {
                    //remove nhan vien
                    this.Model.DeleteNhanVien(nv);
                    this.View.showMessage("Thêm nhân viên thất bai");
                }
            }
            else
            {
                this.View.showMessage("Thêm nhân viên thất bai");
            }
        }

        public void UpdateNhanVien(NhanVien nv, NhanVien acc)
        {
            if (this.Model.UpdateNhanVien(nv))
            {
                this.View.showMessage("Sửa nhân viên thành công");
                this.Load(acc);
            }
            else
            {
                this.View.showMessage("Sửa nhân viên thất bại");
            }
        }

        public void DeleteNhanVien(NhanVien nhanVien, NhanVien acc)
        {
            if (this.Model.DeleteNhanVien(nhanVien))
            {
                this.View.showMessage("Xóa nhân viên thành công");
                this.Load(acc);
            }
            else
            {
                this.View.showMessage("Xóa nhân viên thất bại");
            }
        }

        public void search(NhanVien acc, string keyword)
        {
            List<NhanVien> list = this.Model.GetNhanVienTable(acc, keyword);
            this.View.loadNhnVienTable(list);
        }

        //ql phan ca (CHUA LAM)
        public void Load_PhanCa(CaLamViec calamviec)
        {
            //select ma nhan vien, ten nhan vien, ca lam viec
            //DataTable dt = MySQL_DB.Instance.Select($"nhanvien ORDER BY CASE WHEN CaLamViec Like '%{calamviec.GetDisplayName()}%' THEN 0  ELSE 1  END, TenNV;", "MaNV, TenNV, CaLamViec");
            DataTable dt = new DataTable();
            this.Model.CaLamViec = null;
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
                    //MySQL_DB.Instance.Update("NhanVien", updates, condition);
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
                //DataTable NvTrongCa = MySQL_DB.Instance.SelectJoin("nhanvien as nv", "nv.MaNV, nv.TenNV, nv.CaLamViec", $"JOIN account acc ON nv.MaNV = acc.MaNV WHERE acc.khoa = 0 AND nv.CaLamViec LIKE '%{thu+calamviec.GetDisplayName()}%' ORDER BY nv.TenNV;");
                DataTable NvTrongCa = new DataTable();
                foreach (DataRow row in NvTrongCa.Rows)
                {
                    string MaNV = row["MaNV"].ToString();
                    //kiem tra neu chua co trong bang diem danh thi them vao
                    //bool checkExist = MySQL_DB.Instance.Count("diemdanh", $"MaNV = '{MaNV}' AND Ngay Like '{date.ToString("yyyy-MM-dd")}' AND CaLam = '{calamviec.GetDisplayName()}'") > 0;
                    bool checkExist = false;
                    if (!checkExist)
                    {
                        string fields = "MaNV, Ngay, CaLam, DiemDanh";
                        string values = $"'{MaNV}', '{date.ToString("yyyy-MM-dd")}', '{calamviec.GetDisplayName()}', '0'";
                        //MySQL_DB.Instance.Insert("diemdanh", fields, values);
                    }
                }

                //DataTable NvKhongTrongCa = MySQL_DB.Instance.SelectJoin("nhanvien as nv", "nv.MaNV, nv.TenNV, nv.CaLamViec", $"JOIN account acc ON nv.MaNV = acc.MaNV WHERE nv.CaLamViec NOT LIKE '%{thu + calamviec.GetDisplayName()}%';");
                DataTable NvKhongTrongCa = new DataTable();
                //delete nhan vien khong trong ca
                foreach (DataRow row in NvKhongTrongCa.Rows)
                {
                    //MessageBox.Show(row["MaNV"].ToString());
                    string MaNV = row["MaNV"].ToString();
                    //MySQL_DB.Instance.Delete("diemdanh", $"MaNV = '{MaNV}' AND Ngay Like '{date.ToString("yyyy-MM-dd")}' AND CaLam = '{calamviec.GetDisplayName()}'");
                }
            }
            //select ma nhan vien, ten nhan vien, ca lam viec
            //DataTable dt = MySQL_DB.Instance.SelectJoin("diemdanh as dd", "dd.MaNV, nv.TenNV, dd.DiemDanh, dd.CaLam, dd.Ngay", $"JOIN NhanVien nv ON dd.MaNV = nv.MaNV WHERE dd.Ngay Like '{date.ToString("yyyy-MM-dd")}' AND dd.CaLam = '{calamviec.GetDisplayName()}';");
            DataTable dt = new DataTable();
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
                //MySQL_DB.Instance.Update("DiemDanh", updates, condition);
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
