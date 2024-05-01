
use HQTpr
go

--Tạo bảng-------------------------------------------------------------

--Bảng Quyền người dùng
CREATE TABLE QUYENNGUOIDUNG(
	QuyenNguoiDung varchar(20) CONSTRAINT PK_QUYENNGUOIDUNG PRIMARY KEY,
	TenQuyen nvarchar(50) NOT NULL
)
go

insert into QUYENNGUOIDUNG(QuyenNguoiDung, TenQuyen) values ('Quyen1', 'GiaoVien')
insert into QUYENNGUOIDUNG(QuyenNguoiDung, TenQuyen) values ('Quyen2', 'HocVien')

--Bảng Tài Khoản
CREATE TABLE TAIKHOAN(
	MaTaiKhoan varchar(20)  constraint PK_TAIKHOAN primary key,
    TenDangNhap varchar(20) unique,
    MatKhau varchar(20) NOT NULL,
    QuyenNguoiDung varchar(20) NOT NULL,
    CONSTRAINT FK_QUYENNGUOIDUNG_TAIKHOAN FOREIGN KEY (QuyenNguoiDung) 
        REFERENCES QUYENNGUOIDUNG(QuyenNguoiDung)
);
go

insert into TAIKHOAN(MaTaiKhoan, TenDangNhap, MatKhau,QuyenNguoiDung) values ('TKAD', 'Tho', '123', 'Quyen3')

--Bảng Giáo Viên
CREATE TABLE GIAOVIEN(
	MaGiaoVien int constraint PK_GIAOVIEN PRIMARY KEY IDENTITY,
	HoTen nvarchar(50) NOT NULL,
	NgaySinh DATE CHECK(DATEDIFF(year, NgaySinh, GETDATE()) >= 18),
	GioiTinh nvarchar(20) NOT NULL, 
	DiaChi nvarchar(100) NOT NULL,
	SoDienThoai varchar(20) CHECK(len(SoDienThoai) = 10),
	Email varchar(50) NOT NULL, 
	MaTK varchar(20)
)
go

--Bảng Khóa Học
CREATE TABLE KHOAHOC(
	MaKhoaHoc int constraint PK_KHOAHOC PRIMARY KEY IDENTITY,
	TenKhoaHoc nvarchar(50) NOT NULL
)
go

--Bảng Lớp Học
CREATE TABLE LOPHOC(
	MaLopHoc int constraint PK_LOPHOC PRIMARY KEY IDENTITY,
	MaKhoaHoc int constraint FK_LOPHOC_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	TenLopHoc nvarchar(50) NOT NULL,
	TongSoBuoiHoc INT CHECK(TongSoBuoiHoc > 0),
	HocPhi REAL CHECK(HocPhi >= 0)
)
go

--Bảng Phòng Học
CREATE TABLE PHONGHOC(
	MaPhongHoc int constraint PK_PHONGHOC PRIMARY KEY IDENTITY,
	SoLuongChoNgoi INT CHECK(SoLuongChoNgoi > 0)
)	
go

--Bảng Ca Học
CREATE TABLE CAHOC(
	Ca INT constraint PK_CAHOC PRIMARY KEY,
	GioBatDau varchar(10) NOT NULL,
	GioKetThuc varchar(10) NOT NULL
)	
go

