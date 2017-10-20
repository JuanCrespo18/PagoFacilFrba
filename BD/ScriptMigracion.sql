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
	from gd_esquema.Maestra

insert into ONEFORALL.DIRECCIONES
select distinct Empresa_Direccion,1702 as CP  from gd_esquema.Maestra
GO

insert into ONEFORALL.DIRECCIONES
(DIR_DIRECCION, DIR_CODIGO_POSTAL)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal
	from gd_esquema.Maestra
	where Sucursal_Codigo_Postal is not null
GO

insert into ONEFORALL.RUBROS
(RUB_DESCRIPCION)
	select distinct Rubro_descripcion
	from gd_esquema.Maestra
GO

insert into ONEFORALL.SUCURSALES
(SUC_NOMBRE, SUC_DIR_ID)
	select distinct Sucursal_Nombre, B.DIR_ID
	from gd_esquema.Maestra A 
	left join ONEFORALL.DIRECCIONES B 
		ON A.Sucursal_Dirección= B.DIR_DIRECCION
	where Sucursal_Nombre is not null
GO

insert into ONEFORALL.CLIENTES
(CLIE_DNI, CLIE_APELLIDO, CLIE_NOMBRE, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_DIR_ID)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail,B.DIR_ID
	from gd_esquema.Maestra A
	left join ONEFORALL.DIRECCIONES B 
		ON A.Cliente_Direccion= B.DIR_DIRECCION
		AND B.DIR_CODIGO_POSTAL = A.Cliente_Codigo_Postal
GO
 
insert into ONEFORALL.EMPRESAS
(EMP_CUIT, EMP_NOMBRE, EMP_DIR_ID, EMP_RUB_ID, EMP_ACTIVA)
	select distinct Empresa_Cuit, Empresa_Nombre, B.DIR_ID, C.RUB_ID, 1 as EMP_ACTIVA
	from gd_esquema.Maestra A
	left join ONEFORALL.DIRECCIONES B 
		ON A.Empresa_Direccion= B.DIR_DIRECCION
	left join ONEFORALL.RUBROS C 
		ON a.Rubro_Descripcion = C.RUB_DESCRIPCION
GO


insert into ONEFORALL.RENDICIONES
(REND_ID, REND_FECHA, REND_EMP_ID, REND_TOTAL_RENDICION, REND_PORCENTAJE_COMISION)
	select distinct Rendicion_Nro, Rendicion_Fecha, B.EMP_ID,
			sum(ItemRendicion_Importe)AS REND_TOTAL_RENDICION, --ANALIZAR SI ES CORRECTO EL SUM 
			CAST(ROUND((select top 1 ItemRendicion_Importe/Total from gd_esquema.Maestra  m2 where m2.Rendicion_Nro = A.Rendicion_Nro)*100, -1) as int)-- ANALIZAR
	from gd_esquema.Maestra A
	LEFT JOIN ONEFORALL.EMPRESAS B
	ON B.EMP_CUIT = A.Empresa_Cuit AND B.EMP_NOMBRE = A.Empresa_Nombre
	where A.Rendicion_Nro is not null
	group by Rendicion_Nro, Rendicion_Fecha,B.EMP_ID
	order by 1
GO