--==========================================================

USE [DB_Acme]
GO

--==========================================================
--===========CREATE PROCEDURE PARA INSERTAR PEDIDO==========
--==========================================================
IF OBJECT_ID('[dbo].[InsertarPedido]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[InsertarPedido];
GO
CREATE PROCEDURE [dbo].[InsertarPedido]
	@ID_Cliente [int],
	@TotalBruto [decimal] (10,2),
	@Impuesto [decimal] (10,2),
	@ValorNeto [decimal] (10,2)
AS
	DECLARE @FechaRegistro [datetime]
	DECLARE @Estado [bit]
	BEGIN
		SET @FechaRegistro = SYSDATETIME()
		SET @Estado = 1
	END
	BEGIN
		INSERT INTO [dbo].[TB_Pedido] ([ID_Cliente],[FechaRegistro],[TotalBruto],[Impuesto],[ValorNeto],[Estado])
		VALUES (@ID_Cliente, @FechaRegistro, @TotalBruto, @Impuesto, @ValorNeto, @Estado)
	END
GO
--==========================================================


--==========================================================
--=====CREATE PROCEDURE PARA INSERTAR DETALLE DE PEDIDO=====
--==========================================================
IF OBJECT_ID('[dbo].[InsertarDetallePedido]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[InsertarDetallePedido];
GO
CREATE PROCEDURE [dbo].[InsertarDetallePedido]
	@ID_Pedido [int],
	@ID_Producto [int],	
	@Cantidad [int]	
AS
	DECLARE @Codigo [nvarchar](25)
	DECLARE @NombreProducto [nvarchar](25)
	DECLARE @Descripcion [nvarchar](250)
	DECLARE @ValorUnitario [decimal] (10,2)
	DECLARE @Impuesto [decimal] (10,2)
	DECLARE @SubTotal [decimal] (10,2)
	BEGIN
		SELECT @Codigo = Codigo FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SELECT @NombreProducto = NombreProducto FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SELECT @Descripcion = Descripcion FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SELECT @ValorUnitario = ValorUnitario FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SELECT @Impuesto = Impuesto FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SET @ValorUnitario = @ValorUnitario * @Cantidad
		SET @SubTotal = (@Impuesto * @ValorUnitario) + @ValorUnitario
	END
	BEGIN
		INSERT INTO [dbo].[TB_DetallePedido] ([ID_Pedido],[ID_Producto],[Codigo],[NombreProducto],[Descripcion],[Cantidad],[ValorUnitario],[Impuesto],[SubTotal])
		VALUES (@ID_Pedido, @ID_Producto, @Codigo, @NombreProducto, @Descripcion, @Cantidad, @ValorUnitario, @Impuesto, @SubTotal)
	END
GO
--==========================================================


--==========================================================
--=========CREATE PROCEDURE PARA CONSULTAR ID_PEDIDO========
--==========================================================
IF OBJECT_ID('[dbo].[ConsultarIdentificadorPedido]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[ConsultarIdentificadorPedido];
GO
CREATE PROCEDURE [dbo].[ConsultarIdentificadorPedido]
	@ID_Pedido [int] OUTPUT
AS
	BEGIN
		SELECT @ID_Pedido = MAX(ID_Pedido) FROM [dbo].[TB_Pedido]
	END
GO
--==========================================================


--==========================================================
--====CREATE PROCEDURE PARA DESCONTAR STOCK DE PRODUCTO=====
--==========================================================
IF OBJECT_ID('[dbo].[ActualizarStockProducto]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[ActualizarStockProducto];
GO
CREATE PROCEDURE [dbo].[ActualizarStockProducto]
	@ID_Producto [int],
	@Cantidad [int]
AS
	DECLARE @Stock [int]
	DECLARE @StockActual [int]
	DECLARE @Estado [bit]
	BEGIN
		SELECT @Stock = Stock FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
		SELECT @Estado = Estado FROM [dbo].[TB_Producto] WHERE ID_Producto = @ID_Producto
	END
	BEGIN
		IF @Estado = 1 AND @Stock >= @Cantidad
			BEGIN
				SET @StockActual = @Stock - @Cantidad
				UPDATE [dbo].[TB_Producto] SET Stock = @StockActual WHERE ID_Producto = @ID_Producto
			END
		ELSE
			BEGIN
				SET @Estado = 0
				UPDATE [dbo].[TB_Producto] SET Estado = @Estado WHERE ID_Producto = @ID_Producto
			END
	END
GO
--==========================================================


--==========================================================
--==========CREATE PROCEDURE PARA INSERTAR VENDEDOR=========
--==========================================================
IF OBJECT_ID('[dbo].[InsertarVendedor]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[InsertarVendedor];
GO
CREATE PROCEDURE [dbo].[InsertarVendedor]
	@NombreCompleto [nvarchar] (25),
	@NumeroDocumento [nvarchar] (25),
	@NombreUsuario [nvarchar] (25),
	@Contrasenia [nvarchar] (25)
AS
	BEGIN
		INSERT INTO [dbo].[TB_Vendedor] ([NombreCompleto], [NumeroDocumento], [NombreUsuario], [Contrasenia])
		VALUES (@NombreCompleto, @NumeroDocumento, @NombreUsuario, HASHBYTES('SHA1', @Contrasenia))
	END
GO
--==========================================================


--==========================================================
--=======CREATE PROCEDURE PARA VERIFICAR LA CONTRASEÑA======
--==========================================================
IF OBJECT_ID('[dbo].[AutenticarVendedor]', 'P') IS NOT NULL DROP PROCEDURE [dbo].[AutenticarVendedor];
GO
CREATE PROCEDURE [dbo].[AutenticarVendedor]
	@NombreUsuario [nvarchar] (25),
	@Contrasenia [nvarchar] (25),
	@Resultado [bit] OUTPUT
AS
	DECLARE @ContraseniaConsultada [nvarchar] (25)
	DECLARE @ContraseniaEncriptada [nvarchar] (25)
	BEGIN
		SELECT @ContraseniaConsultada = Contrasenia FROM [dbo].[TB_Vendedor] WHERE NombreUsuario = @NombreUsuario
		SET @ContraseniaEncriptada = HASHBYTES('SHA1', @Contrasenia)
	END
	BEGIN
		IF @ContraseniaConsultada = @ContraseniaEncriptada
			BEGIN
				SET @Resultado = 1
			end
		ELSE
			BEGIN
				SET @Resultado = 0
			END
	END
GO
--==========================================================