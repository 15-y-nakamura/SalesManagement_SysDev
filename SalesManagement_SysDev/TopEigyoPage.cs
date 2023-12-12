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

namespace SalesManagement_SysDev
{
    public partial class TopEigyoPage : Form
    {
        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();

        internal static int EmID = 0;
        internal static int PoID = 0;


        public TopEigyoPage()
        {

            InitializeComponent();
        }

        private void JuchuKanriBtn_Click(object sender, EventArgs e)
        {
            JuchuKanri.EmID = EmID;
            JuchuKanri.PoID = PoID;

            //現画面を非表示
            this.Visible = false;

            //JuchuKanriを表示
            JuchuKanri f2 = new JuchuKanri();
            f2.Show();
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

        private void KokyakuKanriBtn_Click(object sender, EventArgs e)
        {
            ShukkoKanri.EmID = EmID;
            ShukkoKanri.PoID = PoID;

            //現画面を非表示
            this.Visible = false;

            //Kokyakukanriを表示
            ShukkoKanri f2 = new ShukkoKanri();
            f2.Show();
        }

        private void ChumonKanriBtn_Click(object sender, EventArgs e)
        {
            ChumonKanri.EmID = EmID;
            ChumonKanri.PoID = PoID;
            //現画面を非表示
            this.Visible = false;

            // ChumonKanriを表示
            ChumonKanri f2 = new ChumonKanri();
            f2.Show();
        }

        private void TopEigyoPage_Load(object sender, EventArgs e)
        {

            string[] TopData = new string[4];
            TopData = empDataAccess.GetTopData(EmID);

            string emID = EmID.ToString();

            TopIDLbl.Text = emID;
            TopNameLbl.Text = TopData[0];
            TopYakushokuLbl.Text = TopData[1];
            TopEigyoshoLbl.Text = TopData[2];
            TopJikanLbl.Text = TopData[3];

            if(PoID == 2)
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
            else if(PoID == 1)
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

        private void NyukaKanriBtn_Click(object sender, EventArgs e)
        {
            NyukaKanri.EmID = EmID;
            NyukaKanri.PoID = PoID;
            //現画面を非表示
            this.Visible = false;

            // NyukaKanriを表示
            NyukaKanri f2 = new NyukaKanri();
            f2.Show();
        }

        private void ShukkaKanriBtn_Click(object sender, EventArgs e)
        {
            ShukkaKanri.EmID = EmID;
            ShukkaKanri.PoID = PoID;
            //現画面を非表示
            this.Visible = false;

            // ShukkaKanriを表示
            ShukkaKanri f2 = new ShukkaKanri();
            f2.Show();
        }
    }
}
