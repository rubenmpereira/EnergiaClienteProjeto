USE EnergiaClienteDados
GO

CREATE PROCEDURE DetalhesTitular
@habitacao INT
AS
SELECT * FROM Titular T WHERE T.idHabitacao= @habitacao
GO

EXEC DetalhesTitular @habitacao = 1;
