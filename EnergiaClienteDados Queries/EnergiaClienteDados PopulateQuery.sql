Insert Utilizador(email,contacto,genero,nif,nomeCompleto,palavraPasse)
Values  ('brunoaveiro@gmail.com','917765665',0,'227883957','Bruno Gulherme Frenandes Agustinho','passesecreta'),
		('julianavita@gmail.com','936627884',1,'462789305','Juliana castro','passe123')


Insert Habitacao(emailUtilizador,potencia,fase,nivelTensao,horario)
Values  ('brunoaveiro@gmail.com',6.9,'monofasico','baixo','simples'),
		('julianavita@gmail.com',6.9,'monofasico','baixo','simples')


Insert Fatura(idHabitacao,numero,valor,pago,dataInicio,dataFim,dataLimite)
Values  (1,'HGYT45HJFG',45.80,1,'12-5-2023','1-5-2024','1-30-2024'),
		(2,'HGYT67QWE',86,1,'9-5-2023','10-5-2023','10-30-2023'),
		(2,'HGYT67ASD',92,0,'10-5-2023','11-5-2023','11-30-2023'),
		(2,'HGYT67ZCX',84,0,'11-5-2023','12-5-2023','12-30-2023'),
		(2,'HGYT67RTY',89,0,'12-5-2023','1-5-2024','1-30-2024')

Insert Documento(numeroFatura,ficheiro)
Values  ('HGYT45HJFG',CAST('w' AS VARBINARY(1))),
		('HGYT67QWE',CAST('w' AS VARBINARY(1))),
		('HGYT67ASD',CAST('w' AS VARBINARY(1))),
		('HGYT67ZCX',CAST('w' AS VARBINARY(1))),
		('HGYT67RTY',CAST('w' AS VARBINARY(1)))

Insert Leitura(idHabitacao,estimada,mes,ano,vazio,ponta,cheias,dataLeitura)
Values  (1,0,12,2023,20000,19300,7500,'1-4-2024'),
		(2,0,9,2023,127000,89000,56000,'10-4-2023'),
		(2,1,10,2023,135000,93000,59000,'11-4-2023'),
		(2,1,11,2023,146000,97000,67000,'12-4-2023'),
		(2,1,12,2023,174000,102000,69000,'1-4-2024')
