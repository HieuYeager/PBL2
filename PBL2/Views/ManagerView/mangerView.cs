using PBL2.Class;
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
namespace PBL2.Views.ManagerView
{
    public partial class mangerView : UserControl
    {
        public Form1 form1;
        private AccountModel account;

        // màu khi được chọn
        private readonly Color SelectedBack = Color.FromArgb(70, 101, 87);
        private readonly Color SelectedText = Color.FromArgb(255, 255, 255);

        // màu mặc định (hoặc màu "không chọn")
        private readonly Color DefaultBack = Color.FromArgb(123, 163, 146);
        private readonly Color DefaultText = Color.FromArgb(34, 49, 43);

        //select button
        private Krypton.Toolkit.KryptonButton selectedButton { get; set; }
        public mangerView(AccountModel account)
        {
            InitializeComponent();
            this.account = account;


            this.labelTen.DataBindings.Add("Text", account, "TenNV");
            this.labelVaiTro.DataBindings.Add("Text", account, "VaiTro");

            this.panelPage.Controls.Add(new QL_MenuPage());

            this.selectedButton = this.btnQLMenu;
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
        private void loadQLMenu()
        {
            this.panelPage.Controls.Clear();
            this.panelPage.Controls.Add(new QL_MenuPage());
        }

        private void loadQlNhanVien()
        {
            this.panelPage.Controls.Clear();
            this.panelPage.Controls.Add(new QL_NhanVienPage());
        }
    }
}
