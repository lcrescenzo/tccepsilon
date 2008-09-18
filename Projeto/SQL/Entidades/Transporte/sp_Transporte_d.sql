USE sgr;

DROP PROCEDURE IF EXISTS sp_Transporte_d;

CREATE PROCEDURE sp_Transporte_d 
(
	p_idTransporte INT
)
BEGIN
	
	DELETE FROM sgr.transporte 
	WHERE idTransporte = p_idTransporte;


END