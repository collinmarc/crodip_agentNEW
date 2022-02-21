--
-- Fichier généré par SQLiteStudio v3.2.1 sur ven. févr. 18 15:34:39 2022
--
-- Encodage texte utilisé : System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table : Agent
DROP TABLE IF EXISTS Agent;

CREATE TABLE Agent (
    Id                     INT            PRIMARY KEY,
    numeroNational         NVARCHAR (50)  UNIQUE,
    motdepasse             NVARCHAR (255),
    nom                    VARCHAR (256),
    prenom                 VARCHAR (256),
    idStructure            INT            REFERENCES Structure (id),
    telephoneportable      VARCHAR (256),
    email                  VARCHAR (256),
    dateCreation           DATETIME2,
    dateDerniereConnexion  DATETIME2,
    dateDerniereSynchro    DATETIME2,
    dateModificationAgent  DATETIME2,
    dateModificationCrodip DATETIME2,
    versionLogiciel        VARCHAR (256),
    commentaire            VARCHAR (256),
    cleActivation          VARCHAR (256),
    isActif                BIT            DEFAULT 0,
    droitsPulves           VARCHAR (2560),
    isGestionnaire         BIT            DEFAULT 0,
    signatureElect         BIT            DEFAULT 0,
    statut                 VARCHAR (50) 
);


-- Table : AgentBuseEtalon
DROP TABLE IF EXISTS AgentBuseEtalon;

CREATE TABLE AgentBuseEtalon (
    numeroNational         NVARCHAR (255) NOT NULL,
    idCrodip               NVARCHAR (255) UNIQUE,
    couleur                NVARCHAR (255),
    pressionEtalonnage     FLOAT,
    debitEtalonnage        FLOAT,
    idStructure            INT            REFERENCES Structure (id),
    isSynchro              BIT,
    dateAchat              DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    etat                   BIT,
    isSupprime             BIT,
    isUtilise              BIT,
    agentSuppression       NVARCHAR (255),
    raisonSuppression      NVARCHAR (255),
    dateSuppression        DATETIME2 (0),
    jamaisServi            BIT,
    dateActivation         DATETIME2 (0) 
);


-- Table : AgentManoControle
DROP TABLE IF EXISTS AgentManoControle;

CREATE TABLE AgentManoControle (
    numeroNational         NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idCrodip               NVARCHAR (255),
    marque                 NVARCHAR (255),
    classe                 NVARCHAR (255),
    type                   NVARCHAR (255),
    fondEchelle            NVARCHAR (255),
    etat                   BIT,
    idStructure            INT            REFERENCES Structure (id),
    isSynchro              BIT,
    dateDernierControle    DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    isUtilise              BIT,
    isSupprime             BIT,
    nbControles            INT,
    nbControlesTotal       INT,
    resolution             NVARCHAR (255),
    agentSuppression       NVARCHAR (255),
    raisonSuppression      NVARCHAR (255),
    dateSuppression        DATETIME2 (0),
    jamaisServi            BIT,
    dateActivation         DATETIME2 (0) 
);


-- Table : AgentManoEtalon
DROP TABLE IF EXISTS AgentManoEtalon;

CREATE TABLE AgentManoEtalon (
    numeroNational         NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idCrodip               NVARCHAR (255) UNIQUE,
    marque                 NVARCHAR (255),
    classe                 NVARCHAR (255),
    type                   NVARCHAR (255),
    fondEchelle            NVARCHAR (255),
    idStructure            INT            REFERENCES Structure (id),
    isSynchro              BIT            DEFAULT (0),
    dateDernierControle    DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    etat                   BIT,
    isUtilise              BIT            DEFAULT (0),
    isSupprime             BIT            DEFAULT (0),
    nbControles            INT            DEFAULT (0),
    nbControlesTotal       INT,
    incertitudeEtalon      NVARCHAR (255),
    agentSuppression       NVARCHAR (255),
    raisonSuppression      NVARCHAR (255),
    dateSuppression        DATETIME2 (0),
    jamaisServi            BIT,
    dateActivation         DATETIME2 (0) 
);


-- Table : BancMesure
DROP TABLE IF EXISTS BancMesure;

CREATE TABLE BancMesure (
    id                     NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    marque                 NVARCHAR (255),
    modele                 NVARCHAR (255),
    dateAchat              DATETIME2 (0),
    idStructure            INT            REFERENCES Structure (id),
    dateDernierControle    DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    etat                   BIT,
    isUtilise              BIT            DEFAULT (0),
    isSupprime             BIT            DEFAULT (0),
    nbControles            INT            DEFAULT (0),
    nbControlesTotal       INT            DEFAULT (0),
    agentSuppression       NVARCHAR (255),
    raisonSuppression      NVARCHAR (255),
    dateSuppression        DATETIME2 (0),
    jamaisServi            BIT            DEFAULT (1),
    dateActivation         DATETIME2 (0),
    ModuleAcquisition      NVARCHAR (255) DEFAULT ""
);


-- Table : CONTROLE_REGULIER
DROP TABLE IF EXISTS CONTROLE_REGULIER;

CREATE TABLE CONTROLE_REGULIER (
    CTRG_ID                INTEGER       PRIMARY KEY AUTOINCREMENT
                                         UNIQUE,
    CTRG_DATE              DATE,
    CTRG_STRUCTUREID       INTEGER,
    CTRG_TYPE              VARCHAR (256),
    CTRG_MATID             VARCHAR (256),
    CTRG_NUMAGENT          VARCHAR (256),
    dateModificationAgent  DATETIME,
    dateModificationCrodip DATETIME,
    CTRG_ETAT              VARCHAR (256) 
);


