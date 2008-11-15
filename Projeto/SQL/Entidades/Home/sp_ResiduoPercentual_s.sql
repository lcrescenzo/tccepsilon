USE SGR;

DROP PROCEDURE IF EXISTS sp_ResiduoPercentual_s;

CREATE PROCEDURE sp_ResiduoPercentual_s 
(
	p_qtdResiduos INT,
	p_qtdMeses INT
)
BEGIN

	SET @qtdResiduos = p_qtdResiduos;
	
	SET @dataInicial = DATE_SUB(CURDATE(), INTERVAL p_qtdMeses MONTH);
	SET @dataFinal = NOW(); 
	SET @total = (SELECT SUM(qtdSaida) FROM sgr.transporte WHERE dataSaida BETWEEN @dataInicial AND @dataFinal);
	
	SET @query = CONCAT(' SELECT ',
	' 	res.nome, ',
	' 	(SUM(tra.qtdSaida) / ? ) percentual ',
	' FROM ',
	' 	sgr.transporte tra, ',
	' 	sgr.movimentacao mov, ',
	' 	sgr.residuo res ',
	' WHERE ',
	' 		tra.idMovimentacao = mov.idMovimentacao ',
	' AND res.idResiduo = mov.idResiduo ',
	' AND tra.dataSaida	BETWEEN ? AND ? ', 
	' GROUP BY ',
	' 	mov.idResiduo ',
	' ORDER BY percentual DESC '
	' LIMIT ? '	);
	
	PREPARE STMT FROM @query;
	EXECUTE STMT USING @total, @dataInicial, @dataFinal, @qtdResiduos;
END
