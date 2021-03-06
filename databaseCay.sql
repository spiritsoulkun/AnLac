USE [DoAn]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 24/04/2021 10:04:53 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(100,1) NOT NULL,
	[AdminEmail] [varchar](50) NOT NULL,
	[AdminPassword] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customerCode] [int] IDENTITY(100,1) NOT NULL,
	[customerName] [nvarchar](50) NOT NULL,
	[customerEmail] [nvarchar](50) NOT NULL,
	[customerPassword] [nvarchar](50) NOT NULL,
	[customerPhone] [nvarchar](24) NOT NULL,
	[customerAddress] [nvarchar](60) NULL,
	[customerDateCreateOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[customerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderNumber] [int] NOT NULL,
	[productCode] [int] NOT NULL,
	[orderDetailsQuantity] [int] NULL,
	[orderDetailsPriceEach] [decimal](19, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[orderNumber] ASC,
	[productCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderNumber] [int] IDENTITY(100,1) NOT NULL,
	[orderStatus] [bit] NULL,
	[orderDate] [datetime] NULL,
	[orderShippedDate] [datetime] NULL,
	[customerCode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[productCode] [int] IDENTITY(100,1) NOT NULL,
	[productName] [nvarchar](50) NOT NULL,
	[productDescription] [nvarchar](max) NULL,
	[productQuantityInStock] [int] NOT NULL,
	[productBuyPrice] [decimal](19, 4) NULL,
	[productImage] [varchar](50) NULL,
	[productCreateOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[productCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staffs](
	[staffCode] [int] IDENTITY(100,1) NOT NULL,
	[staffEmail] [varchar](50) NOT NULL,
	[staffPassword] [varchar](50) NOT NULL,
	[staffPhone] [nvarchar](24) NOT NULL,
	[staffAddress] [nvarchar](60) NOT NULL,
	[staffCreateOn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[staffCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24/04/2021 10:04:54 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminID], [AdminEmail], [AdminPassword]) VALUES (100, N'admin', N'123')
INSERT [dbo].[Admin] ([AdminID], [AdminEmail], [AdminPassword]) VALUES (101, N'admin1', N'123')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([customerCode], [customerName], [customerEmail], [customerPassword], [customerPhone], [customerAddress], [customerDateCreateOn]) VALUES (100, N'admin12', N'admin@gmail.com', N'123', N'0773179766', NULL, CAST(N'2021-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([customerCode], [customerName], [customerEmail], [customerPassword], [customerPhone], [customerAddress], [customerDateCreateOn]) VALUES (101, N'admin1', N'123', N'123', N'123', NULL, CAST(N'2021-04-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (105, 109, 1, CAST(126.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (105, 114, 1, CAST(150.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (106, 109, 1, CAST(126.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (106, 114, 2, CAST(350.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (107, 109, 1, CAST(126.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (107, 114, 1, CAST(350.0000 AS Decimal(19, 4)))
INSERT [dbo].[OrderDetails] ([orderNumber], [productCode], [orderDetailsQuantity], [orderDetailsPriceEach]) VALUES (1101, 109, 5, CAST(126.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([orderNumber], [orderStatus], [orderDate], [orderShippedDate], [customerCode]) VALUES (105, 0, CAST(N'2021-04-18T13:49:17.373' AS DateTime), CAST(N'2021-04-19T13:49:01.000' AS DateTime), 101)
INSERT [dbo].[Orders] ([orderNumber], [orderStatus], [orderDate], [orderShippedDate], [customerCode]) VALUES (106, 0, CAST(N'2021-04-18T13:50:04.650' AS DateTime), CAST(N'2021-04-19T13:49:51.000' AS DateTime), 101)
INSERT [dbo].[Orders] ([orderNumber], [orderStatus], [orderDate], [orderShippedDate], [customerCode]) VALUES (107, 0, CAST(N'2021-04-18T14:22:07.900' AS DateTime), CAST(N'2021-04-19T14:22:05.000' AS DateTime), 101)
INSERT [dbo].[Orders] ([orderNumber], [orderStatus], [orderDate], [orderShippedDate], [customerCode]) VALUES (1101, 0, CAST(N'2021-04-19T08:12:58.040' AS DateTime), CAST(N'2021-04-20T08:12:49.000' AS DateTime), 101)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (109, N'Cây Cảnh 1', N'Cây Giống', 5, CAST(126.0000 AS Decimal(19, 4)), N'/img/img02.jpg', CAST(N'2021-04-18T12:53:34.977' AS DateTime))
INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (114, N'Cây Giống ', N'Cây Giống', 1, CAST(350.0000 AS Decimal(19, 4)), N'/img/img03.jpg', CAST(N'2021-04-18T13:48:01.097' AS DateTime))
INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (1107, N'Cây Cảnh 4', N'Cây Chiết Cành', 1, CAST(450.0000 AS Decimal(19, 4)), N'/img/img04.jpg', CAST(N'2021-04-19T07:12:45.990' AS DateTime))
INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (1108, N'Cây Cảnh 3', N'Cây Giống', 1, CAST(126.0000 AS Decimal(19, 4)), N'/img/img04.jpg', CAST(N'2021-04-19T07:12:56.763' AS DateTime))
INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (1110, N'Cây Cảnh 5', N'Cây Giống', 1, CAST(300.0000 AS Decimal(19, 4)), N'/img/img06.jpg', CAST(N'2021-04-19T07:13:17.227' AS DateTime))
INSERT [dbo].[Products] ([productCode], [productName], [productDescription], [productQuantityInStock], [productBuyPrice], [productImage], [productCreateOn]) VALUES (1111, N'Cây Giống 4', N'Cây Giống', 1, CAST(126.0000 AS Decimal(19, 4)), N'/img/img08.jpg', CAST(N'2021-04-19T08:11:11.247' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Admin__F2AA7AD99456E3AE]    Script Date: 24/04/2021 10:04:54 CH ******/
ALTER TABLE [dbo].[Admin] ADD UNIQUE NONCLUSTERED 
(
	[AdminEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_GetDate_customerDateCreateOn]  DEFAULT (getdate()) FOR [customerDateCreateOn]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_GetDate_orderDate]  DEFAULT (getdate()) FOR [orderDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DFGD_productCreateOn]  DEFAULT (getdate()) FOR [productCreateOn]
GO
ALTER TABLE [dbo].[Staffs] ADD  CONSTRAINT [DF_GetDate_staffCreateOn]  DEFAULT (getdate()) FOR [staffCreateOn]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderNumber] FOREIGN KEY([orderNumber])
REFERENCES [dbo].[Orders] ([orderNumber])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_orderNumber]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_productCode] FOREIGN KEY([productCode])
REFERENCES [dbo].[Products] ([productCode])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_productCode]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_customerCode] FOREIGN KEY([customerCode])
REFERENCES [dbo].[Customers] ([customerCode])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_customerCode]
GO
