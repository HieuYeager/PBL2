namespace PBL2.Views.QL_Menu
{
    partial class QL_MenuPage
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
            this.Label = new System.Windows.Forms.Label();
            this.loginBtn = new Krypton.Toolkit.KryptonButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComboBoxDanhMuc = new Krypton.Toolkit.KryptonComboBox();
            this.FindTxt = new Krypton.Toolkit.KryptonTextBox();
            this.addBtn = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxDanhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.Label.Location = new System.Drawing.Point(395, 19);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(206, 35);
            this.Label.TabIndex = 1;
            this.Label.Text = "Quản lý menu";
            // 
            // loginBtn
            // 
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Location = new System.Drawing.Point(15, 73);
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
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Values.Text = "ADD";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(0, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Mongolian Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1003, 575);
            this.dataGridView1.TabIndex = 6;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Column7";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Column9";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // ComboBoxDanhMuc
            // 
            this.ComboBoxDanhMuc.DropDownWidth = 161;
            this.ComboBoxDanhMuc.Location = new System.Drawing.Point(519, 73);
            this.ComboBoxDanhMuc.Name = "ComboBoxDanhMuc";
            this.ComboBoxDanhMuc.Size = new System.Drawing.Size(176, 42);
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Back.Color1 = System.Drawing.Color.White;
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Border.Rounding = 10F;
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Border.Width = 2;
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxDanhMuc.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ComboBoxDanhMuc.StateCommon.Item.Content.Padding = new System.Windows.Forms.Padding(3);
            this.ComboBoxDanhMuc.StateCommon.Item.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.ComboBoxDanhMuc.StateCommon.Item.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.ComboBoxDanhMuc.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxDanhMuc.TabIndex = 7;
            this.ComboBoxDanhMuc.Text = "coffee";
            // 
            // FindTxt
            // 
            this.FindTxt.Location = new System.Drawing.Point(728, 73);
            this.FindTxt.Name = "FindTxt";
            this.FindTxt.Size = new System.Drawing.Size(176, 40);
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
            this.FindTxt.TabIndex = 8;
            this.FindTxt.Text = "username";
            // 
            // addBtn
            // 
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.Location = new System.Drawing.Point(927, 73);
            this.addBtn.Name = "addBtn";
            this.addBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.Size = new System.Drawing.Size(45, 42);
            this.addBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.addBtn.StateCommon.Border.Rounding = 25F;
            this.addBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.TabIndex = 9;
            this.addBtn.Values.Image = global::PBL2.Properties.Resources.search;
            this.addBtn.Values.Text = "";
            // 
            // QL_MenuPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.FindTxt);
            this.Controls.Add(this.ComboBoxDanhMuc);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.Label);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1003, 700);
            this.MinimumSize = new System.Drawing.Size(1003, 700);
            this.Name = "QL_MenuPage";
            this.Size = new System.Drawing.Size(1003, 700);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxDanhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private Krypton.Toolkit.KryptonButton loginBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private Krypton.Toolkit.KryptonComboBox ComboBoxDanhMuc;
        private Krypton.Toolkit.KryptonTextBox FindTxt;
        private Krypton.Toolkit.KryptonButton addBtn;
    }
}
