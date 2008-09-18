USE SGR;

DROP PROCEDURE IF EXISTS sp_Perfil_s;

CREATE PROCEDURE sp_Perfil_s 
(
  P_idPerfil INT	
)
BEGIN

	SELECT 
		idPerfil, 
		descricao 
	FROM 
		sgr.perfil
	WHERE
		((idPerfil IS NULL) OR (idPerfil = P_idPerfil))
	;
END
