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
        public bool RegistChumonDetailData(T_ChumonDetail t_Chumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_ChumonDetails.Add(t_Chumon);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_ChumonDetailDsp> GetAllChumonDetailData()
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
                         where t2.ChFlag == 0
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

        public List<T_ChumonDetailDsp> GetChumonDetailData(int chid)
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

        public List<T_ChumonDetailDsp> SearchChdData(T_ChumonDetail T_Chd,T_Chumon T_Ch)
        {
            List<T_ChumonDetailDsp> Chumon = new List<T_ChumonDetailDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (T_Ch.ChID != -1 && T_Ch.ChFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t2.ChID == T_Ch.ChID &&
                                   t1.ChFlag == 0
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.ChID != -1 && T_Ch.ChFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t2.ChID == T_Ch.ChID &&
                                   t1.ChFlag == T_Ch.ChFlag
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.ChID != -1 && T_Ch.ChFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t2.ChID == T_Ch.ChID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.ChID != -1 && T_Ch.ChFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t2.ChID == T_Ch.ChID &&
                                   t1.ChFlag == 0 &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.OrID != -1 && T_Ch.ChFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.OrID == T_Ch.OrID &&
                                   t1.ChFlag == 0
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.OrID != -1 && T_Ch.ChFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.OrID == T_Ch.OrID &&
                                   t1.ChFlag == T_Ch.ChFlag
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.OrID != -1 && T_Ch.ChFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.OrID == T_Ch.OrID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.OrID != -1 && T_Ch.ChFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.OrID == T_Ch.OrID &&
                                   t1.ChFlag == 0 &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                        T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID != 0 && T_Ch.ChDate != nulldate &&
                        T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag != -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == 0 &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag != -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate != nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID != 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID != 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else if (T_Ch.SoID == 0 && T_Ch.ClID == 0 && T_Ch.ChDate == nulldate &&
                       T_Ch.ChFlag == -1 && T_Ch.ChStateFlag == -1 && T_Chd.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t2.PrID == T_Chd.PrID
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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
            }
            else
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.T_ChumonDetails
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t2.PrID equals t3.PrID
                             where t1.ChFlag == 0 &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t2.ChDetailID,
                                 t2.ChID,
                                 t3.PrName,
                                 t2.ChQuantity
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

        public List<T_ChumonDetail> GetNeedData(int chid)
        {
            List<T_ChumonDetail> Chumon = new List<T_ChumonDetail>();
            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.ChDetailID == chid
                         select new
                         {
                             t1.PrID,
                             t1.ChQuantity
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_ChumonDetail()
                    {
                        PrID = p.PrID,
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

    }
}
