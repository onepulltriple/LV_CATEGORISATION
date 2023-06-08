USE MASTER
DROP DATABASE LV_CATEGORISATION

CREATE DATABASE LV_CATEGORISATION
GO

USE LV_CATEGORISATION

----DROP TABLE CATEGORIES
--CREATE TABLE CATEGORIES (
--	id int PRIMARY KEY IDENTITY(1,1),
--	Name varchar(50) NOT NULL
--	)

--SELECT * FROM CATEGORIES


--DROP TABLE RESULTS
CREATE TABLE RESULTS (
	id int PRIMARY KEY IDENTITY(1,1),
	Positionsnummer varchar(20), -- resize to 100 later
	Kurztext varchar(1000),
	Menge decimal,
	Einheiten varchar(20),
	Langtext varchar(8000),
	Lokale varchar(50),
	Filter varchar(50),
	Beschreibung varchar(500), 
	WeitereBemerkungen varchar(500),
	Treffer varchar(500)
	)

SELECT * FROM RESULTS

