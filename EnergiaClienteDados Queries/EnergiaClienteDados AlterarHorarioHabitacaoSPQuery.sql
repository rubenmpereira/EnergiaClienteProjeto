USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarHorarioHabitacao
@habitacao INT,
@horario NVARCHAR(50)
AS
UPDATE Habitacao
SET horario = @horario
WHERE id = @habitacao
GO

EXEC AlterarHorarioHabitacao @habitacao = 1,@horario='simples';

