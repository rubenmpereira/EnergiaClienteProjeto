USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarNifTitular
@habitacao INT,
@nif NVARCHAR(9)
AS
UPDATE Titular
SET nif = @nif
WHERE idHabitacao = @habitacao
GO

EXEC AlterarNifTitular @habitacao = 1,@nif='256758948';
