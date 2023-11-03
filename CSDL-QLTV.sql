CREATE DATABASE QLTV
USE QLTV
CREATE TABLE SACH
(
	Masach CHAR(5) NOT NULL,
	Tensach NVARCHAR(50) NOT NULL,
	Namxb INT NOT NULL,
	Nhaxb NVARCHAR(30) NOT NULL
)
CREATE TABLE SINHVIEN
(
	Masv CHAR(10) NOT NULL,
	Hoten NVARCHAR(50) NOT NULL,
	Ngaysinh DATETIME NOT NULL,
	Gioitinh BIT NOT NULL,
	Diachi NVARCHAR(50) NOT NULL
)
CREATE TABLE MUONSACH
(
	Masach CHAR(5) NOT NULL,
	Masv CHAR(10) NOT NULL,
	Ngaymuon DATETIME NOT NULL,
	Ngaytra DATETIME NOT NULL,
)
drop table MUONSACH
CREATE TABLE NGUOIDUNG
(
	Tendangnhap NCHAR(10) CONSTRAINT PK_TENDN PRIMARY KEY(Tendangnhap),
	Matkhau NCHAR(10),
	Maquyen int
)

CREATE TABLE PHANQUYEN
(
	Maquyen int CONSTRAINT PK_MAQUYEN PRIMARY KEY(Maquyen),
	Tenquyen NVARCHAR(30)
)
--------------------------TẠO RÀNG BUỘC--------------------------
---------------------------KHÓA CHÍNH---------------------------
ALTER TABLE SACH ADD CONSTRAINT PK_SACH PRIMARY KEY (Masach)
ALTER TABLE SINHVIEN ADD CONSTRAINT PK_SV PRIMARY KEY(Masv)
ALTER TABLE MUONSACH ADD CONSTRAINT PK_MUONSACH PRIMARY KEY(Masach, Masv)

---------------------------KHÓA NGOẠI---------------------------
ALTER TABLE MUONSACH ADD CONSTRAINT FK_MUONSACH_SACH FOREIGN KEY(Masach) REFERENCES SACH(Masach)
ALTER TABLE MUONSACH ADD CONSTRAINT FK_MUONSACH_SV FOREIGN KEY(Masv) REFERENCES SINHVIEN(Masv)
ALTER TABLE NGUOIDUNG ADD CONSTRAINT FK_NGUOIDUNG FOREIGN KEY(Maquyen) REFERENCES PHANQUYEN(Maquyen)

--------------------------Nhập dữ liệu--------------------------
--Bảng sách
INSERT INTO SACH (Masach, Tensach, Namxb, Nhaxb) 
VALUES	('MS001', N'Tin học đại cương', 2013, N'Đại học Bách Khoa Hà Nội'),
		('MS002', N'Đại số tuyến tính', 2010, N'Đại học Sư phạm'),
		('MS003', N'Triết học', 2000, N'Học viện chính trị quốc gia'),
		('MS004', N'Quản lý nhân lực', 2000, N'Đại học Kinh tế quốc dân'),
		('MS005', N'Nhập môn tin học', 2008, N'Học viện bưu chính viễn thông'),
		('MS006', N'Xác suất thống kê', 2009, N'Đại học Quy Nhơn'),
		('MS007', N'Lập trình C#', 2013, N'Đại học Quy Nhơn')
select * from SACH
--Bảng Sinh Viên
INSERT INTO SINHVIEN (Masv, Hoten, Ngaysinh, Gioitinh, Diachi) 
VALUES	('SV001', N'Phạm Quỳnh Như', '12/12/2003', 1, N'64 An Dương Vương - Quy Nhơn - Bình Định'),
		('SV002', N'Trần Tiến Đạt', '02/11/2000', 0, N'Tuy Phước - Bình Định'),
		('SV003', N'Phan Trọng Nghĩa', '02/04/2002', 0, N'60 Ngô Mây - Quy Nhơn - Bình Định'),
		('SV004', N'Nguyễn Thị Nga', '06/05/2001', 1, N'Phù Cát - Bình Định'),
		('SV005', N'Nguyễn Thị Nụ', '04/05/2003', 1, N'128 Nguyễn Thị Định - Quy Nhơn - Bình Định'),
		('SV006', N'Trương Thị Ngân', '05/04/2002', 1, N'325 Trần Hưng Đạo - Quy Nhơn - Bình Định'),
		('SV007', N'Phan Huy Tùng', '11/02/2000', 0, N'60 Ngô Mây - Quy Nhơn - Bình Định')

select * from SINHVIEN
--Bảng Mượn sách
INSERT INTO MUONSACH (Masach, Masv, Ngaymuon, Ngaytra)
VALUES	('MS001', 'SV002', '2022/12/06', '2022/12/12'),
		('MS003', 'SV002', '2022/12/11', '2022/12/12'),
		('MS001', 'SV001', '2022/12/11', '2023/03/02'),
		('MS001', 'SV005', '2022/12/10', '2022/12/11'),
		('MS003', 'SV007', '2023/01/01', '2023/03/02'),
		('MS004', 'SV007', '2023/10/11', '2023/03/01'),
		('MS007', 'SV004', '2023/09/11', '2023/10/30'),
		('MS001', 'SV003', '2023/01/02', '2023/01/02'),
		('MS005', 'SV006', '2022/12/09 ', '2022/12/12')
select * from MUONSACH
--Bảng Người dùng
INSERT INTO NGUOIDUNG (Tendangnhap, Matkhau, Maquyen) 
VALUES	('hungqnu', '123', 1),
		('huongadmin', '312', 2),
		('xuanla', '456', 1),
		('phuonglth','123', 1)
select * from NguoiDung
INSERT INTO PHANQUYEN (Maquyen, Tenquyen)
VALUES	(1, N'User'),
		(2, N'Admin')

SELECT COUNT(*) FROM NGUOIDUNG WHERE Tendangnhap='huongadmin' AND Matkhau='312'


