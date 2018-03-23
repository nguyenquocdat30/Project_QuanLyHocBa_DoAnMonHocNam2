using QuanLyHocBaTHPTPhamVanDong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new AccountDAO();
                }
                return AccountDAO.instance;
            }

            private set
            {
                AccountDAO.instance = value;
            }
        }

        private AccountDAO() { }
        public bool Login(string userName,string passWord)
        {
            string query = "USP_LOGIN @USERNAME , @PASSWORD";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[]{userName,passWord});
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName (string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT dbo.Account.* FROM dbo.Account WHERE TaiKhoan = '"+userName+"'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string username , string password ,string displayname, string newpassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UPDATEACCOUNT @USERNAME , @PASSWORD , @DISPLAYNAME , @NEWPASSWORD",new object[] { username,password,displayname,newpassword});
            return result > 0;
        }
        public DataTable LoadAccount()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADACCOUNT");
        }
        public bool InsertAccount (string userName,string name,string passWord,int type)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_CHECKTHEMTAIKHOAN @USERNAME , @NAME , @PASSWORD , @TYPE",new object[] { userName,name,passWord,type});
            return result > 0;
        }
        public bool UpdateAccount(string userName ,string name,string passWord,int type)
        {
            string query = string.Format("UPDATE dbo.Account SET TenNguoiDung = N'{0}',MatKhau ='{1}',LoaiTaiKhoan = {2} WHERE TaiKhoan = '{3}'",name,passWord,type,userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE FROM dbo.Account WHERE TaiKhoan = '{0}'",userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
