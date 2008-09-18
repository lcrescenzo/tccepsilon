USE sgr;

DROP PROCEDURE IF EXISTS sp_Cadri_u;

CREATE PROCEDURE sp_Cadri_u 
(
	p_idCadri INT,
  p_numero INT,
  p_destino VARCHAR(45),
  p_quantidade DECIMAL(20,4),
  p_OI INT,
  p_validade DATETIME
)
BEGIN
	
	UPDATE cadri 
	SET numero = p_numero, 
			destino = p_destino, 
			quantidade = p_quantidade, 
			OI = p_OI, 
			validade = p_validade 
	WHERE 
			idCadri = p_idCadri
	;


	
END