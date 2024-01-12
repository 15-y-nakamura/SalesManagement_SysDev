using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class SyukkoDetailDataAccess
    {
        public bool RegistSyudData(T_SyukkoDetail t_Syukko)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_SyukkoDetails.Add(t_Syukko);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_SyukkoDetailDsp> GetAllSyukkoDetailData()
        {
            List<T_SyukkoDetailDsp> Syukko = new List<T_SyukkoDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_SyukkoDetails
                         join t2 in context.T_Syukkos
                         on t1.SyID equals t2.SyID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t2.SyFlag == 0
                         select new
                         {
                             t1.SyDetailID,
                             t1.SyID,
                             t3.PrName,
                             t1.SyQuantity
                         };

                foreach (var p in tb)
                {
                    Syukko.Add(new T_SyukkoDetailDsp()
                    {
                        SyID = p.SyID,
                        SyDetailID = p.SyDetailID,
                        PrName = p.PrName,
                        SyQuantity = p.SyQuantity
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Syukko;
        }
    }
}
