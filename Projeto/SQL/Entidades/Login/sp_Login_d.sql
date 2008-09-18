USE sgr;

DROP PROCEDURE IF EXISTS sp_Login_d;

CREATE PROCEDURE sp_Login_d 
(
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.login 
	WHERE idUsuario = p_idUsuario;

END