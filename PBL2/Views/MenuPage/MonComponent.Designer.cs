namespace PBL2.Views.MenuPage
{
    partial class MonComponent
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
            this.kryptonGroup1 = new Krypton.Toolkit.KryptonGroup();
            this.addBtn = new Krypton.Toolkit.KryptonButton();
            this.labelGia = new System.Windows.Forms.Label();
            this.labelTenMon = new System.Windows.Forms.Label();
            this.Image = new Krypton.Toolkit.KryptonPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroup1.Location = new System.Drawing.Point(10, 10);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.addBtn);
            this.kryptonGroup1.Panel.Controls.Add(this.Image);
            this.kryptonGroup1.Panel.Controls.Add(this.labelGia);
            this.kryptonGroup1.Panel.Controls.Add(this.labelTenMon);
            this.kryptonGroup1.Size = new System.Drawing.Size(227, 131);
            this.kryptonGroup1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonGroup1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonGroup1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup1.StateCommon.Border.Rounding = 10F;
            this.kryptonGroup1.TabIndex = 0;
            // 
            // addBtn
            // 
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBtn.Location = new System.Drawing.Point(134, 75);
            this.addBtn.Name = "addBtn";
            this.addBtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.Size = new System.Drawing.Size(76, 39);
            this.addBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.addBtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.addBtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.addBtn.StateCommon.Border.Rounding = 25F;
            this.addBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.TabIndex = 7;
            this.addBtn.Values.Text = "Thêm";
            this.addBtn.Click += new System.EventHandler(this.addMon_Click);
            // 
            // labelGia
            // 
            this.labelGia.AutoSize = true;
            this.labelGia.BackColor = System.Drawing.Color.Transparent;
            this.labelGia.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGia.Location = new System.Drawing.Point(114, 48);
            this.labelGia.Name = "labelGia";
            this.labelGia.Size = new System.Drawing.Size(46, 24);
            this.labelGia.TabIndex = 1;
            this.labelGia.Text = "1000";
            // 
            // labelTenMon
            // 
            this.labelTenMon.AutoSize = true;
            this.labelTenMon.BackColor = System.Drawing.Color.Transparent;
            this.labelTenMon.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenMon.Location = new System.Drawing.Point(106, 11);
            this.labelTenMon.Name = "labelTenMon";
            this.labelTenMon.Size = new System.Drawing.Size(58, 24);
            this.labelTenMon.TabIndex = 0;
            this.labelTenMon.Text = "label1";
            // 
            // Image
            // 
            this.Image.Dock = System.Windows.Forms.DockStyle.Left;
            this.Image.Image = global::PBL2.Properties.Resources.Green_coffee_logo_badge___Free_Vector;
            this.Image.Location = new System.Drawing.Point(0, 0);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(100, 123);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image.TabIndex = 2;
            this.Image.TabStop = false;
            // 
            // MonComponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonGroup1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MonComponent";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(247, 151);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            this.kryptonGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonGroup kryptonGroup1;
        private System.Windows.Forms.Label labelTenMon;
        private System.Windows.Forms.Label labelGia;
        private Krypton.Toolkit.KryptonPictureBox Image;
        private Krypton.Toolkit.KryptonButton addBtn;
    }
}
