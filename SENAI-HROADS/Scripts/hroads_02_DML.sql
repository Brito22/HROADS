USE SENAI_HROADS_TARDE	
GO

INSERT INTO TIPO_DE_HABILIDADE(NomeTipoHabilidade)
VALUES ('ATAQUE'), ('DEFESA'), ('CURA'), ('MAGIA');
GO

SELECT * FROM TIPO_DE_HABILIDADE
GO

INSERT INTO HABILIDADE (IdTipoHabilidade, NomeHabilidade)
VALUES (1,'LAN�A MORTAL'), (2,'ESCUDO SUPREMO'), (3,'RECUPERAR VIDA'), (NULL, 'NENHUMA');
GO

SELECT * FROM HABILIDADE
GO

INSERT INTO HABILIDADE2 (IdTipoHabilidade, NomeHabilidade2)
VALUES (1,'LAN�A MORTAL'), (2,'ESCUDO SUPREMO'), (3,'RECUPERAR VIDA'), (NULL, 'NENHUMA');
GO

SELECT * FROM HABILIDADE2
GO


INSERT INTO CLASSE (IdHabilidade, IdHabilidade2, NomeClasse)
VALUES (1,2,'BARBARO'), (2,4,'CRUZADO'), (1,4,'CA�ADORA DE DEMONIOS'), (3,2,'MONGE'), (4,4,'NECROMANTE'), (3,4,'FEITICEIRO'), (4,4,'ARCANISTA');
GO

DELETE FROM CLASSE
GO

SELECT * FROM CLASSE
GO

INSERT INTO PERSONAGEM (IdClasse, NomePersonagem, CapMaxVida, CapMaxMana, DataAtt, DateCriacao)
VALUES (1, 'DEUBUG', 100, 80, '10/08/2021', '18/01/2019'), (4, 'BITBUG', 70, 100, '10/08/2021', '17/03/2016'), (7, 'FER8', 75, 60, '10/08/2021', '18/03/2018')
GO

INSERT INTO TIPO_USUARIO(titulo)
VALUES ('Administrador'), ('Comum')
GO

INSERT INTO USUARIO(idTipoUsuario, email, senha)
VALUES (1 , 'admin@admin.com', 'admin'), (2,'comum@comun.com', 'comun')
GO


SELECT * FROM PERSONAGEM
GO

SELECT * FROM TIPO_DE_HABILIDADE
SELECT * FROM HABILIDADE
SELECT * FROM HABILIDADE2
SELECT * FROM CLASSE
SELECT * FROM PERSONAGEM
SELECT * FROM TIPO_USUARIO
SELECT * FROM USUARIO