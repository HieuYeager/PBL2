
using PBL2.Class;
using PBL2.Models;
using PBL2.Views.QL_NhanVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Hai--------------------

namespace PBL2.Presenters.QL_NhanVien
{
    public class QL_NhanVienPresenter : IPresenter<QL_NhanVienPage, QL_NhanVienPageModel>
    {
        public QL_NhanVienPage View { get ; set; }
        public QL_NhanVienPageModel Model { get; set; }

        public QL_NhanVienPresenter(QL_NhanVienPage view)
        {
            this.View = view;
            this.Model = new QL_NhanVienPageModel();
        }

        public void Load()
        {
            
        }
    }
}
