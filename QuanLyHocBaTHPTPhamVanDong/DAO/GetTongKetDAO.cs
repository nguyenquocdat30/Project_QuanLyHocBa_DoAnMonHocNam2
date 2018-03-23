using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class GetTongKetDAO
    {
        private static GetTongKetDAO instance;

        public static GetTongKetDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GetTongKetDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public GetTongKetDAO() { }
        public DataTable GetTongKet()
        {
            return DataProvider.Instance.ExecuteQuery("USP_DANHSACHHOCBA");
        }
    }
}
