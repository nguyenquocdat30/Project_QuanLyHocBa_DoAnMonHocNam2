using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocBaTHPTPhamVanDong.DTO
{
    public class Lop
    {
        private string giaoVienChuNhiem;
        private int idHS;
        private int idKhoi;
        private string tenLopHoc;
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

        public string TenLopHoc
        {
            get
            {
                return tenLopHoc;
            }

            set
            {
                tenLopHoc = value;
            }
        }

        public int IdKhoi
        {
            get
            {
                return idKhoi;
            }

            set
            {
                idKhoi = value;
            }
        }

        public int IdHS
        {
            get
            {
                return idHS;
            }

            set
            {
                idHS = value;
            }
        }

        public string GiaoVienChuNhiem
        {
            get
            {
                return giaoVienChuNhiem;
            }

            set
            {
                giaoVienChuNhiem = value;
            }
        }
        public Lop(int id,string tenLopHoc,int idKhoi,int idHS,string giaoVienChuNhiem)
        {
            this.Id = id;
            this.TenLopHoc = tenLopHoc;
            this.IdKhoi = idKhoi;
            this.IdHS = idHS;
            this.GiaoVienChuNhiem = giaoVienChuNhiem;
        }
        public Lop(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenLopHoc = row["tenLopHoc"].ToString();
            this.IdKhoi = (int)row["idKhoi"];
            this.IdHS = (int)row["idHS"];
            this.GiaoVienChuNhiem = row["giaoVienChuNhiem"].ToString();
        }
    }
}
