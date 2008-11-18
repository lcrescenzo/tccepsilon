USE sgr;

DROP PROCEDURE IF EXISTS sp_Perfil_i;

CREATE PROCEDURE sp_Perfil_i
(
  p_descricao VARCHAR(40),
	p_idUsuario INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Perfil');

	INSERT INTO sgr.perfil
	(idPerfil, descricao) 
	VALUES (id, p_descricao);

	CALL sp_HistoricoIncluir_i(p_idUsuario,	1, id);

	SELECT id;
	
END
