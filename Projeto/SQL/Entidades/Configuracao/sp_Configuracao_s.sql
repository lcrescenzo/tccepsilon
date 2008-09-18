USE SGR;

DROP PROCEDURE IF EXISTS sp_Configuracao_s;

CREATE PROCEDURE sp_Configuracao_s 
(
  p_idUsuario INT,
	p_chave VARCHAR(20)
)
BEGIN

	SELECT 
		idUsuario, 
		chave, 
		valor 
	FROM 
		sgr.configuracao
	WHERE  
			idUsuario = p_idUsuario 
	AND	((p_chave IS NULL) OR (chave = p_chave))
	;
END
