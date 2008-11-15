USE SGR;

DROP PROCEDURE IF EXISTS sp_AutenticarLogin_s;

CREATE PROCEDURE sp_AutenticarLogin_s
(
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
	(login = p_login)
	AND (senha = p_senha)
	;

END
