using MySql.Data.MySqlClient;
using PBL2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class ThanhToanPageModel: System.ComponentModel.INotifyPropertyChanged
    {
        public OrderModel order { get; set; }

        private decimal _TienThanhToan = 0;

        public decimal TienThanhToan { 
            get
            {
                return _TienThanhToan;
            }
            set 
            {
                _TienThanhToan = value;
                TienThua = _TienThanhToan - order.Total;
                OnPropertyChanged(nameof(TienThanhToan));
                OnPropertyChanged(nameof(TienThua));
            } 
        }
        public decimal TienThua { 
            get => TienThanhToan - order.Total; 
            set { } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //code moi
        private NhanVien nhanVien;
        private HoaDon hoaDon;

        public ThanhToanPageModel(NhanVien acc, HoaDon order)
        {
            if (acc == null || order == null) return;
            if(order.TrangThai != EnumTrangThai.ChuaThanhToan) return;
            this.nhanVien = acc;
            this.hoaDon = order;
        }
        //truong hop chua co hoa don
        public ThanhToanPageModel(NhanVien acc)
        {
            if (acc == null) return;
            this.nhanVien = acc;
        }

        public List<ChiTietHoaDon> GetChiTietHoaDons()
        {
            if (hoaDon == null) return new List<ChiTietHoaDon>();
            MySqlDataReader reader = ChiTietHoaDons.select()
                .Where($"MaHD = '{hoaDon.MaHD}'")
                .ExecuteToDataReader();

            return ChiTietHoaDons.ToList(reader);
        }

        //tao hoa don moi
        public void TaoHoaDon(HoaDon hoaDon, List<ChiTietHoaDon> chiTietHoaDons)
        {
            //add HoaDon vao DB
            HoaDons.Add(hoaDon);
            //add ChiTietHoaDon vao DB
            foreach (ChiTietHoaDon chiTietHoaDon in chiTietHoaDons)
            {
                chiTietHoaDon.MaHD = hoaDon.MaHD;
                ChiTietHoaDons.Add(chiTietHoaDon);
            }
        }

        //huy don
        public void HuyDon()
        {
            if (hoaDon == null) return;
            //xoa chi tiet hoa don
            MySqlDataReader reader = ChiTietHoaDons.select()
                .Where($"MaHD = '{hoaDon.MaHD}'")
                .ExecuteToDataReader();

            List<ChiTietHoaDon> chiTietHoaDons = ChiTietHoaDons.ToList(reader);
            foreach (ChiTietHoaDon chiTiet in chiTietHoaDons)
            {
                ChiTietHoaDons.Delete(chiTiet);
            }
            //xoa hoa don
            HoaDons.Delete(hoaDon);
        }

        //thanh toan thanh cong -> chuyen trang thai hoa don thanh dang lam
        public void ThanhToanThanhCong()
        {
            if (hoaDon == null) return;
            hoaDon.TrangThai = EnumTrangThai.DangLam;
            HoaDons.Update(hoaDon);
        }
    }
}
