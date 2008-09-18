USE SGR;

DROP PROCEDURE IF EXISTS sp_GrupoResiduo_s;

CREATE PROCEDURE sp_GrupoResiduo_s 
(
  p_nome VARCHAR(50)
)
BEGIN

	SELECT 
		idGrupoResiduo, 
		nome 
	FROM gruporesiduo
	WHERE 
		((p_nome IS NULL) OR (nome LIKE CONCAT('%',p_nome,'%')))
	;
END
