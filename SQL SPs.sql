use DBZONAPAGO

GO

CREATE PROCEDURE SP_TblComercio_Verifica_Agrega(
 @comercio_codigo numeric(10,0),
 @comercio_nombre varchar(50),
 @comercio_nit varchar(50),
 @comercio_direccion varchar(50)
)
AS
BEGIN
 IF (SELECT COUNT(*) FROM TblComercio WHERE comercio_codigo = @comercio_codigo) > 0
	BEGIN
		SELECT 1
	END
 ELSE
	BEGIN
		INSERT INTO TblComercio (comercio_codigo,comercio_nombre,comercio_nit,comercio_direccion) VALUES (@comercio_codigo,@comercio_nombre,@comercio_nit,@comercio_direccion)
		SELECT @comercio_codigo
	END
END

GO

CREATE PROCEDURE SP_TblUsuario_Verifica_Agrega(
 @usuario_identificacion varchar(50),
 @usuario_nombre varchar(150),
 @usuario_email varchar(100)
)
AS
BEGIN
 IF (SELECT COUNT(*) FROM TblUsuario WHERE usuario_identificacion = @usuario_identificacion) > 0
	BEGIN
		SELECT 1
	END
 ELSE
	BEGIN
		INSERT INTO TblUsuario (usuario_identificacion,usuario_nombre,usuario_email) VALUES (@usuario_identificacion,@usuario_nombre,@usuario_email)
		SELECT @usuario_identificacion
	END
END

GO

CREATE PROCEDURE SP_TblTransaccion_Verifica_Agrega(
 @Trans_codigo numeric(10,0),
 @Trans_medio_pago int,
 @Trans_estado int,
 @Trans_total numeric(10,2),
 @Trans_fecha datetime,
 @Trans_concepto varchar(100),
 @comercio_codigo numeric(10,0),
 @usuario_identificacion varchar(50)
)
AS
BEGIN
 IF (SELECT COUNT(*) FROM TblTransaccion WHERE Trans_codigo = @Trans_codigo) > 0
	BEGIN
		SELECT 1
	END
 ELSE
	BEGIN
		INSERT INTO TblTransaccion VALUES (@Trans_codigo
		,CASE WHEN (SELECT COUNT(*) FROM tblTrans_Medio_Pago WHERE Trans_medio_pago = @Trans_medio_pago) = 0 THEN NULL ELSE @Trans_medio_pago END,
		CASE WHEN (SELECT COUNT(*) FROM tblTrans_Estado WHERE Trans_estado = @Trans_estado) = 0 THEN NULL ELSE @Trans_estado END,
		@Trans_total,@Trans_fecha,@Trans_concepto,@comercio_codigo)

		INSERT INTO Tbl_Usuario_Transaccion values (@Trans_codigo,@usuario_identificacion)

		SELECT @Trans_codigo
	END
END

GO

CREATE PROCEDURE SP_UsuarioExistente(
 @identificador varchar(50),
 @intAyuda int
)
AS
BEGIN
DECLARE @STRUSUARIO VARCHAR(20) = ''
DECLARE @INTCOUNT INT = 0

 IF (@intAyuda = 1)
	BEGIN
		SELECT @STRUSUARIO = strUsuario, @INTCOUNT = count(*)  FROM TblUsuario WHERE usuario_identificacion = @identificador GROUP BY strUsuario		
	END
 ELSE
	BEGIN
		SELECT @STRUSUARIO = strUsuario, @INTCOUNT = count(*)  FROM TblComercio WHERE comercio_nit = @identificador GROUP BY strUsuario
	END
END
SELECT CASE WHEN (@INTCOUNT > 0 AND @STRUSUARIO IS NULL) THEN 2 WHEN (@INTCOUNT > 0 AND @STRUSUARIO IS NOT NULL) THEN 1 ELSE 0 END

GO

CREATE PROCEDURE SP_CrearUsuario(
 @identificador varchar(50),
 @strUsuario varchar(20),
 @strContrasenna varchar(50),
 @intAyuda int
)
AS
BEGIN
DECLARE @INTRESULT INT = 0
 IF (@intAyuda = 1)
	BEGIN
		SET @INTRESULT = CASE WHEN (SELECT COUNT(*) FROM TblUsuario WHERE strUsuario = @strUsuario) > 0 THEN -1 ELSE 0 END
		IF(@INTRESULT = 0)
		BEGIN
			UPDATE TblUsuario SET strUsuario = @strUsuario, strContrasenna = @strContrasenna WHERE usuario_identificacion = @identificador
			SET @INTRESULT = 1
		END
		SELECT @INTRESULT
	END
 ELSE
	BEGIN
		SET @INTRESULT = CASE WHEN (SELECT COUNT(*) FROM TblComercio WHERE strUsuario = @strUsuario) > 0 THEN -1 ELSE 0 END
		IF(@INTRESULT = 0)
		BEGIN
			UPDATE TblComercio SET strUsuario = @strUsuario, strContrasenna = @strContrasenna WHERE comercio_nit = @identificador
			SET @INTRESULT = 1
		END
		SELECT @INTRESULT
	END
END


GO

CREATE PROCEDURE SP_InicioSesion(
 @strUsuario varchar(20),
 @strContrasenna varchar(50),
 @intAyuda int
)
AS
BEGIN

 IF (@intAyuda = 1)
	BEGIN
		SELECT COUNT(*) FROM TblUsuario WHERE strUsuario = @strUsuario AND strContrasenna = @strContrasenna
	END
 ELSE
	BEGIN
		SELECT COUNT(*) FROM TblComercio  WHERE strUsuario = @strUsuario AND strContrasenna = @strContrasenna
	END
END

