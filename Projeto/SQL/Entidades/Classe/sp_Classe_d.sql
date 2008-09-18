USE sgr;

DROP PROCEDURE IF EXISTS sp_Classe_d;

CREATE PROCEDURE sp_Classe_d 
(
	p_idClasse INT
)
BEGIN
	
	DELETE FROM sgr.classe 
	WHERE idClasse = p_idClasse 
	;

END