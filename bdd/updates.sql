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
DELETE FROM VERSION WHERE VERSION_DATE>#01/01/2019#
INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.1", #08/12/2019# , "Modules Acquisition") 
INSERT INTO VERSION (VERSION_NUM, VERSION_DATE, VERSION_COMM) VALUES ("V2.6.2", #10/14/2019# , "Signature Electronique") 

