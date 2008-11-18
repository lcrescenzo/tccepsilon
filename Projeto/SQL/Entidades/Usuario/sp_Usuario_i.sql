USE sgr;

DROP PROCEDURE IF EXISTS sp_Usuario_i;

CREATE PROCEDURE sp_Usuario_i
(
	p_nome VARCHAR(50),
	p_idPerfil INT,
	p_email VARCHAR(100),
	p_telefone VARCHAR(10),
	p_endereco VARCHAR(200),
	p_idUsuarioAcao INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Usuario');

	INSERT INTO sgr.usuario
	(idUsuario, nome, idPerfil, CPF, email, telefone, endereco) 
	VALUES (id, p_nome, p_idPerfil, NULL, p_email, p_telefone, p_endereco);
	
	CALL sp_HistoricoIncluir_i(p_idUsuarioAcao,	8, id);
	
	SELECT id;
	
END
