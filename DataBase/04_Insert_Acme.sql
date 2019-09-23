--==========================================================
--====================INSERT VALUES ACME====================
--==========================================================
USE [DB_Acme]
GO
--==========================================================


--==========================================================
--==================CREATE TABLE DOCUMENTO==================
--==========================================================
INSERT [dbo].[TB_Documento] ([TipoDocumento]) VALUES (N'Cedula');

INSERT [dbo].[TB_Documento] ([TipoDocumento]) VALUES (N'Nit');
GO


--==========================================================
--===================CREATE TABLE CIUDAD====================
--==========================================================
INSERT [dbo].[TB_Ciudad] ([NombreCiudad],[NombreRegion]) VALUES (N'Bogotá', N'Antioquia');

INSERT [dbo].[TB_Ciudad] ([NombreCiudad],[NombreRegion]) VALUES (N'Cali', N'Cundinamarca');

INSERT [dbo].[TB_Ciudad] ([NombreCiudad],[NombreRegion]) VALUES (N'Medellín', N'Valle del Cauca');
GO


--==========================================================
--==================CREATE TABLE VENDEDOR===================
--==========================================================
EXECUTE [dbo].[InsertarVendedor] N'Juan Sebastian Rodriguez', N'123456', N'Juansrt', N'Juan3456';

EXECUTE [dbo].[InsertarVendedor] N'Carlos Roman', N'456789', N'Carlosr', N'Carlos6789';

EXECUTE [dbo].[InsertarVendedor] N'Juan Manuel Chaguendo', N'654321', N'Juanmc', N'Juan4321';

EXECUTE [dbo].[InsertarVendedor] N'Hector David', N'987654', N'Hectord', N'Hector7654';
GO

--Procedimiento almacenado para autenticar al vendedor
--DECLARE @Salida BIT
--EXEC [dbo].[AutenticarVendedor] N'Juansrt', N'Juan3456', @Salida OUTPUT
--SELECT @Salida


--==========================================================
--===================CREATE TABLE CLIENTE===================
--==========================================================
INSERT [dbo].[TB_Cliente] ([ID_Vendedor],[ID_Ciudad],[ID_Documento],[NombreCompleto],[NumeroDocumento],[Telefono],[Celular],[Email],[Direccion]) 
VALUES (1, 2, 2, N'Tienda la Fortuna', N'123456', N'123456', N'3183214567', N'tiendalafortuna@hotmail.com', N'Calle 888 # 88-88' );

INSERT [dbo].[TB_Cliente] ([ID_Vendedor],[ID_Ciudad],[ID_Documento],[NombreCompleto],[NumeroDocumento],[Telefono],[Celular],[Email],[Direccion]) 
VALUES (2, 2, 2, N'Tienda la Rebaja', N'654321', N'654321', N'3183214321', N'tiendalarebaja@hotmail.com', N'Calle 999 # 99-99' );
GO


--==========================================================
--====================CREATE TABLE PEDIDO===================
--==========================================================
--INSERT [dbo].[TB_Pedido] ([ID_Cliente],[FechaRegistro],[TotalBruto],[Impuesto],[ValorNeto],[Estado]) 
--VALUES (1, CAST(N'2015-11-30 13:30:53.403' AS DATETIME), 24000, 0.16, 27840, 1);
--GO
EXECUTE [dbo].[InsertarPedido] 1, 24000, 0.16, 27840;
GO

--==========================================================
--==================CREATE TABLE PROMOCION==================
--==========================================================
INSERT [dbo].[TB_Promocion] ([TipoPromocion],[Descripcion])
VALUES (N'No Aplica', N'No aplica ningún tipo de promoción');

INSERT [dbo].[TB_Promocion] ([TipoPromocion],[Descripcion])
VALUES (N'Promoción 30X24', N'Por la compra de 2 paquete X 12 unds. se obsequia 6 unds. del mismo producto');

INSERT [dbo].[TB_Promocion] ([TipoPromocion],[Descripcion])
VALUES (N'Promoción 48X60', N'Por la compra de 2 paquete X 24 unds. se obsequia 12 unds. del mismo producto');
GO


--==========================================================
--==================CREATE TABLE CATEGORIA==================
--==========================================================
INSERT [dbo].[TB_Categoria] ([TipoCategoria],[Descripcion]) VALUES (N'Snacks Dulces', N'Pasabocas de contenido dulce');

INSERT [dbo].[TB_Categoria] ([TipoCategoria],[Descripcion]) VALUES (N'Snacks Salados', N'Pasabocas de contenido salado');
GO


--==========================================================
--===================CREATE TABLE PRODUCTO==================
--==========================================================
INSERT [dbo].[TB_Producto] ([ID_Categoria],[ID_Promocion],[NombreProducto],[Codigo],[Descripcion],[Fabricante],[Stock],[Impuesto],[ValorUnitario],[Estado]) 
VALUES (2, 2, N'Cheetos Bolitas', 123000, N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1000, 0.16, 12000, 1);

INSERT [dbo].[TB_Producto] ([ID_Categoria],[ID_Promocion],[NombreProducto],[Codigo],[Descripcion],[Fabricante],[Stock],[Impuesto],[ValorUnitario],[Estado]) 
VALUES (2, 2, N'Doritos Nacho Cheese', 123111, N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1000, 0.16, 12000, 1);

INSERT [dbo].[TB_Producto] ([ID_Categoria],[ID_Promocion],[NombreProducto],[Codigo],[Descripcion],[Fabricante],[Stock],[Impuesto],[ValorUnitario],[Estado]) 
VALUES (2, 2, N'Papas Margarita Limon', 123222, N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1000, 0.16, 12000, 1);
GO

INSERT [dbo].[TB_Producto] ([ID_Categoria],[ID_Promocion],[NombreProducto],[Codigo],[Descripcion],[Fabricante],[Stock],[Impuesto],[ValorUnitario],[Estado]) 
VALUES (2, 2, N'Papas Margarita Natural', 123333, N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1000, 0.16, 12000, 1);

INSERT [dbo].[TB_Producto] ([ID_Categoria],[ID_Promocion],[NombreProducto],[Codigo],[Descripcion],[Fabricante],[Stock],[Impuesto],[ValorUnitario],[Estado]) 
VALUES (2, 2, N'Papas Margarita Pollo', 123444, N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1000, 0.16, 12000, 1);
GO


--==========================================================
--==============CREATE TABLE DETALLE DE PEDIDO==============
--==========================================================
--INSERT [dbo].[TB_DetallePedido] ([ID_Pedido],[ID_Producto],[Codigo],[NombreProducto],[Descripcion],[Cantidad],[ValorUnitario],[SubTotal]) 
--VALUES (1, 1, 123000, N'Cheetos Bolitas', N'Paquete de snacks salados X 12 unds.', N'Frito-Lay', 1, 12000, 13920);
--INSERT [dbo].[TB_DetallePedido] ([ID_Pedido],[ID_Producto],[Codigo],[NombreProducto],[Descripcion],[Cantidad],[ValorUnitario],[SubTotal]) 
--VALUES (1, 2, 123111, N'Doritos Nacho Cheese', N'Paquete de snacks salados X 12 unds.', 1, 12000, 13920);
--GO

--Procedimiento almacenado para consultar el identificador del ultimo pedido
--DECLARE @Salida BIT
--EXEC [dbo].[ConsultarIdentificadorPedido] @Salida OUTPUT
--SELECT @Salida
--GO

EXECUTE [dbo].[InsertarDetallePedido] 1, 1, 1;
EXECUTE [dbo].[InsertarDetallePedido] 1, 2, 1;
GO