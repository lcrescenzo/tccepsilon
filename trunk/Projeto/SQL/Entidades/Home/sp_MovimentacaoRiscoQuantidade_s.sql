USE SGR;

DROP PROCEDURE IF EXISTS sp_MovimentacaoRiscoQuantidade_s;

CREATE PROCEDURE sp_MovimentacaoRiscoQuantidade_s 
(
	p_percentualCritico DECIMAL(10,2)
)
BEGIN

	SELECT 
		mov.idMovimentacao,
		mov.idCadri,
		mov.idResiduo,
		cad.quantidade permitido,
		sum(tra.qtdSaida) transportado,
		CASE 
			WHEN (p_percentualCritico) < sum(tra.qtdSaida) / cad.quantidade THEN 
			  0 
			WHEN (p_percentualCritico - 0.1) < sum(tra.qtdSaida) / cad.quantidade THEN 
				1
		END criticidade 
	FROM 
		sgr.movimentacao mov, 
		sgr.cadri cad,
		sgr.transporte tra
	WHERE
	  	mov.idCadri = cad.idCadri
	AND mov.idMovimentacao = tra.idMovimentacao
	group by 	mov.idMovimentacao,
						mov.idCadri,
						mov.idResiduo,
						mov.idUsuario,
						cad.quantidade
	having (p_percentualCritico - 0.1) < sum(tra.qtdSaida)/cad.quantidade
  ;
END
