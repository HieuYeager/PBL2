namespace PBL2.Views.MenuPage
{
    partial class Order
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
            this.label2 = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.ThanhToanbtn = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "Order";
            // 
            // panelOrder
            // 
            this.panelOrder.Location = new System.Drawing.Point(0, 52);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(227, 581);
            this.panelOrder.TabIndex = 7;
            // 
            // ThanhToanbtn
            // 
            this.ThanhToanbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThanhToanbtn.Location = new System.Drawing.Point(52, 639);
            this.ThanhToanbtn.Name = "ThanhToanbtn";
            this.ThanhToanbtn.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.ThanhToanbtn.OverrideDefault.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ThanhToanbtn.OverrideFocus.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.ThanhToanbtn.OverrideFocus.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ThanhToanbtn.Size = new System.Drawing.Size(116, 46);
            this.ThanhToanbtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(216)))), ((int)(((byte)(191)))));
            this.ThanhToanbtn.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ThanhToanbtn.StateCommon.Border.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Solid;
            this.ThanhToanbtn.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ThanhToanbtn.StateCommon.Border.Rounding = 25F;
            this.ThanhToanbtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThanhToanbtn.TabIndex = 8;
            this.ThanhToanbtn.Values.Text = "Thanh toán";
            // 
            // Order
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(163)))), ((int)(((byte)(146)))));
            this.Controls.Add(this.ThanhToanbtn);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.label2);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(227, 700);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel panelOrder;
        private Krypton.Toolkit.KryptonButton ThanhToanbtn;
    }
}
