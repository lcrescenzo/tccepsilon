USE SGR;

DROP PROCEDURE IF EXISTS sp_TipoResiduo_s;

CREATE PROCEDURE sp_TipoResiduo_s 
(
  p_idTipoResiduo INT,
	p_descricao VARCHAR(50)
)
BEGIN

	SELECT 
		idTipoResiduo, 
		descricao 
	FROM 
		sgr.tiporesiduo
	WHERE 
		((p_idTipoResiduo IS NULL) OR (idTipoResiduo = p_idTipoResiduo))
	AND	((p_descricao IS NULL) OR (descricao LIKE CONCAT('%', p_descricao, '%')))
	;

END
