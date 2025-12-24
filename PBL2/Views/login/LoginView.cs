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
using PBL2.Views.login;
using PBL2.Data;

namespace PBL2.Views.loginForm
{
    public partial class LoginView : Form, ILoginView
    {
        public Form1 form1;

        private LoginPresenter Presenter;

        private String maNV
        {
            get { return this.AccTxt.Text; }
            set { this.AccTxt.Text = value; }
        }
        private String password
        {
            get { return this.PassTxt.Text; }
            set { this.PassTxt.Text = value; }
        }

        public LoginView()
        {
            InitializeComponent();
            Presenter = new LoginPresenter(this);

            //code cu
            // Thiết lập Data Binding
            //this.AccTxt.DataBindings.Add("Text", loginModel, "MaNV");
            //this.PassTxt.DataBindings.Add("Text", loginModel, "Password");

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
            Presenter.login(maNV, password);
            //code cu
            //AccountModel accountModel = loginPresenter.login(loginModel);
            //if (accountModel != null)
            //{
            //    //MessageBox.Show(accountModel.ToString());
            //    if (form1 != null && accountModel.VaiTro == "Nhân viên")
            //    {
            //        form1.LoadView("StaffView", accountModel);
            //    }
            //    else if (form1 != null && accountModel.VaiTro == "Quản lý")
            //    {
            //        form1.LoadView("ManagerView", accountModel);
            //    }
            //    this.Close();
            //}
        }

        //interface methods
        public void LoginSuccess(NhanVien nv)
        {
            if(nv != null)
            {
                if(nv.VaiTro == EnumVaiTro.QuanLy)
                {
                    form1.LoadView("ManagerView", nv);
                }
                else
                {
                    form1.LoadView("StaffView", nv);
                }
                this.Close();
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }
    }
}
