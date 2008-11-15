USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoById_s;

CREATE PROCEDURE sp_RecursoById_s 
(
  p_idRecurso INT	
)
BEGIN

	SELECT 
		idRecurso,
		idRecursoPai,
		idTipoRecurso,
	 	componente,
		nome
	FROM 
		sgr.recurso
	WHERE
		((p_idRecurso IS NULL) OR (idRecurso = p_idRecurso))
	;
END