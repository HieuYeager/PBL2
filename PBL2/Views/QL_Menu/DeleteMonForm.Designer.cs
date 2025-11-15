namespace PBL2.Views.QL_Menu
{
    partial class DeleteMonForm
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
            this.lbCanhBao = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCanhBao
            // 
            this.lbCanhBao.AutoSize = true;
            this.lbCanhBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(101)))), ((int)(((byte)(87)))));
            this.lbCanhBao.Location = new System.Drawing.Point(193, 37);
            this.lbCanhBao.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCanhBao.Name = "lbCanhBao";
            this.lbCanhBao.Size = new System.Drawing.Size(145, 32);
            this.lbCanhBao.TabIndex = 0;
            this.lbCanhBao.Text = "Cảnh báo";
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.ForeColor = System.Drawing.Color.Red;
            this.lbText.Location = new System.Drawing.Point(40, 116);
            this.lbText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(433, 29);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "Bạn có chắc muốn xóa món này không?";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoa.Location = new System.Drawing.Point(94, 198);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnHuy2
            // 
            this.btnHuy2.Location = new System.Drawing.Point(325, 198);
            this.btnHuy2.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy2.Name = "btnHuy2";
            this.btnHuy2.Size = new System.Drawing.Size(110, 35);
            this.btnHuy2.TabIndex = 3;
            this.btnHuy2.Text = "Hủy";
            this.btnHuy2.UseVisualStyleBackColor = true;
            // 
            // DeleteMonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(533, 288);
            this.Controls.Add(this.btnHuy2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.lbCanhBao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeleteMonForm";
            this.Text = "DeleteMonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCanhBao;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy2;
    }
}