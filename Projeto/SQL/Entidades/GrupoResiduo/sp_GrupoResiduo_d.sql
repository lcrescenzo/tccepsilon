USE sgr;

DROP PROCEDURE IF EXISTS sp_GrupoResiduo_d;

CREATE PROCEDURE sp_GrupoResiduo_d 
(
	p_idGrupoResiduo INT
)
BEGIN
	
	DELETE FROM sgr.gruporesiduo 
	WHERE idGrupoResiduo = p_idGrupoResiduo 
	;

END