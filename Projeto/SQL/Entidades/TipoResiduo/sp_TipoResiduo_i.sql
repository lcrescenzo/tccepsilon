USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_i;

CREATE PROCEDURE sp_TipoResiduo_i
(
  p_descricao VARCHAR(50),
	p_idUsuario INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('TipoResiduo');


	INSERT INTO sgr.tiporesiduo
	(idTipoResiduo, descricao) 
	VALUES (id, p_descricao);

	CALL sp_HistoricoIncluir_i(p_idUsuario,	3, id);

	SELECT id;
	
END
