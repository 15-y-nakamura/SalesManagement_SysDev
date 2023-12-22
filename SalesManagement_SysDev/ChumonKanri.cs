﻿using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class ChumonKanri : Form
    {

        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();
        SalesOfficeDataAccess soDataAccess = new SalesOfficeDataAccess();
        ChumonDataAccess chDataAccess = new ChumonDataAccess();
        ChumonDetailDataAccess chdDataAccess = new ChumonDetailDataAccess();

        private static List<T_ChumonDsp> Chumon;
        private static List<T_ChumonDetailDsp> ChumonDetail;

        internal static int PoID = 0;
        internal static int EmID = 0;
        internal static string Logindate = "";
        public ChumonKanri()
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

        private void ChumonKanri_Load(object sender, EventArgs e)
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

            SetCtrlFormat();
            
            SetFormGridView();
        }

        private void SetCtrlFormat()
        {
            ChumonIDTxb.Text = "";
            JuchuIDTxb.Text = "";
            EigyoushoNameCmb.Items.Clear();
            EigyoushoNameCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ShainIDTxb.Text = "";
            KokyakuIDTxb.Text = "";
            JuchuIDTxb.Text = "";
            ShohinIDTxb.Text = "";
            SuryoTxb.Text = "";
            ChumonjyoutaiFlaguCmb.Items.Clear();
            ChumonjyoutaiFlaguCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ChumonjyoutaiFlaguCmb.Items.Add("処理受付");
            ChumonjyoutaiFlaguCmb.Items.Add("処理確定");
            ChumonKanriFlagCmb.Items.Clear();
            ChumonKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ChumonKanriFlagCmb.Items.Add("表示");
            ChumonKanriFlagCmb.Items.Add("非表示");
            HihyojiTxb.Text = "";

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
            ChumonKanriDgv.ReadOnly = true;
            ChumonDetailDgv.ReadOnly = true;
            //行内をクリックすることで行を選択
            ChumonKanriDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ChumonDetailDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ヘッダー位置の指定
            ChumonKanriDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ChumonDetailDgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            Chumon = chDataAccess.GetChumonData();
            ChumonDetail = chdDataAccess.GetChumonDetailData();

            // DataGridViewに表示するデータを指定
            SetchDataGridView();
            SetchdDataGridView();
        }

        ///////////////////////////////
        //メソッド名：SetDataGridView()
        //引　数   ：M_EmployeeDsp
        //戻り値   ：なし
        //機　能   ：データグリッドビューにデータを反映する
        ///////////////////////////////
        private void SetchDataGridView()
        {
            ChumonKanriDgv.DataSource = Chumon.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ChumonKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            ChumonKanriDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonKanriDgv.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ChumonKanriDgv.Refresh();
        }

        private void SetchdDataGridView()
        {
            ChumonDetailDgv.DataSource = ChumonDetail.ToList();

            //すべての列がコントロールの表示領域の幅いっぱいに表示されるよう列幅を調整
            ChumonKanriDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChumonDetailDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //各列の文字位置の指定
            ChumonDetailDgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonDetailDgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonDetailDgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ChumonDetailDgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            ChumonDetailDgv.Refresh();
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

        //データグリットビュー内のセルをクリック(注文テーブル)
        private void ChumonKanriDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] chDatas = chDataAccess.GetchtxtData(int.Parse(ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[0].Value.ToString()));

            //入力欄にセルの内容を反映
            ChumonIDTxb.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[0].Value.ToString();
            EigyoushoNameCmb.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[1].Value.ToString();
            ShainIDTxb.Text = chDatas[2];
            KokyakuIDTxb.Text = chDatas[3];
            JuchuIDTxb.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[4].Value.ToString();
            ChumonnengappiDtm.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[5].Value.ToString();
            if (ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[6].Value.ToString() == "0")
            {
                ChumonjyoutaiFlaguCmb.Text = "処理受付";
            }
            else
            {
                ChumonjyoutaiFlaguCmb.Text = "処理確定";
            }
            if (ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[7].Value.ToString() == "0")
            {
                ChumonKanriFlagCmb.Text = "表示";
            }
            else
            {
                ChumonKanriFlagCmb.Text = "非表示";
            }
            if(ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[8].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            }

            //aa
            ChumonDetail = chdDataAccess.SearchChumonDetailData(int.Parse(ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[0].Value.ToString()));

            SetchdDataGridView();
        }

        //データグリットビュー内のセルをクリック(注文詳細テーブル)
        private void ChumonDetailDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] chDatas = chDataAccess.GetchtxtData(int.Parse(ChumonDetailDgv.Rows[ChumonDetailDgv.CurrentRow.Index].Cells[1].Value.ToString()));

            //入力欄にセルの内容を反映
            ChumonIDTxb.Text = chDatas[0];
            EigyoushoNameCmb.Text = chDatas[1];
            ShainIDTxb.Text = chDatas[2];
            KokyakuIDTxb.Text = chDatas[3];
            JuchuIDTxb.Text = chDatas[4];
            ChumonnengappiDtm.Text = chDatas[5];
            if (chDatas[6] == "0")
            {
                ChumonjyoutaiFlaguCmb.Text = "処理受付";
            }
            else
            {
                ChumonjyoutaiFlaguCmb.Text = "処理確定";
            }
            if (chDatas[7] == "0")
            {
                ChumonKanriFlagCmb.Text = "表示";
            }
            else
            {
                ChumonKanriFlagCmb.Text = "非表示";
            }            
             HihyojiTxb.Text = chDatas[8];
            
            ShohinIDTxb.Text = chdDataAccess.GetPrID(int.Parse(ChumonDetailDgv.Rows[ChumonDetailDgv.CurrentRow.Index].Cells[0].Value.ToString()));
            SuryoTxb.Text = ChumonDetailDgv.Rows[ChumonDetailDgv.CurrentRow.Index].Cells[3].Value.ToString();

            Chumon = chDataAccess.SearchChumonData(int.Parse(ChumonDetailDgv.Rows[ChumonDetailDgv.CurrentRow.Index].Cells[1].Value.ToString()));

            SetchDataGridView();
        }
    }
}
