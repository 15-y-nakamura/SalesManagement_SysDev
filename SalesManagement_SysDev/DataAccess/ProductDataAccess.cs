using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ProductDataAccess
    {
        ///////////////////////////////
        //メソッド名：SonzaiCheckPrID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品IDの存在チェック
        //           商品IDが存在するときTrue
        //           商品IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrID(int PrID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された商品IDに一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrID == PrID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrName()
        //引　数   ：文字
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品名の存在チェック
        //           商品名が存在するときTrue
        //           商品名が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrName(string PrName)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された商品名に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrName == PrName);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：RegistProduct()
        //引　数   ：M_Product
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistProduct(M_Product regProduct)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Products.Add(regProduct);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }

        public bool UpdateProduct(M_Product regProduct)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var pro = context.M_Products.Single(x => x.PrID == regProduct.PrID);

                pro.MaID = regProduct.MaID;
                pro.PrID = regProduct.PrID;
                pro.PrName = regProduct.PrName;
                pro.Price = regProduct.Price;
                pro.PrSafetyStock = regProduct.PrSafetyStock;
                pro.ScID = regProduct.ScID;
                pro.PrModelNumber = regProduct.PrModelNumber;
                pro.PrColor = regProduct.PrColor;
                pro.PrReleaseDate = regProduct.PrReleaseDate;
                pro.PrFlag = regProduct.PrFlag;
                pro.PrHidden = regProduct.PrHidden;

                context.SaveChanges();
                context.Dispose();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：GetProductData()
        //引　数   ：なし
        //戻り値   ：List<M_ProductDsp>
        //機　能   ：全商品データの取得
        ///////////////////////////////
        public List<M_ProductDsp> GetProductData()
        {
            List<M_ProductDsp> Pro = new List<M_ProductDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.M_Products
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_SmallClassifications
                         on t1.ScID equals t3.ScID
                         select new
                         {
                             t1.PrID,
                             t1.PrName,
                             t2.MaID,
                             t3.ScID,
                             t1.Price,
                             t1.PrSafetyStock,
                             t1.PrModelNumber,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden
                         };

                foreach(var p in tb)
                {
                    Pro.Add(new M_ProductDsp()
                    {
                        PrID = p.PrID,
                        MaID = p.MaID,
                        PrName = p.PrName,
                        Price = p.Price,
                        PrSafetyStock = p.PrSafetyStock,
                        ScID = p.ScID,
                        PrModelNumber = p.PrModelNumber,
                        PrColor = p.PrColor,
                        PrReleaseDate = p.PrReleaseDate,
                        PrFlag = p.PrFlag,
                        PrHidden = p.PrHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Pro;
        }

        ///////////////////////////////
        //メソッド名：GetScID()
        //引　数   ：なし
        //戻り値   ：取得した小分類ID
        //機　能   ：小分類ID取得
        ///////////////////////////////
        public int GetScID(string scid)
        {
            int Scid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_SmallClassifications
                         where t1.ScName == scid
                         select new
                         {
                             t1.ScID
                         };

                foreach (var p in tb)
                {
                    Scid = p.ScID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Scid;
        }
    }
}
