USE SGR;

DROP PROCEDURE IF EXISTS sp_CadriPorResiduo_s;

CREATE PROCEDURE sp_CadriPorResiduo_s 
(
	p_idResiduo INT
)
BEGIN

	SELECT 
			cad.idCadri, 
			cad.numero, 
			cad.destino, 
			cad.quantidade, 
			cad.OI, 
			cad.validade 
	FROM 
			cadri cad
	INNER JOIN sgr.residuocadri rec
	ON rec.idCadri = cad.idCadri
	WHERE   
			((p_idResiduo = NULL) OR (rec.idResiduo = p_idResiduo))
	AND cad.validade > NOW();
	
END