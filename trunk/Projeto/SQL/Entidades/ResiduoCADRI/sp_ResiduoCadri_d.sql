USE SGR;

DROP PROCEDURE IF EXISTS sp_ResiduoCadri_d;

CREATE PROCEDURE sp_ResiduoCadri_d 
(
	p_idCadri INT,
	p_idResiduo INT
)
BEGIN
	
	DELETE FROM sgr.residuocadri
	WHERE 
				idCadri = p_idCadri
	AND 	idResiduo = p_idResiduo;

END