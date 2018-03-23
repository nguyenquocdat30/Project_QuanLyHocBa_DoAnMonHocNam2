CREATE DATABASE QuanLyTHPT
ON PRIMARY
(
	NAME = QuanLyHocBa1,
	FILENAME = 'E:\PROJECT_C#\QuanLyHocBaTHPTPhamVanDong\SQL\QuanLy.mdf',
	SIZE = 20MB,
	MAXSIZE = 25MB,
	FILEGROWTH = 5MB
)
LOG ON
(
	NAME = logQuanLyHocBa1,
	FILENAME = 'E:\PROJECT_C#\QuanLyHocBaTHPTPhamVanDong\SQL\logQuanLy.ldf',
	SIZE = 20MB,
	MAXSIZE = 25MB,
	FILEGROWTH = 5MB
)
GO

USE QuanLyTHPT
GO
-- HocBa
-- HocSinh
-- MonHoc
-- KetQuaMonHoc
-- LopHoc
-- Account
-- TongKet
-- Khoi
-- Hanh Kiem 
-- 

CREATE TABLE Account
(
	TaiKhoan VARCHAR(100) PRIMARY KEY,
	TenNguoiDung NVARCHAR(100) NOT NULL DEFAULT N'Chưa Có Tên',
	MatKhau VARCHAR(1000) NOT NULL,
	LoaiTaiKhoan INT NOT NULL DEFAULT 0 -- 1: admin 0: user
)

GO
CREATE TABLE HocBa
(
	id INT IDENTITY PRIMARY KEY,
	NgayVaoSo DATE NOT NULL
)
GO
CREATE TABLE MonHoc
(
	id INT IDENTITY PRIMARY KEY,
	TenMonHoc NVARCHAR(100) NOT NULL DEFAULT N'Chưa Có Tên',
	SoTiet INT NOT NULL DEFAULT 0
)
GO
CREATE TABLE Khoi
(
	id INT IDENTITY PRIMARY KEY,
	TenKhoi INT NOT NULL DEFAULT 10 CHECK (TenKhoi >= 10 AND TenKhoi <=12)
)
GO
CREATE TABLE HocSinh
(
	id INT IDENTITY PRIMARY KEY,
	HoHocSinh NVARCHAR(30) NOT NULL DEFAULT N'Chưa Nhập Họ',
	TenHocSinh NVARCHAR(20) NOT NULL DEFAULT N'Chưa Nhập Tên',
	NamSinh DATE NOT NULL ,
	GioiTinh BIT NOT NULL DEFAULT 1, -- 0: Nữ 1: Nam
	QueQuan NVARCHAR(100) NOT NULL DEFAULT N'Chưa Nhập',
	DanToc NVARCHAR(10) NOT NULL DEFAULT N'Kinh',
	TonGiao NVARCHAR(20) NOT NULL DEFAULT N'Không',
	DiaChi NVARCHAR(100) NOT NULL DEFAULT N'Chưa Nhập Địa Chỉ',
	HanhKiem NVARCHAR(5) NULL
	FOREIGN KEY (id) REFERENCES dbo.HocBa(id)
)
GO
CREATE TABLE LopHoc
(
	id INT IDENTITY PRIMARY KEY,
	TenLopHoc VARCHAR(2) NOT NULL DEFAULT N'C1',
	idKhoi INT NOT NULL ,
	idHS INT NOT NULL,
	GiaoVienChuNhiem NVARCHAR(100) NOT NULL,
	FOREIGN KEY (idKhoi) REFERENCES dbo.Khoi(id),
	FOREIGN KEY (idHS) REFERENCES dbo.HocSinh(id)
)
GO
CREATE TABLE HocKy
(
	id INT IDENTITY PRIMARY KEY,
	MaHocKy INT NOT NULL CHECK (MaHocKy > 0 AND MaHocKy < 3) DEFAULT 1
)
GO
CREATE TABLE KetQuaMonHoc
(
	id INT IDENTITY PRIMARY KEY,
	DiemMieng FLOAT NOT NULL DEFAULT 0 CHECK(DiemMieng >= 0 AND DiemMieng <=10),
	Diem15Phut FLOAT NOT NULL DEFAULT 0 CHECK(Diem15Phut >= 0 AND Diem15Phut <=10),
	Diem1Tiet FLOAT NOT NULL DEFAULT 0 CHECK(Diem1Tiet >= 0 AND Diem1Tiet <=10),
	DiemHocKy FLOAT NOT NULL DEFAULT 0 CHECK(DiemHocKy >= 0 AND DiemHocKy <=10),
	idHocSinh INT NOT NULL,
	idMonHoc INT NOT NULL,
	idHocKy INT NOT NULL
	FOREIGN KEY (idHocSinh) REFERENCES dbo.HocSinh(id),
	FOREIGN KEY (idMonHoc) REFERENCES dbo.MonHoc(id),
	FOREIGN KEY (idHocKy) REFERENCES HocKy(id)
)
GO
-- THÊM DỮ LIỆU VÀO CHO BẢNG HỌC BẠ
INSERT INTO dbo.HocBa
        ( NgayVaoSo )
