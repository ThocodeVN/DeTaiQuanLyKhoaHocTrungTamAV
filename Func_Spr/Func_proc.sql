create database TestSQLCSharp
go

use TestSQLCsharp
go

create function Hello()
returns nvarchar(50)
as
begin
	declare @hello nvarchar(50)
	set @hello = 'Hello!'
	return @hello
end
go

create function Goodnight(@name nvarchar(50))
returns nvarchar(50)
as
begin
	set @name = 'Goodnight ' + @name
	return @name
end
go

create proc Info
as
begin
	select * from Person
end
go

create proc Info_ID @id int
as
begin
	select * from Person
	where id = @id
end