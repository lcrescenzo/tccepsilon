USE sgr;

DROP PROCEDURE IF EXISTS sp_Cadri_d;

CREATE PROCEDURE sp_Cadri_d 
(
	p_idCadri INT
)
BEGIN
	
	DELETE FROM cadri 
	WHERE idCadri = p_idCadri;

END