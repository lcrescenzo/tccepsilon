USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_d;

CREATE PROCEDURE sp_TipoResiduo_d 
(
	p_idTipoResiduo INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.tiporesiduo 
	WHERE idTipoResiduo = p_idTipoResiduo;

	CALL sp_HistoricoExcluir_i(p_idUsuario,	3, p_idTipoResiduo);

END