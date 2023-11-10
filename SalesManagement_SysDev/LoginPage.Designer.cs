namespace SalesManagement_SysDev
{
    partial class LoginPage
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_CleateDabase = new System.Windows.Forms.Button();
            this.btn_InsertSampleData = new System.Windows.Forms.Button();
            this.ShainLbl = new System.Windows.Forms.Label();
            this.PasuwadoLbl = new System.Windows.Forms.Label();
            this.ShainTxb = new System.Windows.Forms.TextBox();
            this.PasuwadoTxb = new System.Windows.Forms.TextBox();
            this.RoguinLbl = new System.Windows.Forms.Label();
            this.RoguinBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CleateDabase
            // 
            this.btn_CleateDabase.Location = new System.Drawing.Point(798, 4);
            this.btn_CleateDabase.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_CleateDabase.Name = "btn_CleateDabase";
            this.btn_CleateDabase.Size = new System.Drawing.Size(177, 74);
            this.btn_CleateDabase.TabIndex = 0;
            this.btn_CleateDabase.Text = "データベース生成";
            this.btn_CleateDabase.UseVisualStyleBackColor = true;
            this.btn_CleateDabase.Click += new System.EventHandler(this.btn_CleateDabase_Click);
            // 
            // btn_InsertSampleData
            // 
            this.btn_InsertSampleData.Location = new System.Drawing.Point(798, 94);
            this.btn_InsertSampleData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_InsertSampleData.Name = "btn_InsertSampleData";
            this.btn_InsertSampleData.Size = new System.Drawing.Size(177, 74);
            this.btn_InsertSampleData.TabIndex = 0;
            this.btn_InsertSampleData.Text = "サンプルデータ登録";
            this.btn_InsertSampleData.UseVisualStyleBackColor = true;
            this.btn_InsertSampleData.Click += new System.EventHandler(this.btn_InsertSampleData_Click);
            // 
            // ShainLbl
            // 
            this.ShainLbl.AutoSize = true;
            this.ShainLbl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShainLbl.Location = new System.Drawing.Point(60, 226);
            this.ShainLbl.Name = "ShainLbl";
            this.ShainLbl.Size = new System.Drawing.Size(119, 36);
            this.ShainLbl.TabIndex = 1;
            this.ShainLbl.Text = "社員ID";
            // 
            // PasuwadoLbl
            // 
            this.PasuwadoLbl.AutoSize = true;
            this.PasuwadoLbl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PasuwadoLbl.Location = new System.Drawing.Point(60, 330);
            this.PasuwadoLbl.Name = "PasuwadoLbl";
            this.PasuwadoLbl.Size = new System.Drawing.Size(155, 36);
            this.PasuwadoLbl.TabIndex = 2;
            this.PasuwadoLbl.Text = "パスワード";
            // 
            // ShainTxb
            // 
            this.ShainTxb.Location = new System.Drawing.Point(268, 237);
            this.ShainTxb.Name = "ShainTxb";
            this.ShainTxb.Size = new System.Drawing.Size(461, 25);
            this.ShainTxb.TabIndex = 3;
            // 
            // PasuwadoTxb
            // 
            this.PasuwadoTxb.Location = new System.Drawing.Point(268, 330);
            this.PasuwadoTxb.Name = "PasuwadoTxb";
            this.PasuwadoTxb.Size = new System.Drawing.Size(461, 25);
            this.PasuwadoTxb.TabIndex = 4;
            // 
            // RoguinLbl
            // 
            this.RoguinLbl.AutoSize = true;
            this.RoguinLbl.Font = new System.Drawing.Font("MS UI Gothic", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RoguinLbl.Location = new System.Drawing.Point(245, 88);
            this.RoguinLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoguinLbl.Name = "RoguinLbl";
            this.RoguinLbl.Size = new System.Drawing.Size(438, 80);
            this.RoguinLbl.TabIndex = 5;
            this.RoguinLbl.Text = "ログイン画面";
            // 
            // RoguinBtn
            // 
            this.RoguinBtn.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RoguinBtn.Location = new System.Drawing.Point(330, 404);
            this.RoguinBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.RoguinBtn.Name = "RoguinBtn";
            this.RoguinBtn.Size = new System.Drawing.Size(290, 102);
            this.RoguinBtn.TabIndex = 6;
            this.RoguinBtn.Text = "ログイン";
            this.RoguinBtn.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 566);
            this.Controls.Add(this.RoguinBtn);
            this.Controls.Add(this.RoguinLbl);
            this.Controls.Add(this.PasuwadoTxb);
            this.Controls.Add(this.ShainTxb);
            this.Controls.Add(this.PasuwadoLbl);
            this.Controls.Add(this.ShainLbl);
            this.Controls.Add(this.btn_InsertSampleData);
            this.Controls.Add(this.btn_CleateDabase);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoginPage";
            this.Text = "販売管理システムログイン画面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CleateDabase;
        private System.Windows.Forms.Button btn_InsertSampleData;
        private System.Windows.Forms.Label ShainLbl;
        private System.Windows.Forms.Label PasuwadoLbl;
        private System.Windows.Forms.TextBox ShainTxb;
        private System.Windows.Forms.TextBox PasuwadoTxb;
        private System.Windows.Forms.Label RoguinLbl;
        private System.Windows.Forms.Button RoguinBtn;
    }
}

