using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        InputCheck inputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;

        public Shainkanri()
        {

            InitializeComponent();
        }

        private void Shainkanri_Load(object sender, EventArgs e)
        {
            //PlaceHolderText();

            //コントロールの初期設定
            SetCtrlFormat();

            //データグリッドビューの設定
            SetFormSyainKanriGridView();
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
            YakushokuNameTxb.Items.Clear();
            YakushokuNameTxb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShainKanriFlagCmb.Items.Clear();
            ShainKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            HihyojiTxb.Text = "";

            //役職名を取得
            var PoName = PositionDA.GetPoName();

            //役職名をコンボボックスに追加
            foreach (string Poname in PoName.Reverse())
            {
                YakushokuNameTxb.Items.Add(Poname);
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
        }

        /*private void PlaceHolderText(){
            PlaceHolderText();

            string[] TopData = new string[4];
            TopData = empDataAccess.GetTopData(EmID);

            string emID = EmID.ToString();

            TopIDLbl.Text = emID;
            TopNameLbl.Text = TopData[0];
            TopYakushokuLbl.Text = TopData[1];
            TopEigyoshoLbl.Text = TopData[2];
            TopJikanLbl.Text = TopData[3];

            TopHonshaBtn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            TopHonshaBtn.FlatAppearance.BorderSize = 1;
            TopHonshaBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            TopEigyoBtn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            TopEigyoBtn.FlatAppearance.BorderSize = 2;
            TopEigyoBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            TopButsuryuBtn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
            TopButsuryuBtn.FlatAppearance.BorderSize = 2;
            TopButsuryuBtn.FlatAppearance.BorderColor = Color.SteelBlue;


        }

        //テキストボックス内に灰色の文字を表示
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
        private void SetFormSyainKanriGridView()
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
        //メソッド名：GetDataGridView()
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
        //引　数   ：なし
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

            //行の高さ設定
            ShainKanriDgv.RowTemplate.Height = 40;

            //各列の文字位置の指定
            ShainKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShainKanriDgv.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ShainKanriDgv.Refresh();

        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            //入力チェック
            if (!InputRegistDataCheck())
            {
                return;
            }    
            
            //形式化
            var empdata = SetEmployeeData();

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
            if (!InputCheck.CheckPoNameCmb(YakushokuNameTxb.Text).flg)
            {
                MessageDsp.DspMsg(InputCheck.CheckSoNameCmb(YakushokuNameTxb.Text).Msg);
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //メソッド名：InputRegistDataCheck()
        //引　数   ：なし
        //戻り値   ：M_Employee
        //機　能   ：社員情報を形式化する
        ///////////////////////////////
        private M_Employee SetEmployeeData()
        {
            int PoID = PositionDA.GetPoID(YakushokuNameTxb.Text);
            int SoID = SalesOfficeDA.GetSoID(EigyoushoNameCmb.Text);
            int EmFlg;

            if(ShainKanriFlagCmb.Text == "非表示")
            {
                EmFlg = 2;
            }
            else
            {
                EmFlg = 0;
            }

            var rmd = new Random();
            var firstpass =  rmd.Next(1000, 9999);

            return new M_Employee
            {
                EmID = int.Parse(ShainIDTxb.Text),
                EmName = ShainNameTxb.Text,
                PoID = PoID,
                SoID = SoID,
                EmHiredate = JoinDateDtm.Value,
                EmPassword = firstpass.ToString(),
                EmPhone = TelTxb.Text,
                EmFlag = EmFlg,
                EmHidden = HihyojiTxb.Text
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
                    SetFormSyainKanriGridView();
                }
                else
                {
                    MessageDsp.DspMsg("M4021");
                }
            }
        }
    }
}
