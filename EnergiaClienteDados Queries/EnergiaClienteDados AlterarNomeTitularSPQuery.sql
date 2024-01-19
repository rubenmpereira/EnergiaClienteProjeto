USE EnergiaClienteDados
GO

CREATE PROCEDURE AlterarNomeTitular
@habitacao INT,
@nomeCompleto NVARCHAR(250)
AS
UPDATE Titular
SET nomeCompleto = @nomeCompleto
WHERE idHabitacao = @habitacao
GO

EXEC AlterarNomeTitular @habitacao = 1,@nomeCompleto='Nuno Frederico';

