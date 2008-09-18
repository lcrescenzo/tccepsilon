USE SGR;

DROP PROCEDURE IF EXISTS sp_Historico_s;

CREATE PROCEDURE sp_Historico_s
(
  p_idHistorico INT, 
	p_idUsuario INT, 
	p_idEntidade INT, 
	p_idManutencao INT,  
	p_idmantido INT,
	p_periodoInicio DATETIME,
	p_periodoFim DATETIME	
)
BEGIN

	SELECT 
		idHistorico, 
		idUsuario, 
		idEntidade, 
		idManutencao, 
		dataAlteracao, 
		idmantido 
	FROM 
		sgr.historico
	WHERE 
		((p_idHistorico IS NULL) OR (p_idHistorico = idHistorico)) 
	AND	((p_idUsuario IS NULL) OR (p_idUsuario = idUsuario)) 
	AND	((p_idEntidade IS NULL) OR (p_idEntidade = idEntidade)) 
	AND	((p_idManutencao IS NULL) OR (idManutencao = p_idManutencao))
	AND	((p_idmantido IS NULL) OR (idmantido = p_idmantido)) 
	AND	((p_periodoInicio IS NULL AND p_periodoFim IS NULL) OR (dataAlteracao BETWEEN p_periodoInicio AND p_periodoFim))
	AND	((p_periodoInicio IS NOT NULL AND p_periodoFim IS NULL) OR (dataAlteracao > p_periodoInicio))
	AND	((p_periodoInicio IS NULL AND p_periodoFim IS NOT NULL) OR (dataAlteracao < p_periodoFim))
	;

END
