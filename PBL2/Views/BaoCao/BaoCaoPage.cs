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

            DateTime from = DateTime.Now.AddDays(-10);
            this.DateTimeFrom.Value = from;
            DateTime today = DateTime.Now;
            this.DateTimeTo.Value = today;
            this.Presenter.load(from, today);
            loadChart();

        }

        private void DateTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = this.DateTimeFrom.Value;
            DateTime to = this.DateTimeTo.Value;
            if (from.Date > to.Date)
            { 
                DateTimeFrom.Value = DateTimeTo.Value.AddDays(-1);
            }
            if (to.Date < from.Date) 
            { 
                DateTimeTo.Value = DateTimeFrom.Value.AddDays(1);
            }
        }

        private void  loadBtn_click(object sender, EventArgs e) {
            DateTime from = this.DateTimeFrom.Value;
            DateTime to = this.DateTimeTo.Value;
            this.Presenter.load(from, to);
            loadChart(); 
        }
        
        public void loadChart()
        {
            chart1.DataSource = this.Model.dt;
            chart1.Series[0].XValueMember = "Ngay";
            chart1.Series[0].XValueType = ChartValueType.Date;
            chart1.Series[0].YValueMembers = "TongThanhTien";
            chart1.Series[0].YValueType = ChartValueType.Double;
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.DataBind();
        }


    }
}
