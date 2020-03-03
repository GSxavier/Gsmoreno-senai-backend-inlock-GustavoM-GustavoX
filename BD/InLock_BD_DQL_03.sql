USE InLock_Games_Tarde;

SELECT * FROM Usuarios;
SELECT * FROM Estudios;
SELECT * FROM Jogos;

SELECT IdJogo, NomeJogo,NomeEstudio FROM Jogos
INNER JOIN Estudios on Estudios.IdEstudio = Jogos.IdEstudio;

SELECT  NomeEstudio, NomeJogo FROM Estudios
LEFT JOIN Jogos on Jogos.IdEstudio = Estudios.IdEstudio

SELECT Email, Senha FROM Usuarios
where Email  like 'adimin%';

SELECT * FROM Jogos 
where IdJogo = 2;

select * from Estudios
where IdEstudio = 1;





