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
    public class BaoCaoPresenter : IPresenter<BaoCaoPage, BaoCaoModel>
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
                this.Model.dt.Columns.Add("Ngay", typeof(string));
                this.Model.dt.Columns.Add("TongThanhTien", typeof(decimal));
            }
        }
    }
}
