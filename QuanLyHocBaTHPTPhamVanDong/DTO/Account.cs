using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DTO
{
    public class Account
    {
        private int type;
        private string passWord;
        private string name;
        private string userName;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return passWord;
            }

            set
            {
                passWord = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
        public Account(string userName , string name , int type,string passWord = null)
        {
            this.Name = name;
            this.UserName = userName;
            this.PassWord = passWord;
            this.Type = type;
        }
        public Account(DataRow row)
        {
            this.Name = row["TenNguoiDung"].ToString();
            this.UserName = row["TaiKhoan"].ToString();
            this.PassWord = row["MatKhau"].ToString();
            this.Type = (int)row["LoaiTaiKhoan"];
        }
    }
}
