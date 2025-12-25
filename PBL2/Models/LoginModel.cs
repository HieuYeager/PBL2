using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class LoginModel
    {
        //code cu
        //public string MaNV { get; set; }
        //public string Password { get; set; }

        //get account from database
        public Account GetAccountByMaNV(string maNV)
        {
            return Accounts.Get(maNV);
        }

        public NhanVien GetNhanVienByMaNV(string maNV)
        {
            return NhanViens.Get(maNV);
        }
    }
}
