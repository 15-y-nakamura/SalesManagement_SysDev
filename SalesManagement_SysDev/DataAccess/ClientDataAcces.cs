﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ClientDataAccess
    {
        ///////////////////////////////
        //メソッド名：GetClientData()
        //引　数   ：なし
        //戻り値   ：List<M_ClientDsp>
        //機　能   ：全顧客データの取得
        ///////////////////////////////
        public List<M_ClientDsp> GetClientData()
        {
            List<M_ClientDsp> Cli = new List<M_ClientDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.M_Clients
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         select new
                         {
                             t1.ClID,
                             t1.ClName,
                             t2.SoName,
                             t1.ClPhone,
                             t1.ClPostal,
                             t1.ClAddress,
                             t1.ClFAX,
                             t1.ClFlag,
                             t1.ClHidden
                         };

                foreach (var p in tb)
                {
                    Cli.Add(new M_ClientDsp()
                    {
                        ClID = p.ClID,
                        ClName = p.ClName,
                        SoName = p.SoName,
                        ClPhone = p.ClPhone,
                        ClPostal = p.ClPostal,
                        ClAddress = p.ClAddress,
                        ClFax = p.ClFAX,
                        ClFlag = p.ClFlag,
                        ClHidden = p.ClHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Cli;
        }

        ///////////////////////////////
        //メソッド名：RegistClient()
        //引　数   ：M_Client
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：顧客情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistClient(M_Client regClient)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Clients.Add(regClient);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateClient(M_Client regClient)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var cli = context.M_Clients.Single(x => x.ClID == regClient.ClID);

                cli.ClName = regClient.ClName;
                cli.SoID = regClient.SoID;
                cli.ClPhone = regClient.ClPhone;
                cli.ClPostal = regClient.ClPostal;
                cli.ClAddress = regClient.ClAddress;
                cli.ClFAX = regClient.ClFAX;
                cli.ClFlag = regClient.ClFlag;
                cli.ClHidden = regClient.ClHidden;

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
        //メソッド名：GetCIID()
        //引　数   ：なし
        //戻り値   ：取得した顧客ID
        //機　能   ：顧客ID取得
        ///////////////////////////////
        public int GetCIID(string ciname)
        {
            int ciid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Clients
                         where t1.ClName == ciname
                         select new
                         {
                             t1.ClID
                         };

                foreach (var p in tb)
                {
                    ciid = p.ClID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return ciid;
        }

        public List<M_ClientDsp> SearchClient(M_Client regClient)
        {
            List<M_ClientDsp> cli = new List<M_ClientDsp>();

            if (regClient.ClID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClID == regClient.ClID
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (regClient.ClID == 0 && regClient.ClFlag == -1 && regClient.SoID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) ||
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX)
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (regClient.ClID != 0 && regClient.ClFlag == -1 && regClient.SoID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) ||
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX)  &&
                                   t1.ClID == (regClient.ClID)
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (regClient.ClID == 0 && regClient.ClFlag != -1 && regClient.SoID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t1.ClFlag == regClient.ClFlag
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (regClient.ClID == 0 && regClient.ClFlag == -1 && regClient.SoID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t2.SoID == regClient.SoID
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (regClient.ClID == 0 && regClient.ClFlag != -1 && regClient.SoID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t2.SoID == regClient.SoID &&
                                   t1.ClFlag == regClient.ClFlag
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (regClient.ClID != 0 && regClient.ClFlag != -1 && regClient.SoID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t2.SoID == regClient.SoID &&
                                   t1.ClFlag == regClient.ClFlag &&
                                   t1.ClID == regClient.ClID
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (regClient.ClID != 0 && regClient.ClFlag == -1 && regClient.SoID != 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t2.SoID == regClient.SoID &&
                                   t1.ClID == regClient.ClID
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (regClient.ClID != 0 && regClient.ClFlag != -1 && regClient.SoID == 0)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Clients
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             where t1.ClName.Contains(regClient.ClName) &&
                                   (t1.ClHidden.Contains(regClient.ClHidden) || 
                                   t1.ClHidden == null) &&
                                   t1.ClPhone.Contains(regClient.ClPhone) &&
                                   t1.ClPostal.Contains(regClient.ClPostal) &&
                                   t1.ClAddress.Contains(regClient.ClAddress) &&
                                   t1.ClFAX.Contains(regClient.ClFAX) &&
                                   t1.ClFlag == regClient.ClFlag &&
                                   t1.ClID == regClient.ClID
                             select new
                             {
                                 t1.ClID,
                                 t1.ClName,
                                 t2.SoName,
                                 t1.ClPhone,
                                 t1.ClPostal,
                                 t1.ClAddress,
                                 t1.ClFAX,
                                 t1.ClFlag,
                                 t1.ClHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        cli.Add(new M_ClientDsp()
                        {
                            ClID = p.ClID,
                            ClName = p.ClName,
                            SoName = p.SoName,
                            ClPhone = p.ClPhone,
                            ClPostal = p.ClPostal,
                            ClAddress = p.ClAddress,
                            ClFax = p.ClFAX,
                            ClFlag = p.ClFlag,
                            ClHidden = p.ClHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            return cli;
        }

        public bool DeleteClient(M_Client regClient)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var cli = context.M_Clients.Single(x => x.ClID == regClient.ClID);

                cli.ClFlag = regClient.ClFlag;
                cli.ClHidden = regClient.ClHidden;

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
