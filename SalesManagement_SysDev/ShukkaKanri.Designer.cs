namespace SalesManagement_SysDev
{
    partial class ShukkaKanri
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
            this.TopShukkaPnl = new System.Windows.Forms.Panel();
            this.ShukkaDateDtm = new System.Windows.Forms.DateTimePicker();
            this.ShukkaKanriFlagCmb = new System.Windows.Forms.ComboBox();
            this.ComfirmBtn = new System.Windows.Forms.Button();
            this.GamenKousinBtn = new System.Windows.Forms.Button();
            this.ShukkaKanriDgv = new System.Windows.Forms.DataGridView();
            this.ShukkaJotaiFlagCmb = new System.Windows.Forms.ComboBox();
            this.HiddenBtn = new System.Windows.Forms.Button();
            this.KokyakuIDTxb = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ShukkaIDLbl = new System.Windows.Forms.Label();
            this.EigyoshoNameTxb = new System.Windows.Forms.TextBox();
            this.ShukkaJotaiFlagLbl = new System.Windows.Forms.Label();
            this.ShukkaKanriFlagLbl = new System.Windows.Forms.Label();
            this.HihyojiLbl = new System.Windows.Forms.Label();
            this.SuryoTxb = new System.Windows.Forms.TextBox();
            this.SuryoLbl = new System.Windows.Forms.Label();
            this.ShohinIDTxb = new System.Windows.Forms.TextBox();
            this.ShohinIDLbl = new System.Windows.Forms.Label();
            this.HihyojiTxb = new System.Windows.Forms.TextBox();
            this.ShainIDLbl = new System.Windows.Forms.Label();
            this.ShainIDTxb = new System.Windows.Forms.TextBox();
            this.ShukkaIDTxb = new System.Windows.Forms.TextBox();
            this.EigyoshoNameLbl = new System.Windows.Forms.Label();
            this.KokyakuIDLbl = new System.Windows.Forms.Label();
            this.ShukkaDateLbl = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
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
            this.TopShukkaPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShukkaKanriDgv)).BeginInit();
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
            this.TopLbl.Text = "出荷管理画面";
            // 
            // TopShukkaPnl
            // 
            this.TopShukkaPnl.AutoSize = true;
            this.TopShukkaPnl.BackColor = System.Drawing.Color.LightGray;
            this.TopShukkaPnl.Controls.Add(this.ShukkaDateDtm);
            this.TopShukkaPnl.Controls.Add(this.ShukkaKanriFlagCmb);
            this.TopShukkaPnl.Controls.Add(this.ComfirmBtn);
            this.TopShukkaPnl.Controls.Add(this.GamenKousinBtn);
            this.TopShukkaPnl.Controls.Add(this.ShukkaKanriDgv);
            this.TopShukkaPnl.Controls.Add(this.ShukkaJotaiFlagCmb);
            this.TopShukkaPnl.Controls.Add(this.HiddenBtn);
            this.TopShukkaPnl.Controls.Add(this.KokyakuIDTxb);
            this.TopShukkaPnl.Controls.Add(this.SearchBtn);
            this.TopShukkaPnl.Controls.Add(this.ShukkaIDLbl);
            this.TopShukkaPnl.Controls.Add(this.EigyoshoNameTxb);
            this.TopShukkaPnl.Controls.Add(this.ShukkaJotaiFlagLbl);
            this.TopShukkaPnl.Controls.Add(this.ShukkaKanriFlagLbl);
            this.TopShukkaPnl.Controls.Add(this.HihyojiLbl);
            this.TopShukkaPnl.Controls.Add(this.SuryoTxb);
            this.TopShukkaPnl.Controls.Add(this.SuryoLbl);
            this.TopShukkaPnl.Controls.Add(this.ShohinIDTxb);
            this.TopShukkaPnl.Controls.Add(this.ShohinIDLbl);
            this.TopShukkaPnl.Controls.Add(this.HihyojiTxb);
            this.TopShukkaPnl.Controls.Add(this.ShainIDLbl);
            this.TopShukkaPnl.Controls.Add(this.ShainIDTxb);
            this.TopShukkaPnl.Controls.Add(this.ShukkaIDTxb);
            this.TopShukkaPnl.Controls.Add(this.EigyoshoNameLbl);
            this.TopShukkaPnl.Controls.Add(this.KokyakuIDLbl);
            this.TopShukkaPnl.Controls.Add(this.ShukkaDateLbl);
            this.TopShukkaPnl.Location = new System.Drawing.Point(253, 158);
            this.TopShukkaPnl.Name = "TopShukkaPnl";
            this.TopShukkaPnl.Size = new System.Drawing.Size(1856, 783);
            this.TopShukkaPnl.TabIndex = 23;
            // 
            // ShukkaDateDtm
            // 
            this.ShukkaDateDtm.Location = new System.Drawing.Point(1056, 292);
            this.ShukkaDateDtm.Name = "ShukkaDateDtm";
            this.ShukkaDateDtm.Size = new System.Drawing.Size(200, 25);
            this.ShukkaDateDtm.TabIndex = 58;
            // 
            // ShukkaKanriFlagCmb
            // 
            this.ShukkaKanriFlagCmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShukkaKanriFlagCmb.FormattingEnabled = true;
            this.ShukkaKanriFlagCmb.Location = new System.Drawing.Point(644, 220);
            this.ShukkaKanriFlagCmb.Name = "ShukkaKanriFlagCmb";
            this.ShukkaKanriFlagCmb.Size = new System.Drawing.Size(201, 26);
            this.ShukkaKanriFlagCmb.TabIndex = 57;
            // 
            // ComfirmBtn
            // 
            this.ComfirmBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ComfirmBtn.Location = new System.Drawing.Point(960, 26);
            this.ComfirmBtn.Name = "ComfirmBtn";
            this.ComfirmBtn.Size = new System.Drawing.Size(300, 90);
            this.ComfirmBtn.TabIndex = 56;
            this.ComfirmBtn.Text = "確定";
            this.ComfirmBtn.UseVisualStyleBackColor = true;
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
            // ShukkaKanriDgv
            // 
            this.ShukkaKanriDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShukkaKanriDgv.Location = new System.Drawing.Point(97, 492);
            this.ShukkaKanriDgv.Name = "ShukkaKanriDgv";
            this.ShukkaKanriDgv.RowHeadersWidth = 62;
            this.ShukkaKanriDgv.RowTemplate.Height = 27;
            this.ShukkaKanriDgv.Size = new System.Drawing.Size(1633, 256);
            this.ShukkaKanriDgv.TabIndex = 50;
            // 
            // ShukkaJotaiFlagCmb
            // 
            this.ShukkaJotaiFlagCmb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShukkaJotaiFlagCmb.FormattingEnabled = true;
            this.ShukkaJotaiFlagCmb.Location = new System.Drawing.Point(1055, 220);
            this.ShukkaJotaiFlagCmb.Name = "ShukkaJotaiFlagCmb";
            this.ShukkaJotaiFlagCmb.Size = new System.Drawing.Size(201, 26);
            this.ShukkaJotaiFlagCmb.TabIndex = 49;
            // 
            // HiddenBtn
            // 
            this.HiddenBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HiddenBtn.Location = new System.Drawing.Point(545, 26);
            this.HiddenBtn.Name = "HiddenBtn";
            this.HiddenBtn.Size = new System.Drawing.Size(300, 90);
            this.HiddenBtn.TabIndex = 25;
            this.HiddenBtn.Text = "非表示";
            this.HiddenBtn.UseVisualStyleBackColor = true;
            // 
            // KokyakuIDTxb
            // 
            this.KokyakuIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KokyakuIDTxb.Location = new System.Drawing.Point(1052, 150);
            this.KokyakuIDTxb.Name = "KokyakuIDTxb";
            this.KokyakuIDTxb.Size = new System.Drawing.Size(201, 25);
            this.KokyakuIDTxb.TabIndex = 48;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchBtn.Location = new System.Drawing.Point(138, 26);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(300, 90);
            this.SearchBtn.TabIndex = 26;
            this.SearchBtn.Text = "検索";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // ShukkaIDLbl
            // 
            this.ShukkaIDLbl.AutoSize = true;
            this.ShukkaIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShukkaIDLbl.Location = new System.Drawing.Point(123, 150);
            this.ShukkaIDLbl.Name = "ShukkaIDLbl";
            this.ShukkaIDLbl.Size = new System.Drawing.Size(93, 28);
            this.ShukkaIDLbl.TabIndex = 28;
            this.ShukkaIDLbl.Text = "出荷ID";
            // 
            // EigyoshoNameTxb
            // 
            this.EigyoshoNameTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EigyoshoNameTxb.Location = new System.Drawing.Point(642, 150);
            this.EigyoshoNameTxb.Name = "EigyoshoNameTxb";
            this.EigyoshoNameTxb.Size = new System.Drawing.Size(201, 25);
            this.EigyoshoNameTxb.TabIndex = 46;
            // 
            // ShukkaJotaiFlagLbl
            // 
            this.ShukkaJotaiFlagLbl.AutoSize = true;
            this.ShukkaJotaiFlagLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShukkaJotaiFlagLbl.Location = new System.Drawing.Point(865, 220);
            this.ShukkaJotaiFlagLbl.Name = "ShukkaJotaiFlagLbl";
            this.ShukkaJotaiFlagLbl.Size = new System.Drawing.Size(184, 28);
            this.ShukkaJotaiFlagLbl.TabIndex = 29;
            this.ShukkaJotaiFlagLbl.Text = "出荷状態フラグ";
            // 
            // ShukkaKanriFlagLbl
            // 
            this.ShukkaKanriFlagLbl.AutoSize = true;
            this.ShukkaKanriFlagLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShukkaKanriFlagLbl.Location = new System.Drawing.Point(444, 220);
            this.ShukkaKanriFlagLbl.Name = "ShukkaKanriFlagLbl";
            this.ShukkaKanriFlagLbl.Size = new System.Drawing.Size(184, 28);
            this.ShukkaKanriFlagLbl.TabIndex = 29;
            this.ShukkaKanriFlagLbl.Text = "出荷管理フラグ";
            // 
            // HihyojiLbl
            // 
            this.HihyojiLbl.AutoSize = true;
            this.HihyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HihyojiLbl.Location = new System.Drawing.Point(61, 360);
            this.HihyojiLbl.Name = "HihyojiLbl";
            this.HihyojiLbl.Size = new System.Drawing.Size(152, 28);
            this.HihyojiLbl.TabIndex = 30;
            this.HihyojiLbl.Text = "非表示理由";
            // 
            // SuryoTxb
            // 
            this.SuryoTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuryoTxb.Location = new System.Drawing.Point(644, 294);
            this.SuryoTxb.Name = "SuryoTxb";
            this.SuryoTxb.Size = new System.Drawing.Size(201, 25);
            this.SuryoTxb.TabIndex = 44;
            // 
            // SuryoLbl
            // 
            this.SuryoLbl.AutoSize = true;
            this.SuryoLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SuryoLbl.Location = new System.Drawing.Point(560, 291);
            this.SuryoLbl.Name = "SuryoLbl";
            this.SuryoLbl.Size = new System.Drawing.Size(68, 28);
            this.SuryoLbl.TabIndex = 31;
            this.SuryoLbl.Text = "数量";
            // 
            // ShohinIDTxb
            // 
            this.ShohinIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShohinIDTxb.Location = new System.Drawing.Point(237, 294);
            this.ShohinIDTxb.Name = "ShohinIDTxb";
            this.ShohinIDTxb.Size = new System.Drawing.Size(201, 25);
            this.ShohinIDTxb.TabIndex = 44;
            // 
            // ShohinIDLbl
            // 
            this.ShohinIDLbl.AutoSize = true;
            this.ShohinIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShohinIDLbl.Location = new System.Drawing.Point(123, 291);
            this.ShohinIDLbl.Name = "ShohinIDLbl";
            this.ShohinIDLbl.Size = new System.Drawing.Size(93, 28);
            this.ShohinIDLbl.TabIndex = 31;
            this.ShohinIDLbl.Text = "商品ID";
            // 
            // HihyojiTxb
            // 
            this.HihyojiTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HihyojiTxb.Location = new System.Drawing.Point(237, 360);
            this.HihyojiTxb.Multiline = true;
            this.HihyojiTxb.Name = "HihyojiTxb";
            this.HihyojiTxb.Size = new System.Drawing.Size(609, 90);
            this.HihyojiTxb.TabIndex = 43;
            // 
            // ShainIDLbl
            // 
            this.ShainIDLbl.AutoSize = true;
            this.ShainIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShainIDLbl.Location = new System.Drawing.Point(123, 220);
            this.ShainIDLbl.Name = "ShainIDLbl";
            this.ShainIDLbl.Size = new System.Drawing.Size(93, 28);
            this.ShainIDLbl.TabIndex = 33;
            this.ShainIDLbl.Text = "社員ID";
            // 
            // ShainIDTxb
            // 
            this.ShainIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShainIDTxb.Location = new System.Drawing.Point(237, 220);
            this.ShainIDTxb.Name = "ShainIDTxb";
            this.ShainIDTxb.Size = new System.Drawing.Size(201, 25);
            this.ShainIDTxb.TabIndex = 41;
            this.ShainIDTxb.UseWaitCursor = true;
            // 
            // ShukkaIDTxb
            // 
            this.ShukkaIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShukkaIDTxb.Location = new System.Drawing.Point(237, 150);
            this.ShukkaIDTxb.Name = "ShukkaIDTxb";
            this.ShukkaIDTxb.Size = new System.Drawing.Size(201, 25);
            this.ShukkaIDTxb.TabIndex = 40;
            // 
            // EigyoshoNameLbl
            // 
            this.EigyoshoNameLbl.AutoSize = true;
            this.EigyoshoNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EigyoshoNameLbl.Location = new System.Drawing.Point(504, 150);
            this.EigyoshoNameLbl.Name = "EigyoshoNameLbl";
            this.EigyoshoNameLbl.Size = new System.Drawing.Size(124, 28);
            this.EigyoshoNameLbl.TabIndex = 35;
            this.EigyoshoNameLbl.Text = "営業所名";
            // 
            // KokyakuIDLbl
            // 
            this.KokyakuIDLbl.AutoSize = true;
            this.KokyakuIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KokyakuIDLbl.Location = new System.Drawing.Point(938, 150);
            this.KokyakuIDLbl.Name = "KokyakuIDLbl";
            this.KokyakuIDLbl.Size = new System.Drawing.Size(93, 28);
            this.KokyakuIDLbl.TabIndex = 38;
            this.KokyakuIDLbl.Text = "顧客ID";
            // 
            // ShukkaDateLbl
            // 
            this.ShukkaDateLbl.AutoSize = true;
            this.ShukkaDateLbl.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.ShukkaDateLbl.Location = new System.Drawing.Point(855, 294);
            this.ShukkaDateLbl.Name = "ShukkaDateLbl";
            this.ShukkaDateLbl.Size = new System.Drawing.Size(194, 26);
            this.ShukkaDateLbl.TabIndex = 37;
            this.ShukkaDateLbl.Text = "出荷完了年月日";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.button15.Location = new System.Drawing.Point(12, 795);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(210, 146);
            this.button15.TabIndex = 23;
            this.button15.Text = "ログアウト";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // TopIDHyojiLbl
            // 
            this.TopIDHyojiLbl.AutoSize = true;
            this.TopIDHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDHyojiLbl.Location = new System.Drawing.Point(898, 28);
            this.TopIDHyojiLbl.Name = "TopIDHyojiLbl";
            this.TopIDHyojiLbl.Size = new System.Drawing.Size(54, 30);
            this.TopIDHyojiLbl.TabIndex = 73;
            this.TopIDHyojiLbl.Text = "ID：";
            // 
            // TopIDLbl
            // 
            this.TopIDLbl.AutoSize = true;
            this.TopIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDLbl.Location = new System.Drawing.Point(953, 28);
            this.TopIDLbl.Name = "TopIDLbl";
            this.TopIDLbl.Size = new System.Drawing.Size(0, 30);
            this.TopIDLbl.TabIndex = 72;
            // 
            // TopEigyoshoLbl
            // 
            this.TopEigyoshoLbl.AutoSize = true;
            this.TopEigyoshoLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoLbl.Location = new System.Drawing.Point(1010, 91);
            this.TopEigyoshoLbl.Name = "TopEigyoshoLbl";
            this.TopEigyoshoLbl.Size = new System.Drawing.Size(0, 30);
            this.TopEigyoshoLbl.TabIndex = 71;
            // 
            // TopEigyoshoHyojiLbl
            // 
            this.TopEigyoshoHyojiLbl.AutoSize = true;
            this.TopEigyoshoHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoHyojiLbl.Location = new System.Drawing.Point(892, 91);
            this.TopEigyoshoHyojiLbl.Name = "TopEigyoshoHyojiLbl";
            this.TopEigyoshoHyojiLbl.Size = new System.Drawing.Size(118, 30);
            this.TopEigyoshoHyojiLbl.TabIndex = 70;
            this.TopEigyoshoHyojiLbl.Text = "営業所：";
            // 
            // TopJikanLbl
            // 
            this.TopJikanLbl.AutoSize = true;
            this.TopJikanLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanLbl.Location = new System.Drawing.Point(1800, 28);
            this.TopJikanLbl.Name = "TopJikanLbl";
            this.TopJikanLbl.Size = new System.Drawing.Size(0, 30);
            this.TopJikanLbl.TabIndex = 69;
            // 
            // TopJikanHyojiLbl
            // 
            this.TopJikanHyojiLbl.AutoSize = true;
            this.TopJikanHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanHyojiLbl.Location = new System.Drawing.Point(1621, 28);
            this.TopJikanHyojiLbl.Name = "TopJikanHyojiLbl";
            this.TopJikanHyojiLbl.Size = new System.Drawing.Size(177, 30);
            this.TopJikanHyojiLbl.TabIndex = 68;
            this.TopJikanHyojiLbl.Text = "ログイン時間：";
            // 
            // TopYakushokuLbl
            // 
            this.TopYakushokuLbl.AutoSize = true;
            this.TopYakushokuLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuLbl.Location = new System.Drawing.Point(1345, 91);
            this.TopYakushokuLbl.Name = "TopYakushokuLbl";
            this.TopYakushokuLbl.Size = new System.Drawing.Size(0, 30);
            this.TopYakushokuLbl.TabIndex = 67;
            // 
            // TopYakushokuHyojiLbl
            // 
            this.TopYakushokuHyojiLbl.AutoSize = true;
            this.TopYakushokuHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuHyojiLbl.Location = new System.Drawing.Point(1264, 91);
            this.TopYakushokuHyojiLbl.Name = "TopYakushokuHyojiLbl";
            this.TopYakushokuHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopYakushokuHyojiLbl.TabIndex = 66;
            this.TopYakushokuHyojiLbl.Text = "役職：";
            // 
            // TopNameLbl
            // 
            this.TopNameLbl.AutoSize = true;
            this.TopNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameLbl.Location = new System.Drawing.Point(1345, 28);
            this.TopNameLbl.Name = "TopNameLbl";
            this.TopNameLbl.Size = new System.Drawing.Size(0, 30);
            this.TopNameLbl.TabIndex = 65;
            // 
            // TopNameHyojiLbl
            // 
            this.TopNameHyojiLbl.AutoSize = true;
            this.TopNameHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameHyojiLbl.Location = new System.Drawing.Point(1264, 28);
            this.TopNameHyojiLbl.Name = "TopNameHyojiLbl";
            this.TopNameHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopNameHyojiLbl.TabIndex = 64;
            this.TopNameHyojiLbl.Text = "名前：";
            // 
            // ShukkaKanri
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
            this.Controls.Add(this.button15);
            this.Controls.Add(this.TopShukkaPnl);
            this.Controls.Add(this.TopLbl);
            this.Controls.Add(this.TopButsuryuBtn);
            this.Controls.Add(this.TopEigyoBtn);
            this.Controls.Add(this.TopHonshaBtn);
            this.KeyPreview = true;
            this.Name = "ShukkaKanri";
            this.Text = "販売在庫管理システム - 営業管理画面 - 出荷管理画面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopShukkaPnl.ResumeLayout(false);
            this.TopShukkaPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShukkaKanriDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TopHonshaBtn;
        private System.Windows.Forms.Button TopEigyoBtn;
        private System.Windows.Forms.Button TopButsuryuBtn;
        private System.Windows.Forms.Label TopLbl;
        private System.Windows.Forms.Panel TopShukkaPnl;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button HiddenBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label ShukkaIDLbl;
        private System.Windows.Forms.TextBox EigyoshoNameTxb;
        private System.Windows.Forms.Label ShukkaKanriFlagLbl;
        private System.Windows.Forms.Label HihyojiLbl;
        private System.Windows.Forms.TextBox ShohinIDTxb;
        private System.Windows.Forms.Label ShohinIDLbl;
        private System.Windows.Forms.TextBox HihyojiTxb;
        private System.Windows.Forms.Label ShainIDLbl;
        private System.Windows.Forms.TextBox ShainIDTxb;
        private System.Windows.Forms.TextBox ShukkaIDTxb;
        private System.Windows.Forms.Label EigyoshoNameLbl;
        private System.Windows.Forms.Label KokyakuIDLbl;
        private System.Windows.Forms.Label ShukkaDateLbl;
        private System.Windows.Forms.Label ShukkaJotaiFlagLbl;
        private System.Windows.Forms.ComboBox ShukkaJotaiFlagCmb;
        private System.Windows.Forms.DataGridView ShukkaKanriDgv;
        private System.Windows.Forms.Button GamenKousinBtn;
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
        private System.Windows.Forms.Button ComfirmBtn;
        private System.Windows.Forms.ComboBox ShukkaKanriFlagCmb;
        private System.Windows.Forms.DateTimePicker ShukkaDateDtm;
        private System.Windows.Forms.TextBox KokyakuIDTxb;
        private System.Windows.Forms.TextBox SuryoTxb;
        private System.Windows.Forms.Label SuryoLbl;
    }
}