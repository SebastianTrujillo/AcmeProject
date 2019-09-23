--==========================================================

USE [DB_Acme]
GO

--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Categoria]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Categoria];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Categoria]
ON [dbo].[TB_Categoria]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Categoria'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Ciudad]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Ciudad];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Ciudad]
ON [dbo].[TB_Ciudad]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Ciudad'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Cliente]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Cliente];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Cliente]
ON [dbo].[TB_Cliente]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Cliente'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_DetallePedido]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_DetallePedido];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_DetallePedido]
ON [dbo].[TB_DetallePedido]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_DetallePedido'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Documento]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Documento];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Documento]
ON [dbo].[TB_Documento]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Documento'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Pedido]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Pedido];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Pedido]
ON [dbo].[TB_Pedido]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Pedido'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Producto]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Producto];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Producto]
ON [dbo].[TB_Producto]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Producto'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Promocion]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Promocion];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Promocion]
ON [dbo].[TB_Promocion]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Promocion'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================


--==========================================================
--==========CREATE TRIGGER REGISTRO DEL EVENTO DML==========
--==========================================================
IF OBJECT_ID('[dbo].[Registro_Evento_DML_TB_Vendedor]', N'TR') IS NOT NULL DROP TRIGGER [dbo].[Registro_Evento_DML_TB_Vendedor];
GO
CREATE TRIGGER [dbo].[Registro_Evento_DML_TB_Vendedor]
ON [dbo].[TB_Vendedor]
AFTER INSERT, UPDATE, DELETE
AS 
	DECLARE @TiempoEvento datetime
	DECLARE @usuario [nvarchar] (25)
	DECLARE @NombreBaseDatos [nvarchar] (25)
	DECLARE @NombreObjeto [nvarchar] (25)
	DECLARE @TipoObjeto [nvarchar] (10)
	DECLARE @ComandoDML [nvarchar] (10)
	SET @TiempoEvento = SYSDATETIME()
	SET @usuario = SYSTEM_USER
	SET @NombreBaseDatos = N'DB_Acme'
	SET @NombreObjeto = N'TB_Vendedor'
	SET @TipoObjeto = N'TABLE'
	SET @ComandoDML = NULL

IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
			BEGIN
				SET @ComandoDML = N'UPDATE'
			END
		ELSE
			BEGIN
				SET @ComandoDML = N'INSERT'
			END
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM INSERTED
	END
ELSE IF EXISTS(SELECT * FROM DELETED)
	BEGIN
		SET @ComandoDML = N'DELETE'
		INSERT INTO [dbo].[TB_Auditoria] ([TiempoEvento], [NombreUsuario], [NombreBaseDatos], [NombreObjeto], [TipoObjeto], [ComandoDML])
		SELECT @TiempoEvento, @usuario, @NombreBaseDatos, @NombreObjeto, @TipoObjeto, @ComandoDML
		FROM DELETED
	END
GO
--==========================================================