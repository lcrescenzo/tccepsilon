USE SGR;

DROP PROCEDURE IF EXISTS sp_RecursoByPerfilRecursoPai_s;

CREATE PROCEDURE sp_RecursoByPerfilRecursoPai_s 
(
	p_idPerfil INT, 
	p_idRecursoPai INT
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
	AND	(((p_idRecursoPai IS NULL) AND (rec.idRecursoPai IS NULL)) OR (rec.idRecursoPai = p_idRecursoPai))
	;
	
END
