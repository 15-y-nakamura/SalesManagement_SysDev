using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalesManagement_SysDev
{
    public partial class Kokyakukanri : Form
    {
        //社員テーブルアクセスクラスのインスタンス化
        EmployeeDataAccess EmployeeDA = new EmployeeDataAccess();

        //顧客テーブルアクセスのクラスのインスタンス化
        ClientDataAccess ClientDA = new ClientDataAccess();

        //役職テーブルアクセスクラスのインスタンス化
        PositionDataAccess PositionDA = new PositionDataAccess();

        //営業所テーブルアクセスクラスのインスタンス化
        SalesOfficeDataAccess SalesOfficeDA = new SalesOfficeDataAccess();

        //データグリッドビュー用のスタッフデータ
        private static List<M_EmployeeDsp> Employee;

        //メッセージ表示クラスインスタンス化
        MessageDsp MessageDsp = new MessageDsp();

        //入力チェッククラスインスタンス化
        InputCheck InputCheck = new InputCheck();

        //データグリッドビュー用の顧客データ
        private static List<M_ClientDsp> Client;


        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;
        internal static string Logindate = "";

        public Kokyakukanri()
        {

            InitializeComponent();


        }
        private void Kokyakukanri_Load(object sender, EventArgs e)
        {
            PlaceHolderText();

            string[] TopData = new string[4];
            TopData = empDataAccess.GetTopData(EmID);

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

                //PlaceHolderText();

                //コントロールの初期設定
                SetCtrlFormat();

                //データグリッドビューの設定
                SetFormKokyakukanriGridView();

            }


        }

        //テキストボックス内に灰色の文字を表示
        private void PlaceHolderText()
        {
            YubinHaiiroLbl.Text = "ハイフンなし";
            YubinHaiiroLbl.ForeColor = Color.Gray;
            YubinHaiiroLbl.BackColor = Color.White;
            YubinTxb.Enter += YubinTxb_Enter;
            YubinTxb.Leave += YubinTxb_Leave;


            TelHaiiroLbl.Text = "ハイフンあり";
            TelHaiiroLbl.ForeColor = Color.Gray;
            TelHaiiroLbl.BackColor = Color.White;
            TelTxb.Enter += TelTxb_Enter;
            TelTxb.Leave += TelTxb_Leave;

            FaxHaiiroLbl.Text = "ハイフンあり";
            FaxHaiiroLbl.ForeColor = Color.Gray;
            FaxHaiiroLbl.BackColor = Color.White;
            FaxTxb.Enter += FaxTxb_Enter;
            FaxTxb.Leave += FaxTxb_Leave;
        }

        //郵便番号のテキストボックスが選択されている場合
        private void YubinTxb_Enter(object sender, EventArgs e)
        {
            if (YubinHaiiroLbl.Text == "ハイフンなし")
            {
                YubinHaiiroLbl.Text = "";
                YubinHaiiroLbl.ForeColor = SystemColors.WindowText;
            }
        }

        //郵便番号のテキストボックスが選択されていない・入力されていない場合
        private void YubinTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(YubinTxb.Text))
            {
                YubinHaiiroLbl.Text = "ハイフンなし";
                YubinHaiiroLbl.ForeColor = SystemColors.GrayText;
            }
        }


        //電話番号のテキストボックスが選択されている場合
        private void TelTxb_Enter(object sender, EventArgs e)
        {
            if (TelHaiiroLbl.Text == "ハイフンあり")
            {
                TelHaiiroLbl.Text = "";
                TelHaiiroLbl.ForeColor = SystemColors.WindowText;
            }
        }

        //電話番号のテキストボックスが選択されていない・入力されていない場合
        private void TelTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TelTxb.Text))
            {
                TelHaiiroLbl.Text = "ハイフンあり";
                TelHaiiroLbl.ForeColor = Color.Gray;
            }
        }

        //FAXのテキストボックスが選択されている場合
        private void FaxTxb_Enter(object sender, EventArgs e)
        {
            if (FaxHaiiroLbl.Text == "ハイフンあり")
            {
                FaxHaiiroLbl.Text = "";
                FaxHaiiroLbl.ForeColor = SystemColors.WindowText;
            }
        }

        //FAXのテキストボックスが選択されていない・入力されていない場合
        private void FaxTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FaxTxb.Text))
            {
                FaxHaiiroLbl.Text = "ハイフンあり";
                FaxHaiiroLbl.ForeColor = SystemColors.GrayText;
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
            KokyakuIDTxb.Text = "";
            KokyakuNameTxb.Text = "";
            EigyoshoNameCmb.Items.Clear();
            EigyoshoNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            YubinTxb.Text = "";
            JushoTxb.Text = "";
            TelTxb.Text = "";
            FaxTxb.Text = "";
            KokyakuKanriFlagCmb.Items.Clear();
            KokyakuKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            HihyojiTxb.Text = "";

            //営業所名を取得
            var SoName = SalesOfficeDA.GetSoName();

            //営業所名をコンボボックスに追加
            foreach (string Soname in SoName.Reverse())
            {
                EigyoshoNameCmb.Items.Add(Soname);
            }

            KokyakuKanriFlagCmb.Items.Add("表示");
            KokyakuKanriFlagCmb.Items.Add("非表示");

            PlaceHolderText();

        }

        private void SetFormKokyakukanriGridView()
        {
            //読み取り専用に指定
            KokyakuKanriDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            KokyakuKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            KokyakuKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListDisplay();
        }

        private void ListDisplay()
        {
            // スタッフデータの取得
            Client = ClientDA.GetClientData();

            // DataGridViewに表示するデータを指定
            SetDataGridView(Client);
        }

        private void SetDataGridView(List<M_ClientDsp> Client)
        {
            KokyakuKanriDgv.DataSource = Client.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            KokyakuKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //行の高さ設定
            //KokyakuKanriDgv.RowTemplate.Height = 40;

            //各列の文字位置の指定
            KokyakuKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            KokyakuKanriDgv.Refresh();

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

        private void TopButsuryuBtn_Click_1(object sender, EventArgs e)
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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!InputUpdataDataCheck())
            {
                return;
            }

            var updatedata = SetClientUpdateData();

            UpdateClient(updatedata);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult result = messageDsp.DspMsg("M0004");

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

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!InputRegistDataCheck())
            {
                return;
            }

            //形式化
            var clidata = SetClientData();

            //登録
            RegistClient(clidata);
        }

        private bool InputRegistDataCheck()
        {
            /*顧客IDの入力チェック
            if (!InputCheck.CheckRegistClID(KokyakuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistClID(KokyakuIDTxb.Text).Msg);
                KokyakuIDTxb.Focus();
                return false;
            }*/

            //顧客名の入力チェック
            if (!InputCheck.CheckClname(KokyakuNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClname(KokyakuNameTxb.Text).Msg);
                KokyakuNameTxb.Focus();
                return false;
            }

            //営業所名の入力チェック
            if (!InputCheck.CheckSoNameEiCmb(EigyoshoNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckSoNameEiCmb(EigyoshoNameCmb.Text).Msg);
                return false;
            }

            //電話番号の入力チェック
            if (!InputCheck.CheckClPhone(TelTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClPhone(TelTxb.Text).Msg);
                TelTxb.Focus();
                return false;
            }

            //郵便番号の入力チェック
            if (!InputCheck.CheckClYubin(YubinTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClYubin(YubinTxb.Text).Msg);
                YubinTxb.Focus();
                return false;
            }

            //住所の入力チェック
            if (!InputCheck.CheckClJusho(JushoTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClJusho(JushoTxb.Text).Msg);
                JushoTxb.Focus();
                return false;
            }

            //FAXの入力チェック
            if (!InputCheck.CheckClFax(FaxTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClFax(FaxTxb.Text).Msg);
                FaxTxb.Focus();
                return false;
            }

            return true;
        }


        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：M_Client
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Client SetClientData()
        {
            int SoID = SalesOfficeDA.GetSoID(EigyoshoNameCmb.Text);
            int ClFlg;

            if (KokyakuKanriFlagCmb.Text == "非表示")
            {
                ClFlg = 2;
            }
            else
            {
                ClFlg = 0;
            }

            return new M_Client
            {
                //ClID = int.Parse(KokyakuIDTxb.Text),
                ClName = KokyakuNameTxb.Text,
                SoID = SoID,
                ClPhone = TelTxb.Text,
                ClPostal = YubinTxb.Text,
                ClAddress = JushoTxb.Text,
                ClFAX = FaxTxb.Text,
                ClFlag = ClFlg,
                ClHidden = HihyojiTxb.Text
            };
        }

        ///////////////////////////////
        //メソッド名：RegistClient()
        //引　数   ：M_Client
        //戻り値   ：なし
        //機　能   ：形式化した顧客情報を登録する
        ///////////////////////////////
        private void RegistClient(M_Client cli)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M1021"))
            {
                if (ClientDA.RegistClient(cli))
                {
                    MessageDsp.DspMsg("M1022");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormKokyakukanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M1023");
                }
            }
        }

        private bool InputUpdataDataCheck()
        {
            //顧客IDの入力チェック
            if (!InputCheck.CheckClID(KokyakuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClID(KokyakuIDTxb.Text).Msg);
                KokyakuIDTxb.Focus();
                return false;
            }

            //顧客名の入力チェック
            if (!InputCheck.CheckClname(KokyakuNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClname(KokyakuNameTxb.Text).Msg);
                KokyakuNameTxb.Focus();
                return false;
            }

            //電話番号の入力チェック
            if (!InputCheck.CheckClPhone(TelTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClPhone(TelTxb.Text).Msg);
                TelTxb.Focus();
                return false;
            }

            //営業所名の入力チェック
            if (!InputCheck.CheckSoNameCmb(EigyoshoNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckSoNameCmb(EigyoshoNameCmb.Text).Msg);
                return false;
            }

            //郵便番号の入力チェック
            if (!InputCheck.CheckClYubin(YubinTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClYubin(YubinTxb.Text).Msg);
                YubinTxb.Focus();
                return false;
            }

            //住所の入力チェック
            if (!InputCheck.CheckClJusho(JushoTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClJusho(JushoTxb.Text).Msg);
                JushoTxb.Focus();
                return false;
            }

            //FAXの入力チェック
            if (!InputCheck.CheckClFax(FaxTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClFax(FaxTxb.Text).Msg);
                FaxTxb.Focus();
                return false;
            }

            //非表示理由の入力チェック
            if (KokyakuKanriFlagCmb.Text == "非表示")
            {
                if (!InputCheck.CheckHidden(HihyojiTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckHidden(HihyojiTxb.Text).Msg);
                    return false;
                }
            }
            return true;
        }

        private M_Client SetClientUpdateData()
        {
            int SoID = SalesOfficeDA.GetSoID(EigyoshoNameCmb.Text);
            int ClFlg;

            if (KokyakuKanriFlagCmb.Text == "非表示")
            {
                ClFlg = 2;
            }
            else
            {
                ClFlg = 0;
            }

            return new M_Client
            {
                ClID = int.Parse(KokyakuIDTxb.Text),
                ClName = KokyakuNameTxb.Text,
                SoID = SoID,
                ClPhone = TelTxb.Text,
                ClPostal = YubinTxb.Text,
                ClAddress = JushoTxb.Text,
                ClFAX = FaxTxb.Text,
                ClFlag = ClFlg,
                ClHidden = HihyojiTxb.Text
            };
        }

        private void UpdateClient(M_Client cli)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M1026"))
            {
                if (ClientDA.UpdateClient(cli))
                {
                    MessageDsp.DspMsg("M1027");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormKokyakukanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M1028");
                }
            }
        }

        private void KokyakuKanriDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //クリックされた行データをテキストボックスへ
            KokyakuIDTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            KokyakuNameTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            EigyoshoNameCmb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            TelTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            YubinTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            JushoTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            FaxTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[6].Value.ToString();
            //顧客管理フラグを日本語に変換
            if ((int)KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[7].Value == 0)
            {
                KokyakuKanriFlagCmb.Text = "表示";
            }
            else if ((int)KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[7].Value == 2)
            {
                KokyakuKanriFlagCmb.Text = "非表示";
            }

            if (KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[8].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = KokyakuKanriDgv.Rows[KokyakuKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            }

            if (TelHaiiroLbl.Text == "ハイフンあり")
            {
                TelHaiiroLbl.Text = "";
                TelHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

            if (FaxHaiiroLbl.Text == "ハイフンあり")
            {
                FaxHaiiroLbl.Text = "";
                FaxHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

            if (YubinHaiiroLbl.Text == "ハイフンなし")
            {
                YubinHaiiroLbl.Text = "";
                YubinHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void TelTxb_Click(object sender, EventArgs e)
        {
            if (TelHaiiroLbl.Text == "ハイフンあり")
            {
                TelHaiiroLbl.Text = "";
                TelHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void TelHaiiroLbl_Click(object sender, EventArgs e)
        {
            TelTxb.Focus();
            if (TelHaiiroLbl.Text == "ハイフンあり")
            {
                TelHaiiroLbl.Text = "";
                TelHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void TelHaiiroLbl_MouseMove(object sender, MouseEventArgs e)
        {
            TelHaiiroLbl.Cursor = Cursors.IBeam;
        }

        private void FaxTxb_Click(object sender, EventArgs e)
        {
            if (FaxHaiiroLbl.Text == "ハイフンあり")
            {
                FaxHaiiroLbl.Text = "";
                FaxHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void FaxHaiiroLbl_Click(object sender, EventArgs e)
        {
            FaxTxb.Focus();
            if (FaxHaiiroLbl.Text == "ハイフンあり")
            {
                FaxHaiiroLbl.Text = "";
                FaxHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void FaxHaiiroLbl_MouseMove(object sender, MouseEventArgs e)
        {
            FaxHaiiroLbl.Cursor = Cursors.IBeam;
        }

        private void YubinTxb_Click(object sender, EventArgs e)
        {
            if (YubinHaiiroLbl.Text == "ハイフンなし")
            {
                YubinHaiiroLbl.Text = "";
                YubinHaiiroLbl.ForeColor = SystemColors.WindowText;
            }
        }

        private void YubinHaiiroLbl_Click(object sender, EventArgs e)
        {
            YubinTxb.Focus();
            if (YubinHaiiroLbl.Text == "ハイフンなし")
            {
                YubinHaiiroLbl.Text = "";
                YubinHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

        }

        private void YubinHaiiroLbl_MouseMove(object sender, MouseEventArgs e)
        {
            YubinHaiiroLbl.Cursor = Cursors.IBeam;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!InputSearchDataCheck())
            {
                return;
            }

            var searchdata = SetClientSearchData();

            SearchClient(searchdata);

        }

        private bool InputSearchDataCheck()
        {
            //顧客IDの入力チェック
            if (KokyakuIDTxb.Text != "")
            {
                if (!InputCheck.CheckSearchClID(KokyakuIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchClID(KokyakuIDTxb.Text).Msg);
                    return false;
                }
            }

            //顧客名の入力チェック
            if (KokyakuNameTxb.Text != "")
            {
                if (!InputCheck.CheckSearchClname(KokyakuNameTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchClname(KokyakuNameTxb.Text).Msg);
                    return false;
                }
            }

            //電話番号の入力チェック
            if (TelTxb.Text != "")
            {
                if (!InputCheck.CheckSearchClPhone(TelTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckSearchClPhone(TelTxb.Text).Msg);
                    return false;
                }
            }

            return true;
        }

        private M_Client SetClientSearchData()
        {
            int clid = 0;
            int soid = 0;
            int clflg = -1;

            if (KokyakuIDTxb.Text != "")
            {
                clid = int.Parse(KokyakuIDTxb.Text);
            }


            if (EigyoshoNameCmb.Text != "")
            {
                soid = SalesOfficeDA.GetSoID(EigyoshoNameCmb.Text);
            }


            if (KokyakuKanriFlagCmb.Text != "")
            {
                if (KokyakuKanriFlagCmb.Text == "非表示")
                {
                    clflg = 2;
                }
                else
                {
                    clflg = 0;
                }
            }


            M_Client M_Cli = new M_Client()
            {
                ClID = clid,
                ClName = KokyakuNameTxb.Text,
                SoID = soid,
                ClPhone = TelTxb.Text,
                ClPostal = YubinTxb.Text,
                ClAddress = JushoTxb.Text,
                ClFAX = FaxTxb.Text,
                ClFlag = clflg,
                ClHidden = HihyojiTxb.Text
            };

            return M_Cli;
        }

        private void SearchClient(M_Client searchcli)
        {
            var cli = ClientDA.SearchClient(searchcli);

            SetDataGridView(cli);
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
            var cli = SetClientHideenData();

            //更新
            HiddenClient(cli);

        }

        private void GamenKousinBtn_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();

            SetFormKokyakukanriGridView();
        }

        private bool InputHiddenDataCheck()
        {
            //顧客IDチェック
            if (!InputCheck.CheckClID(KokyakuIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckClID(KokyakuIDTxb.Text).Msg);
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

        private M_Client SetClientHideenData()
        {
            M_Client M_Cli = new M_Client()
            {
                ClID = int.Parse(KokyakuIDTxb.Text),
                ClFlag = 2,
                ClHidden = HihyojiTxb.Text
            };

            return M_Cli;
        }

        private void HiddenClient(M_Client cli)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M1029"))
            {
                if (ClientDA.DeleteClient(cli))
                {
                    MessageDsp.DspMsg("M1030");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormKokyakukanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M1031");
                }
            }
        }


    }

}