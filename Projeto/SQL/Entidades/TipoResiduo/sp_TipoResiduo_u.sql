USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_u;

CREATE PROCEDURE sp_TipoResiduo_u 
(
	p_idTipoResiduo INT,
	p_descricao VARCHAR(50),
	p_idUsuario INT
)
BEGIN
	
	UPDATE sgr.tiporesiduo 
	SET descricao = p_descricao 
	WHERE idTipoResiduo = p_idTipoResiduo 
	;
	
	CALL sp_HistoricoAlterar_i(p_idUsuario, 3, p_idTipoResiduo);
	
END