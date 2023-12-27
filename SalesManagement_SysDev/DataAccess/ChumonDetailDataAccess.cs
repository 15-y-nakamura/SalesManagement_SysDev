using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ChumonDetailDataAccess
    {
        public List<T_ChumonDetailDsp> GetChumonDetailData()
        {
            List<T_ChumonDetailDsp> Chumon = new List<T_ChumonDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         select new
                         {
                             t1.ChDetailID,
                             t1.ChID,
                             t3.PrName,
                             t1.ChQuantity
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_ChumonDetailDsp()
                    {
                        ChID = p.ChID,
                        ChDetailID = p.ChDetailID,
                        PrName = p.PrName,
                        ChQuantity = p.ChQuantity
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Chumon;
        }

        public List<T_ChumonDetailDsp> SearchChumonDetailData(int chid)
        {
            List<T_ChumonDetailDsp> Chumon = new List<T_ChumonDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.ChID == chid
                         select new
                         {
                             t1.ChDetailID,
                             t1.ChID,
                             t3.PrName,
                             t1.ChQuantity
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_ChumonDetailDsp()
                    {
                        ChID = p.ChID,
                        ChDetailID = p.ChDetailID,
                        PrName = p.PrName,
                        ChQuantity = p.ChQuantity
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Chumon;
        }

        public string GetPrID(int chdid)
        {
            string Prid = "";

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.ChDetailID == chdid
                         select new
                         {
                             t1.PrID
                         };

                foreach (var p in tb)
                {
                    Prid = p.PrID.ToString();
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Prid;
        }
    }
}
