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
    public partial class QL_MenuPage : UserControl, IView<QL_MenuPresenter, QL_MenuPageModel>
    {
        public QL_MenuPresenter Presenter { get; set; }

        public QL_MenuPageModel Model { get; set; }
        public QL_MenuPage()
        {
            InitializeComponent();
            //presenter
            this.Presenter = new QL_MenuPresenter(this);
            //model
            this.Model = this.Presenter.Model;
            //load
            this.LoadTable();
            SetupEventHandlers();
        }
        private void SetupEventHandlers()
        {
            // Add button click event
            this.loginBtn.Click += LoginBtn_Click;

            // DataGridView double-click to edit
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;

            // DataGridView right-click context menu for edit/delete
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Sửa");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa");
            editMenuItem.Click += EditMenuItem_Click;
            deleteMenuItem.Click += DeleteMenuItem_Click;
            contextMenu.Items.Add(editMenuItem);
            contextMenu.Items.Add(deleteMenuItem);
            this.dataGridView1.ContextMenuStrip = contextMenu;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Open AddMonForm
            AddMonForm addForm = new AddMonForm(this.Presenter);
            addForm.ShowDialog();
            // Reload table after adding
            if (addForm.DialogResult == DialogResult.OK)
            {
                this.LoadTable();
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit on double-click
            if (e.RowIndex >= 0)
            {
                EditSelectedDish();
            }
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedDish();
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedDish();
        }

        private void EditSelectedDish()
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maMon = GetMaMonFromRow(selectedRow);

                if (!string.IsNullOrWhiteSpace(maMon))
                {
                    UpdateMonForm updateForm = new UpdateMonForm(this.Presenter, maMon);
                    updateForm.ShowDialog();
                    // Reload table after updating
                    if (updateForm.DialogResult == DialogResult.OK)
                    {
                        this.LoadTable();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteSelectedDish()
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string maMon = GetMaMonFromRow(selectedRow);
                string tenMon = GetTenMonFromRow(selectedRow);

                if (!string.IsNullOrWhiteSpace(maMon))
                {
                    DeleteMonForm deleteForm = new DeleteMonForm(this.Presenter, maMon, tenMon);
                    deleteForm.ShowDialog();
                    // Reload table after deleting
                    if (deleteForm.DialogResult == DialogResult.OK)
                    {
                        this.LoadTable();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy thông tin món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetMaMonFromRow(DataGridViewRow row)
        {
            try
            {
                // Try DataRowView first (when DataSource is DataTable)
                if (row.DataBoundItem is DataRowView rowView)
                {
                    return rowView["MaMon"]?.ToString() ?? "";
                }
                // Try DataRow directly
                else if (Model.Table != null && row.Index >= 0 && row.Index < Model.Table.Rows.Count)
                {
                    return Model.Table.Rows[row.Index]["MaMon"]?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting MaMon: {ex.Message}");
            }
            return "";
        }

        private string GetTenMonFromRow(DataGridViewRow row)
        {
            try
            {
                // Try DataRowView first (when DataSource is DataTable)
                if (row.DataBoundItem is DataRowView rowView)
                {
                    return rowView["TenMon"]?.ToString() ?? "";
                }
                // Try DataRow directly
                else if (Model.Table != null && row.Index >= 0 && row.Index < Model.Table.Rows.Count)
                {
                    return Model.Table.Rows[row.Index]["TenMon"]?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting TenMon: {ex.Message}");
            }
            return "";
        }
        public void LoadTable()
        {
            this.Presenter.LoadMenu();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.Table;
            //custom column
            try
            {
                this.dataGridView1.Columns["MaMon"].HeaderText = "Mã món";
                this.dataGridView1.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridView1.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
