USE sgr;

DROP PROCEDURE IF EXISTS sp_Perfil_d;

CREATE PROCEDURE sp_Perfil_d 
(
	p_idPerfil INT
)
BEGIN
	
	DELETE FROM sgr.perfil 
	WHERE idPerfil = p_idPerfil 
	;

END