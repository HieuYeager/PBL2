using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBL2.Views.ThanhToan;
using PBL2.Models;
using PBL2.Data;
using System.Data;
using System.Windows.Forms;

namespace PBL2.Presenters.ThanhToan
{
    public class ThanhToanPresenter
    {
        public IThanhToanPage View { get; set; }
        public ThanhToanPageModel Model { get; set; }

        public ThanhToanPresenter(IThanhToanPage view, NhanVien acc, HoaDon order)
        {
            View = view;
            Model = new ThanhToanPageModel(acc, order);
        }

        //truong hop chua co hoa don
        public ThanhToanPresenter(IThanhToanPage view, NhanVien acc)
        {
            View = view;
            Model = new ThanhToanPageModel(acc);
        }

        //tao hoa dong mac dinh trang thai chua thanh toan
        public HoaDon CreateOrder(NhanVien acc, List<ChiTietHoaDon> chiTietHoaDons)
        {
            DateTime now = DateTime.Now;
            decimal thanhTien = 0;
            foreach (ChiTietHoaDon chiTietHoaDon in chiTietHoaDons)
            {
                thanhTien += chiTietHoaDon.TongTien;
            }
            HoaDon newHoaDon = new HoaDon
            {
                MaHD = this.gererateMaHoaDon(now),
                MaNV = acc.MaNV,
                TrangThai = EnumTrangThai.ChuaThanhToan,
                NgayLapHD = now,
                MaBan = 0,
                ThanhTien = thanhTien
            };
            this.Model.TaoHoaDon(newHoaDon, chiTietHoaDons);
            return newHoaDon;
        }

        private string gererateMaHoaDon(DateTime dt)
        {
            //12 chars: ddMMyyHHmm
            return "HD" + dt.ToString("ddMMyyHHmm");
        }

        public bool CheckMaHoaDon(string maHoaDon)
        {
            ////DataTable dt = MySQL_DB.Instance.ExecuteQuery("SELECT MaHoaDon FROM hoadon ORDER BY MaHoaDon DESC LIMIT 1");
            //DataTable dt = MySQL_DB.Instance.Select("hoadon", "MaHD", "MaHD= '" + maHoaDon + "' LIMIT 1");
            //if (dt.Rows.Count > 0) return true;
            return false;
        }

        public bool CheckThanhToan(decimal tongTien, decimal tienThanhToan)
        {
            decimal tienThua = tienThanhToan - tongTien;
            if (tienThua < 0)
            {
                return false;
            }

            this.Model.ThanhToanThanhCong();

            return true;
        }

        public void CancelOrder()
        {
            this.Model.HuyDon();
        }

        //get chi tiet hoa don
        public List<ChiTietHoaDon> GetChiTietHoaDons()
        {
            return this.Model.GetChiTietHoaDons();
        }
    }
}
