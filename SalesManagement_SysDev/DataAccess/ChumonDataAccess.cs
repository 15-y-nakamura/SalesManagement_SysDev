﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ChumonDataAccess
    {
        EmployeeDataAccess EmpDA = new EmployeeDataAccess();

        public List<T_ChumonDsp> GetAllChumonData()
        {
            List<T_ChumonDsp> Chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         //join t3 in context.M_Employees
                         //on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         join t5 in context.T_Orders
                         on t1.OrID equals t5.OrID
                         where t1.ChFlag == 0 &&
                               t1.ChStateFlag == 0
                         select new
                         {
                             t1.ChID,
                             t2.SoName,
                             t1.EmID,
                             t4.ClName,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChFlag,
                             t1.ChStateFlag,
                             t1.ChHidden
                         };

                foreach (var p in tb)
                {
                    if (p.EmID == null)
                    {
                        Chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            SoName = p.SoName,
                            EmName = "未確定",
                            ClName = p.ClName,
                            OrID = p.OrID,
                            ChDate = p.ChDate,
                            ChFlag = p.ChFlag,
                            ChStateFlag = p.ChStateFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                    else
                    {
                        Chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            SoName = p.SoName,
                            EmName = EmpDA.GetEmName((int)p.EmID),
                            ClName = p.ClName,
                            OrID = p.OrID,
                            ChDate = p.ChDate,
                            ChFlag = p.ChFlag,
                            ChStateFlag = p.ChStateFlag,
                            ChHidden = p.ChHidden
                        });
                    }
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
                         //join t3 in context.M_Employees
                         //on t1.EmID equals t3.EmID
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
                    if (p.EmID == null)
                    {
                        data[2] = "";
                    }
                    else
                    {
                        data[2] = p.EmID.ToString();
                    }
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

        public List<T_ChumonDsp> GetChData(int chid)
        {
            List<T_ChumonDsp> Chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         //join t3 in context.M_Employees
                         //on t1.EmID equals t3.EmID
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
                             t1.EmID,
                             t4.ClName,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChFlag,
                             t1.ChStateFlag,
                             t1.ChHidden
                         };

                foreach (var p in tb)
                {
                    if (p.EmID == null)
                    {
                        Chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            SoName = p.SoName,
                            EmName = "未確定",
                            ClName = p.ClName,
                            OrID = p.OrID,
                            ChDate = p.ChDate,
                            ChFlag = p.ChFlag,
                            ChStateFlag = p.ChStateFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                    else
                    {
                        Chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            SoName = p.SoName,
                            EmName = EmpDA.GetEmName((int)p.EmID),
                            ClName = p.ClName,
                            OrID = p.OrID,
                            ChDate = p.ChDate,
                            ChFlag = p.ChFlag,
                            ChStateFlag = p.ChStateFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Chumon;
        }

        public List<T_ChumonDsp> SearchChumonData(T_Chumon T_Ch, T_ChumonDetail T_Chd)
        {
            List<T_ChumonDsp> Chumon = new List<T_ChumonDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            if (T_Ch.ChID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.ChID == T_Ch.ChID &&
                                   t1.ChFlag == T_Ch.ChFlag
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.OrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.OrID == T_Ch.OrID &&
                                   t1.ChFlag == T_Ch.ChFlag
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate 
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) 
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate != nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID != -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.SoID == T_Ch.SoID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID != -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.ClID == T_Ch.ClID &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate != nulldate
                        && T_Chd.PrID == -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             where t1.ChDate == T_Ch.ChDate &&
                                   t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate
                        && T_Chd.PrID != -1 && T_Ch.EmID == -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             join t6 in context.T_ChumonDetails
                             on t1.ChID equals t6.ChID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t6.PrID == T_Chd.PrID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (T_Ch.SoID == -1 && T_Ch.ClID == -1 && T_Ch.ChDate == nulldate 
                        && T_Chd.PrID == -1 && T_Ch.EmID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null) &&
                                   t1.EmID == T_Ch.EmID
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
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
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             join t5 in context.T_Orders
                             on t1.OrID equals t5.OrID
                             //join t6 in context.T_ChumonDetails
                             //on t1.ChID equals t6.ChID
                             where t1.ChFlag == T_Ch.ChFlag &&
                                   t1.ChStateFlag == T_Ch.ChStateFlag &&
                                   (t1.ChHidden.Contains(T_Ch.ChHidden) ||
                                   t1.ChHidden == null)
                             select new
                             {
                                 t1.ChID,
                                 t2.SoName,
                                 t1.EmID,
                                 t4.ClName,
                                 t1.OrID,
                                 t1.ChDate,
                                 t1.ChFlag,
                                 t1.ChStateFlag,
                                 t1.ChHidden
                             };

                    foreach (var p in tb)
                    {
                        if (p.EmID == null)
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = "未確定",
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
                        else
                        {
                            Chumon.Add(new T_ChumonDsp()
                            {
                                ChID = p.ChID,
                                SoName = p.SoName,
                                EmName = EmpDA.GetEmName((int)p.EmID),
                                ClName = p.ClName,
                                OrID = p.OrID,
                                ChDate = p.ChDate,
                                ChFlag = p.ChFlag,
                                ChStateFlag = p.ChStateFlag,
                                ChHidden = p.ChHidden
                            });
                        }
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

        public bool SonzaiCheckChID(int chid)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された注文IDに一致するデータが存在するか
                flg = context.T_Chumons.Any(x => x.ChID == chid);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        public bool HiddenChumonDate(T_Chumon T_Ch)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var ch = context.T_Chumons.Single(x => x.ChID == T_Ch.ChID);

                ch.ChFlag = T_Ch.ChFlag;
                ch.ChHidden = T_Ch.ChHidden;

                context.SaveChanges();
                context.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConfirmChumonDate(T_Chumon T_Ch)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var ch = context.T_Chumons.Single(x => x.ChID == T_Ch.ChID);

                ch.ChStateFlag = T_Ch.ChStateFlag;
                ch.EmID = T_Ch.EmID;

                context.SaveChanges();
                context.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<T_Chumon> GetSyukkoNeedData(int chid)
        {
            List<T_Chumon> Chumon = new List<T_Chumon>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         where t1.ChID == chid
                         select new
                         {
                             t1.ClID,
                             t1.SoID,
                             t1.OrID,
                         };

                foreach (var p in tb)
                {
                    Chumon.Add(new T_Chumon()
                    {
                        ClID = p.ClID,
                        SoID = p.SoID,
                        OrID = p.OrID
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

        public int GetOrID(int chid)
        {
            int OrID = 0;

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         where t1.ChID == chid
                         select new
                         {
                             OrID = t1.OrID,
                         };

                foreach (var p in tb)
                {
                    OrID = p.OrID;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return OrID;
        }

        public bool RegistChumonData(T_Chumon t_Chumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Chumons.Add(t_Chumon);
                context.SaveChanges();
                context.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetChID(int OrID)
        {
            int ChID = 0;

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.T_Chumons
                         where t1.OrID == OrID
                         select new
                         {
                             t1.ChID
                         };

                foreach (var p in tb)
                {
                    ChID = p.ChID;
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ChID;
        }
        public bool GetStateflg(int chid) 
        {
            bool flg = false;
            try 
            {
                var context = new SalesManagement_DevContext();
                var tb = context.T_Chumons.Single(x => x.ChID == chid);
                var StateFlag = tb.ChStateFlag;
                if (StateFlag == 1)
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
    }
}
