using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SalesManagement_SysDev
{
    internal class InputCheck
    {
        //社員テーブルアクセスクラスのインスタンス化
        EmployeeDataAccess EmployeeDA = new EmployeeDataAccess();

        //商品テーブルアクセスクラスのインスタンス化
        ProductDataAccess ProductDA = new ProductDataAccess();

        //受注テーブルアクセスクラスのインスタンス化
        OrderDataAccess JuchuDA = new OrderDataAccess();

        //商品テーブルアクセスクラスのインスタンス化
        ShohinDataAccess ShohinDA = new ShohinDataAccess();

        //顧客テーブルアクセスクラスのインスタンス化
        ClientDataAccess ClientDA = new ClientDataAccess();

        //注文テーブルアクセスクラスのインスタンス化
        ChumonDataAccess ChumonDA = new ChumonDataAccess();

        ///////////////////////////////
        //メソッド名：CheckZenkaku()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：全角文字のチェック
        //           全角文字のときTrue
        //           全角文字以外のときFalse
        ///////////////////////////////
        public bool CheckZenkaku(string text)
        {
            int textLength = text.Replace("\r\n", string.Empty).Length;
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(text.Replace("\r\n", string.Empty));

            if (textByte == textLength * 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：CheckSuuti()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：半角数字のチェック
        //           半角数字のときTrue
        //           半角数字以外のときFalse
        ///////////////////////////////
        public bool CheckSuuti (string text)
        {
            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：CheckSuutiHaihun()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：半角数字とハイフンのチェック
        //           半角数字ハイフンのときTrue
        //           半角数字ハイフン以外のときFalse
        ///////////////////////////////
        public bool CheckSuutiHaihun(string text)
        {
            Regex regex = new Regex("^[0-9-]+$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：CheckHankakueisu()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：半角英数字のチェック
        //           半角英数字のときTrue
        //           半角英数字以外のときFalse
        ///////////////////////////////
        public bool CheckHankakueisu (string text)
        {
            Regex regex = new Regex("[a-zA-Z0-9]+$");
            if (!regex.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        ///////////////////////////////
        //メソッド名：CheckPhoneFAX()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：電話番号形式／FAX形式のチェック
        //           電話番号形式／FAX形式のときTrue
        //           電話番号形式／FAX形式以外のときFalse
        ///////////////////////////////
        public bool CheckPhoneFAX(string text)
        {
            Regex regex = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}$");
            if (regex.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        ///////////////////////////////
        //メソッド名：CheckDate()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：日付形式のチェック
        //           日付形式のときTrue
        //           日付形式以外のときFalse
        ///////////////////////////////
        public bool CheckDate(string text)
        {
            Regex regex = new Regex("[0-9]{4}/[0-3]{2}/[0-9]{2}$");
            if (!regex.IsMatch(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///////////////////////////////
        //メソッド名：CheckRegistEmID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の社員ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg,string Msg) CheckRegistEmID(string text)
        {
            if (text == "")
            {               
                return(false, "M4003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M4001");
            }

            if (EmployeeDA.SonzaiCheckEmID(int.Parse(text)))
            {
                return (false, "M4004");
            }

            if (text.Length > 6)
            {
                return (false, "M4002");
            }

            return(true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckEmID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：社員ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckEmID(string text)
        {
            if (text == "")
            {
                return (false, "M4003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M4001");
            }
            
            if (text.Length > 6)
            {
                return (false, "M4002");
            }
            
            if (!EmployeeDA.SonzaiCheckEmID(int.Parse(text)))
            {
                return (false, "M4022");
            }            

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckEmname()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：社員名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg,string Msg) CheckEmname(string text)
        {
            if (text == "")
            {
                return (false, "M4007");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M4005");
            }

            if(text.Length > 50)
            {
                return (false, "M4006");
            }

            return(true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckEmPhone()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：電話番号入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg,string Msg) CheckEmPhone(string text)
        {
            if (text == "")
            {
                return (false, "M4016");
            }

            if (!CheckSuutiHaihun(text))
            {
                return (false, "M4015");
            }

            if (text.Length < 12)
            {
                return (false, "M4030");
            }

            if (text.Length > 13)
            {
                return (false, "M4015");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckSoNameCmb()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：営業名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg,string Msg) CheckSoNameCmb (string text)
        {
            if(text == "")
            {
                return (false, "M4008");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPoNameCmb()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：役職名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg,string Msg) CheckPoNameCmb (string text)
        {
            if (text == "")
            {
                return (false, "M4009");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckEmFlagCmb()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：社員管理フラグ入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg,string Msg) CheckEmFlagCmb (string text)
        {
            if (text == "")
            {
                return (false, "M4017");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckHidden()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：非表示理由入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckHidden(string text)
        {
            if(text == "")
            {
                return (false, "M9001");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の商品ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistPrID(string text)
        {
            if(text == "")
            {
                return (false, "M2003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M2001");
            }

            if (ProductDA.SonzaiCheckPrID(int.Parse(text)))
            {
                return (false, "M2004");
            }
            
            if (text.Length > 6)
            {
                return (false, "M2002");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の商品ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckSearchPrID(string text)
        {
            if (text == "")
            {
                return (false, "M2003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M2001");
            }

            if (text.Length > 6)
            {
                return (false, "M2002");
            }

            return (true, text);
        }

        public (bool flg, string Msg) CheckPrID(string text)
        {
            if (text == "")
            {
                return (false, "M2003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M2001");
            }

            if (!ProductDA.SonzaiCheckPrID(int.Parse(text)))
            {
                return (false, "M2029");
            }

            if (text.Length > 6)
            {
                return (false, "M2002");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistJuchuID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の受注ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistJuchuID(string text)
        {
            if (text == "")
            {
                return (false, "M6003");
            }
            
            if(!CheckSuuti(text))
            {
                return (false, "M6001");
            }

            if (JuchuDA.SonzaiCheckOrID(int.Parse(text)))
            {
                return (false, "M6004");
            }

            return (true, text);
        }

        public (bool flg,string Msg) CheckSearchEmID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M4001");
            }

            //if (!EmployeeDA.SonzaiCheckEmID(int.Parse(text)))
            //{
            //    return (false, "M4022");
            //}

            if (text.Length > 6)
            {
                return (false, "M4002");
            }
            return (true, text);
        }        
        ///////////////////////////////
        //メソッド名：CheckRegistOrID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の受注ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistOrID(string text)
        {
            if (text == "")
            {
                return (false, "M6003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M6001");
            }

            if (text.Length > 6)
            {
                return (false, "M6002");
            }

            return (true, text);
        }
        

        ///////////////////////////////
        //メソッド名：CheckRegistOrID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の受注ID存在チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckOrID(string text)
        {
            if (JuchuDA.SonzaiCheckOrID(int.Parse(text)))
            {
                return (false, "");
            }

            return (true, text);
        }



        public (bool flg,string Msg) CheckSearchEmname(string text)
        {
            if (!CheckZenkaku(text))
            {
                return (false, "M4005");
            }

            if (text.Length > 50)
            {
                return (false, "M4006");
            }


            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchEmPhone(string text)
        {
            if (!CheckSuutiHaihun(text))
            {
                return (false, "M4015");
            }

            if (text.Length < 12)
            {
                return (false, "M4030");
            }

            if (text.Length > 13)
            {
                return (false, "M4015");
            }

            if (text.Length < 12)
            {
                return (false, "M4030");
            }
            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrName()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：商品名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrName(string text)
        {
            if(text == "")
            {
                return (false, "M2008");
            }

            if (CheckZenkaku(text))
            {
                return (false, "M2006");
            }

            if (!ProductDA.SonzaiCheckPrName(text))
            {
                return (false, "M2030");
            }
          
            if (text.Length > 50)
            {
                return (false, "M2007");
            }
            return(true, text);
        }

        public (bool flg, string Msg) CheckSearchPrName(string text)
        {
            if (text == "")
            {
                return (false, "M2007");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M2005");
            }

            if (text.Length < 50)
            {
                return (false, "M2006");
            }
            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckJuchuSoNameCmb()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：営業名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckJuchuSoNameCmb(string text)
        {
            if (text == "")
            {
                return (false, "M6004");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckClname()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：顧客名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckClname(string text)
        {
            if (text == "")
            {
                return (false, "M1006");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M1004");

            }

            if (text.Length > 50)
            {
                return (false, "M1005");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistOrDetailID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の受注詳細ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistOrDetailID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M6013");
            }

            if (text.Length > 6)
            {
                return (false, "M6014");
            }

            if (text == "")
            {
                return (false, "M6015");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrMaker()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：メーカー名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrMaker(string text)
        {
            if (text == "")
            {
                return (false, "M2005");
            }

            return (true, text);
        }       
                
        ///////////////////////////////
        //メソッド名：CheckRegistClID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の顧客ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistClID(string text)
        {
            if (text == "")
            {
                return (false, "M1003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M1001");
            }

            if (EmployeeDA.SonzaiCheckClID(int.Parse(text)))
            {
                return (false, "M1032");
            }

            if (text.Length > 6)
            {
                return (false, "M1002");
            }
            return (true, text);
        } 

        ///////////////////////////////
        //メソッド名：CheckPrice()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：価格入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrice(string text)
        {
            if (text == "")
            {
                return (false, "M2011");
            }

            if(text.Length > 9)
            {
                return (false, "M2010");
            }

            if (CheckSuuti(text))
            {
                return (false, "M2009");
            }

            return(true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckCheckPrSafetyStock()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：安全在庫数入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrSafetyStock(string text)
        {
            if(text == "")
            {
                return (false, "M2014");
            }

            if(text.Length > 4)
            {
                return (false,"M2013");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M2012");
            }

            return(true, text);
        }


        ///////////////////////////////
        //メソッド名：CheckMcID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：大分類ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckMcID(string text)
        {
            if (text == "")
            {
                return (false, "M2014");
            }
            return (true, text);
        }

        //////////////////////////////////
        //メソッド名：CheckClPhone()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：電話番号入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckClPhone(string text)
        {
            if (text == "")
            {
                return (false, "M1012");
            }

            if (!CheckSuutiHaihun(text))
            {
                return (false, "M1010");
            }

            if(text.Length >13)
            {
                return (false, "M1011");
            }

            if(text.Length < 12)
            {
                return (false, "M1033");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistOrderEmid()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：社員ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistOrderEmID(string text)
        {
            if (text == "")
            {
                return (false, "M4003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M4001");
            }

            if (!EmployeeDA.SonzaiCheckEmID(int.Parse(text)))
            {
                return (false, "M6005");
            }

            if (text.Length > 6)
            {
                return (false, "M4002");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckSearchOrderEmid()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：社員ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckSearchOrderEmID(string text)
        {
            if (text == "")
            {
                return (false, "M4003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M4001");
            }

            if (text.Length > 6)
            {
                return (false, "M4002");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistOrderClID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の顧客ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistOrderClID(string text)
        {
            if (text == "")
            {
                return (false, "M1003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M1001");
            }

            if (!ClientDA.SonzaiCheckCIID(int.Parse(text)))
            {
                return (false, "M6006");
            }

            if (text.Length > 6)
            {
                return (false, "M1002");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckSearchClID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の顧客ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckSearchOrderClID(string text)
        {
            if (text == "")
            {
                return (false, "M1003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M1001");
            }

            if (text.Length > 6)
            {
                return (false, "M1002");
            }

            return (true, text);
        }


        ///////////////////////////////
        //メソッド名：CheckRegistClTantoName()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の顧客担当者名の入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistClTantoName(string text)
        {
            if (text == "")
            {
                return (false, "M6009");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M6007");
            }

            if (text.Length > 50)
            {
                return (false, "M6008");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistSuryo()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の数量入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistSuryo(string text)
        {
            if (text == "")
            {
                return (false, "M6019");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M6017");
            }

            if (text.Length > 4)
            {
                return (false, "M6018");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckScID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：小分類ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg)CheckScID (string text)
        {
            if(text == "")
            {
                return (false, "M2016");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckSoNameEiCmb()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：営業名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckSoNameEiCmb(string text)
        {
            if (text == "")
            {
                return (false, "M1007");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrModelNumber()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：型番入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg)CheckPrModelNumber (string text)
        {
            if (text == "")
            {
                return (false, "M2019");
            }

            if (text.Length > 20)
            {
                return (false, "M2018");
            }

            if (CheckHankakueisu(text))
            {
                return (false, "M2017");
            }

            return(true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrColor()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：色入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg)CheckPrColor (string text)
        {
            if(text == "")
            {
                return (false, "M2022");
            }

            if(text.Length > 20)
            {
                return (false, "M2021");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M2020");
            }

            return (true, text);
        }

        //////////////////////////////////       
        //メソッド名：CheckClYubin()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：郵便番号入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckClYubin(string text)
        {
            if (text == "")
            {
                return (false, "M1015");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M1013");
            }

            if (text.Length != 7)
            {
                return (false, "M1014");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckClJusho()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：住所入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckClJusho(string text)
        {
            if (text == "")
            {
                return (false, "M1009");
            }

            if (text.Length > 50)
            {
                return (false, "M1008");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckRegistGokeiKingaku()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の合計金額入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistGokeiKingaku(string text)
        {
            if (CheckSuuti(text))
            {
                return (false, "M6020");
            }

            if (text.Length > 10)
            {
                return (false, "M6021");
            }

            if (text == "")
            {
                return (false, "M6022");
            }

            return (true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckPrReleaseDate()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：発売日入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrReleaseDate (string text)
        {
            if(text ==  "")
            {
                return (false, "M2023");
            }

            return (true, text);
        }
               
        //メソッド名：CheckRegistShohinID()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：登録する時の商品ID入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckRegistOrderShohinID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M2001");
            }

            if (text.Length > 10)
            {
                return (false, "M2002");
            }

            if (text == "")
            {
                return (false, "M2003");
            }

            return (true, text);
        }


        ///////////////////////////////
        //メソッド名：CheckPrFlag()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：商品管理フラグ入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrFlag (string text)
        {
            if(text == "")
            {
                return (false, "M2023");
            }

            return (true, text);
        }
      
        //////////////////////////////////
        //メソッド名：CheckClFax()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：FAX入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        //////////////////////////////////
        public (bool flg, string Msg) CheckClFax(string text)
        {
            if (text == "")
            {
                return (false, "M1018");
            }

            if (!CheckSuutiHaihun(text))
            {
                return (false, "M1016");
            }

            if (text.Length > 13)
            {
                return (false, "M1017");
            }

            if (text.Length < 12)
            {
                return (false, "M1034");
            }


            return (true, text);
        }

        public (bool flg, string Msg) CheckClID(string text)
        {
            if (text == "")
            {
                return (false, "M1003");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M1001");
            }

            if (text.Length > 6)
            {
                return (false, "M2002");
            }

            if (!EmployeeDA.SonzaiCheckClID(int.Parse(text)))
            {
                return (false, "M1024");
            }


            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchClID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M1001");
            }

            if (text.Length > 6)
            {
                return (false, "M1002");
            }

            if (!EmployeeDA.SonzaiCheckClID(int.Parse(text)))
            {
                return (false, "M1024");
            }

            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchClname(string text)
        {
            if (!CheckZenkaku(text))
            {
                return (false, "M1004");
            }

            if (text.Length > 50)
            {
                return (false, "M1005");
            }

            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchClPhone(string text)
        {
            if (!CheckSuutiHaihun(text))
            {
                return (false, "M1010");
            }

            if (text.Length > 13)
            {
                return (false, "M1011");
            }
            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchClYubin(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M1013");
            }

            if (text.Length > 7)
            {
                return (false, "M1014");
            }
            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchClFax(string text)
        {
            if (!CheckSuutiHaihun(text))
            {
                return (false, "M1016");
            }

            if (text.Length > 13)
            {
                return (false, "M1017");
            }
            return (true, text);
        }

        public (bool flg, string Msg) CheckSearchChID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M7001");
            }

            if(text.Length > 7)
            {
                return (false, "M7002");
            }

            return (true, text);
        }

        public (bool flg, string Msg) CheckChdID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M7017");
            }

            if (text.Length > 7)
            {
                return (false, "M7018");
            }

            return (true, text);
        }

        public (bool flg, string Msg) CheckChID(string text)
        {
            if (!CheckSuuti(text))
            {
                return (false, "M7001");
            }

            if (text.Length > 7)
            {
                return (false, "M7002");
            }

            if (ChumonDA.SonzaiCheckChID(int.Parse(text)))
            {
                return (false, "M7027");
            }

            return (true, text);
        }
    }
}
