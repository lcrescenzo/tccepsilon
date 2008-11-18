USE sgr;

DROP PROCEDURE IF EXISTS sp_Perfil_u;

CREATE PROCEDURE sp_Perfil_u 
(
	p_idPerfil  INT,
	p_descricao VARCHAR(40),
	p_idUsuario INT
)
BEGIN
	
	UPDATE sgr.perfil 
	SET descricao = p_descricao 
	WHERE 
		idPerfil = p_idPerfil
	;

	CALL sp_HistoricoAlterar_i(p_idUsuario,	1, p_idPerfil);

END