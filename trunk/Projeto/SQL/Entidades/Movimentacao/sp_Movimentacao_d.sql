USE sgr;

DROP PROCEDURE IF EXISTS sp_Movimentacao_d;

CREATE PROCEDURE sp_Movimentacao_d
(
	p_idMovimentacao INT
)
BEGIN
	
	DELETE FROM sgr.movimentacao 
	WHERE 
		idMovimentacao = p_idMovimentacao 
	;

END