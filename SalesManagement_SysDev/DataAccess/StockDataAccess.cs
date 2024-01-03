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
    }
}
