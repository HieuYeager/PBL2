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
    public partial class Mon : UserControl
    {
        public delegate void Select_Mon(MonModel mon);

        public Select_Mon select_Mon;
        public MonModel mon { get; set; }
        public Mon()
        {
            InitializeComponent();
        }

        public Mon(MonModel mon)
        {
            InitializeComponent();
            this.mon = mon;

            this.labelTenMon.DataBindings.Add("Text", mon, "TenMon");
            this.labelGia.DataBindings.Add("Text", mon, "DonGia");
        }

        public void addMon_Click(object sender, EventArgs e) {
            if (select_Mon != null) {
                select_Mon(mon);
            }
        }

    }
}
