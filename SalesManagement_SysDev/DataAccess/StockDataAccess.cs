using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class StockDataAccess
    {
        public int GetStQuantity(int PrID)
        {
            int stQuantity = 0;

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Stocks
                         where t1.PrID == PrID
                         select new
                         {
                             stQuantity = t1.StQuantity
                         };

                foreach (var p in tb)
                {
                    stQuantity = p.stQuantity;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return stQuantity;
        }

        public bool UpdateStock(T_Stock stock)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var ch = context.T_Stocks.Single(x => x.PrID == stock.PrID);

                ch.StQuantity = stock.StQuantity;

                context.SaveChanges();
                context.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_StockDsp> GetStockData()
        {
            List<T_StockDsp> Stock = new List<T_StockDsp>(); 

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Stocks
                         join t2 in context.M_Products
                         on t1.PrID equals t2.PrID
                         join t3 in context.M_Makers
                         on t2.MaID equals t3.MaID
                         where t1.StFlag == 0 &&
                               t2.PrFlag == 0
                         select new
                         {
                             t1.StID,
                             t3.MaName,
                             t2.PrName,
                             t1.StQuantity,
                             t2.PrSafetyStock,
                             t1.StFlag
                         };

                foreach (var p in tb)
                {
                    Stock.Add(new T_StockDsp(){
                        StID = p.StID,
                        MaName = p.MaName,
                        PrName = p.PrName,
                        StQuantity = p.StQuantity,
                        PrSafetyStock = p.PrSafetyStock,
                        StFlag = p.StFlag
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Stock;
        }
    }
}
