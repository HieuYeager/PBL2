using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Data
{
    public enum EnumCaLam
    {
        [Display(Name = "Ca sáng")]
        CaSang,
        [Display(Name = "Ca chiều")]
        CaChieu,
        [Display(Name = "Ca tối")]
        CaToi
    }


    public class LichLamViec
    {
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public EnumCaLam CaLam { get; set; }

        // Property phụ để hiển thị tiếng Việt trong DataGridView
        public string CaLamStr
        {
            get
            {
                if (CaLam == EnumCaLam.CaSang) return EnumCaLam.CaSang.GetDisplayName();
                else if (CaLam == EnumCaLam.CaChieu) return EnumCaLam.CaChieu.GetDisplayName();
                else return EnumCaLam.CaToi.GetDisplayName();
            }
            private set { }
        }

        public bool DiemDanh { get; set; }
    }


}
