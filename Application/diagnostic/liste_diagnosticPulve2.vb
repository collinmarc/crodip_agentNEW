Public Class liste_diagnosticPulve2
    Inherits System.Windows.Forms.Form

    Private m_oDiag As Diagnostic = Nothing
    Private _Puverisateur As Pulverisateur
    Private _DiagMode As Globals.DiagMode
    Public Property DiagMode() As Globals.DiagMode
        Get
            Return _DiagMode
        End Get
        Set(ByVal value As Globals.DiagMode)
            _DiagMode = value
        End Set
    End Property
    Public Property oPulve() As Pulverisateur
        Get
            Return _Puverisateur
        End Get
        Set(ByVal value As Pulverisateur)
            _Puverisateur = value
        End Set
    End Property
    Private _Exploit As Exploitation
    Friend WithEvents m_ImageList As ImageList
    Friend WithEvents DataGridView1 As DataGridView

    Friend WithEvents m_bsrcDiag As BindingSource
    Friend WithEvents id As DataGridViewTextBoxColumn

    Friend WithEvents controleDateDebut As DataGridViewTextBoxColumn

    Friend WithEvents controleEtat As DataGridViewTextBoxColumn

    Friend WithEvents Col_Rapports As DataGridViewDisableButtonColumn

    Friend WithEvents col_SM As DataGridViewDisableButtonColumn

    Friend WithEvents col_contrat As DataGridViewDisableButtonColumn

    Friend WithEvents col_Signatures As DataGridViewDisableButtonColumn

    Friend WithEvents col_Details As DataGridViewDisableButtonColumn

    Friend WithEvents IdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresNumeroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresAdresseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresCodePostalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismePresCommuneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeInspNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeInspAgrementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurNumeroNationalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurPrenomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeOriginePresIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeOriginePresNumeroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeOriginePresNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeOrigineInspNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents OrganismeOrigineInspAgrementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurOrigineIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurOrigineNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents InspecteurOriginePrenomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateDebutDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateDebutSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateFinDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateFinSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateDernierControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleDateDernierControleSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleCommuneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleCodePostalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleLieuDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleTerritoireDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleSiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleNomSiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleIsCompletDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleIsPremierControleDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleIsSiteSecuriseDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleIsRecupResidusDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleEtatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleInfosConseilsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleTarifDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleIsPulveRepareDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleIsPreControleProfessionelDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleIsAutoControleDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ProprietaireIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireRaisonSocialeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireRepresentantDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietairePrenomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireNomDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireCodeApeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireNumeroSirenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireCommuneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireCodePostalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireAdresseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireEmailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireTelephonePortableDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ProprietaireTelephoneFixeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurAncienIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurNumNationalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurNumChassisDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurMarqueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurModeleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurCapaciteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurLargeurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurNbRangsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurLargeurPlantationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurIsVentilateurDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurIsDebrayageDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurAnneeAchatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurSurfaceDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurNbUtilisateursDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurIsCuveRincageDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurIsRotobuseDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurIsRinceBidonDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents PulverisateurCategorieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurAttelageDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurPulverisationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurAutresAccessoiresDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurDateProchainControleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurControleEtatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseMarqueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseModeleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseCouleurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseGenreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseCalibreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseDebitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseDebitDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseDebit2barsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseDebit3barsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseAgeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseNbBusesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseAngleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseFonctionnementDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseIsISODataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ManometreMarqueDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ManometreDiametreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ManometreTypeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ManometreFondEchelleDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ManometrePressionTravailDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ManometrePressionTravailDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ExploitationSauDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateModificationAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateModificationAgentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateModificationCrodipDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateModificationCrodipSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSynchroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSynchroSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents IsSynchroDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents IsATGIPDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents IsTGIPDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents IsFactureDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents SyntheseErreurMoyenneManoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurMaxiManoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurDebitmetreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseNbBusesUseesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SynthesePerteChargeMoyenneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SynthesePerteChargeMaxiDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurMaxiManoDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurDebitmetreDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseNbBusesUseesDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SynthesePerteChargeMaxiDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SyntheseImprecision542DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticItemsLstDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticBusesListDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents NbreLotsBusesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticMano542ListDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticTroncons833DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleBancMesureIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleNbreNiveauxDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleNbreTronconsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleUseCalibrateurDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents ControleManoControleNumNationalDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp551DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp12323DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp5621DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp552DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp5622DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp811DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp8312DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp8314DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp571DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticHelp12123DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DiagnosticInfosComplementairesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents RelevePression8331DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents RelevePression8332DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents RelevePression8333DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents RelevePression8334DataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ControleInitialIdDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents RIFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SMFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents CCFileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents ParamDiagDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents TotalHTDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents TotalTVADataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents TotalTTCDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurRegulationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurRegulationOptionsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurModeUtilisationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurNbreExploitantsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents PulverisateurRincagecircuitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents IsContrevisiteImmediateDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents OrigineDiagDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents TypeDiagnosticDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents CodeInseeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents BuseDebitMoyenPMDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents CommentaireDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SignRIClientDataGridViewImageColumn As DataGridViewImageColumn

    Friend WithEvents DateSignRIClientDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSignRIClientSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents IsSignRIClientDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents SignRIAgentDataGridViewImageColumn As DataGridViewImageColumn

    Friend WithEvents DateSignRIAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSignRIAgentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents IsSignRIAgentDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents SignCCAgentDataGridViewImageColumn As DataGridViewImageColumn

    Friend WithEvents IsSignCCAgentDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents DateSignCCAgentDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSignCCAgentSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents SignCCClientDataGridViewImageColumn As DataGridViewImageColumn

    Friend WithEvents IsSignCCClientDataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn

    Friend WithEvents DateSignCCClientDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Friend WithEvents DateSignCCClientSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn

    Public Property oExploit() As Exploitation
        Get
            Return _Exploit
        End Get
        Set(ByVal value As Exploitation)
            _Exploit = value
        End Set
    End Property
    Private _Agent As Agent
    Public Property oAgent() As Agent
        Get
            Return _Agent
        End Get
        Set(ByVal value As Agent)
            _Agent = value
        End Set
    End Property

