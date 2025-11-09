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
        public DataTable GetAllNguyenLieu()
        {
            string query = "SELECT MaNguyenLieu, TenNguyenLieu, DonVi, SoLuong, NgayCapNhat FROM nguyenlieu";
            return MySQL_DB.Instance.ExecuteQuery(query);
        }
    }
}
