namespace PBL2.Views.BaoCao
{
    partial class BaoCaoPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DateTimeFrom = new Krypton.Toolkit.KryptonDateTimePicker();
            this.DateTimeTo = new Krypton.Toolkit.KryptonDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(970, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bao cao";
            // 
            // chart1
            // 
            chartArea11.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart1.Legends.Add(legend11);
            this.chart1.Location = new System.Drawing.Point(73, 180);
            this.chart1.Name = "chart1";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart1.Series.Add(series11);
            this.chart1.Size = new System.Drawing.Size(971, 300);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // DateTimeFrom
            // 
            this.DateTimeFrom.Location = new System.Drawing.Point(224, 63);
            this.DateTimeFrom.Name = "DateTimeFrom";
            this.DateTimeFrom.Size = new System.Drawing.Size(226, 25);
            this.DateTimeFrom.TabIndex = 3;
            this.DateTimeFrom.ValueChanged += new System.EventHandler(this.DateTime_ValueChanged);
            // 
            // DateTimeTo
            // 
            this.DateTimeTo.Location = new System.Drawing.Point(597, 63);
            this.DateTimeTo.Name = "DateTimeTo";
            this.DateTimeTo.Size = new System.Drawing.Size(226, 25);
            this.DateTimeTo.TabIndex = 4;
            this.DateTimeTo.ValueChanged += new System.EventHandler(this.DateTime_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(487, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến ngày";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(848, 63);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.OverrideDefault.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.OverrideDefault.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.OverrideFocus.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.OverrideFocus.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.Size = new System.Drawing.Size(31, 25);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.TabIndex = 7;
            this.kryptonButton1.Values.Image = global::PBL2.Properties.Resources.refresh_icon;
            this.kryptonButton1.Values.Text = "";
            this.kryptonButton1.Click += new System.EventHandler(this.loadBtn_click);
            // 
            // BaoCaoPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateTimeTo);
            this.Controls.Add(this.DateTimeFrom);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1203, 753);
            this.MinimumSize = new System.Drawing.Size(1203, 753);
            this.Name = "BaoCaoPage";
            this.Size = new System.Drawing.Size(1203, 753);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Krypton.Toolkit.KryptonDateTimePicker DateTimeFrom;
        private Krypton.Toolkit.KryptonDateTimePicker DateTimeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}
