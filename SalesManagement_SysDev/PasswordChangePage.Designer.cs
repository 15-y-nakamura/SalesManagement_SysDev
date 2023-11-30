namespace SalesManagement_SysDev
{
    partial class PasswordChangePage
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
            this.PassChnLbl = new System.Windows.Forms.Label();
            this.PassLbl = new System.Windows.Forms.Label();
            this.RepeatPassLbl = new System.Windows.Forms.Label();
            this.PassTxb = new System.Windows.Forms.TextBox();
            this.RepeatPassTxb = new System.Windows.Forms.TextBox();
            this.KeepBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PassChnLbl
            // 
            this.PassChnLbl.AutoSize = true;
            this.PassChnLbl.Font = new System.Drawing.Font("MS UI Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PassChnLbl.Location = new System.Drawing.Point(169, 58);
            this.PassChnLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PassChnLbl.Name = "PassChnLbl";
            this.PassChnLbl.Size = new System.Drawing.Size(674, 80);
            this.PassChnLbl.TabIndex = 6;
            this.PassChnLbl.Text = "パスワード変更画面";
            // 
            // PassLbl
            // 
            this.PassLbl.AutoSize = true;
            this.PassLbl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PassLbl.Location = new System.Drawing.Point(177, 183);
            this.PassLbl.Name = "PassLbl";
            this.PassLbl.Size = new System.Drawing.Size(246, 36);
            this.PassLbl.TabIndex = 7;
            this.PassLbl.Text = "新しいパスワード";
            // 
            // RepeatPassLbl
            // 
            this.RepeatPassLbl.AutoSize = true;
            this.RepeatPassLbl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RepeatPassLbl.Location = new System.Drawing.Point(177, 290);
            this.RepeatPassLbl.Name = "RepeatPassLbl";
            this.RepeatPassLbl.Size = new System.Drawing.Size(390, 36);
            this.RepeatPassLbl.TabIndex = 8;
            this.RepeatPassLbl.Text = "新しいパスワード（確認用）";
            // 
            // PassTxb
            // 
            this.PassTxb.Location = new System.Drawing.Point(269, 241);
            this.PassTxb.Name = "PassTxb";
            this.PassTxb.Size = new System.Drawing.Size(461, 25);
            this.PassTxb.TabIndex = 9;
            // 
            // RepeatPassTxb
            // 
            this.RepeatPassTxb.Location = new System.Drawing.Point(269, 343);
            this.RepeatPassTxb.Name = "RepeatPassTxb";
            this.RepeatPassTxb.Size = new System.Drawing.Size(461, 25);
            this.RepeatPassTxb.TabIndex = 10;
            // 
            // KeepBtn
            // 
            this.KeepBtn.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeepBtn.Location = new System.Drawing.Point(340, 407);
            this.KeepBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.KeepBtn.Name = "KeepBtn";
            this.KeepBtn.Size = new System.Drawing.Size(290, 102);
            this.KeepBtn.TabIndex = 11;
            this.KeepBtn.Text = "保存";
            this.KeepBtn.UseVisualStyleBackColor = true;
            // 
            // PasswordChangePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 566);
            this.Controls.Add(this.KeepBtn);
            this.Controls.Add(this.RepeatPassTxb);
            this.Controls.Add(this.PassTxb);
            this.Controls.Add(this.RepeatPassLbl);
            this.Controls.Add(this.PassLbl);
            this.Controls.Add(this.PassChnLbl);
            this.Name = "PasswordChangePage";
            this.Text = "販売管理システムパスワード変更画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PassChnLbl;
        private System.Windows.Forms.Label PassLbl;
        private System.Windows.Forms.Label RepeatPassLbl;
        private System.Windows.Forms.TextBox PassTxb;
        private System.Windows.Forms.TextBox RepeatPassTxb;
        private System.Windows.Forms.Button KeepBtn;
    }
}