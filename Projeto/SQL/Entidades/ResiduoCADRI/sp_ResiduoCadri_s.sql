USE sgr;

DROP PROCEDURE IF EXISTS sp_ResiduoCadri_s;

CREATE PROCEDURE sp_ResiduoCadri_s
(
	p_idCadri INT,
  p_idResiduo INT
)
BEGIN

	SELECT 
			idCadri,
			idResiduo
	FROM 
			residuocadri
	WHERE   
			((p_idCadri IS NULL) OR (idCadri = p_idCadri))
	AND	((p_idResiduo IS NULL) OR (idResiduo = p_idResiduo));
	
END