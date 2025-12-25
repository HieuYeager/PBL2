using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL2.Views.BaoCao
{
    public interface IBaoCaoPage
    {
        void loadChart(DataTable dt);
        void loadMonChart(DataTable dt);
    }
}
