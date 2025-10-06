using PBL2.Views.MenuPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using PBL2.Class;
using PBL2.Models;
using System.Windows.Forms;
namespace PBL2.Presenters
{
    internal class MenuPresenter
    {
        private PBL2.Views.MenuPage.Menu view;
        private MenuModel menuModel = new MenuModel();
        public MenuPresenter() { }
        public MenuPresenter(PBL2.Views.MenuPage.Menu viewM)
        {
            this.view = viewM;
        }

        public void Load() {
            loadDM();
            loadMon();
        }

        public void loadDM() {
            menuModel.danhmuc.Clear();
            MySQL_DB mySQL_DB = new MySQL_DB();

            DataTable dt = mySQL_DB.Select("DanhMuc", "*");
            foreach (DataRow row in dt.Rows)
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = row["MaDM"].ToString();
                danhMuc.TenDM = row["TenDM"].ToString();
                menuModel.danhmuc.Add(danhMuc);
            }
            view.UpdateView(menuModel);
        }

        public void loadMon()
        {
            menuModel.mons.Clear();
            MySQL_DB mySQL_DB = new MySQL_DB();

            DataTable dt = mySQL_DB.Select("Mon", "*");
            //MessageBox.Show(dt.Rows.Count.ToString());
            foreach (DataRow row in dt.Rows)
            {
                MonModel monModel = new MonModel();
                monModel.MaMon = row["MaMon"].ToString();
                monModel.TenMon = row["TenMon"].ToString();
                try
                {
                    string donGia = row["DonGia"].ToString();
                    monModel.DonGia = decimal.Parse(donGia);
                }
                catch
                {
                    monModel.DonGia = -1;
                }
                menuModel.mons.Add(monModel);
            }
            view.UpdateView(menuModel);
        }
    }
}
