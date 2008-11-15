USE SGR;

DROP PROCEDURE IF EXISTS sp_ResiduoPorCadri_s;

CREATE PROCEDURE sp_ResiduoPorCadri_s 
(
	p_idCadri INT
)
BEGIN

	SELECT 
		res.idResiduo,
  	res.idTipoResiduo,
  	res.idClasse,
  	res.idGrupoResiduo,
  	res.nome,
  	res.estFisico,
  	res.auditoria,
  	res.unidadeMedida 
	FROM 
		sgr.residuo res
	INNER JOIN sgr.residuocadri rec
	ON rec.idResiduo = res.idResiduo
	WHERE
			((p_idCadri IS NULL) OR (rec.idCadri = p_idCadri))
  ;
END
