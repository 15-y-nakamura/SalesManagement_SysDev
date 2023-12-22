using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //データグリッドビュー用のスタッフデータ
        private static List<M_ProductDsp> Product;

        MessageDsp MessageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck InputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;
        internal static string Logindate = "";

        public ShohinKanri()
        {

            InitializeComponent();
        }

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

        private void ShohinKanri_Load(object sender, EventArgs e)
        {

            //コントロールの初期設定
            SetCtrlFormat();

            //データグリッドビューの設定
            SetFormShohinKanriGridView();

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
            MakerIDTxb.Text = "";
            KakakuTxb.Text = "";
            AnzenTxb.Text = "";
            DaibunruiCmb.Items.Clear();
            DaibunruiCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShoubunruiCmb.Items.Clear();
            ShoubunruiCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            KatabanTxb.Text = "";
            IroTxb.Text = "";
            SellDtm.Text = "";
            HihyojiTxb.Text = "";
            ShohinKanriCmb.Items.Clear();
            ShohinKanriCmb.DropDownStyle = ComboBoxStyle.DropDownList;

            //小分類を取得
            var ScName = SmallClassificationDA.GetScName();

            //小分類をコンボボックスに追加
            foreach (string Scname in ScName.Reverse())
            {
                ShoubunruiCmb.Items.Add(ScName);
            }

            //大分類名を取得
            var McName = MajorClassificationDA.GetMcName();

            //営業所名をコンボボックスに追加
            foreach (string Mcname in McName.Reverse())
            {
                DaibunruiCmb.Items.Add(McName);
            }

            ShohinKanriCmb.Items.Add("表示");
            ShohinKanriCmb.Items.Add("非表示");
        }

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
            Product = ProductDA.GetProductData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        private void SetDataGridView()
        {
            ShohinKanriDgv.DataSource = Product.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ShohinKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //行の高さ設定
            ShohinKanriDgv.RowTemplate.Height = 40;

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
            //ミス
        }

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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!InputUpdataDataCheck())
            {
                return;
            }

            var updatedata = SetProductUpdateData();

            UpdateProduct(updatedata);
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：商品登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        
        private bool InputRegistDataCheck()
        {
            //商品IDの入力チェック
            if (!InputCheck.CheckRegistPrID(ShohinIDTxb.Text).flg)
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
            if (!InputCheck.CheckPrMaker(MakerIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrMaker(MakerIDTxb.Text).Msg);
                return false;
            }

            //価格の入力チェック
            if (!InputCheck.CheckPrice(KakakuLbl.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrice(KakakuLbl.Text).Msg);
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
            if (!InputCheck.CheckPrReleaseDate(SellDtm.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrReleaseDate(SellDtm.Text).Msg);
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
            int PrFlg;

            if (ShohinKanriCmb.Text == "非表示")
            {
                PrFlg = 2;
            } else
            {
                PrFlg = 0;
            }

            return new M_Product
            {
                PrID = int.Parse(ShohinIDTxb.Text),
                MaID = int.Parse(MakerIDTxb.Text),
                PrName = ShohinNameTxb.Text,
                Price = int.Parse(MakerIDTxb.Text),
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
            if (DialogResult.OK == MessageDsp.DspMsg("M2025"))
            {
                if (ProductDA.RegistProduct(pro))
                {
                    MessageDsp.DspMsg("M2026");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormShohinKanriGridView();
                } else
                {
                    MessageDsp.DspMsg("M2027");
                }
            }
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
            if (!InputCheck.CheckPrMaker(MakerIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrMaker(MakerIDTxb.Text).Msg);
                return false;
            }

            //価格の入力チェック
            if (!InputCheck.CheckPrice(KakakuLbl.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrice(KakakuLbl.Text).Msg);
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
            if (!InputCheck.CheckPrReleaseDate(SellDtm.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPrReleaseDate(SellDtm.Text).Msg);
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
            int PrFlg;

            if (ShohinKanriCmb.Text == "非表示")
            {
                PrFlg = 2;
            } else
            {
                PrFlg = 0;
            }

            return new M_Product
            {
                PrID = int.Parse(ShohinIDTxb.Text),
                MaID = int.Parse(MakerIDTxb.Text),
                PrName = ShohinNameTxb.Text,
                Price = int.Parse(MakerIDTxb.Text),
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
            if (DialogResult.OK == MessageDsp.DspMsg("M2030"))
            {
                if (ProductDA.UpdateProduct(pro))
                {
                    MessageDsp.DspMsg("M2031");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormShohinKanriGridView();
                } else
                {
                    MessageDsp.DspMsg("M2032");
                }
            }
        }
    }
}