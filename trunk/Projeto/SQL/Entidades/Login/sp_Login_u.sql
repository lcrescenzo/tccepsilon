USE sgr;

DROP PROCEDURE IF EXISTS sp_Login_u;

CREATE PROCEDURE sp_Login_u
(
	p_idUsuario INT,
	p_senha VARCHAR(200)
)
BEGIN
	
	UPDATE sgr.login 
	SET senha = p_senha 
	WHERE idUsuario = p_idUsuario 
	;

END