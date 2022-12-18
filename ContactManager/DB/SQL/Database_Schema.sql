﻿USE [master]
GO
/****** Object:  Database [ContactManager]    Script Date: 2022-12-18 5:20:02 PM ******/
CREATE DATABASE [ContactManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ContactManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ContactManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ContactManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ContactManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ContactManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ContactManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ContactManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ContactManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ContactManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ContactManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ContactManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ContactManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ContactManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ContactManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ContactManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ContactManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ContactManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ContactManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ContactManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ContactManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ContactManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ContactManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ContactManager] SET RECOVERY FULL 
GO
ALTER DATABASE [ContactManager] SET  MULTI_USER 
GO
ALTER DATABASE [ContactManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ContactManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ContactManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ContactManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ContactManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ContactManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ContactManager', N'ON'
GO
ALTER DATABASE [ContactManager] SET QUERY_STORE = OFF
GO
USE [ContactManager]
GO
/****** Object:  User [visualstudio]    Script Date: 2022-12-18 5:20:02 PM ******/
CREATE USER [visualstudio] FOR LOGIN [visualstudio] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [visualstudio]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [visualstudio]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[Province] [varchar](30) NULL,
	[PostalCode] [varchar](10) NULL,
	[Country] [varchar](30) NULL,
	[ApartmentNumber] [int] NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [varchar](1) NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Title] [varchar](4) NULL,
	[Birthday] [date] NULL,
	[LastUpdated] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[Image_Id] [int] NULL,
	[Created] [datetime] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [varchar](1) NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilePicture] [varbinary](max) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[ContryCode] [varchar](4) NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Contact] [varchar](1) NOT NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-18 5:20:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Code] [varchar](1) NOT NULL,
	[Description] [varchar](90) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (1, N'rue dollar', N'longeuil', N'qc', N'h8y6yp', N'canada', 0, 3, N'P', CAST(N'2022-12-17T19:26:51.003' AS DateTime))
GO
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (3, N'931 rue ghameroff', N'lala land', N'quebec', N'h8t3r5', N'canada', 0, 5, N'P', CAST(N'2022-12-18T17:16:17.683' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (1, N'Tawfiq', N'Jawhar', NULL, NULL, CAST(N'2022-12-08T11:23:59.857' AS DateTime), 1, NULL, CAST(N'2022-11-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (2, N'Brendan', N'Wood', N'Mr', NULL, CAST(N'2022-12-07T14:56:49.640' AS DateTime), 1, NULL, CAST(N'2022-12-07T14:23:50.143' AS DateTime))
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (3, N'youssef', N'idiot', N'mr', CAST(N'2000-07-27' AS Date), CAST(N'2022-12-17T22:10:07.800' AS DateTime), 1, NULL, CAST(N'2022-12-17T19:26:50.980' AS DateTime))
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (4, N'test', N'test', N'', CAST(N'0001-01-01' AS Date), CAST(N'2022-12-17T22:10:29.713' AS DateTime), 1, NULL, CAST(N'2022-12-17T22:10:29.707' AS DateTime))
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (5, N'email test', N'test', N'', CAST(N'0001-01-01' AS Date), CAST(N'2022-12-17T23:06:06.930' AS DateTime), 1, NULL, CAST(N'2022-12-17T23:06:06.917' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Email] ON 
GO
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (4, N'testing@gmail.com', 5, N'P', CAST(N'2022-12-17T23:07:32.477' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Email] OFF
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (1, N'6166673', N'514', 4, N'P', CAST(N'2022-12-17T22:10:29.717' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (5, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:38.283' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (6, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:39.963' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (7, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:40.163' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (8, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:40.997' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (9, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:42.113' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (10, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:42.340' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (11, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:42.533' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (12, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:42.730' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (13, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:42.930' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (14, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:43.110' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (15, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:43.303' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (16, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:43.477' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (17, N'616667', N'514', 4, N'P', CAST(N'2022-12-17T23:03:43.657' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (18, N'61666735', N'514', 4, N'P', CAST(N'2022-12-17T23:03:49.240' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (19, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:52.977' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (20, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:53.570' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (21, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:53.777' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (22, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:53.967' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (23, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:55.483' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (24, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:55.660' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (25, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:55.847' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (26, N'6166674', N'514', 4, N'P', CAST(N'2022-12-17T23:03:56.017' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (27, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:03:59.730' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (28, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:00.233' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (29, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:00.453' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (30, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:00.653' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (31, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:00.813' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (32, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:01.047' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (33, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:01.227' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (34, N'6166674', N'518', 4, N'P', CAST(N'2022-12-17T23:04:01.390' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (35, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:10.817' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (36, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:11.360' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (37, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:11.727' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (38, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:12.030' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (39, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:12.250' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (40, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:12.447' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (41, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:12.643' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (42, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:12.843' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (43, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:13.023' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (44, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:13.193' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (45, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:13.353' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (46, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:13.517' AS DateTime))
GO
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (47, N'6166676', N'514', 4, N'P', CAST(N'2022-12-17T23:04:13.687' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Phone] OFF
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'B', N'Buisness specification code for buisness or work records.')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'O', N'Other specification code for other records.')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'P', N'Personal specification code for personal records.')
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_Created]  DEFAULT (getdate()) FOR [Created]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Contact]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Type]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_Image] FOREIGN KEY([Image_Id])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_Image]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Contact]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Type]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Contact]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Type] FOREIGN KEY([Type_Contact])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Type]
GO
USE [master]
GO
ALTER DATABASE [ContactManager] SET  READ_WRITE 
GO
