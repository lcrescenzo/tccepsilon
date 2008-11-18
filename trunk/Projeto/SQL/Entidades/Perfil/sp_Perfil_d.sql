USE sgr;

DROP PROCEDURE IF EXISTS sp_Perfil_d;

CREATE PROCEDURE sp_Perfil_d 
(
	p_idPerfil INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.perfil 
	WHERE idPerfil = p_idPerfil 
	;

	CALL sp_HistoricoExcluir_i(p_idUsuario,	1, p_idPerfil);

END