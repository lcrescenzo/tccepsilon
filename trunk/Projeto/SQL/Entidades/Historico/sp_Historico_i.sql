USE sgr;

DROP PROCEDURE IF EXISTS sp_Historico_i;

CREATE PROCEDURE sp_Historico_i
(
  p_idUsuario INT, 
	p_idEntidade INT, 
	p_idManutencao INT, 
	p_dataAlteracao DATETIME, 
	p_idmantido INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Historico');


	INSERT INTO sgr.historico
	(idHistorico, idUsuario, idEntidade, idManutencao, dataAlteracao, idmantido) 
	VALUES (id, p_idUsuario, p_idEntidade, p_idManutencao, p_dataAlteracao, p_idmantido);

	SELECT id;
	
END
