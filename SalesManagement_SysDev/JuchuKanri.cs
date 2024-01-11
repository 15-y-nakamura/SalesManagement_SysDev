using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalesManagement_SysDev
{
    public partial class JuchuKanri : Form
    {
        //社員テーブルアクセスクラスのインスタンス化
        EmployeeDataAccess EmployeeDA = new EmployeeDataAccess();

        //役職テーブルアクセスクラスのインスタンス化
        PositionDataAccess PositionDA = new PositionDataAccess();

        //営業所テーブルアクセスクラスのインスタンス化
        SalesOfficeDataAccess SalesOfficeDA = new SalesOfficeDataAccess();

        //顧客テーブルアクセスクラスのインスタンス化
        ClientDataAccess ClientDA = new ClientDataAccess();

        //受注テーブルアクセスクラスのインスタンス化
        OrderDataAccess OrderDA = new OrderDataAccess();

        //受注詳細テーブルアクセスクラスのインスタンス化
        OrderDetailDataAccess OrderDetailDA = new OrderDetailDataAccess();

        //データグリッドビュー用の受注データ
        private static List<T_OrderDsp> Orderdsp;

        //データグリッドビュー用の受注データ
        private static List<T_OrderDetailDsp> OrderDetaildsp;

        //メッセージ表示クラスインスタンス化
        MessageDsp MessageDsp = new MessageDsp();

        //入力チェッククラスインスタンス化
        InputCheck InputCheck = new InputCheck();

        internal static int PoID = 0;
        internal static int EmID = 0;
        internal static int SoID = 0;
        internal static int CIID = 0;

        public int OrQuantity { get; private set; }
        internal static string Logindate = "";

        public JuchuKanri()
        {

            InitializeComponent();
        }

        private void JuchuKanri_Load(object sender, EventArgs e)
        {
            string[] TopData = new string[4];
            TopData = EmployeeDA.GetTopData(EmID);

            string emID = EmID.ToString();
            string logindate = Logindate;

            TopIDLbl.Text = emID;
            TopNameLbl.Text = TopData[0];
            TopYakushokuLbl.Text = TopData[1];
            TopEigyoshoLbl.Text = TopData[2];
            TopJikanLbl.Text = logindate;

            if (PoID == 2)
            {
                TopHonshaBtn.Enabled = false;
                TopHonshaBtn.BackColor = Color.DarkGray;
                TopHonshaBtn.FlatAppearance.BorderSize = 2;
                TopHonshaBtn.FlatAppearance.BorderColor = Color.Black;

                TopButsuryuBtn.Enabled = false;
                TopButsuryuBtn.BackColor = Color.DarkGray;
                TopButsuryuBtn.FlatAppearance.BorderSize = 2;
                TopButsuryuBtn.FlatAppearance.BorderColor = Color.Black;

                TopEigyoBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
                TopEigyoBtn.FlatAppearance.BorderSize = 2;
                TopEigyoBtn.FlatAppearance.BorderColor = Color.SteelBlue;

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

            //受注データグリッドビューの設定
            SetFormJuchuKanriGridView();

            //詳細受注データグリッドビューの設定
            SetFormJuchuKanriDetailGridView();
        }

        ///////////////////////////////
        //メソッド名：SetCtrlFormat()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コントロールの初期設定
        ///////////////////////////////
        private void SetCtrlFormat()
        {
            JuchuIDTxb.Text = "";
            JuchuDateDtm.Checked = false;
            ShainIDTxb.Text = "";
            KokyakuIDTxb.Text = "";
            KokyakuTantoNameTxb.Text = "";
            EigyoushoNameCmb.Items.Clear();
            EigyoushoNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            JuchuJotaiFlagCmb.Items.Clear();
            JuchuJotaiFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            JuchuKanriFlagCmb.Items.Clear();
            JuchuKanriFlagCmb.Items.Clear();
            JuchuDetailIDTxb.Text = "";
            ShohinIDTxb.Text = "";
            SuryoTxb.Text = "";
            GokeiKingakuTxb.Text = "";
            HihyojiTxb.Text = "";

            //営業所名を取得
            var SoName = SalesOfficeDA.GetSoName();

            //営業所名をコンボボックスに追加
            foreach (string Soname in SoName.Reverse())
            {
                EigyoushoNameCmb.Items.Add(Soname);
            }

            JuchuJotaiFlagCmb.Items.Add("確認");
            JuchuJotaiFlagCmb.Items.Add("未確定");

            JuchuKanriFlagCmb.Items.Add("表示");
            JuchuKanriFlagCmb.Items.Add("非表示");
        }



        /*テキストボックス内に灰色の文字を表示
        private void PlaceHolderText()
        {
            TelTxb.Text = "ハイフンあり";
            TelTxb.ForeColor = SystemColors.GrayText;
            TelTxb.Enter += TelTxb_Enter;
            TelTxb.Leave += TelTxb_Leave;
        }

        //電話番号のテキストボックスが選択されていない場合
        private void TelTxb_Enter(object sender, EventArgs e)
        {
           if (TelTxb.Text == "ハイフンあり")
            {
                TelTxb.Text = "";
                TelTxb.ForeColor = SystemColors.WindowText;
            }
        }

        //電話番号のテキストボックスが選択されていない・入力されていない場合
        private void TelTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TelTxb.Text))
            {
               TelTxb.Text = "ハイフンあり";
                TelTxb.ForeColor = SystemColors.GrayText;
            }
        }*/

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
        private void SetFormJuchuKanriGridView()
        {
            //読み取り専用に指定
            JuchuKanriDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            JuchuKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            JuchuKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListOrderDisplay();
        }

        ///////////////////////////////
        //メソッド名：SetFormSyainKanriDetailGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormJuchuKanriDetailGridView()
        {
            //読み取り専用に指定
            JuchuKanriDetailDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            JuchuKanriDetailDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            JuchuKanriDetailDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListOrderDetailDisplay();
        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示
        ///////////////////////////////
        private void ListOrderDisplay()
        {
            // 受注データの取得
            Orderdsp = OrderDA.GetOrderData();

            // DataGridViewに表示するデータを指定
            SetDataOrderGridView(Orderdsp);
        }

        ///////////////////////////////
        //メソッド名：GetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示
        ///////////////////////////////
        private void ListOrderDetailDisplay()
        {
            //受注詳細データの取得
            OrderDetaildsp = OrderDetailDA.GetOrderDetailData();

            // DataGridViewに表示するデータを指定
            SetDataOrderDetailGridView(OrderDetaildsp);
        }


        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetDataOrderGridView(List<T_OrderDsp> Orderdsp)
        {
            JuchuKanriDgv.DataSource = Orderdsp.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            JuchuKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            /*            
            //各列幅の指定
            ShainKanriDgv.Columns[0].Width = 80; //社員ID
            ShainKanriDgv.Columns[1].Width = 100; //社員名
            ShainKanriDgv.Columns[2].Width = 80; //営業ID
            ShainKanriDgv.Columns[3].Width = 100; //営業名
            ShainKanriDgv.Columns[4].Width = 80; //役職ID
            ShainKanriDgv.Columns[5].Width = 70; //役職名
            ShainKanriDgv.Columns[6].Width = 100; //入社年月日
            ShainKanriDgv.Columns[7].Width = 100; //電話番号
            ShainKanriDgv.Columns[8].Width = 110; //社員管理フラグ
            ShainKanriDgv.Columns[9].Width = 160; //非表示理由
            */

            //行の高さ設定
            JuchuKanriDetailDgv.RowTemplate.Height = 40;

            //各列の文字位置の指定
            JuchuKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            JuchuKanriDgv.Refresh();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetDataOrderDetailGridView(List<T_OrderDetailDsp> OrderDetaildsp)
        {

            JuchuKanriDetailDgv.DataSource = OrderDetaildsp.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            JuchuKanriDetailDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            /*            
            //各列幅の指定
            ShainKanriDgv.Columns[0].Width = 80; //社員ID
            ShainKanriDgv.Columns[1].Width = 100; //社員名
            ShainKanriDgv.Columns[2].Width = 80; //営業ID
            ShainKanriDgv.Columns[3].Width = 100; //営業名
            ShainKanriDgv.Columns[4].Width = 80; //役職ID
            ShainKanriDgv.Columns[5].Width = 70; //役職名
            ShainKanriDgv.Columns[6].Width = 100; //入社年月日
            ShainKanriDgv.Columns[7].Width = 100; //電話番号
            ShainKanriDgv.Columns[8].Width = 110; //社員管理フラグ
            ShainKanriDgv.Columns[9].Width = 160; //非表示理由
            */

            //行の高さ設定
            JuchuKanriDetailDgv.RowTemplate.Height = 40;

            JuchuKanriDetailDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDetailDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDetailDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDetailDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            JuchuKanriDetailDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            JuchuKanriDetailDgv.Refresh();
        }

        //登録ボタンクラック
        private void RegistBtn_Click(object sender, EventArgs e)
        {


            //受注IDの入力チェック
            if (!InputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
            }

            // テキストボックスから数値を取得
            int textBoxValue = int.Parse(JuchuIDTxb.Text);

            // データベースから、テキストボックスの数値と一致するデータがあるか確認
            using (var dbContext = new SalesManagement_DevContext())
            {
                // データベース内のテーブルから、条件に一致するレコードを検索
                var matchingData = dbContext.T_Orders.FirstOrDefault(x => x.OrID == textBoxValue);

                if (matchingData != null)
                {
                    // 一致するデータが見つかった場合の処理
                    MessageBox.Show("受注詳細に飛びます");

                    //入力チェック
                    if (!InputRegistOrderDetailDataCheck())
                    {
                        return;
                    }

                    var orderdetail = SetOrderDetailData();

                    //登録
                    RegistOrderDetail(orderdetail);
                }
                else
                {
                    // 一致するデータが見つからなかった場合の処理
                    MessageBox.Show("受注登録に飛びます");

                    //入力チェック
                    if (!InputRegistOrderDataCheck())
                    {
                        return;
                    }

                    //形式化
                    var order = SetOrderData();

                    //登録
                    RegistOrder(order);
                }
            }
        }

        ///////////////////////////////
        //メソッド名：InputRegistOrderDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputRegistOrderDataCheck()
        {
                //受注IDの入力チェック
                if (!InputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
                    return false;
                }

                //社員IDの入力チェック
                if (!InputCheck.CheckRegistOrderEmID(ShainIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrderEmID(ShainIDTxb.Text).Msg);
                    return false;
                }

                //顧客IDの入力チェック
                if (!InputCheck.CheckRegistOrderClID(KokyakuIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrderClID(KokyakuIDTxb.Text).Msg);
                    return false;
                }

                //顧客担当者名の入力チェック
                if (!InputCheck.CheckRegistClTantoName(KokyakuTantoNameTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistClTantoName(KokyakuTantoNameTxb.Text).Msg);
                    return false;
                }

                //営業所名の入力チェック
                if (!InputCheck.CheckJuchuSoNameCmb(EigyoushoNameCmb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckJuchuSoNameCmb(EigyoushoNameCmb.Text).Msg);
                    return false;
                }

            return true;
        }

        ///////////////////////////////
        //メソッド名：InputRegistOrderDetailDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：受注詳細登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputRegistOrderDetailDataCheck()
        {
            //受注IDの入力チェック
            if (!InputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
                return false;
            }

            //受注詳細IDの入力チェック
            if (!InputCheck.CheckRegistOrDetailID(JuchuDetailIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistOrDetailID(ShohinIDTxb.Text).Msg);
                return false;
            }

            //商品IDの入力チェック
            if (!InputCheck.CheckRegistOrderShohinID(ShohinIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistOrderShohinID(ShohinIDTxb.Text).Msg);
                return false;
            }

            //数量の入力チェック
            if (!InputCheck.CheckRegistSuryo(SuryoTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistSuryo(SuryoTxb.Text).Msg);
                return false;
            }

            //合計金額の入力チェック
            if (!InputCheck.CheckRegistGokeiKingaku(GokeiKingakuTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistGokeiKingaku(GokeiKingakuTxb.Text).Msg);
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：T_Order
        //機　能   ：受注情報を形式化する
        ///////////////////////////////
        private T_Order SetOrderData()
        {
            int SoID = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            //int EmID = EmployeeDA.GetEmID(ShainIDTxb.Text);
            //int CIID = ClientDA.GetCIID(KokyakuIDTxb.Text);

            int OrFlg;
            int OrStateFlg;

            if (JuchuKanriFlagCmb.Text == "非表示")
            {
                OrFlg = 2;
            }
            else
            {
                OrFlg = 0;
            }

            if (JuchuJotaiFlagCmb.Text == "確定")
            {
                OrStateFlg = 1;
            }
            else
            {
                OrStateFlg = 0;
            }

            return new T_Order
            {
                OrID = int.Parse(JuchuIDTxb.Text),
                SoID = SoID,
                EmID = int.Parse(ShainIDTxb.Text),
                ClID = int.Parse(KokyakuIDTxb.Text),
                ClCharge = KokyakuTantoNameTxb.Text,
                OrDate = JuchuDateDtm.Value,
                OrStateFlag = OrStateFlg,
                OrFlag = OrFlg,
                OrHidden = HihyojiTxb.Text
            };
        }

        ///////////////////////////////
        //メソッド名：SetOrderDetailData()
        //引　数   ：なし
        //戻り値   ：T_OrderDetail
        //機　能   ：受注詳細情報を形式化する
        ///////////////////////////////
        private T_OrderDetail SetOrderDetailData()
        {
            return new T_OrderDetail
            {
                OrDetailID = int.Parse(JuchuDetailIDTxb.Text),
                OrID = int.Parse(JuchuIDTxb.Text),
                PrID = int.Parse(ShohinIDTxb.Text),
                OrQuantity = int.Parse(SuryoTxb.Text),
                OrTotalPrice = Convert.ToDecimal(GokeiKingakuTxb.Text),
            };
        }

        ///////////////////////////////
        //メソッド名：RegistOrder()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した受注情報を登録する
        ///////////////////////////////
        private void RegistOrder(T_Order order)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M6024"))
            {
                if (OrderDA.RegistOrder(order))
                {
                    MessageDsp.DspMsg("M6025");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormJuchuKanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M6026");
                }
            }
        }

        ///////////////////////////////
        //メソッド名：RegistOrderDetail()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した受注情報を登録する
        ///////////////////////////////
        private void RegistOrderDetail(T_OrderDetail orderdetail)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M6024"))
            {
                if (OrderDetailDA.RegistOrderDetail(orderdetail))
                {
                    MessageDsp.DspMsg("M6025");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormJuchuKanriDetailGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M6026");
                }
            }
        }

        //検索ボタンクリック
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!InputSearchDataCheck())
            {
                return;
            }

            var ordersearchdata = SetOrderData();

            var orderdetailsearchdata = SetOrderDetailData();

            SearchOrder(ordersearchdata, orderdetailsearchdata);

        }

        private bool InputSearchDataCheck()
        {
            //受注IDの入力チェック
            if (JuchuIDTxb.Text != "")
            {
                if (!InputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
                    return false;
                }
            }

            //社員IDの入力チェック
            if (ShainIDTxb.Text != "")
            {
                if (!InputCheck.CheckSearchOrderEmID(ShainIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchOrderEmID(ShainIDTxb.Text).Msg);
                    return false;
                }
            }

            //顧客IDの入力チェック
            if (KokyakuIDTxb.Text != "")
            {
                if (!InputCheck.CheckSearchOrderClID(KokyakuIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchOrderClID(KokyakuIDTxb.Text).Msg);
                    return false;
                }
            }

            //顧客担当者名の入力チェック
            if (KokyakuTantoNameTxb.Text != "")
            {
                if (!InputCheck.CheckRegistClTantoName(KokyakuTantoNameTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistClTantoName(KokyakuTantoNameTxb.Text).Msg);
                    return false;
                }
            }

            //営業所名の入力チェック
            if (EigyoushoNameCmb.Text != "")
            {
                if (!InputCheck.CheckJuchuSoNameCmb(EigyoushoNameCmb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckJuchuSoNameCmb(EigyoushoNameCmb.Text).Msg);
                    return false;
                }
            }

            //受注詳細IDの入力チェック
            if (JuchuDetailIDTxb.Text != "")
            {
                if (!InputCheck.CheckRegistOrDetailID(JuchuDetailIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrDetailID(ShohinIDTxb.Text).Msg);
                    return false;
                }
            }

            //商品IDの入力チェック
            if (ShohinIDTxb.Text != "")
            {
                if (!InputCheck.CheckRegistOrderShohinID(ShohinIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistOrderShohinID(ShohinIDTxb.Text).Msg);
                    return false;
                }
            }

            //数量の入力チェック
            if (SuryoTxb.Text != "")
            {
                if (!InputCheck.CheckRegistSuryo(SuryoTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistSuryo(SuryoTxb.Text).Msg);
                    return false;
                }
            }

            //合計金額の入力チェック
            if (GokeiKingakuTxb.Text != "")
            {
                if (!InputCheck.CheckRegistGokeiKingaku(GokeiKingakuTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckRegistGokeiKingaku(GokeiKingakuTxb.Text).Msg);
                    return false;
                }
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：SetOrderSearchData()
        //引　数   ：なし
        //戻り値   ：T_Order
        //機　能   ：受注情報を形式化する
        ///////////////////////////////
        private T_Order SetOrderSearchData()
        {
            int soid = 0;
            int OrFlg = -1;
            int OrStateFlg = -1;
            DateTime date = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (EigyoushoNameCmb.Text != "")
            {
                soid = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            }

            if (JuchuDateDtm.Checked)
            {
                date = JuchuDateDtm.Value;
            }

            if (JuchuKanriFlagCmb.Text != "")
            {
                if (JuchuKanriFlagCmb.Text == "非表示")
                {
                    OrFlg = 2;
                }
                else
                {
                    OrFlg = 0;
                }
            }

            if (JuchuJotaiFlagCmb.Text == "")
            {
                if (JuchuJotaiFlagCmb.Text == "確定")
                {
                    OrStateFlg = 1;
                }
                else
                {
                    OrStateFlg = 0;
                }
            }

            T_Order T_Ord = new T_Order()
            {
                OrID = int.Parse(JuchuIDTxb.Text),
                SoID = soid,
                EmID = int.Parse(ShainIDTxb.Text),
                ClID = int.Parse(KokyakuIDTxb.Text),
                ClCharge = KokyakuTantoNameTxb.Text,
                OrDate = date,
                OrStateFlag = OrStateFlg,
                OrFlag = OrFlg,
                OrHidden = HihyojiTxb.Text,
            };

            return T_Ord;

        }

        ///////////////////////////////
        //メソッド名：SetOrderDetailData()
        //引　数   ：なし
        //戻り値   ：T_OrderDetail
        //機　能   ：受注詳細情報を形式化する
        ///////////////////////////////
        private T_OrderDetail SetOrderDetaiSearchlData()
        {

            T_OrderDetail T_Ordertail = new T_OrderDetail()
            {
                OrDetailID = int.Parse(JuchuDetailIDTxb.Text),
                OrID = int.Parse(JuchuIDTxb.Text),
                PrID = int.Parse(ShohinIDTxb.Text),
                OrQuantity = int.Parse(SuryoTxb.Text),
                OrTotalPrice = Convert.ToDecimal(GokeiKingakuTxb.Text),
            };

            return T_Ordertail;
        }

        private void SearchOrder(T_Order ordseadata, T_OrderDetail orddetailseadata)
        {
            var orddata = OrderDA.SearchOrder(ordseadata);
            var orddetaildata = OrderDetailDA.SearchOrderDetail(orddetailseadata);

            //データグリッドビューの設定
            //SetDataGridView(orddata, orddetaildata);

        }

        //画面更新ボタンクリック
        private void GamenKousinBtn_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();

            SetFormJuchuKanriGridView();
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
            var ord = SetJuchuHideenData();

            //更新
            HiddenJuchu(ord);
        }

        private bool InputHiddenDataCheck()
        {
            //受注IDの入力チェック
            if (!InputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
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

        private T_Order SetJuchuHideenData()
        {
            T_Order T_ord = new T_Order()
            {
                OrID = int.Parse(JuchuIDTxb.Text),
                OrFlag = 2,
                OrHidden = HihyojiTxb.Text
            };

            return T_ord;
        }


        private void HiddenJuchu(T_Order ord)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M6028"))
            {
                if (OrderDA.DeleteEmployee(ord))
                {
                    MessageDsp.DspMsg("M6029");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormJuchuKanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M6030");
                }
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            /*using (var dbContext = new SalesManagement_DevContext())
            {
                // 受注情報フラグを0から1に更新するコード
                var orderToUpdate = dbContext.T_Order.FirstOrDefault(o => o.OrID == orderId); // orderIdは更新したい受注のIDなど
                if (orderToUpdate != null)
                {
                    orderToUpdate.OrFlag = 1; // 受注情報フラグを1に更新
                    dbContext.SaveChanges(); // 変更をデータベースに保存
                }

                // 新しい注文レコードを作成するコード
                var newChumon = new T_Chumon
                {
                    SoID = newSalesOfficeId, // 新しい注文の営業所IDなど
                    EmID = newEmployeeId, // 新しい注文の社員IDなど
                    ClID = newClientId, // 新しい注文の顧客IDなど
                    ClCharge = newClientCharge, // 新しい注文の顧客担当者名など
                    OrDate = DateTime.Now, // 新しい注文の受注年月日（例：現在の日付）
                    OrStateFlag = 0, // 新しい注文の受注状態フラグ（適切な値を設定）
                    OrFlag = 0, // 新しい注文の受注管理フラグ（適切な値を設定）
                    OrHidden = null // 新しい注文の非表示理由（初期値はnullなど）
                                    // 他のプロパティも適切に設定
                };

                dbContext.T_Chumon.Add(newChumon); // 新しい注文レコードを追加
                dbContext.SaveChanges(); // 変更をデータベースに保存
            }*/
        }

        private void JuchuKanriDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            JuchuIDTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            EigyoushoNameCmb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            ShainIDTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            KokyakuIDTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            KokyakuTantoNameTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            JuchuDateDtm.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            //受注状態フラグを日本語に変換
            if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[6].Value == 0)
            {
                JuchuJotaiFlagCmb.Text = "未確定";
            }
            else if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[6].Value == 1)
            {
                JuchuJotaiFlagCmb.Text = "確定";
            }
            //受注管理フラグを日本語に変換
            if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[7].Value == 0)
            {
                JuchuKanriFlagCmb.Text = "表示";
            }
            else if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[7].Value == 2)
            {
                JuchuKanriFlagCmb.Text = "非表示";
            }

            if (JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[8].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            }
        }

        private void JuchuKanriDetailDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            JuchuDetailIDTxb.Text = JuchuKanriDetailDgv.Rows[JuchuKanriDetailDgv.CurrentRow.Index].Cells[0].Value.ToString();
            JuchuIDTxb.Text = JuchuKanriDetailDgv.Rows[JuchuKanriDetailDgv.CurrentRow.Index].Cells[1].Value.ToString();
            ShohinIDTxb.Text = JuchuKanriDetailDgv.Rows[JuchuKanriDetailDgv.CurrentRow.Index].Cells[2].Value.ToString();
            SuryoTxb.Text = JuchuKanriDetailDgv.Rows[JuchuKanriDetailDgv.CurrentRow.Index].Cells[3].Value.ToString();
            GokeiKingakuTxb.Text =  JuchuKanriDetailDgv.Rows[JuchuKanriDetailDgv.CurrentRow.Index].Cells[4].Value.ToString();
        }
    }
}
