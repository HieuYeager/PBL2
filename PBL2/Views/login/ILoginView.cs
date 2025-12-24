using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.login
{
    public interface ILoginView
    {
        void LoginSuccess(NhanVien nv);
        void ShowError(string message);
    }
}
