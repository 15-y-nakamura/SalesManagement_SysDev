using System;
using System.Collections;
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
            List<T_OrderDsp> Order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.OrFlag == 0 &&
                               t1.OrStateFlag == 0
                         select new
                         {
                             t1.OrID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
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
                        EmName = p.EmName,
                        ClName = p.ClName,
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

            return Order;
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

        //確定
        public bool ConfirmOrderDate(T_Order T_Or)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var or = context.T_Orders.Single(x => x.OrID == T_Or.OrID);

                or.OrStateFlag = T_Or.OrStateFlag;

                context.SaveChanges();
                context.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_OrderDetail> GetNeedData(int orid)
        {
            List<T_OrderDetail> Order = new List<T_OrderDetail>();
            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_OrderDetails
                         join t2 in context.T_Orders
                         on t1.OrID equals t2.OrID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.OrDetailID == orid
                         select new
                         {
                             t1.PrID,
                             t1.OrQuantity
                         };

                foreach (var p in tb)
                {
                    Order.Add(new T_OrderDetail()
                    {
                        PrID = p.PrID,
                        OrQuantity = p.OrQuantity
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Order;
        }



        public bool UpdateStock(T_Chumon chumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var or = context.T_Chumons.Single(x => x.ChID == chumon.ChID);

                context.SaveChanges();
                context.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_Order> GetChumonNeedData(int orid)
        {
            List<T_Order> Order = new List<T_Order>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         where t1.OrID == orid
                         select new
                         {
                             t1.ClID,
                             t1.SoID,
                             t1.OrID,
                             t1.OrHidden
                         };

                foreach (var p in tb)
                {
                    Order.Add(new T_Order()
                    {
                        ClID = p.ClID,
                        SoID = p.SoID,
                        OrID = p.OrID,
                        OrHidden = p.OrHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Order;
        }


        public List<T_OrderDsp> SearchOrderData(T_Order T_Or,T_OrderDetail T_OrD )
        {
            List<T_OrderDsp> Order = new List<T_OrderDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            //受注ID入力
            if (T_Or.OrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.OrID == T_Or.OrID &&
                                   t1.OrFlag == 0
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_OrD.OrDetailID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_OrderDetails
                             on t1.OrID equals t5.OrID
                             where t5.OrDetailID == T_OrD.OrDetailID &&
                                   t1.OrFlag == 0
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 && 
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.SoID == T_Or.SoID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.SoID == T_Or.SoID &&
                                   t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID != -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.EmID == T_Or.EmID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID != -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.SoID == T_Or.SoID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID != -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.ClID == T_Or.ClID &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate != nulldate && T_OrD.PrID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.OrDate == T_Or.OrDate &&
                                   t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
            else if (T_Or.EmID == -1 && T_Or.SoID == -1 && T_Or.ClID == -1 &&
                        T_Or.OrDate == nulldate && T_OrD.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
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
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where t1.OrFlag == T_Or.OrFlag &&
                                   t1.OrStateFlag == T_Or.OrStateFlag &&
                                  (t1.OrHidden.Contains(T_Or.OrHidden) ||
                                   t1.OrHidden == null)
                             select new
                             {
                                 t1.OrID,
                                 t2.SoName,
                                 t3.EmName,
                                 t4.ClName,
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
                            EmName = p.EmName,
                            ClName = p.ClName,
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

        public bool GetStateflg(int orid)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                var tb = context.T_Orders.Single(x => x.OrID == orid);
                var StateFlag = tb.OrStateFlag;
                if (StateFlag == 0)
                {
                    flg = true;
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        public string[] GetTxtData(int OrID)
        {
            string[] TxtData = new string[8];

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         where t1.OrID == OrID
                         select new
                         {
                             t2.SoName,
                             t1.EmID,
                             t1.ClID,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrFlag,
                             t1.OrStateFlag,
                             t1.OrHidden
                         };

                foreach (var p in tb)
                {
                    TxtData[0] = p.SoName;
                    TxtData[1] = p.EmID.ToString();
                    TxtData[2] = p.ClID.ToString();
                    TxtData[3] = p.ClCharge;
                    TxtData[4] = p.OrDate.ToString();
                    TxtData[5] = p.OrFlag.ToString();
                    TxtData[6] = p.OrStateFlag.ToString();
                    TxtData[7] = p.OrHidden;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return TxtData;
        }

        public List<T_OrderDsp> GetOrDspData(int OrID)
        {
            List<T_OrderDsp> Order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.OrID == OrID
                         select new
                         {
                             t1.OrID,
                             t2.SoName,
                             t3.EmName,
                             t4.ClName,
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
                        EmName = p.EmName,
                        ClName = p.ClName,
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

            return Order;
        }
    }
}
