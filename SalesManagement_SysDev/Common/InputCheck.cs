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
        //メソッド名：CheckPhone()
        //引　数   ：文字列
        //戻り値   ：True:異常なし、False:異常あり
        //機　能   ：電話番号形式／FAX形式のチェック
        //           電話番号形式／FAX形式のときTrue
        //           電話番号形式／FAX形式以外のときFalse
        ///////////////////////////////
        public bool CheckPhoneFAX(string text)
        {
            Regex regex = new Regex("[0-9]{3}-[0-9]{4}-[0-9]{4}$");
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
    }
}
