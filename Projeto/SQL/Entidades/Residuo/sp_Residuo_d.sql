USE sgr;

DROP PROCEDURE IF EXISTS sp_Residuo_d;

CREATE PROCEDURE sp_Residuo_d 
(
	p_idResiduo INT,
	p_idUsuario INT
)
BEGIN
	
	DELETE FROM residuo
	WHERE idResiduo = p_idResiduo;
	
	CALL sp_HistoricoExcluir_i(p_idUsuario,	10, p_idResiduo);	

END