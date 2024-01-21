using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;


namespace SalesManagement_SysDev.DataAccess
{
    internal class OrderDetailDataAccess
    {
        public List<T_OrderDetailDsp> SearchOrderDetail(T_OrderDetail T_OrD, T_Order T_Or)
        {
            List<T_OrderDetailDsp> Jucde = new List<T_OrderDetailDsp>();

            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (T_OrD.OrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t1.OrID == T_OrD.OrID &&
                                   t2.OrFlag == T_Or.OrFlag
                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_OrD.OrDetailID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t1.OrDetailID == T_OrD.OrDetailID &&
                                   t2.OrFlag == T_Or.OrFlag
                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t5.PrID == T_OrD.PrID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null) &&
                                   t5.PrID == T_OrD.PrID
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t5.PrID == T_OrD.PrID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.OrDate == T_Or.OrDate &&
                                   t5.PrID == T_OrD.PrID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.SoID == T_Or.SoID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t5.PrID == T_OrD.PrID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
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
                    var tb = from t1 in context.T_Orders
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             join t6 in context.M_Products
                             on t5.PrID equals t6.PrID
                             where t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t5.OrDetailID,
                                 t1.OrID,
                                 t6.PrName,
                                 t5.OrQuantity,
                                 t5.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Jucde;
        }

        ///////////////////////////////
        //メソッド名：GetOrderDetailData()
        //引　数   ：なし
        //戻り値   ：List<T_OrderDetailDsp>
        //機　能   ：全受注詳細データの取得
        ///////////////////////////////
        public List<T_OrderDetailDsp> GetOrderDetailData()
            {
                List<T_OrderDetailDsp> Jucde = new List<T_OrderDetailDsp>();

                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == 0 &&
                                   t2.OrStateFlag == 0

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        Jucde.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return Jucde;
            }


            ///////////////////////////////
            //メソッド名：RegistJuchu()
            //引　数   ：T_Order
            //戻り値   ：True:異常なし、False:異常あり
            //機　能   ：受注詳細情報の登録
            //           登録が成功したときTrue
            //           登録が失敗したときFalse
            ///////////////////////////////
            public bool RegistOrderDetail(T_OrderDetail regJuchuDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_OrderDetails.Add(regJuchuDetail);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        ///////////////////////////////
        //メソッド名：SonzaiCheckJuchuDetailIDD()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能     受注詳細IDの存在チェック
        //           受注詳細IDが存在するときTrue
        //           受注詳細IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckJuchuDetailID(int OrDetailID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された受注詳細IDに一致するデータが存在するか
                flg = context.T_OrderDetails.Any(x => x.OrDetailID == OrDetailID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        public List<T_OrderDetailDsp> SearchOrderDetailData(T_OrderDetail T_Ord, T_Order T_Or)
        {
            List<T_OrderDetailDsp> OrderDetail = new List<T_OrderDetailDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (T_Or.OrID != 0 && T_Or.OrFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t1.OrID == T_Or.OrID &&
                                    t2.OrFlag == 0

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.OrID != 0 && T_Or.OrFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t1.OrID == T_Or.OrID &&
                                    t2.OrFlag == T_Or.OrFlag

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.OrID != 0 && T_Or.OrFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t1.OrID == T_Or.OrID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.OrID != 0 && T_Or.OrFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrID == T_Or.OrID &&
                                  t2.OrFlag == 0 &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                   t2.OrFlag == 0 &&
                                   t2.OrStateFlag == T_Or.OrStateFlag &&
                                   (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                   t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                   t2.OrFlag == 0 &&
                                   (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                   t2.OrHidden == null) &&
                                   t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.ClID == T_Or.ClID &&
                                  t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == 0 &&
                                  t2.OrStateFlag == T_Or.OrStateFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == T_Or.OrFlag &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrDate == T_Or.OrDate &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };


                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.ClID == T_Or.ClID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.SoID == T_Or.SoID &&
                                  t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.ClID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1 && T_Ord.PrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null) &&
                                  t1.PrID == T_Ord.PrID

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
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
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.T_Orders
                             on t1.OrID equals t2.OrID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             where t2.OrFlag == 0 &&
                                  (t2.OrHidden.Contains(T_Or.OrHidden) ||
                                  t2.OrHidden == null)

                             select new
                             {
                                 t1.OrDetailID,
                                 t2.OrID,
                                 t3.PrName,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice
                             };

                    foreach (var p in tb)
                    {
                        OrderDetail.Add(new T_OrderDetailDsp()
                        {
                            OrDetailID = p.OrDetailID,
                            OrID = p.OrID,
                            PrName = p.PrName,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return OrderDetail;
        }

        public List<T_OrderDetailDsp> GetOrdDspData(int OrID)
        {
            List<T_OrderDetailDsp> OrderDetail = new List<T_OrderDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_OrderDetails
                         join t2 in context.T_Orders
                         on t1.OrID equals t2.OrID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.OrID == OrID
                         select new
                         {
                             t1.OrDetailID,
                             t2.OrID,
                             t3.PrName,
                             t1.OrQuantity,
                             t1.OrTotalPrice
                         };

                foreach (var p in tb)
                {
                    OrderDetail.Add(new T_OrderDetailDsp()
                    {
                        OrDetailID = p.OrDetailID,
                        OrID = p.OrID,
                        PrName = p.PrName,
                        OrQuantity = p.OrQuantity,
                        OrTotalPrice = p.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
            return OrderDetail;
        }
    }
}
