USE EnergiaClienteDados
GO

CREATE PROCEDURE UltimasFaturas
@habitacao INT
AS
SELECT TOP(10) *,(select D.ficheiro from Documento D Where D.numeroFatura=F.numero) as documento FROM Fatura F WHERE F.idHabitacao = @habitacao
GO

EXEC UltimasFaturas @habitacao = 1;

