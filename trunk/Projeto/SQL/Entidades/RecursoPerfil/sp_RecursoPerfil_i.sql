USE sgr;

DROP PROCEDURE IF EXISTS sp_RecursoPerfil_i;

CREATE PROCEDURE sp_RecursoPerfil_i
(
  p_idPerfil INT, 
	p_idRecurso INT
)
BEGIN
	
	INSERT INTO sgr.recursoperfil
	(idPerfil, idRecurso) 
	VALUES (p_idPerfil, p_idRecurso);


END
