using MySql.Data.MySqlClient;
using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Models
{
    internal class QLTonKhoModel
    {
        public List<NguyenLieuTonKho> GetAllNguyenLieu()
        {
            return NguyenLieuTonKhos.GetAll();
        }

        public List<NguyenLieuTonKho> GetAllNguyenLieuCanhBao()
        {
            return NguyenLieuTonKhos.GetAll().Where(x => x.SoLuong <= x.MucCanhBao).ToList();
        }

        public List<LichSuTonKho> GetAllLichSuTonKho()
        {
           return LichSuTonKhos.GetAll();
        }
        public List<LichSuTonKho> GetAllLichSuTonKho(string condition)
        {
            MySqlDataReader reader = LichSuTonKhos.select().Where(condition).ExecuteToDataReader();
            return LichSuTonKhos.ToList(reader);
        }

        public int GetCountCanhBao()
        { 
            return NguyenLieuTonKhos.Count($"{NguyenLieuTonKhos.SoLuong} <= {NguyenLieuTonKhos.MucCanhBao}");
        }

        public int GetHetHang()
        {
            return NguyenLieuTonKhos.Count($"{NguyenLieuTonKhos.SoLuong} <= 0");
        }

        public EnumDonVi GetDonVi(int maNguyenLieu)
        {
                return NguyenLieuTonKhos.Get(maNguyenLieu)?.DonVi??EnumDonVi.G;
        }
        //
        public bool xoaNguyenLieu(NguyenLieuTonKho nguyenLieu)
        {
            return NguyenLieuTonKhos.Delete(nguyenLieu) > 0;
        }

        public string nhapKho(LichSuTonKho LichSuTonKho)
        {
            string message = "";
            if (LichSuTonKhos.Add(LichSuTonKho) > 0)
            {
                NguyenLieuTonKho nguyenLieu = NguyenLieuTonKhos.Get(LichSuTonKho.MaNguyenLieu);
                nguyenLieu.SoLuong += LichSuTonKho.SoLuong;
                nguyenLieu.NgayCapNhat = DateTime.Now;
                if (NguyenLieuTonKhos.Update(nguyenLieu) > 0)
                {
                    message = "Nhập kho thành công";
                }
                else
                {
                    message = "Nhập kho thất bại";
                }
            }
            else
            {
                message = "Nhập kho thất bại";
            }
            return message;
        }

        public string xuatKho(LichSuTonKho LichSuTonKho)
        {
            string message = "";
            if (LichSuTonKhos.Add(LichSuTonKho) > 0)
            {
                NguyenLieuTonKho nguyenLieu = NguyenLieuTonKhos.Get(LichSuTonKho.MaNguyenLieu);
                if(nguyenLieu.SoLuong < 0)
                {
                     message = "Xuất kho thất bại, só lượng nguyên liệu trong kho không hợp lệ";
                    return message;
                }
                nguyenLieu.SoLuong -= LichSuTonKho.SoLuong;
                nguyenLieu.NgayCapNhat = DateTime.Now;
                if (NguyenLieuTonKhos.Update(nguyenLieu) > 0)
                {
                    message = "Xuất kho thành công";
                }
                else
                {
                    message = "Xuất kho thất bại";
                }
            }
            else
            {
                message = "Xuất kho thất bại";
            }
            return message;
        }

        public bool AddNguyenLieu(NguyenLieuTonKho nguyenLieuTonKho)
        {
            return NguyenLieuTonKhos.Add(nguyenLieuTonKho) > 0;
        }

        public bool EditNguyenLieu(NguyenLieuTonKho nguyenLieuTonKho)
        {
            return NguyenLieuTonKhos.Update(nguyenLieuTonKho) > 0;
        }
    }
}
