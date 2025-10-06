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

namespace PBL2.Views.MenuPage
{
    public partial class menuPage : UserControl
    {
        private PBL2.Views.MenuPage.Menu menu;
        private Order order;
        public menuPage()
        {
            InitializeComponent();
            menu = new Menu();
            menu.addMon += addMon;
            order = new Order();
            this.panelMenu.Controls.Add(menu);
            this.panelOrder.Controls.Add(order);
        }

        private void addMon(MonModel mon)
        {
            order.addMon(mon);
        }
    }
}
