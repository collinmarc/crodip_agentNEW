DELETE FROM AGENTPC;
DELETE FROM POOL;
DELETE FROM POOLMANOC;
DELETE FROM POOLMANOE;

CREATE TABLE Agent2 (Id                     INT            PRIMARY KEY,numeroNational         NVARCHAR (50)  UNIQUE,motdepasse             NVARCHAR (255),nom                    VARCHAR (256),prenom                 VARCHAR (256),idStructure            INT            REFERENCES Structure (id) ON DELETE CASCADE,telephoneportable      VARCHAR (256),email                  VARCHAR (256),dateCreation           DATETIME2,dateDerniereConnexion  DATETIME2,dateDerniereSynchro    DATETIME2,dateModificationAgent  DATETIME2,dateModificationCrodip DATETIME2,versionLogiciel        VARCHAR (256),commentaire            VARCHAR (256),cleActivation          VARCHAR (256),isActif                BIT            DEFAULT 0,droitsPulves           VARCHAR (2560),isGestionnaire         BIT            DEFAULT 0,signatureElect         BIT            DEFAULT 0,statut                 VARCHAR (50));
INSERT INTO Agent2 (Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut) SELECT Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut from Agent
ALTER TABLE Agent RENAME TO AGENT_ADEL;
ALTER TABLE Agent2 RENAME TO AGENT;

CREATE TABLE IdentifiantPulverisateur2 (id                     INT            NOT NULL PRIMARY KEY,idStructure            INT            REFERENCES Structure (id) ON DELETE CASCADE,numeroNational         NVARCHAR (30)  NOT NULL,etat                   NVARCHAR (30),dateUtilisation        NVARCHAR (255),libelle                NVARCHAR (255),dateModificationAgent  NVARCHAR (255),dateModificationCrodip NVARCHAR (255));
INSERT INTO IdentifiantPulverisateur2 (id,idStructure,numeroNational,etat,dateUtilisation,libelle,dateModificationAgent,dateModificationCrodip) SELECT id,idStructure,numeroNational,etat,dateUtilisation,libelle,dateModificationAgent,dateModificationCrodip FROM IdentifiantPulverisateur
ALTER TABLE IdentifiantPulverisateur RENAME TO IdentifiantPulverisateur_ADEL;
ALTER TABLE IdentifiantPulverisateur2 RENAME TO IdentifiantPulverisateur;

