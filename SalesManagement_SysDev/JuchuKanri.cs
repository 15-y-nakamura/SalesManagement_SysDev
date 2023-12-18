using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

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
        

        public JuchuKanri()
        {

            InitializeComponent();
        }



        private void JuchuKanri_Load(object sender, EventArgs e)
        {
            string[] TopData = new string[4];
            TopData = EmployeeDA.GetTopData(EmID);

            string emID = EmID.ToString();

            TopIDLbl.Text = emID;
            TopNameLbl.Text = TopData[0];
            TopYakushokuLbl.Text = TopData[1];
            TopEigyoshoLbl.Text = TopData[2];
            TopJikanLbl.Text = TopData[3];

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

            //データグリッドビューの設定
            SetFormJuchuKanriGridView();

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
            ShainNameTxb.Text = "";
            KokyakuNameTxb.Text = "";
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
            // 受注データの取得
            Orderdsp = OrderDA.GetOrderData();

            //受注詳細データの取得
            OrderDetaildsp = OrderDetailDA.GetOrderDetailData().

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetDataGridView()
        {
            JuchuKanriDgv.DataSource = Orderdsp.ToList();
            JuchuKanriDgv.DataSource = OrderDetaildsp.ToList();


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
            JuchuKanriDgv.RowTemplate.Height = 40;

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
            JuchuKanriDgv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            JuchuKanriDgv.Refresh();
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!InputRegistDataCheck())
            {
                return;
            }

            //形式化
            var order = SetOrderData();

            //形式化
            var orderdetail = SetOrderDetailData();

            //登録
            RegistOrder(order,orderdetail);
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：社員登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputRegistDataCheck()
        {
            /*受注IDの入力チェック
            if (!InputCheck.CheckRegistJuchuID(JuchuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistJuchuID(JuchuIDTxb.Text).Msg);
                return false;
            }

            //社員IDの入力チェック
            if (!InputCheck.CheckRegistEmID(ShainNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistEmID(ShainNameTxb.Text).Msg);
                return false;
            }

            //顧客IDの入力チェック
            if (!InputCheck.CheckRegistClID(KokyakuNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistClID(KokyakuNameTxb.Text).Msg);
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

            //商品IDの入力チェック
            if (!InputCheck.CheckRegistShohinID(ShohinIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistShohinID(ShohinIDTxb.Text).Msg);
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
            }*/

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
            int EmID = EmployeeDA.GetEmID(ShainNameTxb.Text);
            int CIID = ClientDA.GetCIID(KokyakuNameTxb.Text);

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
                EmID = EmID,
                ClID = CIID,
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
        //メソッド名：RegistEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した受注情報を登録する
        ///////////////////////////////
        private void RegistOrder(T_Order order, T_OrderDetail orderdetail)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M6024"))
            {
                if (OrderDA.RegistOrder(order))
                {
                    if(OrderDetailDA.RegistOrderDetail(orderdetail))
                    {
                        MessageDsp.DspMsg("M6025");

                        //コントロールの初期設定
                        SetCtrlFormat();

                        //データグリッドビューの設定
                        SetFormJuchuKanriGridView();
                    }
                }
                else
                {
                    MessageDsp.DspMsg("M6026");
                }
            }
        }

        private void ShainKanriDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JuchuIDTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            JuchuDateDtm.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            ShainNameTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            KokyakuNameTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            KokyakuTantoNameTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            EigyoushoNameCmb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            ShohinIDTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[6].Value.ToString();
            SuryoTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[7].Value.ToString();
            GokeiKingakuTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            //受注状態フラグを日本語に変換
            if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[9].Value == 0)
            {
                JuchuJotaiFlagCmb.Text = "未確定";
            }
            else if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[9].Value == 1)
            {
                JuchuJotaiFlagCmb.Text = "確定";
            }
            //受注管理フラグを日本語に変換
            if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[10].Value == 0)
            {
                JuchuKanriFlagCmb.Text = "表示";
            }
            else if ((int)JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[10].Value == 2)
            {
                JuchuKanriFlagCmb.Text = "非表示";
            }

            if (JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[11].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = JuchuKanriDgv.Rows[JuchuKanriDgv.CurrentRow.Index].Cells[11].Value.ToString();
            }
        }
    }
}
