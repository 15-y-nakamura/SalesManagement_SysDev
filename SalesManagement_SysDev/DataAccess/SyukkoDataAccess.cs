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
    }
}
