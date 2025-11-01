using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PBL2.Models;
using PBL2.Presenters.Menu;
namespace PBL2.Views.MenuPage
{
    public partial class MonComponent : UserControl
    {
        //presenter
        MenuPagePresenter presenter;
        //model
        public MonModel mon { get; set; }
        public MonComponent()
        {
            InitializeComponent();
        }
        public MonComponent(MonModel mon, MenuPagePresenter menuPagePresenter)
        {
            InitializeComponent();
            this.mon = mon;

            this.labelTenMon.DataBindings.Add("Text", mon, "TenMon");
            this.labelGia.DataBindings.Add("Text", mon, "GiaBan");
            this.presenter = menuPagePresenter;
        }

        public void addMon_Click(object sender, EventArgs e) {
            if (this.presenter != null) {
                this.presenter.addMon(mon);
            }
        }

    }
}
