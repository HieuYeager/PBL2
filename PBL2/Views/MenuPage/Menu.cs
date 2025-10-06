using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;
using MySql.Data.MySqlClient;
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters;
namespace PBL2.Views.MenuPage
{
    public partial class Menu : UserControl, IView
    {
        public delegate void AddMon(MonModel mon);
        public AddMon addMon;
        private MenuModel menuModel = new MenuModel();
        private MenuPresenter menuPresenter;
        public Menu()
        {
            InitializeComponent();
            menuPresenter = new MenuPresenter(this);

            menuPresenter.Load();

            this.ComboBoxDanhMuc.DataSource = menuModel.danhmuc;
            this.ComboBoxDanhMuc.ValueMember = "MaDM";
            this.ComboBoxDanhMuc.DisplayMember = "TenDM";

            foreach(MonModel mon in menuModel.mons)
            { 
                Mon mon1 = new Mon(mon);
                mon1.select_Mon += selectMon;
                this.panelMons.Controls.Add(mon1);
            }
        }
        
        public void UpdateView(IModel model) {
            if (model is MenuModel) { 
                this.menuModel = (MenuModel)model;
            }
        }

        private void selectMon(MonModel mon) {
            if(addMon != null)
            {
                addMon(mon);
            }
        }

    }
}
