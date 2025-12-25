using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.QLTonKho
{
    public interface IQLTonKho
    {
        void loadTonKho(List<NguyenLieuTonKho> nguyenLieuTonKhos, int tongNguyenLieu, int canhBao, int hetHang);

        void loadCanhBao(List<NguyenLieuTonKho> nguyenLieuTonKhos);

        void loadLichSu(List<LichSuTonKhos> lichSuTonKhos);

        void ShowMessage(string message);
    }
}
