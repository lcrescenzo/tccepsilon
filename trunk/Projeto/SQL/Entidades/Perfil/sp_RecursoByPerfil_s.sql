USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoByPerfil_s;

CREATE PROCEDURE sp_RecursoByPerfil_s 
(
	p_idPerfil INT
)
BEGIN

	SELECT
		rec.idRecurso,
		rec.idRecursoPai,
		rec.idTipoRecurso,
	 	rec.componente,
		rec.nome
	FROM 
							recurso rec
	INNER JOIN 	recursoperfil rpe
	ON rpe.idRecurso = rec.idRecurso
	WHERE
			rpe.idPerfil = p_idPerfil
	;
	
END
