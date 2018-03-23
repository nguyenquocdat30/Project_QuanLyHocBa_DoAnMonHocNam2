using QuanLyHocBaTHPTPhamVanDong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class LopHocDAO
    {
        private static LopHocDAO instance;

        public static LopHocDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new LopHocDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public LopHocDAO() { }
        public DataTable LoadLopHoc()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADLOPHOC");
        }
        public Lop GetLopById(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT dbo.LopHoc.* FROM dbo.LopHoc WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Lop(item);
            }
            return null;
        }
        public Lop GetLopByIdHocSinh(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT dbo.LopHoc.* FROM dbo.LopHoc WHERE idHS = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Lop(item);
            }
            return null;
        }
        public bool UpdateLopHoc(string id,string tenLopHoc,string giaoVienCN)
        {
            string query = string.Format("UPDATE dbo.LopHoc SET TenLopHoc ='{1}',GiaoVienChuNhiem= N'{2}'WHERE id ={0}",id,tenLopHoc,giaoVienCN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteLopHoc(string id)
        {
            string query = string.Format("DELETE FROM dbo.LopHoc WHERE id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
