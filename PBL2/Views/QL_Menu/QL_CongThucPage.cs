using Google.Protobuf.WellKnownTypes;
using Mysqlx.Resultset;
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_Menu;
using PBL2.Views.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PBL2.Views.QL_Menu
{
    public partial class QL_CongThucPage : UserControl, IView<QL_MenuPresenter, QL_MenuPageModel>
    {
        public QL_MenuPresenter Presenter { get; set; }

        public QL_MenuPageModel Model { get; set; }

        //chuyen sang trang khac
        public delegate void LoadQL_MenuPageDelegate();
        public event LoadQL_MenuPageDelegate LoadQL_MenuPageHandler;

        //constructor
        public QL_CongThucPage(QL_MenuPresenter presenter)
        {
            InitializeComponent();
            //presenter
            this.Presenter = presenter;
            //model
            this.Model = this.Presenter.Model;
            //load comboBox
            this.Presenter.loadNguyenLieu(this.cmBoxNguyenLieu);
            this.Presenter.loadDonVi(this.cmBoxDonVi);
            //load
            this.Presenter.LoadMenu();
            this.LoadTable();
            this.loadDataCongThucTable();
            
            //SetupEventHandlers();
            //load combobox danhmuc
            List<DanhMuc> danhmucs = this.Presenter.loadDM();
            this.ComboBoxDanhMuc.DataSource = danhmucs;
            this.ComboBoxDanhMuc.ValueMember = "MaDM";
            this.ComboBoxDanhMuc.DisplayMember = "TenDM";
            this.ComboBoxDanhMuc.SelectedIndex = 0;
        }
        //event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            loadDetail(dataGridView1.Rows[e.RowIndex]);
        }

        private void UpdateMonBtn_Click(object sender, EventArgs e)
        {
            //foreach (DataRow row in this.Model.CongThuc.Rows)
            //{
            //    string tenNguyenLieu = row["TenNguyenLieu"].ToString();
            //    string soLuong = row["SoLuong"].ToString();
            //    string donVi = row["DonVi"].ToString();
            //    string maMon = row["MaMon"].ToString();
            //    string maNguyenLieu = row["MaNguyenLieu"].ToString();
            //    MessageBox.Show($"ma mon: {maMon}, ma nguyen lieu: {maNguyenLieu}, Ten nguyen lieu: {tenNguyenLieu}, soluong: {soLuong}, don vi: {donVi}");
            //}
            this.Presenter.luuCongThuc();
            //MessageBox.Show("Chưa xong", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.ComboBoxDanhMuc.SelectedValue);
            try
            {
                int danhMucId = Convert.ToInt32(this.ComboBoxDanhMuc.SelectedValue);
                this.Presenter.timMon(this.FindTxt.Text, danhMucId);
                this.LoadTable();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //event table nguyen lieu
        private void dataGridViewNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            loadNguyenLieu(this.dataGridViewCongThuc.Rows[e.RowIndex]);
        }

        private void comboBoxNguyenLieu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //DonViNguyenLieu donVi = (DonViNguyenLieu)cmBoxDonVi.SelectedValue;
            //MessageBox.Show($"Người dùng chọn: {donVi}");
            try
            {
                int maNguyenLieu = Convert.ToInt32(this.cmBoxNguyenLieu.SelectedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }

            foreach (DataGridViewRow row in this.dataGridViewCongThuc.Rows)
            {
                if (row.Cells["MaNguyenLieu"].Value.ToString() == this.cmBoxNguyenLieu.SelectedValue.ToString())
                {
                    loadNguyenLieu(row);
                    return;
                }
            }

            this.txtSoLuong.Text = "0";
            this.canAdd(true);
        }

        private void btnAddNguyenLieu_Click(object sender, EventArgs e)
        {
            double soLuong = 0;
            DonViNguyenLieu donVi = DonViNguyenLieu.g;

            try
            {
                soLuong = double.Parse(this.txtSoLuong.Text);
                donVi = (DonViNguyenLieu)cmBoxDonVi.SelectedValue;
                if(soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = this.Model.CongThuc.NewRow();
                row["MaMon"] = this.Model.seletedMaMon.ToString();
                row["MaNguyenLieu"] = this.cmBoxNguyenLieu.SelectedValue.ToString();
                row["TenNguyenLieu"] = this.cmBoxNguyenLieu.Text;
                row["SoLuong"] = soLuong.ToString();
                row["donVi"] = donVi.GetDisplayName();

                this.Model.CongThuc.Rows.Add(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            this.canAdd(false);
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            int maMon = this.Model.seletedMaMon;
            int maNguyenLieu = 0;
            try
            {
                maNguyenLieu = Convert.ToInt32(this.cmBoxNguyenLieu.SelectedValue);
                MessageBox.Show($"Người dùng chọn: {maNguyenLieu}");
                if(this.Presenter.CongThucExists(maMon, maNguyenLieu))
                {
                    this.Presenter.xoaCongThuc(maMon, maNguyenLieu);
                }
                this.Model.CongThuc.Rows.Remove(this.Model.CongThuc.Rows[this.dataGridViewCongThuc.SelectedRows[0].Index]);
                dataGridView1.ClearSelection();              // Bỏ chọn các dòng khác
                dataGridView1.Rows[0].Selected = true;
                this.loadNguyenLieu(this.dataGridViewCongThuc.SelectedRows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //txt soluong
        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Người dùng đã nhập xong và nhấn Enter!");
                e.SuppressKeyPress = true; // tránh tiếng 'ding'
                this.update_Soluong();
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Người dùng đã nhập xong và rời TextBox!");
            this.update_Soluong();
        }

        //cmb don vi
        private void comboBoxDonVi_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.dataGridViewCongThuc.Rows[this.dataGridViewCongThuc.SelectedRows[0].Index].Cells["donVi"].Value = ((DonViNguyenLieu)cmBoxDonVi.SelectedValue).GetDisplayName();
        }

        //back 
        private void BackBtn_Click(object sender, EventArgs e)
        {
            //this.Back();
            this.LoadQL_MenuPageHandler?.Invoke();
        }

        //table load
        public void loadDataCongThucTable()
        {
            this.Presenter.LoadCongThuc(this.Model.seletedMaMon);
            this.dataGridViewCongThuc.Columns.Clear();
            this.dataGridViewCongThuc.DataSource = Model.CongThuc;
            //custom column
            try
            {
                this.dataGridViewCongThuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridViewCongThuc.Columns["MaMon"].Visible = false;
                this.dataGridViewCongThuc.Columns["MaNguyenLieu"].Visible = false;
                this.dataGridViewCongThuc.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
                this.dataGridViewCongThuc.Columns["TenNguyenLieu"].FillWeight = 60;
                this.dataGridViewCongThuc.Columns["SoLuong"].HeaderText = "Số lượng";
                this.dataGridViewCongThuc.Columns["SoLuong"].FillWeight = 20;
                this.dataGridViewCongThuc.Columns["DonVi"].HeaderText = "Đơn vị tính";
                this.dataGridViewCongThuc.Columns["DonVi"].FillWeight = 20;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if(dataGridViewCongThuc.Rows.Count > 0) this.loadNguyenLieu(dataGridViewCongThuc.Rows[0]);
            else this.canAdd(true);
        }
        public void LoadTable()
        {
            //this.Presenter.LoadMenu();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.Table;
            //custom column
            try
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.Columns["MaMon"].HeaderText = "Mã món";
                this.dataGridView1.Columns["MaMon"].FillWeight = 5;
                this.dataGridView1.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridView1.Columns["TenMon"].FillWeight = 30;
                this.dataGridView1.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridView1.Columns["GiaBan"].FillWeight = 15;
                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridView1.Columns["DonVi"].FillWeight = 15;
                this.dataGridView1.Columns["DonVi"].Visible = false;
                this.dataGridView1.Columns["URl_Anh"].Visible = false;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            this.loadDetail(dataGridView1.Rows[0]);
        }

        public void loadDetail(DataGridViewRow row)
        {
            try
            {
                this.Model.seletedMaMon = int.Parse(row.Cells["MaMon"].Value.ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            this.loadDataCongThucTable();
            if(this.dataGridViewCongThuc.Rows.Count == 0) return;
            this.loadNguyenLieu(this.dataGridViewCongThuc.Rows[0]);
        }

        public void loadNguyenLieu(DataGridViewRow row)
        {
            this.canAdd(false);
            double soluong = 0;
            int maNguyenLieu = 0;
            DonViNguyenLieu donVi = DonViNguyenLieu.g;
            try
            {
                soluong = double.Parse(row.Cells["SoLuong"].Value.ToString());
                maNguyenLieu = this.Presenter.getMaNguyenLieu(row.Cells["TenNguyenLieu"].Value.ToString());
                switch (row.Cells["DonVi"].Value.ToString())
                {
                    case "g":
                        donVi = DonViNguyenLieu.g;
                        break;
                    case "Kg":
                        donVi = DonViNguyenLieu.Kg;
                        break;
                    case "L":
                        donVi = DonViNguyenLieu.L;
                        break;
                    case "ml":
                        donVi = DonViNguyenLieu.ml;
                        break;
                }
                this.cmBoxNguyenLieu.SelectedValue = maNguyenLieu;
                this.txtSoLuong.Text = soluong.ToString();
                this.cmBoxDonVi.SelectedValue = donVi;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        //btn action
        private void canAdd(bool canAdd)
        {
            if (canAdd)
            {
                this.btnAddNguyenLieu.Visible = true;
                this.btnXoaNguyenLieu.Visible = false;
            }
            else
            {
                this.btnAddNguyenLieu.Visible = false;
                this.btnXoaNguyenLieu.Visible = true;
            }
        }

        private void update_Soluong()
        {
            double soLuong = 0;
            try
            {
                soLuong = double.Parse(this.txtSoLuong.Text);
                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtSoLuong.Text = this.dataGridViewCongThuc.SelectedRows[0].Cells["SoLuong"].Value.ToString();
                    return;
                }
                this.dataGridViewCongThuc.SelectedRows[0].Cells["SoLuong"].Value = soLuong.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }

}
