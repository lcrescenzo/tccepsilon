USE sgr;

DROP PROCEDURE IF EXISTS sp_Configuracao_u;

CREATE PROCEDURE sp_Configuracao_u 
(
	p_idUsuario INT,
	p_chave VARCHAR(20),
	p_valor VARCHAR(8000)
)
BEGIN
	
	UPDATE sgr.configuracao 
	SET valor = p_valor 
	WHERE 
		idUsuario = p_idUsuario 
	AND	((p_chave IS NULL) OR (chave = p_chave))
	;

END