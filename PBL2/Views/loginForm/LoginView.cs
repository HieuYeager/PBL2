using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Presenters;
using PBL2.Models;

namespace PBL2.Views.loginForm
{
    public partial class LoginView : Form, IView
    {
        public Form1 form1;
        private LoginModel loginModel { get; } = new LoginModel();
        private LoginPresenter loginPresenter = new LoginPresenter();

        //public string MaNV { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void UpdateView(IModel model) { 
            if(model is LoginModel)
            {
                //update du lieu
            }
        }
        public LoginView()
        {
            InitializeComponent();

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
       
            //LoginPresenter loginPresenter = new LoginPresenter(this, loginModel);
            String result = loginPresenter.login(loginModel);
            if (result != "")
            {
                this.Close();
                if (form1 != null)
                {
                    form1.LoadView("staffLayoutView");
                }
            }
        }
    }
}
