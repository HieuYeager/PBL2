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
using PBL2.Views.QL_Menu;
using PBL2.Views.QL_NhanVien;
using PBL2.Views.BaoCao;
using PBL2.Views.QLTonKho;
using PBL2.Presenters.QL_NhanVien;
using PBL2.Views.PhanCa;
using PBL2.Data;

namespace PBL2.Views.ManagerView
{
    public partial class mangerView : UserControl
    {
        public Form1 form1;
        private NhanVien nhanVien { get; set; }

        //properties for data binding
        private String tenNV
        {
            get { return this.labelTen.Text; }
            set { this.labelTen.Text = value; }
        }
        private String vaiTro
        {
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
        public mangerView(NhanVien nv)
        {
            InitializeComponent();
            this.nhanVien = nv;
            this.tenNV = nv.TenNV;
            this.vaiTro = nv.VaiTroStr;

            //this.panelPage.Controls.Add(new QL_MenuPage());
            this.loadBaoCao();

            this.selectedButton = this.btnBaoCao;
            changeButtonColor(this.selectedButton);
        }

        //event
        private void logout_btn_click(object sender, EventArgs e)
        {
            if (form1 != null)
            {
                form1.LoadView("HomePage", null);
            }
        }

        private void btnQLMenu_click(object sender, EventArgs e)
        {
            changeButtonColor((Krypton.Toolkit.KryptonButton)sender);
            loadQLMenu();
        }

        private void btnQLNhanVien_click(object sender, EventArgs e)
        {
            changeButtonColor((Krypton.Toolkit.KryptonButton)sender);
            this.loadQlNhanVien();
        }

        private void btnBaoCao_click(object sender, EventArgs e)
        {
            changeButtonColor((Krypton.Toolkit.KryptonButton)sender);
            this.loadBaoCao();
        }

        private void btnQLTonKho_click(object sender, EventArgs e)
        {
            changeButtonColor((Krypton.Toolkit.KryptonButton)sender);
            this.loadQLTonKho();
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
        public void loadQLMenu()
        {
            this.panelPage.Controls.Clear();
            QL_MenuPage ql_MenuPage = new QL_MenuPage();
            ql_MenuPage.LoadQL_ConhThucPageHandler += this.loadQL_CongThuc;
            ql_MenuPage.LoadQL_PhanLoaiPageHandler += this.loadQL_PhanLoai;
            this.panelPage.Controls.Add(ql_MenuPage);
        }

        public void loadQlNhanVien()
        {
            this.panelPage.Controls.Clear();
            QL_NhanVienPage ql_NhanVienPage = new QL_NhanVienPage(nhanVien);
            ql_NhanVienPage.LoadPhanCaHandler += this.loadPhancaPage;

            this.panelPage.Controls.Add(ql_NhanVienPage);
        }

        public void loadBaoCao()
        {
            this.panelPage.Controls.Clear();
            this.panelPage.Controls.Add(new BaoCaoPage());
        }

        public void loadQLTonKho()
        {
            this.panelPage.Controls.Clear();
            this.panelPage.Controls.Add(new QLTonKhoPage(this.nhanVien));
        }

        public void loadQL_CongThuc(QL_CongThucPage ql_CongThucPage)
        {
            this.panelPage.Controls.Clear();
            if (ql_CongThucPage != null) ql_CongThucPage.LoadQL_MenuPageHandler += this.loadQLMenu;
            this.panelPage.Controls.Add(ql_CongThucPage);
        }

        //trang phu
        public void loadQL_PhanLoai(QL_PhanLoaiPage ql_PhanLoaiPage)
        {
            this.panelPage.Controls.Clear();
            if (ql_PhanLoaiPage != null) ql_PhanLoaiPage.LoadQL_MenuPageHandler += this.loadQLMenu;
            this.panelPage.Controls.Add(ql_PhanLoaiPage);
        }
        public void loadPhancaPage(QL_NhanVienPresenter presenter)
        {
            this.panelPage.Controls.Clear();
            PhanCaPage phanCaPage = new PhanCaPage(presenter);
            phanCaPage.loadQLNhanVienHandler += this.loadQlNhanVien;
            this.panelPage.Controls.Add(phanCaPage);
        }
    }
}
