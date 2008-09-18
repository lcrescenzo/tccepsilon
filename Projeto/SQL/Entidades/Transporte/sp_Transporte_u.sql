USE sgr;

DROP PROCEDURE IF EXISTS sp_Transporte_u;

CREATE PROCEDURE sp_Transporte_u
(
	p_idTransporte INT, 
	p_dataSaida DATETIME, 
	p_qtdSaida DECIMAL(20,4), 
	p_transportadora VARCHAR(100), 
	p_idEstado INT,
	p_idUsuario INT
)
BEGIN
	
	UPDATE sgr.transporte 
	SET 
		dataSaida = p_dataSaida, 
		qtdSaida = p_qtdSaida, 
		transportadora = p_transportadora, 
		idEstado = p_idEstado, 
		idUsuario = p_idUsuario 
	WHERE 
		((p_idTransporte IS NULL) OR (idTransporte = p_idTransporte))
	AND ((p_dataSaida IS NULL) OR (DATE(dataSaida) = DATE(p_idTransporte)))
	AND ((p_qtdSaida IS NULL) OR (qtdSaida = p_qtdSaida))
	AND ((p_transportadora IS NULL) OR (transportadora = p_transportadora))
	AND ((p_idEstado IS NULL) OR (idEstado = p_idEstado))
	AND ((p_idUsuario IS NULL) OR (idUsuario = p_idUsuario))
	;

	
END