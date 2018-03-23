using QuanLyHocBaTHPTPhamVanDong.DAO;
using QuanLyHocBaTHPTPhamVanDong.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocBaTHPTPhamVanDong
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        #region Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Thật Sự Muốn Thoát Chương Trình ?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbxUserName.Text;
            string passWord = tbxPassWord.Text;
            if(Login(userName,passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                TableManager f = new TableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
                tbxUserName.Text = "";
                tbxPassWord.Text = "";
                tbxUserName.Focus();
            }
            else
            {
                if(tbxPassWord.Text.Length == 0 || tbxUserName.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa Nhập Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxUserName.Text = "";
                    tbxPassWord.Text = "";
                    tbxUserName.Focus();
                }
                else
                {
                    MessageBox.Show("Bạn Đã Nhập Sai Tài Khoản Hoặc Mật Khẩu !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxPassWord.Text = "";
                    tbxPassWord.Focus();
                }
            }
        }
        #endregion
        #region Method
        bool Login(string userName,string passWord)
        {
            return AccountDAO.Instance.Login(userName,passWord);
        }
        #endregion
    }
}
