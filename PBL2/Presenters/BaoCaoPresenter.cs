using Mysqlx.Crud;
using PBL2.Data;
using PBL2.Models;
using PBL2.Views.BaoCao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBL2.Views.MenuPage.menuPage;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace PBL2.Presenters.BaoCao
{
    public class BaoCaoPresenter
    {
        private IBaoCaoPage View { get; set; }
        private BaoCaoModel Model { get; set; } = new BaoCaoModel();

        public BaoCaoPresenter(IBaoCaoPage view)
        {
            this.View = view;
            this.load();
        }

        public void load()
        {
            string query = "SELECT DATE(NgayLapHD) AS Ngay, SUM(ThanhTien) AS TongThanhTien FROM HoaDon GROUP BY DATE(NgayLapHD) ORDER BY Ngay;";
            DataTable dt = DB.ExecuteQuery(query);
            if(dt != null) { }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Ngay", typeof(string));
                dt.Columns.Add("TongThanhTien", typeof(decimal));
            }
            this.View?.loadChart(dt);
        }

        public void load(DateTime from, DateTime to)
        {
            string query = $"SELECT DATE(NgayLapHD) AS Ngay, SUM(ThanhTien) AS TongThanhTien FROM HoaDon WHERE NgayLapHD BETWEEN '{from.ToString("yyyy-MM-dd")}' AND '{to.ToString("yyyy-MM-dd")}' GROUP BY DATE(NgayLapHD) ORDER BY Ngay;";
            //MessageBox.Show(query);
            DataTable dt = DB.ExecuteQuery(query);
            if (dt != null) { }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Ngay", typeof(DateTime));
                dt.Columns.Add("TongThanhTien", typeof(decimal));
            }
            this.View?.loadChart(dt);
        }

        public void loadMonTheoDoanhThu()
        {
            string query = "SELECT m.TenMon, SUM(cthd.soLuong * cthd.DonGia) AS DoanhThu" +
                " FROM ChiTietHoaDon cthd" +
                " JOIN Mon m ON cthd.MaMon = m.MaMon" +
                " GROUP BY m.MaMon, m.TenMon" +
                " ORDER BY DoanhThu DESC LIMIT 5; ";
            DataTable dt = DB.ExecuteQuery(query);
            if (dt == null)
            {
                MessageBox.Show("Không có dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.View?.loadMonChart(dt);
        }

        public void loadMonTheoDoanhThu(DateTime from, DateTime to)
        {
            string query = "SELECT m.TenMon, SUM(cthd.soLuong * cthd.DonGia) AS DoanhThu" +
                " FROM ChiTietHoaDon cthd" +
                " JOIN Mon m ON cthd.MaMon = m.MaMon" +
                " JOIN HoaDon hd ON hd.MaHD = cthd.MaHD" +
                $" WHERE NgayLapHD BETWEEN '{from.ToString("yyyy-MM-dd")}' AND '{to.ToString("yyyy-MM-dd")}'" +
                " GROUP BY m.MaMon, m.TenMon" +
                " ORDER BY DoanhThu DESC LIMIT 5";
            DataTable dt = DB.ExecuteQuery(query);
            if (dt == null)
            {
                MessageBox.Show("Không có dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.View?.loadMonChart(dt);
        }
    }
}
