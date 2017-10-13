insert into gd_esquema.Direcciones
(direccion, codigo_postal)
	select distinct Cliente_Direccion, Cliente_Codigo_Postal
	from gd_esquema.Maestra

insert into gd_esquema.Direcciones
values ((select distinct Empresa_Direccion from gd_esquema.Maestra), 1416)

insert into gd_esquema.Direcciones
(direccion, codigo_postal)
	select distinct Sucursal_Dirección, Sucursal_Codigo_Postal
	from gd_esquema.Maestra
	where Sucursal_Codigo_Postal is not null

insert into gd_esquema.Rubros
(descripcion)
	select distinct Rubro_descripcion
	from gd_esquema.Maestra