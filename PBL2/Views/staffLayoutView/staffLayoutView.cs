using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL2.Views.staffView
{
    public partial class staffLayoutView : UserControl
    {
        public Form1 form1 { get; set; }
        public staffLayoutView()
        {
            InitializeComponent();
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
