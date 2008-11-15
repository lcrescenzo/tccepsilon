USE SGR;

DROP PROCEDURE IF EXISTS sp_PerfilById_s;

CREATE PROCEDURE sp_PerfilById_s 
(
  p_idPerfil INT	
)
BEGIN

	SELECT 
		idPerfil, 
		descricao 
	FROM 
		sgr.perfil
	WHERE
		((p_idPerfil IS NULL) OR (idPerfil = p_idPerfil))
	;
END
