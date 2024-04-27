use DBhqt
go

--Bảng Quyền người dùng
CREATE TABLE QUYENNGUOIDUNG(
	QuyenNguoiDung varchar(20) CONSTRAINT PK_QUYENNGUOIDUNG PRIMARY KEY,
	TenQuyen nvarchar(50) NOT NULL
)
go


--Bảng Tài Khoản
CREATE TABLE TAIKHOAN(
    TenDangNhap varchar(20) CONSTRAINT PK_TAIKHOAN PRIMARY KEY,
    MatKhau varchar(20) NOT NULL,
    QuyenNguoiDung varchar(20) NOT NULL,
    CONSTRAINT FK_QUYENNGUOIDUNG_TAIKHOAN FOREIGN KEY (QuyenNguoiDung) 
        REFERENCES QUYENNGUOIDUNG(QuyenNguoiDung)
);
go

---- procedure quản lý tài khoản
--CREATE OR ALTER PROC QUANLYTAIKHOAN
--@ThaoTac nvarchar(50),
--@TenDangNhap nvarchar(20) = null,
--@MatKhau varchar(20) = null,
--@QuyenNguoiDung varchar(20) = null
--AS
--Begin
--	if @ThaoTac = 'Add'
--		begin
--			INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, QuyenNguoiDung) VALUES (@TenDangNhap, @MatKhau, @QuyenNguoiDung)
--		end
		
--	if @ThaoTac = 'Delete'
--		begin
--			DELETE FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap
--		end

--	if @ThaoTac = 'Update'
--		begin	
--			UPDATE TAIKHOAN SET  MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap
--		end
--End
--go


--exec QUANLYTAIKHOAN 'Add', 'Quan', '123', 'GiaoVien'

--Bảng Giáo Viên
CREATE TABLE GIAOVIEN(
	MaGiaoVien varchar(20) constraint PK_GIAOVIEN PRIMARY KEY,
	HoTen nvarchar(50) NOT NULL,
	NgaySinh DATE CHECK(DATEDIFF(year, NgaySinh, GETDATE()) >= 18),
	GioiTinh nvarchar(20) NOT NULL, 
	DiaChi nvarchar(100) NOT NULL,
	SoDienThoai varchar(20) CHECK(len(SoDienThoai) = 10),
	Email varchar(50) NOT NULL,
	TenDangNhap varchar(20) CONSTRAINT FK_GIAOVIEN_TAIKHOAN FOREIGN KEY REFERENCES TAIKHOAN(TenDangNhap) ON DELETE SET NULL ON UPDATE CASCADE 
)
go

--INSERT INTO GIAOVIEN (MaGiaoVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, TenDangNhap)
--VALUES ('GV001', 'Quân', '1980-01-01', 'Nam', 'Địa chỉ của Quân', '0123456789', 'quan@example.com', 'Quan');


--Bảng Khóa Học
CREATE TABLE KHOAHOC(
	MaKhoaHoc varchar(20) constraint PK_KHOAHOC PRIMARY KEY,
	TenKhoaHoc nvarchar(50) NOT NULL
)
go

--Bảng Lớp Học
CREATE TABLE LOPHOC(
	MaLopHoc varchar(20) constraint PK_LOPHOC PRIMARY KEY,
	MaKhoaHoc varchar(20) constraint FK_LOPHOC_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	TenLopHoc nvarchar(50) NOT NULL,
	TongSoBuoiHoc INT CHECK(TongSoBuoiHoc > 0),
	HocPhi REAL CHECK(HocPhi >= 0)
)
go

