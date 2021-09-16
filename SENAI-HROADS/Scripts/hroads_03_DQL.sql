USE SENAI_HROADS_TARDE
GO

SELECT * FROM TIPO_DE_HABILIDADE
SELECT * FROM HABILIDADE
SELECT * FROM HABILIDADE2
SELECT * FROM CLASSE
SELECT * FROM PERSONAGEM
GO


--Atualizar o nome do personagem Fer8 para Fer7;

UPDATE PERSONAGEM
SET NomePersonagem = 'FER7'
WHERE IdPersonagem = 6

--Atualizar o nome da classe de Necromante para Necromancer;

UPDATE CLASSE
SET NomeClasse = 'NECROMANCER'
WHERE IdClasse = 5

--Selecionar todos os personagens;

SELECT * FROM PERSONAGEM

--Selecionar todos as classes;

SELECT * FROM CLASSE

--Selecionar somente o nome das classes;

SELECT NomeClasse AS Nome FROM CLASSE

--Selecionar todas as habilidades;

SELECT * FROM HABILIDADE
SELECT * FROM HABILIDADE2

--Realizar a contagem de quantas habilidades estão cadastradas;

SELECT idHabilidade, NomeHabilidade AS Nome FROM HABILIDADE

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente;

SELECT idHabilidade FROM HABILIDADE

--Selecionar todos os tipos de habilidades;

SELECT * FROM TIPO_DE_HABILIDADE

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;

SELECT NomeHabilidade, NomeTipoHabilidade FROM HABILIDADE
LEFT JOIN TIPO_DE_HABILIDADE
ON HABILIDADE.IdTipoHabilidade = TIPO_DE_HABILIDADE.IdTipoHabilidade

--Selecionar todos os personagens e suas respectivas classes;

SELECT NomePersonagem, NomeClasse FROM PERSONAGEM
LEFT JOIN CLASSE
ON PERSONAGEM.IdClasse = CLASSE.IdClasse

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);

SELECT NomePersonagem, NomeClasse FROM PERSONAGEM
RIGHT JOIN CLASSE
ON PERSONAGEM.IdClasse = CLASSE.IdClasse

--Selecionar todas as classes e suas respectivas habilidades;
SELECT NomeClasse, NomeHabilidade , NomeHabilidade2 FROM CLASSE
LEFT JOIN HABILIDADE
ON CLASSE.IdHabilidade = HABILIDADE.IdHabilidade
LEFT JOIN HABILIDADE2
ON CLASSE.IdHabilidade2 = HABILIDADE2.IdHabilidade2

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT NomeClasse, NomeHabilidade , NomeHabilidade2 FROM CLASSE
INNER JOIN HABILIDADE
ON CLASSE.IdHabilidade = HABILIDADE.IdHabilidade
INNER JOIN HABILIDADE2
ON CLASSE.IdHabilidade2 = HABILIDADE2.IdHabilidade2

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT NomeClasse, NomeHabilidade , NomeHabilidade2 FROM CLASSE
FULL OUTER JOIN HABILIDADE
ON CLASSE.IdHabilidade = HABILIDADE.IdHabilidade
FULL OUTER JOIN HABILIDADE2
ON CLASSE.IdHabilidade2 = HABILIDADE2.IdHabilidade2