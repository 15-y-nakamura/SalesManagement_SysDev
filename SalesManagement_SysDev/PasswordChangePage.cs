using SalesManagement_SysDev.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class PasswordChangePage : Form
    {
        MessageDsp messageDsp = new MessageDsp();
        EmployeeDataAccess empDataAccess = new EmployeeDataAccess();
        InputCheck inputCheck = new InputCheck();

        internal static int EmID = 0;

        public PasswordChangePage()
        {
            InitializeComponent();
        }

        private void KeepBtn_Click(object sender, EventArgs e)
        {
            //妥当なパスワードデータ取得
            if (!TextMatchCheck())
            {
                return;
            }
  
            var updCategory = GenerateDataAtUpdate();

            UpdatePassward(updCategory);
        }

        ///////////////////////////////
        //妥当なパスワードデータ取得
        //メソッド名：TextMatchCheck()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool TextMatchCheck()
        {
            //新しいパスワードの空欄チェック
            if (NewPassTxb.Text == null || NewPassTxb.Text.Trim() == "")
            {
                messageDsp.DspMsg("M4013");
                RepeatPassTxb.Focus();
                return false;
            }

            //新しいパスワードの半角英数字チェック
            if (!inputCheck.CheckHankakueisu(NewPassTxb.Text.Trim()))
            {
                messageDsp.DspMsg("M4011");
                NewPassTxb.Focus();
                return false;
            }

            // 新しいパスワードの文字数チェック
            if (5 > NewPassTxb.TextLength || NewPassTxb.TextLength > 10)
            {
                messageDsp.DspMsg("M4012");
                NewPassTxb.Focus();
                return false;
            }

            
            //新しいパスワード（確認用）の空欄チェック
            if (RepeatPassTxb.Text == null || RepeatPassTxb.Text.Trim() == "")
            {
                messageDsp.DspMsg("M1101");
                RepeatPassTxb.Focus();
                return false;
            }
            

            //パスワード一致確認
            if (NewPassTxb.Text != RepeatPassTxb.Text)
            {
                messageDsp.DspMsg("M1102");
                NewPassTxb.Focus();
                return false;
            }

            return true;

        }

        
        private M_Employee GenerateDataAtUpdate()
        {
            return new M_Employee
            {
                EmID = EmID,
                EmPassword = NewPassTxb.Text
            };
        }
        
        private void UpdatePassward(M_Employee updCategory)
        {
            if (DialogResult.OK == messageDsp.DspMsg("M1103"))
            {
                if (empDataAccess.UpdatePassword(updCategory))
                {
                    messageDsp.DspMsg("M1104");
                }
                else
                {
                    messageDsp.DspMsg("M1105");
                    return;
                }
                
            }

            //入力エリアのクリア
            NewPassTxb.Text = "";
            RepeatPassTxb.Text = "";
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            //フォームを閉じる確認メッセージの表示
            DialogResult result = messageDsp.DspMsg("M0001");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                this.Close();
            }
        }
    }
}
