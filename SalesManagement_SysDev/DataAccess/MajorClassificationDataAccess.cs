using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class MajorClassificationDataAccess
    {
        public IEnumerable<string> GetMcName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pMcName = context.M_MajorCassifications.Select(x => x.McName);

                IEnumerable<string> McName = pMcName;
                return McName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：GetMcID()
        //引　数   ：なし
        //戻り値   ：取得した大分類ID
        //機　能   ：大分類ID取得
        ///////////////////////////////
        public int GetMcID(string mcname)
        {
            int mcid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_MajorCassifications
                         where t1.McName == mcname
                         select new
                         {
                             t1.McID
                         };

                foreach (var p in tb)
                {
                    mcid = p.McID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return mcid;
        }

        ///////////////////////////////
        //メソッド名：GetScName()
        //引　数   ：なし
        //戻り値   ：取得した小分類名
        //機　能   ：小分類名取得
        ///////////////////////////////
        public string GetScName(int scid)
        {
            string scname = "";

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_SmallClassifications
                         where t1.ScID == scid
                         select new
                         {
                             t1.ScName
                         };

                foreach (var p in tb)
                {
                    scname = p.ScName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return scname;
        }


    }
}
