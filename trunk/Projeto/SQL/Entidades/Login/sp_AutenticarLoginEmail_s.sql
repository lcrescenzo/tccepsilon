USE SGR;

DROP PROCEDURE IF EXISTS sp_AutenticarLoginEmail_s;

CREATE PROCEDURE sp_AutenticarLoginEmail_s
(
	p_login VARCHAR(30),
	p_email VARCHAR(100)
)
BEGIN

	SELECT 
		loi.idUsuario, 
		loi.login, 
		loi.senha 
	FROM 
							sgr.login loi
	INNER JOIN 	sgr.usuario usu
	ON loi.idUsuario = usu.idUsuario
	WHERE 
	(loi.login = p_login)
	AND (usu.email = email)
	;

END
