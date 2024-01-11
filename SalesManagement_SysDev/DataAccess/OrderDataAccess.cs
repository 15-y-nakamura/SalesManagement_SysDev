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
    internal class OrderDataAccess
    {
        public List<T_OrderDsp> SearchOrder(T_Order regOrder)
        {
            List<T_OrderDsp> ord = new List<T_OrderDsp>();

            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (regOrder.OrID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrID == regOrder.OrID
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        ord.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ord;
        }



        public bool DeleteEmployee(T_Order regOrder)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var emp = context.T_Orders.Single(x => x.OrID == regOrder.OrID);

                emp.OrFlag = regOrder.OrFlag;
                emp.OrHidden = regOrder.OrHidden;

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
        //メソッド名：GetOrderData()
        //引　数   ：なし
        //戻り値   ：List<T_OrderDsp>
        //機　能   ：全受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderData()
        {
            List<T_OrderDsp> Juc = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         where t1.OrFlag == 0

                         select new
                         {
                             t1.OrID,
                             t2.SoName,
                             t1.EmID,
                             t1.ClID,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden,
                         };

                foreach (var p in tb)
                {
                    Juc.Add(new T_OrderDsp()
                    {
                        OrID = p.OrID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        ClID = p.ClID,
                        ClCharge = p.ClCharge,
                        OrDate = p.OrDate,
                        OrStateFlag = p.OrStateFlag,
                        OrFlag = p.OrFlag,
                        OrHidden = p.OrHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Juc;
        }

        ///////////////////////////////
        //メソッド名：RegistJuchu()
        //引　数   ：T_Order
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：受注情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistOrder(T_Order regJuchu)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Orders.Add(regJuchu);
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
        //メソッド名：SonzaiCheckOrID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：受注IDの存在チェック
        //           受注IDが存在するときTrue
        //           受注IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckOrID(int OrID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された受注IDに一致するデータが存在するか
                flg = context.T_Orders.Any(x => x.OrID == OrID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        public List<T_OrderDsp> SearchOrderData(T_Order T_Or)
        {
            List<T_OrderDsp> Order = new List<T_OrderDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (T_Or.OrID != 0 && T_Or.OrFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrID == T_Or.OrID &&
                             t1.OrFlag == 0

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.OrID != 0 && T_Or.OrFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrID == T_Or.OrID &&
                                   t1.OrFlag == T_Or.OrFlag

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.SoID == T_Or.SoID &&
                                  t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate != nulldate &&
                        T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };


                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };


                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrFlag == T_Or.OrFlag &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == 0 &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };


                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.SoID == T_Or.SoID &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.SoID == T_Or.SoID &&
                                  t1.OrDate == T_Or.OrDate &&
                                  t1.OrFlag == T_Or.OrFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.SoID == T_Or.SoID &&
                                      t1.OrDate == T_Or.OrDate &&
                                      t1.OrFlag == 0 &&
                                      (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                      t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag != -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrFlag == 0 &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrFlag == 0 &&
                                  t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID == 0 && T_Or.OrDate != nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.OrDate == T_Or.OrDate &&
                                      t1.OrFlag == 0 &&
                                      (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                      t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Or.SoID != 0 && T_Or.OrDate == nulldate &&
                       T_Or.OrFlag == -1 && T_Or.OrStateFlag == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.SoID == T_Or.SoID &&
                                  t1.OrFlag == 0 &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                  t1.OrHidden == null)

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
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
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID

                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t1.EmID,
                                 t1.ClID,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };

                    foreach (var p in tb)
                    {
                        Order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            ClID = p.ClID,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return Order;
        }
    }
}
