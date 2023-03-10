USE [master]
GO
/****** Object:  Database [QuanLyVanBan]    Script Date: 12/13/2022 9:56:52 AM ******/
CREATE DATABASE [QuanLyVanBan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyVanBan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyVanBan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyVanBan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyVanBan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyVanBan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyVanBan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyVanBan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyVanBan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyVanBan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyVanBan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyVanBan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyVanBan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyVanBan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyVanBan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyVanBan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyVanBan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyVanBan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyVanBan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyVanBan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyVanBan', N'ON'
GO
ALTER DATABASE [QuanLyVanBan] SET QUERY_STORE = OFF
GO
USE [QuanLyVanBan]
GO
/****** Object:  Table [dbo].[CaNhan]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaNhan](
	[MaCaNhan] [int] IDENTITY(1,1) NOT NULL,
	[TenCaNhan] [nvarchar](50) NULL,
	[SDT] [int] NULL,
	[email] [varchar](50) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[MaDonVi] [varchar](15) NULL,
	[MaChucVu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCaNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietQuyen]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietQuyen](
	[MaChiTietQuyen] [int] NOT NULL,
	[ChucNang] [nvarchar](100) NOT NULL,
	[CheckQuyen_ChucNang] [bit] NULL,
	[MaNhomQuyen] [int] NULL,
	[MaQuyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [int] NOT NULL,
	[TenChucVu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChuyenVanBan]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenVanBan](
	[MaDonVi] [varchar](15) NOT NULL,
	[MaVanBanDen] [int] NOT NULL,
	[NoiNhan] [nvarchar](200) NULL,
	[SoPhat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC,
	[MaVanBanDen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoKhan]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoKhan](
	[MaDoKhan] [int] NOT NULL,
	[TenDoKhan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoKhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoMat]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoMat](
	[MaDoMat] [int] NOT NULL,
	[TenDoMat] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoMat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[MaDonVi] [varchar](15) NOT NULL,
	[TenDonVi] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSuThayDoi]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuThayDoi](
	[MaThayDoi] [int] NOT NULL,
	[SuKien] [varchar](256) NOT NULL,
	[TenDoiTuong] [varchar](256) NOT NULL,
	[LoaiDoiTuong] [varchar](256) NOT NULL,
	[CauLenhSQL] [varchar](max) NOT NULL,
	[ThoiGianThucHien] [datetime] NOT NULL,
	[MaCaNhan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThayDoi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinhVucVanBan]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhVucVanBan](
	[MaLinhVuc] [int] NOT NULL,
	[TenLinhVuc] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLinhVuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiVanBan]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiVanBan](
	[MaLoaiVanBan] [varchar](100) NOT NULL,
	[TenLoaiVanBan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiVanBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung_ChiTietQuyen]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung_ChiTietQuyen](
	[MaNguoiDung_ChiTietQuyen] [int] NOT NULL,
	[MaNhomQuyen] [int] NULL,
	[MaCaNhan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung_ChiTietQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomQuyen]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomQuyen](
	[MaNhomQuyen] [int] NOT NULL,
	[TenNhomQuyen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhomQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [int] NOT NULL,
	[TenQuyen] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VanBanDen]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VanBanDen](
	[MaVanBanDen] [int] IDENTITY(1,1) NOT NULL,
	[ThuTruongDuyet] [nvarchar](100) NULL,
	[SoVanBan] [varchar](11) NULL,
	[KyHieuVanBan] [varchar](30) NULL,
	[NgonNgu] [nvarchar](30) NULL,
	[NgayVanBan] [date] NULL,
	[HanGiaiQuyet] [date] NULL,
	[SoBan] [int] NULL,
	[SoTo] [int] NULL,
	[GhiChu] [nvarchar](500) NULL,
	[NgayDen] [date] NULL,
	[HoTenNguoiKy] [nvarchar](50) NULL,
	[ChucVuNguoiKy] [nvarchar](100) NULL,
	[SoHoSo] [varchar](20) NULL,
	[TinhTrang] [bit] NULL,
	[CoQuanBanHanh] [nvarchar](200) NULL,
	[TrichYeu] [nvarchar](500) NULL,
	[_file] [varchar](200) NULL,
	[TrangThaiXuLy] [int] NULL,
	[TrangThaiVanBan] [bit] NULL,
	[ThuHoi] [bit] NULL,
	[NgayTraBaoMat] [date] NULL,
	[MaDonVi] [varchar](15) NULL,
	[MaLinhVuc] [int] NULL,
	[MaLoaiVanBan] [varchar](100) NULL,
	[MaDoMat] [int] NULL,
	[MaDoKhan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVanBanDen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VanBanDi]    Script Date: 12/13/2022 9:56:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VanBanDi](
	[MaVanBanDi] [int] IDENTITY(1,1) NOT NULL,
	[SoVanBan] [varchar](11) NULL,
	[KyHieuVanBan] [varchar](30) NULL,
	[NgonNgu] [nvarchar](30) NULL,
	[NgayVanBan] [date] NULL,
	[SoBan] [int] NULL,
	[SoTo] [int] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[DonViNhan] [nvarchar](500) NULL,
	[HoTenNguoiKy] [nvarchar](50) NULL,
	[ChucVuNguoiKy] [nvarchar](50) NULL,
	[SoHoSo] [int] NULL,
	[TrangThai] [int] NOT NULL,
	[TrichYeu] [nvarchar](500) NULL,
	[_file] [varchar](200) NULL,
	[MaDonVi] [varchar](15) NULL,
	[MaLinhVuc] [int] NULL,
	[MaLoaiVanBan] [varchar](100) NULL,
	[MaDoMat] [int] NULL,
	[MaDoKhan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaVanBanDi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CaNhan] ON 

INSERT [dbo].[CaNhan] ([MaCaNhan], [TenCaNhan], [SDT], [email], [TenDangNhap], [MatKhau], [MaDonVi], [MaChucVu]) VALUES (3, N'Nguyễn Thảo Ngân', 92734871, N'ngan.nguyen.0168@gmail.com', N'thaongan', N'1', NULL, 1)
INSERT [dbo].[CaNhan] ([MaCaNhan], [TenCaNhan], [SDT], [email], [TenDangNhap], [MatKhau], [MaDonVi], [MaChucVu]) VALUES (4, N'Đỗ Quang Hạnh', 9273487, N'hanh2@gmail.com', N'quanghanh', N'1', N'155', 2)
INSERT [dbo].[CaNhan] ([MaCaNhan], [TenCaNhan], [SDT], [email], [TenDangNhap], [MatKhau], [MaDonVi], [MaChucVu]) VALUES (5, N'Trần Văn Tùng', 238942374, N'trantung@gmail.com', N'trantung', N'1', N'155', 3)
SET IDENTITY_INSERT [dbo].[CaNhan] OFF
GO
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (1, N'Xem danh sách văn bản ', 1, 1, 1)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (2, N'Phê duyệt văn bản ', 1, 1, 4)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (3, N'Xem danh sách văn bản', 1, 2, 1)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (4, N'Xóa văn bản', 1, 2, 3)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (5, N'Gửi văn bản', 1, 2, 2)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (6, N'Thu hồi văn bản', 1, 2, 6)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (7, N'Xem văn bản', 1, 3, 1)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (8, N'Thêm văn bản đi', 1, 3, 4)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (9, N'Xóa văn bản đi', 1, 3, 3)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (10, N'Sửa văn bản đi', 1, 3, 2)
INSERT [dbo].[ChiTietQuyen] ([MaChiTietQuyen], [ChucNang], [CheckQuyen_ChucNang], [MaNhomQuyen], [MaQuyen]) VALUES (11, N'Xem danh sách văn bản đi', 1, 3, 1)
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (1, N'Tiểu đoàn trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (2, N'Chính trị viên tiểu đoàn')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (3, N'Phó tiểu đoàn trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (4, N'Đại đội trưởng')
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu]) VALUES (5, N'Chính trị viên đại đội')
GO
INSERT [dbo].[ChuyenVanBan] ([MaDonVi], [MaVanBanDen], [NoiNhan], [SoPhat]) VALUES (N'd1', 1, N'c155 ', 1)
GO
INSERT [dbo].[DoKhan] ([MaDoKhan], [TenDoKhan]) VALUES (1, N'Mức 1')
INSERT [dbo].[DoKhan] ([MaDoKhan], [TenDoKhan]) VALUES (2, N'Mức 2')
INSERT [dbo].[DoKhan] ([MaDoKhan], [TenDoKhan]) VALUES (3, N'Mức 3')
INSERT [dbo].[DoKhan] ([MaDoKhan], [TenDoKhan]) VALUES (4, N'Mức 4')
INSERT [dbo].[DoKhan] ([MaDoKhan], [TenDoKhan]) VALUES (5, N'Mức 5')
GO
INSERT [dbo].[DoMat] ([MaDoMat], [TenDoMat]) VALUES (1, N'Mức 1')
INSERT [dbo].[DoMat] ([MaDoMat], [TenDoMat]) VALUES (2, N'Mức 2')
INSERT [dbo].[DoMat] ([MaDoMat], [TenDoMat]) VALUES (3, N'Mức 3')
INSERT [dbo].[DoMat] ([MaDoMat], [TenDoMat]) VALUES (4, N'Mức 4')
INSERT [dbo].[DoMat] ([MaDoMat], [TenDoMat]) VALUES (5, N'Mức 5')
GO
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'153', N'Đại đội 153')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'154', N'Đại đội 154')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'155', N'Đại đội 155')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'156', N'Đại đội 156')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'157', N'Đại đội 157')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'CT', N'Phòng Chính Trị')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'd1', N'Tiểu đoàn 1')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'KT', N'Phòng Kỹ Thuật')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'LKBK', N'Đại đội liên kết bách khoa')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'LKLN', N'Đại đội liên kết nước ngoài')
INSERT [dbo].[DonVi] ([MaDonVi], [TenDonVi]) VALUES (N'TC', N'Ban Tác Chiến')
GO
INSERT [dbo].[LinhVucVanBan] ([MaLinhVuc], [TenLinhVuc]) VALUES (1, N'Chính Trị')
INSERT [dbo].[LinhVucVanBan] ([MaLinhVuc], [TenLinhVuc]) VALUES (2, N'Quân sự')
INSERT [dbo].[LinhVucVanBan] ([MaLinhVuc], [TenLinhVuc]) VALUES (3, N'Hậu cần - Kĩ thuật')
GO
INSERT [dbo].[LoaiVanBan] ([MaLoaiVanBan], [TenLoaiVanBan]) VALUES (N'1', N'Công văn')
INSERT [dbo].[LoaiVanBan] ([MaLoaiVanBan], [TenLoaiVanBan]) VALUES (N'2', N'Văn kiện ')
GO
INSERT [dbo].[NguoiDung_ChiTietQuyen] ([MaNguoiDung_ChiTietQuyen], [MaNhomQuyen], [MaCaNhan]) VALUES (1, 1, 3)
INSERT [dbo].[NguoiDung_ChiTietQuyen] ([MaNguoiDung_ChiTietQuyen], [MaNhomQuyen], [MaCaNhan]) VALUES (2, 2, 4)
INSERT [dbo].[NguoiDung_ChiTietQuyen] ([MaNguoiDung_ChiTietQuyen], [MaNhomQuyen], [MaCaNhan]) VALUES (3, 3, 5)
GO
INSERT [dbo].[NhomQuyen] ([MaNhomQuyen], [TenNhomQuyen]) VALUES (1, N'Lãnh đạo')
INSERT [dbo].[NhomQuyen] ([MaNhomQuyen], [TenNhomQuyen]) VALUES (2, N'Văn thử')
INSERT [dbo].[NhomQuyen] ([MaNhomQuyen], [TenNhomQuyen]) VALUES (3, N'Đại đội')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (1, N'Xem')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (2, N'Sửa')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (3, N'Xóa')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (4, N'Thêm')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (5, N'Phê duyệt ')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen]) VALUES (6, N'Thu hồi')
GO
SET IDENTITY_INSERT [dbo].[VanBanDen] ON 

INSERT [dbo].[VanBanDen] ([MaVanBanDen], [ThuTruongDuyet], [SoVanBan], [KyHieuVanBan], [NgonNgu], [NgayVanBan], [HanGiaiQuyet], [SoBan], [SoTo], [GhiChu], [NgayDen], [HoTenNguoiKy], [ChucVuNguoiKy], [SoHoSo], [TinhTrang], [CoQuanBanHanh], [TrichYeu], [_file], [TrangThaiXuLy], [TrangThaiVanBan], [ThuHoi], [NgayTraBaoMat], [MaDonVi], [MaLinhVuc], [MaLoaiVanBan], [MaDoMat], [MaDoKhan]) VALUES (1, NULL, N' 123', NULL, N'Tiếng Anh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VanBanDen] ([MaVanBanDen], [ThuTruongDuyet], [SoVanBan], [KyHieuVanBan], [NgonNgu], [NgayVanBan], [HanGiaiQuyet], [SoBan], [SoTo], [GhiChu], [NgayDen], [HoTenNguoiKy], [ChucVuNguoiKy], [SoHoSo], [TinhTrang], [CoQuanBanHanh], [TrichYeu], [_file], [TrangThaiXuLy], [TrangThaiVanBan], [ThuHoi], [NgayTraBaoMat], [MaDonVi], [MaLinhVuc], [MaLoaiVanBan], [MaDoMat], [MaDoKhan]) VALUES (2, NULL, N' 334', NULL, N'Tiếng Anh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VanBanDen] OFF
GO
ALTER TABLE [dbo].[CaNhan]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[CaNhan]  WITH CHECK ADD FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[ChiTietQuyen]  WITH CHECK ADD FOREIGN KEY([MaNhomQuyen])
REFERENCES [dbo].[NhomQuyen] ([MaNhomQuyen])
GO
ALTER TABLE [dbo].[ChiTietQuyen]  WITH CHECK ADD FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[Quyen] ([MaQuyen])
GO
ALTER TABLE [dbo].[ChuyenVanBan]  WITH CHECK ADD FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[LichSuThayDoi]  WITH CHECK ADD FOREIGN KEY([MaCaNhan])
REFERENCES [dbo].[CaNhan] ([MaCaNhan])
GO
ALTER TABLE [dbo].[NguoiDung_ChiTietQuyen]  WITH CHECK ADD FOREIGN KEY([MaCaNhan])
REFERENCES [dbo].[CaNhan] ([MaCaNhan])
GO
ALTER TABLE [dbo].[NguoiDung_ChiTietQuyen]  WITH CHECK ADD FOREIGN KEY([MaNhomQuyen])
REFERENCES [dbo].[NhomQuyen] ([MaNhomQuyen])
GO
ALTER TABLE [dbo].[VanBanDen]  WITH CHECK ADD FOREIGN KEY([MaDoKhan])
REFERENCES [dbo].[DoKhan] ([MaDoKhan])
GO
ALTER TABLE [dbo].[VanBanDen]  WITH CHECK ADD FOREIGN KEY([MaDoMat])
REFERENCES [dbo].[DoMat] ([MaDoMat])
GO
ALTER TABLE [dbo].[VanBanDen]  WITH CHECK ADD FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[VanBanDen]  WITH CHECK ADD FOREIGN KEY([MaLinhVuc])
REFERENCES [dbo].[LinhVucVanBan] ([MaLinhVuc])
GO
ALTER TABLE [dbo].[VanBanDen]  WITH CHECK ADD FOREIGN KEY([MaLoaiVanBan])
REFERENCES [dbo].[LoaiVanBan] ([MaLoaiVanBan])
GO
ALTER TABLE [dbo].[VanBanDi]  WITH CHECK ADD FOREIGN KEY([MaDoKhan])
REFERENCES [dbo].[DoKhan] ([MaDoKhan])
GO
ALTER TABLE [dbo].[VanBanDi]  WITH CHECK ADD FOREIGN KEY([MaDoMat])
REFERENCES [dbo].[DoMat] ([MaDoMat])
GO
ALTER TABLE [dbo].[VanBanDi]  WITH CHECK ADD FOREIGN KEY([MaDonVi])
REFERENCES [dbo].[DonVi] ([MaDonVi])
GO
ALTER TABLE [dbo].[VanBanDi]  WITH CHECK ADD FOREIGN KEY([MaLinhVuc])
REFERENCES [dbo].[LinhVucVanBan] ([MaLinhVuc])
GO
ALTER TABLE [dbo].[VanBanDi]  WITH CHECK ADD FOREIGN KEY([MaLoaiVanBan])
REFERENCES [dbo].[LoaiVanBan] ([MaLoaiVanBan])
GO
USE [master]
GO
ALTER DATABASE [QuanLyVanBan] SET  READ_WRITE 
GO
