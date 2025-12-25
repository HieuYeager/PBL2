using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.QL_Menu
{
    public interface IQL_MenuPage
    {
        void loadTable(List<Mon> mons);
        void loadDetail(Mon mon);
        void showMessage(string message);
    }
}
