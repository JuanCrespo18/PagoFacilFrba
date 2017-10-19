----------------------------------------------------------------------------------------
-----------------------------------BORRAR TABLAS----------------------------------------
----------------------------------------------------------------------------------------
IF OBJECT_ID ( '[gd_esquema].[DEVOLUCIONES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[DEVOLUCIONES]
GO

IF OBJECT_ID ( '[gd_esquema].[ITEMS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[ITEMS]
GO

IF OBJECT_ID ( '[gd_esquema].[FACTURAS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[FACTURAS]
GO
	
IF OBJECT_ID ( '[gd_esquema].[PAGOS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[PAGOS]
GO

IF OBJECT_ID ( '[gd_esquema].[RENDICIONES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[RENDICIONES]
GO

IF OBJECT_ID ( '[gd_esquema].[EMPRESAS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[EMPRESAS]
GO

IF OBJECT_ID ( '[gd_esquema].[USUARIO_X_SUCURSAL]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[USUARIO_X_SUCURSAL]
GO

IF OBJECT_ID ( '[gd_esquema].[SUCURSALES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[SUCURSALES]
GO

IF OBJECT_ID ( '[gd_esquema].[CLIENTES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[CLIENTES]
GO

IF OBJECT_ID ( '[gd_esquema].[RUBROS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[RUBROS]
GO

IF OBJECT_ID ( '[gd_esquema].[DIRECCIONES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[DIRECCIONES]
GO

IF OBJECT_ID ( '[gd_esquema].[USUARIO_X_ROL]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[USUARIO_X_ROL]
GO

IF OBJECT_ID ( '[gd_esquema].[USUARIOS]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[USUARIOS]
GO

IF OBJECT_ID ( '[gd_esquema].[ROL_X_FUNCIONALIDAD]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[ROL_X_FUNCIONALIDAD]
GO

IF OBJECT_ID ( '[gd_esquema].[FUNCIONALIDADES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[FUNCIONALIDADES]
GO

IF OBJECT_ID ( '[gd_esquema].[ROLES]', 'U' ) IS NOT NULL
	DROP TABLE [gd_esquema].[ROLES]
GO

----------------------------------------------------------------------------------------
-----------------------------------FUNCIONALIDADES--------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[FUNCIONALIDADES](
	[FUNC_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [FUNC_PRIMARY] PRIMARY KEY,
	[FUNC_DESCRIPCION] VARCHAR(100) NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------ROLES------------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[ROLES](
	[ROL_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [ROL_PRIMARY] PRIMARY KEY,
	[ROL_NOMBRE] VARCHAR(45) NOT NULL,
	[ROL_ACTIVO] BIT NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------ROL_X_FUNCIONALIDAD----------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[ROL_X_FUNCIONALIDAD](
	[FUNCX_ID] INT NOT NULL CONSTRAINT [FK_RXF_FUNCX_ID] REFERENCES [gd_esquema].[FUNCIONALIDADES],
	[ROLX_ID] INT NOT NULL CONSTRAINT [FK_RXF_ROLX_ID] REFERENCES [gd_esquema].[ROLES],
	CONSTRAINT [PK_Rol_X_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[FUNCX_ID] ASC,
	[ROLX_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
-----------------------------------RUBROS-----------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[RUBROS](
	[RUB_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [RUB_PRIMARY] PRIMARY KEY,
	[RUB_DESCRIPCION] NVARCHAR(45) NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------DIRECCIONES--------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[DIRECCIONES](
	[DIR_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [DIR_PRIMARY] PRIMARY KEY,
	[DIR_DIRECCION] NVARCHAR(255) NOT NULL,
	[DIR_CODIGO_POSTAL] NVARCHAR(255) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------USUARIOS---------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[USUARIOS](
	[USER_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [USER_PRIMARY] PRIMARY KEY,
	[USER_USUARIO] VARCHAR(255) NOT NULL CONSTRAINT UQ_USER_USUARIO UNIQUE,
	[USER_PASSWORD] VARCHAR(150) NOT NULL,
	[USER_ACTIVO] BIT NOT NULL,
	[USER_INTENTOS] TINYINT NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------USUARIO_X_ROL----------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[USUARIO_X_ROL](
	[USERX_ID] INT NOT NULL CONSTRAINT [FK_UXR_USERX_ID] REFERENCES [gd_esquema].[USUARIOS],
	[ROLX_ID] INT NOT NULL CONSTRAINT [FK_UXR_ROLX_ID] REFERENCES [gd_esquema].[ROLES],
	CONSTRAINT [PK_Usuario_X_Rol] PRIMARY KEY CLUSTERED 
	(
		[USERX_ID] ASC,
		[ROLX_ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
-----------------------------------CLIENTES---------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[CLIENTES](
	[CLIE_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [CLIE_PRIMARY] PRIMARY KEY,
	[CLIE_NOMBRE] NVARCHAR(255) NOT NULL,
	[CLIE_APELLIDO] NVARCHAR(255) NOT NULL,
	[CLIE_FECHA_NACIMIENTO] DATETIME NOT NULL,
	[CLIE_DIR_ID] INT NOT NULL CONSTRAINT FK_CLIE_DIR_ID REFERENCES [gd_esquema].[DIRECCIONES] ,
	[CLIE_DNI] CHAR(8) NOT NULL,
	[CLIE_MAIL] NVARCHAR(255) NOT NULL,
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------SUCURSALES-------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[SUCURSALES](
	[SUC_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [SUC_PRIMARY] PRIMARY KEY,
	[SUC_DIR_ID] INT NOT NULL CONSTRAINT FK_SUC_DIR_ID REFERENCES [gd_esquema].[DIRECCIONES],
	[SUC_NOMBRE] NVARCHAR(45) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------USUARIO_X_SUCURSAL-----------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[USUARIO_X_SUCURSAL](
	[USERX_ID] INT NOT NULL CONSTRAINT [FK_UXS_USERX_ID] REFERENCES [gd_esquema].[USUARIOS],
	[SUCX_ID] INT NOT NULL CONSTRAINT [FK_UXS_SUCX_ID] REFERENCES [gd_esquema].[SUCURSALES],
	CONSTRAINT [PK_Usuario_X_Sucursal] PRIMARY KEY CLUSTERED 
(
	[USERX_ID] ASC,
	[SUCX_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------
-----------------------------------EMPRESAS---------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[EMPRESAS](
	[EMP_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [EMP_PRIMARY] PRIMARY KEY,
	[EMP_CUIT] NVARCHAR(50) NOT NULL,
	[EMP_NOMBRE] NVARCHAR(255) NOT NULL,
	[EMP_DIR_ID] INT NOT NULL CONSTRAINT FK_EMP_DIR_ID REFERENCES [gd_esquema].[DIRECCIONES],
	[EMP_RUB_ID] INT NOT NULL CONSTRAINT FK_EMP_RUB_ID REFERENCES [gd_esquema].[RUBROS],
	[EMP_ACTIVA] BIT NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------RENDICIONES------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[RENDICIONES](
	[REND_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [REND_PRIMARY] PRIMARY KEY,
	[REND_EMP_ID] INT NOT NULL CONSTRAINT FK_REND_EMP_ID REFERENCES [gd_esquema].[EMPRESAS],
	[REND_TOTAL_RENDICION] NUMERIC(18,2) NOT NULL ,
	[REND_PORCENTAJE_COMISION] TINYINT NOT NULL,
	[REND_FECHA] DATETIME NOT NULL
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------PAGOS------------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[PAGOS](
	[PAGO_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [PAGO_PRIMARY] PRIMARY KEY,
	[PAGO_FECHA_PAGO] DATETIME NOT NULL,
	[PAGO_TOTAL] NUMERIC(18,2) NOT NULL ,
	[PAGO_FORMA_PAGO] NVARCHAR(255) NOT NULL,
	[PAGO_CLIE_ID] INT NOT NULL CONSTRAINT FK_PAGO_CLIE_ID REFERENCES [gd_esquema].[CLIENTES],
	[PAGO_USER_ID] INT NOT NULL CONSTRAINT FK_PAGO_USER_ID REFERENCES [gd_esquema].[USUARIOS],
	[PAGO_SUC_ID] INT NOT NULL CONSTRAINT FK_PAGO_SUC_ID REFERENCES [gd_esquema].[SUCURSALES]
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------FACTURAS---------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[FACTURAS](
	[FACT_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [FACT_PRIMARY] PRIMARY KEY,
	[FACT_CLIE_ID] INT NOT NULL CONSTRAINT FK_FACT_CLIE_ID REFERENCES [gd_esquema].[CLIENTES],
	[FACT_VENCIMIENTO] DATETIME NOT NULL,
	[FACT_ALTA] DATETIME NOT NULL,
	[FACT_REND_ID] NUMERIC(18,0) NULL CONSTRAINT FK_FACT_REND_ID REFERENCES [gd_esquema].[RENDICIONES],
	[PAGO_PAGO_ID] NUMERIC(18,0) NOT NULL CONSTRAINT FK_FACT_PAGO_ID REFERENCES [gd_esquema].[PAGOS],
)
GO	

----------------------------------------------------------------------------------------
-----------------------------------ITEMS------------------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[ITEMS](
	[ITEM_ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT [ITEM_PRIMARY] PRIMARY KEY,
	[ITEM_FACT_ID] NUMERIC(18,0) NOT NULL CONSTRAINT FK_ITEM_FACT_ID REFERENCES [gd_esquema].[FACTURAS],
	[ITEM_CANTIDAD] NUMERIC(18,0) NOT NULL,
	[ITEM_MONTO] NUMERIC(18,2) NOT NULL
)
GO

----------------------------------------------------------------------------------------
-----------------------------------DEVOLUCIONES-----------------------------------------
----------------------------------------------------------------------------------------
CREATE TABLE [gd_esquema].[DEVOLUCIONES](
	[DEV_FACT_ID] NUMERIC(18,0) IDENTITY(1,1) NOT NULL CONSTRAINT [DEV_PRIMARY] PRIMARY KEY CONSTRAINT FK_DEV_FACT_ID REFERENCES [gd_esquema].[FACTURAS],
	[DEV_DESCRIPCION] NVARCHAR(255) NOT NULL,
	[DEV_USER_ID] INT NOT NULL CONSTRAINT FK_DEV_USER_ID REFERENCES [gd_esquema].[USUARIOS],
	[DEV_CLIE_ID] INT NOT NULL CONSTRAINT FK_DEV_CLIE_ID REFERENCES [gd_esquema].[CLIENTES],
	[DEV_TIPO] VARCHAR(45) NOT NULL
)
GO	

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
