using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class SalesOfficeDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetSoName()
        //引　数   ：なし
        //戻り値   ：取得した営業所名
        //機　能   ：営業所名の取得
        ///////////////////////////////
        public IEnumerable<string> GetSoName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pSoName = context.M_SalesOffices.Select(x => x.SoName);
                IEnumerable<string> SoName = pSoName;
                return SoName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：GetSoID()
        //引　数   ：なし
        //戻り値   ：取得した営業所ID
        //機　能   ：営業所ID取得
        ///////////////////////////////
        public int GetSoID(string soname)
        {
            int soid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_SalesOffices
                         where t1.SoName == soname
                         select new
                         {
                             t1.SoID
                         };

                foreach (var p in tb)
                {
                    soid = p.SoID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return soid;
        }
    }
}
