﻿ALTER TABLE [Pulverisateur] ALTER COLUMN largeur TEXT(255);
ALTER TABLE [Pulverisateur] ALTER COLUMN nombrerangs TEXT(255);
-- CREATION DE LA TABLE CONTROLE_REGULIER
-- CREATE TABLE CONTROLE_REGULIER (CTRG_ID AUTOINCREMENT PRIMARY KEY,CTRG_DATE DATETIME,CTRG_STRUCTUREID int, CTRG_TYPE TEXT(10), CTRG_MATID TEXT(255), CTRG_ETAT TEXT(255), dateModificationAgent DATETIME ,dateModificationCrodip DATETIME)
-- CREATION d'UNE TABLE VERSION
-- CREATE TABLE VERSION (VERSION_NUM TEXT(255),VERSION_DATE DATETIME,VERSION_COMM TEXT(255))
-- CREATE TABLE REFERENTIELS (CODE TEXT(255),dateModificationCrodip DATETIME,LIBELLE TEXT(255));
-- INSERT INTO REFERENTIELS (CODE,LIBELLE,dateModificationCrodip) VALUES ("APE", "Code APE" , #01/01/1970#);
-- INSERT INTO REFERENTIELS (CODE,LIBELLE,dateModificationCrodip) VALUES ("PULVETYPECAT", "types de pulvérisateurs par catégorie" , #01/01/1970#);
-- INSERT INTO REFERENTIELS (CODE,LIBELLE,dateModificationCrodip) VALUES ("PULVEMARQUESMODELES", "Modèles de pulvérisateurs par marque" , #01/01/1970#);
-- INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.001",#25/03/2013#, "creation des refetentiels")