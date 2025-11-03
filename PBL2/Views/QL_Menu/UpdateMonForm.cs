using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Models;
using PBL2.Presenters.QL_Menu;
//--------------------Bin--------------------
namespace PBL2.Views.QL_Menu
{
    public partial class UpdateMonForm : Form
    {
        private QL_MenuPresenter presenter;
        private string maMon;

        public UpdateMonForm(QL_MenuPresenter presenter, string maMon)
        {
            InitializeComponent();
            this.presenter = presenter;
            this.maMon = maMon;
            SetupEventHandlers();
            LoadDishData();
        }

        private void SetupEventHandlers()
        {
            this.btnCapNhat.Click += BtnCapNhat_Click;
            this.btnHuy.Click += BtnHuy_Click;
        }

        private void LoadDishData()
        {
            MonModel mon = presenter.GetMonByMaMon(maMon);
            if (mon != null)
            {
                txtMaMonAn.Text = mon.MaMon;
                txtMaMonAn.ReadOnly = true;
                txtMaMonAn.BackColor = System.Drawing.SystemColors.Control; 
                txtTenMon.Text = mon.TenMon;
                txtGia.Text = mon.GiaBan.ToString();
                txtDonVi.Text = mon.DonVi;
            }
            else
            {
                MessageBox.Show("Không thể tải thông tin món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                MessageBox.Show("Vui lòng nhập giá bán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtGia.Text, out decimal giaBan) || giaBan <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            MonModel mon = new MonModel
            {
                MaMon = this.maMon,
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = giaBan,
                DonVi = txtDonVi.Text.Trim()
            };

            
            if (presenter.EditMon(mon))
            {
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }
}