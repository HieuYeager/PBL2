using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using PBL2.Views.loginForm;
using PBL2.Models;
using PBL2.Views.login;
using PBL2.Data;
namespace PBL2.Presenters.Login
{
    public class LoginPresenter
    {
        LoginModel Model = new LoginModel();
        ILoginView View;

        public LoginPresenter(ILoginView view) {
            this.View = view;
        }

        public void login(string maNV, string password)
        {
            Account acc = Model.GetAccountByMaNV(maNV);
            if(acc == null)
            {
                View.ShowError("Tài khoản không tồn tại");
            }
            else if(acc.khoa == true)
            {
                View.ShowError("Tài khoản đã bị khoá");
            }
            else
            {
                if(BCrypt.Net.BCrypt.Verify(password, acc.password))
                {
                    NhanVien nv = Model.GetNhanVienByMaNV(maNV);
                    View.LoginSuccess(nv);
                }
                else
                {
                    View.ShowError("Sai mật khẩu");
                }
            }
        }

        //code cu
        //public AccountModel login(LoginModel loginModel) {
        //    if (loginModel == null)
        //    {
        //        return null;
        //    }

        //    AccountModel accountModel = new AccountModel();
        //    KeyValuePair<bool, string> result = this.CheckLogin(loginModel.MaNV, loginModel.Password);

        //    if (result.Key)
        //    {
        //        //MessageBox.Show(result.Value, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        DataTable dt = MySQL_DB.Instance.Select("nhanvien", "MaNV, TenNV , VaiTro",$"MaNV = '{loginModel.MaNV}'");
        //        DataRow row = dt.Rows[0];
        //        if (row != null)
        //        {
        //            accountModel.MaNV = row["MaNV"].ToString();
        //            accountModel.TenNV = row["TenNV"].ToString();
        //            accountModel.VaiTro = row["VaiTro"].ToString();
        //        }

        //        return accountModel;
        //    }
        //    else
        //    {
        //        MessageBox.Show(result.Value, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return null;
        //}

        //Ham check login
        //private KeyValuePair<bool, string> CheckLogin(string MaNV, string password)
        //{
        //    KeyValuePair<bool, string> result = new KeyValuePair<bool, string>(false, "Tài khoản không tồn tại");
        //    string hashPass = "";

            
        //    //try
        //    //{
        //        DataTable dt = MySQL_DB.Instance.Select("account", "password, khoa", $"MaNV = '{MaNV}'");

        //        if (dt.Rows.Count == 0)
        //        {
        //            return result;
        //        }
        //        else
        //        {
        //            //DataRow row = dt.Rows[0];
        //            hashPass = dt.Rows[0]["password"].ToString();
        //            Console.WriteLine(hashPass);
        //        }

        //        if (dt.Rows[0]["khoa"].ToString() == "True")
        //        {
        //            result = new KeyValuePair<bool, string>(false, "tài khoản bị khóa");
        //        }
        //        else if (BCrypt.Net.BCrypt.Verify(password, hashPass))
        //        {
        //            result = new KeyValuePair<bool, string>(true, "đăng nhập thành công");
        //        }
        //        else
        //        {
        //            result = new KeyValuePair<bool, string>(false, "mật khẩu không đúng");
        //        }
        //    //}
        //    //catch
        //    //{
        //    //    Console.WriteLine("Ket noi khong thanh cong");
        //    //}

            

        //    return result;
        //    //string HashPassword(string password)
        //    //{
        //    //    return BCrypt.Net.BCrypt.HashPassword(password); // cost mặc định an toàn
        //    //}

        //    //bool VerifyPassword(string password, string hash)
        //    //{
        //    //    return BCrypt.Net.BCrypt.Verify(password, hash);
        //    //}
        //}

    }
}
