﻿using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections;
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
    public partial class ChumonKanri : Form
    {

        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();
        SalesOfficeDataAccess soDataAccess = new SalesOfficeDataAccess();
        ChumonDataAccess chDataAccess = new ChumonDataAccess();
        ChumonDetailDataAccess chdDataAccess = new ChumonDetailDataAccess();
        StockDataAccess stDataAccess = new StockDataAccess();
        SyukkoDataAccess syuDataAccess = new SyukkoDataAccess();
        SyukkoDetailDataAccess syudDataAccess = new SyukkoDetailDataAccess();
        ShohinDataAccess shoDataAccess = new ShohinDataAccess();
        ClientDataAccess clDataAccess = new ClientDataAccess();

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
            ShainName.Text = "--";
            KokyakuIDTxb.Text = "";
            KokyakuName.Text = "--";
            JuchuIDTxb.Text = "";
            ShohinIDTxb.Text = "";
            ShohinName.Text = "--";
            SuryoTxb.Text = "";
            ChumonnengappiDtm.Checked = false;
            ChumonjyoutaiFlaguCmb.Items.Clear();
            ChumonjyoutaiFlaguCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ChumonjyoutaiFlaguCmb.Items.Add("処理受付");
            ChumonjyoutaiFlaguCmb.Items.Add("処理確定");
            ChumonKanriFlagCmb.Items.Clear();
            ChumonKanriFlagCmb.DropDownStyle = ComboBoxStyle.DropDownList;
            ChumonKanriFlagCmb.Items.Add("表示");
            ChumonKanriFlagCmb.Items.Add("非表示");
            HihyojiTxb.Text = "";
            ChumonIDTxb.Enabled = true;
            ConfirmBtn.Enabled = false;
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
            Chumon = chDataAccess.GetAllChumonData();
            ChumonDetail = chdDataAccess.GetAllChumonDetailData();

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
            if (ChumonKanriDgv.Rows.Count == 0)
            {
                return;
            }

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
            if (ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[8].Value == null)
            {
                HihyojiTxb.Text = "";
            }
            else
            {
                HihyojiTxb.Text = ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[8].Value.ToString();
            }

            ChumonDetail = chdDataAccess.GetChumonDetailData(int.Parse(ChumonKanriDgv.Rows[ChumonKanriDgv.CurrentRow.Index].Cells[0].Value.ToString()));

            ChumonIDTxb.Enabled = false;
            ConfirmBtn.Enabled = true;
            HiddenBtn.Enabled = true;
            ChumonnengappiDtm.Checked = true;

            SetchdDataGridView();
        }

        //データグリットビュー内のセルをクリック(注文詳細テーブル)
        private void ChumonDetailDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChumonDetailDgv.Rows.Count == 0)
            {
                return;
            }

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

            Chumon = chDataAccess.GetChData(int.Parse(ChumonDetailDgv.Rows[ChumonDetailDgv.CurrentRow.Index].Cells[1].Value.ToString()));

            ChumonIDTxb.Enabled = false;
            ConfirmBtn.Enabled = true;
            HiddenBtn.Enabled = true;

            SetchDataGridView();
        }

        private void GamenKousinBtn_Click(object sender, EventArgs e)
        {
            SetCtrlFormat();
            SetFormGridView();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if(!SearchInputCheck())
            {
                return;
            }

            var chdata = SetChSearchData();
            var chddata = SetChdSearchData();

            SearchChumon(chdata,chddata);
        }

        private bool SearchInputCheck()
        {
            if (ChumonIDTxb.Text != "")
            {
                if (!inputCheck.CheckSearchChID(ChumonIDTxb.Text).flg)
                {
                    messageDsp.DspMsg(inputCheck.CheckSearchChID(ChumonIDTxb.Text).Msg);
                    return false;
                }
            }

            if (ShainIDTxb.Text != "")
            {
                if (!inputCheck.CheckSearchEmID(ShainIDTxb.Text).flg)
                {
                    messageDsp.DspMsg(inputCheck.CheckSearchEmID(ShainIDTxb.Text).Msg);
                    return false;
                }
            }

            if (JuchuIDTxb.Text != "")
            {
                if (!inputCheck.CheckRegistOrID(JuchuIDTxb.Text).flg)
                {
                    messageDsp.DspMsg(inputCheck.CheckRegistOrID(JuchuIDTxb.Text).Msg);
                    return false;
                }
            }

            if (KokyakuIDTxb.Text != "")
            {
                if (!inputCheck.CheckClID(KokyakuIDTxb.Text).flg)
                {
                    messageDsp.DspMsg(inputCheck.CheckClID(KokyakuIDTxb.Text).Msg);
                    return false;
                }
            }

            if(ShohinIDTxb.Text != "")
            {
                if (!inputCheck.CheckSearchPrID(ShohinIDTxb.Text).flg)
                {
                    messageDsp.DspMsg(inputCheck.CheckSearchPrID(ShohinIDTxb.Text).Msg);
                    return false;
                }
            }
            return true;
        }

        private T_Chumon SetChSearchData()
        {
            int chid = -1;
            int soid = -1;
            int emid = -1;
            int clid = -1;
            int orid = -1;
            DateTime date = DateTime.ParseExact("00010101", "yyyymmdd", null);
            int chsflg = -1;
            int chflg = -1;

            if (ChumonIDTxb.Text != "")
            {
                chid = int.Parse(ChumonIDTxb.Text);
            }

            if(EigyoushoNameCmb.Text != "")
            {
                soid = soDataAccess.GetSoID(EigyoushoNameCmb.Text);
            }

            if (ShainIDTxb.Text != "")
            {
                emid = int.Parse(ShainIDTxb.Text);
            }

            if (KokyakuIDTxb.Text != "")
            {
                clid = int.Parse(KokyakuIDTxb.Text);
            }

            if (JuchuIDTxb.Text != "")
            {
                orid = int.Parse(JuchuIDTxb.Text);
            }

            if(ChumonnengappiDtm.Checked == true)
            {
                date = ChumonnengappiDtm.Value.Date;
            }

            if (ChumonjyoutaiFlaguCmb.Text == "処理確定")
            {
                chsflg = 1;
            }
            else
            {
                chsflg = 0;
            }
            
            if (ChumonKanriFlagCmb.Text == "非表示")
            {
                chflg = 2;
            }
            else
            {
                chflg = 0;
            }

            T_Chumon T_Ch = new T_Chumon()
            {   
                ChID = chid,
                EmID = emid,
                SoID = soid,
                ClID = clid,
                OrID = orid,
                ChDate = date,
                ChStateFlag = chsflg,
                ChFlag = chflg,
                ChHidden = HihyojiTxb.Text,
            };

            return T_Ch;
        }

        private T_ChumonDetail SetChdSearchData()
        {
            //int chdid = 0;
            int chid = -1;
            int prid = -1;

            if(ChumonIDTxb.Text != "")
            {
                chid = int.Parse(ChumonIDTxb.Text);
            }

            if(ShohinIDTxb.Text != "")
            {
                prid = int.Parse(ShohinIDTxb.Text);
            }

            T_ChumonDetail T_Chd = new T_ChumonDetail()
            {
                ChID = chid,
                PrID = prid,
            };

            return T_Chd;
        }

        private void SearchChumon(T_Chumon T_Ch, T_ChumonDetail T_ChD)
        {
            Chumon = chDataAccess.SearchChumonData(T_Ch,T_ChD);
            ChumonDetail = chdDataAccess.SearchChdData(T_ChD, T_Ch);
            
            if (Chumon.Count == 0 && ChumonDetail.Count == 0)
            {
                messageDsp.DspMsg("M7026");
            }

            SetchDataGridView();
            SetchdDataGridView();
        }

        private void HiddenBtn_Click(object sender, EventArgs e)
        {
            if (!HiddenInputCheck())
            {
                return;
            }

            var HiddenData = SetHiddenDate();

            HiddenChumon(HiddenData);
        }

        private bool HiddenInputCheck()
        {
            if(!inputCheck.CheckChID(ChumonIDTxb.Text).flg)
            {
                messageDsp.DspMsg(inputCheck.CheckChID(ChumonIDTxb.Text).Msg);
                return false;
            }

            if (!inputCheck.CheckHidden(HihyojiTxb.Text).flg)
            {
                messageDsp.DspMsg(inputCheck.CheckHidden(HihyojiTxb.Text).Msg);
                return false;
            }

            if (!chDataAccess.GetStateflg(int.Parse(ChumonIDTxb.Text)))
            {
                if (DialogResult.No == messageDsp.DspMsg("M7035"))
                {
                    return false;
                }
            }

            return true;
        }

        private T_Chumon SetHiddenDate()
        {
            T_Chumon T_Ch = new T_Chumon()
            { 
                ChID = int.Parse(ChumonIDTxb.Text),
                ChFlag = 2,
                ChHidden = HihyojiTxb.Text
            };

            return T_Ch;
        }

        private void HiddenChumon(T_Chumon T_Ch)
        {
            if (DialogResult.OK == messageDsp.DspMsg("M7028"))
            {
                if (chDataAccess.HiddenChumonDate(T_Ch))
                {
                    messageDsp.DspMsg("M7029");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormGridView();
                }
                else
                {
                    messageDsp.DspMsg("M7030");
                }
            }


        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (!ConfirmInputCheck())
            {
                return;
            }

            var ConfirmData = SetConfirmData();

            ConfirmChumon(ConfirmData);
        }

        private bool ConfirmInputCheck()
        {
            if (!inputCheck.CheckChID(ChumonIDTxb.Text).flg)
            {
                messageDsp.DspMsg(inputCheck.CheckChID(ChumonIDTxb.Text).Msg);
                return false;
            }

            if (chDataAccess.GetStateflg(int.Parse(ChumonIDTxb.Text)))
            {
                messageDsp.DspMsg("M7036");
                return false;
            }

            return true;
        }

        private T_Chumon SetConfirmData()
        {
            T_Chumon T_Ch = new T_Chumon()
            {
                ChID = int.Parse(ChumonIDTxb.Text),
                EmID = EmID,
                ChStateFlag = 1,
            };

            return T_Ch;
        }

        private bool UpdateStockData()
        {
            var NeedData = chdDataAccess.GetNeedData(int.Parse(ChumonIDTxb.Text));
            int stock = 0;

            foreach (var nd in NeedData)
            {
                stock = stDataAccess.GetStQuantity(nd.PrID);
                stock = stock - nd.ChQuantity;

                T_Stock t_Stock = new T_Stock()
                {
                    PrID = nd.PrID,
                    StQuantity = stock,
                };

                if (!stDataAccess.UpdateStock(t_Stock))
                {
                    return false;
                }
            }

            return true;
        }

        private bool RegistSyukko()
        {
            var NeedData = chDataAccess.GetSyukkoNeedData(int.Parse(ChumonIDTxb.Text));

            foreach (var nd in NeedData)
            { 
                T_Syukko t_Syukko = new T_Syukko
                {
                    EmID = null,
                    ClID = nd.ClID,
                    SoID = nd.SoID,
                    OrID = nd.OrID,
                    SyDate = null,
                    SyStateFlag = 0,
                    SyFlag = 0,
                    SyHidden = null
                };

                if (!syuDataAccess.RegistSyukkoData(t_Syukko))
                {
                    return false;
                }
            }
            

            return true;
        }

        private bool RegistSyukkoDetail()
        {
            var NeedData = chdDataAccess.GetNeedData(int.Parse(ChumonIDTxb.Text));
            int OrID = chDataAccess.GetOrID(int.Parse(ChumonIDTxb.Text));
            int SyID = syuDataAccess.GetSyID(OrID);

            foreach (var nd in NeedData)
            {
                T_SyukkoDetail t_Syukkodtl = new T_SyukkoDetail
                {
                    SyID = SyID,
                    PrID = nd.PrID,
                    SyQuantity = nd.ChQuantity
                };

                if (!syudDataAccess.RegistSyudData(t_Syukkodtl))
                {
                    return false;
                }
            }


            return true;
        }

        private void ConfirmChumon(T_Chumon T_Ch)
        {
            if (DialogResult.OK == messageDsp.DspMsg("M7031"))
            {
                if (chDataAccess.ConfirmChumonDate(T_Ch) && UpdateStockData() && 
                RegistSyukko() && RegistSyukkoDetail())
                {
                    messageDsp.DspMsg("M7032");

                    //コントロールの初期設定
                    SetCtrlFormat();

                    //データグリッドビューの設定
                    SetFormGridView();
                }
                else
                {
                    messageDsp.DspMsg("M7033");
                }
            }
        }

        private void ShohinIDTxb_TextChanged(object sender, EventArgs e)
        {
            if(!inputCheck.CheckSuuti(ShohinIDTxb.Text))
            {
                ShohinName.Text = "--";
                return;
            }

            ShohinName.Text = shoDataAccess.GetPrName(int.Parse(ShohinIDTxb.Text));
        }

        private void ShainIDTxb_TextChanged(object sender, EventArgs e)
        {
            if (!inputCheck.CheckSuuti(ShainIDTxb.Text))
            {
                ShainName.Text = "--";
                return;
            }

            ShainName.Text = empDataAccess.GetEmName(int.Parse(ShainIDTxb.Text));
        }

        private void KokyakuIDTxb_TextChanged(object sender, EventArgs e)
        {
            if (!inputCheck.CheckSuuti(KokyakuIDTxb.Text))
            {
                KokyakuName.Text = "--";
                return;
            }

            KokyakuName.Text = clDataAccess.GetClName(int.Parse(KokyakuIDTxb.Text));
        }
    }
}
