USE EnergiaClienteDados
GO

CREATE PROCEDURE AdicionarLeitura
@habitacao INT,
@estimada BIT,
@mes INT,
@ano INT,
@dataLeitura DATE,
@vazio INT,
@ponta INT,
@cheias INT
AS
INSERT Leitura(idHabitacao,estimada,mes,ano,dataLeitura,vazio,ponta,cheias)
VALUES  (@Habitacao,@estimada,@mes,@ano,@dataLeitura,@vazio,@ponta,@cheias)
GO

EXEC AdicionarLeitura @habitacao = 1,@estimada=1,@mes=9,@ano=2023,@dataLeitura='10-05-2023',@vazio=17000,@ponta=15000,@cheias=3000;