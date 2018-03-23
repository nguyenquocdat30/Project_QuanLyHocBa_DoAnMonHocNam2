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
    public partial class TableManager : Form
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
                QuyenTruyCap(loginAccount.Type);
            }
        }

        public TableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            SetDataGridView();
        }
        #region Event
        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mọi Thông Tin Vui Lòng Liên Hệ - Nguyễn Quốc Đạt - 01643127775","Liên Hệ",MessageBoxButtons.OK,MessageBoxIcon.Question);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan f = new ThongTinTaiKhoan(LoginAccount);
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SetQuyenTruyCap(LoginAccount))
            {
                fAdmin f = new fAdmin();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Không Có Quyền Đăng Nhập Vào Phần Quản Trị !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void TableManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Thật Sự Muốn Thoát ?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan f = new ThongTinTaiKhoan(LoginAccount);
            f.ShowDialog();
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (SetQuyenTruyCap(LoginAccount))
            {
                fAdmin f = new fAdmin();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Không Có Quyền Đăng Nhập Vào Phần Quản Trị !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }
        #endregion
        #region methob
        private void SetDataGridView()
        {
            dgvTongKet.DataSource = GetTongKetDAO.Instance.GetTongKet();
        }
        private bool SetQuyenTruyCap(Account login)
        {
            if (login.Type == 1) return true;
            else return false;
        }
        private void QuyenTruyCap(int Type)
        {
            btnAdmin.Enabled = Type == 1;
            adminToolStripMenuItem.Enabled = Type == 1;
        }
        #endregion
    }
}
