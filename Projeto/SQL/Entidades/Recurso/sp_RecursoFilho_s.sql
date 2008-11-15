USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoFilho_s;

CREATE PROCEDURE sp_RecursoFilho_s 
(
  p_idRecursoPai INT	
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
		((p_idRecursoPai IS NULL) OR (idRecursoPai = p_idRecursoPai))
	;
END
