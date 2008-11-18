USE sgr;

DROP PROCEDURE IF EXISTS sp_Cadri_d;

CREATE PROCEDURE sp_Cadri_d 
(
	p_idCadri INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM cadri 
	WHERE idCadri = p_idCadri;
	
	CALL sp_HistoricoExcluir_i(p_idUsuario,	7, p_idCadri);

END