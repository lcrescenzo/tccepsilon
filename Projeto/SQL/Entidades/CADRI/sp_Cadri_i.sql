USE sgr;

DROP PROCEDURE IF EXISTS sp_Cadri_i;

CREATE PROCEDURE sp_Cadri_i 
(
  p_numero VARCHAR(30),
  p_destino VARCHAR(45),
  p_quantidade DECIMAL(20,4),
  p_OI INT,
  p_validade DATETIME,
	p_idUsuario INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Cadri');

	INSERT INTO cadri (idCadri, numero, destino, quantidade, OI, validade) 
	VALUES (id, p_numero, p_destino, p_quantidade, p_OI, p_validade);
	
	CALL sp_HistoricoIncluir_i(p_idUsuario,	7, id);
	
	SELECT id;
	
END
