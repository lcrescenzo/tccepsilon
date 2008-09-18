USE SGR;

DROP PROCEDURE IF EXISTS sp_Movimentacao_s;

CREATE PROCEDURE sp_Movimentacao_s 
(
  p_idMovimentacao INT,
	p_idCadri INT,
	p_idResiduo INT
)
BEGIN

	SELECT 
		idMovimentacao, 
		idResiduo, 
		idCadri, 
		idUsuario 
	FROM 
		sgr.movimentacao
	WHERE
		((p_idMovimentacao IS NULL) OR (idMovimentacao = p_idMovimentacao))
	AND ((p_idResiduo IS NULL) OR (idResiduo = p_idResiduo))
	AND ((p_idCadri IS NULL) OR (idCadri = p_idCadri))
	;
END
