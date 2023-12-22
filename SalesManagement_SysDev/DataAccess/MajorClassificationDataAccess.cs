using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class MajorClassificationDataAccess
    {
        public IEnumerable<string> GetMcName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pMcName = context.M_MajorCassifications.Select(x => x.McName);

                IEnumerable<string> McName = pMcName;
                return McName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
