USE sgr;

DROP PROCEDURE IF EXISTS sp_Usuario_d;

CREATE PROCEDURE sp_Usuario_d 
(
	p_idUsuario INT,
	p_idUsuarioAcao INT
)
BEGIN
	
	DELETE FROM sgr.usuario
	WHERE idUsuario = p_idUsuario;

	CALL sp_HistoricoExcluir_i(p_idUsuarioAcao,	8, p_idUsuario);

END