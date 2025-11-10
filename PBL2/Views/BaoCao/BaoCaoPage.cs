using PBL2.Models;
using PBL2.Presenters.BaoCao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PBL2.Views.BaoCao
{
    public partial class BaoCaoPage : UserControl, IView<BaoCaoPresenter, BaoCaoModel>
    {
        public BaoCaoPresenter Presenter { get; set; }

        public BaoCaoModel Model { get; set; }
        public BaoCaoPage()
        {
            InitializeComponent();
            this.Presenter = new BaoCaoPresenter(this);
            this.Model = this.Presenter.Model;
            chart1.DataSource = this.Model.dt;
            chart1.Series[0].XValueMember = "Ngay";
            chart1.Series[0].YValueMembers = "TongThanhTien";
            chart1.Series[0].ChartType = SeriesChartType.Column;
            //chart1.DataBind();

        }

    }
}
