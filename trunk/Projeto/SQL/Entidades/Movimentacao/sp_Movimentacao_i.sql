USE sgr;

DROP PROCEDURE IF EXISTS sp_Movimentacao_i;

CREATE PROCEDURE sp_Movimentacao_i
(
  p_idResiduo INT, 
	p_idCadri INT,  
	p_idUsuario INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Movimentacao');


	INSERT INTO sgr.movimentacao
	(idMovimentacao, idResiduo, idCadri, idUsuario) 
	VALUES (id, p_idResiduo, p_idCadri, p_idUsuario);


	CALL sp_HistoricoIncluir_i(p_idUsuario,	11, id);


	SELECT id;
	
END
