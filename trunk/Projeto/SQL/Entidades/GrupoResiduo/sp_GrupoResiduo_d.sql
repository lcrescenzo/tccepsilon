USE sgr;

DROP PROCEDURE IF EXISTS sp_GrupoResiduo_d;

CREATE PROCEDURE sp_GrupoResiduo_d 
(
	p_idGrupoResiduo INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.gruporesiduo 
	WHERE idGrupoResiduo = p_idGrupoResiduo 
	;

	CALL sp_HistoricoExcluir_i(p_idUsuario,	4, p_idGrupoResiduo);

END