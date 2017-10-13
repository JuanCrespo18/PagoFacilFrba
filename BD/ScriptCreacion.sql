/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [GD2C2017]
GO
/****** Object:  Table [gd_esquema].[Clientes]    Script Date: 12/10/2017 22:31:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[direccion] [int] NOT NULL,
	[dni] [int] NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Devoluciones]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Devoluciones](
	[factura] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[usuario] [int] NOT NULL,
	[cliente] [int] NOT NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Devoluciones] PRIMARY KEY CLUSTERED 
(
	[factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Direcciones]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Direcciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[codigo_postal] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Direcciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Empresas]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Empresas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cuit] [bigint] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [int] NOT NULL,
	[rubro] [int] NOT NULL,
	[activa] [bit] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Facturas]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Facturas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [int] NOT NULL,
	[vencimiento] [date] NOT NULL,
	[alta] [date] NOT NULL,
	[rendicion] [int] NULL,
	[pago] [int] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Funcionalidades]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Funcionalidades](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Items]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NOT NULL,
	[monto] [decimal](10, 2) NOT NULL,
	[factura] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Pagos]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Pagos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_pago] [date] NOT NULL,
	[cliente] [int] NOT NULL,
	[usuario] [int] NOT NULL,
	[sucursal] [int] NOT NULL,
	[total] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Rendiciones]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Rendiciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[empresa] [int] NOT NULL,
	[total_rendicion] [decimal](10, 2) NOT NULL,
	[porcentaje_comision] [tinyint] NOT NULL,
	[fecha_rendicion] [date] NOT NULL,
 CONSTRAINT [PK_Rendiciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Rol_X_Funcionalidad]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Rol_X_Funcionalidad](
	[id_rol] [int] NOT NULL,
	[id_funcionalidad] [int] NOT NULL,
 CONSTRAINT [PK_Rol_X_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_funcionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Roles]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Rubros]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Rubros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rubros] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Sucursales]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Sucursales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[direccion] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Usuario_X_Rol]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Usuario_X_Rol](
	[id_usuario] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_X_Rol] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Usuario_X_Sucursal]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Usuario_X_Sucursal](
	[id_usuario] [int] NOT NULL,
	[id_sucursal] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_X_Sucursal] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC,
	[id_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [gd_esquema].[Usuarios]    Script Date: 12/10/2017 22:31:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [gd_esquema].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NOT NULL,
	[contrasenia] [varchar](50) NULL,
	[activo] [bit] NOT NULL,
	[intentos] [tinyint] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [gd_esquema].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Direcciones] FOREIGN KEY([direccion])
REFERENCES [gd_esquema].[Direcciones] ([id])
GO
ALTER TABLE [gd_esquema].[Clientes] CHECK CONSTRAINT [FK_Clientes_Direcciones]
GO
ALTER TABLE [gd_esquema].[Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Devoluciones_Clientes] FOREIGN KEY([cliente])
REFERENCES [gd_esquema].[Clientes] ([id])
GO
ALTER TABLE [gd_esquema].[Devoluciones] CHECK CONSTRAINT [FK_Devoluciones_Clientes]
GO
ALTER TABLE [gd_esquema].[Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Devoluciones_Facturas] FOREIGN KEY([factura])
REFERENCES [gd_esquema].[Facturas] ([id])
GO
ALTER TABLE [gd_esquema].[Devoluciones] CHECK CONSTRAINT [FK_Devoluciones_Facturas]
GO
ALTER TABLE [gd_esquema].[Devoluciones]  WITH CHECK ADD  CONSTRAINT [FK_Devoluciones_Usuarios] FOREIGN KEY([usuario])
REFERENCES [gd_esquema].[Usuarios] ([id])
GO
ALTER TABLE [gd_esquema].[Devoluciones] CHECK CONSTRAINT [FK_Devoluciones_Usuarios]
GO
ALTER TABLE [gd_esquema].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Direcciones] FOREIGN KEY([direccion])
REFERENCES [gd_esquema].[Direcciones] ([id])
GO
ALTER TABLE [gd_esquema].[Empresas] CHECK CONSTRAINT [FK_Empresas_Direcciones]
GO
ALTER TABLE [gd_esquema].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Empresas_Rubros] FOREIGN KEY([rubro])
REFERENCES [gd_esquema].[Rubros] ([id])
GO
ALTER TABLE [gd_esquema].[Empresas] CHECK CONSTRAINT [FK_Empresas_Rubros]
GO
ALTER TABLE [gd_esquema].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY([cliente])
REFERENCES [gd_esquema].[Clientes] ([id])
GO
ALTER TABLE [gd_esquema].[Facturas] CHECK CONSTRAINT [FK_Facturas_Clientes]
GO
ALTER TABLE [gd_esquema].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Pagos] FOREIGN KEY([pago])
REFERENCES [gd_esquema].[Pagos] ([id])
GO
ALTER TABLE [gd_esquema].[Facturas] CHECK CONSTRAINT [FK_Facturas_Pagos]
GO
ALTER TABLE [gd_esquema].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Rendiciones] FOREIGN KEY([rendicion])
REFERENCES [gd_esquema].[Rendiciones] ([id])
GO
ALTER TABLE [gd_esquema].[Facturas] CHECK CONSTRAINT [FK_Facturas_Rendiciones]
GO
ALTER TABLE [gd_esquema].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Facturas] FOREIGN KEY([factura])
REFERENCES [gd_esquema].[Facturas] ([id])
GO
ALTER TABLE [gd_esquema].[Items] CHECK CONSTRAINT [FK_Items_Facturas]
GO
ALTER TABLE [gd_esquema].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Clientes] FOREIGN KEY([cliente])
REFERENCES [gd_esquema].[Clientes] ([id])
GO
ALTER TABLE [gd_esquema].[Pagos] CHECK CONSTRAINT [FK_Pagos_Clientes]
GO
ALTER TABLE [gd_esquema].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Sucursales] FOREIGN KEY([sucursal])
REFERENCES [gd_esquema].[Sucursales] ([id])
GO
ALTER TABLE [gd_esquema].[Pagos] CHECK CONSTRAINT [FK_Pagos_Sucursales]
GO
ALTER TABLE [gd_esquema].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Usuarios] FOREIGN KEY([usuario])
REFERENCES [gd_esquema].[Usuarios] ([id])
GO
ALTER TABLE [gd_esquema].[Pagos] CHECK CONSTRAINT [FK_Pagos_Usuarios]
GO
ALTER TABLE [gd_esquema].[Rendiciones]  WITH CHECK ADD  CONSTRAINT [FK_Rendiciones_Empresas] FOREIGN KEY([empresa])
REFERENCES [gd_esquema].[Empresas] ([id])
GO
ALTER TABLE [gd_esquema].[Rendiciones] CHECK CONSTRAINT [FK_Rendiciones_Empresas]
GO
ALTER TABLE [gd_esquema].[Rol_X_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_X_Funcionalidad_Funcionalidades] FOREIGN KEY([id_funcionalidad])
REFERENCES [gd_esquema].[Funcionalidades] ([id])
GO
ALTER TABLE [gd_esquema].[Rol_X_Funcionalidad] CHECK CONSTRAINT [FK_Rol_X_Funcionalidad_Funcionalidades]
GO
ALTER TABLE [gd_esquema].[Rol_X_Funcionalidad]  WITH CHECK ADD  CONSTRAINT [FK_Rol_X_Funcionalidad_Roles] FOREIGN KEY([id_rol])
REFERENCES [gd_esquema].[Roles] ([id])
GO
ALTER TABLE [gd_esquema].[Rol_X_Funcionalidad] CHECK CONSTRAINT [FK_Rol_X_Funcionalidad_Roles]
GO
ALTER TABLE [gd_esquema].[Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_Sucursales_Direcciones] FOREIGN KEY([direccion])
REFERENCES [gd_esquema].[Direcciones] ([id])
GO
ALTER TABLE [gd_esquema].[Sucursales] CHECK CONSTRAINT [FK_Sucursales_Direcciones]
GO
ALTER TABLE [gd_esquema].[Usuario_X_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_X_Rol_Roles] FOREIGN KEY([id_rol])
REFERENCES [gd_esquema].[Roles] ([id])
GO
ALTER TABLE [gd_esquema].[Usuario_X_Rol] CHECK CONSTRAINT [FK_Usuario_X_Rol_Roles]
GO
ALTER TABLE [gd_esquema].[Usuario_X_Rol]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_X_Rol_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [gd_esquema].[Usuarios] ([id])
GO
ALTER TABLE [gd_esquema].[Usuario_X_Rol] CHECK CONSTRAINT [FK_Usuario_X_Rol_Usuarios]
GO
ALTER TABLE [gd_esquema].[Usuario_X_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_X_Sucursal_Sucursales] FOREIGN KEY([id_sucursal])
REFERENCES [gd_esquema].[Sucursales] ([id])
GO
ALTER TABLE [gd_esquema].[Usuario_X_Sucursal] CHECK CONSTRAINT [FK_Usuario_X_Sucursal_Sucursales]
GO
ALTER TABLE [gd_esquema].[Usuario_X_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_X_Sucursal_Usuarios] FOREIGN KEY([id_usuario])
REFERENCES [gd_esquema].[Usuarios] ([id])
GO
ALTER TABLE [gd_esquema].[Usuario_X_Sucursal] CHECK CONSTRAINT [FK_Usuario_X_Sucursal_Usuarios]
GO
