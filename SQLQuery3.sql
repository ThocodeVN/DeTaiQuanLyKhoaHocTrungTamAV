﻿use Project_DBMS
go

--Bảng Quyền người dùng
CREATE TABLE QUYENNGUOIDUNG(
	MaQuyen varchar(20) CONSTRAINT PK_QUYENNGUOIDUNG PRIMARY KEY,
	TenQuyen nvarchar(50) NOT NULL
)
go

--Bảng Tài Khoản
CREATE TABLE TAIKHOAN(
    TenDangNhap varchar(20) CONSTRAINT PK_TAIKHOAN PRIMARY KEY,
    MatKhau varchar(20) NOT NULL,
    QuyenNguoiDung varchar(20) NOT NULL,
    CONSTRAINT FK_QUYENNGUOIDUNG_TAIKHOAN FOREIGN KEY (QuyenNguoiDung) 
        REFERENCES QUYENNGUOIDUNG(MaQuyen)
);

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
	TieuDe nvarchar(50),
	NoiDung nvarchar(255) NOT NULL
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

--Bảng Học Vào
CREATE TABLE HOCVAO(
	MaNhomHoc varchar(20) constraint FK_HOCVAO_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE ON UPDATE CASCADE,
	ThuTrongTuan nvarchar(20) constraint FK_HOCVAO_THUTRONGTUAN FOREIGN KEY REFERENCES THUTRONGTUAN(ThuTrongTuan) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT PK_HOCVAO PRIMARY KEY (MaNhomHoc, ThuTrongTuan)
)
go

--Bảng Danh Sách Nhóm
CREATE TABLE DANHSACHNHOM(
	MaNhomHoc varchar(20) constraint FK_DANHSACHNHOM_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE,
	MaHocVien varchar(20) constraint FK_DANHSACHNHOM_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE, 
	DiemLyThuyet REAL CHECK(DiemLyThuyet between 0 and 10) DEFAULT 0,
	DiemThucHanh REAL CHECK(DiemThucHanh between 0 and 10) DEFAULT 0,
	TrangThaiThanhToan BIT NOT NULL DEFAULT 0,
	TrangThaiCapChungChi BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_DANHSACHNHOM PRIMARY KEY (MaHocVien, MaNhomHoc)
)
go

--Bảng Truyền Tin
CREATE TABLE TRUYENTIN(
	MaThongBao varchar(20) constraint FK_TRUYENTIN_THONGBAO FOREIGN KEY REFERENCES THONGBAO(MaThongBao) ON DELETE CASCADE,
	MaNhomHoc varchar(20) constraint FK_TRUYENTIN_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE,
	CONSTRAINT PK_TRUYENTIN PRIMARY KEY (MaThongBao, MaNhomHoc)
)
go

--Bảng Bảng Điểm Danh
CREATE TABLE BANGDIEMDANH(
	NgayHoc DATE constraint FK_BANGDIEMDANH_NGAYHOC FOREIGN KEY REFERENCES NGAYHOC(NgayHoc) ON DELETE CASCADE ,
	MaNhomHoc varchar(20) constraint FK_BANGDIEMDANH_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC(MaNhomHoc) ON DELETE CASCADE ,
	MaHocVien varchar(20) constraint FK_BANGDIEMDANH_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien) ON DELETE CASCADE,
	HienDien BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_BANGDIEMDANH PRIMARY KEY (NgayHoc, MaNhomHoc, MaHocVien)
)
Go

create table DANGKY
(
	MaKhoaHoc varchar(20) CONSTRAINT FK_DANGKY_KHOAHOC FOREIGN KEY REFERENCES KHOAHOC(MaKhoaHoc),
	MaLopHoc varchar(20) CONSTRAINT FK_DANGKY_LOPHOC FOREIGN KEY REFERENCES LOPHOC(MaLopHoc),
	MaHocVien varchar(20) CONSTRAINT FK_DANGKY_HOCVIEN FOREIGN KEY REFERENCES HOCVIEN(MaHocVien),
	CONSTRAINT PK_DANGKY PRIMARY KEY(MaKhoaHoc,MaLopHoc,MaHocVien)
)
go


CREATE TABLE HOCTHEO(
	MaPhongHoc varchar(20) constraint FK_HOCTHEO_PHONGHOC FOREIGN KEY REFERENCES PHONGHOC (MaPhongHoc),
	Ca INT constraint FK_HOCTHEO_CAHOC FOREIGN KEY REFERENCES CAHOC(Ca),
	MaNhomHoc varchar(20) constraint FK_HOCTHEO_NHOMHOC FOREIGN KEY REFERENCES NHOMHOC (MaNhomHoc) 
	CONSTRAINT PK_HOCTHEO PRIMARY KEY(MaPhongHoc,Ca,MaNhomHoc)
)
go
