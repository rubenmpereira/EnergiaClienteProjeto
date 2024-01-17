CREATE DATABASE EnergiaClienteDados
GO

USE EnergiaClienteDados
GO

CREATE TABLE Utilizador(
email			NVARCHAR(320) PRIMARY KEY,
palavraPasse	NVARCHAR(250),
nomeCompleto	NVARCHAR(250),
nif				NVARCHAR(9),
contacto		NVARCHAR(9),
genero			BIT
)
GO

CREATE TABLE Habitacao(
id				INT IDENTITY(1,1) PRIMARY KEY,
emailUtilizador	NVARCHAR(320) FOREIGN KEY REFERENCES Utilizador(email),
potencia		DECIMAL,
fase			NVARCHAR(50),
nivelTensao		NVARCHAR(50),
horario			NVARCHAR(50)
)
GO

CREATE TABLE Titular(
idHabitacao		INT FOREIGN KEY REFERENCES Habitacao(id),
nomeCompleto	NVARCHAR(250),
nif				NVARCHAR(9),
contacto		NVARCHAR(9),
)
GO

CREATE TABLE Fatura(
numero			NVARCHAR(250) PRIMARY KEY,
dataInicio		DATE,
dataFim			DATE,
pago			BIT,
valor			DECIMAL,
dataLimite		DATE,
idHabitacao		INT FOREIGN KEY REFERENCES Habitacao(id)
)
GO

CREATE TABLE Documento(
id				INT IDENTITY(1,1) PRIMARY KEY,
numeroFatura	NVARCHAR(250) FOREIGN KEY REFERENCES FATURA(NUMERO),
ficheiro		VARBINARY
)
GO

CREATE TABLE Leitura(
id				INT IDENTITY(1,1) PRIMARY KEY,
vazio			INT,
ponta			INT,
cheias			INT,
mes				int,
ano				int,
dataLeitura		date,
idHabitacao		INT FOREIGN KEY REFERENCES Habitacao(id),
estimada		bit
)
GO