--Bảng Nhóm Học
CREATE TABLE NHOMHOC(
	MaNhomHoc int constraint PK_NHOMHOC PRIMARY KEY IDENTITY,
	MaLopHoc int constraint FK_NHOMHOC_LOPHOC FOREIGN KEY REFERENCES LOPHOC(MaLopHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	MaGiaoVien int constraint FK_NHOMHOC_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE SET NULL ON UPDATE CASCADE,
	Ca INT constraint FK_NHOMHOC_CAHOC FOREIGN KEY REFERENCES CAHOC(Ca) ON DELETE SET NULL ON UPDATE CASCADE,
	SoLuongHocVienToiThieu INT CHECK(SoLuongHocVienToiThieu > 0),
	SoLuongHocVienToiDa INT CHECK(SoLuongHocVienToiDa > 0), 
	SoHocVienHienTai int default 0,
	NgayBatDau DATE NOT NULL,	
	TongBuoiHoc int not null,
	TrangThaiMoDangKy BIT NOT NULL DEFAULT 0,
)	
go	

--Bảng Học Viên
CREATE TABLE HOCVIEN(
	MaHocVien int constraint PK_HOCVIEN PRIMARY KEY IDENTITY,
	TenHocVien nvarchar(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh nvarchar(20) NOT NULL, 
	DiaChi nvarchar(100) NOT NULL,
	SoDienThoai varchar(20) CHECK(len(SoDienThoai) = 10),
	Email varchar(50) NOT NULL, 
	 MaTk varchar(20)
)
go


--Bảng Thông Báo
CREATE TABLE THONGBAO(
	MaThongBao int constraint PK_THONGBAO PRIMARY KEY IDENTITY,
	MaGiaoVien int CONSTRAINT FK_THONGBAO_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE SET NULL ON UPDATE CASCADE,
	TieuDe nvarchar(50),
	NoiDung nvarchar(255) NOT NULL,
	NgayGui date not null,
)
go

--Bảng Truyền Tin
CREATE TABLE TRUYENTIN(
	MaThongBao int constraint FK_TRUYENTIN_THONGBAO FOREIGN KEY REFERENCES THONGBAO(MaThongBao) ON DELETE CASCADE,
	MaNhomHoc int constraint FK_TRUYENTIN_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE,
	CONSTRAINT PK_TRUYENTIN PRIMARY KEY (MaThongBao, MaNhomHoc)
)

alter table TRUYENTIN add MaGui int constraint PK_TRUYENTIN primary key IDENTITY
alter table TRUYENTIN drop  PK_TRUYENTIN 
alter table TRUYENTIN drop  column MaGui 

--Bảng Ngày Học
CREATE TABLE NGAYHOC(
	NgayHoc DATE constraint PK_NGAYHOC PRIMARY KEY,
)
go

--Bảng Thứ Trong Tuần
CREATE TABLE THUTRONGTUAN(
	ThuTrongTuan nvarchar(20) constraint PK_THUTRONGTUAN PRIMARY KEY,
)
go

--Bảng Phụ Trách
CREATE TABLE PHUTRACH(
	MaGiaoVien int constraint FK_PHUTRACH_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE CASCADE ON UPDATE CASCADE,
	MaKhoaHoc int constraint FK_PHUTRACH_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT PK_PHUTRACH PRIMARY KEY (MaGiaoVien, MaKhoaHoc)
)
go

--Bảng Danh Sách Nhóm
CREATE TABLE DANHSACHNHOM(
	MaNhomHoc int constraint FK_DANHSACHNHOM_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE,
	MaHocVien int constraint FK_DANHSACHNHOM_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE, 
	DiemGiuaKhoa REAL CHECK(DiemGiuaKhoa between 0 and 10) DEFAULT 0,
	DiemCuoiKhoa REAL CHECK(DiemCuoiKhoa between 0 and 10) DEFAULT 0,
	TrangThaiThanhToan BIT NOT NULL DEFAULT 0,
	TrangThaiCapChungChi BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_DANHSACHNHOM PRIMARY KEY (MaHocVien, MaNhomHoc)
)
go

--Bảng Điểm Danh
CREATE TABLE BANGDIEMDANH(
	NgayHoc DATE constraint FK_BANGDIEMDANH_NGAYHOC FOREIGN KEY REFERENCES NGAYHOC(NgayHoc) ON DELETE CASCADE ,
	MaNhomHoc int constraint FK_BANGDIEMDANH_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE ,
	MaHocVien int constraint FK_BANGDIEMDANH_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE,
	HienDien BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_BANGDIEMDANH PRIMARY KEY (NgayHoc, MaNhomHoc, MaHocVien)
)
go

--Bảng đăng ký
create table DANGKY
(
	MaKhoaHoc int CONSTRAINT FK_DANGKY_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc),
	MaLopHoc int CONSTRAINT FK_DANGKY_LOPHOC FOREIGN KEY REFERENCES LOPHOC(MaLopHoc),
	MaHocVien int CONSTRAINT FK_DANGKY_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien),
	TrangThaiDongHocPhi bit default 0
	CONSTRAINT PK_DANGKY PRIMARY KEY(MaKhoaHoc,MaLopHoc,MaHocVien)
)
go

