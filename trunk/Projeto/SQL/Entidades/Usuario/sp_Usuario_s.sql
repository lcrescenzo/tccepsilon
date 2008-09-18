USE SGR;

DROP PROCEDURE IF EXISTS sp_Usuario_s;

CREATE PROCEDURE sp_Usuario_s 
(
  p_idUsuario INT,
	p_nome VARCHAR(50),
	p_idPerfil INT,
	p_email VARCHAR(100),
	p_telefone VARCHAR(10),
	p_endereco VARCHAR(200) 
)
BEGIN

	SELECT 
		idUsuario, 
		nome, 
		idPerfil, 
		'', 
		email, 
		telefone, 
		endereco 
	FROM 
		sgr.usuario
	WHERE 
			((p_idUsuario IS NULL) 	OR (idUsuario = p_idUsuario))
	AND	((p_nome IS NULL) 			OR (p_nome LIKE CONCAT('%', p_nome, '%')))
	AND	((p_idPerfil IS NULL) 	OR (idPerfil = p_idPerfil))
	AND	((p_email IS NULL) 			OR (email = p_email))
	AND	((p_telefone IS NULL) 	OR (telefone LIKE CONCAT('%', p_telefone, '%')))
	AND	((p_endereco IS NULL) 	OR (endereco LIKE CONCAT('%', p_endereco, '%')))
	AND idUsuario > 0
	;

END
