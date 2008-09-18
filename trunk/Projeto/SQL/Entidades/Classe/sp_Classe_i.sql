USE sgr;

DROP PROCEDURE IF EXISTS sp_Classe_i;

CREATE PROCEDURE sp_Classe_i
(
  p_descricao VARCHAR(50)
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Classe');

	INSERT INTO sgr.classe
	(idClasse, descricao) 
	VALUES (id, p_descricao);

	SELECT id;
	
END
