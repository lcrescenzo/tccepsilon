USE sgr;

DROP PROCEDURE IF EXISTS sp_Perfil_i;

CREATE PROCEDURE sp_Perfil_i
(
  p_descricao VARCHAR(40)
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Perfil');

	INSERT INTO sgr.perfil
	(idPerfil, descricao) 
	VALUES (id, p_descricao);

	SELECT id;
	
END
