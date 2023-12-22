using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    internal class SmallClassificationDataAccess
    {
        public IEnumerable<string> GetScName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pScName = context.M_SmallClassifications.Select(x => x.ScName);

                IEnumerable<string> ScName = pScName;
                return ScName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
