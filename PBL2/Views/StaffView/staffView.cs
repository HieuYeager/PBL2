using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.X509;
using PBL2.Models;
using PBL2.Views.MenuPage;
using PBL2.Views.ThanhToan;
using PBL2.Views.QLTonKho;
using PBL2.Views.QLDon;
using PBL2.Data;
namespace PBL2.Views.staffView
{
    public partial class staffView : UserControl
    {
        //form
        public Form1 form1 { get; set; }
        private NhanVien nhanVien { get; set; }
        private menuPage menuPage { get; set; }

        //properties for data binding
        private String tenNV {
            get { return this.labelTen.Text; }
            set { this.labelTen.Text = value; }
        }
        private String vaiTro {
            get { return this.labelVaiTro.Text; }
            set { this.labelVaiTro.Text = value; }
        }


    // màu khi được chọn
    private readonly Color SelectedBack = Color.FromArgb(70, 101, 87);
        private readonly Color SelectedText = Color.FromArgb(255, 255, 255);

        // màu mặc định (hoặc màu "không chọn")
        private readonly Color DefaultBack = Color.FromArgb(123, 163, 146);
        private readonly Color DefaultText = Color.FromArgb(34, 49, 43);

        //select button
        private Krypton.Toolkit.KryptonButton selectedButton { get; set; }

        public staffView(NhanVien nv)
        {
            //code cu
            //this.account = account;
            //this.labelTen.DataBindings.Add("Text", account, "TenNV");
            //this.labelVaiTro.DataBindings.Add("Text", account, "VaiTro");

            InitializeComponent();

            this.nhanVien = nv;
            this.tenNV = nv.TenNV;
            this.vaiTro = nv.VaiTroStr;

            //default button
            //changeButtonColor(this.btnMenu);
            changeButtonColor(this.btnMenu);

            this.loadMenuPage();
        }
        
        //event
        private void logout_btn_click(object sender, EventArgs e)
        {
            if (form1 != null)
            {
                form1.LoadView("HomePage", null);
            }
        }

        private void menubtn_click(object sender, EventArgs e)
        {
            //change button color
            changeButtonColor(this.btnMenu);
            loadMenuPage();
        }

        private void Don_btn_click(object sender, EventArgs e)
        {
            changeButtonColor(this.btnDon);
            loadQlDonPage();
        }

        private void TonKho_btn_click(object sender, EventArgs e)
        {
            //change button color
            changeButtonColor(this.btnTonKho);
            LoadQLTonKhoPage();
        }

        //function
        private void changeButtonColor(Krypton.Toolkit.KryptonButton button)
        {
            //chang button color
            if (this.selectedButton != null)
            {
                this.ResetButtonAppearance(this.selectedButton);
            }
            this.selectedButton = button;
            this.ApplySelectedAppearance(this.selectedButton);
            
            this.btnLogout.Focus();
        }

        private void ApplySelectedAppearance(Krypton.Toolkit.KryptonButton btn)
        {
            btn.StateCommon.Back.Color1 = SelectedBack;
            btn.StateCommon.Content.ShortText.Color1 = SelectedText;
        }

        private void ResetButtonAppearance(Krypton.Toolkit.KryptonButton btn)
        {
            if (btn == null) return;
            btn.StateCommon.Back.Color1 = DefaultBack;
            btn.StateCommon.Content.ShortText.Color1 = DefaultText;
        }

        //load
        private void loadMenuPage()
        {
            this.panelPage.Controls.Clear();
            if(menuPage == null)
            {
                this.menuPage = new menuPage(this.nhanVien);
            }
            this.panelPage.Controls.Add(this.menuPage);
            this.menuPage.thanhtoanPage = this.LoadThanhToanPage;

        }

        private void loadMenuPage_ClearOrder()
        {
            this.panelPage.Controls.Clear();
            if (menuPage == null)
            {
                this.menuPage = new menuPage(this.nhanVien);
            }
            else
            {
                this.menuPage.clearOrder();
            }
            this.panelPage.Controls.Add(this.menuPage);
            this.menuPage.thanhtoanPage = this.LoadThanhToanPage;

        }

        public void loadQlDonPage()
        {
            this.panelPage.Controls.Clear();
            QLDonPage qlDonPage = new QLDonPage(this.nhanVien);
            qlDonPage.loadThanhToan_Handler += this.LoadThanhToanPage;
            this.panelPage.Controls.Add(qlDonPage);

        }

        private void LoadQLTonKhoPage()
        {
            this.panelPage.Controls.Clear();

            this.panelPage.Controls.Add(new QLTonKhoPage(this.nhanVien));
        }

        private void LoadThanhToanPage(HoaDon order, NhanVien acc) {
            this.panelPage.Controls.Clear();
            ThanhToanPage thanhToanPage = new ThanhToanPage(acc, order);

            thanhToanPage.LoadMenuPageHandler += this.loadMenuPage;
            thanhToanPage.LoadMenuPageHandler_ClearOrder += this.loadMenuPage_ClearOrder;
            this.panelPage.Controls.Add(thanhToanPage);
        }

        private void LoadThanhToanPage(List<ChiTietHoaDon> chiTietHoaDons, NhanVien acc)
        {
            if(chiTietHoaDons == null || chiTietHoaDons.Count == 0)
                return;
            this.panelPage.Controls.Clear();
            ThanhToanPage thanhToanPage = new ThanhToanPage(acc, chiTietHoaDons);

            thanhToanPage.LoadMenuPageHandler += this.loadMenuPage;
            thanhToanPage.LoadMenuPageHandler_ClearOrder += this.loadMenuPage_ClearOrder;
            this.panelPage.Controls.Add(thanhToanPage);
        }
    }
}
