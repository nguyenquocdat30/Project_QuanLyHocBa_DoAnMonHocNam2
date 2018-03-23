using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class HocSinhDAO
    {
        private static HocSinhDAO instance;

        public static HocSinhDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocSinhDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public HocSinhDAO() { }
        public DataTable LoadHocSinh()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADHOCSINH");
        }
    }
}