VALUES  ( '5/5/2012'),( '5/5/2012'),( '5/5/2012'),('5/5/2012'),
		( '5/5/2013'),( '5/5/2013'),( '5/5/2013'),('5/5/2013'),
		( '5/5/2014'),( '5/5/2014'),( '5/5/2014'),('5/5/2014')
GO
-- THÊM DỮ LIỆU VÀO CHO BẢNG HỌC SINH
INSERT INTO dbo.HocSinh
        ( HoHocSinh ,
          TenHocSinh ,
          NamSinh ,
          GioiTinh ,
          QueQuan ,
          DanToc ,
          TonGiao ,
          DiaChi
        )
VALUES  ( N'Bùi Thị Bích' ,N'Hằng' ,'6/6/1997' ,0 ,N'Nha Trang' ,N'Kinh' ,N'Không' ,N'TDP 1 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Phạm Thị Ngọc' ,N'Trâm' ,'9/12/1997' ,0 ,N'Thái Bình' ,N'Kinh' ,N'Không' ,N'TDP 2 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Nguyễn Văn' ,N'Thành' ,'11/30/1997' ,1 ,N'Hà Tĩnh' ,N'Kinh' ,N'Không' ,N'TDP 4 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Dương Văn' ,N'Dũng' ,'6/8/1997' ,1 ,N'Nghệ An' ,N'Kinh' ,N'Không' ,N'TDP 6 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Nguyễn Thị' ,N'Hằng' ,'3/25/1998' ,0 ,N'Đồng Nai' ,N'Kinh' ,N'Không' ,N'TDP 5 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Phạm Thị Tuyết' ,N'Nhi' ,'1/27/1998' ,0 ,N'Thái Nguyên' ,N'Kinh' ,N'Không' ,N'TDP 6 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Nguyễn Trung' ,N'Kiên' ,'8/6/1998' ,1 ,N'Kiên Giang' ,N'Kinh' ,N'Không' ,N'TDP 3 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Hoàng Thị' ,N'Như' ,'2/16/1998' ,0 ,N'Hà Tĩnh' ,N'Kinh' ,N'Không' ,N'TDP 1 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Phạm Văn' ,N'Nam' ,'7/26/1999' ,1 ,N'Bình Phước' ,N'Kinh' ,N'Không' ,N'TDP 3 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Dương Thị Thùy' ,N'Dung' ,'9/8/1999' ,0 ,N'Đăk Lăk' ,N'Kinh' ,N'Không' ,N'TDP 6 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Phạm Thành' ,N'Trung' ,'10/13/1999' ,1 ,N'Đồng Nai' ,N'Kinh' ,N'Không' ,N'TDP 1 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'),
		( N'Lê Văn' ,N'Phương' ,'11/24/1999' ,1 ,N'Lâm Đồng' ,N'Kinh' ,N'Không' ,N'TDP 6 - TT Kiến Đức - Đăk R Lấp - Đăk Nông')
GO
-- THÊM MÔN HỌC
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'TOÁN',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'LÝ',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'HÓA',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'VĂN',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'ANH',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'SINH',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'SỬ',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'ĐỊA',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'GIÁO DỤC CÔNG DÂN',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'THỂ DỤC',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'GIÁO DỤC QUỐC PHÒNG',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'CÔNG NGHỆ',45)
INSERT INTO dbo.MonHoc( TenMonHoc, SoTiet )VALUES  ( N'TIN HỌC',45)
GO
-- SET LẠI ID CHO HỌC KỲ
DBCC CHECKIDENT('LopHoc', RESEED, 0)

