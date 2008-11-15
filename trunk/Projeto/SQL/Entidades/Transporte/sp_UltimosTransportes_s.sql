USE SGR;

DROP PROCEDURE IF EXISTS sp_UltimosTransportes_s;

CREATE PROCEDURE sp_UltimosTransportes_s 
(
  p_idMovimentacao INT,
	p_Ultimos INT
)
BEGIN

SET @ultimos = p_Ultimos;
SET @query = CONCAT('	SELECT  idTransporte,  dataSaida,  qtdSaida, transportadora,  idEstado,  idUsuario,  idMovimentacao  FROM ',
	'		sgr.transporte ', 	CONCAT(' WHERE  idMovimentacao = ', p_idMovimentacao) ,	' ORDER BY dataSaida DESC ',	' LIMIT ?');

	PREPARE STMT FROM @query;
	EXECUTE STMT USING @ultimos;
END