GO

CREATE PROCEDURE SP_ObtenerTransaccionesPagador(
 @usuario_identificacion varchar(50) = ''
)
AS
BEGIN

SELECT tr.Trans_codigo, coalesce(tr.Trans_medio_pago,0) as Trans_medio_pago, coalesce(tr.Trans_estado,0) as Trans_estado,
	   tr.Trans_total, tr.Trans_fecha, tr.Trans_concepto, tr.comercio_codigo,
	   us.usuario_identificacion, coalesce(mepa.str_Trans_medio_pago,'') as strTrans_medio_pago, coalesce(est.str_Trans_estado,'') as strTrans_estado
FROM TblTransaccion as tr
LEFT JOIN tblTrans_Medio_Pago as mepa on mepa.Trans_medio_pago = tr.Trans_medio_pago
LEFT JOIN tblTrans_Estado as est ON est.Trans_estado = tr.Trans_estado
INNER JOIN Tbl_Usuario_Transaccion AS ustra ON ustra.Trans_codigo = tr.Trans_codigo
INNER JOIN TblUsuario AS us ON us.usuario_identificacion = ustra.usuario_identificacion
WHERE us.usuario_identificacion = @usuario_identificacion

END

GO

CREATE PROCEDURE SP_ObtenerEstados
AS
BEGIN

SELECT Trans_estado,str_Trans_estado FROM tblTrans_Estado ORDER BY str_Trans_estado

END

GO

CREATE PROCEDURE SP_ObtenerMediosPago
AS
BEGIN

SELECT Trans_medio_pago,str_Trans_medio_pago FROM tblTrans_Medio_Pago ORDER BY str_Trans_medio_pago

END

GO

CREATE PROCEDURE SP_ObtenerComercios
AS
BEGIN

SELECT comercio_codigo,comercio_nombre,comercio_nit,comercio_direccion FROM TblComercio ORDER BY comercio_nombre

END

GO

CREATE PROCEDURE SP_ObtenerTransaccionesComercio(
 @comercio_nit varchar(50) = '',
 @Trans_fechaIni datetime,
 @Trans_fechaFin datetime,
 @Trans_codigo numeric (10,0),
 @usuario_identificacion varchar(50) = ''
)
AS
BEGIN
SELECT tr.Trans_codigo, coalesce(tr.Trans_medio_pago,0) as Trans_medio_pago, coalesce(tr.Trans_estado,0) as Trans_estado,
	   tr.Trans_total, tr.Trans_fecha, tr.Trans_concepto, tr.comercio_codigo,
	   ustra.usuario_identificacion, coalesce(mepa.str_Trans_medio_pago,'') as strTrans_medio_pago, coalesce(est.str_Trans_estado,'') as strTrans_estado,
	   CASE WHEN tr.Trans_estado <> 1 THEN 1 ELSE 0 END as intPuedeEditar
FROM TblTransaccion as tr
LEFT JOIN tblTrans_Medio_Pago as mepa on mepa.Trans_medio_pago = tr.Trans_medio_pago
LEFT JOIN tblTrans_Estado as est ON est.Trans_estado = tr.Trans_estado
INNER JOIN TblComercio AS com ON com.comercio_codigo = tr.comercio_codigo
INNER JOIN Tbl_Usuario_Transaccion AS ustra ON ustra.Trans_codigo = tr.Trans_codigo
WHERE tr.Trans_fecha between @Trans_fechaIni and @Trans_fechaFin
AND (com.comercio_nit = @comercio_nit OR -1 = @comercio_nit) AND (tr.Trans_codigo = @Trans_codigo OR 0 = @Trans_codigo)
AND (ustra.usuario_identificacion = @usuario_identificacion OR '' = @usuario_identificacion)

END


GO

CREATE PROCEDURE SP_ActualizarTransaccion(
 @Trans_codigo numeric(10,0),
 @Trans_medio_pago int,
 @Trans_estado int,
 @Trans_total numeric(10,2),
 @Trans_fecha datetime,
 @Trans_concepto varchar(100)
)
AS
BEGIN
	UPDATE TblTransaccion SET Trans_medio_pago = @Trans_medio_pago, Trans_estado = @Trans_estado, Trans_total = @Trans_total,
	Trans_fecha = @Trans_fecha, Trans_concepto = @Trans_concepto WHERE Trans_codigo = @Trans_codigo

	SELECT 1
END

GO

CREATE PROCEDURE SP_ObtenerTransaccion(
 @Trans_codigo numeric (10,0)
)
AS
BEGIN
SELECT tr.Trans_codigo, coalesce(tr.Trans_medio_pago,0) as Trans_medio_pago, coalesce(tr.Trans_estado,0) as Trans_estado,
	   tr.Trans_total, tr.Trans_fecha, tr.Trans_concepto, tr.comercio_codigo,
	   ustra.usuario_identificacion, coalesce(mepa.str_Trans_medio_pago,'') as strTrans_medio_pago, coalesce(est.str_Trans_estado,'') as strTrans_estado,
	   CASE WHEN tr.Trans_estado <> 1 THEN 1 ELSE 0 END as intPuedeEditar
FROM TblTransaccion as tr
LEFT JOIN tblTrans_Medio_Pago as mepa on mepa.Trans_medio_pago = tr.Trans_medio_pago
LEFT JOIN tblTrans_Estado as est ON est.Trans_estado = tr.Trans_estado
INNER JOIN TblComercio AS com ON com.comercio_codigo = tr.comercio_codigo
INNER JOIN Tbl_Usuario_Transaccion AS ustra ON ustra.Trans_codigo = tr.Trans_codigo
WHERE tr.Trans_codigo = @Trans_codigo

END
