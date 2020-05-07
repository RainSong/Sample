USE master
GO
IF NOT EXISTS ( SELECT  name
                FROM    SYS.databases
                WHERE   name = 'sample' ) 
    BEGIN
        CREATE DATABASE sample
    END

USE sample
GO

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   name = 'classes' ) 
    BEGIN
        DROP TABLE classes
    END
GO

CREATE TABLE classes
    (
      ID INT NOT NULL
             IDENTITY(1, 1)
             PRIMARY KEY ,
      [Name] VARCHAR(50) NOT NULL
    )

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   name = 'students' ) 
    BEGIN
        DROP TABLE students
    END
CREATE TABLE students
    (
      ID INT PRIMARY KEY
             IDENTITY(1, 1) ,
      ClassID INT NOT NULL ,
      Name VARCHAR(30) NOT NULL ,
      Sex BIT NOT NULL
              DEFAULT 1 ,
      Brithday DATETIME NULL ,
      StudentNO VARCHAR(50) NOT NULL
    )
GO

INSERT  INTO Classes
        ( [Name] )
VALUES  ( '一年级甲班' )


GO
INSERT  INTO students
        ( ClassID ,
          Name ,
          Sex ,
          Brithday ,
          StudentNO
        )
        SELECT  *
        FROM    ( SELECT    1 AS ClassID ,
                            '张国立' AS Name ,
                            1 AS Sex ,
                            '1988-7-7' AS Brithday ,
                            'Stu0001' AS StudentNO
                  UNION ALL
                  SELECT    1 ,
                            '王丽丽' ,
                            0 ,
                            '1985-10-1' ,
                            'Stu0002'
                  UNION ALL
                  SELECT    1 ,
                            '王宝强' ,
                            1 ,
                            '1992-5-6' ,
                            'Stu0003'
                  UNION ALL
                  SELECT    1 ,
                            '赵丽颖' ,
                            0 ,
                            '1991-10-11' ,
                            'Stu0004'
                ) AS T