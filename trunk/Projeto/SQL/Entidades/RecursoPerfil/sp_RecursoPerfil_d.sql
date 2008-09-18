USE sgr;

DROP PROCEDURE IF EXISTS sp_RecursoPerfil_d;

CREATE PROCEDURE sp_RecursoPerfil_d 
(
	p_idPerfil INT,
	p_idRecurso INT
)
BEGIN
	
	DELETE FROM sgr.recursoperfil 
	WHERE idPerfil = p_idPerfil 
	AND idRecurso = p_idRecurso ;

END