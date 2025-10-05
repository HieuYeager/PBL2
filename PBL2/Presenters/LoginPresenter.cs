using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Models;
namespace PBL2.Presenters
{
    internal class LoginPresenter: IPresenter
    {
        //public Login() { }

        public String login(LoginModel loginModel) {
            if (loginModel == null)
            {
                return "";
            }
             
            MySQL_DB mySQL_DB = new MySQL_DB();

            DataTable dt = mySQL_DB.Select("account", "*");
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["MaNV"].ToString() == loginModel.MaNV && row["password"].ToString() == loginModel.Password)
                    {
                        if (row["khoa"].ToString() == "True")
                        {
                            MessageBox.Show("Tài khoản đã bị khóa");
                            return "";
                        }
                        MessageBox.Show("Đăng nhập thành công");
                        return row["MaNV"].ToString();
                    }
                }
            }
            MessageBox.Show("Đăng nhập thất bại");
            return "";
        }
    }
}
