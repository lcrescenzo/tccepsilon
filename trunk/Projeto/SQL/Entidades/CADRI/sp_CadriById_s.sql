USE SGR;

DROP PROCEDURE IF EXISTS sp_CadriById_s;

CREATE PROCEDURE sp_CadriById_s 
(
	p_idCadri INT
)
BEGIN

	SELECT 
			idCadri, 
			numero, 
			destino, 
			quantidade, 
			OI, 
			validade 
	FROM 
			cadri
	WHERE   
			(idCadri = p_idCadri);
	
END