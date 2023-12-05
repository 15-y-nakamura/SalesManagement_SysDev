using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    class LoginDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckFirstPassExistence()
        //引　数   ：password
        //戻り値   ：True or False
        //機　能   ：一致する初期パスワードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckFirstPassExistence(string password)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //FirstPassで一致するデータが存在するか
                flg = context.M_Employees.Any(x => x.FirstPass == password);
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
