DELETE FROM ONEFORALL.ITEMS
GO
DELETE FROM ONEFORALL.FACTURAS
GO
delete from ONEFORALL.PAGOS
GO
delete from ONEFORALL.USUARIOS
GO
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

DBCC CHECKIDENT('ONEFORALL.ITEMS', RESEED, 0);
GO
DBCC CHECKIDENT('ONEFORALL.FACTURAS', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.PAGOS', RESEED, 0);
GO
DBCC CHECKIDENT ('ONEFORALL.USUARIOS', RESEED, 0);
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
	select distinct Sucursal_Nombre, D.DIR_ID
	from gd_esquema.Maestra M 
	left join ONEFORALL.DIRECCIONES D 
		ON M.Sucursal_Dirección= D.DIR_DIRECCION
	where Sucursal_Nombre is not null
GO

insert into ONEFORALL.CLIENTES
(CLIE_DNI, CLIE_APELLIDO, CLIE_NOMBRE, CLIE_FECHA_NACIMIENTO, CLIE_MAIL, CLIE_DIR_ID)
	select distinct [Cliente-Dni], [Cliente-Apellido], [Cliente-Nombre], CAST([Cliente-Fecha_Nac] as DATE), Cliente_Mail,D.DIR_ID
	from gd_esquema.Maestra M
	left join ONEFORALL.DIRECCIONES D 
		ON M.Cliente_Direccion= D.DIR_DIRECCION
		AND D.DIR_CODIGO_POSTAL = M.Cliente_Codigo_Postal
GO
 
insert into ONEFORALL.EMPRESAS
(EMP_CUIT, EMP_NOMBRE, EMP_DIR_ID, EMP_RUB_ID, EMP_ACTIVA)
	select distinct Empresa_Cuit, Empresa_Nombre, D.DIR_ID, R.RUB_ID, 1 as EMP_ACTIVA
	from gd_esquema.Maestra M
	left join ONEFORALL.DIRECCIONES D 
		ON M.Empresa_Direccion= D.DIR_DIRECCION
	left join ONEFORALL.RUBROS R 
		ON M.Rubro_Descripcion = R.RUB_DESCRIPCION
GO

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

insert into ONEFORALL.USUARIOS
(USER_USUARIO, USER_PASSWORD, USER_ACTIVO, USER_INTENTOS)
values('admin', 'w23e', 1, 0)
GO

INSERT INTO ONEFORALL.ROLES
(ROL_NOMBRE, ROL_ACTIVO)
VALUES ('Administrador', 1), ('Cobrador', 1)

INSERT INTO ONEFORALL.USUARIO_X_ROL
(USERX_ID, ROLX_ID)
VALUES (1,1)

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

SET IDENTITY_INSERT ONEFORALL.FACTURAS ON
insert into ONEFORALL.FACTURAS
(FACT_ID, FACT_ALTA, FACT_VENCIMIENTO, FACT_CLIE_ID, FACT_REND_ID, FACT_PAGO_ID, FACT_TOTAL)
	select distinct Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, C.CLIE_ID, MAX(Rendicion_Nro), MAX(Pago_nro), Factura_Total
	from gd_esquema.Maestra M 
	join ONEFORALL.CLIENTES C on M.[Cliente-Dni] = C.CLIE_DNI
	GROUP BY Nro_Factura, Factura_Fecha, Factura_Fecha_Vencimiento, C.CLIE_ID, Factura_Total
	ORDER BY 1 ASC
SET IDENTITY_INSERT ONEFORALL.FACTURAS OFF
GO

INSERT INTO ONEFORALL.ITEMS
(ITEM_FACT_ID, ITEM_CANTIDAD, ITEM_MONTO)
	SELECT DISTINCT Nro_Factura, ItemFactura_Cantidad, ItemFactura_Monto FROM gd_esquema.Maestra
	ORDER BY 1 ASC
GO

