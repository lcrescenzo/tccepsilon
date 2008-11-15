USE SGR;

DROP PROCEDURE IF EXISTS sp_UsuarioById_s;

CREATE PROCEDURE sp_UsuarioById_s
(
  p_idUsuario INT
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
			(idUsuario = p_idUsuario);
END
