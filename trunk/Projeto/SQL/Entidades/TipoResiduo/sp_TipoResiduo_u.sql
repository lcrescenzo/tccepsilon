USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_u;

CREATE PROCEDURE sp_TipoResiduo_u 
(
	p_idTipoResiduo INT,
	p_descricao VARCHAR(50)
)
BEGIN
	
	UPDATE sgr.tiporesiduo 
	SET descricao = p_descricao 
	WHERE idTipoResiduo = p_idTipoResiduo 
	;
	
END