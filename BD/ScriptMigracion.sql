insert into gd_esquema.Direcciones
(direccion, codigo_postal)
	select distinct Cliente_Direccion, Cliente_Codigo_Postal
	from gd_esquema.Maestra

insert into gd_esquema.Direcciones
values ((select distinct Empresa_Direccion from gd_esquema.Maestra), 1416)
GO

insert into gd_esquema.Direcciones
(direccion, codigo_postal)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal
	from gd_esquema.Maestra
	where Sucursal_Codigo_Postal is not null
GO

insert into gd_esquema.Rubros
(descripcion)
	select distinct Rubro_descripcion
	from gd_esquema.Maestra
GO

insert into gd_esquema.Sucursales
(nombre, direccion)
	select distinct Sucursal_Nombre, 
			(select id from gd_esquema.Direcciones
			where direccion = Sucursal_Dirección
			and codigo_postal = Sucursal_Codigo_Postal)
	from gd_esquema.Maestra
	where Sucursal_Nombre is not null
GO

insert into gd_esquema.Clientes
(dni, apellido, nombre, fecha_nacimiento, mail, direccion)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail, 
		(select id from gd_esquema.Direcciones
		where direccion = Cliente_Direccion
		and codigo_postal = Cliente_Codigo_Postal)
	from gd_esquema.Maestra
GO

insert into gd_esquema.Empresas
(cuit, nombre, direccion, rubro, activa)
	select distinct Empresa_Cuit, Empresa_Nombre, 
		(select id from gd_esquema.Direcciones
		where direccion = Empresa_Direccion),
		(select id from gd_esquema.Rubros
		where descripcion = Rubro_Descripcion), 1
	from gd_esquema.Maestra
GO


SET IDENTITY_INSERT gd_esquema.Rendiciones ON
insert into gd_esquema.Rendiciones
(id, fecha_rendicion, empresa, total_rendicion, porcentaje_comision)
	select distinct Rendicion_Nro, Rendicion_Fecha, 
		(select id from gd_esquema.Empresas where cuit = Empresa_Cuit and nombre = Empresa_Nombre),
		sum(ItemRendicion_Importe), 
		CAST(ROUND((select top 1 ItemRendicion_Importe/Total from gd_esquema.Maestra  m2 where m2.Rendicion_Nro = m1.Rendicion_Nro)*100, -1) as int)
	from gd_esquema.Maestra m1
	where m1.Rendicion_Nro is not null
	group by Rendicion_Nro, Rendicion_Fecha, Empresa_Cuit, Empresa_Nombre
	order by 1
SET IDENTITY_INSERT gd_esquema.Rendiciones OFF
GO