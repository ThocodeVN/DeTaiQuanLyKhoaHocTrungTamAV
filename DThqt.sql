use HQT
go

--Tạo bảng-------------------------------------------------------------

--Bảng Quyền người dùng
CREATE TABLE QUYENNGUOIDUNG(
	QuyenNguoiDung varchar(20) CONSTRAINT PK_QUYENNGUOIDUNG PRIMARY KEY,
	TenQuyen nvarchar(50) NOT NULL
)
go

--Bảng Tài Khoản
CREATE TABLE TAIKHOAN(
	MaTaiKhoan int constraint PK_TAIKHOAN primary key,
    TenDangNhap varchar(20) unique,
    MatKhau varchar(20) NOT NULL,
    QuyenNguoiDung varchar(20) NOT NULL,
    CONSTRAINT FK_QUYENNGUOIDUNG_TAIKHOAN FOREIGN KEY (QuyenNguoiDung) 
        REFERENCES QUYENNGUOIDUNG(QuyenNguoiDung)
);
go

--Bảng Giáo Viên
CREATE TABLE GIAOVIEN(
	MaGiaoVien int constraint PK_GIAOVIEN PRIMARY KEY IDENTITY,
	HoTen nvarchar(50) NOT NULL,
	NgaySinh DATE CHECK(DATEDIFF(year, NgaySinh, GETDATE()) >= 18),
	GioiTinh nvarchar(20) NOT NULL, 
	DiaChi nvarchar(100) NOT NULL,
	SoDienThoai varchar(20) CHECK(len(SoDienThoai) = 10),
	Email varchar(50) NOT NULL, 
	MaTK int constraint FK_GIAOVIEN_TAIKHOAN foreign key references TAIKHOAN(MaTaiKhoan)
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
	CCCD varchar(50) CHECK(len(CCCD) = 12),
	MaTK int constraint FK_HOCVIEN_TAIKHOAN foreign key references TAIKHOAN(MaTaiKhoan)
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
	DECLARE @MaTK int
	DECLARE @TenDN varchar(20)
	DECLARE @MK varchar(20)
	DECLARE @Quyen varchar(20)
	
	SELECT @MaTK = 'TK' + i.MaGiaoVien,
		@TenDN = i.HoTen,
		@MK = '123',
		@Quyen = 'Quyen1'
	FROM inserted i 

	if EXISTS (SELECT * FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN)
	BEGIN
		DECLARE @row int
		select @row = COUNT(*) FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN
		SET @row = @row + 1
		SET @TenDN = @TenDN + @row
	END

	INSERT INTO TAIKHOAN (MaTaiKhoan, TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@MaTK, @TenDN, @MK, @Quyen)
END
GO

--trigger tự động tạo tài khoản khi có thêm một học viên
CREATE TRIGGER TG_TuDongThemTaiKhoanHocVien ON HOCVIEN
AFTER INSERT
AS
BEGIN
	DECLARE @MaTK int
	DECLARE @TenDN varchar(20)
	DECLARE @MK varchar(20)
	DECLARE @Quyen varchar(20)
	
	SELECT @MaTK = 'TK' + i.MaHocVien,
		@TenDN = i.TenHocVien,
		@MK = '123',
		@Quyen = 'Quyen2'
	FROM inserted i 

	if EXISTS (SELECT * FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN)
	BEGIN
		DECLARE @row int
		select @row = COUNT(*) FROM TAIKHOAN WHERE TAIKHOAN.TenDangNhap = @TenDN
		SET @row = @row + 1
		SET @TenDN = @TenDN + @row
	END

	INSERT INTO TAIKHOAN (MaTaiKhoan, TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@MaTK, @TenDN, @MK, @Quyen)
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
CREATE OR ALTER FUNCTION uf_LayDanhSachNhom()
RETURNs TABLE
	AS RETURN 
		SELECT dbo.NHOMHOC.*, dbo.LOPHOC.TenLopHoc, dbo.GIAOVIEN.HoTen as TenGiaoVien
		FROM     dbo.LOPHOC INNER JOIN
				dbo.NHOMHOC ON dbo.LOPHOC.MaLopHoc = dbo.NHOMHOC.MaLopHoc INNER JOIN
				dbo.GIAOVIEN ON dbo.NHOMHOC.MaGiaoVien = dbo.GIAOVIEN.MaGiaoVien
go

--Hàm lấy danh sách nhóm đang dạy
CREATE OR ALTER FUNCTION uf_LayDanhSachNhom_DangDay(@MaGiaoVien varchar(20))
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

--Giáo viên gửi cho một nhóm học nào đó
CREATE or ALTER PROCEDURE proc_ThemTruyenTin
	@MaThongBao varchar(20),
	@MaNhomHoc varchar(20)
AS
BEGIN
	Begin Try
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

--Tạo proc chức năng cập nhật bảng điểm bảng điểm 
CREATE OR ALTER PROC QUANLYTAIKHOAN
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

--Tạo proc chức năng xếp lịch học cho các nhóm học


