USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_i;

CREATE PROCEDURE sp_TipoResiduo_i
(
  IN p_descricao VARCHAR(50)
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('TipoResiduo');


	INSERT INTO sgr.tiporesiduo
	(idTipoResiduo, descricao) 
	VALUES (id, p_descricao);

	SELECT id;
	
END
