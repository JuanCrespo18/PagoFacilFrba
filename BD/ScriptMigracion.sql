delete from ONEFORALL.Rendiciones 
GO
delete from ONEFORALL.EMPRESAS 
GO
delete from ONEFORALL.CLIENTES 
GO
delete from ONEFORALL.SUCURSALES 
GO
delete from ONEFORALL.RUBROS 
GO
delete from ONEFORALL.DIRECCIONES 
GO

DBCC CHECKIDENT ('ONEFORALL.RENDICIONES', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.EMPRESAS', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.CLIENTES', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.SUCURSALES', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.RUBROS', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.DIRECCIONES', RESEED, 0);
GO


insert into ONEFORALL.DIRECCIONES
(DIR_DIRECCION, DIR_CODIGO_POSTAL)
	select distinct Cliente_Direccion, Cliente_Codigo_Postal
	from ONEFORALL.Maestra

insert into ONEFORALL.DIRECCIONES
values ((select distinct Empresa_Direccion from ONEFORALL.Maestra), 1416)
GO

insert into ONEFORALL.DIRECCIONES
(DIR_DIRECCION, DIR_CODIGO_POSTAL)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal
	from ONEFORALL.Maestra
	where Sucursal_Codigo_Postal is not null
GO

insert into ONEFORALL.RUBROS
(RUB_DESCRIPCION)
	select distinct Rubro_descripcion
	from ONEFORALL.Maestra
GO

insert into ONEFORALL.SUCURSALES
(SUC_NOMBRE, SUC_DIR_ID)
	select distinct Sucursal_Nombre, 
			(select DIR_ID from ONEFORALL.DIRECCIONES
			where DIR_DIRECCION = Sucursal_Dirección
			and DIR_CODIGO_POSTAL = Sucursal_Codigo_Postal)
	from ONEFORALL.Maestra
	where Sucursal_Nombre is not null
GO

insert into ONEFORALL.CLIENTES
(CLIE_DNI, CLIE_APELLIDO, CLIE_NOMBRE, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_DIR_ID)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail, 
		(select DIR_ID from ONEFORALL.DIRECCIONES
		where DIR_DIRECCION = Cliente_Direccion
		and DIR_CODIGO_POSTAL = Cliente_Codigo_Postal)
	from ONEFORALL.Maestra
GO

insert into ONEFORALL.EMPRESAS
(EMP_CUIT, EMP_NOMBRE, EMP_DIR_ID, EMP_RUB_ID, EMP_ACTIVA)
	select distinct Empresa_Cuit, Empresa_Nombre, 
		(select DIR_ID from ONEFORALL.DIRECCIONES
		where DIR_DIRECCION = Empresa_Direccion),
		(select RUB_ID from ONEFORALL.RUBROS
		where RUB_DESCRIPCION = Rubro_Descripcion), 1
	from ONEFORALL.Maestra
GO


SET IDENTITY_INSERT ONEFORALL.Rendiciones ON
insert into ONEFORALL.RENDICIONES
(REND_ID, REND_FECHA, REND_EMP_ID, REND_TOTAL_RENDICION, REND_PORCENTAJE_COMISION)
	select distinct Rendicion_Nro, Rendicion_Fecha, 
		(select EMP_ID from ONEFORALL.EMPRESAS where EMP_CUIT = Empresa_Cuit and EMP_NOMBRE = Empresa_Nombre),
		sum(ItemRendicion_Importe), 
		CAST(ROUND((select top 1 ItemRendicion_Importe/Total from ONEFORALL.Maestra  m2 where m2.Rendicion_Nro = m1.Rendicion_Nro)*100, -1) as int)
	from ONEFORALL.Maestra m1
	where m1.Rendicion_Nro is not null
	group by Rendicion_Nro, Rendicion_Fecha, Empresa_Cuit, Empresa_Nombre
	order by 1
SET IDENTITY_INSERT ONEFORALL.Rendiciones OFF
GO