USE sgr;

DROP PROCEDURE IF EXISTS sp_GrupoResiduo_i;

CREATE PROCEDURE sp_GrupoResiduo_i
(
  p_nome VARCHAR(50)
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('GrupoResiduo');


	INSERT INTO sgr.gruporesiduo
	(idGrupoResiduo, nome) 
	VALUES (id, p_nome);


	SELECT id;
	
END
