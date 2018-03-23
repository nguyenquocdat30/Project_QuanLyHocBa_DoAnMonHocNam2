using QuanLyHocBaTHPTPhamVanDong.DAO;
using QuanLyHocBaTHPTPhamVanDong.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocBaTHPTPhamVanDong
{
    public partial class fAdmin : Form
    {
        BindingSource HocBaList = new BindingSource();
        BindingSource LopHocList = new BindingSource();
        BindingSource MonHocList = new BindingSource();
        BindingSource HocSinhList = new BindingSource();
        BindingSource DiemThanhPhanList = new BindingSource();
        BindingSource TaiKhoanList = new BindingSource();
        public fAdmin()
        {
            InitializeComponent();
            LoadForm();
        }
        #region Event
        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Thật Sự Muốn Thoát ?","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoatForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadHocBa();
        }
        private void btnXemLopHoc_Click(object sender, EventArgs e)
        {
            LoadLopHoc();
        }

        private void btnXemMonHoc_Click(object sender, EventArgs e)
        {
            LoadMonHoc();
        }

        private void btnXemHocSinh_Click(object sender, EventArgs e)
        {
            LoadHocSinh();
        }

        private void btnXemDiemThanhPhan_Click(object sender, EventArgs e)
        {
            LoadDiemThanhPhan();
        }
        private void btnXemTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void txtIDLopHoc_TextChanged(object sender, EventArgs e)
        {
            if (dgvLopHoc.SelectedCells.Count > 0)
            {
                int id = (int)dgvLopHoc.SelectedCells[0].OwningRow.Cells["id"].Value;
                Lop loadIDKhoi = LopHocDAO.Instance.GetLopById(id);
                Khoi loadTenKhoi = KhoiDAO.Instance.GetKhoiById(loadIDKhoi.IdKhoi);
                cbbKhoiLopHoc.Text = loadTenKhoi.TenKhoi.ToString();
            }
        }

        private void txtIDHocSinh_TextChanged(object sender, EventArgs e)
        {
            if (dgvHocSinh.SelectedCells.Count > 0)
            {
                int id = (int)dgvHocSinh.SelectedCells[0].OwningRow.Cells["id"].Value;
                Lop loadIDKhoi = LopHocDAO.Instance.GetLopByIdHocSinh(id);
                if (loadIDKhoi != null)
                {
                    Khoi loadTenKhoi = KhoiDAO.Instance.GetKhoiById(loadIDKhoi.IdKhoi);
                    cbbLopHocSinh.Text = loadTenKhoi.TenKhoi.ToString() + loadIDKhoi.TenLopHoc.ToString();
                }
                else
                {
                    cbbLopHocSinh.Text = "Null";
                }
            }
        }
        #endregion
        #region methob
        public void LoadForm()
        {
            dgvHocBa.DataSource = HocBaList;
            dgvLopHoc.DataSource = LopHocList;
            dgvMonHoc.DataSource = MonHocList;
            dgvHocSinh.DataSource = HocSinhList;
            dvgDiemThanhPhan.DataSource = DiemThanhPhanList;
            dgvDanhSachTaiKhoan.DataSource = TaiKhoanList;
            //==============================================
            LoadHocBa();
            LoadLopHoc();
            LoadMonHoc();
            LoadAccount();
            LoadHocSinh();
            LoadDiemThanhPhan();
            //==============================================
            AddLopHocBinding();
            AddMonHocBinding();
            AddHocBaBinding();
            AddHocSinhBinding();
            AddAccountBinding();
            AddDiemThanhPhanBinding();
            //==============================================
            LoadKhoiChoLopHoc(cbbKhoiLopHoc);
            LoadTenMonHocChoMonHoc(cbbTenMonHoc);
            LoadLopHocChoHocSinh(cbbLopHocSinh);

        }
        private void LoadHocBa()
        {
            HocBaList.DataSource = HocBaDAO.Instance.LoadHocBa();
        }
        private void LoadLopHoc()
        {
            LopHocList.DataSource = LopHocDAO.Instance.LoadLopHoc();
        }
        private void LoadMonHoc()
        {
            MonHocList.DataSource = MonHocDAO.Instance.LoadMonHoc();
        }
        private void LoadHocSinh()
        {
            HocSinhList.DataSource = HocSinhDAO.Instance.LoadHocSinh();
        }
        private void LoadDiemThanhPhan()
        {
            DiemThanhPhanList.DataSource = DiemThanhPhanDAO.Instance.LoadDiemThanhPhan();
        }
        private void LoadAccount()
        {
            TaiKhoanList.DataSource = AccountDAO.Instance.LoadAccount();
        }
        #endregion
        #region Binding
        public void AddLopHocBinding()
        {
            txtIDLopHoc.DataBindings.Add(new Binding("Text", dgvLopHoc.DataSource, "id",true,DataSourceUpdateMode.Never));
            txtTenLopHoc.DataBindings.Add(new Binding("Text", dgvLopHoc.DataSource, "Tên Lớp", true, DataSourceUpdateMode.Never));
            txtGVCNLopHoc.DataBindings.Add(new Binding("Text", dgvLopHoc.DataSource, "Giáo Viên Chủ Nhiệm", true, DataSourceUpdateMode.Never));
            
        }
        public void AddHocBaBinding()
        {
            tbxIDHocBa.DataBindings.Add(new Binding("Text", dgvHocBa.DataSource, "id", true, DataSourceUpdateMode.Never));
            dtpHocBa.DataBindings.Add(new Binding("Value", dgvHocBa.DataSource, "Ngày Vào Sổ", true, DataSourceUpdateMode.Never));
        }
        public void AddMonHocBinding()
        {
            txtIDMonHoc.DataBindings.Add(new Binding("Text", dgvMonHoc.DataSource, "id", true, DataSourceUpdateMode.Never));
            numSoTietMonHoc.DataBindings.Add(new Binding("Value", dgvMonHoc.DataSource, "Số Tiết", true, DataSourceUpdateMode.Never));
            cbbTenMonHoc.DataBindings.Add(new Binding("Text", dgvMonHoc.DataSource, "Tên Môn Học", true, DataSourceUpdateMode.Never));
        }
        public void AddAccountBinding()
        {
            txtTaiKhoan.DataBindings.Add(new Binding("Text", dgvDanhSachTaiKhoan.DataSource, "Tên Tài Khoản", true, DataSourceUpdateMode.Never));
            txtMatKhau.DataBindings.Add(new Binding("Text", dgvDanhSachTaiKhoan.DataSource, "Mật Khẩu", true, DataSourceUpdateMode.Never));
            txtTenNguoiDung.DataBindings.Add(new Binding("Text", dgvDanhSachTaiKhoan.DataSource, "Tên Người Dùng", true, DataSourceUpdateMode.Never));
            cbbLoaiTaiKhoan.DataBindings.Add(new Binding("Text", dgvDanhSachTaiKhoan.DataSource, "Loại Tài Khoản", true, DataSourceUpdateMode.Never));
        }
        public void AddHocSinhBinding()
        {
            txtIDHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtHoHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Họ Học Sinh", true, DataSourceUpdateMode.Never));
            txtTenHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Tên Học Sinh", true, DataSourceUpdateMode.Never));
            txtDiaChiHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Địa Chỉ", true, DataSourceUpdateMode.Never));
            txtQueQuanHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Quê Quán", true, DataSourceUpdateMode.Never));
            cbbDanTocHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Dân Tộc", true, DataSourceUpdateMode.Never));
            cbbTonGiaoHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Tôn Giáo", true, DataSourceUpdateMode.Never));
            cbbGioiTinhHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Giới Tính", true, DataSourceUpdateMode.Never));
            dtpNamSinhHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Năm Sinh", true, DataSourceUpdateMode.Never));
            cbbHanhKiemHocSinh.DataBindings.Add(new Binding("Text", dgvHocSinh.DataSource, "Hạnh Kiểm", true, DataSourceUpdateMode.Never));
        }
        public void AddDiemThanhPhanBinding()
        {
            txtIDDiemThanhPhan.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "id", true, DataSourceUpdateMode.Never));
            txtHoVaTenDiemThanhPhan.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Họ Tên Học Sinh", true, DataSourceUpdateMode.Never));
            txtMonHocDiemThanhPhan.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Tên Môn Học", true, DataSourceUpdateMode.Never));
            txtDiemMieng.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Điểm Miệng", true, DataSourceUpdateMode.Never));
            txtDiem15Phut.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Điểm 15 Phút", true, DataSourceUpdateMode.Never));
            txtDiem1Tiet.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Điểm 1 Tiết ", true, DataSourceUpdateMode.Never));
            txtDiemHocKy.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Điểm Học Kỳ", true, DataSourceUpdateMode.Never));
            cbbHocKyDiemThanhPhan.DataBindings.Add(new Binding("Text", dvgDiemThanhPhan.DataSource, "Học Kỳ", true, DataSourceUpdateMode.Never));
        }
        public void LoadKhoiChoLopHoc(ComboBox cb)
        {
            cb.DataSource = KhoiDAO.Instance.LoadKhoi();
            cb.DisplayMember = "TenKhoi";
        }
        public void LoadTenMonHocChoMonHoc(ComboBox cb)
        {
            cb.DataSource = MonHocDAO.Instance.LoadMonHoc();
            cb.DisplayMember = "Tên Môn Học";
        }
        public void LoadLopHocChoHocSinh(ComboBox cb)
        {
            cb.DataSource = LopHocDAO.Instance.LoadLopHoc();
            cb.DisplayMember = "Tên Lớp";
        }
        #endregion

        /// <summary>
        /// Chức Năng Học Bạ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnThemHocBa_Click(object sender, EventArgs e)
        {
            DateTime date = dtpHocBa.Value;
            if(HocBaDAO.Instance.InsertHocBa(date))
            {
                MessageBox.Show("Thêm Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHocBa();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Thêm ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaHocBa_Click(object sender, EventArgs e)
        {
            int id = (int)dgvHocBa.SelectedCells[0].OwningRow.Cells["id"].Value;
            DateTime date = dtpHocBa.Value;
            if(HocBaDAO.Instance.UpdateHocBa(id,date))
            {
                MessageBox.Show("Sửa Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHocBa();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Sửa ! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaHocBa_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Chức Năng Tài Khoản
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnThemTaiKHoan_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string name = txtTenNguoiDung.Text;
            string passWord = txtMatKhau.Text;
            int type = 0;
            if(cbbLoaiTaiKhoan.Text == "admin")
            {
                type = 1;
            }
            if (AccountDAO.Instance.InsertAccount(userName,name,passWord,type))
            {
                MessageBox.Show("Thêm Tài Khoản Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Thêm Tài Khoản! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string name = txtTenNguoiDung.Text;
            string passWord = txtMatKhau.Text;
            int type = 0;
            if (cbbLoaiTaiKhoan.Text == "admin")
            {
                type = 1;
            }
            if (AccountDAO.Instance.UpdateAccount(userName, name, passWord, type))
            {
                MessageBox.Show("Sửa Tài Khoản Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Sửa Tài Khoản! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa Tài Khoản Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Xóa Tài Khoản! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Chức Năng Môn Học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            string name = cbbTenMonHoc.Text;
            int soTiet = (int)numSoTietMonHoc.Value;
            if (MonHocDAO.Instance.InsertMonHoc(name,soTiet))
            {
                MessageBox.Show("Thêm Môn Học Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonHoc();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Thêm Môn Học! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaMonHoc_Click(object sender, EventArgs e)
        {
            string name = cbbTenMonHoc.Text;
            string id = txtIDMonHoc.Text;
            int soTiet = (int)numSoTietMonHoc.Value;
            if (MonHocDAO.Instance.UpdateMonHoc(id,name, soTiet))
            {
                MessageBox.Show("Sửa Môn Học Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonHoc();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Sửa Môn Học! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaMonHoc_Click(object sender, EventArgs e)
        {
            string name = cbbTenMonHoc.Text;
            string id = txtIDMonHoc.Text;
            if (MonHocDAO.Instance.DeleteMonHoc(id))
            {
                MessageBox.Show("Xóa Môn Học Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMonHoc();
                LoadDiemThanhPhan();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Xóa Môn Học! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Chức Năng Điểm Thành Phần
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnXoaDiemThanhPhan_Click(object sender, EventArgs e)
        {
            string id = txtIDDiemThanhPhan.Text;
            if (DiemThanhPhanDAO.Instance.DeleteDiemThanhPhan(id))
            {
                MessageBox.Show("Xóa Điểm Thành Phần Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDiemThanhPhan();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Xóa Điểm Thành Phần! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSuaDiemThanhPhan_Click(object sender, EventArgs e)
        {
            string id = txtIDDiemThanhPhan.Text;
            string idHocKy = cbbHocKyDiemThanhPhan.Text;
            string diemMieng = txtDiemMieng.Text;
            string diem15Phut = txtDiem15Phut.Text;
            string diem1Tiet = txtDiem1Tiet.Text;
            string diemHocKy = txtDiemHocKy.Text;
            if (DiemThanhPhanDAO.Instance.UpdateDiemThanhPhan(id,idHocKy,diemMieng,diem15Phut,diem1Tiet,diemHocKy))
            {
                MessageBox.Show("Sửa Điểm Thành Phần Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDiemThanhPhan();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Sửa Điểm Thành Phần! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Chức Năng Lớp Học
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSuaLopHoc_Click(object sender, EventArgs e)
        {
            string id = txtIDLopHoc.Text;
            string a = txtTenLopHoc.Text;
            string giaoVien = txtGVCNLopHoc.Text;
            string tenLop = "";
            if (a.Length == 4)
            {
                for (int i = 2; i <= 3; i++)
                {
                    tenLop += a[i];
                }
                if (LopHocDAO.Instance.UpdateLopHoc(id, tenLop, giaoVien))
                {
                    MessageBox.Show("Sửa Lớp Học Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLopHoc();
                }
                else
                {
                    MessageBox.Show("Có Lỗi Khi Sửa Lớp Học! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Có Lỗi Xảy Ra Khi Sửa ","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnXoaLopHoc_Click(object sender, EventArgs e)
        {
            string id = txtIDLopHoc.Text;

            if (LopHocDAO.Instance.DeleteLopHoc(id))
            {
                MessageBox.Show("Xóa Lớp Học Thành Công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLopHoc();
            }
            else
            {
                MessageBox.Show("Có Lỗi Khi Xóa Lớp Học! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
