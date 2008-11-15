USE SGR;

DROP PROCEDURE IF EXISTS sp_MovimentacaoById_s;

CREATE PROCEDURE sp_MovimentacaoById_s 
(
  p_idMovimentacao INT
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
	;
END
