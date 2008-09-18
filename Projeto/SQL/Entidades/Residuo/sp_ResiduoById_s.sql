USE SGR;

DROP PROCEDURE IF EXISTS sp_ResiduoById_s;

CREATE PROCEDURE sp_ResiduoById_s 
(
	p_idResiduo INT
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
			((p_idResiduo IS NULL) OR (idResiduo = p_idResiduo))
  ;
END
