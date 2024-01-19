USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarFaseHabitacao
@habitacao INT,
@fase NVARCHAR(50)
AS
UPDATE Habitacao
SET fase = @fase
WHERE id = @habitacao
GO

EXEC AlterarFaseHabitacao @habitacao = 1,@fase='mono';