GO
-- THÊM CỘT HẠNH KIỂM CHO HỌC SINH
ALTER TABLE dbo.HocSinh
ADD HanhKiem NVARCHAR(5) NULL
GO
-- THÊM HỌC KỲ 
INSERT INTO dbo.HocKy( MaHocKy)VALUES  (1)
INSERT INTO dbo.HocKy( MaHocKy)VALUES  (2)
GO
-- THÊM KẾT QUẢ MÔN HỌC
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,1 ,1 ,1 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,2 ,3 ,2 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,3 ,1 ,2 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,1 ,5 ,1 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,2 ,4 ,2 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,5 ,9 ,1 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,2 ,10 ,1 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,1 ,11,2 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,8 ,5,1 )
INSERT INTO dbo.KetQuaMonHoc( DiemMieng ,Diem15Phut ,Diem1Tiet ,DiemHocKy ,idHocSinh ,idMonHoc ,idHocKy)VALUES  ( 7.5 ,6.0 ,8.0 ,7.0 ,7 ,3 ,2 )
GO
-- THÊM LỚP HỌC
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C1' ,1 ,1 ,N'THANH TUẤN')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C1' ,2 ,2 ,N'XUÂN SƠN')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C1' ,3 ,3 ,N'BÍCH NGUYỆT')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C2' ,1 ,4 ,N'THANH TUẤN')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C2' ,2 ,5 ,N'TRỌNG VŨ')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C3' ,2 ,6 ,N'THÀNH TRUNG')
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C3' ,1 ,7 ,N'TRUNG THÀNH')
GO
-- TẠO PROCEDURE LOGIN
CREATE PROCEDURE USP_LOGIN
@USERNAME VARCHAR(100),
@PASSWORD VARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE TaiKhoan = @USERNAME AND MatKhau = @PASSWORD
END
GO
-- TẠO PROCEDURE IN DANH SÁCH THÔNG TIN CỦA HỌC SINH ---> 
CREATE PROCEDURE USP_DANHSACHHOCBA
AS
BEGIN
SELECT  dbo.HocBa.id AS [Mã Học Bạ],dbo.HocBa.NgayVaoSo AS [Ngày Vào Sổ] , dbo.HocSinh.HoHocSinh +' '+ dbo.HocSinh.TenHocSinh AS [Họ Tên Học Sinh] ,
 dbo.HocSinh.NamSinh AS [Năm Sinh],CASE WHEN dbo.HocSinh.GioiTinh = 1 THEN 'Nam' WHEN dbo.HocSinh.GioiTinh = 0 THEN N'Nữ' END AS [Giới Tính],
 dbo.HocSinh.QueQuan AS [Quê Quán],dbo.HocSinh.DanToc AS [Dân Tộc] , dbo.HocSinh.TonGiao AS [Tôn Giáo], dbo.HocSinh.DiaChi AS [Địa Chỉ],
 CAST(dbo.Khoi.TenKhoi AS VARCHAR(5)) + dbo.LopHoc.TenLopHoc AS [Lớp], dbo.HocSinh.HanhKiem  AS [Hạnh Kiểm]
