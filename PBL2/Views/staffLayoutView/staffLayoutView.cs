using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Views.MenuPage;
namespace PBL2.Views.staffView
{
    public partial class staffLayoutView : UserControl
    {
        public Form1 form1 { get; set; }
        public staffLayoutView()
        {
            InitializeComponent();
            panelMenu.Controls.Clear();
            panelMenu.Controls.Add(new PBL2.Views.MenuPage.Menu());
            panelOrder.Controls.Clear();
            panelOrder.Controls.Add(new Order());
        }

        private void logout_btn_click(object sender, EventArgs e)
        {
            if (form1 != null)
            {
                form1.LoadView("HomePage");
            }
        }
    }
}
