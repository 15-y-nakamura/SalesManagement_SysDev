namespace SalesManagement_SysDev
{
    partial class ZaikoKanri
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
            this.TopZaikoPnl = new System.Windows.Forms.Panel();
            this.ZaikoKanriFlagCmb = new System.Windows.Forms.ComboBox();
            this.GamenKousinBtn = new System.Windows.Forms.Button();
            this.ZaikoKanriDgv = new System.Windows.Forms.DataGridView();
            this.MakerIDTxb = new System.Windows.Forms.TextBox();
            this.ShohinNameTxb = new System.Windows.Forms.TextBox();
            this.AnzenTxb = new System.Windows.Forms.TextBox();
            this.SuryoTxb = new System.Windows.Forms.TextBox();
            this.HihyojiTxb = new System.Windows.Forms.TextBox();
            this.ZaikoSuTxb = new System.Windows.Forms.TextBox();
            this.ZaikoIDTxb = new System.Windows.Forms.TextBox();
            this.MakerIDLbl = new System.Windows.Forms.Label();
            this.ShohinNameLbl = new System.Windows.Forms.Label();
            this.JuchuDateLbl = new System.Windows.Forms.Label();
            this.AnzenLbl = new System.Windows.Forms.Label();
            this.ZaikoSuLbl = new System.Windows.Forms.Label();
            this.HihyojiLbl = new System.Windows.Forms.Label();
            this.ZaikoKanriFlagLbl = new System.Windows.Forms.Label();
            this.ZaikoIDLbl = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.HiddenBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
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
            this.TopZaikoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZaikoKanriDgv)).BeginInit();
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
            this.TopHonshaBtn.TabStop = false;
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
            this.TopEigyoBtn.TabStop = false;
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
            this.TopButsuryuBtn.TabStop = false;
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
            this.TopLbl.Text = "在庫管理画面";
            // 
            // TopZaikoPnl
            // 
            this.TopZaikoPnl.BackColor = System.Drawing.Color.LightGray;
            this.TopZaikoPnl.Controls.Add(this.ZaikoKanriFlagCmb);
            this.TopZaikoPnl.Controls.Add(this.GamenKousinBtn);
            this.TopZaikoPnl.Controls.Add(this.ZaikoKanriDgv);
            this.TopZaikoPnl.Controls.Add(this.MakerIDTxb);
            this.TopZaikoPnl.Controls.Add(this.ShohinNameTxb);
            this.TopZaikoPnl.Controls.Add(this.AnzenTxb);
            this.TopZaikoPnl.Controls.Add(this.SuryoTxb);
            this.TopZaikoPnl.Controls.Add(this.HihyojiTxb);
            this.TopZaikoPnl.Controls.Add(this.ZaikoSuTxb);
            this.TopZaikoPnl.Controls.Add(this.ZaikoIDTxb);
            this.TopZaikoPnl.Controls.Add(this.MakerIDLbl);
            this.TopZaikoPnl.Controls.Add(this.ShohinNameLbl);
            this.TopZaikoPnl.Controls.Add(this.JuchuDateLbl);
            this.TopZaikoPnl.Controls.Add(this.AnzenLbl);
            this.TopZaikoPnl.Controls.Add(this.ZaikoSuLbl);
            this.TopZaikoPnl.Controls.Add(this.HihyojiLbl);
            this.TopZaikoPnl.Controls.Add(this.ZaikoKanriFlagLbl);
            this.TopZaikoPnl.Controls.Add(this.ZaikoIDLbl);
            this.TopZaikoPnl.Controls.Add(this.SearchBtn);
            this.TopZaikoPnl.Controls.Add(this.HiddenBtn);
            this.TopZaikoPnl.Controls.Add(this.UpdateBtn);
            this.TopZaikoPnl.Location = new System.Drawing.Point(253, 158);
            this.TopZaikoPnl.Name = "TopZaikoPnl";
            this.TopZaikoPnl.Size = new System.Drawing.Size(1835, 783);
            this.TopZaikoPnl.TabIndex = 23;
            // 
            // ZaikoKanriFlagCmb
            // 
            this.ZaikoKanriFlagCmb.FormattingEnabled = true;
            this.ZaikoKanriFlagCmb.Location = new System.Drawing.Point(237, 290);
            this.ZaikoKanriFlagCmb.Name = "ZaikoKanriFlagCmb";
            this.ZaikoKanriFlagCmb.Size = new System.Drawing.Size(203, 26);
            this.ZaikoKanriFlagCmb.TabIndex = 6;
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
            this.GamenKousinBtn.TabStop = false;
            this.GamenKousinBtn.UseVisualStyleBackColor = true;
            // 
            // ZaikoKanriDgv
            // 
            this.ZaikoKanriDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ZaikoKanriDgv.Location = new System.Drawing.Point(97, 492);
            this.ZaikoKanriDgv.Name = "ZaikoKanriDgv";
            this.ZaikoKanriDgv.RowHeadersWidth = 62;
            this.ZaikoKanriDgv.RowTemplate.Height = 27;
            this.ZaikoKanriDgv.Size = new System.Drawing.Size(1633, 256);
            this.ZaikoKanriDgv.TabIndex = 51;
            this.ZaikoKanriDgv.TabStop = false;
            // 
            // MakerIDTxb
            // 
            this.MakerIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MakerIDTxb.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.MakerIDTxb.Location = new System.Drawing.Point(1432, 150);
            this.MakerIDTxb.Name = "MakerIDTxb";
            this.MakerIDTxb.Size = new System.Drawing.Size(201, 25);
            this.MakerIDTxb.TabIndex = 3;
            // 
            // ShohinNameTxb
            // 
            this.ShohinNameTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShohinNameTxb.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ShohinNameTxb.Location = new System.Drawing.Point(1059, 150);
            this.ShohinNameTxb.Name = "ShohinNameTxb";
            this.ShohinNameTxb.Size = new System.Drawing.Size(201, 25);
            this.ShohinNameTxb.TabIndex = 2;
            // 
            // AnzenTxb
            // 
            this.AnzenTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnzenTxb.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.AnzenTxb.Location = new System.Drawing.Point(642, 219);
            this.AnzenTxb.Name = "AnzenTxb";
            this.AnzenTxb.Size = new System.Drawing.Size(201, 25);
            this.AnzenTxb.TabIndex = 5;
            // 
            // SuryoTxb
            // 
            this.SuryoTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuryoTxb.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.SuryoTxb.Location = new System.Drawing.Point(642, 150);
            this.SuryoTxb.Name = "SuryoTxb";
            this.SuryoTxb.Size = new System.Drawing.Size(201, 25);
            this.SuryoTxb.TabIndex = 1;
            // 
            // HihyojiTxb
            // 
            this.HihyojiTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HihyojiTxb.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.HihyojiTxb.Location = new System.Drawing.Point(237, 364);
            this.HihyojiTxb.Multiline = true;
            this.HihyojiTxb.Name = "HihyojiTxb";
            this.HihyojiTxb.Size = new System.Drawing.Size(606, 90);
            this.HihyojiTxb.TabIndex = 7;
            // 
            // ZaikoSuTxb
            // 
            this.ZaikoSuTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZaikoSuTxb.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.ZaikoSuTxb.Location = new System.Drawing.Point(237, 220);
            this.ZaikoSuTxb.Name = "ZaikoSuTxb";
            this.ZaikoSuTxb.Size = new System.Drawing.Size(201, 25);
            this.ZaikoSuTxb.TabIndex = 4;
            // 
            // ZaikoIDTxb
            // 
            this.ZaikoIDTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZaikoIDTxb.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.ZaikoIDTxb.Location = new System.Drawing.Point(237, 150);
            this.ZaikoIDTxb.Name = "ZaikoIDTxb";
            this.ZaikoIDTxb.Size = new System.Drawing.Size(201, 25);
            this.ZaikoIDTxb.TabIndex = 0;
            // 
            // MakerIDLbl
            // 
            this.MakerIDLbl.AutoSize = true;
            this.MakerIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MakerIDLbl.Location = new System.Drawing.Point(1313, 147);
            this.MakerIDLbl.Name = "MakerIDLbl";
            this.MakerIDLbl.Size = new System.Drawing.Size(99, 28);
            this.MakerIDLbl.TabIndex = 2;
            this.MakerIDLbl.Text = "メーカID";
            // 
            // ShohinNameLbl
            // 
            this.ShohinNameLbl.AutoSize = true;
            this.ShohinNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShohinNameLbl.Location = new System.Drawing.Point(933, 150);
            this.ShohinNameLbl.Name = "ShohinNameLbl";
            this.ShohinNameLbl.Size = new System.Drawing.Size(96, 28);
            this.ShohinNameLbl.TabIndex = 2;
            this.ShohinNameLbl.Text = "商品名";
            // 
            // JuchuDateLbl
            // 
            this.JuchuDateLbl.AutoSize = true;
            this.JuchuDateLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.JuchuDateLbl.Location = new System.Drawing.Point(528, 150);
            this.JuchuDateLbl.Name = "JuchuDateLbl";
            this.JuchuDateLbl.Size = new System.Drawing.Size(93, 28);
            this.JuchuDateLbl.TabIndex = 2;
            this.JuchuDateLbl.Text = "商品ID";
            // 
            // AnzenLbl
            // 
            this.AnzenLbl.AutoSize = true;
            this.AnzenLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AnzenLbl.Location = new System.Drawing.Point(469, 220);
            this.AnzenLbl.Name = "AnzenLbl";
            this.AnzenLbl.Size = new System.Drawing.Size(152, 28);
            this.AnzenLbl.TabIndex = 2;
            this.AnzenLbl.Text = "安全在庫数";
            // 
            // ZaikoSuLbl
            // 
            this.ZaikoSuLbl.AutoSize = true;
            this.ZaikoSuLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZaikoSuLbl.Location = new System.Drawing.Point(114, 220);
            this.ZaikoSuLbl.Name = "ZaikoSuLbl";
            this.ZaikoSuLbl.Size = new System.Drawing.Size(96, 28);
            this.ZaikoSuLbl.TabIndex = 2;
            this.ZaikoSuLbl.Text = "在庫数";
            // 
            // HihyojiLbl
            // 
            this.HihyojiLbl.AutoSize = true;
            this.HihyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HihyojiLbl.Location = new System.Drawing.Point(58, 364);
            this.HihyojiLbl.Name = "HihyojiLbl";
            this.HihyojiLbl.Size = new System.Drawing.Size(152, 28);
            this.HihyojiLbl.TabIndex = 2;
            this.HihyojiLbl.Text = "非表示理由";
            // 
            // ZaikoKanriFlagLbl
            // 
            this.ZaikoKanriFlagLbl.AutoSize = true;
            this.ZaikoKanriFlagLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZaikoKanriFlagLbl.Location = new System.Drawing.Point(26, 290);
            this.ZaikoKanriFlagLbl.Name = "ZaikoKanriFlagLbl";
            this.ZaikoKanriFlagLbl.Size = new System.Drawing.Size(184, 28);
            this.ZaikoKanriFlagLbl.TabIndex = 2;
            this.ZaikoKanriFlagLbl.Text = "在庫管理フラグ";
            // 
            // ZaikoIDLbl
            // 
            this.ZaikoIDLbl.AutoSize = true;
            this.ZaikoIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZaikoIDLbl.Location = new System.Drawing.Point(117, 150);
            this.ZaikoIDLbl.Name = "ZaikoIDLbl";
            this.ZaikoIDLbl.Size = new System.Drawing.Size(93, 28);
            this.ZaikoIDLbl.TabIndex = 2;
            this.ZaikoIDLbl.Text = "在庫ID";
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SearchBtn.Location = new System.Drawing.Point(960, 26);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(300, 90);
            this.SearchBtn.TabIndex = 1;
            this.SearchBtn.TabStop = false;
            this.SearchBtn.Text = "検索";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // HiddenBtn
            // 
            this.HiddenBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HiddenBtn.Location = new System.Drawing.Point(545, 26);
            this.HiddenBtn.Name = "HiddenBtn";
            this.HiddenBtn.Size = new System.Drawing.Size(300, 90);
            this.HiddenBtn.TabIndex = 1;
            this.HiddenBtn.TabStop = false;
            this.HiddenBtn.Text = "非表示";
            this.HiddenBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UpdateBtn.Location = new System.Drawing.Point(138, 26);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(300, 90);
            this.UpdateBtn.TabIndex = 1;
            this.UpdateBtn.TabStop = false;
            this.UpdateBtn.Text = "更新";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("MS UI Gothic", 20F);
            this.button15.Location = new System.Drawing.Point(12, 795);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(210, 146);
            this.button15.TabIndex = 23;
            this.button15.TabStop = false;
            this.button15.Text = "ログアウト";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // TopIDHyojiLbl
            // 
            this.TopIDHyojiLbl.AutoSize = true;
            this.TopIDHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDHyojiLbl.Location = new System.Drawing.Point(898, 28);
            this.TopIDHyojiLbl.Name = "TopIDHyojiLbl";
            this.TopIDHyojiLbl.Size = new System.Drawing.Size(54, 30);
            this.TopIDHyojiLbl.TabIndex = 63;
            this.TopIDHyojiLbl.Text = "ID：";
            // 
            // TopIDLbl
            // 
            this.TopIDLbl.AutoSize = true;
            this.TopIDLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopIDLbl.Location = new System.Drawing.Point(953, 28);
            this.TopIDLbl.Name = "TopIDLbl";
            this.TopIDLbl.Size = new System.Drawing.Size(0, 30);
            this.TopIDLbl.TabIndex = 62;
            // 
            // TopEigyoshoLbl
            // 
            this.TopEigyoshoLbl.AutoSize = true;
            this.TopEigyoshoLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoLbl.Location = new System.Drawing.Point(1010, 91);
            this.TopEigyoshoLbl.Name = "TopEigyoshoLbl";
            this.TopEigyoshoLbl.Size = new System.Drawing.Size(0, 30);
            this.TopEigyoshoLbl.TabIndex = 61;
            // 
            // TopEigyoshoHyojiLbl
            // 
            this.TopEigyoshoHyojiLbl.AutoSize = true;
            this.TopEigyoshoHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopEigyoshoHyojiLbl.Location = new System.Drawing.Point(892, 91);
            this.TopEigyoshoHyojiLbl.Name = "TopEigyoshoHyojiLbl";
            this.TopEigyoshoHyojiLbl.Size = new System.Drawing.Size(118, 30);
            this.TopEigyoshoHyojiLbl.TabIndex = 60;
            this.TopEigyoshoHyojiLbl.Text = "営業所：";
            // 
            // TopJikanLbl
            // 
            this.TopJikanLbl.AutoSize = true;
            this.TopJikanLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanLbl.Location = new System.Drawing.Point(1800, 28);
            this.TopJikanLbl.Name = "TopJikanLbl";
            this.TopJikanLbl.Size = new System.Drawing.Size(0, 30);
            this.TopJikanLbl.TabIndex = 59;
            // 
            // TopJikanHyojiLbl
            // 
            this.TopJikanHyojiLbl.AutoSize = true;
            this.TopJikanHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopJikanHyojiLbl.Location = new System.Drawing.Point(1621, 28);
            this.TopJikanHyojiLbl.Name = "TopJikanHyojiLbl";
            this.TopJikanHyojiLbl.Size = new System.Drawing.Size(177, 30);
            this.TopJikanHyojiLbl.TabIndex = 58;
            this.TopJikanHyojiLbl.Text = "ログイン時間：";
            // 
            // TopYakushokuLbl
            // 
            this.TopYakushokuLbl.AutoSize = true;
            this.TopYakushokuLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuLbl.Location = new System.Drawing.Point(1345, 91);
            this.TopYakushokuLbl.Name = "TopYakushokuLbl";
            this.TopYakushokuLbl.Size = new System.Drawing.Size(0, 30);
            this.TopYakushokuLbl.TabIndex = 57;
            // 
            // TopYakushokuHyojiLbl
            // 
            this.TopYakushokuHyojiLbl.AutoSize = true;
            this.TopYakushokuHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopYakushokuHyojiLbl.Location = new System.Drawing.Point(1264, 91);
            this.TopYakushokuHyojiLbl.Name = "TopYakushokuHyojiLbl";
            this.TopYakushokuHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopYakushokuHyojiLbl.TabIndex = 56;
            this.TopYakushokuHyojiLbl.Text = "役職：";
            // 
            // TopNameLbl
            // 
            this.TopNameLbl.AutoSize = true;
            this.TopNameLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameLbl.Location = new System.Drawing.Point(1345, 28);
            this.TopNameLbl.Name = "TopNameLbl";
            this.TopNameLbl.Size = new System.Drawing.Size(0, 30);
            this.TopNameLbl.TabIndex = 55;
            // 
            // TopNameHyojiLbl
            // 
            this.TopNameHyojiLbl.AutoSize = true;
            this.TopNameHyojiLbl.Font = new System.Drawing.Font("MS UI Gothic", 15F);
            this.TopNameHyojiLbl.Location = new System.Drawing.Point(1264, 28);
            this.TopNameHyojiLbl.Name = "TopNameHyojiLbl";
            this.TopNameHyojiLbl.Size = new System.Drawing.Size(88, 30);
            this.TopNameHyojiLbl.TabIndex = 54;
            this.TopNameHyojiLbl.Text = "名前：";
            // 
            // ZaikoKanri
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
            this.Controls.Add(this.TopZaikoPnl);
            this.Controls.Add(this.TopLbl);
            this.Controls.Add(this.TopButsuryuBtn);
            this.Controls.Add(this.TopEigyoBtn);
            this.Controls.Add(this.TopHonshaBtn);
            this.KeyPreview = true;
            this.Name = "ZaikoKanri";
            this.Text = "販売在庫管理システム - 物流管理画面 - 在庫管理画面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JuchuKanri_Load);
            this.TopZaikoPnl.ResumeLayout(false);
            this.TopZaikoPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZaikoKanriDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TopHonshaBtn;
        private System.Windows.Forms.Button TopEigyoBtn;
        private System.Windows.Forms.Button TopButsuryuBtn;
        private System.Windows.Forms.Label TopLbl;
        private System.Windows.Forms.Panel TopZaikoPnl;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button HiddenBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.TextBox ZaikoIDTxb;
        private System.Windows.Forms.Label ShohinNameLbl;
        private System.Windows.Forms.Label ZaikoIDLbl;
        private System.Windows.Forms.TextBox MakerIDTxb;
        private System.Windows.Forms.TextBox ShohinNameTxb;
        private System.Windows.Forms.TextBox ZaikoSuTxb;
        private System.Windows.Forms.Label MakerIDLbl;
        private System.Windows.Forms.Label ZaikoSuLbl;
        private System.Windows.Forms.Label ZaikoKanriFlagLbl;
        private System.Windows.Forms.TextBox SuryoTxb;
        private System.Windows.Forms.TextBox AnzenTxb;
        private System.Windows.Forms.TextBox HihyojiTxb;
        private System.Windows.Forms.Label HihyojiLbl;
        private System.Windows.Forms.DataGridView ZaikoKanriDgv;
        private System.Windows.Forms.Button GamenKousinBtn;
        private System.Windows.Forms.ComboBox ZaikoKanriFlagCmb;
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
        private System.Windows.Forms.Label JuchuDateLbl;
        private System.Windows.Forms.Label AnzenLbl;
    }
}