FROM ((dbo.HocBa JOIN dbo.HocSinh ON HocSinh.id = HocBa.id ) JOIN dbo.LopHoc ON LopHoc.idHS = HocSinh.id ) JOIN dbo.Khoi ON Khoi.id = LopHoc.idKhoi
END
GO
-- PROCEDURE UPDATEACCOUNT
CREATE PROCEDURE USP_UPDATEACCOUNT
@USERNAME VARCHAR(100) ,@PASSWORD VARCHAR(100) ,@DISPLAYNAME NVARCHAR(100) ,@NEWPASSWORD VARCHAR(100)
AS
BEGIN
	DECLARE @IS_RIGHT_PASS_WORD INT
	SET @IS_RIGHT_PASS_WORD = 0
	SELECT @IS_RIGHT_PASS_WORD = COUNT(*) FROM dbo.Account WHERE dbo.Account.TaiKhoan = @USERNAME AND dbo.Account.MatKhau = @PASSWORD
	IF ( @IS_RIGHT_PASS_WORD = 1)
	BEGIN
		IF(@NEWPASSWORD = NULL OR @NEWPASSWORD ='')
		BEGIN
			UPDATE dbo.Account SET dbo.Account.TenNguoiDung = @DISPLAYNAME WHERE dbo.Account.TaiKhoan = @USERNAME
		END
		ELSE
		BEGIN
			UPDATE dbo.Account SET dbo.Account.TenNguoiDung = @DISPLAYNAME, dbo.Account.MatKhau = @NEWPASSWORD WHERE dbo.Account.TaiKhoan = @USERNAME
		END
	END
	
END
GO
-- PROCEDURE LOAD LOP HOC
CREATE PROCEDURE USP_LOADLOPHOC
AS
BEGIN
	SELECT dbo.LopHoc.id,CAST(dbo.Khoi.TenKhoi AS VARCHAR(2)) + dbo.LopHoc.TenLopHoc AS [Tên Lớp],dbo.LopHoc.GiaoVienChuNhiem AS [Giáo Viên Chủ Nhiệm]
	FROM dbo.LopHoc JOIN dbo.Khoi ON Khoi.id = LopHoc.idKhoi
END
GO
-- PROCEDURE LOAD HỌC BẠ
CREATE PROCEDURE USP_LOADHOCBA_HOCSINH
AS
BEGIN
SELECT dbo.HocBa.id , dbo.HocBa.NgayVaoSo AS [Ngày Vào Sổ] FROM dbo.HocBa 
END
GO
-- PROCEDURE LOAD MÔN HỌC
CREATE PROCEDURE USP_LOADMONHOC
AS
BEGIN
	SELECT dbo.MonHoc.id,dbo.MonHoc.TenMonHoc AS [Tên Môn Học] ,dbo.MonHoc.SoTiet AS [Số Tiết]
	FROM dbo.MonHoc
END
GO
-- PROCEDURE LOAD ACCOUNT
CREATE PROCEDURE USP_LOADACCOUNT
AS
BEGIN
	SELECT dbo.Account.TenNguoiDung AS[Tên Người Dùng],dbo.Account.TaiKhoan AS [Tên Tài Khoản],dbo.Account.MatKhau AS [Mật Khẩu],CASE WHEN dbo.Account.LoaiTaiKhoan = 1 THEN 'admin' ELSE 'user' END AS [Loại Tài Khoản]
	FROM dbo.Account
END
GO
-- PROCEDURE LOAD HOC SINH
CREATE PROCEDURE USP_LOADHOCSINH
AS
BEGIN
	SELECT dbo.HocSinh.id ,dbo.HocSinh.HoHocSinh AS [Họ Học Sinh],dbo.HocSinh.TenHocSinh AS [Tên Học Sinh],dbo.HocSinh.NamSinh AS [Năm Sinh],CASE WHEN dbo.HocSinh.GioiTinh = 1 THEN 'Nam' WHEN dbo.HocSinh.GioiTinh = 0 THEN N'Nữ' END AS [Giới Tính],dbo.HocSinh.DanToc AS [Dân Tộc],dbo.HocSinh.TonGiao AS [Tôn Giáo],dbo.HocSinh.QueQuan AS [Quê Quán],dbo.HocSinh.DiaChi AS [Địa Chỉ],dbo.HocSinh.HanhKiem AS [Hạnh Kiểm]
	FROM dbo.HocSinh
