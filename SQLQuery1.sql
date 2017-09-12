USE master
GO
IF NOT EXISTS (SELECT name FROM SYS.databases WHERE name = 'sample')
BEGIN
	CREATE DATABASE sample
END

USE sample
GO

IF EXISTS (SELECT * FROM sys.objects where name = 'students')
BEGIN
	DROP TABLE students
END
CREATE TABLE students
	(
		ID INT PRIMARY KEY IDENTITY(1,1),
		Name VARCHAR(30) NOT NULL,
		Sex BIT NOT NULL DEFAULT 1,
		Brithday DATETIME NULL
	)

GO
INSERT INTO students (Name,Sex,Brithday)
SELECT * FROM (SELECT '张国立' AS Name,1 AS Sex,'1988-7-7' as Brithday
			   UNION ALL
			   SELECT '王丽丽',0,'1985-10-1'
			   UNION ALL
			   SELECT '王宝强',1,'1992-5-6'
			   UNION ALL
			   SELECT '赵丽颖',0,'1991-10-11') AS T