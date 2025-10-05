namespace PBL2.Views.MenuPage
{
    partial class Menu
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search_Click = new System.Windows.Forms.Button();
            this.menuDrop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(261, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 35);
            this.textBox1.TabIndex = 0;
            // 
            // Search_Click
            // 
            this.Search_Click.Location = new System.Drawing.Point(514, 19);
            this.Search_Click.Name = "Search_Click";
            this.Search_Click.Size = new System.Drawing.Size(86, 35);
            this.Search_Click.TabIndex = 1;
            this.Search_Click.Text = "Search";
            this.Search_Click.UseVisualStyleBackColor = true;
            // 
            // menuDrop
            // 
            this.menuDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDrop.FormattingEnabled = true;
            this.menuDrop.Location = new System.Drawing.Point(79, 21);
            this.menuDrop.Name = "menuDrop";
            this.menuDrop.Size = new System.Drawing.Size(121, 33);
            this.menuDrop.TabIndex = 2;
            this.menuDrop.SelectedIndexChanged += new System.EventHandler(this.menuDrop_SelectedIndexChanged);
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.menuDrop);
            this.Controls.Add(this.Search_Click);
            this.Controls.Add(this.textBox1);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(821, 700);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Search_Click;
        private System.Windows.Forms.ComboBox menuDrop;
    }
}
