delete from gd_esquema.Rendiciones 
GO
delete from gd_esquema.Empresas 
GO
delete from gd_esquema.Clientes 
GO
delete from gd_esquema.Sucursales 
GO
delete from gd_esquema.Rubros 
GO
delete from gd_esquema.Direcciones 
GO

DBCC CHECKIDENT ('gd_esquema.Rendiciones', RESEED, 0);
GO
DBCC CHECKIDENT ('gd_esquema.Empresas', RESEED, 0);
GO
DBCC CHECKIDENT ('gd_esquema.Clientes', RESEED, 0);
GO
DBCC CHECKIDENT ('gd_esquema.Sucursales', RESEED, 0);
GO
DBCC CHECKIDENT ('gd_esquema.Rubros', RESEED, 0);
GO
DBCC CHECKIDENT ('gd_esquema.Direcciones', RESEED, 0);
GO


insert into gd_esquema.Direcciones
(DIR_DIRECCION, DIR_CODIGO_POSTAL)
	select distinct Cliente_Direccion, Cliente_Codigo_Postal
	from gd_esquema.Maestra

insert into gd_esquema.Direcciones
values ((select distinct Empresa_Direccion from gd_esquema.Maestra), 1416)
GO

insert into gd_esquema.Direcciones
(DIR_DIRECCION, DIR_CODIGO_POSTAL)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal
	from gd_esquema.Maestra
	where Sucursal_Codigo_Postal is not null
GO

insert into gd_esquema.Rubros
(RUB_DESCRIPCION)
	select distinct Rubro_descripcion
	from gd_esquema.Maestra
GO

insert into gd_esquema.Sucursales
(SUC_NOMBRE, SUC_DIR_ID)
	select distinct Sucursal_Nombre, 
			(select DIR_ID from gd_esquema.Direcciones
			where DIR_DIRECCION = Sucursal_Dirección
			and DIR_CODIGO_POSTAL = Sucursal_Codigo_Postal)
	from gd_esquema.Maestra
	where Sucursal_Nombre is not null
GO

insert into gd_esquema.Clientes
(CLIE_DNI, CLIE_APELLIDO, CLIE_NOMBRE, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_DIR_ID)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail, 
		(select DIR_ID from gd_esquema.Direcciones
		where DIR_DIRECCION = Cliente_Direccion
		and DIR_CODIGO_POSTAL = Cliente_Codigo_Postal)
	from gd_esquema.Maestra
GO

insert into gd_esquema.Empresas
(EMP_CUIT, EMP_NOMBRE, EMP_DIR_ID, EMP_RUB_ID, EMP_ACTIVA)
	select distinct Empresa_Cuit, Empresa_Nombre, 
		(select DIR_ID from gd_esquema.Direcciones
		where DIR_DIRECCION = Empresa_Direccion),
		(select RUB_ID from gd_esquema.Rubros
		where RUB_DESCRIPCION = Rubro_Descripcion), 1
	from gd_esquema.Maestra
GO


SET IDENTITY_INSERT gd_esquema.Rendiciones ON
insert into gd_esquema.Rendiciones
(REND_ID, REND_FECHA, REND_EMP_ID, REND_TOTAL_RENDICION, REND_PORCENTAJE_COMISION)
	select distinct Rendicion_Nro, Rendicion_Fecha, 
		(select EMP_ID from gd_esquema.Empresas where EMP_CUIT = Empresa_Cuit and EMP_NOMBRE = Empresa_Nombre),
		sum(ItemRendicion_Importe), 
		CAST(ROUND((select top 1 ItemRendicion_Importe/Total from gd_esquema.Maestra  m2 where m2.Rendicion_Nro = m1.Rendicion_Nro)*100, -1) as int)
	from gd_esquema.Maestra m1
	where m1.Rendicion_Nro is not null
	group by Rendicion_Nro, Rendicion_Fecha, Empresa_Cuit, Empresa_Nombre
	order by 1
SET IDENTITY_INSERT gd_esquema.Rendiciones OFF
GO