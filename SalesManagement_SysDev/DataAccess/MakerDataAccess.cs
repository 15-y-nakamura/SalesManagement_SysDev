using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class MakerDataAccess
    {
        public IEnumerable<string> GetMaName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pMaName = context.M_Makers.Select(x => x.MaName);

                IEnumerable<string> MaName = pMaName;
                return MaName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
