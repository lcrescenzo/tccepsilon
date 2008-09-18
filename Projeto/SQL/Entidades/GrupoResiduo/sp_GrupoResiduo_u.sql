USE sgr;

DROP PROCEDURE IF EXISTS sp_GrupoResiduo_u;

CREATE PROCEDURE sp_GrupoResiduo_u 
(
	p_idGrupoResiduo INT,
	p_nome VARCHAR(50)
)
BEGIN
	
	UPDATE sgr.gruporesiduo 
	SET nome = p_nome 
	WHERE idGrupoResiduo = p_idGrupoResiduo
	;

	
END