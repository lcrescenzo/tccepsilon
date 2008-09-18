USE sgr;

DROP PROCEDURE IF EXISTS sp_Configuracao_i;

CREATE PROCEDURE sp_Configuracao_i
(
 	p_idUsuario INT,
	p_chave VARCHAR(20),
	p_valor VARCHAR(8000)
)
BEGIN

	INSERT INTO sgr.configuracao
	(idUsuario, chave, valor) 
	VALUES (p_idUsuario, p_chave, p_valor);

	SELECT p_idUsuario;
END
