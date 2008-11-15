USE SGR;

DROP PROCEDURE IF EXISTS sp_Usuario_s;

CREATE PROCEDURE sp_Usuario_s 
(
	p_nome VARCHAR(50),
	p_idPerfil INT,
	p_email VARCHAR(100),
	p_telefone VARCHAR(10),
	p_login VARCHAR(30) 
)
BEGIN

	SELECT 
		usu.idUsuario, 
		usu.nome, 
		usu.idPerfil, 
		'' CPF, 
		usu.email, 
		usu.telefone, 
		usu.endereco 
	FROM 
							sgr.usuario 	usu
	INNER JOIN 	sgr.login 		lgn
	ON usu.idUsuario = lgn.idUsuario
	WHERE 
			((p_nome 			IS NULL) 	OR (usu.nome LIKE CONCAT('%', p_nome, '%')))
	AND	((p_idPerfil 	IS NULL) 	OR (usu.idPerfil = p_idPerfil))
	AND	((p_email 		IS NULL) 	OR (usu.email LIKE CONCAT('%', p_email, '%')))
	AND	((p_telefone 	IS NULL) 	OR (usu.telefone LIKE CONCAT('%', p_telefone, '%')))
	AND	((p_login 		IS NULL) 	OR (lgn.login LIKE CONCAT('%', p_login, '%')))
	AND usu.idUsuario > 0
	;

END
