USE sgr;

DROP PROCEDURE IF EXISTS sp_Movimentacao_d;

CREATE PROCEDURE sp_Movimentacao_d
(
	p_idMovimentacao INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.movimentacao 
	WHERE 
		idMovimentacao = p_idMovimentacao 
	;

	CALL sp_HistoricoExcluir_i(p_idUsuario,	11, p_idMovimentacao);

END