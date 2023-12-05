namespace SalesManagement_SysDev
{
    partial class Shainkanri
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
            this.TopHonshaBtn = new System.Windows.Forms.Button();
            this.TopEigyoBtn = new System.Windows.Forms.Button();
            this.TopButsuryuBtn = new System.Windows.Forms.Button();
            this.TopLbl = new System.Windows.Forms.Label();
            this.TopShainPnl = new System.Windows.Forms.Panel();
            this.EigyoushoNameCmb = new System.Windows.Forms.ComboBox();
            this.JoinDateDtm = new System.Windows.Forms.DateTimePicker();
            this.GamenKousinBtn = new System.Windows.Forms.Button();
            this.ShainKanriDgv = new System.Windows.Forms.DataGridView();
            this.TelTxb = new System.Windows.Forms.TextBox();
            this.TelLbl = new System.Windows.Forms.Label();
            this.EigyoshoNameLbl = new System.Windows.Forms.Label();
            this.ShainKanriFlagCmb = new System.Windows.Forms.ComboBox();
            this.YakushokuNameTxb = new System.Windows.Forms.ComboBox();
            this.YakushokuNameTxb = new System.Windows.Forms.ComboBox();
            this.ShainNameTxb = new System.Windows.Forms.TextBox();
            this.HihyojiTxb = new System.Windows.Forms.TextBox();
            this.ShainIDTxb = new System.Windows.Forms.TextBox();
            this.ShainNameLbl = new System.Windows.Forms.Label();
            this.JoinDateLbl = new System.Windows.Forms.Label();
            this.YakushokuNameLbl = new System.Windows.Forms.Label();
            this.HihyojiLbl = new System.Windows.Forms.Label();
            this.ShainKanriFlagLbl = new System.Windows.Forms.Label();
            this.ShainIDLbl = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.HiddenBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.RegistBtn = new System.Windows.Forms.Button();
            this.TopLogoutBtn = new System.Windows.Forms.Button();
            this.TopIDHyojiLbl = new System.Windows.Forms.Label();
            this.TopIDLbl = new System.Windows.Forms.Label();
            this.TopEigyoshoLbl = new System.Windows.Forms.Label();
            this.TopEigyoshoHyojiLbl = new System.Windows.Forms.Label();
            this.TopJikanLbl = new System.Windows.Forms.Label();
            this.TopJikanHyojiLbl = new System.Windows.Forms.Label();
            this.TopYakushokuLbl = new System.Windows.Forms.Label();
            this.TopYakushokuHyojiLbl = new System.Windows.Forms.Label();
            this.TopNameLbl = new System.Windows.Forms.Label();
            this.TopNameHyojiLbl = new System.Windows.Forms.Label();
            this.TopShainPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShainKanriDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // TopHonshaBtn
            // 
            this.TopHonshaBtn.AutoSize = true;
            this.TopHonshaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopHonshaBtn.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.TopHonshaBtn.Location = new System.Drawing.Point(12, 158);
            this.TopHonshaBtn.Name = "TopHonshaBtn";
            this.TopHonshaBtn.Size = new System.Drawing.Size(210, 130);
            this.TopHonshaBtn.TabIndex = 0;
            this.TopHonshaBtn.Text = "本社";
            this.TopHonshaBtn.UseVisualStyleBackColor = true;
            this.TopHonshaBtn.Click += new System.EventHandler(this.TopHonshaBtn_Click);
            // 
            // TopEigyoBtn
            // 
            this.TopEigyoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopEigyoBtn.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.TopEigyoBtn.Location = new System.Drawing.Point(12, 294);
            this.TopEigyoBtn.Name = "TopEigyoBtn";
            this.TopEigyoBtn.Size = new System.Drawing.Size(210, 130);
            this.TopEigyoBtn.TabIndex = 1;
            this.TopEigyoBtn.Text = "営業";
            this.TopEigyoBtn.UseVisualStyleBackColor = true;
            this.TopEigyoBtn.Click += new System.EventHandler(this.TopEigyoBtn_Click);
            // 
            // TopButsuryuBtn
            // 
            this.TopButsuryuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TopButsuryuBtn.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.TopButsuryuBtn.Location = new System.Drawing.Point(12, 430);
            this.TopButsuryuBtn.Name = "TopButsuryuBtn";
            this.TopButsuryuBtn.Size = new System.Drawing.Size(210, 130);
            this.TopButsuryuBtn.TabIndex = 2;
            this.TopButsuryuBtn.Text = "物流";
            this.TopButsuryuBtn.UseVisualStyleBackColor = true;
            this.TopButsuryuBtn.Click += new System.EventHandler(this.TopButsuryuBtn_Click);
            // 
            // TopLbl
            // 
            this.TopLbl.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.TopLbl.Location = new System.Drawing.Point(253, 38);
            this.TopLbl.Name = "TopLbl";
            this.TopLbl.Size = new System.Drawing.Size(617, 93);
            this.TopLbl.TabIndex = 3;
            this.TopLbl.Text = "社員管理画面";
            // 
            // TopShainPnl
            // 
            this.TopShainPnl.BackColor = System.Drawing.Color.LightGray;
            this.TopShainPnl.Controls.Add(this.EigyoushoNameCmb);
            this.TopShainPnl.Controls.Add(this.JoinDateDtm);
            this.TopShainPnl.Controls.Add(this.GamenKousinBtn);
            this.TopShainPnl.Controls.Add(this.ShainKanriDgv);
            this.TopShainPnl.Controls.Add(this.TelTxb);
            this.TopShainPnl.Controls.Add(this.TelLbl);
            this.TopShainPnl.Controls.Add(this.EigyoshoNameLbl);
            this.TopShainPnl.Controls.Add(this.ShainKanriFlagCmb);
            this.TopShainPnl.Controls.Add(this.YakushokuNameTxb);
            this.TopShainPnl.Controls.Add(this.YakushokuNameTxb);
            this.TopShainPnl.Controls.Add(this.ShainNameTxb);
            this.TopShainPnl.Controls.Add(this.HihyojiTxb);
            this.TopShainPnl.Controls.Add(this.ShainIDTxb);
            this.TopShainPnl.Controls.Add(this.ShainNameLbl);
            this.TopShainPnl.Controls.Add(this.JoinDateLbl);
            this.TopShainPnl.Controls.Add(this.YakushokuNameLbl);
            this.TopShainPnl.Controls.Add(this.HihyojiLbl);
            this.TopShainPnl.Controls.Add(this.ShainKanriFlagLbl);
            this.TopShainPnl.Controls.Add(this.ShainIDLbl);
            this.TopShainPnl.Controls.Add(this.SearchBtn);
            this.TopShainPnl.Controls.Add(this.HiddenBtn);
            this.TopShainPnl.Controls.Add(this.UpdateBtn);
            this.TopShainPnl.Controls.Add(this.RegistBtn);
            this.TopShainPnl.Location = new System.Drawing.Point(253, 158);
            this.TopShainPnl.Name = "TopShainPnl";
            this.TopShainPnl.Size = new System.Drawing.Size(1835, 783);
            this.TopShainPnl.TabIndex = 23;
            // 
            // EigyoushoNameCmb
            // 
            this.EigyoushoNameCmb.FormattingEnabled = true;
            this.EigyoushoNameCmb.Location = new System.Drawing.Point(1050, 149);
            this.EigyoushoNameCmb.Name = "EigyoushoNameCmb";
            this.EigyoushoNameCmb.Size = new System.Drawing.Size(201, 26);
            this.EigyoushoNameCmb.TabIndex = 56;
            // 
            // JoinDateDtm
            // 
            this.JoinDateDtm.Location = new System.Drawing.Point(642, 219);
            this.JoinDateDtm.Name = "JoinDateDtm";
            this.JoinDateDtm.Size = new System.Drawing.Size(201, 25);
            this.JoinDateDtm.TabIndex = 55;
            // 
            // GamenKousinBtn
            // 
            this.GamenKousinBtn.BackgroundImage = global::SalesManagement_SysDev.Properties.Resources.reload;
            this.GamenKousinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.GamenKousinBtn.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.GamenKousinBtn.Location = new System.Drawing.Point(1710, 26);
            this.GamenKousinBtn.Name = "GamenKousinBtn";
            this.GamenKousinBtn.Size = new System.Drawing.Size(100, 90);
            this.GamenKousinBtn.TabIndex = 54;
            this.GamenKousinBtn.UseVisualStyleBackColor = true;
            // 
            // ShainKanriDgv
            // 
            this.ShainKanriDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShainKanriDgv.Location = new System.Drawing.Point(97, 492);
            this.ShainKanriDgv.Name = "ShainKanriDgv";
            this.ShainKanriDgv.RowHeadersWidth = 62;
            this.ShainKanriDgv.RowTemplate.Height = 27;
            this.ShainKanriDgv.Size = new System.Drawing.Size(1633, 256);
            this.ShainKanriDgv.TabIndex = 51;
            // 
            // TelTxb
            // 
            this.TelTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TelTxb.Location = new System.Drawing.Point(1428, 150);
            this.TelTxb.Name = "TelTxb";
            this.TelTxb.Size = new System.Drawing.Size(201, 25);
            this.TelTxb.TabIndex = 21;
            // 
            // TelLbl
            // 
            this.TelLbl.AutoSize = true;
            this.TelLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TelLbl.Location = new System.Drawing.Point(1285, 150);
            this.TelLbl.Name = "TelLbl";
            this.TelLbl.Size = new System.Drawing.Size(124, 28);
            this.TelLbl.TabIndex = 19;
            this.TelLbl.Text = "電話番号";
            // 
            // EigyoshoNameLbl
            // 
            this.EigyoshoNameLbl.AutoSize = true;
            this.EigyoshoNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EigyoshoNameLbl.Location = new System.Drawing.Point(908, 150);
            this.EigyoshoNameLbl.Name = "EigyoshoNameLbl";
            this.EigyoshoNameLbl.Size = new System.Drawing.Size(124, 28);
            this.EigyoshoNameLbl.TabIndex = 20;
            this.EigyoshoNameLbl.Text = "営業所名";
            // 
            // ShainKanriFlagCmb
            // 
            this.ShainKanriFlagCmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShainKanriFlagCmb.FormattingEnabled = true;
            this.ShainKanriFlagCmb.Location = new System.Drawing.Point(237, 290);
            this.ShainKanriFlagCmb.Name = "ShainKanriFlagCmb";
            this.ShainKanriFlagCmb.Size = new System.Drawing.Size(201, 26);
            this.ShainKanriFlagCmb.TabIndex = 18;
            // 
            // YakushokuNameTxb
            // 
            this.YakushokuNameTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.YakushokuNameTxb.FormattingEnabled = true;
            this.YakushokuNameTxb.Location = new System.Drawing.Point(237, 218);
            this.YakushokuNameTxb.Name = "YakushokuNameTxb";
            this.YakushokuNameTxb.Size = new System.Drawing.Size(201, 26);
            this.YakushokuNameTxb.TabIndex = 18;
            // 
            // ShainNameTxb
            // 
            this.ShainNameTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShainNameTxb.Location = new System.Drawing.Point(642, 150);
            this.ShainNameTxb.Name = "ShainNameTxb";
            this.ShainNameTxb.Size = new System.Drawing.Size(201, 25);
            this.ShainNameTxb.TabIndex = 13;
            // 
            // HihyojiTxb
            // 
            this.HihyojiTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HihyojiTxb.Location = new System.Drawing.Point(642, 290);
            this.HihyojiTxb.Multiline = true;
            this.HihyojiTxb.Name = "HihyojiTxb";
            this.HihyojiTxb.Size = new System.Drawing.Size(609, 90);
            this.HihyojiTxb.TabIndex = 14;
            // 
            // ShainIDTxb
            // 
            this.ShainIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShainIDTxb.Location = new System.Drawing.Point(237, 150);
            this.ShainIDTxb.Name = "ShainIDTxb";
            this.ShainIDTxb.Size = new System.Drawing.Size(201, 25);
            this.ShainIDTxb.TabIndex = 17;
            // 
            // ShainNameLbl
            // 
            this.ShainNameLbl.AutoSize = true;
            this.ShainNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShainNameLbl.Location = new System.Drawing.Point(530, 150);
            this.ShainNameLbl.Name = "ShainNameLbl";
            this.ShainNameLbl.Size = new System.Drawing.Size(96, 28);
            this.ShainNameLbl.TabIndex = 6;
            this.ShainNameLbl.Text = "社員名";
            // 
            // JoinDateLbl
            // 
            this.JoinDateLbl.AutoSize = true;
            this.JoinDateLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.JoinDateLbl.Location = new System.Drawing.Point(474, 216);
            this.JoinDateLbl.Name = "JoinDateLbl";
            this.JoinDateLbl.Size = new System.Drawing.Size(152, 28);
            this.JoinDateLbl.TabIndex = 7;
            this.JoinDateLbl.Text = "入社年月日";
            // 
            // YakushokuNameLbl
            // 
            this.YakushokuNameLbl.AutoSize = true;
            this.YakushokuNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.YakushokuNameLbl.Location = new System.Drawing.Point(121, 219);
            this.YakushokuNameLbl.Name = "YakushokuNameLbl";
            this.YakushokuNameLbl.Size = new System.Drawing.Size(96, 28);
            this.YakushokuNameLbl.TabIndex = 8;
            this.YakushokuNameLbl.Text = "役職名";
            // 
            // HihyojiLbl
            // 
            this.HihyojiLbl.AutoSize = true;
            this.HihyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HihyojiLbl.Location = new System.Drawing.Point(473, 290);
            this.HihyojiLbl.Name = "HihyojiLbl";
            this.HihyojiLbl.Size = new System.Drawing.Size(152, 28);
            this.HihyojiLbl.TabIndex = 9;
            this.HihyojiLbl.Text = "非表示理由";
            // 
            // ShainKanriFlagLbl
            // 
            this.ShainKanriFlagLbl.AutoSize = true;
            this.ShainKanriFlagLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShainKanriFlagLbl.Location = new System.Drawing.Point(33, 290);
            this.ShainKanriFlagLbl.Name = "ShainKanriFlagLbl";
            this.ShainKanriFlagLbl.Size = new System.Drawing.Size(184, 28);
            this.ShainKanriFlagLbl.TabIndex = 10;
            this.ShainKanriFlagLbl.Text = "社員管理フラグ";
            // 
            // ShainIDLbl
            // 
            this.ShainIDLbl.AutoSize = true;
            this.ShainIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShainIDLbl.Location = new System.Drawing.Point(125, 150);
            this.ShainIDLbl.Name = "ShainIDLbl";
            this.ShainIDLbl.Size = new System.Drawing.Size(93, 28);
            this.ShainIDLbl.TabIndex = 11;
            this.ShainIDLbl.Text = "社員ID";
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchBtn.Location = new System.Drawing.Point(1375, 26);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(300, 90);
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.Text = "検索";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // HiddenBtn
            // 
            this.HiddenBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HiddenBtn.Location = new System.Drawing.Point(960, 26);
            this.HiddenBtn.Name = "HiddenBtn";
            this.HiddenBtn.Size = new System.Drawing.Size(300, 90);
            this.HiddenBtn.TabIndex = 4;
            this.HiddenBtn.Text = "非表示";
            this.HiddenBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UpdateBtn.Location = new System.Drawing.Point(545, 26);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(300, 90);
            this.UpdateBtn.TabIndex = 5;
            this.UpdateBtn.Text = "更新";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // RegistBtn
            // 
            this.RegistBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RegistBtn.Location = new System.Drawing.Point(138, 26);
            this.RegistBtn.Name = "RegistBtn";
            this.RegistBtn.Size = new System.Drawing.Size(300, 90);
            this.RegistBtn.TabIndex = 2;
            this.RegistBtn.Text = "登録";
            this.RegistBtn.UseVisualStyleBackColor = true;
            this.RegistBtn.Click += new System.EventHandler(this.RegistBtn_Click);
            // 
            // TopLogoutBtn
            // 
            this.TopLogoutBtn.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.TopLogoutBtn.Location = new System.Drawing.Point(12, 795);
            this.TopLogoutBtn.Name = "TopLogoutBtn";
            this.TopLogoutBtn.Size = new System.Drawing.Size(210, 146);
            this.TopLogoutBtn.TabIndex = 23;
            this.TopLogoutBtn.Text = "ログアウト";
            this.TopLogoutBtn.UseVisualStyleBackColor = true;
            this.TopLogoutBtn.Click += new System.EventHandler(this.TopLogoutBtn_Click);
            // 
            // TopIDHyojiLbl
            // 
            this.TopIDHyojiLbl.AutoSize = true;
            this.TopIDHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDHyojiLbl.Location = new System.Drawing.Point(898, 28);
            this.TopIDHyojiLbl.Name = "TopIDHyojiLbl";
            this.TopIDHyojiLbl.Size = new System.Drawing.Size(54, 30);
            this.TopIDHyojiLbl.TabIndex = 83;
            this.TopIDHyojiLbl.Text = "ID：";
            // 
            // TopIDLbl
            // 
            this.TopIDLbl.AutoSize = true;
            this.TopIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDLbl.Location = new System.Drawing.Point(953, 28);
            this.TopIDLbl.Name = "TopIDLbl";
            this.TopIDLbl.Size = new System.Drawing.Size(0, 30);
            this.TopIDLbl.TabIndex = 82;
            // 
            // TopEigyoshoLbl
            // 
            this.TopEigyoshoLbl.AutoSize = true;
            this.TopEigyoshoLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoLbl.Location = new System.Drawing.Point(1010, 91);
            this.TopEigyoshoLbl.Name = "TopEigyoshoLbl";
            this.TopEigyoshoLbl.Size = new System.Drawing.Size(0, 30);
            this.TopEigyoshoLbl.TabIndex = 81;
            // 
            // TopEigyoshoHyojiLbl
            // 
            this.TopEigyoshoHyojiLbl.AutoSize = true;
            this.TopEigyoshoHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoHyojiLbl.Location = new System.Drawing.Point(892, 91);
            this.TopEigyoshoHyojiLbl.Name = "TopEigyoshoHyojiLbl";
            this.TopEigyoshoHyojiLbl.Size = new System.Drawing.Size(118, 30);
            this.TopEigyoshoHyojiLbl.TabIndex = 80;
            this.TopEigyoshoHyojiLbl.Text = "営業所：";
            // 
            // TopJikanLbl
            // 
            this.TopJikanLbl.AutoSize = true;
            this.TopJikanLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanLbl.Location = new System.Drawing.Point(1800, 28);
            this.TopJikanLbl.Name = "TopJikanLbl";
            this.TopJikanLbl.Size = new System.Drawing.Size(0, 30);
            this.TopJikanLbl.TabIndex = 79;
            // 
            // TopJikanHyojiLbl
            // 
            this.TopJikanHyojiLbl.AutoSize = true;
            this.TopJikanHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanHyojiLbl.Location = new System.Drawing.Point(1621, 28);
            this.TopJikanHyojiLbl.Name = "TopJikanHyojiLbl";
            this.TopJikanHyojiLbl.Size = new System.Drawing.Size(177, 30);
            this.TopJikanHyojiLbl.TabIndex = 78;
            this.TopJikanHyojiLbl.Text = "ログイン時間：";
            // 
            // TopYakushokuLbl
            // 
            this.TopYakushokuLbl.AutoSize = true;
            this.TopYakushokuLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuLbl.Location = new System.Drawing.Point(1345, 91);
            this.TopYakushokuLbl.Name = "TopYakushokuLbl";
            this.TopYakushokuLbl.Size = new System.Drawing.Size(0, 30);
            this.TopYakushokuLbl.TabIndex = 77;
            // 
            // TopYakushokuHyojiLbl
            // 
            this.TopYakushokuHyojiLbl.AutoSize = true;
            this.TopYakushokuHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuHyojiLbl.Location = new System.Drawing.Point(1264, 91);
            this.TopYakushokuHyojiLbl.Name = "TopYakushokuHyojiLbl";
            this.TopYakushokuHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopYakushokuHyojiLbl.TabIndex = 76;
            this.TopYakushokuHyojiLbl.Text = "役職：";
            // 
            // TopNameLbl
            // 
            this.TopNameLbl.AutoSize = true;
            this.TopNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameLbl.Location = new System.Drawing.Point(1345, 28);
            this.TopNameLbl.Name = "TopNameLbl";
            this.TopNameLbl.Size = new System.Drawing.Size(0, 30);
            this.TopNameLbl.TabIndex = 75;
            // 
            // TopNameHyojiLbl
            // 
            this.TopNameHyojiLbl.AutoSize = true;
            this.TopNameHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameHyojiLbl.Location = new System.Drawing.Point(1264, 28);
            this.TopNameHyojiLbl.Name = "TopNameHyojiLbl";
            this.TopNameHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopNameHyojiLbl.TabIndex = 74;
            this.TopNameHyojiLbl.Text = "名前：";
            // 
            // Shainkanri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.TopIDHyojiLbl);
            this.Controls.Add(this.TopIDLbl);
            this.Controls.Add(this.TopEigyoshoLbl);
            this.Controls.Add(this.TopEigyoshoHyojiLbl);
            this.Controls.Add(this.TopJikanLbl);
            this.Controls.Add(this.TopJikanHyojiLbl);
            this.Controls.Add(this.TopYakushokuLbl);
            this.Controls.Add(this.TopYakushokuHyojiLbl);
            this.Controls.Add(this.TopNameLbl);
            this.Controls.Add(this.TopNameHyojiLbl);
            this.Controls.Add(this.TopLogoutBtn);
            this.Controls.Add(this.TopShainPnl);
            this.Controls.Add(this.TopLbl);
            this.Controls.Add(this.TopButsuryuBtn);
            this.Controls.Add(this.TopEigyoBtn);
            this.Controls.Add(this.TopHonshaBtn);
            this.KeyPreview = true;
            this.Name = "Shainkanri";
            this.Text = "販売在庫管理システム - 本社管理画面 - 社員管理画面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Shainkanri_Load);
            this.TopShainPnl.ResumeLayout(false);
            this.TopShainPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShainKanriDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TopHonshaBtn;
        private System.Windows.Forms.Button TopEigyoBtn;
        private System.Windows.Forms.Button TopButsuryuBtn;
        private System.Windows.Forms.Label TopLbl;
        private System.Windows.Forms.Panel TopShainPnl;
        private System.Windows.Forms.Button TopLogoutBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button HiddenBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.Button RegistBtn;
        private System.Windows.Forms.TextBox ShainNameTxb;
        private System.Windows.Forms.TextBox HihyojiTxb;
        private System.Windows.Forms.TextBox ShainIDTxb;
        private System.Windows.Forms.Label ShainNameLbl;
        private System.Windows.Forms.Label JoinDateLbl;
        private System.Windows.Forms.Label YakushokuNameLbl;
        private System.Windows.Forms.Label HihyojiLbl;
        private System.Windows.Forms.Label ShainKanriFlagLbl;
        private System.Windows.Forms.Label ShainIDLbl;
        private System.Windows.Forms.ComboBox ShainKanriFlagCmb;
        private System.Windows.Forms.ComboBox YakushokuNameTxb;
        private System.Windows.Forms.TextBox TelTxb;
        private System.Windows.Forms.Label TelLbl;
        private System.Windows.Forms.Label EigyoshoNameLbl;
        private System.Windows.Forms.DataGridView ShainKanriDgv;
        private System.Windows.Forms.Button GamenKousinBtn;
        private System.Windows.Forms.DateTimePicker JoinDateDtm;
        private System.Windows.Forms.ComboBox EigyoushoNameCmb;
        private System.Windows.Forms.Label TopIDHyojiLbl;
        private System.Windows.Forms.Label TopIDLbl;
        private System.Windows.Forms.Label TopEigyoshoLbl;
        private System.Windows.Forms.Label TopEigyoshoHyojiLbl;
        private System.Windows.Forms.Label TopJikanLbl;
        private System.Windows.Forms.Label TopJikanHyojiLbl;
        private System.Windows.Forms.Label TopYakushokuLbl;
        private System.Windows.Forms.Label TopYakushokuHyojiLbl;
        private System.Windows.Forms.Label TopNameLbl;
        private System.Windows.Forms.Label TopNameHyojiLbl;
    }
}