-- Table : ControleAgentBanc
DROP TABLE IF EXISTS ControleAgentBanc;

CREATE TABLE ControleAgentBanc (
    id                    NVARCHAR (50)  NOT NULL
                                         PRIMARY KEY,
    date                  DATETIME2 (0),
    marqueDebitmetre      NVARCHAR (255),
    modeleDebitmetre      NVARCHAR (255),
    typeDebitmetre        NVARCHAR (255),
    idManometreEtalon     NVARCHAR (50),
    intervalleLectures    INT,
    temperatureExterieure INT,
    temperatureEau        INT,
    pressionManometre     INT,
    debitLue              INT,
    resultat              NVARCHAR (255),
    etat                  BIT,
    isSynchro             BIT
);


-- Table : ControleAgentMano
DROP TABLE IF EXISTS ControleAgentMano;

CREATE TABLE ControleAgentMano (
    id                  NVARCHAR (50)  NOT NULL
                                       PRIMARY KEY,
    date                DATETIME2 (0),
    idManoEtalon        NVARCHAR (50),
    idManoControle      NVARCHAR (50),
    temperature         INT,
    pressionAppliquee   INT,
    pressionMontante    INT,
    pressionDescendante INT,
    erreurAbsolue       INT,
    erreurFondEchelle   INT,
    erreurMoyenne       INT,
    resultat            NVARCHAR (255),
    etat                BIT
);


-- Table : ControleBancMesure
DROP TABLE IF EXISTS ControleBancMesure;

CREATE TABLE ControleBancMesure (
    id                     NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idStructure            NVARCHAR (255) REFERENCES Structure (id),
    idBanc                 NVARCHAR (255),
    buse1                  NVARCHAR (255),
    buse2                  NVARCHAR (255),
    buse3                  NVARCHAR (255),
    buse4                  NVARCHAR (255),
    buse5                  NVARCHAR (255),
    buse6                  NVARCHAR (255),
    tempExt                NVARCHAR (255),
    tempEau                NVARCHAR (255),
    resultat               NVARCHAR (255),
    b1_pressionEtal        NVARCHAR (255),
    b1_debitEtal           NVARCHAR (255),
    b1_2bar_m1             NVARCHAR (255),
    b1_2bar_m2             NVARCHAR (255),
    b1_2bar_m3             NVARCHAR (255),
    b1_2bar_moy            NVARCHAR (255),
    b1_2bar_ecart          NVARCHAR (255),
    b1_3bar_m1             NVARCHAR (255),
    b1_3bar_m2             NVARCHAR (255),
    b1_3bar_m3             NVARCHAR (255),
    b1_3bar_moy            NVARCHAR (255),
    b1_3bar_ecart          NVARCHAR (255),
    b2_pressionEtal        NVARCHAR (255),
    b2_debitEtal           NVARCHAR (255),
    b2_2bar_m1             NVARCHAR (255),
    b2_2bar_m2             NVARCHAR (255),
    b2_2bar_m3             NVARCHAR (255),
    b2_2bar_moy            NVARCHAR (255),
    b2_2bar_ecart          NVARCHAR (255),
    b2_3bar_m1             NVARCHAR (255),
    b2_3bar_m2             NVARCHAR (255),
    b2_3bar_m3             NVARCHAR (255),
    b2_3bar_moy            NVARCHAR (255),
    b2_3bar_ecart          NVARCHAR (255),
    b3_pressionEtal        NVARCHAR (255),
    b3_debitEtal           NVARCHAR (255),
    b3_2bar_m1             NVARCHAR (255),
    b3_2bar_m2             NVARCHAR (255),
    b3_2bar_m3             NVARCHAR (255),
    b3_2bar_moy            NVARCHAR (255),
    b3_2bar_ecart          NVARCHAR (255),
    b3_3bar_m1             NVARCHAR (255),
    b3_3bar_m2             NVARCHAR (255),
    b3_3bar_m3             NVARCHAR (255),
    b3_3bar_moy            NVARCHAR (255),
    b3_3bar_ecart          NVARCHAR (255),
    b4_pressionEtal        NVARCHAR (255),
    b4_debitEtal           NVARCHAR (255),
    b4_2bar_m1             NVARCHAR (255),
    b4_2bar_m2             NVARCHAR (255),
    b4_2bar_m3             NVARCHAR (255),
    b4_2bar_moy            NVARCHAR (255),
    b4_2bar_ecart          NVARCHAR (255),
    b4_3bar_m1             NVARCHAR (255),
    b4_3bar_m2             NVARCHAR (255),
    b4_3bar_m3             NVARCHAR (255),
    b4_3bar_moy            NVARCHAR (255),
    b4_3bar_ecart          NVARCHAR (255),
    b5_pressionEtal        NVARCHAR (255),
    b5_debitEtal           NVARCHAR (255),
    b5_2bar_m1             NVARCHAR (255),
    b5_2bar_m2             NVARCHAR (255),
    b5_2bar_m3             NVARCHAR (255),
    b5_2bar_moy            NVARCHAR (255),
    b5_2bar_ecart          NVARCHAR (255),
    b5_3bar_m1             NVARCHAR (255),
    b5_3bar_m2             NVARCHAR (255),
    b5_3bar_m3             NVARCHAR (255),
    b5_3bar_moy            NVARCHAR (255),
    b5_3bar_ecart          NVARCHAR (255),
    b6_pressionEtal        NVARCHAR (255),
    b6_debitEtal           NVARCHAR (255),
    b6_2bar_m1             NVARCHAR (255),
    b6_2bar_m2             NVARCHAR (255),
    b6_2bar_m3             NVARCHAR (255),
    b6_2bar_moy            NVARCHAR (255),
    b6_2bar_ecart          NVARCHAR (255),
    b6_3bar_m1             NVARCHAR (255),
    b6_3bar_m2             NVARCHAR (255),
    b6_3bar_m3             NVARCHAR (255),
    b6_3bar_moy            NVARCHAR (255),
    b6_3bar_ecart          NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    idFichevie             NVARCHAR (255),
    b1_2bar_conformite     NVARCHAR (255),
    b2_2bar_conformite     NVARCHAR (255),
    b3_2bar_conformite     NVARCHAR (255),
    b4_2bar_conformite     NVARCHAR (255),
    b5_2bar_conformite     NVARCHAR (255),
    b6_2bar_conformite     NVARCHAR (255),
    b1_3bar_conformite     NVARCHAR (255),
    b2_3bar_conformite     NVARCHAR (255),
    b3_3bar_conformite     NVARCHAR (255),
    b4_3bar_conformite     NVARCHAR (255),
    b5_3bar_conformite     NVARCHAR (255),
    b6_3bar_conformite     NVARCHAR (255) 
);


