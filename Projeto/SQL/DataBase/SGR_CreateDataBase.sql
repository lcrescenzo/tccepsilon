
CREATE DATABASE SGR;

USE sgr;

CREATE TABLE TipoRecurso (
  idTipoRecurso CHAR(1) NOT NULL,
  descricao VARCHAR(40) NULL,
  PRIMARY KEY(idTipoRecurso)
);

CREATE TABLE GrupoResiduo (
  idGrupoResiduo INT NOT NULL,
  nome VARCHAR(50) NULL,
  PRIMARY KEY(idGrupoResiduo)
);

CREATE TABLE Manutencao (
  idManutencao INT NOT NULL,
  descricao VARCHAR(20) NULL,
  PRIMARY KEY(idManutencao)
);

CREATE TABLE Perfil (
  idPerfil INT NOT NULL,
  descricao VARCHAR(40) NULL,
  PRIMARY KEY(idPerfil)
);

CREATE TABLE TipoResiduo (
  idTipoResiduo INT NOT NULL,
  descricao VARCHAR(50) NULL,
  PRIMARY KEY(idTipoResiduo)
);

CREATE TABLE TabelaIdentificador (
  nomeTabela VARCHAR(40) NOT NULL,
  ultimoID INT NULL,
  PRIMARY KEY(nomeTabela)
);

CREATE TABLE Classe (
  idClasse INT NOT NULL,
  descricao VARCHAR(50) NULL,
  PRIMARY KEY(idClasse)
);

CREATE TABLE Cadri (
  idCadri INT NOT NULL,
  numero INT UNSIGNED NOT NULL,
  destino VARCHAR(45) NULL,
  quantidade DECIMAL(20,4) NULL,
  OI INT NULL,
  validade DATETIME NULL,
  PRIMARY KEY(idCadri),
  UNIQUE INDEX ux_Cadri_numero(numero)
);

CREATE TABLE Estado (
  idEstado INT NOT NULL,
  descricao VARCHAR(30) NOT NULL,
  PRIMARY KEY(idEstado)
);

CREATE TABLE Entidade (
  idEntidade INT NOT NULL,
  descricao VARCHAR(45) NOT NULL,
  PRIMARY KEY(idEntidade)
);

CREATE TABLE Recurso (
  idRecurso INT NOT NULL,
  idTipoRecurso CHAR(1) NOT NULL,
  idRecursoPai INT NOT NULL,
  nome VARCHAR(50) NULL,
  componente VARCHAR(50) NULL,
  PRIMARY KEY(idRecurso),
  INDEX Recurso_FKIndex1(idRecursoPai),
  INDEX Recurso_FKIndex3(idTipoRecurso),
  FOREIGN KEY(idRecursoPai)
    REFERENCES Recurso(idRecurso)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idTipoRecurso)
    REFERENCES TipoRecurso(idTipoRecurso)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Usuario (
  idUsuario INT NOT NULL,
  nome VARCHAR(50) NULL,
  idPerfil INT NULL,
  CPF VARCHAR(15) NULL,
  email VARCHAR(100) NULL,
  telefone VARCHAR(10) NULL,
  endereco VARCHAR(200) NULL,
  PRIMARY KEY(idUsuario),
  INDEX Usuario_FKidPerfil(idPerfil),
  UNIQUE INDEX ux_Usuario(CPF),
  FOREIGN KEY(idPerfil)
    REFERENCES Perfil(idPerfil)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Login (
  idUsuario INT NOT NULL,
  login VARCHAR(30) NOT NULL,
  senha VARCHAR(200) BINARY NOT NULL,
  PRIMARY KEY(idUsuario),
  INDEX Login_FKidUsuario(idUsuario),
  FOREIGN KEY(idUsuario)
    REFERENCES Usuario(idUsuario)
      ON DELETE RESTRICT
      ON UPDATE CASCADE
);

CREATE TABLE RecursoPerfil (
  idPerfil INT NOT NULL,
  idRecurso INT NOT NULL,
  PRIMARY KEY(idPerfil, idRecurso),
  INDEX RecursoPerfil_FKidRecurso(idRecurso),
  INDEX RecursoPerfil_FKidPerfil(idPerfil),
  FOREIGN KEY(idRecurso)
    REFERENCES Recurso(idRecurso)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idPerfil)
    REFERENCES Perfil(idPerfil)
      ON DELETE RESTRICT
      ON UPDATE CASCADE
);

CREATE TABLE Historico (
  idHistorico INT NOT NULL,
  idUsuario INT NOT NULL,
  idEntidade INT NOT NULL,
  idManutencao INT NOT NULL,
  dataAlteracao DATETIME NULL,
  idmantido INT NOT NULL,
  PRIMARY KEY(idHistorico),
  INDEX TLog_FKidManutencao(idManutencao),
  INDEX TLog_FKidEntidade(idEntidade),
  INDEX TLog_FKIndex3(idUsuario),
  FOREIGN KEY(idManutencao)
    REFERENCES Manutencao(idManutencao)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idEntidade)
    REFERENCES Entidade(idEntidade)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idUsuario)
    REFERENCES Usuario(idUsuario)
      ON DELETE RESTRICT
      ON UPDATE CASCADE
);

