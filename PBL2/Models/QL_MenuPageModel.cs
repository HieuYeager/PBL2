using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Bin--------------------
namespace PBL2.Models
{
    public class QL_MenuPageModel
    {
        public DataTable Table { get; set; }
        //ql cong thuc
        public DataTable CongThuc { get; set; }
        public int seletedMaMon { get; set; }
        //ql phan loai
        public DataTable DanhMucList { get; set; }
        public DataTable MonInDanhMucList { get; set; }
        public DataTable MonNotInDanhMucList { get; set; }
        public int seletedMaDanhMuc { get; set; }
    }
}
