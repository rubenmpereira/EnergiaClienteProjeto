USE EnergiaClienteDados
GO

CREATE PROCEDURE DetalhesHabitacao
@habitacao INT
AS
SELECT * FROM Habitacao H WHERE H.id= @habitacao
GO

EXEC DetalhesHabitacao @habitacao = 1;
