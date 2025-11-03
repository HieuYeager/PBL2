using PBL2.Models;
using PBL2.Views.QL_Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Bin--------------------
namespace PBL2.Presenters.QL_Menu
{
    public class QL_MenuPresenter : IPresenter<QL_MenuPage, QL_MenuPageModel>
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
                
                if (!string.IsNullOrWhiteSpace(mon.MaMon) && int.TryParse(mon.MaMon, out int maMonValue))
                {
                    fields = $"MaMon, {fields}";
                    values = $"{maMonValue}, {values}";
                }

                int result = MySQL_DB.Instance.Insert("Mon", fields, values);

                if (result > 0)
                {
                    MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (mon == null || string.IsNullOrWhiteSpace(mon.MaMon))
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
                    MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            try
            {
                string condition = $"MaMon = {maMon}";
                bool result = MySQL_DB.Instance.Delete("Mon", condition);

                if (result)
                {
                    MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MaMon = row["MaMon"].ToString(),
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
    }
}