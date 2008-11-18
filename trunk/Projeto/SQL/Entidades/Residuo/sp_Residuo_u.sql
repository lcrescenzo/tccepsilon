USE sgr;

DROP PROCEDURE IF EXISTS sp_Residuo_u;

CREATE PROCEDURE sp_Residuo_u 
(
	p_idResiduo INT,
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
	
	UPDATE sgr.residuo 
	SET 
		idTipoResiduo = p_idTipoResiduo, 
		idClasse = p_idClasse, 
		idGrupoResiduo = p_idGrupoResiduo, 
		nome = p_nome, 
		estFisico = p_estFisico, 
		auditoria = p_auditoria, 
		unidadeMedida = p_unidadeMedida 
	WHERE 
		idResiduo = p_idResiduo
;

	CALL sp_HistoricoAlterar_i(p_idUsuario,	10, p_idResiduo);
	
END