USE EnergiaClienteDados
GO

CREATE PROCEDURE DetalhesUtilizador
@email nvarchar(320)
AS
SELECT U.email,U.nomeCompleto,U.nif,U.contacto,U.genero FROM Utilizador U WHERE U.email= @email
GO

EXEC DetalhesUtilizador @email = 'brunoaveiro@gmail.com';
