use QLNV1
go

select * from NhanVien
go

create trigger test on dbo.NhanVien
for insert
as
begin
	print N' đã thêm thành công'
end
go

insert into dbo.NhanVien (Manv, HoNV, Tenlot, tenNV, NgSinh, Dchi, Phai, Luong, MaNQL, Phong) 
values ('nv16', 'Ho', 'Dang', 'Xuan Trang', '2004-04-05', 'da lat', 'Nu',1000, 'NV06', 8)
go

create trigger checkold on dbo.NhanVien
for delete
as
begin
	declare @old date
	select @old = ol.NgSinh
	from deleted ol
	if YEAR(getdate()) - YEAR(@old) > 30
		begin
			print N'không được xóa người trên 30 tuổi'
			rollback tran
		end
end

delete from NhanVien where Manv = 'nv07'

select * from ThanNhan
go

create trigger checkemp on dbo.ThanNhan
for delete
as
begin
	declare @old date
	select @old = ol.NgaySinh
	from deleted ol
	if YEAR(getdate()) - YEAR(@old) >1
		begin
			print N'không được xóa người trên 1 tuổi'
			rollback tran
		end
end

delete from ThanNhan where MaNV = 'nv02'