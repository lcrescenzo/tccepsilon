USE SGR;

DROP PROCEDURE IF EXISTS sp_Transporte_s;

CREATE PROCEDURE sp_Transporte_s 
(
  p_idTransporte INT, 
	p_dataSaida DATETIME, 
	p_qtdSaida DECIMAL(20,4), 
	p_transportadora VARCHAR(100), 
	p_idUsuario INT, 
	p_idMovimentacao INT
)
BEGIN

	SELECT 
		idTransporte, 
		dataSaida, 
		qtdSaida, 
		transportadora, 
		idEstado, 
		idUsuario, 
		idMovimentacao 
	FROM 
		sgr.transporte
	WHERE 
		((p_idTransporte IS NULL) OR (idTransporte = p_idTransporte))
	AND	((p_transportadora IS NULL) OR (transportadora LIKE CONCAT('%', p_transportadora, '%')))
	AND	((p_idUsuario IS NULL) OR (idUsuario = p_idUsuario))
	AND	((p_idMovimentacao IS NULL) OR (idMovimentacao = p_idMovimentacao))
	AND	((p_dataSaida IS NULL) OR (date(dataSaida) = date(p_dataSaida)))
	;

END