CREATE TABLE Residuo (
  idResiduo INT NOT NULL,
  idTipoResiduo INT NOT NULL,
  idClasse INT NOT NULL,
  idGrupoResiduo INT NOT NULL,
  nome VARCHAR(100) NULL,
  estFisico CHAR(1) NULL,
  auditoria BIT NULL,
  unidadeMedida CHAR(3) NULL,
  PRIMARY KEY(idResiduo),
  INDEX Residuo_FKidClasse(idClasse),
  INDEX Residuo_FKidTipoResiduo(idTipoResiduo),
  INDEX Residuo_FKIndex3(idGrupoResiduo),
  FOREIGN KEY(idClasse)
    REFERENCES Classe(idClasse)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idTipoResiduo)
    REFERENCES TipoResiduo(idTipoResiduo)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idGrupoResiduo)
    REFERENCES GrupoResiduo(idGrupoResiduo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Configuracao (
  idUsuario INT NULL,
  chave CHAR(20) NOT NULL,
  valor VARCHAR(8000) NULL,
  INDEX Configuracao_FKIndex1(idUsuario),
  FOREIGN KEY(idUsuario)
    REFERENCES Usuario(idUsuario)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE ResiduoCadri (
  idCadri INT NOT NULL,
  idResiduo INT NOT NULL,
  PRIMARY KEY(idCadri, idResiduo),
  INDEX ResiduoCadri_FKIndex1(idResiduo),
  INDEX ResiduoCadri_FKIndex2(idCadri),
  FOREIGN KEY(idResiduo)
    REFERENCES Residuo(idResiduo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(idCadri)
    REFERENCES Cadri(idCadri)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Movimentacao (
  idMovimentacao INT NOT NULL,
  idResiduo INT NOT NULL,
  idCadri INT NOT NULL,
  idUsuario INT NOT NULL,
  PRIMARY KEY(idMovimentacao),
  INDEX Movimentacao_FKidusuario(idUsuario),
  INDEX Movimentacao_FKIndex2(idCadri, idResiduo),
  FOREIGN KEY(idUsuario)
    REFERENCES Usuario(idUsuario)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idCadri, idResiduo)
    REFERENCES ResiduoCadri(idCadri, idResiduo)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Transporte (
  idTransporte INT NOT NULL,
  dataSaida DATETIME NOT NULL,
  qtdSaida DECIMAL(20,4) NOT NULL,
  transportadora VARCHAR(100) NULL,
  idEstado INT NOT NULL,
  idUsuario INT NOT NULL,
  idMovimentacao INT NOT NULL,
  PRIMARY KEY(idTransporte),
  INDEX Transporte_FKidMovimentacao(idMovimentacao),
  INDEX Transporte_FKidUsuario(idUsuario),
  INDEX Transporte_FKIdEstado(idEstado),
  FOREIGN KEY(idMovimentacao)
    REFERENCES Movimentacao(idMovimentacao)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idUsuario)
    REFERENCES Usuario(idUsuario)
      ON DELETE RESTRICT
      ON UPDATE CASCADE,
  FOREIGN KEY(idEstado)
    REFERENCES Estado(idEstado)
      ON DELETE RESTRICT
      ON UPDATE CASCADE
);

-- INSERT PADRÃO DAS TABELAS 

-- TabelaIdentificador
INSERT INTO TabelaIdentificador VALUES ('Perfil', 0);
INSERT INTO TabelaIdentificador VALUES ('Recurso', 0); 
INSERT INTO TabelaIdentificador VALUES ('TipoResiduo', 0); 
INSERT INTO TabelaIdentificador VALUES ('GrupoResiduo', 0); 
INSERT INTO TabelaIdentificador VALUES ('Classe', 0); 
INSERT INTO TabelaIdentificador VALUES ('Entidade', 0); 
INSERT INTO TabelaIdentificador VALUES ('Estado', 0); 
INSERT INTO TabelaIdentificador VALUES ('Cadri', 0); 
INSERT INTO TabelaIdentificador VALUES ('Usuario', 0); 
INSERT INTO TabelaIdentificador VALUES ('Historico', 0); 
INSERT INTO TabelaIdentificador VALUES ('Residuo', 0);
INSERT INTO TabelaIdentificador VALUES ('Movimentacao', 0); 
INSERT INTO TabelaIdentificador VALUES ('Transporte', 0);

-- Entidade
INSERT INTO Entidade VALUES (1, 'Perfil');
INSERT INTO Entidade VALUES (2, 'Recurso'); 
INSERT INTO Entidade VALUES (3, 'Tipo de Resíduo'); 
INSERT INTO Entidade VALUES (4, 'Grupo de Resíduo'); 
INSERT INTO Entidade VALUES (5, 'Classe'); 
INSERT INTO Entidade VALUES (6, 'Estado'); 
INSERT INTO Entidade VALUES (7, 'Cadri'); 
INSERT INTO Entidade VALUES (8, 'Usuario'); 
INSERT INTO Entidade VALUES (9, 'Histórico'); 
INSERT INTO Entidade VALUES (10, 'Resíduo');
INSERT INTO Entidade VALUES (11, 'Movimentacao'); 
INSERT INTO Entidade VALUES (12, 'Transporte');


-- Manutencao
INSERT INTO Manutencao VALUES (1, 'Incluir');
INSERT INTO Manutencao VALUES (2, 'Alterar'); 
INSERT INTO Manutencao VALUES (3, 'Excluir'); 


INSERT INTO TipoRecurso VALUES ('M', 'Menu');
INSERT INTO TipoRecurso VALUES ('P', 'Página');
INSERT INTO TipoRecurso VALUES ('B', 'Botão');

-- Usuário admin
INSERT INTO Usuario VALUES (-1, 'Grupo Epsilon', NULL, '000000000000', 'grupoepsilon@gmail.com', '00000000', 'USCS - Universidade de São Caetano do Sul');
INSERT INTO Login VALUES (-1, 'epsilon', '846c81d2255f2922e3c5ad9bbaa70c2');-- sgrweb