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
    public partial class QL_PhanLoaiPage : UserControl
    {
        public QL_MenuPresenter Presenter { get; set; }

        public QL_MenuPageModel Model { get; set; }

        //chuyen sang trang khac
        public delegate void LoadQL_MenuPageDelegate();
        public event LoadQL_MenuPageDelegate LoadQL_MenuPageHandler;

        //constructor
        public QL_PhanLoaiPage(QL_MenuPresenter presenter)
        {
            InitializeComponent();
            //presenter
            this.Presenter = presenter;
            //model
            this.Model = this.Presenter.Model;
            //load comboBox
            //this.Presenter.loadNguyenLieu(this.cmBoxNguyenLieu);
            //this.Presenter.loadDonVi(this.cmBoxDonVi);
            //load
            this.Presenter.LoadDanhMuc();
            this.LoadTable();
            
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

        private void findBtn_Click(object sender, EventArgs e)
        {
            try
            {    
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Presenter.AddDanhMuc(this.txtTenDanhMuc.Text);
            this.LoadTable();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.Presenter.EditDanhMuc(this.Model.seletedMaDanhMuc, this.txtTenDanhMuc.Text);
            this.LoadTable();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Presenter.DeleteDanhMuc(this.Model.seletedMaDanhMuc);
            this.LoadTable();
        }
        //back 
        private void BackBtn_Click(object sender, EventArgs e)
        {
            //this.Back();
            this.LoadQL_MenuPageHandler?.Invoke();
        }
        //-----------------------------------------------------
        //table in load
        public void loadDataMonInDanhMuc()
        {
            this.Presenter.LoadMonInDanhMuc(this.Model.seletedMaDanhMuc);
            this.dataGridViewIn.Columns.Clear();
            this.dataGridViewIn.DataSource = Model.MonInDanhMucList;
            //custom column
            try
            {
                this.dataGridViewIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridViewIn.Columns["MaMon"].HeaderText = "Mã";
                this.dataGridViewIn.Columns["MaMon"].FillWeight = 10;
                this.dataGridViewIn.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridViewIn.Columns["TenMon"].FillWeight = 50;
                this.dataGridViewIn.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridViewIn.Columns["GiaBan"].FillWeight = 30;
                this.dataGridViewIn.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridViewIn.Columns["DonVi"].Visible = false;
                this.dataGridViewIn.Columns["URl_Anh"].Visible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Cột bo
            DataGridViewButtonColumn ThemBtnCol = new DataGridViewButtonColumn();
            ThemBtnCol.Name = "BoCol";
            ThemBtnCol.HeaderText = "";
            ThemBtnCol.Text = "Bỏ";
            ThemBtnCol.UseColumnTextForButtonValue = false;
            ThemBtnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewIn.Columns.Add(ThemBtnCol);

        }

        private void dataGridViewIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex != dataGridViewIn.Columns["BoCol"].Index) return;
            int maMon = 0;
            try
            {
                maMon = int.Parse(this.dataGridViewIn.Rows[e.RowIndex].Cells["MaMon"].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            this.Presenter.RemoveMonFromDanhMuc(maMon, this.Model.seletedMaDanhMuc);
            this.loadDataMonInDanhMuc();
            this.loadDataMonNotInDanhMuc();
        }
        //nut xoa
        private void dataGridViewIn_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewIn.Columns["BoCol"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Vẽ nút như bình thường
                e.PaintContent(e.CellBounds);
                string imagePath = Path.Combine(MySQL_DB.projectRoot, "Resources", "minus.png");
                // Load ảnh icon
                Image icon = Image.FromFile(imagePath); // Đường dẫn tới icon

                // Tính vị trí để căn giữa ảnh
                int x = e.CellBounds.Left + (e.CellBounds.Width - icon.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - icon.Height) / 2;

                // Vẽ ảnh
                e.Graphics.DrawImage(icon, new Point(x, y));

                e.Handled = true;
            }

        }

        private void dataGridViewIn_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewIn.Columns["BoCol"].Index)
            {
                e.ToolTipText = "Bỏ";
            }

        }


        //---------------------------------------------------
        //table not in load
        public void loadDataMonNotInDanhMuc()
        {
            this.Presenter.LoadMonNotInDanhMuc(this.Model.seletedMaDanhMuc);
            this.dataGridViewNotIn.Columns.Clear();
            this.dataGridViewNotIn.DataSource = Model.MonNotInDanhMucList;
            //custom column
            try
            {
                this.dataGridViewNotIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridViewNotIn.Columns["MaMon"].HeaderText = "Mã";
                this.dataGridViewNotIn.Columns["MaMon"].FillWeight = 10;
                this.dataGridViewNotIn.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridViewNotIn.Columns["TenMon"].FillWeight = 50;
                this.dataGridViewNotIn.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridViewNotIn.Columns["GiaBan"].FillWeight = 30;
                this.dataGridViewNotIn.Columns["DonVi"].HeaderText = "Đơn vị";
                this.dataGridViewNotIn.Columns["DonVi"].Visible = false;
                this.dataGridViewNotIn.Columns["URl_Anh"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //Cột Them
            DataGridViewButtonColumn ThemBtnCol = new DataGridViewButtonColumn();
            ThemBtnCol.Name = "ThemCol";
            ThemBtnCol.HeaderText = "";
            ThemBtnCol.Text = "Thêm";
            ThemBtnCol.UseColumnTextForButtonValue = false;
            ThemBtnCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewNotIn.Columns.Add(ThemBtnCol);
        }

        private void dataGridViewNotIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0 || e.ColumnIndex != dataGridViewNotIn.Columns["ThemCol"].Index) return;
            int maMon = 0;
            try
            {
                maMon = int.Parse(this.dataGridViewNotIn.Rows[e.RowIndex].Cells["MaMon"].Value.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            this.Presenter.AddMonToDanhMuc(maMon, this.Model.seletedMaDanhMuc);
            this.loadDataMonInDanhMuc();
            this.loadDataMonNotInDanhMuc();
        }

        //nut them
        private void dataGridViewNotIn_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewNotIn.Columns["ThemCol"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Vẽ nút như bình thường
                e.PaintContent(e.CellBounds);
                string imagePath = Path.Combine(MySQL_DB.projectRoot, "Resources", "plus.png");
                // Load ảnh icon
                Image icon = Image.FromFile(imagePath); // Đường dẫn tới icon

                // Tính vị trí để căn giữa ảnh
                int x = e.CellBounds.Left + (e.CellBounds.Width - icon.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - icon.Height) / 2;

                // Vẽ ảnh
                e.Graphics.DrawImage(icon, new Point(x, y));

                e.Handled = true;
            }

        }

        private void dataGridViewNotIn_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewNotIn.Columns["ThemCol"].Index)
            {
                e.ToolTipText = "Thêm";
            }

        }

        //-----------------------------------------------------
        //table load
        public void LoadTable()
        {
            this.Presenter.LoadDanhMuc();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.DanhMucList;
            //custom column
            try
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.Columns["MaDM"].HeaderText = "Mã";
                this.dataGridView1.Columns["MaDM"].FillWeight = 10;
                this.dataGridView1.Columns["TenDM"].HeaderText = "Tên danh mục";
                this.dataGridView1.Columns["TenDM"].FillWeight = 80;
                this.dataGridView1.Columns["SoLuongMon"].HeaderText = "";
                this.dataGridView1.Columns["SoLuongMon"].FillWeight = 10;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //load list mon
            if(dataGridView1.Rows.Count > 0)loadDetail(this.dataGridView1.Rows[0]);
        }

        public void loadDetail(DataGridViewRow row)
        {
            try
            {
                this.Model.seletedMaDanhMuc = int.Parse(row.Cells["MaDM"].Value.ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            //MessageBox.Show(this.Model.seletedMaDanhMuc.ToString());
            this.txtTenDanhMuc.Text = row.Cells["TenDM"].Value.ToString();
            this.loadDataMonInDanhMuc();
            this.loadDataMonNotInDanhMuc();
        }

        //btn action
    }

}
