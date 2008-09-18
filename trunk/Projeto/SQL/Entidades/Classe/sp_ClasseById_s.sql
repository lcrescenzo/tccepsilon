USE SGR;

DROP PROCEDURE IF EXISTS sp_ClasseById_s;

CREATE PROCEDURE sp_ClasseById_s 
(
  p_idClasse INT
)
BEGIN

	SELECT 
		idClasse, 
		descricao 
	FROM 
		sgr.classe
	WHERE  
		((p_idClasse IS NULL) OR (idClasse = p_idClasse))
	;
END
