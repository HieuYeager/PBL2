using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.QLDon
{
    public interface IQLDonPage
    {
        void loadTatCaDonHang(List<HoaDon> hoaDons);

        void loadChiTietDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons);

        void loadThanhToanPage(HoaDon hoaDon);

        void loadCongThuc(List<CongThuc> congThucs);
    }
}