END
GO
-- PROCEDURE LOAD DIEM THANH PHAN
CREATE PROCEDURE USP_LOADDIEMTHANHPHAN
AS
BEGIN
	SELECT dbo.KetQuaMonHoc.id ,dbo.HocSinh.HoHocSinh +' '+ dbo.HocSinh.TenHocSinh AS [Họ Tên Học Sinh] ,dbo.MonHoc.TenMonHoc AS [Tên Môn Học],dbo.HocKy.MaHocKy AS [Học Kỳ],dbo.KetQuaMonHoc.DiemMieng AS [Điểm Miệng],dbo.KetQuaMonHoc.Diem15Phut AS [Điểm 15 Phút],dbo.KetQuaMonHoc.Diem1Tiet AS [Điểm 1 Tiết ],dbo.KetQuaMonHoc.DiemHocKy AS [Điểm Học Kỳ]
	FROM dbo.HocSinh JOIN dbo.KetQuaMonHoc ON KetQuaMonHoc.idHocSinh = HocSinh.id JOIN dbo.MonHoc ON MonHoc.id = KetQuaMonHoc.idMonHoc JOIN dbo.HocKy ON HocKy.id = KetQuaMonHoc.idHocKy
END
GO
-- PROCEDURE LOAD KHOI
CREATE PROCEDURE USP_LOADKHOI
AS
BEGIN
	SELECT dbo.Khoi.TenKhoi FROM dbo.Khoi
END
-- PROCEDURE THEM TAI KHOAN
GO
CREATE PROCEDURE USP_CHECKTHEMTAIKHOAN
@TENTAIKHOAN VARCHAR(100),
@TENNGUOIDUNG NVARCHAR(100),
@MATKHAU VARCHAR(1000),
@LOAITAIKHOAN INT
AS
IF NOT EXISTS ( SELECT dbo.Account.TenNguoiDung FROM dbo.Account WHERE dbo.Account.TaiKhoan = @TENTAIKHOAN)
BEGIN
	INSERT INTO dbo.Account( TaiKhoan ,TenNguoiDung ,MatKhau ,LoaiTaiKhoan) VALUES  ( @TENTAIKHOAN ,@TENNGUOIDUNG,@MATKHAU ,@LOAITAIKHOAN)
END
GO
--======================================================================================================================================================================================================================================================================================================================================================================================

SELECT dbo.HocSinh.id, dbo.MonHoc.TenMonHoc ,dbo.HocKy.MaHocKy, CAST(KHOI.TenKhoi AS VARCHAR(2)) + dbo.LopHoc.TenLopHoc AS [LỚP], (dbo.KetQuaMonHoc.DiemMieng + dbo.KetQuaMonHoc.Diem15Phut + dbo.KetQuaMonHoc.Diem1Tiet*2 + dbo.KetQuaMonHoc.DiemHocKy *3 )/7 AS [Điểm Tổng Kết]
FROM dbo.Khoi JOIN dbo.LopHoc ON LopHoc.idKhoi = Khoi.id JOIN dbo.HocSinh ON HocSinh.id = LopHoc.idHS JOIN dbo.KetQuaMonHoc ON KetQuaMonHoc.idHocSinh = HocSinh.id JOIN dbo.MonHoc ON MonHoc.id = KetQuaMonHoc.idMonHoc JOIN dbo.HocKy ON HocKy.id = KetQuaMonHoc.idHocKy
WHERE dbo.HocSinh.id =2 AND dbo.HocKy.MaHocKy =2 AND dbo.Khoi.TenKhoi = 11
GO
INSERT INTO dbo.HocBa( NgayVaoSo ) VALUES  ('')
GO
SELECT dbo.HocBa.* FROM dbo.HocBa
UPDATE dbo.HocBa SET NgayVaoSo = '6/4/2014' WHERE id = 14
GO
INSERT INTO dbo.LopHoc( TenLopHoc ,idKhoi ,idHS ,GiaoVienChuNhiem) VALUES  ( 'C5' ,0 , 0 , N'' )
GO
DELETE FROM dbo.KetQuaMonHoc WHERE id = 20
DELETE FROM dbo.MonHoc WHERE id = 2 
UPDATE dbo.KetQuaMonHoc SET idHocKy = 1 ,DiemMieng = 2,Diem15Phut = 3,Diem1Tiet =2 ,DiemHocKy =2 WHERE id = 2
GO
UPDATE dbo.LopHoc SET TenLopHoc ='',GiaoVienChuNhiem= N''WHERE id = 1
GO
SELECT dbo.HocSinh.* 
FROM dbo.HocSinh 
WHERE DiaChi = N'TDP 6 - TT Kiến Đức - Đăk R Lấp - Đăk Nông'
		AND HanhKiem = N'Tốt'