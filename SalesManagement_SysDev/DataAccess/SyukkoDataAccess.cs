using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class SyukkoDataAccess
    {
        public bool RegistSyukkoData(T_Syukko t_Syukko)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Syukkos.Add(t_Syukko);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetSyID(int OrID)
        {
            int SyID = 0;

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Syukkos
                         where t1.OrID == OrID
                         select new
                         {
                             t1.SyID
                         };

                foreach (var p in tb)
                {
                    SyID = p.SyID;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return SyID;
        }

        public List<T_SyukkoDsp> GetAllSyukkoData()
        {
            List<T_SyukkoDsp> Syukko = new List<T_SyukkoDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Syukkos
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         join t5 in context.T_Orders
                         on t1.OrID equals t5.OrID
                         where t1.SyFlag == 0
                         select new
                         {
                             t1.SyID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
                             t1.OrID,
                             t1.SyDate,
                             t1.SyFlag,
                             t1.SyStateFlag,
                             t1.SyHidden
                         };

                foreach (var p in tb)
                {
                    Syukko.Add(new T_SyukkoDsp()
                    {
                        SyID = p.SyID,
                        EmName = p.EmName,
                        SoName = p.SoName,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        SyDate = p.SyDate,
                        SyFlag = p.SyFlag,
                        SyStateFlag = p.SyStateFlag,
                        SyHidden = p.SyHidden
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
