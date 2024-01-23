using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalesManagement_SysDev
{
    public partial class ShohinKanri : Form
    {
        //商品テーブルのインスタンス化
        ProductDataAccess ProductDA = new ProductDataAccess();

        //大分類テーブルのインスタンス化
        MajorClassificationDataAccess MajorClassificationDA = new MajorClassificationDataAccess();

        //小分類テーブルのインスタンス化
        SmallClassificationDataAccess SmallClassificationDA = new SmallClassificationDataAccess();

        //メーカテーブルのインスタンス化
        MakerDataAccess MakerDA = new MakerDataAccess();

        //データグリッドビュー用のスタッフデータ
        private static List<M_ProductDsp> Productdsp;

        MessageDsp MessageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck InputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;
        internal static string Logindate = "";

        int ClickFlg = -1;

        public ShohinKanri()
        {

            InitializeComponent();
        }

        private void ShohinKanri_Load(object sender, EventArgs e)
        {
            string[] TopData = new string[4];
            TopData = empDataAccess.GetTopData(EmID);

            string emID = EmID.ToString();
            string logindate = Logindate;

            TopIDLbl.Text = emID;
            TopNameLbl.Text = TopData[0];
            TopYakushokuLbl.Text = TopData[1];
            TopEigyoshoLbl.Text = TopData[2];
            TopJikanLbl.Text = logindate;

            if (PoID == 3)
            {
                TopHonshaBtn.Enabled = false;
                TopHonshaBtn.BackColor = Color.DarkGray;
                TopHonshaBtn.FlatAppearance.BorderSize = 2;
                TopHonshaBtn.FlatAppearance.BorderColor = Color.Black;

                TopEigyoBtn.Enabled = false;
                TopEigyoBtn.BackColor = Color.DarkGray;
                TopEigyoBtn.FlatAppearance.BorderSize = 2;
                TopEigyoBtn.FlatAppearance.BorderColor = Color.Black;

                TopButsuryuBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
                TopButsuryuBtn.FlatAppearance.BorderSize = 2;
                TopButsuryuBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            }
            else if (PoID == 1)
            {

                TopHonshaBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
                TopHonshaBtn.FlatAppearance.BorderSize = 2;
                TopHonshaBtn.FlatAppearance.BorderColor = Color.SteelBlue;

                TopEigyoBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
                TopEigyoBtn.FlatAppearance.BorderSize = 2;
                TopEigyoBtn.FlatAppearance.BorderColor = Color.SteelBlue;

                TopButsuryuBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
                TopButsuryuBtn.FlatAppearance.BorderSize = 2;
                TopButsuryuBtn.FlatAppearance.BorderColor = Color.SteelBlue;
            }

            //コントロールの初期設定
            SetCtrlFormat();

            //データグリッドビューの設定
            SetFormShohinKanriGridView();
        }

        ///////////////////////////////
        //メソッド名：SetCtrlFormat()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コントロールの初期設定
        ///////////////////////////////
        private void SetCtrlFormat()
        {
            ShohinIDTxb.Text = "";
            ShohinNameTxb.Text = "";
            MakerNameCmb.Items.Clear();
            MakerNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            KakakuTxb.Text = "";
            AnzenTxb.Text = "";
            DaibunruiCmb.Items.Clear();
            DaibunruiCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShoubunruiCmb.Items.Clear();
            ShoubunruiCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            KatabanTxb.Text = "";
            IroTxb.Text = "";
            SellDtm.Checked = false;
            HihyojiTxb.Text = "";
            ShohinKanriCmb.Items.Clear();
            ShohinKanriCmb.DropDownStyle = ComboBoxStyle.DropDownList;

            ///小分類を取得
            var ScName = SmallClassificationDA.GetScName();

            //小分類をコンボボックスに追加
            foreach (string Scname in ScName.Reverse())
            {
               ShoubunruiCmb.Items.Add(Scname);
            }

            //大分類名を取得
            var McName = MajorClassificationDA.GetMcName();

            //大分類名をコンボボックスに追加
            foreach (string Mcname in McName.Reverse())
            {
                DaibunruiCmb.Items.Add(Mcname);
            }

            var MaName = MakerDA.GetMaName();

            foreach (string Maname in MaName.Reverse())
            {
                MakerNameCmb.Items.Add(Maname);
            }

            UpdateBtn.Enabled = false;
            HiddenBtn.Enabled = false;

            ShohinKanriCmb.Items.Add("表示");
            ShohinKanriCmb.Items.Add("非表示");
        }

        //本社ボタンクリック
        private void TopHonshaBtn_Click(object sender, EventArgs e)
        {
            TopHonshaPage.EmID = EmID;
            TopHonshaPage.PoID = PoID;
            TopHonshaPage.Logindate = Logindate;

            //現画面を非表示
            this.Visible = false;

            //TopHonshaPageを表示
            TopHonshaPage f2 = new TopHonshaPage();
            f2.Show();
        }

        //営業ボタンクリック
        private void TopEigyoBtn_Click(object sender, EventArgs e)
        {
            TopEigyoPage.EmID = EmID;
            TopEigyoPage.PoID = PoID;
            TopEigyoPage.Logindate = Logindate;

            //現画面を非表示
            this.Visible = false;

            //TopEigyoPageを表示
            TopEigyoPage f2 = new TopEigyoPage();
            f2.Show();
        }

        //物流ボタンクリック
        private void TopButsuryuBtn_Click(object sender, EventArgs e)
        {
            TopButsuryuPage.EmID = EmID;
            TopButsuryuPage.PoID = PoID;
            TopButsuryuPage.Logindate = Logindate;

            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            TopButsuryuPage f2 = new TopButsuryuPage();
            f2.Show();
        }

        //ログアウトボタンクリック
        private void TopLogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageDsp.DspMsg("M0004");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                //現画面を非表示
                this.Visible = false;

                //TopButsuryuPageを表示
                LoginPage f2 = new LoginPage();
                f2.ShowDialog();
            }
            else
            {
                // キャンセルの時の処理
            }
        }

        ///////////////////////////////
        //メソッド名：SetFormSyainKanriGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormShohinKanriGridView()
        {
            //読み取り専用に指定
            ShohinKanriDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            ShohinKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            ShohinKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListDisplay();
        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示
        ///////////////////////////////
        private void ListDisplay()
        {
            // スタッフデータの取得
            Productdsp = ProductDA.GetProductData();

            // DataGridViewに表示するデータを指定
            SetDataGridView(Productdsp);
        }


        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：M_ProdactDsp
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetDataGridView(List<M_ProductDsp> Productdsp)
        {
            ShohinKanriDgv.DataSource = Productdsp.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ShohinKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //行の高さ設定
            //ShohinKanriDgv.RowTemplate.Height = 40;

            //各列の文字位置の指定
            ShohinKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShohinKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ShohinKanriDgv.Refresh();
        }

        private void ShohinKanriDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ShohinKanriDgv.Rows.Count == 0)
            {
                return;
            }

            ClickFlg = 0;

            ShohinIDTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            ShohinNameTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            MakerNameCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            KakakuTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            AnzenTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            DaibunruiCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            ShoubunruiCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[6].Value.ToString();
            KatabanTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[7].Value.ToString();
            IroTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            SellDtm.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[9].Value.ToString();

            //商品管理フラグを日本語に変換
            if ((int)ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[10].Value == 0)
            {
                ShohinKanriCmb.Text = "表示";
            }
            else if ((int)ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[10].Value == 2)
            {
                ShohinKanriCmb.Text = "非表示";
            }

            if (ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[11].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[11].Value.ToString();
            }

            //ShoubunruiCmb.Items.Clear();
            //DaibunruiCmb.Items.Clear();

            /////小分類を取得
            //var ScName = SmallClassificationDA.GetScName();

            ////小分類をコンボボックスに追加
            //foreach (string Scname in ScName.Reverse())
            //{
            //    ShoubunruiCmb.Items.Add(Scname);
            //}

            ////大分類名を取得
            //var McName = MajorClassificationDA.GetMcName();

            ////大分類名をコンボボックスに追加
            //foreach (string Mcname in McName.Reverse())
            //{
            //    DaibunruiCmb.Items.Add(Mcname);
            //}

            UpdateBtn.Enabled = true;
            HiddenBtn.Enabled = true;

            ClickFlg = -1;
        }

        //登録ボタンクリック
        private void RegistBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if(!InputRegistDataCheck())
            {
                return;
            }

            //形式化
            var prodata = SetProductData();

            //登録
            RegistProduct(prodata);
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputRegistDataCheck()
        {
            //商品名の入力チェック
            if (!InputCheck.CheckPrName(ShohinNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrName(ShohinNameTxb.Text).Msg);
                return false;
            }

            //メーカー名の入力チェック
            if(!InputCheck.CheckMakerName(MakerNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckMakerName(MakerNameCmb.Text).Msg);
                return false;
            }

            //価格の入力チェック
            if (!InputCheck.CheckPrice(KakakuTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrice(KakakuTxb.Text).Msg);
                return false;
            }

            //安全在庫数の入力チェック
            if (!InputCheck.CheckPrSafetyStock(AnzenTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrSafetyStock(AnzenTxb.Text).Msg);
                return false;
            }

            //小分類IDの入力チェック
            if (!InputCheck.CheckScID(ShoubunruiCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckScID(ShoubunruiCmb.Text).Msg);
                return false;
            }

            //型番の入力チェック
            if (!InputCheck.CheckPrModelNumber(KatabanTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrModelNumber(KatabanTxb.Text).Msg);
                return false;
            }

            //色の入力チェック
            if (!InputCheck.CheckPrColor(IroTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrColor(IroTxb.Text).Msg);
                return false;
            }

            //発売日の入力チェック
            if (!SellDtm.Checked)
            {
                MessageDsp.DspMsg("M2023");
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：M_Product
        //機　能   ：商品情報を形式化する
        ///////////////////////////////
        private M_Product SetProductData()
        {
            int ScID = ProductDA.GetScID(ShoubunruiCmb.Text);
            int MaID = ProductDA.GetMaID(MakerNameCmb.Text);
            int PrFlg;

            if (ShohinKanriCmb.Text == "非表示")
            {
                PrFlg = 2;
            }
            else
            {
                PrFlg = 0;
            }

            return new M_Product
            {
                //PrID = int.Parse(ShohinIDTxb.Text),
                MaID = MaID,
                PrName = ShohinNameTxb.Text,
                Price = decimal.Parse(KakakuTxb.Text),
                PrSafetyStock = int.Parse(AnzenTxb.Text),
                ScID = ScID,
                PrModelNumber = KatabanTxb.Text,
                PrColor = IroTxb.Text,
                PrReleaseDate = SellDtm.Value,
                PrFlag = PrFlg,
                PrHidden = HihyojiTxb.Text
            };
        }

        ///////////////////////////////
        //メソッド名：RegistProduct()
        //引　数   ：M_Product
        //戻り値   ：なし
        //機　能   ：形式化した商品情報を登録する
        ///////////////////////////////
        private void RegistProduct(M_Product pro)
        {
            //商品IDの入力チェック
            if (ShohinIDTxb.Text != "")
            {
                if (DialogResult.OK == MessageDsp.DspMsg("M2038"))
                {
                    if (DialogResult.OK == MessageDsp.DspMsg("M2026"))
                    {
                        if (ProductDA.RegistProduct(pro))
                        {
                            MessageDsp.DspMsg("M2027");

                            //コントロールの初期設定
                            SetCtrlFormat();

                            //データグリッドビューの設定
                            SetFormShohinKanriGridView();
                        }
                        else
                        {
                            MessageDsp.DspMsg("M2028");
                        }
                    }
                }
            }
            else
            {
                if (DialogResult.OK == MessageDsp.DspMsg("M2026"))
                {
                    if (ProductDA.RegistProduct(pro))
                    {
                        MessageDsp.DspMsg("M2027");

                        //コントロールの初期設定
                        SetCtrlFormat();

                        //データグリッドビューの設定
                        SetFormShohinKanriGridView();
                    }
                    else
                    {
                        MessageDsp.DspMsg("M2028");
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!InputUpdataDataCheck())
            {
                return;
            }

            var updatedata = SetProductUpdateData();

            UpdateProduct(updatedata);
        }

        private bool InputUpdataDataCheck()
        {
            //商品IDの入力チェック
            if (!InputCheck.CheckPrID(ShohinIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrID(ShohinIDTxb.Text).Msg);
                return false;
            }

            //商品名の入力チェック
            if (!InputCheck.CheckPrName(ShohinNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrName(ShohinNameTxb.Text).Msg);
                return false;
            }

            //メーカー名の入力チェック
            if (!InputCheck.CheckMakerName(MakerNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckMakerName(MakerNameCmb.Text).Msg);
                return false;
            }

            //価格の入力チェック
            if (!InputCheck.CheckPrice(KakakuTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrice(KakakuTxb.Text).Msg);
                return false;
            }

            //安全在庫数の入力チェック
            if (!InputCheck.CheckPrSafetyStock(AnzenTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrSafetyStock(AnzenTxb.Text).Msg);
                return false;
            }

            //小分類IDの入力チェック
            if (!InputCheck.CheckScID(ShoubunruiCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckScID(ShoubunruiCmb.Text).Msg);
                return false;
            }

            //型番の入力チェック
            if (!InputCheck.CheckPrModelNumber(KatabanTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrModelNumber(KatabanTxb.Text).Msg);
                return false;
            }

            //色の入力チェック
            if (!InputCheck.CheckPrColor(IroTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrColor(IroTxb.Text).Msg);
                return false;
            }

            //発売日の入力チェック
            if (!SellDtm.Checked)
            {
                MessageDsp.DspMsg("M2023");
                return false;
            }

            //非表示理由の入力チェック
            if (ShohinKanriCmb.Text == "非表示")
            {
                if (!InputCheck.CheckHidden(HihyojiTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckHidden(HihyojiTxb.Text).Msg);
                    return false;
                }
            }

            return true;
        }

        private M_Product SetProductUpdateData()
        {
            int ScID = ProductDA.GetScID(ShoubunruiCmb.Text);
            int MaID = ProductDA.GetMaID(MakerNameCmb.Text);

            int PrFlg;

            if (ShohinKanriCmb.Text == "非表示")
            {
                PrFlg = 2;
            }
            else
            {
                PrFlg = 0;
            }

            return new M_Product
            {
                PrID = int.Parse(ShohinIDTxb.Text),
                MaID = MaID,
                PrName = ShohinNameTxb.Text,
                Price = decimal.Parse(KakakuTxb.Text),
                PrSafetyStock = int.Parse(AnzenTxb.Text),
                ScID = ScID,
                PrModelNumber = KatabanTxb.Text,
                PrColor = IroTxb.Text,
                PrReleaseDate = SellDtm.Value,
                PrFlag = PrFlg,
                PrHidden = HihyojiTxb.Text
            };
        }

        private void UpdateProduct(M_Product pro)
         {
            if (DialogResult.OK == MessageDsp.DspMsg("M2031"))
            {
                if (ProductDA.UpdateProduct(pro))
                {
                    MessageDsp.DspMsg("M2032");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormShohinKanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M2033");
                }
            }
        }

        //非表示ボタンクリック
        private void HiddenBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!InputHiddenDataCheck())
            {
                return;
            }

            //形式化
            var pro = SetProdactHideenData();

            //更新
            HiddenOrder(pro);
        }

        ///////////////////////////////
        //メソッド名：InputHiddenDataCheck()
        //引　数   ：なし
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：社員非表示時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputHiddenDataCheck()
        {
            //商品IDの入力チェック
            if (!InputCheck.CheckPrID(ShohinIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrID(ShohinIDTxb.Text).Msg);
                return false;
            }

            //非表示理由チェック
            if (!InputCheck.CheckHidden(HihyojiTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckHidden(HihyojiTxb.Text).Msg); ;
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //メソッド名：SetProdactHideenData()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Product SetProdactHideenData()
        {
            M_Product M_Pro = new M_Product()
            {
                PrID = int.Parse(ShohinIDTxb.Text),
                PrFlag = 2,
                PrHidden = HihyojiTxb.Text
            };

            return M_Pro;
        }

        ///////////////////////////////
        //メソッド名：HiddenEmployee()
        //引　数   ：M_Prodact
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を非表示設定に更新する
        ///////////////////////////////
        private void HiddenOrder(M_Product pro)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M2034"))
            {                
                if (ProductDA.DeleteProduct(pro))
                {
                    MessageDsp.DspMsg("M2035");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormShohinKanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M2036");
                }
            }
        }

        private void GamenKousinBtn_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();

            SetFormShohinKanriGridView();

            UpdateBtn.Enabled = false;
            HiddenBtn.Enabled = false;
        }

        //検索ボタンクリック
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!InputSearchDataCheck())
            {
                return;
            }

            var searchdata = SetProductSearchData();

            var majordata = SetMajorClassificatioData();

            SearchProduct(searchdata, majordata);
        }

        ///////////////////////////////
        //メソッド名：InputSearchDataCheck()
        //引　数   ：なし
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：社員検索時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputSearchDataCheck()
        {
            //商品IDの入力チェック
            if (ShohinIDTxb.Text != "")
            {
                if (!InputCheck.CheckSearchPrID(ShohinIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchPrID(ShohinIDTxb.Text).Msg);
                    return false;
                }
            }

            //商品名の入力チェック
            if (ShohinNameTxb.Text != "")
            {
                if (!InputCheck.CheckSearchPrName(ShohinNameTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchPrName(ShohinNameTxb.Text).Msg);
                    return false;
                }
            }

            //メーカー名の入力チェック
            if(MakerNameCmb.Text != "")
            {
                if (!InputCheck.CheckSearchMakerName(MakerNameCmb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchMakerName(MakerNameCmb.Text).Msg);
                    return false;
                }
            }

            //価格の入力チェック
            if (KakakuTxb.Text != "")
            {
                if (!InputCheck.CheckSearchPrice(KakakuTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchPrice(KakakuTxb.Text).Msg);
                    return false;
                }
            }

            //安全在庫数の入力チェック
            if(AnzenTxb.Text != "")
            {
                if (!InputCheck.CheckSearchPrSafetyStock(AnzenTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchPrSafetyStock(AnzenTxb.Text).Msg);
                    return false;
                }
            }

            /*小分類IDの入力チェック
            if(ShoubunruiCmb.Text != "")
            {
                int scid = ProductDA.GetScID(ShoubunruiCmb.Text);

                if (!ProductDA.SonzaiCheckScID(scid))
                {
                    MessageDsp.DspMsg("M2025");
                    return false;
                }

            }*/

            //型番の入力チェック
            if(KatabanTxb.Text != "")
            {
                if (!InputCheck.CheckPrModelNumber(KatabanTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckPrModelNumber(KatabanTxb.Text).Msg);
                    return false;
                }
            }

            //色の入力チェック
            if(IroTxb.Text != "")
            {
                if (!InputCheck.CheckPrColor(IroTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckPrColor(IroTxb.Text).Msg);
                    return false;
                }
            }

            //発売日の入力チェック
            if(SellDtm.Checked == true)
            {
                DateTime date = DateTime.ParseExact("00010101", "yyyymmdd", null);

                date = SellDtm.Value.Date;

                if (!ProductDA.SonzaiCheckPrReleaseDate(date))
                {
                    MessageBox.Show("M2025");
                    return false;
                }
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：SetEmployeeSearchData()
        //引　数   ：なし
        //戻り値   ：M_Product
        //機　能   ：商品情報を形式化する
        ///////////////////////////////
        private M_Product SetProductSearchData()
        {
            int prid = -1;
            int scid = 0;
            int maid = 0;
            decimal price = 0;
            int prsafetystock = 0;
            int PrFlg = -1;
            DateTime date = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (ShohinIDTxb.Text != "")
            {
                prid = int.Parse(ShohinIDTxb.Text);
            }

            if (ShoubunruiCmb.Text != "")
            {
                scid = ProductDA.GetScID(ShoubunruiCmb.Text);
            }

            if(MakerNameCmb.Text != "")
            {
                maid = ProductDA.GetMaID(MakerNameCmb.Text);
            }

            if(KakakuTxb.Text != "")
            {
                price = decimal.Parse(KakakuTxb.Text);
            }

            if(AnzenTxb.Text != "")
            {
                prsafetystock = int.Parse(AnzenTxb.Text);
            }

            if (ShohinKanriCmb.Text != "")
            {
                if (ShohinKanriCmb.Text == "非表示")
                {
                    PrFlg = 2;
                }
                else
                {
                    PrFlg = 0;
                }
            }

            if (SellDtm.Checked)
            {
                date = SellDtm.Value.Date;
            }

            M_Product M_Pro = new M_Product()
            {
                PrID = prid,
                MaID = maid,
                PrName = ShohinNameTxb.Text,
                Price = price,
                PrSafetyStock = prsafetystock,
                ScID = scid,
                PrModelNumber = KatabanTxb.Text,
                PrColor = IroTxb.Text,
                PrReleaseDate = date,
                PrFlag = PrFlg,
                PrHidden = HihyojiTxb.Text
            };

            return M_Pro;
        }

        ///////////////////////////////
        //メソッド名：SetMajorClassificatioData()
        //引　数   ：なし
        //戻り値   ：T_OrderDetail
        //機　能   ：大分類名情報を形式化する
        ///////////////////////////////
        private M_MajorClassification SetMajorClassificatioData()
        {
            int mcid = -1;

            if (DaibunruiCmb.Text != "")
            {
                mcid = MajorClassificationDA.GetMcID(DaibunruiCmb.Text);
            }

            M_MajorClassification M_MajorClassification = new M_MajorClassification()
            {
                McID = mcid
            };

            return M_MajorClassification;
        }

        ///////////////////////////////
        //メソッド名：SearchEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を検索、表示する
        ///////////////////////////////
        private void SearchProduct(M_Product searchpro, M_MajorClassification searchmaj)
        {
            var pro = ProductDA.SearchProduct(searchpro, searchmaj);

            if (pro.Count == 0)
            {
                MessageDsp.DspMsg("M2025");
            }

            SetDataGridView(pro);
        }

        private void ShohinKanriDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ShohinIDTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            //ShohinNameTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            //MakerNameCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            //KakakuTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            //AnzenTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            //DaibunruiCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            //ShoubunruiCmb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[6].Value.ToString();
            //KatabanTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[7].Value.ToString();
            //IroTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            //SellDtm.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[9].Value.ToString();

            ////商品管理フラグを日本語に変換
            //if ((int)ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[10].Value == 0)
            //{
            //    ShohinKanriCmb.Text = "表示";
            //}
            //else if ((int)ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[10].Value == 2)
            //{
            //    ShohinKanriCmb.Text = "非表示";
            //}

            //if (ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[11].Value == null)
            //{
            //    HihyojiTxb.Text = "";
            //}
            //else
            //{
            //    HihyojiTxb.Text = ShohinKanriDgv.Rows[ShohinKanriDgv.CurrentRow.Index].Cells[11].Value.ToString();
            //}

            //ShoubunruiCmb.Items.Clear();
            //DaibunruiCmb.Items.Clear();

            /////小分類を取得
            //var ScName = SmallClassificationDA.GetScName();

            ////小分類をコンボボックスに追加
            //foreach (string Scname in ScName.Reverse())
            //{
            //    ShoubunruiCmb.Items.Add(Scname);
            //}

            ////大分類名を取得
            //var McName = MajorClassificationDA.GetMcName();

            ////大分類名をコンボボックスに追加
            //foreach (string Mcname in McName.Reverse())
            //{
            //    DaibunruiCmb.Items.Add(Mcname);
            //}

            //UpdateBtn.Enabled = true;
            //HiddenBtn.Enabled = true;
        }


        private void DaibunruiCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ClickFlg == 0)
            {
                return;
            }

            if(ShoubunruiCmb.Text == "")
            {
                int mcID = SmallClassificationDA.GetMcID(DaibunruiCmb.Text);

                using (var dbContext = new SalesManagement_DevContext())
                {
                    var ShobunruiList = dbContext.M_SmallClassifications
                        .Where(sc => sc.McID == mcID)
                        .Select(sc => sc.ScName)
                        .ToList();

                    ShoubunruiCmb.Items.Clear();
                    ShoubunruiCmb.Items.AddRange(ShobunruiList.ToArray());
                }
            }
            else if (!SmallClassificationDA.Check(MajorClassificationDA.GetMcID(DaibunruiCmb.Text),ShoubunruiCmb.Text))
            {
                int mcID = SmallClassificationDA.GetMcID(DaibunruiCmb.Text);

                using (var dbContext = new SalesManagement_DevContext())
                {
                    var ShobunruiList = dbContext.M_SmallClassifications
                        .Where(sc => sc.McID == mcID)
                        .Select(sc => sc.ScName)
                        .ToList();

                    ShoubunruiCmb.Items.Clear();
                    ShoubunruiCmb.Items.AddRange(ShobunruiList.ToArray());
                }
            }
        }

        private void ShoubunruiCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int scID = MajorClassificationDA.GetMcID(ShoubunruiCmb.Text);

            //using (var dbContext = new SalesManagement_DevContext())
            //{
            //    var DaibunruiList = dbContext.M_SmallClassifications
            //        .Where(sc => sc.ScID == scID)
            //        .Select(sc => sc.M_MajorClassification.McName);
            //    //    .ToList();

            //    //DaibunruiCmb.Items.Clear();
            //    //DaibunruiCmb.Items.AddRange(DaibunruiList.ToArray());
            //    DaibunruiCmb.Text = DaibunruiList.ToString();
            //}
        }

        private void ShoubunruiCmb_TextChanged(object sender, EventArgs e)
        {
            if (ClickFlg == 0)
            {
                return;
            }

            if (DaibunruiCmb.Text == "")
            {
                string McName = SmallClassificationDA.GetMcName(ShoubunruiCmb.Text);
                DaibunruiCmb.Text = McName;
            }
            else if(!SmallClassificationDA.Check(MajorClassificationDA.GetMcID(DaibunruiCmb.Text), ShoubunruiCmb.Text))
            {
                string McName = SmallClassificationDA.GetMcName(ShoubunruiCmb.Text);
                DaibunruiCmb.Text = McName;
            }
            //using (var dbContext = new SalesManagement_DevContext())
            //{
            //    var DaibunruiList = dbContext.M_SmallClassifications
            //        .Where(sc => sc.ScID == scID)
            //        .Select(sc => sc.M_MajorClassification.McName);
            //    //    .ToList();

            //    //DaibunruiCmb.Items.Clear();
            //    //DaibunruiCmb.Items.AddRange(DaibunruiList.ToArray());
            //    DaibunruiCmb.Text = DaibunruiList.ToString();
            //}
        }
    }
}