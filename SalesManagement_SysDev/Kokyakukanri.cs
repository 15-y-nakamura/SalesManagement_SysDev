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
    public partial class Kokyakukanri : Form
    {

        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;

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

                TopEigyoBtn.FlatAppearance.MouseOverBackColor = Color.LightBlue;
                TopEigyoBtn.FlatAppearance.BorderSize = 2;
                TopEigyoBtn.FlatAppearance.BorderColor = Color.SteelBlue;

            }
            else if (PoID == 1)
            {

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


        }

        //テキストボックス内に灰色の文字を表示
        private void PlaceHolderText()
        {
            YubinTxb.Text = "ハイフンなし";
            YubinTxb.ForeColor = SystemColors.GrayText;
            YubinTxb.Enter += YubinTxb_Enter;
            YubinTxb.Leave += YubinTxb_Leave;

            JushoTxb.Text = "ハイフンあり";
            JushoTxb.ForeColor = SystemColors.GrayText;
            JushoTxb.Enter += JushoTxb_Enter;
            JushoTxb.Leave += JushoTxb_Leave;

            TelTxb.Text = "ハイフンあり";
            TelTxb.ForeColor = SystemColors.GrayText;
            TelTxb.Enter += TelTxb_Enter;
            TelTxb.Leave += TelTxb_Leave;

            FaxTxb.Text = "ハイフンあり";
            FaxTxb.ForeColor = SystemColors.GrayText;
            FaxTxb.Enter += FaxTxb_Enter;
            FaxTxb.Leave += FaxTxb_Leave;
        }

        //郵便番号のテキストボックスが選択されている場合
        private void YubinTxb_Enter(object sender, EventArgs e)
        {
            if (YubinTxb.Text == "ハイフンなし")
            {
                YubinTxb.Text = "";
                YubinTxb.ForeColor = SystemColors.WindowText;
            }
        }

        //郵便番号のテキストボックスが選択されていない・入力されていない場合
        private void YubinTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(YubinTxb.Text))
            {
                YubinTxb.Text = "ハイフンなし";
                YubinTxb.ForeColor = SystemColors.GrayText;
            }
        }

        //住所のテキストボックスが選択されている場合
        private void JushoTxb_Enter(object sender, EventArgs e)
        {
            if (JushoTxb.Text == "ハイフンあり")
            {
               JushoTxb.Text = "";
               JushoTxb.ForeColor = SystemColors.WindowText;
            }
        }

        //住所のテキストボックスが選択されていない・入力されていない場合
        private void JushoTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JushoTxb.Text))
            {
                JushoTxb.Text = "ハイフンあり";
                JushoTxb.ForeColor = SystemColors.GrayText;
            }
        }

        //電話番号のテキストボックスが選択されている場合
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
        }

        //FAXのテキストボックスが選択されている場合
        private void FaxTxb_Enter(object sender, EventArgs e)
        {
            if (FaxTxb.Text == "ハイフンあり")
            {
                FaxTxb.Text = "";
                FaxTxb.ForeColor = SystemColors.WindowText;
            }
        }

        //FAXのテキストボックスが選択されていない・入力されていない場合
        private void FaxTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FaxTxb.Text))
            {
                FaxTxb.Text = "ハイフンあり";
                FaxTxb.ForeColor = SystemColors.GrayText;
            }
        }

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
       
        private void TopButsuryuBtn_Click_1(object sender, EventArgs e)
        {
            TopButsuryuPage.EmID = EmID;
            TopButsuryuPage.PoID = PoID;

            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            TopButsuryuPage f2 = new TopButsuryuPage();
            f2.Show();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

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
    }
}
