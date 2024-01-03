using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
