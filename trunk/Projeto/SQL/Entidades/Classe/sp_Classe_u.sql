USE sgr;

DROP PROCEDURE IF EXISTS sp_Classe_u;

CREATE PROCEDURE sp_Classe_u 
(
	p_idClasse  INT,
	p_descricao VARCHAR(50)
)
BEGIN
	
	UPDATE sgr.classe 
	SET descricao = p_descricao 
	WHERE 
		idClasse = p_idClasse 
	;

	
END