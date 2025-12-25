using MySqlX.XDevAPI.Common;
using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.QLTonKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    public partial class NhapKhoForm : Form
    {
        private NhanVien currentAccount;

        QLTonKhoPresenter presenter;

        private int maNguyenLieu {
            get
            {
                try
                {
                    return int.Parse(comboBoxTenNL.SelectedValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set 
            {
                comboBoxTenNL.SelectedValue = value;
            }
        }
        private int soLuongNhap
        {
            get
            {
                try
                {
                    return int.Parse(txtSoLuong.Text.Trim());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                txtSoLuong.Text = value.ToString();
            }
        }
        private string ghiChu
        {
            get
            {
                return txtGhiChu.Text.Trim();
            }
            set
            {
                txtGhiChu.Text = value;
            }
        }

        public NhapKhoForm(NhanVien account, QLTonKhoPresenter qLDonPresenter)
        {
            InitializeComponent();
            this.currentAccount = account;
            this.presenter = qLDonPresenter;
            //
            this.txtMaNV.Text = this.currentAccount.MaNV;
            //load comboBox ten nguyen lieu
            List<NguyenLieuTonKho> nguyenLieuTonKhos = this.presenter.GetAllLieu();

            this.comboBoxTenNL.DataSource = nguyenLieuTonKhos;
            this.comboBoxTenNL.DisplayMember = "TenNguyenLieu";
            this.comboBoxTenNL.ValueMember = "MaNguyenLieu";
        }

        private void txtMaNL_choose_Click(object sender, EventArgs e)
        {
            //LoadNguyenLieu();
            EnumDonVi donVi = this.presenter.GetDonVi(maNguyenLieu);
            txtDonVi.Text = donVi.GetDisplayName();
        }

        private void Huy_Click(object sender, EventArgs e)
        {
            this.presenter.LoadDanhSachNguyenLieu();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void XacNhan_Click(object sender, EventArgs e)
        {
            if(soLuongNhap <= 0)
            {
                MessageBox.Show("Số lượng nhập không hợp lệ", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LichSuTonKho lichSuTonKho = new LichSuTonKho
            {
                MaNV = this.currentAccount.MaNV,
                MaNguyenLieu = maNguyenLieu,
                HoatDong = EnumHoatDong.NhapKho,
                SoLuong = soLuongNhap,
                ghiChu = this.ghiChu,
                Ngay = DateTime.Now
            };
            this.presenter.NhapKho(lichSuTonKho);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
