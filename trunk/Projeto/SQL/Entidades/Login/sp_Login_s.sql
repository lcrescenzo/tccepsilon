USE SGR;

DROP PROCEDURE IF EXISTS sp_Login_s;

CREATE PROCEDURE sp_Login_s 
(
	p_idUsuario INT,
	p_login VARCHAR(30),
	p_senha VARCHAR(200)
)
BEGIN

	SELECT 
		idUsuario, 
		login, 
		senha 
	FROM 
		sgr.login
	WHERE 
		
		((p_idUsuario IS NULL) OR (idUsuario = p_idUsuario))
		AND ((p_login IS NULL) OR (login = p_login))
		AND ((p_senha IS NULL) OR (senha = p_senha))
		;

END