-- Table : ControleManoMesure
DROP TABLE IF EXISTS ControleManoMesure;

CREATE TABLE ControleManoMesure (
    id                       NVARCHAR (255) NOT NULL
                                            PRIMARY KEY,
    idStructure              NVARCHAR (255) REFERENCES Structure (id),
    idMano                   NVARCHAR (255),
    manoEtalon               NVARCHAR (255),
    tempAir                  NVARCHAR (255),
    resultat                 NVARCHAR (255),
    up_pt1_pres_manoCtrl     NVARCHAR (255),
    up_pt1_pres_manoEtalon   NVARCHAR (255),
    up_pt1_incertitude       NVARCHAR (255),
    up_pt1_EMT               NVARCHAR (255),
    up_pt1_err_abs           NVARCHAR (255),
    up_pt1_err_fondEchelle   NVARCHAR (255),
    up_pt2_pres_manoCtrl     NVARCHAR (255),
    up_pt2_pres_manoEtalon   NVARCHAR (255),
    up_pt2_incertitude       NVARCHAR (255),
    up_pt2_EMT               NVARCHAR (255),
    up_pt2_err_abs           NVARCHAR (255),
    up_pt2_err_fondEchelle   NVARCHAR (255),
    up_pt3_pres_manoCtrl     NVARCHAR (255),
    up_pt3_pres_manoEtalon   NVARCHAR (255),
    up_pt3_incertitude       NVARCHAR (255),
    up_pt3_EMT               NVARCHAR (255),
    up_pt3_err_abs           NVARCHAR (255),
    up_pt3_err_fondEchelle   NVARCHAR (255),
    up_pt4_pres_manoCtrl     NVARCHAR (255),
    up_pt4_pres_manoEtalon   NVARCHAR (255),
    up_pt4_incertitude       NVARCHAR (255),
    up_pt4_EMT               NVARCHAR (255),
    up_pt4_err_abs           NVARCHAR (255),
    up_pt4_err_fondEchelle   NVARCHAR (255),
    up_pt5_pres_manoCtrl     NVARCHAR (255),
    up_pt5_pres_manoEtalon   NVARCHAR (255),
    up_pt5_incertitude       NVARCHAR (255),
    up_pt5_EMT               NVARCHAR (255),
    up_pt5_err_abs           NVARCHAR (255),
    up_pt5_err_fondEchelle   NVARCHAR (255),
    up_pt6_pres_manoCtrl     NVARCHAR (255),
    up_pt6_pres_manoEtalon   NVARCHAR (255),
    up_pt6_incertitude       NVARCHAR (255),
    up_pt6_EMT               NVARCHAR (255),
    up_pt6_err_abs           NVARCHAR (255),
    up_pt6_err_fondEchelle   NVARCHAR (255),
    down_pt1_pres_manoCtrl   NVARCHAR (255),
    down_pt1_pres_manoEtalon NVARCHAR (255),
    down_pt1_incertitude     NVARCHAR (255),
    down_pt1_EMT             NVARCHAR (255),
    down_pt1_err_abs         NVARCHAR (255),
    down_pt1_err_fondEchelle NVARCHAR (255),
    down_pt2_pres_manoCtrl   NVARCHAR (255),
    down_pt2_pres_manoEtalon NVARCHAR (255),
    down_pt2_incertitude     NVARCHAR (255),
    down_pt2_EMT             NVARCHAR (255),
    down_pt2_err_abs         NVARCHAR (255),
    down_pt2_err_fondEchelle NVARCHAR (255),
    down_pt3_pres_manoCtrl   NVARCHAR (255),
    down_pt3_pres_manoEtalon NVARCHAR (255),
    down_pt3_incertitude     NVARCHAR (255),
    down_pt3_EMT             NVARCHAR (255),
    down_pt3_err_abs         NVARCHAR (255),
    down_pt3_err_fondEchelle NVARCHAR (255),
    down_pt4_pres_manoCtrl   NVARCHAR (255),
    down_pt4_pres_manoEtalon NVARCHAR (255),
    down_pt4_incertitude     NVARCHAR (255),
    down_pt4_EMT             NVARCHAR (255),
    down_pt4_err_abs         NVARCHAR (255),
    down_pt4_err_fondEchelle NVARCHAR (255),
    down_pt5_pres_manoCtrl   NVARCHAR (255),
    down_pt5_pres_manoEtalon NVARCHAR (255),
    down_pt5_incertitude     NVARCHAR (255),
    down_pt5_EMT             NVARCHAR (255),
    down_pt5_err_abs         NVARCHAR (255),
    down_pt5_err_fondEchelle NVARCHAR (255),
    down_pt6_pres_manoCtrl   NVARCHAR (255),
    down_pt6_pres_manoEtalon NVARCHAR (255),
    down_pt6_incertitude     NVARCHAR (255),
    down_pt6_EMT             NVARCHAR (255),
    down_pt6_err_abs         NVARCHAR (255),
    down_pt6_err_fondEchelle NVARCHAR (255),
    dateModificationAgent    DATETIME2 (0),
    dateModificationCrodip   DATETIME2 (0),
    up_pt1_conformite        NVARCHAR (255),
    up_pt2_conformite        NVARCHAR (255),
    up_pt3_conformite        NVARCHAR (255),
    up_pt4_conformite        NVARCHAR (255),
    up_pt5_conformite        NVARCHAR (255),
    up_pt6_conformite        NVARCHAR (255),
    down_pt1_conformite      NVARCHAR (255),
    down_pt2_conformite      NVARCHAR (255),
    down_pt3_conformite      NVARCHAR (255),
    down_pt4_conformite      NVARCHAR (255),
    down_pt5_conformite      NVARCHAR (255),
    down_pt6_conformite      NVARCHAR (255),
    idFichevie               NVARCHAR (255) 
);


