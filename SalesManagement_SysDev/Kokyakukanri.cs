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

        }

        private void PlaceHolderText()
        {
            KokyakuTantoNameTxb.Text = "ハイフンなし";
            KokyakuTantoNameTxb.ForeColor = SystemColors.GrayText;
            KokyakuTantoNameTxb.Enter += KokyakuTantoNameTxb_Enter;
            KokyakuTantoNameTxb.Leave += KokyakuTantoNameTxb_Leave;

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

        private void KokyakuTantoNameTxb_Enter(object sender, EventArgs e)
        {
            if (KokyakuTantoNameTxb.Text == "ハイフンなし")
            {
                KokyakuTantoNameTxb.Text = "";
                KokyakuTantoNameTxb.ForeColor = SystemColors.WindowText;
            }
        }
        private void KokyakuTantoNameTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KokyakuTantoNameTxb.Text))
            {
                KokyakuTantoNameTxb.Text = "ハイフンなし";
                KokyakuTantoNameTxb.ForeColor = SystemColors.GrayText;
            }
        }

        private void JushoTxb_Enter(object sender, EventArgs e)
        {
            if (JushoTxb.Text == "ハイフンあり")
            {
               JushoTxb.Text = "";
               JushoTxb.ForeColor = SystemColors.WindowText;
            }

            
            if (JushoTxb.Text == "ハイフンあり")
            {
                JushoTxb.Text = "";
                JushoTxb.ForeColor = SystemColors.WindowText;
            }
        }

        private void JushoTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JushoTxb.Text))
            {
                JushoTxb.Text = "ハイフンあり";
                JushoTxb.ForeColor = SystemColors.GrayText;
            }



            if (string.IsNullOrWhiteSpace(JushoTxb.Text))
            {
                JushoTxb.Text = "ハイフンあり";
                JushoTxb.ForeColor = SystemColors.GrayText;
            }
        }

        private void TelTxb_Enter(object sender, EventArgs e)
        {
            if (TelTxb.Text == "ハイフンあり")
            {
                TelTxb.Text = "";
                TelTxb.ForeColor = SystemColors.WindowText;
            }
        }

        private void TelTxb_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TelTxb.Text))
            {
                TelTxb.Text = "ハイフンあり";
                TelTxb.ForeColor = SystemColors.GrayText;
            }
        }

        private void FaxTxb_Enter(object sender, EventArgs e)
        {
            if (FaxTxb.Text == "ハイフンあり")
            {
                FaxTxb.Text = "";
                FaxTxb.ForeColor = SystemColors.WindowText;
            }
        }

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
            //現画面を非表示
            this.Visible = false;

            //TopHonshaPageを表示
            TopHonshaPage f2 = new TopHonshaPage();
            f2.Show();
        }

        private void TopEigyoBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //TopEigyoPageを表示
            TopEigyoPage f2 = new TopEigyoPage();
            f2.Show();
        }
       
        private void TopButsuryuBtn_Click_1(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            TopButsuryuPage f2 = new TopButsuryuPage();
            f2.Show();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }


    }
}
