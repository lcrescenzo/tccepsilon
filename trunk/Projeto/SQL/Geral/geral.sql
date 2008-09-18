USE SGR;

DROP FUNCTION IF EXISTS fn_CapturaIdentificador ;

CREATE FUNCTION fn_CapturaIdentificador 
(
	entidade VARCHAR(40)
) 
RETURNS INT
BEGIN
	DECLARE identificador INT; 
	
	UPDATE TabelaIdentificador 
	SET ultimoID = ultimoID + 1
	WHERE 
		nomeTabela = entidade;
		
		
	SET identificador = (SELECT ultimoID FROM TabelaIdentificador WHERE nomeTabela = entidade);
	
	RETURN identificador; 
END