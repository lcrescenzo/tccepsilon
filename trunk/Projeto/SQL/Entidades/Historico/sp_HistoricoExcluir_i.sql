USE sgr;

DROP PROCEDURE IF EXISTS sp_HistoricoExcluir_i;

CREATE PROCEDURE sp_HistoricoExcluir_i 
(
	p_idUsuario		int,
	p_idEntidade	int,
	p_idMantido		int
)
BEGIN
	
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Historico');
	
	INSERT INTO historico (
	   idHistorico
	  ,idUsuario
	  ,idEntidade
	  ,idManutencao
	  ,dataAlteracao
	  ,idmantido
	) VALUES (
	   id -- idHistorico
	  ,p_idUsuario -- idUsuario
	  ,p_idEntidade -- idEntidade
	  ,3 -- idManutencao
	  ,NOW() -- dataAlteracao
	  ,p_idMantido -- idmantido
	)
	;
END