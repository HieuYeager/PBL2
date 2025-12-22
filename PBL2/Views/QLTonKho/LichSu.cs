using PBL2.Class;
using PBL2.Models;
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
        public LichSu()
        {
            InitializeComponent();
        }

        public void LoadLichSuTonKho(int? maNguyenLieu = null)
        {
            string table = "lichsutonkho as ls";
            //string fields = "ID, MaNguyenLieu, MaNV, HoatDong, SoLuong, Gia, GhiChu, Ngay";
            string fields = "nl.TenNguyenLieu, nv.TenNV, ls.*";

            string where = null;
            if (maNguyenLieu.HasValue)
                where = $"MaNguyenLieu = {maNguyenLieu.Value}";

            DataTable dt;

            //if (maNguyenLieu.HasValue)
            //{
            //    dt = MySQL_DB.Instance.Select(table, fields, $"MaNguyenLieu = {maNguyenLieu.Value}");
            //}
            //else
            //{
            //    dt = MySQL_DB.Instance.Select(table, fields); // load all
            //}
            string join = "JOIN NhanVien as nv ON nv.MaNV = ls.MaNV " +
                "JOIN NguyenLieu as nl ON nl.MaNguyenLieu = ls.MaNguyenLieu";

            dt = MySQL_DB.Instance.SelectJoin(table, fields, join);

            if (dt != null && dt.Rows.Count > 0)
            {
                this.dataGridView1.Columns.Clear();
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Đổi tên cột để dễ đọc
                dataGridView1.Columns["TenNV"].HeaderText = "Nhân viên";
                dataGridView1.Columns["TenNV"].FillWeight = 15;
                dataGridView1.Columns["TenNguyenLieu"].HeaderText = "Nguyên liệu";
                dataGridView1.Columns["TenNguyenLieu"].FillWeight = 15;

                dataGridView1.Columns["ID"].HeaderText = "ID";
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.Columns["MaNguyenLieu"].HeaderText = "Mã NL";
                dataGridView1.Columns["MaNguyenLieu"].Visible = false;
                dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";
                dataGridView1.Columns["MaNV"].Visible = false;

                dataGridView1.Columns["HoatDong"].HeaderText = "Hoạt Động";
                dataGridView1.Columns["HoatDong"].FillWeight = 10;
                dataGridView1.Columns["SoLuong"].HeaderText = "Số Lượng";
                dataGridView1.Columns["SoLuong"].FillWeight = 10;
                dataGridView1.Columns["Gia"].FillWeight = 10;
                dataGridView1.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dataGridView1.Columns["GhiChu"].FillWeight = 30;
                dataGridView1.Columns["Ngay"].HeaderText = "Thời Gian";
                dataGridView1.Columns["Ngay"].FillWeight = 20;
            }
            else
            {
                MessageBox.Show("Không thể tải dữ liệu lichsutonkho.", "Lỗi Tải Dữ Liệu");
            }
        }

        private void UncheckOthers(CheckBox selected)
        {
            foreach (var control in this.Controls)
            {
                if (control is CheckBox cb && cb != selected)
                {
                    cb.Checked = false;
                }
            }
        }

        private void MaNL_CheckedChanged(object sender, EventArgs e)
        {
            if (MaNL.Checked)
                UncheckOthers(MaNL);
        }

        private void MaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (MaNV.Checked)
                UncheckOthers(MaNV);
        }

        private void TenNL_CheckedChanged(object sender, EventArgs e)
        {
            if (TenNL.Checked)
                UncheckOthers(TenNL);
        }

        private void ngay_CheckedChanged(object sender, EventArgs e)
        {
            if (ngay.Checked)
                UncheckOthers(ngay);
        }

        private void thang_CheckedChanged(object sender, EventArgs e)
        {
            if (thang.Checked)
                UncheckOthers(thang);
        }

        private void nam_CheckedChanged(object sender, EventArgs e)
        {
            if (nam.Checked)
                UncheckOthers(nam);
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            string keyword = txtSearch.Text.Trim();

            string table = "lichsutonkho";
            string fields = "ID, MaNguyenLieu, MaNV, HoatDong, SoLuong, GhiChu, Ngay";
            string condition = "";

            if (string.IsNullOrEmpty(keyword))
            {
                condition = null;
            }

            if (MaNL.Checked)
            {
                condition = $"MaNguyenLieu LIKE '%{keyword}%'";
            }
            else if (MaNV.Checked)
            {
                condition = $"MaNV LIKE '%{keyword}%'";
            }
            else if (TenNL.Checked)
            {
                condition = $"TenNguyenLieu LIKE '%{keyword}%'";
            }
            else if (ngay.Checked)
            {
                if (!int.TryParse(keyword, out int day) || day < 1 || day > 31)
                {
                    MessageBox.Show("Ngày không hợp lệ (1-31).");
                    return;
                }
                condition = $"DAY(Ngay) = {day}";
            }
            else if (thang.Checked)
            {
                if (!int.TryParse(keyword, out int month) || month < 1 || month > 12)
                {
                    MessageBox.Show("Tháng không hợp lệ (1-12).");
                    return;
                }
                condition = $"MONTH(Ngay) = {month}";
            }
            else if (nam.Checked)
            {
                if (!int.TryParse(keyword, out int year) || year < 1900)
                {
                    MessageBox.Show("Năm không hợp lệ.");
                    return;
                }
                condition = $"YEAR(Ngay) = {year}";
            }
            else
            {
                string[] parts = keyword.Split('/', '-');

                // dd/mm/yyyy
                if (parts.Length == 3)
                {
                    if (int.TryParse(parts[0], out int day)
                        && int.TryParse(parts[1], out int month)
                        && int.TryParse(parts[2], out int year))
                    {
                        string mysqlDate = $"{year}-{month:D2}-{day:D2}";
                        condition = $"DATE(Ngay) = '{mysqlDate}'";
                    }
                    else
                    {
                        MessageBox.Show("Định dạng không hợp lệ. Đúng: dd/mm/yyyy");
                        return;
                    }
                }

                //dd/mm
                else if (parts.Length == 2)
                {
                    // user nhập dd/MM
                    if (int.TryParse(parts[0], out int day)
                        && int.TryParse(parts[1], out int month))
                    {
                        condition = $"DAY(Ngay) = {day} AND MONTH(Ngay) = {month}";
                    }
                    else
                    {
                        MessageBox.Show("Định dạng ngày/tháng không hợp lệ (dd/mm).");
                        return;
                    }
                }

                // mm/yyyy
                else if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int month)
                        && int.TryParse(parts[1], out int year))
                    {
                        condition = $"MONTH(Ngay) = {month} AND YEAR(Ngay) = {year}";
                    }
                    else
                    {
                        MessageBox.Show("Định dạng tháng-năm không hợp lệ (mm/yyyy).");
                        return;
                    }
                }

                // yyyy
                else if (parts.Length == 1 && keyword.Length == 4)
                {
                    if (int.TryParse(keyword, out int year))
                    {
                        condition = $"YEAR(Ngay) = {year}";
                    }
                    else
                    {
                        MessageBox.Show("Năm không hợp lệ.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể phân tích cú pháp thời gian.");
                    return;
                }
            }

            DataTable dt = MySQL_DB.Instance.Select(table, fields, condition);

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {}
        private void LichSu_Load(object sender, EventArgs e) {}
        private void textBox1_TextChanged(object sender, EventArgs e) {}

        ///------------------------------------------------------
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    if (row.Cells["HoatDong"].Value.ToString().Trim() == HoatDongTonKho.XuatKho.GetDisplayName())
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(70, 140, 110);
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }
            }
            catch (Exception ex) 
            {
            
            }

        }

    }
}
