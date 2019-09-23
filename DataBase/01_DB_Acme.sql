--==========================================================
--===================CREATE DATABASE ACME===================
--==========================================================
USE [master];
GO
IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'DB_Acme') 
DROP DATABASE [DB_Acme];
GO
CREATE DATABASE [DB_Acme];
GO
--==========================================================

USE [DB_Acme];
GO

--==========================================================
--==================CREATE TABLE DOCUMENTO==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Documento]') IS NOT NULL DROP TABLE [dbo].[TB_Documento];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Documento]
(
	[ID_Documento] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumento] [nvarchar](10) NOT NULL,
 
	CONSTRAINT [PK_TB_Documento] PRIMARY KEY CLUSTERED	([ID_Documento] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
--==========================================================


--==========================================================
--====================CREATE TABLE CIUDAD===================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Ciudad]') IS NOT NULL DROP TABLE [dbo].[TB_Ciudad];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Ciudad]
(
	[ID_Ciudad] [int] IDENTITY(1,1) NOT NULL,
	[NombreCiudad] [nvarchar](25) NOT NULL,
	[NombreRegion] [nvarchar](25) NOT NULL,
 
	CONSTRAINT [PK_TB_Ciudad] PRIMARY KEY CLUSTERED	([ID_Ciudad] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
--==========================================================


--==========================================================
--==================CREATE TABLE CATEGORIA==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Categoria]') IS NOT NULL DROP TABLE [dbo].[TB_Categoria];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Categoria]
(
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[TipoCategoria] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](140) NOT NULL,
 
	CONSTRAINT [PK_TB_Categoria] PRIMARY KEY CLUSTERED ([ID_Categoria] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
--==========================================================


--==========================================================
--==================CREATE TABLE PROMOCION==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Promocion]') IS NOT NULL DROP TABLE [dbo].[TB_Promocion];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Promocion]
(
	[ID_Promocion] [int] IDENTITY(1,1) NOT NULL,
	[TipoPromocion] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](140) NOT NULL,
 
	CONSTRAINT [PK_TB_Promocion] PRIMARY KEY CLUSTERED	([ID_Promocion] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
--==========================================================


--==========================================================
--===================CREATE TABLE VENDEDOR==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Vendedor]') IS NOT NULL DROP TABLE [dbo].[TB_Vendedor];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Vendedor]
(
	[ID_Vendedor] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](25) NOT NULL,
	[NumeroDocumento] [nvarchar](25) NOT NULL,
	[NombreUsuario] [nvarchar](25) NOT NULL,
	[Contrasenia] [nvarchar](25) NOT NULL,
	 
	CONSTRAINT [PK_TB_Vendedor] PRIMARY KEY CLUSTERED ([ID_Vendedor] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO
--==========================================================


--==========================================================
--====================CREATE TABLE CLIENTE==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Cliente]') IS NOT NULL DROP TABLE [dbo].[TB_Cliente];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Cliente]
(
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[ID_Vendedor] [int] NOT NULL,
	[ID_Ciudad] [int] NOT NULL,
	[ID_Documento] [int] NOT NULL,
	[NombreCompleto] [nvarchar](25) NOT NULL,
	[NumeroDocumento] [nvarchar](25) NOT NULL,
	[Telefono] [nvarchar](25) NOT NULL,
	[Celular] [nvarchar](25) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Direccion] [nvarchar](80) NOT NULL,
 
	CONSTRAINT [PK_TB_Cliente] PRIMARY KEY CLUSTERED ([ID_Cliente] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO

ALTER TABLE [dbo].[TB_Cliente] WITH CHECK ADD CONSTRAINT [FK_TB_Cliente_TB_Vendedor] 
FOREIGN KEY([ID_Vendedor]) REFERENCES [dbo].[TB_Vendedor] ([ID_Vendedor])
GO
ALTER TABLE [dbo].[TB_Cliente] CHECK CONSTRAINT [FK_TB_Cliente_TB_Vendedor]
GO

ALTER TABLE [dbo].[TB_Cliente] WITH CHECK ADD CONSTRAINT [FK_TB_Cliente_TB_Ciudad] 
FOREIGN KEY([ID_Ciudad]) REFERENCES [dbo].[TB_Ciudad] ([ID_Ciudad])
GO
ALTER TABLE [dbo].[TB_Cliente] CHECK CONSTRAINT [FK_TB_Cliente_TB_Ciudad]
GO

ALTER TABLE [dbo].[TB_Cliente] WITH CHECK ADD CONSTRAINT [FK_TB_Cliente_TB_Documento] 
FOREIGN KEY([ID_Documento]) REFERENCES [dbo].[TB_Documento] ([ID_Documento])
GO
ALTER TABLE [dbo].[TB_Cliente] CHECK CONSTRAINT [FK_TB_Cliente_TB_Documento]
GO
--==========================================================


--==========================================================
--=====================CREATE TABLE PEDIDO==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Pedido]') IS NOT NULL DROP TABLE [dbo].[TB_Pedido];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Pedido]
(
	[ID_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[TotalBruto] [decimal] (10,2) NOT NULL,
	[Impuesto] [decimal] (10,2) NOT NULL,
	[ValorNeto] [decimal] (10,2) NOT NULL,
	[Estado] [bit] NOT NULL,
 
	CONSTRAINT [PK_TB_Pedido] PRIMARY KEY CLUSTERED ([ID_Pedido] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO

ALTER TABLE [dbo].[TB_Pedido] WITH CHECK ADD CONSTRAINT [FK_TB_Pedido_TB_Cliente] 
FOREIGN KEY([ID_Cliente]) REFERENCES [dbo].[TB_Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[TB_Pedido] CHECK CONSTRAINT [FK_TB_Pedido_TB_Cliente]
GO
--==========================================================


--==========================================================
--====================CREATE TABLE PRODUCTO=================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Producto]') IS NOT NULL DROP TABLE [dbo].[TB_Producto];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Producto]
(
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[ID_Categoria] [int] NOT NULL,
	[ID_Promocion] [int] NOT NULL,	
	[NombreProducto] [nvarchar](25) NOT NULL,
	[Codigo] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Fabricante] [nvarchar](50) NOT NULL,
	[Stock] [int] NOT NULL,	
	[Impuesto] [decimal] (10,2) NOT NULL,
	[ValorUnitario] [decimal] (10,2) NOT NULL,
	[Estado] [bit] NOT NULL,
 
	CONSTRAINT [PK_TB_Producto] PRIMARY KEY CLUSTERED ([ID_Producto] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO

ALTER TABLE [dbo].[TB_Producto] WITH CHECK ADD CONSTRAINT [FK_TB_Producto_TB_Categoria] 
FOREIGN KEY([ID_Categoria]) REFERENCES [dbo].[TB_Categoria] ([ID_Categoria])
GO
ALTER TABLE [dbo].[TB_Producto] CHECK CONSTRAINT [FK_TB_Producto_TB_Categoria]
GO

ALTER TABLE [dbo].[TB_Producto] WITH CHECK ADD CONSTRAINT [FK_TB_Producto_TB_Promocion] 
FOREIGN KEY([ID_Promocion]) REFERENCES [dbo].[TB_Promocion] ([ID_Promocion])
GO
ALTER TABLE [dbo].[TB_Producto] CHECK CONSTRAINT [FK_TB_Producto_TB_Promocion]
GO
--==========================================================


--==========================================================
--===============CREATE TABLE DETALLE PEDIDO================
--==========================================================
IF OBJECT_ID('[dbo].[TB_DetallePedido]') IS NOT NULL DROP TABLE [dbo].[TB_DetallePedido];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DetallePedido]
(
	[ID_DetallePedido] [int] IDENTITY(1,1) NOT NULL,
	[ID_Pedido] [int] NOT NULL,
	[ID_Producto] [int] NOT NULL,	
	[Codigo] [nvarchar](25) NOT NULL,
	[NombreProducto] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[Cantidad] [int] NOT NULL,	
	[ValorUnitario] [decimal] (10,2) NOT NULL,
	[Impuesto] [decimal] (10,2) NOT NULL,
	[SubTotal] [decimal] (10,2) NOT NULL,	
 
	CONSTRAINT [PK_TB_DetallePedido] PRIMARY KEY CLUSTERED ([ID_DetallePedido] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY]
GO

ALTER TABLE [dbo].[TB_DetallePedido] WITH CHECK ADD CONSTRAINT [FK_TB_DetallePedido_TB_Pedido] 
FOREIGN KEY([ID_Pedido]) REFERENCES [dbo].[TB_Pedido] ([ID_Pedido])
GO
ALTER TABLE [dbo].[TB_DetallePedido] CHECK CONSTRAINT [FK_TB_DetallePedido_TB_Pedido]
GO

ALTER TABLE [dbo].[TB_DetallePedido] WITH CHECK ADD CONSTRAINT [FK_TB_DetallePedido_TB_Producto] 
FOREIGN KEY([ID_Producto]) REFERENCES [dbo].[TB_Producto] ([ID_Producto])
GO
ALTER TABLE [dbo].[TB_DetallePedido] CHECK CONSTRAINT [FK_TB_DetallePedido_TB_Producto]
GO
--==========================================================


--==========================================================
--==================CREATE TABLE AUDITORIA==================
--==========================================================
IF OBJECT_ID('[dbo].[TB_Auditoria]') IS NOT NULL DROP TABLE [dbo].[TB_Auditoria];
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Auditoria]
(	
	[ID_Auditoria] [int] IDENTITY(1,1) NOT NULL,
	[TiempoEvento] [datetime] NOT NULL,
	[NombreUsuario] [nvarchar] (25) NOT NULL,
   	[NombreBaseDatos] [nvarchar] (25) NOT NULL,
  	[NombreObjeto] [nvarchar] (25) NOT NULL,
	[TipoObjeto] [nvarchar] (10) NOT NULL,
 	[ComandoDML] [nvarchar] (10) NOT NULL,

	CONSTRAINT [PK_TB_Auditoria] PRIMARY KEY CLUSTERED	([ID_Auditoria] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY]
GO
--==========================================================