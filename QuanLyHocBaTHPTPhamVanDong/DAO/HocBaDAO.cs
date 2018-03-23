using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class HocBaDAO
    {
        private static HocBaDAO instance;

        public static HocBaDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocBaDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public HocBaDAO() { }
        public DataTable LoadHocBa()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADHOCBA_HOCSINH");
        }
        public bool InsertHocBa(DateTime ngayVaoSo)
        {
            string query = string.Format("INSERT INTO dbo.HocBa( NgayVaoSo ) VALUES  ('{0}')",ngayVaoSo);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHocBa(int id ,DateTime ngayVaoSo)
        {
            string query = string.Format("UPDATE dbo.HocBa SET NgayVaoSo = '{0}' WHERE id = {1}",ngayVaoSo,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteHocBa(int id)
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
