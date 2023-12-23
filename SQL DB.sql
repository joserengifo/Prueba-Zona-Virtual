Create database DBZONAPAGO

go

use DBZONAPAGO

CREATE TABLE TblComercio (
    comercio_codigo numeric(10,0) NOT NULL PRIMARY KEY,
    comercio_nombre varchar(50),
    comercio_nit varchar(50) not null,
    comercio_direccion varchar(50),
	strUsuario varchar(20),
	strContrasenna varchar(50)
);

CREATE TABLE tblTrans_Medio_Pago (
    Trans_medio_pago int NOT NULL PRIMARY KEY,
    str_Trans_medio_pago varchar(20)
);

CREATE TABLE tblTrans_Estado (
    Trans_estado int NOT NULL PRIMARY KEY,
    str_Trans_estado varchar(20)
);

CREATE TABLE TblTransaccion (
	Trans_codigo numeric(10,0) NOT NULL PRIMARY KEY,
	Trans_medio_pago int,
	Trans_estado int,
	Trans_total numeric(10,2),
	Trans_fecha datetime,
	Trans_concepto varchar(100),
    comercio_codigo numeric(10,0),

	CONSTRAINT fk_TblTransaccion_comercio_codigo FOREIGN KEY (comercio_codigo) REFERENCES TblComercio(comercio_codigo),
	CONSTRAINT fk_TblTransaccion_Trans_medio_pago FOREIGN KEY (Trans_medio_pago) REFERENCES tblTrans_Medio_Pago(Trans_medio_pago),
	CONSTRAINT fk_TblTransaccion_Trans_Estado FOREIGN KEY (Trans_Estado) REFERENCES tblTrans_Estado(Trans_Estado)
);

CREATE TABLE TblUsuario (
    usuario_identificacion varchar(50) NOT NULL PRIMARY KEY,
    usuario_nombre varchar(150),
    usuario_email varchar(100),
	strUsuario varchar(20),
	strContrasenna varchar(50)
);

CREATE TABLE Tbl_Usuario_Transaccion (
	usuario_transaccion_unico numeric(10,0) identity(1,1) PRIMARY KEY,
	Trans_codigo numeric(10,0) NOT NULL,
	usuario_identificacion varchar(50) NOT NULL,

	CONSTRAINT fk_Tbl_Usuario_Transaccion_Trans_codigo FOREIGN KEY (Trans_codigo) REFERENCES TblTransaccion(Trans_codigo),
	CONSTRAINT fk_Tbl_Usuario_Transaccion_usuario_identificacion FOREIGN KEY (usuario_identificacion) REFERENCES TblUsuario(usuario_identificacion)
);
----------------------------------------------------------------------------------------

insert into tblTrans_Medio_Pago values (32,'Tarjeta de Crédito'),(29,'PSE'),(41,'Gana'),(42,'Caja')
insert into tblTrans_Estado values (1,'Aprobada'),(1000,'Rechazada'),(999,'Pendiente'),(1001,'Rechazada SR')
