USE sgr;

DROP PROCEDURE IF EXISTS sp_Transporte_i;

CREATE PROCEDURE sp_Transporte_i
(
	p_dataSaida DATETIME, 
	p_qtdSaida DECIMAL(20,4), 
	p_transportadora VARCHAR(100), 
	p_idUsuario INT, 
	p_idMovimentacao INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Transporte');


	INSERT INTO sgr.transporte
	(idTransporte, dataSaida, qtdSaida, transportadora, idEstado, idUsuario, idMovimentacao) 
	VALUES (id, p_dataSaida, p_qtdSaida, p_transportadora, 0, p_idUsuario, p_idMovimentacao);

	SELECT id;
	
END
