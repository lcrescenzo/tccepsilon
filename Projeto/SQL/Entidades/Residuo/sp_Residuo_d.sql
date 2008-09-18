USE sgr;

DROP PROCEDURE IF EXISTS sp_Residuo_d;

CREATE PROCEDURE sp_Residuo_d 
(
	p_idResiduo INT
)
BEGIN
	
	DELETE FROM residuo
	WHERE idResiduo = p_idResiduo;

END