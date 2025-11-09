using System.Windows.Forms;

namespace PBL2.Views.QLTonKho
{
    partial class QLTonKhoPage
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
            this.TBPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblCB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUuTien = new System.Windows.Forms.Label();
            this.lblHetHang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTongNL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.nhapKho = new System.Windows.Forms.Button();
            this.xuat = new System.Windows.Forms.Button();
            this.xemLichSu = new System.Windows.Forms.Button();
            this.xem = new System.Windows.Forms.Button();
            this.TBPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TBPanel
            // 
            this.TBPanel.ColumnCount = 3;
            this.TBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TBPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TBPanel.Controls.Add(this.panel1, 1, 0);
            this.TBPanel.Controls.Add(this.panel2, 2, 0);
            this.TBPanel.Controls.Add(this.panel3, 0, 0);
            this.TBPanel.Location = new System.Drawing.Point(28, 118);
            this.TBPanel.Name = "TBPanel";
            this.TBPanel.RowCount = 1;
            this.TBPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TBPanel.Size = new System.Drawing.Size(1154, 150);
            this.TBPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.lblTrangThai);
            this.panel1.Controls.Add(this.lblCB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(387, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 144);
            this.panel1.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(24, 108);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(92, 32);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "label7";
            // 
            // lblCB
            // 
            this.lblCB.AutoSize = true;
            this.lblCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCB.Location = new System.Drawing.Point(20, 64);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(152, 55);
            this.lblCB.TabIndex = 3;
            this.lblCB.Text = "label8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(499, 64);
            this.label3.TabIndex = 0;
            this.label3.Text = "CẢNH BÁO THIẾU";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCoral;
            this.panel2.Controls.Add(this.lblUuTien);
            this.panel2.Controls.Add(this.lblHetHang);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(771, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 144);
            this.panel2.TabIndex = 3;
            // 
            // lblUuTien
            // 
            this.lblUuTien.AutoSize = true;
            this.lblUuTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUuTien.Location = new System.Drawing.Point(24, 108);
            this.lblUuTien.Name = "lblUuTien";
            this.lblUuTien.Size = new System.Drawing.Size(92, 32);
            this.lblUuTien.TabIndex = 6;
            this.lblUuTien.Text = "label9";
            // 
            // lblHetHang
            // 
            this.lblHetHang.AutoSize = true;
            this.lblHetHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHetHang.Location = new System.Drawing.Point(19, 64);
            this.lblHetHang.Name = "lblHetHang";
            this.lblHetHang.Size = new System.Drawing.Size(179, 55);
            this.lblHetHang.TabIndex = 5;
            this.lblHetHang.Text = "label10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 64);
            this.label4.TabIndex = 1;
            this.label4.Text = "HẾT HÀNG";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.lblTongNL);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 144);
            this.panel3.TabIndex = 4;
            // 
            // lblTongNL
            // 
            this.lblTongNL.AutoSize = true;
            this.lblTongNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNL.Location = new System.Drawing.Point(3, 70);
            this.lblTongNL.Name = "lblTongNL";
            this.lblTongNL.Size = new System.Drawing.Size(152, 55);
            this.lblTongNL.TabIndex = 1;
            this.lblTongNL.Text = "label5";
            this.lblTongNL.Click += new System.EventHandler(this.lblTongNL_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 64);
            this.label2.TabIndex = 0;
            this.label2.Text = "TỔNG NGUYÊN LIỆU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Kho";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1154, 468);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(114)))), ((int)(((byte)(232)))));
            this.add.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(27, 66);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(200, 46);
            this.add.TabIndex = 4;
            this.add.Text = "+ Thêm Nguyên Liệu";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // nhapKho
            // 
            this.nhapKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(177)))), ((int)(((byte)(67)))));
            this.nhapKho.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapKho.ForeColor = System.Drawing.Color.White;
            this.nhapKho.Location = new System.Drawing.Point(244, 66);
            this.nhapKho.Name = "nhapKho";
            this.nhapKho.Size = new System.Drawing.Size(130, 46);
            this.nhapKho.TabIndex = 5;
            this.nhapKho.Text = "Nhập Kho";
            this.nhapKho.UseVisualStyleBackColor = false;
            this.nhapKho.Click += new System.EventHandler(this.nhapKho_Click);
            // 
            // xuat
            // 
            this.xuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(140)))), ((int)(((byte)(22)))));
            this.xuat.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuat.ForeColor = System.Drawing.Color.White;
            this.xuat.Location = new System.Drawing.Point(394, 66);
            this.xuat.Name = "xuat";
            this.xuat.Size = new System.Drawing.Size(130, 46);
            this.xuat.TabIndex = 6;
            this.xuat.Text = "Xuất Kho";
            this.xuat.UseVisualStyleBackColor = false;
            // 
            // xemLichSu
            // 
            this.xemLichSu.BackColor = System.Drawing.Color.White;
            this.xemLichSu.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemLichSu.ForeColor = System.Drawing.Color.Black;
            this.xemLichSu.Location = new System.Drawing.Point(699, 66);
            this.xemLichSu.Name = "xemLichSu";
            this.xemLichSu.Size = new System.Drawing.Size(130, 46);
            this.xemLichSu.TabIndex = 8;
            this.xemLichSu.Text = "Xem Lịch Sử";
            this.xemLichSu.UseVisualStyleBackColor = false;
            this.xemLichSu.Click += new System.EventHandler(this.xemLichSu_Click);
            // 
            // xem
            // 
            this.xem.BackColor = System.Drawing.Color.Red;
            this.xem.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xem.ForeColor = System.Drawing.Color.Black;
            this.xem.Location = new System.Drawing.Point(542, 66);
            this.xem.Name = "xem";
            this.xem.Size = new System.Drawing.Size(137, 46);
            this.xem.TabIndex = 7;
            this.xem.Text = "Xem Cảnh Báo";
            this.xem.UseVisualStyleBackColor = false;
            this.xem.Click += new System.EventHandler(this.xem_Click);
            // 
            // QLTonKhoPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.xemLichSu);
            this.Controls.Add(this.xem);
            this.Controls.Add(this.xuat);
            this.Controls.Add(this.nhapKho);
            this.Controls.Add(this.add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPanel);
            this.MaximumSize = new System.Drawing.Size(1203, 753);
            this.MinimumSize = new System.Drawing.Size(1203, 753);
            this.Name = "QLTonKhoPage";
            this.Size = new System.Drawing.Size(1203, 753);
            this.Load += new System.EventHandler(this.QLTonKhoPage_Load);
            this.TBPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TBPanel;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelDetail;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblCB;
        private System.Windows.Forms.Label lblUuTien;
        private System.Windows.Forms.Label lblHetHang;
        private System.Windows.Forms.Label lblTongNL;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button nhapKho;
        private System.Windows.Forms.Button xuat;
        private System.Windows.Forms.Button xemLichSu;
        private System.Windows.Forms.Button xem;
    }
}
