using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SalesManagement_SysDev.DataAccess
{
    internal class OrderDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetOrderData()
        //引　数   ：なし
        //戻り値   ：List<T_OrderDsp>
        //機　能   ：全受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderData()
        {
            List<T_OrderDsp> Juc = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID

                         select new
                         {
                             t1.OrID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden,
                         };

                foreach (var p in tb)
                {
                    Juc.Add(new T_OrderDsp()
                    {
                        OrID = p.OrID,
                        SoName = p.SoName,
                        EmName = p.EmName,
                        ClName = p.ClName,
                        ClCharge = p.ClCharge,
                        OrDate = p.OrDate,
                        OrStateFlag =  p.OrStateFlag,
                        OrFlag = p.OrFlag,
                        OrHidden = p.OrHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Juc;
        }

        ///////////////////////////////
        //メソッド名：RegistJuchu()
        //引　数   ：T_Order
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：受注情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistOrder(T_Order regJuchu)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Orders.Add(regJuchu);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckOrID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：受注IDの存在チェック
        //           受注IDが存在するときTrue
        //           受注IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckOrID(int OrID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された受注IDに一致するデータが存在するか
                flg = context.T_Orders.Any(x => x.OrID == OrID);
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
