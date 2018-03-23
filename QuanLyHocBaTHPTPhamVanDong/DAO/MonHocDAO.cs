using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    class MonHocDAO
    {
        private static MonHocDAO instance;

        public static MonHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonHocDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public MonHocDAO() { }
        public DataTable LoadMonHoc()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADMONHOC");
        }
        public bool InsertMonHoc(string name,int soTiet)
        {
            string query = string.Format("INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet ) VALUES  ( N'{0}',{1} )",name,soTiet);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMonHoc(string id)
        {
            string query = string.Format("DELETE FROM dbo.KetQuaMonHoc WHERE idMonHoc = {0} DELETE FROM dbo.MonHoc WHERE id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMonHoc(string id,string name,int soTiet)
        {
            string query = string.Format("UPDATE dbo.MonHoc SET TenMonHoc = N'{0}' ,SoTiet = {1} WHERE id = {2}",name,soTiet,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
