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
    public partial class ThongTinTaiKhoan : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }

        public ThongTinTaiKhoan(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        #region Event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void ThongTinTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Thật Sự Muốn Thoát ?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        #endregion
        #region methob
        private void ChangeAccount(Account acc)
        {
            tbxUserName.Text = acc.UserName;
            txtTenHienThi.Text = acc.Name;
            if (acc.Type == 1)
                txtLoaiTaiKhoan.Text = "admin";
            else txtLoaiTaiKhoan.Text = "staff";
        }
        private void UpdateAccount()
        {
            string displayName = txtTenHienThi.Text;
            string passWord = tbxPassWord.Text;
            string userName = tbxUserName.Text;
            string newPassWord = txtNewPassWord.Text;
            string reenterPassWord = txtNhapLaiPassWord.Text;
            if(!newPassWord.Equals(reenterPassWord))
            {
                MessageBox.Show("Vui Lòng Nhập Lại Mật Khẩu Đúng Với Mật Khẩu Mới !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPassWord.Text = "";
                txtNhapLaiPassWord.Text = "";
                tbxPassWord.Text = "";
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, passWord, displayName, newPassWord))
                {
                    MessageBox.Show("Cập Nhật Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxPassWord.Text = "";
                    txtNewPassWord.Text = "";
                    txtNhapLaiPassWord.Text = "";
                }
                else
                {
                    MessageBox.Show("Vui Lòng Điền Đúng Mật Khẩu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxPassWord.Text = "";
                    txtNewPassWord.Text = "";
                    txtNhapLaiPassWord.Text = "";
                }
            }
        }
        #endregion
    }
}
