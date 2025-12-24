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
using PBL2.Class;
using System.Data;

namespace PBL2.Presenters.QLDon
{
    public class QLDonPresenter
    {
        public QLDonModel Model { get; set; }
        public QLDonPage View { get; set; }

        public QLDonPresenter(QLDonPage view)
        {
            View = view;
            Model = new QLDonModel();
        }
        //load
        public void LoadAllHoaDonChuaThanhToan()
        {
            //MessageBox.Show($"TrangThai = '{TrangThaiHoaDon.ChuaThanhToan.GetDisplayName()}'");
            DataTable dt = MySQL_DB.Instance.Select("hoadon", "*", $"TrangThai = '{TrangThaiHoaDon.ChuaThanhToan.GetDisplayName()}' ");
            loadToModel(dt);
        }

        public void LoadAllHoaDonDaThanhToan()
        {
            DataTable dt = MySQL_DB.Instance.Select("hoadon", "*", $"TrangThai = '{TrangThaiHoaDon.DaThanhToan.GetDisplayName()}' ");
            loadToModel(dt);
        }

        public void LoadAllHoaDonDangLam()
        {
            DataTable dt = MySQL_DB.Instance.Select("hoadon", "*", $"TrangThai = '{TrangThaiHoaDon.DangLam.GetDisplayName()}' ");
            loadToModel(dt);
        }

        public void LoadAllHoaDonSanSang()
        {
            DataTable dt = MySQL_DB.Instance.Select("hoadon", "*", $"TrangThai = '{TrangThaiHoaDon.SanSang.GetDisplayName()}' ");
            loadToModel(dt);
        }

        private void loadToModel(DataTable dt)
        {
            this.Model.HoaDons.Clear();
            foreach (DataRow row in dt.Rows)
            {
                TrangThaiHoaDon trangThai = TrangThaiHoaDon.ChuaThanhToan;

                HoaDon hoaDon = new HoaDon();
                try
                {
                    hoaDon.MaHD = row["MaHD"].ToString();
                    hoaDon.MaNV = row["MaNV"].ToString();
                    hoaDon.NgayLapHD = Convert.ToDateTime(row["NgayLapHD"]);
                    hoaDon.ThanhTien = Convert.ToDecimal(row["ThanhTien"]);
                    hoaDon.MaBan = row["MaBan"] != DBNull.Value ? Convert.ToInt32(row["MaBan"]) : (int?)null;
                    //hoaDon.TrangThai = (TrangThaiHoaDon)Enum.Parse(typeof(TrangThaiHoaDon), row["TrangThai"].ToString().Replace(" ", ""));
                    if (row["TrangThai"] != DBNull.Value)
                    {
                        if (row["TrangThai"].ToString() == TrangThaiHoaDon.ChuaThanhToan.GetDisplayName()) trangThai = TrangThaiHoaDon.ChuaThanhToan;
                        else if (row["TrangThai"].ToString() == TrangThaiHoaDon.DaThanhToan.GetDisplayName()) trangThai = TrangThaiHoaDon.DaThanhToan;
                        else if (row["TrangThai"].ToString() == TrangThaiHoaDon.DangLam.GetDisplayName()) trangThai = TrangThaiHoaDon.DangLam;
                        else if (row["TrangThai"].ToString() == TrangThaiHoaDon.SanSang.GetDisplayName()) trangThai = TrangThaiHoaDon.SanSang;
                        else if (row["TrangThai"].ToString() == TrangThaiHoaDon.DaPhucVu.GetDisplayName()) trangThai = TrangThaiHoaDon.DaPhucVu;
                    }
                    hoaDon.TrangThai = trangThai;

                    this.Model.HoaDons.Add(hoaDon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải hóa đơn: " + ex.Message);
                    continue;
                }
            }

        }
        //function chua thanh toan component
        //loadThanhToanPage
        public void loadThanhToanPage(HoaDon hoaDon)
        {
            this.View?.DonCTHComp_LoadThanhToan(hoaDon);
        }

        //bat dau lam mon
        public void batDauLamMon(HoaDon hoaDon)
        {
            //update trang thai hoa don
            MySQL_DB.Instance.Update("hoadon", $"TrangThai = '{TrangThaiHoaDon.DangLam.GetDisplayName()}'", $"MaHD = '{hoaDon.MaHD}'");
            this.Model.HoaDons.Remove(hoaDon);
            this.View.loadAllDonHang();
        }

        //lam xong mon
        public void lamXongMon(HoaDon hoaDon)
        {
            //update trang thai hoa don
            MySQL_DB.Instance.Update("hoadon", $"TrangThai = '{TrangThaiHoaDon.SanSang.GetDisplayName()}'", $"MaHD = '{hoaDon.MaHD}'");
            this.Model.HoaDons.Remove(hoaDon);
            this.View.loadAllDonHang();
        }

        //da phuc vu
        public void daPhucVu(HoaDon hoaDon)
        {
            //update trang thai hoa don
            MySQL_DB.Instance.Update("hoadon", $"TrangThai = '{TrangThaiHoaDon.DaPhucVu.GetDisplayName()}'", $"MaHD = '{hoaDon.MaHD}'");
            this.Model.HoaDons.Remove(hoaDon);
            this.View.loadAllDonHang();
        }

        //huy don
        public bool huyDon(HoaDon hoaDon)
        {
            try
            {
                //Xóa chi tiết hóa đơn
                MySQL_DB.Instance.Delete("chitiethoadon", $"MaHD = '{hoaDon.MaHD}'");
                //Xóa hóa đơn
                MySQL_DB.Instance.Delete("hoadon", $"MaHD = '{hoaDon.MaHD}'");

                this.Model.HoaDons.Remove(hoaDon);
                this.View.loadAllDonHang();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi hủy đơn: " + ex.Message);
                return false;
            }
        }
        
        //function cho don
        public void loadChiTietDon(HoaDon hd)
        {
            this.View?.loadChiTietDon(hd);
        }

        public void LoadCongThuc(int maMon)
        {
            //this.Model.seletedMaMon = maMon;
            string condition = $"MaMon = {maMon}";
            //DataTable dt = MySQL_DB.Instance.Select("CongThuc", "*", condition);
            DataTable dt = MySQL_DB.Instance.SelectJoin("CongThuc ct", "ct.MaMon, nl.MaNguyenLieu, nl.TenNguyenLieu, ct.SoLuong, ct.DonVi",
                        $" JOIN NguyenLieu nl ON ct.MaNguyenLieu = nl.MaNguyenLieu WHERE ct.MaMon = {maMon}");
            
            this.View?.loadCongThucMon(dt);
        }
    }
}
