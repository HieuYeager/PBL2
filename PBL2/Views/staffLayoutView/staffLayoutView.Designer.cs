namespace PBL2.Views.staffView
{
    partial class staffLayoutView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBot = new System.Windows.Forms.Panel();
            this.btnLogout = new Krypton.Toolkit.KryptonButton();
            this.panelBtns = new System.Windows.Forms.Panel();
            this.btnIngredient = new Krypton.Toolkit.KryptonButton();
            this.btnOrderlist = new Krypton.Toolkit.KryptonButton();
            this.btnMenu = new Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelBot.SuspendLayout();
            this.panelBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.panel1.Controls.Add(this.panelBot);
            this.panel1.Controls.Add(this.panelBtns);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 700);
            this.panel1.TabIndex = 0;
            // 
            // panelBot
            // 
            this.panelBot.Controls.Add(this.btnLogout);
            this.panelBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBot.Location = new System.Drawing.Point(0, 600);
            this.panelBot.Name = "panelBot";
            this.panelBot.Size = new System.Drawing.Size(179, 100);
            this.panelBot.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Location = new System.Drawing.Point(0, 53);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnLogout.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnLogout.OverrideDefault.Border.Draw = Krypton.Toolkit.InheritBool.False;
            this.btnLogout.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLogout.Size = new System.Drawing.Size(179, 47);
            this.btnLogout.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnLogout.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnLogout.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnLogout.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnLogout.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnLogout.StateCommon.Border.Rounding = 10F;
            this.btnLogout.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Values.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.logout_btn_click);
            // 
            // panelBtns
            // 
            this.panelBtns.Controls.Add(this.btnIngredient);
            this.panelBtns.Controls.Add(this.btnOrderlist);
            this.panelBtns.Controls.Add(this.btnMenu);
            this.panelBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBtns.Location = new System.Drawing.Point(0, 162);
            this.panelBtns.Name = "panelBtns";
            this.panelBtns.Padding = new System.Windows.Forms.Padding(15, 30, 15, 0);
            this.panelBtns.Size = new System.Drawing.Size(179, 538);
            this.panelBtns.TabIndex = 1;
            // 
            // btnIngredient
            // 
            this.btnIngredient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngredient.Location = new System.Drawing.Point(15, 124);
            this.btnIngredient.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnIngredient.Name = "btnIngredient";
            this.btnIngredient.OverrideDefault.Border.Draw = Krypton.Toolkit.InheritBool.False;
            this.btnIngredient.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIngredient.Size = new System.Drawing.Size(149, 47);
            this.btnIngredient.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnIngredient.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnIngredient.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnIngredient.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnIngredient.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnIngredient.StateCommon.Border.Rounding = 10F;
            this.btnIngredient.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngredient.TabIndex = 2;
            this.btnIngredient.Values.Text = "Ingredient";
            // 
            // btnOrderlist
            // 
            this.btnOrderlist.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrderlist.Location = new System.Drawing.Point(15, 77);
            this.btnOrderlist.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnOrderlist.Name = "btnOrderlist";
            this.btnOrderlist.OverrideDefault.Border.Draw = Krypton.Toolkit.InheritBool.False;
            this.btnOrderlist.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOrderlist.Size = new System.Drawing.Size(149, 47);
            this.btnOrderlist.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnOrderlist.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnOrderlist.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnOrderlist.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnOrderlist.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnOrderlist.StateCommon.Border.Rounding = 10F;
            this.btnOrderlist.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderlist.TabIndex = 1;
            this.btnOrderlist.Values.Text = "Order list";
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.Location = new System.Drawing.Point(15, 30);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnMenu.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnMenu.OverrideDefault.Border.Draw = Krypton.Toolkit.InheritBool.False;
            this.btnMenu.OverrideDefault.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnMenu.Size = new System.Drawing.Size(149, 47);
            this.btnMenu.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnMenu.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.btnMenu.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnMenu.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.btnMenu.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnMenu.StateCommon.Border.Rounding = 10F;
            this.btnMenu.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Values.Text = "Menu";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::PBL2.Properties.Resources.Green_coffee_logo_badge___Free_Vector;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // staffLayoutView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "staffLayoutView";
            this.Size = new System.Drawing.Size(1000, 700);
            this.panel1.ResumeLayout(false);
            this.panelBot.ResumeLayout(false);
            this.panelBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelBot;
        private System.Windows.Forms.Panel panelBtns;
        private Krypton.Toolkit.KryptonButton btnMenu;
        private Krypton.Toolkit.KryptonButton btnIngredient;
        private Krypton.Toolkit.KryptonButton btnOrderlist;
        private Krypton.Toolkit.KryptonButton btnLogout;
    }
}
