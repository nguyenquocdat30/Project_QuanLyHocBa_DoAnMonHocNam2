using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DTO
{
    public class Khoi
    {
        private int tenKhoi;
        private int id;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int TenKhoi
        {
            get
            {
                return tenKhoi;
            }

            set
            {
                tenKhoi = value;
            }
        }
        public Khoi (int id,int tenKhoi)
        {
            this.Id = id;
            this.TenKhoi = tenKhoi;
        }
        public Khoi(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenKhoi = (int)row["TenKhoi"];
        }
    }
}
