USE SGR;
-- B = Botão
-- M = Menu
-- P = Página
-- A = Ação

-- Avaliar se irá existir(Backup)
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (0, 'P', NULL, 'Avisos', '~/Telas/Home.aspx');

-- -- -- Manutenção
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1, 'M', NULL, 'Cadastros', 'mnuManutencao');
-- CADRI
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1100, 'P', 1, 'CADRI', '~/Telas/Manutencao/CADRI/Consulta.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1101, 'A', 1100, 'Consultar', '');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1102, 'A', 1100, 'Manter', '');
-- Grupo de Resíduo
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1200, 'P', 1, 'Grupo de Resíduos', '~/Telas/Manutencao/GrupoResiduo/Consulta.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1201, 'A', 1200, 'Consultar', '');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1202, 'A', 1200, 'Manter', '');
-- Movimentação 
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1300, 'P', 1, 'Movimentação', '~/Telas/Manutencao/Movimentacao/Movimentacao.aspx');

-- Resíduo
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1400, 'P', 1, 'Resíduo', '~/Telas/Manutencao/Residuo/Consulta.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1401, 'A', 1400, 'Consultar', '');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (1402, 'A', 1400, 'Manter', '');

-- -- -- Configuração
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (2, 'M', NULL, 'Configuração', 'mnuConfiguracao');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (2100, 'P', 2, 'Sistema', '~/Telas/Administracao/Configuracao/Sistema.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (2200, 'P', 2, 'Usuario', '~/Telas/Administracao/Configuracao/Usuario.aspx');

-- -- -- Administração
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3, 'M', NULL, 'Administração', 'mnuAdministracao');
-- Perfil
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3100, 'P', 3, 'Perfil', '~/Telas/Administracao/Perfil/Consulta.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3101, 'A', 3100, 'Consultar', '');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3102, 'A', 3100, 'Manter', '');
-- Usuário
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3200, 'P', 3, 'Usuário', '~/Telas/Administracao/Usuario/Consulta.aspx');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3201, 'A', 3200, 'Consultar', '');
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (3202, 'A', 3200, 'Manter', '');

-- Dados do usuário (Meus Dados) 
-- INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (4, 'P', NULL, 'Meus Dados', '~/Telas/MeusDados.aspx');

-- Avaliar se irá existir(Backup)
-- INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (5, 'P', NULL, 'Backup', '~/Telas/Backup.aspx');

-- Info Sistema 
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (6, 'P', NULL, 'Sobre o Sistema', '~/Telas/Sistema/Sobre.aspx');
-- INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (6100, 'P', 6, 'Sobre', '~/Telas/Sistema/Sobre.aspx');

-- Sair
INSERT INTO sgr.recurso (idRecurso, idTipoRecurso, idRecursoPai, nome, componente)  VALUES (7, 'P', NULL, 'Sair', '~/Telas/Sistema/Sair.aspx');
