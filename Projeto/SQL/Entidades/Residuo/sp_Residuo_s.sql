USE SGR;

DROP PROCEDURE IF EXISTS sp_Residuo_s;

CREATE PROCEDURE sp_Residuo_s 
(
	p_idTipoResiduo INT,
  p_idClasse INT,
  p_idGrupoResiduo INT,
  p_nome VARCHAR(100),
  p_estFisico CHAR(1),
  p_auditoria BIT 
)
BEGIN

	SELECT 
		idResiduo,
  	idTipoResiduo,
  	idClasse,
  	idGrupoResiduo,
  	nome,
  	estFisico,
  	auditoria,
  	unidadeMedida 
	FROM 
			sgr.residuo
	WHERE   
  ((p_idTipoResiduo IS NULL) OR (idTipoResiduo = p_idTipoResiduo))
  AND ((p_idClasse IS NULL) OR (idClasse = p_idClasse))
  AND ((p_idGrupoResiduo IS NULL) OR (idGrupoResiduo = p_idGrupoResiduo))
  AND ((p_nome IS NULL) OR (nome LIKE CONCAT('%', p_nome, '%')))
  AND ((p_estFisico IS NULL) OR (p_estFisico = estFisico))
  AND ((p_auditoria IS NULL) OR (p_auditoria  = auditoria))
;
END
