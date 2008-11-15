USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoPrincipal_s;

CREATE PROCEDURE sp_RecursoPrincipal_s()
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
		(idRecursoPai IS NULL)
	;
END