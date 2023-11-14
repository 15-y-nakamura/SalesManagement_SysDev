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
        public TopEigyoPage()
        {

            InitializeComponent();
        }

        private void JuchuKanriBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //JuchuKanriを表示
            JuchuKanri f2 = new JuchuKanri();
            f2.Show();
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

        private void TopButsuryuBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            TopButsuryuPage f2 = new TopButsuryuPage();
            f2.Show();
        }

        private void KokyakuKanriBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //Kokyakukanriを表示
            Kokyakukanri f2 = new Kokyakukanri();
            f2.Show();
        }

        private void ChumonKanriBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            // ChumonKanriを表示
            ChumonKanri f2 = new ChumonKanri();
            f2.Show();
        }

        
    }
}
