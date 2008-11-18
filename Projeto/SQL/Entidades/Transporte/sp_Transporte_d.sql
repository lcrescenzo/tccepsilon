USE sgr;

DROP PROCEDURE IF EXISTS sp_Transporte_d;

CREATE PROCEDURE sp_Transporte_d 
(
	p_idTransporte INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM sgr.transporte 
	WHERE idTransporte = p_idTransporte;

	CALL sp_HistoricoExcluir_i(p_idUsuario,	12, p_idTransporte);

END