-- Bảng học theo
CREATE TABLE HOCTHEO(
	MaPhongHoc int constraint FK_HOCTHEO_PHONGHOC FOREIGN KEY REFERENCES PHONGHOC (MaPhongHoc),
	Ca INT constraint FK_HOCTHEO_CAHOC FOREIGN KEY REFERENCES CAHOC(Ca),
	MaNhomHoc int constraint FK_HOCTHEO_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC (MaNhomHoc) ,
	Thu nvarchar(20) constraint FK_HOCTHEO_THUTRONGTUAN foreign key references THUTRONGTUAN (ThuTrongTuan)
	CONSTRAINT PK_HOCTHEO PRIMARY KEY(MaPhongHoc,Ca,MaNhomHoc)
)
go
--------------------------------------------------------------------------------
-- TẠO TRIGGER

--trigger kiểm tra một học viên có đăng kí trùng lớp trong một khóa hay không?
CREATE TRIGGER TG_KiemTraTrungLopTrungLop ON DANGKY
AFTER INSERT
AS
BEGIN
	DECLARE @MaHocVien int
	DECLARE @RowKH int
	DECLARE @RowLH int
	SELECT @MaHocVien = i.MaHocVien
	FROM inserted i

	SELECT @RowLH = COUNT(MaLopHoc), @RowKH = COUNT(DISTINCT MaKhoaHoc) FROM DANGKY WHERE DANGKY.MaHocVien = @MaHocVien

	if @RowKH <> @RowLH 
		BEGIN
			RAISERROR('HỌC VIÊN ĐÃ THAM GIA KHÓA HỌC NÀY!',16,1);
		ROLLBACK;
		END
END
GO

--trigger kiểm tra một học viên có đăng kí trùng nhóm trong một lớp hay không và có đóng đủ học phí hay chưa ?
CREATE TRIGGER TG_KiemTraTrungNhom ON DANHSACHNHOM
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @MaHocVien varchar(20)
	SELECT @MaHocVien = i.MaHocVien
	FROM inserted i
	DECLARE @TrangThaiHocPhi bit
	SELECT @TrangThaiHocPhi = TrangThaiDongHocPhi FROM DANGKY WHERE DANGKY.MaHocVien = @MaHocVien

	if @TrangThaiHocPhi = 0
		BEGIN
			RAISERROR('HỌC VIÊN CHƯA ĐÓNG ĐỦ HỌC PHÍ!',16,1);
		ROLLBACK;
		END

	DECLARE @Row int
	DECLARE @RowD int

	SELECT @Row = COUNT(q.MaNhomHoc) , @RowD = COUNT( DISTINCT MaLopHoc )FROM(
	SELECT MaHocVien, MaNhomHoc FROM DANHSACHNHOM WHERE MaHocVien = @MaHocVien) q INNER JOIN NHOMHOC ON q.MaNhomHoc = NHOMHOC.MaNhomHoc

	if (@Row <> @RowD)
		BEGIN
			RAISERROR('HỌC VIÊN ĐÃ THAM GIA LỚP HỌC NÀY!',16,1);
		ROLLBACK;
		END
END
GO

-- trigger tự động tạo tài khoản khi có thêm một giáo viên
CREATE TRIGGER TG_TuDongThemTaiKhoanGiaoVien ON GIAOVIEN
AFTER INSERT
AS
BEGIN
	DECLARE @MaTK varchar(20)
	DECLARE @TenDN varchar(20)
	DECLARE @MK varchar(20)
	DECLARE @Quyen varchar(20)
	DECLARE @MaGV int
	SELECT @MaGV = i.MaGiaoVien,
	@MaTK = 'TK' + CAST(i.MaGiaoVien as varchar),
		@TenDN = i.HoTen,
		@MK = '123',
		@Quyen = 'Quyen1'
	FROM inserted i 

	if EXISTS (SELECT * FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN)
	BEGIN
		DECLARE @row int
		select @row = COUNT(*) FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN
		SET @row = @row + 1
		SET @TenDN = @TenDN + CAST(@row as varchar)
	END

	INSERT INTO TAIKHOAN (MaTaiKhoan, TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@MaTK, @TenDN, @MK, @Quyen)
	UPDATE GIAOVIEN SET MaTK = @MaTK WHERE MaGiaoVien = @MaGV
