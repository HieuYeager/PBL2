namespace PBL2.Views.QL_Menu
{
    partial class AddMonForm
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
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.ThemMon = new System.Windows.Forms.Label();
            this.lbTenMon = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.lbDonVi = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtMaMon = new System.Windows.Forms.Label();
            this.txtMaMonAn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTenMon
            // 
            this.txtTenMon.Location = new System.Drawing.Point(209, 150);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(300, 31);
            this.txtTenMon.TabIndex = 0;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(209, 200);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(300, 31);
            this.txtGia.TabIndex = 1;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(209, 255);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(300, 31);
            this.txtDonVi.TabIndex = 2;
            // 
            // ThemMon
            // 
            this.ThemMon.AutoSize = true;
            this.ThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThemMon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ThemMon.Location = new System.Drawing.Point(234, 37);
            this.ThemMon.Name = "ThemMon";
            this.ThemMon.Size = new System.Drawing.Size(195, 42);
            this.ThemMon.TabIndex = 3;
            this.ThemMon.Text = "Thêm món";
            // 
            // lbTenMon
            // 
            this.lbTenMon.AutoSize = true;
            this.lbTenMon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbTenMon.Location = new System.Drawing.Point(87, 156);
            this.lbTenMon.Name = "lbTenMon";
            this.lbTenMon.Size = new System.Drawing.Size(97, 25);
            this.lbTenMon.TabIndex = 4;
            this.lbTenMon.Text = "Tên Món";
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbGia.Location = new System.Drawing.Point(104, 203);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(45, 25);
            this.lbGia.TabIndex = 5;
            this.lbGia.Text = "Giá";
            // 
            // lbDonVi
            // 
            this.lbDonVi.AutoSize = true;
            this.lbDonVi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbDonVi.Location = new System.Drawing.Point(87, 261);
            this.lbDonVi.Name = "lbDonVi";
            this.lbDonVi.Size = new System.Drawing.Size(73, 25);
            this.lbDonVi.TabIndex = 6;
            this.lbDonVi.Text = "Đơn vị";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Snow;
            this.btnThem.Location = new System.Drawing.Point(92, 317);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(181, 61);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHuy.Location = new System.Drawing.Point(363, 317);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(181, 61);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // txtMaMon
            // 
            this.txtMaMon.AutoSize = true;
            this.txtMaMon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMaMon.Location = new System.Drawing.Point(87, 97);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(89, 25);
            this.txtMaMon.TabIndex = 10;
            this.txtMaMon.Text = "Mã món";
            // 
            // txtMaMonAn
            // 
            this.txtMaMonAn.Location = new System.Drawing.Point(209, 97);
            this.txtMaMonAn.Name = "txtMaMonAn";
            this.txtMaMonAn.Size = new System.Drawing.Size(300, 31);
            this.txtMaMonAn.TabIndex = 11;
            // 
            // AddMonForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.txtMaMonAn);
            this.Controls.Add(this.txtMaMon);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lbDonVi);
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.lbTenMon);
            this.Controls.Add(this.ThemMon);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtTenMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMonForm";
            this.Text = "AddMonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label ThemMon;
        private System.Windows.Forms.Label lbTenMon;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label lbDonVi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label txtMaMon;
        private System.Windows.Forms.TextBox txtMaMonAn;
    }
}