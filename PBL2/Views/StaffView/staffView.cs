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
namespace PBL2.Views.staffView
{
    public partial class staffView : UserControl
    {
        public Form1 form1 { get; set; }
        private AccountModel account { get; set; }
        //form
        private menuPage menuPage { get; set; }


        // màu khi được chọn
        private readonly Color SelectedBack = Color.FromArgb(70, 101, 87);
        private readonly Color SelectedText = Color.FromArgb(255, 255, 255);

        // màu mặc định (hoặc màu "không chọn")
        private readonly Color DefaultBack = Color.FromArgb(123, 163, 146);
        private readonly Color DefaultText = Color.FromArgb(34, 49, 43);

        //select button
        private Krypton.Toolkit.KryptonButton selectedButton { get; set; }

        public staffView(AccountModel account)
        {
            InitializeComponent();
            this.account = account;

            this.labelTen.DataBindings.Add("Text", account, "TenNV");
            this.labelVaiTro.DataBindings.Add("Text", account, "VaiTro");

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

        private void Ingredient_btn_click(object sender, EventArgs e)
        {
            //change button color
            changeButtonColor(this.btnIngredient);
            LoadIngredientPage();
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
                this.menuPage = new menuPage();
            }
            this.panelPage.Controls.Add(this.menuPage);
            this.menuPage.thanhtoan = this.LoadThanhToanPage;

        }

        public void loadQlDonPage()
        {
            this.panelPage.Controls.Clear();

            this.panelPage.Controls.Add(new QLDonPage());
        }

        private void LoadIngredientPage()
        {
            this.panelPage.Controls.Clear();

            this.panelPage.Controls.Add(new QLTonKhoPage(this.account));
        }
        private void LoadThanhToanPage(OrderModel order) {
            if (order.orderDetails.Count == 0) return;
            this.panelPage.Controls.Clear();
            this.panelPage.Controls.Add(new ThanhToanPage(this.account, order));
        }
    }
}
