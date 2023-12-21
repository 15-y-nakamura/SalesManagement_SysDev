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

            if (CheckSuuti(text))
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

        public (bool flg, string Msg) CheckEmID(string text)
        {
            if (text == "")
            {
                return (false, "M4003");
            }

            if (CheckSuuti(text))
            {
                return (false, "M4001");
            }

            if (!EmployeeDA.SonzaiCheckEmID(int.Parse(text)))
            {
                return (false, "M4022");
            }

            if (text.Length > 6)
            {
                return (false, "M4002");
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

            if (!CheckPhoneFAX(text))
            {
                return (false, "M4014");
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

        public (bool flg, string Msg) CheckHidden(string text)
        {
            if (text == "")
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
                return (false, "M2036");
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

            if (ProductDA.SonzaiCheckPrID(int.Parse(text)))
            {
                return (false, "M2028");
            }

            if (text.Length > 6)
            {
                return (false, "M2002");
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
                return (false, "M2007");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M2005");
            }

            if (ProductDA.SonzaiCheckPrName(text))
            {
                return (false, "M2029");
            }

            if (text.Length > 50)
            {
                return (false, "M2006");
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
                return (false, "M2004");
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
                return (false, "M2010");
            }

            if(text.Length > 9)
            {
                return (false, "M2009");
            }

            if (CheckSuuti(text))
            {
                return (false, "M2008");
            }

            return(true, text);
        }

        ///////////////////////////////
        //メソッド名：CheckCheckPrSafetyStock()
        //引　数   ：文字列
        //戻り値   ：(True:異常なし、False:異常あり,文字列)
        //機　能   ：商品名入力チェック
        //           問題がないときTrue、文字列
        //           問題があるときFalse、メッセージID
        ///////////////////////////////
        public (bool flg, string Msg) CheckPrSafetyStock(string text)
        {
            if(text == "")
            {
                return (false, "M2013");
            }

            if(text.Length > 4)
            {
                return (false,"M2012");
            }

            if (!CheckSuuti(text))
            {
                return (false, "M2011");
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
                return (false, "M2015");
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
                return (false, "M2018");
            }

            if (text.Length > 20)
            {
                return (false, "M2017");
            }

            if (CheckHankakueisu(text))
            {
                return (false, "M2016");
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
                return (false, "M2021");
            }

            if(text.Length > 20)
            {
                return (false, "M2020");
            }

            if (!CheckZenkaku(text))
            {
                return (false, "M2019");
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
                return (false, "M2022");
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
    }
}
