using Mysqlx.Crud;
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
        public BaoCaoPage View { get; set; }
        public BaoCaoModel Model { get; set; }

        public BaoCaoPresenter(BaoCaoPage view)
        {
            this.View = view;
            this.Model = new BaoCaoModel();
            this.load();
        }

        public void load()
        {
            string query = "SELECT DATE(NgayLapHD) AS Ngay, SUM(ThanhTien) AS TongThanhTien FROM HoaDon GROUP BY DATE(NgayLapHD) ORDER BY Ngay;";
            DataTable dt = MySQL_DB.Instance.ExecuteQuery(query);
            if(dt != null) this.Model.dt = dt;
            else
            {
                this.Model.dt = new DataTable();
                this.Model.dt.Columns.Add("Ngay", typeof(string));
                this.Model.dt.Columns.Add("TongThanhTien", typeof(decimal));
            }
        }

        public void load(DateTime from, DateTime to)
        {
            string query = $"SELECT DATE(NgayLapHD) AS Ngay, SUM(ThanhTien) AS TongThanhTien FROM HoaDon WHERE NgayLapHD BETWEEN '{from.ToString("yyyy-MM-dd")}' AND '{to.ToString("yyyy-MM-dd")}' GROUP BY DATE(NgayLapHD) ORDER BY Ngay;";
            //MessageBox.Show(query);
            DataTable dt = MySQL_DB.Instance.ExecuteQuery(query);
            if (dt != null) this.Model.dt = dt;
            else
            {
                this.Model.dt = new DataTable();
                this.Model.dt.Columns.Add("Ngay", typeof(DateTime));
                this.Model.dt.Columns.Add("TongThanhTien", typeof(decimal));
            }
        }

        public DataTable loadMonTheoDoanhThu(DateTime from, DateTime to)
        {
            DataTable dt = MySQL_DB.Instance.SelectJoin("ChiTietHoaDon cthd", "m.TenMon, SUM(cthd.TongTien) AS DoanhThu",
                "JOIN Mon m ON cthd.MaMon = m.MaMon GROUP BY m.MaMon, m.TenMon ORDER BY DoanhThu DESC LIMIT 5;");
            if (dt != null) return dt;
            return new DataTable();
        }
    }
}
