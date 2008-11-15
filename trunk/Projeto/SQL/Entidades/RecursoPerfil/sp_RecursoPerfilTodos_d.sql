USE sgr;

DROP PROCEDURE IF EXISTS sp_RecursoPerfilTodos_d;

CREATE PROCEDURE sp_RecursoPerfilTodos_d 
(
	p_idPerfil INT
)
BEGIN
	
	DELETE FROM sgr.recursoperfil 
	WHERE idPerfil = p_idPerfil ;

END