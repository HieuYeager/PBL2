using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Hai--------------------


namespace PBL2.Models
{
    public class QL_NhanVienPageModel
    {
        public DataTable Table { get; set; }

        //phan ca
        public DataTable CaLamViec { get; set; }

        //diem danh
        public DataTable DiemDanh { get; set; }
    }
}
