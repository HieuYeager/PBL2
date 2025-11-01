using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Bin--------------------
using PBL2.Models;
using PBL2.Presenters.QL_Menu;
namespace PBL2.Views.QL_Menu
{
    public partial class QL_MenuPage : UserControl, IView<QL_MenuPresenter, QL_MenuPageModel>
    {
        public QL_MenuPresenter Presenter { get; set; }

        public QL_MenuPageModel Model { get; set; }
        public QL_MenuPage()
        {
            InitializeComponent();
            //presenter
            this.Presenter = new QL_MenuPresenter(this);
            //model
            this.Model = this.Presenter.Model;
            //load
            this.LoadTable();
        }

        public void LoadTable()
        {
            this.Presenter.LoadMenu();
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = Model.Table;
            //custom column
            try
            {
                this.dataGridView1.Columns["MaMon"].HeaderText = "Mã món";
                this.dataGridView1.Columns["TenMon"].HeaderText = "Tên món";
                this.dataGridView1.Columns["GiaBan"].HeaderText = "Giá bán";
                this.dataGridView1.Columns["DonVi"].HeaderText = "Đơn vị";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
