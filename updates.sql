--Version 2.5.4.3 
--Ajout de la JamaisServi et DateACTIVATION dans les tables matériel
--ALTER TABLE [BancMesure] ADD jamaisServi YESNO;
--ALTER TABLE [BancMesure] ADD dateActivation DATE
--Update BancMesure set jamaisServi = NO, dateActivation=dateDernierControle;
--ALTER TABLE [AgentManoControle] ADD jamaisServi YESNO;
--ALTER TABLE [AgentManoControle] ADD dateActivation DATE
--Update AgentManoControle set jamaisServi = NO, dateActivation=dateDernierControle;
--ALTER TABLE [AgentManoEtalon] ADD jamaisServi YESNO;
--ALTER TABLE [AgentManoEtalon] ADD dateActivation DATE
--Update AgentManoEtalon set jamaisServi = NO, dateActivation=dateDernierControle;
--ALTER TABLE [AgentBuseEtalon] ADD jamaisServi YESNO;
--ALTER TABLE [AgentBuseEtalon] ADD dateActivation DATE
--Update AgentBuseEtalon set jamaisServi = NO, dateActivation=dateAchat
-- Version 4 Lot 1b
--ALTER TABLE [Diagnostic] ADD controleInitialId VARCHAR(20)
--ALTER TABLE [Diagnostic] ADD pulverisateurAncienId VARCHAR(50)
--ALTER TABLE [pulverisateur] ADD isEclairageRampe YESNO
--ALTER TABLE [pulverisateur] ADD isBarreGuidage YESNO
--ALTER TABLE [pulverisateur] ADD isCoupureAutoTroncons YESNO
--ALTER TABLE [pulverisateur] ADD isRincageAutoAssiste YESNO
--version 4 Lot 2
--UPDATE DIAGNOSTICITEM SET ITEMVALUE="0" where idItem = "831" and itemvalue = "4"
--UPDATE DIAGNOSTICITEM SET ITEMVALUE="0" where idItem = "833" and itemvalue = "4"
-- MAJ VERSION (la date doit être au format #MM/JJ/AAA#
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.2b",#01/13/2015#, "Renommer les DiagItem 831 et 833") 
--ALTER TABLE [Agent] ADD droitsPulves MEMO
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.2c",#02/10/2015#, "Ajout des droitsPulves dans la table Agent") 
--Lot3
-- Modèle Buses
--ALTER TABLE [pulverisateur] ADD buseModele VARCHAR(255)
--ALTER TABLE [Diagnostic] ADD buseModele VARCHAR(255)
--ALTER TABLE [pulverisateur] ADD buseNbniveaux LONG
--ALTER TABLE [pulverisateur] ADD manometreNbniveaux LONG
--ALTER TABLE [pulverisateur] ADD manometreNbtroncons LONG
-- 20150512170000
--ALTER TABLE [pulverisateur] ADD buseCouleur VARCHAR(255)
--ALTER TABLE [Diagnostic] ADD RIFileName VARCHAR(255)
--ALTER TABLE [Diagnostic] ADD SMFileName VARCHAR(255)
--ALTER TABLE [pulverisateur] ADD regulation VARCHAR(255)
--UPDATE Pulverisateur set regulation = "Pression constante" where isPressionconstante
--UPDATE Pulverisateur set regulation = "DPM" where isDPM
--UPDATE Pulverisateur set regulation = "DPA" where isDPA
--UPDATE Pulverisateur set regulation = "DPAE" where isDPAE
--ALTER TABLE [pulverisateur] DROP COLUMN isDPAE
--ALTER TABLE [pulverisateur] DROP COLUMN isDPA
--ALTER TABLE [pulverisateur] DROP COLUMN isDPM
--ALTER TABLE [pulverisateur] DROP COLUMN isPressionconstante
--ALTER TABLE [Diagnostic] ADD pulverisateurRegulation VARCHAR(255)
--UPDATE Diagnostic set pulverisateurRegulation = "Pression constante" where pulverisateurRegulationIsPressionconstante
--UPDATE Diagnostic set pulverisateurRegulation = "DPM" where pulverisateurRegulationIsDPM
--UPDATE Diagnostic set pulverisateurRegulation = "DPA" where pulverisateurRegulationIsDPA
--UPDATE Diagnostic set pulverisateurRegulation = "DPAE" where pulverisateurRegulationIsDPAE
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsPressionconstante
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsDpm
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsDpa
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsDpae

--ALTER TABLE [Agent] ADD isGestionnaire YESNO

--ALTER TABLE [pulverisateur] ADD regulationOptions VARCHAR(255)
--UPDATE Pulverisateur set regulationOptions = "Pression" where isDPAEPression
--UPDATE Pulverisateur set regulationOptions = "Débit" where isDPAEDebit
--ALTER TABLE [pulverisateur] DROP COLUMN isDPAEDebit
--ALTER TABLE [pulverisateur] DROP COLUMN isDPAEPression

--ALTER TABLE [Diagnostic] ADD pulverisateurRegulationOptions VARCHAR(255)
--UPDATE Diagnostic set pulverisateurRegulationOptions = "Pression" where pulverisateurRegulationIsPression
--UPDATE Diagnostic set pulverisateurRegulation = "Débit" where pulverisateurRegulationIsDebit
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsPression
--ALTER TABLE [Diagnostic] DROP COLUMN pulverisateurRegulationIsDebit

--ALTER TABLE [pulverisateur] ADD modeUtilisation VARCHAR(50)
--ALTER TABLE [pulverisateur] ADD nombreExploitants VARCHAR(10)
--ALTER TABLE [Diagnostic] ADD pulverisateurModeUtilisation VARCHAR(50)
--ALTER TABLE [Diagnostic] ADD pulverisateurNbreExploitants VARCHAR(10)

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.3",#05/28/2015#, "Version 20150528170000") 

-- Ajout d'un champs controleEtat Sur pulvé
--ALTER TABLE [pulverisateur] ADD controleEtat VARCHAR(10)
--UPDATE Pulverisateur set controleEtat = ''
--create VIEW controleEtatPulve (ID,Etat) as Select P.id,diagnostic.controleEtat FROM  diagnostic, pulverisateur P WHERE diagnostic.pulverisateurid = p.id and Diagnostic.controleDateFin = (SELECT MAX(Diagnostic.controleDateFin)FROM Diagnostic WHERE Diagnostic.pulverisateurId = P.id AND diagnostic.pulverisateurid = P.id)
--UPDATE  Pulverisateur P INNER JOIN ControleEtatPulve CTRL ON  P.ID = CTRL.ID SET P.ControleEtat = CTRL.etat
--DROP VIEW ControleEtatPulve

--ALTER TABLE [Diagnostic] ADD buseFonctionnement VARCHAR(255);
--UPDATE Diagnostic set BuseFonctionnement = 'STANDARD' WHERE buseFonctionnementIsStandard
--UPDATE Diagnostic set BuseFonctionnement = 'A PASTILLE / CHAMBRE' WHERE buseFonctionnementIsPastilleChambre
--UPDATE Diagnostic set BuseFonctionnement = 'A INJECTION D''AIR LIBRE' WHERE buseFonctionnementIsInjectionAirLibre
--UPDATE Diagnostic set BuseFonctionnement = 'A INJECTION D''AIR FORCEE' WHERE buseFonctionnementIsInjectionAirForce
--ALTER TABLE [Diagnostic] DROP buseFonctionnementIsStandard;
--ALTER TABLE [Diagnostic] DROP buseFonctionnementIsPastilleChambre;
--ALTER TABLE [Diagnostic] DROP buseFonctionnementIsInjectionAirLibre;
--ALTER TABLE [Diagnostic] DROP buseFonctionnementIsInjectionAirForce;

-- Ajout des champs Categorie et Pulverisation sur les tables Pulve et Diagnostic
-- ALTER TABLE [pulverisateur] ADD categorie VARCHAR(255)
-- ALTER TABLE [pulverisateur] ADD pulverisation VARCHAR(255)
-- ALTER TABLE [diagnostic] ADD pulverisateurCategorie VARCHAR(255)
-- ALTER TABLE [diagnostic] ADD pulverisateurPulverisation VARCHAR(255)
-- UPDATE pulverisateur set categorie = 'Axial' WHERE categorieIsAxial
-- UPDATE pulverisateur set categorie = 'Rampe' WHERE categorieIsRampe
-- UPDATE pulverisateur set categorie = 'Jet Dirigé' WHERE categorieIsJetDirige
-- UPDATE pulverisateur set categorie = 'Canon' WHERE categorieIsCanon
-- UPDATE pulverisateur set categorie = 'Voute' WHERE categorieIsVoute
-- UPDATE pulverisateur set categorie = 'Face par face' WHERE categorieIsFaceParFace
-- UPDATE pulverisateur set pulverisation = 'Jet Porté' WHERE isJetPorte
-- UPDATE pulverisateur set pulverisation = 'Jet Projeté' WHERE isJetProjete
-- UPDATE pulverisateur set pulverisation = 'Pneumatique' WHERE isPneumatique
-- UPDATE Diagnostic set pulverisateurCategorie = 'Axial' WHERE pulverisateurCategorieIsAxial
-- UPDATE Diagnostic set pulverisateurCategorie = 'Rampe' WHERE pulverisateurCategorieIsRampe
-- UPDATE Diagnostic set pulverisateurCategorie = 'Jet Dirigé' WHERE pulverisateurCategorieIsJetDirige
-- UPDATE Diagnostic set pulverisateurCategorie = 'Canon' WHERE pulverisateurCategorieIsCanon
-- UPDATE Diagnostic set pulverisateurCategorie = 'Voute' WHERE pulverisateurCategorieIsVoute
-- UPDATE Diagnostic set pulverisateurCategorie = 'Face par face' WHERE pulverisateurCategorieIsFaceParFace
-- UPDATE Diagnostic set pulverisateurPulverisation = 'Jet Porté' WHERE pulverisateurIsJetPorte
-- UPDATE Diagnostic set pulverisateurPulverisation = 'Jet Projeté' WHERE pulverisateurIsJetProjete
-- UPDATE Diagnostic set pulverisateurPulverisation = 'Pneumatique' WHERE pulverisateurIsPneumatique

-- Suppression des anciens champs
-- ALTER TABLE [Pulverisateur] DROP CategorieIsAxial;
-- ALTER TABLE [Pulverisateur] DROP CategorieIsRampe;
-- ALTER TABLE [Pulverisateur] DROP CategorieIsJetDirige;
-- ALTER TABLE [Pulverisateur] DROP CategorieIsCanon;
-- ALTER TABLE [Pulverisateur] DROP CategorieIsVoute;
-- ALTER TABLE [Pulverisateur] DROP CategorieIsFaceParFace;

-- ALTER TABLE [Pulverisateur] DROP IsJetPorte;
-- ALTER TABLE [Pulverisateur] DROP IsJetProjete;
-- ALTER TABLE [Pulverisateur] DROP IsPneumatique;

-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsAxial;
-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsRampe;
-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsJetDirige;
-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsCanon;
-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsVoute;
-- ALTER TABLE [Diagnostic] DROP pulverisateurCategorieIsFaceParFace;

-- ALTER TABLE [Diagnostic] DROP pulverisateurIsJetPorte;
-- ALTER TABLE [Diagnostic] DROP pulverisateurIsJetProjete;
-- ALTER TABLE [Diagnostic] DROP pulverisateurIsPneumatique;

-- INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.3b",#12/21/2015#, "Version 20151223100000") 

-- CREATE TABLE IdentifiantPulverisateur (  id LONG PRIMARY KEY,  idStructure LONG,  numeroNational varchar(30) NOT NULL UNIQUE,  etat varchar(30) ,  dateUtilisation varchar(255) ,  libelle varchar(255) ,  dateModificationAgent varchar(255) ,  dateModificationCrodip varchar(255)) ;
-- ALTER TABLE FichevieBancMesure ADD FVFileName VARCHAR( 255 ) NULL DEFAULT NULL ;
-- ALTER TABLE FichevieManometreControle ADD FVFileName VARCHAR( 255 ) NULL DEFAULT NULL ;
-- ALTER TABLE FichevieManometreEtalon ADD FVFileName VARCHAR( 255 ) NULL DEFAULT NULL ;

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.4",#05/12/2016#, "Version 20160512120000") 

--Version 20160822170000 
--ALTER TABLE [Diagnostic] ADD CCFileName VARCHAR(255)
--ALTER TABLE [pulverisateur] ADD isAspirationExt YESNO
--ALTER TABLE [pulverisateur] ADD isDispoAntiRetour YESNO
--ALTER TABLE [pulverisateur] ADD isReglageAutoHauteur YESNO
--ALTER TABLE [pulverisateur] ADD isFiltrationAspiration YESNO
--ALTER TABLE [pulverisateur] ADD isFiltrationRefoulement YESNO
--ALTER TABLE [pulverisateur] ADD isFiltrationTroncons YESNO
--ALTER TABLE [pulverisateur] ADD isFiltrationBuses YESNO
--ALTER TABLE [pulverisateur] ADD isPulveAdditionnel YESNO
--ALTER TABLE [pulverisateur] ADD pulvePrincipalNumNat VARCHAR(50)
--UPDATE pulverisateur SET isPulveAdditionnel = 0 
--UPDATE pulverisateur SET pulvePrincipalNumNat = ''
--transmission des champs pulvé
--ALTER TABLE Diagnostic ADD pulverisateurCoupureAutoTroncons VARCHAR(10)
--ALTER TABLE Diagnostic ADD pulverisateurReglageAutoHauteur VARCHAR(10)
--UPDATE Diagnostic SET pulverisateurCoupureAutoTroncons = "NON"
--UPDATE Diagnostic SET pulverisateurReglageAutoHauteur= "NON"
--ALTER TABLE [pulverisateur] ADD isRincagecircuit YESNO
--UPDATE pulverisateur SET isRincagecircuit = 0 
--ALTER TABLE Diagnostic ADD pulverisateurRincagecircuit VARCHAR(10)
--UPDATE Diagnostic SET pulverisateurRincagecircuit = "NON"
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.5",#09/21/2016#, "Version 20160921150000") 
--ALTER TABLE Diagnostic ADD typeDiagnostic VARCHAR(20)
--ALTER TABLE Diagnostic ADD codeInsee VARCHAR(20)
--UPDATE Diagnostic SET typeDiagnostic = "pulverisateur"
--UPDATE Diagnostic SET typeDiagnostic = "equipement" where pulverisateurId in ( select id from pulverisateur where isPulveAdditionnel)
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.5.4.6",#12/06/2016#, "Version 20161216170000") 
--Version 2.5.6
--ALTER TABLE [pulverisateur] ADD isPompesDoseuses YESNO
--UPDATE pulverisateur SET isPompesDoseuses = 0 
--ALTER TABLE [pulverisateur] ADD nbPompesDoseuses LONG
--UPDATE pulverisateur SET nbPompesDoseuses = 0 
--UPDATE pulverisateur SET nbPompesDoseuses = 0 
--ALTER TABLE [diagnostic] ADD commentaire varchar(255)
--UPDATE Diagnostic SET commentaire = '' 
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6",#09/01/2018#, "Pompes Doseuses") 
--ALTER TABLE BancMesure ADD ModuleAcquisition VARCHAR(255)
--UPDATE BancMesure SET ModuleAcquisition = 'MD2' 
-- date au format MM/JJ/AAAA
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.1", #08/12/2019# , "Modules Acquisition") 

--ALTER TABLE Agent ADD SignatureElect BIT
--UPDATE Agent SET SignatureElect = False
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.2", #10/14/2019# , "Signature Electronique") 
--DELETE FROM VERSION WHERE VERSION_DATE>#01/01/2019#
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.1", #08/12/2019# , "Modules Acquisition") 
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.2", #10/14/2019# , "Signature Electronique") 

--ALTER TABLE DIAGNOSTIC ADD pulverisateurNumNational varchar(255)
--UPDATE DIAGNOSTIC, pulverisateur SET DIAGNOSTIC.pulverisateurNumNational = pulverisateur.numeroNational WHERE pulverisateur.id = diagnostic.pulverisateurid
--ALTER TABLE DIAGNOSTIC ADD pulverisateurNumchassis varchar(255)
--ALTER TABLE PULVERISATEUR ADD numchassis varchar(255)
--ALTER TABLE DIAGNOSTIC ADD origineDiag varchar(255)
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.3", #04/07/2020# , "NumChassis,diag.pulveNumnat") 

--ALTER TABLE DIAGNOSTIC ADD isSignRIAgent YESNO
--ALTER TABLE DIAGNOSTIC ADD isSignRIClient YESNO
--ALTER TABLE DIAGNOSTIC ADD isSignCCAgent YESNO
--ALTER TABLE DIAGNOSTIC ADD isSignCCClient YESNO

--ALTER TABLE DIAGNOSTIC ADD dateSignRIAgent DATE
--ALTER TABLE DIAGNOSTIC ADD dateSignRIClient DATE
--ALTER TABLE DIAGNOSTIC ADD dateSignCCAgent DATE
--ALTER TABLE DIAGNOSTIC ADD dateSignCCClient DATE

--ALTER TABLE DIAGNOSTIC ADD signRIAgent  LONGBINARY
--ALTER TABLE DIAGNOSTIC ADD signRIClient  LONGBINARY
--ALTER TABLE DIAGNOSTIC ADD signCCAgent  LONGBINARY
--ALTER TABLE DIAGNOSTIC ADD signCCClient  LONGBINARY

--UPDATE DIAGNOSTIC SET isSignRIAgent = False,isSignRIClient = False, isSignCCAgent = False,isSignCCClient = False
--UPDATE DIAGNOSTIC SET dateSignRIAgent = null,dateSignRIClient = null, dateSignCCAgent = null,dateSignCCClient = null
--UPDATE DIAGNOSTIC SET signRIAgent = null,signRIClient = null, signCCAgent = null, signCCClient = null

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.4", #05/25/2020# , "Signatureelec diag") 

--UPDATE PULVERISATEUR SET DATEPROCHAINCONTROLE = NULL where DATEPROCHAINCONTROLE = #01/01/2001# OR DATEPROCHAINCONTROLE = #00:00:00#

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.4", #09/04/2020# , "MAJ pulve") 

--ALTER TABLE DIAGNOSTIC ADD isSupprime YESNO
--ALTER TABLE DIAGNOSTIC ADD diagRemplacementId varchar(30)
--UPDATE DIAGNOSTIC SET isSupprime = False,diagRemplacementId = ''

--ALTER TABLE DIAGNOSTIC ADD signRIAgent  LONGBINARY
--UPDATE DIAGNOSTIC SET signRIAgent=NULL
--ALTER TABLE DIAGNOSTIC ADD signRIClient  LONGBINARY
--UPDATE DIAGNOSTIC SET signRIClient=NULL
--ALTER TABLE DIAGNOSTIC ADD signCCAgent  LONGBINARY
--UPDATE DIAGNOSTIC SET signCCAgent=NULL
--ALTER TABLE DIAGNOSTIC ADD signCCClient  LONGBINARY
--UPDATE DIAGNOSTIC SET signCCClient=NULL

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.7.0", #26/01/2021# , "RemplaceDiag") 

--ALTER TABLE DIAGNOSTIC ADD totalHT  DECIMAL(10,2)
--ALTER TABLE DIAGNOSTIC ADD totalTTC  DECIMAL(10,2)
--ALTER TABLE DIAGNOSTIC ADD dateRemplacement  DATETIME
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.7.01", #29/04/2021# , "Diag:TotalHT") 

--ALTER TABLE DIAGNOSTIC ADD isCVImmediate YESNO
--ALTER TABLE DIAGNOSTIC ADD isGratuit YESNO
--UPDATE DIAGNOSTIC SET isCVImmediate = False
--UPDATE DIAGNOSTIC SET isGratuit = False
--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.7.02", #10/05/2021# , "CVImmédiateGratuite") 

--ALTER TABLE ExploitationTOPulverisateur ADD isSupprimeCoProp YESNO 
--UPDATE ExploitationTOPulverisateur SET isSupprimeCoProp = False
--CREATE TABLE [facture] ([idfacture] TEXT(255)  NOT NULL,[idstructure] TEXT(50) ,[datefacture] DATETIME,[dateecheance] DATETIME,[commentaire] TEXT(255) ,[modereglement] TEXT(255) ,[isreglee] BIT NOT NULL,[refreglement] TEXT(255) ,[totalht] float,[txtva] float,[totalttc] float,[totaltva] float,[iddiag] TEXT(50) ,[idexploit] TEXT(50) ,[rsclient] TEXT(255) ,[nomclient] TEXT(255) ,[prenomclient] TEXT(255) ,[adresseclient] TEXT(255) ,[cpclient] TEXT(255) ,[communeclient] TEXT(255) ,[telfixeclient] TEXT(255) ,[telportclient] TEXT(255) ,[emailclient] TEXT(255), [dateModificationAgent]  dateTime, [dateModificationCRODIP]  dateTime ,CONSTRAINT [PK_facture] PRIMARY KEY ([idfacture]));
--CREATE TABLE [factureitem] ([idfacture] TEXT(255) , [nfactureitem] LONG NOT NULL,[categorie] TEXT(255) ,[prestation] TEXT(255) ,[quantite] float,[pu] float,[totalhtitem] float,[totaltvaitem] float,[totalttcitem] float,[txtvaitem] float, [dateModificationAgent]  dateTime, [dateModificationCRODIP]  dateTime ,CONSTRAINT [PK_factureitems] PRIMARY KEY ([idfacture],[nfactureitem]));

--ALTER TABLE [factureitem] ADD CONSTRAINT [facturefactureitem] FOREIGN KEY ([idfacture]) REFERENCES [facture] ([idfacture]);

--Alter Table Facture add column pathPDF Text(255);

--INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.8.00", #29/11/2021# , "CoProprietaire") 

--CREATE TABLE AgentPC (idCrodip TEXT PRIMARY KEY ,idStructure INTEGER  REFERENCES Structure (id) ON DELETE SET NULL,cleUtilisation TEXT,libelle                TEXT,etat                   BIT,numInterne             TEXT,AgentSuppression       TEXT,RaisonSuppression      TEXT,dateSuppression        DATETIME,isSupprime             BIT,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);


--CREATE TABLE POOL (idCrodip TEXT PRIMARY KEY,libelle TEXT, idCRODIPPC             TEXT           REFERENCES AgentPC (idCrodip) ON DELETE SET NULL, ,nbPastillesVertes INTEGER DEFAULT (0),dateModificationAgent  DATETIME,dateModificationCrodip DATETIME,idStructure INTEGER REFERENCES Structure (id),idBanc TEXT REFERENCES BancMesure (id) ON DELETE SET NULL);

--ALTER TABLE Agent ADD COLUMN idCRODIPPOOL TEXT REFERENCES POOL (idCRODIP) ON DELETE SET NULL;


--Alter Table DIAGNOSTIC Add COLUMN BLFileName  TEXT ;
--Alter Table DIAGNOSTIC Add COLUMN ESFileName  TEXT ;
--Alter Table DIAGNOSTIC Add COLUMN COPROFileName  TEXT ;
--Alter Table DIAGNOSTIC Add COLUMN FACTFileNames  TEXT ;

-- GESTION DES EQUIPEMENTS
--DROP TABLE IF EXISTS AgentPC;
--CREATE TABLE AgentPC (idCrodip TEXT PRIMARY KEY ,idStructure INTEGER  REFERENCES Structure (id) ON DELETE SET NULL,cleUtilisation TEXT,libelle                TEXT,etat                   BIT,numInterne             TEXT,AgentSuppression       TEXT,RaisonSuppression      TEXT,dateSuppression        DATETIME,isSupprime             BIT,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);

--DROP TABLE IF EXISTS POOL;
--CREATE TABLE POOL (idCrodip TEXT PRIMARY KEY,libelle TEXT, idCRODIPPC TEXT REFERENCES AgentPC (idCrodip) ON DELETE SET NULL, nbPastillesVertes INTEGER DEFAULT (0),dateModificationAgent  DATETIME,dateModificationCrodip DATETIME,idStructure INTEGER REFERENCES Structure (id) ON DELETE CASCADE, idBanc TEXT REFERENCES BancMesure (id) ON DELETE SET NULL);

-- A SUPPRIMER LORS DE LA MISE EN PROD (SUPPRESSION DE LA PREPROD 2206)
--CREATE TABLE Agent2 (Id                     INT            PRIMARY KEY,numeroNational         NVARCHAR (50)  UNIQUE,motdepasse             NVARCHAR (255),nom                    VARCHAR (256),prenom                 VARCHAR (256),idStructure            INT            REFERENCES Structure (id) ON DELETE CASCADE,telephoneportable      VARCHAR (256),email                  VARCHAR (256),dateCreation           DATETIME2,dateDerniereConnexion  DATETIME2,dateDerniereSynchro    DATETIME2,dateModificationAgent  DATETIME2,dateModificationCrodip DATETIME2,versionLogiciel        VARCHAR (256),commentaire            VARCHAR (256),cleActivation          VARCHAR (256),isActif                BIT            DEFAULT 0,droitsPulves           VARCHAR (2560),isGestionnaire         BIT            DEFAULT 0,signatureElect         BIT            DEFAULT 0,statut                 VARCHAR (50));
--INSERT INTO Agent2 (Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut) SELECT Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut from Agent
--ALTER TABLE Agent RENAME TO AGENT_ADEL;
--ALTER TABLE Agent2 RENAME TO AGENT;
--ALTER TABLE Agent ADD COLUMN idCRODIPPOOL TEXT REFERENCES POOL (idCRODIP) ON DELETE SET NULL;
--

--DROP TABLE IF EXISTS PoolManoC;
--CREATE TABLE PoolManoC (id INTEGER  PRIMARY KEY AUTOINCREMENT,idCRODIPPool           TEXT     REFERENCES POOL (idCRODIP) ON DELETE CASCADE,numeroNationalManoC    TEXT     REFERENCES AgentManoControle (numeroNational) ON DELETE CASCADE,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);
--DROP TABLE IF EXISTS PoolManoE;
--CREATE TABLE PoolManoE (id                     INTEGER  PRIMARY KEY AUTOINCREMENT,idCRODIPPool           TEXT     REFERENCES POOL (idCRODIP) ON DELETE CASCADE,numeroNationalManoE    TEXT     REFERENCES AgentManoEtalon (numeroNational) ON DELETE CASCADE,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);
--DROP TABLE IF EXISTS PoolBUSE;
--CREATE TABLE PoolBUSE (id                     INTEGER  PRIMARY KEY AUTOINCREMENT,idCRODIPPool           TEXT     REFERENCES POOL (idCRODIP) ON DELETE CASCADE, numeroNationalBUSE     TEXT     ,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);

--ALTER TABLE IdentifiantPulverisateur ADD COLUMN         idCRODIPPOOL           TEXT           REFERENCES POOL (idCRODIP) ON DELETE CASCADE;

-- Ajout des dépendances BANC-POOL
--CREATE TABLE PoolBanc (id                     INTEGER  PRIMARY KEY AUTOINCREMENT,idCRODIPPool           TEXT     REFERENCES POOL (idCrodip) ON DELETE NO ACTION,numeroNationalBanc     TEXT     REFERENCES BancMesure (id) ON DELETE CASCADE,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);

--Nettoyage de la base  (si upgrade)
--DROP TABLE IF EXISTS AGENT_ADEL;
--DELETE FROM POOLBanc;
--DELETE FROM POOLBUSE;
--DELETE FROM POOLManoE;
--DELETE FROM POOLManoC;
--DELETE FROM AgentPC;
--UPDATE IdentifiantPulverisateur SET idCRODIPPOOL = NULL;
--UPDATE Agent SET idCRODIPPOOL = NULL;
--DELETE FROM POOL;
--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V3.0.00','2022-09-27 12:00:00','Gestion des equipements');

-- EVOLUTION METROLOGIE
--ALTER TABLE AgentManocontrole ADD COLUMN bAjusteur BIT ;
--ALTER TABLE AgentManocontrole ADD COLUMN resolutionLecture Text ;
--Update AgentManocontrole SET bAJusteur = 0, resolutionLecture = resolution ;
--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V3.0.01','2023-03-01 12:00:00','Metrologie');

-- Tracabilité Mano
--ALTER TABLE AgentManocontrole ADD COLUMN typeTraca Text ;
--ALTER TABLE AgentManocontrole ADD COLUMN numTraca int ;
--ALTER TABLE AgentManocontrole ADD COLUMN typeRaccord text ;
--ALTER TABLE DiagnosticTroncons833 Add COLUMN manocId Text;
--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V3.1.00','2023-07-23 12:00:00','Tracabilité Mano');

--ALTER TABLE Pulverisateur Add COLUMN immatCertificat  Text;
--ALTER TABLE Pulverisateur Add COLUMN immatPlaque Text;
--ALTER TABLE Pulverisateur ADD COLUMN numerochassis Text;
--UPDATE Pulverisateur SET numerochassis = numchassis;
--ALTER TABLE Pulverisateur DROP COLUMN numchassis;
--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V3.1.01','2024-01-16 12:00:00','Immatriculation Pulve');

-- Suppression des Categorie vides
--DELETE FROM PrestationCategorie where libelle = ""
--DELETE from ExploitationToPulverisateur where idExploitation in (select id from exploitation where raisonsociale = '' and nomExploitant = '');
--DELETE from Exploitation where raisonsociale = '' and nomExploitant = '';
--DELETE from ExploitationToPulverisateur where idExploitation in (select id from exploitation where raisonsociale IS NULL and nomExploitant IS NULL);
--DELETE from Exploitation where raisonsociale IS NULL and nomExploitant IS NULL;

--DELETE from FicheVieBancMesure where caracteristiques = 'RECUP';
--DELETE from FicheVieManometreControle where caracteristiques = 'RECUP';
--DELETE from FicheVieManometreEtalon where caracteristiques = 'RECUP';

--ALTER TABLE Exploitation ADD COLUMN uid integer;
--ALTER TABLE Exploitation ADD COLUMN aid text;
--ALTER TABLE Exploitation ADD COLUMN uidstructure integer;
--update Exploitation set aid = id;
--update Exploitation set uidstructure = idstructure;
--ALTER TABLE pulverisateur ADD COLUMN uid integer;
--ALTER TABLE pulverisateur ADD COLUMN uidstructure integer;
--ALTER TABLE pulverisateur ADD COLUMN aid text;
--update Pulverisateur set aid = id;
--update Pulverisateur set uidStructure = idstructure;
--ALTER TABLE ExploitationToPulverisateur ADD COLUMN uid integer;
--ALTER TABLE ExploitationToPulverisateur ADD COLUMN uidexploitation integer;
--ALTER TABLE ExploitationToPulverisateur ADD COLUMN uidpulverisateur integer;
--ALTER TABLE ExploitationToPulverisateur ADD COLUMN aid text;
--update ExploitationToPulverisateur set aid = id;
--ALTER TABLE Agent ADD COLUMN uid integer;
--ALTER TABLE Agent ADD COLUMN aid text;
--ALTER TABLE Agent ADD COLUMN uidstructure integer;
--update Agent set aid = id;
--ALTER TABLE Diagnostic ADD COLUMN uid integer;
--ALTER TABLE Diagnostic ADD COLUMN aid text;
--ALTER TABLE Diagnostic ADD COLUMN uidstructure integer;
--ALTER TABLE Diagnostic ADD COLUMN uidexploitation integer;
--ALTER TABLE Diagnostic ADD COLUMN uidpulverisateur integer;
--ALTER TABLE Diagnostic ADD COLUMN uidagent integer;
--update Diagnostic set aid = id;
--ALTER TABLE DiagnosticItem ADD COLUMN uid integer;
--ALTER TABLE DiagnosticItem ADD COLUMN aid text;
--ALTER TABLE DiagnosticItem ADD COLUMN uiddiagnostic integer;
--ALTER TABLE DiagnosticItem ADD COLUMN aiddiagnostic integer;
--update DiagnosticItem set aid = id;
--update DiagnosticItem set aiddiagnostic = iddiagnostic;
--
--ALTER TABLE DiagnosticBuses ADD COLUMN uid integer;
--ALTER TABLE DiagnosticBuses ADD COLUMN aid text;
--ALTER TABLE Diagnosticbuses ADD COLUMN uiddiagnostic integer;
--ALTER TABLE Diagnosticbuses ADD COLUMN aiddiagnostic text;
--update DiagnosticBuses set aid = id;
--update DiagnosticBuses set aiddiagnostic = iddiagnostic;
--ALTER TABLE DiagnosticBusesDetail ADD COLUMN uid integer;
--ALTER TABLE DiagnosticBusesDetail ADD COLUMN aid text;
--ALTER TABLE DiagnosticbusesDetail ADD COLUMN uiddiagnostic integer;
--ALTER TABLE DiagnosticbusesDetail ADD COLUMN aiddiagnostic text;
--update DiagnosticBusesDetail set aid = id;
--update DiagnosticBusesDetail set aiddiagnostic = iddiagnostic;
--ALTER TABLE DiagnosticMano542 ADD COLUMN uid integer;
--ALTER TABLE DiagnosticMano542 ADD COLUMN aid text;
--ALTER TABLE DiagnosticMano542 ADD COLUMN uiddiagnostic integer;
--ALTER TABLE DiagnosticMano542 ADD COLUMN aiddiagnostic text;
--update DiagnosticMano542 set aid = id;
--update DiagnosticMano542 set aiddiagnostic = iddiagnostic;
--ALTER TABLE DiagnosticTroncons833 ADD COLUMN uid integer;
--ALTER TABLE DiagnosticTroncons833 ADD COLUMN aid text;
--ALTER TABLE DiagnosticTroncons833 ADD COLUMN uiddiagnostic integer;
--ALTER TABLE DiagnosticTroncons833 ADD COLUMN aiddiagnostic text;
--update DiagnosticTroncons833 set aid = id;
--update DiagnosticTroncons833 set aiddiagnostic = iddiagnostic;
--
--ALTER TABLE BancMesure ADD COLUMN uid integer;
--ALTER TABLE BancMesure ADD COLUMN aid text;
--ALTER TABLE BancMesure ADD COLUMN uidstructure integer;
--update BancMesure set aid = id;
--update BancMesure set uidstructure = idStructure;
--
--ALTER TABLE AgentManoControle ADD COLUMN uid integer;
--ALTER TABLE AgentManoControle ADD COLUMN aid text;
--ALTER TABLE AgentManoControle ADD COLUMN uidstructure integer;
--update AgentManoControle set aid = idcrodip;
--update AgentManoControle set uidStructure = idstructure;
--
--ALTER TABLE AgentManoEtalon ADD COLUMN uid integer;
--ALTER TABLE AgentManoEtalon ADD COLUMN aid text;
--ALTER TABLE AgentManoEtalon ADD COLUMN uidstructure integer;
--update AgentManoEtalon set aid = idcrodip;
--update AgentManoEtalon set uidStructure = idstructure;
--
--ALTER TABLE FicheVieBancMesure ADD COLUMN uid integer;
--ALTER TABLE FicheVieBancMesure ADD COLUMN aid text;
--ALTER TABLE FicheVieBancMesure ADD COLUMN uidstructure integer;
--ALTER TABLE FicheVieBancMesure ADD COLUMN uidbancmesure integer;
--ALTER TABLE FicheVieBancMesure ADD COLUMN uidagentcontroleur integer;
--update FicheVieBancMesure set aid = id;
--
--ALTER TABLE FicheVieManometreControle ADD COLUMN uid integer;
--ALTER TABLE FicheVieManometreControle ADD COLUMN aid text;
--ALTER TABLE FicheVieManometreControle ADD COLUMN uidstructure integer;
--ALTER TABLE FicheVieManometreControle ADD COLUMN uidManometre integer;
--ALTER TABLE FicheVieManometreControle ADD COLUMN uidagentcontroleur integer;
--update FicheVieManometreControle set aid = id;
--
--ALTER TABLE FicheVieManometreetalon ADD COLUMN uid integer;
--ALTER TABLE FicheVieManometreetalon ADD COLUMN aid text;
--ALTER TABLE FicheVieManometreetalon ADD COLUMN uidstructure integer;
--ALTER TABLE FicheVieManometreetalon ADD COLUMN uidManometre integer;
--ALTER TABLE FicheVieManometreetalon ADD COLUMN uidagentcontroleur integer;
--update FicheVieManometreetalon set aid = id;
--
--ALTER TABLE AgentBuseetalon ADD COLUMN uid integer;
--ALTER TABLE AgentBuseetalon ADD COLUMN aid text;
--ALTER TABLE AgentBuseetalon ADD COLUMN uidstructure integer;
--update AgentBuseetalon set aid = idcrodip;
--
--ALTER TABLE IdentifiantPulverisateur ADD COLUMN uid integer;
--ALTER TABLE IdentifiantPulverisateur ADD COLUMN aid text;
--ALTER TABLE IdentifiantPulverisateur ADD COLUMN uidstructure integer;
--update IdentifiantPulverisateur set aid = id;
--update IdentifiantPulverisateur set uidstructure = idStructure;
--
--ALTER TABLE Controle_Regulier ADD COLUMN uid integer;
--ALTER TABLE Controle_Regulier ADD COLUMN aid text;
--ALTER TABLE Controle_Regulier ADD COLUMN uidstructure integer;
--ALTER TABLE Controle_Regulier ADD COLUMN aidagent integer;
--ALTER TABLE Controle_Regulier ADD COLUMN uidagent integer;
--ALTER TABLE Controle_Regulier ADD COLUMN uidmateriel integer;
--update Controle_Regulier set aid = ctrg_id;
--update Controle_Regulier set uidstructure = ctrg_StructureId;
--
--ALTER TABLE prestationcategorie ADD COLUMN uid integer;
--ALTER TABLE prestationcategorie ADD COLUMN aid text;
--ALTER TABLE prestationcategorie ADD COLUMN uidstructure integer;
--update prestationcategorie set aid = id;
--update prestationcategorie set uidstructure = idStructure;
--
--ALTER TABLE prestationTarif ADD COLUMN uid integer;
--ALTER TABLE prestationTarif ADD COLUMN aid text;
--ALTER TABLE prestationTarif ADD COLUMN uidstructure integer;
--ALTER TABLE prestationTarif ADD COLUMN uidcategorie integer;
--update prestationTarif set aid = id;
--update prestationTarif set uidstructure = idStructure;
--
----Suppression de la contrainte pool sur Agent
--CREATE TABLE AGENT2 (    Id                     INT            PRIMARY KEY,numeroNational         NVARCHAR (50)  UNIQUE,    motdepasse             NVARCHAR (255),    nom                    VARCHAR (256),    prenom                 VARCHAR (256),    idStructure            INT            REFERENCES Structure (id) ON DELETE CASCADE,    telephoneportable      VARCHAR (256),    email                  VARCHAR (256),    dateCreation           DATETIME2,    dateDerniereConnexion  DATETIME2,    dateDerniereSynchro    DATETIME2,    dateModificationAgent  DATETIME2,    dateModificationCrodip DATETIME2,    versionLogiciel        VARCHAR (256),    commentaire            VARCHAR (256),    cleActivation          VARCHAR (256),    isActif                BIT            DEFAULT 0,    droitsPulves           VARCHAR (2560),    isGestionnaire         BIT            DEFAULT 0,    signatureElect         BIT            DEFAULT 0,    statut                 VARCHAR (50),    idCRODIPPOOL           TEXT,    uid                    INTEGER,    aid                    TEXT,    uidstructure           INTEGER);
--INSERT INTO Agent2 (Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut,idCRODIPPOOL,uid,aid,uidstructure) SELECT Id,numeroNational,motdepasse,nom,prenom,idStructure,telephoneportable,email,dateCreation,dateDerniereConnexion,dateDerniereSynchro,dateModificationAgent,dateModificationCrodip,versionLogiciel,commentaire,cleActivation,isActif,droitsPulves,isGestionnaire,signatureElect,statut,idCRODIPPOOL,uid,aid,uidstructure FROM Agent;
--ALTER TABLE Agent RENAME TO Agent1;
--ALTER TABLE Agent2 RENAME TO Agent;
--
---- Suppression de la contrainte unique sur id
--CREATE TABLE PrestationCategorie2 (id                     INT (1, 1)     NOT NULL,idStructure            INT            ,libelle                NVARCHAR (255),dateModificationAgent  DATETIME2 (0),dateModificationCrodip DATETIME2 (0),uid                    INTEGER,aid                    TEXT,uidstructure           INTEGER);
--insert into PrestationCategorie2 (id,idStructure,libelle,dateModificationAgent,dateModificationCrodip,uid,aid,uidstructure) SELECT id,idStructure,libelle,dateModificationAgent,dateModificationCrodip,uid,aid,uidstructure FROM PrestationCategorie;
--ALTER TABLE PrestationCategorie RENAME TO PrestationCategorie1;
--ALTER TABLE PrestationCategorie2 RENAME TO PrestationCategorie;
--
---- Suppression de la contrainte unique sur l'id et la existence de la categorie
--CREATE TABLE PrestationTarif2 (id INT (1, 1)     NOT NULL,idCategorie            INT,idStructure            INT            REFERENCES Structure (id) ON DELETE CASCADE,description            NVARCHAR (255),tarifHT                FLOAT,tarifTTC               FLOAT,tva                    FLOAT,dateModificationAgent  DATETIME2 (0),dateModificationCrodip DATETIME2 (0),uid                    INTEGER,aid                    TEXT,uidstructure           INTEGER,uidcategorie           INTEGER);
--insert into PrestationTarif2 (id,idCategorie,idStructure,description,tarifHT,tarifTTC,tva,dateModificationAgent,dateModificationCrodip ,uid,aid,uidstructure,uidcategorie) Select id,idCategorie,idStructure,description,tarifHT,tarifTTC,tva,dateModificationAgent,dateModificationCrodip ,uid,aid,uidstructure,uidcategorie from Prestationtarif;
--ALTER TABLE PrestationTarif RENAME TO PrestationTarif1;
--ALTER TABLE PrestationTarif2 RENAME TO PrestationTarif;
--
--
---- Suppression de la contrainte unique sur l'id 
--CREATE TABLE CONTROLE_REGULIER2 (CTRG_ID                INTEGER,CTRG_DATE              DATE,CTRG_STRUCTUREID       INTEGER,CTRG_TYPE              VARCHAR (256),CTRG_MATID             VARCHAR (256),CTRG_NUMAGENT          VARCHAR (256),dateModificationAgent  DATETIME,dateModificationCrodip DATETIME,CTRG_ETAT              VARCHAR (256),uid                    INTEGER,aid                    TEXT,uidstructure           INTEGER,aidagent               INTEGER,uidagent               INTEGER,uidmateriel            INTEGER);
--insert into CONTROLE_REGULIER2 (CTRG_ID,CTRG_DATE,CTRG_STRUCTUREID,CTRG_TYPE,CTRG_MATID,CTRG_NUMAGENT,dateModificationAgent,dateModificationCrodip,CTRG_ETAT,uid,aid,uidstructure,aidagent,uidagent,uidmateriel) SELECT CTRG_ID,CTRG_DATE,CTRG_STRUCTUREID,CTRG_TYPE,CTRG_MATID,CTRG_NUMAGENT,dateModificationAgent,dateModificationCrodip,CTRG_ETAT,uid,aid,uidstructure,aidagent,uidagent,uidmateriel from CONTROLE_REGULIER;
--ALTER TABLE CONTROLE_REGULIER RENAME TO CONTROLE_REGULIER1;
--ALTER TABLE CONTROLE_REGULIER2 RENAME TO CONTROLE_REGULIER;
--
--ExploitationToPulverisateur
--ALTER TABLE ExploitationToPulverisateur ADD COLUMN uidstructure integer;
--UPDATE ExploitationToPulverisateur SET uidstructure = (select uidstructure from exploitation where exploitation.id = ExploitationTOPulverisateur.idExploitation);

-- Suppression de la contrainte unique sur le numéro national sur agentManocontrole 
--CREATE TABLE AgentManoControle2 ( numeroNational Text,idCrodip text ,marque text ,classe text ,type text ,fondEchelle text ,etat BIT,idStructure INT,isSynchro BIT,dateDernierControle datetime ,dateModificationAgent datetime ,dateModificationCrodip datetime ,isUtilise BIT,isSupprime BIT,nbControles INT,nbControlesTotal INT,resolution text ,agentSuppression text ,raisonSuppression text ,dateSuppression datetime ,jamaisServi BIT,dateActivation datetime ,bAjusteur BIT,resolutionLecture TEXT,typeTraca TEXT,numTraca INT,typeRaccord TEXT,uid INTEGER,aid TEXT,uidstructure INTEGER);
--insert into AgentManoControle2 (numeroNational,idCrodip,marque,classe,type,fondEchelle,etat,idStructure,isSynchro,dateDernierControle,dateModificationAgent,dateModificationCrodip,isUtilise,isSupprime,nbControles,nbControlesTotal,resolution,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,bAjusteur,resolutionLecture,typeTraca,numTraca,typeRaccord,uid,aid,uidstructure) SELECT numeroNational,idCrodip,marque,classe,type,fondEchelle,etat,idStructure,isSynchro,dateDernierControle,dateModificationAgent,dateModificationCrodip,isUtilise,isSupprime,nbControles,nbControlesTotal,resolution,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,bAjusteur,resolutionLecture,typeTraca,numTraca,typeRaccord,uid,aid,uidstructure from AgentManoControle;
--ALTER TABLE AgentManoControle RENAME TO AgentManoControle2201;
--ALTER TABLE AgentManoControle2 RENAME TO AgentManoControle;

-- Suppression de la contrainte unique sur le numéro national sur agentManoEtalon 
--CREATE TABLE AgentManoEtalon2 (numeroNational text, idCrodip text,marque text ,classe text ,type text ,fondEchelle text ,idStructure INT ,isSynchro BIT,dateDernierControle datetime ,dateModificationAgent datetime ,dateModificationCrodip datetime ,etat BIT,isUtilise BIT ,isSupprime BIT ,nbControles INT ,nbControlesTotal INT ,incertitudeEtalon text ,agentSuppression text ,raisonSuppression text ,dateSuppression datetime ,jamaisServi BIT,dateActivation datetime ,uid INTEGER,aid TEXT,uidstructure INTEGER);
--insert into AgentManoEtalon2 (numeroNational,idCrodip,marque,classe,type,fondEchelle,idStructure,isSynchro,dateDernierControle,dateModificationAgent,dateModificationCrodip,etat,isUtilise,isSupprime,nbControles,nbControlesTotal,incertitudeEtalon,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,uid,aid,uidstructure)	SELECT numeroNational,idCrodip,marque,classe,type,fondEchelle,idStructure,isSynchro,dateDernierControle,dateModificationAgent,dateModificationCrodip,etat,isUtilise,isSupprime,nbControles,nbControlesTotal,incertitudeEtalon,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,uid,aid,uidstructure from AgentManoEtalon;
--ALTER TABLE AgentManoEtalon RENAME TO AgentManoEtalon2201;
--ALTER TABLE AgentManoEtalon2 RENAME TO AgentManoEtalon;

-- Suppression de la contrainte unique sur le numéro national sur AgentbuseEtalon 
--CREATE TABLE AgentbuseEtalon2 (	numeroNational text,idCrodip text ,couleur text ,pressionEtalonnage FLOAT,debitEtalonnage FLOAT,idStructure INT,isSynchro BIT,dateAchat datetime,dateModificationAgent datetime,dateModificationCrodip datetime,etat BIT,isSupprime BIT,isUtilise BIT,agentSuppression text ,raisonSuppression text ,dateSuppression datetime,jamaisServi BIT,dateActivation datetime,uid INTEGER,aid TEXT,uidstructure INTEGER);
--insert into AgentbuseEtalon2 (numeroNational,idCrodip,couleur,pressionEtalonnage,debitEtalonnage,idStructure,isSynchro,dateAchat,dateModificationAgent,dateModificationCrodip,etat,isSupprime,isUtilise,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,uid,aid,uidstructure) SELECT  numeroNational,idCrodip,couleur,pressionEtalonnage,debitEtalonnage,idStructure,isSynchro,dateAchat,dateModificationAgent,dateModificationCrodip,etat,isSupprime,isUtilise,agentSuppression,raisonSuppression,dateSuppression,jamaisServi,dateActivation,uid,aid,uidstructure from AgentbuseEtalon;
--ALTER TABLE AgentbuseEtalon RENAME TO AgentbuseEtalon2201;
--ALTER TABLE AgentbuseEtalon2 RENAME TO AgentbuseEtalon;

--Inversion du Numero national et idCrodip dans les bases Mano et buses
--Update AgentManoControle SET numeroNational = idCrodip, idCrodip = numeroNational;
--Update AgentManoEtalon SET numeroNational = idCrodip, idCrodip = numeroNational;
--Update AgentbuseEtalon SET numeroNational = idCrodip, idCrodip = numeroNational;

--Update AgentManoControle SET aid = idCrodip;
--Update AgentManoEtalon SET aid = idCrodip;
--Update AgentbuseEtalon SET aid = idCrodip;

--ALTER TABLE FichevieManometreControle ADD COLUMN numnatMano text;
--ALTER TABLE FichevieManometreControle ADD COLUMN IdCrodipMano text;
--Update FichevieManometreControle set IdCrodipMano = idManometre where AUTEUR = 'CRODIP' ;
--Update FichevieManometreControle set IdCrodipMano = (SELECT idCrodip from AgentManoControle where numeroNational = idManometre and isSupprime=0) where AUTEUR = 'AGENT' ;

--Update FichevieManometreControle set numnatMano = (SELECT numeroNational from AgentManoControle where idCrodip = idManometre) WHERE AUTEUR = 'CRODIP' ;
--Update FichevieManometreControle set numnatMano = idManometre WHERE AUTEUR = 'AGENT' ;

--ALTER TABLE FichevieManometreControle RENAME Column idManometre to idManometreOLD;
--ALTER TABLE FichevieManometreControle RENAME COLUMN idCrodipMano to idManometre;

--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.1.01','2024-11-01 12:00:00','uid');
--CREATE TABLE IdentifiantPulverisateur2 (id INT,idStructure INT ,numeroNational text  ,etat text, dateUtilisation  Text, libelle TEXT, dateModificationAgent  NVARCHAR (255),dateModificationCrodip NVARCHAR (255),uid  INTEGER,aid  TEXT,uidstructure  INTEGER);
--insert into IdentifiantPulverisateur2 (id ,idStructure ,numeroNational ,etat , dateUtilisation  , libelle , dateModificationAgent  ,dateModificationCrodip ,uid,aid  ,uidstructure  ) SELECT  id ,idStructure ,numeroNational ,etat , dateUtilisation  , libelle , dateModificationAgent  ,dateModificationCrodip ,uid,aid  ,uidstructure from IdentifiantPulverisateur;
--ALTER TABLE IdentifiantPulverisateur RENAME TO IdentifiantPulverisateur0702;
--ALTER TABLE IdentifiantPulverisateur2 RENAME TO IdentifiantPulverisateur;
--INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.1.02','2025-02-07 12:00:00','IdentPulve');

DROP TABLE IF EXISTS POOL;
DROP TABLE IF EXISTS POOLBanc;
DROP TABLE IF EXISTS POOLBUSE;
DROP TABLE IF EXISTS POOLMAnoc;
DROP TABLE IF EXISTS POOLMAnoE;
DROP TABLE IF EXISTS POOLMAnoEtalon;
DROP TABLE IF EXISTS POOLAgent;

DROP TABLE IF EXISTS Agent1;
DROP TABLE IF EXISTS AgentbuseEtalon2201;
DROP TABLE IF EXISTS AgentManoControle2201;
DROP TABLE IF EXISTS AgentManoEtalon2201;
DROP TABLE IF EXISTS CONTROLE_REGULIER1;
DROP TABLE IF EXISTS CONTROLE_REGULIER0702;
DROP TABLE IF EXISTS CONTROLE_REGULIER2;
DROP TABLE IF EXISTS PrestationCategorie1;
DROP TABLE IF EXISTS PrestationTarif1;
DROP TABLE IF EXISTS IdentifiantPulverisateur0702;

DROP TABLE IF EXISTS POOL;
Create Table Pool (uid integer PRIMARY KEY, idPool text, uidstructure integer, uidbanc integer, aidbanc text, libelle text, etat bit, agentSuppression text, raisonSuppression text, dateSuppression datetime, isSupprime bit, dateModificationAgent datetime, dateModificationCrodip dateTime, dateActivation datetime, nbPastillesVertes integer);

INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-01 12:00:00','pool2');

DROP TABLE IF EXISTS POOLAgent;
CREATE TABLE PoolAgent (uid BIGINT(20) NOT NULL,aid text  ,uidpool BIGINT(20) default 0,namepool text  DEFAULT '',uidagent BIGINT(20) default 0,aidagent text  DEFAULT '',uidstructure BIGINT(20) DEFAULT '0',dateAssociation dateTime NOT NULL DEFAULT CURRENT_TIMESTAMP,dateModificationAgent datemime NULL DEFAULT NULL,dateModificationCrodip datetime NULL DEFAULT NULL) ;

INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 12:00:00','poolAgent');

DROP TABLE IF EXISTS POOLPc;
CREATE TABLE PoolPc (uid BIGINT(20) NOT NULL,aid text  DEFAULT  '',uidpool BIGINT(20) DEFAULT 0,namepool text  DEFAULT '',uidpc BIGINT(20) DEFAULT 0,idPc text  DEFAULT '',uidstructure BIGINT(20) DEFAULT '0',dateAssociation datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,dateModificationAgent datetime NULL DEFAULT NULL,dateModificationCrodip datetime NULL DEFAULT NULL)  ;

INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 14:00:00','poolPc');

DROP TABLE IF EXISTS POOLBuse;
CREATE TABLE PoolBuse (uid bigint(20) NOT NULL,aid Text  DEFAULT '',uidpool bigint(20) ,namepool Text  DEFAULT '',uidbuse bigint(20),idBuse Text  DEFAULT '',uidstructure bigint(20) DEFAULT '0',dateAssociation datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,dateModificationAgent datetime NULL DEFAULT NULL,dateModificationCrodip datetime NULL DEFAULT NULL);
INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 15:00:00','poolBuse');

DROP TABLE IF EXISTS POOLManoControle;
CREATE TABLE PoolManoControle (uid bigint(20) NOT NULL,aid Text  DEFAULT '',uidpool bigint(20) Default 0,namepool Text  DEFAULT '',uidmanoc bigint(20) Default 0,idManometre text  DEFAULT '',uidstructure bigint(20) DEFAULT 0,dateAssociation datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,dateModificationAgent datetime NULL DEFAULT NULL,dateModificationCrodip datetime NULL DEFAULT NULL);
INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 15:10:00','poolManoControle');

DROP TABLE IF EXISTS POOLManoEtalon;
CREATE TABLE PoolManoEtalon (uid bigint(20) NOT NULL,aid Text  DEFAULT '',uidpool bigint(20) Default 0,namepool Text  DEFAULT '',uidmanoe bigint(20) Default 0,idManometre text  DEFAULT '',uidstructure bigint(20) DEFAULT 0,dateAssociation datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,dateModificationAgent datetime NULL DEFAULT NULL,dateModificationCrodip datetime NULL DEFAULT NULL);
INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 15:20:00','poolManoEtalon');

DROP TABLE IF EXISTS AgentPC2;
CREATE TABLE AgentPC2 (idCrodip TEXT,idStructure INTEGER,cleUtilisation TEXT,libelle TEXT,etat BIT,numInterne TEXT,AgentSuppression TEXT,RaisonSuppression TEXT,dateSuppression DATETIME,isSupprime BIT,dateModificationAgent  DATETIME,dateModificationCrodip DATETIME);
insert into AgentPC2 (idCrodip ,idStructure ,cleUtilisation ,libelle ,etat ,numInterne ,AgentSuppression ,RaisonSuppression ,dateSuppression ,isSupprime ,dateModificationAgent  ,dateModificationCrodip ) SELECT idCrodip ,idStructure ,cleUtilisation ,libelle ,etat ,numInterne ,AgentSuppression ,RaisonSuppression ,dateSuppression ,isSupprime ,dateModificationAgent  ,dateModificationCrodip  from AgentPC

Drop Table AgentPC;
ALTER TABLE AgentPC2 RENAME TO AgentPc;

Alter Table AgentPC Add Column uid Bigint(20) Default 0;
Alter Table AgentPC Add Column idPC text Default '';
Alter Table AgentPC Add Column uidstructure Bigint(20) Default 0;
Alter Table AgentPC add Column idRegistre Text Default '';
Alter Table AgentPC add Column marque Text Default '';
Alter Table AgentPC add Column modele Text Default '';
Alter Table AgentPC add Column systeme Text Default '';
Alter Table AgentPC add Column memoire Text Default '';
Alter Table AgentPC add Column disque Text Default '';
Alter Table AgentPC add Column memo Text Default '';
Alter Table AgentPC add Column owc_etat Text Default '';
Alter Table AgentPC add Column owc_folder Text Default '';
Alter Table AgentPC add Column owc_commun Text Default '';
Alter Table AgentPC add Column owc_parametres Text Default '';
Alter Table AgentPC add Column owc_organismes Text Default '';
Alter Table AgentPC add Column owc_user Text Default '';
Alter Table AgentPC add Column owc_password Text Default '';
Alter Table AgentPC add Column owc_version Text Default '';
Alter Table AgentPC add Column isSecours Text Default '';
Alter Table AgentPC add Column SignatureElect Text Default '0';
Alter Table AgentPC add Column isSignElecActive Text Default '0';
Alter Table AgentPC add Column modeSignature Text Default '';
Alter Table AgentPC add Column versionLogiciel Text Default '';
Alter Table AgentPC add Column isReinitialisationMode BIT NOT NULL DEFAULT '0';
Alter Table AgentPC add Column isMasterMode BIT NOT NULL DEFAULT '1';
Alter Table AgentPC add Column isDownloadMetrologieMode BIT NOT NULL DEFAULT '0';
Alter Table AgentPC add Column isDownloadTarificationMode BIT NOT NULL DEFAULT '0';
Alter Table AgentPC add Column isDownloadPulveExploitationMode BIT NOT NULL DEFAULT '0';
Alter Table AgentPC add Column isDownloadIdentifiantPulveMode BIT NOT NULL DEFAULT '0';
Update AgentPC set idPC = idCRODIP, uidStructure = idStructure, idRegistre = numinterne;
Alter Table AgentPC drop Column idCrodip;
Alter Table AgentPC drop Column idStructure;
Alter Table AgentPC drop Column numInterne;

Alter Table Agent add Column uidpool Bigint(20) DEFAULT 0;
Alter Table Agent drop Column idCRODIPPOOL ;

INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 16:10:00','AgentPC');

Alter Table PoolManoEtalon Add Column isSupprime Bit default 0;
Alter Table PoolManoControle Add Column isSupprime Bit default 0;
Alter Table PoolBuse Add Column isSupprime Bit default 0;
Alter Table PoolAgent Add Column isSupprime Bit default 0;
Alter Table PoolPc Add Column isSupprime Bit default 0;
Alter Table Pool Add Column aid Text default '';
INSERT INTO VERSION (VERSION_NUM,VERSION_DATE,VERSION_COMM) VALUES ('V4.2','2025-03-25 16:10:00','Pool');
