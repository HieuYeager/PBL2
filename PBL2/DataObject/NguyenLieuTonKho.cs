using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public enum EnumDonVi
    {
        [Display(Name = "ml")]
        Ml,
        [Display(Name = "g")]
        G,
        [Display(Name = "cái")]
        Cai
    }

    public class NguyenLieuTonKho
    {
        public int MaNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public decimal SoLuong { get; set; }
        public EnumDonVi DonVi { get; set; }

        // Property phụ để hiển thị tiếng Việt / ký hiệu trong DataGridView
        public string DonViStr
        {
            get
            {
                if (DonVi == EnumDonVi.Ml) return EnumDonVi.Ml.GetDisplayName();
                else if (DonVi == EnumDonVi.G) return EnumDonVi.G.GetDisplayName();
                else return EnumDonVi.Cai.GetDisplayName();
            }
            private set { }
        }

        public decimal MucCanhBao { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }

}
