CREATE DATABASE InLock_Games_Tarde;
USE InLock_Games_Tarde;

CREATE TABLE Estudios (
IdEstudio INT PRIMARY KEY IDENTITY,
NomeEstudio VARCHAR (255),
);

CREATE TABLE Jogos (
IdJogo  INT PRIMARY KEY IDENTITY,
NomeJogo VARCHAR (255) UNIQUE,
Descricao VARCHAR (255)  NOT NULL,
DataLancamento DATE  NOT NULL,
Valor DECIMAL NOT NULL,
IdEstudio  INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);



CREATE TABLE TipoUsuarios (
IdTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR (255)
);

CREATE TABLE Usuarios (
IdUsuario  INT PRIMARY KEY IDENTITY,
Email VARCHAR (255) UNIQUE,
Senha VARCHAR (255) NOT NULL,
IdTipoUsuario  INT FOREIGN KEY REFERENCES TipoUsuarios (IdTipoUsuario)
);

SELECT J.IdJogo, J.NomeJogo , J.Descricao , J.DataLancamento , J.Valor ,  E.NomeEstudio, J.IdEstudio FROM Jogos  J LEFT JOIN Estudios E on E.IdEstudio = J.IdEstudio