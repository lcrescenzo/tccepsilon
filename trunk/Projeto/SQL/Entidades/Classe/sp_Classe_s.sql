USE SGR;

DROP PROCEDURE IF EXISTS sp_Classe_s;

CREATE PROCEDURE sp_Classe_s 
(
	p_descricao VARCHAR(50)
)
BEGIN

	SELECT 
		idClasse, 
		descricao 
	FROM 
		sgr.classe
	WHERE  
		((p_descricao IS NULL) OR (descricao = p_descricao))
	;
END
