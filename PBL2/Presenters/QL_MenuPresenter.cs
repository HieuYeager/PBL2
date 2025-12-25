using PBL2.Models;
using PBL2.Views.QL_Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Data;
//--------------------Bin--------------------
namespace PBL2.Presenters.QL_Menu
{
    public class QL_MenuPresenter
    {
        public QL_MenuPage View { get; set; }
        public QL_MenuPageModel Model { get; set; }

        public QL_MenuPresenter(QL_MenuPage view)
        {
            View = view;
            Model = new QL_MenuPageModel();
        }

        public void LoadMenu()
        {
            string sql = Mons.select().GetSql();
            DataTable dt = DB.ExecuteQuery(sql);
            this.Model.Table = dt;
        }

        public List<DanhMuc> loadDM()
        {
            //Model.danhmuc.Clear();
            List<DanhMuc> result = new List<DanhMuc>();
            //add ALL option
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = -1;
                danhMuc.TenDM = "Tất cả";
                result.Add(danhMuc);
            }
            //load danh muc
            List<DanhMuc> danhMucs = DanhMucs.GetAll();
            result.AddRange(danhMucs);
            return result;
        }


        public bool AddMon(Mon mon)
        {
            if (mon == null)
            {
                MessageBox.Show("Thông tin món không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            
            if (string.IsNullOrWhiteSpace(mon.TenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mon.GiaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(mon.DonVi))
            {
                MessageBox.Show("Vui lòng nhập đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                
                bool result = Mons.Add(mon) > 0;

                if (result)
                {
                    //MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                    return true;
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool EditMon(Mon mon)
        {
            if (mon == null || string.IsNullOrWhiteSpace(mon.MaMon.ToString()))
            {
                MessageBox.Show("Thông tin món không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           
            if (string.IsNullOrWhiteSpace(mon.TenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (mon.GiaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(mon.DonVi))
            {
                MessageBox.Show("Vui lòng nhập đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                // Build update string
                bool result = Mons.Update(mon) > 0;

                if (result)
                {
                    //MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                    return true;
                }
                else
                {
                    MessageBox.Show("Cập nhật món thất bại! Có thể món không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteMon(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                MessageBox.Show("Mã món không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //check mon co trong danh muc mon khong
            
            if (DanhMuc_Mons.Count($"MaMon = {maMon}") > 0)
            {
                List<DanhMuc_Mon> congThucs = DanhMuc_Mons.ToList(DanhMuc_Mons.select().Where($"MaMon = {maMon}").ExecuteToDataReader());
                //MySQL_DB.Instance.Delete("CongThuc", $"MaMon = {maMon}");
                foreach (DanhMuc_Mon congThuc in congThucs)
                {
                    DanhMuc_Mons.Delete(congThuc);
                }
                    //xoa mon khoi danh muc mon
                    //MySQL_DB.Instance.Delete("DanhMuc_Mon", $"MaMon = {maMon}");
            }
            //xoa cong thuc
            
            if (CongThucs.Count($"MaMon = {maMon}") > 0)
            {
                List<CongThuc> congThucs = CongThucs.ToList(CongThucs.select().Where($"MaMon = {maMon}").ExecuteToDataReader());
                //MySQL_DB.Instance.Delete("CongThuc", $"MaMon = {maMon}");
                foreach (CongThuc congThuc in congThucs)
                {
                    CongThucs.Delete(congThuc);
                }
            }

            try
            {
                int maMonInt = Convert.ToInt32(maMon);
                bool result = Mons.Delete(Mons.Get(maMonInt)) > 0;

                if (result)
                {
                    //MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMenu();
                    return true;
                }
                else
                {
                    MessageBox.Show("Xóa món thất bại! Có thể món không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public void timMon(string findName, int findDanhMucID)
        {
            //clear
            this.Model.Table.Rows.Clear();
            //creat query
            string conditionDMQuery = "";
            string conditionNameQuery = "";


            if (findDanhMucID > 0)
            {
                conditionDMQuery += $" JOIN DanhMuc_Mon ON Mon.MaMon = DanhMuc_Mon.MaMon ";
                conditionDMQuery += $" JOIN DanhMuc ON DanhMuc_Mon.MaDM = DanhMuc.MaDM WHERE DanhMuc.MaDM = {findDanhMucID} ";
            }

            conditionNameQuery += $" Mon.TenMon LIKE '%{findName}%'";

            //excute query
            DataTable dt = null;
            if (findDanhMucID > 0)
            {
                //dt = MySQL_DB.Instance.SelectJoin("Mon", "Mon.*", $" {conditionDMQuery} AND {conditionNameQuery}");
                string sql = $"SELECT Mon.* FROM Mon {conditionDMQuery} AND {conditionNameQuery};";
                Console.WriteLine(sql);
                dt = DB.ExecuteQuery(sql);
            }
            else
            {
                //dt = MySQL_DB.Instance.Select("Mon", "*", conditionNameQuery);
                string sql = $"SELECT Mon.* FROM Mon WHERE {conditionNameQuery};";
                Console.WriteLine(sql);
                dt = DB.ExecuteQuery(sql);
            }
            if (dt == null)
            {
                return;
            }
            //add mons
            //loadMons(dt);
            this.Model.Table = dt;
        }

        //QLCongThuc
        public void LoadCongThuc(int maMon)
        {
            //this.Model.seletedMaMon = maMon;
            string condition = $"MaMon = {maMon}";
            //DataTable dt = MySQL_DB.Instance.Select("CongThuc", "*", condition);
            //DataTable dt = MySQL_DB.Instance.SelectJoin("CongThuc ct", "ct.MaMon, nl.MaNguyenLieu, nl.TenNguyenLieu, ct.SoLuong, ct.DonVi", 
                        //$" JOIN NguyenLieu nl ON ct.MaNguyenLieu = nl.MaNguyenLieu WHERE ct.MaMon = {maMon}");
            string sql = $"SELECT ct.MaMon, nl.MaNguyenLieu, nl.TenNguyenLieu, ct.SoLuong, nl.DonVi FROM CongThuc ct JOIN NguyenLieuTonKho nl ON ct.MaNguyenLieu = nl.MaNguyenLieu WHERE ct.MaMon = {maMon};";
            Console.WriteLine(sql);
            DataTable dt = DB.ExecuteQuery(sql);
            //return dt;
            this.Model.CongThuc = dt;
        }
        
        public void loadNguyenLieu(Krypton.Toolkit.KryptonComboBox cb)
        {
            //DataTable dt = MySQL_DB.Instance.Select("NguyenLieu", "NguyenLieu.MaNguyenLieu, NguyenLieu.TenNguyenLieu");
            DataTable dt = DB.ExecuteQuery("SELECT NguyenLieuTonKho.MaNguyenLieu, NguyenLieuTonKho.TenNguyenLieu FROM NguyenLieuTonKho;");
            cb.DataSource = dt;
            cb.DisplayMember = "TenNguyenLieu";
            cb.ValueMember = "MaNguyenLieu";
        }

        public int getMaNguyenLieu(string tenNguyenLieu)
        {
            //DataTable dt = MySQL_DB.Instance.Select("NguyenLieu", "*", $"TenNguyenLieu = '{tenNguyenLieu}'");
            DataTable dt = DB.ExecuteQuery($"SELECT MaNguyenLieu FROM NguyenLieuTonKho WHERE TenNguyenLieu = '{tenNguyenLieu}'");
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32( dt.Rows[0]["MaNguyenLieu"]);
            }
            return -1;
        }

        public void loadDonVi(Krypton.Toolkit.KryptonComboBox cb)
        {
            EnumDonVi[] donVis = (EnumDonVi[])Enum.GetValues(typeof(EnumDonVi));
            var donVisList = donVis.Select(dv => new
            {
                Name = dv.GetDisplayName(),
                Value = dv
            }).ToList();
            cb.DataSource = donVisList;
            cb.DisplayMember = "Name";
            cb.ValueMember = "Value";
        }

        public void luuCongThuc()
        {
            foreach (DataRow row in this.Model.CongThuc.Rows)
            {
                int maMon = 0;
                int maNguyenLieu = 0;
                Decimal soLuong = 0;
                try
                {
                    maMon = Convert.ToInt32(row["MaMon"]);
                    maNguyenLieu = Convert.ToInt32(row["MaNguyenLieu"]);
                    soLuong = Convert.ToDecimal(row["SoLuong"]);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                bool exists = this.CongThucExists(maMon, maNguyenLieu);
                if(!exists)
                {
                    // Insert new record
                    string fields = "MaMon, MaNguyenLieu, SoLuong";
                    string values = $"{maMon}, {maNguyenLieu}, {soLuong}'";
                    //MySQL_DB.Instance.Insert("CongThuc", fields, values);
        
                    CongThuc congThuc = new CongThuc
                    {
                        MaMon = maMon,
                        MaNguyenLieu = maNguyenLieu,
                        SoLuong = soLuong
                    };
                    CongThucs.Add(congThuc);
                    
                }
                else
                {
                    string updates = $"SoLuong = {soLuong}'";
                    string condition = $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}";
                    //MySQL_DB.Instance.Update("CongThuc", updates, condition);
                    CongThuc congThuc = new CongThuc
                    {
                        MaMon = maMon,
                        MaNguyenLieu = maNguyenLieu,
                        SoLuong = soLuong
                    };
                    CongThucs.Update(congThuc);

                }

            }
        }

        public void xoaCongThuc(int maMon, int maNguyenLieu)
        {
            //string condition = $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}";
            //MySQL_DB.Instance.Delete("CongThuc", condition);
            CongThuc congThuc = new CongThuc
            {
                MaMon = maMon,
                MaNguyenLieu = maNguyenLieu
            };
            CongThucs.Delete(congThuc);
        }

        public bool CongThucExists(int maMon, int maNguyenLieu)
        {
            //return MySQL_DB.Instance.Count("CongThuc", $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}") > 0;
            return CongThucs.Count($"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}") > 0;
        }

        //QL phan loai/ danh muc
        public void LoadDanhMuc()
        {
            //DataTable dt = MySQL_DB.Instance.Select("CongThuc", "*", condition);
            //DataTable dt = MySQL_DB.Instance.Select("DanhMuc dm LEFT JOIN DanhMuc_Mon dmm ON dm.MaDM = dmm.MaDM GROUP BY dm.MaDM;",
            //                "dm.*, COUNT(dmm.MaMon) AS SoLuongMon");
            string sql = $"SELECT dm.*, COUNT(dmm.MaMon) AS SoLuongMon FROM DanhMuc dm LEFT JOIN DanhMuc_Mon dmm ON dm.MaDM = dmm.MaDM GROUP BY dm.MaDM;";
            Console.WriteLine(sql);
            DataTable dt = DB.ExecuteQuery(sql);
            //return dt;
            this.Model.DanhMucList = dt;
        }
        public void LoadMonInDanhMuc(int maDM)
        {
            //DataTable dt = MySQL_DB.Instance.SelectJoin("Mon m", "m.*",
            //                $" JOIN DanhMuc_Mon dm ON m.MaMon = dm.MaMon WHERE dm.MaDM = {maDM}");
            string sql = $"SELECT m.* FROM Mon m JOIN DanhMuc_Mon dm ON m.MaMon = dm.MaMon WHERE dm.MaDM = {maDM}; ";
            Console.WriteLine(sql);
            DataTable dt = DB.ExecuteQuery(sql);
            this.Model.MonInDanhMucList = dt;
        }
        public void LoadMonNotInDanhMuc(int maDM)
        {
            //DataTable dt = MySQL_DB.Instance.SelectJoin("Mon m", "m.*",
            //                $" WHERE m.MaMon NOT IN (SELECT dm.MaMon FROM DanhMuc_Mon dm WHERE dm.MaDM = {maDM})");
            string sql = $"SELECT m.* FROM Mon m WHERE m.MaMon NOT IN (  SELECT dm.MaMon FROM DanhMuc_Mon dm WHERE dm.MaDM = {maDM});";
            Console.WriteLine(sql);
            DataTable dt = DB.ExecuteQuery(sql);
            this.Model.MonNotInDanhMucList = dt;
        }
        
        public void AddDanhMuc(string tenDM)
        {
            if (TenDanhMucExists(tenDM))
            {
                MessageBox.Show($"Danh mục: {tenDM} đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string fields = "TenDM";
            //string values = $"'{tenDM}'";
            //MySQL_DB.Instance.Insert("DanhMuc", fields, values);
            DanhMuc danhMuc = new DanhMuc
            {
                TenDM = tenDM
            };
            DanhMucs.Add(danhMuc);
        }

        public bool TenDanhMucExists(string tenDM)
        {
            //return MySQL_DB.Instance.Count("DanhMuc", $"TenDM = '{tenDM}'") > 0;
            return DanhMucs.Count($"TenDM = '{tenDM}'") > 0;
        }

        public void EditDanhMuc(int maDM, string tenDM)
        {
            if (TenDanhMucExists(tenDM))
            {
                MessageBox.Show($"Danh mục: {tenDM} đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string updates = $"TenDM = '{tenDM}'";
            //string condition = $"MaDM = {maDM}";
            //MySQL_DB.Instance.Update("DanhMuc", updates, condition);
            DanhMuc danhMuc = new DanhMuc
            {
                MaDM = maDM,
                TenDM = tenDM
            };
            DanhMucs.Update(danhMuc);
        }
        public void DeleteDanhMuc(int maDM)
        {
            //check if danh muc is used
            //if (MySQL_DB.Instance.Count("DanhMuc_Mon", $"MaDM = {maDM}") > 0)
            if (DanhMuc_Mons.Count($"MaDM = {maDM}") > 0)
            {
                MessageBox.Show($"Danh mục đang có món, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string condition = $"MaDM = {maDM}";
            //MySQL_DB.Instance.Delete("DanhMuc", condition);
            DanhMuc danhMuc = new DanhMuc
            {
                MaDM = maDM
            };
            DanhMucs.Delete(danhMuc);
        }
    
        public void AddMonToDanhMuc(int maMon, int maDM)
        {
            //check if exists
            //if (MySQL_DB.Instance.Count("DanhMuc_Mon", $"MaMon = {maMon} AND MaDM = {maDM}") > 0)
            if (DanhMuc_Mons.Count($"MaMon = {maMon} AND MaDM = {maDM}") > 0)
            {
                MessageBox.Show($"Món đã có trong danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //string fields = "MaMon, MaDM";
            //string values = $"{maMon}, {maDM}";
            //MySQL_DB.Instance.Insert("DanhMuc_Mon", fields, values);
            DanhMuc_Mon danhMuc_Mon = new DanhMuc_Mon
            {
                MaMon = maMon,
                MaDM = maDM
            };
            DanhMuc_Mons.Add(danhMuc_Mon);
        }

        public void RemoveMonFromDanhMuc(int maMon, int maDM)
        {
            //string condition = $"MaMon = {maMon} AND MaDM = {maDM}";
            //MySQL_DB.Instance.Delete("DanhMuc_Mon", condition);
            DanhMuc_Mon danhMuc_Mon = new DanhMuc_Mon
            {
                MaMon = maMon,
                MaDM = maDM
            };
            DanhMuc_Mons.Delete(danhMuc_Mon);
        }
    }
}