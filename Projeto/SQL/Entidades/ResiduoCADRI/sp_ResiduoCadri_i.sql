USE sgr;

DROP PROCEDURE IF EXISTS sp_ResiduoCadri_i;

CREATE PROCEDURE sp_ResiduoCadri_i
(
  p_idCadri INT,
  p_idResiduo INT
)
BEGIN

	INSERT INTO residuocadri (idCadri, idResiduo) 
	VALUES (p_idCadri, p_idResiduo);
		
END
