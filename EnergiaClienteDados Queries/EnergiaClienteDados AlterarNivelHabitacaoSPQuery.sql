USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarNivelHabitacao
@habitacao INT,
@nivelTensao NVARCHAR(50)
AS
UPDATE Habitacao
SET nivelTensao = @nivelTensao
WHERE id = @habitacao
GO

EXEC AlterarNivelHabitacao @habitacao = 1,@nivelTensao='mono';