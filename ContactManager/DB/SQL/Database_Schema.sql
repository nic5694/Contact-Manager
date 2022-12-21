USE [ContactManager]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-20 9:37:47 PM ******/
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
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-20 9:37:47 PM ******/
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
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-20 9:37:47 PM ******/
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
/****** Object:  Table [dbo].[Image]    Script Date: 2022-12-20 9:37:47 PM ******/
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
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-20 9:37:47 PM ******/
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
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-20 9:37:47 PM ******/
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

INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (7, N'dollard', N'longueuil', N'Qc', N'j4k4p1', N'Canada', 2293, 5, N'P', CAST(N'2022-12-20T21:34:58.100' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (8, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 5, N'B', CAST(N'2022-12-20T21:34:58.100' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (9, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 5, N'O', CAST(N'2022-12-20T21:34:58.103' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (10, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 6, N'P', CAST(N'2022-12-20T21:35:31.930' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (11, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 6, N'B', CAST(N'2022-12-20T21:35:31.930' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (12, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 6, N'O', CAST(N'2022-12-20T21:35:31.930' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (13, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 7, N'P', CAST(N'2022-12-20T21:36:02.267' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (14, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 7, N'B', CAST(N'2022-12-20T21:36:02.267' AS DateTime))
INSERT [dbo].[Address] ([Id], [StreetAddress], [City], [Province], [PostalCode], [Country], [ApartmentNumber], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (15, N'N/A', N'N/A', N'N/A', N'N/A', N'N/A', 0, 7, N'O', CAST(N'2022-12-20T21:36:02.270' AS DateTime))
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (5, N'Youssef ', N'Chahboune', N'Mr', CAST(N'2022-07-27' AS Date), CAST(N'2022-12-20T21:34:58.090' AS DateTime), 1, NULL, CAST(N'2022-12-20T21:34:58.090' AS DateTime))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (6, N'Nicholas', N'Martottia', N'Mr', CAST(N'2022-12-09' AS Date), CAST(N'2022-12-20T21:35:31.920' AS DateTime), 1, NULL, CAST(N'2022-12-20T21:35:31.920' AS DateTime))
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [Title], [Birthday], [LastUpdated], [Active], [Image_Id], [Created]) VALUES (7, N'Contantine', N'', N'Mr', CAST(N'2022-01-17' AS Date), CAST(N'2022-12-20T21:36:02.257' AS DateTime), 1, NULL, CAST(N'2022-12-20T21:36:02.257' AS DateTime))
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Email] ON 

INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (4, N'chahbouney2000@outlook.fr', 5, N'P', CAST(N'2022-12-20T21:34:58.107' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (5, N'N/A', 5, N'B', CAST(N'2022-12-20T21:34:58.110' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (6, N'N/A', 5, N'O', CAST(N'2022-12-20T21:34:58.110' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (7, N'nic@test.com', 6, N'P', CAST(N'2022-12-20T21:35:31.933' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (8, N'N/A', 6, N'B', CAST(N'2022-12-20T21:35:31.940' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (9, N'N/A', 6, N'O', CAST(N'2022-12-20T21:35:31.940' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (10, N'N/A', 7, N'P', CAST(N'2022-12-20T21:36:02.270' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (11, N'N/A', 7, N'B', CAST(N'2022-12-20T21:36:02.270' AS DateTime))
INSERT [dbo].[Email] ([Id], [Email], [Contact_Id], [Type_Code], [LastUpdated]) VALUES (12, N'N/A', 7, N'O', CAST(N'2022-12-20T21:36:02.270' AS DateTime))
SET IDENTITY_INSERT [dbo].[Email] OFF
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 

INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (4, N'4506740774', N'1', 5, N'O', CAST(N'2022-12-20T21:34:58.110' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (5, N'N/A', N'N/A', 5, N'P', CAST(N'2022-12-20T21:34:58.113' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (6, N'N/A', N'N/A', 5, N'B', CAST(N'2022-12-20T21:34:58.113' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (7, N'N/A', N'N/A', 6, N'P', CAST(N'2022-12-20T21:35:31.943' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (8, N'N/A', N'N/A', 6, N'B', CAST(N'2022-12-20T21:35:31.943' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (9, N'N/A', N'N/A', 6, N'O', CAST(N'2022-12-20T21:35:31.943' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (10, N'4501234567', N'1', 7, N'B', CAST(N'2022-12-20T21:36:02.273' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (11, N'N/A', N'N/A', 7, N'P', CAST(N'2022-12-20T21:36:02.273' AS DateTime))
INSERT [dbo].[Phone] ([Id], [Number], [ContryCode], [Contact_Id], [Type_Contact], [LastUpdated]) VALUES (12, N'N/A', N'N/A', 7, N'O', CAST(N'2022-12-20T21:36:02.277' AS DateTime))
SET IDENTITY_INSERT [dbo].[Phone] OFF
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'B', N'Business')
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'O', N'Other')
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'P', N'Personal')
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

