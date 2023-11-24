using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class EmployeeDataAccess
    {
        ///////////////////////////////
        //メソッド名：PasswordCheck()
        //引　数   ：数値、文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：パスワードの一致チェック
        //           パスワードが一致するときTrue
        //           パスワードが一致しないときFalse
        ///////////////////////////////
        public bool PasswordCheck(int EmID,string Password)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された社員IDとパスワードが一致するか
                flg = context.M_Employees.Any(x => x.EmID == EmID && x.EmPassword == Password && x.EmFlag == 0);
                context.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return flg;
        }

        ///////////////////////////////
        //メソッド名：GetPositiomID()
        //引　数   ：数値 社員ID
        //戻り値   ：数値 役職ID
        //機　能   ：社員の役職を取得する
        ///////////////////////////////
        public int GetPositiomID(int EmID)
        {
            int PositiomID = 0;

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.M_Employees
                         join t2 in context.M_Positions
                         on t1.PoID equals t2.PoID
                         where t1.EmID == EmID
                         select new
                         {
                            t2.PoID
                         };

                foreach (var p in tb)
                {
                   PositiomID = p.PoID;
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return PositiomID;
        }

        ///////////////////////////////
        //メソッド名：GetTopData()
        //引　数   ：数値 社員ID
        //戻り値   ：配列 
        //機　能   ：トップページに必要な社員情報を取得する
        ///////////////////////////////
        public string[] GetTopData(int EmID)
        {
            string[] TopData = new string[4];

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.M_Employees
                         join t2 in context.M_Positions
                         on t1.PoID equals t2.PoID
                         join t3 in context.M_SalesOffices
                         on t1.SoID equals t3.SoID
                         where t1.EmID == EmID
                         select new
                         {
                             t1.EmName,
                             t2.PoName,
                             t3.SoName
                         };

                foreach (var p in tb)
                {
                    TopData[0] = p.EmName;
                    TopData[1] = p.PoName;
                    TopData[2] = p.SoName;
                    TopData[3] = DateTime.Now.ToString();
                }
               
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return TopData;
        }

        /*なくてもいいかも
        ///////////////////////////////
        //メソッド名：SonzaiCheckEmID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：社員IDの存在チェック
        //           社員IDが存在するときTrue
        //           社員IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckEmID(int EmID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された社員IDに一致するデータが存在するか
                flg = context.M_Employees.Any(x => x.EmID == EmID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        */
    }
}
