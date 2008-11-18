USE sgr;

DROP PROCEDURE IF EXISTS sp_Residuo_i;

CREATE PROCEDURE sp_Residuo_i
(
  p_idTipoResiduo INT,
  p_idClasse INT,
  p_idGrupoResiduo INT,
  p_nome VARCHAR(100),
  p_estFisico CHAR(1),
  p_auditoria BIT,
  p_unidadeMedida CHAR(3),
	p_idUsuario INT
)
BEGIN
	DECLARE id INT;
	
	SET id = fn_CapturaIdentificador('Residuo');


	INSERT INTO sgr.residuo
	(idResiduo, idTipoResiduo, idClasse, idGrupoResiduo, nome, estFisico, auditoria, unidadeMedida) 
	VALUES (id, p_idTipoResiduo, p_idClasse, p_idGrupoResiduo, p_nome, p_estFisico, p_auditoria, p_unidadeMedida);

	CALL sp_HistoricoIncluir_i(p_idUsuario,	10, id);
	
	SELECT id;
	
END
