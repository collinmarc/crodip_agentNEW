Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports Ionic.Zip

<Serializable(), XmlInclude(GetType(Diagnostic)), XmlInclude(GetType(DiagnosticItemsList)), XmlInclude(GetType(DiagnosticItem))> _
Public Class Diagnostic
    Implements ICloneable
    Private _id As String = ""
    Private _organismePresId As Integer
    Private _organismePresNumero As String = ""
    Private _organismePresNom As String = ""
    Private _organismePresAdresse As String = ""
    Private _organismePresCodePostal As String = ""
    Private _organismePresCommune As String = ""
    Private _organismeInspNom As String = ""
    Private _organismeInspAgrement As String = ""
    Private _inspecteurId As Integer
    Private _inspecteurNumeroNat As String
    Private _inspecteurNom As String = ""
    Private _inspecteurPrenom As String = ""
    Private _organismeOriginePresId As Integer
    Private _organismeOriginePresNumero As String = ""
    Private _organismeOriginePresNom As String = ""
    Private _organismeOrigineInspNom As String = ""
    Private _organismeOrigineInspAgrement As String = ""
    Private _inspecteurOrigineId As Integer
    Private _inspecteurOrigineNom As String = ""
    Private _inspecteurOriginePrenom As String = ""

    Private _controleDateDebut As String = ""
    Private _controleDateFin As String = ""
    Private _controleCommune As String = ""
    Private _controleCodePostal As String = ""
    Private _controleLieu As String = ""
    Private _controleTerritoire As String = ""
    Private _controleSite As String = ""
    Private _controleNomSite As String = ""
    Private _controleIsComplet As Boolean
    Private _controleIsPremierControle As Boolean
    Private _controleDateDernierControle As String = ""
    Private _controleIsSiteSecurise As Boolean
    Private _controleIsRecupResidus As Boolean
    Private _controleEtat As String = ""
    Private _controleInfosConseils As String = ""
    Private _controleTarif As String = ""
    Private _controleIsPulveRepare As Boolean
    Private _controleIsPreControleProfessionel As Boolean
    Private _controleIsAutoControle As Boolean

    Private _proprietaireId As String = ""
    Private _proprietaireRaisonSociale As String = ""
    Private _proprietairePrenom As String = ""
    Private _proprietaireNom As String = ""
    Private _proprietaireCodeApe As String = ""
    Private _proprietaireNumeroSiren As String = ""
    Private _proprietaireCommune As String = ""
    Private _proprietaireCodePostal As String = ""
    Private _proprietaireAdresse As String = ""
    Private _proprietaireEmail As String = ""
    Private _proprietaireTelephonePortable As String = ""
    Private _proprietaireTelephoneFixe As String = ""
    Private _ProprietaireRepresentant As String = ""
    Private _codeInsee As String = ""

    Private _pulverisateurId As String = ""
    Private _pulverisateurNumNational As String = ""
    Private _pulverisateurMarque As String = ""
    Private _pulverisateurModele As String = ""
    Private _pulverisateurType As String = ""
    Private _pulverisateurCapacite As String = ""
    Private _pulverisateurLargeur As String = ""
    Private _pulverisateurNbRangs As String = ""
    Private _pulverisateurLargeurPlantation As String = ""
    Private _pulverisateurIsVentilateur As Boolean
    Private _pulverisateurIsDebrayage As Boolean
    Private _pulverisateurAnneeAchat As String = ""
    Private _pulverisateurSurface As String = ""
    Private _pulverisateurNbUtilisateurs As String = ""
    Private _pulverisateurIsCuveRincage As Boolean
    Private _pulverisateurCapaciteCuveRincage As String = ""
    Private _pulverisateurIsRotobuse As Boolean
    Private _pulverisateurIsRinceBidon As Boolean
    Private _pulverisateurIsBidonLaveMain As Boolean
    Private _pulverisateurIsLanceLavageExterieur As Boolean
    Private _pulverisateurIsCuveIncorporation As Boolean
    Private _pulverisateurCategorie As String
    Private _pulverisateurAttelage As String = ""
    Private _pulverisateurPulverisation As String = ""
    Private _pulverisateurAutresAccessoires As String = ""
    Private _pulverisateurEmplacementIdentification As String = ""
    Private _pulverisateurDateProchainControle As String = ""
    Private _pulverisateurControleEtat As String = ""
    Private _pulverisateurCoupureAutoTroncons As String = ""
    Private _pulverisateurReglageAutoHauteur As String = ""
    Private _pulverisateurRincagecircuit As String = ""
    Private _pulverisateur As Pulverisateur 'Reference sur le Pulve (non exportées ni sauvegardée)
    Private _pulverisateurNumChassis As String = ""


    Private _buseMarque As String = ""
    Private _buseModele As String = ""
    Private _buseCouleur As String = ""
    Private _buseGenre As String = ""
    Private _buseCalibre As String = ""
    Private _buseDebit As String = ""
    Private _buseDebit2bars As String = ""
    Private _buseDebit3bars As String = ""
    Private _buseAge As String = ""
    Private _buseNbBuses As String = ""
    Private _buseType As String = ""
    Private _buseAngle As String = ""
    Private _buseFonctionnementIsStandard As Boolean
    Private _buseFonctionnementIsPastilleChambre As Boolean
    Private _buseFonctionnementIsInjectionAirLibre As Boolean
    Private _buseFonctionnementIsInjectionAirForce As Boolean
    Private _buseFonctionnement As String = ""
    Private _buseIsISO As Boolean
    Private _manometreMarque As String = ""
    Private _manometreDiametre As String = ""
    Private _manometreType As String = ""
    Private _manometreFondEchelle As String = ""
    Private _manometrePressionTravail As String = ""
    Private _exploitationTypeCultureIsGrandeCulture As Boolean
    Private _exploitationTypeCultureIsLegume As Boolean
    Private _exploitationTypeCultureIsElevage As Boolean
    Private _exploitationTypeCultureIsArboriculture As Boolean
    Private _exploitationTypeCultureIsViticulture As Boolean
    Private _exploitationTypeCultureIsAutres As Boolean
    Private _exploitationSau As String = ""
    Private _dateModificationAgent As String = ""
    Private _dateModificationCrodip As String = ""
    Private _dateSynchro As String = ""
    Private _isSynchro As Boolean
    Private _isATGIP As Boolean
    Private _isTGIP As Boolean
    Private _isFacture As Boolean
    Private _syntheseErreurMoyenneMano As String = ""
    Private _syntheseErreurMaxiMano As String = ""
    Private _syntheseErreurDebitmetre As String = ""
    Private _syntheseErreurMoyenneCinemometre As String = ""
    Private _syntheseUsureMoyenneBuses As String = ""
    Private _syntheseNbBusesUsees As String = ""
    Private _synthesePerteChargeMoyenne As String = ""
    Private _synthesePerteChargeMaxi As String = ""
    Private _diagnosticItemLst As DiagnosticItemsList
    Private _diagnosticBuses As DiagnosticBusesList
    Private _nbreLotsBuses As Integer
    Protected m_diagnosticMano542List As DiagnosticMano542List
    Protected m_diagnosticTroncons833 As DiagnosticTroncons833List
    Private _BancControleID As String
    Protected m_controleUseCalibrateur As Boolean 'Utilisation du calibrateur Oui/non
    Protected m_controleNbreNiveaux As Integer 'Nbre de Niveaux dans Mano/troncons
    Protected m_controleNbreTroncons As Integer 'Nbre de tronçons
    Private _controleManoControleNumNational As String 'Numéro national du mano de controle
    Protected m_diagnostichelp551 As DiagnosticHelp551
    Private _diagnostichelp5621 As DiagnosticHelp5621
    Protected m_diagnostichelp552 As DiagnosticHelp552
    Private _diagnostichelp5622 As DiagnosticHelp5622
    Private _diagnostichelp811 As DiagnosticHelp811
    Private _diagnostichelp8314 As DiagnosticHelp831
    Private _diagnostichelp8312 As DiagnosticHelp831
    Private _diagnostichelp571 As DiagnosticHelp571
    Private _diagnostichelp12123 As DiagnosticHelp12123
    Private _diagnostichelp12323 As DiagnosticHelp551
    'Attributs pour le rapport de synthese
    Protected m_relevePression833_1 As RelevePression833
    Protected m_relevePression833_2 As RelevePression833
    Protected m_relevePression833_3 As RelevePression833
    Protected m_relevePression833_4 As RelevePression833
    Protected m_SyntheseImprecision542 As String
    Private _ControleInitialId As String
    Private _PulverisateurAncienId As String

    Private _diagnosticInfosComplementaire As DiagnosticInfosComplementaires
    Private _TotalHT As Decimal
    Private _TotalTVA As Decimal
    Private _TotalTTC As Decimal
    Private _RIFileName As String = ""
    Private _SMFileName As String = ""
    Private _CCFileName As String = ""
    Private _PulverisateurRegulation As String = ""
    Private _PulverisateurRegulationOptions As String = ""
    Private _PulverisateurModeUtilisation As String = ""
    Private _PulverisateurNbreExploitants As String = ""
    Private _Commentaire As String

    Private _isContreVisiteImmediate As Boolean
    Private _typeDiagnostic As String

    Protected m_buseDebitMoyenPM As Decimal 'utilisé pour le Reglage Pulve

    Private _ParamDiag As CRODIP_ControlLibrary.ParamDiag

    Public Sub New()
        controleIsPulveRepare = False
        controleIsPreControleProfessionel = False
        controleIsAutoControle = False
        organismeOriginePresId = 0
        organismeOriginePresNumero = ""
        organismeOriginePresNom = ""
        organismeOrigineInspNom = ""
        organismeOrigineInspAgrement = ""
        inspecteurOrigineId = 0
        inspecteurOrigineNom = ""
        inspecteurOriginePrenom = ""
        organismePresId = 0
        organismePresNumero = ""
        organismePresNom = ""
        organismeInspNom = ""
        organismeInspAgrement = ""
        inspecteurId = 0
        inspecteurNom = ""
        inspecteurPrenom = ""
        _BancControleID = ""
        controleNbreNiveaux = 0
        controleNbreTroncons = 0
        controleUseCalibrateur = False
        controleManoControleNumNational = ""

        _diagnosticItemLst = New DiagnosticItemsList()
        _diagnosticBuses = New DiagnosticBusesList()
        m_diagnosticMano542List = New DiagnosticMano542List()
        m_diagnosticTroncons833 = New DiagnosticTroncons833List()

        m_diagnostichelp551 = New DiagnosticHelp551(Crodip_agent.DiagnosticHelp551.Help551Mode.Mode551)
        _diagnostichelp12323 = New DiagnosticHelp551(Crodip_agent.DiagnosticHelp551.Help551Mode.Mode12323)
        _diagnostichelp5621 = New DiagnosticHelp5621
        m_diagnostichelp552 = New DiagnosticHelp552
        _diagnostichelp5622 = New DiagnosticHelp5622
        _diagnostichelp811 = New DiagnosticHelp811
        _diagnostichelp8312 = New DiagnosticHelp831(DiagnosticHelp831.ModeHelp831.Mode8312)
        _diagnostichelp8314 = New DiagnosticHelp831(DiagnosticHelp831.ModeHelp831.Mode8314)
        _diagnostichelp571 = New DiagnosticHelp571
        _diagnostichelp12123 = New DiagnosticHelp12123
        _diagnostichelp12323 = New DiagnosticHelp551(Crodip_agent.DiagnosticHelp551.Help551Mode.Mode12323)
        _diagnosticInfosComplementaire = New DiagnosticInfosComplementaires

        controleLieu = ""
        controleTerritoire = ""
        controleSite = ""
        controleNomSite = ""
        controleIsComplet = True
        controleIsPremierControle = False
        controleDateDernierControle = ""
        controleIsSiteSecurise = False
        controleIsRecupResidus = False
        controleEtat = ""
        controleInfosConseils = ""
        controleTarif = ""

        dateSynchro = ""
        isSynchro = False
        isATGIP = False
        isTGIP = False
        isFacture = False
        dateModificationAgent = CSDate.mysql2access(Date.Now)
        controleInitialId = ""

        Me.buseGenre = ""
        Me.buseCalibre = ""
        Me.buseDebit = ""
        Me.buseDebit2bars = ""
        Me.buseDebit3bars = ""
        _isContreVisiteImmediate = False
        manometrePressionTravailD = 3

        controleIsComplet = True
        controleDateDebut = CSDate.mysql2access(Date.Now)
        controleDateFin = CSDate.mysql2access(Date.Now)
        controleIsPremierControle = True
        controleDateDernierControle = ""
        typeDiagnostic = "pulverisateur"
        RIFileName = ""
        CCFileName = ""
        SMFileName = ""
        m_buseDebitMoyenPM = 0

        diagRemplacementId = ""
        isSupprime = False
    End Sub

    Public Sub New(ByVal pAgent As Agent, ByVal pPulve As Pulverisateur, ByVal pClient As Exploitation)
        MyClass.New()
        setOrganisme(pAgent)
        setPulverisateur(pPulve)
        SetProprietaire(pClient)
        controleIsComplet = True
        controleDateDebut = CSDate.mysql2access(Date.Now)
        controleDateFin = CSDate.mysql2access(Date.Now)
    End Sub

    ''' <summary>
    ''' Retourne un clone de l'objet courant
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As Diagnostic

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
            CSDebug.dispError("Diagnostic.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

#Region "Properties"

    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property

    Public Property organismePresId() As Integer
        Get
            Return _organismePresId
        End Get
        Set(ByVal Value As Integer)
            _organismePresId = Value
        End Set
    End Property

    Public Property organismePresNumero() As String
        Get
            Return _organismePresNumero
        End Get
        Set(ByVal Value As String)
            _organismePresNumero = Value
        End Set
    End Property

    Public Property organismePresNom() As String
        Get
            Return _organismePresNom
        End Get
        Set(ByVal Value As String)
            _organismePresNom = Value
        End Set
    End Property
    ''' <summary>
    ''' Adresse de l'organisme
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <XmlIgnoreAttribute()>
    Public Property organismePresAdresse() As String
        Get
            Return _organismePresAdresse
        End Get
        Set(ByVal Value As String)
            _organismePresAdresse = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property organismePresCodePostal() As String
        Get
            Return _organismePresCodePostal
        End Get
        Set(ByVal Value As String)
            _organismePresCodePostal = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property organismePresCommune() As String
        Get
            Return _organismePresCommune
        End Get
        Set(ByVal Value As String)
            _organismePresCommune = Value
        End Set
    End Property
    Public Property organismeInspNom() As String
        Get
            Return _organismeInspNom
        End Get
        Set(ByVal Value As String)
            _organismeInspNom = Value
        End Set
    End Property

    Public Property organismeInspAgrement() As String
        Get
            Return _organismeInspAgrement
        End Get
        Set(ByVal Value As String)
            _organismeInspAgrement = Value
        End Set
    End Property

    Public Property inspecteurId() As Integer
        Get
            Return _inspecteurId
        End Get
        Set(ByVal Value As Integer)
            _inspecteurId = Value
        End Set
    End Property
    Public Property inspecteurNumeroNational() As String
        Get
            Return _inspecteurNumeroNat
        End Get
        Set(ByVal Value As String)
            _inspecteurNumeroNat = Value
        End Set
    End Property

    Public Property inspecteurNom() As String
        Get
            Return _inspecteurNom
        End Get
        Set(ByVal Value As String)
            _inspecteurNom = Value
        End Set
    End Property

    Public Property inspecteurPrenom() As String
        Get
            Return _inspecteurPrenom
        End Get
        Set(ByVal Value As String)
            _inspecteurPrenom = Value
        End Set
    End Property

    ''===== Organisme de controle d'origine
    Public Property organismeOriginePresId() As Integer
        Get
            Return _organismeOriginePresId
        End Get
        Set(ByVal Value As Integer)
            _organismeOriginePresId = Value
        End Set
    End Property

    Public Property organismeOriginePresNumero() As String
        Get
            Return _organismeOriginePresNumero
        End Get
        Set(ByVal Value As String)
            _organismeOriginePresNumero = Value
        End Set
    End Property

    Public Property organismeOriginePresNom() As String
        Get
            Return _organismeOriginePresNom
        End Get
        Set(ByVal Value As String)
            _organismeOriginePresNom = Value
        End Set
    End Property

    Public Property organismeOrigineInspNom() As String
        Get
            Return _organismeOrigineInspNom
        End Get
        Set(ByVal Value As String)
            _organismeOrigineInspNom = Value
        End Set
    End Property

    Public Property organismeOrigineInspAgrement() As String
        Get
            Return _organismeOrigineInspAgrement
        End Get
        Set(ByVal Value As String)
            _organismeOrigineInspAgrement = Value
        End Set
    End Property

    Public Property inspecteurOrigineId() As Integer
        Get
            Return _inspecteurOrigineId
        End Get
        Set(ByVal Value As Integer)
            _inspecteurOrigineId = Value
        End Set
    End Property

    Public Property inspecteurOrigineNom() As String
        Get
            Return _inspecteurOrigineNom
        End Get
        Set(ByVal Value As String)
            _inspecteurOrigineNom = Value
        End Set
    End Property

    Public Property inspecteurOriginePrenom() As String
        Get
            Return _inspecteurOriginePrenom
        End Get
        Set(ByVal Value As String)
            _inspecteurOriginePrenom = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property controleDateDebut() As String
        Get
            Return _controleDateDebut
        End Get
        Set(ByVal Value As String)
            _controleDateDebut = Value
        End Set
    End Property
    <XmlElement("controleDateDebut")>
    Public Property controleDateDebutS() As String
        Get
            Return CSDate.GetDateForWS(_controleDateDebut)
        End Get
        Set(ByVal Value As String)
            _controleDateDebut = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property controleDateFin() As String
        Get
            Return _controleDateFin
        End Get
        Set(ByVal Value As String)
            _controleDateFin = Value
        End Set
    End Property
    <XmlElement("controleDateFin")>
    Public Property controleDateFinS() As String
        Get
            Return CSDate.GetDateForWS(_controleDateFin)
        End Get
        Set(ByVal Value As String)
            _controleDateFin = Value
        End Set
    End Property

    Public Function getDateDernierControleDate() As Date
        Dim dReturn As Date
        Try
            Return CDate(_controleDateDernierControle)
        Catch ex As Exception
            Return New Date()
        End Try
        Return dReturn
    End Function

    <XmlIgnoreAttribute()>
    Public Property controleDateDernierControle() As String
        Get
            Return _controleDateDernierControle
        End Get
        Set(ByVal Value As String)
            _controleDateDernierControle = Value
        End Set
    End Property
    <XmlElement("controleDateDernierControle")>
    Public Property controleDateDernierControleS() As String
        Get
            Return CSDate.GetDateForWS(_controleDateDernierControle)
        End Get
        Set(ByVal Value As String)
            _controleDateDernierControle = Value
        End Set
    End Property
    Public Property controleCommune() As String
        Get
            Return _controleCommune
        End Get
        Set(ByVal Value As String)
            _controleCommune = Value
        End Set
    End Property

    Public Property controleCodePostal() As String
        Get
            Return _controleCodePostal
        End Get
        Set(ByVal Value As String)
            _controleCodePostal = Value
        End Set
    End Property

    Public Property controleLieu() As String
        Get
            Return _controleLieu
        End Get
        Set(ByVal Value As String)
            _controleLieu = Value
        End Set
    End Property

    Public Property controleTerritoire() As String
        Get
            Return _controleTerritoire
        End Get
        Set(ByVal Value As String)
            _controleTerritoire = Value
        End Set
    End Property

    Public Property controleSite() As String
        Get
            Return _controleSite
        End Get
        Set(ByVal Value As String)
            _controleSite = Value
        End Set
    End Property

    Public Property controleNomSite() As String
        Get
            Return _controleNomSite
        End Get
        Set(ByVal Value As String)
            _controleNomSite = Value
        End Set
    End Property

    Public Property controleIsComplet() As Boolean
        Get
            Return _controleIsComplet
        End Get
        Set(ByVal Value As Boolean)
            _controleIsComplet = Value
        End Set
    End Property

    Public Property controleIsPremierControle() As Boolean
        Get
            Return _controleIsPremierControle
        End Get
        Set(ByVal Value As Boolean)
            _controleIsPremierControle = Value
        End Set
    End Property


    Public Property controleIsSiteSecurise() As Boolean
        Get
            Return _controleIsSiteSecurise
        End Get
        Set(ByVal Value As Boolean)
            _controleIsSiteSecurise = Value
        End Set
    End Property

    Public Property controleIsRecupResidus() As Boolean
        Get
            Return _controleIsRecupResidus
        End Get
        Set(ByVal Value As Boolean)
            _controleIsRecupResidus = Value
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
    Public Property controleEtat() As String
        Get
            Return _controleEtat
        End Get
        Set(ByVal Value As String)
            If (Value <> _controleEtat) Then
                _controleEtat = Value
                CalculDateProchainControle()
            End If
        End Set
    End Property
    <XmlIgnore>
    Public ReadOnly Property controleEtatLibelle() As String
        Get
            Dim bReturn As String = ""

            If isSupprime Then
                bReturn = "Rmpl(" & diagRemplacementId & ")"
            Else
                Select Case controleEtat
                    Case controleEtatOK
                        bReturn = "OK"
                    Case controleEtatNOKCV
                        bReturn = "CV"
                    Case controleEtatNOKCC
                        bReturn = "NOK"
                End Select
            End If
            Return bReturn
        End Get
    End Property

    Public Property controleInfosConseils() As String
        Get
            Return _controleInfosConseils
        End Get
        Set(ByVal Value As String)
            _controleInfosConseils = Value
        End Set
    End Property

    Public Property controleTarif() As String
        Get
            Return _controleTarif
        End Get
        Set(ByVal Value As String)
            _controleTarif = Value
        End Set
    End Property

    Public Property controleIsPulveRepare() As Boolean
        Get
            Return _controleIsPulveRepare
        End Get
        Set(ByVal Value As Boolean)
            _controleIsPulveRepare = Value
        End Set
    End Property

    Public Property controleIsPreControleProfessionel() As Boolean
        Get
            Return _controleIsPreControleProfessionel
        End Get
        Set(ByVal Value As Boolean)
            _controleIsPreControleProfessionel = Value
        End Set
    End Property
    Public Property controleIsAutoControle() As Boolean
        Get
            Return _controleIsAutoControle
        End Get
        Set(ByVal Value As Boolean)
            _controleIsAutoControle = Value
        End Set
    End Property
    Public Property proprietaireId() As String
        Get
            Return _proprietaireId
        End Get
        Set(ByVal Value As String)
            _proprietaireId = Value
        End Set
    End Property

    Public Property proprietaireRaisonSociale() As String
        Get
            Return _proprietaireRaisonSociale
        End Get
        Set(ByVal Value As String)
            _proprietaireRaisonSociale = Value
        End Set
    End Property

    ''' <summary>
    ''' Nom et prenom du représenant du propriétaire
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property proprietaireRepresentant() As String
        Get
            Return _ProprietaireRepresentant

        End Get
        Set(ByVal Value As String)
            _ProprietaireRepresentant = Value
        End Set
    End Property
    Public Property proprietairePrenom() As String
        Get
            Return _proprietairePrenom
        End Get
        Set(ByVal Value As String)
            _proprietairePrenom = Value
        End Set
    End Property

    Public Property proprietaireNom() As String
        Get
            Return _proprietaireNom
        End Get
        Set(ByVal Value As String)
            _proprietaireNom = Value
        End Set
    End Property

    Public Property proprietaireCodeApe() As String
        Get
            Return _proprietaireCodeApe
        End Get
        Set(ByVal Value As String)
            _proprietaireCodeApe = Value
        End Set
    End Property

    Public Property proprietaireNumeroSiren() As String
        Get
            Return _proprietaireNumeroSiren
        End Get
        Set(ByVal Value As String)
            _proprietaireNumeroSiren = Value
        End Set
    End Property

    Public Property proprietaireCommune() As String
        Get
            Return _proprietaireCommune
        End Get
        Set(ByVal Value As String)
            _proprietaireCommune = Value
        End Set
    End Property

    Public Property proprietaireCodePostal() As String
        Get
            Return _proprietaireCodePostal
        End Get
        Set(ByVal Value As String)
            _proprietaireCodePostal = Value
        End Set
    End Property

    Public Property proprietaireAdresse() As String
        Get
            Return _proprietaireAdresse
        End Get
        Set(ByVal Value As String)
            _proprietaireAdresse = Value
        End Set
    End Property

    Public Property proprietaireEmail() As String
        Get
            Return _proprietaireEmail
        End Get
        Set(ByVal Value As String)
            _proprietaireEmail = Value
        End Set
    End Property

    Public Property proprietaireTelephonePortable() As String
        Get
            Return _proprietaireTelephonePortable
        End Get
        Set(ByVal Value As String)
            _proprietaireTelephonePortable = Value
        End Set
    End Property

    Public Property proprietaireTelephoneFixe() As String
        Get
            Return _proprietaireTelephoneFixe
        End Get
        Set(ByVal Value As String)
            _proprietaireTelephoneFixe = Value
        End Set
    End Property

    Public Property pulverisateurId() As String
        Get
            Return _pulverisateurId
        End Get
        Set(ByVal Value As String)
            _pulverisateurId = Value
        End Set
    End Property
    Public Property pulverisateurAncienId() As String
        Get
            Return _PulverisateurAncienId
        End Get
        Set(ByVal Value As String)
            _PulverisateurAncienId = Value
        End Set
    End Property
    Public Property pulverisateurNumNational() As String
        Get
            Return _pulverisateurNumNational
        End Get
        Set(ByVal Value As String)
            _pulverisateurNumNational = Value
        End Set
    End Property
    Public Property pulverisateurNumChassis() As String
        Get
            Return _pulverisateurNumChassis
        End Get
        Set(ByVal Value As String)
            _pulverisateurNumChassis = Value
        End Set
    End Property

    Public Property pulverisateurMarque() As String
        Get
            Return _pulverisateurMarque
        End Get
        Set(ByVal Value As String)
            _pulverisateurMarque = Value
        End Set
    End Property

    Public Property pulverisateurModele() As String
        Get
            Return _pulverisateurModele
        End Get
        Set(ByVal Value As String)
            _pulverisateurModele = Value
        End Set
    End Property

    Public Property pulverisateurType() As String
        Get
            Return _pulverisateurType
        End Get
        Set(ByVal Value As String)
            _pulverisateurType = Value
        End Set
    End Property

    Public Property pulverisateurCapacite() As String
        Get
            Return _pulverisateurCapacite
        End Get
        Set(ByVal Value As String)
            _pulverisateurCapacite = Value
        End Set
    End Property

    Public Property pulverisateurLargeur() As String
        Get
            Return _pulverisateurLargeur
        End Get
        Set(ByVal Value As String)
            _pulverisateurLargeur = Value
        End Set
    End Property

    Public Property pulverisateurNbRangs() As String
        Get
            Return _pulverisateurNbRangs
        End Get
        Set(ByVal Value As String)
            _pulverisateurNbRangs = Value
        End Set
    End Property

    Public Property pulverisateurLargeurPlantation() As String
        Get
            Return _pulverisateurLargeurPlantation
        End Get
        Set(ByVal Value As String)
            _pulverisateurLargeurPlantation = Value
        End Set
    End Property

    Public Property pulverisateurIsVentilateur() As Boolean
        Get
            Return _pulverisateurIsVentilateur
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsVentilateur = Value
        End Set
    End Property

    Public Property pulverisateurIsDebrayage() As Boolean
        Get
            Return _pulverisateurIsDebrayage
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsDebrayage = Value
        End Set
    End Property

    Public Property pulverisateurAnneeAchat() As String
        Get
            Return _pulverisateurAnneeAchat
        End Get
        Set(ByVal Value As String)
            _pulverisateurAnneeAchat = Value
        End Set
    End Property

    Public Property pulverisateurSurface() As String
        Get
            Return _pulverisateurSurface
        End Get
        Set(ByVal Value As String)
            _pulverisateurSurface = Value
        End Set
    End Property

    Public Property pulverisateurNbUtilisateurs() As String
        Get
            Return _pulverisateurNbUtilisateurs
        End Get
        Set(ByVal Value As String)
            _pulverisateurNbUtilisateurs = Value
        End Set
    End Property

    Public Property pulverisateurIsCuveRincage() As Boolean
        Get
            Return _pulverisateurIsCuveRincage
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsCuveRincage = Value
        End Set
    End Property

    Public Property pulverisateurCapaciteCuveRincage() As String
        Get
            Return _pulverisateurCapaciteCuveRincage
        End Get
        Set(ByVal Value As String)
            _pulverisateurCapaciteCuveRincage = Value
        End Set
    End Property

    Public Property pulverisateurIsRotobuse() As Boolean
        Get
            Return _pulverisateurIsRotobuse
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsRotobuse = Value
        End Set
    End Property

    Public Property pulverisateurIsRinceBidon() As Boolean
        Get
            Return _pulverisateurIsRinceBidon
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsRinceBidon = Value
        End Set
    End Property

    Public Property pulverisateurIsBidonLaveMain() As Boolean
        Get
            Return _pulverisateurIsBidonLaveMain
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsBidonLaveMain = Value
        End Set
    End Property

    Public Property pulverisateurIsLanceLavageExterieur() As Boolean
        Get
            Return _pulverisateurIsLanceLavageExterieur
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsLanceLavageExterieur = Value
        End Set
    End Property

    Public Property pulverisateurIsCuveIncorporation() As Boolean
        Get
            Return _pulverisateurIsCuveIncorporation
        End Get
        Set(ByVal Value As Boolean)
            _pulverisateurIsCuveIncorporation = Value
        End Set
    End Property

    Public Property pulverisateurCategorie() As String
        Get
            Return _pulverisateurCategorie
        End Get
        Set(ByVal Value As String)
            _pulverisateurCategorie = Value
        End Set
    End Property

    Public Property pulverisateurAttelage() As String
        Get
            Return _pulverisateurAttelage
        End Get
        Set(ByVal Value As String)
            _pulverisateurAttelage = Value
        End Set
    End Property


    Public Property pulverisateurPulverisation() As String
        Get
            Return _pulverisateurPulverisation
        End Get
        Set(ByVal Value As String)
            _pulverisateurPulverisation = Value
        End Set
    End Property



    Public Property pulverisateurAutresAccessoires() As String
        Get
            Return _pulverisateurAutresAccessoires
        End Get
        Set(ByVal Value As String)
            _pulverisateurAutresAccessoires = Value
        End Set
    End Property

    Public Property pulverisateurEmplacementIdentification() As String
        Get
            Return _pulverisateurEmplacementIdentification
        End Get
        Set(ByVal Value As String)
            _pulverisateurEmplacementIdentification = Value
        End Set
    End Property
    ''' <summary>
    ''' Date initial de prochain controle pour le pulvérisateur
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Ce champs n'est pas stocké,ni synchronisé car il ne sert que lors de la création du Diag </remarks>
    <XmlIgnoreAttribute()>
    Public Property pulverisateurDateProchainControle() As String
        Get
            Return _pulverisateurDateProchainControle
        End Get
        Set(ByVal Value As String)
            _pulverisateurDateProchainControle = Value
        End Set
    End Property
    ''' <summary>
    ''' Etat initial du pulverrisateur au début du controle
    '''  1 = PULVE EN BON ETAT
    '''  0 = DEFAUT SUR PULVE
    '''  Rien = pas de controle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Ce champs n'est pas stocké,ni synchronisé car il ne sert que lors de la création du Diag </remarks>
    <XmlIgnoreAttribute()>
    Public Property pulverisateurControleEtat() As String
        Get
            Return _pulverisateurControleEtat
        End Get
        Set(ByVal Value As String)
            _pulverisateurControleEtat = Value
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
    Public Property buseCouleur() As String
        Get
            Return _buseCouleur
        End Get
        Set(ByVal Value As String)
            _buseCouleur = Value
        End Set
    End Property

    Public Property buseGenre() As String
        Get
            Return _buseGenre
        End Get
        Set(ByVal Value As String)
            _buseGenre = Value
        End Set
    End Property

    Public Property buseCalibre() As String
        Get
            Return _buseCalibre
        End Get
        Set(ByVal Value As String)
            _buseCalibre = Value
        End Set
    End Property

    Public Property buseDebit() As String
        Get
            Return _buseDebit
        End Get
        Set(ByVal Value As String)
            _buseDebit = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property buseDebitD() As String
        Get
            Try
                Return CDec(_buseDebit)
            Catch ex As Exception
                Return 0D
            End Try
            Return _buseDebit
        End Get
        Set(ByVal Value As String)
        End Set
    End Property
    Public Property buseDebit2bars() As String
        Get
            Return _buseDebit2bars
        End Get
        Set(ByVal Value As String)
            _buseDebit2bars = Value
        End Set
    End Property

    Public Property buseDebit3bars() As String
        Get
            Return _buseDebit3bars
        End Get
        Set(ByVal Value As String)
            _buseDebit3bars = Value
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

    Public Property buseNbBuses() As String
        Get
            Return _buseNbBuses
        End Get
        Set(ByVal Value As String)
            _buseNbBuses = Value
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

    Public Property buseAngle() As String
        Get
            Return _buseAngle
        End Get
        Set(ByVal Value As String)
            _buseAngle = Value
        End Set
    End Property

    'Public Property buseFonctionnementIsStandard() As Boolean
    '    Get
    '        Return _buseFonctionnementIsStandard
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _buseFonctionnementIsStandard = Value
    '        '' MAJ du libellé du fonctionnement di besoin (pour assurer la compat avec ancienne version"
    '        If (Value) And String.IsNullOrEmpty(_buseFonctionnement) Then
    '            _buseFonctionnement = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=1]/text")(0).InnerText
    '        End If
    '    End Set
    'End Property

    'Public Property buseFonctionnementIsPastilleChambre() As Boolean
    '    Get
    '        Return _buseFonctionnementIsPastilleChambre
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _buseFonctionnementIsPastilleChambre = Value
    '        '' MAJ du libellé du fonctionnement di besoin (pour assurer la compat avec ancienne version"
    '        If (Value) And String.IsNullOrEmpty(_buseFonctionnement) Then
    '            _buseFonctionnement = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=2]/text")(0).InnerText
    '        End If
    '    End Set
    'End Property

    'Public Property buseFonctionnementIsInjectionAirLibre() As Boolean
    '    Get
    '        Return _buseFonctionnementIsInjectionAirLibre
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _buseFonctionnementIsInjectionAirLibre = Value
    '        '' MAJ du libellé du fonctionnement di besoin (pour assurer la compat avec ancienne version"
    '        If (Value) And String.IsNullOrEmpty(_buseFonctionnement) Then
    '            _buseFonctionnement = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=3]/text")(0).InnerText
    '        End If
    '    End Set
    'End Property

    'Public Property buseFonctionnementIsInjectionAirForce() As Boolean
    '    Get
    '        Return _buseFonctionnementIsInjectionAirForce
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _buseFonctionnementIsInjectionAirForce = Value
    '        '' MAJ du libellé du fonctionnement di besoin (pour assurer la compat avec ancienne version"
    '        If (Value) And String.IsNullOrEmpty(_buseFonctionnement) Then
    '            _buseFonctionnement = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=4]/text")(0).InnerText
    '        End If
    '    End Set
    'End Property
    'Public Function getbuseFonctionnement() As String
    '    Return _buseFonctionnement
    'End Function
    'Private Function setbuseFonctionnement(pValue As String) As String
    '    _buseFonctionnement = pValue
    'End Function
    Public Property buseFonctionnement As String
        Get
            Return _buseFonctionnement
        End Get
        Set(value As String)
            _buseFonctionnement = value
        End Set
    End Property
    ''' <summary>
    ''' Mise à jour des booléens de fonctionnement des buses
    ''' </summary>
    ''' <remarks></remarks>
    'Private Sub setBooleensFonctionnement()
    '    Me.buseFonctionnementIsStandard = False
    '    Me.buseFonctionnementIsPastilleChambre = False
    '    Me.buseFonctionnementIsInjectionAirLibre = False
    '    Me.buseFonctionnementIsInjectionAirForce = False

    '    Dim sStandard As String = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=1]/text")(0).InnerText
    '    Dim sPastille As String = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=2]/text")(0).InnerText
    '    Dim sAirLibre As String = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=3]/text")(0).InnerText
    '    Dim sAirForce As String = Globals.GLOB_XML_FONCTIONNEMENTBUSES_BUSES.getXmlNodes("//type/fonctionnement/item[id=4]/text")(0).InnerText
    '    Select Case _buseFonctionnement.ToUpper.Trim()
    '        Case sStandard.ToUpper.Trim()
    '            Me.buseFonctionnementIsStandard = True
    '        Case sPastille.ToUpper.Trim()
    '            Me.buseFonctionnementIsPastilleChambre = True
    '        Case sAirLibre.ToUpper.Trim()
    '            Me.buseFonctionnementIsInjectionAirLibre = True
    '        Case sAirForce.ToUpper.Trim()
    '            Me.buseFonctionnementIsInjectionAirForce = True
    '    End Select

    'End Sub
    Public Property buseIsISO() As Boolean
        Get
            Return _buseIsISO
        End Get
        Set(ByVal Value As Boolean)
            _buseIsISO = Value
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

    Public Property manometreDiametre() As String
        Get
            Return _manometreDiametre
        End Get
        Set(ByVal Value As String)
            _manometreDiametre = Value
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
    ''' <summary>
    ''' La Pression de travail est la Pression de controle des Buses
    ''' Elle est initalisée à 3 Lors de la création d'un Diag
    ''' on l'apelle aussi Pression de Mesure
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property manometrePressionTravail() As String
        Get
            Return _manometrePressionTravail
        End Get
        Set(ByVal Value As String)
            _manometrePressionTravail = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property manometrePressionTravailD() As Decimal
        Get
            Try
                Return CDec(_manometrePressionTravail)
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _manometrePressionTravail = Value.ToString()
        End Set
    End Property
    Public Property exploitationTypeCultureIsGrandeCulture() As Boolean
        Get
            Return _exploitationTypeCultureIsGrandeCulture
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsGrandeCulture = Value
        End Set
    End Property

    Public Property exploitationTypeCultureIsLegume() As Boolean
        Get
            Return _exploitationTypeCultureIsLegume
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsLegume = Value
        End Set
    End Property

    Public Property exploitationTypeCultureIsElevage() As Boolean
        Get
            Return _exploitationTypeCultureIsElevage
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsElevage = Value
        End Set
    End Property

    Public Property exploitationTypeCultureIsArboriculture() As Boolean
        Get
            Return _exploitationTypeCultureIsArboriculture
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsArboriculture = Value
        End Set
    End Property

    Public Property exploitationTypeCultureIsViticulture() As Boolean
        Get
            Return _exploitationTypeCultureIsViticulture
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsViticulture = Value
        End Set
    End Property

    Public Property exploitationTypeCultureIsAutres() As Boolean
        Get
            Return _exploitationTypeCultureIsAutres
        End Get
        Set(ByVal Value As Boolean)
            _exploitationTypeCultureIsAutres = Value
        End Set
    End Property

    Public Property exploitationSau() As String
        Get
            Return _exploitationSau
        End Get
        Set(ByVal Value As String)
            _exploitationSau = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateSynchro() As String
        Get
            Return _dateSynchro
        End Get
        Set(ByVal Value As String)
            _dateSynchro = Value
        End Set
    End Property
    <XmlElement("dateSynchro")>
    Public Property dateSynchroS() As String
        Get
            Return CSDate.GetDateForWS(_dateSynchro)
        End Get
        Set(ByVal Value As String)
            _dateSynchro = Value
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

    Public Property isATGIP() As Boolean
        Get
            Return _isATGIP
        End Get
        Set(ByVal Value As Boolean)
            _isATGIP = Value
        End Set
    End Property

    Public Property isTGIP() As Boolean
        Get
            Return _isTGIP
        End Get
        Set(ByVal Value As Boolean)
            _isTGIP = Value
        End Set
    End Property

    Public Property isFacture() As Boolean
        Get
            Return _isFacture
        End Get
        Set(ByVal Value As Boolean)
            _isFacture = Value
        End Set
    End Property

    Public Property syntheseErreurMoyenneMano() As String
        Get
            Return _syntheseErreurMoyenneMano
        End Get
        Set(ByVal Value As String)
            _syntheseErreurMoyenneMano = Value
        End Set
    End Property

    Public Property syntheseErreurMaxiMano() As String
        Get
            Return _syntheseErreurMaxiMano
        End Get
        Set(ByVal Value As String)
            _syntheseErreurMaxiMano = Value
        End Set
    End Property

    Public Property syntheseErreurDebitmetre() As String
        Get
            Return _syntheseErreurDebitmetre
        End Get
        Set(ByVal Value As String)
            If IsNumeric(Value) Then
                _syntheseErreurDebitmetre = Value
            End If
        End Set
    End Property

    Public Property syntheseErreurMoyenneCinemometre() As String
        Get
            Return _syntheseErreurMoyenneCinemometre
        End Get
        Set(ByVal Value As String)
            _syntheseErreurMoyenneCinemometre = Value
        End Set
    End Property

    Public Property syntheseUsureMoyenneBuses() As String
        Get
            Return _syntheseUsureMoyenneBuses
        End Get
        Set(ByVal Value As String)
            _syntheseUsureMoyenneBuses = Value
        End Set
    End Property

    Public Property syntheseNbBusesUsees() As String
        Get
            Return _syntheseNbBusesUsees
        End Get
        Set(ByVal Value As String)
            _syntheseNbBusesUsees = Value
        End Set
    End Property

    Public Property synthesePerteChargeMoyenne() As String
        Get
            Return _synthesePerteChargeMoyenne
        End Get
        Set(ByVal Value As String)
            _synthesePerteChargeMoyenne = Value
        End Set
    End Property

    Public Property synthesePerteChargeMaxi() As String
        Get
            Return _synthesePerteChargeMaxi
        End Get
        Set(ByVal Value As String)
            _synthesePerteChargeMaxi = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property syntheseErreurMoyenneManoD As Decimal
        Get
            Try

                Return _syntheseErreurMoyenneMano
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _syntheseErreurMoyenneMano = Value.ToString()
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property syntheseErreurMaxiManoD As Decimal
        Get
            Try
                Return _syntheseErreurMaxiMano
            Catch ex As Exception
                Return 0D
            End Try

        End Get
        Set(ByVal Value As Decimal)
            _syntheseErreurMaxiMano = Value.ToString()
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property syntheseErreurDebitmetreD As Decimal
        Get
            Try

                Return _syntheseErreurDebitmetre
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            If IsNumeric(Value) Then
                _syntheseErreurDebitmetre = Value.ToString()
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property syntheseErreurMoyenneCinemometreD As Decimal
        Get
            Try
                Return _syntheseErreurMoyenneCinemometre
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _syntheseErreurMoyenneCinemometre = Value.ToString()
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property syntheseUsureMoyenneBusesD As Decimal
        Get
            Try

                Return _syntheseUsureMoyenneBuses
            Catch ex As Exception
                Return 0D
            End Try

        End Get
        Set(ByVal Value As Decimal)
            _syntheseUsureMoyenneBuses = Value.ToString()
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property syntheseNbBusesUseesD As Decimal
        Get
            Try

                Return _syntheseNbBusesUsees
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _syntheseNbBusesUsees = Value.ToString()
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property synthesePerteChargeMoyenneD As Decimal
        Get
            Try

                Return _synthesePerteChargeMoyenne
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _synthesePerteChargeMoyenne = Value.ToString()
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property synthesePerteChargeMaxiD As Decimal
        Get
            Try
                Return _synthesePerteChargeMaxi
            Catch ex As Exception
                Return 0D
            End Try
        End Get
        Set(ByVal Value As Decimal)
            _synthesePerteChargeMaxi = Value.ToString()
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property syntheseImprecision542 As String
        Get

            Return m_SyntheseImprecision542
        End Get
        Set(ByVal Value As String)
            m_SyntheseImprecision542 = Value
        End Set
    End Property
    ''' <summary>
    ''' Liste des DiagItems
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>il faut garder cette propriété serializable car elle est utilisé par la methode de clone</remarks>
    Public Property diagnosticItemsLst() As DiagnosticItemsList
        Get
            Return _diagnosticItemLst
        End Get
        Set(ByVal Value As DiagnosticItemsList)
            _diagnosticItemLst = Value
        End Set
    End Property

    Public Property diagnosticBusesList() As DiagnosticBusesList
        Get
            Return _diagnosticBuses
        End Get
        Set(ByVal Value As DiagnosticBusesList)
            _diagnosticBuses = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property NbreLotsBuses() As Integer
        Get
            Return _nbreLotsBuses
        End Get
        Set(ByVal Value As Integer)
            _nbreLotsBuses = Value
        End Set
    End Property
    Public Property diagnosticMano542List() As DiagnosticMano542List
        Get
            Return m_diagnosticMano542List
        End Get
        Set(ByVal Value As DiagnosticMano542List)
            m_diagnosticMano542List = Value
        End Set
    End Property
    Public Property diagnosticTroncons833() As DiagnosticTroncons833List
        Get
            Return m_diagnosticTroncons833
        End Get
        Set(ByVal Value As DiagnosticTroncons833List)
            m_diagnosticTroncons833 = Value
        End Set
    End Property

    Public Property controleBancMesureId() As String
        Get
            Return _BancControleID
        End Get
        Set(ByVal Value As String)
            _BancControleID = Value
        End Set
    End Property

    Public Property controleNbreNiveaux() As Integer
        Get
            Return m_controleNbreNiveaux
        End Get
        Set(ByVal Value As Integer)
            m_controleNbreNiveaux = Value
        End Set
    End Property
    Public Property controleNbreTroncons() As Integer
        Get
            Return m_controleNbreTroncons
        End Get
        Set(ByVal Value As Integer)
            m_controleNbreTroncons = Value
        End Set
    End Property
    Public Property controleUseCalibrateur() As Boolean
        Get
            Return m_controleUseCalibrateur
        End Get
        Set(ByVal Value As Boolean)
            m_controleUseCalibrateur = Value
        End Set
    End Property
    ''' <summary>
    ''' Mano de controle utilisé pour ce diagnostique
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property controleManoControleNumNational() As String
        Get
            Return _controleManoControleNumNational
        End Get
        Set(ByVal Value As String)
            _controleManoControleNumNational = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp551() As DiagnosticHelp551
        Get
            Return m_diagnostichelp551
        End Get
        Set(ByVal Value As DiagnosticHelp551)
            m_diagnostichelp551 = Value
        End Set
    End Property
    Public Function diagnosticHelp551AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = m_diagnostichelp551.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp12323() As DiagnosticHelp551
        Get
            Return _diagnostichelp12323
        End Get
        Set(ByVal Value As DiagnosticHelp551)
            _diagnostichelp12323 = Value
        End Set
    End Property
    Public Function diagnosticHelp12323AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp12323.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function

    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp5621() As DiagnosticHelp5621
        Get
            Return _diagnostichelp5621
        End Get
        Set(ByVal Value As DiagnosticHelp5621)
            _diagnostichelp5621 = Value
        End Set
    End Property
    Public Function diagnosticHelp5621AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp5621.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp552() As DiagnosticHelp552
        Get
            Return m_diagnostichelp552
        End Get
        Set(ByVal Value As DiagnosticHelp552)
            m_diagnostichelp552 = Value
        End Set
    End Property
    Public Function diagnosticHelp552AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = m_diagnostichelp552.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp5622() As DiagnosticHelp5622
        Get
            Return _diagnostichelp5622
        End Get
        Set(ByVal Value As DiagnosticHelp5622)
            _diagnostichelp5622 = Value
        End Set
    End Property
    Public Function diagnosticHelp5622AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp5622.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp811() As DiagnosticHelp811
        Get
            Return _diagnostichelp811
        End Get
        Set(ByVal Value As DiagnosticHelp811)
            _diagnostichelp811 = Value
        End Set
    End Property

    Public Function diagnosticHelp811AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp811.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp8312() As DiagnosticHelp831
        Get
            Return _diagnostichelp8312
        End Get
        Set(ByVal Value As DiagnosticHelp831)
            _diagnostichelp8312 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp8314() As DiagnosticHelp831
        Get
            Return _diagnostichelp8314
        End Get
        Set(ByVal Value As DiagnosticHelp831)
            _diagnostichelp8314 = Value
        End Set
    End Property

    Public Function diagnosticHelp8312AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp8312.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    Public Function diagnosticHelp8314AsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnostichelp8314.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp571 As DiagnosticHelp571
        Get
            Return _diagnostichelp571
        End Get
        Set(ByVal Value As DiagnosticHelp571)
            _diagnostichelp571 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property diagnosticHelp12123 As DiagnosticHelp12123
        Get
            Return _diagnostichelp12123
        End Get
        Set(ByVal Value As DiagnosticHelp12123)
            _diagnostichelp12123 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property diagnosticInfosComplementaires() As DiagnosticInfosComplementaires
        Get
            Return _diagnosticInfosComplementaire
        End Get
        Set(ByVal Value As DiagnosticInfosComplementaires)
            _diagnosticInfosComplementaire = Value
        End Set
    End Property

    Public Function diagnosticInfosComplementairesAsDiagItem() As DiagnosticItem
        Dim objDiagItem As DiagnosticItem
        objDiagItem = _diagnosticInfosComplementaire.ConvertToDiagnosticItem()
        objDiagItem.dateModificationAgent = dateModificationAgent
        objDiagItem.dateModificationCrodip = dateModificationCrodip

        Return objDiagItem
    End Function

    <XmlIgnoreAttribute()>
    Public Property relevePression833_1 As RelevePression833
        Get
            Return m_relevePression833_1
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_1 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property relevePression833_2 As RelevePression833
        Get
            Return m_relevePression833_2
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_2 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property relevePression833_3 As RelevePression833
        Get
            Return m_relevePression833_3
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_3 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property relevePression833_4 As RelevePression833
        Get
            Return m_relevePression833_4
        End Get
        Set(ByVal Value As RelevePression833)
            m_relevePression833_4 = Value
        End Set
    End Property
    Public Property controleInitialId As String
        Get
            Return _ControleInitialId
        End Get
        Set(ByVal Value As String)
            _ControleInitialId = Value
        End Set
    End Property
    Public Property RIFileName() As String
        Get
            Return _RIFileName
        End Get
        Set(ByVal Value As String)
            _RIFileName = Value
        End Set
    End Property
    Public Property SMFileName() As String
        Get
            Return _SMFileName
        End Get
        Set(ByVal Value As String)
            _SMFileName = Value
        End Set
    End Property
    Public Property CCFileName() As String
        Get
            Return _CCFileName
        End Get
        Set(ByVal Value As String)
            _CCFileName = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property ParamDiag As CRODIP_ControlLibrary.ParamDiag
        Get
            Return _ParamDiag
        End Get
        Set(ByVal Value As CRODIP_ControlLibrary.ParamDiag)
            _ParamDiag = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property TotalHT As Decimal
        Get
            Return _TotalHT
        End Get
        Set(ByVal Value As Decimal)
            _TotalHT = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property TotalTVA As Decimal
        Get
            Return _TotalTVA
        End Get
        Set(ByVal Value As Decimal)
            _TotalTVA = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property TotalTTC As Decimal
        Get
            Return _TotalTTC
        End Get
        Set(ByVal Value As Decimal)
            _TotalTTC = Value
        End Set
    End Property


    Public Property pulverisateurRegulation As String
        Get
            Return _PulverisateurRegulation
        End Get
        Set(value As String)
            _PulverisateurRegulation = value
        End Set
    End Property
    Public Property pulverisateurRegulationOptions As String
        Get
            Return _PulverisateurRegulationOptions
        End Get
        Set(value As String)
            _PulverisateurRegulationOptions = value
        End Set
    End Property

    Public Property pulverisateurModeUtilisation As String
        Get
            Return _PulverisateurModeUtilisation
        End Get
        Set(value As String)
            _PulverisateurModeUtilisation = value
        End Set
    End Property
    Public Property pulverisateurNbreExploitants As String
        Get
            Return _PulverisateurNbreExploitants
        End Get
        Set(value As String)
            _PulverisateurNbreExploitants = value
        End Set
    End Property
    Public Property pulverisateurCoupureAutoTroncons As String
        Get
            Return _pulverisateurCoupureAutoTroncons
        End Get
        Set(value As String)
            _pulverisateurCoupureAutoTroncons = value
        End Set
    End Property
    Public Property pulverisateurReglageAutoHauteur As String
        Get
            Return _pulverisateurReglageAutoHauteur
        End Get
        Set(value As String)
            _pulverisateurReglageAutoHauteur = value
        End Set
    End Property
    Public Property pulverisateurRincagecircuit As String
        Get
            Return _pulverisateurRincagecircuit
        End Get
        Set(value As String)
            _pulverisateurRincagecircuit = value
        End Set
    End Property

    Public Property isContrevisiteImmediate() As Boolean
        Get
            Return _isContreVisiteImmediate
        End Get
        Set(ByVal Value As Boolean)
            _isContreVisiteImmediate = Value
        End Set
    End Property
    ''' <summary>
    ''' origine du diag (CRODIP, GIP, ITEQ, ...
    ''' </summary>
    ''' <returns></returns>
    <XmlElement("typeDiag")>
    Public Property origineDiag() As String
    Public Property typeDiagnostic() As String
        Get
            Return _typeDiagnostic
        End Get
        Set(ByVal Value As String)
            _typeDiagnostic = Value
        End Set
    End Property
    Public Property codeInsee() As String
        Get
            Return _codeInsee
        End Get
        Set(ByVal Value As String)
            _codeInsee = Value
        End Set
    End Property
    ''' <summary>
    ''' DebitMoyen à la pression de Mesure (non sauvegardé)
    ''' (utilise pour le reglagePulve ?)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <XmlIgnoreAttribute()>
    Public Property buseDebitMoyenPM() As Decimal
        Get
            Return m_buseDebitMoyenPM
        End Get
        Set(ByVal Value As Decimal)
            m_buseDebitMoyenPM = Value
        End Set
    End Property
    ''' <summary>
    ''' Commentaire associé au diagnostic
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property commentaire() As String
        Get
            Return _Commentaire
        End Get
        Set(ByVal value As String)
            _Commentaire = value
        End Set
    End Property

#End Region

    Public Function SetProprietaire(ByVal pClient As Exploitation) As Boolean

        Dim bReturn As Boolean
        Try
            proprietaireId = pClient.id
            proprietaireNumeroSiren = pClient.numeroSiren
            proprietaireCodeApe = pClient.codeApe
            proprietaireRaisonSociale = pClient.raisonSociale
            proprietaireNom = pClient.nomExploitant
            proprietairePrenom = pClient.prenomExploitant
            proprietaireAdresse = pClient.adresse
            proprietaireCodePostal = pClient.codePostal
            proprietaireCommune = pClient.commune
            proprietaireTelephoneFixe = pClient.telephoneFixe
            proprietaireTelephonePortable = pClient.telephonePortable
            proprietaireEmail = pClient.eMail

            exploitationTypeCultureIsGrandeCulture = pClient.isProdGrandeCulture
            exploitationTypeCultureIsElevage = pClient.isProdElevage
            exploitationTypeCultureIsArboriculture = pClient.isProdArboriculture
            exploitationTypeCultureIsLegume = pClient.isProdLegume
            exploitationTypeCultureIsViticulture = pClient.isProdViticulture
            exploitationTypeCultureIsAutres = pClient.isProdAutre
            exploitationSau = pClient.surfaceAgricoleUtile

            Dim oLstCommunes As ReferentielCommunesCSV = New ReferentielCommunesCSV()
            oLstCommunes.load()
            codeInsee = oLstCommunes.getCodeINSEE(proprietaireCodePostal, proprietaireCommune)

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Dupplique les Infos de l'organisme et de l'inspecteur dans l'Organisme et l'inspecteur d'origine
    ''' (utilisée lors d'une contre visite)
    ''' </summary>
    ''' <returns>TRUE/FALSE</returns>
    ''' <remarks></remarks>
    Public Function duppliqueInfosOrganisme() As Boolean
        Dim bReturn As Boolean
        Try
            organismeOriginePresId = organismePresId
            organismeOriginePresNumero = organismePresNumero
            organismeOriginePresNom = organismePresNom
            organismeOrigineInspNom = organismeInspNom
            organismeOrigineInspAgrement = organismeInspAgrement
            inspecteurOrigineId = inspecteurId
            inspecteurOrigineNom = inspecteurNom
            inspecteurOriginePrenom = inspecteurPrenom
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.duppliqueInfosOrganisme ERR : " + ex.Message())
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function setOrganisme(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try


            organismePresId = pAgent.idStructure
            Dim structureCourante As Structuree
            Try
                structureCourante = StructureManager.getStructureById(pAgent.idStructure)
            Catch ex As Exception
                structureCourante = New Structuree
            End Try
            organismePresNumero = structureCourante.idCrodip
            organismePresNom = structureCourante.nom
            organismeInspNom = Globals.GLOB_DIAG_NOMAGR
            organismeInspAgrement = Globals.GLOB_DIAG_NUMAGR
            organismePresAdresse = structureCourante.adresse
            organismePresCodePostal = structureCourante.codePostal
            organismePresCommune = structureCourante.commune

            inspecteurId = pAgent.id
            inspecteurNom = pAgent.nom
            inspecteurPrenom = pAgent.prenom
            inspecteurNumeroNational = pAgent.numeroNational
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.SetOrganisme ERR " + ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    ''' <summary>
    '''  Configure le Diagnostic comme une contre-visite
    ''' </summary>
    ''' <returns>Boolean </returns>
    ''' <remarks></remarks>
    Public Function SetAsContreVisite(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Me.duppliqueInfosOrganisme()
            'Organisme précédant = CRODIP/Indigo
            Me.organismeOriginePresNom = Globals.GLOB_DIAG_NOMAGR
            Me.inspecteurOrigineNom = Me.inspecteurNom
            Me.inspecteurOriginePrenom = Me.inspecteurPrenom
            Me.setOrganisme(pAgent)
            Me.controleInitialId = Me.id
            Me.controleDateDernierControle = Me.controleDateFin
            Me.controleDateDebut = CSDate.mysql2access(Date.Now)
            Me.controleDateFin = CSDate.mysql2access(Date.Now)
            Me.dateModificationAgent = CSDate.mysql2access(Date.Now)
            Me.controleIsComplet = False
            Me.isATGIP = False
            Me.isTGIP = False
            Me.isFacture = False
            Me.isSynchro = False
            Me.id = ""
            Me.diagRemplacementId = ""
            Me.dateSignCCAgent = Nothing
            Me.dateSignCCClient = Nothing
            Me.dateSignRIAgent = Nothing
            Me.dateSignRIClient = Nothing
            Me.isSignCCAgent = False
            Me.isSignCCClient = False
            Me.isSignRIAgent = False
            Me.isSignRIClient = False
            Me.SignCCAgent = Nothing
            Me.SignCCClient = Nothing
            Me.SignRIAgent = Nothing
            Me.SignRIClient = Nothing

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.SetAsContreVisite ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Fill(ByVal pColName As String, ByVal pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pColName.ToUpper.Trim()
                Case "id".ToUpper().Trim()
                    Me.id = pcolValue.ToString()
                Case "organismePresId".ToUpper().Trim()
                    Me.organismePresId = pcolValue
                Case "organismePresNumero".ToUpper().Trim()
                    Me.organismePresNumero = pcolValue.ToString()
                Case "organismePresNom".ToUpper().Trim()
                    Me.organismePresNom = pcolValue.ToString()
                Case "organismeInspNom".ToUpper().Trim()
                    Me.organismeInspNom = pcolValue.ToString()
                Case "organismeInspAgrement".ToUpper().Trim()
                    Me.organismeInspAgrement = pcolValue.ToString()
                Case "inspecteurId".ToUpper().Trim()
                    Me.inspecteurId = pcolValue
                Case "inspecteurNom".ToUpper().Trim()
                    Me.inspecteurNom = pcolValue.ToString()
                Case "inspecteurPrenom".ToUpper().Trim()
                    Me.inspecteurPrenom = pcolValue.ToString()

                Case "organismeOriginePresId".ToUpper().Trim()
                    Me.organismeOriginePresId = pcolValue
                Case "organismeOriginePresNumero".ToUpper().Trim()
                    Me.organismeOriginePresNumero = pcolValue.ToString()
                Case "organismeOriginePresNom".ToUpper().Trim()
                    Me.organismeOriginePresNom = pcolValue.ToString()
                Case "organismeOrigineInspNom".ToUpper().Trim()
                    Me.organismeOrigineInspNom = pcolValue.ToString()
                Case "organismeOrigineInspAgrement".ToUpper().Trim()
                    Me.organismeOrigineInspAgrement = pcolValue.ToString()
                Case "inspecteurOrigineId".ToUpper().Trim()
                    Me.inspecteurOrigineId = pcolValue
                Case "inspecteurOrigineNom".ToUpper().Trim()
                    Me.inspecteurOrigineNom = pcolValue.ToString()
                Case "inspecteurOriginePrenom".ToUpper().Trim()
                    Me.inspecteurOriginePrenom = pcolValue.ToString()
                Case "controleEtat".ToUpper().Trim()
                    'On mémorise la date de prochain controle avant de mettre à jour l'état
                    Dim DateProchainCtrl As String = pulverisateurDateProchainControle
                    Me.controleEtat = pcolValue
                    pulverisateurDateProchainControle = DateProchainCtrl

                Case "controleDateDebut".ToUpper().Trim()
                    Me.controleDateDebut = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "controleDateFin".ToUpper().Trim()
                    Me.controleDateFin = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "controleCommune".ToUpper().Trim()
                    Me.controleCommune = pcolValue.ToString()
                Case "controleCodePostal".ToUpper().Trim()
                    Me.controleCodePostal = pcolValue.ToString()
                Case "controleLieu".ToUpper().Trim()
                    Me.controleLieu = pcolValue.ToString()
                Case "controleTerritoire".ToUpper().Trim()
                    Me.controleTerritoire = pcolValue.ToString()
                Case "controleSite".ToUpper().Trim()
                    Me.controleSite = pcolValue.ToString()
                Case "controleNomSite".ToUpper().Trim()
                    Me.controleNomSite = pcolValue.ToString()
                Case "controleIsComplet".ToUpper().Trim()
                    Me.controleIsComplet = pcolValue
                Case "controleIsPremierControle".ToUpper().Trim()
                    Me.controleIsPremierControle = pcolValue
                Case "controleDateDernierControle".ToUpper().Trim()
                    Me.controleDateDernierControle = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "controleIsSiteSecurise".ToUpper().Trim()
                    Me.controleIsSiteSecurise = pcolValue
                Case "controleIsRecupResidus".ToUpper().Trim()
                    Me.controleIsRecupResidus = pcolValue
                Case "controleEtat".ToUpper().Trim()
                    Me.controleEtat = pcolValue.ToString()
                Case "controleInfosConseils".ToUpper().Trim()
                    Me.controleInfosConseils = pcolValue.ToString()
                Case "controleTarif".ToUpper().Trim()
                    Me.controleTarif = pcolValue.ToString()
                Case "controleIsPulveRepare".ToUpper().Trim()
                    Me.controleIsPulveRepare = pcolValue
                Case "controleIsPreControleProfessionel".ToUpper().Trim()
                    Me.controleIsPreControleProfessionel = pcolValue
                Case "controleIsAutoControle".ToUpper().Trim()
                    Me.controleIsAutoControle = pcolValue
                Case "proprietaireId".ToUpper().Trim()
                    Me.proprietaireId = pcolValue.ToString()
                Case "proprietaireRaisonSociale".ToUpper().Trim()
                    Me.proprietaireRaisonSociale = pcolValue.ToString()
                Case "proprietairePrenom".ToUpper().Trim()
                    Me.proprietairePrenom = pcolValue.ToString()
                Case "proprietaireNom".ToUpper().Trim()
                    Me.proprietaireNom = pcolValue.ToString()
                Case "proprietaireCodeApe".ToUpper().Trim()
                    Me.proprietaireCodeApe = pcolValue.ToString()
                Case "proprietaireNumeroSiren".ToUpper().Trim()
                    Me.proprietaireNumeroSiren = pcolValue.ToString()
                Case "proprietaireCommune".ToUpper().Trim()
                    Me.proprietaireCommune = pcolValue.ToString()
                Case "proprietaireCodePostal".ToUpper().Trim()
                    Me.proprietaireCodePostal = pcolValue.ToString()
                Case "proprietaireAdresse".ToUpper().Trim()
                    Me.proprietaireAdresse = pcolValue.ToString()
                Case "proprietaireEmail".ToUpper().Trim()
                    Me.proprietaireEmail = pcolValue.ToString()
                Case "proprietaireTelephonePortable".ToUpper().Trim()
                    Me.proprietaireTelephonePortable = pcolValue.ToString()
                Case "proprietaireTelephoneFixe".ToUpper().Trim()
                    Me.proprietaireTelephoneFixe = pcolValue.ToString()
                Case "ProprietaireRepresentant".ToUpper().Trim()
                    Me.proprietaireRepresentant = pcolValue.ToString()
                Case "pulverisateurId".ToUpper().Trim()
                    Me.pulverisateurId = pcolValue.ToString()
                Case "pulverisateurMarque".ToUpper().Trim()
                    Me.pulverisateurMarque = pcolValue.ToString()
                Case "pulverisateurModele".ToUpper().Trim()
                    Me.pulverisateurModele = pcolValue.ToString()
                Case "pulverisateurType".ToUpper().Trim()
                    Me.pulverisateurType = pcolValue.ToString()
                Case "pulverisateurCapacite".ToUpper().Trim()
                    Me.pulverisateurCapacite = pcolValue.ToString()
                Case "pulverisateurLargeur".ToUpper().Trim()
                    Me.pulverisateurLargeur = pcolValue.ToString()
                Case "pulverisateurNbRangs".ToUpper().Trim()
                    Me.pulverisateurNbRangs = pcolValue.ToString()
                Case "pulverisateurLargeurPlantation".ToUpper().Trim()
                    Me.pulverisateurLargeurPlantation = pcolValue.ToString()
                Case "pulverisateurIsVentilateur".ToUpper().Trim()
                    Me.pulverisateurIsVentilateur = pcolValue
                Case "pulverisateurIsDebrayage".ToUpper().Trim()
                    Me.pulverisateurIsDebrayage = pcolValue
                Case "pulverisateurAnneeAchat".ToUpper().Trim()
                    Me.pulverisateurAnneeAchat = pcolValue.ToString()
                Case "pulverisateurSurface".ToUpper().Trim()
                    Me.pulverisateurSurface = pcolValue.ToString()
                Case "pulverisateurNbUtilisateurs".ToUpper().Trim()
                    Me.pulverisateurNbUtilisateurs = pcolValue.ToString()
                Case "pulverisateurIsCuveRincage".ToUpper().Trim()
                    Me.pulverisateurIsCuveRincage = pcolValue
                Case "pulverisateurCapaciteCuveRincage".ToUpper().Trim()
                    Me.pulverisateurCapaciteCuveRincage = pcolValue.ToString()
                Case "pulverisateurIsRotobuse".ToUpper().Trim()
                    Me.pulverisateurIsRotobuse = pcolValue
                Case "pulverisateurIsRinceBidon".ToUpper().Trim()
                    Me.pulverisateurIsRinceBidon = pcolValue
                Case "pulverisateurIsBidonLaveMain".ToUpper().Trim()
                    Me.pulverisateurIsBidonLaveMain = pcolValue
                Case "pulverisateurIsLanceLavageExterieur".ToUpper().Trim()
                    Me.pulverisateurIsLanceLavageExterieur = pcolValue
                Case "pulverisateurIsCuveIncorporation".ToUpper().Trim()
                    Me.pulverisateurIsCuveIncorporation = pcolValue
                Case "pulverisateurCategorie".ToUpper().Trim()
                    Me.pulverisateurCategorie = pcolValue.ToString
                Case "pulverisateurAttelage".ToUpper().Trim()
                    Me.pulverisateurAttelage = pcolValue.ToString()
                Case "pulverisateurRegulation".ToUpper().Trim()
                    Me.pulverisateurRegulation = pcolValue.ToString()
                Case "pulverisateurRegulationOptions".ToUpper().Trim()
                    Me.pulverisateurRegulationOptions = pcolValue.ToString()
                Case "pulverisateurPulverisation".ToUpper().Trim()
                    Me.pulverisateurPulverisation = pcolValue.ToString
                Case "pulverisateurAutresAccessoires".ToUpper().Trim()
                    Me.pulverisateurAutresAccessoires = pcolValue.ToString()
                Case "pulverisateurEmplacementIdentification".ToUpper().Trim()
                    Me.pulverisateurEmplacementIdentification = pcolValue.ToString()
                Case "pulverisateurModeUtilisation".ToUpper().Trim()
                    Me.pulverisateurModeUtilisation = pcolValue.ToString()
                Case "pulverisateurNbreExploitants".ToUpper().Trim()
                    Me.pulverisateurNbreExploitants = pcolValue.ToString()
                Case "buseMarque".ToUpper().Trim()
                    Me.buseMarque = pcolValue.ToString()
                Case "buseModele".ToUpper().Trim()
                    Me.buseModele = pcolValue.ToString()
                Case "buseCouleur".ToUpper().Trim()
                    Me.buseCouleur = pcolValue.ToString()
                Case "buseGenre".ToUpper().Trim()
                    Me.buseGenre = pcolValue.ToString()
                Case "buseCalibre".ToUpper().Trim()
                    Me.buseCalibre = pcolValue.ToString()
                Case "buseDebit".ToUpper().Trim()
                    Me.buseDebit = pcolValue.ToString()
                Case "buseDebit2bars".ToUpper().Trim()
                    Me.buseDebit2bars = pcolValue.ToString()
                Case "buseDebit3bars".ToUpper().Trim()
                    Me.buseDebit3bars = pcolValue.ToString()
                Case "buseAge".ToUpper().Trim()
                    Me.buseAge = pcolValue.ToString()
                Case "buseNbBuses".ToUpper().Trim()
                    Me.buseNbBuses = pcolValue.ToString()
                Case "buseType".ToUpper().Trim()
                    Me.buseType = pcolValue.ToString()
                Case "buseAngle".ToUpper().Trim()
                    Me.buseAngle = pcolValue.ToString()
                    'Case "buseFonctionnementIsStandard".ToUpper().Trim()
                    '    Me.buseFonctionnementIsStandard = pcolValue
                    'Case "buseFonctionnementIsPastilleChambre".ToUpper().Trim()
                    '    Me.buseFonctionnementIsPastilleChambre = pcolValue
                    'Case "buseFonctionnementIsInjectionAirLibre".ToUpper().Trim()
                    '    Me.buseFonctionnementIsInjectionAirLibre = pcolValue
                    'Case "buseFonctionnementIsInjectionAirForce".ToUpper().Trim()
                    '    Me.buseFonctionnementIsInjectionAirForce = pcolValue
                Case "buseFonctionnement".ToUpper().Trim()
                    Me.buseFonctionnement = pcolValue.ToString()
                Case "buseIsISO".ToUpper().Trim()
                    Me.buseIsISO = pcolValue
                Case "manometreMarque".ToUpper().Trim()
                    Me.manometreMarque = pcolValue.ToString()
                Case "manometreDiametre".ToUpper().Trim()
                    Me.manometreDiametre = pcolValue.ToString()
                Case "manometreType".ToUpper().Trim()
                    Me.manometreType = pcolValue.ToString()
                Case "manometreFondEchelle".ToUpper().Trim()
                    Me.manometreFondEchelle = pcolValue.ToString()
                Case "manometrePressionTravail".ToUpper().Trim()
                    Me.manometrePressionTravail = pcolValue.ToString()
                Case "exploitationTypeCultureIsGrandeCulture".ToUpper().Trim()
                    Me.exploitationTypeCultureIsGrandeCulture = pcolValue
                Case "exploitationTypeCultureIsLegume".ToUpper().Trim()
                    Me.exploitationTypeCultureIsLegume = pcolValue
                Case "exploitationTypeCultureIsElevage".ToUpper().Trim()
                    Me.exploitationTypeCultureIsElevage = pcolValue
                Case "exploitationTypeCultureIsArboriculture".ToUpper().Trim()
                    Me.exploitationTypeCultureIsArboriculture = pcolValue
                Case "exploitationTypeCultureIsViticulture".ToUpper().Trim()
                    Me.exploitationTypeCultureIsViticulture = pcolValue
                Case "exploitationTypeCultureIsAutres".ToUpper().Trim()
                    Me.exploitationTypeCultureIsAutres = pcolValue
                Case "exploitationSau".ToUpper().Trim()
                    Me.exploitationSau = pcolValue.ToString()
                Case "dateModificationAgent".ToUpper().Trim()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "dateModificationCrodip".ToUpper().Trim()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "dateSynchro".ToUpper().Trim()
                    Me.dateSynchro = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "isSynchro".ToUpper().Trim()
                    Me.isSynchro = pcolValue
                Case "isATGIP".ToUpper().Trim()
                    Me.isATGIP = pcolValue
                Case "isTGIP".ToUpper().Trim()
                    Me.isTGIP = pcolValue
                Case "isFacture".ToUpper().Trim()
                    Me.isFacture = pcolValue
                Case "syntheseErreurMoyenneMano".ToUpper().Trim()
                    Me.syntheseErreurMoyenneMano = pcolValue.ToString()
                Case "syntheseErreurMaxiMano".ToUpper().Trim()
                    Me.syntheseErreurMaxiMano = pcolValue.ToString()
                Case "syntheseErreurDebitmetre".ToUpper().Trim()
                    Me.syntheseErreurDebitmetre = pcolValue.ToString()
                Case "syntheseErreurMoyenneCinemometre".ToUpper().Trim()
                    Me.syntheseErreurMoyenneCinemometre = pcolValue.ToString()
                Case "syntheseUsureMoyenneBuses".ToUpper().Trim()
                    Me.syntheseUsureMoyenneBuses = pcolValue.ToString()
                Case "syntheseNbBusesUsees".ToUpper().Trim()
                    Me.syntheseNbBusesUsees = pcolValue.ToString()
                Case "synthesePerteChargeMoyenne".ToUpper().Trim()
                    Me.synthesePerteChargeMoyenne = pcolValue.ToString()
                Case "synthesePerteChargeMaxi".ToUpper().Trim()
                    Me.synthesePerteChargeMaxi = pcolValue.ToString()
                Case "controleBancMesureId".ToUpper().Trim()
                    Me.controleBancMesureId = pcolValue.ToString()
                Case "controleUseCalibrateur".ToUpper().Trim()
                    Me.controleUseCalibrateur = pcolValue
                Case "controleNbreNiveaux".ToUpper().Trim()
                    Me.controleNbreNiveaux = pcolValue.ToString()
                Case "controleNbreTroncons".ToUpper().Trim()
                    Me.controleNbreTroncons = pcolValue.ToString()
                Case "controleManoControleNumNational".ToUpper().Trim()
                    Me.controleManoControleNumNational = pcolValue.ToString()
                Case "controleInitialId".ToUpper().Trim()
                    Me.controleInitialId = pcolValue.ToString()
                Case "pulverisateurAncienId".ToUpper().Trim()
                    Me.pulverisateurAncienId = pcolValue.ToString()
                Case "RIFileName".ToUpper().Trim()
                    Me.RIFileName = pcolValue.ToString
                Case "SMFileName".ToUpper().Trim()
                    Me.SMFileName = pcolValue.ToString
                Case "CCFileName".ToUpper().Trim()
                    Me.CCFileName = pcolValue.ToString
                Case "pulverisateurCoupureAutoTroncons".ToUpper().Trim()
                    Me.pulverisateurCoupureAutoTroncons = pcolValue.ToString
                Case "pulverisateurReglageAutoHauteur".ToUpper().Trim()
                    Me.pulverisateurReglageAutoHauteur = pcolValue.ToString
                Case "pulverisateurRincagecircuit".ToUpper().Trim()
                    Me.pulverisateurRincagecircuit = pcolValue.ToString
                Case "typeDiagnostic".ToUpper().Trim()
                    Me.typeDiagnostic = pcolValue.ToString
                Case "codeInsee".ToUpper().Trim()
                    Me.codeInsee = pcolValue.ToString
                Case "commentaire".ToUpper().Trim()
                    Me.commentaire = pcolValue.ToString
                Case "pulverisateurNumNational".ToUpper().Trim()
                    Me.pulverisateurNumNational = pcolValue.ToString()
                Case "pulverisateurNumchassis".ToUpper().Trim()
                    Me.pulverisateurNumChassis = pcolValue.ToString()
                    'le typeDiag est le nom du champ dans le WS
                Case "typeDiag".ToUpper().Trim(), "origineDiag".ToUpper().Trim()
                    Me.origineDiag = pcolValue.ToString()
                Case "isSignRIAgent".ToUpper().Trim()
                    Me.isSignRIAgent = pcolValue
                Case "isSignRIClient".ToUpper().Trim()
                    Me.isSignRIClient = pcolValue
                Case "isSignCCAgent".ToUpper().Trim()
                    Me.isSignCCAgent = pcolValue
                Case "isSignCCClient".ToUpper().Trim()
                    Me.isSignCCClient = pcolValue
                Case "dateSignRIAgent".ToUpper().Trim()
                    If pcolValue.ToString() <> "" Then
                        Try
                            Me.dateSignRIAgent = CDate(pcolValue)
                        Catch

                        End Try

                    End If
                Case "dateSignRIClient".ToUpper().Trim()
                    If pcolValue.ToString() <> "" Then
                        Try

                            Me.dateSignRIClient = CDate(pcolValue)
                        Catch

                        End Try
                    End If
                Case "dateSignCCAgent".ToUpper().Trim()
                    If pcolValue.ToString() <> "" Then
                        Try
                            Me.dateSignCCAgent = CDate(pcolValue)
                        Catch

                        End Try
                    End If
                Case "dateSignCCClient".ToUpper().Trim()
                    If pcolValue.ToString <> "" Then
                        Try
                            Me.dateSignCCClient = CDate(pcolValue)
                        Catch

                        End Try
                    End If
                Case "SignRIAgent".ToUpper().Trim()
                    Me.SignRIAgent = pcolValue
                Case "SignRIClient".ToUpper().Trim()
                    Me.SignRIClient = pcolValue
                Case "SignCCAgent".ToUpper().Trim()
                    Me.SignCCAgent = pcolValue
                Case "SignCCClient".ToUpper().Trim()
                    Me.SignCCClient = pcolValue
                Case "isSupprime".ToUpper().Trim()
                    Me.isSupprime = pcolValue
                Case "diagRemplacementId".ToUpper().Trim()
                    If IsDBNull(pcolValue) Then
                        Me.diagRemplacementId = ""
                    Else
                        Me.diagRemplacementId = pcolValue.ToString()
                    End If
                Case "TotalHT".ToUpper().Trim()
                    Me.TotalHT = pcolValue
                Case "totalTTC".ToUpper().Trim()
                    Me.TotalTTC = pcolValue
            End Select
            '            ALTER TABLE DIAGNOSTIC ADD isSignRIAgent YESNO
            'ALTER TABLE DIAGNOSTIC ADD isSignRIClient YESNO
            'ALTER TABLE DIAGNOSTIC ADD isSignCCAgent YESNO
            'ALTER TABLE DIAGNOSTIC ADD isSignCCClient YESNO

            'ALTER TABLE DIAGNOSTIC ADD dateSignRIAgent DATE
            'ALTER TABLE DIAGNOSTIC ADD dateSignRIClient DATE
            'ALTER TABLE DIAGNOSTIC ADD dateSignCCAgent DATE
            'ALTER TABLE DIAGNOSTIC ADD dateSignCCClient DATE

            'ALTER TABLE DIAGNOSTIC ADD signRIAgent  LONGBINARY
            'ALTER TABLE DIAGNOSTIC ADD signRIClient  LONGBINARY
            'ALTER TABLE DIAGNOSTIC ADD signCCAgent  LONGBINARY
            'ALTER TABLE DIAGNOSTIC ADD signCCClient  LONGBINARY
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.Fill (" & pColName & "," & pcolValue.ToString() & ") ERR" + ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function calcNbreMesuresAncienneVersion() As Integer
        Dim bReturn As Boolean
        Dim pNbreMesure As Integer = 0
        Try
            Dim oSortedList As New SortedList()
            Dim nPressionMax As Integer = 0
            Dim nPressionMin As Integer = Integer.MaxValue
            Dim nColumnMax As Integer = 0
            Dim nColumnMin As Integer = Integer.MaxValue
            Dim nMesureMax1Pression As Integer = 0
            Dim nMesureMaxTouteslesPressions As Integer = 0

            For Each oDiag833 As DiagnosticTroncons833 In Me.diagnosticTroncons833.Liste
                oSortedList.Add(Trim(oDiag833.idPression) & "-" & Trim(oDiag833.idColumn), oDiag833.pressionSortie)
                If oDiag833.idPression < nPressionMin Then
                    nPressionMin = oDiag833.idPression
                End If
                If oDiag833.idColumn < nColumnMin Then
                    nColumnMin = oDiag833.idColumn
                End If
                If oDiag833.idPression > nPressionMax Then
                    nPressionMax = oDiag833.idPression
                End If
                If oDiag833.idColumn > nColumnMax Then
                    nColumnMax = oDiag833.idColumn
                End If
            Next
            'On parcourt le tableau en partant du plus grand 
            For nPression As Integer = nPressionMax To nPressionMin Step -1
                nMesureMax1Pression = nColumnMax 'Par défaut, la mesure max est la plus grande
                For nColumn As Integer = nColumnMax To nColumnMin Step -1
                    If oSortedList.ContainsKey(Trim(nPression) & "-" & Trim(nColumn)) Then
                        If oSortedList(Trim(nPression) & "-" & Trim(nColumn)) = 0 Then
                            'on prend la plus petite collone = 0
                            If nColumn < nMesureMax1Pression Then
                                nMesureMax1Pression = nColumn
                            End If
                        Else
                            'Dés que l'on rencontre une valeur <>0 on s'arrête
                            Exit For
                        End If
                    End If
                Next nColumn
                If nMesureMax1Pression <> 0 Then
                    If nMesureMax1Pression > nMesureMaxTouteslesPressions Then
                        nMesureMaxTouteslesPressions = nMesureMax1Pression
                    End If
                End If
            Next
            pNbreMesure = nMesureMaxTouteslesPressions - 1

        Catch ex As Exception
            CSDebug.dispError("Diagnostique.calcNbreMesuresAncienneVersion ERR" + ex.Message.ToString())
            bReturn = False
        End Try
        Return pNbreMesure
    End Function


    Public Function setPulverisateur(ByVal poPulve As Pulverisateur) As Boolean
        Dim bReturn As Boolean
        Try
            Me.pulverisateurId = poPulve.id
            Me.pulverisateurNumNational = poPulve.numeroNational
            Me.pulverisateurNumChassis = poPulve.numChassis
            If String.IsNullOrEmpty(poPulve.ancienIdentifiant) Then
                pulverisateurAncienId = ""
            Else
                pulverisateurAncienId = "Ancien identifiant :" & poPulve.ancienIdentifiant & ""
            End If
            Me.pulverisateurMarque = poPulve.marque
            Me.pulverisateurModele = poPulve.modele
            Me.pulverisateurType = poPulve.type
            Me.pulverisateurCapacite = poPulve.capacite
            Me.pulverisateurLargeur = poPulve.largeur
            Me.pulverisateurNbRangs = poPulve.nombreRangs
            Me.pulverisateurLargeurPlantation = poPulve.largeurPlantation
            Me.pulverisateurIsVentilateur = poPulve.isVentilateur
            Me.pulverisateurIsDebrayage = poPulve.isDebrayage
            Me.pulverisateurAnneeAchat = poPulve.anneeAchat
            Me.pulverisateurSurface = poPulve.surfaceParAn
            Me.pulverisateurNbUtilisateurs = poPulve.nombreUtilisateurs
            Me.pulverisateurIsCuveRincage = poPulve.isCuveRincage
            Me.pulverisateurCapaciteCuveRincage = poPulve.capaciteCuveRincage
            Me.pulverisateurIsRotobuse = poPulve.isRotobuse
            Me.pulverisateurIsRinceBidon = poPulve.isRinceBidon
            Me.pulverisateurIsBidonLaveMain = poPulve.isBidonLaveMain
            Me.pulverisateurIsLanceLavageExterieur = poPulve.isLanceLavage
            Me.pulverisateurIsCuveIncorporation = poPulve.isCuveIncorporation
            Me.pulverisateurCategorie = poPulve.categorie
            'Me.pulverisateurCategorieIsAxial = poPulve.categorieIsAxial
            'Me.pulverisateurCategorieIsJetDirige = poPulve.categorieIsJetDirige
            'Me.pulverisateurCategorieIsCanon = poPulve.categorieIsCanon
            'Me.pulverisateurCategorieIsVoute = poPulve.categorieIsVoute
            'Me.pulverisateurCategorieIsFaceParFace = poPulve.categorieIsFaceParFace
            Me.pulverisateurAttelage = poPulve.attelage
            'Me.pulverisateurRegulationIsPressionCONSTante = poPulve.isPressionconstante
            'Me.pulverisateurRegulationIsDpm = poPulve.isDPM
            'Me.pulverisateurRegulationIsDpa = poPulve.isDPA
            'Me.pulverisateurRegulationIsDpae = poPulve.isDPAE
            'Me.pulverisateurRegulationIsPression = poPulve.isDPAEPression
            'Me.pulverisateurRegulationIsDebit = poPulve.isDPAEDebit
            Me.pulverisateurRegulation = poPulve.regulation
            Me.pulverisateurRegulationOptions = poPulve.regulationOptions
            Me.pulverisateurPulverisation = poPulve.pulverisation
            Me.pulverisateurAutresAccessoires = ""
            Me.pulverisateurEmplacementIdentification = poPulve.emplacementIdentification
            Me.pulverisateurModeUtilisation = poPulve.modeUtilisation
            Me.pulverisateurNbreExploitants = poPulve.nombreExploitants
            If poPulve.isCoupureAutoTroncons Then
                Me.pulverisateurCoupureAutoTroncons = "OUI"
            Else
                Me.pulverisateurCoupureAutoTroncons = "NON"
            End If
            If poPulve.isReglageAutoHauteur Then
                Me.pulverisateurReglageAutoHauteur = "OUI"
            Else
                Me.pulverisateurReglageAutoHauteur = "NON"
            End If
            If poPulve.isRincagecircuit Then
                Me.pulverisateurRincagecircuit = "OUI"
            Else
                Me.pulverisateurRincagecircuit = "NON"
            End If

            Me.buseMarque = poPulve.buseMarque
            Me.buseModele = poPulve.buseModele
            Me.buseType = poPulve.buseType
            Me.buseFonctionnement = poPulve.buseFonctionnement
            'setbuseFonctionnement(poPulve.buseFonctionnement)
            'Me.setBooleensFonctionnement()
            Me.buseAngle = poPulve.buseAngle
            Me.buseIsISO = poPulve.buseIsIso
            Me.buseAge = poPulve.buseAge
            Me.buseNbBuses = poPulve.nombreBuses
            Me.buseCouleur = poPulve.buseCouleur

            Me.manometreMarque = poPulve.manometreMarque
            Me.manometreDiametre = poPulve.manometreDiametre
            Me.manometreType = poPulve.manometreType
            Me.manometreFondEchelle = poPulve.manometreFondEchelle
            '            Me.manometrePressionTravail = poPulve.manometrePressionTravail 'La Pression reste toujours à 3

            Me.pulverisateurDateProchainControle = poPulve.dateProchainControle
            Me.pulverisateurControleEtat = poPulve.controleEtat

            Dim sDate As String = poPulve.getDateDernierControle()
            If sDate = "" Then
                controleIsPremierControle = True
                controleDateDernierControle = ""
            Else

                controleIsPremierControle = False
                controleDateDernierControle = sDate
            End If
            If poPulve.isPulveAdditionnel Then
                typeDiagnostic = "equipement"
            Else
                typeDiagnostic = "pulverisateur"
            End If

            'Mise à jour du DiahHelp12123
            _diagnostichelp12123.fonctionnementBuses = poPulve.buseFonctionnement
            If poPulve.isPompesDoseuses Then
                Dim nbPompes As Integer
                nbPompes = poPulve.nbPompesDoseuses

                _diagnostichelp12123.lstPompesTrtSem.Clear()
                _diagnostichelp12123.lstPompes.Clear()
                If poPulve.isTraitementdesSemences() Then
                    For i As Integer = 1 To nbPompes
                        _diagnostichelp12123.AjoutePompeTrtSem()
                    Next

                Else
                    For i As Integer = 1 To nbPompes
                        _diagnostichelp12123.AjoutePompe()
                    Next


                End If
            Else
                'Pas de pompes doseuses
                _diagnostichelp12123.lstPompes.Clear()
                _diagnostichelp12123.lstPompesTrtSem.Clear()
                'Pour le traietement des semences CUILLERES
                'On ajout une Pompe avec 1 Mesure
                If poPulve.isTraitementdesSemences() Then
                    Dim oPompe As DiagnosticHelp12123PompeTrtSem
                    oPompe = _diagnostichelp12123.AjoutePompeTrtSem()
                End If
            End If
            _diagnostichelp12123.fonctionnementBuses = poPulve.buseFonctionnement
            _diagnostichelp12123.calcule()

            'On Stocke la referenc du pulve ou l'encodage Automatique
            _pulverisateur = poPulve
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.SetPulverisateur ERR:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getParamDiag() As CRODIP_ControlLibrary.ParamDiag
        Dim oReturn As New CRODIP_ControlLibrary.ParamDiag()
        Try
            Dim lst As List(Of CRODIP_ControlLibrary.ParamDiag)
            lst = CRODIP_ControlLibrary.ParamDiag.readXML()
            For Each oParam As CRODIP_ControlLibrary.ParamDiag In lst
                If oParam.libelle = Me.pulverisateurCategorie Or oParam.libelle = Me.pulverisateurType Then
                    oReturn = oParam
                    Exit For
                End If
            Next


        Catch ex As Exception
            CSDebug.dispError("Diagnostic.getParamDiag ERROR :" & ex.Message)
        End Try

        Return oReturn
    End Function

    ''' <summary>
    ''' Ajout d'un diagItem au diagnostic
    '''  Vérification s'il existe déjà
    ''' </summary>
    ''' <param name="pDiagnosticItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function AdOrReplaceDiagItem(ByVal pDiagnosticItem As DiagnosticItem) As Boolean
        Debug.Assert(diagnosticItemsLst IsNot Nothing)
        Dim bReturn As Boolean

        Try
            pDiagnosticItem.idDiagnostic = Me.id
            diagnosticItemsLst.AddOrReplace(pDiagnosticItem)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.AddDiagItem ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Suppression d'un diagItem du diagnostic
    ''' vérification de l'existence
    ''' </summary>
    ''' <param name="pDiagnosticItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RemoveDiagItem(ByVal pDiagnosticItem As DiagnosticItem) As Boolean
        Debug.Assert(diagnosticItemsLst IsNot Nothing)
        Dim bReturn As Boolean

        Try
            diagnosticItemsLst.Remove(pDiagnosticItem)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.RemoveDiagItem ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' Generation du dataset en vue la la construction du Bon de Livraison
    Public Function generateDataSetForBL(PCommentaire As String) As ds_EtatBL
        Dim oReturn As ds_EtatBL
        Try

            oReturn = New ds_EtatBL()
            Dim oRow As ds_EtatBL.FactureRow
            Dim oStructure As New Structuree()
            oStructure = StructureManager.getStructureById(Me.organismePresId)
            oRow = oReturn.Facture.AddFactureRow(IdPulve:=Me.pulverisateurNumNational,
                                                 NomOrganisme:=Me.organismePresNom,
                                                 MontantHT:=Me.TotalHT,
                                                 MontantTVA:=Me.TotalTVA,
                                                 MontantTTC:=Me.TotalTTC,
                                                 refacture:="",
                                                 dateFacture:=Date.Now(),
                                                 Footer:="",
                                                 LogoFileName:="",
                                                 Logo:=Nothing,
                                                 Commentaire:=PCommentaire)
            oReturn.Pulve.AddPulveRow(oRow,
                                      Marque:=pulverisateurMarque,
                                      Modele:=pulverisateurModele,
                                      Type:=pulverisateurType,
                                      Categorie:=Me.pulverisateurCategorie,
                                      _Largeur_rang:=pulverisateurLargeur,
                                      Annee:=pulverisateurAnneeAchat,
                                      Attelage:=pulverisateurAttelage,
                                      Regulation:=pulverisateurRegulation)

            oReturn.Proprio.AddProprioRow(
                                          RS:=proprietaireRaisonSociale,
                                          Nom:=proprietaireNom & " " & proprietairePrenom,
                                          Adresse:=proprietaireAdresse,
                                          CodePostal:=proprietaireCodePostal,
                                          Commune:=proprietaireCommune,
                                          CodeAPE:=proprietaireCodeApe,
                                          SIREN:=proprietaireNumeroSiren,
                                          Tel:=proprietaireTelephoneFixe,
                                          Fax:="",
                                          Port:=proprietaireTelephonePortable,
                                          Mail:=proprietaireEmail)

            oReturn.Organisme.AddOrganismeRow(parentFactureRowByFacture_Organisme:=oRow,
                                              adresse:=oStructure.adresse,
                                              Code_postal:=oStructure.codePostal,
                                              Commune:=oStructure.commune,
                                              Inspecteur:=inspecteurNom & " " & inspecteurPrenom,
                                              LieuControle:=Me.controleLieu,
                                              Site:=Me.controleSite,
                                              Nom_du_site:=Me.controleNomSite,
                                              TelFax:=oStructure.telephoneFixe & "" & oStructure.telephoneFax,
                                              SIREN:="",
                                              TVA:="",
                                              RCS:="")

        Catch ex As Exception
            CSDebug.dispError("Diagnostic.generateDataSetForBL ERR" & ex.Message)
            oReturn = Nothing

        End Try
        Return oReturn

    End Function

    Public Function pulverisateurRegulationIsPressionCONSTante() As Boolean
        Return pulverisateurRegulation.Trim().ToLower() = "Pression constante".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPM() As Boolean
        Return pulverisateurRegulation.Trim().ToLower() = "DPM".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPA() As Boolean
        Return pulverisateurRegulation.Trim().ToLower() = "DPA".Trim().ToLower()
    End Function
    Public Function pulverisateurRegulationIsDPAE() As Boolean
        Return pulverisateurRegulation.Trim().ToLower().StartsWith("DPAE".Trim().ToLower())
    End Function

    Public Function calDebitMoyen(pDebitMoyenSource As Decimal, pPressionMesure As Decimal, Optional pPressionReference As Decimal = 3) As Decimal
        'Calcul du Débit Moyen à 3 bars
        Dim newDebitBuses As Decimal = 0
        Try
            'Q2= v ( (P2*Q1²)/P1)
            newDebitBuses = Math.Sqrt((pPressionReference * pDebitMoyenSource * pDebitMoyenSource) / pPressionMesure)
        Catch ex As Exception
            newDebitBuses = 0
        End Try
        Return Math.Round(newDebitBuses, 3)
    End Function
    ''' <summary>
    ''' Calcul la date de prochain controle pour le pulvé en fonction de l'tat du pulvé et du résultat du Controle
    ''' Etat du Pulvé
    '''  1 = PULVE EN BON ETAT
    '''  0 = DEFAUT SUR PULVE
    '''  Rien = pas de controle
    '''  
    ''' ATTENTION : l'état du pulve n'est pas modifié !!!
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalculDateProchainControle(Optional pImport As Boolean = False) As String
        Dim dReturn As Date
        If String.IsNullOrEmpty(pulverisateurDateProchainControle) Then
            dReturn = Now()
        Else
            dReturn = CDate(pulverisateurDateProchainControle)
        End If
        Dim oAlertes As Alertes
        oAlertes = Alertes.readXML()
        Dim nMoisValideOK As String = Pulverisateur.getNiveauAlerte(CDate(controleDateDebut)).Jaune
        Dim nMoisValideCV As String = Pulverisateur.getNiveauAlerte(CDate(controleDateDebut)).Rouge


        Dim pulverisateurControleEtatApres As String = pulverisateurControleEtat

        Select Case pulverisateurControleEtat
            Case "" 'Etat Nouveau
                Select Case controleEtat
                    Case Diagnostic.controleEtatOK
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideOK)
                    Case Diagnostic.controleEtatNOKCV
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                    Case Diagnostic.controleEtatNOKCC
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                End Select
            Case Pulverisateur.controleEtatOK
                'Etat OK
                Select Case controleEtat
                    Case Diagnostic.controleEtatOK
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideOK)
                    Case Diagnostic.controleEtatNOKCV
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                    Case Diagnostic.controleEtatNOKCC
                        'dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                End Select
            Case Pulverisateur.controleEtatNOKCV 'En attente de CV
                Select Case controleEtat
                    Case Diagnostic.controleEtatOK
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideOK)
                    Case Diagnostic.controleEtatNOKCV
                        If pImport Then
                            dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                        Else
                            'If CDate(controleDateDebut) <= dReturn Then
                            'dReturn = dReturn
                            'Else
                            dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                            'End If
                        End If
                    Case Diagnostic.controleEtatNOKCC
                        '        If pImport Then
                        '            dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                        '        Else
                        '            If CDate(controleDateDebut) <= dReturn Then
                        '                dReturn = dReturn
                        '            Else
                        '                dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                        '            End If
                        '        End If
                End Select
            Case Pulverisateur.controleEtatNOKCC 'Etat Attente de Controle Complet
                Select Case controleEtat
                    Case Diagnostic.controleEtatOK
                        dReturn = CDate(controleDateDebut).AddMonths(nMoisValideOK)
                    Case Diagnostic.controleEtatNOKCV
                        'If CDate(controleDateDebut) <= dReturn Then
                        '    dReturn = dReturn
                        'Else
                        '    dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                        'End If
                    Case Diagnostic.controleEtatNOKCC
                        '        If CDate(controleDateDebut) > dReturn Then
                        '            dReturn = dReturn
                        '        Else
                        '            dReturn = CDate(controleDateDebut).AddMonths(nMoisValideCV)
                        '        End If
                End Select
        End Select



        pulverisateurDateProchainControle = CSDate.ToCRODIPString(dReturn)
        Return CSDate.ToCRODIPString(dReturn)
    End Function
    ''' <summary>
    ''' Déclaration de l'utilisation des bancs et Controle Mano
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function setUtiliseBancEtMano(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            If Not String.IsNullOrEmpty(Me.controleManoControleNumNational) Then
                Dim oMano As ManometreControle = ManometreControleManager.getManometreControleByNumeroNational(Me.controleManoControleNumNational)
                If oMano IsNot Nothing Then
                    oMano.setUtilise(pAgent)
                    oMano.incNbControles()
                    ManometreControleManager.save(oMano)
                End If
            End If
            If Not String.IsNullOrEmpty(Me.controleBancMesureId) Then
                Dim obanc As Banc = BancManager.getBancById(Me.controleBancMesureId)
                If obanc IsNot Nothing Then
                    obanc.setUtilise(pAgent)
                    obanc.incNbControles()
                    BancManager.save(obanc)
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.setUtiliseBancEtMAno ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    ''' <summary>
    ''' Encodage automatique des diagItem
    ''' </summary>
    Public Sub EncodageAuto()

        Dim oLst As List(Of DiagnosticItem)
        oLst = _pulverisateur.EncodageAutomatiqueDefauts()
        For Each oDiagItem As DiagnosticItemAuto In oLst
            If oDiagItem.Etat = DiagnosticItemAuto.EtatDiagItemAuto.Actif Then
                Me.AdOrReplaceDiagItem(oDiagItem)
            Else
                Me.RemoveDiagItem(oDiagItem)
            End If
        Next

    End Sub

    Private _SignRIclient As Byte()
    <XmlIgnore()>
    Public Property SignRIClient() As Byte()
        Get
            Return _SignRIclient
        End Get
        Set(ByVal value As Byte())
            _SignRIclient = value
        End Set
    End Property
    Private _DateSignRIClient As Date?
    <XmlIgnore()>
    Public Property dateSignRIClient() As Date?
        Get
            Return _DateSignRIClient
        End Get
        Set(ByVal value As Date?)
            _DateSignRIClient = value
        End Set
    End Property
    <XmlElement("dateSignRIClient")>
    Public Property dateSignRIClientS() As String
        Get
            If dateSignRIClient.HasValue Then
                Return CSDate.GetDateForWS(dateSignRIClient)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            dateSignRIClient = CSDate.FromCrodipString(Value)
        End Set
    End Property
    Private _isSignRIClient As Boolean
    <XmlIgnore()>
    Public ReadOnly Property isSign() As Boolean
        Get
            Return isSignRIAgent And isSignRIClient And isSignCCAgent And isSignCCClient
        End Get
    End Property
    Public Property isSignRIClient() As Boolean
        Get
            Return _isSignRIClient
        End Get
        Set(ByVal value As Boolean)
            _isSignRIClient = value
        End Set
    End Property
    Private _SignRIAgent As Byte()
    <XmlIgnore()>
    Public Property SignRIAgent() As Byte()
        Get
            Return _SignRIAgent
        End Get
        Set(ByVal value As Byte())
            _SignRIAgent = value
        End Set
    End Property
    Private _DateSignRIAgent As Date?
    <XmlIgnore()>
    Public Property dateSignRIAgent() As Date?
        Get
            Return _DateSignRIAgent
        End Get
        Set(ByVal value As Date?)
            _DateSignRIAgent = value
        End Set
    End Property
    <XmlElement("dateSignRIAgent")>
    Public Property dateSignRIAgentS() As String
        Get
            If dateSignRIAgent.HasValue Then
                Return CSDate.GetDateForWS(dateSignRIAgent)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            dateSignRIAgent = CSDate.FromCrodipString(Value)
        End Set
    End Property
    Private _isSignRIAgent As Boolean
    Public Property isSignRIAgent() As Boolean
        Get
            Return _isSignRIAgent
        End Get
        Set(ByVal value As Boolean)
            _isSignRIAgent = value
        End Set
    End Property
    Private _SignCCAgent As Byte()
    <XmlIgnore()>
    Public Property SignCCAgent() As Byte()
        Get
            Return _SignCCAgent
        End Get
        Set(ByVal value As Byte())
            _SignCCAgent = value
        End Set
    End Property
    Private _isSignCCAgent As Boolean
    Public Property isSignCCAgent() As Boolean
        Get
            Return _isSignCCAgent
        End Get
        Set(ByVal value As Boolean)
            _isSignCCAgent = value
        End Set
    End Property
    Private _DateSignCCAgent As Date?
    <XmlIgnore()>
    Public Property dateSignCCAgent() As Date?
        Get
            Return _DateSignCCAgent
        End Get
        Set(ByVal value As Date?)
            _DateSignCCAgent = value
        End Set
    End Property
    <XmlElement("dateSignCCAgent")>
    Public Property dateSignCCAgentS() As String
        Get
            If dateSignCCAgent.HasValue Then
                Return CSDate.GetDateForWS(_DateSignCCAgent)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            _DateSignCCAgent = CSDate.FromCrodipString(Value)
        End Set
    End Property
    Private _SignCCClient As Byte()
    <XmlIgnore()>
    Public Property SignCCClient() As Byte()
        Get
            Return _SignCCClient
        End Get
        Set(ByVal value As Byte())
            _SignCCClient = value
        End Set
    End Property
    Private _isSignCCClient As Boolean
    Public Property isSignCCClient() As Boolean
        Get
            Return _isSignCCClient
        End Get
        Set(ByVal value As Boolean)
            _isSignCCClient = value
        End Set
    End Property
    Private _DateSignCCClient As Date?
    <XmlIgnore()>
    Public Property dateSignCCClient() As Date?
        Get
            Return _DateSignCCClient
        End Get
        Set(ByVal value As Date?)
            _DateSignCCClient = value
        End Set
    End Property
    <XmlElement("dateSignCCClient")>
    Public Property dateSignCCClientS() As String
        Get
            If dateSignCCClient.HasValue Then
                Return CSDate.GetDateForWS(_DateSignCCClient)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            _DateSignCCClient = CSDate.FromCrodipString(Value)
        End Set
    End Property
    Private _isSupprime As Boolean
    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal value As Boolean)
            _isSupprime = value
        End Set
    End Property

    Private _diagRemplacementId As String
    Public Property diagRemplacementId() As String
        Get
            Return _diagRemplacementId
        End Get
        Set(ByVal value As String)
            _diagRemplacementId = value
        End Set
    End Property
    Private Function IsFichierExists(pFileName As String) As Boolean
        Dim bReturn As Boolean
        bReturn = True
        If Not System.IO.File.Exists(Globals.CONST_PATH_EXP_DIAGNOSTIC & "/" & pFileName) Then
            EtatCrodip.getPDFs(Globals.CONST_PATH_EXP_DIAGNOSTIC, pFileName)
            If Not System.IO.File.Exists(Globals.CONST_PATH_EXP_DIAGNOSTIC & "/" & pFileName) Then
                bReturn = False
            End If
        End If
        Return bReturn
    End Function
    Public Function IsFichierRIExists() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        bReturn = IsFichierExists(Me.RIFileName)
        Return bReturn
    End Function
    Public Function IsFichierSMExists() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        bReturn = IsFichierExists(Me.SMFileName)
        Return bReturn
    End Function
    Public Function IsFichierCCExists() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        bReturn = IsFichierExists(Me.CCFileName)
        Return bReturn
    End Function


End Class
