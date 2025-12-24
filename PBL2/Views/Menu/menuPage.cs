using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Data;
using PBL2.Models;
using PBL2.Presenters.Menu;
using PBL2.Views.Menu;

namespace PBL2.Views.MenuPage
{
    public partial class menuPage : UserControl, IMenuPage
    {
        public delegate void ThanhToan(List<ChiTietHoaDon> order, NhanVien acc);
        public ThanhToan thanhtoanPage = null;

        //presenter
        MenuPagePresenter Presenter { get;}

        NhanVien account;

        //properties for data binding
        private string FindName { 
            get => this.FindTxt.Text; 
            set => this.FindTxt.Text = value;
        }
        private int FindDanhMucID {
            get => (int)this.ComboBoxDanhMuc.SelectedValue;
            set => this.ComboBoxDanhMuc.SelectedValue = value; 
        }

        public menuPage(NhanVien acc)
        {
            InitializeComponent();

            //presenter
            this.Presenter = new MenuPagePresenter(this);
            Presenter.Load();

            this.FindName = "";
            this.FindDanhMucID = -1;
            this.account = acc;
        }

        //event
        private void buttonFind_Click(object sender, EventArgs e)
        {
            this.Presenter.timMon(this.FindName, this.FindDanhMucID);
        }

        private void buttonThanhToan_click(object sender, EventArgs e)
        {
            if(thanhtoanPage == null) return;
            thanhtoanPage?.Invoke(this.Presenter.GetChiTietHoaDons(), this.account);
            //this.Presenter.showHoaDon();
        }
        //funtion
        public void clearOrder()
        {
            this.ListOrderDetailsPn.Controls.Clear();
        }

        public void LoadMenu(List<Mon> mons)
        {
            this.panelMons.Controls.Clear();
            foreach (Mon mon in mons)
            {
                MonComponent mon1 = new MonComponent(mon, this.Presenter);
                this.panelMons.Controls.Add(mon1);
            }
        }

        public void LoadDanhMuc(List<DanhMuc> danhMucs)
        {
            this.ComboBoxDanhMuc.DataSource = danhMucs;
            this.ComboBoxDanhMuc.ValueMember = "MaDM";
            this.ComboBoxDanhMuc.DisplayMember = "TenDM";
        }

        public void AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            this.ListOrderDetailsPn.Controls.Add(new OrderDetailComponent(chiTietHoaDon, this.Presenter));
        }

    }
}
