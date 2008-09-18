USE SGR;

DROP PROCEDURE IF EXISTS sp_TipoResiduoById_s;

CREATE PROCEDURE sp_TipoResiduoById_s 
(
  p_idTipoResiduo INT
)
BEGIN

	SELECT 
		idTipoResiduo, 
		descricao 
	FROM 
		sgr.tiporesiduo
	WHERE 
		idTipoResiduo = p_idTipoResiduo
	;

END
