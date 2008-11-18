USE SGR;

DROP PROCEDURE IF EXISTS sp_Historico_s;

CREATE PROCEDURE sp_Historico_s 
(
	p_idUsuario INT, 
	p_idEntidade INT, 
	p_idManutencao INT,  
	p_periodoInicio DATETIME,
	p_periodoFim DATETIME	
)
BEGIN

	SELECT 
		his.idHistorico, 
		usu.login, 
		ent.descricao entidade, 
		man.descricao manutencao, 
		his.dataAlteracao, 
		his.idmantido 
	FROM 
		sgr.historico his
		INNER JOIN sgr.entidade ent ON his.idEntidade = ent.idEntidade
		INNER JOIN sgr.manutencao man ON his.idManutencao = man.idManutencao
		INNER JOIN sgr.login usu ON his.idUsuario = usu.idUsuario
	WHERE 
		((p_idUsuario IS NULL) OR (p_idUsuario = his.idUsuario)) 
	AND	((p_idEntidade IS NULL) OR (p_idEntidade = his.idEntidade)) 
	AND	((p_idManutencao IS NULL) OR (his.idManutencao = p_idManutencao))
	AND	((p_periodoInicio IS NULL AND p_periodoFim IS NULL) OR (his.dataAlteracao BETWEEN p_periodoInicio AND p_periodoFim))
	-- AND	((p_periodoInicio IS NOT NULL AND p_periodoFim IS NULL) OR (his.dataAlteracao > p_periodoInicio))
	-- AND	((p_periodoInicio IS NULL AND p_periodoFim IS NOT NULL) OR (his.dataAlteracao < p_periodoFim))
	;

END
