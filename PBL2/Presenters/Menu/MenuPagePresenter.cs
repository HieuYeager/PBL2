using PBL2.Class;
using PBL2.Models;
using PBL2.Models;
using PBL2.Views.MenuPage;
using PBL2.Views.MenuPage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types;

namespace PBL2.Presenters.Menu
{
    public class MenuPagePresenter : IPresenter<menuPage, MenuPageModel>
    {
        public menuPage View { get; set; }
        public MenuPageModel Model { get; set; }

        public MenuPagePresenter(menuPage view) {

            this.View = view;
            this.Model = new MenuPageModel();
            this.Load();
            
        }

        //function
        public void Load()
        {
            loadDM();
            loadMons();
        }

        public void loadDM()
        {
            Model.danhmuc.Clear();
            //add ALL option
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = -1;
                danhMuc.TenDM = "Tất cả";
                this.Model.danhmuc.Add(danhMuc);
            }
            //load danh muc
            DataTable dt = MySQL_DB.Instance.Select("DanhMuc", "*");
            foreach (DataRow row in dt.Rows)
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = int.Parse(row["MaDM"].ToString());
                danhMuc.TenDM = row["TenDM"].ToString();
                Model.danhmuc.Add(danhMuc);
            }
        }

        public void loadMons()
        {
            //clear
            this.Model.mons.Clear();

            DataTable dt = MySQL_DB.Instance.Select("Mon", "*");
            //MessageBox.Show(dt.Rows.Count.ToString());
            foreach (DataRow row in dt.Rows)
            {
                MonModel monModel = new MonModel();
                monModel.MaMon = row["MaMon"].ToString();
                monModel.TenMon = row["TenMon"].ToString();
                try
                {
                    string GiaBan = row["GiaBan"].ToString();
                    monModel.GiaBan = decimal.Parse(GiaBan);
                }
                catch
                {
                    monModel.GiaBan = -1;
                }
                this.Model.mons.Add(monModel);
            }
        }

        public void timMon()
        {
            //clear
            this.Model.mons.Clear();
            //creat query
            string conditionDMQuery = "";
            string conditionNameQuery = "";


            if (this.Model.FindDanhMucID > 0)
            {
                conditionDMQuery += $" JOIN DanhMuc_Mon ON Mon.MaMon = DanhMuc_Mon.MaMon ";
                conditionDMQuery += $" JOIN DanhMuc ON DanhMuc_Mon.MaDM = DanhMuc.MaDM WHERE DanhMuc.MaDM = {this.Model.FindDanhMucID} ";
            }

            conditionNameQuery += $" Mon.TenMon LIKE '%{this.Model.FindName}%'";

            //excute query
            DataTable dt = null;
            if (this.Model.FindDanhMucID > 0)
            {
                dt = MySQL_DB.Instance.SelectJoin("Mon", "Mon.MaMon, Mon.TenMon, Mon.GiaBan ", $" {conditionDMQuery} AND {conditionNameQuery}");
            }
            else
            {
                dt = MySQL_DB.Instance.Select("Mon", "*", conditionNameQuery);
            }
            if (dt == null)
            {
                return;
            }
            //add mons
            foreach (DataRow row in dt.Rows)
            {
                MonModel monModel = new MonModel();
                monModel.MaMon = row["MaMon"].ToString();
                monModel.TenMon = row["TenMon"].ToString();
                try
                {
                    string GiaBan = row["GiaBan"].ToString();
                    monModel.GiaBan = decimal.Parse(GiaBan);
                }
                catch
                {
                    monModel.GiaBan = -1;
                }
                this.Model.mons.Add(monModel);
            }
        }

        public void addMon(MonModel mon)
        {
            OrderDetailModel orderDetail = new OrderDetailModel();
            if (mon != null)
            {
                if (Model.order.orderDetails.Exists(o => o.monModel.MaMon == mon.MaMon))
                {
                    Model.order.orderDetails.Find(x => x.monModel.MaMon == mon.MaMon).soLuong++;
                    return;
                }
                else
                {
                    orderDetail.monModel = mon;
                    orderDetail.soLuong = 1;
                    this.Model.order.orderDetails.Add(orderDetail);
                    this.View.AddOrderDetail(orderDetail);
                    return;
                }
            }
            return;
        }

        public void removeMon(OrderDetailModel orderDetail)
        {
            this.Model.order.orderDetails.Remove(orderDetail);
        }
    }
}
