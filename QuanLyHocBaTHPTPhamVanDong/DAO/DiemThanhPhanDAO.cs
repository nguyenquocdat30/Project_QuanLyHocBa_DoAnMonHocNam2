using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    class DiemThanhPhanDAO
    {
        private static DiemThanhPhanDAO instance;

        public static DiemThanhPhanDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiemThanhPhanDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public DiemThanhPhanDAO() { }
        public DataTable LoadDiemThanhPhan()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADDIEMTHANHPHAN");
        }
        public bool DeleteDiemThanhPhan(string id)
        {
            string query = string.Format("DELETE FROM dbo.KetQuaMonHoc WHERE id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDiemThanhPhan(string id, string idHocKy,string diemMieng,string diem15Phut,string diem1Tiet,string diemHocKy)
        {
            string query = string.Format("UPDATE dbo.KetQuaMonHoc SET idHocKy = {1} ,DiemMieng = {2},Diem15Phut = {3},Diem1Tiet ={4} ,DiemHocKy ={5} WHERE id = {0}", id, idHocKy, diemMieng, diem15Phut, diem1Tiet, diemHocKy);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
