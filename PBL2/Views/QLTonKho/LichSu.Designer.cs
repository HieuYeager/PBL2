namespace PBL2.Views.QLTonKho
{
    partial class LichSu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ngay = new System.Windows.Forms.CheckBox();
            this.thang = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.nam = new System.Windows.Forms.CheckBox();
            this.MaNL = new System.Windows.Forms.CheckBox();
            this.TenNL = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaNV = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ngay
            // 
            this.ngay.AutoSize = true;
            this.ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(817, 166);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(95, 33);
            this.ngay.TabIndex = 0;
            this.ngay.Text = "Ngày";
            this.ngay.UseVisualStyleBackColor = true;
            this.ngay.CheckedChanged += new System.EventHandler(this.ngay_CheckedChanged);
            // 
            // thang
            // 
            this.thang.AutoSize = true;
            this.thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thang.Location = new System.Drawing.Point(931, 166);
            this.thang.Name = "thang";
            this.thang.Size = new System.Drawing.Size(108, 33);
            this.thang.TabIndex = 1;
            this.thang.Text = "Tháng";
            this.thang.UseVisualStyleBackColor = true;
            this.thang.CheckedChanged += new System.EventHandler(this.thang_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(651, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lịch Sử Nhập Nguyên Liệu";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(265, 101);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 44);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm Kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(448, 100);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(604, 45);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // nam
            // 
            this.nam.AutoSize = true;
            this.nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nam.Location = new System.Drawing.Point(1063, 166);
            this.nam.Name = "nam";
            this.nam.Size = new System.Drawing.Size(90, 33);
            this.nam.TabIndex = 6;
            this.nam.Text = "Năm";
            this.nam.UseVisualStyleBackColor = true;
            this.nam.CheckedChanged += new System.EventHandler(this.nam_CheckedChanged);
            // 
            // MaNL
            // 
            this.MaNL.AutoSize = true;
            this.MaNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaNL.Location = new System.Drawing.Point(417, 166);
            this.MaNL.Name = "MaNL";
            this.MaNL.Size = new System.Drawing.Size(109, 33);
            this.MaNL.TabIndex = 7;
            this.MaNL.Text = "Mã NL";
            this.MaNL.UseVisualStyleBackColor = true;
            this.MaNL.CheckedChanged += new System.EventHandler(this.MaNL_CheckedChanged);
            // 
            // TenNL
            // 
            this.TenNL.AutoSize = true;
            this.TenNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenNL.Location = new System.Drawing.Point(678, 166);
            this.TenNL.Name = "TenNL";
            this.TenNL.Size = new System.Drawing.Size(119, 33);
            this.TenNL.TabIndex = 8;
            this.TenNL.Text = "Tên NL";
            this.TenNL.UseVisualStyleBackColor = true;
            this.TenNL.CheckedChanged += new System.EventHandler(this.TenNL_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thông Tin Tìm Kiếm";
            // 
            // MaNV
            // 
            this.MaNV.AutoSize = true;
            this.MaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaNV.Location = new System.Drawing.Point(541, 166);
            this.MaNV.Name = "MaNV";
            this.MaNV.Size = new System.Drawing.Size(111, 33);
            this.MaNV.TabIndex = 10;
            this.MaNV.Text = "Mã NV";
            this.MaNV.UseVisualStyleBackColor = true;
            this.MaNV.CheckedChanged += new System.EventHandler(this.MaNV_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1160, 512);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // LichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 763);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.MaNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TenNL);
            this.Controls.Add(this.MaNL);
            this.Controls.Add(this.nam);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thang);
            this.Controls.Add(this.ngay);
            this.Name = "LichSu";
            this.Text = "LichSu";
            this.Load += new System.EventHandler(this.LichSu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ngay;
        private System.Windows.Forms.CheckBox thang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox nam;
        private System.Windows.Forms.CheckBox MaNL;
        private System.Windows.Forms.CheckBox TenNL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox MaNV;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}