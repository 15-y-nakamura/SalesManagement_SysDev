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

        public PasswordChangePage()
        {
            InitializeComponent();
        }

        private void KeepBtn_Click(object sender, EventArgs e)
        {
            //妥当なパスワードデータ取得
            if (!TextMatchCheck())
                return;

            /*5.2.2.2 商品カテゴリ情報作成
            var updCategory = GenerateDataAtUpdate();

            // 5.2.2.3 商品カテゴリ情報更新
            UpdateCategory(updCategory);*/

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
            // 新しいパスワードの適否
            if (!String.IsNullOrEmpty(NewPassTxb.Text.Trim()))
            {
                //新しいパスワードの半角英数字チェック
                if (!inputCheck.CheckHankakueisu(NewPassTxb.Text.Trim()))
                {
                    MessageBox.Show("パスワードは半角英数字です。");
                    NewPassTxb.Focus();
                    return false;
                }

                // 新しいパスワードの文字数チェック
                if (NewPassTxb.TextLength >= 11)
                {
                    MessageBox.Show("パスワードは10文字以下です。");
                    NewPassTxb.Focus();
                    return false;
                }

                //新しいパスワードの空欄チェック
                if (NewPassTxb.Text == null || NewPassTxb.Text.Trim() == "")
                {
                    MessageBox.Show("新しいパスワードが空欄です。");
                    RepeatPassTxb.Focus();
                    return false;
                }
            }

            // 新しいパスワード（確認用）の適否
            if (!String.IsNullOrEmpty(RepeatPassTxb.Text.Trim()))
            {
                //新しいパスワード（確認用）の空欄チェック
                if (RepeatPassTxb.Text == null || RepeatPassTxb.Text.Trim() == "")
                {
                    MessageBox.Show("新しいパスワード(確認用)が空欄です。");
                    RepeatPassTxb.Focus();
                    return false;
                }
            }

            //パスワード一致確認
            if (NewPassTxb.Text != RepeatPassTxb.Text)
            {
                MessageBox.Show("新しいパスワードと新しいパスワード(確認用)に入力された値が一致しません。");
                NewPassTxb.Focus();
                return false;
            }

            return true;

        }

        /*//////////////////////////////
        //　5.2.2.2 商品カテゴリ情報作成
        //メソッド名：GenerateDataAtUpdate()
        //引　数   ：なし
        //戻り値   ：商品カテゴリ更新情報
        //機　能   ：更新データのセット
        ///////////////////////////////
        private M_Employee GenerateDataAtUpdate()
        {
            string cParentCategory = "";

            // 商品カテゴリ情報の作成
            return new M_Employee
            {
                ParentCategory = cParentCategory,
                CategoryCD = textBoxCategoryCD.Text.Trim(),
                CategoryName = textBoxCategoryName.Text.Trim(),
                CategoryKana = textBoxCategoryKana.Text.Trim(),
                DeleteFlg = checkBoxDeleteFlg.Checked,
                Comments = textBoxComments.Text.Trim(),
            };
        }

        ///////////////////////////////
        //　5.2.2.3 商品カテゴリ情報更新
        //メソッド名：UpdateCategory()
        //引　数   ：商品カテゴリ情報
        //戻り値   ：なし
        //機　能   ：商品カテゴリ情報の更新
        ///////////////////////////////
        private void UpdateCategory(M_Employee updCategory)
        {
            //更新確認メッセージ
            DialogResult result = messageDsp.DspMsg("M4014");

            if (result == DialogResult.Cancel)
                return;

            //商品カテゴリ情報の登録
            bool flg = empDataAccess.UpdateCategoryData(updCategory);
            if (flg == true)
                //MessageBox.Show("データを更新しました。");
                messageDsp.DspMsg("M4015");
            else
                //MessageBox.Shoe("データの更新に失敗しました。");
                messageDsp.DspMsg("M4016");

            textBoxCategoryCD.Focus();

            //入力エリアのクリア
            ClearInput();

            //データグリッドビューの表示
            GetDataGridView();

        }*/

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            //現画面を非表示
            this.Visible = false;

            //TopButsuryuPageを表示
            LoginPage f2 = new LoginPage();
            f2.Show();
        }
    }
}
