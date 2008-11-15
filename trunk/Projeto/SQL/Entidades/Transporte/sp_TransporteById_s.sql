USE SGR;

DROP PROCEDURE IF EXISTS sp_TransporteById_s;

CREATE PROCEDURE sp_TransporteById_s 
(
  p_idTransporte INT
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
		((p_idTransporte IS NULL) OR (idTransporte = p_idTransporte));
END
