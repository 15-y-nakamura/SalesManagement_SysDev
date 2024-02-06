using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SalesManagement_SysDev
{
    public partial class ShukkoKanri : Form
    {
        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        SalesOfficeDataAccess soDataAccess = new SalesOfficeDataAccess();
        SyukkoDataAccess syDataAccess = new SyukkoDataAccess();
        SyukkoDetailDataAccess sydDataAccess = new SyukkoDetailDataAccess();
        InputCheck inputCheck = new InputCheck();

        private static List<T_SyukkoDsp> Syukko;
        private static List<T_SyukkoDetailDsp> SyukkoDetail;

        internal static int PoID = 0;
        internal static int EmID = 0;
        internal static string Logindate;
        public ShukkoKanri()
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
            TopButsuryuPage.Logindate= Logindate;

            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            TopButsuryuPage f2 = new TopButsuryuPage();
            f2.Show();
        }

        private void ShukkoKanri_Load(object sender, EventArgs e)
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

            SetCtrlFormat();

            SetFormGridView();
        }

        private void SetCtrlFormat()
        {
            ShukkoIDTxb.Text = "";
            JuchuIDTxb.Text = "";
            EigyoushoNameCmb.Items.Clear();
            EigyoushoNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShainIDTxb.Text = "";
            //ShainName.Text = "--";
            KokyakuIDTxb.Text = "";
            //KokyakuName.Text = "--";
            JuchuIDTxb.Text = "";
            ShohinIDTxb.Text = "";
            //ShohinName.Text = "--";
            SuryoTxb.Text = "";
            ShukkoDateDtm.Checked = false;
            ShukkoJotaiFlagCmb.Items.Clear();
            ShukkoJotaiFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShukkoJotaiFlagCmb.Items.Add("処理受付");
            ShukkoJotaiFlagCmb.Items.Add("処理確定");
            KokyakuKanriFlagCmb.Items.Clear();
            KokyakuKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            KokyakuKanriFlagCmb.Items.Add("表示");
            KokyakuKanriFlagCmb.Items.Add("非表示");
            HihyojiTxb.Text = "";
            ComfirmBtn.Enabled = false;
            HiddenBtn.Enabled = false;

            //営業所名を取得
            var SoName = soDataAccess.GetSoName();
            //営業所名をコンボボックスに追加
            foreach (string Soname in SoName.Reverse())
            {
                EigyoushoNameCmb.Items.Add(Soname);
            }
        }

        private void SetFormGridView()
        {
            //読み取り専用に指定
            ShukkoKanriDgv.ReadOnly = true;
            ShukkoDetailDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            ShukkoKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ShukkoDetailDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            ShukkoKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ShukkoDetailDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //データグリッドビューのデータ取得
            ListDisplay();
        }

        private void ListDisplay()
        {
            // スタッフデータの取得
            Syukko = syDataAccess.GetAllSyukkoData();
            SyukkoDetail = sydDataAccess.GetAllSyukkoDetailData();

            // DataGridViewに表示するデータを指定
            SetchDataGridView();
            SetchdDataGridView();
        }

        private void SetchDataGridView()
        {
            ShukkoKanriDgv.DataSource = Syukko.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ShukkoKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            ShukkoKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoKanriDgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ShukkoKanriDgv.Refresh();
        }

        private void SetchdDataGridView()
        {
            ShukkoDetailDgv.DataSource = SyukkoDetail.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ShukkoDetailDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            ShukkoDetailDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoDetailDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoDetailDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ShukkoDetailDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ShukkoDetailDgv.Refresh();
        }

        private void KokyakuKanriFlagLbl_Click(object sender, EventArgs e)
        {
            //ミス
        }

        private void HiddenBtn_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