--Bảng Phòng Học
CREATE TABLE PHONGHOC(
	MaPhongHoc varchar(20) constraint PK_PHONGHOC PRIMARY KEY,
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
	MaNhomHoc varchar(20) constraint PK_NHOMHOC PRIMARY KEY,
	MaLopHoc varchar(20) constraint FK_NHOMHOC_LOPHOC FOREIGN KEY REFERENCES LOPHOC(MaLopHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	MaGiaoVien varchar(20) constraint FK_NHOMHOC_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE SET NULL ON UPDATE CASCADE,
	MaPhongHoc varchar(20) constraint FK_NHOMHOC_PHONGHOC FOREIGN KEY REFERENCES PHONGHOC(MaPhongHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	Ca INT constraint FK_NHOMHOC_CAHOC FOREIGN KEY REFERENCES CAHOC(Ca) ON DELETE SET NULL ON UPDATE CASCADE,
	SoLuongHocVienToiThieu INT CHECK(SoLuongHocVienToiThieu > 0),
	SoLuongHocVienToiDa INT CHECK(SoLuongHocVienToiDa > 0), 
	NgayBatDau DATE NOT NULL,	
	NgayKetThuc DATE NOT NULL, 
	TrangThaiMoDangKy BIT NOT NULL DEFAULT 0,
)	
go

---- Hàm chức năng lấy danh sách các nhóm mà giáo viên đang dạy
--CREATE OR ALTER FUNCTION Lay_Danh_Sach_Nhom_Giao_Vien_Dang_Day (@MaGiaoVien varchar(20))
--RETURNS Table
--AS
--RETURN	(SELECT * FROM NHOMHOC WHERE MaGiaoVien = @MaGiaoVien)
--GO


--select * from Lay_Danh_Sach_Nhom_Giao_Vien_Dang_Day ('GV001')

--Bảng Học Viên
CREATE TABLE HOCVIEN(
	MaHocVien varchar(20) constraint PK_HOCVIEN PRIMARY KEY,
	TenHocVien nvarchar(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh nvarchar(20) NOT NULL, 
	DiaChi nvarchar(100) NOT NULL,
	SoDienThoai varchar(20) CHECK(len(SoDienThoai) = 10),
	CCCD varchar(50) CHECK(len(CCCD) = 12),
	TenDangNhap varchar(20) CONSTRAINT FK_HOCVIEN_TAIKHOAN FOREIGN KEY REFERENCES TAIKHOAN(TenDangNhap) ON DELETE SET NULL ON UPDATE CASCADE 
)
go

--Bảng Thông Báo
CREATE TABLE THONGBAO(
	MaThongBao varchar(20) constraint PK_THONGBAO PRIMARY KEY,
	MaGiaoVien varchar(20) CONSTRAINT FK_THONGBAO_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE SET NULL ON UPDATE CASCADE,
	MaNhomHoc varchar(20) CONSTRAINT FK_THONGBAO_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE SET NULL ON UPDATE CASCADE,
	TieuDe nvarchar(50),
	NoiDung nvarchar(255) NOT NULL,
	NgayGui date not null,
)
go

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
	MaGiaoVien varchar(20) constraint FK_PHUTRACH_GIAOVIEN FOREIGN KEY REFERENCES GIAOVIEN(MaGiaoVien) ON DELETE CASCADE ON UPDATE CASCADE,
	MaKhoaHoc varchar(20) constraint FK_PHUTRACH_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT PK_PHUTRACH PRIMARY KEY (MaGiaoVien, MaKhoaHoc)
)
go

--DROP TABLE HOCVAO

--Bảng Danh Sách Nhóm
CREATE TABLE DANHSACHNHOM(
	MaNhomHoc varchar(20) constraint FK_DANHSACHNHOM_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE,
	MaHocVien varchar(20) constraint FK_DANHSACHNHOM_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE, 
	DiemGiuaKhoa REAL CHECK(DiemGiuaKhoa between 0 and 10) DEFAULT 0,
	DiemCuoiKhoa REAL CHECK(DiemCuoiKhoa between 0 and 10) DEFAULT 0,
	TrangThaiThanhToan BIT NOT NULL DEFAULT 0,
	TrangThaiCapChungChi BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_DANHSACHNHOM PRIMARY KEY (MaHocVien, MaNhomHoc)
)
go


----Tạo proc chức năng quản lý bảng điểm 
--CREATE OR ALTER PROC QUANLYTAIKHOAN
--@MaNhomHoc nvarchar(20) = null,
--@MaHocVien varchar(20) = null,
--@DiemGiuaKhoa REAL,
--@DiemCuoiKhoa REAL
--AS
--Begin
--			UPDATE DANHSACHNHOM SET DiemGiuaKhoa = @DiemGiuaKhoa, DiemCuoiKhoa = @DiemCuoiKhoa 
--			WHERE MaHocVien = @MaHocVien and MaNhomHoc = @MaNhomHoc
--End
--go

----Tạo trigger quản lý cấp chứng chỉ
--CREATE TRIGGER TG_KiemTraDieuKienCapChungChi
--ON DANHSACHNHOM
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    DECLARE @MaNhomHoc varchar(20);
--    DECLARE @MaHocVien varchar(20);
--    DECLARE @DiemGiuaKhoa REAL;
--    DECLARE @DiemCuoiKhoa REAL;
--	DECLARE @DiemQuaMon REAL = 5;
--    SELECT @MaNhomHoc = i.MaNhomHoc, @MaHocVien = i.MaHocVien, @DiemGiuaKhoa = i.DiemGiuaKhoa, @DiemCuoiKhoa = i.DiemCuoiKhoa
--    FROM inserted i;
--    IF @DiemGiuaKhoa >= @DiemQuaMon AND @DiemCuoiKhoa >= @DiemQuaMon
--    BEGIN
--        UPDATE DANHSACHNHOM
--        SET TrangThaiCapChungChi = 1
--        WHERE MaNhomHoc = @MaNhomHoc AND MaHocVien = @MaHocVien;
--    END 
--	  ELSE
--    BEGIN
--        UPDATE DANHSACHNHOM
--        SET TrangThaiCapChungChi = 0
--        WHERE MaNhomHoc = @MaNhomHoc AND MaHocVien = @MaHocVien;
--    END
--END;
--GO


----Hàm trả về danh sách học viên của một nhóm
--CREATE OR ALTER FUNCTION Lay_Danh_Sach_Hoc_Vien_Cua_Mot_Nhom (@MaNhomHoc varchar(20))
--RETURNS table
--as
--	RETURN (SELECT * FROM DANHSACHNHOM WHERE MaNhomHoc = @MaNhomHoc)
--go

--Bảng Điểm Danh
CREATE TABLE BANGDIEMDANH(
	NgayHoc DATE constraint FK_BANGDIEMDANH_NGAYHOC FOREIGN KEY REFERENCES NGAYHOC(NgayHoc) ON DELETE CASCADE ,
	MaNhomHoc varchar(20) constraint FK_BANGDIEMDANH_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE ,
	MaHocVien varchar(20) constraint FK_BANGDIEMDANH_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE,
	HienDien BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_BANGDIEMDANH PRIMARY KEY (NgayHoc, MaNhomHoc, MaHocVien)
)
go

----Procedure thêm một danh sách điểm danh theo ngày dựa trên danh sách nhóm
--CREATE OR ALTER PROC Tao_Bang_Diem_Danh
--@MaNhomHoc varchar(20)
--AS
--Begin
--	-- kiểm tra xem đã tạo bảng điểm danh cho ngày hôm nay hay chưa, nếu chưa thì tạo
--	DECLARE @Row int
--	SELECT @Row = COUNT(*) FROM BANGDIEMDANH WHERE NgayHoc = CONVERT(DATE, GETDATE()) AND MaNhomHoc = @MaNhomHoc
--	IF @Row = 0
--		Begin
--				INSERT INTO BANGDIEMDANH(NgayHoc ,MaNhomHoc, MaHocVien, HienDien)
--				SELECT CONVERT(DATE, GETDATE()), @MaNhomHoc, MaHocVien, 0
--				FROM Lay_Danh_Sach_Hoc_Vien_Cua_Mot_Nhom(@MaNhomHoc)
--		End
--End
--go

----Proc chức năng điểm danh cho một nhóm học 
--CREATE OR ALTER PROC Diem_Danh_Cho_Nhom 
--@MaNhomHoc varchar(20),
--@NgayHoc DATE,
--@MaHocVien varchar(20)
--AS
--Begin
--	-- kiểm tra xem một nhóm học đã có ngày điểm danh chưa, nếu rồi thì mới điểm danh
--	DECLARE @Row int
--	SELECT @Row = COUNT(*) FROM BANGDIEMDANH WHERE NgayHoc = CONVERT(DATE, GETDATE()) AND MaNhomHoc = @MaNhomHoc
--	IF @Row > 0
--		Begin
--				UPDATE BANGDIEMDANH SET HienDien = 1
--				WHERE NgayHoc = @NgayHoc and MaNhomHoc = @MaNhomHoc and MaHocVien = @MaHocVien
--		End
--End
--go


--Bảng đăng ký
create table DANGKY
(
	MaKhoaHoc varchar(20) CONSTRAINT FK_DANGKY_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc),
	MaLopHoc varchar(20) CONSTRAINT FK_DANGKY_LOPHOC FOREIGN KEY REFERENCES LOPHOC(MaLopHoc),
	MaHocVien varchar(20) CONSTRAINT FK_DANGKY_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien),
	CONSTRAINT PK_DANGKY PRIMARY KEY(MaKhoaHoc,MaLopHoc,MaHocVien)
)

