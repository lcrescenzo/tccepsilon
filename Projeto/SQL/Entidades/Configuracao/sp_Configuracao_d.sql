USE sgr;

DROP PROCEDURE IF EXISTS sp_Configuracao_d;

CREATE PROCEDURE sp_Configuracao_d 
(
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.configuracao 
	WHERE idUsuario = p_idUsuario
	;

END