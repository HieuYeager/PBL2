using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------Bin--------------------
namespace PBL2.Models
{
    public class QL_MenuPageModel: IModel
    {
        public DataTable Table { get; set; }
        public int DanhMuc { get; set; }
        public string Find { get; set; }
    }
}
