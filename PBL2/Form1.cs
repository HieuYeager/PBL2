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
using PBL2.Views.ManagerView;
using PBL2.Views.HomePage;
using PBL2.Class;


namespace PBL2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadView("HomePage", null);
            //LoadView("StaffView", new AccountModel() { MaNV = "Test" , TenNV = "Test", VaiTro = "Nhân viên"});
            //LoadView("ManagerView", new AccountModel() { MaNV = "Test", TenNV = "Test", VaiTro = "Quản lý" });
        }

        public void LoadView(String ViewName, AccountModel account)
        {
            if (ViewName == "StaffView")
            {
                staffView staffView = new staffView(account);
                staffView.form1 = this;
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(staffView);
            }
            else if(ViewName == "ManagerView")
            {
                mangerView mangerView = new mangerView(account);
                mangerView.form1 = this;
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(mangerView);
            }
            else {
                HomePage homePage = new HomePage();
                homePage.form1 = this;
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(homePage);
            }

        }

    }
}
