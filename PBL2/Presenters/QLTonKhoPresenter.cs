using PBL2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Presenters.QLTonKho
{
    internal class QLTonKhoPresenter
    {
        private QLTonKhoModel model;

        public QLTonKhoPresenter()
        {
            model = new QLTonKhoModel();
        }

        public DataTable GetDanhSachNguyenLieu()
        {
            return model.GetAllNguyenLieu();
        }
    }
}
