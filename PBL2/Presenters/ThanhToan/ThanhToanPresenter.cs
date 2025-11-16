using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PBL2.Views.ThanhToan;
using PBL2.Models;
using PBL2.Class;
using System.Data;
using System.Windows.Forms;

namespace PBL2.Presenters.ThanhToan
{
    public class ThanhToanPresenter : IPresenter<ThanhToanPage, ThanhToanPageModel>
    {
        public ThanhToanPage View { get; set; }
        public ThanhToanPageModel Model { get; set; }

        public ThanhToanPresenter(ThanhToanPage view, AccountModel acc, OrderModel order)
        {
            View = view;
            Model = new ThanhToanPageModel(acc, order);
        }

        //tao hoa dong mac dinh trang thai chua thanh toan
        public void CreateOrder(string maNV)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.MaHD = this.gererateMaHoaDon();
            hoaDon.MaNV = maNV;
            hoaDon.TrangThai = TrangThaiHoaDon.ChuaThanhToan;
            hoaDon.NgayLapHD = DateTime.Now;
            hoaDon.MaBan = 1;
            hoaDon.ThanhTien = this.Model.order.Total;
            
            this.Model.order.MaHD = hoaDon.MaHD;
            //add order detail
            foreach (var item in this.Model.order.orderDetails)
            {
                ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
                chiTietHoaDon.MaHD = hoaDon.MaHD;
                chiTietHoaDon.MaMon = item.monModel.MaMon;
                chiTietHoaDon.SoLuong = item.soLuong;
                chiTietHoaDon.DonGia = item.monModel.GiaBan;
                chiTietHoaDon.TongTien = item.tongTien;
                hoaDon.ChiTietHoaDons.Add(chiTietHoaDon);
            }
            try
            {
                //Insert
                string fields = "MaHD, TrangThai, NgayLapHD, MaBan, ThanhTien, MaNV";
                string values = "'" + hoaDon.MaHD + "', '" + hoaDon.TrangThai.GetDisplayName() + "', '" + hoaDon.NgayLapHD?.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + hoaDon.MaBan + "', '" + hoaDon.ThanhTien + "', '" + hoaDon.MaNV + "'";

                //Console.WriteLine(fields + "--" + values);
                MySQL_DB.Instance.Insert("hoaDon", fields, values);
                //insert cac chi tiet hoa don
                foreach (var item in hoaDon.ChiTietHoaDons)
                {
                    fields = "MaHD, MaMon, SoLuong, DonGia, TongTien";
                    values = "'" + item.MaHD + "', '" + item.MaMon + "', '" + item.SoLuong + "', '" + item.DonGia + "', '" + item.TongTien + "'";
                    MySQL_DB.Instance.Insert("chiTietHoaDon", fields, values);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tạo hóa đơn: " + ex.Message);
            }

        }

        private string gererateMaHoaDon()
        {
            int id = 1;
            string maHoaDon = "";
            do {
                maHoaDon = "HD" + DateTime.Now.ToString("ddMMyy") + id.ToString("0000");
                id++;
            } while (this.CheckMaHoaDon(maHoaDon));
            return maHoaDon;
        }

        private bool CheckMaHoaDon(string maHoaDon)
        {
            //DataTable dt = MySQL_DB.Instance.ExecuteQuery("SELECT MaHoaDon FROM hoadon ORDER BY MaHoaDon DESC LIMIT 1");
            DataTable dt = MySQL_DB.Instance.Select("hoadon", "MaHD", "MaHD= '" + maHoaDon + "' LIMIT 1");
            if (dt.Rows.Count > 0) return true;
            return false;
        }

        public bool CheckThanhToan()
        {
            if (this.Model.TienThua < 0 && this.Model.TienThanhToan > 0)
            {
                return false;
            }

            MySQL_DB.Instance.Update("hoaDon", "TrangThai = '" + TrangThaiHoaDon.DaThanhToan.GetDisplayName() + "'", "MaHD='" + this.Model.order.MaHD + "'");

            return true;
        }

        public void CancelOrder()
        {
            try
            {
                MySQL_DB.Instance.Delete("chiTietHoaDon", "MaHD='" + this.Model.order.MaHD + "'");
                MySQL_DB.Instance.Delete("hoadon", "MaHD='" + this.Model.order.MaHD + "'");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi hủy đơn: " + ex.Message);
            }
        }
    }
}
