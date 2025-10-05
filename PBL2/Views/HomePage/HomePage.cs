using PBL2.Views.loginForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PBL2.Views.loginForm.LoginView;

namespace PBL2.Views.HomePage
{
    public partial class HomePage : UserControl
    {
        public Form1 form1;
        public HomePage()
        {
            InitializeComponent();
        }
        private void buttonlogin_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            if (form1 != null)
            {
                loginView.form1 = form1;
            }
            loginView.Show();
        }
    }
}
