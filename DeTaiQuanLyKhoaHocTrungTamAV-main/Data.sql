use DBhqt
go

-- chèn dữ liệu cho bảng QUYENNGUOIDUNG
select * from QUYENNGUOIDUNG

insert into QUYENNGUOIDUNG (QuyenNguoiDung, TenQuyen) values ('Quyen1', 'GiaoVien')
insert into QUYENNGUOIDUNG (QuyenNguoiDung, TenQuyen) values ('Quyen2', 'HocVien')

--Chèn dữ liệu cho bảng TAIKHOAN
select * from TAIKHOAN

insert into TAIKHOAN (TenDangNhap, MatKhau, QuyenNguoiDung) values ('Quan', '123', 'Quyen1')
insert into TAIKHOAN (TenDangNhap, MatKhau, QuyenNguoiDung) values ('Tho', '123', 'Quyen1')
insert into TAIKHOAN (TenDangNhap, MatKhau, QuyenNguoiDung) values ('Thanh', '124', 'Quyen2')

exec QUANLYTAIKHOAN 'Add', 'Ngoc', '123', 'Quyen2'

-- Chèn dữ liệu cho bảng GIAOVIEN
select * from GIAOVIEN 

insert into GIAOVIEN (MaGiaoVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, TenDangNhap) values ('GV001', 'Quan', '1980-01-01','Nam', 'My Tho', '1234567890', 'Quan@gmail.com', 'Quan')
insert into GIAOVIEN (MaGiaoVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, TenDangNhap) values ('GV002', 'Tho', '1980-01-01','Nam', 'My Tho', '1234567890', 'Quan@gmail.com', 'Tho')

-- Chèn dữ liệu cho bảng KHOAHOC
select * from KHOAHOC

insert into KHOAHOC(MaKhoaHoc, TenKhoaHoc) values ('KH01', 'Ielts')

-- Chèn dữ liệu cho bảng LOPHOC

select * from LOPHOC

insert into LOPHOC(MaLopHoc, MaKhoaHoc, TenLopHoc, HocPhi, TongSoBuoiHoc) values ('LOP01', 'KH01', 'Lop 6.0', 10000, '50')

-- Chèn dữ liệu cho bảng NHOMHOC
select * from NHOMHOC 