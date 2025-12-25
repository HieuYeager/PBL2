using PBL2.Models;
using PBL2.Views.QLTonKho;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL2.Data;

namespace PBL2.Presenters.QLTonKho
{
    public class QLTonKhoPresenter
    {
        private QLTonKhoModel model = new QLTonKhoModel();
        IQLTonKho View;

        public QLTonKhoPresenter(IQLTonKho view)
        {
            this.View = view;
        }

        public void LoadDanhSachNguyenLieu()
        {
            List<NguyenLieuTonKho> nguyenLieuTonKhos = model.GetAllNguyenLieu();
            int tonKho = nguyenLieuTonKhos.Count();
            int canhBao = model.GetCountCanhBao();
            int hetHang = model.GetHetHang();
            this.View?.loadTonKho(nguyenLieuTonKhos,
                tonKho,
                canhBao,
                hetHang);
        }

        public List<NguyenLieuTonKho> GetAllLieu()
        {
            return model.GetAllNguyenLieu();
        }

        public List<NguyenLieuTonKho> GetAllNguyeLieuCanhBao()
        {
            return model.GetAllNguyenLieuCanhBao();
        }

        public List<LichSuTonKho> GetAllLichSuTonKho()
        {
            return model.GetAllLichSuTonKho();
        }

        public List<LichSuTonKho> GetAllLichSuTonKho(string Condition)
        {
            return model.GetAllLichSuTonKho(Condition);
        }

        public EnumDonVi GetDonVi(int maNguyenLieu)
        {
            return model.GetDonVi(maNguyenLieu);
        }

        public void XoaNguyenLieu(NguyenLieuTonKho nguyenLieu)
        {
            if(model.xoaNguyenLieu(nguyenLieu))
            {
                this.View?.ShowMessage("Xóa nguyên liệu thành công!");
                LoadDanhSachNguyenLieu();
            }
            else
            {
                this.View?.ShowMessage("Xóa nguyên liệu thất bài!");
            }
        }

        public void NhapKho(LichSuTonKho lichSuTonKho)
        {
            if(lichSuTonKho == null) return;
            if(lichSuTonKho.SoLuong <= 0) return;
            string message = model.nhapKho(lichSuTonKho);
            this.View?.ShowMessage(message);

            this.LoadDanhSachNguyenLieu();
        }

        public void XuatKho(LichSuTonKho lichSuTonKho)
        {
            if (lichSuTonKho == null) return;
            if (lichSuTonKho.SoLuong <= 0) return;
            string message = model.xuatKho(lichSuTonKho);
            this.View?.ShowMessage(message);

            this.LoadDanhSachNguyenLieu();
        }

        public bool AddNguyenLieu(NguyenLieuTonKho nguyenLieuTonKho)
        {
            bool check = model.AddNguyenLieu(nguyenLieuTonKho);
            if(!check)
            {
                this.View?.ShowMessage("Thêm nguyên liệu thất bại!");
                return check;
            }
            this.LoadDanhSachNguyenLieu();
            return check;
        }

        public bool EditNguyenLieu(NguyenLieuTonKho nguyenLieuTonKho)
        {
            bool check = model.EditNguyenLieu(nguyenLieuTonKho);
            if (!check)
            {
                this.View?.ShowMessage("Sưa nguyên liệu thất bại!");
                return check;
            }
            this.LoadDanhSachNguyenLieu();
            return check;
        }
    }
}
