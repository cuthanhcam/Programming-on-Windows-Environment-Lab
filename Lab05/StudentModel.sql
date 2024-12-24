-- Tạo cơ sở dữ liệu
CREATE DATABASE StudentModel

-- Sử dụng cơ sở dữ liệu đã tạo
USE StudentModel;

-- Tạo bảng Faculty
CREATE TABLE Faculty (
    FacultyID INT PRIMARY KEY,
    FacultyName NVARCHAR(255) NOT NULL
);

-- Tạo bảng Major
CREATE TABLE Major (
    FacultyID INT,
    MajorID INT,
    Name NVARCHAR(255) NOT NULL,
    PRIMARY KEY (FacultyID, MajorID),
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
);

-- Tạo bảng Student
CREATE TABLE Student (
    StudentID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    AverageScore FLOAT,
    FacultyID INT NULL,
    MajorID INT NULL,
    Avatar NVARCHAR(255) NULL,
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID),
    FOREIGN KEY (FacultyID, MajorID) REFERENCES Major(FacultyID, MajorID)
);

-- Thêm dữ liệu vào bảng Faculty
INSERT INTO Faculty (FacultyID, FacultyName)
VALUES
	(1, N'Công nghệ thông tin'),
	(2, N'Ngôn Ngữ Anh'),
	(3, N'Quản Trị Kinh Doanh');

-- Thêm dữ liệu vào bảng Major
INSERT INTO Major (FacultyID, MajorID, Name)
VALUES
	(1, 1, N'Công nghệ phần mềm'),
	(2, 1, N'Tiếng Anh Thương Mại'),
	(1, 2, N'Hệ thống thông tin'),
	(2, 2, N'Tiếng Anh Truyền Thông'),
	(1, 3, N'An toàn thông tin');

SELECT * FROM Faculty;
SELECT * FROM Major;