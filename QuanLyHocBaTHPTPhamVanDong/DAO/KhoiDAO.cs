using QuanLyHocBaTHPTPhamVanDong.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DAO
{
    public class KhoiDAO
    {
        private static KhoiDAO instance;

        public static KhoiDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhoiDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public KhoiDAO() { }
        public DataTable LoadKhoi()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_LOADKHOI");
        }
        public Khoi GetKhoiById(int  id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT dbo.Khoi.* FROM dbo.Khoi WHERE id = '" + id + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Khoi(item);
            }
            return null;
        }
    }
}
