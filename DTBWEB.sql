USE [daweb4]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[IdBanner] [int] IDENTITY(1,1) NOT NULL,
	[Horizontal] [float] NOT NULL,
	[Vertical] [float] NOT NULL,
	[IDImages] [int] NOT NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED 
(
	[IdBanner] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCustomer] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](20) NOT NULL,
	[CustomerName] [nvarchar](35) NULL,
	[PhoneCustomer] [nchar](10) NULL,
	[CustomerAddress] [ntext] NULL,
	[CitizenIdentificationCode] [nchar](12) NULL,
	[DateOfBirth] [date] NULL,
	[Sex] [int] NULL,
	[IdImages] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[IDCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryNotes]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryNotes](
	[IdDeliveryNotes] [int] IDENTITY(1,1) NOT NULL,
	[IDInvoice] [int] NOT NULL,
	[DateCreated] [date] NOT NULL,
	[DeliveryAddress] [ntext] NOT NULL,
	[RecipientPhone] [nchar](10) NOT NULL,
	[Status] [int] NOT NULL,
	[IDStaff] [int] NULL,
 CONSTRAINT [PK_DeliveryNotes] PRIMARY KEY CLUSTERED 
(
	[IdDeliveryNotes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[IDfooter] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NOT NULL,
 CONSTRAINT [PK_Footer] PRIMARY KEY CLUSTERED 
(
	[IDfooter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[IDImages] [int] IDENTITY(1,1) NOT NULL,
	[NameImages] [nvarchar](50) NOT NULL,
	[UrlImages] [nchar](120) NULL,
 CONSTRAINT [PK_Produc1Images] PRIMARY KEY CLUSTERED 
(
	[IDImages] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imported Products]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imported Products](
	[IDImportedProducts] [int] IDENTITY(1,1) NOT NULL,
	[IDStaff] [int] NOT NULL,
	[IDWarehouse] [int] NOT NULL,
	[DateCreated] [date] NOT NULL,
 CONSTRAINT [PK_Imported Products Detail] PRIMARY KEY CLUSTERED 
(
	[IDImportedProducts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportedProductsDetail]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportedProductsDetail](
	[IDImportedProducts] [int] NOT NULL,
	[IDProduct] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[InputPrice] [float] NOT NULL,
 CONSTRAINT [PK_ImportedProductsDetail] PRIMARY KEY CLUSTERED 
(
	[IDImportedProducts] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[IDInvoice] [int] IDENTITY(1,1) NOT NULL,
	[IDCustomer] [int] NOT NULL,
	[IDStaff] [int] NULL,
	[DateCreated] [date] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[IDInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoicedetails]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoicedetails](
	[IDInvoice] [int] NOT NULL,
	[IDProduct] [int] NOT NULL,
	[TotalQuantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Invoicedetails] PRIMARY KEY CLUSTERED 
(
	[IDInvoice] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[IDProduct] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductDescription] [ntext] NULL,
	[IDProductType] [int] NOT NULL,
	[IDSupplier] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Sale] [float] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImagesDetails]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImagesDetails](
	[IDImages] [int] NOT NULL,
	[IDProduct] [int] NOT NULL,
	[ngaycapnhat] [date] NULL,
 CONSTRAINT [PK_ProductImagesDetails] PRIMARY KEY CLUSTERED 
(
	[IDImages] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[IDProductType] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[IDProductType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shopping cart]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shopping cart](
	[IDshoppingCart] [int] IDENTITY(1,1) NOT NULL,
	[IDCustomer] [int] NOT NULL,
 CONSTRAINT [PK_Shopping cart] PRIMARY KEY CLUSTERED 
(
	[IDshoppingCart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shoppingCartDeltails]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shoppingCartDeltails](
	[IDshoppingCart] [int] NOT NULL,
	[IDProduct] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_IDshoppingCartDeltails] PRIMARY KEY CLUSTERED 
(
	[IDshoppingCart] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[IdSkill] [int] IDENTITY(1,1) NOT NULL,
	[NameSkill] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Skill] PRIMARY KEY CLUSTERED 
(
	[IdSkill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillDetails]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillDetails](
	[IdSkill] [int] NOT NULL,
	[IDStaff] [int] NOT NULL,
	[updateDay] [datetime] NOT NULL,
 CONSTRAINT [PK_SkillDetails] PRIMARY KEY CLUSTERED 
(
	[IdSkill] ASC,
	[IDStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[IDStaff] [int] IDENTITY(1,1) NOT NULL,
	[StaffName] [nvarchar](35) NOT NULL,
	[Username] [nchar](20) NOT NULL,
	[StaffAddress] [ntext] NOT NULL,
	[PhoneStaff] [nchar](10) NOT NULL,
	[CitizenIdentificationCode] [nchar](12) NOT NULL,
	[IDStaffType] [int] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Sex] [int] NOT NULL,
	[IdImages] [int] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[IDStaff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffType]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StaffType](
	[IDStaffType] [int] IDENTITY(1,1) NOT NULL,
	[StaffTypeName] [nvarchar](35) NOT NULL,
 CONSTRAINT [PK_StaffType] PRIMARY KEY CLUSTERED 
(
	[IDStaffType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[IDSupplier] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](35) NOT NULL,
	[PhoneSupplier] [nchar](12) NOT NULL,
	[SupplierAddress] [nvarchar](max) NOT NULL,
	[EmailSupplier] [nchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[IDSupplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Username] [nchar](20) NOT NULL,
	[Email] [nchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Check] [int] NOT NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[IDWarehouse] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseName] [nvarchar](50) NOT NULL,
	[WarehouseAddress] [ntext] NOT NULL,
	[DateCreated] [date] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[IDWarehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehousedetails]    Script Date: 4/25/2024 10:36:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehousedetails](
	[IDWarehouse] [int] NOT NULL,
	[IDProduct] [int] NOT NULL,
	[QuantityInStock] [int] NOT NULL,
 CONSTRAINT [PK_Warehousedetails] PRIMARY KEY CLUSTERED 
(
	[IDWarehouse] ASC,
	[IDProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

INSERT [dbo].[Banner] ([IdBanner], [Horizontal], [Vertical], [IDImages]) VALUES (2, 941, 901, 23)
INSERT [dbo].[Banner] ([IdBanner], [Horizontal], [Vertical], [IDImages]) VALUES (3, 1734, 740, 22)
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (8, N'huy                 ', N'Nguyễn Văn Huy', N'0924872656', N'HCM', N'090909090909', CAST(N'1990-02-05' AS Date), 1, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (10, N'huy2                ', N'Phạm Đoạt ', N'0902000853', N'HCM', N'080808080808', CAST(N'1996-05-03' AS Date), 1, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (11, N'huy3                ', N'Nguyễn Khanh', N'0945888373', N'HCM', N'070707070707', CAST(N'1997-07-04' AS Date), 1, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (12, N'songa               ', NULL, NULL, NULL, NULL, CAST(N'0001-01-01' AS Date), 0, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (13, N'khanhngu            ', N'hồ chí khanhss', N'0932606822', N'tphcm', N'08275927212 ', CAST(N'2002-10-05' AS Date), 1, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (14, N'khanhga             ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (15, N'nguyentuanhuy       ', N'Nguyễn Tuấn Huy', N'0344403943', N'nhơn trạch đồng nai', N'123         ', CAST(N'2003-01-04' AS Date), 1, NULL)
INSERT [dbo].[Customer] ([IDCustomer], [Username], [CustomerName], [PhoneCustomer], [CustomerAddress], [CitizenIdentificationCode], [DateOfBirth], [Sex], [IdImages]) VALUES (16, N'nguyentuanhuy1      ', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryNotes] ON 

INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (2, 4, CAST(N'2024-07-05' AS Date), N'HCM', N'0909000999', 2, 10)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (4, 24, CAST(N'2024-04-24' AS Date), N'asdasdxz', N'9387363311', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (5, 25, CAST(N'2024-04-24' AS Date), N'quan 9 duong 920', N'0987214547', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (6, 26, CAST(N'2024-04-24' AS Date), N'jggkj', N'0987214547', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (7, 27, CAST(N'2024-04-24' AS Date), N'kkkk', N'9387363311', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (8, 28, CAST(N'2024-04-24' AS Date), N'xzcxzczxcxz', N'0937026887', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (9, 30, CAST(N'2024-04-25' AS Date), N'aaaa', N'0344403943', 1, NULL)
INSERT [dbo].[DeliveryNotes] ([IdDeliveryNotes], [IDInvoice], [DateCreated], [DeliveryAddress], [RecipientPhone], [Status], [IDStaff]) VALUES (10, 31, CAST(N'2024-04-25' AS Date), N'fdfsd', N'0344403943', 2, 11)
SET IDENTITY_INSERT [dbo].[DeliveryNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (1, N'customer1', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (2, N'customer2', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (3, N'customer3', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (4, N'customer4', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (5, N'customer5', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (6, N'customer5', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (7, N'customer6', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (8, N'Product AirPods Pro 2-0', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (11, N'Product AirPods Pro 2-1', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (12, N'Product AirPods Pro 2-2', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (13, N'Product Sony WF-1000XM4-0', N'/img/1dc275ee-4db1-4371-be4f-ce0c5747df0a.jpg                                                                           ')
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (14, N'Product Sony WF-1000XM4-1', N'/img/63ef0b00-3241-4684-b950-3299a5251e6f.jpg                                                                           ')
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (15, N'Product Sony WF-1000XM4-2', N'/img/33dddc0b-93c2-4699-8a5c-19bfc451082b.jpg                                                                           ')
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (16, N'Product Samsung Galaxy Buds Pro-0', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (17, N'Product Samsung Galaxy Buds Pro-1', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (18, N'Product Samsung Galaxy Buds Pro-2', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (19, N'Product BEATS STUDIO PRO-0', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (20, N'Product BEATS STUDIO PRO-1', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (21, N'Product BEATS STUDIO PRO-3', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (22, N'Banner-1', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (23, N'Banner-2', NULL)
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (24, N'chữ tiếng việt 3.jpg', N'/img/feae10fd-48d6-4f7d-9207-a2d84f97926b.jpg                                                                           ')
INSERT [dbo].[Images] ([IDImages], [NameImages], [UrlImages]) VALUES (25, N'a5.jpg', N'/img/9a919cf4-421f-4a60-9d3e-4204eca0d1bd.jpg                                                                           ')
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Imported Products] ON 

INSERT [dbo].[Imported Products] ([IDImportedProducts], [IDStaff], [IDWarehouse], [DateCreated]) VALUES (2, 7, 2, CAST(N'2022-07-07' AS Date))
INSERT [dbo].[Imported Products] ([IDImportedProducts], [IDStaff], [IDWarehouse], [DateCreated]) VALUES (3, 7, 2, CAST(N'2023-03-03' AS Date))
INSERT [dbo].[Imported Products] ([IDImportedProducts], [IDStaff], [IDWarehouse], [DateCreated]) VALUES (4, 7, 2, CAST(N'2023-09-09' AS Date))
SET IDENTITY_INSERT [dbo].[Imported Products] OFF
GO
INSERT [dbo].[ImportedProductsDetail] ([IDImportedProducts], [IDProduct], [Quantity], [InputPrice]) VALUES (2, 2, 100, 70)
INSERT [dbo].[ImportedProductsDetail] ([IDImportedProducts], [IDProduct], [Quantity], [InputPrice]) VALUES (2, 3, 70, 100)
INSERT [dbo].[ImportedProductsDetail] ([IDImportedProducts], [IDProduct], [Quantity], [InputPrice]) VALUES (3, 4, 100, 125)
INSERT [dbo].[ImportedProductsDetail] ([IDImportedProducts], [IDProduct], [Quantity], [InputPrice]) VALUES (4, 4, 70, 110)
INSERT [dbo].[ImportedProductsDetail] ([IDImportedProducts], [IDProduct], [Quantity], [InputPrice]) VALUES (4, 5, 120, 170)
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (4, 8, 9, CAST(N'2024-07-04' AS Date), 2)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (6, 14, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (10, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (24, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (25, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (26, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (27, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (28, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (29, 13, NULL, CAST(N'2024-04-24' AS Date), 1)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (30, 15, NULL, CAST(N'2024-04-25' AS Date), 3)
INSERT [dbo].[Invoice] ([IDInvoice], [IDCustomer], [IDStaff], [DateCreated], [Status]) VALUES (31, 15, 7, CAST(N'2024-04-25' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (4, 2, 10, CAST(160 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (4, 3, 15, CAST(180 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (6, 2, 1, CAST(180000 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (26, 2, 2, CAST(180000 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (27, 3, 1, CAST(132222 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (28, 2, 1, CAST(180000 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (30, 2, 2, CAST(180000 AS Decimal(18, 0)))
INSERT [dbo].[Invoicedetails] ([IDInvoice], [IDProduct], [TotalQuantity], [Price]) VALUES (31, 3, 2, CAST(132222 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (2, N'AirPods Pro 2', N'Chủ Động Khử Tiếng Ồn lên đến 2 lần. Tính năng Chủ Động Khử Tiếng Ồn lên đến 2 lần. 
Âm Thanh Thích Ứng hoàn toàn mới điều chỉnh việc kiểm soát tiếng ồn theo môi trường của bạn một cách thông minh.
Chế độ Âm Thanh Không Gian nâng tầm trải nghiệm âm thanh sống động. Và một lần sạc mang lại thời lượng pin lên đến 6 giờ. --Hiệu năng âm thanh
H2.
Thêm đắm chìm
trong thế giới
âm thanh.
Chip H2 do Apple thiết kế là sức mạnh đằng sau AirPods Pro và hiệu năng âm thanh tiên tiến của sản phẩm này. 
Chip hoạt động đồng thời với bộ khuếch đại và trình điều khiển tùy chỉnh giúp mang đến những nốt cao rõ ràng,
trong trẻo và âm trầm sâu lắng, đầy đặn đến bất ngờ. Vì thế mọi âm thanh đều ấn tượng hơn bao giờ hết.--
Chip H2 thực hiện được nhiều chức năng hơn bao giờ hết, bằng cách sử dụng các thuật toán để đồng thời mang đến khả năng khử tiếng ồn thông minh hơn
, âm thanh ba chiều cao cấp cùng thời lượng pin hiệu suất cao hơn.', 5, 1, CAST(180000 AS Decimal(18, 0)), 10, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (3, N'Sony WF-1000XM4', N'Công nghệ chống ồn tiên tiến – nay còn xuất sắc hơn
Mọi chi tiết trong tai nghe WF-1000XM4 đều được thiết kế mới hoàn toàn. Chẳng hạn như Bộ xử lý tích hợp V1 mới được Sony phát 
triển riêng với khả năng chống ồn tốt hơn bao giờ hết, củ loa mới với hiệu suất cao hơn, micro cảm biến tiếng ồn và Miếng đệm tai
chống ồn cải tiến cho cảm giác vừa vặn hơn.', 5, 2, CAST(132222 AS Decimal(18, 0)), 3.5, 0)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (4, N'Samsung Galaxy Buds Pro', N'Nâng tầm trải nghiệm âm với Chống Ồn Chủ Động
Chuẩn âm thanh studio với loa 2 chiều AKG mạnh mẽ
Âm thanh vòm, chuẩn chất điện ảnh từ 360 Audio*
Đàm thoại rõ ràng với hệ thống 3 mic cải tiến mới -- Tính năng Chống Ồn Chủ Động (Active Noise Canceling) trên Galaxy Buds Pro lọc 
ấn tượng đến 99% tiếng ồn xung quanh. Mic bên trong và mic bên ngoài của tai nghe có khả năng kiểm soát hiệu quả tiếng ồn trong thời 
gian thực. Bằng một thuật toán thông minh giúp loại bỏ tiếng ồn, bạn có thể chọn các mức ANC để tăng hoặc giảm âm thanh phù hợp theo
từng không gian như sau: chuyển lên mức Cao với những không gian ồn hoặc chuyển xuống mức Thấp khi đang ở trong những không gian yên 
tĩnh như thư viện - tất cả đều diễn ra nhanh chóng, không cần phải thay đổi âm lượng. ', 5, 3, CAST(192000 AS Decimal(18, 0)), 30, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (5, N'BEATS STUDIO PRO', N' Bảo Hành 03 Tháng
 Trang bị công nghệ Chống ồn chủ động thích ứng Adaptive Active Noise Cancelling và Xuyên âm Transparency được nâng cấp đáng kể.
 Bluetooth 5.3 tiên tiến giúp kết nối mạnh và ổn định, có trang bị dây AUX 3.5mm đi kèm.
Thời lượng pin lên tới 24 giờ có bật chống ồn ANC, hỗ trợ sạc nhanh 10 phút mang lại 4 giờ hoạt động tiện lợi -- Thiết kế 
của tai nghe Beats Studio Pro (LIKE NEW) không có quá nhiều thay đổi so với thế hệ tiền nhiệm. Vẫn mang trên mình ngôn ngữ 
thiết kế đã quá huyền thoại của Beats, tuy nhiên độ bền bỉ của mẫu tai nghe này được nâng cấp hơn hẳn so với thế hệ trước
nhờ sử dụng loạt vật liệu tốt hơn, giúp tai nghe chống lại xoắn gấp và va đập tốt hơn.', 7, 5, CAST(223000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (16, N'BEATS STUDIO 252', N'Với thời lượng pin lên tới 40 giờ⁸, tai nghe Beats Studio Pro giúp bạn tận hưởng âm nhạc lâu hơn. Tận hưởng thời gian nghe lên tới 24 giờ khi bật chế độ ANC', 7, 5, CAST(200000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (17, N' AirPods 3', N'Tai nghe Airpods 3 2022 sở hữu thiết kế nhỏ gọn cùng ngoại hình khá mới lạ do nút tai đã được lược bỏ. Sự tối giản trong thiết kế này mang tới cho người dùng cảm giác gọn gàng và vô cùng thoải mái. Từ đó giúp bạn sử dụng được lâu hơn cũng như phù hợp hơn với những ai đổ nhiều mồ hôi.', 5, 1, CAST(150000 AS Decimal(18, 0)), 50, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (19, N'BEATS SOLO PRO', N'Tai nghe Beats Solo Pro (Nobox) mang tới cho người dùng một mức giá cực kì dễ chịu, dễ dàng tiếp cận đến với sản phẩm hơn rất nhiều, Tai nghe Beats Solo Pro (Nobox) là dòng sản phẩm không có hộp, chỉ gồm tai nghe và dây sạc tặng kèm, hình thức Like-new ( có thể thay đổi theo từng sản phẩm khác nhau ) ', 7, 5, CAST(230000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (20, N'BEATS STUDIO 3 WIRELESS', N'Tai nghe Studio 3 mới nhất kế thừa thiết kế của Beats studio wireless huyền thoại sử dụng chip bluetooth Apple W1 mới nhất', 3, 5, CAST(200000 AS Decimal(18, 0)), 10, 0)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (21, N'Gaming JBL Quantum One ', N'JBL QUANTUM ONE khoác lên mình một ngoại hình đậm chất gaming không thể lẫn vào đâu được. Hệ thống dải đèn RGB 3 vùng phát sáng thực sự thể hiện nét cá tính khác biệt mà không hề ‘làm màu’ chút nào. Chiếc tai nghe cũng được chế tác với từng đường nét cao cấp nhất của một sản phẩm flagship với những đường gân, rãnh đầy mạnh mẽ. Không chỉ vậy, cảm giác đeo vẫn là điểm được JBL chăm chút nhất cho dòng sản phẩm gaming và JBL QUANTUM ONE cũng được kế thừa phong cách thiết kế cộng thái học game thủ đỉnh cao.', 2, 4, CAST(400000 AS Decimal(18, 0)), 20, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (22, N'JBL T115BT', N'Tai nghe JBL T115BT sẽ là lựa chọn hết sức tuyệt vời với các bạn yêu thích các dòng tai nghe JBL có dây đeo cổ. Với dung lượng pin lên đến 8 tiếng, khả năng sạc nhanh trong 2h, công nghệ âm thanh độc quyền JBL Pure Bass Sound, driver 8.6mm dynamic cho âm thanh sống động.', 5, 4, CAST(150000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (23, N' Samsung Galaxy Buds 2 Pro R510N', N'Galaxy Buds 2 Pro được hãng ưu ái trang bị âm thanh chất lượng cao 24 bit cho ra những âm sắc chân thật, rõ ràng và sống động như khi nghe trực tiếp. Mọi nốt nhạc đều được thể hiện một cách hoàn hảo và trọn vẹn nhất, cho bạn những nguồn cảm hứng bất tận thông qua những giai điệu tuyệt vời.', 3, 3, CAST(500000 AS Decimal(18, 0)), 2, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1006, N'Sony WH-CH520', N'Tai nghe chụp tai Sony WH-CH520 sở hữu âm thanh kỹ thuật số DSEE giúp mang lại âm thanh chân thực cùng với đó là pin cho thời gian sử dụng tới 40 giờ. Bên cạnh đó, sản phẩm tai nghe Sony này sở hữu thiết kế khá gọn nhẹ cùng với thiết kế tích hợp micro vô cùng tiện lợi.', 3, 2, CAST(200000 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1007, N' Apple EarPods Lightning', N'Tai nghe Earpods với Lightning Connection được thiết kế với màu trắng trang nhã cho bạn thể hiện phong cách trẻ trung, năng động, sành điệu tạo cảm giác thời thượng cho chính người sử dụng. Hai đầu tai được thiết kế giống như hai hạt đậu, ôm gọn trong tai giúp tai nghe Apple cách âm tốt nhất cho bạn tận hưởng trọn vẹn từng khoảnh khắc âm nhạc.

Thiết kế hai đầu tai hình hạt đậu ôm trọn trong tai hiện đại

Khi sản phẩm điện thoại iphone 7/7 Plus ra mắt Apple đã loại bỏ jack tai nghe 3.5mm và dùng chính cổng lightningđể kết nối với tai nghe. Sản phẩm tai nghe có dây này được trang bị với khả năng chống nước và chống mồ hôi hiệu quả cho bạn sử dụng thoải mái nhất không tạo cảm giác khó chịu. Dây tai nghe được thiết kế dài 120 cm vừa vặn cho bạn thoải mái để điện thoại vào túi quần và đeo tai nghe tiện lợi, gọn nhẹ.

Trang bị phím remote và microphone tiện dụng trên tai nghe lightning Apple
Apple Earpods với thiết kế thông minh với phím remote tiện dụng cùng trang bị microphone khi bạn xem phim, nghe nhạc thì bạn có thể dễ dàng điều chỉnh âm lượng theo ý mình tùy thích mà không cần phải điều chỉnh trên chiếc điện thoại.

Trang bị phím remote và microphone tiện dụng 

Bên cạnh đó, trang bị cổng lightning chính hãng Apple hỗ trợ việc bạn có thể trả lời hoặc kết thúc cuộc gọi trực tiếp ngay khi bạn đang cắm tai nghe với điện thoại trên chiếc iPhone của mình cho bạn sử dụng được ở chế độ rảnh tay một cách thuận tiện.

Chất lượng âm thanh sống động với phần bass ấn tượng trên lighining Apple Earpods
Tai nghe lightning sử dụng đến hai màng loa độc đáo ở hai bên đầu tai nghe cho chất lượng âm thanh sống động, trung thực và cực kì ấn tượng. Khả năng cách âm hiệu quả không bị nhiễu trong quá trình bạn sử dụng cho chất lượng âm thanh tốt nhất.

Earpods sử dụng đến hai màng loa độc đáo ở hai bên đầu tai nghe

Loa bên trong được thiết kế cho âm bass cực tốt, giảm thiểu thoát âm và tối đa hóa âm thanh phát ra giúp chất lượng âm thanh phản hồi tốt hơn giúp cho bạn hòa mình vào âm nhạc để tận hưởng trọn vẹn âm thanh với những giai điệu âm nhạc sâu sắc.

Loa bên trong được thiết kế cho âm bass cực tốt, giảm thiểu thoát âm và tối đa hóa âm thanh phát ra

Mua tai nghe Lightning Apple Earpods MMTN2 chính hãng, giá tốt tại CellphoneS
CellphoneS nơi được nhiều khách hàng tin tưởng lựa chọn với các sản phẩm chính hãng, chi phí, hợp lý và hơn hết với đội ngũ nhân viên tận tâm sẽ khiến bạn hoàn toàn hài lòng khi trải nghiệm tại cửa hàng. Đến CellphoneS để sở hữu ngay một chiếc tai nghe Apple Earpods Lightning MMTN2 để tận hưởng âm nhạc trọn vẹn. Bạn sẽ nhận được nhiều ưu đãi khi mua sản phẩm cam kết bảo hành chính hãng 12 tháng tại Cares.vn - trung tâm bảo hành ủy quyền của Apple tại Việt Nam và được hỗ trợ trả góp 0% với thẻ tín dụng tại cửa hàng.

Với các bạn ở xa muốn mua sản phẩm có thể liên hệ qua hotline 1800.2097 để đặt hàng và có bất kỳ thắc mắc cần được tư vấn giải đáp, chúng tôi luôn sẵn sàng giúp đỡ bạn về thông tin tai nghe lightning Apple Earpods chính hãng!

', 5, 1, CAST(120000 AS Decimal(18, 0)), 3, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1008, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1015, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1016, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1017, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1018, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1019, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1020, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1021, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1022, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1023, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1024, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1025, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1026, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1027, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1028, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1029, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1030, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1031, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1032, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1033, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1034, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1035, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1036, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1037, N'BEATS STUDIO BUDS', N'Tai nghe Beats Studio Buds sử dụng chip tùy biến riêng thế hệ mới cho Beats phát triển để tập chung phát triển về mặt âm thanh cho nên một số tính năng như "Tự động chuyển đổi giữa các thiết bị kết nối, Cảm biến tiện cận tự động dừng/phát nhạc, Sạc không dây" Đã Bị Loại Bỏ.', 1, 5, CAST(350000 AS Decimal(18, 0)), 5, 1)
INSERT [dbo].[Product] ([IDProduct], [ProductName], [ProductDescription], [IDProductType], [IDSupplier], [Price], [Sale], [Status]) VALUES (1041, N'fdsafd', N'1', 1, 1, CAST(333 AS Decimal(18, 0)), 3, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (8, 2, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (11, 2, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (12, 2, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (13, 3, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (14, 3, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (15, 3, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (16, 4, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (17, 4, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (18, 4, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (19, 5, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (20, 5, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (21, 5, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (24, 3, NULL)
INSERT [dbo].[ProductImagesDetails] ([IDImages], [IDProduct], [ngaycapnhat]) VALUES (25, 1041, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (1, N'Tai nghe True Wireless')
INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (2, N'Tai nghe Gaming')
INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (3, N'Tai nghe Bluetooth')
INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (5, N'Tai nghe In-Ear')
INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (6, N'Tai nghe On-Ear')
INSERT [dbo].[ProductType] ([IDProductType], [ProductTypeName]) VALUES (7, N'Tai nghe Over-Ear')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Shopping cart] ON 

INSERT [dbo].[Shopping cart] ([IDshoppingCart], [IDCustomer]) VALUES (1, 13)
SET IDENTITY_INSERT [dbo].[Shopping cart] OFF
GO
INSERT [dbo].[shoppingCartDeltails] ([IDshoppingCart], [IDProduct], [Quantity]) VALUES (1, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Skill] ON 

INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (1, N'Kỹ năng quản lí nhân viên')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (2, N'Kỹ năng bán hàng')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (3, N'Kỹ năng quản lí đơn hàng giao hàng')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (4, N'Kỹ năng quản lí sản phẩm')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (5, N'Kỹ năng quản lí kho')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (7, N'Kỹ năng quản lí loại sản phẩm')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (8, N'Kỹ năng quản lí khách hàng')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (9, N'kỹ năng quản lí và tạo phiếu giao hàng')
INSERT [dbo].[Skill] ([IdSkill], [NameSkill]) VALUES (10, N'Kỹ năng Quản lí hóa đơn của khách hàng')
SET IDENTITY_INSERT [dbo].[Skill] OFF
GO
INSERT [dbo].[SkillDetails] ([IdSkill], [IDStaff], [updateDay]) VALUES (3, 10, CAST(N'2024-02-02T00:00:00.000' AS DateTime))
INSERT [dbo].[SkillDetails] ([IdSkill], [IDStaff], [updateDay]) VALUES (8, 9, CAST(N'2024-02-02T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([IDStaff], [StaffName], [Username], [StaffAddress], [PhoneStaff], [CitizenIdentificationCode], [IDStaffType], [DateOfBirth], [Sex], [IdImages]) VALUES (7, N'Admin', N'Adminlor            ', N'HCM', N'0858676767', N'219449498497', 1, CAST(N'1992-05-02' AS Date), 1, NULL)
INSERT [dbo].[Staff] ([IDStaff], [StaffName], [Username], [StaffAddress], [PhoneStaff], [CitizenIdentificationCode], [IDStaffType], [DateOfBirth], [Sex], [IdImages]) VALUES (9, N'Huy', N'User_NV1            ', N'HN', N'0995248653', N'766168163267', 3, CAST(N'1990-03-07' AS Date), 1, NULL)
INSERT [dbo].[Staff] ([IDStaff], [StaffName], [Username], [StaffAddress], [PhoneStaff], [CitizenIdentificationCode], [IDStaffType], [DateOfBirth], [Sex], [IdImages]) VALUES (10, N'Ân', N'User_NV2            ', N'HCM', N'0923418654', N'43832453786 ', 6, CAST(N'1997-06-08' AS Date), 1, NULL)
INSERT [dbo].[Staff] ([IDStaff], [StaffName], [Username], [StaffAddress], [PhoneStaff], [CitizenIdentificationCode], [IDStaffType], [DateOfBirth], [Sex], [IdImages]) VALUES (11, N'Ngao', N'User_NV3            ', N'HCM', N'0942642482', N'26784773652 ', 4, CAST(N'1999-09-05' AS Date), 1, NULL)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[StaffType] ON 

INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (1, N'Admin')
INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (2, N'Nhân viên quản lí')
INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (3, N'Nhân viên bán hàng')
INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (4, N'Nhân viên giao hàng')
INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (5, N'Nhân viên kế toán')
INSERT [dbo].[StaffType] ([IDStaffType], [StaffTypeName]) VALUES (6, N'Nhân viên quản lý kho')
SET IDENTITY_INSERT [dbo].[StaffType] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([IDSupplier], [SupplierName], [PhoneSupplier], [SupplierAddress], [EmailSupplier]) VALUES (1, N'Apple', N'18001192    ', N'Phòng 901, Ngôi Nhà Đức Tại Tp. Hồ Chí Minh, số 33, đường Lê Duẩn, Phường Bến Nghé, Quận 1, thành phố Hồ Chí Minh, Việt Nam', N'Apple@gamil.com.vn                                ')
INSERT [dbo].[Supplier] ([IDSupplier], [SupplierName], [PhoneSupplier], [SupplierAddress], [EmailSupplier]) VALUES (2, N'Sony', N'02838222227 ', N'TẦNG 6 VÀ 7, TÒA NHÀ PRESIDENT PLACE, 93 NGUYỄN DU, PHƯỜNG BẾN NGHÉ, QUẬN 1, TP. HỒ CHÍ MINH.', N'Sony@gamil.com.vn                                 ')
INSERT [dbo].[Supplier] ([IDSupplier], [SupplierName], [PhoneSupplier], [SupplierAddress], [EmailSupplier]) VALUES (3, N'Samsung', N'2839157310  ', N' Số 2, đường Hải Triều, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', N'Samsung@gamil.com.vn                              ')
INSERT [dbo].[Supplier] ([IDSupplier], [SupplierName], [PhoneSupplier], [SupplierAddress], [EmailSupplier]) VALUES (4, N'JBL', N'6299055253  ', N'JBL STORE CRESCENT MALL | 101 Đ Tôn Dật Tiên, Tân Phú, Quận 7, Thành phố Hồ Chí Minh', N'JBL@gamil.com.vn                                  ')
INSERT [dbo].[Supplier] ([IDSupplier], [SupplierName], [PhoneSupplier], [SupplierAddress], [EmailSupplier]) VALUES (5, N'Beats', N'0941144666  ', N'Cơ sở 3: 12 ngõ 860 phố Minh Khai, quận Hai Bà Trưng, Hà Nội.', N'Razer@gmail.com.vn                                ')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'Adminlor            ', N'Admin@gmail.com                                   ', N'Aa123                                                                                                                                                                                                                                                          ', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy                 ', N'huy@gmail.com                                     ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy1                ', N'huy1@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy2                ', N'huy2@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy3                ', N'huy3@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy4                ', N'huy4@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy5                ', N'huy5@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huy6                ', N'huy6@gmail.com                                    ', N'123                                                                                                                                                                                                                                                            ', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huyngu              ', N'huyngu@222gmail.com                               ', N'$2a$11$GVEv6Y/6K6y/PfKEDCGaS.Zb1aA4QBoRPQs1IodO/sv/krqcO3GIi', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'huyngu123           ', N'huyngu213@gmail.com                               ', N'$2a$11$riEo32FDlvJGwxCcuVShi.HxUlIyTEOxB3gRZgRlNGDX0TVz1ABkm', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'khanhchi            ', N'khanhchii741@gmail.com                            ', N'$2a$11$wCf5FsUlbdEDMLLr7xRwZ.Q.1hGiNRFFtv1esqoujp0GCYwAZq69q                                                                                                                                                                                                   ', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'khanhchua           ', N'khanhchua741@gmail.com                            ', N'$2a$11$ZPlRjY0DxyhoT/plJpxZlOiQmPJUW.0FZZrDIIlpUFdl4VAWpaLs6                                                                                                                                                                                                   ', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'khanhga             ', N'khanhga741@gmail.com                              ', N'$2a$11$iCMAKo2ZqJtxSRyha4emlew8bPyaSs9cEpKSNZwMfkA6oNr.4r8ze', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'khanhngu            ', N'khanhngu@gmail.com                                ', N'$2a$11$XPGDoyPscA.ZEwENvTcv.ehcNy6bhrZJkSGNsl7J4cLv6oFfzR3ie', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'nguyentuanhuy       ', N'huynopro102@gmail.com                             ', N'$2a$11$zWAxXZA9n0mXrORbQQ6uIeCYoIAKJxpdRUmT46lq782zL4Zj0i4RW', 2)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'nguyentuanhuy1      ', N'huynopro101@gmail.com                             ', N'$2a$11$Rr3RWUUAD493ZWpbtgIzj.XAFLfrrLet8Q2amDg0VVNMcUj3EDKwq', 1)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'nguyentuanhuy2      ', N'e21@gmail.com                                     ', N'$2a$11$0Lr.zkeEiVuQr0EXYGZkFe.BZajkc0Cs1ydfoCbn.7IMRQ6oh6cvC', 4)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'sơn                 ', N'sonle123@gmail.com                                ', N'$2a$11$w5zoEYX.5cnNJ5kw7.w4X.Ii8txIJYePCWwBnKH4QzLeLbwJ9XXYC                                                                                                                                                                                                   ', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'songa               ', N'songa22@gmail.com                                 ', N'$2a$11$1ZJgiF890tIPN5GmDBALLupeHeLowPrKMeYPbpkLna8DH10m5L0p6', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'sonngu              ', N'sonngu123@gmail.com                               ', N'$2a$11$aGGvJW774VfZkp/k6Oa/0.n1Wj9QaRWPX5YbERCZxZPvxaXE7JqVC', 3)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'sonnguyen           ', N'hehe@gmail.com                                    ', N'$2a$11$AnmkPvuYBKwkW5ArGREmgOZA2kEEstjhkWWT45zgd8ZV5LMCsYbkW', 2)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'User_NV1            ', N'NV1@gmail.com                                     ', N'456                                                                                                                                                                                                                                                            ', 4)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'User_NV2            ', N'NV2@gmail.com                                     ', N'456                                                                                                                                                                                                                                                            ', 2)
INSERT [dbo].[User] ([Username], [Email], [Password], [Check]) VALUES (N'User_NV3            ', N'NV3@gmail.com                                     ', N'789                                                                                                                                                                                                                                                            ', 4)
GO
SET IDENTITY_INSERT [dbo].[Warehouse] ON 

INSERT [dbo].[Warehouse] ([IDWarehouse], [WarehouseName], [WarehouseAddress], [DateCreated]) VALUES (2, N'Kho-1', N'39 đường Hùng Vương, xã Vĩnh Thanh, Nhơn Trạch, Đồng Nai', CAST(N'2024-07-04' AS Date))
INSERT [dbo].[Warehouse] ([IDWarehouse], [WarehouseName], [WarehouseAddress], [DateCreated]) VALUES (4, N'Kho-2', N'Ấp Hòa Bình, xã Vĩnh Thanh, Nhơn Trạch, Đồng Nai', CAST(N'2024-04-03' AS Date))
SET IDENTITY_INSERT [dbo].[Warehouse] OFF
GO
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 2, 90)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 3, 55)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 4, 170)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 5, 120)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 16, 250)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 17, 40)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 19, 50)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 20, 55)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 21, 70)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 22, 45)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 23, 55)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1006, 33)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1007, 52)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1008, 100)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1015, 100)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1016, 100)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1017, 100)
INSERT [dbo].[Warehousedetails] ([IDWarehouse], [IDProduct], [QuantityInStock]) VALUES (2, 1018, 100)
GO
ALTER TABLE [dbo].[Banner]  WITH CHECK ADD  CONSTRAINT [FK_Banner_Images] FOREIGN KEY([IDImages])
REFERENCES [dbo].[Images] ([IDImages])
GO
ALTER TABLE [dbo].[Banner] CHECK CONSTRAINT [FK_Banner_Images]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Images] FOREIGN KEY([IdImages])
REFERENCES [dbo].[Images] ([IDImages])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Images]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_User]
GO
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Invoice] FOREIGN KEY([IDInvoice])
REFERENCES [dbo].[Invoice] ([IDInvoice])
GO
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Invoice]
GO
ALTER TABLE [dbo].[DeliveryNotes]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryNotes_Staff] FOREIGN KEY([IDStaff])
REFERENCES [dbo].[Staff] ([IDStaff])
GO
ALTER TABLE [dbo].[DeliveryNotes] CHECK CONSTRAINT [FK_DeliveryNotes_Staff]
GO
ALTER TABLE [dbo].[Imported Products]  WITH CHECK ADD  CONSTRAINT [FK_Imported Products Detail_Staff] FOREIGN KEY([IDStaff])
REFERENCES [dbo].[Staff] ([IDStaff])
GO
ALTER TABLE [dbo].[Imported Products] CHECK CONSTRAINT [FK_Imported Products Detail_Staff]
GO
ALTER TABLE [dbo].[Imported Products]  WITH CHECK ADD  CONSTRAINT [FK_Imported Products Detail_Warehouse] FOREIGN KEY([IDWarehouse])
REFERENCES [dbo].[Warehouse] ([IDWarehouse])
GO
ALTER TABLE [dbo].[Imported Products] CHECK CONSTRAINT [FK_Imported Products Detail_Warehouse]
GO
ALTER TABLE [dbo].[ImportedProductsDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportedProductsDetail_Imported Products] FOREIGN KEY([IDImportedProducts])
REFERENCES [dbo].[Imported Products] ([IDImportedProducts])
GO
ALTER TABLE [dbo].[ImportedProductsDetail] CHECK CONSTRAINT [FK_ImportedProductsDetail_Imported Products]
GO
ALTER TABLE [dbo].[ImportedProductsDetail]  WITH CHECK ADD  CONSTRAINT [FK_ImportedProductsDetail_Product] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[ImportedProductsDetail] CHECK CONSTRAINT [FK_ImportedProductsDetail_Product]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([IDCustomer])
REFERENCES [dbo].[Customer] ([IDCustomer])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Staff] FOREIGN KEY([IDStaff])
REFERENCES [dbo].[Staff] ([IDStaff])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Staff]
GO
ALTER TABLE [dbo].[Invoicedetails]  WITH CHECK ADD  CONSTRAINT [FK_Invoicedetails_Invoice] FOREIGN KEY([IDInvoice])
REFERENCES [dbo].[Invoice] ([IDInvoice])
GO
ALTER TABLE [dbo].[Invoicedetails] CHECK CONSTRAINT [FK_Invoicedetails_Invoice]
GO
ALTER TABLE [dbo].[Invoicedetails]  WITH CHECK ADD  CONSTRAINT [FK_Invoicedetails_Product] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[Invoicedetails] CHECK CONSTRAINT [FK_Invoicedetails_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([IDProductType])
REFERENCES [dbo].[ProductType] ([IDProductType])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([IDSupplier])
REFERENCES [dbo].[Supplier] ([IDSupplier])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[ProductImagesDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductImagesDetails_Images] FOREIGN KEY([IDImages])
REFERENCES [dbo].[Images] ([IDImages])
GO
ALTER TABLE [dbo].[ProductImagesDetails] CHECK CONSTRAINT [FK_ProductImagesDetails_Images]
GO
ALTER TABLE [dbo].[ProductImagesDetails]  WITH CHECK ADD  CONSTRAINT [FK_ProductImagesDetails_Product] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[ProductImagesDetails] CHECK CONSTRAINT [FK_ProductImagesDetails_Product]
GO
ALTER TABLE [dbo].[Shopping cart]  WITH CHECK ADD  CONSTRAINT [FK_Shopping cart_Customer] FOREIGN KEY([IDCustomer])
REFERENCES [dbo].[Customer] ([IDCustomer])
GO
ALTER TABLE [dbo].[Shopping cart] CHECK CONSTRAINT [FK_Shopping cart_Customer]
GO
ALTER TABLE [dbo].[shoppingCartDeltails]  WITH CHECK ADD  CONSTRAINT [FK_shoppingCartDeltails_Product] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[shoppingCartDeltails] CHECK CONSTRAINT [FK_shoppingCartDeltails_Product]
GO
ALTER TABLE [dbo].[shoppingCartDeltails]  WITH CHECK ADD  CONSTRAINT [FK_shoppingCartDeltails_Shopping cart] FOREIGN KEY([IDshoppingCart])
REFERENCES [dbo].[Shopping cart] ([IDshoppingCart])
GO
ALTER TABLE [dbo].[shoppingCartDeltails] CHECK CONSTRAINT [FK_shoppingCartDeltails_Shopping cart]
GO
ALTER TABLE [dbo].[SkillDetails]  WITH CHECK ADD  CONSTRAINT [FK_SkillDetails_Skill] FOREIGN KEY([IdSkill])
REFERENCES [dbo].[Skill] ([IdSkill])
GO
ALTER TABLE [dbo].[SkillDetails] CHECK CONSTRAINT [FK_SkillDetails_Skill]
GO
ALTER TABLE [dbo].[SkillDetails]  WITH CHECK ADD  CONSTRAINT [FK_SkillDetails_Staff] FOREIGN KEY([IDStaff])
REFERENCES [dbo].[Staff] ([IDStaff])
GO
ALTER TABLE [dbo].[SkillDetails] CHECK CONSTRAINT [FK_SkillDetails_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Images] FOREIGN KEY([IdImages])
REFERENCES [dbo].[Images] ([IDImages])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Images]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_StaffType] FOREIGN KEY([IDStaffType])
REFERENCES [dbo].[StaffType] ([IDStaffType])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_StaffType]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_User] FOREIGN KEY([Username])
REFERENCES [dbo].[User] ([Username])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_User]
GO
ALTER TABLE [dbo].[Warehousedetails]  WITH CHECK ADD  CONSTRAINT [FK_Warehousedetails_Product] FOREIGN KEY([IDProduct])
REFERENCES [dbo].[Product] ([IDProduct])
GO
ALTER TABLE [dbo].[Warehousedetails] CHECK CONSTRAINT [FK_Warehousedetails_Product]
GO
ALTER TABLE [dbo].[Warehousedetails]  WITH CHECK ADD  CONSTRAINT [FK_Warehousedetails_Warehouse] FOREIGN KEY([IDWarehouse])
REFERENCES [dbo].[Warehouse] ([IDWarehouse])
GO
ALTER TABLE [dbo].[Warehousedetails] CHECK CONSTRAINT [FK_Warehousedetails_Warehouse]
GO
