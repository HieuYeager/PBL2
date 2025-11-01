using PBL2.Models;
using PBL2.Views.QL_Menu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Bin--------------------
namespace PBL2.Presenters.QL_Menu
{
    public class QL_MenuPresenter : IPresenter<QL_MenuPage, QL_MenuPageModel>
    {
        public QL_MenuPage View { get; set; }
        public QL_MenuPageModel Model { get; set; }

        public QL_MenuPresenter(QL_MenuPage view)
        {
            View = view;
            Model = new QL_MenuPageModel();
        }

        public void LoadMenu()
        {
            DataTable dt = MySQL_DB.Instance.Select("mon", "*");
            this.Model.Table = dt;
        }
    }
}
