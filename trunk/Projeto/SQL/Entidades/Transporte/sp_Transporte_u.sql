USE sgr;

DROP PROCEDURE IF EXISTS sp_Transporte_u;

CREATE PROCEDURE sp_Transporte_u
(
	p_idTransporte INT, 
	p_qtdSaida DECIMAL(20,4), 
	p_transportadora VARCHAR(100), 
	p_idUsuario INT
)
BEGIN
	
	UPDATE sgr.transporte 
	SET 
		qtdSaida = p_qtdSaida, 
		transportadora = p_transportadora, 
		idUsuario = p_idUsuario 
	WHERE 
		((p_idTransporte IS NULL) OR (idTransporte = p_idTransporte))
	;
	
	CALL sp_HistoricoAlterar_i(p_idUsuario,	12, p_idTransporte);
	
END