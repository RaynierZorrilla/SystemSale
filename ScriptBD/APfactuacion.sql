USE [master]
GO
/****** Object:  Database [APfacturacion]    Script Date: 10/08/2023 0:17:09 ******/
CREATE DATABASE [APfacturacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'APfacturacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\APfacturacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'APfacturacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\APfacturacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [APfacturacion] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [APfacturacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [APfacturacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [APfacturacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [APfacturacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [APfacturacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [APfacturacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [APfacturacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [APfacturacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [APfacturacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [APfacturacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [APfacturacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [APfacturacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [APfacturacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [APfacturacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [APfacturacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [APfacturacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [APfacturacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [APfacturacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [APfacturacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [APfacturacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [APfacturacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [APfacturacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [APfacturacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [APfacturacion] SET RECOVERY FULL 
GO
ALTER DATABASE [APfacturacion] SET  MULTI_USER 
GO
ALTER DATABASE [APfacturacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [APfacturacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [APfacturacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [APfacturacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [APfacturacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [APfacturacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'APfacturacion', N'ON'
GO
ALTER DATABASE [APfacturacion] SET QUERY_STORE = ON
GO
ALTER DATABASE [APfacturacion] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [APfacturacion]
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[idcategoria] [int] NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[precio_venta] [decimal](11, 2) NOT NULL,
	[stock] [int] NOT NULL,
	[descripcion] [varchar](250) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](200) NOT NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[sexo] [varchar](100) NOT NULL,
	[rol] [varchar](50) NOT NULL,
	[cedula] [varchar](100) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](100) NOT NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_empleado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persona]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persona](
	[idpersona] [int] IDENTITY(1,1) NOT NULL,
	[tipo_persona] [varchar](20) NOT NULL,
	[nombre] [varchar](55) NOT NULL,
	[tipo_documentos] [varchar](100) NULL,
	[cedula] [varchar](25) NULL,
	[direccion] [varchar](55) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idpersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[idrol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idrol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tclien]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tclien](
	[idce] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[telefono] [varchar](100) NOT NULL,
	[sexo] [varchar](50) NOT NULL,
	[cedula] [varchar](100) NOT NULL,
	[direccion] [varchar](100) NULL,
	[email] [varchar](100) NULL,
 CONSTRAINT [PK_tclien] PRIMARY KEY CLUSTERED 
(
	[idce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[idrol] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[cedula] [varchar](20) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](20) NULL,
	[email] [varchar](50) NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vent]    Script Date: 10/08/2023 0:17:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vent](
	[idvent] [int] IDENTITY(1,1) NOT NULL,
	[precio] [decimal](11, 2) NOT NULL,
	[cantidad] [int] NOT NULL,
	[tipo_pago] [varchar](50) NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
	[total] [decimal](11, 2) NOT NULL,
	[producto] [varchar](50) NOT NULL,
	[empleado] [varchar](100) NULL,
 CONSTRAINT [PK_vent] PRIMARY KEY CLUSTERED 
(
	[idvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[categoria] ON 

INSERT [dbo].[categoria] ([idcategoria], [nombre], [descripcion], [estado]) VALUES (1, N'Arroz', N'Arroz campos', 1)
SET IDENTITY_INSERT [dbo].[categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([ID], [nombre], [apellido], [sexo], [rol], [cedula], [direccion], [telefono], [email]) VALUES (2, N'Luis', N'Gonzalez', N'Masculino', N'Empleado', N'3049582384', N'Santo Domingo', N'8297483845', N'nez2043@gmail.com')
INSERT [dbo].[empleado] ([ID], [nombre], [apellido], [sexo], [rol], [cedula], [direccion], [telefono], [email]) VALUES (4, N'Rourger', N'Morla', N'Masculino', N'Empleado', N'3034847284', N'San Pedro de Macoris', N'8098374782', N'2839405@gmail.com')
INSERT [dbo].[empleado] ([ID], [nombre], [apellido], [sexo], [rol], [cedula], [direccion], [telefono], [email]) VALUES (5, N'Rosa', N'Balbuena', N'Femenino', N'Empleado', N'29301948294', N'Santo Domingo', N'8294850574', N'buena3023@gmail.com')
INSERT [dbo].[empleado] ([ID], [nombre], [apellido], [sexo], [rol], [cedula], [direccion], [telefono], [email]) VALUES (8, N'Andy', N'Louis', N'Masculino', N'Gerente', N'230405029405', N'California', N'1239459395', N'20345@gmail.com')
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
SET IDENTITY_INSERT [dbo].[tclien] ON 

INSERT [dbo].[tclien] ([idce], [nombre], [apellido], [telefono], [sexo], [cedula], [direccion], [email]) VALUES (3, N'Emilio', N'Sosa', N'8297385845', N'Masculino', N'1556321144', N'La Romana', N'Sos233@gmail.com')
INSERT [dbo].[tclien] ([idce], [nombre], [apellido], [telefono], [sexo], [cedula], [direccion], [email]) VALUES (4, N'Julio', N'Perez', N'8928374854', N'Masculino', N'1556321144', N'San Pedro de Macoris', N'')
INSERT [dbo].[tclien] ([idce], [nombre], [apellido], [telefono], [sexo], [cedula], [direccion], [email]) VALUES (6, N'Meysen', N'Zorrilla', N'-292175233', N'Masculino', N'1556321144', N'San Pedro de Macoris', N'Zorrillaraynier2003@gmail.com')
INSERT [dbo].[tclien] ([idce], [nombre], [apellido], [telefono], [sexo], [cedula], [direccion], [email]) VALUES (7, N'Rosa', N'Zorrilla', N'-292175233', N'Femenino', N'1556321144', N'San Pedro de Macoris', N'Zorrillaraynier2003@gmail.com')
SET IDENTITY_INSERT [dbo].[tclien] OFF
GO
SET IDENTITY_INSERT [dbo].[vent] ON 

INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (3, CAST(40900.00 AS Decimal(11, 2)), 3, N'Efectivo', CAST(N'2023-07-20T00:00:00.000' AS DateTime), CAST(122700.00 AS Decimal(11, 2)), N'Bateria', N'Rosa Balbuena')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1014, CAST(20500.00 AS Decimal(11, 2)), 6, N'Tarjeta', CAST(N'2023-07-24T00:00:00.000' AS DateTime), CAST(102500.00 AS Decimal(11, 2)), N'Piano', NULL)
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1016, CAST(10200.00 AS Decimal(11, 2)), 4, N'Efectivo', CAST(N'2023-07-25T00:00:00.000' AS DateTime), CAST(40800.00 AS Decimal(11, 2)), N'Saxofon', NULL)
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1017, CAST(3300.00 AS Decimal(11, 2)), 3, N'Tarjeta', CAST(N'2023-07-27T00:00:00.000' AS DateTime), CAST(9900.00 AS Decimal(11, 2)), N'In ear', NULL)
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1018, CAST(40900.00 AS Decimal(11, 2)), 6, N'Efectivo', CAST(N'2023-07-27T00:00:00.000' AS DateTime), CAST(245400.00 AS Decimal(11, 2)), N'Bateria', NULL)
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1020, CAST(16000.00 AS Decimal(11, 2)), 2, N'Efectivo', CAST(N'2023-08-08T00:00:00.000' AS DateTime), CAST(32000.00 AS Decimal(11, 2)), N'Bajo', NULL)
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1022, CAST(9500.00 AS Decimal(11, 2)), 1, N'Efectivo', CAST(N'2023-08-08T00:00:00.000' AS DateTime), CAST(9500.00 AS Decimal(11, 2)), N'Trompeta', N'Luis Gonzalez')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1024, CAST(40900.00 AS Decimal(11, 2)), 3, N'Efectivo', CAST(N'2023-08-08T00:00:00.000' AS DateTime), CAST(122700.00 AS Decimal(11, 2)), N'Bateria', N'luis')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1025, CAST(20500.00 AS Decimal(11, 2)), 1, N'Efectivo', CAST(N'2023-08-09T00:00:00.000' AS DateTime), CAST(20500.00 AS Decimal(11, 2)), N'Piano', N'Luis')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1026, CAST(20500.00 AS Decimal(11, 2)), 1, N'Efectivo', CAST(N'2023-08-09T00:00:00.000' AS DateTime), CAST(20500.00 AS Decimal(11, 2)), N'Piano', N'Rounger Morla')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1027, CAST(8100.00 AS Decimal(11, 2)), 1, N'Efectivo', CAST(N'2023-08-09T00:00:00.000' AS DateTime), CAST(8100.00 AS Decimal(11, 2)), N'Guitarra acustica', N'Rounger Morla')
INSERT [dbo].[vent] ([idvent], [precio], [cantidad], [tipo_pago], [fecha_hora], [total], [producto], [empleado]) VALUES (1028, CAST(3300.00 AS Decimal(11, 2)), 1, N'Efectivo', CAST(N'2023-08-09T00:00:00.000' AS DateTime), CAST(3300.00 AS Decimal(11, 2)), N'In ear', N'Luis')
SET IDENTITY_INSERT [dbo].[vent] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__articulo__72AFBCC6962DCA19]    Script Date: 10/08/2023 0:17:10 ******/
ALTER TABLE [dbo].[articulo] ADD UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[categoria] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[rol] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[usuario] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([idrol])
REFERENCES [dbo].[rol] ([idrol])
GO
USE [master]
GO
ALTER DATABASE [APfacturacion] SET  READ_WRITE 
GO
