using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    public class QLDonModel
    {
        public List<HoaDon> GetHoaDons(EnumTrangThai trangThai)
        {
            MySqlDataReader reader = HoaDons.select().Where($"TrangThai = '{trangThai.GetDisplayName()}'").ExecuteToDataReader();
            List<HoaDon> hoaDons = HoaDons.ToList(reader);
            return hoaDons;
        }

        public List<ChiTietHoaDon> GetChiTietHoaDons(HoaDon hoaDon)
        {
            if (hoaDon == null) return new List<ChiTietHoaDon>();
            MySqlDataReader reader = ChiTietHoaDons.select()
                .Where($"MaHD = '{hoaDon.MaHD}'")
                .ExecuteToDataReader();
            return ChiTietHoaDons.ToList(reader);
        }
        public void DonSanSang(HoaDon hoaDon)
        {
            if (hoaDon == null) return;
            hoaDon.TrangThai = EnumTrangThai.SanSang;
            HoaDons.Update(hoaDon);
        }

        public void DonDaPhucVu(HoaDon hoaDon)
        {
            if (hoaDon == null) return;
            hoaDon.TrangThai = EnumTrangThai.DaPhucVu;
            HoaDons.Update(hoaDon);
        }

        public void HuyDon(HoaDon hoaDon)
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

        public List<CongThuc> loadCongThuc(int maMon)
        {   
            MySqlDataReader reader = CongThucs.select()
                .Where($"MaMon = '{maMon}'")
                .ExecuteToDataReader();

            List<CongThuc> congThucs = CongThucs.ToList(reader);
            if(congThucs == null)
                congThucs = new List<CongThuc>();
            return congThucs;
        }
    }
}
