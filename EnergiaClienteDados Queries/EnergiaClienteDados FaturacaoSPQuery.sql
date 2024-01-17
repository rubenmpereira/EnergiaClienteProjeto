USE EnergiaClienteDados
GO

CREATE PROCEDURE Faturacao
@habitacao	INT,
@numero		nvarchar(250),
@valor		DECIMAL,
@pago		BIT,
@dataini	DATE,
@datafim	DATE,
@datalim	DATE,
@documento	VARBINARY
AS
INSERT Fatura(idHabitacao,numero,valor,pago,dataInicio,dataFim,dataLimite)
VALUES  (@habitacao,@numero,@valor,@pago,@dataini,@datafim,@datalim)
INSERT Documento(numeroFatura,ficheiro)
VALUES (@numero,@documento)
GO