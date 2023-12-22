using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ChumonDataAccess
    {
        public List<T_ChumonDsp> GetChumonData()
        {
            List<T_ChumonDsp> Chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         join t5 in context.T_Orders
                         on t1.OrID equals t5.OrID
                         where t1.ChFlag == 0
                         select new
                         {
                             t1.ChID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChFlag,
                             t1.ChStateFlag,
                             t1.ChHidden
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_ChumonDsp()
                    {
                        ChID = p.ChID,
                        EmName = p.EmName,
                        SoName = p.SoName,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        ChDate = p.ChDate,
                        ChFlag = p.ChFlag,
                        ChStateFlag = p.ChStateFlag,
                        ChHidden = p.ChHidden
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

        public string[] GetchtxtData(int chid)
        {
            string[] data = new string[9];

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         join t5 in context.T_Orders
                         on t1.OrID equals t5.OrID
                         where t1.ChID == chid
                         select new
                         {
                             t1.ChID,
                             t2.SoName,
                             t1.EmID,
                             t1.ClID,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden
                         };

                foreach (var p in tb)
                {
                    data[0] = p.ChID.ToString();
                    data[1] = p.SoName;
                    data[2] = p.EmID.ToString();
                    data[3] = p.ClID.ToString();
                    data[4] = p.OrID.ToString();
                    data[5] = p.ChDate.ToString();
                    data[6] = p.ChStateFlag.ToString();
                    data[7] = p.ChFlag.ToString();
                    if (p.ChHidden == null)
                    {
                        data[8] = "";
                    }
                    else
                    {
                        data[8] = p.ChHidden;
                    }
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        public List<T_ChumonDsp> SearchChumonData(int chid)
        {
            List<T_ChumonDsp> Chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         join t5 in context.T_Orders
                         on t1.OrID equals t5.OrID
                         where t1.ChFlag == 0 &&
                               t1.ChID == chid
                         select new
                         {
                             t1.ChID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChFlag,
                             t1.ChStateFlag,
                             t1.ChHidden
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_ChumonDsp()
                    {
                        ChID = p.ChID,
                        EmName = p.EmName,
                        SoName = p.SoName,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        ChDate = p.ChDate,
                        ChFlag = p.ChFlag,
                        ChStateFlag = p.ChStateFlag,
                        ChHidden = p.ChHidden
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
    }
}
