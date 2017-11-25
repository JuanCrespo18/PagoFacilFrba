USE [GD2C2017]

----------------------------------------------------------------------------------------
-----------------------------------BORRAR TABLAS----------------------------------------
----------------------------------------------------------------------------------------
IF OBJECT_ID ( '[ONEFORALL].[DEVOLUCIONES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[DEVOLUCIONES]						------Borra Tabla [DEVOLUCIONES]
GO

IF OBJECT_ID ( '[ONEFORALL].[ITEMS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[ITEMS]								------Borra Tabla [ITEMS]
GO

IF OBJECT_ID ( '[ONEFORALL].[FACTURAS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[FACTURAS]							------Borra Tabla [FACTURAS]
GO
	
IF OBJECT_ID ( '[ONEFORALL].[PAGOS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[PAGOS]								------Borra Tabla [PAGOS]
GO

IF OBJECT_ID ( '[ONEFORALL].[RENDICIONES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[RENDICIONES]						------Borra Tabla [RENDICIONES]
GO

IF OBJECT_ID ( '[ONEFORALL].[EMPRESAS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[EMPRESAS]						------Borra Tabla [EMPRESAS]
GO

IF OBJECT_ID ( '[ONEFORALL].[USUARIO_X_SUCURSAL]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[USUARIO_X_SUCURSAL]				------Borra Tabla [USUARIO_X_SUCURSAL]
GO

IF OBJECT_ID ( '[ONEFORALL].[SUCURSALES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[SUCURSALES]						------Borra Tabla [SUCURSALES]
GO

IF OBJECT_ID ( '[ONEFORALL].[CLIENTES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[CLIENTES]						------Borra Tabla [CLIENTES]
GO

IF OBJECT_ID ( '[ONEFORALL].[RUBROS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[RUBROS]							------Borra Tabla [RUBROS]
GO

IF OBJECT_ID ( '[ONEFORALL].[DIRECCIONES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[DIRECCIONES]					------Borra Tabla [DIRECCIONES]
GO

IF OBJECT_ID ( '[ONEFORALL].[USUARIO_X_ROL]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[USUARIO_X_ROL]					------Borra Tabla [USUARIO_X_ROL]
GO

IF OBJECT_ID ( '[ONEFORALL].[USUARIOS]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[USUARIOS]						------Borra Tabla [USUARIOS]
GO

IF OBJECT_ID ( '[ONEFORALL].[ROL_X_FUNCIONALIDAD]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[ROL_X_FUNCIONALIDAD]			------Borra Tabla [ROL_X_FUNCIONALIDAD]
GO

IF OBJECT_ID ( '[ONEFORALL].[FUNCIONALIDADES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[FUNCIONALIDADES]				------Borra Tabla [FUNCIONALIDADES]
GO

IF OBJECT_ID ( '[ONEFORALL].[ROLES]', 'U' ) IS NOT NULL
	DROP TABLE [ONEFORALL].[ROLES]							------Borra Tabla [ROLES]
GO

----------------------------------------------------------------------------------------
------------------------CREO TABLA FUNCIONALIDADES--------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[FUNCIONALIDADES](
	[FUNC_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [FUNC_PRIMARY] PRIMARY KEY,
	[FUNC_DESCRIPCION] VARCHAR(100) NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
--------------------------------CREO TABLA ROLES----------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[ROLES](
	[ROL_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [ROL_PRIMARY] PRIMARY KEY,
	[ROL_NOMBRE] VARCHAR(45) NOT NULL,
	[ROL_ACTIVO] BIT NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
------------------------CREO TABLA ROL_X_FUNCIONALIDAD----------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[ROL_X_FUNCIONALIDAD](
	[FUNCX_ID] INT NOT NULL CONSTRAINT [FK_RXF_FUNCX_ID] REFERENCES [ONEFORALL].[FUNCIONALIDADES],
	[ROLX_ID] INT NOT NULL CONSTRAINT [FK_RXF_ROLX_ID] REFERENCES [ONEFORALL].[ROLES],
	CONSTRAINT [PK_Rol_X_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[FUNCX_ID] ASC,
	[ROLX_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
----------------------------------CREO TABLA RUBROS-------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[RUBROS](
	[RUB_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [RUB_PRIMARY] PRIMARY KEY,
	[RUB_DESCRIPCION] NVARCHAR(45) NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-------------------------------CREO TABLA DIRECCIONES-----------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[DIRECCIONES](
	[DIR_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [DIR_PRIMARY] PRIMARY KEY,
	[DIR_DIRECCION] NVARCHAR(255) NOT NULL,
	[DIR_CODIGO_POSTAL] CHAR(8) NOT NULL,
	[DIR_PISO] CHAR(2) NULL,
	[DIR_DEPARTAMENTO] CHAR(2) NULL,
	[DIR_LOCALIDAD] NVARCHAR(20) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
--------------------------------CREO TABLA USUARIOS-------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[USUARIOS](
	[USER_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [USER_PRIMARY] PRIMARY KEY,
	[USER_USUARIO] VARCHAR(255) NOT NULL CONSTRAINT UQ_USER_USUARIO UNIQUE,
	[USER_PASSWORD] VARCHAR(150) NOT NULL,
	[USER_ACTIVO] BIT NOT NULL,
	[USER_INTENTOS] TINYINT NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------CREO TABLA USUARIO_X_ROL-----------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[USUARIO_X_ROL](
	[USERX_ID] INT NOT NULL CONSTRAINT [FK_UXR_USERX_ID] REFERENCES [ONEFORALL].[USUARIOS],
	[ROLX_ID] INT NOT NULL CONSTRAINT [FK_UXR_ROLX_ID] REFERENCES [ONEFORALL].[ROLES],
	CONSTRAINT [PK_Usuario_X_Rol] PRIMARY KEY CLUSTERED 
	(
		[USERX_ID] ASC,
		[ROLX_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
------------------------------CREO TABLA CLIENTES---------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[CLIENTES](
	[CLIE_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [CLIE_PRIMARY] PRIMARY KEY,
	[CLIE_NOMBRE] NVARCHAR(255) NOT NULL,
	[CLIE_APELLIDO] NVARCHAR(255) NOT NULL,
	[CLIE_FECHA_NACIMIENTO] DATETIME NOT NULL,
	[CLIE_DIR_ID] INT NOT NULL CONSTRAINT FK_CLIE_DIR_ID REFERENCES [ONEFORALL].[DIRECCIONES] ,
	[CLIE_DNI] CHAR(8) NOT NULL,
	[CLIE_MAIL] NVARCHAR(255) NOT NULL,
	[CLIE_ACTIVO] BIT NOT NULL,
	[CLIE_TELEFONO] NVARCHAR(20) NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------CREO TABLA SUCURSALES--------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[SUCURSALES](
	[SUC_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [SUC_PRIMARY] PRIMARY KEY,
	[SUC_DIR_ID] INT NOT NULL CONSTRAINT FK_SUC_DIR_ID REFERENCES [ONEFORALL].[DIRECCIONES],
	[SUC_NOMBRE] NVARCHAR(45) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
----------------------------CREO TABLA USUARIO_X_SUCURSAL-------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[USUARIO_X_SUCURSAL](
	[USERX_ID] INT NOT NULL CONSTRAINT [FK_UXS_USERX_ID] REFERENCES [ONEFORALL].[USUARIOS],
	[SUCX_ID] INT NOT NULL CONSTRAINT [FK_UXS_SUCX_ID] REFERENCES [ONEFORALL].[SUCURSALES],
	CONSTRAINT [PK_Usuario_X_Sucursal] PRIMARY KEY CLUSTERED 
(
	[USERX_ID] ASC,
	[SUCX_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
-----------------------------CREO TABLA EMPRESAS----------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[EMPRESAS](
	[EMP_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [EMP_PRIMARY] PRIMARY KEY,
	[EMP_CUIT] NVARCHAR(50) NOT NULL,
	[EMP_NOMBRE] NVARCHAR(255) NOT NULL,
	[EMP_DIR_ID] INT NOT NULL CONSTRAINT FK_EMP_DIR_ID REFERENCES [ONEFORALL].[DIRECCIONES],
	[EMP_RUB_ID] INT NOT NULL CONSTRAINT FK_EMP_RUB_ID REFERENCES [ONEFORALL].[RUBROS],
	[EMP_ACTIVA] BIT NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------CREO TABLA RENDICIONES-------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[RENDICIONES](
	[REND_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [REND_PRIMARY] PRIMARY KEY,
	[REND_EMP_ID] INT NOT NULL CONSTRAINT FK_REND_EMP_ID REFERENCES [ONEFORALL].[EMPRESAS],
	[REND_TOTAL_RENDICION] NUMERIC(18,2) NOT NULL ,
	[REND_PORCENTAJE_COMISION] TINYINT NOT NULL,
	[REND_FECHA] DATETIME NOT NULL
)
GO	

----------------------------------------------------------------------------------------
--------------------------------CREO TABLA PAGOS----------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[PAGOS](
	[PAGO_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [PAGO_PRIMARY] PRIMARY KEY,
	[PAGO_FECHA_PAGO] DATETIME NOT NULL,
	[PAGO_TOTAL] NUMERIC(18,2) NOT NULL ,
	[PAGO_FORMA_PAGO] NVARCHAR(255) NOT NULL,
	[PAGO_CLIE_ID] INT NOT NULL CONSTRAINT FK_PAGO_CLIE_ID REFERENCES [ONEFORALL].[CLIENTES],
	[PAGO_USER_ID] INT NOT NULL CONSTRAINT FK_PAGO_USER_ID REFERENCES [ONEFORALL].[USUARIOS],
	[PAGO_SUC_ID] INT NOT NULL CONSTRAINT FK_PAGO_SUC_ID REFERENCES [ONEFORALL].[SUCURSALES]
)
GO	

----------------------------------------------------------------------------------------
-------------------------------CREO TABLA FACTURAS--------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[FACTURAS](
	[FACT_ID] NUMERIC(18,0) NOT NULL CONSTRAINT [FACT_PRIMARY] PRIMARY KEY,
	[FACT_CLIE_ID] INT NOT NULL CONSTRAINT FK_FACT_CLIE_ID REFERENCES [ONEFORALL].[CLIENTES],
	[FACT_EMP_ID] INT NOT NULL CONSTRAINT FK_FACT_EMP_ID REFERENCES [ONEFORALL].[EMPRESAS],
	[FACT_VENCIMIENTO] DATETIME NOT NULL,
	[FACT_ALTA] DATETIME NOT NULL,
	[FACT_REND_ID] NUMERIC(18,0) NULL CONSTRAINT FK_FACT_REND_ID REFERENCES [ONEFORALL].[RENDICIONES],
	[FACT_PAGO_ID] NUMERIC(18,0) NULL CONSTRAINT FK_FACT_PAGO_ID REFERENCES [ONEFORALL].[PAGOS],
	[FACT_TOTAL] NUMERIC (18,2) NOT NULL,
	[FACT_ACTIVA] BIT NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------CREO TABLA ITEMS-------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[ITEMS](
	[ITEM_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [ITEM_PRIMARY] PRIMARY KEY,
	[ITEM_FACT_ID] NUMERIC(18,0) NOT NULL CONSTRAINT FK_ITEM_FACT_ID REFERENCES [ONEFORALL].[FACTURAS],
	[ITEM_CANTIDAD] NUMERIC(18,0) NOT NULL,
	[ITEM_MONTO] NUMERIC(18,2) NOT NULL
)
GO

----------------------------------------------------------------------------------------
---------------------------------CREO TABLA DEVOLUCIONES--------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [ONEFORALL].[DEVOLUCIONES](
	[DEV_FACT_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [DEV_PRIMARY] PRIMARY KEY CONSTRAINT FK_DEV_FACT_ID REFERENCES [ONEFORALL].[FACTURAS],
	[DEV_DESCRIPCION] NVARCHAR(255) NOT NULL,
	[DEV_USER_ID] INT NOT NULL CONSTRAINT FK_DEV_USER_ID REFERENCES [ONEFORALL].[USUARIOS],
	[DEV_CLIE_ID] INT NOT NULL CONSTRAINT FK_DEV_CLIE_ID REFERENCES [ONEFORALL].[CLIENTES],
	[DEV_TIPO] VARCHAR(45) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------FIN CREACION TABLAS----------------------------------
----------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------
---------------------------------Borro VISTALISTARFACTURAS si existe--------------------
----------------------------------------------------------------------------------------
IF OBJECT_ID ( '[ONEFORALL].[VISTALISTARFACTURAS]', 'V' ) IS NOT NULL
	DROP VIEW [ONEFORALL].VISTALISTARFACTURAS
GO

----------------------------------------------------------------------------------------
---------------------------------CREO VISTA VISTALISTARFACTURAS ------------------------
----------------------------------------------------------------------------------------
CREATE VIEW [ONEFORALL].[VISTALISTARFACTURAS]
AS
SELECT        ONEFORALL.FACTURAS.FACT_ID, ONEFORALL.CLIENTES.CLIE_NOMBRE + N' ' + ONEFORALL.CLIENTES.CLIE_APELLIDO AS FACT_CLIE, ONEFORALL.EMPRESAS.EMP_NOMBRE AS FACT_EMP, 
                         ONEFORALL.FACTURAS.FACT_VENCIMIENTO, ONEFORALL.FACTURAS.FACT_ALTA, ONEFORALL.FACTURAS.FACT_REND_ID, ONEFORALL.FACTURAS.FACT_PAGO_ID, ONEFORALL.FACTURAS.FACT_TOTAL, ONEFORALL.FACTURAS.FACT_ACTIVA
FROM            ONEFORALL.CLIENTES INNER JOIN
                         ONEFORALL.FACTURAS ON ONEFORALL.CLIENTES.CLIE_ID = ONEFORALL.FACTURAS.FACT_CLIE_ID INNER JOIN
                         ONEFORALL.EMPRESAS ON ONEFORALL.FACTURAS.FACT_EMP_ID = ONEFORALL.EMPRESAS.EMP_ID
GO

----------------------------------------------------------------------------------------
---------------------------------Borro VW_SUCURSALES si existe--------------------------
----------------------------------------------------------------------------------------
IF OBJECT_ID ( '[ONEFORALL].[VW_SUCURSALES]', 'V' ) IS NOT NULL
	DROP VIEW [ONEFORALL].VW_SUCURSALES
GO

----------------------------------------------------------------------------------------
---------------------------------CREO VISTA [VW_SUCURSALES] ----------------------------
----------------------------------------------------------------------------------------
CREATE VIEW [ONEFORALL].[VW_SUCURSALES] 
	AS 
	SELECT s.SUC_NOMBRE AS NOMBRE,d.DIR_DIRECCION AS DIRECCION,d.DIR_CODIGO_POSTAL AS CP,d.DIR_LOCALIDAD AS LOCALIDAD
	FROM ONEFORALL.SUCURSALES s join ONEFORALL.DIRECCIONES d 
	ON s.SUC_DIR_ID = d.DIR_ID
go

DELETE FROM ONEFORALL.ROL_X_FUNCIONALIDAD	----VACIO TABLA ROL_X_FUNCIONALIDAD
GO
DELETE FROM ONEFORALL.FUNCIONALIDADES		----VACIO TABLA FUNCIONALIDADES
GO
DELETE FROM ONEFORALL.USUARIO_X_ROL			----VACIO TABLA USUARIO_X_ROL
GO
DELETE FROM ONEFORALL.ROLES					----VACIO TABLA ROLES
GO
DELETE FROM ONEFORALL.ITEMS					----VACIO TABLA ITEMS
GO
DELETE FROM ONEFORALL.FACTURAS				----VACIO TABLA FACTURAS
GO
delete from ONEFORALL.PAGOS					----VACIO TABLA PAGOS
GO
delete from ONEFORALL.USUARIOS				----VACIO TABLA USUARIOS
GO
delete from ONEFORALL.Rendiciones			----VACIO TABLA Rendiciones
GO
delete from ONEFORALL.EMPRESAS				----VACIO TABLA EMPRESAS
GO
delete from ONEFORALL.CLIENTES				----VACIO TABLA CLIENTES
GO
delete from ONEFORALL.SUCURSALES			----VACIO TABLA SUCURSALES
GO
delete from ONEFORALL.RUBROS				----VACIO TABLA RUBROS
GO
delete from ONEFORALL.DIRECCIONES			----VACIO TABLA DIRECCIONES
GO

DBCC CHECKIDENT('ONEFORALL.FUNCIONALIDADES', RESEED,1);		----RESETEA IDENTITY FUNCIONALIDADES
GO
DBCC CHECKIDENT('ONEFORALL.ROLES', RESEED,1);				----RESETEA IDENTITY ROLES
GO
DBCC CHECKIDENT('ONEFORALL.ITEMS', RESEED,1);				----RESETEA IDENTITY ITEMS
GO
DBCC CHECKIDENT ('ONEFORALL.PAGOS', RESEED,1);				----RESETEA IDENTITY PAGOS
GO
DBCC CHECKIDENT ('ONEFORALL.USUARIOS', RESEED,1);			----RESETEA IDENTITY USUARIOS
GO
DBCC CHECKIDENT ('ONEFORALL.RENDICIONES', RESEED,1);		----RESETEA IDENTITY RENDICIONES
GO	
DBCC CHECKIDENT ('ONEFORALL.EMPRESAS', RESEED,1);			----RESETEA IDENTITY EMPRESAS
GO
DBCC CHECKIDENT ('ONEFORALL.CLIENTES', RESEED,1);			----RESETEA IDENTITY CLIENTES
GO
DBCC CHECKIDENT ('ONEFORALL.SUCURSALES', RESEED,1);			----RESETEA IDENTITY SUCURSALES
GO
DBCC CHECKIDENT ('ONEFORALL.RUBROS', RESEED,1);				----RESETEA IDENTITY RUBROS
GO
DBCC CHECKIDENT ('ONEFORALL.DIRECCIONES', RESEED,1);		----RESETEA IDENTITY DIRECCIONES
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [DIRECCIONES]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.DIRECCIONES
(DIR_DIRECCION, DIR_CODIGO_POSTAL, DIR_LOCALIDAD)
	select distinct Cliente_Direccion, Cliente_Codigo_Postal,  'CABA'
	from gd_esquema.Maestra

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [DIRECCIONES]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.DIRECCIONES
select distinct Empresa_Direccion,1702 as CP, NULL, NULL, 'CABA' from gd_esquema.Maestra
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [DIRECCIONES]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.DIRECCIONES
(DIR_DIRECCION, DIR_CODIGO_POSTAL, DIR_LOCALIDAD)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal, 'CABA'
	from gd_esquema.Maestra
	where Sucursal_Codigo_Postal is not null
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [RUBROS]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.RUBROS
(RUB_DESCRIPCION)
	select distinct Rubro_descripcion
	from gd_esquema.Maestra
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [SUCURSALES]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.SUCURSALES
(SUC_NOMBRE, SUC_DIR_ID)
	select distinct Sucursal_Nombre, D.DIR_ID
	from gd_esquema.Maestra M 
	left join ONEFORALL.DIRECCIONES D 
		ON M.Sucursal_Dirección= D.DIR_DIRECCION
	where Sucursal_Nombre is not null
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [CLIENTES]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.CLIENTES
(CLIE_DNI, CLIE_APELLIDO, CLIE_NOMBRE, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_DIR_ID, CLIE_ACTIVO)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail,D.DIR_ID, 1
	from gd_esquema.Maestra M
	left join ONEFORALL.DIRECCIONES D 
		ON M.Cliente_Direccion= D.DIR_DIRECCION
		AND D.DIR_CODIGO_POSTAL = M.Cliente_Codigo_Postal
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [EMPRESAS]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.EMPRESAS
(EMP_CUIT, EMP_NOMBRE, EMP_DIR_ID, EMP_RUB_ID, EMP_ACTIVA)
	select distinct Empresa_Cuit, Empresa_Nombre, D.DIR_ID, R.RUB_ID, 1 as EMP_ACTIVA
	from gd_esquema.Maestra M
	left join ONEFORALL.DIRECCIONES D 
		ON M.Empresa_Direccion= D.DIR_DIRECCION
	left join ONEFORALL.RUBROS R 
		ON M.Rubro_Descripcion = R.RUB_DESCRIPCION
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [RENDICIONES]------------------------------
----------------------------------------------------------------------------------------
set identity_insert ONEFORALL.RENDICIONES on
insert into ONEFORALL.RENDICIONES
(REND_ID, REND_FECHA, REND_EMP_ID, REND_TOTAL_RENDICION, REND_PORCENTAJE_COMISION)
	select distinct Rendicion_Nro, Rendicion_Fecha, E.EMP_ID,
			sum(ItemRendicion_Importe)AS REND_TOTAL_RENDICION, --ANALIZAR SI ES CORRECTO EL SUM 
			CAST(ROUND((select top 1 ItemRendicion_Importe/Total from gd_esquema.Maestra  m2 where m2.Rendicion_Nro = M.Rendicion_Nro)*100, -1) as int)-- ANALIZAR
	from gd_esquema.Maestra M
	LEFT JOIN ONEFORALL.EMPRESAS E
	ON E.EMP_CUIT = M.Empresa_Cuit AND E.EMP_NOMBRE = M.Empresa_Nombre
	where M.Rendicion_Nro is not null
	group by Rendicion_Nro, Rendicion_Fecha,E.EMP_ID
	order by 1
set identity_insert ONEFORALL.RENDICIONES off
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [USUARIOS]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.USUARIOS
(USER_USUARIO, USER_PASSWORD, USER_ACTIVO, USER_INTENTOS)
values('admin', 'w23e', 1, 0)
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [ROLES]------------------------------
----------------------------------------------------------------------------------------
INSERT INTO ONEFORALL.ROLES
(ROL_NOMBRE, ROL_ACTIVO)
VALUES ('Administrador', 1), ('Cobrador', 1)

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [USUARIO_X_ROL]------------------------------
----------------------------------------------------------------------------------------
INSERT INTO ONEFORALL.USUARIO_X_ROL
(USERX_ID, ROLX_ID)
VALUES (1,1)

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [PAGOS]------------------------------
----------------------------------------------------------------------------------------
set identity_insert ONEFORALL.PAGOS on
insert into ONEFORALL.PAGOS
(PAGO_ID, PAGO_FECHA_PAGO, PAGO_CLIE_ID, PAGO_USER_ID, PAGO_FORMA_PAGO, PAGO_SUC_ID, PAGO_TOTAL)
	select distinct Pago_nro, Pago_Fecha,  c.CLIE_ID, u.USER_ID, FormaPagoDescripcion, s.SUC_ID, Total
	from gd_esquema.Maestra M
	join ONEFORALL.CLIENTES C on M.[Cliente-Dni] = c.CLIE_DNI
	join ONEFORALL.SUCURSALES S on M.Sucursal_Nombre = S.SUC_NOMBRE
	join ONEFORALL.USUARIOS U on 1 = 1
set identity_insert ONEFORALL.PAGOS off
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [FACTURAS]------------------------------
----------------------------------------------------------------------------------------
insert into ONEFORALL.FACTURAS
(FACT_ID, FACT_ALTA, FACT_VENCIMIENTO, FACT_CLIE_ID, FACT_REND_ID, FACT_PAGO_ID, FACT_TOTAL, FACT_EMP_ID, FACT_ACTIVA)
	select distinct Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, C.CLIE_ID, MAX(Rendicion_Nro), MAX(Pago_nro), Factura_Total, E.EMP_ID, 1
	from gd_esquema.Maestra M 
	join ONEFORALL.CLIENTES C on M.[Cliente-Dni] = C.CLIE_DNI
	join ONEFORALL.EMPRESAS E ON M.Empresa_Cuit = E.EMP_CUIT AND M.Empresa_Nombre = E.EMP_NOMBRE
	GROUP BY Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, C.CLIE_ID, Factura_Total, e.EMP_ID
	ORDER BY 1 ASC
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [ITEMS]------------------------------
----------------------------------------------------------------------------------------
INSERT INTO ONEFORALL.ITEMS
(ITEM_FACT_ID, ITEM_CANTIDAD, ITEM_MONTO)
	SELECT DISTINCT Nro_Factura, ItemFactura_Cantidad, ItemFactura_Monto FROM gd_esquema.Maestra
	ORDER BY 1 ASC
GO

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [FUNCIONALIDADES]------------------------------
----------------------------------------------------------------------------------------
INSERT INTO ONEFORALL.FUNCIONALIDADES
(FUNC_DESCRIPCION)
VALUES ('Administrar'), ('Cobrar')

----------------------------------------------------------------------------------------
---------------------------------CARGO TABLA [ROL_X_FUNCIONALIDAD]------------------------------
----------------------------------------------------------------------------------------
INSERT INTO ONEFORALL.ROL_X_FUNCIONALIDAD
(ROLX_ID, FUNCX_ID)
VALUES (1,1), (2,2)
