using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ShohinDataAccess
    {
        ///////////////////////////////
        //メソッド名：SonzaiCheckShohinID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品IDの存在チェック
        //           商品IDが存在するときTrue
        //           商品IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckShohinID(int PrID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された社員IDに一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrID == PrID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
    }
}
