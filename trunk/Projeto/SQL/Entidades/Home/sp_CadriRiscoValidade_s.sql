USE SGR;

DROP PROCEDURE IF EXISTS sp_CadriRiscoValidade_s;

CREATE PROCEDURE sp_CadriRiscoValidade_s 
(
	p_dias INT
)
BEGIN
	
	SET @p_dataAtual = CURDATE();
	SET @p_dataInicial = DATE_SUB(@p_dataAtual, INTERVAL 10 DAY);
	SET @p_dataFinal = DATE_ADD(@p_dataAtual, INTERVAL p_dias DAY);
	
	SELECT 
			cad.idCadri, 
			cad.numero, 
			cad.destino, 
			cad.quantidade, 
			cad.OI, 
			cad.validade,
			CASE
				WHEN cad.validade > @p_dataAtual AND cad.validade < @p_dataFinal THEN
					0
				WHEN cad.validade < @p_dataAtual AND cad.validade > @p_dataInicial THEN
					1
				ELSE
					2
			END criticidade
	FROM 
			cadri cad
	WHERE   
		cad.validade BETWEEN @p_dataInicial AND @p_dataFinal;
END