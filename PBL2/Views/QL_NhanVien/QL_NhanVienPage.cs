using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//--------------------Hai--------------------
using PBL2.Class;
using PBL2.Models;
using PBL2.Presenters.QL_NhanVien;

namespace PBL2.Views.QL_NhanVien
{
    public partial class QL_NhanVienPage : UserControl, IView<QL_NhanVienPresenter, QL_NhanVienPageModel>
    {
        public QL_NhanVienPresenter Presenter { get; set; }

        public QL_NhanVienPageModel Model { get; set; }
        public QL_NhanVienPage()
        {
            InitializeComponent();
            this.Presenter = new QL_NhanVienPresenter(this);
            this.Model = this.Presenter.Model;
        }

    }
}
