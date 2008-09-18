USE sgr;

DROP PROCEDURE IF EXISTS sp_Usuario_d;

CREATE PROCEDURE sp_Usuario_d 
(
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.usuario
	WHERE idUsuario = p_idUsuario;

END