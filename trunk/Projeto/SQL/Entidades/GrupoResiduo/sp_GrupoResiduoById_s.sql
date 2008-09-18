USE SGR;

DROP PROCEDURE IF EXISTS sp_GrupoResiduoById_s;

CREATE PROCEDURE sp_GrupoResiduoById_s 
(
  p_idGrupoResiduo INT
)
BEGIN

	SELECT 
		idGrupoResiduo, 
		nome 
	FROM gruporesiduo
	WHERE 
		((p_idGrupoResiduo IS NULL) OR (idGrupoResiduo = p_idGrupoResiduo))
	;

END
