USE InLock_Games_Tarde;


INSERT INTO TipoUsuarios (Titulo)
VALUES ('ADMINISTRADOR') , ('CLIENTE');

INSERT INTO Usuarios ( Email, Senha , IdTipoUsuario)
VALUES ( 'adimin@admin.com', 'adimin',1) ,('cliente@cliente.com','cliente',2);

INSERT INTO Estudios (NomeEstudio)
VALUES ('Blizard') ,('Rockstar Studios'), ('Square Enix');

INSERT INTO Jogos ( NomeJogo, Descricao, DataLancamento ,Valor, IdEstudio)
VALUES ('Red Dead Redemption 2', 'jogo eletronico de acao-aventura western','26/10/2018',120.00,2),
('Diablo 3', ' E um jogo que contem bastante acao e é viciante seja você um novato ou um fã', '15/05/2012',99.00, 1)
 
 