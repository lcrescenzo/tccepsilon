USE sgr;

DROP PROCEDURE IF EXISTS sp_Login_i;

CREATE PROCEDURE sp_Login_i
(
  p_idUsuario INT,
	p_login VARCHAR(30),
	p_senha VARCHAR(200)
)
BEGIN
	
	INSERT INTO sgr.login
	(idUsuario, login, senha) 
	VALUES (p_idUsuario, p_login, p_senha);

	SELECT p_idUsuario;
	
END
