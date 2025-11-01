using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Class
{
    public class Account
    {
        public string MaNV { get; set; }           // varchar(10) PK
        public string Password { get; set; }       // CHAR(60)
        public bool Khoa { get; set; }             // bool
    }
    
}
