using PBL2.Models;
using PBL2.Views.QL_Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Class;
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
            DataTable dt = MySQL_DB.Instance.Select("Mon", "*");
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
            DataTable dt = MySQL_DB.Instance.Select("DanhMuc", "*");
            foreach (DataRow row in dt.Rows)
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = int.Parse(row["MaDM"].ToString());
                danhMuc.TenDM = row["TenDM"].ToString();
                result.Add(danhMuc);
            }
            return result;
        }


        public bool AddMon(MonModel mon)
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
                
                string fields = "TenMon, GiaBan, DonVi";
                string values = $"'{mon.TenMon}', {mon.GiaBan}, '{mon.DonVi}'";
                
                if (!string.IsNullOrWhiteSpace(mon.MaMon.ToString()) && int.TryParse(mon.MaMon.ToString(), out int maMonValue))
                {
                    fields = $"MaMon, {fields}";
                    values = $"{maMonValue}, {values}";
                }

                int result = MySQL_DB.Instance.Insert("Mon", fields, values);

                if (result > 0)
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

                string fields = "TenMon, GiaBan, DonVi";
                string values = $"'{mon.TenMon}', {mon.GiaBan}, '{mon.DonVi}'";

                if (!string.IsNullOrWhiteSpace(mon.MaMon.ToString()) && int.TryParse(mon.MaMon.ToString(), out int maMonValue))
                {
                    fields = $"MaMon, {fields}";
                    values = $"{maMonValue}, {values}";
                }

                int result = MySQL_DB.Instance.Insert("Mon", fields, values);

                if (result > 0)
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


        public bool EditMon(MonModel mon)
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
                string updates = $"TenMon = '{mon.TenMon}', GiaBan = {mon.GiaBan}, DonVi = '{mon.DonVi}'";

                string condition = $"MaMon = {mon.MaMon}";
                int result = MySQL_DB.Instance.Update("Mon", updates, condition);

                if (result > 0)
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
                string updates = $"TenMon = '{mon.TenMon}', GiaBan = {mon.GiaBan}, DonVi = '{mon.DonVi}'";

                string condition = $"MaMon = {mon.MaMon}";
                int result = MySQL_DB.Instance.Update("Mon", updates, condition);

                if (result > 0)
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
            if (MySQL_DB.Instance.Count("DanhMuc_Mon", $"MaMon = {maMon}") > 0)
            {
                //xoa mon khoi danh muc mon
                MySQL_DB.Instance.Delete("DanhMuc_Mon", $"MaMon = {maMon}");
            }
            //xoa cong thuc
            if (MySQL_DB.Instance.Count("CongThuc", $"MaMon = {maMon}") > 0)
            {
                MySQL_DB.Instance.Delete("CongThuc", $"MaMon = {maMon}");
            }

            try
            {
                string condition = $"MaMon = {maMon}";
                bool result = MySQL_DB.Instance.Delete("Mon", condition);

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

        public MonModel GetMonByMaMon(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
                return null;

            try
            {
                DataTable dt = MySQL_DB.Instance.Select("Mon", "*", $"MaMon = {maMon}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    MonModel mon = new MonModel
                    {
                        MaMon =  Convert.ToInt32(row["MaMon"]),
                        TenMon = row["TenMon"].ToString(),
                        GiaBan = Convert.ToDecimal(row["GiaBan"]),
                        DonVi = row["DonVi"].ToString()
                    };
                    return mon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin món: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
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
                dt = MySQL_DB.Instance.SelectJoin("Mon", "Mon.*", $" {conditionDMQuery} AND {conditionNameQuery}");
            }
            else
            {
                dt = MySQL_DB.Instance.Select("Mon", "*", conditionNameQuery);
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
            DataTable dt = MySQL_DB.Instance.SelectJoin("CongThuc ct", "ct.MaMon, nl.MaNguyenLieu, nl.TenNguyenLieu, ct.SoLuong, ct.DonVi", 
                        $" JOIN NguyenLieu nl ON ct.MaNguyenLieu = nl.MaNguyenLieu WHERE ct.MaMon = {maMon}");
            //return dt;
            this.Model.CongThuc = dt;
        }
        
        public void loadNguyenLieu(Krypton.Toolkit.KryptonComboBox cb)
        {
            DataTable dt = MySQL_DB.Instance.Select("NguyenLieu", "NguyenLieu.MaNguyenLieu, NguyenLieu.TenNguyenLieu");
            cb.DataSource = dt;
            cb.DisplayMember = "TenNguyenLieu";
            cb.ValueMember = "MaNguyenLieu";
        }

        public int getMaNguyenLieu(string tenNguyenLieu)
        {
            DataTable dt = MySQL_DB.Instance.Select("NguyenLieu", "*", $"TenNguyenLieu = '{tenNguyenLieu}'");
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32( dt.Rows[0]["MaNguyenLieu"]);
            }
            return -1;
        }

        public void loadDonVi(Krypton.Toolkit.KryptonComboBox cb)
        {
            DonViNguyenLieu[] donVis = (DonViNguyenLieu[])Enum.GetValues(typeof(DonViNguyenLieu));
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
                double soLuong = 0;
                string donVi = row["DonVi"].ToString();
                try
                {
                    maMon = Convert.ToInt32(row["MaMon"]);
                    maNguyenLieu = Convert.ToInt32(row["MaNguyenLieu"]);
                    soLuong = Convert.ToDouble(row["SoLuong"]);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                bool exists = this.CongThucExists(maMon, maNguyenLieu);
                if(!exists)
                {
                    // Insert new record
                    string fields = "MaMon, MaNguyenLieu, SoLuong, DonVi";
                    string values = $"{maMon}, {maNguyenLieu}, {soLuong}, '{donVi}'";
                    MySQL_DB.Instance.Insert("CongThuc", fields, values);
                    
                }
                else
                {
                    string updates = $"SoLuong = {soLuong}, DonVi = '{donVi}'";
                    string condition = $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}";
                    MySQL_DB.Instance.Update("CongThuc", updates, condition);
                }
                    
            }
        }

        public void xoaCongThuc(int maMon, int maNguyenLieu)
        {
            string condition = $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}";
            MySQL_DB.Instance.Delete("CongThuc", condition);
        }

        public bool CongThucExists(int maMon, int maNguyenLieu)
        {
            return MySQL_DB.Instance.Count("CongThuc", $"MaMon = {maMon} AND MaNguyenLieu = {maNguyenLieu}") > 0;
        }

        //QL phan loai/ danh muc
        public void LoadDanhMuc()
        {  
            //DataTable dt = MySQL_DB.Instance.Select("CongThuc", "*", condition);
            DataTable dt = MySQL_DB.Instance.Select("DanhMuc dm LEFT JOIN DanhMuc_Mon dmm ON dm.MaDM = dmm.MaDM GROUP BY dm.MaDM;", 
                            "dm.*, COUNT(dmm.MaMon) AS SoLuongMon");
            //return dt;
            this.Model.DanhMucList = dt;
        }
        public void LoadMonInDanhMuc(int maDM)
        {
            DataTable dt = MySQL_DB.Instance.SelectJoin("Mon m", "m.*",
                            $" JOIN DanhMuc_Mon dm ON m.MaMon = dm.MaMon WHERE dm.MaDM = {maDM}");
            this.Model.MonInDanhMucList = dt;
        }
        public void LoadMonNotInDanhMuc(int maDM)
        {
            DataTable dt = MySQL_DB.Instance.SelectJoin("Mon m", "m.*",
                            $" WHERE m.MaMon NOT IN (SELECT dm.MaMon FROM DanhMuc_Mon dm WHERE dm.MaDM = {maDM})");
            this.Model.MonNotInDanhMucList = dt;
        }
        
        public void AddDanhMuc(string tenDM)
        {
            if (TenDanhMucExists(tenDM))
            {
                MessageBox.Show($"Danh mục: {tenDM} đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fields = "TenDM";
            string values = $"'{tenDM}'";
            MySQL_DB.Instance.Insert("DanhMuc", fields, values);
        }

        public bool TenDanhMucExists(string tenDM)
        {
            return MySQL_DB.Instance.Count("DanhMuc", $"TenDM = '{tenDM}'") > 0;
        }

        public void EditDanhMuc(int maDM, string tenDM)
        {
            if (TenDanhMucExists(tenDM))
            {
                MessageBox.Show($"Danh mục: {tenDM} đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string updates = $"TenDM = '{tenDM}'";
            string condition = $"MaDM = {maDM}";
            MySQL_DB.Instance.Update("DanhMuc", updates, condition);
        }
        public void DeleteDanhMuc(int maDM)
        {
            //check if danh muc is used
            if (MySQL_DB.Instance.Count("DanhMuc_Mon", $"MaDM = {maDM}") > 0)
            {
                MessageBox.Show($"Danh mục đang có món, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string condition = $"MaDM = {maDM}";
            MySQL_DB.Instance.Delete("DanhMuc", condition);
        }
    
        public void AddMonToDanhMuc(int maMon, int maDM)
        {
            //check if exists
            if (MySQL_DB.Instance.Count("DanhMuc_Mon", $"MaMon = {maMon} AND MaDM = {maDM}") > 0)
            {
                MessageBox.Show($"Món đã có trong danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fields = "MaMon, MaDM";
            string values = $"{maMon}, {maDM}";
            MySQL_DB.Instance.Insert("DanhMuc_Mon", fields, values);
        }

        public void RemoveMonFromDanhMuc(int maMon, int maDM)
        {
            string condition = $"MaMon = {maMon} AND MaDM = {maDM}";
            MySQL_DB.Instance.Delete("DanhMuc_Mon", condition);
        }
    }
}