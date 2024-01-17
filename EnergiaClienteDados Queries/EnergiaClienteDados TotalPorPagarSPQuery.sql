USE EnergiaClienteDados
GO

CREATE PROCEDURE TotalPorPagar
@habitacao INT
AS
SELECT SUM(F.valor) AS 'Total' FROM Fatura F WHERE F.idHabitacao=@habitacao AND F.pago=0
GO

EXEC TotalPorPagar @habitacao = 2;

