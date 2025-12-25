using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.Menu
{
    public interface IMenuPage
    {
        void LoadMenu(List<Mon> mons);
        void LoadDanhMuc(List<DanhMuc> danhMucs);
        void AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);
    }
}
