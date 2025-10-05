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
using PBL2.Views.loginForm;
using PBL2.Views.staffView;


namespace PBL2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.loadView += LoadView;
            loginView.Show();
        }

        private void LoadView(String ViewName)
        {
            if(ViewName == "staffLayoutView")
            {
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(new staffLayoutView());
            }
        }

        private void LoadView(String ViewName, IModel model)
        {
            if (ViewName == "staffLayoutView")
            {
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(new staffLayoutView());
            }
        }
    }
}
