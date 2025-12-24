using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public class CongThuc
    {
        public int MaMon { get; set; }
        //bien phu: ten mon
        public string TenMon
        {
            get
            {
                return Mons.Get(this.MaMon)?.TenMon??"";
            }
            private set { }
        }
        public int MaNguyenLieu { get; set; }

        //bien phu: ten nguyen lieu
        public string TenNguyenLieu
        {
            get
            {
                return NguyenLieuTonKhos.Get(this.MaNguyenLieu)?.TenNguyenLieu??"";
            }
            private set { }
        }
        public decimal SoLuong { get; set; }

        public string DonViStr
        {
            get
            {
                return NguyenLieuTonKhos.Get(this.MaNguyenLieu)?.DonViStr??"";
            }
            private set { }
        }
    }

}
