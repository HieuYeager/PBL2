using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Presenters.Login;
using PBL2.Models;

namespace PBL2.Views.loginForm
{
    public partial class LoginView : Form
    {
        public Form1 form1;
        //private LoginModel loginModel { 
        //    get{
        //        return new LoginModel()
        //        {
        //            MaNV = this.AccTxt.Text,
        //            Password = this.PassTxt.Text
        //        };
        //    }
        //    set
        //    {
        //        this.AccTxt.Text = value.MaNV.ToString();
        //        this.PassTxt.Text = value.Password.ToString();
        //    }
        //}

        private LoginModel loginModel = new LoginModel();
        private LoginPresenter loginPresenter;

        public LoginView()
        {
            InitializeComponent();
            loginPresenter = new LoginPresenter();

            // Thiết lập Data Binding
            this.AccTxt.DataBindings.Add("Text", loginModel, "MaNV");
            this.PassTxt.DataBindings.Add("Text", loginModel, "Password");

        }

        //close button
        private void closseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //show password
        private void showPassword_click(object sender, EventArgs e)
        {
            if (this.ShowPassCheckBtn.Checked == true)
            {
                //this.PassTxt.UseSystemPasswordChar = false;
                this.PassTxt.PasswordChar = '\0';
            }
            else
            {
                this.PassTxt.PasswordChar = '●';
            }
        }

        //login button
        private void loginButton_Click(object sender, EventArgs e)
        {
            AccountModel accountModel = loginPresenter.login(loginModel);
            if (accountModel != null)
            {
                //MessageBox.Show(accountModel.ToString());
                if (form1 != null && accountModel.VaiTro == "Nhân viên")
                {
                    form1.LoadView("StaffView", accountModel);
                }
                else if (form1 != null && accountModel.VaiTro == "Quản lý")
                {
                    form1.LoadView("ManagerView", accountModel);
                }
                this.Close();
            }
        }
    }
}