-- Table : Diagnostic
DROP TABLE IF EXISTS Diagnostic;

CREATE TABLE Diagnostic (
    id                                     NVARCHAR (50)  NOT NULL
                                                          PRIMARY KEY,
    organismePresId                        INT,
    organismePresNumero                    NVARCHAR (255),
    organismePresNom                       NVARCHAR (255),
    organismeInspNom                       NVARCHAR (255),
    organismeInspAgrement                  NVARCHAR (255),
    inspecteurId                           INT            REFERENCES Agent (Id),
    inspecteurNom                          NVARCHAR (255),
    inspecteurPrenom                       NVARCHAR (255),
    controleDateDebut                      DATETIME2 (0),
    controleDateFin                        DATETIME2 (0),
    controleCommune                        NVARCHAR (255),
    controleCodePostal                     NVARCHAR (255),
    controleLieu                           NVARCHAR (255),
    controleTerritoire                     NVARCHAR (255),
    controleSite                           NVARCHAR (255),
    controleNomSite                        NVARCHAR (255),
    controleIsComplet                      BIT,
    controleIsPremierControle              BIT,
    controleDateDernierControle            DATETIME2 (0),
    controleIsSiteSecurise                 BIT,
    controleIsRecupResidus                 BIT,
    controleEtat                           NVARCHAR (255),
    controleInfosConseils                  NVARCHAR (255),
    controleTarif                          NVARCHAR (255),
    controleIsPulveRepare                  BIT,
    proprietaireId                         NVARCHAR (255) REFERENCES Exploitation (id),
    proprietaireRaisonSociale              NVARCHAR (255),
    proprietairePrenom                     NVARCHAR (255),
    proprietaireNom                        NVARCHAR (255),
    proprietaireCodeApe                    NVARCHAR (255),
    proprietaireNumeroSiren                NVARCHAR (255),
    proprietaireCommune                    NVARCHAR (255),
    proprietaireCodePostal                 NVARCHAR (255),
    proprietaireAdresse                    NVARCHAR (255),
    proprietaireEmail                      NVARCHAR (255),
    proprietaireTelephonePortable          NVARCHAR (255),
    proprietaireTelephoneFixe              NVARCHAR (255),
    pulverisateurId                        NVARCHAR (50)  REFERENCES Pulverisateur (id),
    pulverisateurMarque                    NVARCHAR (255),
    pulverisateurModele                    NVARCHAR (255),
    pulverisateurType                      NVARCHAR (255),
    pulverisateurCapacite                  NVARCHAR (255),
    pulverisateurLargeur                   NVARCHAR (255),
    pulverisateurNbRangs                   NVARCHAR (255),
    pulverisateurLargeurPlantation         NVARCHAR (255),
    pulverisateurIsVentilateur             BIT,
    pulverisateurIsDebrayage               BIT,
    pulverisateurAnneeAchat                NVARCHAR (255),
    pulverisateurSurface                   NVARCHAR (255),
    pulverisateurNbUtilisateurs            NVARCHAR (255),
    pulverisateurIsCuveRincage             BIT,
    pulverisateurCapaciteCuveRincage       NVARCHAR (255),
    pulverisateurIsRotobuse                BIT,
    pulverisateurIsRinceBidon              BIT,
    pulverisateurIsBidonLaveMain           BIT,
    pulverisateurIsLanceLavageExterieur    BIT,
    pulverisateurIsCuveIncorporation       BIT,
    pulverisateurAttelage                  NVARCHAR (255),
    pulverisateurAutresAccessoires         NVARCHAR (255),
    buseMarque                             NVARCHAR (255),
    buseCouleur                            NVARCHAR (255),
    buseGenre                              NVARCHAR (255),
    buseCalibre                            NVARCHAR (255),
    buseDebit                              NVARCHAR (255),
    buseDebit2bars                         NVARCHAR (255),
    buseDebit3bars                         NVARCHAR (255),
    buseAge                                NVARCHAR (255),
    buseNbBuses                            NVARCHAR (255),
    buseType                               NVARCHAR (255),
    buseAngle                              NVARCHAR (255),
    buseIsISO                              BIT,
    manometreMarque                        NVARCHAR (255),
    manometreDiametre                      NVARCHAR (255),
    manometreType                          NVARCHAR (255),
    manometreFondEchelle                   NVARCHAR (255),
    manometrePressionTravail               NVARCHAR (255),
    exploitationTypeCultureIsGrandeCulture BIT,
    exploitationTypeCultureIsLegume        BIT,
    exploitationTypeCultureIsElevage       BIT,
    exploitationTypeCultureIsArboriculture BIT,
    exploitationTypeCultureIsViticulture   BIT,
    exploitationTypeCultureIsAutres        BIT,
    exploitationSau                        NVARCHAR (255),
    dateModificationAgent                  DATETIME2 (0),
    dateModificationCrodip                 DATETIME2 (0),
    dateSynchro                            DATETIME2 (0),
    isSynchro                              BIT,
    isATGIP                                BIT            DEFAULT (0),
    isTGIP                                 BIT            DEFAULT (0),
    isFacture                              BIT            DEFAULT (0),
    syntheseErreurMoyenneMano              NVARCHAR (255),
    syntheseErreurMaxiMano                 NVARCHAR (255),
    syntheseErreurDebitmetre               NVARCHAR (255),
    syntheseErreurMoyenneCinemometre       NVARCHAR (255),
    syntheseUsureMoyenneBuses              NVARCHAR (255),
    syntheseNbBusesUsees                   NVARCHAR (255),
    synthesePerteChargeMoyenne             NVARCHAR (255),
    synthesePerteChargeMaxi                NVARCHAR (255),
    controleIsPreControleProfessionel      BIT,
    controleIsAutoControle                 BIT,
    ProprietaireRepresentant               NVARCHAR (255),
    organismeOriginePresId                 INT,
    organismeOriginePresNumero             NVARCHAR (255),
    organismeOriginePresNom                NVARCHAR (255),
    organismeOrigineInspNom                NVARCHAR (255),
    organismeOrigineInspAgrement           NVARCHAR (255),
    inspecteurOrigineId                    INT,
    inspecteurOrigineNom                   NVARCHAR (255),
    inspecteurOriginePrenom                NVARCHAR (255),
    pulverisateurEmplacementIdentification NVARCHAR (255),
    controleBancMesureId                   NVARCHAR (255),
    controleUseCalibrateur                 BIT,
    controleNbreNiveaux                    NVARCHAR (255),
    controleNbreTroncons                   NVARCHAR (255),
    controleManoControleNumNational        NVARCHAR (255),
    controleInitialId                      NVARCHAR (20),
    pulverisateurAncienId                  NVARCHAR (50),
    buseModele                             NVARCHAR (255),
    RIFileName                             NVARCHAR (255),
    SMFileName                             NVARCHAR (255),
    pulverisateurRegulation                NVARCHAR (255),
    pulverisateurRegulationOptions         NVARCHAR (255),
    pulverisateurModeUtilisation           NVARCHAR (50),
    pulverisateurNbreExploitants           NVARCHAR (10),
    buseFonctionnement                     NVARCHAR (255),
    pulverisateurCategorie                 NVARCHAR (255),
    pulverisateurPulverisation             NVARCHAR (255),
    CCFileName                             NVARCHAR (255),
    pulverisateurCoupureAutoTroncons       NVARCHAR (10),
    pulverisateurReglageAutoHauteur        NVARCHAR (10),
    pulverisateurRincagecircuit            NVARCHAR (10),
    typeDiagnostic                         NVARCHAR (20),
    codeInsee                              NVARCHAR (20),
    commentaire                            NVARCHAR (255),
    pulverisateurNumNational               NVARCHAR (255),
    pulverisateurNumchassis                NVARCHAR (255),
    OrigineDiag                            NVARCHAR (255),
    isSignRIAgent                          BIT,
    isSignRIClient                         BIT,
    isSignCCAgent                          BIT,
    isSignCCClient                         BIT,
    dateSignRIAgent                        DATETIME2 (0),
    dateSignRIClient                       DATETIME2 (0),
    dateSignCCAgent                        DATETIME2 (0),
    dateSignCCClient                       DATETIME2 (0),
    isSupprime                             BIT,
    diagRemplacementId                     NVARCHAR (30),
    signRIAgent                            BLOB,
    signRIClient                           BLOB,
    signCCAgent                            BLOB,
    signCCClient                           BLOB,
    totalHT                                FLOAT,
    totalTTC                               FLOAT,
    dateRemplacement                       DATETIME2 (0),
    isCVImmediate                          BIT,
    isGratuit                              BIT
);


