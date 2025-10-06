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
using PBL2.Views.staffView;
using PBL2.Views.HomePage;


namespace PBL2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadView("HomePage");
            LoadView("staffView");
        }

        public void LoadView(String ViewName)
        {
            if (ViewName == "staffView")
            {
                staffView staffLayoutView = new staffView();
                staffLayoutView.form1 = this;
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(staffLayoutView);
            }
            else if (ViewName == "HomePage") {
                HomePage homePage = new HomePage();
                homePage.form1 = this;
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(homePage);
            }

        }

        public void LoadView(String ViewName, IModel model)
        {
            if (ViewName == "staffView")
            {
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(new staffView());
            }
        }
    }
}
