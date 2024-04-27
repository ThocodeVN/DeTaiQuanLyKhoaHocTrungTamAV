-- Tạo cơ sở dữ liệu
CREATE DATABASE manageEmp;
GO

-- Sử dụng cơ sở dữ liệu
USE manageEmp;
GO

-- Tạo bảng Emp
CREATE TABLE Emp (
    eid INTEGER PRIMARY KEY,
    ename VARCHAR(100),
    age INTEGER,
    salary REAL
);
GO

-- Tạo bảng Works
CREATE TABLE Works (
    eid INTEGER,
    did INTEGER,
    pct_time INTEGER,
    FOREIGN KEY (eid) REFERENCES Emp(eid),
    FOREIGN KEY (did) REFERENCES Dept(did)
);
GO

-- Tạo bảng Dept
CREATE TABLE Dept (
    did INTEGER PRIMARY KEY,
    budget REAL,
    managerid INTEGER,
    FOREIGN KEY (managerid) REFERENCES Emp(eid)
);
GO

select * from Dept
go

CREATE TRIGGER checkSal ON Dept
FOR INSERT, UPDATE 
AS
BEGIN
	DECLARE @newmnid INT
	SELECT @newmnid = ne.managerid
	FROM INSERTED ne
	
	

	IF @newmnid NOT IN ( SELECT eid FROM Emp )
	BEGIN
		RAISERROR ('không tìm thấy quản lý này',16,10)
		ROLLBACK TRAN;
		RETURN;
	END

	SELECT did, MIN(eid) AS eid INTO ED
	FROM Works 
	GROUP BY did;

	SELECT managerid, eid INTO MD
	FROM ED INNER JOIN Dept ON ED.did = Dept.did
	
	SELECT managerid, Emp.eid, Emp.salary INTO SD
	FROM MD INNER JOIN Emp ON MD.eid = Emp.eid
	
	DECLARE @max REAL
	SELECT @max = MAX(salary)
	FROM  SD

	DECLARE @mnSal INT
	SELECT @mnSal = salary
	FROM Emp
	WHERE eid = @newmnid

	IF @mnSal < @max
	BEGIN
		RAISERROR ('lương quản lý phải lớn hơn nhân viên',16,10)
		ROLLBACK TRAN;
	END
END
GO
--Emp(eid: integer, ename: string, age: integer, salary: real)
--Works(eid: integer, did: integer, pct_time: integer)
--Dept(did: integer, budget: real, managerid: integer)


--Whenever an employee is given a raise, the manager’s salary must be increased to
--be at least as much.

CREATE TRIGGER checkRAIS ON Emp
AFTER UPDATE
AS
BEGIN
	DECLARE @newSaL INT, @oldSal INT
	SELECT @newSal = ne.salary, @oldSal = ol.salary
	FROM inserted ne, inserted ol

	DECLARE @addition INT
	SELECT @addition = @newSaL - @oldSal

	DECLARE @ID INT;
	DECLARE readf CURSOR FOR 
	SELECT managerid FROM Dept;

	OPEN readf;
	FETCH NEXT FROM readf INTO @ID;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Xử lý giá trị @value ở đây

		FETCH NEXT FROM cursor_name INTO @ID;
		UPDATE Emp SET salary = salary + @addition
		WHERE Emp.eid = @ID
	END

	CLOSE readf;
	DEALLOCATE readf;
END
GO