END
GO

--trigger tự động tạo tài khoản khi có thêm một học viên
CREATE TRIGGER TG_TuDongThemTaiKhoanHocVien ON HOCVIEN
AFTER INSERT
AS
BEGIN
	DECLARE @MaTK varchar(20)
	DECLARE @TenDN varchar(20)
	DECLARE @MK varchar(20)
	DECLARE @Quyen varchar(20)
	DECLARE @MaHV int

	SELECT @MaHV = i.MaHocVien,
	@MaTK = 'TK' + CAST( i.MaHocVien as varchar), 
		@TenDN = i.TenHocVien,
		@MK = '123',
		@Quyen = 'Quyen2'
	FROM inserted i 

	if EXISTS (SELECT * FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN)
	BEGIN
		DECLARE @row int
		select @row = COUNT(*) FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN
		SET @row = @row + 1
		SET @TenDN = @TenDN + CAST(@row as varchar)
	END

	INSERT INTO TAIKHOAN (MaTaiKhoan, TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@MaTK, @TenDN, @MK, @Quyen)
	UPDATE HOCVIEN SET MaTK = @MaTK WHERE MaHocVien = @MaHV
END
GO


--Trigger kiểm tra số lượng học viên của lớp khi xóa học viên khỏi danh sách
CREATE OR ALTER TRIGGER TG_KiemTraSoLuongHV ON DANHSACHNHOM
FOR DELETE
AS
BEGIN
   DECLARE @MaHocVien int
   DECLARE @MaNhomHoc int
   SELECT @MaHocVien = d.MaHocVien, @MaNhomHoc = d.MaNhomHoc
   FROM deleted d

   PRINT( 'Học viên bị xóa: ' + @MaHocVien)
   UPDATE NHOMHOC SET SoHocVienHienTai = SoHocVienHienTai - 1 WHERE MaNhomHoc = @MaNhomHoc
END
go

--Trigger kiểm tra điều kiện cấp chứng chỉ:
CREATE TRIGGER TG_KiemTraDieuKienCapChungChi
ON DANHSACHNHOM
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @MaNhomHoc varchar(20);
    DECLARE @MaHocVien varchar(20);
    DECLARE @DiemGiuaKhoa REAL;
    DECLARE @DiemCuoiKhoa REAL;
	DECLARE @DiemQuaMon REAL = 5;
    SELECT @MaNhomHoc = i.MaNhomHoc, @MaHocVien = i.MaHocVien, @DiemGiuaKhoa = i.DiemGiuaKhoa, @DiemCuoiKhoa = i.DiemCuoiKhoa
    FROM inserted i;
    IF @DiemGiuaKhoa >= @DiemQuaMon AND @DiemCuoiKhoa >= @DiemQuaMon
    BEGIN
        UPDATE DANHSACHNHOM
        SET TrangThaiCapChungChi = 1
        WHERE MaNhomHoc = @MaNhomHoc AND MaHocVien = @MaHocVien;
    END 
	  ELSE
    BEGIN
        UPDATE DANHSACHNHOM
        SET TrangThaiCapChungChi = 0
        WHERE MaNhomHoc = @MaNhomHoc AND MaHocVien = @MaHocVien;
    END
END;
GO

--------------------------------------------------------------------------------
-- TẠO CHỨC NĂNG

--proc lấy phân quyền
CREATE or ALTER PROCEDURE dbo.proc_LayRole(@loginname sysname)
AS
BEGIN
	select R.Name as Role
	from sys.database_principals P 
		left outer join sys.database_role_members RM on P.principal_id=RM.member_principal_id 
		left outer join sys.database_principals R on R.principal_id=RM.role_principal_id
	WHERE P.name = @loginname
END
go

