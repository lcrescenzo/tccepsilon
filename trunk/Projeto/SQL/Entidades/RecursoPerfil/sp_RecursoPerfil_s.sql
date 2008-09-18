USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoPerfil_s;

CREATE PROCEDURE sp_RecursoPerfil_s 
(
	idPerfil INT, 
	idRecurso INT
)
BEGIN

	SELECT 
		idPerfil, 
		idRecurso 
	FROM 
		sgr.recursoperfil
	WHERE ((p_idPerfil IS NULL) OR (idPerfil = p_idPerfil))
	AND ((p_idRecurso IS NULL) OR (idRecurso = p_idRecurso))
	;

END