#Region " Code g�n�r� par le Concepteur Windows Form "
    Public Sub setcontexte(pPulve As Pulverisateur, pExploit As Exploitation, pagent As Agent)
        oPulve = pPulve
        oExploit = pExploit
        oAgent = pagent
    End Sub
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        For n As Integer = DataGridView1.Columns.GetColumnCount(DataGridViewElementStates.None) - 1 To 8 Step -1
            DataGridView1.Columns.RemoveAt(n)
        Next

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_selectDiagnostic_VisuDiag As System.Windows.Forms.Label
    Friend WithEvents btn_selectDiagnostic_annuler As System.Windows.Forms.Label
    Friend WithEvents btnSignature As Label
    Friend WithEvents listControle_search As System.Windows.Forms.TextBox
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(liste_diagnosticPulve2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.listControle_search = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_selectDiagnostic_VisuDiag = New System.Windows.Forms.Label()
        Me.btn_selectDiagnostic_annuler = New System.Windows.Forms.Label()
        Me.btnSignature = New System.Windows.Forms.Label()
        Me.m_ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.m_bsrcDiag = New System.Windows.Forms.BindingSource(Me.components)
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controleDateDebut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controleEtat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col_Rapports = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_SM = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_contrat = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_Signatures = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.col_Details = New Crodip_agent.DataGridViewDisableButtonColumn()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresNumeroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresAdresseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismePresCommuneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeInspNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurPrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateDebutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateDebutSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateFinDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateFinSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateDernierControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleCommuneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleCodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleLieuDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleTerritoireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleSiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleNomSiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleIsCompletDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleEtatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleInfosConseilsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleTarifDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ProprietaireIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietairePrenomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireNomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireCommuneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireAdresseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireEmailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurMarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurModeleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurLargeurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PulverisateurCategorieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurAttelageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseMarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseModeleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseCouleurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseGenreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseCalibreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseDebitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseDebitDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseDebit2barsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseDebit3barsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseAgeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseNbBusesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseAngleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseFonctionnementDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseIsISODataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ManometreMarqueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManometreDiametreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManometreTypeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManometreFondEchelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManometrePressionTravailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ExploitationSauDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationAgentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateModificationCrodipSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSynchroDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSynchroSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSynchroDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsATGIPDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsTGIPDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IsFactureDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SyntheseImprecision542DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticBusesListDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NbreLotsBusesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleBancMesureIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleNbreTronconsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp551DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp552DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp811DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp571DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RelevePression8331DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RelevePression8332DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RelevePression8333DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RelevePression8334DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ControleInitialIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RIFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SMFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCFileNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParamDiagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalHTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalTVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalTTCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurRegulationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.OrigineDiagDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TypeDiagnosticDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodeInseeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommentaireDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SignRIClientDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DateSignRIClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSignRIClientSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSignRIClientDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SignRIAgentDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DateSignRIAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSignRIAgentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsSignRIAgentDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SignCCAgentDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IsSignCCAgentDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateSignCCAgentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSignCCAgentSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SignCCClientDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.IsSignCCClientDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateSignCCClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateSignCCClientSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'listControle_search
        '
        Me.listControle_search.Location = New System.Drawing.Point(409, 16)
        Me.listControle_search.Name = "listControle_search"
        Me.listControle_search.Size = New System.Drawing.Size(152, 20)
        Me.listControle_search.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(321, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "N� contr�le : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(9, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(288, 25)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "     S�lectionnez un contr�le"
        '
        'btn_selectDiagnostic_VisuDiag
        '
        Me.btn_selectDiagnostic_VisuDiag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_selectDiagnostic_VisuDiag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_VisuDiag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_VisuDiag.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_VisuDiag.Image = CType(resources.GetObject("btn_selectDiagnostic_VisuDiag.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_VisuDiag.Location = New System.Drawing.Point(449, 391)
        Me.btn_selectDiagnostic_VisuDiag.Name = "btn_selectDiagnostic_VisuDiag"
        Me.btn_selectDiagnostic_VisuDiag.Size = New System.Drawing.Size(180, 24)
        Me.btn_selectDiagnostic_VisuDiag.TabIndex = 51
        Me.btn_selectDiagnostic_VisuDiag.Text = "       Visualisation d�un contr�le"
        Me.btn_selectDiagnostic_VisuDiag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_selectDiagnostic_annuler
        '
        Me.btn_selectDiagnostic_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_selectDiagnostic_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_selectDiagnostic_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_selectDiagnostic_annuler.Image = CType(resources.GetObject("btn_selectDiagnostic_annuler.Image"), System.Drawing.Image)
        Me.btn_selectDiagnostic_annuler.Location = New System.Drawing.Point(8, 392)
        Me.btn_selectDiagnostic_annuler.Name = "btn_selectDiagnostic_annuler"
        Me.btn_selectDiagnostic_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_selectDiagnostic_annuler.TabIndex = 50
        Me.btn_selectDiagnostic_annuler.Text = "    Annuler"
        Me.btn_selectDiagnostic_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSignature
        '
        Me.btnSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSignature.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignature.ForeColor = System.Drawing.Color.White
        Me.btnSignature.Image = Global.Crodip_agent.Resources.btn_Signture
        Me.btnSignature.Location = New System.Drawing.Point(227, 391)
        Me.btnSignature.Name = "btnSignature"
        Me.btnSignature.Size = New System.Drawing.Size(160, 24)
        Me.btnSignature.TabIndex = 52
        Me.btnSignature.Text = "         Signatures"
        Me.btnSignature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_ImageList
        '
        Me.m_ImageList.ImageStream = CType(resources.GetObject("m_ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.m_ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.m_ImageList.Images.SetKeyName(0, "favicon-pdf.ico")
        Me.m_ImageList.Images.SetKeyName(1, "PDF.png")
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.controleDateDebut, Me.controleEtat, Me.Col_Rapports, Me.col_SM, Me.col_contrat, Me.col_Signatures, Me.col_Details, Me.IdDataGridViewTextBoxColumn, Me.OrganismePresIdDataGridViewTextBoxColumn, Me.OrganismePresNumeroDataGridViewTextBoxColumn, Me.OrganismePresNomDataGridViewTextBoxColumn, Me.OrganismePresAdresseDataGridViewTextBoxColumn, Me.OrganismePresCodePostalDataGridViewTextBoxColumn, Me.OrganismePresCommuneDataGridViewTextBoxColumn, Me.OrganismeInspNomDataGridViewTextBoxColumn, Me.OrganismeInspAgrementDataGridViewTextBoxColumn, Me.InspecteurIdDataGridViewTextBoxColumn, Me.InspecteurNumeroNationalDataGridViewTextBoxColumn, Me.InspecteurNomDataGridViewTextBoxColumn, Me.InspecteurPrenomDataGridViewTextBoxColumn, Me.OrganismeOriginePresIdDataGridViewTextBoxColumn, Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn, Me.OrganismeOriginePresNomDataGridViewTextBoxColumn, Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn, Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn, Me.InspecteurOrigineIdDataGridViewTextBoxColumn, Me.InspecteurOrigineNomDataGridViewTextBoxColumn, Me.InspecteurOriginePrenomDataGridViewTextBoxColumn, Me.ControleDateDebutDataGridViewTextBoxColumn, Me.ControleDateDebutSDataGridViewTextBoxColumn, Me.ControleDateFinDataGridViewTextBoxColumn, Me.ControleDateFinSDataGridViewTextBoxColumn, Me.ControleDateDernierControleDataGridViewTextBoxColumn, Me.ControleDateDernierControleSDataGridViewTextBoxColumn, Me.ControleCommuneDataGridViewTextBoxColumn, Me.ControleCodePostalDataGridViewTextBoxColumn, Me.ControleLieuDataGridViewTextBoxColumn, Me.ControleTerritoireDataGridViewTextBoxColumn, Me.ControleSiteDataGridViewTextBoxColumn, Me.ControleNomSiteDataGridViewTextBoxColumn, Me.ControleIsCompletDataGridViewCheckBoxColumn, Me.ControleIsPremierControleDataGridViewCheckBoxColumn, Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn, Me.ControleIsRecupResidusDataGridViewCheckBoxColumn, Me.ControleEtatDataGridViewTextBoxColumn, Me.ControleInfosConseilsDataGridViewTextBoxColumn, Me.ControleTarifDataGridViewTextBoxColumn, Me.ControleIsPulveRepareDataGridViewCheckBoxColumn, Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn, Me.ControleIsAutoControleDataGridViewCheckBoxColumn, Me.ProprietaireIdDataGridViewTextBoxColumn, Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn, Me.ProprietaireRepresentantDataGridViewTextBoxColumn, Me.ProprietairePrenomDataGridViewTextBoxColumn, Me.ProprietaireNomDataGridViewTextBoxColumn, Me.ProprietaireCodeApeDataGridViewTextBoxColumn, Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn, Me.ProprietaireCommuneDataGridViewTextBoxColumn, Me.ProprietaireCodePostalDataGridViewTextBoxColumn, Me.ProprietaireAdresseDataGridViewTextBoxColumn, Me.ProprietaireEmailDataGridViewTextBoxColumn, Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn, Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn, Me.PulverisateurIdDataGridViewTextBoxColumn, Me.PulverisateurAncienIdDataGridViewTextBoxColumn, Me.PulverisateurNumNationalDataGridViewTextBoxColumn, Me.PulverisateurNumChassisDataGridViewTextBoxColumn, Me.PulverisateurMarqueDataGridViewTextBoxColumn, Me.PulverisateurModeleDataGridViewTextBoxColumn, Me.PulverisateurTypeDataGridViewTextBoxColumn, Me.PulverisateurCapaciteDataGridViewTextBoxColumn, Me.PulverisateurLargeurDataGridViewTextBoxColumn, Me.PulverisateurNbRangsDataGridViewTextBoxColumn, Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn, Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn, Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn, Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn, Me.PulverisateurSurfaceDataGridViewTextBoxColumn, Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn, Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn, Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn, Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn, Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn, Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn, Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn, Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn, Me.PulverisateurCategorieDataGridViewTextBoxColumn, Me.PulverisateurAttelageDataGridViewTextBoxColumn, Me.PulverisateurPulverisationDataGridViewTextBoxColumn, Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn, Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn, Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn, Me.PulverisateurControleEtatDataGridViewTextBoxColumn, Me.BuseMarqueDataGridViewTextBoxColumn, Me.BuseModeleDataGridViewTextBoxColumn, Me.BuseCouleurDataGridViewTextBoxColumn, Me.BuseGenreDataGridViewTextBoxColumn, Me.BuseCalibreDataGridViewTextBoxColumn, Me.BuseDebitDataGridViewTextBoxColumn, Me.BuseDebitDDataGridViewTextBoxColumn, Me.BuseDebit2barsDataGridViewTextBoxColumn, Me.BuseDebit3barsDataGridViewTextBoxColumn, Me.BuseAgeDataGridViewTextBoxColumn, Me.BuseNbBusesDataGridViewTextBoxColumn, Me.BuseTypeDataGridViewTextBoxColumn, Me.BuseAngleDataGridViewTextBoxColumn, Me.BuseFonctionnementDataGridViewTextBoxColumn, Me.BuseIsISODataGridViewCheckBoxColumn, Me.ManometreMarqueDataGridViewTextBoxColumn, Me.ManometreDiametreDataGridViewTextBoxColumn, Me.ManometreTypeDataGridViewTextBoxColumn, Me.ManometreFondEchelleDataGridViewTextBoxColumn, Me.ManometrePressionTravailDataGridViewTextBoxColumn, Me.ManometrePressionTravailDDataGridViewTextBoxColumn, Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn, Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn, Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn, Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn, Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn, Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn, Me.ExploitationSauDataGridViewTextBoxColumn, Me.DateModificationAgentDataGridViewTextBoxColumn, Me.DateModificationAgentSDataGridViewTextBoxColumn, Me.DateModificationCrodipDataGridViewTextBoxColumn, Me.DateModificationCrodipSDataGridViewTextBoxColumn, Me.DateSynchroDataGridViewTextBoxColumn, Me.DateSynchroSDataGridViewTextBoxColumn, Me.IsSynchroDataGridViewCheckBoxColumn, Me.IsATGIPDataGridViewCheckBoxColumn, Me.IsTGIPDataGridViewCheckBoxColumn, Me.IsFactureDataGridViewCheckBoxColumn, Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn, Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn, Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn, Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn, Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn, Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn, Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn, Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn, Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn, Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn, Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn, Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn, Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn, Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn, Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn, Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn, Me.SyntheseImprecision542DataGridViewTextBoxColumn, Me.DiagnosticItemsLstDataGridViewTextBoxColumn, Me.DiagnosticBusesListDataGridViewTextBoxColumn, Me.NbreLotsBusesDataGridViewTextBoxColumn, Me.DiagnosticMano542ListDataGridViewTextBoxColumn, Me.DiagnosticTroncons833DataGridViewTextBoxColumn, Me.ControleBancMesureIdDataGridViewTextBoxColumn, Me.ControleNbreNiveauxDataGridViewTextBoxColumn, Me.ControleNbreTronconsDataGridViewTextBoxColumn, Me.ControleUseCalibrateurDataGridViewCheckBoxColumn, Me.ControleManoControleNumNationalDataGridViewTextBoxColumn, Me.DiagnosticHelp551DataGridViewTextBoxColumn, Me.DiagnosticHelp12323DataGridViewTextBoxColumn, Me.DiagnosticHelp5621DataGridViewTextBoxColumn, Me.DiagnosticHelp552DataGridViewTextBoxColumn, Me.DiagnosticHelp5622DataGridViewTextBoxColumn, Me.DiagnosticHelp811DataGridViewTextBoxColumn, Me.DiagnosticHelp8312DataGridViewTextBoxColumn, Me.DiagnosticHelp8314DataGridViewTextBoxColumn, Me.DiagnosticHelp571DataGridViewTextBoxColumn, Me.DiagnosticHelp12123DataGridViewTextBoxColumn, Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn, Me.RelevePression8331DataGridViewTextBoxColumn, Me.RelevePression8332DataGridViewTextBoxColumn, Me.RelevePression8333DataGridViewTextBoxColumn, Me.RelevePression8334DataGridViewTextBoxColumn, Me.ControleInitialIdDataGridViewTextBoxColumn, Me.RIFileNameDataGridViewTextBoxColumn, Me.SMFileNameDataGridViewTextBoxColumn, Me.CCFileNameDataGridViewTextBoxColumn, Me.ParamDiagDataGridViewTextBoxColumn, Me.TotalHTDataGridViewTextBoxColumn, Me.TotalTVADataGridViewTextBoxColumn, Me.TotalTTCDataGridViewTextBoxColumn, Me.PulverisateurRegulationDataGridViewTextBoxColumn, Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn, Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn, Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn, Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn, Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn, Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn, Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn, Me.OrigineDiagDataGridViewTextBoxColumn, Me.TypeDiagnosticDataGridViewTextBoxColumn, Me.CodeInseeDataGridViewTextBoxColumn, Me.BuseDebitMoyenPMDataGridViewTextBoxColumn, Me.CommentaireDataGridViewTextBoxColumn, Me.SignRIClientDataGridViewImageColumn, Me.DateSignRIClientDataGridViewTextBoxColumn, Me.DateSignRIClientSDataGridViewTextBoxColumn, Me.IsSignRIClientDataGridViewCheckBoxColumn, Me.SignRIAgentDataGridViewImageColumn, Me.DateSignRIAgentDataGridViewTextBoxColumn, Me.DateSignRIAgentSDataGridViewTextBoxColumn, Me.IsSignRIAgentDataGridViewCheckBoxColumn, Me.SignCCAgentDataGridViewImageColumn, Me.IsSignCCAgentDataGridViewCheckBoxColumn, Me.DateSignCCAgentDataGridViewTextBoxColumn, Me.DateSignCCAgentSDataGridViewTextBoxColumn, Me.SignCCClientDataGridViewImageColumn, Me.IsSignCCClientDataGridViewCheckBoxColumn, Me.DateSignCCClientDataGridViewTextBoxColumn, Me.DateSignCCClientSDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.m_bsrcDiag
        Me.DataGridView1.Location = New System.Drawing.Point(6, 42)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 10
        Me.DataGridView1.Size = New System.Drawing.Size(634, 315)
        Me.DataGridView1.TabIndex = 53
        '
        'm_bsrcDiag
        '
        Me.m_bsrcDiag.DataSource = GetType(Crodip_agent.Diagnostic)
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "N�"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 44
        '
        'controleDateDebut
        '
        Me.controleDateDebut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.controleDateDebut.DataPropertyName = "controleDateDebut"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.controleDateDebut.DefaultCellStyle = DataGridViewCellStyle1
        Me.controleDateDebut.FillWeight = 200.0!
        Me.controleDateDebut.HeaderText = "Date"
        Me.controleDateDebut.Name = "controleDateDebut"
        Me.controleDateDebut.ReadOnly = True
        Me.controleDateDebut.Width = 55
        '
        'controleEtat
        '
        Me.controleEtat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.controleEtat.DataPropertyName = "controleEtatLibelle"
        Me.controleEtat.HeaderText = "R�sultat"
        Me.controleEtat.Name = "controleEtat"
        Me.controleEtat.ReadOnly = True
        Me.controleEtat.Width = 71
        '
        'Col_Rapports
        '
        Me.Col_Rapports.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.Col_Rapports.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col_Rapports.HeaderText = "Rapport"
        Me.Col_Rapports.Name = "Col_Rapports"
        Me.Col_Rapports.ReadOnly = True
        Me.Col_Rapports.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Col_Rapports.Text = "Visualiser"
        Me.Col_Rapports.ToolTipText = "Visualiser le rapport d'inspection"
        Me.Col_Rapports.UseColumnTextForButtonValue = True
        Me.Col_Rapports.Width = 51
        '
        'col_SM
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.col_SM.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_SM.HeaderText = "Synth�se des mesures"
        Me.col_SM.Name = "col_SM"
        Me.col_SM.ReadOnly = True
        Me.col_SM.Text = "Visualiser"
        Me.col_SM.ToolTipText = "Visualiser la synht�se des mesures"
        Me.col_SM.UseColumnTextForButtonValue = True
        Me.col_SM.Width = 72
        '
        'col_contrat
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.col_contrat.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_contrat.HeaderText = "Contrat"
        Me.col_contrat.Name = "col_contrat"
        Me.col_contrat.ReadOnly = True
        Me.col_contrat.Text = "Visualiser"
        Me.col_contrat.ToolTipText = "Visualiser le contrat commercial"
        Me.col_contrat.UseColumnTextForButtonValue = True
        Me.col_contrat.Width = 47
        '
        'col_Signatures
        '
        Me.col_Signatures.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.col_Signatures.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_Signatures.HeaderText = "Signatures"
        Me.col_Signatures.Name = "col_Signatures"
        Me.col_Signatures.ReadOnly = True
        Me.col_Signatures.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_Signatures.Text = "Signer"
        Me.col_Signatures.UseColumnTextForButtonValue = True
        Me.col_Signatures.Width = 63
        '
        'col_Details
        '
        Me.col_Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(217, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.col_Details.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_Details.HeaderText = "D�tails"
        Me.col_Details.Name = "col_Details"
        Me.col_Details.ReadOnly = True
        Me.col_Details.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col_Details.Text = "D�tail"
        Me.col_Details.UseColumnTextForButtonValue = True
        Me.col_Details.Width = 45
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Width = 40
        '
        'OrganismePresIdDataGridViewTextBoxColumn
        '
        Me.OrganismePresIdDataGridViewTextBoxColumn.DataPropertyName = "organismePresId"
        Me.OrganismePresIdDataGridViewTextBoxColumn.HeaderText = "organismePresId"
        Me.OrganismePresIdDataGridViewTextBoxColumn.Name = "OrganismePresIdDataGridViewTextBoxColumn"
        Me.OrganismePresIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresIdDataGridViewTextBoxColumn.Width = 110
        '
        'OrganismePresNumeroDataGridViewTextBoxColumn
        '
        Me.OrganismePresNumeroDataGridViewTextBoxColumn.DataPropertyName = "organismePresNumero"
        Me.OrganismePresNumeroDataGridViewTextBoxColumn.HeaderText = "organismePresNumero"
        Me.OrganismePresNumeroDataGridViewTextBoxColumn.Name = "OrganismePresNumeroDataGridViewTextBoxColumn"
        Me.OrganismePresNumeroDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresNumeroDataGridViewTextBoxColumn.Width = 138
        '
        'OrganismePresNomDataGridViewTextBoxColumn
        '
        Me.OrganismePresNomDataGridViewTextBoxColumn.DataPropertyName = "organismePresNom"
        Me.OrganismePresNomDataGridViewTextBoxColumn.HeaderText = "organismePresNom"
        Me.OrganismePresNomDataGridViewTextBoxColumn.Name = "OrganismePresNomDataGridViewTextBoxColumn"
        Me.OrganismePresNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresNomDataGridViewTextBoxColumn.Width = 123
        '
        'OrganismePresAdresseDataGridViewTextBoxColumn
        '
        Me.OrganismePresAdresseDataGridViewTextBoxColumn.DataPropertyName = "organismePresAdresse"
        Me.OrganismePresAdresseDataGridViewTextBoxColumn.HeaderText = "organismePresAdresse"
        Me.OrganismePresAdresseDataGridViewTextBoxColumn.Name = "OrganismePresAdresseDataGridViewTextBoxColumn"
        Me.OrganismePresAdresseDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresAdresseDataGridViewTextBoxColumn.Width = 139
        '
        'OrganismePresCodePostalDataGridViewTextBoxColumn
        '
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn.DataPropertyName = "organismePresCodePostal"
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn.HeaderText = "organismePresCodePostal"
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn.Name = "OrganismePresCodePostalDataGridViewTextBoxColumn"
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresCodePostalDataGridViewTextBoxColumn.Width = 155
        '
        'OrganismePresCommuneDataGridViewTextBoxColumn
        '
        Me.OrganismePresCommuneDataGridViewTextBoxColumn.DataPropertyName = "organismePresCommune"
        Me.OrganismePresCommuneDataGridViewTextBoxColumn.HeaderText = "organismePresCommune"
        Me.OrganismePresCommuneDataGridViewTextBoxColumn.Name = "OrganismePresCommuneDataGridViewTextBoxColumn"
        Me.OrganismePresCommuneDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismePresCommuneDataGridViewTextBoxColumn.Width = 148
        '
        'OrganismeInspNomDataGridViewTextBoxColumn
        '
        Me.OrganismeInspNomDataGridViewTextBoxColumn.DataPropertyName = "organismeInspNom"
        Me.OrganismeInspNomDataGridViewTextBoxColumn.HeaderText = "organismeInspNom"
        Me.OrganismeInspNomDataGridViewTextBoxColumn.Name = "OrganismeInspNomDataGridViewTextBoxColumn"
        Me.OrganismeInspNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeInspNomDataGridViewTextBoxColumn.Width = 122
        '
        'OrganismeInspAgrementDataGridViewTextBoxColumn
        '
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn.DataPropertyName = "organismeInspAgrement"
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn.HeaderText = "organismeInspAgrement"
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn.Name = "OrganismeInspAgrementDataGridViewTextBoxColumn"
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeInspAgrementDataGridViewTextBoxColumn.Width = 145
        '
        'InspecteurIdDataGridViewTextBoxColumn
        '
        Me.InspecteurIdDataGridViewTextBoxColumn.DataPropertyName = "inspecteurId"
        Me.InspecteurIdDataGridViewTextBoxColumn.HeaderText = "inspecteurId"
        Me.InspecteurIdDataGridViewTextBoxColumn.Name = "InspecteurIdDataGridViewTextBoxColumn"
        Me.InspecteurIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurIdDataGridViewTextBoxColumn.Width = 90
        '
        'InspecteurNumeroNationalDataGridViewTextBoxColumn
        '
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn.DataPropertyName = "inspecteurNumeroNational"
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn.HeaderText = "inspecteurNumeroNational"
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn.Name = "InspecteurNumeroNationalDataGridViewTextBoxColumn"
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurNumeroNationalDataGridViewTextBoxColumn.Width = 157
        '
        'InspecteurNomDataGridViewTextBoxColumn
        '
        Me.InspecteurNomDataGridViewTextBoxColumn.DataPropertyName = "inspecteurNom"
        Me.InspecteurNomDataGridViewTextBoxColumn.HeaderText = "inspecteurNom"
        Me.InspecteurNomDataGridViewTextBoxColumn.Name = "InspecteurNomDataGridViewTextBoxColumn"
        Me.InspecteurNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurNomDataGridViewTextBoxColumn.Width = 103
        '
        'InspecteurPrenomDataGridViewTextBoxColumn
        '
        Me.InspecteurPrenomDataGridViewTextBoxColumn.DataPropertyName = "inspecteurPrenom"
        Me.InspecteurPrenomDataGridViewTextBoxColumn.HeaderText = "inspecteurPrenom"
        Me.InspecteurPrenomDataGridViewTextBoxColumn.Name = "InspecteurPrenomDataGridViewTextBoxColumn"
        Me.InspecteurPrenomDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurPrenomDataGridViewTextBoxColumn.Width = 117
        '
        'OrganismeOriginePresIdDataGridViewTextBoxColumn
        '
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn.DataPropertyName = "organismeOriginePresId"
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn.HeaderText = "organismeOriginePresId"
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn.Name = "OrganismeOriginePresIdDataGridViewTextBoxColumn"
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeOriginePresIdDataGridViewTextBoxColumn.Width = 143
        '
        'OrganismeOriginePresNumeroDataGridViewTextBoxColumn
        '
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn.DataPropertyName = "organismeOriginePresNumero"
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn.HeaderText = "organismeOriginePresNumero"
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn.Name = "OrganismeOriginePresNumeroDataGridViewTextBoxColumn"
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeOriginePresNumeroDataGridViewTextBoxColumn.Width = 171
        '
        'OrganismeOriginePresNomDataGridViewTextBoxColumn
        '
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn.DataPropertyName = "organismeOriginePresNom"
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn.HeaderText = "organismeOriginePresNom"
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn.Name = "OrganismeOriginePresNomDataGridViewTextBoxColumn"
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeOriginePresNomDataGridViewTextBoxColumn.Width = 156
        '
        'OrganismeOrigineInspNomDataGridViewTextBoxColumn
        '
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn.DataPropertyName = "organismeOrigineInspNom"
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn.HeaderText = "organismeOrigineInspNom"
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn.Name = "OrganismeOrigineInspNomDataGridViewTextBoxColumn"
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeOrigineInspNomDataGridViewTextBoxColumn.Width = 155
        '
        'OrganismeOrigineInspAgrementDataGridViewTextBoxColumn
        '
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn.DataPropertyName = "organismeOrigineInspAgrement"
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn.HeaderText = "organismeOrigineInspAgrement"
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn.Name = "OrganismeOrigineInspAgrementDataGridViewTextBoxColumn"
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrganismeOrigineInspAgrementDataGridViewTextBoxColumn.Width = 178
        '
        'InspecteurOrigineIdDataGridViewTextBoxColumn
        '
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn.DataPropertyName = "inspecteurOrigineId"
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn.HeaderText = "inspecteurOrigineId"
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn.Name = "InspecteurOrigineIdDataGridViewTextBoxColumn"
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurOrigineIdDataGridViewTextBoxColumn.Width = 123
        '
        'InspecteurOrigineNomDataGridViewTextBoxColumn
        '
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn.DataPropertyName = "inspecteurOrigineNom"
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn.HeaderText = "inspecteurOrigineNom"
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn.Name = "InspecteurOrigineNomDataGridViewTextBoxColumn"
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurOrigineNomDataGridViewTextBoxColumn.Width = 136
        '
        'InspecteurOriginePrenomDataGridViewTextBoxColumn
        '
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn.DataPropertyName = "inspecteurOriginePrenom"
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn.HeaderText = "inspecteurOriginePrenom"
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn.Name = "InspecteurOriginePrenomDataGridViewTextBoxColumn"
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn.ReadOnly = True
        Me.InspecteurOriginePrenomDataGridViewTextBoxColumn.Width = 150
        '
        'ControleDateDebutDataGridViewTextBoxColumn
        '
        Me.ControleDateDebutDataGridViewTextBoxColumn.DataPropertyName = "controleDateDebut"
        Me.ControleDateDebutDataGridViewTextBoxColumn.HeaderText = "controleDateDebut"
        Me.ControleDateDebutDataGridViewTextBoxColumn.Name = "ControleDateDebutDataGridViewTextBoxColumn"
        Me.ControleDateDebutDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateDebutDataGridViewTextBoxColumn.Width = 122
        '
        'ControleDateDebutSDataGridViewTextBoxColumn
        '
        Me.ControleDateDebutSDataGridViewTextBoxColumn.DataPropertyName = "controleDateDebutS"
        Me.ControleDateDebutSDataGridViewTextBoxColumn.HeaderText = "controleDateDebutS"
        Me.ControleDateDebutSDataGridViewTextBoxColumn.Name = "ControleDateDebutSDataGridViewTextBoxColumn"
        Me.ControleDateDebutSDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateDebutSDataGridViewTextBoxColumn.Width = 129
        '
        'ControleDateFinDataGridViewTextBoxColumn
        '
        Me.ControleDateFinDataGridViewTextBoxColumn.DataPropertyName = "controleDateFin"
        Me.ControleDateFinDataGridViewTextBoxColumn.HeaderText = "controleDateFin"
        Me.ControleDateFinDataGridViewTextBoxColumn.Name = "ControleDateFinDataGridViewTextBoxColumn"
        Me.ControleDateFinDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateFinDataGridViewTextBoxColumn.Width = 107
        '
        'ControleDateFinSDataGridViewTextBoxColumn
        '
        Me.ControleDateFinSDataGridViewTextBoxColumn.DataPropertyName = "controleDateFinS"
        Me.ControleDateFinSDataGridViewTextBoxColumn.HeaderText = "controleDateFinS"
        Me.ControleDateFinSDataGridViewTextBoxColumn.Name = "ControleDateFinSDataGridViewTextBoxColumn"
        Me.ControleDateFinSDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateFinSDataGridViewTextBoxColumn.Width = 114
        '
        'ControleDateDernierControleDataGridViewTextBoxColumn
        '
        Me.ControleDateDernierControleDataGridViewTextBoxColumn.DataPropertyName = "controleDateDernierControle"
        Me.ControleDateDernierControleDataGridViewTextBoxColumn.HeaderText = "controleDateDernierControle"
        Me.ControleDateDernierControleDataGridViewTextBoxColumn.Name = "ControleDateDernierControleDataGridViewTextBoxColumn"
        Me.ControleDateDernierControleDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateDernierControleDataGridViewTextBoxColumn.Width = 166
        '
        'ControleDateDernierControleSDataGridViewTextBoxColumn
        '
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn.DataPropertyName = "controleDateDernierControleS"
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn.HeaderText = "controleDateDernierControleS"
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn.Name = "ControleDateDernierControleSDataGridViewTextBoxColumn"
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleDateDernierControleSDataGridViewTextBoxColumn.Width = 173
        '
        'ControleCommuneDataGridViewTextBoxColumn
        '
        Me.ControleCommuneDataGridViewTextBoxColumn.DataPropertyName = "controleCommune"
        Me.ControleCommuneDataGridViewTextBoxColumn.HeaderText = "controleCommune"
        Me.ControleCommuneDataGridViewTextBoxColumn.Name = "ControleCommuneDataGridViewTextBoxColumn"
        Me.ControleCommuneDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleCommuneDataGridViewTextBoxColumn.Width = 117
        '
        'ControleCodePostalDataGridViewTextBoxColumn
        '
        Me.ControleCodePostalDataGridViewTextBoxColumn.DataPropertyName = "controleCodePostal"
        Me.ControleCodePostalDataGridViewTextBoxColumn.HeaderText = "controleCodePostal"
        Me.ControleCodePostalDataGridViewTextBoxColumn.Name = "ControleCodePostalDataGridViewTextBoxColumn"
        Me.ControleCodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleCodePostalDataGridViewTextBoxColumn.Width = 124
        '
        'ControleLieuDataGridViewTextBoxColumn
        '
        Me.ControleLieuDataGridViewTextBoxColumn.DataPropertyName = "controleLieu"
        Me.ControleLieuDataGridViewTextBoxColumn.HeaderText = "controleLieu"
        Me.ControleLieuDataGridViewTextBoxColumn.Name = "ControleLieuDataGridViewTextBoxColumn"
        Me.ControleLieuDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleLieuDataGridViewTextBoxColumn.Width = 90
        '
        'ControleTerritoireDataGridViewTextBoxColumn
        '
        Me.ControleTerritoireDataGridViewTextBoxColumn.DataPropertyName = "controleTerritoire"
        Me.ControleTerritoireDataGridViewTextBoxColumn.HeaderText = "controleTerritoire"
        Me.ControleTerritoireDataGridViewTextBoxColumn.Name = "ControleTerritoireDataGridViewTextBoxColumn"
        Me.ControleTerritoireDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleTerritoireDataGridViewTextBoxColumn.Width = 111
        '
        'ControleSiteDataGridViewTextBoxColumn
        '
        Me.ControleSiteDataGridViewTextBoxColumn.DataPropertyName = "controleSite"
        Me.ControleSiteDataGridViewTextBoxColumn.HeaderText = "controleSite"
        Me.ControleSiteDataGridViewTextBoxColumn.Name = "ControleSiteDataGridViewTextBoxColumn"
        Me.ControleSiteDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleSiteDataGridViewTextBoxColumn.Width = 88
        '
        'ControleNomSiteDataGridViewTextBoxColumn
        '
        Me.ControleNomSiteDataGridViewTextBoxColumn.DataPropertyName = "controleNomSite"
        Me.ControleNomSiteDataGridViewTextBoxColumn.HeaderText = "controleNomSite"
        Me.ControleNomSiteDataGridViewTextBoxColumn.Name = "ControleNomSiteDataGridViewTextBoxColumn"
        Me.ControleNomSiteDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleNomSiteDataGridViewTextBoxColumn.Width = 110
        '
        'ControleIsCompletDataGridViewCheckBoxColumn
        '
        Me.ControleIsCompletDataGridViewCheckBoxColumn.DataPropertyName = "controleIsComplet"
        Me.ControleIsCompletDataGridViewCheckBoxColumn.HeaderText = "controleIsComplet"
        Me.ControleIsCompletDataGridViewCheckBoxColumn.Name = "ControleIsCompletDataGridViewCheckBoxColumn"
        Me.ControleIsCompletDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsCompletDataGridViewCheckBoxColumn.Width = 97
        '
        'ControleIsPremierControleDataGridViewCheckBoxColumn
        '
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn.DataPropertyName = "controleIsPremierControle"
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn.HeaderText = "controleIsPremierControle"
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn.Name = "ControleIsPremierControleDataGridViewCheckBoxColumn"
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsPremierControleDataGridViewCheckBoxColumn.Width = 133
        '
        'ControleIsSiteSecuriseDataGridViewCheckBoxColumn
        '
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn.DataPropertyName = "controleIsSiteSecurise"
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn.HeaderText = "controleIsSiteSecurise"
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn.Name = "ControleIsSiteSecuriseDataGridViewCheckBoxColumn"
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsSiteSecuriseDataGridViewCheckBoxColumn.Width = 118
        '
        'ControleIsRecupResidusDataGridViewCheckBoxColumn
        '
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn.DataPropertyName = "controleIsRecupResidus"
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn.HeaderText = "controleIsRecupResidus"
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn.Name = "ControleIsRecupResidusDataGridViewCheckBoxColumn"
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsRecupResidusDataGridViewCheckBoxColumn.Width = 129
        '
        'ControleEtatDataGridViewTextBoxColumn
        '
        Me.ControleEtatDataGridViewTextBoxColumn.DataPropertyName = "controleEtat"
        Me.ControleEtatDataGridViewTextBoxColumn.HeaderText = "controleEtat"
        Me.ControleEtatDataGridViewTextBoxColumn.Name = "ControleEtatDataGridViewTextBoxColumn"
        Me.ControleEtatDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleEtatDataGridViewTextBoxColumn.Width = 89
        '
        'ControleInfosConseilsDataGridViewTextBoxColumn
        '
        Me.ControleInfosConseilsDataGridViewTextBoxColumn.DataPropertyName = "controleInfosConseils"
        Me.ControleInfosConseilsDataGridViewTextBoxColumn.HeaderText = "controleInfosConseils"
        Me.ControleInfosConseilsDataGridViewTextBoxColumn.Name = "ControleInfosConseilsDataGridViewTextBoxColumn"
        Me.ControleInfosConseilsDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleInfosConseilsDataGridViewTextBoxColumn.Width = 132
        '
        'ControleTarifDataGridViewTextBoxColumn
        '
        Me.ControleTarifDataGridViewTextBoxColumn.DataPropertyName = "controleTarif"
        Me.ControleTarifDataGridViewTextBoxColumn.HeaderText = "controleTarif"
        Me.ControleTarifDataGridViewTextBoxColumn.Name = "ControleTarifDataGridViewTextBoxColumn"
        Me.ControleTarifDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleTarifDataGridViewTextBoxColumn.Width = 91
        '
        'ControleIsPulveRepareDataGridViewCheckBoxColumn
        '
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn.DataPropertyName = "controleIsPulveRepare"
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn.HeaderText = "controleIsPulveRepare"
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn.Name = "ControleIsPulveRepareDataGridViewCheckBoxColumn"
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsPulveRepareDataGridViewCheckBoxColumn.Width = 121
        '
        'ControleIsPreControleProfessionelDataGridViewCheckBoxColumn
        '
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn.DataPropertyName = "controleIsPreControleProfessionel"
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn.HeaderText = "controleIsPreControleProfessionel"
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn.Name = "ControleIsPreControleProfessionelDataGridViewCheckBoxColumn"
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsPreControleProfessionelDataGridViewCheckBoxColumn.Width = 171
        '
        'ControleIsAutoControleDataGridViewCheckBoxColumn
        '
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn.DataPropertyName = "controleIsAutoControle"
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn.HeaderText = "controleIsAutoControle"
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn.Name = "ControleIsAutoControleDataGridViewCheckBoxColumn"
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleIsAutoControleDataGridViewCheckBoxColumn.Width = 120
        '
        'ProprietaireIdDataGridViewTextBoxColumn
        '
        Me.ProprietaireIdDataGridViewTextBoxColumn.DataPropertyName = "proprietaireId"
        Me.ProprietaireIdDataGridViewTextBoxColumn.HeaderText = "proprietaireId"
        Me.ProprietaireIdDataGridViewTextBoxColumn.Name = "ProprietaireIdDataGridViewTextBoxColumn"
        Me.ProprietaireIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireIdDataGridViewTextBoxColumn.Width = 93
        '
        'ProprietaireRaisonSocialeDataGridViewTextBoxColumn
        '
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn.DataPropertyName = "proprietaireRaisonSociale"
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn.HeaderText = "proprietaireRaisonSociale"
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn.Name = "ProprietaireRaisonSocialeDataGridViewTextBoxColumn"
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireRaisonSocialeDataGridViewTextBoxColumn.Width = 152
        '
        'ProprietaireRepresentantDataGridViewTextBoxColumn
        '
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn.DataPropertyName = "proprietaireRepresentant"
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn.HeaderText = "proprietaireRepresentant"
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn.Name = "ProprietaireRepresentantDataGridViewTextBoxColumn"
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireRepresentantDataGridViewTextBoxColumn.Width = 148
        '
        'ProprietairePrenomDataGridViewTextBoxColumn
        '
        Me.ProprietairePrenomDataGridViewTextBoxColumn.DataPropertyName = "proprietairePrenom"
        Me.ProprietairePrenomDataGridViewTextBoxColumn.HeaderText = "proprietairePrenom"
        Me.ProprietairePrenomDataGridViewTextBoxColumn.Name = "ProprietairePrenomDataGridViewTextBoxColumn"
        Me.ProprietairePrenomDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietairePrenomDataGridViewTextBoxColumn.Width = 120
        '
        'ProprietaireNomDataGridViewTextBoxColumn
        '
        Me.ProprietaireNomDataGridViewTextBoxColumn.DataPropertyName = "proprietaireNom"
        Me.ProprietaireNomDataGridViewTextBoxColumn.HeaderText = "proprietaireNom"
        Me.ProprietaireNomDataGridViewTextBoxColumn.Name = "ProprietaireNomDataGridViewTextBoxColumn"
        Me.ProprietaireNomDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireNomDataGridViewTextBoxColumn.Width = 106
        '
        'ProprietaireCodeApeDataGridViewTextBoxColumn
        '
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn.DataPropertyName = "proprietaireCodeApe"
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn.HeaderText = "proprietaireCodeApe"
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn.Name = "ProprietaireCodeApeDataGridViewTextBoxColumn"
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireCodeApeDataGridViewTextBoxColumn.Width = 128
        '
        'ProprietaireNumeroSirenDataGridViewTextBoxColumn
        '
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn.DataPropertyName = "proprietaireNumeroSiren"
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn.HeaderText = "proprietaireNumeroSiren"
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn.Name = "ProprietaireNumeroSirenDataGridViewTextBoxColumn"
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireNumeroSirenDataGridViewTextBoxColumn.Width = 145
        '
        'ProprietaireCommuneDataGridViewTextBoxColumn
        '
        Me.ProprietaireCommuneDataGridViewTextBoxColumn.DataPropertyName = "proprietaireCommune"
        Me.ProprietaireCommuneDataGridViewTextBoxColumn.HeaderText = "proprietaireCommune"
        Me.ProprietaireCommuneDataGridViewTextBoxColumn.Name = "ProprietaireCommuneDataGridViewTextBoxColumn"
        Me.ProprietaireCommuneDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireCommuneDataGridViewTextBoxColumn.Width = 131
        '
        'ProprietaireCodePostalDataGridViewTextBoxColumn
        '
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn.DataPropertyName = "proprietaireCodePostal"
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn.HeaderText = "proprietaireCodePostal"
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn.Name = "ProprietaireCodePostalDataGridViewTextBoxColumn"
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireCodePostalDataGridViewTextBoxColumn.Width = 138
        '
        'ProprietaireAdresseDataGridViewTextBoxColumn
        '
        Me.ProprietaireAdresseDataGridViewTextBoxColumn.DataPropertyName = "proprietaireAdresse"
        Me.ProprietaireAdresseDataGridViewTextBoxColumn.HeaderText = "proprietaireAdresse"
        Me.ProprietaireAdresseDataGridViewTextBoxColumn.Name = "ProprietaireAdresseDataGridViewTextBoxColumn"
        Me.ProprietaireAdresseDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireAdresseDataGridViewTextBoxColumn.Width = 122
        '
        'ProprietaireEmailDataGridViewTextBoxColumn
        '
        Me.ProprietaireEmailDataGridViewTextBoxColumn.DataPropertyName = "proprietaireEmail"
        Me.ProprietaireEmailDataGridViewTextBoxColumn.HeaderText = "proprietaireEmail"
        Me.ProprietaireEmailDataGridViewTextBoxColumn.Name = "ProprietaireEmailDataGridViewTextBoxColumn"
        Me.ProprietaireEmailDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireEmailDataGridViewTextBoxColumn.Width = 109
        '
        'ProprietaireTelephonePortableDataGridViewTextBoxColumn
        '
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn.DataPropertyName = "proprietaireTelephonePortable"
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn.HeaderText = "proprietaireTelephonePortable"
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn.Name = "ProprietaireTelephonePortableDataGridViewTextBoxColumn"
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireTelephonePortableDataGridViewTextBoxColumn.Width = 174
        '
        'ProprietaireTelephoneFixeDataGridViewTextBoxColumn
        '
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn.DataPropertyName = "proprietaireTelephoneFixe"
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn.HeaderText = "proprietaireTelephoneFixe"
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn.Name = "ProprietaireTelephoneFixeDataGridViewTextBoxColumn"
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProprietaireTelephoneFixeDataGridViewTextBoxColumn.Width = 154
        '
        'PulverisateurIdDataGridViewTextBoxColumn
        '
        Me.PulverisateurIdDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurId"
        Me.PulverisateurIdDataGridViewTextBoxColumn.HeaderText = "pulverisateurId"
        Me.PulverisateurIdDataGridViewTextBoxColumn.Name = "PulverisateurIdDataGridViewTextBoxColumn"
        Me.PulverisateurIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurIdDataGridViewTextBoxColumn.Width = 101
        '
        'PulverisateurAncienIdDataGridViewTextBoxColumn
        '
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurAncienId"
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn.HeaderText = "pulverisateurAncienId"
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn.Name = "PulverisateurAncienIdDataGridViewTextBoxColumn"
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurAncienIdDataGridViewTextBoxColumn.Width = 134
        '
        'PulverisateurNumNationalDataGridViewTextBoxColumn
        '
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurNumNational"
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn.HeaderText = "pulverisateurNumNational"
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn.Name = "PulverisateurNumNationalDataGridViewTextBoxColumn"
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurNumNationalDataGridViewTextBoxColumn.Width = 153
        '
        'PulverisateurNumChassisDataGridViewTextBoxColumn
        '
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurNumChassis"
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn.HeaderText = "pulverisateurNumChassis"
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn.Name = "PulverisateurNumChassisDataGridViewTextBoxColumn"
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurNumChassisDataGridViewTextBoxColumn.Width = 150
        '
        'PulverisateurMarqueDataGridViewTextBoxColumn
        '
        Me.PulverisateurMarqueDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurMarque"
        Me.PulverisateurMarqueDataGridViewTextBoxColumn.HeaderText = "pulverisateurMarque"
        Me.PulverisateurMarqueDataGridViewTextBoxColumn.Name = "PulverisateurMarqueDataGridViewTextBoxColumn"
        Me.PulverisateurMarqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurMarqueDataGridViewTextBoxColumn.Width = 128
        '
        'PulverisateurModeleDataGridViewTextBoxColumn
        '
        Me.PulverisateurModeleDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurModele"
        Me.PulverisateurModeleDataGridViewTextBoxColumn.HeaderText = "pulverisateurModele"
        Me.PulverisateurModeleDataGridViewTextBoxColumn.Name = "PulverisateurModeleDataGridViewTextBoxColumn"
        Me.PulverisateurModeleDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurModeleDataGridViewTextBoxColumn.Width = 127
        '
        'PulverisateurTypeDataGridViewTextBoxColumn
        '
        Me.PulverisateurTypeDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurType"
        Me.PulverisateurTypeDataGridViewTextBoxColumn.HeaderText = "pulverisateurType"
        Me.PulverisateurTypeDataGridViewTextBoxColumn.Name = "PulverisateurTypeDataGridViewTextBoxColumn"
        Me.PulverisateurTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurTypeDataGridViewTextBoxColumn.Width = 116
        '
        'PulverisateurCapaciteDataGridViewTextBoxColumn
        '
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurCapacite"
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn.HeaderText = "pulverisateurCapacite"
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn.Name = "PulverisateurCapaciteDataGridViewTextBoxColumn"
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurCapaciteDataGridViewTextBoxColumn.Width = 134
        '
        'PulverisateurLargeurDataGridViewTextBoxColumn
        '
        Me.PulverisateurLargeurDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurLargeur"
        Me.PulverisateurLargeurDataGridViewTextBoxColumn.HeaderText = "pulverisateurLargeur"
        Me.PulverisateurLargeurDataGridViewTextBoxColumn.Name = "PulverisateurLargeurDataGridViewTextBoxColumn"
        Me.PulverisateurLargeurDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurLargeurDataGridViewTextBoxColumn.Width = 128
        '
        'PulverisateurNbRangsDataGridViewTextBoxColumn
        '
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurNbRangs"
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn.HeaderText = "pulverisateurNbRangs"
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn.Name = "PulverisateurNbRangsDataGridViewTextBoxColumn"
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurNbRangsDataGridViewTextBoxColumn.Width = 137
        '
        'PulverisateurLargeurPlantationDataGridViewTextBoxColumn
        '
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurLargeurPlantation"
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn.HeaderText = "pulverisateurLargeurPlantation"
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn.Name = "PulverisateurLargeurPlantationDataGridViewTextBoxColumn"
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurLargeurPlantationDataGridViewTextBoxColumn.Width = 175
        '
        'PulverisateurIsVentilateurDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsVentilateur"
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsVentilateur"
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn.Name = "PulverisateurIsVentilateurDataGridViewCheckBoxColumn"
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsVentilateurDataGridViewCheckBoxColumn.Width = 131
        '
        'PulverisateurIsDebrayageDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsDebrayage"
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsDebrayage"
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn.Name = "PulverisateurIsDebrayageDataGridViewCheckBoxColumn"
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsDebrayageDataGridViewCheckBoxColumn.Width = 133
        '
        'PulverisateurAnneeAchatDataGridViewTextBoxColumn
        '
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurAnneeAchat"
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn.HeaderText = "pulverisateurAnneeAchat"
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn.Name = "PulverisateurAnneeAchatDataGridViewTextBoxColumn"
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurAnneeAchatDataGridViewTextBoxColumn.Width = 151
        '
        'PulverisateurSurfaceDataGridViewTextBoxColumn
        '
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurSurface"
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn.HeaderText = "pulverisateurSurface"
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn.Name = "PulverisateurSurfaceDataGridViewTextBoxColumn"
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurSurfaceDataGridViewTextBoxColumn.Width = 129
        '
        'PulverisateurNbUtilisateursDataGridViewTextBoxColumn
        '
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurNbUtilisateurs"
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn.HeaderText = "pulverisateurNbUtilisateurs"
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn.Name = "PulverisateurNbUtilisateursDataGridViewTextBoxColumn"
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurNbUtilisateursDataGridViewTextBoxColumn.Width = 157
        '
        'PulverisateurIsCuveRincageDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsCuveRincage"
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsCuveRincage"
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn.Name = "PulverisateurIsCuveRincageDataGridViewCheckBoxColumn"
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsCuveRincageDataGridViewCheckBoxColumn.Width = 146
        '
        'PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn
        '
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurCapaciteCuveRincage"
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn.HeaderText = "pulverisateurCapaciteCuveRincage"
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn.Name = "PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn"
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurCapaciteCuveRincageDataGridViewTextBoxColumn.Width = 199
        '
        'PulverisateurIsRotobuseDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsRotobuse"
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsRotobuse"
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn.Name = "PulverisateurIsRotobuseDataGridViewCheckBoxColumn"
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsRotobuseDataGridViewCheckBoxColumn.Width = 127
        '
        'PulverisateurIsRinceBidonDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsRinceBidon"
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsRinceBidon"
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn.Name = "PulverisateurIsRinceBidonDataGridViewCheckBoxColumn"
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsRinceBidonDataGridViewCheckBoxColumn.Width = 136
        '
        'PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsBidonLaveMain"
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsBidonLaveMain"
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn.Name = "PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn"
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsBidonLaveMainDataGridViewCheckBoxColumn.Width = 155
        '
        'PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsLanceLavageExterieur"
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsLanceLavageExterieur"
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn.Name = "PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn"
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsLanceLavageExterieurDataGridViewCheckBoxColumn.Width = 188
        '
        'PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn
        '
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn.DataPropertyName = "pulverisateurIsCuveIncorporation"
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn.HeaderText = "pulverisateurIsCuveIncorporation"
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn.Name = "PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn"
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn.ReadOnly = True
        Me.PulverisateurIsCuveIncorporationDataGridViewCheckBoxColumn.Width = 168
        '
        'PulverisateurCategorieDataGridViewTextBoxColumn
        '
        Me.PulverisateurCategorieDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurCategorie"
        Me.PulverisateurCategorieDataGridViewTextBoxColumn.HeaderText = "pulverisateurCategorie"
        Me.PulverisateurCategorieDataGridViewTextBoxColumn.Name = "PulverisateurCategorieDataGridViewTextBoxColumn"
        Me.PulverisateurCategorieDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurCategorieDataGridViewTextBoxColumn.Width = 137
        '
        'PulverisateurAttelageDataGridViewTextBoxColumn
        '
        Me.PulverisateurAttelageDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurAttelage"
        Me.PulverisateurAttelageDataGridViewTextBoxColumn.HeaderText = "pulverisateurAttelage"
        Me.PulverisateurAttelageDataGridViewTextBoxColumn.Name = "PulverisateurAttelageDataGridViewTextBoxColumn"
        Me.PulverisateurAttelageDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurAttelageDataGridViewTextBoxColumn.Width = 131
        '
        'PulverisateurPulverisationDataGridViewTextBoxColumn
        '
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurPulverisation"
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn.HeaderText = "pulverisateurPulverisation"
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn.Name = "PulverisateurPulverisationDataGridViewTextBoxColumn"
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurPulverisationDataGridViewTextBoxColumn.Width = 152
        '
        'PulverisateurAutresAccessoiresDataGridViewTextBoxColumn
        '
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurAutresAccessoires"
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn.HeaderText = "pulverisateurAutresAccessoires"
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn.Name = "PulverisateurAutresAccessoiresDataGridViewTextBoxColumn"
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurAutresAccessoiresDataGridViewTextBoxColumn.Width = 179
        '
        'PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn
        '
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurEmplacementIdentification"
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn.HeaderText = "pulverisateurEmplacementIdentification"
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn.Name = "PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn"
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurEmplacementIdentificationDataGridViewTextBoxColumn.Width = 216
        '
        'PulverisateurDateProchainControleDataGridViewTextBoxColumn
        '
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurDateProchainControle"
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn.HeaderText = "pulverisateurDateProchainControle"
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn.Name = "PulverisateurDateProchainControleDataGridViewTextBoxColumn"
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurDateProchainControleDataGridViewTextBoxColumn.Width = 196
        '
        'PulverisateurControleEtatDataGridViewTextBoxColumn
        '
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurControleEtat"
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn.HeaderText = "pulverisateurControleEtat"
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn.Name = "PulverisateurControleEtatDataGridViewTextBoxColumn"
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurControleEtatDataGridViewTextBoxColumn.Width = 150
        '
        'BuseMarqueDataGridViewTextBoxColumn
        '
        Me.BuseMarqueDataGridViewTextBoxColumn.DataPropertyName = "buseMarque"
        Me.BuseMarqueDataGridViewTextBoxColumn.HeaderText = "buseMarque"
        Me.BuseMarqueDataGridViewTextBoxColumn.Name = "BuseMarqueDataGridViewTextBoxColumn"
        Me.BuseMarqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseMarqueDataGridViewTextBoxColumn.Width = 91
        '
        'BuseModeleDataGridViewTextBoxColumn
        '
        Me.BuseModeleDataGridViewTextBoxColumn.DataPropertyName = "buseModele"
        Me.BuseModeleDataGridViewTextBoxColumn.HeaderText = "buseModele"
        Me.BuseModeleDataGridViewTextBoxColumn.Name = "BuseModeleDataGridViewTextBoxColumn"
        Me.BuseModeleDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseModeleDataGridViewTextBoxColumn.Width = 90
        '
        'BuseCouleurDataGridViewTextBoxColumn
        '
        Me.BuseCouleurDataGridViewTextBoxColumn.DataPropertyName = "buseCouleur"
        Me.BuseCouleurDataGridViewTextBoxColumn.HeaderText = "buseCouleur"
        Me.BuseCouleurDataGridViewTextBoxColumn.Name = "BuseCouleurDataGridViewTextBoxColumn"
        Me.BuseCouleurDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseCouleurDataGridViewTextBoxColumn.Width = 91
        '
        'BuseGenreDataGridViewTextBoxColumn
        '
        Me.BuseGenreDataGridViewTextBoxColumn.DataPropertyName = "buseGenre"
        Me.BuseGenreDataGridViewTextBoxColumn.HeaderText = "buseGenre"
        Me.BuseGenreDataGridViewTextBoxColumn.Name = "BuseGenreDataGridViewTextBoxColumn"
        Me.BuseGenreDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseGenreDataGridViewTextBoxColumn.Width = 84
        '
        'BuseCalibreDataGridViewTextBoxColumn
        '
        Me.BuseCalibreDataGridViewTextBoxColumn.DataPropertyName = "buseCalibre"
        Me.BuseCalibreDataGridViewTextBoxColumn.HeaderText = "buseCalibre"
        Me.BuseCalibreDataGridViewTextBoxColumn.Name = "BuseCalibreDataGridViewTextBoxColumn"
        Me.BuseCalibreDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseCalibreDataGridViewTextBoxColumn.Width = 87
        '
        'BuseDebitDataGridViewTextBoxColumn
        '
        Me.BuseDebitDataGridViewTextBoxColumn.DataPropertyName = "buseDebit"
        Me.BuseDebitDataGridViewTextBoxColumn.HeaderText = "buseDebit"
        Me.BuseDebitDataGridViewTextBoxColumn.Name = "BuseDebitDataGridViewTextBoxColumn"
        Me.BuseDebitDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseDebitDataGridViewTextBoxColumn.Width = 80
        '
        'BuseDebitDDataGridViewTextBoxColumn
        '
        Me.BuseDebitDDataGridViewTextBoxColumn.DataPropertyName = "buseDebitD"
        Me.BuseDebitDDataGridViewTextBoxColumn.HeaderText = "buseDebitD"
        Me.BuseDebitDDataGridViewTextBoxColumn.Name = "BuseDebitDDataGridViewTextBoxColumn"
        Me.BuseDebitDDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseDebitDDataGridViewTextBoxColumn.Width = 88
        '
        'BuseDebit2barsDataGridViewTextBoxColumn
        '
        Me.BuseDebit2barsDataGridViewTextBoxColumn.DataPropertyName = "buseDebit2bars"
        Me.BuseDebit2barsDataGridViewTextBoxColumn.HeaderText = "buseDebit2bars"
        Me.BuseDebit2barsDataGridViewTextBoxColumn.Name = "BuseDebit2barsDataGridViewTextBoxColumn"
        Me.BuseDebit2barsDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseDebit2barsDataGridViewTextBoxColumn.Width = 106
        '
        'BuseDebit3barsDataGridViewTextBoxColumn
        '
        Me.BuseDebit3barsDataGridViewTextBoxColumn.DataPropertyName = "buseDebit3bars"
        Me.BuseDebit3barsDataGridViewTextBoxColumn.HeaderText = "buseDebit3bars"
        Me.BuseDebit3barsDataGridViewTextBoxColumn.Name = "BuseDebit3barsDataGridViewTextBoxColumn"
        Me.BuseDebit3barsDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseDebit3barsDataGridViewTextBoxColumn.Width = 106
        '
        'BuseAgeDataGridViewTextBoxColumn
        '
        Me.BuseAgeDataGridViewTextBoxColumn.DataPropertyName = "buseAge"
        Me.BuseAgeDataGridViewTextBoxColumn.HeaderText = "buseAge"
        Me.BuseAgeDataGridViewTextBoxColumn.Name = "BuseAgeDataGridViewTextBoxColumn"
        Me.BuseAgeDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseAgeDataGridViewTextBoxColumn.Width = 74
        '
        'BuseNbBusesDataGridViewTextBoxColumn
        '
        Me.BuseNbBusesDataGridViewTextBoxColumn.DataPropertyName = "buseNbBuses"
        Me.BuseNbBusesDataGridViewTextBoxColumn.HeaderText = "buseNbBuses"
        Me.BuseNbBusesDataGridViewTextBoxColumn.Name = "BuseNbBusesDataGridViewTextBoxColumn"
        Me.BuseNbBusesDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseNbBusesDataGridViewTextBoxColumn.Width = 98
        '
        'BuseTypeDataGridViewTextBoxColumn
        '
        Me.BuseTypeDataGridViewTextBoxColumn.DataPropertyName = "buseType"
        Me.BuseTypeDataGridViewTextBoxColumn.HeaderText = "buseType"
        Me.BuseTypeDataGridViewTextBoxColumn.Name = "BuseTypeDataGridViewTextBoxColumn"
        Me.BuseTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseTypeDataGridViewTextBoxColumn.Width = 79
        '
        'BuseAngleDataGridViewTextBoxColumn
        '
        Me.BuseAngleDataGridViewTextBoxColumn.DataPropertyName = "buseAngle"
        Me.BuseAngleDataGridViewTextBoxColumn.HeaderText = "buseAngle"
        Me.BuseAngleDataGridViewTextBoxColumn.Name = "BuseAngleDataGridViewTextBoxColumn"
        Me.BuseAngleDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseAngleDataGridViewTextBoxColumn.Width = 82
        '
        'BuseFonctionnementDataGridViewTextBoxColumn
        '
        Me.BuseFonctionnementDataGridViewTextBoxColumn.DataPropertyName = "buseFonctionnement"
        Me.BuseFonctionnementDataGridViewTextBoxColumn.HeaderText = "buseFonctionnement"
        Me.BuseFonctionnementDataGridViewTextBoxColumn.Name = "BuseFonctionnementDataGridViewTextBoxColumn"
        Me.BuseFonctionnementDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseFonctionnementDataGridViewTextBoxColumn.Width = 131
        '
        'BuseIsISODataGridViewCheckBoxColumn
        '
        Me.BuseIsISODataGridViewCheckBoxColumn.DataPropertyName = "buseIsISO"
        Me.BuseIsISODataGridViewCheckBoxColumn.HeaderText = "buseIsISO"
        Me.BuseIsISODataGridViewCheckBoxColumn.Name = "BuseIsISODataGridViewCheckBoxColumn"
        Me.BuseIsISODataGridViewCheckBoxColumn.ReadOnly = True
        Me.BuseIsISODataGridViewCheckBoxColumn.Width = 62
        '
        'ManometreMarqueDataGridViewTextBoxColumn
        '
        Me.ManometreMarqueDataGridViewTextBoxColumn.DataPropertyName = "manometreMarque"
        Me.ManometreMarqueDataGridViewTextBoxColumn.HeaderText = "manometreMarque"
        Me.ManometreMarqueDataGridViewTextBoxColumn.Name = "ManometreMarqueDataGridViewTextBoxColumn"
        Me.ManometreMarqueDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometreMarqueDataGridViewTextBoxColumn.Width = 120
        '
        'ManometreDiametreDataGridViewTextBoxColumn
        '
        Me.ManometreDiametreDataGridViewTextBoxColumn.DataPropertyName = "manometreDiametre"
        Me.ManometreDiametreDataGridViewTextBoxColumn.HeaderText = "manometreDiametre"
        Me.ManometreDiametreDataGridViewTextBoxColumn.Name = "ManometreDiametreDataGridViewTextBoxColumn"
        Me.ManometreDiametreDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometreDiametreDataGridViewTextBoxColumn.Width = 126
        '
        'ManometreTypeDataGridViewTextBoxColumn
        '
        Me.ManometreTypeDataGridViewTextBoxColumn.DataPropertyName = "manometreType"
        Me.ManometreTypeDataGridViewTextBoxColumn.HeaderText = "manometreType"
        Me.ManometreTypeDataGridViewTextBoxColumn.Name = "ManometreTypeDataGridViewTextBoxColumn"
        Me.ManometreTypeDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometreTypeDataGridViewTextBoxColumn.Width = 108
        '
        'ManometreFondEchelleDataGridViewTextBoxColumn
        '
        Me.ManometreFondEchelleDataGridViewTextBoxColumn.DataPropertyName = "manometreFondEchelle"
        Me.ManometreFondEchelleDataGridViewTextBoxColumn.HeaderText = "manometreFondEchelle"
        Me.ManometreFondEchelleDataGridViewTextBoxColumn.Name = "ManometreFondEchelleDataGridViewTextBoxColumn"
        Me.ManometreFondEchelleDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometreFondEchelleDataGridViewTextBoxColumn.Width = 143
        '
        'ManometrePressionTravailDataGridViewTextBoxColumn
        '
        Me.ManometrePressionTravailDataGridViewTextBoxColumn.DataPropertyName = "manometrePressionTravail"
        Me.ManometrePressionTravailDataGridViewTextBoxColumn.HeaderText = "manometrePressionTravail"
        Me.ManometrePressionTravailDataGridViewTextBoxColumn.Name = "ManometrePressionTravailDataGridViewTextBoxColumn"
        Me.ManometrePressionTravailDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometrePressionTravailDataGridViewTextBoxColumn.Width = 156
        '
        'ManometrePressionTravailDDataGridViewTextBoxColumn
        '
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn.DataPropertyName = "manometrePressionTravailD"
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn.HeaderText = "manometrePressionTravailD"
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn.Name = "ManometrePressionTravailDDataGridViewTextBoxColumn"
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn.ReadOnly = True
        Me.ManometrePressionTravailDDataGridViewTextBoxColumn.Width = 164
        '
        'ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsGrandeCulture"
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsGrandeCulture"
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsGrandeCultureDataGridViewCheckBoxColumn.Width = 199
        '
        'ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsLegume"
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsLegume"
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsLegumeDataGridViewCheckBoxColumn.Width = 169
        '
        'ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsElevage"
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsElevage"
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsElevageDataGridViewCheckBoxColumn.Width = 170
        '
        'ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsArboriculture"
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsArboriculture"
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsArboricultureDataGridViewCheckBoxColumn.Width = 190
        '
        'ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsViticulture"
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsViticulture"
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsViticultureDataGridViewCheckBoxColumn.Width = 177
        '
        'ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn
        '
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn.DataPropertyName = "exploitationTypeCultureIsAutres"
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn.HeaderText = "exploitationTypeCultureIsAutres"
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn.Name = "ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn"
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ExploitationTypeCultureIsAutresDataGridViewCheckBoxColumn.Width = 161
        '
        'ExploitationSauDataGridViewTextBoxColumn
        '
        Me.ExploitationSauDataGridViewTextBoxColumn.DataPropertyName = "exploitationSau"
        Me.ExploitationSauDataGridViewTextBoxColumn.HeaderText = "exploitationSau"
        Me.ExploitationSauDataGridViewTextBoxColumn.Name = "ExploitationSauDataGridViewTextBoxColumn"
        Me.ExploitationSauDataGridViewTextBoxColumn.ReadOnly = True
        Me.ExploitationSauDataGridViewTextBoxColumn.Width = 104
        '
        'DateModificationAgentDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.HeaderText = "dateModificationAgent"
        Me.DateModificationAgentDataGridViewTextBoxColumn.Name = "DateModificationAgentDataGridViewTextBoxColumn"
        Me.DateModificationAgentDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateModificationAgentDataGridViewTextBoxColumn.Width = 138
        '
        'DateModificationAgentSDataGridViewTextBoxColumn
        '
        Me.DateModificationAgentSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.HeaderText = "dateModificationAgentS"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.Name = "DateModificationAgentSDataGridViewTextBoxColumn"
        Me.DateModificationAgentSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateModificationAgentSDataGridViewTextBoxColumn.Width = 145
        '
        'DateModificationCrodipDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodip"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.Name = "DateModificationCrodipDataGridViewTextBoxColumn"
        Me.DateModificationCrodipDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateModificationCrodipDataGridViewTextBoxColumn.Width = 140
        '
        'DateModificationCrodipSDataGridViewTextBoxColumn
        '
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.DataPropertyName = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.HeaderText = "dateModificationCrodipS"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.Name = "DateModificationCrodipSDataGridViewTextBoxColumn"
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateModificationCrodipSDataGridViewTextBoxColumn.Width = 147
        '
        'DateSynchroDataGridViewTextBoxColumn
        '
        Me.DateSynchroDataGridViewTextBoxColumn.DataPropertyName = "dateSynchro"
        Me.DateSynchroDataGridViewTextBoxColumn.HeaderText = "dateSynchro"
        Me.DateSynchroDataGridViewTextBoxColumn.Name = "DateSynchroDataGridViewTextBoxColumn"
        Me.DateSynchroDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSynchroDataGridViewTextBoxColumn.Width = 92
        '
        'DateSynchroSDataGridViewTextBoxColumn
        '
        Me.DateSynchroSDataGridViewTextBoxColumn.DataPropertyName = "dateSynchroS"
        Me.DateSynchroSDataGridViewTextBoxColumn.HeaderText = "dateSynchroS"
        Me.DateSynchroSDataGridViewTextBoxColumn.Name = "DateSynchroSDataGridViewTextBoxColumn"
        Me.DateSynchroSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSynchroSDataGridViewTextBoxColumn.Width = 99
        '
        'IsSynchroDataGridViewCheckBoxColumn
        '
        Me.IsSynchroDataGridViewCheckBoxColumn.DataPropertyName = "isSynchro"
        Me.IsSynchroDataGridViewCheckBoxColumn.HeaderText = "isSynchro"
        Me.IsSynchroDataGridViewCheckBoxColumn.Name = "IsSynchroDataGridViewCheckBoxColumn"
        Me.IsSynchroDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsSynchroDataGridViewCheckBoxColumn.Width = 59
        '
        'IsATGIPDataGridViewCheckBoxColumn
        '
        Me.IsATGIPDataGridViewCheckBoxColumn.DataPropertyName = "isATGIP"
        Me.IsATGIPDataGridViewCheckBoxColumn.HeaderText = "isATGIP"
        Me.IsATGIPDataGridViewCheckBoxColumn.Name = "IsATGIPDataGridViewCheckBoxColumn"
        Me.IsATGIPDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsATGIPDataGridViewCheckBoxColumn.Width = 52
        '
        'IsTGIPDataGridViewCheckBoxColumn
        '
        Me.IsTGIPDataGridViewCheckBoxColumn.DataPropertyName = "isTGIP"
        Me.IsTGIPDataGridViewCheckBoxColumn.HeaderText = "isTGIP"
        Me.IsTGIPDataGridViewCheckBoxColumn.Name = "IsTGIPDataGridViewCheckBoxColumn"
        Me.IsTGIPDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsTGIPDataGridViewCheckBoxColumn.Width = 45
        '
        'IsFactureDataGridViewCheckBoxColumn
        '
        Me.IsFactureDataGridViewCheckBoxColumn.DataPropertyName = "isFacture"
        Me.IsFactureDataGridViewCheckBoxColumn.HeaderText = "isFacture"
        Me.IsFactureDataGridViewCheckBoxColumn.Name = "IsFactureDataGridViewCheckBoxColumn"
        Me.IsFactureDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsFactureDataGridViewCheckBoxColumn.Width = 56
        '
        'SyntheseErreurMoyenneManoDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMoyenneMano"
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMoyenneMano"
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn.Name = "SyntheseErreurMoyenneManoDataGridViewTextBoxColumn"
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMoyenneManoDataGridViewTextBoxColumn.Width = 173
        '
        'SyntheseErreurMaxiManoDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMaxiMano"
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMaxiMano"
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn.Name = "SyntheseErreurMaxiManoDataGridViewTextBoxColumn"
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMaxiManoDataGridViewTextBoxColumn.Width = 151
        '
        'SyntheseErreurDebitmetreDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurDebitmetre"
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn.HeaderText = "syntheseErreurDebitmetre"
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn.Name = "SyntheseErreurDebitmetreDataGridViewTextBoxColumn"
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurDebitmetreDataGridViewTextBoxColumn.Width = 153
        '
        'SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMoyenneCinemometre"
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMoyenneCinemometre"
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn.Name = "SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn"
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMoyenneCinemometreDataGridViewTextBoxColumn.Width = 207
        '
        'SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn
        '
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn.DataPropertyName = "syntheseUsureMoyenneBuses"
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn.HeaderText = "syntheseUsureMoyenneBuses"
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn.Name = "SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn"
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseUsureMoyenneBusesDataGridViewTextBoxColumn.Width = 175
        '
        'SyntheseNbBusesUseesDataGridViewTextBoxColumn
        '
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn.DataPropertyName = "syntheseNbBusesUsees"
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn.HeaderText = "syntheseNbBusesUsees"
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn.Name = "SyntheseNbBusesUseesDataGridViewTextBoxColumn"
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseNbBusesUseesDataGridViewTextBoxColumn.Width = 147
        '
        'SynthesePerteChargeMoyenneDataGridViewTextBoxColumn
        '
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn.DataPropertyName = "synthesePerteChargeMoyenne"
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn.HeaderText = "synthesePerteChargeMoyenne"
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn.Name = "SynthesePerteChargeMoyenneDataGridViewTextBoxColumn"
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn.ReadOnly = True
        Me.SynthesePerteChargeMoyenneDataGridViewTextBoxColumn.Width = 177
        '
        'SynthesePerteChargeMaxiDataGridViewTextBoxColumn
        '
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn.DataPropertyName = "synthesePerteChargeMaxi"
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn.HeaderText = "synthesePerteChargeMaxi"
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn.Name = "SynthesePerteChargeMaxiDataGridViewTextBoxColumn"
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn.ReadOnly = True
        Me.SynthesePerteChargeMaxiDataGridViewTextBoxColumn.Width = 155
        '
        'SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMoyenneManoD"
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMoyenneManoD"
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn.Name = "SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn"
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMoyenneManoDDataGridViewTextBoxColumn.Width = 181
        '
        'SyntheseErreurMaxiManoDDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMaxiManoD"
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMaxiManoD"
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn.Name = "SyntheseErreurMaxiManoDDataGridViewTextBoxColumn"
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMaxiManoDDataGridViewTextBoxColumn.Width = 159
        '
        'SyntheseErreurDebitmetreDDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurDebitmetreD"
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn.HeaderText = "syntheseErreurDebitmetreD"
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn.Name = "SyntheseErreurDebitmetreDDataGridViewTextBoxColumn"
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurDebitmetreDDataGridViewTextBoxColumn.Width = 161
        '
        'SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn
        '
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn.DataPropertyName = "syntheseErreurMoyenneCinemometreD"
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn.HeaderText = "syntheseErreurMoyenneCinemometreD"
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn.Name = "SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn"
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseErreurMoyenneCinemometreDDataGridViewTextBoxColumn.Width = 215
        '
        'SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn
        '
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn.DataPropertyName = "syntheseUsureMoyenneBusesD"
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn.HeaderText = "syntheseUsureMoyenneBusesD"
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn.Name = "SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn"
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseUsureMoyenneBusesDDataGridViewTextBoxColumn.Width = 183
        '
        'SyntheseNbBusesUseesDDataGridViewTextBoxColumn
        '
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn.DataPropertyName = "syntheseNbBusesUseesD"
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn.HeaderText = "syntheseNbBusesUseesD"
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn.Name = "SyntheseNbBusesUseesDDataGridViewTextBoxColumn"
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseNbBusesUseesDDataGridViewTextBoxColumn.Width = 155
        '
        'SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn
        '
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn.DataPropertyName = "synthesePerteChargeMoyenneD"
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn.HeaderText = "synthesePerteChargeMoyenneD"
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn.Name = "SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn"
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SynthesePerteChargeMoyenneDDataGridViewTextBoxColumn.Width = 185
        '
        'SynthesePerteChargeMaxiDDataGridViewTextBoxColumn
        '
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn.DataPropertyName = "synthesePerteChargeMaxiD"
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn.HeaderText = "synthesePerteChargeMaxiD"
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn.Name = "SynthesePerteChargeMaxiDDataGridViewTextBoxColumn"
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn.ReadOnly = True
        Me.SynthesePerteChargeMaxiDDataGridViewTextBoxColumn.Width = 163
        '
        'SyntheseImprecision542DataGridViewTextBoxColumn
        '
        Me.SyntheseImprecision542DataGridViewTextBoxColumn.DataPropertyName = "syntheseImprecision542"
        Me.SyntheseImprecision542DataGridViewTextBoxColumn.HeaderText = "syntheseImprecision542"
        Me.SyntheseImprecision542DataGridViewTextBoxColumn.Name = "SyntheseImprecision542DataGridViewTextBoxColumn"
        Me.SyntheseImprecision542DataGridViewTextBoxColumn.ReadOnly = True
        Me.SyntheseImprecision542DataGridViewTextBoxColumn.Width = 145
        '
        'DiagnosticItemsLstDataGridViewTextBoxColumn
        '
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn.DataPropertyName = "diagnosticItemsLst"
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn.HeaderText = "diagnosticItemsLst"
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn.Name = "DiagnosticItemsLstDataGridViewTextBoxColumn"
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticItemsLstDataGridViewTextBoxColumn.Width = 119
        '
        'DiagnosticBusesListDataGridViewTextBoxColumn
        '
        Me.DiagnosticBusesListDataGridViewTextBoxColumn.DataPropertyName = "diagnosticBusesList"
        Me.DiagnosticBusesListDataGridViewTextBoxColumn.HeaderText = "diagnosticBusesList"
        Me.DiagnosticBusesListDataGridViewTextBoxColumn.Name = "DiagnosticBusesListDataGridViewTextBoxColumn"
        Me.DiagnosticBusesListDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticBusesListDataGridViewTextBoxColumn.Width = 125
        '
        'NbreLotsBusesDataGridViewTextBoxColumn
        '
        Me.NbreLotsBusesDataGridViewTextBoxColumn.DataPropertyName = "NbreLotsBuses"
        Me.NbreLotsBusesDataGridViewTextBoxColumn.HeaderText = "NbreLotsBuses"
        Me.NbreLotsBusesDataGridViewTextBoxColumn.Name = "NbreLotsBusesDataGridViewTextBoxColumn"
        Me.NbreLotsBusesDataGridViewTextBoxColumn.ReadOnly = True
        Me.NbreLotsBusesDataGridViewTextBoxColumn.Width = 104
        '
        'DiagnosticMano542ListDataGridViewTextBoxColumn
        '
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn.DataPropertyName = "diagnosticMano542List"
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn.HeaderText = "diagnosticMano542List"
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn.Name = "DiagnosticMano542ListDataGridViewTextBoxColumn"
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticMano542ListDataGridViewTextBoxColumn.Width = 141
        '
        'DiagnosticTroncons833DataGridViewTextBoxColumn
        '
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn.DataPropertyName = "diagnosticTroncons833"
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn.HeaderText = "diagnosticTroncons833"
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn.Name = "DiagnosticTroncons833DataGridViewTextBoxColumn"
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticTroncons833DataGridViewTextBoxColumn.Width = 143
        '
        'ControleBancMesureIdDataGridViewTextBoxColumn
        '
        Me.ControleBancMesureIdDataGridViewTextBoxColumn.DataPropertyName = "controleBancMesureId"
        Me.ControleBancMesureIdDataGridViewTextBoxColumn.HeaderText = "controleBancMesureId"
        Me.ControleBancMesureIdDataGridViewTextBoxColumn.Name = "ControleBancMesureIdDataGridViewTextBoxColumn"
        Me.ControleBancMesureIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleBancMesureIdDataGridViewTextBoxColumn.Width = 139
        '
        'ControleNbreNiveauxDataGridViewTextBoxColumn
        '
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn.DataPropertyName = "controleNbreNiveaux"
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn.HeaderText = "controleNbreNiveaux"
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn.Name = "ControleNbreNiveauxDataGridViewTextBoxColumn"
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleNbreNiveauxDataGridViewTextBoxColumn.Width = 132
        '
        'ControleNbreTronconsDataGridViewTextBoxColumn
        '
        Me.ControleNbreTronconsDataGridViewTextBoxColumn.DataPropertyName = "controleNbreTroncons"
        Me.ControleNbreTronconsDataGridViewTextBoxColumn.HeaderText = "controleNbreTroncons"
        Me.ControleNbreTronconsDataGridViewTextBoxColumn.Name = "ControleNbreTronconsDataGridViewTextBoxColumn"
        Me.ControleNbreTronconsDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleNbreTronconsDataGridViewTextBoxColumn.Width = 138
        '
        'ControleUseCalibrateurDataGridViewCheckBoxColumn
        '
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn.DataPropertyName = "controleUseCalibrateur"
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn.HeaderText = "controleUseCalibrateur"
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn.Name = "ControleUseCalibrateurDataGridViewCheckBoxColumn"
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn.ReadOnly = True
        Me.ControleUseCalibrateurDataGridViewCheckBoxColumn.Width = 120
        '
        'ControleManoControleNumNationalDataGridViewTextBoxColumn
        '
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn.DataPropertyName = "controleManoControleNumNational"
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn.HeaderText = "controleManoControleNumNational"
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn.Name = "ControleManoControleNumNationalDataGridViewTextBoxColumn"
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleManoControleNumNationalDataGridViewTextBoxColumn.Width = 197
        '
        'DiagnosticHelp551DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp551DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp551"
        Me.DiagnosticHelp551DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp551"
        Me.DiagnosticHelp551DataGridViewTextBoxColumn.Name = "DiagnosticHelp551DataGridViewTextBoxColumn"
        Me.DiagnosticHelp551DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp551DataGridViewTextBoxColumn.Width = 120
        '
        'DiagnosticHelp12323DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp12323"
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp12323"
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn.Name = "DiagnosticHelp12323DataGridViewTextBoxColumn"
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp12323DataGridViewTextBoxColumn.Width = 132
        '
        'DiagnosticHelp5621DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp5621"
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp5621"
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn.Name = "DiagnosticHelp5621DataGridViewTextBoxColumn"
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp5621DataGridViewTextBoxColumn.Width = 126
        '
        'DiagnosticHelp552DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp552DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp552"
        Me.DiagnosticHelp552DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp552"
        Me.DiagnosticHelp552DataGridViewTextBoxColumn.Name = "DiagnosticHelp552DataGridViewTextBoxColumn"
        Me.DiagnosticHelp552DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp552DataGridViewTextBoxColumn.Width = 120
        '
        'DiagnosticHelp5622DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp5622"
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp5622"
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn.Name = "DiagnosticHelp5622DataGridViewTextBoxColumn"
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp5622DataGridViewTextBoxColumn.Width = 126
        '
        'DiagnosticHelp811DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp811DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp811"
        Me.DiagnosticHelp811DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp811"
        Me.DiagnosticHelp811DataGridViewTextBoxColumn.Name = "DiagnosticHelp811DataGridViewTextBoxColumn"
        Me.DiagnosticHelp811DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp811DataGridViewTextBoxColumn.Width = 120
        '
        'DiagnosticHelp8312DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp8312"
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp8312"
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn.Name = "DiagnosticHelp8312DataGridViewTextBoxColumn"
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp8312DataGridViewTextBoxColumn.Width = 126
        '
        'DiagnosticHelp8314DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp8314"
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp8314"
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn.Name = "DiagnosticHelp8314DataGridViewTextBoxColumn"
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp8314DataGridViewTextBoxColumn.Width = 126
        '
        'DiagnosticHelp571DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp571DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp571"
        Me.DiagnosticHelp571DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp571"
        Me.DiagnosticHelp571DataGridViewTextBoxColumn.Name = "DiagnosticHelp571DataGridViewTextBoxColumn"
        Me.DiagnosticHelp571DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp571DataGridViewTextBoxColumn.Width = 120
        '
        'DiagnosticHelp12123DataGridViewTextBoxColumn
        '
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn.DataPropertyName = "diagnosticHelp12123"
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn.HeaderText = "diagnosticHelp12123"
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn.Name = "DiagnosticHelp12123DataGridViewTextBoxColumn"
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticHelp12123DataGridViewTextBoxColumn.Width = 132
        '
        'DiagnosticInfosComplementairesDataGridViewTextBoxColumn
        '
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn.DataPropertyName = "diagnosticInfosComplementaires"
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn.HeaderText = "diagnosticInfosComplementaires"
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn.Name = "DiagnosticInfosComplementairesDataGridViewTextBoxColumn"
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn.ReadOnly = True
        Me.DiagnosticInfosComplementairesDataGridViewTextBoxColumn.Width = 183
        '
        'RelevePression8331DataGridViewTextBoxColumn
        '
        Me.RelevePression8331DataGridViewTextBoxColumn.DataPropertyName = "relevePression833_1"
        Me.RelevePression8331DataGridViewTextBoxColumn.HeaderText = "relevePression833_1"
        Me.RelevePression8331DataGridViewTextBoxColumn.Name = "RelevePression8331DataGridViewTextBoxColumn"
        Me.RelevePression8331DataGridViewTextBoxColumn.ReadOnly = True
        Me.RelevePression8331DataGridViewTextBoxColumn.Width = 131
        '
        'RelevePression8332DataGridViewTextBoxColumn
        '
        Me.RelevePression8332DataGridViewTextBoxColumn.DataPropertyName = "relevePression833_2"
        Me.RelevePression8332DataGridViewTextBoxColumn.HeaderText = "relevePression833_2"
        Me.RelevePression8332DataGridViewTextBoxColumn.Name = "RelevePression8332DataGridViewTextBoxColumn"
        Me.RelevePression8332DataGridViewTextBoxColumn.ReadOnly = True
        Me.RelevePression8332DataGridViewTextBoxColumn.Width = 131
        '
        'RelevePression8333DataGridViewTextBoxColumn
        '
        Me.RelevePression8333DataGridViewTextBoxColumn.DataPropertyName = "relevePression833_3"
        Me.RelevePression8333DataGridViewTextBoxColumn.HeaderText = "relevePression833_3"
        Me.RelevePression8333DataGridViewTextBoxColumn.Name = "RelevePression8333DataGridViewTextBoxColumn"
        Me.RelevePression8333DataGridViewTextBoxColumn.ReadOnly = True
        Me.RelevePression8333DataGridViewTextBoxColumn.Width = 131
        '
        'RelevePression8334DataGridViewTextBoxColumn
        '
        Me.RelevePression8334DataGridViewTextBoxColumn.DataPropertyName = "relevePression833_4"
        Me.RelevePression8334DataGridViewTextBoxColumn.HeaderText = "relevePression833_4"
        Me.RelevePression8334DataGridViewTextBoxColumn.Name = "RelevePression8334DataGridViewTextBoxColumn"
        Me.RelevePression8334DataGridViewTextBoxColumn.ReadOnly = True
        Me.RelevePression8334DataGridViewTextBoxColumn.Width = 131
        '
        'ControleInitialIdDataGridViewTextBoxColumn
        '
        Me.ControleInitialIdDataGridViewTextBoxColumn.DataPropertyName = "controleInitialId"
        Me.ControleInitialIdDataGridViewTextBoxColumn.HeaderText = "controleInitialId"
        Me.ControleInitialIdDataGridViewTextBoxColumn.Name = "ControleInitialIdDataGridViewTextBoxColumn"
        Me.ControleInitialIdDataGridViewTextBoxColumn.ReadOnly = True
        Me.ControleInitialIdDataGridViewTextBoxColumn.Width = 103
        '
        'RIFileNameDataGridViewTextBoxColumn
        '
        Me.RIFileNameDataGridViewTextBoxColumn.DataPropertyName = "RIFileName"
        Me.RIFileNameDataGridViewTextBoxColumn.HeaderText = "RIFileName"
        Me.RIFileNameDataGridViewTextBoxColumn.Name = "RIFileNameDataGridViewTextBoxColumn"
        Me.RIFileNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.RIFileNameDataGridViewTextBoxColumn.Width = 87
        '
        'SMFileNameDataGridViewTextBoxColumn
        '
        Me.SMFileNameDataGridViewTextBoxColumn.DataPropertyName = "SMFileName"
        Me.SMFileNameDataGridViewTextBoxColumn.HeaderText = "SMFileName"
        Me.SMFileNameDataGridViewTextBoxColumn.Name = "SMFileNameDataGridViewTextBoxColumn"
        Me.SMFileNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.SMFileNameDataGridViewTextBoxColumn.Width = 92
        '
        'CCFileNameDataGridViewTextBoxColumn
        '
        Me.CCFileNameDataGridViewTextBoxColumn.DataPropertyName = "CCFileName"
        Me.CCFileNameDataGridViewTextBoxColumn.HeaderText = "CCFileName"
        Me.CCFileNameDataGridViewTextBoxColumn.Name = "CCFileNameDataGridViewTextBoxColumn"
        Me.CCFileNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.CCFileNameDataGridViewTextBoxColumn.Width = 90
        '
        'ParamDiagDataGridViewTextBoxColumn
        '
        Me.ParamDiagDataGridViewTextBoxColumn.DataPropertyName = "ParamDiag"
        Me.ParamDiagDataGridViewTextBoxColumn.HeaderText = "ParamDiag"
        Me.ParamDiagDataGridViewTextBoxColumn.Name = "ParamDiagDataGridViewTextBoxColumn"
        Me.ParamDiagDataGridViewTextBoxColumn.ReadOnly = True
        Me.ParamDiagDataGridViewTextBoxColumn.Width = 84
        '
        'TotalHTDataGridViewTextBoxColumn
        '
        Me.TotalHTDataGridViewTextBoxColumn.DataPropertyName = "TotalHT"
        Me.TotalHTDataGridViewTextBoxColumn.HeaderText = "TotalHT"
        Me.TotalHTDataGridViewTextBoxColumn.Name = "TotalHTDataGridViewTextBoxColumn"
        Me.TotalHTDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalHTDataGridViewTextBoxColumn.Width = 71
        '
        'TotalTVADataGridViewTextBoxColumn
        '
        Me.TotalTVADataGridViewTextBoxColumn.DataPropertyName = "TotalTVA"
        Me.TotalTVADataGridViewTextBoxColumn.HeaderText = "TotalTVA"
        Me.TotalTVADataGridViewTextBoxColumn.Name = "TotalTVADataGridViewTextBoxColumn"
        Me.TotalTVADataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalTVADataGridViewTextBoxColumn.Width = 77
        '
        'TotalTTCDataGridViewTextBoxColumn
        '
        Me.TotalTTCDataGridViewTextBoxColumn.DataPropertyName = "TotalTTC"
        Me.TotalTTCDataGridViewTextBoxColumn.HeaderText = "TotalTTC"
        Me.TotalTTCDataGridViewTextBoxColumn.Name = "TotalTTCDataGridViewTextBoxColumn"
        Me.TotalTTCDataGridViewTextBoxColumn.ReadOnly = True
        Me.TotalTTCDataGridViewTextBoxColumn.Width = 77
        '
        'PulverisateurRegulationDataGridViewTextBoxColumn
        '
        Me.PulverisateurRegulationDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurRegulation"
        Me.PulverisateurRegulationDataGridViewTextBoxColumn.HeaderText = "pulverisateurRegulation"
        Me.PulverisateurRegulationDataGridViewTextBoxColumn.Name = "PulverisateurRegulationDataGridViewTextBoxColumn"
        Me.PulverisateurRegulationDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurRegulationDataGridViewTextBoxColumn.Width = 143
        '
        'PulverisateurRegulationOptionsDataGridViewTextBoxColumn
        '
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurRegulationOptions"
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn.HeaderText = "pulverisateurRegulationOptions"
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn.Name = "PulverisateurRegulationOptionsDataGridViewTextBoxColumn"
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurRegulationOptionsDataGridViewTextBoxColumn.Width = 179
        '
        'PulverisateurModeUtilisationDataGridViewTextBoxColumn
        '
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurModeUtilisation"
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn.HeaderText = "pulverisateurModeUtilisation"
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn.Name = "PulverisateurModeUtilisationDataGridViewTextBoxColumn"
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurModeUtilisationDataGridViewTextBoxColumn.Width = 164
        '
        'PulverisateurNbreExploitantsDataGridViewTextBoxColumn
        '
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurNbreExploitants"
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn.HeaderText = "pulverisateurNbreExploitants"
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn.Name = "PulverisateurNbreExploitantsDataGridViewTextBoxColumn"
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurNbreExploitantsDataGridViewTextBoxColumn.Width = 166
        '
        'PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn
        '
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurCoupureAutoTroncons"
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn.HeaderText = "pulverisateurCoupureAutoTroncons"
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn.Name = "PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn"
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurCoupureAutoTronconsDataGridViewTextBoxColumn.Width = 199
        '
        'PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn
        '
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurReglageAutoHauteur"
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn.HeaderText = "pulverisateurReglageAutoHauteur"
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn.Name = "PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn"
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurReglageAutoHauteurDataGridViewTextBoxColumn.Width = 192
        '
        'PulverisateurRincagecircuitDataGridViewTextBoxColumn
        '
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn.DataPropertyName = "pulverisateurRincagecircuit"
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn.HeaderText = "pulverisateurRincagecircuit"
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn.Name = "PulverisateurRincagecircuitDataGridViewTextBoxColumn"
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn.ReadOnly = True
        Me.PulverisateurRincagecircuitDataGridViewTextBoxColumn.Width = 160
        '
        'IsContrevisiteImmediateDataGridViewCheckBoxColumn
        '
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn.DataPropertyName = "isContrevisiteImmediate"
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn.HeaderText = "isContrevisiteImmediate"
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn.Name = "IsContrevisiteImmediateDataGridViewCheckBoxColumn"
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsContrevisiteImmediateDataGridViewCheckBoxColumn.Width = 123
        '
        'OrigineDiagDataGridViewTextBoxColumn
        '
        Me.OrigineDiagDataGridViewTextBoxColumn.DataPropertyName = "origineDiag"
        Me.OrigineDiagDataGridViewTextBoxColumn.HeaderText = "origineDiag"
        Me.OrigineDiagDataGridViewTextBoxColumn.Name = "OrigineDiagDataGridViewTextBoxColumn"
        Me.OrigineDiagDataGridViewTextBoxColumn.ReadOnly = True
        Me.OrigineDiagDataGridViewTextBoxColumn.Width = 85
        '
        'TypeDiagnosticDataGridViewTextBoxColumn
        '
        Me.TypeDiagnosticDataGridViewTextBoxColumn.DataPropertyName = "typeDiagnostic"
        Me.TypeDiagnosticDataGridViewTextBoxColumn.HeaderText = "typeDiagnostic"
        Me.TypeDiagnosticDataGridViewTextBoxColumn.Name = "TypeDiagnosticDataGridViewTextBoxColumn"
        Me.TypeDiagnosticDataGridViewTextBoxColumn.ReadOnly = True
        Me.TypeDiagnosticDataGridViewTextBoxColumn.Width = 102
        '
        'CodeInseeDataGridViewTextBoxColumn
        '
        Me.CodeInseeDataGridViewTextBoxColumn.DataPropertyName = "codeInsee"
        Me.CodeInseeDataGridViewTextBoxColumn.HeaderText = "codeInsee"
        Me.CodeInseeDataGridViewTextBoxColumn.Name = "CodeInseeDataGridViewTextBoxColumn"
        Me.CodeInseeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodeInseeDataGridViewTextBoxColumn.Width = 82
        '
        'BuseDebitMoyenPMDataGridViewTextBoxColumn
        '
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn.DataPropertyName = "buseDebitMoyenPM"
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn.HeaderText = "buseDebitMoyenPM"
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn.Name = "BuseDebitMoyenPMDataGridViewTextBoxColumn"
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn.ReadOnly = True
        Me.BuseDebitMoyenPMDataGridViewTextBoxColumn.Width = 128
        '
        'CommentaireDataGridViewTextBoxColumn
        '
        Me.CommentaireDataGridViewTextBoxColumn.DataPropertyName = "Commentaire"
        Me.CommentaireDataGridViewTextBoxColumn.HeaderText = "Commentaire"
        Me.CommentaireDataGridViewTextBoxColumn.Name = "CommentaireDataGridViewTextBoxColumn"
        Me.CommentaireDataGridViewTextBoxColumn.ReadOnly = True
        Me.CommentaireDataGridViewTextBoxColumn.Width = 93
        '
        'SignRIClientDataGridViewImageColumn
        '
        Me.SignRIClientDataGridViewImageColumn.DataPropertyName = "SignRIClient"
        Me.SignRIClientDataGridViewImageColumn.HeaderText = "SignRIClient"
        Me.SignRIClientDataGridViewImageColumn.Name = "SignRIClientDataGridViewImageColumn"
        Me.SignRIClientDataGridViewImageColumn.ReadOnly = True
        Me.SignRIClientDataGridViewImageColumn.Width = 71
        '
        'DateSignRIClientDataGridViewTextBoxColumn
        '
        Me.DateSignRIClientDataGridViewTextBoxColumn.DataPropertyName = "dateSignRIClient"
        Me.DateSignRIClientDataGridViewTextBoxColumn.HeaderText = "dateSignRIClient"
        Me.DateSignRIClientDataGridViewTextBoxColumn.Name = "DateSignRIClientDataGridViewTextBoxColumn"
        Me.DateSignRIClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignRIClientDataGridViewTextBoxColumn.Width = 111
        '
        'DateSignRIClientSDataGridViewTextBoxColumn
        '
        Me.DateSignRIClientSDataGridViewTextBoxColumn.DataPropertyName = "dateSignRIClientS"
        Me.DateSignRIClientSDataGridViewTextBoxColumn.HeaderText = "dateSignRIClientS"
        Me.DateSignRIClientSDataGridViewTextBoxColumn.Name = "DateSignRIClientSDataGridViewTextBoxColumn"
        Me.DateSignRIClientSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignRIClientSDataGridViewTextBoxColumn.Width = 118
        '
        'IsSignRIClientDataGridViewCheckBoxColumn
        '
        Me.IsSignRIClientDataGridViewCheckBoxColumn.DataPropertyName = "isSignRIClient"
        Me.IsSignRIClientDataGridViewCheckBoxColumn.HeaderText = "isSignRIClient"
        Me.IsSignRIClientDataGridViewCheckBoxColumn.Name = "IsSignRIClientDataGridViewCheckBoxColumn"
        Me.IsSignRIClientDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsSignRIClientDataGridViewCheckBoxColumn.Width = 78
        '
        'SignRIAgentDataGridViewImageColumn
        '
        Me.SignRIAgentDataGridViewImageColumn.DataPropertyName = "SignRIAgent"
        Me.SignRIAgentDataGridViewImageColumn.HeaderText = "SignRIAgent"
        Me.SignRIAgentDataGridViewImageColumn.Name = "SignRIAgentDataGridViewImageColumn"
        Me.SignRIAgentDataGridViewImageColumn.ReadOnly = True
        Me.SignRIAgentDataGridViewImageColumn.Width = 73
        '
        'DateSignRIAgentDataGridViewTextBoxColumn
        '
        Me.DateSignRIAgentDataGridViewTextBoxColumn.DataPropertyName = "dateSignRIAgent"
        Me.DateSignRIAgentDataGridViewTextBoxColumn.HeaderText = "dateSignRIAgent"
        Me.DateSignRIAgentDataGridViewTextBoxColumn.Name = "DateSignRIAgentDataGridViewTextBoxColumn"
        Me.DateSignRIAgentDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignRIAgentDataGridViewTextBoxColumn.Width = 113
        '
        'DateSignRIAgentSDataGridViewTextBoxColumn
        '
        Me.DateSignRIAgentSDataGridViewTextBoxColumn.DataPropertyName = "dateSignRIAgentS"
        Me.DateSignRIAgentSDataGridViewTextBoxColumn.HeaderText = "dateSignRIAgentS"
        Me.DateSignRIAgentSDataGridViewTextBoxColumn.Name = "DateSignRIAgentSDataGridViewTextBoxColumn"
        Me.DateSignRIAgentSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignRIAgentSDataGridViewTextBoxColumn.Width = 120
        '
        'IsSignRIAgentDataGridViewCheckBoxColumn
        '
        Me.IsSignRIAgentDataGridViewCheckBoxColumn.DataPropertyName = "isSignRIAgent"
        Me.IsSignRIAgentDataGridViewCheckBoxColumn.HeaderText = "isSignRIAgent"
        Me.IsSignRIAgentDataGridViewCheckBoxColumn.Name = "IsSignRIAgentDataGridViewCheckBoxColumn"
        Me.IsSignRIAgentDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsSignRIAgentDataGridViewCheckBoxColumn.Width = 80
        '
        'SignCCAgentDataGridViewImageColumn
        '
        Me.SignCCAgentDataGridViewImageColumn.DataPropertyName = "SignCCAgent"
        Me.SignCCAgentDataGridViewImageColumn.HeaderText = "SignCCAgent"
        Me.SignCCAgentDataGridViewImageColumn.Name = "SignCCAgentDataGridViewImageColumn"
        Me.SignCCAgentDataGridViewImageColumn.ReadOnly = True
        Me.SignCCAgentDataGridViewImageColumn.Width = 76
        '
        'IsSignCCAgentDataGridViewCheckBoxColumn
        '
        Me.IsSignCCAgentDataGridViewCheckBoxColumn.DataPropertyName = "isSignCCAgent"
        Me.IsSignCCAgentDataGridViewCheckBoxColumn.HeaderText = "isSignCCAgent"
        Me.IsSignCCAgentDataGridViewCheckBoxColumn.Name = "IsSignCCAgentDataGridViewCheckBoxColumn"
        Me.IsSignCCAgentDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsSignCCAgentDataGridViewCheckBoxColumn.Width = 83
        '
        'DateSignCCAgentDataGridViewTextBoxColumn
        '
        Me.DateSignCCAgentDataGridViewTextBoxColumn.DataPropertyName = "dateSignCCAgent"
        Me.DateSignCCAgentDataGridViewTextBoxColumn.HeaderText = "dateSignCCAgent"
        Me.DateSignCCAgentDataGridViewTextBoxColumn.Name = "DateSignCCAgentDataGridViewTextBoxColumn"
        Me.DateSignCCAgentDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignCCAgentDataGridViewTextBoxColumn.Width = 116
        '
        'DateSignCCAgentSDataGridViewTextBoxColumn
        '
        Me.DateSignCCAgentSDataGridViewTextBoxColumn.DataPropertyName = "dateSignCCAgentS"
        Me.DateSignCCAgentSDataGridViewTextBoxColumn.HeaderText = "dateSignCCAgentS"
        Me.DateSignCCAgentSDataGridViewTextBoxColumn.Name = "DateSignCCAgentSDataGridViewTextBoxColumn"
        Me.DateSignCCAgentSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignCCAgentSDataGridViewTextBoxColumn.Width = 123
        '
        'SignCCClientDataGridViewImageColumn
        '
        Me.SignCCClientDataGridViewImageColumn.DataPropertyName = "SignCCClient"
        Me.SignCCClientDataGridViewImageColumn.HeaderText = "SignCCClient"
        Me.SignCCClientDataGridViewImageColumn.Name = "SignCCClientDataGridViewImageColumn"
        Me.SignCCClientDataGridViewImageColumn.ReadOnly = True
        Me.SignCCClientDataGridViewImageColumn.Width = 74
        '
        'IsSignCCClientDataGridViewCheckBoxColumn
        '
        Me.IsSignCCClientDataGridViewCheckBoxColumn.DataPropertyName = "isSignCCClient"
        Me.IsSignCCClientDataGridViewCheckBoxColumn.HeaderText = "isSignCCClient"
        Me.IsSignCCClientDataGridViewCheckBoxColumn.Name = "IsSignCCClientDataGridViewCheckBoxColumn"
        Me.IsSignCCClientDataGridViewCheckBoxColumn.ReadOnly = True
        Me.IsSignCCClientDataGridViewCheckBoxColumn.Width = 81
        '
        'DateSignCCClientDataGridViewTextBoxColumn
        '
        Me.DateSignCCClientDataGridViewTextBoxColumn.DataPropertyName = "dateSignCCClient"
        Me.DateSignCCClientDataGridViewTextBoxColumn.HeaderText = "dateSignCCClient"
        Me.DateSignCCClientDataGridViewTextBoxColumn.Name = "DateSignCCClientDataGridViewTextBoxColumn"
        Me.DateSignCCClientDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignCCClientDataGridViewTextBoxColumn.Width = 114
        '
        'DateSignCCClientSDataGridViewTextBoxColumn
        '
        Me.DateSignCCClientSDataGridViewTextBoxColumn.DataPropertyName = "dateSignCCClientS"
        Me.DateSignCCClientSDataGridViewTextBoxColumn.HeaderText = "dateSignCCClientS"
        Me.DateSignCCClientSDataGridViewTextBoxColumn.Name = "DateSignCCClientSDataGridViewTextBoxColumn"
        Me.DateSignCCClientSDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateSignCCClientSDataGridViewTextBoxColumn.Width = 121
        '
        'liste_diagnosticPulve2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(641, 424)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSignature)
        Me.Controls.Add(Me.btn_selectDiagnostic_VisuDiag)
        Me.Controls.Add(Me.btn_selectDiagnostic_annuler)
        Me.Controls.Add(Me.listControle_search)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "liste_diagnosticPulve2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Crodip .::. Liste des contr�les"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsrcDiag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Function getDiagnostic() As Diagnostic
        Return m_oDiag
    End Function

    Sub searchDiagnostic(ByVal param As String)
        Try
            Dim query As String
            If param = "" Then
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat, RIFileName, SMFileName, CCFileName, IsSignRIAgent, ISSignRIClient, ISSignCCAgent, IsSignCCClient FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & oPulve.id & "' AND Diagnostic.organismePresId =" & oAgent.idStructure
            Else
                query = "SELECT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat, RIFileName, SMFileName, CCFileName, ISSignRIClient, ISSignCCAgent, IsSignCCClient FROM Diagnostic WHERE Diagnostic.pulverisateurId='" & oPulve.id & "' AND Diagnostic.organismePresId=" & oAgent.idStructure & " AND Diagnostic.id LIKE '%" & param & "%'"
            End If
            query = query & " ORDER BY Diagnostic.controleDateFin DESC"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            '            listPulveDiagnostic.Items.Clear()
            m_bsrcDiag.Clear()

            While dataResults.Read()
                Dim oDiag As New Diagnostic()

                For i As Int32 = 0 To dataResults.FieldCount - 1
                    oDiag.Fill(dataResults.GetName(i), dataResults.GetValue(i))
                Next
                m_bsrcDiag.Add(oDiag)
            End While
            dataResults.Close()
            bdd.free()
            bdd = Nothing
            Dim nRow As Integer = 0
            For Each oDiag As Diagnostic In m_bsrcDiag.List
                Select Case Trim(oDiag.controleEtat)
                    Case "-1"
                        DataGridView1.Rows(nRow).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                    Case "0"

                        DataGridView1.Rows(nRow).DefaultCellStyle.ForeColor = System.Drawing.Color.Orange
                    Case "1"
                        DataGridView1.Rows(nRow).DefaultCellStyle.ForeColor = System.Drawing.Color.Green
                End Select
                Dim oCell As DataGridViewDisableButtonCell
                oCell = DataGridView1.Rows(nRow).Cells(Col_Rapports.Index)
                oCell.Enabled = Not String.IsNullOrEmpty(oDiag.RIFileName)
                oCell.Style.ForeColor = System.Drawing.Color.White
                oCell = DataGridView1.Rows(nRow).Cells(col_SM.Index)
                oCell.Enabled = Not String.IsNullOrEmpty(oDiag.SMFileName)
                oCell.Style.ForeColor = System.Drawing.Color.White
                oCell = DataGridView1.Rows(nRow).Cells(col_contrat.Index)
                oCell.Enabled = Not String.IsNullOrEmpty(oDiag.CCFileName)
                oCell.Style.ForeColor = System.Drawing.Color.White
                oCell = DataGridView1.Rows(nRow).Cells(col_Signatures.Index)
                oCell.Enabled = Not oDiag.isSign
                oCell.Style.ForeColor = System.Drawing.Color.White
                oCell = DataGridView1.Rows(nRow).Cells(col_Details.Index)
                oCell.Style.ForeColor = System.Drawing.Color.White

                nRow = nRow + 1
            Next
        Catch ex As Exception
            CSDebug.dispError("liste_diagnosticPulve::searchDiagnostic : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub liste_diagnosticPulve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        col_Signatures.Visible = oAgent.isSignElecActive
        searchDiagnostic("")
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.Refresh()
    End Sub

    Private Sub btn_selectDiagnostic_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_annuler.Click
        Statusbar.clear()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_selectDiagnostic_VisuDiag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_selectDiagnostic_VisuDiag.Click

        DialogResult = Windows.Forms.DialogResult.Cancel
        '    If listPulveDiagnostic.SelectedItems().Count > 0 Then
        '        Try
        '            ' On r�cup�re le Diagnostic selectionn�
        '            Me.DiagMode = Globals.DiagMode.CTRL_VISU
        '            Me.DialogResult = Windows.Forms.DialogResult.OK
        '            Me.Close()

        '        Catch ex As Exception
        '            CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
        '        End Try
        '    End If
    End Sub

    Private Sub listControle_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listControle_search.TextChanged
        searchDiagnostic(Trim(listControle_search.Text.Replace(" ", "")))
    End Sub

    Private Sub btnSignature_Click(sender As Object, e As EventArgs) Handles btnSignature.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        'If listPulveDiagnostic.SelectedItems().Count > 0 Then
        '    Try
        '        ' On r�cup�re le Diagnostic selectionn�
        '        Me.DiagMode = Globals.DiagMode.CTRL_SIGNATURE
        '        Me.DialogResult = Windows.Forms.DialogResult.OK
        '        Me.Close()

        '    Catch ex As Exception
        '        CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
        '    End Try
        'End If
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim File As String = ""
        m_oDiag = m_bsrcDiag.Current
        If m_oDiag IsNot Nothing Then
            Select Case e.ColumnIndex
                Case Col_Rapports.Index
                    VisualisationRI()
                Case Col_SM.Index
                    VisualisationSM()
                Case col_contrat.Index
                    VisualisationCC()
                Case col_Signatures.Index
                    Signatures()
                Case col_Details.Index
                    DetailsRapports()
            End Select
        End If
    End Sub

    Private Sub DetailsRapports()
        If m_oDiag IsNot Nothing Then
            Try
                m_oDiag = DiagnosticManager.getDiagnosticById(m_oDiag.id)

                ' On r�cup�re le Diagnostic selectionn�
                Me.DiagMode = Globals.DiagMode.CTRL_VISU
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Signatures()
        If m_oDiag IsNot Nothing Then
            Try
                m_oDiag = DiagnosticManager.getDiagnosticById(m_oDiag.id)
                ' On r�cup�re le Diagnostic selectionn�
                Me.DiagMode = Globals.DiagMode.CTRL_SIGNATURE
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception
                CSDebug.dispError("Visualisation Diagnostic - getDiagnosticById" & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub VisualisationRI()
        If m_oDiag IsNot Nothing Then
            Try
                If Not String.IsNullOrEmpty(m_oDiag.RIFileName) Then
                    EtatCrodip.getPDFs(Globals.CONST_PATH_EXP_DIAGNOSTIC, m_oDiag.RIFileName)
                    CSFile.open(Globals.CONST_PATH_EXP_DIAGNOSTIC & m_oDiag.RIFileName)                ' On r�cup�re le Diagnostic selectionn�
                End If
            Catch ex As Exception
                CSDebug.dispError("liste_DiagnosticPulve2.VisualisationRI  ERR :" & ex.Message.ToString)
            End Try
        End If
    End Sub
    Private Sub VisualisationSM()
        If m_oDiag IsNot Nothing Then
            Try
                If Not String.IsNullOrEmpty(m_oDiag.SMFileName) Then
                    EtatCrodip.getPDFs(Globals.CONST_PATH_EXP_DIAGNOSTIC, m_oDiag.SMFileName)
                    CSFile.open(Globals.CONST_PATH_EXP_DIAGNOSTIC & m_oDiag.SMFileName)                ' On r�cup�re le Diagnostic selectionn�
                End If
            Catch ex As Exception
                CSDebug.dispError("liste_DiagnosticPulve2.VisualisationSM  ERR :" & ex.Message.ToString)
            End Try
        End If
    End Sub
    Private Sub VisualisationCC()
        If m_oDiag IsNot Nothing Then
            Try
                If Not String.IsNullOrEmpty(m_oDiag.CCFileName) Then
                    EtatCrodip.getPDFs(Globals.CONST_PATH_EXP_DIAGNOSTIC, m_oDiag.CCFileName)
                    CSFile.open(Globals.CONST_PATH_EXP_DIAGNOSTIC & m_oDiag.CCFileName)                ' On r�cup�re le Diagnostic selectionn�
                End If
            Catch ex As Exception
                CSDebug.dispError("liste_DiagnosticPulve2.VisualisationCC  ERR :" & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        m_oDiag = m_bsrcDiag.Current
        If m_oDiag IsNot Nothing Then
            Select Case e.ColumnIndex
                Case 3, 4, 5
                    DataGridView1.Cursor = Cursors.Hand
                Case Else
                    DataGridView1.Cursor = Cursors.Default
            End Select
        End If
    End Sub

End Class