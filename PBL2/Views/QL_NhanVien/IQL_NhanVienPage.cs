using PBL2.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.QL_NhanVien
{
    public interface IQL_NhanVienPage
    {
        void loadNhnVienTable(List<NhanVien> listNhanVien);
        void loadChiTietNhanVien(NhanVien nhavien);

        void showMessage(string message);
    }
}
