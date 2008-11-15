USE sgr;

DROP PROCEDURE IF EXISTS sp_ResiduoCadri_s;

CREATE PROCEDURE sp_ResiduoCadri_s
(
	p_idCadri INT
)
BEGIN

	SELECT 
			res.idResiduo,
			res.auditoria,
			res.estFisico,
			res.idClasse,
			res.idGrupoResiduo,
			res.idTipoResiduo,
			res.nome,
			res.unidadeMedida
	FROM 
			residuocadri rec
	INNER JOIN sgr.residuo res
	ON rec.idResiduo = res.idResiduo
	WHERE   
		((p_idCadri IS NULL) OR (idCadri = p_idCadri));
END