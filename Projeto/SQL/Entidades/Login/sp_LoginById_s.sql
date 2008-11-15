USE SGR;

DROP PROCEDURE IF EXISTS sp_LoginById_s;

CREATE PROCEDURE sp_LoginById_s 
(
	p_idUsuario INT
)
BEGIN

	SELECT 
		idUsuario, 
		login, 
		senha 
	FROM 
		sgr.login
	WHERE 
		(idUsuario = p_idUsuario)
	;
END
