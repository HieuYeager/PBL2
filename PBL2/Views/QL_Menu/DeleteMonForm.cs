using PBL2.Class;
using PBL2.Presenters;
using PBL2.Presenters.QL_Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Bin--------------------
namespace PBL2.Views.QL_Menu
{
    public partial class DeleteMonForm : Form
    {
        private QL_MenuPresenter presenter;
        private string maMon;
        private string tenMon;

        public DeleteMonForm(QL_MenuPresenter presenter, string maMon, string tenMon)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.maMon = maMon;
            this.tenMon = tenMon;
            SetupEventHandlers();
            UpdateDeleteMessage();
        }

        private void SetupEventHandlers()
        {
            this.btnXoa.Click += BtnXoa_Click;
            this.btnHuy2.Click += BtnHuy2_Click;
        }

        private void UpdateDeleteMessage()
        {
            if (!string.IsNullOrWhiteSpace(tenMon))
            {
                lbText.Text = $"Bạn có chắc muốn xóa món \"{tenMon}\" không?";
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                MessageBox.Show("Mã món không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (presenter.DeleteMon(maMon))
            {
                // Close form on success
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnHuy2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
