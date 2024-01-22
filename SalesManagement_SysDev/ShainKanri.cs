using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class Shainkanri : Form
    {
        //社員テーブルアクセスクラスのインスタンス化
        EmployeeDataAccess EmployeeDA = new EmployeeDataAccess();

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


        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();

        //他のフォームからログイン情報をもらうための変数
        internal static int EmID = 0;
        internal static int PoID = 0;
        internal static string Logindate = "";

        public Shainkanri()
        {

            InitializeComponent();
        }

        private void Shainkanri_Load(object sender, EventArgs e)
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

            TopHonshaBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
            TopHonshaBtn.FlatAppearance.BorderSize = 2;
            TopHonshaBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            TopEigyoBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
            TopEigyoBtn.FlatAppearance.BorderSize = 2;
            TopEigyoBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            TopButsuryuBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 241, 251);
            TopButsuryuBtn.FlatAppearance.BorderSize = 2;
            TopButsuryuBtn.FlatAppearance.BorderColor = Color.SteelBlue;


            PlaceHolderText();

            //コントロールの初期設定
            SetCtrlFormat();

            //データグリッドビューの設定

            SetFormGridView();

            //SetFormSyainKanriGridView();

            UpdateBtn.Enabled = false;
            HiddenBtn.Enabled = false;

        }

        ///////////////////////////////
        //メソッド名：SetCtrlFormat()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：コントロールの初期設定
        ///////////////////////////////
        private void SetCtrlFormat()
        {
            ShainIDTxb.Text = "";
            ShainNameTxb.Text = "";
            EigyoushoNameCmb.Items.Clear();
            EigyoushoNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            TelTxb.Text = "";
            YakushokuNameCmb.Items.Clear();
            YakushokuNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShainKanriFlagCmb.Items.Clear();
            ShainKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            HihyojiTxb.Text = "";
            JoinDateDtm.Checked = false;

            //役職名を取得
            var PoName = PositionDA.GetPoName();

            //役職名をコンボボックスに追加
            foreach (string Poname in PoName.Reverse())
            {
                YakushokuNameCmb.Items.Add(Poname);
            }

            //営業所名を取得
            var SoName = SalesOfficeDA.GetSoName();
            //営業所名をコンボボックスに追加
            foreach (string Soname in SoName.Reverse())
            {
                EigyoushoNameCmb.Items.Add(Soname);
            }

            ShainKanriFlagCmb.Items.Add("表示");
            ShainKanriFlagCmb.Items.Add("非表示");

            ShainIDTxb.Enabled = true;
            UpdateBtn.Enabled = false;
            HiddenBtn.Enabled = false;

        }


        //テキストボックス内に灰色の文字を表示
        private void PlaceHolderText()
        {
            TelHaiiroLbl.Text = "ハイフンあり";
            TelHaiiroLbl.ForeColor = Color.Gray;
            TelHaiiroLbl.BackColor = Color.White;
            TelTxb.Enter += TelTxb_Enter;
            TelTxb.Leave += TelTxb_Leave;
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

        ///////////////////////////////
        //メソッド名：SetFormSyainKanriGridView()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの設定
        ///////////////////////////////
        private void SetFormGridView()
        {
            //読み取り専用に指定
            ShainKanriDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            ShainKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            ShainKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListDisplay();
        }

        ///////////////////////////////
        //メソッド名：ListDisplay()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：データグリッドビューの表示
        ///////////////////////////////
        private void ListDisplay()
        {
            // スタッフデータの取得
            Employee = EmployeeDA.GetEmployeeData();

            // DataGridViewに表示するデータを指定
            SetDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：M_EmployeeDsp
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetDataGridView()
        {
            ShainKanriDgv.DataSource = Employee.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ShainKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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


            //各列の文字位置の指定
            ShainKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            
            ShainKanriDgv.Refresh();
        }

        //登録ボタンクリック
        private void RegistBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!InputRegistDataCheck())
            {
                return;
            }

            //形式化
            var empdata = SetEmployeeRegistData();

            //登録
            RegistEmployee(empdata);
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：社員登録時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputRegistDataCheck()
        {
            //社員IDの入力チェック
            if (!InputCheck.CheckRegistEmID(ShainIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckRegistEmID(ShainIDTxb.Text).Msg);
                ShainIDTxb.Focus();
                return false;
            }

            //社員名の入力チェック
            if (!InputCheck.CheckEmname(ShainNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmname(ShainNameTxb.Text).Msg);
                ShainNameTxb.Focus();
                return false;
            }

            //営業所名の入力チェック
            if (!InputCheck.CheckSoNameCmb(EigyoushoNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckSoNameCmb(EigyoushoNameCmb.Text).Msg);
                return false;
            }

            //電話番号の入力チェック
            if (!InputCheck.CheckEmPhone(TelTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmPhone(TelTxb.Text).Msg);
                TelTxb.Focus();
                return false;
            } 

            //役職名の入力チェック
            if (!InputCheck.CheckPoNameCmb(YakushokuNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPoNameCmb(YakushokuNameCmb.Text).Msg);
                return false;
            }

            //入社年月日の入力チェック
            if (!JoinDateDtm.Checked)
            {
                MessageDsp.DspMsg("M4010");
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：SetEmployeeData()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Employee SetEmployeeRegistData()
        {
            int PoID = PositionDA.GetPoID(YakushokuNameCmb.Text);
            int SoID = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            int EmFlg;

            if (ShainKanriFlagCmb.Text == "非表示")
            {
                EmFlg = 2;
            }
            else
            {
                EmFlg = 0;
            }

            //var rmd = new Random();
            //var firstpass = rmd.Next(1000, 9999);

            return new M_Employee
            {
                EmID = int.Parse(ShainIDTxb.Text),
                EmName = ShainNameTxb.Text,
                PoID = PoID,
                SoID = SoID,
                EmHiredate = JoinDateDtm.Value,
                EmPassword = ShainIDTxb.Text.ToString(),
                EmPhone = TelTxb.Text,
                EmFlag = EmFlg,
                EmHidden = HihyojiTxb.Text,
                FirstPass = ShainIDTxb.Text.ToString()
            };
        }

        ///////////////////////////////
        //メソッド名：RegistEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を登録する
        ///////////////////////////////
        private void RegistEmployee(M_Employee emp)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M4019"))
            {
                if (EmployeeDA.RegistEmployee(emp))
                {
                    MessageDsp.DspMsg("M4020");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M4021");
                }
            }
        }

        //データグリットビュー内のセルをクリック
        private void ShainKanriDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ShainKanriDgv.Rows.Count == 0)
            {
                return;
            }

            ShainIDTxb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            ShainNameTxb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            EigyoushoNameCmb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[2].Value.ToString();
            YakushokuNameCmb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[3].Value.ToString();
            JoinDateDtm.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            TelTxb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            //社員管理フラグを日本語に変換
            if ((int)ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[6].Value == 0)
            {
                ShainKanriFlagCmb.Text = "表示";
            }
            else if ((int)ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[6].Value == 2)
            {
                ShainKanriFlagCmb.Text = "非表示";
            }

            if (ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[7].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = ShainKanriDgv.Rows[ShainKanriDgv.CurrentRow.Index].Cells[7].Value.ToString();
            }

            if (TelHaiiroLbl.Text == "ハイフンあり")
            {
                TelHaiiroLbl.Text = "";
                TelHaiiroLbl.ForeColor = SystemColors.WindowText;
            }

            ShainIDTxb.Enabled = false;
            UpdateBtn.Enabled = true;
            HiddenBtn.Enabled = true;

        }

        //更新ボタンクリック
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (!InputUpdataDataCheck())
            {
                return;
            }

            var updatedata = SetEmployeeUpdateData();

            UpdateEmployee(updatedata);
        }

        ///////////////////////////////
        //メソッド名：InputUpdataDataCheck()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：社員更新時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputUpdataDataCheck()
        {
            //社員IDの入力チェック
            if (!InputCheck.CheckEmID(ShainIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmID(ShainIDTxb.Text).Msg);
                return false;
            }

            //社員名の入力チェック
            if (!InputCheck.CheckEmname(ShainNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmname(ShainNameTxb.Text).Msg);
                return false;
            }

            //電話番号の入力チェック
            if (!InputCheck.CheckEmPhone(TelTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmPhone(TelTxb.Text).Msg);
                return false;
            }

            //営業所名の入力チェック
            if (!InputCheck.CheckSoNameCmb(EigyoushoNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckSoNameCmb(EigyoushoNameCmb.Text).Msg);
                return false;
            }

            //役職名の入力チェック
            if (!InputCheck.CheckPoNameCmb(YakushokuNameCmb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckPoNameCmb(YakushokuNameCmb.Text).Msg);
                return false;
            }

            //非表示理由の入力チェック
            if (ShainKanriFlagCmb.Text == "非表示")
            {
                if (!InputCheck.CheckHidden(HihyojiTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckHidden(HihyojiTxb.Text).Msg);
                    return false;
                }
            }
            
            //入社年月日の入力チェック
            if (!JoinDateDtm.Checked)
            {
                MessageDsp.DspMsg("M4010");
                return false;
            }
            return true;
        }

        ///////////////////////////////
        //メソッド名：SetEmployeeUpdateData()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Employee SetEmployeeUpdateData()
        {
            int PoID = PositionDA.GetPoID(YakushokuNameCmb.Text);
            int SoID = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            int EmFlg;

            if (ShainKanriFlagCmb.Text == "非表示")
            {
                EmFlg = 2;
            }
            else
            {
                EmFlg = 0;
            }

            return new M_Employee
            {
                EmID = int.Parse(ShainIDTxb.Text),
                EmName = ShainNameTxb.Text,
                PoID = PoID,
                SoID = SoID,
                EmHiredate = JoinDateDtm.Value,
                EmPhone = TelTxb.Text,
                EmFlag = EmFlg,
                EmHidden = HihyojiTxb.Text
            };
        }

        ///////////////////////////////
        //メソッド名：UpdateEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を更新する
        ///////////////////////////////
        private void UpdateEmployee(M_Employee emp)
        {
            if(DialogResult.OK == MessageDsp.DspMsg("M4024"))
            {
                if (EmployeeDA.UpdateEmployee(emp))
                {
                    MessageDsp.DspMsg("M4025");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M4026");
                }
            }
        }

        //電話番号テキストボックスクリック
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
        
        //検索ボタンクリック
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (!InputSearchDataCheck())
            {
                return;
            }

            var searchdata = SetEmployeeSearchData();

            SearchEmployee(searchdata);
        }

        ///////////////////////////////
        //メソッド名：InputSearchDataCheck()
        //引　数   ：なし
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：社員検索時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputSearchDataCheck()
        {
            //社員IDの入力チェック
            if (ShainIDTxb.Text != "")
            {
                if (!InputCheck.CheckSearchEmID(ShainIDTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckEmID(ShainIDTxb.Text).Msg);
                    return false;
                }
            }

            //社員名の入力チェック
            if (ShainNameTxb.Text != "")
            {
                if (!InputCheck.CheckSearchEmname(ShainNameTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckEmname(ShainNameTxb.Text).Msg);
                    return false;
                }
            }

            //電話番号の入力チェック
            if (TelTxb.Text != "")
            {
                if (!InputCheck.CheckSearchEmPhone(TelTxb.Text).flg)
                {
                    MessageDsp.DspMsg(InputCheck.CheckEmPhone(TelTxb.Text).Msg);
                    return false;
                }
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：SetEmployeeSearchData()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Employee SetEmployeeSearchData()
        {
            int poid = 0;
            int emid = -1;
            int soid = 0;
            int emflg = -1;
            DateTime date = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (ShainIDTxb.Text != "")
            {
                emid = int.Parse(ShainIDTxb.Text);
            }
            
            if (YakushokuNameCmb.Text != "")
            { 
                poid = PositionDA.GetPoID(YakushokuNameCmb.Text);
            }           
            
            if(EigyoushoNameCmb.Text != "")
            {
                soid = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            }
            

            if(ShainKanriFlagCmb.Text != "")
            {
                if (ShainKanriFlagCmb.Text == "非表示")
                {
                    emflg = 2;
                }
                else
                {
                    emflg = 0;
                }    
            }
            
            if (JoinDateDtm.Checked)
            {
                date = JoinDateDtm.Value.Date;
            }

            M_Employee M_Emp = new M_Employee()
            {
                EmID = emid,
                EmName = ShainNameTxb.Text,
                SoID = soid,
                PoID = poid,
                EmHiredate = date,
                EmPhone = TelTxb.Text,
                EmFlag = emflg,
                EmHidden = HihyojiTxb.Text
            };

            return M_Emp;
        }

        ///////////////////////////////
        //メソッド名：SearchEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を検索、表示する
        ///////////////////////////////
        private void SearchEmployee(M_Employee searchemp)
        {
            Employee = EmployeeDA.SearchEmployee(searchemp);

            if(Employee.Count == 0)
            { 
                MessageDsp.DspMsg("M4018");
            }

            SetDataGridView();
        }

        //画面更新ボタンクリック
        private void GamenKousinBtn_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();
            SetFormGridView();

            //SetFormSyainKanriGridView();
            ShainIDTxb.Enabled = true;
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
            var emp =　SetEmployeeHideenData();

            //更新
            HiddenEmployee(emp);

        }

        ///////////////////////////////
        //メソッド名：InputHiddenDataCheck()
        //引　数   ：なし
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：社員非表示時の入力チェック項目の妥当性をチェックする
        ///////////////////////////////
        private bool InputHiddenDataCheck()
        {
            //社員IDチェック
            if (!InputCheck.CheckEmID(ShainIDTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckEmID(ShainIDTxb.Text).Msg);
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
        //メソッド名：SetEmployeeHideenData()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Employee SetEmployeeHideenData()
        {
            M_Employee M_Emp = new M_Employee()
            {
                EmID = int.Parse(ShainIDTxb.Text),
                EmFlag = 2,
                EmHidden = HihyojiTxb.Text
            };

            return M_Emp;
        }

        ///////////////////////////////
        //メソッド名：HiddenEmployee()
        //引　数   ：M_Employee
        //戻り値   ：なし
        //機　能   ：形式化した社員情報を非表示設定に更新する
        ///////////////////////////////
        private void HiddenEmployee(M_Employee emp)
        {
            if (DialogResult.OK == MessageDsp.DspMsg("M4027"))
            {
                if (EmployeeDA.DeleteEmployee(emp))
                {
                    MessageDsp.DspMsg("M4028");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M4029");
                }
            }
        }
    }
}

