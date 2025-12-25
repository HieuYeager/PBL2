using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.QLTonKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    public partial class LichSu : Form
    {
        QLTonKhoPresenter Presenter;
        private int maNguyenLieu
        {
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

        public LichSu(QLTonKhoPresenter qLTonKhoPresenter)
        {
            InitializeComponent();
            this.Presenter = qLTonKhoPresenter;

            //load comboBox ten nguyen lieu
            List<NguyenLieuTonKho> nguyenLieuTonKhos = new List<NguyenLieuTonKho>();
            nguyenLieuTonKhos.Add(new NguyenLieuTonKho() { MaNguyenLieu = -1, TenNguyenLieu = "tất cả" });
            nguyenLieuTonKhos.AddRange(this.Presenter.GetAllLieu());
            this.comboBoxTenNL.DataSource = nguyenLieuTonKhos;
            this.comboBoxTenNL.DisplayMember = "TenNguyenLieu";
            this.comboBoxTenNL.ValueMember = "MaNguyenLieu";
            maNguyenLieu = -1;
        }

        public void LoadLichSuTonKho()
        {
            this.dataGridView1.Columns.Clear();
            List<LichSuTonKho> lichSuTonKhos = this.Presenter.GetAllLichSuTonKho();

            if (lichSuTonKhos != null && lichSuTonKhos.Count > 0)
            {
                dataGridView1.DataSource = lichSuTonKhos;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dataGridView1.Columns["ID"].HeaderText = "ID";
                this.dataGridView1.Columns["ID"].FillWeight = 5;

                this.dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";
                this.dataGridView1.Columns["MaNV"].FillWeight = 5;
                this.dataGridView1.Columns["MaNV"].Visible = false;

                this.dataGridView1.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                this.dataGridView1.Columns["TenNhanVien"].FillWeight = 12;
                this.dataGridView1.Columns["TenNhanVien"].ReadOnly = true;

                this.dataGridView1.Columns["MaNguyenLieu"].HeaderText = "Mã NL";
                this.dataGridView1.Columns["MaNguyenLieu"].FillWeight = 5;
                this.dataGridView1.Columns["MaNguyenLieu"].Visible = false;

                this.dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
                this.dataGridView1.Columns["TenNguyenLieu"].FillWeight = 17;
                this.dataGridView1.Columns["TenNguyenLieu"].ReadOnly = true;

                this.dataGridView1.Columns["HoatDong"].HeaderText = "Hoạt động (enum)";
                this.dataGridView1.Columns["HoatDong"].FillWeight = 8;
                this.dataGridView1.Columns["HoatDong"].Visible = false;

                this.dataGridView1.Columns["HoatDongStr"].HeaderText = "Hoạt động";
                this.dataGridView1.Columns["HoatDongStr"].FillWeight = 10;
                this.dataGridView1.Columns["HoatDongStr"].ReadOnly = true;
                this.dataGridView1.Columns["HoatDongStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                this.dataGridView1.Columns["SoLuong"].FillWeight = 10;
                this.dataGridView1.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridView1.Columns["DonVi"].FillWeight = 6;
                this.dataGridView1.Columns["DonVi"].ReadOnly = true;

                this.dataGridView1.Columns["ghiChu"].HeaderText = "Ghi chú";
                this.dataGridView1.Columns["ghiChu"].FillWeight = 18;

                this.dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
                this.dataGridView1.Columns["Ngay"].FillWeight = 12;
                this.dataGridView1.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                this.dataGridView1.Columns["Ngay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả.");
            }
        }

        private void txtMaNL_choose_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            List<LichSuTonKho> lichSuTonKhos = this.Presenter.GetAllLichSuTonKho();
            //LoadNguyenLieu();
            if (maNguyenLieu != -1)
            {
                lichSuTonKhos = this.Presenter.GetAllLichSuTonKho($"{LichSuTonKhos.MaNguyenLieu} = '{maNguyenLieu}'");

            }
            if (lichSuTonKhos != null && lichSuTonKhos.Count > 0)
            {
                dataGridView1.DataSource = lichSuTonKhos;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dataGridView1.Columns["ID"].HeaderText = "ID";
                this.dataGridView1.Columns["ID"].FillWeight = 5;

                this.dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";
                this.dataGridView1.Columns["MaNV"].FillWeight = 5;
                this.dataGridView1.Columns["MaNV"].Visible = false;

                this.dataGridView1.Columns["TenNhanVien"].HeaderText = "Nhân viên";
                this.dataGridView1.Columns["TenNhanVien"].FillWeight = 12;
                this.dataGridView1.Columns["TenNhanVien"].ReadOnly = true;

                this.dataGridView1.Columns["MaNguyenLieu"].HeaderText = "Mã NL";
                this.dataGridView1.Columns["MaNguyenLieu"].FillWeight = 5;
                this.dataGridView1.Columns["MaNguyenLieu"].Visible = false;

                this.dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
                this.dataGridView1.Columns["TenNguyenLieu"].FillWeight = 17;
                this.dataGridView1.Columns["TenNguyenLieu"].ReadOnly = true;

                this.dataGridView1.Columns["HoatDong"].HeaderText = "Hoạt động (enum)";
                this.dataGridView1.Columns["HoatDong"].FillWeight = 8;
                this.dataGridView1.Columns["HoatDong"].Visible = false;

                this.dataGridView1.Columns["HoatDongStr"].HeaderText = "Hoạt động";
                this.dataGridView1.Columns["HoatDongStr"].FillWeight = 10;
                this.dataGridView1.Columns["HoatDongStr"].ReadOnly = true;
                this.dataGridView1.Columns["HoatDongStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                this.dataGridView1.Columns["SoLuong"].FillWeight = 10;
                this.dataGridView1.Columns["SoLuong"].DefaultCellStyle.Format = "N2";
                this.dataGridView1.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridView1.Columns["DonVi"].FillWeight = 6;
                this.dataGridView1.Columns["DonVi"].ReadOnly = true;

                this.dataGridView1.Columns["ghiChu"].HeaderText = "Ghi chú";
                this.dataGridView1.Columns["ghiChu"].FillWeight = 18;

                this.dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
                this.dataGridView1.Columns["Ngay"].FillWeight = 12;
                this.dataGridView1.Columns["Ngay"].DefaultCellStyle.Format = "dd/MM/yyyy";
                this.dataGridView1.Columns["Ngay"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            else
            {
                
            }
        }


        private void LichSu_Load(object sender, EventArgs e) {}
        private void textBox1_TextChanged(object sender, EventArgs e) {}

        ///------------------------------------------------------

    }
}
