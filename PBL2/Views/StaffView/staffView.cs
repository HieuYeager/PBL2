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
    public partial class staffView : UserControl
    {
        public Form1 form1 { get; set; }
        public staffView()
        {
            InitializeComponent();
            this.panelPage.Controls.Add(new menuPage());
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
