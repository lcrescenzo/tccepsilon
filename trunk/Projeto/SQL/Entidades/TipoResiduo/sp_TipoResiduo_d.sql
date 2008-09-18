USE sgr;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_d;

CREATE PROCEDURE sp_TipoResiduo_d 
(
	p_idTipoResiduo INT
)
BEGIN
	
	DELETE FROM sgr.tiporesiduo 
	WHERE idTipoResiduo = p_idTipoResiduo;

END