-- Trigger tạo Login, User và gán quyền cho User sau khi tiến hành tạo tài khoản mới
CREATE or ALTER TRIGGER tg_TaoTaiKhoan ON TAIKHOAN
AFTER INSERT
AS
BEGIN
	DECLARE @username varchar(20);
	DECLARE @pass varchar(20);
	DECLARE @quyen varchar(20);
	DECLARE @sql varchar(2000);
 
	SELECT @username = i.TenDangNhap, @pass = i.MatKhau, @quyen = i.QuyenNguoiDung FROM inserted i
	SET @sql = 'CREATE LOGIN [' + @username + '] WITH PASSWORD=''' + @pass + ''', DEFAULT_DATABASE= HQTpr, CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF' 
	EXEC (@sql);
 
	SET @sql = 'CREATE USER ' + @username + ' FOR LOGIN ' + @username
	EXEC (@sql);
 
	IF(@quyen = 'Quyen2')
	BEGIN
		SET @sql = 'ALTER ROLE HocVien ADD MEMBER ' + @userName;
		EXEC (@sql)
	END
 
	ELSE IF(@quyen = 'Quyen1')
	BEGIN
		SET @sql = 'ALTER ROLE GiaoVien ADD MEMBER ' + @userName;
		EXEC (@sql)
	END
 
	ELSE IF(@quyen = 'Quyen3')
	BEGIN
		SET @sql = 'ALTER SERVER ROLE sysadmin ADD MEMBER ' + @username
		EXEC (@sql);
	END
END
go

--Kiểm tra ngày điểm danh
CREATE or ALTER PROC proc_KiemTraNgayDiemDanh
@day date
AS
BEGIN
	IF(@day not in (Select NgayHoc FROM NGAYHOC))
	BEGIN
		INSERT INTO dbo.NGAYHOC VALUES(@day)
	END
END
GO

-- procedure quản lý tài khoản
CREATE OR ALTER PROC QUANLYTAIKHOAN
@ThaoTac nvarchar(50),
@TenDangNhap nvarchar(20) = null,
@MatKhau varchar(20) = null,
@QuyenNguoiDung varchar(20) = null
AS
Begin
	if @ThaoTac = 'Add'
		begin
			INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@TenDangNhap, @MatKhau, @QuyenNguoiDung)
		end
		
	if @ThaoTac = 'Delete'
		begin
			DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap
		end

	if @ThaoTac = 'Update'
		begin	
			UPDATE TAIKHOAN SET  MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap
		end
End
go

--Hàm trả về một danh sách các nhóm học
CREATE OR ALTER FUNCTION dbo.uf_LayDanhSachNhom()
RETURNs TABLE
	AS RETURN 
		SELECT dbo.NHOMHOC.*, dbo.LOPHOC.TenLopHoc, dbo.GIAOVIEN.HoTen as TenGiaoVien
		FROM     dbo.LOPHOC INNER JOIN
				dbo.NHOMHOC ON dbo.LOPHOC.MaLopHoc = dbo.NHOMHOC.MaLopHoc INNER JOIN
				dbo.GIAOVIEN ON dbo.NHOMHOC.MaGiaoVien = dbo.GIAOVIEN.MaGiaoVien
go

--Hàm lấy danh sách nhóm đang dạy
CREATE OR ALTER FUNCTION dbo.uf_LayDanhSachNhom_DangDay(@MaGiaoVien int)
RETURNs TABLE
	AS RETURN 
		SELECT * 
		FROM dbo.uf_LayDanhSachNhom() 
		where MaGiaoVien = @MaGiaoVien
go

--Xóa một lớp học
CREATE OR ALTER PROC proc_XoaLopHoc
	@MaLopHoc varchar(20)
AS
BEGIN
	Begin try
		Delete from LOPHOC
		where MaLopHoc = @MaLopHoc
	End try
	Begin catch
		print N'Không xóa được'
		print ERROR_MESSAGE()
		Rollback Tran delete_Empl
	End catch
END
GO

--Giáo viên tạo thông báo
CREATE or ALTER PROCEDURE proc_ThemThongBao
	@MaGiaoVien int,
	@TieuDe nvarchar(50),
	@NoiDung nvarchar(255)
AS
BEGIN
	Begin Try
		INSERT INTO dbo.THONGBAO (MaGiaoVien, TieuDe, NoiDung, NgayGui) VALUES(@MaGiaoVien, @TieuDe, @NoiDung, GETDATE())
	End try
	Begin catch
		declare @mess varchar(max)
		set @mess=ERROR_MESSAGE()
		Raiserror(@mess, 16, 1)
	end catch
END
GO

-- Xem thông báo được tạo bởi một giáo viên
CREATE or ALTER FUNCTION uf_XemThongBaoGiaoVien (@MaGiaoVien int)
RETURNS TABLE
AS
	RETURN
	SELECT * FROM THONGBAO WHERE MaGiaoVien = @MaGiaoVien
GO

--Giáo viên gửi cho một nhóm học nào đó
CREATE or ALTER PROCEDURE proc_ThemTruyenTin
	@MaNhomHoc int
AS
BEGIN
	DECLARE @MaThongBao int
	Begin Try
		SELECT TOP 1 @MaThongBao = MaThongBao FROM THONGBAO
		ORDER BY NgayGui DESC
		INSERT INTO dbo.TRUYENTIN VALUES(@MaThongBao, @MaNhomHoc)
	End try
	Begin catch
		declare @mess varchar(max)
		set @mess=ERROR_MESSAGE()
		Raiserror(@mess, 16, 1)
	end catch
END
GO

-- Function Lấy danh sách học viên trong nhóm học
CREATE OR ALTER FUNCTION func_layDSHocVienNhomHoc(@maNhomHoc varchar(20))
RETURNs TABLE
AS RETURN 
	Select DANHSACHNHOM.*, HOCVIEN.TenHocVien
	From DANHSACHNHOM join HOCVIEN on DANHSACHNHOM.MaHocVien = HOCVIEN.MaHocVien
	Where DANHSACHNHOM.MaNhomHoc in (@maNhomHoc)
go

--Quản Lý Bảng Điểm
CREATE OR ALTER PROC QUANLYBANGDIEM
@MaNhomHoc nvarchar(20) = null,
@MaHocVien varchar(20) = null,
@DiemGiuaKhoa REAL,
@DiemCuoiKhoa REAL
AS
Begin
	UPDATE DANHSACHNHOM SET DiemGiuaKhoa = @DiemGiuaKhoa, DiemCuoiKhoa = @DiemCuoiKhoa 
	WHERE MaHocVien = @MaHocVien and MaNhomHoc = @MaNhomHoc
End
go

--lấy danh sách học viên của một nhóm
CREATE OR ALTER FUNCTION dbo.func_layDSHocVienNhomHoc(@MaNhomHoc int)
	RETURNs TABLE
	AS RETURN 
		Select DANHSACHNHOM.*, HOCVIEN.TenHocVien
		From DANHSACHNHOM join HOCVIEN on DANHSACHNHOM.MaHocVien = HOCVIEN.MaHocVien
		Where DANHSACHNHOM.MaNhomHoc in (@maNhomHoc)
	go

--Tạo proc chức năng xếp lịch học cho các nhóm học

--Lấy bảng điểm
CREATE OR ALTER PROC proc_LapBangDiem (@MaNhomHoc int)
	AS
	BEGIN
		SELECT DANHSACHNHOM.*, HOCVIEN.TenHocVien
		FROM DANHSACHNHOM join HOCVIEN on DANHSACHNHOM.MaHocVien = HOCVIEN.MaHocVien
		WHERE DANHSACHNHOM.MaNhomHoc = @MaNhomHoc
	END
	Go

exec proc_LapBangDiem 4
go

--Điểm danh
CREATE OR ALTER PROC proc_DiemDanhHocVien(
	@NgayHoc date,
	@MaNhomHoc varchar(20),
	@MaHocVien varchar(20),
	@HienDien BIT)
AS
BEGIN
	if (@NgayHoc not in (select NgayHoc from BANGDIEMDANH))
	begin
	Insert into BANGDIEMDANH(NgayHoc, MaNhomHoc, MaHocVien, HienDien) 
	Values (@NgayHoc, @MaNhomHoc, @MaHocVien, @HienDien);
	return;
	end
		
	UPDATE BANGDIEMDANH SET HienDien = @HienDien WHERE MaNhomHoc = @MaNhomHoc and MaHocVien = @MaHocVien and NgayHoc = @NgayHoc
END
GO

CREATE OR ALTER FUNCTION dbo.uf_LayBangDiemDanh()
RETURNS TABLE
AS
	RETURN 
	SELECT * FROM BANGDIEMDANH
GO

--Sửa thông tin học viên
CREATE or ALTER PROC proc_SuaThongTinHocVien
	@MaHocVien int,
	@TenHocVien nvarchar(50),
	@NgaySinh DATE,
	@GioiTinh nvarchar(20),
	@DiaChi nvarchar(100),
	@SoDienThoai varchar(20)
AS
BEGIN
	Begin try
		UPDATE HOCVIEN
		SET TenHocVien = @TenHocVien, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai
		WHERE MaHocVien = @MaHocVien
		PRINT @ma
	End try
	Begin catch
		declare @mess varchar(max)
		set @mess=ERROR_MESSAGE()
		Raiserror(@mess, 16, 1)
	End catch
END
GO

EXEC proc_SuaThongTinHocVien 1, 'Thanh' ,'2004-01-01','Nam', 'binh phuoc', '1234567890'
GO

--Lấy danh sách khóa
CREATE OR ALTER FUNCTION dbo.uf_LayDanhSachKhoa()
RETURNS TABLE
AS
	RETURN
	SELECT * FROM KHOAHOC
GO


--Lấy danh sách khóa
CREATE OR ALTER FUNCTION dbo.uf_LayDanhSachLop()
RETURNS TABLE
AS
	RETURN
	SELECT * FROM LOPHOC
GO
------------------------------------------------------------
--Tạo role phân các quyền trên table

--Tạo role cho các học viên
CREATE ROLE HocVien
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON DANGKY TO HocVien
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON HOCVIEN TO HocVien 
GRANT SELECT, REFERENCES ON DANHSACHNHOM TO HocVien
GRANT SELECT, INSERT, UPDATE, REFERENCES ON TAIKHOAN TO HocVien
GRANT SELECT, REFERENCES ON HOCTHEO TO HocVien
GRANT SELECT, REFERENCES ON KHOAHOC TO HocVien
GRANT SELECT, REFERENCES ON LOPHOC TO HocVien
GRANT SELECT, REFERENCES ON NHOMHOC TO HocVien
GRANT SELECT, REFERENCES ON GIAOVIEN TO HocVien
GRANT SELECT, REFERENCES ON CAHOC TO HocVien
GRANT SELECT, REFERENCES ON THONGBAO TO HocVien

GRANT EXECUTE TO HocVien
GRANT SELECT TO HocVien

--Tạo role cho các giáo viên
CREATE ROLE GiaoVien
GRANT SELECT, REFERENCES ON PHUTRACH TO GiaoVien
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON GIAOVIEN TO GiaoVien
GRANT SELECT, INSERT, UPDATE, REFERENCES ON TAIKHOAN TO GiaoVien
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON THONGBAO TO GiaoVien
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON TRUYENTIN TO GiaoVien
GRANT SELECT, REFERENCES ON HOCTHEO TO GiaoVien
GRANT SELECT, REFERENCES ON KHOAHOC TO GiaoVien
GRANT SELECT, REFERENCES ON LOPHOC TO GiaoVien
GRANT SELECT, UPDATE, INSERT, REFERENCES ON DANHSACHNHOM TO GiaoVien
GRANT SELECT, REFERENCES ON HOCTHEO TO GiaoVien
GRANT SELECT, REFERENCES ON HOCVIEN TO GiaoVien
GRANT EXECUTE TO GiaoVien
GRANT SELECT TO GiaoVien

GRANT SELECT ON uf_LayDanhSachNhom_DangDay TO GiaoVien
GRANT SELECT ON dbo.func_layDSHocVienNhomHoc TO GiaoVien
GRANT SELECT, INSERT, REFERENCES ON NgayHoc TO GiaoVien