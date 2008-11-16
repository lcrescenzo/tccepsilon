USE SGR;

DROP PROCEDURE IF EXISTS sp_RemoveResiduosCadri_d;

CREATE PROCEDURE sp_RemoveResiduosCadri_d 
(
	p_idCadri INT
)
BEGIN

	DELETE FROM sgr.residuocadri
	WHERE (residuocadri.idCadri = p_idCadri)
	AND residuocadri.idResiduo NOT IN (SELECT mov.idResiduo FROM movimentacao mov WHERE mov.idCadri = p_idCadri);

END