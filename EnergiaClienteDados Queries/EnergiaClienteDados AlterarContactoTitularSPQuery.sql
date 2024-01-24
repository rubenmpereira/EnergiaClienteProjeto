USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarContactoTitular
@habitacao INT,
@contacto NVARCHAR(9)
AS
UPDATE Titular
SET contacto = @contacto
WHERE idHabitacao = @habitacao
GO

EXEC AlterarContactoTitular @habitacao = 1,@contacto='910000000';
