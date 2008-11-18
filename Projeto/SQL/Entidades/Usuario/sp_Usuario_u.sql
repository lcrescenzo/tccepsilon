USE sgr;

DROP PROCEDURE IF EXISTS sp_Usuario_u;

CREATE PROCEDURE sp_Usuario_u 
(
	p_idUsuario INT,
	p_nome VARCHAR(50),
	p_idPerfil INT,
	p_email VARCHAR(100),
	p_telefone VARCHAR(10),
	p_endereco VARCHAR(200),
	p_idUsuarioAcao INT
)
BEGIN
	
	UPDATE sgr.usuario 
	SET 
		nome = p_nome, 
		idPerfil = p_idPerfil, 
		CPF = NULL, 
		email = p_email, 
		telefone = p_telefone, 
		endereco = p_endereco 
	WHERE 
		idUsuario = p_idUsuario
	;

	CALL sp_HistoricoExcluir_i(p_idUsuarioAcao,	8, p_idUsuario);
	
END