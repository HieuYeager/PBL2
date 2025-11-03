namespace PBL2.Views.QL_NhanVien
{
    partial class QL_NhanVienPage
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
            this.Label = new System.Windows.Forms.Label();
            this.loginBtn = new Krypton.Toolkit.KryptonButton();
            this.FindTxt = new Krypton.Toolkit.KryptonTextBox();
            this.searchBtn = new Krypton.Toolkit.KryptonButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.Label.Location = new System.Drawing.Point(386, 24);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(315, 43);
            this.Label.TabIndex = 2;
            this.Label.Text = "Quản lý nhân viên";
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Location = new System.Drawing.Point(28, 74);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.loginBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.loginBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.loginBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.loginBtn.Size = new System.Drawing.Size(116, 46);
            this.loginBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.loginBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.loginBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.loginBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.loginBtn.StateCommon.Border.Rounding = 10F;
            this.loginBtn.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.loginBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Mongolian Baiti", 12F);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Values.Text = "ADD++";
            this.loginBtn.Click += new System.EventHandler(this.addBtn_Click_1);
            // 
            // FindTxt
            // 
            this.FindTxt.Location = new System.Drawing.Point(792, 74);
            this.FindTxt.Name = "FindTxt";
            this.FindTxt.Size = new System.Drawing.Size(189, 44);
            this.FindTxt.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.FindTxt.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.FindTxt.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.FindTxt.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.FindTxt.StateCommon.Border.Rounding = 10F;
            this.FindTxt.StateCommon.Border.Width = 2;
            this.FindTxt.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.FindTxt.StateCommon.Content.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindTxt.StateCommon.Content.Padding = new System.Windows.Forms.Padding(3);
            this.FindTxt.TabIndex = 9;
            this.FindTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FindTxt.TextChanged += new System.EventHandler(this.FindTxt_TextChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Location = new System.Drawing.Point(715, 74);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.searchBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.searchBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.searchBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.searchBtn.Size = new System.Drawing.Size(45, 42);
            this.searchBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.searchBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.searchBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.searchBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.searchBtn.StateCommon.Border.Rounding = 25F;
            this.searchBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.TabIndex = 10;
            this.searchBtn.Values.Image = global::PBL2.Properties.Resources.search;
            this.searchBtn.Values.Text = "";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(953, 736);
            this.dataGridView1.TabIndex = 11;
            // 
            // QL_NhanVienPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.FindTxt);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.Label);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1128, 875);
            this.MinimumSize = new System.Drawing.Size(1128, 875);
            this.Name = "QL_NhanVienPage";
            this.Size = new System.Drawing.Size(1128, 875);
            this.Load += new System.EventHandler(this.QL_NhanVienPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private Krypton.Toolkit.KryptonButton loginBtn;
        private Krypton.Toolkit.KryptonTextBox FindTxt;
        private Krypton.Toolkit.KryptonButton searchBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
