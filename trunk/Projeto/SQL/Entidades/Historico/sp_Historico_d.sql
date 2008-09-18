USE sgr;

DROP PROCEDURE IF EXISTS sp_Historico_d;

CREATE PROCEDURE sp_Historico_d 
(
	p_anos INT
)
BEGIN
	
	DELETE FROM sgr.historico 
	WHERE dataAlteracao = 'dataAlteracao' 
	AND year(dataAlteracao) < (year(NOW()) - p_anos)
	AND MONTH(dataAlteracao) < MONTH(NOW()) 
	AND DAY(dataAlteracao) < DAY(NOW()) 
	;

END