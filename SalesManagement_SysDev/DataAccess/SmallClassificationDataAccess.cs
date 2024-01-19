using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class SmallClassificationDataAccess
    {
        public IEnumerable<string> GetScName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pScName = context.M_SmallClassifications.Select(x => x.ScName);

                IEnumerable<string> ScName = pScName;
                return ScName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：GetGetEmID()
        //引　数   ：なし
        //戻り値   ：取得した社員ID
        //機　能   ：社員ID取得
        ///////////////////////////////
        public int GetEmID(string emname)
        {
            int emid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Employees
                         where t1.EmName == emname
                         select new
                         {
                             t1.EmID
                         };

                foreach (var p in tb)
                {
                    emid = p.EmID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return emid;
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

        public bool Check(int mcid ,string scname)
        {
            var context = new SalesManagement_DevContext();
            bool flg = false;

            try
            {
                flg = context.M_SmallClassifications.Any(x => x.ScName == scname && x.McID == mcid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetMcID()
        //引　数   ：なし
        //戻り値   ：取得した大分類ID
        //機　能   ：大分類ID取得
        ///////////////////////////////
        public string GetMcName(string scname)
        {
            string mcname = "";

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_SmallClassifications
                         join t2 in context.M_MajorCassifications
                         on t1.McID equals t2.McID
                         where t1.ScName == scname
                         select new
                         {
                             t2.McName
                         };

                foreach (var p in tb)
                {
                    mcname = p.McName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return mcname;
        }
    }
}
