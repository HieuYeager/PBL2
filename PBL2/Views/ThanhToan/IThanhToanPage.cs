using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.ThanhToan
{
    public interface IThanhToanPage
    {
        void loadChiTietHoaDon(List<ChiTietHoaDon> chiTietHoaDons);
        void loadHoaDon(HoaDon hoaDon);

    }
}
