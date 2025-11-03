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
    public partial class DeleteNhanVienForm : Form
    {
        private string maNV;
        private string tenNV;
        public DeleteNhanVienForm(string maNV, string tenNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            this.tenNV = tenNV;
        }

        private void DeleteNhanVienForm_Load(object sender, EventArgs e)
        {
        
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Opacity = 0; // ẩn form trắng

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhân viên '{tenNV}' (Mã: {maNV})?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string condition = $"MaNV = '{maNV}'";

                    MySQL_DB.Instance.Delete("Account", condition);

                    bool success = MySQL_DB.Instance.Delete("nhanvien", condition);

                    if (success)
                    {
                        MessageBox.Show($"Xóa nhân viên {tenNV} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}
