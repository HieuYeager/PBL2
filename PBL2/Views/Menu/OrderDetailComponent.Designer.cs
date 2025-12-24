namespace PBL2.Views.MenuPage
{
    partial class OrderDetailComponent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailComponent));
            this.kryptonGroup1 = new Krypton.Toolkit.KryptonGroup();
            this.closeBtn = new Krypton.Toolkit.KryptonButton();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.minusBtn = new Krypton.Toolkit.KryptonButton();
            this.addBtn = new Krypton.Toolkit.KryptonButton();
            this.labelGia = new System.Windows.Forms.Label();
            this.labelTenMon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.closeBtn);
            this.kryptonGroup1.Panel.Controls.Add(this.labelSoLuong);
            this.kryptonGroup1.Panel.Controls.Add(this.minusBtn);
            this.kryptonGroup1.Panel.Controls.Add(this.addBtn);
            this.kryptonGroup1.Panel.Controls.Add(this.labelGia);
            this.kryptonGroup1.Panel.Controls.Add(this.labelTenMon);
            this.kryptonGroup1.Size = new System.Drawing.Size(240, 89);
            this.kryptonGroup1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonGroup1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonGroup1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup1.StateCommon.Border.Rounding = 0F;
            this.kryptonGroup1.TabIndex = 1;
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Location = new System.Drawing.Point(184, 49);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.closeBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.closeBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.closeBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.closeBtn.Size = new System.Drawing.Size(35, 35);
            this.closeBtn.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.closeBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.closeBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.closeBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.closeBtn.StateCommon.Border.Rounding = 5F;
            this.closeBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Values.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Values.Image")));
            this.closeBtn.Values.Text = "";
            this.closeBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.labelSoLuong.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoLuong.Location = new System.Drawing.Point(54, 50);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(27, 34);
            this.labelSoLuong.TabIndex = 10;
            this.labelSoLuong.Text = "0";
            // 
            // minusBtn
            // 
            this.minusBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minusBtn.Location = new System.Drawing.Point(13, 50);
            this.minusBtn.Name = "minusBtn";
            this.minusBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.minusBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.minusBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.minusBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.minusBtn.Size = new System.Drawing.Size(35, 35);
            this.minusBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.minusBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.minusBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.minusBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.minusBtn.StateCommon.Border.Rounding = 5F;
            this.minusBtn.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.minusBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minusBtn.StateCommon.Content.ShortText.Image = ((System.Drawing.Image)(resources.GetObject("minusBtn.StateCommon.Content.ShortText.Image")));
            this.minusBtn.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.minusBtn.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.minusBtn.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.minusBtn.TabIndex = 9;
            this.minusBtn.Values.Image = ((System.Drawing.Image)(resources.GetObject("minusBtn.Values.Image")));
            this.minusBtn.Values.Text = "";
            this.minusBtn.Click += new System.EventHandler(this.subBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.Location = new System.Drawing.Point(98, 49);
            this.addBtn.Name = "addBtn";
            this.addBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.Size = new System.Drawing.Size(35, 35);
            this.addBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.addBtn.StateCommon.Border.Rounding = 5F;
            this.addBtn.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.addBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.StateCommon.Content.ShortText.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.StateCommon.Content.ShortText.Image")));
            this.addBtn.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.addBtn.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.addBtn.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.addBtn.TabIndex = 7;
            this.addBtn.Values.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Values.Image")));
            this.addBtn.Values.Text = "";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // labelGia
            // 
            this.labelGia.AutoSize = true;
            this.labelGia.BackColor = System.Drawing.Color.Transparent;
            this.labelGia.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGia.Location = new System.Drawing.Point(30, 27);
            this.labelGia.Name = "labelGia";
            this.labelGia.Size = new System.Drawing.Size(50, 21);
            this.labelGia.TabIndex = 1;
            this.labelGia.Text = "1000";
            // 
            // labelTenMon
            // 
            this.labelTenMon.AutoSize = true;
            this.labelTenMon.BackColor = System.Drawing.Color.Transparent;
            this.labelTenMon.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenMon.Location = new System.Drawing.Point(9, 6);
            this.labelTenMon.Name = "labelTenMon";
            this.labelTenMon.Size = new System.Drawing.Size(113, 21);
            this.labelTenMon.TabIndex = 0;
            this.labelTenMon.Text = "<Tên món>";
            // 
            // OrderDetailComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kryptonGroup1);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OrderDetailComponent";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(250, 99);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroup kryptonGroup1;
        private Krypton.Toolkit.KryptonButton addBtn;
        private System.Windows.Forms.Label labelTenMon;
        private Krypton.Toolkit.KryptonButton minusBtn;
        private System.Windows.Forms.Label labelSoLuong;
        private Krypton.Toolkit.KryptonButton closeBtn;
        private System.Windows.Forms.Label labelGia;
    }
}
