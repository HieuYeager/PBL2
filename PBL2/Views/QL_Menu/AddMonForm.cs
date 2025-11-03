using PBL2.Models;
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
    public partial class AddMonForm : Form
    {
        private QL_MenuPresenter presenter;

        public AddMonForm(QL_MenuPresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            this.btnThem.Click += BtnThem_Click;
            this.btnHuy.Click += BtnHuy_Click;
            this.txtMaMonAn.TextChanged += TxtMaMonAn_TextChanged;
        }
        private void TxtMaMonAn_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
          
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
           
            string maMon = txtMaMonAn.Text.Trim();
            if (!string.IsNullOrWhiteSpace(maMon))
            {
                if (!int.TryParse(maMon, out int maMonValue) || maMonValue <= 0)
                {
                    MessageBox.Show("Mã món phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                MonModel existingMon = presenter.GetMonByMaMon(maMon);
                if (existingMon != null)
                {
                    MessageBox.Show($"Mã món {maMon} đã tồn tại! Vui lòng chọn mã khác hoặc để trống để tự động tạo.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

      
            MonModel mon = new MonModel
            {
                MaMon = Convert.ToInt32(maMon),
                TenMon = txtTenMon.Text.Trim(),
                GiaBan = giaBan,
                DonVi = txtDonVi.Text.Trim()
            };

            
            if (presenter.AddMon(mon))
            {
                
                // Clear form
                txtMaMonAn.Clear();
                txtTenMon.Clear();
                txtGia.Clear();
                txtDonVi.Clear();
                // Close form on success
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