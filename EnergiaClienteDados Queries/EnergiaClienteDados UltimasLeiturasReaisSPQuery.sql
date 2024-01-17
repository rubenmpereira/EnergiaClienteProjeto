USE EnergiaClienteDados
GO

CREATE PROCEDURE UltimasLeiturasReais
@habitacao INT,
@quantidade INT
AS
SELECT TOP(@quantidade) * FROM Leitura L WHERE L.idHabitacao=@habitacao AND L.estimada=0
GO

EXEC UltimasLeiturasReais @habitacao = 2,@quantidade=6;