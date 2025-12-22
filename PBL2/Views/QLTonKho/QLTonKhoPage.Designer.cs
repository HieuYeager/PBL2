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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.add = new System.Windows.Forms.Button();
            this.nhapKho = new System.Windows.Forms.Button();
            this.xuat = new System.Windows.Forms.Button();
            this.xemLichSu = new System.Windows.Forms.Button();
            this.xem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.TBPanel.Size = new System.Drawing.Size(1154, 125);
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
            this.panel1.Size = new System.Drawing.Size(360, 117);
            this.panel1.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(19, 90);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(64, 25);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "label7";
            // 
            // lblCB
            // 
            this.lblCB.AutoSize = true;
            this.lblCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCB.Location = new System.Drawing.Point(15, 46);
            this.lblCB.Name = "lblCB";
            this.lblCB.Size = new System.Drawing.Size(109, 39);
            this.lblCB.TabIndex = 3;
            this.lblCB.Text = "label8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 38);
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
            this.panel2.Size = new System.Drawing.Size(360, 117);
            this.panel2.TabIndex = 3;
            // 
            // lblUuTien
            // 
            this.lblUuTien.AutoSize = true;
            this.lblUuTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUuTien.Location = new System.Drawing.Point(24, 90);
            this.lblUuTien.Name = "lblUuTien";
            this.lblUuTien.Size = new System.Drawing.Size(64, 25);
            this.lblUuTien.TabIndex = 6;
            this.lblUuTien.Text = "label9";
            // 
            // lblHetHang
            // 
            this.lblHetHang.AutoSize = true;
            this.lblHetHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHetHang.Location = new System.Drawing.Point(19, 46);
            this.lblHetHang.Name = "lblHetHang";
            this.lblHetHang.Size = new System.Drawing.Size(128, 39);
            this.lblHetHang.TabIndex = 5;
            this.lblHetHang.Text = "label10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 38);
            this.label4.TabIndex = 1;
            this.label4.Text = "HẾT HÀNG";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightBlue;
            this.panel3.Controls.Add(this.lblTongNL);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 117);
            this.panel3.TabIndex = 4;
            // 
            // lblTongNL
            // 
            this.lblTongNL.AutoSize = true;
            this.lblTongNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNL.Location = new System.Drawing.Point(3, 55);
            this.lblTongNL.Name = "lblTongNL";
            this.lblTongNL.Size = new System.Drawing.Size(109, 39);
            this.lblTongNL.TabIndex = 1;
            this.lblTongNL.Text = "label5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(345, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "TỔNG NGUYÊN LIỆU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản Lý Kho";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(114)))), ((int)(((byte)(232)))));
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.add.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(326, 66);
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
            this.nhapKho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nhapKho.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhapKho.ForeColor = System.Drawing.Color.White;
            this.nhapKho.Location = new System.Drawing.Point(31, 69);
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
            this.xuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xuat.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xuat.ForeColor = System.Drawing.Color.White;
            this.xuat.Location = new System.Drawing.Point(181, 69);
            this.xuat.Name = "xuat";
            this.xuat.Size = new System.Drawing.Size(130, 46);
            this.xuat.TabIndex = 6;
            this.xuat.Text = "Xuất Kho";
            this.xuat.UseVisualStyleBackColor = false;
            this.xuat.Click += new System.EventHandler(this.xuatKho_Click);
            // 
            // xemLichSu
            // 
            this.xemLichSu.BackColor = System.Drawing.Color.White;
            this.xemLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.xem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 249);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1203, 504);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // QLTonKhoPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.xemLichSu);
            this.Controls.Add(this.xem);
            this.Controls.Add(this.xuat);
            this.Controls.Add(this.nhapKho);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPanel);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button nhapKho;
        private System.Windows.Forms.Button xuat;
        private System.Windows.Forms.Button xemLichSu;
        private System.Windows.Forms.Button xem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
    }
}
