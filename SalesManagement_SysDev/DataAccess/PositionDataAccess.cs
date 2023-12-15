using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class PositionDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetPoName()
        //引　数   ：なし
        //戻り値   ：取得した役職名
        //機　能   ：役職名の取得
        ///////////////////////////////
        public IEnumerable<string> GetPoName()
        {
            var context = new SalesManagement_DevContext();
            try
            {
                var pPoName = context.M_Positions.Select(x => x.PoName);
                IEnumerable<string> PoName = pPoName;
                return PoName;
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：GetPoID()
        //引　数   ：なし
        //戻り値   ：取得した役職ID
        //機　能   ：役職IDの取得
        ///////////////////////////////
        public int GetPoID(string poname)
        {
            int poid = 0;

            var context =new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Positions
                         where t1.PoName == poname
                         select new
                         {
                             t1.PoID
                         };

                foreach (var p in tb)
                {
                    poid = p.PoID;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return poid;
        }
    }
}
