USE SGR;

DROP PROCEDURE IF EXISTS sp_Cadri_s;

CREATE PROCEDURE sp_Cadri_s 
(
	p_idCadri INT,
  p_numero INT,
  p_destino VARCHAR(45),
  p_validade DATETIME
)
BEGIN

	SELECT 
			idCadri, 
			numero, 
			destino, 
			quantidade, 
			OI, 
			validade 
	FROM 
			cadri
	WHERE   
			((p_idCadri IS NULL) OR (idCadri = p_idCadri))
	AND	((p_destino IS NULL) OR (destino LIKE CONCAT('%', p_destino, '%')))
	AND	((p_numero IS NULL) OR (numero = p_numero))	
	AND ((p_validade IS NULL) OR (validade = p_validade));
	
END