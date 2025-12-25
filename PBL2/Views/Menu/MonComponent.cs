using PBL2.Models;
using PBL2.Presenters.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL2.Data;

namespace PBL2.Views.MenuPage
{
    public partial class MonComponent : UserControl
    {
        //presenter
        MenuPagePresenter presenter;
        //model
        public Mon mon { get; set; }

        private string imagePath;
        public MonComponent()
        {
            InitializeComponent();
        }
        public MonComponent(Mon mon, MenuPagePresenter menuPagePresenter)
        {
            InitializeComponent();
            this.mon = mon;

            this.labelTenMon.DataBindings.Add("Text", mon, "TenMon");
            this.labelGia.DataBindings.Add("Text", mon, "GiaBan");

            try
            {
                imagePath = Path.Combine(DB.projectRoot, "Resources", mon.URL_anh);
                //MessageBox.Show(imagePath);
                this.pictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
            this.presenter = menuPagePresenter;
        }

        public void addMon_Click(object sender, EventArgs e) {
            if (this.presenter != null) {
                this.presenter.addMon(mon);
            }
        }

    }
}
