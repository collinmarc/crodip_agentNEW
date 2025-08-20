Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Linq
Imports CRODIP_ControlLibrary

<Serializable(), XmlInclude(GetType(Pulverisateur))>
Public Class Pulverisateur
    Inherits root
    Implements ICloneable


    Public Shared CO_PRORIETE As String = "Co-Propriété"
    Public Shared TYPEPULVE_ARBRES As String = "Arbres"
    Public Shared TYPEPULVE_CULTURESBASSES As String = "Cultures basses"
    Public Shared TYPEPULVE_VIGNE As String = "Vigne"

    Public Shared CATEGORIEPULVE_AXIAL As String = "Axial"
    Public Shared CATEGORIEPULVE_CANON As String = "Canon"
    Public Shared CATEGORIEPULVE_FACEPARFACE As String = "Face par face"
    Public Shared CATEGORIEPULVE_JETDIRIGE As String = "Jet dirigé"
    Public Shared CATEGORIEPULVE_RAMPE As String = "Rampe"
    '    Public Shared CATEGORIEPULVE_ARBOVITI As String = GlobalsCRODIP.GLOB_XML_CATEGORIES_PULVE.getXmlNode("//Categorie[id=6]/libelle").InnerText
    Public Shared CATEGORIEPULVE_ARBOVITI2 As String = "ArboViti"
    Public Shared CATEGORIEPULVE_VOUTE As String = "Voute"

    Public Const TYPEVALEURPULVE_LARGEUR As String = "LARGEUR"
    Public Const TYPEVALEURPULVE_RANG As String = "RANG"

    Public Shared PULVERISATION_JETPORTE As String
    Public Shared PULVERISATION_JETPROJETE As String
    Public Shared PULVERISATION_PNEUMATIQUE As String

    Public Shared ATTELAGE_PORTE As String
    Public Shared ATTELAGE_TRAINE As String
    Public Shared ATTELAGE_AUTOMOTEUR As String
    Public Shared ATTELAGE_SEMIPORTE As String
    Public Shared ATTELAGE_INTEGRE As String

    'Public Shared FONCTIONNEMENT_BUSES_STANDARD As String = GlobalsCRODIP.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNode("//type[1]/fonctionnement/item[id=1]/text").InnerText
    'Public Shared FONCTIONNEMENT_BUSES_PASTILLE As String = GlobalsCRODIP.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNode("//type[1]/fonctionnement/item[id=2]/text").InnerText
    'Public Shared FONCTIONNEMENT_BUSES_AIRLIBRE As String = GlobalsCRODIP.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNode("//type[1]/fonctionnement/item[id=3]/text").InnerText
    'Public Shared FONCTIONNEMENT_BUSES_AIRFORCE As String = GlobalsCRODIP.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNode("//type[1]/fonctionnement/item[id=4]/text").InnerText

    Private _id As String = ""
    Private _numeroNational As String = ""
    Private _type As String = ""
    Private _marque As String = ""
    Private _modele As String = ""
    Private _anneeAchat As String = ""
    Private _categorie As String = ""
    Private _categorieIsRampe As Boolean = False
    Private _categorieIsAxial As Boolean = False
    Private _categorieIsJetDirige As Boolean = False
    Private _categorieIsCanon As Boolean = False
    Private _categorieIsVoute As Boolean = False
    Private _categorieIsFaceParFace As Boolean = False
    Private _attelage As String = ""
    Private _pulverisation As String = ""
    Private _isJetPorte As Boolean = False
    Private _isJetProjete As Boolean = False
    Private _isPneumatique As Boolean = False
    Private _capacite As Integer
    Private _largeur As String = ""
    Private m_nombreRangs As String = ""
    Private _largeurPlantation As String = ""
    Private _surfaceParAn As String = ""
    Private _nombreUtilisateurs As String = ""
    Private _isVentilateur As Boolean = False
    Private _isDebrayage As Boolean = False
    Private _isCuveRincage As Boolean = False
    Private _capaciteCuveRincage As String = ""
    Private _isRotobuse As Boolean = False
    Private _isCuveIncorporation As Boolean = False
    Private _isRinceBidon As Boolean = False
    Private _isBidonLaveMain As Boolean = False
    Private _isLanceLavage As Boolean = False
    Private _isPressionConstante As Boolean = False
    Private _isDPM As Boolean = False
    Private _isDPA As Boolean = False
    Private _isDPAE As Boolean = False
    Private _isDPAEPression As Boolean = False
    Private _isDPAEDebit As Boolean = False
    Private _nombreBuses As Integer
    Private _buseIsIso As Boolean = False
    Private _buseMarque As String = ""
    Private _buseType As String = ""
    Private _buseFonctionnement As String = ""
    Private _buseAge As String = ""
    Private _buseAngle As String = ""
    Private _manometreMarque As String = ""
    Private _manometreType As String = ""
    Private _manometreFondEchelle As String = ""
    Private _manometreDiametre As String = ""
    Private _manometrePressionTravail As String = ""
    Private _isSynchro As Boolean = False
    Private _isSupprime As Boolean = False
    Private _dateProchainControle As String = ""
    Private _dateModificationCrodip As String = ""
    Private _dateModificationAgent As String = ""
    Private _idStructure As Integer
    Private _EmplacementIdentification As String = ""
    Private _AncienIdentifiant As String = ""
    Private _ControleEtat As String = ""
    Private _raisonSociale As String = ""
    Private _nomExploitant As String = ""
    Private _prenomExploitant As String = ""
    Private _codePostal As String = ""
    Private _commune As String = ""
    Private _EclairageRampe As Boolean = False
    Private _BarreGuidage As Boolean = False
    Private _CoupureAutoTroncons As Boolean = False
    Private _RincageAutoAssiste As Boolean = False
    Private _buseModele As String = ""
    Private _buseNbNiveaux As Integer
    Private _manometreNbNiveaux As Integer
    Private _manometreNbTroncons As Integer
    Private _buseCouleur As String = ""
    Private _Regulation As String = ""
    Private _RegulationOptions As String = ""
    Private _modeUtilisation As String = ""
    Private _nombreExploitants As String = ""
    Private _aspirationExterieur As Boolean = False
    Private _dispositifAntiRetour As Boolean = False
    Private _reglageAutoHauteur As Boolean = False
    Private _filtrationAspiration As Boolean = False
    Private _filtrationRefoulement As Boolean = False
    Private _filtrationTroncons As Boolean = False
    Private _filtrationBuses As Boolean = False
    Private _pulveAdditionnel As Boolean = False
    Private _pulvePrincipalNumNat As String = ""
    Private _isRincagecircuit As Boolean = False
    Private _isPompesDoseuses As Boolean = False
    Private _nbPompesDoseuses As Integer
    Private _numChassis As String

    Private _lstAnnomalie As List(Of Anomalie)
    Public Shared Sub initConstantes()
        PULVERISATION_JETPORTE = GlobalsCRODIP.GLOB_XML_PULVERISATION_PULVE.getXmlNode("//Pulverisation[id=1]/libelle").InnerText
        PULVERISATION_JETPROJETE = GlobalsCRODIP.GLOB_XML_PULVERISATION_PULVE.getXmlNode("//Pulverisation[id=2]/libelle").InnerText
        PULVERISATION_PNEUMATIQUE = GlobalsCRODIP.GLOB_XML_PULVERISATION_PULVE.getXmlNode("//Pulverisation[id=3]/libelle").InnerText

        ATTELAGE_PORTE = GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE.getXmlNode("//Attelage[id=1]/libelle").InnerText
        ATTELAGE_TRAINE = GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE.getXmlNode("//Attelage[id=2]/libelle").InnerText
        ATTELAGE_AUTOMOTEUR = GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE.getXmlNode("//Attelage[id=3]/libelle").InnerText
        ATTELAGE_SEMIPORTE = GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE.getXmlNode("//Attelage[id=4]/libelle").InnerText
        ATTELAGE_INTEGRE = GlobalsCRODIP.GLOB_XML_ATTELAGE_PULVE.getXmlNode("//Attelage[id=5]/libelle").InnerText

    End Sub

    Sub New()
        If GlobalsCRODIP.GLOB_ENV_MODESIMPLIFIE Then
            'En mod simplifié ce n'est pas un E001
            numeroNational = ""
        Else
            numeroNational = GlobalsCRODIP.GLOB_DIAG_NUMAGR
        End If
        dateProchainControle = Nothing
        controleEtat = controleEtatOK
        _lstAnnomalie = New List(Of Anomalie)()
    End Sub
    Public Property id() As String
        Get
            Return aid
        End Get
        Set(ByVal Value As String)
            aid = Value
        End Set
    End Property

    Public Property numeroNational() As String
        Get
            Return _numeroNational
        End Get
        Set(ByVal Value As String)
            _numeroNational = Value
        End Set
    End Property
    ''' <summary>
    ''' ce numéro nationnal sert à mémoriser l'ancien numero en cas de modification
    ''' il est initialisé au moment du chargement de l'objet en mémoire
    ''' </summary>
    ''' <returns></returns>
    Dim _numeroNationalBis As String
    <XmlIgnore()>
    Public Property numeroNationalBis() As String
        Get
            Return _numeroNationalBis
        End Get
        Set(ByVal Value As String)
            _numeroNationalBis = Value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Function isTypeFixeouSemisMobile() As Boolean

        Dim bReturn As Boolean
        Dim oLstParam As List(Of ParamDiag)
        oLstParam = ParamDiag.readXML()
        Dim libParam As String = ""
        For Each oParam As ParamDiag In oLstParam
            If oParam.id = "6" Then
                libParam = oParam.libelle
            End If
        Next
        bReturn = type.Equals(libParam)
        Return bReturn

    End Function
    <XmlIgnore()>
    Public ReadOnly Property isDiagRampe() As Boolean
        Get
            'On réalise un diag en mode Rampe si on est en Culture basses(type) ou en rampe (categorie)
            Return (type.Trim().ToUpper() = TYPEPULVE_CULTURESBASSES.Trim().ToUpper()) Or (categorie = CATEGORIEPULVE_RAMPE)
        End Get
    End Property

    Public Property marque() As String
        Get
            Return _marque
        End Get
        Set(ByVal Value As String)
            _marque = Value
        End Set
    End Property

    Public Property modele() As String
        Get
            Return _modele
        End Get
        Set(ByVal Value As String)
            _modele = Value
        End Set
    End Property

    Public Property anneeAchat() As String
        Get
            Return _anneeAchat
        End Get
        Set(ByVal Value As String)
            _anneeAchat = Value
        End Set
    End Property

    Public Property categorie() As String
        Get
            Return _categorie
        End Get
        Set(ByVal Value As String)
            _categorie = Value
        End Set
    End Property



    Public Property attelage() As String
        Get
            Return _attelage
        End Get
        Set(ByVal Value As String)
            _attelage = Value
            If _attelage = "Trainé" Or _attelage = "Traine" Then
                _attelage = ATTELAGE_TRAINE
            End If
        End Set
    End Property

    Public Property pulverisation() As String
        Get
            Return _pulverisation
        End Get
        Set(ByVal Value As String)
            _pulverisation = Value
        End Set
    End Property
    <XmlElement("capacite")>
    Public Property capaciteWS() As String
        Get
            Return capacite
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                capacite = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property capacite() As Integer
        Get
            Return _capacite
        End Get
        Set(ByVal Value As Integer)
            _capacite = Value
        End Set
    End Property
    ''' <summary>
    ''' Largeur du pulve (on utilise des . comme symbole decimal)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property largeur() As String
        Get
            Return _largeur.Replace(GlobalsCRODIP.CONST_DECIMAL_SYMBOL, ".")
        End Get
        Set(ByVal Value As String)
            _largeur = Value.Replace(".", GlobalsCRODIP.CONST_DECIMAL_SYMBOL)
            If IsNumeric(_largeur) Then
                _largeur = CType(_largeur, Decimal).ToString("##0.##")
                _largeur = _largeur.Replace(GlobalsCRODIP.CONST_DECIMAL_SYMBOL, ".")
            Else
                _largeur = Value
            End If
        End Set
    End Property

    Public Property nombreRangs() As String
        Get
            Return m_nombreRangs
        End Get
        Set(ByVal Value As String)
            m_nombreRangs = Value
            m_nombreRangs = m_nombreRangs.Replace(GlobalsCRODIP.CONST_DECIMAL_SYMBOL, ".")
        End Set
    End Property
    ''' <summary>
    ''' Propriété uniquement pour affiche
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <XmlIgnoreAttribute()>
    Public Property LargeurNombreRangs() As String
        Get
            Dim strTypeValeur As String
            Dim strReturn As String = ""
            strTypeValeur = MarquesManager.GetTypeValeur_Pulve(type, categorie)
            If Not String.IsNullOrEmpty(strTypeValeur) Then
                Select Case strTypeValeur.ToUpper().Trim
                    Case TYPEVALEURPULVE_LARGEUR
                        Dim strlargeur As String = ""
                        If Not String.IsNullOrEmpty(largeur) Then
                            strlargeur = largeur.Replace(".", ",")
                            If IsNumeric(strlargeur) Then
                                Try

                                    strReturn = CType(strlargeur, Decimal).ToString("##0.##").Replace(",", ".")
                                Catch ex As Exception
                                    strReturn = strlargeur
                                End Try
                            End If
                        End If
                    Case TYPEVALEURPULVE_RANG
                        strReturn = nombreRangs
                    Case Else
                        strReturn = ""
                End Select
            End If
            Return strReturn
        End Get
        Set(ByVal Value As String)
        End Set
    End Property

    Public Property largeurPlantation() As String
        Get
            Return _largeurPlantation
        End Get
        Set(ByVal Value As String)
            _largeurPlantation = Value
        End Set
    End Property

    Public Property surfaceParAn() As String
        Get
            Return _surfaceParAn
        End Get
        Set(ByVal Value As String)
            _surfaceParAn = Value
        End Set
    End Property

    Public Property nombreUtilisateurs() As String
        Get
            Return _nombreUtilisateurs
        End Get
        Set(ByVal Value As String)
            _nombreUtilisateurs = Value
        End Set
    End Property

    Public Property isVentilateur() As Boolean
        Get
            Return _isVentilateur
        End Get
        Set(ByVal Value As Boolean)
            _isVentilateur = Value
        End Set
    End Property

    Public Property isDebrayage() As Boolean
        Get
            Return _isDebrayage
        End Get
        Set(ByVal Value As Boolean)
            _isDebrayage = Value
        End Set
    End Property

    Public Property isCuveRincage() As Boolean
        Get
            Return _isCuveRincage
        End Get
        Set(ByVal Value As Boolean)
            _isCuveRincage = Value
        End Set
    End Property

    Public Property capaciteCuveRincage() As String
        Get
            Return _capaciteCuveRincage
        End Get
        Set(ByVal Value As String)
            _capaciteCuveRincage = Value
        End Set
    End Property

    Public Property isRotobuse() As Boolean
        Get
            Return _isRotobuse
        End Get
        Set(ByVal Value As Boolean)
            _isRotobuse = Value
        End Set
    End Property

    Public Property isCuveIncorporation() As Boolean
        Get
            Return _isCuveIncorporation
        End Get
        Set(ByVal Value As Boolean)
            _isCuveIncorporation = Value
        End Set
    End Property

    Public Property isRinceBidon() As Boolean
        Get
            Return _isRinceBidon
        End Get
        Set(ByVal Value As Boolean)
            _isRinceBidon = Value
        End Set
    End Property

    Public Property isBidonLaveMain() As Boolean
        Get
            Return _isBidonLaveMain
        End Get
        Set(ByVal Value As Boolean)
            _isBidonLaveMain = Value
        End Set
    End Property

    Public Property isLanceLavage() As Boolean
        Get
            Return _isLanceLavage
        End Get
        Set(ByVal Value As Boolean)
            _isLanceLavage = Value
        End Set
    End Property
    <XmlElement("nombreBuses")>
    Public Property nombreBusesWS() As String
        Get
            Return nombreBuses
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                nombreBuses = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property nombreBuses() As Integer
        Get
            Return _nombreBuses
        End Get
        Set(ByVal Value As Integer)
            _nombreBuses = Value
        End Set
    End Property

    Public Property buseIsIso() As Boolean
        Get
            Return _buseIsIso
        End Get
        Set(ByVal Value As Boolean)
            _buseIsIso = Value
        End Set
    End Property

    Public Property buseMarque() As String
        Get
            Return _buseMarque
        End Get
        Set(ByVal Value As String)
            _buseMarque = Value
        End Set
    End Property
    Public Property buseModele() As String
        Get
            Return _buseModele
        End Get
        Set(ByVal Value As String)
            _buseModele = Value
        End Set
    End Property

    Public Property buseType() As String
        Get
            Return _buseType
        End Get
        Set(ByVal Value As String)
            _buseType = Value
        End Set
    End Property

    Public Property buseFonctionnement() As String
        Get
            Return _buseFonctionnement
        End Get
        Set(ByVal Value As String)
            _buseFonctionnement = Value
        End Set
    End Property

    Public Property buseAge() As String
        Get
            Return _buseAge
        End Get
        Set(ByVal Value As String)
            _buseAge = Value
        End Set
    End Property

    Public Property buseAngle() As String
        Get
            Return _buseAngle
        End Get
        Set(ByVal Value As String)
            _buseAngle = Value
        End Set
    End Property

    Public Property buseCouleur() As String
        Get
            Return _buseCouleur
        End Get
        Set(ByVal Value As String)
            _buseCouleur = Value
        End Set
    End Property
    Public Property manometreMarque() As String
        Get
            Return _manometreMarque
        End Get
        Set(ByVal Value As String)
            _manometreMarque = Value
        End Set
    End Property

    Public Property manometreType() As String
        Get
            Return _manometreType
        End Get
        Set(ByVal Value As String)
            _manometreType = Value
        End Set
    End Property

    Public Property manometreFondEchelle() As String
        Get
            Return _manometreFondEchelle
        End Get
        Set(ByVal Value As String)
            _manometreFondEchelle = Value
        End Set
    End Property

    Public Property manometreDiametre() As String
        Get
            Return _manometreDiametre
        End Get
        Set(ByVal Value As String)
            _manometreDiametre = Value
        End Set
    End Property

    Public Property manometrePressionTravail() As String
        Get
            Return _manometrePressionTravail
        End Get
        Set(ByVal Value As String)
            _manometrePressionTravail = Value
        End Set
    End Property

    Public Property isSynchro() As Boolean
        Get
            Return _isSynchro
        End Get
        Set(ByVal Value As Boolean)
            _isSynchro = Value
        End Set
    End Property

    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateProchainControleAsDate() As Nullable(Of Date)
        Get
            Try
                Return CDate(_dateProchainControle)
            Catch Ex As Exception
                Return Nothing
            End Try

        End Get
        Set(ByVal Value As Nullable(Of Date))
            _dateProchainControle = Value
        End Set
    End Property
    Public Property dateProchainControle() As String
        Get
            Return _dateProchainControle
        End Get
        Set(ByVal Value As String)
            _dateProchainControle = Value
        End Set
    End Property
    Public Property uidstructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property
    <XmlIgnore>
    Public Property idStructure() As Integer
        Get
            Return uidstructure
        End Get
        Set(ByVal Value As Integer)
            uidstructure = Value
        End Set
    End Property
    Public Property emplacementIdentification() As String
        Get
            Return _EmplacementIdentification
        End Get
        Set(ByVal Value As String)
            _EmplacementIdentification = Value
        End Set
    End Property

    Public Property ancienIdentifiant() As String
        Get
            Return _AncienIdentifiant
        End Get
        Set(ByVal Value As String)
            _AncienIdentifiant = Value
        End Set
    End Property
    ''' Resultat du diagnostic
    '''  1 = PULVE EN BON ETAT
    '''  0 = DEFAUT SUR PULVE
    ''' -1 = Erreur en préliminaires
    '''  Rien = pas de controle
    Public Const controleEtatOK As String = "1"
    Public Const controleEtatNOKCV As String = "0"
    Public Const controleEtatNOKCC As String = "-1"
    ''' <summary>
    ''' Etat du Pulvé
    '''  1 = PULVE EN BON ETAT
    '''  0 = DEFAUT SUR PULVE
    '''  Rien = pas de controle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property controleEtat() As String
        Get
            Return _ControleEtat
        End Get
        Set(ByVal Value As String)
            _ControleEtat = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property RaisonSocialeExploitant() As String
        Get
            Return _raisonSociale
        End Get
        Set(ByVal Value As String)
            _raisonSociale = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property NomExploitant() As String
        Get
            Return _nomExploitant
        End Get
        Set(ByVal Value As String)
            _nomExploitant = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property PrenomExploitant() As String
        Get
            Return _prenomExploitant
        End Get
        Set(ByVal Value As String)
            _prenomExploitant = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property codePostal() As String
        Get
            Return _codePostal
        End Get
        Set(ByVal Value As String)
            _codePostal = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property Commune() As String
        Get
            Return _commune
        End Get
        Set(ByVal Value As String)
            _commune = Value
        End Set
    End Property

    Public Property isEclairageRampe() As Boolean
        Get
            Return _EclairageRampe
        End Get
        Set(ByVal Value As Boolean)
            _EclairageRampe = Value
        End Set
    End Property
    Public Property isBarreGuidage() As Boolean
        Get
            Return _BarreGuidage
        End Get
        Set(ByVal Value As Boolean)
            _BarreGuidage = Value
        End Set
    End Property
    Public Property isCoupureAutoTroncons() As Boolean
        Get
            Return _CoupureAutoTroncons
        End Get
        Set(ByVal Value As Boolean)
            _CoupureAutoTroncons = Value
        End Set
    End Property
    Public Property isRincageAutoAssiste() As Boolean
        Get
            Return _RincageAutoAssiste
        End Get
        Set(ByVal Value As Boolean)
            _RincageAutoAssiste = Value
        End Set
    End Property
    <XmlElement("buseNbniveaux")>
    Public Property buseNbniveauxWS() As String
        Get
            Return buseNbniveaux
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                buseNbniveaux = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property buseNbniveaux() As Integer
        Get
            Return _buseNbNiveaux
        End Get
        Set(ByVal Value As Integer)
            _buseNbNiveaux = Value
        End Set
    End Property
    <XmlElement("manometreNbniveaux")>
    Public Property manometreNbniveauxWS() As String
        Get
            Return manometreNbniveaux
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                manometreNbniveaux = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property manometreNbniveaux() As Integer
        Get
            Return _manometreNbNiveaux
        End Get
        Set(ByVal Value As Integer)
            _manometreNbNiveaux = Value
        End Set
    End Property
    <XmlElement("manometreNbtroncons")>
    Public Property manometreNbtronconsWS() As String
        Get
            Return manometreNbtroncons
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                manometreNbtroncons = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property manometreNbtroncons() As Integer
        Get
            Return _manometreNbTroncons
        End Get
        Set(ByVal Value As Integer)
            _manometreNbTroncons = Value
        End Set
    End Property

    Public Property regulation As String
        Get
            Return _Regulation
        End Get
        Set(value As String)
            _Regulation = value
        End Set
    End Property
    Public Property regulationOptions As String
        Get
            Return _RegulationOptions
        End Get
        Set(value As String)
            _RegulationOptions = value
        End Set
    End Property

    Public Property modeUtilisation As String
        Get
            Return _modeUtilisation
        End Get
        Set(value As String)
            _modeUtilisation = value
        End Set
    End Property
    Public Function isCoPropriete() As Boolean
        Return modeUtilisation = Pulverisateur.CO_PRORIETE
    End Function

    Public Property nombreExploitants As String
        Get
            Return _nombreExploitants
        End Get
        Set(value As String)
            _nombreExploitants = value
        End Set
    End Property
    Public Property isAspirationExt() As Boolean
        Get
            Return _aspirationExterieur
        End Get
        Set(ByVal Value As Boolean)
            _aspirationExterieur = Value
        End Set
    End Property
    ''' <summary>
    ''' Ce champs est supprime de l'interface, mais on le garde en objet car il va réapparaitre !!!!
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isDispoAntiRetour() As Boolean
        Get
            Return _dispositifAntiRetour
        End Get
        Set(ByVal Value As Boolean)
            _dispositifAntiRetour = Value
        End Set
    End Property
    Public Property isReglageAutoHauteur() As Boolean
        Get
            Return _reglageAutoHauteur
        End Get
        Set(ByVal Value As Boolean)
            _reglageAutoHauteur = Value
        End Set
    End Property
    Public Property isFiltrationAspiration() As Boolean
        Get
            Return _filtrationAspiration
        End Get
        Set(ByVal Value As Boolean)
            _filtrationAspiration = Value
        End Set
    End Property

    Public Property isFiltrationRefoulement() As Boolean
        Get
            Return _filtrationRefoulement
        End Get
        Set(ByVal Value As Boolean)
            _filtrationRefoulement = Value
        End Set
    End Property

    Public Property isFiltrationTroncons() As Boolean
        Get
            Return _filtrationTroncons
        End Get
        Set(ByVal Value As Boolean)
            _filtrationTroncons = Value
        End Set
    End Property
    Public Property isFiltrationBuses() As Boolean
        Get
            Return _filtrationBuses
        End Get
        Set(ByVal Value As Boolean)
            _filtrationBuses = Value
        End Set
    End Property

    Public Property isPulveAdditionnel() As Boolean
        Get
            Return _pulveAdditionnel
        End Get
        Set(ByVal Value As Boolean)
            _pulveAdditionnel = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property PulvePrincipalAdditionel() As String
        Get
            If isPulveAdditionnel Then
                Return "Addit."
            Else
                Return "Princ."
            End If
        End Get
        Set(ByVal Value As String)
        End Set
    End Property
    Public Property pulvePrincipalNumNat() As String
        Get
            Return _pulvePrincipalNumNat
        End Get
        Set(ByVal Value As String)
            _pulvePrincipalNumNat = Value
        End Set
    End Property
    Public Property isRincagecircuit() As Boolean
        Get
            Return _isRincagecircuit
        End Get
        Set(ByVal Value As Boolean)
            _isRincagecircuit = Value
        End Set
    End Property
    <XmlElement("nbPompesDoseuses")>
    Public Property nbPompesDoseusesWS() As String
        Get
            Return nbPompesDoseuses
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                nbPompesDoseuses = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property nbPompesDoseuses() As Integer
        Get
            Return _nbPompesDoseuses
        End Get
        Set(ByVal value As Integer)
            _nbPompesDoseuses = value
        End Set
    End Property

    Public Property isPompesDoseuses() As Boolean
        Get
            Return _isPompesDoseuses
        End Get
        Set(ByVal value As Boolean)
            _isPompesDoseuses = value
        End Set
    End Property

    Public Property numeroChassis() As String
        Get
            Return _numChassis
        End Get
        Set(ByVal value As String)
            _numChassis = value
        End Set
    End Property
    Private _immatCertificat As String
    Public Property immatCertificat() As String
        Get
            Return _immatCertificat
        End Get
        Set(ByVal value As String)
            _immatCertificat = value
        End Set
    End Property
    Private _immatPlaque As String
    Public Property immatPlaque() As String
        Get
            Return _immatPlaque
        End Get
        Set(ByVal value As String)
            _immatPlaque = value
        End Set
    End Property

    Public Function setLargeurNbreRangs(pstr As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim strTypeValeur As String
            strTypeValeur = MarquesManager.GetTypeValeur_Pulve(type, categorie)
            'pstr = pstr.Replace(".", ",")
            'Me.largeur = pstr
            'Me.nombreRangs = pstr
            Select Case strTypeValeur.ToUpper().Trim
                Case TYPEVALEURPULVE_LARGEUR.ToUpper.Trim()
                    Me.largeur = pstr
                    Me.nombreRangs = ""
                    bReturn = True
                Case TYPEVALEURPULVE_RANG.ToUpper.Trim()
                    Me.nombreRangs = pstr
                    Me.largeur = ""
                    bReturn = True
                Case Else
                    Me.largeur = pstr
                    Me.nombreRangs = ""
                    bReturn = False
            End Select
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.SetLargeurNbreRangs ERR" + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overrides Function Fill(pColName As String, pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            pColName = pColName.Replace("Pulverisateur.", "")
            bReturn = MyBase.Fill(pColName, pColValue)
            If Not bReturn Then
                bReturn = True
                Select Case pColName.ToUpper().Trim
                    Case "id".ToUpper().Trim()
                        Me.id = pColValue.ToString()
                    'Case "numeroNational".ToUpper().Trim()
                    '    Me.numeroNational = pColValue.ToString()
                    '    'Mémorisation du numéro nationnal
                    '    Me.numeroNationalBis = pColValue.ToString()
                    'Case "type".ToUpper().Trim()
                    '    Me.type = pColValue.ToString()
                    'Case "marque".ToUpper().Trim()
                    '    Me.marque = pColValue.ToString()
                    'Case "modele".ToUpper().Trim()
                    '    Me.modele = pColValue.ToString()
                    'Case "anneeAchat".ToUpper().Trim()
                    '    Me.anneeAchat = pColValue.ToString()
                    'Case "categorie".ToUpper().Trim()
                    '    Me.categorie = pColValue.ToString
                    'Case "attelage".ToUpper().Trim()
                    '    Me.attelage = pColValue.ToString()
                    'Case "pulverisation".ToUpper().Trim()
                    '    Me.pulverisation = pColValue.ToString
                    'Case "capacite".ToUpper().Trim()
                    '    Me.capacite = pColValue
                    'Case "largeur".ToUpper().Trim()
                    '    Me.largeur = pColValue.ToString()
                    'Case "nombreRangs".ToUpper().Trim()
                    '    Me.nombreRangs = pColValue.ToString()
                    'Case "largeurPlantation".ToUpper().Trim()
                    '    Me.largeurPlantation = pColValue.ToString()
                    'Case "surfaceParAn".ToUpper().Trim()
                    '    Me.surfaceParAn = pColValue.ToString()
                    'Case "nombreUtilisateurs".ToUpper().Trim()
                    '    Me.nombreUtilisateurs = pColValue.ToString()
                    'Case "isVentilateur".ToUpper().Trim()
                    '    Me.isVentilateur = pColValue
                    'Case "isDebrayage".ToUpper().Trim()
                    '    Me.isDebrayage = pColValue
                    'Case "isCuveRincage".ToUpper().Trim()
                    '    Me.isCuveRincage = pColValue
                    'Case "capaciteCuveRincage".ToUpper().Trim()
                    '    Me.capaciteCuveRincage = pColValue.ToString()
                    'Case "isRotobuse".ToUpper().Trim()
                    '    Me.isRotobuse = pColValue
                    'Case "isCuveIncorporation".ToUpper().Trim()
                    '    Me.isCuveIncorporation = pColValue
                    'Case "isRinceBidon".ToUpper().Trim()
                    '    Me.isRinceBidon = pColValue
                    'Case "isBidonLaveMain".ToUpper().Trim()
                    '    Me.isBidonLaveMain = pColValue
                    'Case "isLanceLavage".ToUpper().Trim()
                    '    Me.isLanceLavage = pColValue
                    'Case "regulation".ToUpper().Trim()
                    '    Me.regulation = pColValue.ToString
                    'Case "regulationOptions".ToUpper().Trim()
                    '    Me.regulationOptions = pColValue.ToString
                    'Case "nombreBuses".ToUpper().Trim()
                    '    Me.nombreBuses = pColValue
                    'Case "buseIsIso".ToUpper().Trim()
                    '    Me.buseIsIso = pColValue
                    'Case "buseMarque".ToUpper().Trim()
                    '    Me.buseMarque = pColValue.ToString()
                    'Case "buseType".ToUpper().Trim()
                    '    Me.buseType = pColValue.ToString()
                    'Case "buseFonctionnement".ToUpper().Trim()
                    '    Me.buseFonctionnement = pColValue.ToString()
                    'Case "buseAge".ToUpper().Trim()
                    '    Me.buseAge = pColValue.ToString()
                    'Case "buseAngle".ToUpper().Trim()
                    '    Me.buseAngle = pColValue.ToString()
                    'Case "buseCouleur".ToUpper().Trim()
                    '    Me.buseCouleur = pColValue.ToString()
                    'Case "manometreMarque".ToUpper().Trim()
                    '    Me.manometreMarque = pColValue.ToString()
                    'Case "manometreType".ToUpper().Trim()
                    '    Me.manometreType = pColValue.ToString()
                    'Case "manometreFondEchelle".ToUpper().Trim()
                    '    Me.manometreFondEchelle = pColValue.ToString()
                    'Case "manometreDiametre".ToUpper().Trim()
                    '    Me.manometreDiametre = pColValue.ToString()
                    'Case "manometrePressionTravail".ToUpper().Trim()
                    '    Me.manometrePressionTravail = pColValue.ToString()
                    'Case "isSynchro".ToUpper().Trim()
                    '    Me.isSynchro = pColValue
                    'Case "isSupprime".ToUpper().Trim()
                    '    Me.isSupprime = pColValue
                    Case "dateProchainControle".ToUpper().Trim()
                        If pColValue.ToString() <> "01/01/2001 00:00:00" And pColValue.ToString() <> "0000-00-00 00:00:00" Then
                            Me.dateProchainControle = CSDate.ToCRODIPString(pColValue.ToString())
                        End If
                    Case "idStructure".ToUpper().Trim()
                        Me.uidstructure = pColValue
                    'Case "emplacementIdentification".ToUpper().Trim()
                    '    Me.emplacementIdentification = pColValue
                    'Case "ancienIdentifiant".ToUpper().Trim()
                    '    Me.ancienIdentifiant = pColValue
                    ''Champs ajouter pour optimiser l'affichage
                    'Case "controleEtat".ToUpper().Trim()
                    '    Me.controleEtat = pColValue
                    Case "raisonSociale".ToUpper().Trim()
                        Me.RaisonSocialeExploitant = pColValue
                        ''Case "nomExploitant".ToUpper().Trim()
                        ''    Me.NomExploitant = pColValue
                        ''Case "prenomExploitant".ToUpper().Trim()
                        ''    Me.PrenomExploitant = pColValue
                        ''Case "codepostal".ToUpper().Trim()
                        ''    Me.codePostal = pColValue
                        ''Case "commune".ToUpper().Trim()
                        ''    Me.Commune = pColValue
                        ''Case "isEclairageRampe".ToUpper().Trim()
                        ''    Me.isEclairageRampe = pColValue
                        ''Case "isBarreGuidage".ToUpper().Trim()
                        ''    Me.isBarreGuidage = pColValue
                        ''Case "isCoupureAutoTroncons".ToUpper().Trim()
                        ''    Me.isCoupureAutoTroncons = pColValue
                        ''Case "isRincageAutoAssiste".ToUpper().Trim()
                        ''    Me.isRincageAutoAssiste = pColValue
                        ''Case "buseModele".ToUpper().Trim()
                        ''    Me.buseModele = pColValue.ToString()
                        ''Case "buseNbniveaux".ToUpper().Trim()
                        ''    Me.buseNbniveaux = pColValue
                        ''Case "manometreNbNiveaux".ToUpper().Trim()
                        ''    Me.manometreNbniveaux = pColValue
                        ''Case "manometreNbTroncons".ToUpper().Trim()
                        ''    Me.manometreNbtroncons = pColValue
                        ''Case "modeUtilisation".ToUpper().Trim()
                        ''    Me.modeUtilisation = pColValue
                        ''Case "nombreExploitants".ToUpper().Trim()
                        ''    Me.nombreExploitants = pColValue
                        ''Case "isAspirationExt".ToUpper().Trim()
                        ''    Me.isAspirationExt = pColValue
                        ''Case "isDispoAntiRetour".ToUpper().Trim()
                        ''    Me.isDispoAntiRetour = pColValue
                        ''Case "isReglageAutoHauteur".ToUpper().Trim()
                        ''    Me.isReglageAutoHauteur = pColValue
                        ''Case "isFiltrationAspiration".ToUpper().Trim()
                        ''    Me.isFiltrationAspiration = pColValue
                        ''Case "isFiltrationRefoulement".ToUpper().Trim()
                        ''    Me.isFiltrationRefoulement = pColValue
                        ''Case "isFiltrationTroncons".ToUpper().Trim()
                        ''    Me.isFiltrationTroncons = pColValue
                        ''Case "isFiltrationBuses".ToUpper().Trim()
                        ''    Me.isFiltrationBuses = pColValue
                        ''Case "isPulveAdditionnel".ToUpper().Trim()
                        ''    Me.isPulveAdditionnel = pColValue
                        ''Case "pulvePrincipalNumNat".ToUpper().Trim()
                        ''    Me.pulvePrincipalNumNat = pColValue
                        ''Case "isrincagecircuit".ToUpper().Trim()
                        ''    Me.isRincagecircuit = pColValue
                        ''Case "isPompesDoseuses".ToUpper().Trim()
                        ''    Me.isPompesDoseuses = pColValue
                        ''Case "nbPompesDoseuses".ToUpper().Trim()
                        ''    Me.nbPompesDoseuses = pColValue
                        ''Case "numeroChassis".ToUpper().Trim()
                        ''    Me.numeroChassis = pColValue
                        ''Case "immatCertificat".ToUpper().Trim()
                        ''    Me.immatCertificat = pColValue
                        ''Case "immatPlaque".ToUpper().Trim()
                        ''    Me.immatPlaque = pColValue
                        'Case "uid".Trim().ToUpper()
                        '    Me.uid = pColValue
                        'Case "uidstructure".Trim().ToUpper()
                        '    Me.uidstructure = pColValue
                    Case Else
                        bReturn = False
                End Select
            End If
            numeroNationalBis = numeroNational
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.Fill(" & pColName & "," & pColValue & ") ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Rend le paramètre du diagnostic associé au ParamDiagLibellé du pulvérisateur
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getParamDiag() As CRODIP_ControlLibrary.ParamDiag
        Dim oReturn As New CRODIP_ControlLibrary.ParamDiag()
        Try
            Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
            lst = CRODIP_ControlLibrary.ParamDiag.readXML()
            For Each oParam As CRODIP_ControlLibrary.ParamDiag In lst
                If Trim(oParam.libelle.ToUpper()).Equals(Trim(Me.type.ToUpper())) Then
                    oReturn = oParam
                    Exit For
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.getParamDiag()  Error :" & ex.Message)
            oReturn = Nothing
        End Try

        Return oReturn
    End Function
    ''' <summary>
    ''' Transfert d'un pulvérisateur d'une exploitation a une autre
    ''' </summary>
    ''' <param name="pExploitOrigineId"></param>
    ''' <param name="pExploitCibleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function TransfertPulve(pExploitOrigine As Exploitation, pExploitCible As Exploitation, pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = False
            Dim oExpl2Pulve As ExploitationTOPulverisateur
            oExpl2Pulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(pExploitOrigine.id, id)
            If Not String.IsNullOrEmpty(oExpl2Pulve.id) Then
                oExpl2Pulve.isSupprimeCoProp = True
                ExploitationTOPulverisateurManager.save(oExpl2Pulve, pAgent)
            End If
            oExpl2Pulve = New ExploitationTOPulverisateur()
            oExpl2Pulve.idExploitation = pExploitCible.id
            oExpl2Pulve.uidexploitation = pExploitCible.uid
            oExpl2Pulve.idPulverisateur = Me.id
            oExpl2Pulve.uidpulverisateur = Me.uid
            oExpl2Pulve.uidstructure = Me.uidstructure
            bReturn = ExploitationTOPulverisateurManager.save(oExpl2Pulve, pAgent)
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.TransfertPulve ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

    Public Function CheckParam(pPulve As Pulverisateur) As Boolean
        Dim bReturn As Boolean
        Dim oParamDiag As CRODIP_ControlLibrary.ParamDiag
        Try

            bReturn = True
            oParamDiag = getParamDiag()
            If String.IsNullOrEmpty(oParamDiag.fichierConfig) Then
                CSDebug.dispFatal("Impossible de trouver le fichier de configuration du controle pour le Pulve type = " & pPulve.type & ", categorie = " & pPulve.categorie)
                bReturn = False
            Else
                Dim sParamFile As String = GlobalsCRODIP.GLOB_PARAM_RepertoireParametres & "/" & oParamDiag.fichierConfig
                If Not System.IO.File.Exists(sParamFile) Then
                    CSDebug.dispFatal("le fichier de configuration du controle pour le Pulve type = " & pPulve.type & ", categorie = " & pPulve.categorie & " Fichier de config " & sParamFile & "n'existe pas")
                    bReturn = False
                Else
                    Dim olst As New CRODIP_ControlLibrary.LstParamCtrlDiag()
                    If Not olst.readXML(sParamFile) Then
                        CSDebug.dispFatal("le fichier de configuration " & sParamFile & " n'est pas correct")
                        bReturn = False
                    End If
                End If
            End If

        Catch ex As Exception
            CSDebug.dispFatal("Pulverisateur.CheckParam ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    ''' <summary>
    ''' Rend la date de dernier controle d'un pulvérisateur
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getDateDernierControle() As String

        Dim oReturn As Date
        oReturn = Date.MinValue
        If Not String.IsNullOrEmpty(id) Then
            Try
                'Lecture des Diagnostic d'un pulve triées par date de debut
                Dim olst As List(Of Diagnostic)
                olst = DiagnosticManager.getlstDiagnosticByPulveId(id)
                If olst.Count > 0 Then
                    oReturn = olst(0).controleDateFin
                End If

            Catch ex As Exception
                CSDebug.dispError("Pulverisateur.getdateDernierControle ERR : " & ex.Message)
            End Try
        End If
        'on retourne un date sous forme de chaine ou Vide
        If oReturn = Date.MinValue Then
            Return ""
        Else
            Return CSDate.ToCRODIPString(oReturn)
        End If

    End Function

    Public Enum CheckResult As Integer
        OK = 0
        NUMEROEXISTANT = 1
        NUMEROPASLEPREMIER = 2
        NUMEROPASDANSLALISTE = 3
        NUMEROFORMATINCORRECT = 4
        NUMEROPART1FORMATINCORRECT = 5
        NUMEROPASDANSLALISTEOTC = 6
    End Enum
    ''' <summary>
    ''' Check numéro national Pulvérisateur
    ''' </summary>
    ''' <param name="pNumNAtional">Numéro national à vérifier</param>
    ''' <param name="pAgent">Agent </param>
    ''' <param name="pbAjout">VRAI si on est en ajout de Pulvéridateur</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function CheckNumeroNational(pNumNatPart1 As String, pNumNatPart2 As String, pAgent As Agent, pbAjout As Boolean) As CheckResult
        Dim bReturn As CheckResult = CheckResult.OK
        Dim pNumNational As String = pNumNatPart1 & pNumNatPart2
        If Not checkPart1NumNat(pNumNatPart1) Then
            Return CheckResult.NUMEROPART1FORMATINCORRECT
        End If
        ' Lecture de la liste des identifiant dispo
        Dim olst As List(Of IdentifiantPulverisateur) = IdentifiantPulverisateurManager.getListeInutilise(pAgent)
        If pNumNatPart2.Length <> 6 Or Not IsNumeric(pNumNatPart2) Then
            bReturn = CheckResult.NUMEROFORMATINCORRECT
        End If
        If pNumNatPart1 = GlobalsCRODIP.GLOB_DIAG_NUMAGR Then
            If bReturn = CheckResult.OK And pbAjout Then
                'En mode ajout , on vérifie toujours l'existence
                If PulverisateurManager.getNbrePulverisateursParNumeroNational(pNumNational) > 0 Then
                    bReturn = CheckResult.NUMEROEXISTANT
                End If
            End If
            Dim bCheck As Boolean
            bCheck = True
            If Not pbAjout And Me.numeroNational = pNumNational Then
                'Si on n'est pas en ajout est qu'il n'y a pas eu de modif sur le numéro 
                ' => pas de controle par rapport aux Identifiants Pulvés
                bCheck = False
            End If
            If bReturn = CheckResult.OK Then
                If olst.Count > 0 And bCheck Then
                    'S'il y a des identifiant Pulvés
                    'Si on  test un numero CRODIP
                    If pNumNational <> olst(0).numeroNational Then
                        bReturn = CheckResult.NUMEROPASLEPREMIER
                    End If
                    Dim bDansLaListe As Boolean = False
                    For Each oIdent As IdentifiantPulverisateur In olst
                        If oIdent.numeroNational = pNumNational Then
                            bDansLaListe = True
                        End If
                    Next
                    If Not bDansLaListe Then
                        bReturn = CheckResult.NUMEROPASDANSLALISTE
                    End If
                End If
            End If
        Else
            'Pulve non indigo (E001)
            'il faut que le numéro existe dans la base OTC
            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
                Dim oPulverisateurOTC As PulverisateurOTC = PulverisateurManager.WSgetPulverisateurOTC(numeroNational, pAgent.uid)
                If oPulverisateurOTC Is Nothing Then
                    bReturn = CheckResult.NUMEROPASDANSLALISTEOTC
                End If
            End If
        End If
        Return bReturn
    End Function
    Private Function checkPart1NumNat(pNumNatPart1 As String) As Boolean
        Dim strValue As String
        Dim strC1 As String
        Dim strC2_4 As String
        Dim bOk As Boolean
        Dim strAlphabet As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

        strValue = pNumNatPart1
        bOk = True
        If strValue.Length <> 4 Then
            bOk = False
        End If
        If bOk Then
            strC1 = strValue(0)
            If Not strAlphabet.Contains(strC1.ToUpper()) Then
                bOk = False
            End If
        End If
        If bOk Then
            strC2_4 = strValue.Substring(1, 3)
            If Not IsNumeric(strC2_4) Then
                bOk = False
            End If
            If strC2_4.Contains(".") Or strC2_4.Contains(",") Then
                bOk = False
            End If
        End If
        Return bOk

    End Function


    ''' <summary>
    ''' Encodage Automatique des défauts 
    ''' </summary>
    ''' <returns>Liste des défauts à inclure dans le Controle</returns>
    ''' <remarks></remarks>
    Public Function EncodageAutomatiqueDefauts() As List(Of DiagnosticItem)
        Dim oReturn As New List(Of DiagnosticItem)
        Dim oDiagItem As DiagnosticItemAuto
        Dim oParamdiag As CRODIP_ControlLibrary.ParamDiag = getParamDiag()
        Dim sfichierConfig As String = oParamdiag.fichierConfig
        Dim olstParam As New CRODIP_ControlLibrary.LstParamCtrlDiag()


        Try
            olstParam.readXML(GlobalsCRODIP.GLOB_PARAM_RepertoireParametres & "/" & sfichierConfig)
            ' DEfauut Pneumatiques
            '-----------------
            oDiagItem = New DiagnosticItemAuto("", "251", "0", "", DiagnosticItem.EtatDiagItemOK)
            If attelage = Pulverisateur.ATTELAGE_PORTE Or isTypeFixeouSemisMobile() Then
                oDiagItem.FillWithParam(olstParam.Find("2.5.1.0"))
            End If
            oReturn.Add(oDiagItem)
            oDiagItem = New DiagnosticItemAuto("", "252", "0", "", DiagnosticItem.EtatDiagItemOK)
            If attelage = Pulverisateur.ATTELAGE_PORTE Or isTypeFixeouSemisMobile() Then
                oDiagItem.FillWithParam(olstParam.Find("2.5.2.0"))
            End If
            oReturn.Add(oDiagItem)
            'Defaut CultureBasse et Ventilateur => 10.1.1.0
            '--------------------
            oDiagItem = New DiagnosticItemAuto("", "1011", "0")
            oReturn.Add(oDiagItem)
            If type = Pulverisateur.TYPEPULVE_CULTURESBASSES And Not isVentilateur Then
                oDiagItem.FillWithParam(olstParam.Find("10.1.1.0"))
            End If

            'Defaut CultureBasse et Ventilateur => 10.1.2.0
            '--------------------
            oDiagItem = New DiagnosticItemAuto("", "1012", "0")
            oReturn.Add(oDiagItem)
            If type = Pulverisateur.TYPEPULVE_CULTURESBASSES And Not isVentilateur Then
                oDiagItem.FillWithParam(olstParam.Find("10.1.2.0"))
            End If

            'Defaut CultureBasse et Ventilateur => 10.2.1.0
            '--------------------
            oDiagItem = New DiagnosticItemAuto("", "1021", "0")
            oReturn.Add(oDiagItem)
            If type = Pulverisateur.TYPEPULVE_CULTURESBASSES And Not isVentilateur Then
                oDiagItem.FillWithParam(olstParam.Find("10.2.1.0"))
            End If

            'Defaut CultureBasse et Ventilateur => 10.2.2.0
            '--------------------
            oDiagItem = New DiagnosticItemAuto("", "1022", "0")
            oReturn.Add(oDiagItem)
            If type = Pulverisateur.TYPEPULVE_CULTURESBASSES And Not isVentilateur Then
                oDiagItem.FillWithParam(olstParam.Find("10.2.2.0"))
            End If
            'Pressionconstante() / DPM() / DPA() =>5.5.1.0
            '----------------------------------------------
            oDiagItem = New DiagnosticItemAuto("", "551", "0")
            oReturn.Add(oDiagItem)
            If pulverisateurRegulationIsPressionCONSTante() Or pulverisateurRegulationIsDPM() Or pulverisateurRegulationIsDPA() Then
                oDiagItem.FillWithParam(olstParam.Find("5.5.1.0"))
            End If
            'Pressionconstante() / DPM() / DPA() =>5.5.2.0
            '----------------------------------------------
            oDiagItem = New DiagnosticItemAuto("", "552", "0")
            oReturn.Add(oDiagItem)
            If pulverisateurRegulationIsPressionCONSTante() Or pulverisateurRegulationIsDPM() Or pulverisateurRegulationIsDPA() Then
                oDiagItem.FillWithParam(olstParam.Find("5.5.2.0"))
            End If
            'RegulationIsDPAE
            '----------------
            If Not pulverisateurRegulationIsDPMAssiste() Then
                oDiagItem = New DiagnosticItemAuto("", "562", "0")
                oReturn.Add(oDiagItem)
            End If
            If pulverisateurRegulationIsDPAE() Then
                oDiagItem.FillWithParam(olstParam.Find("5.6.2.0"))
            End If
            'Cuve incorporation
            '-------------------
            oDiagItem = New DiagnosticItemAuto("", "431", "3")
            oReturn.Add(oDiagItem)

            If Not isCuveIncorporation Then
                oDiagItem.FillWithParam(olstParam.Find("4.3.1.3"))
            End If
            'Cuve Rincage
            '-----------
            oDiagItem = New DiagnosticItemAuto("", "461", "1")
            oReturn.Add(oDiagItem)
            If Not isCuveRincage() Then
                oDiagItem.FillWithParam(olstParam.Find("4.6.1.1"))
            End If

            'RotoBuse
            '---------
            oDiagItem = New DiagnosticItemAuto("", "462", "1")
            oReturn.Add(oDiagItem)
            If Not isRotobuse() Then
                oDiagItem.FillWithParam(olstParam.Find("4.6.2.1"))
            End If
            'RinceBidon
            '------------
            oDiagItem = New DiagnosticItemAuto("", "432", "1")
            oReturn.Add(oDiagItem)
            If Not isRinceBidon() Then
                oDiagItem.FillWithParam(olstParam.Find("4.3.2.1"))
            End If
            'LanceLavage
            '---------------
            oDiagItem = New DiagnosticItemAuto("", "463", "1")
            oReturn.Add(oDiagItem)
            If Not isLanceLavage() Then
                oDiagItem.FillWithParam(olstParam.Find("4.6.3.1"))

            End If
            'Bidon Lave-Main
            '--------------
            oDiagItem = New DiagnosticItemAuto("", "1241", "1")
            oReturn.Add(oDiagItem)
            If Not isBidonLaveMain() Then
                oDiagItem.FillWithParam(olstParam.Find("12.4.1.1"))
            End If
            'FiltrationAspiration
            '----------------------
            oDiagItem = New DiagnosticItemAuto("", "711", "1")
            oReturn.Add(oDiagItem)
            If Not isFiltrationAspiration() Then
                oDiagItem.FillWithParam(olstParam.Find("7.1.1.1"))
            End If
            'FiltrationRefoulement
            '---------------------
            oDiagItem = New DiagnosticItemAuto("", "721", "1")
            oReturn.Add(oDiagItem)
            If Not isFiltrationRefoulement() Then
                oDiagItem.FillWithParam(olstParam.Find("7.2.1.1"))
            End If
            'FiltrationsTroncons
            '-------------------
            oDiagItem = New DiagnosticItemAuto("", "731", "1")
            oReturn.Add(oDiagItem)
            If Not isFiltrationTroncons() Then
                oDiagItem.FillWithParam(olstParam.Find("7.3.1.1"))
            End If
            'FiltrationBuses
            '--------------
            oDiagItem = New DiagnosticItemAuto("", "741", "1")
            oReturn.Add(oDiagItem)
            If Not isFiltrationBuses() Then
                oDiagItem.FillWithParam(olstParam.Find("7.4.1.1"))
            End If
            'RincageCircuit
            '--------------
            oDiagItem = New DiagnosticItemAuto("", "464", "1")
            oReturn.Add(oDiagItem)
            If Not isRincagecircuit Then
                oDiagItem.FillWithParam(olstParam.Find("4.6.4.1"))
            End If
            'Pompes Doseuses
            '--------------
            oDiagItem = New DiagnosticItemAuto("", "1211", "0")
            oReturn.Add(oDiagItem)
            If Not isPompesDoseuses Then
                oDiagItem.FillWithParam(olstParam.Find("12.1.1.0"))
            End If
            oDiagItem = New DiagnosticItemAuto("", "1212", "0")
            oReturn.Add(oDiagItem)
            If Not isPompesDoseuses Then
                oDiagItem.FillWithParam(olstParam.Find("12.1.2.0"))
            End If
            oDiagItem = New DiagnosticItemAuto("", "1213", "0")
            oReturn.Add(oDiagItem)
            If Not isPompesDoseuses Then
                oDiagItem.FillWithParam(olstParam.Find("12.1.3.0"))
            End If

        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.EncodageAutomatiqueDefauts ERR : " & ex.Message)
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Encodage Automatique des défauts 
    ''' </summary>
    ''' <returns>Liste des défauts à inclure dans le Controle</returns>
    ''' <remarks></remarks>
    Public Function DecodageAutomatiqueDefauts(pList As List(Of DiagnosticItem)) As Boolean
        Dim bReturn As Boolean
        Dim oDiagItem As DiagnosticItem


        isCuveIncorporation = True
        isCuveRincage = True
        isRotobuse = True
        isRinceBidon = True
        isLanceLavage = True
        isBidonLaveMain = True
        isFiltrationAspiration = True
        isFiltrationRefoulement = True
        isFiltrationTroncons = True
        isFiltrationBuses = True
        isRincagecircuit = True

        Try
            For Each oDiagItem In pList
                If oDiagItem.idItem = "431" And oDiagItem.itemValue = "3" Then
                    isCuveIncorporation = False
                End If
                If oDiagItem.idItem = "461" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isCuveRincage = False
                End If
                If oDiagItem.idItem = "462" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isRotobuse = False
                End If
                If oDiagItem.idItem = "432" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isRinceBidon = False
                End If
                If oDiagItem.idItem = "463" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isLanceLavage = False
                End If
                If oDiagItem.idItem = "1241" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isBidonLaveMain = False
                End If
                If oDiagItem.idItem = "711" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isFiltrationAspiration = False
                End If
                If oDiagItem.idItem = "721" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isFiltrationRefoulement = False
                End If
                If oDiagItem.idItem = "731" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isFiltrationTroncons = False
                End If
                If oDiagItem.idItem = "741" And oDiagItem.itemValue = "1" And oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemABSENCE Then
                    isFiltrationBuses = False
                End If
                If oDiagItem.idItem = "464" And oDiagItem.itemValue = "1" Then
                    isRincagecircuit = False
                End If
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.DecodageAutomatiqueDefauts ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'DecodageAutomatiqueDefaut
    Public Function pulverisateurRegulationIsPressionCONSTante() As Boolean
        Return regulation.Trim().ToLower() = "Pression CONSTante".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPM() As Boolean
        Return regulation.Trim().ToLower() = "DPM".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPA() As Boolean
        Return regulation.Trim().ToLower() = "DPA".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPAE() As Boolean
        Return regulation.Trim().ToLower().StartsWith("DPAE".Trim().ToLower())
    End Function
    Public Function pulverisateurRegulationIsDPAESeul() As Boolean
        Dim bReturn As Boolean
        bReturn = pulverisateurRegulationIsDPAE()
        If bReturn Then
            bReturn = Not (pulverisateurRegulationIsDPAEDebit() Or pulverisateurRegulationIsDPAEPression())
        End If
        Return bReturn
    End Function
    Public Function pulverisateurRegulationIsDPAEComplet() As Boolean
        Dim bReturn As Boolean
        bReturn = pulverisateurRegulationIsDPAEDebit() And pulverisateurRegulationIsDPAEPression()
        Return bReturn
    End Function
    Public Function pulverisateurRegulationIsDPAEDebit() As Boolean
        Dim bReturn As Boolean
        bReturn = pulverisateurRegulationIsDPAE()
        If bReturn Then
            bReturn = regulationOptions.Contains("Débit")
        End If
        Return bReturn
    End Function
    Public Function pulverisateurRegulationIsDPAEPression() As Boolean
        Dim bReturn As Boolean
        bReturn = pulverisateurRegulationIsDPAE()
        If bReturn Then
            bReturn = regulationOptions.Contains("Pression")
        End If
        Return bReturn
    End Function
    Public Function pulverisateurRegulationIsDPMAssiste() As Boolean
        Return regulation.Trim().ToLower().StartsWith("DPM ASSISTE".Trim().ToLower())
    End Function

    Public Function SetControleEtat(pdiagnostic As Diagnostic) As Boolean
        Dim bReturn As Boolean

        Try
            'Si le controle est le dernier en date
            Dim dateDernierControlePulve As Date
            If Me.getDateDernierControle() = "" Then
                dateDernierControlePulve = Date.MinValue
            Else
                dateDernierControlePulve = Me.getDateDernierControle()
            End If
            If pdiagnostic.controleDateFin > dateDernierControlePulve Then
                Select Case controleEtat
                    Case Pulverisateur.controleEtatNOKCC
                        'Si le pulve était en att de Controle complet
                        'il y reste sauf pour un controle OK
                        Select Case pdiagnostic.controleEtat
                            Case Diagnostic.controleEtatOK
                                controleEtat = Pulverisateur.controleEtatOK
                            Case Diagnostic.controleEtatNOKCV
                            Case Diagnostic.controleEtatNOKCC
                            Case Else
                        End Select
                    Case Else

                        Select Case pdiagnostic.controleEtat
                            Case Diagnostic.controleEtatOK
                                controleEtat = Pulverisateur.controleEtatOK
                            Case Diagnostic.controleEtatNOKCV
                                controleEtat = Pulverisateur.controleEtatNOKCV
                            Case Diagnostic.controleEtatNOKCC
                                controleEtat = Pulverisateur.controleEtatNOKCC
                            Case Else
                                controleEtat = Pulverisateur.controleEtatOK
                        End Select
                End Select
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.setControleEtat ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Rend Vrai si le pulvé est de categorie 'traitement des semences"
    ''' </summary>
    ''' <param name="pTrt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isTRTSPE(pTrt As String) As Boolean
        'Parcours du fichier config pour remplir une Liste des types-categories
        Dim bReturn As Boolean
        Dim xpath As String
        bReturn = False
        xpath = MarquesManager.XPATH_VALEURS_TRTSPE.Replace("%type%", type).Replace("%categorie%", categorie)
        Dim oNodesTrtSpe As Xml.XmlNodeList = GlobalsCRODIP.GLOB_XML_TYPES_CATEGORIES_PULVE.getXmlNodes(xpath)
        For Each oAttCategorie As Xml.XmlNode In oNodesTrtSpe
            If oAttCategorie.InnerText = pTrt Then
                bReturn = True
            End If
        Next
        Return bReturn
    End Function
    Public Function isTraitementdesSemences() As Boolean
        Return isTRTSPE("TRTSEM")
    End Function

    Public Shared Function getNiveauAlerte(Optional pDate As Date? = Nothing) As NiveauAlerte
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE

        If pDate Is Nothing Then
            pDate = DateTime.Now
        End If

        Dim lstNiveauAlerte As List(Of NiveauAlerte)
        lstNiveauAlerte = Alertes.readXML().NiveauxAlertes
        Dim oNiveau As NiveauAlerte = Nothing
        Try

            oNiveau = lstNiveauAlerte.Where(Function(m) m.Materiel = NiveauAlerte.Enum_typeMateriel.Pulverisateur) _
                                .Where(Function(m) m.DateEffet <= pDate) _
                                .OrderByDescending(Function(m) m.DateEffet).First()

        Catch ex As Exception

        End Try

        If oNiveau Is Nothing Then
            oNiveau = New NiveauAlerte()
            oNiveau.Rouge = 4
            oNiveau.Jaune = 60
        End If
        Return oNiveau
    End Function
    Public Sub SetPulverisateurAdditionnel(pPulvePrinc As Pulverisateur)
        Me.isPulveAdditionnel = True
        Me.pulvePrincipalNumNat = pPulvePrinc.numeroNational
        Me.numeroNationalBis = ""
        Me.numeroNational = pPulvePrinc.numeroNational.Substring(0, 4)
        Me.marque = ""
        Me.modele = ""
        Me.numeroChassis = ""
        Me.anneeAchat = ""
        Me.emplacementIdentification = ""
        Me.type = ""
        Me.categorie = ""
        Me.LargeurNombreRangs = ""
        Me.buseMarque = ""
        Me.buseType = ""
        Me.buseFonctionnement = ""
        Me.buseModele = ""
        Me.buseAngle = ""
        Me.buseNbniveaux = 0
        Me.nombreBuses = 0
        Me.buseIsIso = False
        Me.buseCouleur = ""
        Me.buseAge = ""
        Me.ancienIdentifiant = ""
        Me.pulverisation = ""
        Me.buseType = ""

        'N° Chasssis, Année, Type , niveau tronçons Mano Modifiat , Fitration Tronons et buses Modificables pulveridation Modificable
    End Sub

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As Pulverisateur

        Try


            ' Create a memory stream and a formatter.
            Dim ms As New System.IO.MemoryStream(1000)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing,
                New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone))
            ' Serialize the object into the stream.
            bf.Serialize(ms, Me)
            ' Position streem pointer back to first byte.
            ms.Seek(0, System.IO.SeekOrigin.Begin)
            ' Deserialize into another object.
            oReturn = bf.Deserialize(ms)
            ' release memory.
            ms.Close()
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn

    End Function
    Private _bisCompareOTC As Boolean
    Public Property isCompareOTC() As Boolean
        Get
            Return _bisCompareOTC
        End Get
        Set(ByVal value As Boolean)
            _bisCompareOTC = value
        End Set
    End Property
    Private Function AjouteAnomalieOTC(pCritere As String, pValeurAgent As String, pValeurOTC As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oAnomalie As New Anomalie
            oAnomalie.critere = pCritere
            oAnomalie.valeurAgent = pValeurAgent
            oAnomalie.valeurOTC = pValeurOTC
            _lstAnnomalie.Add(oAnomalie)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.AjouteAnnomalieOTC ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    <XmlIgnore()>
    Public ReadOnly Property lstAnomalie() As List(Of Anomalie)
        Get
            Return _lstAnnomalie
        End Get
    End Property
    Public Function CompareOTC(puidAgent As Integer) As Boolean
        Dim bReturn As Boolean = True
        Try
            Dim oPulveOTC As PulverisateurOTC
            lstAnomalie.Clear()
            oPulveOTC = PulverisateurManager.WSgetPulverisateurOTC(Me.numeroNational, puidAgent)
            If oPulveOTC IsNot Nothing Then
                If Me.anneeAchat <> oPulveOTC.Année Then
                    AjouteAnomalieOTC("Année", Me.anneeAchat, oPulveOTC.Année)
                    bReturn = False
                End If
                If Me.attelage <> oPulveOTC.Attelage Then
                    AjouteAnomalieOTC("Attelage", Me.attelage, oPulveOTC.Attelage)
                    bReturn = False
                End If
                If Me.categorie <> oPulveOTC.Catégorie Then
                    AjouteAnomalieOTC("Categorie", Me.categorie, oPulveOTC.Catégorie)
                    bReturn = False
                End If
                If Me.pulverisation <> oPulveOTC.Fonctionnement Then
                    AjouteAnomalieOTC("Pulverisation", Me.pulverisation, oPulveOTC.Fonctionnement)
                    bReturn = False
                End If
                If Me.marque <> oPulveOTC.Marque Then
                    AjouteAnomalieOTC("Marque", Me.marque, oPulveOTC.Marque)
                    bReturn = False
                End If
                If Me.type <> oPulveOTC.Type Then
                    AjouteAnomalieOTC("Type", Me.type, oPulveOTC.Type)
                    bReturn = False
                End If
                If Me.capacite <> oPulveOTC.Volume Then
                    AjouteAnomalieOTC("Volume", Me.capacite, oPulveOTC.Volume)
                    bReturn = False
                End If
                If Me.largeur <> oPulveOTC.Largeur Then
                    AjouteAnomalieOTC("Largeur", Me.largeur, oPulveOTC.Largeur)
                    bReturn = False
                End If

            End If

        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.CompareOTC ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function setValeursOTC() As Boolean
        Dim breturn As Boolean
        Try
            For Each oAno As Anomalie In lstAnomalie
                If oAno.bvaleurOTCOK Then
                    Select Case oAno.critere
                        Case "Année"
                            Me.anneeAchat = oAno.valeurOTC
                        Case "Attelage"
                            Me.attelage = oAno.valeurOTC
                        Case "Categorie"
                            Me.categorie = oAno.valeurOTC
                        Case "Pulverisation"
                            Me.pulverisation = oAno.valeurOTC
                        Case "Marque"
                            Me.marque = oAno.valeurOTC
                        Case "Type"
                            Me.type = oAno.valeurOTC
                        Case "Volume"
                            Me.capacite = oAno.valeurOTC

                        Case "Largeur"
                            Me.largeur = oAno.valeurOTC

                    End Select
                End If
            Next
            isCompareOTC = True
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("Pulverisateur.setValeursOTC ERR", ex)
            breturn = False
        End Try
        Return breturn
    End Function
    Private _isConfirmeIdentifiant As Boolean
    Public Property isConfirmeIdentifiant() As Boolean
        Get
            Return _isConfirmeIdentifiant
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeIdentifiant = value
        End Set
    End Property
    Private _isConfirmeMarque As Boolean
    Public Property isConfirmeMarque() As Boolean
        Get
            Return _isConfirmeMarque
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeMarque = value
        End Set
    End Property
    Private _isConfirmeModele As Boolean
    Public Property isConfirmeModele() As Boolean
        Get
            Return _isConfirmeModele
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeModele = value
        End Set
    End Property
    Private _isConfirmeAnneeConstruction As Boolean
    Public Property isConfirmeAnneeConstruction() As Boolean
        Get
            Return _isConfirmeAnneeConstruction
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeAnneeConstruction = value
        End Set
    End Property
    Private _isConfirmeVolume As Boolean
    Public Property isConfirmeVolume() As Boolean
        Get
            Return _isConfirmeVolume
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeVolume = value
        End Set
    End Property
    Private _isConfirmeLargeur As Boolean
    Public Property isConfirmeLargeur() As Boolean
        Get
            Return _isConfirmeLargeur
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeLargeur = value
        End Set
    End Property
    Private _isConfirmeCategorie As Boolean
    Public Property isConfirmeCategorie() As Boolean
        Get
            Return _isConfirmeCategorie
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeCategorie = value
        End Set
    End Property
    Private _isConfirmeType As Boolean
    Public Property isConfirmeType() As Boolean
        Get
            Return _isConfirmeType
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeType = value
        End Set
    End Property
    Private _isConfirmeFonctionnement As Boolean
    Public Property isConfirmeFonctionnement() As Boolean
        Get
            Return _isConfirmeFonctionnement
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeFonctionnement = value
        End Set
    End Property
    Private _isConfirmeRegulation As Boolean
    Public Property isConfirmeRegulation() As Boolean
        Get
            Return _isConfirmeRegulation
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeRegulation = value
        End Set
    End Property
    Private _isConfirmeAttelage As Boolean
    Public Property isConfirmeAttelage() As Boolean
        Get
            Return _isConfirmeAttelage
        End Get
        Set(ByVal value As Boolean)
            _isConfirmeAttelage = value
        End Set
    End Property
    Private _isAnomalies As Boolean
    Public Property isAnomalies() As Boolean
        Get
            Return _isAnomalies
        End Get
        Set(ByVal value As Boolean)
            _isAnomalies = value
        End Set
    End Property
    Private _niveauAnomalies As Integer
    Public Property niveauAnomalies() As Integer
        Get
            Return _niveauAnomalies
        End Get
        Set(ByVal value As Integer)
            _niveauAnomalies = value
        End Set
    End Property
    Private _nombreAnomalies As Integer
    Public Property nombreAnomalies() As Integer
        Get
            Return _nombreAnomalies
        End Get
        Set(ByVal value As Integer)
            _nombreAnomalies = value
        End Set
    End Property
    Private _nombreMineures As Integer
    Public Property nombreMineures() As Integer
        Get
            Return _nombreMineures
        End Get
        Set(ByVal value As Integer)
            _nombreMineures = value
        End Set
    End Property
    Private _dateModificationAnomalies As DateTime
    <XmlIgnoreAttribute()>
    Public Property dateModificationAnomalies() As Date
        Get
            Return _dateModificationAnomalies
        End Get
        Set(ByVal Value As Date)
            _dateModificationAnomalies = Value
        End Set
    End Property
    <XmlElement("dateModificationAnomalies")>
    Private _dateModificationAnomaliesS As String
    Public Property dateModificationAomaliesS() As String
        Get
            If dateModificationAgent <> Date.MinValue Then
                Return CSDate.GetDateForWS(dateModificationAnomalies)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                Try
                    dateModificationAnomalies = CSDate.FromCrodipString(Value)
                Catch
                End Try
            End If
        End Set
    End Property
    Private _isPulveRecordedInOTC As Boolean
    Public Property isPulveRecordedInOTC() As Boolean
        Get
            Return _isPulveRecordedInOTC
        End Get
        Set(ByVal value As Boolean)
            _isPulveRecordedInOTC = value
        End Set
    End Property
    Private _isPulveDownloadByExportOTC As Boolean
    Public Property isPulveDownloadByExportOTC() As Boolean
        Get
            Return _isPulveDownloadByExportOTC
        End Get
        Set(ByVal value As Boolean)
            _isPulveDownloadByExportOTC = value
        End Set
    End Property
    Private _isPulveDownloadByCheckKeyOTC As Boolean
    Public Property isPulveDownloadByCheckKeyOTC() As Boolean
        Get
            Return _isPulveDownloadByCheckKeyOTC
        End Get
        Set(ByVal value As Boolean)
            _isPulveDownloadByCheckKeyOTC = value
        End Set
    End Property

End Class