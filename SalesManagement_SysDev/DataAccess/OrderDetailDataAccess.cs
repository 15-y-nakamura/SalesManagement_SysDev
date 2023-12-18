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
    internal class OrderDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetJuchuData()
        //引　数   ：なし
        //戻り値   ：List<T_OrderDetail>
        //機　能   ：全受注データの取得
        ///////////////////////////////
        public List<T_OrderDetailDsp> GetOrderDetailData()
        {
            List<T_OrderDetailDsp> Jucde = new List<T_OrderDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_OrderDetails
                         join t2 in context.T_Orders
                         on t1.OrID equals t2.OrID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID

                         select new
                         {
                             t1.OrDetailID,
                             t2.OrID,
                             t3.PrID,
                             t1.OrQuantity,
                             t1.OrTotalPrice
                         };

                foreach (var p in tb)
                {
                    Jucde.Add(new T_OrderDetailDsp()
                    {
                        OrDetailID = p.OrDetailID,
                        OrID = p.OrID,
                        PrID = p.PrID,
                        OrQuantity = p.OrQuantity,
                        OrTotalPrice = p.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Jucde;
        }


        ///////////////////////////////
        //メソッド名：RegistJuchu()
        //引　数   ：T_Order
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：受注詳細情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistOrderDetail(T_OrderDetail regJuchuDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_OrderDetails.Add(regJuchuDetail);
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
        //メソッド名：SonzaiCheckJuchuDetailIDD()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能     受注詳細IDの存在チェック
        //           受注詳細IDが存在するときTrue
        //           受注詳細IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckJuchuDetailID(int OrDetailID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された受注詳細IDに一致するデータが存在するか
                flg = context.T_OrderDetails.Any(x => x.OrDetailID == OrDetailID);
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
