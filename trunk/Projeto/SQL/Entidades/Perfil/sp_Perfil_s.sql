USE SGR;

DROP PROCEDURE IF EXISTS sp_Perfil_s;

CREATE PROCEDURE sp_Perfil_s 
(
	p_descricao VARCHAR(40)
)
BEGIN

	SELECT 
		idPerfil, 
		descricao 
	FROM 
		sgr.perfil
	WHERE
		((p_descricao IS NULL) OR (descricao LIKE CONCAT('%', p_descricao, '%')))
	;
END
