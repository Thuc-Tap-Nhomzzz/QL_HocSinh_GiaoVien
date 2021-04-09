USE [master]
GO
--drop database QL_HocSinh_GiaoVien
CREATE DATABASE [QL_HocSinh_GiaoVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_HocSinh_GiaoVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_HocSinh_GiaoVien.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_HocSinh_GiaoVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QL_HocSinh_GiaoVien_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
USE [QL_HocSinh_GiaoVien]

GO
CREATE TABLE [dbo].[Bomon](
	[Ma] [varchar](20) PRIMARY KEY  NOT NULL,
	[Ten] [varchar](50),
	[Diadiem] [varchar](200),
 )
 GO
CREATE TABLE [dbo].[Monhoc](
	[Ma] [varchar](20) PRIMARY KEY NOT NULL,
	[Ten] [nvarchar](50),
	[Sotiet] [int],
	[Gioithieu] [text],
	[Hinhthucthi] [nvarchar](20)
)
GO
CREATE TABLE [dbo].[Giaovien](
	[Ma] [varchar](20) PRIMARY KEY NOT NULL,
	[Ten] [nvarchar](50),
	[Gioitinh] [bit],
	[Ngaysinh] [date],
	[Email] [nvarchar](50),
	[Sodienthoai] [nvarchar](30),
	[Luong] [int],
	[Nhiemvu] [nvarchar](30),
	[Bomonma] [varchar](20),
	FOREIGN KEY([Bomonma]) REFERENCES [dbo].[Bomon] ([Ma])
 )
GO
CREATE TABLE [dbo].[Lophocphan](
	[Ma] [varchar](20) PRIMARY KEY NOT NULL,
	[Ten] [nvarchar](50),
	[Hocki] [char](5),
	[NgayBD] [date],
	[NgayKT] [date],
	[Ngaythi] [date],
	[Siso] [int],
	[Thu] [varchar](10),
	[Tiet] [int],
	[Namhoc] [varchar](5),
	[Monma] [varchar](20),
	[Giaovienma] [varchar](20),
	FOREIGN KEY([Giaovienma]) REFERENCES [dbo].[Giaovien] ([Ma]),
	FOREIGN KEY([Monma]) REFERENCES [dbo].[Monhoc] ([Ma])
 )
 GO
CREATE TABLE [dbo].[Hocsinh](
	[Ma] [varchar](20) PRIMARY KEY NOT NULL,
	[Ten] [nvarchar](50),
	[Lopma] [varchar](20),
	[Ngaysinh] [date],
	[Gioitinh] [bit],
	[Dantoc] [nvarchar](30),
	[Diachi] [nvarchar](50),
	[Email] [nvarchar](30),
	[Sodienthoai] [nvarchar](30),
	FOREIGN KEY([Lopma]) REFERENCES [dbo].[Lophocphan] ([Ma])
 )
GO
CREATE TABLE [dbo].[Diem](
	[Diem1] [float],
	[Diem2] [float],
	[Diem3] [float],
	[Tongket] [float],
	[Lopma] [varchar](20),
	[Hocsinhma] [varchar](20),
	FOREIGN KEY([Hocsinhma]) REFERENCES [dbo].[Hocsinh] ([Ma]),
	FOREIGN KEY([Lopma]) REFERENCES [dbo].[Lophocphan] ([Ma])
)
GO

/* insert into Lophocphan(ma, ten, hocki, ngaybd, ngaykt, ngaythi, siso,thu, tiet, namhoc, monma, giaovienma) values
  ('Lop10I20202021', 'Lớp 10 Học kỳ I Năm 2020-2021','I','2020-10-1', '2020-11-30', '2020-12-01', 30, '2','30', '2020-2021', 'Mon001','GV001'),
  insert into [Giaovien]( [Ma],[Ten],[Gioitinh],[Ngaysinh],[Email],[Anh],[Luong],[Nhiemvu],[Vaitro],[Bomonma],[Trangthai]) values
  (GV001, N'Chu Thị Hường',0, '1980-01-01', 'chuthuhuong@gmail.com',N'Ảnh cô Chu Thị Hường' )
go
insert into HocSinh(Ma, Ten, LopMa, NgaySinh, DanToc,GioiTinh, DiaChi,Email, SoDienThoai, TrangThai ) values
('HS001', N'Trần Văn Dũng', 'Lop10I20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran8@gmail.com','0337108530', 1),
('HS002', N'Trần Văn A', 'Lop10I20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran8@gmail.com','0337108530', 1),
('HS001', N'Trần Văn B', 'Lop10II20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran8@gmail.com','0337108530', 1),
('HS003', N'Trần Văn C', 'Lop10II20202021', getdate(), 'Kinh', 1, N'Hà Nội', 'Dxtran2@gmail.com','0337108530', 1),
('HS004', N'Trần Văn D', 'Lop11I20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran3@gmail.com','0337108530', 1),
('HS005', N'Trần Văn E', 'Lop11I20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran5@gmail.com','0337108530', 1),
('HS006', N'Trần Văn F', 'Lop11II20202021', getdate(), 'Kinh', 1, N'Nam Định', 'Dxtran7@gmail.com','0337108530', 1)
*/