-- Table : DiagnosticBuses
DROP TABLE IF EXISTS DiagnosticBuses;

CREATE TABLE DiagnosticBuses (
    id                     INTEGER        NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
    idDiagnostic           NVARCHAR (255) NOT NULL
                                          REFERENCES Diagnostic (id),
    marque                 NVARCHAR (255),
    nombre                 NVARCHAR (255),
    genre                  NVARCHAR (255),
    calibre                NVARCHAR (255),
    couleur                NVARCHAR (255),
    debitMoyen             NVARCHAR (255),
    debitNominal           NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    idLot                  NVARCHAR (255),
    ecartTolere            NVARCHAR (255) 
);


-- Table : DiagnosticBusesDetail
DROP TABLE IF EXISTS DiagnosticBusesDetail;

CREATE TABLE DiagnosticBusesDetail (
    id                     INTEGER        NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
    idDiagnostic           NVARCHAR (255) NOT NULL
                                          REFERENCES Diagnostic (id),
    idBuse                 INT,
    idLot                  INT,
    debit                  NVARCHAR (255),
    ecart                  NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : DiagnosticFacture
DROP TABLE IF EXISTS DiagnosticFacture;

CREATE TABLE DiagnosticFacture (
    id                       NVARCHAR (255) NOT NULL
                                            PRIMARY KEY,
    factureReference         NVARCHAR (255),
    factureDate              NVARCHAR (255),
    factureTotal             NVARCHAR (255),
    emetteurOrganisme        NVARCHAR (255),
    emetteurOrganismeAdresse NVARCHAR (255),
    emetteurOrganismeCpVille NVARCHAR (255),
    emetteurOrganismeTelFax  NVARCHAR (255),
    emetteurOrganismeSiren   NVARCHAR (255),
    emetteurOrganismeTva     NVARCHAR (255),
    emetteurOrganismeRcs     NVARCHAR (255),
    recepteurRaisonSociale   NVARCHAR (255),
    recepteurProprio         NVARCHAR (255),
    recepteurCpVille         NVARCHAR (255),
    dateModificationAgent    NVARCHAR (255),
    dateModificationCrodip   NVARCHAR (255) 
);


-- Table : DiagnosticFactureItem
DROP TABLE IF EXISTS DiagnosticFactureItem;

CREATE TABLE DiagnosticFactureItem (
    id                     INT (1, 1)     NOT NULL
                                          PRIMARY KEY,
    idFacture              NVARCHAR (255) REFERENCES DiagnosticFacture (id),
    libelle                NVARCHAR (255),
    prixUnitaire           NVARCHAR (255),
    qte                    NVARCHAR (255),
    tva                    NVARCHAR (255),
    prixTotal              NVARCHAR (255),
    dateModificationAgent  NVARCHAR (255),
    dateModificationCrodip NVARCHAR (255) 
);


-- Table : DiagnosticItem
DROP TABLE IF EXISTS DiagnosticItem;

CREATE TABLE DiagnosticItem (
    id                     INTEGER        PRIMARY KEY AUTOINCREMENT,
    idDiagnostic           NVARCHAR (50)  NOT NULL
                                          REFERENCES Diagnostic (id),
    idItem                 NVARCHAR (10),
    itemValue              NVARCHAR (255),
    itemCodeEtat           NVARCHAR (255),
    isItemCode1            BIT,
    isItemCode2            BIT,
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    cause                  NVARCHAR (10) 
);


-- Table : DiagnosticMano542
DROP TABLE IF EXISTS DiagnosticMano542;

CREATE TABLE DiagnosticMano542 (
    id                     INTEGER        NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
    idDiagnostic           NVARCHAR (255) NOT NULL
                                          REFERENCES Diagnostic (id),
    pressionPulve          NVARCHAR (255),
    pressionControle       NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : DiagnosticTroncons833
DROP TABLE IF EXISTS DiagnosticTroncons833;

CREATE TABLE DiagnosticTroncons833 (
    id                     INTEGER        NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
    idDiagnostic           NVARCHAR (255) NOT NULL
                                          REFERENCES Diagnostic (id),
    idPression             NVARCHAR (255),
    idColumn               NVARCHAR (255),
    pressionSortie         NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : Etat_DebitBuses
DROP TABLE IF EXISTS Etat_DebitBuses;

CREATE TABLE Etat_DebitBuses (
    numBuse          NVARCHAR (255) NOT NULL,
    ecartPourcentage FLOAT
);


-- Table : Exploitation
DROP TABLE IF EXISTS Exploitation;

CREATE TABLE Exploitation (
    id                     NVARCHAR (50)  NOT NULL
                                          PRIMARY KEY,
    numeroSiren            NVARCHAR (255),
    codeApe                NVARCHAR (5),
    raisonSociale          NVARCHAR (255),
    nombreExploitant       SMALLINT,
    nomExploitant          NVARCHAR (255),
    prenomExploitant       NVARCHAR (255),
    adresse                NVARCHAR (255),
    codePostal             NVARCHAR (5),
    commune                NVARCHAR (255),
    codeInsee              NVARCHAR (5),
    telephoneFixe          NVARCHAR (20),
    telephonePortable      NVARCHAR (20),
    telephoneFax           NVARCHAR (20),
    eMail                  NVARCHAR (255),
    surfaceAgricoleUtile   NVARCHAR (255),
    isProdGrandeCulture    BIT,
    isProdElevage          BIT,
    isProdArboriculture    BIT,
    isProdLegume           BIT,
    isProdViticulture      BIT,
    isProdAutre            BIT,
    productionAutre        NVARCHAR (255),
    idStructure            INT            REFERENCES Structure (id),
    isSupprime             BIT,
    dateModificationCrodip DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    dateDernierControle    DATETIME2 (0) 
);


-- Table : ExploitationTOPulverisateur
DROP TABLE IF EXISTS ExploitationTOPulverisateur;

CREATE TABLE ExploitationTOPulverisateur (
    id                     NVARCHAR (100) NOT NULL
                                          PRIMARY KEY,
    idPulverisateur        NVARCHAR (50)  REFERENCES Pulverisateur (id),
    idExploitation         NVARCHAR (50)  REFERENCES Exploitation (id),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    isSupprimeCoProp       BIT
);


-- Table : facture
DROP TABLE IF EXISTS facture;

CREATE TABLE facture (
    idfacture              NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idstructure            NVARCHAR (50)  REFERENCES Structure (id),
    datefacture            DATETIME2 (0),
    dateecheance           DATETIME2 (0),
    commentaire            NVARCHAR (255),
    modereglement          NVARCHAR (255),
    isreglee               BIT            NOT NULL
                                          DEFAULT (0),
    refreglement           NVARCHAR (255),
    totalht                FLOAT,
    txtva                  FLOAT,
    totalttc               FLOAT,
    totaltva               FLOAT,
    iddiag                 NVARCHAR (50),
    idexploit              NVARCHAR (50),
    rsclient               NVARCHAR (255),
    nomclient              NVARCHAR (255),
    prenomclient           NVARCHAR (255),
    adresseclient          NVARCHAR (255),
    cpclient               NVARCHAR (255),
    communeclient          NVARCHAR (255),
    telfixeclient          NVARCHAR (255),
    telportclient          NVARCHAR (255),
    emailclient            NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCRODIP DATETIME2 (0),
    pathPDF                NVARCHAR (255) 
);


-- Table : factureitem
DROP TABLE IF EXISTS factureitem;

CREATE TABLE factureitem (
    idfacture              NVARCHAR (255) NOT NULL,
    nfactureitem           INT            NOT NULL,
    categorie              NVARCHAR (255),
    prestation             NVARCHAR (255),
    quantite               FLOAT,
    pu                     FLOAT,
    totalhtitem            FLOAT,
    totaltvaitem           FLOAT,
    totalttcitem           FLOAT,
    txtvaitem              FLOAT,
    dateModificationAgent  DATETIME2 (0),
    dateModificationCRODIP DATETIME2 (0) 
);


-- Table : FichevieBancMesure
DROP TABLE IF EXISTS FichevieBancMesure;

CREATE TABLE FichevieBancMesure (
    id                     NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idBancMesure           NVARCHAR (255) REFERENCES BancMesure (id),
    type                   NVARCHAR (255),
    auteur                 NVARCHAR (255),
    idAgentControleur      INT,
    caracteristiques       NVARCHAR (255),
    dateModif              DATETIME2 (0),
    blocage                BIT,
    pressionControle       NVARCHAR (255),
    valeursMesurees        NVARCHAR (255),
    idManometreControle    NVARCHAR (255),
    idBuseEtalon           NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0),
    FVFileName             NVARCHAR (255) 
);


-- Table : FichevieManometreControle
DROP TABLE IF EXISTS FichevieManometreControle;

CREATE TABLE FichevieManometreControle (
    id                     NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idManometre            NVARCHAR (255),
    type                   NVARCHAR (255),
    auteur                 NVARCHAR (255),
    idAgentControleur      INT,
    caracteristiques       NVARCHAR (255),
    dateModif              DATETIME2 (0),
    blocage                BIT,
    idReetalonnage         NVARCHAR (255),
    nomLaboratoire         NVARCHAR (255),
    dateReetalonnage       DATETIME2 (0),
    pressionControle       NVARCHAR (255),
    valeursMesurees        NVARCHAR (255),
    idManometreControleur  NVARCHAR (255),
    dateModificationCrodip DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    FVFileName             NVARCHAR (255) 
);


-- Table : FichevieManometreEtalon
DROP TABLE IF EXISTS FichevieManometreEtalon;

CREATE TABLE FichevieManometreEtalon (
    id                     NVARCHAR (255) NOT NULL
                                          PRIMARY KEY,
    idManometre            NVARCHAR (255),
    type                   NVARCHAR (255),
    auteur                 NVARCHAR (255),
    idAgentControleur      INT,
    caracteristiques       NVARCHAR (255),
    dateModif              DATETIME2 (0),
    blocage                BIT,
    idReetalonnage         NVARCHAR (255),
    nomLaboratoire         NVARCHAR (255),
    dateReetalonnage       DATETIME2 (0),
    pressionControle       NVARCHAR (255),
    valeursMesurees        NVARCHAR (255),
    idManometreControleur  NVARCHAR (255),
    dateModificationCrodip DATETIME2 (0),
    dateModificationAgent  DATETIME2 (0),
    FVFileName             NVARCHAR (255) 
);


-- Table : IdentifiantPulverisateur
DROP TABLE IF EXISTS IdentifiantPulverisateur;

CREATE TABLE IdentifiantPulverisateur (
    id                     INT            NOT NULL
                                          PRIMARY KEY,
    idStructure            INT            REFERENCES Structure (id),
    numeroNational         NVARCHAR (30)  NOT NULL,
    etat                   NVARCHAR (30),
    dateUtilisation        NVARCHAR (255),
    libelle                NVARCHAR (255),
    dateModificationAgent  NVARCHAR (255),
    dateModificationCrodip NVARCHAR (255) 
);


-- Table : PrestationCategorie
DROP TABLE IF EXISTS PrestationCategorie;

CREATE TABLE PrestationCategorie (
    id                     INT (1, 1)     NOT NULL
                                          PRIMARY KEY,
    idStructure            INT            REFERENCES Structure (id),
    libelle                NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : PrestationTarif
DROP TABLE IF EXISTS PrestationTarif;

CREATE TABLE PrestationTarif (
    id                     INT (1, 1)     NOT NULL
                                          PRIMARY KEY,
    idCategorie            INT            REFERENCES PrestationCategorie (id),
    idStructure            INT,
    description            NVARCHAR (255),
    tarifHT                FLOAT,
    tarifTTC               FLOAT,
    tva                    FLOAT,
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : Pulverisateur
DROP TABLE IF EXISTS Pulverisateur;

CREATE TABLE Pulverisateur (
    id                        NVARCHAR (50)  NOT NULL
                                             PRIMARY KEY,
    numeroNational            NVARCHAR (255),
    type                      NVARCHAR (255),
    marque                    NVARCHAR (255),
    modele                    NVARCHAR (255),
    anneeAchat                NVARCHAR (4),
    attelage                  NVARCHAR (255),
    capacite                  INT,
    largeur                   NVARCHAR (255),
    nombrerangs               NVARCHAR (255),
    largeurPlantation         NVARCHAR (255),
    surfaceParAn              NVARCHAR (255),
    nombreUtilisateurs        NVARCHAR (255),
    isVentilateur             BIT,
    isDebrayage               BIT,
    isCuveRincage             BIT,
    capaciteCuveRincage       NVARCHAR (255),
    isRotobuse                BIT,
    isCuveIncorporation       BIT,
    isRinceBidon              BIT,
    isBidonLaveMain           BIT,
    isLanceLavage             BIT,
    nombreBuses               INT,
    buseIsIso                 BIT,
    buseMarque                NVARCHAR (255),
    buseType                  NVARCHAR (255),
    buseFonctionnement        NVARCHAR (255),
    buseAge                   INT,
    buseAngle                 NVARCHAR (255),
    manometreMarque           NVARCHAR (255),
    manometreType             NVARCHAR (255),
    manometreFondEchelle      NVARCHAR (255),
    manometreDiametre         NVARCHAR (255),
    manometrePressionTravail  NVARCHAR (255),
    idStructure               INT            REFERENCES Structure (id),
    isSynchro                 BIT,
    isSupprime                BIT,
    dateProchainControle      DATETIME2 (0),
    dateModificationAgent     DATETIME2 (0),
    dateModificationCrodip    DATETIME2 (0),
    emplacementIdentification NVARCHAR (255),
    ancienIdentifiant         NVARCHAR (255),
    isEclairageRampe          BIT,
    isBarreGuidage            BIT,
    isCoupureAutoTroncons     BIT,
    isRincageAutoAssiste      BIT,
    buseModele                NVARCHAR (255),
    buseNbniveaux             INT,
    manometreNbniveaux        INT,
    manometreNbtroncons       INT,
    buseCouleur               NVARCHAR (255),
    regulation                NVARCHAR (255),
    regulationOptions         NVARCHAR (255),
    modeUtilisation           NVARCHAR (50),
    nombreExploitants         NVARCHAR (10),
    controleEtat              NVARCHAR (255),
    categorie                 NVARCHAR (255),
    pulverisation             NVARCHAR (255),
    isAspirationExt           BIT,
    isDispoAntiRetour         BIT,
    isReglageAutoHauteur      BIT,
    isFiltrationAspiration    BIT,
    isFiltrationRefoulement   BIT,
    isFiltrationTroncons      BIT,
    isFiltrationBuses         BIT,
    isPulveAdditionnel        BIT,
    pulvePrincipalNumNat      NVARCHAR (50),
    isRincagecircuit          BIT,
    isPompesDoseuses          BIT,
    nbPompesDoseuses          INT,
    Numchassis                NVARCHAR (255) 
);


-- Table : Structure
DROP TABLE IF EXISTS Structure;

CREATE TABLE Structure (
    id                     INTEGER        NOT NULL
                                          PRIMARY KEY,
    idCrodip               NVARCHAR (255) UNIQUE,
    nom                    NVARCHAR (255),
    type                   NVARCHAR (255),
    nomResponsable         NVARCHAR (255),
    nomContact             NVARCHAR (255),
    prenomContact          NVARCHAR (255),
    adresse                NVARCHAR (255),
    codePostal             NVARCHAR (5),
    commune                NVARCHAR (255),
    codeInsee              NVARCHAR (5),
    telephoneFixe          NVARCHAR (20),
    telephonePortable      NVARCHAR (20),
    telephoneFax           NVARCHAR (20),
    eMail                  NVARCHAR (255),
    commentaire            NVARCHAR (255),
    dateModificationAgent  DATETIME2 (0),
    dateModificationCrodip DATETIME2 (0) 
);


-- Table : Synchronisation
DROP TABLE IF EXISTS Synchronisation;

CREATE TABLE Synchronisation (
    id                  [INT IDENTITY] (1, 1) NOT NULL,
    idAgent             INT,
    sensSynchronisation NVARCHAR (255),
    dateSynchronisation DATETIME2 (0),
    logSynchronisation  TEXT
);


-- Table : VERSION
DROP TABLE IF EXISTS VERSION;

CREATE TABLE VERSION (
    VERSION_NUM  NVARCHAR (255),
    VERSION_DATE DATETIME2 (0),
    VERSION_COMM NVARCHAR (255) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
