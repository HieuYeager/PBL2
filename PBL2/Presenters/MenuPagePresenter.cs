using PBL2.Data;
using PBL2.Models;
using PBL2.Views.Menu;
using PBL2.Views.MenuPage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;

namespace PBL2.Presenters.Menu
{
    public class MenuPagePresenter
    {
        //public menuPage View { get; set; }

        IMenuPage View;
        private MenuPageModel Model { get; set; } = new MenuPageModel();

        public MenuPagePresenter(IMenuPage view) {

            this.View = view;
            this.Load();
            
        }
        //function
        public void Load()
        {
            loadDM();
            loadMons();
        }
        // them vao hoa don
        public void addMon(Mon mon)
        {
            
            if (mon != null)
            {
                if (Model.GetChiTietHoaDons().Exists(o => o.MaMon == mon.MaMon))
                {
                    Model.GetChiTietHoaDons().Find(x => x.MaMon == mon.MaMon).SoLuong++;
                }
                else
                {
                    ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon
                    {
                        MaHD = "",
                        MaMon = mon.MaMon,
                        SoLuong = 1,
                        DonGia = mon.GiaBan
                    };
                    this.Model.addChiTietHoaDon(chiTietHoaDon);
                    this.View.AddChiTietHoaDon(chiTietHoaDon);
                }
            }
            return;
        }

        public void subMon(ChiTietHoaDon chiTietHoaDon)
        {
            if (chiTietHoaDon == null) {
                Console.WriteLine("Mon khong ton tai trong hoa don");
                return;
            }
            chiTietHoaDon.SoLuong--;

        }

        public void removeMon(ChiTietHoaDon chiTietHoaDon)
        {
            if (chiTietHoaDon == null) return;
            this.Model.removeChiTietHoaDon(chiTietHoaDon);
        }

        public void showHoaDon() {
            foreach (var item in this.Model.GetChiTietHoaDons())
            {
                MessageBox.Show("Ma Mon: " + item.MaMon + " So Luong: " + item.SoLuong + " Don Gia: " + item.DonGia);
            }
        }
        //menu
        public void loadMons()
        {
            View.LoadMenu(Model.GetMons());
        }

        public void loadDM()
        {
            List<DanhMuc> danhMucs = new List<DanhMuc>();
            //Model.danhmuc.Clear();
            //load danh muc
            danhMucs = DanhMucs.GetAll();
            //add ALL option
            {
                DanhMuc danhMuc = new DanhMuc();
                danhMuc.MaDM = -1;
                danhMuc.TenDM = "Tất cả";
                danhMucs.Add(danhMuc);
            }
            View.LoadDanhMuc(danhMucs);
        }

        public void timMon(string findName, int findDanhMucID)
        {
            findName = findName.Trim();

            if (findDanhMucID == -1 && findName == "")
            {
                View.LoadMenu(Model.GetMons());
                return;
            }
            if (findDanhMucID == -1)
            {
                View.LoadMenu(Model.GetMons(findName));
            }
            else
            {
                View.LoadMenu(Model.GetMons(findName, findDanhMucID));
            }
        }

        public List<ChiTietHoaDon> GetChiTietHoaDons()
        {
            return this.Model.GetChiTietHoaDons();
        }
    }
}
