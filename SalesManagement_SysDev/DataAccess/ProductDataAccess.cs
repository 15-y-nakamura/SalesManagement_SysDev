﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace SalesManagement_SysDev.DataAccess
{
    internal class ProductDataAccess
    {
        public IEnumerable<string> GetPrName()
        {
            var context = new SalesManagement_DevContext();

            try
            {
                var pPrName = context.M_Products.Select(x => x.PrName);

                IEnumerable<string> PrName = pPrName;
                return PrName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品IDの存在チェック
        //           商品IDが存在するときTrue
        //           商品IDが存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrID(int PrID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された商品IDに一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrID == PrID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrice()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：価格の存在チェック
        //           価格が存在するときTrue
        //           価格が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrice(decimal Price)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された価格に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.Price == Price);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrSafetyStock()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：安全在庫数の存在チェック
        //           安全在庫数が存在するときTrue
        //           安全在庫数が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrSafetyStock(int PrSafetyStock)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された安全在庫数に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrSafetyStock == PrSafetyStock);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }


        ///////////////////////////////
        //メソッド名：SonzaiCheckScID()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：小分類名の存在チェック
        //           小分類名が存在するときTrue
        //           小分類名が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckScID(int ScID)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された小分類名に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.ScID == ScID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckMaName()
        //引　数   ：数値
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：小分類名の存在チェック
        //           小分類名が存在するときTrue
        //           小分類名が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckMaName(string MaName)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力されたメーカ名に一致するデータが存在するか
                flg = context.M_Makers.Any(x => x.MaName == MaName);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrName()
        //引　数   ：文字
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品名の存在チェック
        //           商品名が存在するときTrue
        //           商品名が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrName(string PrName)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された商品名に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrName == PrName);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrModelNumber()
        //引　数   ：文字
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：型番の存在チェック
        //           型番が存在するときTrue
        //           型番が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrModelNumber(string PrModelNumber)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された型番に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrModelNumber == PrModelNumber);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckColor()
        //引　数   ：文字
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：型番の存在チェック
        //           型番が存在するときTrue
        //           型番が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrColor(string PrColor)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された型番に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrColor == PrColor);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SonzaiCheckPrReleaseDate()
        //引　数   ：文字
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品名の存在チェック
        //           商品名が存在するときTrue
        //           商品名が存在しないときFalse
        ///////////////////////////////
        public bool SonzaiCheckPrReleaseDate(DateTime PrReleaseDate)
        {
            bool flg = false;

            try
            {
                var context = new SalesManagement_DevContext();
                //入力された商品名に一致するデータが存在するか
                flg = context.M_Products.Any(x => x.PrReleaseDate == PrReleaseDate);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：RegistProduct()
        //引　数   ：M_Product
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品情報の登録
        //           登録が成功したときTrue
        //           登録が失敗したときFalse
        ///////////////////////////////
        public bool RegistProduct(M_Product regProduct)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Products.Add(regProduct);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }

        public bool UpdateProduct(M_Product regProduct)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var pro = context.M_Products.Single(x => x.PrID == regProduct.PrID);

                pro.MaID = regProduct.MaID;
                pro.PrID = regProduct.PrID;
                pro.PrName = regProduct.PrName;
                pro.Price = regProduct.Price;
                pro.PrSafetyStock = regProduct.PrSafetyStock;
                pro.ScID = regProduct.ScID;
                pro.PrModelNumber = regProduct.PrModelNumber;
                pro.PrColor = regProduct.PrColor;
                pro.PrReleaseDate = regProduct.PrReleaseDate;
                pro.PrFlag = regProduct.PrFlag;
                pro.PrHidden = regProduct.PrHidden;

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
        //メソッド名：DeleteProdact()
        //引　数   ：M_Product
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：商品情報の非表示
        //           成功したときTrue
        //           失敗したときFalse
        ///////////////////////////////
        public bool DeleteProduct(M_Product regProduct)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var pro = context.M_Products.Single(x => x.PrID == regProduct.PrID);

                pro.PrFlag = regProduct.PrFlag;
                pro.PrHidden = regProduct.PrHidden;

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
        //メソッド名：SearchEmployee()
        //引　数   ：M_ProduvtDsp
        //戻り値   ：M_ProductDsp
        //機　能   ：商品情報の検索
        ///////////////////////////////
        public List<M_ProductDsp> SearchProduct(M_Product regProduct, M_MajorClassification regMajorClassification)
        {
            List<M_ProductDsp> pro = new List<M_ProductDsp>();
            DateTime nulldate = DateTime.ParseExact("00010101", "yyyymmdd", null);

            // 商品ID選択
            if (regProduct.PrID != -1)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications on t3.McID equals t4.McID
                             where t1.PrID == regProduct.PrID &&
                                   t1.PrFlag == regProduct.PrFlag
                             select new
                             {
                                 t1.PrID,
                                 t1.PrName,
                                 t2.MaName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McName = p.McName,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、型番選択
            else if (regProduct.MaID != -1 && regProduct.PrModelNumber != "")
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications on t3.McID equals t4.McID
                             where t1.MaID == regProduct.MaID &&
                                   t1.PrModelNumber == regProduct.PrModelNumber &&
                                   t1.PrName.Contains(regProduct.PrName) &&
                                   t1.PrColor.Contains(regProduct.PrColor) &&
                                   t1.PrFlag == regProduct.PrFlag
                             select new
                             {
                                 t1.PrID,
                                 t1.PrName,
                                 t2.MaName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McName = p.McName,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //型番選択
            else if (regProduct.MaID == -1 && regProduct.PrModelNumber != "")
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications on t3.McID equals t4.McID
                             where t1.PrModelNumber == regProduct.PrModelNumber &&
                                   t1.PrName.Contains(regProduct.PrName) &&
                                   t1.PrColor.Contains(regProduct.PrColor) &&
                                   t1.PrFlag == regProduct.PrFlag
                             select new
                             {
                                 t1.PrID,
                                 t1.PrName,
                                 t2.MaName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            McName = p.McName,
                            ScName = p.ScName,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、大分類、小分類、発売日選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t3.McID == regMajorClassification.McID &&
                             t1.ScID == regProduct.ScID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //大分類、小分類、発売日選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t3.McID == regMajorClassification.McID &&
                             t1.ScID == regProduct.ScID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、小分類、発売日選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t1.ScID == regProduct.ScID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、大分類、発売日選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t3.McID == regMajorClassification.McID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、大分類、小分類選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t3.McID == regMajorClassification.McID &&
                             t1.ScID == regProduct.ScID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、大分類選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t3.McID == regMajorClassification.McID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、小分類選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID && 
                             t1.ScID == regProduct.ScID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー、発売日選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //小分類、発売日選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.ScID == regProduct.ScID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //大分類、発売日選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t3.McID == regMajorClassification.McID &&
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //大分類、小分類選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t3.McID == regMajorClassification.McID &&
                             t1.ScID == regProduct.ScID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //メーカー選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.MaID == regProduct.MaID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //大分類選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate == nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t3.McID == regMajorClassification.McID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //小分類選択
            else if (regProduct.MaID != -1 && regMajorClassification.McID != -1 &&
                    regProduct.ScID != -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.ScID == regProduct.ScID &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //発売日選択
            else if (regProduct.MaID == -1 && regMajorClassification.McID == -1 &&
                    regProduct.ScID == -1 && regProduct.PrReleaseDate != nulldate)
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where
                             t1.PrReleaseDate == regProduct.PrReleaseDate &&
                             t1.PrName.Contains(regProduct.PrName) &&
                             t1.PrFlag == regProduct.PrFlag &&
                            (t1.PrHidden.Contains(regProduct.PrHidden) ||
                             t1.PrHidden == null) &&
                             t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //選択なし
            else
            {
                try
                {
                    var context = new SalesManagement_DevContext();
                    // tbはIEnumerable型
                    var tb = from t1 in context.M_Products
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_SmallClassifications
                             on t1.ScID equals t3.ScID
                             join t4 in context.M_MajorCassifications
                             on t3.McID equals t4.McID
                             where t1.PrName.Contains(regProduct.PrName) &&
                                    t1.PrFlag == regProduct.PrFlag &&
                                    (t1.PrHidden.Contains(regProduct.PrHidden) ||
                                    t1.PrHidden == null) &&
                                    t1.PrColor.Contains(regProduct.PrColor)

                             select new
                             {
                                 t1.PrID,
                                 t2.MaName,
                                 t1.PrName,
                                 t4.McName,
                                 t3.ScName,
                                 t1.Price,
                                 t1.PrSafetyStock,
                                 t1.PrModelNumber,
                                 t1.PrColor,
                                 t1.PrReleaseDate,
                                 t1.PrFlag,
                                 t1.PrHidden
                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        pro.Add(new M_ProductDsp()
                        {
                            PrID = p.PrID,
                            MaName = p.MaName,
                            PrName = p.PrName,
                            McName = p.McName,
                            ScName = p.ScName,
                            Price = p.Price,
                            PrSafetyStock = p.PrSafetyStock,
                            PrModelNumber = p.PrModelNumber,
                            PrColor = p.PrColor,
                            PrReleaseDate = p.PrReleaseDate,
                            PrFlag = p.PrFlag,
                            PrHidden = p.PrHidden
                        });
                    }
                    context.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return pro;
        }


        ///////////////////////////////
        //メソッド名：GetProductData()
        //引　数   ：なし
        //戻り値   ：List<M_ProductDsp>
        //機　能   ：全商品データの取得
        ///////////////////////////////
        public List<M_ProductDsp> GetProductData()
        {
            List<M_ProductDsp> Pro = new List<M_ProductDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                var tb = from t1 in context.M_Products
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_SmallClassifications
                         on t1.ScID equals t3.ScID
                         join t4 in context.M_MajorCassifications
                         on t3.McID equals t4.McID
                         where t1.PrFlag == 0
                         select new
                         {
                             t1.PrID,
                             t2.MaName,
                             t1.PrName,
                             t3.ScName,
                             t4.McName,
                             t1.Price,
                             t1.PrSafetyStock,
                             t1.PrModelNumber,
                             t1.PrColor,
                             t1.PrReleaseDate,
                             t1.PrFlag,
                             t1.PrHidden
                         };

                foreach(var p in tb)
                {
                    Pro.Add(new M_ProductDsp()
                    {
                        PrID = p.PrID,
                        MaName = p.MaName,
                        PrName = p.PrName,
                        Price = p.Price,
                        PrSafetyStock = p.PrSafetyStock,
                        McName = p.McName,
                        ScName = p.ScName,
                        PrModelNumber = p.PrModelNumber,
                        PrColor = p.PrColor,
                        PrReleaseDate = p.PrReleaseDate,
                        PrFlag = p.PrFlag,
                        PrHidden = p.PrHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Pro;
        }

        ///////////////////////////////
        //メソッド名：GetScID()
        //引　数   ：なし
        //戻り値   ：取得した小分類ID
        //機　能   ：小分類ID取得
        ///////////////////////////////
        public int GetScID(string scid)
        {
            int Scid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_SmallClassifications
                         where t1.ScName == scid
                         select new
                         {
                             t1.ScID
                         };

                foreach (var p in tb)
                {
                    Scid = p.ScID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Scid;
        }

        ///////////////////////////////
        //メソッド名：GetMaID()
        //引　数   ：なし
        //戻り値   ：取得したメーカーID
        //機　能   ：メーカーID取得
        ///////////////////////////////
        public int GetMaID(string maname)
        {
            int Maid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Makers
                         where t1.MaName == maname
                         select new
                         {
                             t1.MaID
                         };

                foreach (var p in tb)
                {
                    Maid = p.MaID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Maid;
        }

        ///////////////////////////////
        //メソッド名：GetPrID()
        //引　数   ：なし
        //戻り値   ：取得したメーカID
        //機　能   ：メーカID取得
        ///////////////////////////////
        public int GetPrID(string prname)
        {
            int prid = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Products
                         where t1.PrName == prname
                         select new
                         {
                             t1.PrID
                         };

                foreach (var p in tb)
                {
                    prid = p.PrID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return prid;
        }

        public decimal GetPrice(string prname)
        {
            decimal price = 0;

            var context = new SalesManagement_DevContext();
            try
            {
                var tb = from t1 in context.M_Products
                         where t1.PrName == prname
                         select new
                         {
                             t1.Price
                         };

                foreach (var p in tb)
                {
                    price = p.Price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return price;
        }
    }
}