-- Bảng học theo
CREATE TABLE HOCTHEO(
	MaPhongHoc varchar(20) constraint FK_HOCTHEO_PHONGHOC FOREIGN KEY REFERENCES PHONGHOC (MaPhongHoc),
	Ca INT constraint FK_HOCTHEO_CAHOC FOREIGN KEY REFERENCES CAHOC(Ca),
	MaNhomHoc varchar(20) constraint FK_HOCTHEO_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC (MaNhomHoc) ,
	Thu nvarchar(20) constraint FK_HOCTHEO_THUTRONGTUAN foreign key references THUTRONGTUAN (ThuTrongTuan)
	CONSTRAINT PK_HOCTHEO PRIMARY KEY(MaPhongHoc,Ca,MaNhomHoc)
)
	
----Trigger kiểm tra học viên có đăng ký 2 nhóm cùng 1 lớp không?
--CREATE TRIGGER TG_KiemTraTrungLop ON DANHSACHNHOM
--AFTER INSERT
--AS
--BEGIN
--	DECLARE @MaHocVien varchar(20)
--	SELECT @MaHocVien = i.MaHocVien
--	FROM inserted i

--	DECLARE @Row int
--	DECLARE @RowD int

--	SELECT @Row = COUNT(q.MaNhomHoc) , @RowD = COUNT( DISTINCT MaLopHoc )FROM(
--	SELECT MaHocVien, MaNhomHoc FROM DANHSACHNHOM WHERE MaHocVien = @MaHocVien) q INNER JOIN NHOMHOC ON q.MaNhomHoc = NHOMHOC.MaNhomHoc

--		if (@Row <> @RowD)
--		BEGIN
--			RAISERROR('HỌC VIÊN ĐÃ THAM GIA LỚP HỌC NÀY!',16,1);
--		ROLLBACK;
--		END
--END
--GO

