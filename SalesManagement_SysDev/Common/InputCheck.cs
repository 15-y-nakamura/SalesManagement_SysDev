using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (text == "")
            {
                return (false, "M9001");
            }

            return (true, text);
        }

        public (bool flg,string Msg) CheckSearchEmID(string text)
        {
            if (!CheckSuuti(text))
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

        public (bool flg,string Msg) CheckSearchEmPhone(string text)
        {
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
    }
}
