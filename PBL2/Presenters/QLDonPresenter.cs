using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL2.Models;
using PBL2.Views.QLDon;
using PBL2.Presenters;
using System.Windows.Forms;
using PBL2.Data;
using System.Data;

namespace PBL2.Presenters.QLDon
{
    public class QLDonPresenter
    {
        public QLDonModel Model { get; set; }
        public IQLDonPage View { get; set; }

        public QLDonPresenter(IQLDonPage view)
        {
            View = view;
            Model = new QLDonModel();
        }
        //load
        public void LoadAllHoaDonChuaThanhToan()
        {
            List<HoaDon> hoaDons = this.Model.GetHoaDons(EnumTrangThai.ChuaThanhToan);
            this.View.loadTatCaDonHang(hoaDons);
        }

        public void LoadAllHoaDonDangLam()
        {
            List<HoaDon> hoaDons = this.Model.GetHoaDons(EnumTrangThai.DangLam);
            this.View.loadTatCaDonHang(hoaDons);
        }

        public void LoadAllHoaDonSanSang()
        {
            List<HoaDon> hoaDons = this.Model.GetHoaDons(EnumTrangThai.SanSang);
            this.View.loadTatCaDonHang(hoaDons);
        }

        //loadThanhToanPage
        public void loadThanhToanPage(HoaDon hoaDon)
        {
            this.View?.loadThanhToanPage(hoaDon);
        }

        //lam xong mon
        public void lamXongMon(HoaDon hoaDon)
        {
            this.Model.DonSanSang(hoaDon);
            this.LoadAllHoaDonDangLam();
        }

        //da phuc vu
        public void daPhucVu(HoaDon hoaDon)
        {
            this.Model.DonDaPhucVu(hoaDon);
            this.LoadAllHoaDonSanSang();
        }

        //huy don
        public void huyDon(HoaDon hoaDon)
        {
            try
            {
                this.Model.HuyDon(hoaDon);
                MessageBox.Show("Hủy đơn thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi hủy đơn: " + ex.Message);
     
            }
        }
        
        //function cho don
        public void loadChiTietDon(HoaDon hd)
        {
            List<ChiTietHoaDon> chiTietHoaDon = this.Model.GetChiTietHoaDons(hd);
            this.View?.loadChiTietDon(hd, chiTietHoaDon);
            if(chiTietHoaDon.Count > 0) this.LoadCongThuc(chiTietHoaDon[0].MaMon);
            else this.View?.loadCongThuc(new List<CongThuc>());
        }

        public void LoadCongThuc(int maMon)
        {
            List<CongThuc> congThucs = this.Model.loadCongThuc(maMon);
            this.View?.loadCongThuc(congThucs);
        }
    }
}
