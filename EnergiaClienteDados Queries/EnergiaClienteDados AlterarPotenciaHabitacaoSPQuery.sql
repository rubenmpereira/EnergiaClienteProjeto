USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarPotenciaHabitacao
@habitacao INT,
@potencia DECIMAL
AS
UPDATE Habitacao
SET potencia = @potencia
WHERE id = @habitacao
GO

EXEC AlterarPotenciaHabitacao @habitacao = 1,@potencia=6.9;

