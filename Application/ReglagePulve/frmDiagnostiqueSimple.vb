Imports System.Collections.Generic
Imports System.IO
''' <summary>
''' Simplification de la fenêtre frmDiagnostique 
''' utilisé par l'outil de reglagePulvé
''' Problème de performances
''' </summary>
Public Class frmDiagnostiqueSimple
    Inherits frmCRODIP
    Implements IfrmCRODIP

    ' Variables globales au diagnostique
    'Dim totalCheckboxSelected As Integer = 0
    'Dim arrCheckboxes(8, 3) As Integer
    'Dim arrAnswers(13, 12, 12, 12) As DiagnosticItem
    'Liste des controles par onglets
    Protected LstCtrl As New List(Of List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2)))
    Protected Const CHK_OK As Integer = 1

    Protected Const CHK_DEFAUT_MINEUR As Integer = 2
    Protected Const CHK_DEFAUT_MAJEUR As Integer = 3

    Protected m_modeAffichage As GlobalsCRODIP.DiagMode
    Protected typeControle As String = "Rampe"
    Protected typeJet As String = "Jet Porté"

    Protected tmpListBuses As New DiagnosticBusesList
    Protected m_RelevePression833_P1 As RelevePression833
    Protected m_RelevePression833_P2 As RelevePression833
    Protected m_RelevePression833_P3 As RelevePression833
    Protected m_RelevePression833_P4 As RelevePression833

    Protected m_Niveaux As Integer
    Protected m_Troncons As Integer
    Protected Const ROW_NIVEAUX As Integer = 0
    Protected Const ROW_TRONCONS As Integer = 1
    Protected Const ROW_PRESSION As Integer = 2
    Protected Const ROW_ECART_BAR As Integer = 3
    Protected Const ROW_ECART_PCT As Integer = 4
    Protected Const ROW_MOYENNE_PRESSION_LUE_TOUS As Integer = 5
    Protected Const ROW_MOYENNE_ECART_TOUS As Integer = 6
    Protected Const ROW_ECARTMOYEN_PCT As Integer = 7
    Protected Const ROW_SEPARATOR As Integer = 8
    Protected Const ROW_MOYENNE_ECART_AUTRE As Integer = 9
    Protected Const ROW_HETERO_BAR As Integer = 10
    Protected Const ROW_HETERO_PCT As Integer = 11
    Protected Const ROW_NPRESSION As Integer = 12
    Protected Const ROW_NB As Integer = 13
    Protected m_tbPressionManoCurrent As CRODIP_ControlLibrary.TBNumeric
    Protected m_lblDefautEcart As Label
    Protected m_lblDefautHeterogeneite As Label
    Protected m_dgvPressionCurrent As DataGridView
    Protected m_RelevePression833_Current As RelevePression833
    Protected m_tbMoyenneCurrent As CRODIP_ControlLibrary.TBNumeric
    Protected m_tbMoyEcartBarCurrent As CRODIP_ControlLibrary.TBNumeric
    Protected m_tbMoyEcartPctCurrent As CRODIP_ControlLibrary.TBNumeric

    'Protected m_PopupHelp551Mode As Integer = 0  ' O= Close, 551, 562
    'Protected m_PopupHelp552Mode As Integer = 0  ' O= Close, 551, 562
    Protected m_PopupHelp831Mode As DiagnosticHelp831.ModeHelp831 = DiagnosticHelp831.ModeHelp831.Mode8312
    Protected m_bDuringLoad As Boolean = True
    Protected m_bDuringLoad551 As Boolean = True
    Protected m_bDuringLoad552 As Boolean = True

    Protected m_oParamdiag As CRODIP_ControlLibrary.ParamDiag
    Protected m_DiagBuses As New DiagnosticBusesList()
    Protected m_referentielBuses As New ReferentielBusesCSV()
    Protected m_diagnostic As Diagnostic
    'Protected objInfos(15) As Object

    Protected m_Pulverisateur As Pulverisateur
    Protected m_Exploit As Exploitation


    Public Sub New()
        '        MyBase.New()
        m_bDuringLoad = True
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        OrganizeControls()

        m_referentielBuses.load(GlobalsCRODIP.GLOB_STR_REFERENTIELBUSES_FILENAME)
        m_bDuringLoad = False


    End Sub
    Public Sub New(ByVal _modeAffichage As String, pDiag As Diagnostic, pPulverisateur As Pulverisateur, pExploit As Exploitation)
        Me.New()
        setContexte(pDiag, _modeAffichage, pPulverisateur, pExploit)
    End Sub
    Public Sub setContexte(pDiag As Diagnostic, ByVal _modeAffichage As GlobalsCRODIP.DiagMode, pPulve As Pulverisateur, pExploit As Exploitation)
        m_modeAffichage = _modeAffichage
        m_diagnostic = pDiag
        m_Pulverisateur = pPulve
        m_Exploit = pExploit
    End Sub


#Region " Loaders "
    ''' <summary>
    ''' Organisation des controls CkeckBox en Group et en page
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OrganizeControls()
        Dim lstOnglet As List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        Dim lstGrpBox As List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'Onglet 1 'Etat General
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        'lstGrpBox.Add(RadioButton_diagnostic_2111)
        'lstGrpBox.Add(RadioButton_diagnostic_2112)
        'lstGrpBox.Add(RadioButton_diagnostic_2110)

        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2121)
        'lstGrpBox.Add(RadioButton_diagnostic_2122)
        'lstGrpBox.Add(RadioButton_diagnostic_2120)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2131)
        'lstGrpBox.Add(RadioButton_diagnostic_2132)
        'lstGrpBox.Add(RadioButton_diagnostic_2130)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2211)
        'lstGrpBox.Add(RadioButton_diagnostic_2212)
        'lstGrpBox.Add(RadioButton_diagnostic_2213)
        'lstGrpBox.Add(RadioButton_diagnostic_2210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2221)
        'lstGrpBox.Add(RadioButton_diagnostic_2222)
        'lstGrpBox.Add(RadioButton_diagnostic_2220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2231)
        'lstGrpBox.Add(RadioButton_diagnostic_2232)
        'lstGrpBox.Add(RadioButton_diagnostic_2230)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2241)
        'lstGrpBox.Add(RadioButton_diagnostic_2242)
        'lstGrpBox.Add(RadioButton_diagnostic_2240)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2251)
        'lstGrpBox.Add(RadioButton_diagnostic_2252)
        'lstGrpBox.Add(RadioButton_diagnostic_2250)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2310)
        'lstGrpBox.Add(RadioButton_diagnostic_2311)
        'lstGrpBox.Add(RadioButton_diagnostic_2312)
        'lstGrpBox.Add(RadioButton_diagnostic_2313)
        'lstGrpBox.Add(RadioButton_diagnostic_2314)
        'lstGrpBox.Add(RadioButton_diagnostic_2315)
        'lstGrpBox.Add(RadioButton_diagnostic_2316)
        'lstGrpBox.Add(RadioButton_diagnostic_2317)
        'lstGrpBox.Add(RadioButton_diagnostic_2318)
        'lstGrpBox.Add(RadioButton_diagnostic_2319)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        'lstGrpBox.Add(RadioButton_diagnostic_2321)
        'lstGrpBox.Add(RadioButton_diagnostic_2322)
        'lstGrpBox.Add(RadioButton_diagnostic_2323)
        'lstGrpBox.Add(RadioButton_diagnostic_2324)
        'lstGrpBox.Add(RadioButton_diagnostic_2325)
        'lstGrpBox.Add(RadioButton_diagnostic_2326)
        'lstGrpBox.Add(RadioButton_diagnostic_2327)
        'lstGrpBox.Add(RadioButton_diagnostic_2320)
        'lstGrpBox.Add(RadioButton_diagnostic_2329)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        'lstGrpBox.Add(RadioButton_diagnostic_2411)
        'lstGrpBox.Add(RadioButton_diagnostic_2412)
        'lstGrpBox.Add(RadioButton_diagnostic_2413)
        'lstGrpBox.Add(RadioButton_diagnostic_2414)
        'lstGrpBox.Add(RadioButton_diagnostic_2410)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2511)
        'lstGrpBox.Add(RadioButton_diagnostic_2512)
        'lstGrpBox.Add(RadioButton_diagnostic_2510)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_2521)
        'lstGrpBox.Add(RadioButton_diagnostic_2522)
        'lstGrpBox.Add(RadioButton_diagnostic_2520)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        LstCtrl.Add(lstOnglet)

        'Onglet2 Pompe/ Cuves
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_3111)
        'lstGrpBox.Add(RadioButton_diagnostic_3112)
        'lstGrpBox.Add(RadioButton_diagnostic_3110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_3211)
        'lstGrpBox.Add(RadioButton_diagnostic_3212)
        'lstGrpBox.Add(RadioButton_diagnostic_3210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_3221)
        'lstGrpBox.Add(RadioButton_diagnostic_3222)
        'lstGrpBox.Add(RadioButton_diagnostic_3223)
        'lstGrpBox.Add(RadioButton_diagnostic_3220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_3231)
        'lstGrpBox.Add(RadioButton_diagnostic_3230)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4111)
        'lstGrpBox.Add(RadioButton_diagnostic_4112)
        'lstGrpBox.Add(RadioButton_diagnostic_4113)
        'lstGrpBox.Add(RadioButton_diagnostic_4114)
        'lstGrpBox.Add(RadioButton_diagnostic_4110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4121)
        'lstGrpBox.Add(RadioButton_diagnostic_4122)
        'lstGrpBox.Add(RadioButton_diagnostic_4120)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        'lstGrpBox.Add(RadioButton_diagnostic_4211)
        'lstGrpBox.Add(RadioButton_diagnostic_4212)
        'lstGrpBox.Add(RadioButton_diagnostic_4213)
        'lstGrpBox.Add(RadioButton_diagnostic_4210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4311)
        'lstGrpBox.Add(RadioButton_diagnostic_4312)
        'lstGrpBox.Add(RadioButton_diagnostic_4313)
        'lstGrpBox.Add(RadioButton_diagnostic_4314)
        'lstGrpBox.Add(RadioButton_diagnostic_4310)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4321)
        'lstGrpBox.Add(RadioButton_diagnostic_4322)
        'lstGrpBox.Add(RadioButton_diagnostic_4320)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4410)
        'lstGrpBox.Add(RadioButton_diagnostic_4411)
        'lstGrpBox.Add(RadioButton_diagnostic_4412)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4420)
        'lstGrpBox.Add(RadioButton_diagnostic_4421)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4510)
        'lstGrpBox.Add(RadioButton_diagnostic_4511)
        'lstGrpBox.Add(RadioButton_diagnostic_4512)
        'lstGrpBox.Add(RadioButton_diagnostic_4513)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4520)
        'lstGrpBox.Add(RadioButton_diagnostic_4521)
        'lstGrpBox.Add(RadioButton_diagnostic_4522)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4610)
        'lstGrpBox.Add(RadioButton_diagnostic_4611)
        'lstGrpBox.Add(RadioButton_diagnostic_4612)
        'lstGrpBox.Add(RadioButton_diagnostic_4613)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4620)
        'lstGrpBox.Add(RadioButton_diagnostic_4621)
        'lstGrpBox.Add(RadioButton_diagnostic_4622)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4630)
        'lstGrpBox.Add(RadioButton_diagnostic_4631)
        'lstGrpBox.Add(RadioButton_diagnostic_4632)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_4640)
        'lstGrpBox.Add(RadioButton_diagnostic_4641)
        'lstGrpBox.Add(RadioButton_diagnostic_4642)
        lstOnglet.Add(lstGrpBox)



        LstCtrl.Add(lstOnglet)

        'Onglet3 Flexibles canalisations Filtres
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_6111)
        'lstGrpBox.Add(RadioButton_diagnostic_6112)
        'lstGrpBox.Add(RadioButton_diagnostic_6113)
        'lstGrpBox.Add(RadioButton_diagnostic_6110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_7111)
        'lstGrpBox.Add(RadioButton_diagnostic_7112)
        'lstGrpBox.Add(RadioButton_diagnostic_7113)
        'lstGrpBox.Add(RadioButton_diagnostic_7114)
        'lstGrpBox.Add(RadioButton_diagnostic_7115)
        'lstGrpBox.Add(RadioButton_diagnostic_7110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_7211)
        'lstGrpBox.Add(RadioButton_diagnostic_7212)
        'lstGrpBox.Add(RadioButton_diagnostic_7213)
        'lstGrpBox.Add(RadioButton_diagnostic_7214)
        'lstGrpBox.Add(RadioButton_diagnostic_7215)
        'lstGrpBox.Add(RadioButton_diagnostic_7210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_7311)
        'lstGrpBox.Add(RadioButton_diagnostic_7312)
        'lstGrpBox.Add(RadioButton_diagnostic_7313)
        'lstGrpBox.Add(RadioButton_diagnostic_7314)
        'lstGrpBox.Add(RadioButton_diagnostic_7310)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_7411)
        'lstGrpBox.Add(RadioButton_diagnostic_7412)
        'lstGrpBox.Add(RadioButton_diagnostic_7413)
        'lstGrpBox.Add(RadioButton_diagnostic_7414)
        'lstGrpBox.Add(RadioButton_diagnostic_7415)
        'lstGrpBox.Add(RadioButton_diagnostic_7410)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        LstCtrl.Add(lstOnglet)

        'Onglet4 Jets Souffleries
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        'lstGrpBox.Add(RadioButton_diagnostic_9111)
        'lstGrpBox.Add(RadioButton_diagnostic_9112)
        'lstGrpBox.Add(RadioButton_diagnostic_9113)
        'lstGrpBox.Add(RadioButton_diagnostic_9114)
        'lstGrpBox.Add(RadioButton_diagnostic_9115)
        'lstGrpBox.Add(RadioButton_diagnostic_9116)
        'lstGrpBox.Add(RadioButton_diagnostic_9110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        'lstGrpBox.Add(RadioButton_diagnostic_9121)
        'lstGrpBox.Add(RadioButton_diagnostic_9122)
        'lstGrpBox.Add(RadioButton_diagnostic_9120)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_9211)
        'lstGrpBox.Add(RadioButton_diagnostic_9212)
        'lstGrpBox.Add(RadioButton_diagnostic_9210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_9221)
        lstGrpBox.Add(RadioButton_diagnostic_9222)
        lstGrpBox.Add(RadioButton_diagnostic_9220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_10111)
        'lstGrpBox.Add(RadioButton_diagnostic_10112)
        'lstGrpBox.Add(RadioButton_diagnostic_10113)
        'lstGrpBox.Add(RadioButton_diagnostic_10114)
        'lstGrpBox.Add(RadioButton_diagnostic_10115)
        'lstGrpBox.Add(RadioButton_diagnostic_10116)
        'lstGrpBox.Add(RadioButton_diagnostic_10117)
        'lstGrpBox.Add(RadioButton_diagnostic_10110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        'lstGrpBox.Add(RadioButton_diagnostic_10121)
        'lstGrpBox.Add(RadioButton_diagnostic_10122)
        'lstGrpBox.Add(RadioButton_diagnostic_10120)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        'lstGrpBox.Add(RadioButton_diagnostic_10211)
        'lstGrpBox.Add(RadioButton_diagnostic_10212)
        'lstGrpBox.Add(RadioButton_diagnostic_10213)
        'lstGrpBox.Add(RadioButton_diagnostic_10210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        'lstGrpBox.Add(RadioButton_diagnostic_10221)
        'lstGrpBox.Add(RadioButton_diagnostic_10222)
        'lstGrpBox.Add(RadioButton_diagnostic_10223)
        'lstGrpBox.Add(RadioButton_diagnostic_10220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        LstCtrl.Add(lstOnglet)

        'Onglet5 : Mesures Commandes Regulation
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5111)
        lstGrpBox.Add(RadioButton_diagnostic_5112)
        lstGrpBox.Add(RadioButton_diagnostic_5110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5211)
        lstGrpBox.Add(RadioButton_diagnostic_5212)
        lstGrpBox.Add(RadioButton_diagnostic_5210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5221)
        lstGrpBox.Add(RadioButton_diagnostic_5222)
        lstGrpBox.Add(RadioButton_diagnostic_5223)
        lstGrpBox.Add(RadioButton_diagnostic_5220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5311)
        lstGrpBox.Add(RadioButton_diagnostic_5312)
        lstGrpBox.Add(RadioButton_diagnostic_5310)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5321)
        lstGrpBox.Add(RadioButton_diagnostic_5322)
        lstGrpBox.Add(RadioButton_diagnostic_5323)
        lstGrpBox.Add(RadioButton_diagnostic_5320)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5411)
        lstGrpBox.Add(RadioButton_diagnostic_5412)
        lstGrpBox.Add(RadioButton_diagnostic_5413)
        lstGrpBox.Add(RadioButton_diagnostic_5414)
        lstGrpBox.Add(RadioButton_diagnostic_5410)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_5421)
        lstGrpBox.Add(RadioButton_diagnostic_5422)
        lstGrpBox.Add(RadioButton_diagnostic_5423)
        lstGrpBox.Add(RadioButton_diagnostic_5420)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_5511)
        lstGrpBox.Add(RadioButton_diagnostic_5512)
        lstGrpBox.Add(RadioButton_diagnostic_5510)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_5521)
        lstGrpBox.Add(RadioButton_diagnostic_5522)
        lstGrpBox.Add(RadioButton_diagnostic_5520)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_5611)
        lstGrpBox.Add(RadioButton_diagnostic_5612)
        lstGrpBox.Add(RadioButton_diagnostic_5610)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_5621)
        lstGrpBox.Add(RadioButton_diagnostic_5622)
        lstGrpBox.Add(RadioButton_diagnostic_5620)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_5710)
        lstGrpBox.Add(RadioButton_diagnostic_5711)
        lstGrpBox.Add(RadioButton_diagnostic_5712)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        LstCtrl.Add(lstOnglet)

        'Onglet 6 Rampes
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8111)
        lstGrpBox.Add(RadioButton_diagnostic_8112)
        lstGrpBox.Add(RadioButton_diagnostic_8113)
        lstGrpBox.Add(RadioButton_diagnostic_8114)
        lstGrpBox.Add(RadioButton_diagnostic_8110)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8121)
        lstGrpBox.Add(RadioButton_diagnostic_8122)
        lstGrpBox.Add(RadioButton_diagnostic_8123)
        lstGrpBox.Add(RadioButton_diagnostic_8124)
        lstGrpBox.Add(RadioButton_diagnostic_8120)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8131)
        lstGrpBox.Add(RadioButton_diagnostic_8132)
        lstGrpBox.Add(RadioButton_diagnostic_8130)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8141)
        lstGrpBox.Add(RadioButton_diagnostic_8142)
        lstGrpBox.Add(RadioButton_diagnostic_8140)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8151)
        lstGrpBox.Add(RadioButton_diagnostic_8152)
        lstGrpBox.Add(RadioButton_diagnostic_8150)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8161)
        lstGrpBox.Add(RadioButton_diagnostic_8162)
        lstGrpBox.Add(RadioButton_diagnostic_8160)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8171)
        lstGrpBox.Add(RadioButton_diagnostic_8172)
        lstGrpBox.Add(RadioButton_diagnostic_8170)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8211)
        lstGrpBox.Add(RadioButton_diagnostic_8210)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8221)
        lstGrpBox.Add(RadioButton_diagnostic_8222)
        lstGrpBox.Add(RadioButton_diagnostic_8220)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8231)
        lstGrpBox.Add(RadioButton_diagnostic_8232)
        lstGrpBox.Add(RadioButton_diagnostic_8233)
        lstGrpBox.Add(RadioButton_diagnostic_8234)
        lstGrpBox.Add(RadioButton_diagnostic_8230)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        lstGrpBox.Add(RadioButton_diagnostic_8311)
        lstGrpBox.Add(RadioButton_diagnostic_8312)
        lstGrpBox.Add(RadioButton_diagnostic_8313)
        lstGrpBox.Add(RadioButton_diagnostic_8314)
        lstGrpBox.Add(RadioButton_diagnostic_8310)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_8321)
        lstGrpBox.Add(RadioButton_diagnostic_8322)
        lstGrpBox.Add(RadioButton_diagnostic_8323)
        lstGrpBox.Add(RadioButton_diagnostic_8320)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        lstGrpBox.Add(RadioButton_diagnostic_8331)
        lstGrpBox.Add(RadioButton_diagnostic_8332)
        lstGrpBox.Add(RadioButton_diagnostic_8333)
        lstGrpBox.Add(RadioButton_diagnostic_8334)
        lstGrpBox.Add(RadioButton_diagnostic_8330)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)


        LstCtrl.Add(lstOnglet)


        'Onglet7 Mano Tronçcons
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        LstCtrl.Add(lstOnglet)

        'Onglet8 Buses
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        LstCtrl.Add(lstOnglet)

        'Onglet9 Accesoires
        lstOnglet = New List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2))
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_11110)
        lstGrpBox.Add(RadioButton_diagnostic_11111)
        lstGrpBox.Add(RadioButton_diagnostic_11112)
        lstGrpBox.Add(RadioButton_diagnostic_11113)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_11120)
        lstGrpBox.Add(RadioButton_diagnostic_11121)
        lstGrpBox.Add(RadioButton_diagnostic_11122)
        lstGrpBox.Add(RadioButton_diagnostic_11123)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_11130)
        lstGrpBox.Add(RadioButton_diagnostic_11131)
        lstGrpBox.Add(RadioButton_diagnostic_11132)
        lstGrpBox.Add(RadioButton_diagnostic_11133)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_11140)
        lstGrpBox.Add(RadioButton_diagnostic_11141)
        lstGrpBox.Add(RadioButton_diagnostic_11142)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12110)
        lstGrpBox.Add(RadioButton_diagnostic_12111)
        lstGrpBox.Add(RadioButton_diagnostic_12112)
        lstGrpBox.Add(RadioButton_diagnostic_12113)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12120)
        lstGrpBox.Add(RadioButton_diagnostic_12121)
        lstGrpBox.Add(RadioButton_diagnostic_12122)
        lstGrpBox.Add(RadioButton_diagnostic_12123)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12130)
        lstGrpBox.Add(RadioButton_diagnostic_12131)
        lstGrpBox.Add(RadioButton_diagnostic_12132)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12210)
        lstGrpBox.Add(RadioButton_diagnostic_12211)
        lstGrpBox.Add(RadioButton_diagnostic_12212)
        lstGrpBox.Add(RadioButton_diagnostic_12213)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12220)
        lstGrpBox.Add(RadioButton_diagnostic_12221)
        lstOnglet.Add(lstGrpBox)
        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)

        lstGrpBox.Add(RadioButton_diagnostic_12310)
        lstGrpBox.Add(RadioButton_diagnostic_12311)
        lstGrpBox.Add(RadioButton_diagnostic_12312)
        lstGrpBox.Add(RadioButton_diagnostic_12313)
        lstGrpBox.Add(RadioButton_diagnostic_12314)
        lstGrpBox.Add(RadioButton_diagnostic_12315)
        lstGrpBox.Add(RadioButton_diagnostic_12316)
        lstGrpBox.Add(RadioButton_diagnostic_12317)
        lstGrpBox.Add(RadioButton_diagnostic_12318)
        lstOnglet.Add(lstGrpBox)

        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_12320)
        lstGrpBox.Add(RadioButton_diagnostic_12321)
        lstGrpBox.Add(RadioButton_diagnostic_12322)
        lstGrpBox.Add(RadioButton_diagnostic_12323)
        lstGrpBox.Add(RadioButton_diagnostic_12324)
        lstOnglet.Add(lstGrpBox)

        lstGrpBox = New List(Of CRODIP_ControlLibrary.CtrlDiag2)
        lstGrpBox.Add(RadioButton_diagnostic_12410)
        lstGrpBox.Add(RadioButton_diagnostic_12411)
        lstGrpBox.Add(RadioButton_diagnostic_12412)
        lstOnglet.Add(lstGrpBox)

        LstCtrl.Add(lstOnglet)

    End Sub
    Protected Overridable Sub Formload() Implements IfrmCRODIP.formLoad
        'Propriété a mettre obligatoirement par programme
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        'Je ne sais pas pourquoi mais cette methode est apellé lors du design des fen^tres Filles
        ' la proctection par Try Cath n'est pas suffisante
        If m_diagnostic IsNot Nothing Then
            ''Debug
            '' Mise a jour de la barre de statut
            'Statusbar.display(GlobalsCRODIP.CONST_STATUTMSG_DIAG_ENCOURS, False)
            'Lecture du paramétrage associé au pulvérisateur
            m_oParamdiag = m_Pulverisateur.getParamDiag()
            If String.IsNullOrEmpty(m_oParamdiag.fichierConfig) Then
                CSDebug.dispFatal("Impossible de Trouver le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie)
            End If
            Dim sParamFile As String = My.Settings.RepertoireParametres & "/" & m_oParamdiag.fichierConfig
            If Not System.IO.File.Exists(sParamFile) Then
                CSDebug.dispFatal("le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie & " Fichier de config " & sParamFile & "n'existe pas")
            End If
            Dim bRead As Boolean
            bRead = LectureParametresAffichage(sParamFile)
            If Not bRead Then
                CSDebug.dispFatal("Impossible de lire le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie & "fichier de config " & sParamFile)
            End If

            If m_Pulverisateur.isDiagRampe() Then
                typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE
            Else

                typeControle = Pulverisateur.CATEGORIEPULVE_ARBOVITI2
            End If

            typeJet = m_Pulverisateur.pulverisation

            ' Affichage des informations du client (i faut prendre les données dans le Diag pour avoir les infos au moment du diag)
            diag_client_raisonSociale.Text = m_diagnostic.proprietaireRaisonSociale
            diag_client_proprioSiren.Text = "M. " & m_diagnostic.proprietaireNom & " " & m_diagnostic.proprietairePrenom & " - N° SIREN : " & m_diagnostic.proprietaireNumeroSiren
            ' Affichage des informations du pulvé
            diag_pulve_numNatio.Text = m_Pulverisateur.numeroNational
            diag_pulve_marqueModele.Text = m_Pulverisateur.marque & " - " & m_Pulverisateur.modele
            diag_pulve_Type.Text = m_Pulverisateur.type
            ' Debut d'écoute controle des buses
            'For i As Integer = 1 To 48
            '    'diagBuses_mesureDebit_1_debit
            '    Try
            '        Dim tmpInputBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & i & "_debit", globFormDiagnostic)
            '        AddHandler tmpInputBox.KeyPress, AddressOf diagBuses_mesureDebit_debit_KeyPress
            '    Catch ex As Exception
            '        CSDebug.dispError("diagnostique::diagnostique_Load (Debut d'écoute controle des buses)" & ex.Message)
            '    End Try
            'Next

            ' On charge les mano de contrôle de la structure
            getListeManoControle()

            ' On charge les bancs de l'agent
            getListeBancsMesures()


            'Buses
            diagBuses_tab_categories.TabPages.Clear()

            ' Passage en mode Rampe/ArboViti
            SetDiagnostic833Type()


            'L'affichage des défaut de pressions provoque le OK sur 8334
            RadioButton_diagnostic_8330.Checked = False
            'Initialisation des Tab 5621 et 5622
            RadioButton_diagnostic_5621.Tag = "NOK"
            RadioButton_diagnostic_5622.Tag = "NOK"
            If m_diagnostic.id <> "" Then
                ' Chargement du diagnostic
                loadExistingDiag()
                RadioButton_diagnostic_5621.Tag = "OK"
                RadioButton_diagnostic_5622.Tag = "OK"
                If m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU Then
                    ' Changement des boutons
                    btn_Poursuivre.Visible = False
                    btn_Valider.Visible = True
                    btn_Valider.Text = "    Recapitulatif"
                    btn_annuler.Visible = False
                End If
            Else
                'Encodage automatique de certains controles
                encodageAutomatique()
            End If

            'Affectation des popup 551 et 552 au bon controle
            'If Not Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Contains(Me.popup_help_551) Then
            '    Me.popup_help_551.Parent.Controls.Remove(popup_help_551)
            '    Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.popup_help_551)
            'End If
            'If Not Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Contains(Me.popup_help_552) Then
            '    Me.popup_help_552.Parent.Controls.Remove(popup_help_552)
            '    Me.tabPage_diagnostique_mesureCommandesRegulation.Controls.Add(Me.popup_help_552)
            'End If

            If Not Me.tabPage_diagnostique_rampes.Controls.Contains(Me.popup_help_831) Then
                Me.popup_help_831.Parent.Controls.Remove(popup_help_831)
                Me.tabPage_diagnostique_rampes.Controls.Add(Me.popup_help_831)
            End If
            If Not Me.tabPage_diagnostique_rampes.Controls.Contains(Me.popup_help_811) Then
                Me.popup_help_811.Parent.Controls.Remove(popup_help_811)
                Me.tabPage_diagnostique_rampes.Controls.Add(Me.popup_help_811)
            End If
            checkIsOk(9)
            'Catch ex As Exception
            '    CSDebug.dispError("diagnostique_Load ERR" & ex.Message)
            '    If ex.InnerException IsNot Nothing Then
            '        CSDebug.dispError("diagnostique_Load ERR" & ex.InnerException.Message)
            '    End If
            'End Try
            m_bDuringLoad551 = False
            m_bDuringLoad552 = False
        End If

    End Sub

    Protected Overridable Sub getListeManoControle()
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByAgent(agentCourant)
        Dim positionTop As Integer = 0
        For Each tmpManoControle As ManometreControle In arrManoControle
            Dim objComboItem As New objComboItem(tmpManoControle.numeroNational, tmpManoControle.idCrodip & " - " & tmpManoControle.type & " (" & tmpManoControle.marque & ")")
            manoTroncon_listManoControle.Items.Add(objComboItem)
            'buses_listManoControle.Items.Add(objComboItem)
        Next

    End Sub

    Protected Overridable Sub getListeBancsMesures()
        Dim arrBancs As System.Collections.Generic.List(Of Banc) = BancManager.getBancByAgent(agentCourant)
        For Each tmpBanc As Banc In arrBancs
            Dim objComboItem As New objComboItem(tmpBanc.id, tmpBanc.id & " - " & tmpBanc.marque & " (" & tmpBanc.modele & ")")
            buses_listBancs.Items.Add(objComboItem)
        Next

    End Sub
    '''
    ''' Affichage des points par défauts en fonction du pulvérisateur
    ''''
    Private Function encodageAutomatique() As Boolean
        Dim bReturn As Boolean
        Try
            '============
            ' Defaut activé par défaut F(Pulvé)
            '============
            m_diagnostic.EncodageAuto()
            AfficheDiagnosticItems()

            '================================
            'Initialisation de l'onglet Buses
            '================================
            diagBuses_conf_nbCategories.Text = m_Pulverisateur.buseNbniveaux
            tbPressionMesure.Text = 3 'Pression de controle
            validNbCategories() 'Création des controles 
            For nbLot As Integer = 1 To m_Pulverisateur.buseNbniveaux
                'Initialisation de la catégorie n
                Dim Lot As String = nbLot.ToString()

                'Nombre de buses
                Dim otb As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & Lot, Me)
                otb.Text = m_Pulverisateur.nombreBuses
                valideNbBuses(nbLot, m_Pulverisateur.nombreBuses)
                'ComboBox_marque_
                Dim ocbx As ComboBox = CSForm.getControlByName("comboBox_marque_" & Lot, Me)
                If ocbx IsNot Nothing Then
                    ocbx.Items.Clear()
                    ocbx.Items.AddRange(m_referentielBuses.getMarques().ToArray())
                End If
                ocbx.Text = m_diagnostic.buseMarque
                'L'initialisation des modèles est faite par l'evenement sur la cbxMarques (changeMarqueBuseSelected)
                ocbx = CSForm.getControlByName("comboBox_modele_" & Lot, Me)
                ocbx.Text = m_diagnostic.buseModele
                'L'initialisation des couleur est faite par l'evenement sur la cbxModele (changeModeleBuseSelected)
                ocbx = CSForm.getControlByName("comboBox_couleur_" & Lot, Me)
                ocbx.Text = m_diagnostic.buseCouleur


            Next nbLot

            '===================
            'Mano833
            '====================
            If m_Pulverisateur.manometreNbniveaux <> 0 Then
                nup_niveaux.Value = m_Pulverisateur.manometreNbniveaux
            End If
            If m_Pulverisateur.manometreNbtroncons <> 0 Then
                nupTroncons.Value = m_Pulverisateur.manometreNbtroncons
            End If
            CreerNiveauxTroncons833()
            '            SetCurrentPressionControls()
            SelectTableauMesurePourDefaut()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.encodageAutomatique ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Chargement des infos d'un diagnostic existant
    Public Sub loadExistingDiag()
        Try
            ' On liste les boutons radio du form

            'RadioButton_diagnostic_5622.CheckState = CheckState.Unchecked
            'RadioButton_diagnostic_5621.CheckState = CheckState.Unchecked

            'Les Données des help 551 5621 552 5622 sont affichées lors de l'activation du popup
            'Calcul du Help 551 et 5621
            m_diagnostic.diagnosticHelp551.calc(5.0)
            m_diagnostic.diagnosticHelp5621.calc(5.0)
            'Calcul du help 552 et 5622 (Débitmetre)
            m_diagnostic.diagnosticHelp552.DebitMoyen0Bar = m_diagnostic.buseDebitD
            m_diagnostic.diagnosticHelp552.PressionMesure = m_diagnostic.manometrePressionTravailD
            m_diagnostic.diagnosticHelp552.calc()

            m_diagnostic.diagnosticHelp5622.DebitMoyen0Bar = m_diagnostic.buseDebitD
            m_diagnostic.diagnosticHelp5622.PressionMesure = m_diagnostic.manometrePressionTravailD
            m_diagnostic.diagnosticHelp5622.calc()

            'Récupération des infos de help811
            If m_diagnostic.diagnosticHelp811.hasValue() Then
                help811_largeur.Text = m_diagnostic.diagnosticHelp811.LargeurRampe
                help811_fleche.Text = m_diagnostic.diagnosticHelp811.Fleche
                calc_help_811()
            End If

            'Récupération des infos de help831
            If m_diagnostic.diagnosticHelp8312.hasValue() Then
                help831_ecartementReference.Text = m_diagnostic.diagnosticHelp8312.Ecart_reference
                help831_ecartementMax.Text = m_diagnostic.diagnosticHelp8312.Ecart_Maxi
                help831_ecartementMin.Text = m_diagnostic.diagnosticHelp8312.Ecart_Mini
                help831_ecart.Text = m_diagnostic.diagnosticHelp8312.Ecart_pct
                calc_help_831()
            End If
            ' On renseigne les synthèses des tableaux
            'pressionTronc_perteChargeMax.Text = diagnosticCourant.synthesePerteChargeMaxi
            'pressionTronc_perteChargeMoy.Text = diagnosticCourant.synthesePerteChargeMoyenne
            'pressionTronc_heterogeniteAlimentation.Text = ""

            manoPulveEcartMoyen.Text = m_diagnostic.syntheseErreurMoyenneMano
            manoPulveEcartMax.Text = m_diagnostic.syntheseErreurMaxiMano
            manopulveResultat.Text = ""

            If String.IsNullOrEmpty(m_diagnostic.manometrePressionTravail) Then
                tbPressionMesure.Text = "3"

            Else
                tbPressionMesure.Text = m_diagnostic.manometrePressionTravail
            End If
            diagBuses_debitMoyen.Text = m_diagnostic.buseDebit
            diagBuses_nbBusesUsees.Text = m_diagnostic.syntheseNbBusesUsees
            diagBuses_usureMoyBuses.Text = m_diagnostic.syntheseUsureMoyenneBuses
            diagBuses_resultat.Text = ""

            ' Chargement des infos des buses (tableau 9.2.2)
            ' Banc de controle
            Dim tmpDiagnosticBuses As DiagnosticBuses
            If Not m_diagnostic.diagnosticBusesList Is Nothing And Not m_diagnostic.diagnosticBusesList.Liste Is Nothing Then
                For Each objItem As objComboItem In buses_listBancs.Items
                    If objItem.Id = m_diagnostic.controleBancMesureId Then
                        buses_listBancs.SelectedItem = objItem
                    End If
                Next
                'Nbre de Buses
                'buses_listManoControle.SelectedValue = diagnosticCourant.BancControleId
                ' On récupère le nombre de niveau de buses
                Dim nbNiveauxBuses As Integer = 0
                For Each tmpDiagnosticBuses In m_diagnostic.diagnosticBusesList.Liste
                    nbNiveauxBuses += 1
                Next

                ' On implémente les onglets du tableau 9.2.2
                diagBuses_conf_nbCategories.Text = nbNiveauxBuses.ToString
                validNbCategories()

                ' On boucle chaque niveau
                Dim LotId As Integer = 1
                For Each tmpDiagnosticBuses In m_diagnostic.diagnosticBusesList.Liste
                    ' Récupération des contrôles
                    Dim tmpBtn_nbBusesValider As Label = CSForm.getControlByName("Button_valider_nbBuses_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_nbBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_debitNominalPourCalcul As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_debitNominal As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominal_" & LotId, diagBuses_tab_categories)
                    Dim tmpCmbBox_ecartTolere As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & LotId, diagBuses_tab_categories)
                    Dim tmpCmbBox_marque As ComboBox = CSForm.getControlByName("ComboBox_marque_" & LotId, diagBuses_tab_categories)
                    Dim tmpCmbBox_genre As ComboBox = CSForm.getControlByName("ComboBox_modele_" & LotId, diagBuses_tab_categories)
                    Dim tmpCmbBox_couleur As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_calibre As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_calibre_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_debitMoyen As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMoyen_" & LotId, diagBuses_tab_categories)
                    ' Dim tmpTxtBox_debitMini As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMini_" & LotId, diagBuses_tab_categories)
                    'Dim tmpTxtBox_debitMaxi As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMaxi_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_nbBusesUsees As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBusesUsees_" & LotId, diagBuses_tab_categories)
                    Dim tmpTxtBox_usureMoyenneBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TEXTBOX_usureMoyenneBuses_" & LotId, diagBuses_tab_categories)
                    '########################################################################################################
                    ' Alimentation des contrôles
                    '@todo : Ecart toléré
                    tmpTxtBox_nbBuses.Text = tmpDiagnosticBuses.nombre
                    tmpTxtBox_debitNominalPourCalcul.Text = tmpDiagnosticBuses.debitNominal
                    tmpTxtBox_debitNominal.Text = tmpDiagnosticBuses.debitNominal
                    tmpCmbBox_ecartTolere.Text = tmpDiagnosticBuses.ecartTolere
                    tmpTxtBox_debitMoyen.Text = "0"
                    'tmpTxtBox_debitMini.Text = "0"
                    'tmpTxtBox_debitMaxi.Text = "0"
                    tmpTxtBox_nbBusesUsees.Text = "0"
                    tmpTxtBox_usureMoyenneBuses.Text = "0"
                    tmpCmbBox_marque.Text = tmpDiagnosticBuses.marque
                    tmpCmbBox_genre.Text = tmpDiagnosticBuses.genre
                    tmpCmbBox_couleur.Text = tmpDiagnosticBuses.couleur
                    tmpTxtBox_calibre.Text = tmpDiagnosticBuses.calibre
                    validerNbBuses_Click(tmpBtn_nbBusesValider, New System.EventArgs)
                    '########################################################################################################
                    ' On charge les buses (9.2.2)
                    Dim tmpDiagnosticBusesDetail As DiagnosticBusesDetail
                    If Not tmpDiagnosticBuses.diagnosticBusesDetailList Is Nothing And Not tmpDiagnosticBuses.diagnosticBusesDetailList.Liste Is Nothing Then
                        Dim curBuse As Integer = 1
                        For Each tmpDiagnosticBusesDetail In tmpDiagnosticBuses.diagnosticBusesDetailList.Liste
                            If tmpDiagnosticBusesDetail.idLot = LotId Then
                                ' Récupération des contrôles
                                Dim tmpTxtBox_debit As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & LotId & "_" & tmpDiagnosticBusesDetail.idBuse & "_debit", diagBuses_tab_categories)
                                Dim tmpTxtBox_usure As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & LotId & "_" & tmpDiagnosticBusesDetail.idBuse & "_usure", diagBuses_tab_categories)
                                '################################################################################################
                                If tmpTxtBox_debit IsNot Nothing Then
                                    tmpTxtBox_debit.Text = tmpDiagnosticBusesDetail.debit
                                End If
                                If tmpTxtBox_usure IsNot Nothing Then
                                    tmpTxtBox_usure.Text = tmpDiagnosticBusesDetail.ecart
                                End If
                                '################################################################################################
                                curBuse += 1
                            End If
                        Next
                    End If
                    'Calcul de l'usure d'un lot
                    '                    mutCalcLot(LotId)

                    '########################################################################################################
                    LotId += 1
                Next tmpDiagnosticBuses
            End If
            'Calcul de l'usure des buses de tous les lots
            mutCalcDebitMoy()
            mutCalcUsureMoyBuses()
            mutCalcNbBusesUsee()
            '#####################################################################################################
            'Affichage du Nbre de niveaux et nbre Troncons (8.3.3)
            If m_diagnostic.controleNbreNiveaux = 0 Then
                'Si nbre de niveaux = 0 => Ancienne Version
                Dim nbreMesures As Integer
                nbreMesures = m_diagnostic.calcNbreMesuresAncienneVersion()

                If typeControle <> Pulverisateur.CATEGORIEPULVE_RAMPE Then
                    'En ArboViti, nNiveaux sur 2 troncons
                    m_diagnostic.controleNbreTroncons = 2
                    m_diagnostic.controleNbreNiveaux = CInt(nbreMesures / 2)
                Else
                    'En Rampe, 1 Niveaux sur n troncons
                    m_diagnostic.controleNbreNiveaux = 1
                    m_diagnostic.controleNbreTroncons = nbreMesures

                End If
            End If
            If m_diagnostic.controleNbreNiveaux > 0 Then
                nup_niveaux.Value = m_diagnostic.controleNbreNiveaux

            End If
            If m_diagnostic.controleNbreTroncons > 0 Then
                nupTroncons.Value = m_diagnostic.controleNbreTroncons
            End If
            CreerNiveauxTroncons833()
            '########################################################################################################
            ' Chargement tableau 5.4.2
            Affiche542()
            '########################################################################################################
            ' Chargement tableau 8.3.3
            'affichage du tableau des pressions
            Affiche833()
            'Selection de la pression par défaut
            'SelectTableauMesurePourDefaut()

            'Recalcul de l'onglet Mano
            RecalculerToutMano()
            '########################################################################################################
            AfficheDiagnosticItems()
            '###############################################


            If m_modeAffichage <> GlobalsCRODIP.DiagMode.CTRL_CV Then
                DisableControls()
            End If

            checkIsOk(1)
            checkIsOk(2)
            checkIsOk(3)
            checkIsOk(4)
            checkIsOk(5)
            checkIsOk(6)
            checkIsOk(7)
            checkIsOk(8)
            checkIsOk(9)
        Catch ex As Exception
            CSDebug.dispError("loadExistingDiag ERR" & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("loadExistingDiag ERR" & ex.InnerException.Message)
            End If
        End Try

    End Sub
    Private Function Affiche542() As Boolean
        Dim bReturn As Boolean
        Try


            'Utilisation du Calibrateur
            Me.manopulveIsUseCalibrateur.Checked = m_diagnostic.controleUseCalibrateur
            If m_diagnostic.controleUseCalibrateur Then
                'Parcours de la liste des manos de controle 
                For Each objComboItem As objComboItem In manoTroncon_listManoControle.Items
                    If objComboItem.Id = m_diagnostic.controleManoControleNumNational Then
                        manoTroncon_listManoControle.SelectedItem = objComboItem
                    End If
                Next
            End If

            'Affichage du tableau des pressions (Pression Lue)
            Dim tmpDiagnosticMano542 As DiagnosticMano542
            If Not m_diagnostic.diagnosticMano542List Is Nothing And Not m_diagnostic.diagnosticMano542List.Liste Is Nothing Then
                Dim curPression As Integer = 1
                Dim tmpTxtBox_pressionPulve As CRODIP_ControlLibrary.TBNumeric
                For Each tmpDiagnosticMano542 In m_diagnostic.diagnosticMano542List.Liste
                    ' Récupération des contrôles
                    tmpTxtBox_pressionPulve = CSForm.getControlByName("manopulvePressionPulve_" & curPression, pnl542)
                    '                tmpTxtBox_pressionControle = CSForm.getControlByName("manopulvePressionControle_" & curPression, manopulvePression_panel_manoAgent)
                    '################################################################################################
                    If Not tmpTxtBox_pressionPulve Is Nothing And tmpDiagnosticMano542.pressionPulve <> "" Then
                        tmpTxtBox_pressionPulve.Text = tmpDiagnosticMano542.pressionPulve
                    End If
                    '               If Not tmpTxtBox_pressionControle Is Nothing Then
                    'tmpTxtBox_pressionControle.Text = tmpDiagnosticMano542.pressionControle
                    'End If

                    '################################################################################################
                    curPression += 1
                Next
            End If
            'Affichage de la famille de pression
            SetFamillePressions()

            If m_diagnostic.controleUseCalibrateur Then
                'Affichage du tableau des pressions (Pression Controle) 5.4.2
                'On affiche la pression de controle, car le choix de la famille de pression RAZ les pressions de controles
                If Not m_diagnostic.diagnosticMano542List Is Nothing And Not m_diagnostic.diagnosticMano542List.Liste Is Nothing Then
                    Dim curPression As Integer = 1
                    Dim tmpTxtBox_pressionControle As CRODIP_ControlLibrary.TBNumeric
                    For Each tmpDiagnosticMano542 In m_diagnostic.diagnosticMano542List.Liste
                        ' Récupération des contrôles
                        'tmpTxtBox_pressionPulve = CSForm.getControlByName("manopulvePressionPulve_" & curPression, manopulvePression_panel_manoPulve)
                        tmpTxtBox_pressionControle = CSForm.getControlByName("manopulvePressionControle_" & curPression, manopulvePression_panel_manoAgent)
                        '################################################################################################
                        'If Not tmpTxtBox_pressionPulve Is Nothing Then
                        'tmpTxtBox_pressionPulve.Text = tmpDiagnosticMano542.pressionPulve
                        'End If
                        If Not tmpTxtBox_pressionControle Is Nothing Then
                            tmpTxtBox_pressionControle.Text = tmpDiagnosticMano542.pressionControle
                            calcDefaut542()
                        End If

                        '################################################################################################
                        curPression += 1
                    Next
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.Affiche542 ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Affichage du tableau 833
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Affiche833() As Boolean
        Dim bReturn As Boolean
        Try
            '########################################################################################################
            ' Chargement tableau 8.3.3
            'affichage du tableau des pressions
            Dim tmpDiagnosticTroncons833 As DiagnosticTroncons833
            Dim nPression As Integer
            Dim nNiveau As Integer = 0
            Dim nTroncon As Integer = 0
            If Not m_diagnostic.diagnosticTroncons833 Is Nothing And Not m_diagnostic.diagnosticTroncons833.Liste Is Nothing Then
                For Each tmpDiagnosticTroncons833 In m_diagnostic.diagnosticTroncons833.Liste
                    nPression = tmpDiagnosticTroncons833.idPression
                    'Pour compatibilité avec l'ancienne Version
                    If (nPression > 4) Then
                        nPression = nPression - 4
                    End If
                    SetCurrentPressionControls(nPression)
                    tab_833.SelectTab(nPression - 1)
                    If tmpDiagnosticTroncons833.idColumn < m_dgvPressionCurrent.Columns.Count Then
                        m_dgvPressionCurrent.CurrentCell = m_dgvPressionCurrent(CInt(tmpDiagnosticTroncons833.idColumn), ROW_PRESSION)
                        m_dgvPressionCurrent(CInt(tmpDiagnosticTroncons833.idColumn), ROW_PRESSION).Value = tmpDiagnosticTroncons833.pressionSortie
                        validatePressionTronc(nPression)
                    End If
                Next
            End If
            If m_diagnostic.diagnosticInfosComplementaires IsNot Nothing Then
                If Not String.IsNullOrEmpty(m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut) Then
                    Select Case m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut
                        Case "1"
                            rbPression1.Checked = True

                        Case "2"
                            rbPression2.Checked = True
                        Case "3"
                            rbPression3.Checked = True
                        Case "4"
                            rbPression4.Checked = True
                    End Select

                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.Affihe83 ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend le Control représentant le DiagItem
    ''' </summary>
    ''' <param name="poDiagItem"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getControlFromDiagItem(poDiagItem As DiagnosticItem) As CRODIP_ControlLibrary.CtrlDiag2
        Dim oReturn As CRODIP_ControlLibrary.CtrlDiag2
        Try

            Dim TestIdVar As String = poDiagItem.idItem & poDiagItem.itemValue
            Dim TestNameVar As String = "RadioButton_diagnostic_" & TestIdVar
            oReturn = CSForm.getControlByName(TestNameVar, Me)
        Catch ex As Exception
            CSDebug.dispWarn("Diagnostique.getControlFromDiagItem ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Affichage des Diagnostic Item
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AfficheDiagnosticItems() As Boolean
        Dim bReturn As Boolean
        Try
            ' Chargement des informations du diag
            Dim tmpDiagnosticItem As DiagnosticItem
            Dim isLoaded As Boolean = False
            If Not m_diagnostic.diagnosticItemsLst Is Nothing And Not m_diagnostic.diagnosticItemsLst.Values Is Nothing Then
                For Each tmpDiagnosticItem In m_diagnostic.diagnosticItemsLst.Values
                    If tmpDiagnosticItem IsNot Nothing Then
                        Dim tmpControl As CRODIP_ControlLibrary.CtrlDiag2 = getControlFromDiagItem(tmpDiagnosticItem)
                        If tmpControl IsNot Nothing Then
                            tmpControl.Checked = True
                            Select Case tmpDiagnosticItem.cause
                                Case "1"
                                    tmpControl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN
                                Case "2"
                                    tmpControl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX
                                Case "3"
                                    tmpControl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.TROIS
                            End Select

                        End If
                    End If
                Next
            End If

            bReturn = True
        Catch ex As Exception

            CSDebug.dispError("Diagnostique.LoadDiagnosticItems ERROR : " & ex.Message)

            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region

#Region "============================================================================================="

#End Region

#Region " Onglet Mano/Tronçon "

#Region " OLD - Loaders "

    Public Sub loaderMano()

        Dim positionTop As Integer = 0
        For i As Integer = 1 To 12

            If positionTop = 0 Then
                positionTop = 8
            Else
                positionTop = positionTop + 24
            End If

            '## Mano pulvé
            Dim tmpManoPulve As New CRODIP_ControlLibrary.TBNumeric
            tmpManoPulve.Name = "manopulvePressionPulve_" & i
            Controls.Add(tmpManoPulve)
            ' Position
            tmpManoPulve.Parent = manopulvePression_panel_manoPulve
            tmpManoPulve.Left = 16
            tmpManoPulve.Top = positionTop
            ' Taille
            tmpManoPulve.Width = 128
            '            AddHandler tmpManoPulve.TextChanged, AddressOf calcErrMano

            '## Mano Agent
            Dim tmpManoAgent As New CRODIP_ControlLibrary.TBNumeric
            tmpManoAgent.Name = "manopulvePressionAgent_" & i
            Controls.Add(tmpManoAgent)
            ' Position
            tmpManoAgent.Parent = manopulvePression_panel_manoAgent
            tmpManoAgent.Left = 16
            tmpManoAgent.Top = positionTop
            ' Taille
            tmpManoAgent.Width = 128
            'AddHandler tmpManoAgent.TextChanged, AddressOf calcErrMano

            '## Erreur
            Dim tmpErreur As New CRODIP_ControlLibrary.TBNumeric
            tmpErreur.Name = "errPression_" & i
            Controls.Add(tmpErreur)
            ' Position
            tmpErreur.Parent = manopulvePression_panel_erreur
            tmpErreur.Left = 16
            tmpErreur.Top = positionTop
            ' Taille
            tmpErreur.Width = 128
            tmpErreur.ReadOnly = True

        Next

    End Sub
    Public Sub loaderTroncon()

        For x As Integer = 2 To 3
            Dim positionTop As Integer = 0
            For i As Integer = 1 To 13

                If positionTop = 0 Then
                    positionTop = 8
                Else
                    positionTop = positionTop + 24
                End If

                '## Le label
                Dim tmpLabel As New Label
                tmpLabel.Name = "tronconPressionLue_id_" & x & "_" & i
                tmpLabel.Text = i
                Controls.Add(tmpLabel)
                ' Position
                tmpLabel.Parent = CSForm.getControlByName("manotroncon_pressionTroncon_" & x & "bar_panel_tonconId", globFormDiagnostic)
                tmpLabel.Left = 16
                tmpLabel.Top = positionTop
                ' Taille
                tmpLabel.Width = 40
                ' Apparence
                tmpLabel.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
                tmpLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                tmpLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft

                '## Pression de sortie
                Dim tmpPressionLue As New CRODIP_ControlLibrary.TBNumeric
                tmpPressionLue.Name = "tronconPressionLue_" & x & "_" & i
                Controls.Add(tmpPressionLue)
                ' Position
                tmpPressionLue.Parent = CSForm.getControlByName("manotroncon_pressionTroncon_" & x & "bar_panel_pressionSortie", globFormDiagnostic)
                tmpPressionLue.Left = 16
                tmpPressionLue.Top = positionTop
                ' Taille
                tmpPressionLue.Width = 104
                AddHandler tmpPressionLue.TextChanged, AddressOf calcEcartPressionSortie

                '## Ecart
                Dim tmpEcart As New CRODIP_ControlLibrary.TBNumeric
                tmpEcart.Name = "tronconEcart_" & x & "_" & i
                Controls.Add(tmpEcart)
                ' Position
                tmpEcart.Parent = CSForm.getControlByName("manotroncon_pressionTroncon_" & x & "bar_panel_ecart", globFormDiagnostic)
                tmpEcart.Left = 16
                tmpEcart.Top = positionTop
                ' Taille
                tmpEcart.Width = 80
                tmpEcart.ReadOnly = True

            Next
        Next
    End Sub

#End Region

#Region " 5.4.2 - Contrôle du manomètre pulvérisateur "

#Region " LOCALES VARS "

    ' Mode de calcul des pressions (Si mano calibrateur selectionné ou pas)
    Dim modePressions As String = "without_mano"
    Dim doReload As Boolean = True
    Dim doReloadBis As Boolean = True

#End Region

#Region " Calculs "

    Dim errManoPulve_isOngletFlagOk As Boolean = False
    Dim errManoPulve_isOngletFlagNok As Boolean = True
    'Private Sub calcimprecision(pmanoPulveValue As Double, pEcart As Double, ptb_Imprecision As CRODIP_ControlLibrary.TBNumeric)
    '    '===================
    '    'Pression <=2 bars 
    '    '   0.1>err>0.2 => FAIBLE
    '    '   err>0.2 => FORTE
    '    'Pression > 2 bars
    '    '   %<10 =FAIBLE
    '    '   %>10 = FORTE
    '    '==================
    '    If pmanoPulveValue <= 2 And pEcart <= 0.1 Then
    '        ptb_Imprecision.Text = "OK"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Green
    '        ptb_Imprecision.Tag = 0
    '    End If
    '    If pmanoPulveValue > 2 And pEcart <= (pmanoPulveValue * 0.05) Then
    '        ptb_Imprecision.Text = "OK"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Green
    '        ptb_Imprecision.Tag = 0
    '    End If

    '    If pmanoPulveValue <= 2 And (pEcart > 0.1 And pEcart <= 0.2) Then
    '        ptb_Imprecision.Text = "FAIBLE"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Green
    '        ptb_Imprecision.Tag = 1
    '    End If
    '    If pmanoPulveValue > 2 And (pEcart > (pmanoPulveValue * 0.05) And pEcart <= (pmanoPulveValue * 0.1)) Then
    '        ptb_Imprecision.Text = "FAIBLE"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Green
    '        ptb_Imprecision.Tag = 1
    '    End If

    '    If pmanoPulveValue <= 2 And (pEcart > 0.2) Then
    '        ptb_Imprecision.Text = "FORTE"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Red
    '        ptb_Imprecision.Tag = 2
    '    End If
    '    If pmanoPulveValue > 2 And (pEcart > (pmanoPulveValue * 0.1)) Then
    '        ptb_Imprecision.Text = "FORTE"
    '        ptb_Imprecision.BackColor = System.Drawing.Color.Red
    '        ptb_Imprecision.Tag = 2
    '    End If

    'End Sub
    Private Sub calcDefaut542()

        Dim manoPulvetextBox As New CRODIP_ControlLibrary.TBNumeric
        Dim manoAgenttextBox As New CRODIP_ControlLibrary.TBNumeric
        Dim imprecisiontextBox As New CRODIP_ControlLibrary.TBNumeric
        Dim EcartTextBox As New CRODIP_ControlLibrary.TBNumeric()
        Dim oLstMano542 As New DiagnosticMano542List()
        Dim oCalc542 As New DiagnosticMano542()
        '==============================
        'MAJ de l'imprécision des Mano
        '==============================
        Try
            oLstMano542 = New DiagnosticMano542List()
            For i As Integer = 1 To 4
                ' On récupère l'id
                'Selection des CRODIP_ControlLibrary.TBNumeric
                Select Case i
                    Case 1
                        manoPulvetextBox = manopulvePressionPulve_1
                        manoAgenttextBox = manopulvePressionControle_1
                        imprecisiontextBox = manopulvePressionImprecision_1
                        EcartTextBox = manopulvePressionEcart_1
                    Case 2
                        manoPulvetextBox = manopulvePressionPulve_2
                        manoAgenttextBox = manopulvePressionControle_2
                        imprecisiontextBox = manopulvePressionImprecision_2
                        EcartTextBox = manopulvePressionEcart_2
                    Case 3
                        manoPulvetextBox = manopulvePressionPulve_3
                        manoAgenttextBox = manopulvePressionControle_3
                        imprecisiontextBox = manopulvePressionImprecision_3
                        EcartTextBox = manopulvePressionEcart_3
                    Case 4
                        manoPulvetextBox = manopulvePressionPulve_4
                        manoAgenttextBox = manopulvePressionControle_4
                        imprecisiontextBox = manopulvePressionImprecision_4
                        EcartTextBox = manopulvePressionEcart_4
                End Select

                ' Imprecision d'un Mano 542
                oCalc542 = New DiagnosticMano542(manoPulvetextBox.Text, manoAgenttextBox.Text)
                oLstMano542.Liste.Add(oCalc542)
            Next i
            oLstMano542.CalcImprecisionNew(m_oParamdiag.ParamDiagCalc542)
            For i As Integer = 1 To 4
                oCalc542 = oLstMano542.Liste(i - 1)
                Select Case i
                    Case 1
                        manoPulvetextBox = manopulvePressionPulve_1
                        manoAgenttextBox = manopulvePressionControle_1
                        imprecisiontextBox = manopulvePressionImprecision_1
                        EcartTextBox = manopulvePressionEcart_1
                    Case 2
                        manoPulvetextBox = manopulvePressionPulve_2
                        manoAgenttextBox = manopulvePressionControle_2
                        imprecisiontextBox = manopulvePressionImprecision_2
                        EcartTextBox = manopulvePressionEcart_2
                    Case 3
                        manoPulvetextBox = manopulvePressionPulve_3
                        manoAgenttextBox = manopulvePressionControle_3
                        imprecisiontextBox = manopulvePressionImprecision_3
                        EcartTextBox = manopulvePressionEcart_3
                    Case 4
                        manoPulvetextBox = manopulvePressionPulve_4
                        manoAgenttextBox = manopulvePressionControle_4
                        imprecisiontextBox = manopulvePressionImprecision_4
                        EcartTextBox = manopulvePressionEcart_4
                End Select
                'Si le champs n'est pas renseigné , le calcul a bien été effectué mais on affiche par l'erreur
                If Not String.IsNullOrEmpty(manoAgenttextBox.Text) Then
                    EcartTextBox.Text = oCalc542.Ecart
                    imprecisiontextBox.Text = DiagnosticMano542.GetErreurLabel(oCalc542.Erreur)
                    imprecisiontextBox.Tag = oCalc542.Erreur
                    Select Case oCalc542.Erreur
                        Case DiagnosticMano542.ERR542.FAIBLE
                            imprecisiontextBox.BackColor = System.Drawing.Color.Green
                        Case DiagnosticMano542.ERR542.FORTE
                            imprecisiontextBox.BackColor = System.Drawing.Color.Red
                        Case DiagnosticMano542.ERR542.OK
                            imprecisiontextBox.BackColor = System.Drawing.Color.Green
                    End Select
                End If

            Next i

        Catch ex As Exception
            'manoPulveResetValues_line(idMesure)
            '            CSDebug.dispError("Mano/Tronçon - Err calcErrMano : " & ex.Message.ToString)
        End Try

        'Calcul de l'imprecision des 4 mesures
        Try
            Dim ecartMoyen As Double = 0
            Dim errMax As Double = 0
            Dim errMin As Double = 10000
            Dim errTotal As Double = 0
            Dim errNb As Integer = 0
            Dim imprecisionMax As Integer = 0
            Dim allOk As Boolean = True

            'Calcul du résultat
            manoPulveEcartMoyen.Text = oLstMano542.EcartMoy
            manoPulveEcartMax.Text = oLstMano542.EcartMax
            'Définitiion du Défaut
            'Dim valueBarManoTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionPulve_" & idMano, Panel48)
            'RadioButton_diagnostic_5421.Checked = False
            RadioButton_diagnostic_5422.Checked = False
            RadioButton_diagnostic_5423.Checked = False
            RadioButton_diagnostic_5420.Checked = False
            If oLstMano542.Result = DiagnosticMano542.ERR542.OK Then
                manopulveResultat.Text = "OK"
                manopulveResultat.ForeColor = System.Drawing.Color.Green
                If Not m_bDuringLoad Then
                    RadioButton_diagnostic_5420.Checked = True
                End If
            End If
            If oLstMano542.Result = DiagnosticMano542.ERR542.FAIBLE Then
                manopulveResultat.Text = "FAIBLE"
                manopulveResultat.ForeColor = System.Drawing.Color.LightCoral
                If Not m_bDuringLoad Then
                    RadioButton_diagnostic_5422.Checked = True
                End If
            End If
            If oLstMano542.Result = DiagnosticMano542.ERR542.FORTE Then
                manopulveResultat.Text = "IMPORTANTE"
                If Not m_bDuringLoad Then
                    RadioButton_diagnostic_5423.Checked = True
                End If
                manopulveResultat.ForeColor = System.Drawing.Color.Red
            End If
            checkIsOk(7)


            m_diagnostic.syntheseErreurMoyenneMano = oLstMano542.EcartMoy.ToString
            m_diagnostic.syntheseErreurMaxiMano = oLstMano542.EcartMax.ToString
        Catch ex As Exception
            'CSDebug.dispError("Mano/Tronçon - Err calcErrMano (moyennes) : " & ex.Message.ToString)
        End Try

    End Sub



#End Region

#Region " Mano Controle Event "


    ' RESETS
    Public Sub manoPulveResetValues_line(ByVal numLine As Integer)
        Try
            Dim manopulvePressionEcart As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionEcart_" & numLine, Panel48)
            Dim manopulvePressionImprecision As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionImprecision_" & numLine, Panel48)
            manopulvePressionEcart.Text = ""
            manopulvePressionImprecision.Text = ""
            manopulvePressionImprecision.BackColor = System.Drawing.SystemColors.Control

            Dim isEmpty As Boolean = True
            For i As Integer = 1 To 4
                Dim tmpManopulvePressionLue As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionLue_" & i, Panel48)
                If tmpManopulvePressionLue.Text <> "" Then
                    isEmpty = False
                End If
            Next
            If isEmpty = True Then
                manoPulveResetValues_results()
            End If
        Catch ex As Exception
            CSDebug.dispError("manoPulveResetValues_line ERR : " & ex.Message.ToString)
        End Try
    End Sub
    Public Sub manoPulveResetValues_results()
        manoPulveEcartMoyen.Text = ""
        manoPulveEcartMax.Text = ""
        manopulveResultat.Text = ""
    End Sub

#End Region

#Region " Selection Pression "



    ''' <summary>
    ''' Selectionne le type de saisie de pression en fonction des pressions lues
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetFamillePressions()
        Try


            If manopulvePressionPulve_1.Text = "5" And
                manopulvePressionPulve_2.Text = "10" And
                manopulvePressionPulve_3.Text = "15" And
                manopulvePressionPulve_4.Text = "20" Then

                manopulveIsFortePression.Checked = True

            ElseIf (manopulvePressionPulve_1.Text = "1,6" Or manopulvePressionPulve_1.Text = "1.6") And
                   manopulvePressionPulve_2.Text = "2" And
                   manopulvePressionPulve_3.Text = "3" And
                   manopulvePressionPulve_4.Text = "4" Then

                manopulveIsFaiblePression.Checked = True

            Else
                manopulveIsSaisieManuelle.Checked = True
            End If

        Catch ex As Exception
            CSDebug.dispError("SetFamillePressions ERR : " & ex.Message.ToString)
        End Try
    End Sub
#End Region

#Region " Contrôles de saisie "

    ' CRODIP_ControlLibrary.TBNumeric Numérique
    Private Sub TextBoxNumeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
Handles manopulvePressionPulve_1.KeyPress, manopulvePressionPulve_2.KeyPress, manopulvePressionPulve_3.KeyPress, manopulvePressionPulve_4.KeyPress, manopulvePressionControle_1.KeyPress, manopulvePressionControle_2.KeyPress, manopulvePressionControle_3.KeyPress, manopulvePressionControle_4.KeyPress
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

    Private Sub gdvPressions1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)


    End Sub


#End Region

#Region " EmulReadOnly "

    Private Sub manopulvePressionEcart_1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionEcart_2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionEcart_3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionEcart_4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionImprecision_1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionImprecision_2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionImprecision_3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub manopulvePressionImprecision_4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

#End Region

#End Region

#Region " 8.3.3 - Pression aux sorties des tronçons "

#Region " Calculs "


    Private Sub calcEcartPressionSortie(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If sender.Text <> "" Then
                ' On récupère les id
                Dim tmp() As String = Split(sender.Name.Replace("pressionTronc_", ""), "_pressionSortie_")
                Dim pressionId As Integer = CType(tmp(0), Integer)
                Dim buseId As Integer = CType(tmp(1), Integer)

                ' On récupère les controles
                Dim pressionManotextbox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionPulve_" & pressionId, tabPage_diagnostique_manoTroncon)
                Dim perteChargetextbox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_ecart_" & buseId, tabPage_diagnostique_manoTroncon)

                ' On récupère les données
                Dim pressionManoValue As Double
                If pressionManotextbox.Text <> "" Then
                    pressionManoValue = CType(pressionManotextbox.Text, Double)
                Else
                    pressionManoValue = 0
                End If
                Dim pressionLueValue As Double
                If sender.Text <> "" Then
                    pressionLueValue = CType(sender.Text, Double)
                Else
                    pressionLueValue = 0
                End If

                ' On calcul
                If pressionLueValue = 0 Or pressionManoValue = 0 Then
                    perteChargetextbox.Text = ""
                Else
                    Dim perteCharge As Double = Math.Abs(Math.Round(pressionLueValue - pressionManoValue, 2))
                    perteChargetextbox.Text = perteCharge
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcEcartPressionSortie : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub calcPerteCharge(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If sender.Text <> "" Then
                ' On récupère les id
                Dim tmp() As String = Split(sender.Name.Replace("pressionTronc_", ""), "_pressionSortie_")
                Dim pressionId As Integer = CType(tmp(0), Integer)
                Dim buseId As Integer = CType(tmp(1), Integer)

                ' On récupère les controles
                Dim pressionManoTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionLue_" & pressionId, tabPage_diagnostique_manoTroncon)
                Dim perteChargeTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_perteCharge_" & buseId, tabPage_diagnostique_manoTroncon)

                ' On récupère les données
                Dim pressionManoValue As Double
                If pressionManoTextBox.Text <> "" Then
                    pressionManoValue = CType(pressionManoTextBox.Text, Double)
                Else
                    pressionManoValue = 0
                End If
                Dim pressionLueValue As Double
                If sender.Text <> "" Then
                    pressionLueValue = CType(sender.Text, Double)
                Else
                    pressionLueValue = 0
                End If

                If pressionManoValue = 0 Or pressionLueValue = 0 Then
                    perteChargeTextBox.Text = ""
                Else
                    ' On calcul
                    Dim perteCharge As Double = Math.Abs(Math.Round(pressionLueValue - pressionManoValue, 2))
                    perteChargeTextBox.Text = perteCharge
                End If

            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcPerteCharge : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub calcPressionsMoy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If sender.Text <> "" Then
                ' On récupère les id
                Dim tmp() As String = Split(sender.Name.Replace("pressionTronc_", ""), "_pressionSortie_")
                Dim pressionId As Integer = CType(tmp(0), Integer)
                Dim buseId As Integer = CType(tmp(1), Integer)

                If pressionTroncons_checkIsAllFilled(pressionId) Then

                    ' On récupère les controles
                    Dim pressionManoMoyTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_moyPression", tabPage_diagnostique_manoTroncon)

                    ' On récupère les données
                    Dim pressionMoyenne As Double = 0
                    Dim nbBusesEffect As Integer = 0
                    Dim nbBuses As Integer = 12
                    If pressionId > 4 Then
                        nbBuses = 24
                    End If
                    For i As Integer = 1 To nbBuses
                        Try
                            Dim pressionManoTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_pressionSortie_" & i, tabPage_diagnostique_manoTroncon)
                            If pressionManoTextBox.Text <> "" Then
                                nbBusesEffect += 1
                                Dim pressionManoValue As Double = GlobalsCRODIP.StringToDouble(pressionManoTextBox.Text)
                                pressionMoyenne += pressionManoValue
                            End If
                        Catch ex As Exception
                            CSDebug.dispWarn("diagnostique::calcPressionsMoy : " & ex.Message.ToString)
                        End Try
                    Next
                    pressionMoyenne = Math.Abs(Math.Round(pressionMoyenne / nbBusesEffect, 2))

                    ' On calcul
                    pressionManoMoyTextBox.Text = pressionMoyenne

                    ' Si pas de mano, la moyenne est transmise au tableau du dessus
                    Dim isWithMano As Boolean = False
                    If modePressions <> "without_mano" Then
                        isWithMano = True
                    End If
                    If Not isWithMano Then
                        doReload = False
                        If pressionId = 1 Or pressionId = 5 Then
                            manopulvePressionControle_1.Text = pressionMoyenne
                        ElseIf pressionId = 2 Or pressionId = 6 Then
                            manopulvePressionControle_2.Text = pressionMoyenne
                        ElseIf pressionId = 3 Or pressionId = 7 Then
                            manopulvePressionControle_3.Text = pressionMoyenne
                        ElseIf pressionId = 4 Or pressionId = 8 Then
                            manopulvePressionControle_4.Text = pressionMoyenne
                        End If
                        doReload = True
                    End If

                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcPressionsMoy : " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub calcPerteChargeMoyMaxADEL(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If sender.Text <> "" Then
                ' On récupère les id
                Dim tmp() As String = Split(sender.Name.Replace("pressionTronc_", ""), "_pressionSortie_")
                Dim pressionId As Integer = CType(tmp(0), Integer)
                Dim buseId As Integer = CType(tmp(1), Integer)
                If pressionTroncons_checkIsAllFilled(pressionId) Then
                    ' On récupère les controles
                    Dim perteChargeMoyenne As Double = 0
                    Dim perteChargeMax As Double = 0
                    Dim nbBusesEffect As Integer = 0
                    Dim nbBuses As Integer = 12
                    If pressionId > 4 Then
                        nbBuses = 24
                    End If
                    For i As Integer = 1 To nbBuses
                        Try
                            Dim perteChargeTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_perteCharge_" & i, tabPage_diagnostique_manoTroncon)
                            If perteChargeTextBox.Text <> "" Then
                                nbBusesEffect += 1
                                Dim perteChargeValue As Double = CType(perteChargeTextBox.Text, Double)
                                perteChargeMoyenne += perteChargeValue
                                If Math.Abs(perteChargeValue) > Math.Abs(perteChargeMax) Then
                                    perteChargeMax = Math.Abs(perteChargeValue)
                                End If
                            End If
                        Catch ex As Exception
                            CSDebug.dispWarn("diagnostique::calcPerteChargeMoyMax : " & ex.Message.ToString)
                        End Try
                    Next

                    If nbBusesEffect > 0 Then

                        perteChargeMoyenne = Math.Abs(Math.Round(perteChargeMoyenne / nbBusesEffect, 2))

                        ' Affichage résultats
                        Dim perteChargeMoyTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_perteChargeMoy", tabPage_diagnostique_manoTroncon)
                        Dim perteChargeMaxTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_perteChargeMax", tabPage_diagnostique_manoTroncon)
                        perteChargeMoyTextBox.Text = perteChargeMoyenne
                        perteChargeMaxTextBox.Text = perteChargeMax

                    End If

                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcPerteChargeMoyMax : " & ex.Message.ToString)
        End Try
    End Sub

    Dim calcBuseIsOk_isDefault(8) As Boolean
    Dim calcBuseIsOk_isOk(8) As Boolean
    Private Sub calcBuseIsOk(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''CSDebug.dispInfo("diagnostique::calcBuseIsOk ")
        Try
            ' On récupère les id
            Dim tmp() As String = Split(sender.Name.Replace("pressionTronc_", ""), "_pressionSortie_")
            Dim pressionId As Integer = CType(tmp(0), Integer)
            Dim buseId As Integer = CType(tmp(1), Integer)
            ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "pressionTroncons_checkIsAllFilled")
            If pressionTroncons_checkIsAllFilled(pressionId) Then
                ' On récupère les controles
                Dim moyPressionTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_moyPression", tabPage_diagnostique_manoTroncon)
                Dim calibrEcraseMoyenneTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionLue_" & pressionId, tabPage_diagnostique_manoTroncon)
                Dim isCalibrCheckbox As CheckBox = CSForm.getControlByName("manopulveIsUseCalibrateur", Me)
                ' On récupère les données
                If moyPressionTextBox.Text = "" Then
                    Exit Try
                End If

                Dim moyPressionValue As Double
                If isCalibrCheckbox.Checked Then
                    moyPressionValue = CType(calibrEcraseMoyenneTextBox.Text, Double)
                Else
                    moyPressionValue = CType(moyPressionTextBox.Text, Double)
                End If

                Dim maxPressionValue As Double = 0
                Dim minPressionValue As Double = 10000
                Dim maxEcartValue As Double = 0
                Dim pressionManoValue As Double

                Dim pressionManoTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("manopulvePressionPulve_" & pressionId, tabPage_diagnostique_manoTroncon)
                If pressionManoTextBox.Text <> "" Then
                    pressionManoValue = CType(pressionManoTextBox.Text, Double)
                Else
                    pressionManoValue = 0
                End If

                ' On boucle les buses
                ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "Boucle sur les buses")
                Dim nbBuses As Integer = 12
                If pressionId > 4 Then
                    nbBuses = 24
                End If
                For i As Integer = 1 To nbBuses
                    ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "Boucle sur les buses" & i)
                    Try
                        Dim pressionTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_pressionSortie_" & i, tabPage_diagnostique_manoTroncon)
                        If pressionTextBox.Text <> "" Then
                            Dim pressionValue As Double = CType(pressionTextBox.Text, Double)
                            Dim ecartTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_ecart_" & i, tabPage_diagnostique_manoTroncon)
                            If ecartTextBox.Text <> "" Then

                                'Recalcul de la moyenne sans l'element courant
                                Dim cptTextBox As Integer = 0
                                Dim textboxLeft As Boolean = True
                                Dim cptBoucle As Integer = 1
                                Dim tmpTextBox As CRODIP_ControlLibrary.TBNumeric
                                ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "Boucle sur les buses" & i & "Boucle sur les pressions")
                                Do While textboxLeft
                                    tmpTextBox = CSForm.getControlByName("pressionTronc_" & pressionId & "_pressionSortie_" & cptBoucle, tabPage_diagnostique_manoTroncon)
                                    If tmpTextBox Is Nothing Then
                                        textboxLeft = False
                                    Else
                                        cptBoucle = cptBoucle + 1
                                        If tmpTextBox.Text <> "" Then
                                            cptTextBox = cptTextBox + 1
                                        Else
                                            textboxLeft = False
                                        End If
                                    End If
                                Loop
                                ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "Boucle sur les buses" & i & "Boucle sur les pressions FIN")

                                Dim moyenneRelative As Double

                                If isCalibrCheckbox.Checked Then
                                    moyenneRelative = moyPressionValue
                                Else
                                    moyenneRelative = ((moyPressionValue * cptTextBox) - pressionValue) / (cptTextBox - 1)
                                End If

                                ' Calcul pourcentage ecart
                                Dim ecartValue As Double = Math.Abs(pressionValue - moyenneRelative)
                                Dim pourcentageEcart As Double = ecartValue / moyenneRelative * 100

                                If pourcentageEcart > maxEcartValue Then
                                    maxEcartValue = pourcentageEcart
                                End If
                                If pressionValue > maxPressionValue Then
                                    maxPressionValue = pressionValue
                                End If
                                If pressionValue < minPressionValue Then
                                    minPressionValue = pressionValue
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        CSDebug.dispWarn("diagnostique::calcBuseIsOk 1 : " & ex.Message.ToString)
                    End Try
                Next
                ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "Boucle sur les buses" & "FIN")


                Dim resultLabel As Label = CSForm.getControlByName("pressionTronc_" & pressionId & "_heteroAlim", tabPage_diagnostique_manoTroncon)
                'If Math.Abs(minPressionValue - moyPressionValue) > 0.15 * moyPressionValue Or Math.Abs(maxPressionValue - moyPressionValue) > 0.15 * moyPressionValue Then

                ''CSDebug.dispInfo("=================================================")
                ''CSDebug.dispInfo("8.3.3 Pression Id (" & pressionId & ")")
                ''CSDebug.dispInfo("8.3.3 Pression Min : " & minPressionValue)
                ''CSDebug.dispInfo("8.3.3 Pression Max : " & maxPressionValue)
                ''CSDebug.dispInfo("8.3.3 Pression Moyenne : " & moyPressionValue)
                ''CSDebug.dispInfo("=================================================")
                If typeJet = Pulverisateur.PULVERISATION_JETPORTE Then
                    If maxEcartValue >= 10 Then
                        resultLabel.Text = "DEFAUT"
                        resultLabel.ForeColor = System.Drawing.Color.Red
                        calcBuseIsOk_isOk(pressionId) = False
                        calcBuseIsOk_isDefault(pressionId) = True
                        'arrCheckboxes(7, 3) += 1
                        checkIsOk(7)
                    Else
                        resultLabel.Text = "OK"
                        resultLabel.ForeColor = System.Drawing.Color.Green
                        calcBuseIsOk_isOk(pressionId) = True
                        calcBuseIsOk_isDefault(pressionId) = False
                        'arrCheckboxes(7, 1) += 1
                        checkIsOk(7)
                    End If
                Else
                    If maxEcartValue >= 15 Then
                        resultLabel.Text = "DEFAUT"
                        resultLabel.ForeColor = System.Drawing.Color.Red
                        calcBuseIsOk_isOk(pressionId) = False
                        calcBuseIsOk_isDefault(pressionId) = True
                        'arrCheckboxes(7, 3) += 1
                        checkIsOk(7)
                    Else
                        resultLabel.Text = "OK"
                        resultLabel.ForeColor = System.Drawing.Color.Green
                        calcBuseIsOk_isOk(pressionId) = True
                        calcBuseIsOk_isDefault(pressionId) = False
                        'arrCheckboxes(7, 1) += 1
                        checkIsOk(7)
                    End If
                End If
            End If
            ''CSDebug.dispInfo("diagnostique::calcBuseIsOk :" & "FIN")
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcBuseIsOk 2 : " & ex.Message.ToString)
        End Try
    End Sub


#End Region

#Region " Tests "

    ' On vérifie que toutes les pressions de sorties de l'onglet son saisies
    Public Function pressionTroncons_checkIsAllFilled(ByVal pressionId As Integer) As Boolean
        Return True
        Dim nbBuses As Integer = 12
        If pressionId > 4 Then
            nbBuses = 24
        End If
        For i As Integer = 1 To nbBuses
            Try
                Dim pressionManoTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_pressionSortie_" & i, tabPage_diagnostique_manoTroncon)
                If pressionManoTextBox.Text = "" Then
                    Return False
                End If
            Catch ex As Exception
                CSDebug.dispWarn("diagnostique::checkIsAllFilled : " & ex.Message.ToString)
            End Try
        Next
        Return True
    End Function

#End Region

#Region " Contrôles de saisie "

    ' On n'autorise que du numérique a virgule
    Private Sub pressionTronc_pressionSortie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

#End Region

#Region " Events "




#End Region


#End Region

#Region " Communs "

#Region "Pressions Events"



#End Region

#Region " Sauvegarde tableau 8.3.3 "
    Public Function validerDiagnostiqueTab833() As Boolean
        'CSDebug.dispInfo("Diagnostique.saveTeb833")
        Dim bReturn As Boolean
        Try
            m_diagnostic.diagnosticTroncons833.Liste.Clear()
            '## Sauvegarde du nombre de Niveau et de Troncons
            m_diagnostic.controleNbreNiveaux = m_Niveaux
            m_diagnostic.controleNbreTroncons = m_Troncons

            ' ### Bouclage sur les pressions
            Dim startOnglet As Integer = 1
            Dim endOnglet As Integer = 4
            'Pour la ganaration du rapport de synthese , les releve de pression sont ajoutés au Diag
            'Mais pour éviter les modifs trop importantes la collection diagnosticTroncons833 continue d'être alimentées
            'Les informations sont donc en double
            m_diagnostic.relevePression833_1 = m_RelevePression833_P1
            m_diagnostic.relevePression833_2 = m_RelevePression833_P2
            m_diagnostic.relevePression833_3 = m_RelevePression833_P3
            m_diagnostic.relevePression833_4 = m_RelevePression833_P4
            For nPression As Integer = startOnglet To endOnglet
                SetCurrentPressionControls(nPression)

                Dim nCol As Integer
                If m_RelevePression833_Current IsNot Nothing Then
                    For Each oNiveau As RelevePression833Niveau In m_RelevePression833_Current.colNiveaux
                        For Each oTroncon As RelevePression833Troncon In oNiveau.colTroncons
                            nCol = ((oNiveau.Num - 1) * oNiveau.colTroncons.Count()) + oTroncon.Num
                            Dim troncons833 As DiagnosticTroncons833 = New DiagnosticTroncons833
                            troncons833.idDiagnostic = m_diagnostic.id
                            troncons833.idPression = nPression
                            'Pour compatibilité avec les anciennes versions
                            'If typeControle <> Pulverisateur.CATEGORIEPULVE_RAMPE Then
                            '    troncons833.idPression = nPression + 4
                            'End If

                            troncons833.idColumn = nCol
                            troncons833.pressionSortie = oTroncon.PressionLue
                            'Transfert des elements calculé dans le diagnostic pour GlobalsCRODIP.CONSTruire le rapport de synthèse
                            troncons833.EcartBar = oTroncon.EcartPression
                            troncons833.Ecartpct = oTroncon.EcartPressionpct
                            troncons833.MoyenneAutrePression = oTroncon.MoyenneAutresTroncons
                            troncons833.HeterogeneiteBar = oTroncon.EcartMoyenneAutresTroncons
                            troncons833.HeterogeneitePct = oTroncon.Heterogeneite
                            troncons833.nNiveau = oNiveau.Num
                            troncons833.nTroncon = oTroncon.Num


                            m_diagnostic.diagnosticTroncons833.Liste.Add(troncons833)

                        Next oTroncon

                    Next oNiveau
                End If

            Next nPression

            'Sauvegarde de la pression par defaut
            If m_RelevePression833_P1.PressionManoPourCalculDefaut Then
                m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut = "1"
            End If
            If m_RelevePression833_P2.PressionManoPourCalculDefaut Then
                m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut = "2"
            End If
            If m_RelevePression833_P3.PressionManoPourCalculDefaut Then
                m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut = "3"
            End If
            If m_RelevePression833_P4.PressionManoPourCalculDefaut Then
                m_diagnostic.diagnosticInfosComplementaires.PressionParDefaut = "4"
            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.saveTab833 Error " & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    'Public Function saveTab833OLD()

    '    Dim troncons833List As DiagnosticTroncons833List = New DiagnosticTroncons833List

    '    ' ### Bouclage sur les pressions
    '    Dim startOnglet As Integer = 1
    '    Dim endOnglet As Integer = 4
    '    If typeControle <> Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        startOnglet = 5
    '        endOnglet = 8
    '    End If
    '    For pressionId As Integer = startOnglet To endOnglet
    '        Try
    '            ' ### Bouclage sur chaque mesure
    '            Dim nbBuses As Integer = 12
    '            If typeControle <> Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '                nbBuses = 24
    '            End If
    '            Dim idColumn As Integer
    '            For idColumn = 1 To nbBuses
    '                Try
    '                    Dim txtBox_pressionSortie As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("pressionTronc_" & pressionId & "_pressionSortie_" & idColumn, tabPage_diagnostique_manoTroncon)
    '                    Dim pressionSortie As String = txtBox_pressionSortie.Text
    '                    If pressionSortie = "" Then
    '                        pressionSortie = "0"
    '                    End If

    '                    ' On enregistre la mesure pour la buse en BDD
    '                    Dim troncons833 As DiagnosticTroncons833 = New DiagnosticTroncons833
    '                    troncons833.idDiagnostic = diagnosticCourant.id
    '                    troncons833.idPression = pressionId
    '                    troncons833.idColumn = idColumn
    '                    troncons833.pressionSortie = pressionSortie
    '                    If troncons833List.diagnosticTroncons833 Is Nothing Then
    '                        ReDim troncons833List.diagnosticTroncons833(0)
    '                    Else
    '                        ReDim Preserve troncons833List.diagnosticTroncons833(troncons833List.diagnosticTroncons833.Length)
    '                    End If
    '                    troncons833List.diagnosticTroncons833(troncons833List.diagnosticTroncons833.Length - 1) = troncons833

    '                Catch ex As Exception
    '                    CSDebug.dispWarn("diagnostique::saveTab833 : " & ex.Message.ToString)
    '                End Try
    '            Next
    '        Catch ex As Exception
    '            CSDebug.dispError("diagnostique::saveTab833 : " & ex.Message.ToString)
    '        End Try
    '    Next

    '    diagnosticCourant.diagnosticTroncons833 = troncons833List

    'End Function
#End Region

#Region " Sauvegarde tableau 5.4.2 "
    Public Sub validerDiagnostiqueTab542()
        'CSDebug.dispInfo("Diagnostique.saveTab542")
        Try
            m_diagnostic.syntheseImprecision542 = Me.manopulveResultat.Text
            Dim mano542List As DiagnosticMano542List = New DiagnosticMano542List
            'ReDim mano542List.diagnosticMano542(0)
            '########################################################################

            Dim mano542_1 As DiagnosticMano542 = New DiagnosticMano542
            mano542_1.pressionPulve = manopulvePressionPulve_1.Text
            mano542_1.pressionControle = manopulvePressionControle_1.Text
            If manopulvePressionEcart_1.Text <> "" And IsNumeric(manopulvePressionEcart_1.Text) Then
                mano542_1.Ecart = manopulvePressionEcart_1.Text
            End If
            If manopulvePressionImprecision_1.Text <> "" And IsNumeric(manopulvePressionImprecision_1.Tag) Then
                mano542_1.Erreur = manopulvePressionImprecision_1.Tag
            End If
            mano542List.Liste.Add(mano542_1)
            '        ReDim Preserve mano542List.diagnosticMano542(mano542List.diagnosticMano542.Length)

            Dim mano542_2 As DiagnosticMano542 = New DiagnosticMano542
            mano542_2.pressionPulve = manopulvePressionPulve_2.Text
            mano542_2.pressionControle = manopulvePressionControle_2.Text
            If manopulvePressionEcart_2.Text <> "" And IsNumeric(manopulvePressionEcart_2.Text) Then
                mano542_2.Ecart = manopulvePressionEcart_2.Text
            End If
            If manopulvePressionImprecision_2.Text <> "" And IsNumeric(manopulvePressionImprecision_2.Tag) Then
                mano542_2.Erreur = manopulvePressionImprecision_2.Tag
            End If
            mano542List.Liste.Add(mano542_2)

            Dim mano542_3 As DiagnosticMano542 = New DiagnosticMano542
            mano542_3.pressionPulve = manopulvePressionPulve_3.Text
            mano542_3.pressionControle = manopulvePressionControle_3.Text
            If manopulvePressionEcart_3.Text <> "" And IsNumeric(manopulvePressionEcart_3.Text) Then
                mano542_3.Ecart = manopulvePressionEcart_3.Text
            End If
            If manopulvePressionImprecision_3.Text <> "" And IsNumeric(manopulvePressionImprecision_3.Tag) Then
                mano542_3.Erreur = manopulvePressionImprecision_3.Tag
            End If
            mano542List.Liste.Add(mano542_3)

            Dim mano542_4 As DiagnosticMano542 = New DiagnosticMano542
            mano542_4.pressionPulve = manopulvePressionPulve_4.Text
            mano542_4.pressionControle = manopulvePressionControle_4.Text
            If manopulvePressionEcart_4.Text <> "" And IsNumeric(manopulvePressionEcart_4.Text) Then
                mano542_4.Ecart = manopulvePressionEcart_4.Text
            End If
            If manopulvePressionImprecision_4.Text <> "" And IsNumeric(manopulvePressionImprecision_4.Tag) Then
                mano542_4.Erreur = manopulvePressionImprecision_4.Tag
            End If
            mano542List.Liste.Add(mano542_4)

            '########################################################################
            m_diagnostic.diagnosticMano542List = mano542List
            'Utilisation du Calibrateur
            m_diagnostic.controleUseCalibrateur = manopulveIsUseCalibrateur.Checked
            'Mano De controle
            If manopulveIsUseCalibrateur.Checked Then
                If Not manoTroncon_listManoControle.SelectedItem Is Nothing Then
                    m_diagnostic.controleManoControleNumNational = manoTroncon_listManoControle.SelectedItem.id()
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("saveTab542 ERR : " & ex.Message.ToString)
        End Try

    End Sub
#End Region

#End Region

#End Region

#Region " 9.2.2 - Onglet Buses "

#Region " Calculs "

    ' Calcul et retourne le % d'usure d'une buse
    Private Function mutCalcUsure1Buse(ByVal lotId As Integer, ByVal buseId As Integer) As Double
        ' On récupère les contrôles pour cette buse
        Dim tbdebitBuse As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
        Dim tbusureBuse As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
        Dim debitNominalValue As Double = 0
        Dim debitValue As Double = 0
        Dim usurePourcent As Double = 0
        Dim debitNominalTextBox As CRODIP_ControlLibrary.TBNumeric
        Try
            If tbdebitBuse Is Nothing Then
                CSDebug.dispInfo("le Controle diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit n'existe pas")
                Return 0D
            End If
            If tbusureBuse Is Nothing Then
                CSDebug.dispInfo("le Controle diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure n'existe pas")
                Return 0D
            End If
            If tbdebitBuse.Text <> "" Then
                tbdebitBuse.Text = tbdebitBuse.Text.Replace(".", ",")
                If IsNumeric(tbdebitBuse.Text) And Not String.IsNullOrEmpty(tbdebitBuse.Text) Then
                    debitValue = GlobalsCRODIP.StringToDouble(tbdebitBuse.Text)
                    'Recherche du débit Nominal
                    debitNominalTextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
                    If IsNumeric(tbdebitBuse.Text) And Not String.IsNullOrEmpty(tbdebitBuse.Text) Then
                        debitNominalValue = GlobalsCRODIP.StringToDouble(debitNominalTextBox.Text)
                    Else
                        debitNominalTextBox = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & lotId, diagBuses_tab_categories)
                        If IsNumeric(tbdebitBuse.Text) And Not String.IsNullOrEmpty(tbdebitBuse.Text) Then
                            debitNominalValue = GlobalsCRODIP.StringToDouble(debitNominalTextBox.Text)
                        End If
                    End If
                End If

                If debitNominalValue <> 0 Then
                    'debitNominalValue = 1.08
                    '            Dim ecartTolereTextBox As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                    '           Dim ecartTolereValue As Double = CType(ecartTolereTextBox.text, Double)
                    ' On calcul l'usure
                    Dim oBuse As New DiagnosticBusesDetail()
                    oBuse.debit = debitValue
                    oBuse.CalcEcart(debitNominalValue, 0)
                    tbusureBuse.Text = oBuse.ecart
                    usurePourcent = GlobalsCRODIP.StringToDouble(oBuse.ecart)
                End If
            Else
                tbusureBuse.Text = ""
                usurePourcent = 0
            End If
        Catch ex As Exception
            CSDebug.dispInfo("mutCalcUsure1Buse ERR :" & ex.Message)
            usurePourcent = 0
        End Try
        Return usurePourcent
    End Function

    ' Retourn TRUE si une buse est usée, sinon FALSE
    Private Function mutCalcIs1BuseUsee(ByVal lotId As Integer, ByVal buseId As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            ' On récupère les contrôles pour cette buse
            Dim debitTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
            Dim usureTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
            Dim debitNominalTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)

            If Not debitTextBox Is Nothing Then
                If Not String.IsNullOrEmpty(debitTextBox.Text) And Not String.IsNullOrEmpty(debitNominalTextBox.Text) Then
                    Dim debitValue As Decimal = CType(debitTextBox.Text, Decimal)
                    Dim debitNominalValue As Decimal = CType(debitNominalTextBox.Text, Decimal)
                    Dim ecartTolereTextBox As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                    Dim ecartTolereValue As Decimal = CType(ecartTolereTextBox.Text, Decimal)
                    ' On Calcul
                    Dim oBuse As New DiagnosticBusesDetail()
                    oBuse.debit = debitValue
                    oBuse.CalcEcart(debitNominalValue, ecartTolereValue)
                    If Not oBuse.usee Then
                        usureTextBox.BackColor = System.Drawing.Color.Green
                        usureTextBox.Tag = "OK"
                        bReturn = False
                    Else
                        usureTextBox.BackColor = System.Drawing.Color.Red
                        usureTextBox.Tag = "NOK"
                        bReturn = True
                    End If
                Else
                    'S'il n'y a pas de débit, on se remet en gris
                    usureTextBox.BackColor = System.Drawing.SystemColors.Control
                    bReturn = False
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::mutCalcIsUsed : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    ' Calcul le nombre de buses d'un lot
    Private Function mutCalcNbBuses(ByVal lotId As Integer) As Double
        Try

            Dim nbBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
            If nbBusesTextBox.Text <> "" Then
                Dim nbBusesValue As Double = CType(nbBusesTextBox.Text, Integer)
                Return nbBusesValue
            Else
                Return 0
            End If
        Catch ex As Exception
            CSDebug.dispError("mutCalcNbBuses1 ERR : " & ex.Message.ToString)
            Return 0
        End Try
        ' Récupération des controles
    End Function
    Private Function mutCalcNbBuses() As Integer
        Try

            ' Récupération des controles
            Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
            Dim nbBuses As Integer = 0
            For i As Integer = 1 To nbLots
                Try
                    nbBuses += mutCalcNbBuses(i)
                Catch ex As Exception
                    CSDebug.dispWarn("diagnostique::mutCalcNbBuses : " & ex.Message)
                End Try
            Next
            Return nbBuses
        Catch ex As Exception
            CSDebug.dispError("mutCalcNbBuses2 ERR : " & ex.Message.ToString)
            Return 0
        End Try

    End Function

    ' Calcul le nombre de buses usées d'un lot
    Private Function mutCalcNbBusesUsee(ByVal lotId As Integer) As Integer
        Try

            ' Récupération des controles
            Dim nbBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
            If nbBusesTextBox.Text <> "" Then
                Dim nbBusesValue As Double = CType(nbBusesTextBox.Text, Integer)
                Dim nbBusesUseesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBusesUsees_" & lotId, diagBuses_tab_categories)
                ' On calcul le nombre de buses usées
                Dim nbBusesUsees As Integer = 0
                For i As Integer = 1 To nbBusesValue
                    Try
                        If mutCalcIs1BuseUsee(lotId, i) Then
                            nbBusesUsees += 1
                        End If
                    Catch ex As Exception
                        CSDebug.dispWarn("diagnostique::mutCalcNbBusesUsed : " & ex.Message)
                    End Try
                Next
                nbBusesUseesTextBox.Text = nbBusesUsees
                Return nbBusesUsees
            Else
                Return 0
            End If
        Catch ex As Exception
            CSDebug.dispError("mutCalcNbBusesUsed ERR : " & ex.Message.ToString)
            Return 0
        End Try

    End Function
    '' Calcul le nombre de buses usées du jeu de buses
    'Dim tabBuses_isOk As Integer = -1
    'Private Function mutCalcNbBusesUsed()
    '    Try

    '        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
    '        Dim nbBusesUsees As Integer = 0
    '        For i As Integer = 1 To nbBusesValue
    '            Try
    '                If mutCalcIsUsee(lotId, i) Then
    '                    nbBusesUsees += 1
    '                End If
    '            Catch ex As Exception
    '                CSDebug.dispWarn("diagnostique::mutCalcNbBusesUsed : " & ex.Message)
    '            End Try
    '        Next
    '        nbBusesUseesTextBox.text = nbBusesUsees
    '        Return nbBusesUsees
    '    Else
    '        Return 0
    '    End If
    'End Function
    ' Calcul le nombre de buses usées du jeu de buses
    'Dim tabBuses_isOk As Integer = -1
    Private Function mutCalcNbBusesUsee() As Integer
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim nbBusesUsees As Integer = 0
        For i As Integer = 1 To nbLots
            Try
                nbBusesUsees += mutCalcNbBusesUsee(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostique::mutCalcNbBusesUsed : " & ex.Message)
            End Try
        Next
        '   If tabBuses_isOk <> -1 Then
        'If tabBuses_isOk = 1 Then
        '    arrCheckboxes(8, 1) -= 1
        'Else
        '    arrCheckboxes(8, 3) -= 1
        'End If
        'End If
        If nbBusesUsees > 0 Then
            If (nbBusesUsees / mutCalcNbBuses()) * 100 < m_oParamdiag.ParamDiagCalc922.limitePctBuseUsees Then
                diagBuses_resultat.Text = "USURE PARTIELLE"
                diagBuses_resultat.ForeColor = System.Drawing.Color.Red
                '       tabBuses_isOk = 0
                'arrCheckboxes(8, 3) += 1
                If Not m_bDuringLoad Then
                    RadioButton_diagnostic_9221.Checked = True
                    RadioButton_diagnostic_9222.Checked = False
                    RadioButton_diagnostic_9220.Checked = False
                End If
            Else
                diagBuses_resultat.Text = "USURE GLOBALE"
                diagBuses_resultat.ForeColor = System.Drawing.Color.Red
                '      tabBuses_isOk = 0
                'arrCheckboxes(8, 3) += 1
                If Not m_bDuringLoad Then
                    RadioButton_diagnostic_9221.Checked = False
                    RadioButton_diagnostic_9222.Checked = True
                    RadioButton_diagnostic_9220.Checked = False
                End If
            End If
        Else
            diagBuses_resultat.Text = "OK"
            diagBuses_resultat.ForeColor = System.Drawing.Color.Green
            ' tabBuses_isOk = 1
            'arrCheckboxes(8, 1) += 1
            If Not m_bDuringLoad Then
                RadioButton_diagnostic_9221.Checked = False
                RadioButton_diagnostic_9222.Checked = False
                RadioButton_diagnostic_9220.Checked = True
            End If
        End If
        checkIsOk(8)
        diagBuses_nbBusesUsees.Text = nbBusesUsees
        m_diagnostic.syntheseNbBusesUsees = nbBusesUsees.ToString
        Return nbBusesUsees
    End Function


    ' Calcul l'usure moyenne d'un lot de buses
    Private Function mutCalcUsureMoyBuses(ByVal lotId As Integer) As Double
        ' Récupération des controles
        Dim tbnbBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        Dim nbBusesValue As Integer = CType(tbnbBuses.Text, Integer)
        Dim tbusureMoyBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TEXTBOX_usureMoyenneBuses_" & lotId, diagBuses_tab_categories)
        ' On calcul le nombre de buses usées
        Dim usureMoy As Double = 0
        Dim dUsureBuse As Double
        If Not tbusureMoyBuses Is Nothing Then
            For i As Integer = 1 To nbBusesValue
                Try
                    dUsureBuse = mutCalcUsure1Buse(lotId, i)
                    If dUsureBuse <> 0 Then
                        '                        usureMoy = (usureMoy + Math.Abs(dUsureBuse))
                        usureMoy = (usureMoy + dUsureBuse)
                    End If
                Catch ex As Exception
                    CSDebug.dispWarn("diagnostique::mutCalcUsureMoyBuses : " & ex.Message)
                End Try
            Next
            usureMoy = Math.Round(usureMoy / nbBusesValue, 2)
            tbusureMoyBuses.Text = usureMoy
        End If
        Return usureMoy
    End Function
    ' Calcul l'usure moyenne du jeu de buses
    Private Function mutCalcUsureMoyBuses() As Double
        Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
        Dim usureMoyBuses As Double = 0
        For i As Integer = 1 To nbLots
            Try
                usureMoyBuses += mutCalcUsureMoyBuses(i)
            Catch ex As Exception
                CSDebug.dispWarn("diagnostique::mutCalcUsureMoyBuses() : " & ex.Message)
            End Try
        Next
        usureMoyBuses = Math.Round(usureMoyBuses / nbLots, 2)
        diagBuses_usureMoyBuses.Text = usureMoyBuses
        m_diagnostic.syntheseUsureMoyenneBuses = usureMoyBuses
        fillArrBusesUsee()
        Return usureMoyBuses
    End Function

    ' Calcul le debit moyen d'un lot de buses
    Private Function mutCalcDebitMoy(ByVal lotId As Integer) As Double
        Dim debitMoy As Double = 0

        ' Récupération des controles
        Dim nbBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        If nbBusesTextBox IsNot Nothing Then
            If nbBusesTextBox.Text <> "" And IsNumeric(nbBusesTextBox.Text) Then
                Dim nbBusesValue As Double = CType(nbBusesTextBox.Text, Integer)
                Dim debitMoyBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMoyen_" & lotId, diagBuses_tab_categories)

                Dim debitMiniBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMini_" & lotId, diagBuses_tab_categories)
                Dim debitMaxiBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMaxi_" & lotId, diagBuses_tab_categories)
                Dim debitMin As Double = 9999.99
                Dim debitMax As Double = 0

                ' On calcul le debit moyen des buses

                For i As Integer = 1 To nbBusesValue
                    Try
                        Dim debitTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & i & "_debit", diagBuses_tab_categories)
                        If debitTextBox.Text <> "" Then
                            debitMoy = (debitMoy + CType(debitTextBox.Text, Double))
                            Try
                                Dim debitTmp As Double = CDbl(debitTextBox.Text)
                                If debitTmp < debitMin Then
                                    debitMin = debitTmp
                                End If
                                If debitTmp > debitMax Then
                                    debitMax = debitTmp
                                End If
                            Catch ex As Exception
                                CSDebug.dispWarn("diagnostique::mutCalcDebitMoy Max/min : " & ex.Message)
                            End Try
                        End If
                    Catch ex As Exception
                        CSDebug.dispWarn("diagnostique::mutCalcDebitMoy : " & ex.Message)
                    End Try
                Next
                debitMoy = Math.Round(debitMoy / nbBusesValue, 3)
                debitMoyBusesTextBox.Text = debitMoy
                fillDebitNominalPourCalcul(lotId)

                debitMiniBusesTextBox.Text = debitMin.ToString
                debitMaxiBusesTextBox.Text = debitMax.ToString
            End If
        End If

        Return debitMoy
    End Function
    Private Function mutCalcLot(ByVal LotId As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            mutCalcDebitMoy(LotId)
            mutCalcUsureMoyBuses(LotId)
            mutCalcNbBusesUsee(LotId)
            bReturn = True
        Catch ex As Exception
            'CSDebug.dispWarn("diagnostique::mutCalcLot : " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function

    ' Vérifie si toutes les pressions de l'onglet ManoTronçons ont été remplies
    ' on ne prend en compte que les valeurs de la pression cochée
    Private Function CheckIfManoTronconsAreFilled() As Boolean
        Try

            Dim bAllFilled As Boolean
            Dim ncol As Integer
            Dim odgv As DataGridView = Nothing
            Dim ochk As RadioButton = Nothing
            Dim bUseCalibrateur As Boolean
            'Utilisation du calibrateur
            bUseCalibrateur = manopulveIsUseCalibrateur.Checked

            'Controle du 5.4.2
            '==================
            bAllFilled = True
            If pnl542.Enabled Then
                If String.IsNullOrEmpty(manopulvePressionControle_1.Text) Then
                    bAllFilled = False
                End If
                If String.IsNullOrEmpty(manopulvePressionControle_2.Text) Then
                    bAllFilled = False
                End If
                If String.IsNullOrEmpty(manopulvePressionControle_3.Text) Then
                    bAllFilled = False
                End If
                If String.IsNullOrEmpty(manopulvePressionControle_4.Text) Then
                    bAllFilled = False
                End If
            End If
            'Controle 8.3.3
            '==============
            'Au moins une pression doit être cochée 
            bAllFilled = bAllFilled And (rbPression1.Checked Or rbPression2.Checked Or rbPression3.Checked Or rbPression4.Checked)

            If pnl_833.Enabled Then
                For nPression As Integer = 1 To 4

                    Select Case nPression
                        Case 1
                            odgv = gdvPressions1
                            ochk = rbPression1
                        Case 2
                            odgv = gdvPressions2
                            ochk = rbPression2
                        Case 3
                            odgv = gdvPressions3
                            ochk = rbPression3
                        Case 4
                            odgv = gdvPressions4
                            ochk = rbPression4
                    End Select
                    'On fait la vérification si 
                    ' le calibrateur n'est pas utilisé ou
                    'Si le calibrateur est utilisé et que la pression est cochée

                    If (Not bUseCalibrateur Or (ochk.Checked And bUseCalibrateur)) Then
                        For nNiveau As Integer = 1 To m_Niveaux
                            For nTroncon As Integer = 1 To m_Troncons
                                ncol = ((nNiveau - 1) * m_Troncons) + nTroncon
                                If odgv(ncol, ROW_PRESSION).Value Is Nothing Then
                                    bAllFilled = False
                                End If
                            Next

                        Next
                    End If

                Next
            End If
            Return bAllFilled
        Catch ex As Exception
            CSDebug.dispError("CheckIfManoTronconsAreFilled ERR : " & ex.Message.ToString)
            Return True
        End Try

    End Function
    ' Vérifie si toutes les buses ont été remplies
    Protected Overridable Function CheckIfBusesAreFilled() As Boolean
        Dim bAllFilled As Boolean
        bAllFilled = True
        Try
            bAllFilled = Not (String.IsNullOrEmpty(tbPressionMesure.Text))

            If Panel922.Enabled = True Then
                If IsNumeric(diagBuses_conf_nbCategories.Text) Then
                    Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
                    For i As Integer = 1 To nbLots
                        Try
                            bAllFilled = bAllFilled And CheckIfBusesAreFilled(i)
                        Catch ex As Exception
                            CSDebug.dispWarn("diagnostique::CheckIfBusesAreFilled : " & ex.Message)
                        End Try
                    Next
                End If
            End If
            If bAllFilled Then
                If buses_listBancs.Text = "" Then
                    bAllFilled = False
                End If
            End If
        Catch ex As Exception
            'CSDebug.dispError("CheckIfBusesAreFilled ERR : " & ex.Message.ToString)
        End Try
        Return bAllFilled
    End Function
    ' Vérifie si toutes les buses ont été remplies pour un niveau donné
    Protected Overridable Function CheckIfBusesAreFilled(ByVal pNiveau As Integer) As Boolean
        Dim nbBuses As Integer
        Dim nbBusesTextBox As CRODIP_ControlLibrary.TBNumeric
        Dim debitTextBox As CRODIP_ControlLibrary.TBNumeric
        Dim bAllFilled As Boolean
        Try
            bAllFilled = True
            nbBusesTextBox = CSForm.getControlByName("TextBox_nbBuses_" & pNiveau, diagBuses_tab_categories)
            If nbBusesTextBox IsNot Nothing Then
                nbBuses = CType(nbBusesTextBox.Text, Integer)
                For i As Integer = 1 To nbBuses
                    debitTextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & pNiveau & "_" & i & "_debit", diagBuses_tab_categories)
                    If debitTextBox IsNot Nothing Then
                        If String.IsNullOrEmpty(debitTextBox.Text) Then
                            bAllFilled = False
                        End If
                    End If
                Next i
            End If
        Catch ex As Exception
            'CSDebug.dispError("diagnostique::CheckIfBusesAreFilled : " & ex.Message)
            bAllFilled = False
        End Try
        Return bAllFilled
    End Function
    ' Calcul le debit moyen du jeu de buses
    Private Function mutCalcDebitMoy() As Double
        Try

            Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
            Dim debitMoyBuses As Double = 0
            For i As Integer = 1 To nbLots
                Try
                    debitMoyBuses += mutCalcDebitMoy(i)
                Catch ex As Exception
                    CSDebug.dispWarn("diagnostique::mutCalcDebitMoy : " & ex.Message)
                End Try
            Next
            debitMoyBuses = Math.Round(debitMoyBuses / nbLots, 3)
            diagBuses_debitMoyen.Text = debitMoyBuses
            'help552_debitMoyen0bar.Text = debitMoyBuses
            Return debitMoyBuses
        Catch ex As Exception
            CSDebug.dispError("mutCalcDebitMoy ERR : " & ex.Message.ToString)
            Return 0
        End Try

    End Function

    ' rempli le debit nominal pour calcul
    Private Sub fillDebitNominalPourCalcul(ByVal lotId As Integer)
        Try
            Dim tbDebitNominalCONSTructeur As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & lotId, diagBuses_tab_categories)
            Dim tbdebitNominal As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
            Dim debitMoyBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMoyen_" & lotId, diagBuses_tab_categories)

            Dim oldDuringLoad As Boolean = m_bDuringLoad
            m_bDuringLoad = True
            If tbDebitNominalCONSTructeur.Text = "" Then
                'S'il n'y a pas de débitNominal constructeur on prend 
                '   Le débit moyen si le nombre de buses est >2
                '   le plus petit debit si le nombre de buses est égal à 2
                'Lecture du nombre de buses
                Dim nBuses As Integer = 0
                Dim tb_nbBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
                If IsNumeric(tb_nbBuses.Text) Then
                    nBuses = CInt(tb_nbBuses.Text)
                End If

                If nBuses = 2 Then
                    Dim TBDebit As CRODIP_ControlLibrary.TBNumeric
                    'Récupération du debit de la buse1
                    TBDebit = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_1_debit", diagBuses_tab_categories)
                    tbdebitNominal.Text = TBDebit.DecimalValue
                    'Récupération du debit de la buse1
                    TBDebit = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_2_debit", diagBuses_tab_categories)
                    'DebitNominal = Min( de deux débit)
                    If TBDebit.DecimalValue <> 0 And TBDebit.DecimalValue < tbdebitNominal.DecimalValue Then
                        tbdebitNominal.Text = TBDebit.DecimalValue
                    End If
                Else
                    tbdebitNominal.Text = debitMoyBusesTextBox.Text
                End If

            Else
                tbdebitNominal.Text = tbDebitNominalCONSTructeur.Text
            End If
            m_bDuringLoad = oldDuringLoad  'on revient dans l'état initial
        Catch ex As Exception
            CSDebug.dispError("fillDebitNom ERR : " & ex.Message.ToString)

        End Try

    End Sub

    ' Numéro des buses usées
    Private Sub fillArrBusesUsee()
        Try

            '------------------------------------------------------
            '--- On boucle les lots
            '------------------------------------------------------
            Dim nbLots As Integer = CType(diagBuses_conf_nbCategories.Text, Integer)
            ' On reset le tableau
            ReDim arrBusesUsed(nbLots)
            Dim curNumeroBuse As Integer = 0
            For lotId As Integer = 1 To nbLots
                Try
                    '------------------------------------------------------
                    '--- On boucle les buses
                    '------------------------------------------------------
                    Dim nbBusesTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
                    If nbBusesTextBox.Text <> "" Then
                        Dim nbBusesValue As Double = CType(nbBusesTextBox.Text, Integer)
                        ' On calcul le nombre de buses usées
                        For buseId As Integer = 1 To nbBusesValue
                            Try
                                '------------------------------------------------------
                                '--- Calcul si la  buse est usée
                                '------------------------------------------------------
                                curNumeroBuse += 1
                                Try
                                    ' On récupère les contrôles pour cette buse
                                    Dim debitValue As Double = 0
                                    Dim debitNominalTextBox As CRODIP_ControlLibrary.TBNumeric = Nothing
                                    Dim debitNominalValue As Double = 0
                                    Dim ecartTolereTextBox As ComboBox = Nothing
                                    Dim ecartTolereValue As Double = 0
                                    Dim usureTextBox As CRODIP_ControlLibrary.TBNumeric = Nothing
                                    Dim tmpEcartPourcentage As Decimal

                                    Dim debitTextBox As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)
                                    If Not debitTextBox Is Nothing Then
                                        If debitTextBox.Text <> "" Then
                                            debitValue = GlobalsCRODIP.StringToDouble(debitTextBox.Text)
                                            debitNominalTextBox = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)

                                            If Not debitNominalTextBox Is Nothing Then
                                                debitNominalValue = GlobalsCRODIP.StringToDouble(debitNominalTextBox.Text)
                                            End If

                                            ecartTolereTextBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                                            If Not ecartTolereTextBox Is Nothing Then
                                                ecartTolereValue = GlobalsCRODIP.StringToDouble(ecartTolereTextBox.Text)
                                            End If
                                            usureTextBox = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
                                            ' On Calcul
                                            If debitNominalValue <> 0 Then
                                                tmpEcartPourcentage = CType(Math.Abs(CType(debitValue, Decimal) - CType(debitNominalValue, Decimal)) * CType(100, Decimal) / CType(debitNominalValue, Decimal), Decimal)
                                            End If
                                            If tmpEcartPourcentage < CType(ecartTolereValue, Decimal) Or CType(ecartTolereValue, Decimal) = tmpEcartPourcentage Then
                                                ' Buse pas usée
                                            Else
                                                ' Buse usée
                                                arrBusesUsed(lotId) = arrBusesUsed(lotId) & curNumeroBuse.ToString & " ; "
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    CSDebug.dispWarn("diagnostique::fillArrBusesUsed : " & ex.Message)
                                End Try
                                '------------------------------------------------------
                                '--- FIN -- Calcul si la  buse est usée
                                '------------------------------------------------------
                            Catch ex As Exception
                                CSDebug.dispWarn("diagnostique::fillArrBusesUsed : " & ex.Message)
                            End Try
                        Next
                    End If
                    '------------------------------------------------------
                    '--- FIN -- On boucle les buses
                    '------------------------------------------------------
                Catch ex As Exception
                    CSDebug.dispWarn("diagnostique::mutCalcNbBusesUsed : " & ex.Message)
                End Try
            Next
            '------------------------------------------------------
            '--- FIN -- On boucle les lots
            '------------------------------------------------------
        Catch ex As Exception
            CSDebug.dispError("fillArrBusesUsed ERR : " & ex.Message.ToString)

        End Try

    End Sub

#End Region

#Region " Contrôles saisie "


#End Region

#Region " Events "

    ' Valide le nombre de niveau
    Private Sub validNbCategories()
        'CSDebug.dispInfo("validNbCategories")
        Try
            If diagBuses_conf_nbCategories.Text = "" Or tbPressionMesure.Text = "" Then
                Exit Sub
            End If

            ' Récupération des variables
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDiagnostique))
            'Dim tabCategories As TabControl = diagBuses_tab_categories
            Dim isCleared As Boolean = False
            Do While isCleared = False
                Try
                    If diagBuses_tab_categories.TabPages.Count > 0 Then
                        diagBuses_tab_categories.TabPages.Clear()
                    End If
                    isCleared = True
                Catch ex As Exception
                    isCleared = False
                End Try
            Loop

            If diagBuses_conf_nbCategories.Text = "" Then
                diagBuses_conf_nbCategories.Text = 0
            End If
            Dim nbCategories As Integer = diagBuses_conf_nbCategories.Text

            ' On ajoute les onglets
            ajouterLotBuses(nbCategories)

        Catch ex As Exception
            CSDebug.dispError("diagnostique::validNbCategories : " & ex.Message)
        End Try
    End Sub
    Private Function createControl_LabelNbreBuses(ongletCategorie As TabPage, pLot As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim label_nbBuses As New Label
            ongletCategorie.Controls.Add(label_nbBuses)
            label_nbBuses.Parent = ongletCategorie
            label_nbBuses.Name = "label_nbBuses_" & pLot

            label_nbBuses.Font = LblModele_NombreDeBuses.Font
            label_nbBuses.ForeColor = LblModele_NombreDeBuses.ForeColor
            label_nbBuses.Location = LblModele_NombreDeBuses.Location
            label_nbBuses.Size = LblModele_NombreDeBuses.Size
            label_nbBuses.Text = LblModele_NombreDeBuses.Text
            label_nbBuses.TextAlign = LblModele_NombreDeBuses.TextAlign
            'label_nbBuses.Parent = ongletCategorie
            'label_nbBuses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'label_nbBuses.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            'label_nbBuses.Location = New System.Drawing.Point(8, 8)
            'label_nbBuses.Name = "label_nbBuses_" & pLot
            'label_nbBuses.Size = New System.Drawing.Size(120, 16)
            'label_nbBuses.Text = "Nombre de buses : "
            'label_nbBuses.TextAlign = System.Drawing.ContentAlignment.BottomRight
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.createControl_LabelNbreBuses ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function createControl_TBNbreBuses(ongletCategorie As TabPage, pLot As Integer) As Boolean
        Dim bReturn As Boolean
        Try

            Dim textbox_nbBuses As New CRODIP_ControlLibrary.TBNumeric
            ongletCategorie.Controls.Add(textbox_nbBuses)
            textbox_nbBuses.Parent = ongletCategorie
            textbox_nbBuses.Name = "TextBox_nbBuses_" & pLot

            textbox_nbBuses.Location = tbModele_NombreDeBuses.Location
            textbox_nbBuses.Size = tbModele_NombreDeBuses.Size
            textbox_nbBuses.Text = tbModele_NombreDeBuses.Text
            'textbox_nbBuses.Location = New System.Drawing.Point(136, 8)
            'textbox_nbBuses.Size = New System.Drawing.Size(56, 20)
            'textbox_nbBuses.Text = ""
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.createControl_TBNbreBuses ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Création des controles concernant un Lot de Buses
    ''' </summary>
    ''' <param name="ongletCategorie"></param>
    ''' <param name="pLot"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function createControls_LotBuse(ongletCategorie As TabPage, pLot As Integer) As Boolean
        Dim bReturn As Boolean
        Try

            createControl_LabelNbreBuses(ongletCategorie, pLot)
            createControl_TBNbreBuses(ongletCategorie, pLot)
            '
            'CRODIP_ControlLibrary.TBNumeric "Nombre de buses"
            '
            '
            'Button "Valider"
            '
            Dim Button_valider_nbBuses As New Label
            ongletCategorie.Controls.Add(Button_valider_nbBuses)
            Button_valider_nbBuses.Parent = ongletCategorie
            Button_valider_nbBuses.Name = "Button_valider_nbBuses_" & pLot
            Button_valider_nbBuses.Font = btnModele_validerNbBuses.Font
            Button_valider_nbBuses.ForeColor = btnModele_validerNbBuses.ForeColor
            Button_valider_nbBuses.Image = btnModele_validerNbBuses.Image
            Button_valider_nbBuses.Location = btnModele_validerNbBuses.Location
            Button_valider_nbBuses.Size = btnModele_validerNbBuses.Size
            Button_valider_nbBuses.Text = btnModele_validerNbBuses.Text
            Button_valider_nbBuses.TextAlign = btnModele_validerNbBuses.TextAlign
            AddHandler Button_valider_nbBuses.Click, AddressOf validerNbBuses_Click

            'Débit nominal constructeur
            Dim label_DebitNominalCONSTructeur As New Label
            ongletCategorie.Controls.Add(label_DebitNominalCONSTructeur)
            label_DebitNominalCONSTructeur.Name = "label_DebitNominalCONSTructeur_" & pLot
            label_DebitNominalCONSTructeur.Parent = ongletCategorie
            label_DebitNominalCONSTructeur.Font = lblModele_DebitNominalCONSTructeur.Font
            label_DebitNominalCONSTructeur.ForeColor = lblModele_DebitNominalCONSTructeur.ForeColor
            label_DebitNominalCONSTructeur.Location = lblModele_DebitNominalCONSTructeur.Location
            label_DebitNominalCONSTructeur.Size = lblModele_DebitNominalCONSTructeur.Size
            label_DebitNominalCONSTructeur.Text = lblModele_DebitNominalCONSTructeur.Text
            label_DebitNominalCONSTructeur.TextAlign = lblModele_DebitNominalCONSTructeur.TextAlign

            Dim TextBox_debitNominalCONSTructeur As New CRODIP_ControlLibrary.TBNumeric
            ongletCategorie.Controls.Add(TextBox_debitNominalCONSTructeur)
            TextBox_debitNominalCONSTructeur.Name = "TextBox_debitNominalCONSTructeur_" & pLot
            TextBox_debitNominalCONSTructeur.Parent = ongletCategorie
            TextBox_debitNominalCONSTructeur.Font = tbModele_DebitNominalContructeur.Font
            TextBox_debitNominalCONSTructeur.Location = tbModele_DebitNominalContructeur.Location
            TextBox_debitNominalCONSTructeur.Size = tbModele_DebitNominalContructeur.Size
            TextBox_debitNominalCONSTructeur.Text = tbModele_DebitNominalContructeur.Text
            AddHandler TextBox_debitNominalCONSTructeur.TextChanged, AddressOf DebitNominalCONSTructeur_TextChanged

            'Débit nominal pour calcul *
            Dim label_debitNominalCalcul As New Label
            label_debitNominalCalcul.Name = "label_debitNominal_" & pLot
            ongletCategorie.Controls.Add(label_debitNominalCalcul)
            label_debitNominalCalcul.Parent = ongletCategorie
            label_debitNominalCalcul.Font = lblModele_DebitNominalPourCalcul.Font
            label_debitNominalCalcul.ForeColor = lblModele_DebitNominalPourCalcul.ForeColor
            label_debitNominalCalcul.Location = lblModele_DebitNominalPourCalcul.Location
            label_debitNominalCalcul.Size = lblModele_DebitNominalPourCalcul.Size
            label_debitNominalCalcul.Text = lblModele_DebitNominalPourCalcul.Text
            label_debitNominalCalcul.TextAlign = lblModele_DebitNominalPourCalcul.TextAlign

            Dim TextBox_debitNominalCalcul As New CRODIP_ControlLibrary.TBNumeric
            TextBox_debitNominalCalcul.Name = "TextBox_debitNominal_" & pLot
            ongletCategorie.Controls.Add(TextBox_debitNominalCalcul)
            TextBox_debitNominalCalcul.Parent = ongletCategorie
            TextBox_debitNominalCalcul.Font = tbModele_DebitNominalPourCalcul.Font
            TextBox_debitNominalCalcul.Location = tbModele_DebitNominalPourCalcul.Location
            TextBox_debitNominalCalcul.Size = tbModele_DebitNominalPourCalcul.Size
            TextBox_debitNominalCalcul.Text = tbModele_DebitNominalPourCalcul.Text
            TextBox_debitNominalCalcul.ReadOnly = tbModele_DebitNominalPourCalcul.ReadOnly
            AddHandler TextBox_debitNominalCalcul.TextChanged, AddressOf debitNominalPourCalcul_TextChanged

            'Ecart toléré (10 ou 15 %)
            Dim label_ecartTolere As New Label
            label_ecartTolere.Name = "label_ecartTolere_" & pLot
            ongletCategorie.Controls.Add(label_ecartTolere)
            label_ecartTolere.Parent = ongletCategorie
            label_ecartTolere.Font = lblModele_EcartTolere.Font
            label_ecartTolere.ForeColor = lblModele_EcartTolere.ForeColor
            label_ecartTolere.Location = lblModele_EcartTolere.Location
            label_ecartTolere.Size = lblModele_EcartTolere.Size
            label_ecartTolere.Text = lblModele_EcartTolere.Text
            label_ecartTolere.TextAlign = lblModele_EcartTolere.TextAlign

            Dim TextBox_ecartTolere As New ComboBox
            TextBox_ecartTolere.Name = "ComboBox_ecartTolere_" & pLot
            ongletCategorie.Controls.Add(TextBox_ecartTolere)
            TextBox_ecartTolere.Parent = ongletCategorie
            TextBox_ecartTolere.Font = cbxModele_EcartTolere.Font
            TextBox_ecartTolere.Location = cbxModele_EcartTolere.Location
            TextBox_ecartTolere.DropDownStyle = cbxModele_EcartTolere.DropDownStyle
            TextBox_ecartTolere.Items.AddRange(New Object() {"5", "10", "15"})
            TextBox_ecartTolere.Size = cbxModele_EcartTolere.Size
            TextBox_ecartTolere.Text = cbxModele_EcartTolere.Text
            TextBox_ecartTolere.SelectedIndex = 0
            AddHandler TextBox_ecartTolere.SelectedIndexChanged, AddressOf ecartTolere_SelectedIndexChanged


            'Marque
            Dim label_marque As New Label
            label_marque.Name = "label_marque_" & pLot
            ongletCategorie.Controls.Add(label_marque)
            label_marque.Parent = ongletCategorie
            label_marque.Font = lblModele_Marque.Font
            label_marque.ForeColor = lblModele_Marque.ForeColor
            label_marque.Location = lblModele_Marque.Location
            label_marque.Size = lblModele_Marque.Size
            label_marque.Text = lblModele_Marque.Text
            label_marque.TextAlign = lblModele_Marque.TextAlign

            Dim ComboBox_marque As New ComboBox
            ComboBox_marque.Name = "ComboBox_marque_" & pLot
            ongletCategorie.Controls.Add(ComboBox_marque)
            ComboBox_marque.Parent = ongletCategorie
            ComboBox_marque.DropDownStyle = cbxModele_Marque.DropDownStyle
            ComboBox_marque.Location = cbxModele_Marque.Location
            ComboBox_marque.Size = cbxModele_Marque.Size
            AddHandler ComboBox_marque.SelectedIndexChanged, AddressOf changeMarqueBuseSelected

            'Modele
            Dim label_modele As New Label
            label_modele.Name = "label_modele_" & pLot
            ongletCategorie.Controls.Add(label_modele)
            label_modele.Parent = ongletCategorie
            label_modele.Font = lblModele_Modele.Font
            label_modele.ForeColor = lblModele_Modele.ForeColor
            label_modele.Location = lblModele_Modele.Location
            label_modele.Size = lblModele_Modele.Size
            label_modele.Text = lblModele_Modele.Text
            label_modele.TextAlign = lblModele_Modele.TextAlign

            Dim ComboBox_modele As New ComboBox
            ComboBox_modele.Name = "ComboBox_modele_" & pLot
            ongletCategorie.Controls.Add(ComboBox_modele)
            ComboBox_modele.Parent = ongletCategorie
            ComboBox_modele.DropDownStyle = cbxModele_Modele.DropDownStyle
            ComboBox_modele.Location = cbxModele_Modele.Location
            ComboBox_modele.Size = cbxModele_Modele.Size
            AddHandler ComboBox_modele.SelectedIndexChanged, AddressOf changeModeleBuseSelected


            'Couleur
            Dim label_couleur As New Label
            label_couleur.Name = "label_couleur_" & pLot
            ongletCategorie.Controls.Add(label_couleur)
            label_couleur.Parent = ongletCategorie
            label_couleur.Font = lblModele_Couleur.Font
            label_couleur.ForeColor = lblModele_Couleur.ForeColor
            label_couleur.Location = lblModele_Couleur.Location
            label_couleur.Size = lblModele_Couleur.Size
            label_couleur.Text = lblModele_Couleur.Text
            label_couleur.TextAlign = lblModele_Couleur.TextAlign

            Dim ComboBox_couleur As New ComboBox
            ComboBox_couleur.Name = "ComboBox_couleur_" & pLot
            ongletCategorie.Controls.Add(ComboBox_couleur)
            ComboBox_couleur.Parent = ongletCategorie
            ComboBox_couleur.DropDownStyle = cbxModele_Couleur.DropDownStyle
            ComboBox_couleur.Location = cbxModele_Couleur.Location
            ComboBox_couleur.Size = cbxModele_Couleur.Size
            AddHandler ComboBox_couleur.SelectedIndexChanged, AddressOf changeCouleurBuseSelected


            'Calibre
            Dim label_calibre As New Label
            label_calibre.Name = "label_calibre_" & pLot
            ongletCategorie.Controls.Add(label_calibre)
            label_calibre.Parent = ongletCategorie
            label_calibre.Font = lblModele_Calibre.Font
            label_calibre.ForeColor = lblModele_Calibre.ForeColor
            label_calibre.Location = lblModele_Calibre.Location
            label_calibre.Size = lblModele_Calibre.Size
            label_calibre.Text = lblModele_Calibre.Text
            label_calibre.TextAlign = lblModele_Calibre.TextAlign

            Dim tb_calibre As New CRODIP_ControlLibrary.TBNumeric
            tb_calibre.Name = "TextBox_calibre_" & pLot
            ongletCategorie.Controls.Add(tb_calibre)
            tb_calibre.Parent = ongletCategorie
            tb_calibre.Location = TbModele_Calibre.Location
            tb_calibre.Size = TbModele_Calibre.Size




            'Débit moyen
            Dim label_debitMoyen As New Label
            label_debitMoyen.Name = "label_debitMoyen_" & pLot
            ongletCategorie.Controls.Add(label_debitMoyen)
            label_debitMoyen.Parent = ongletCategorie
            label_debitMoyen.Font = lblModele_DebitMoyen.Font
            label_debitMoyen.ForeColor = lblModele_DebitMoyen.ForeColor
            label_debitMoyen.Location = lblModele_DebitMoyen.Location
            label_debitMoyen.Size = lblModele_DebitMoyen.Size
            label_debitMoyen.Text = lblModele_DebitMoyen.Text
            label_debitMoyen.TextAlign = lblModele_DebitMoyen.TextAlign
            label_debitMoyen.Anchor = lblModele_DebitMoyen.Anchor

            Dim TextBox_debitMoyen As New CRODIP_ControlLibrary.TBNumeric
            TextBox_debitMoyen.Name = "TextBox_debitMoyen_" & pLot
            ongletCategorie.Controls.Add(TextBox_debitMoyen)
            TextBox_debitMoyen.Parent = ongletCategorie
            TextBox_debitMoyen.Font = tbModele_DebitMoyen.Font
            TextBox_debitMoyen.Location = tbModele_DebitMoyen.Location
            TextBox_debitMoyen.ReadOnly = tbModele_DebitMoyen.ReadOnly
            TextBox_debitMoyen.Size = tbModele_DebitMoyen.Size
            TextBox_debitMoyen.Text = tbModele_DebitMoyen.Text
            TextBox_debitMoyen.Anchor = tbModele_DebitMoyen.Anchor

            'Débit mini
            Dim label_debitMini As New Label
            label_debitMini.Name = "label_debitMini_" & pLot
            ongletCategorie.Controls.Add(label_debitMini)
            label_debitMini.Parent = ongletCategorie
            label_debitMini.Font = lblModele_DebitMini.Font
            label_debitMini.ForeColor = lblModele_DebitMini.ForeColor
            label_debitMini.Location = lblModele_DebitMini.Location
            label_debitMini.Size = lblModele_DebitMini.Size
            label_debitMini.Text = lblModele_DebitMini.Text
            label_debitMini.TextAlign = lblModele_DebitMini.TextAlign
            label_debitMini.Anchor = lblModele_DebitMini.Anchor

            Dim TextBox_debitMini As New CRODIP_ControlLibrary.TBNumeric
            ongletCategorie.Controls.Add(TextBox_debitMini)
            TextBox_debitMini.Parent = ongletCategorie
            TextBox_debitMini.Name = "TextBox_debitMini_" & pLot
            TextBox_debitMini.Font = tbModele_DebitMini.Font
            TextBox_debitMini.Location = tbModele_DebitMini.Location
            TextBox_debitMini.ReadOnly = tbModele_DebitMini.ReadOnly
            TextBox_debitMini.Size = tbModele_DebitMini.Size
            TextBox_debitMini.Text = tbModele_DebitMini.Text
            TextBox_debitMini.Anchor = tbModele_DebitMini.Anchor

            'Débit maxi
            Dim label_debitMaxi As New Label
            label_debitMaxi.Name = "label_debitMaxi_" & pLot
            ongletCategorie.Controls.Add(label_debitMaxi)
            label_debitMaxi.Parent = ongletCategorie
            label_debitMaxi.Font = lblModele_DebitMaxi.Font
            label_debitMaxi.ForeColor = lblModele_DebitMaxi.ForeColor
            label_debitMaxi.Location = lblModele_DebitMaxi.Location
            label_debitMaxi.Size = lblModele_DebitMaxi.Size
            label_debitMaxi.Text = lblModele_DebitMaxi.Text
            label_debitMaxi.TextAlign = lblModele_DebitMaxi.TextAlign
            label_debitMaxi.Anchor = lblModele_DebitMaxi.Anchor

            Dim TextBox_debitMaxi As New CRODIP_ControlLibrary.TBNumeric
            ongletCategorie.Controls.Add(TextBox_debitMaxi)
            TextBox_debitMaxi.Parent = ongletCategorie
            TextBox_debitMaxi.Name = "TextBox_debitMaxi_" & pLot
            TextBox_debitMaxi.Font = tbModele_DebitMaxi.Font
            TextBox_debitMaxi.Location = tbModele_DebitMaxi.Location
            TextBox_debitMaxi.ReadOnly = tbModele_DebitMaxi.ReadOnly
            TextBox_debitMaxi.Size = tbModele_DebitMaxi.Size
            TextBox_debitMaxi.Text = tbModele_DebitMaxi.Text
            TextBox_debitMaxi.Anchor = tbModele_DebitMaxi.Anchor



            'Nb buses usées
            Dim label_nbBusesUsees As New Label
            ongletCategorie.Controls.Add(label_nbBusesUsees)
            label_nbBusesUsees.Name = "label_nbBusesUsees_" & pLot
            label_nbBusesUsees.Parent = ongletCategorie
            label_nbBusesUsees.Font = lblModele_NbBusesUsees.Font
            label_nbBusesUsees.ForeColor = lblModele_NbBusesUsees.ForeColor
            label_nbBusesUsees.Location = lblModele_NbBusesUsees.Location
            label_nbBusesUsees.Size = lblModele_NbBusesUsees.Size
            label_nbBusesUsees.Text = lblModele_NbBusesUsees.Text
            label_nbBusesUsees.TextAlign = lblModele_NbBusesUsees.TextAlign
            label_nbBusesUsees.Anchor = lblModele_NbBusesUsees.Anchor


            Dim TextBox_nbBusesUsees As New CRODIP_ControlLibrary.TBNumeric
            TextBox_nbBusesUsees.Name = "TextBox_nbBusesUsees_" & pLot
            ongletCategorie.Controls.Add(TextBox_nbBusesUsees)
            TextBox_nbBusesUsees.Parent = ongletCategorie
            TextBox_nbBusesUsees.Font = tbModele_NbBusesUsees.Font
            TextBox_nbBusesUsees.Location = tbModele_NbBusesUsees.Location
            TextBox_nbBusesUsees.ReadOnly = tbModele_NbBusesUsees.ReadOnly
            TextBox_nbBusesUsees.Size = tbModele_NbBusesUsees.Size
            TextBox_nbBusesUsees.Text = tbModele_NbBusesUsees.Text
            TextBox_nbBusesUsees.Anchor = tbModele_NbBusesUsees.Anchor



            'Usure moyenne des buses
            Dim label_usureMoyenneBuses As New Label
            label_usureMoyenneBuses.Name = "label_usureMoyenneBuses_" & pLot
            ongletCategorie.Controls.Add(label_usureMoyenneBuses)
            label_usureMoyenneBuses.Parent = ongletCategorie
            label_usureMoyenneBuses.Font = lblModele_UsureMoyenne.Font
            label_usureMoyenneBuses.ForeColor = lblModele_UsureMoyenne.ForeColor
            label_usureMoyenneBuses.Location = lblModele_UsureMoyenne.Location
            label_usureMoyenneBuses.Size = lblModele_UsureMoyenne.Size
            label_usureMoyenneBuses.Text = lblModele_UsureMoyenne.Text
            label_usureMoyenneBuses.TextAlign = lblModele_UsureMoyenne.TextAlign
            label_usureMoyenneBuses.Anchor = lblModele_UsureMoyenne.Anchor

            Dim TEXTBOX_usureMoyenneBuses As New CRODIP_ControlLibrary.TBNumeric
            TEXTBOX_usureMoyenneBuses.Name = "TEXTBOX_usureMoyenneBuses_" & pLot
            ongletCategorie.Controls.Add(TEXTBOX_usureMoyenneBuses)
            TEXTBOX_usureMoyenneBuses.Parent = ongletCategorie
            TEXTBOX_usureMoyenneBuses.Font = tbModele_UsureMoyenne.Font
            TEXTBOX_usureMoyenneBuses.Location = tbModele_UsureMoyenne.Location
            TEXTBOX_usureMoyenneBuses.ReadOnly = tbModele_UsureMoyenne.ReadOnly
            TEXTBOX_usureMoyenneBuses.Size = tbModele_UsureMoyenne.Size
            TEXTBOX_usureMoyenneBuses.Text = tbModele_UsureMoyenne.Text
            TEXTBOX_usureMoyenneBuses.Anchor = tbModele_UsureMoyenne.Anchor

            '
            'Panel principal liste des buses
            '
            Dim Panel_listePrincipale As New Panel
            Panel_listePrincipale.Name = "Panel_listePrincipale_" & pLot
            ongletCategorie.Controls.Add(Panel_listePrincipale)
            Panel_listePrincipale.Parent = ongletCategorie
            Panel_listePrincipale.AutoScroll = pblModele_tabMesuresBuses.AutoScroll
            Panel_listePrincipale.BackColor = pblModele_tabMesuresBuses.BackColor
            Panel_listePrincipale.Location = pblModele_tabMesuresBuses.Location
            Panel_listePrincipale.Size = pblModele_tabMesuresBuses.Size
            Panel_listePrincipale.Anchor = pblModele_tabMesuresBuses.Anchor
            '
            'Panel titre : "N°"
            '
            Dim Panel_titreNum As New Panel
            Panel_listePrincipale.Controls.Add(Panel_titreNum)
            Panel_titreNum.Parent = Panel_listePrincipale
            Panel_titreNum.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_titreNum.Location = New System.Drawing.Point(0, 0)
            Panel_titreNum.Name = "Panel_titreNum_" & pLot
            Panel_titreNum.Size = New System.Drawing.Size(72, 40)
            '
            'Label titre : "N°"
            '
            Dim label_titreNum As New Label
            Panel_listePrincipale.Controls.Add(label_titreNum)
            label_titreNum.Parent = Panel_titreNum
            label_titreNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label_titreNum.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            label_titreNum.Location = New System.Drawing.Point(16, 12)
            label_titreNum.Name = "label_titreNum_" & pLot
            label_titreNum.Size = New System.Drawing.Size(40, 16)
            label_titreNum.Text = "N°"
            label_titreNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            '
            'Panel titre : "Débit"
            '
            Dim Panel_titreDebit As New Panel
            Panel_listePrincipale.Controls.Add(Panel_titreDebit)
            Panel_titreDebit.Parent = Panel_listePrincipale
            Panel_titreDebit.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_titreDebit.Location = New System.Drawing.Point(0, 41)
            Panel_titreDebit.Name = "Panel_titreDebit_" & pLot
            Panel_titreDebit.Size = New System.Drawing.Size(72, 71)
            '
            'Label titre : "Débit"
            '
            Dim label_titreDebit As New Label
            Panel_listePrincipale.Controls.Add(label_titreDebit)
            label_titreDebit.Parent = Panel_titreDebit
            label_titreDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label_titreDebit.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            label_titreDebit.Location = New System.Drawing.Point(8, 27)
            label_titreDebit.Name = "label_titreDebit_" & pLot
            label_titreDebit.Size = New System.Drawing.Size(56, 16)
            label_titreDebit.Text = "Débit"
            label_titreDebit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            '
            'Panel titre : "Usure"
            '
            Dim Panel_titreUsure As New Panel
            Panel_listePrincipale.Controls.Add(Panel_titreUsure)
            Panel_titreUsure.Parent = Panel_listePrincipale
            Panel_titreUsure.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            Panel_titreUsure.Location = New System.Drawing.Point(0, 113)
            Panel_titreUsure.Name = "Panel_titreUsure_" & pLot
            Panel_titreUsure.Size = New System.Drawing.Size(72, 71)
            '
            'Label titre : "Usure"
            '
            Dim label_titreUsure As New Label
            Panel_listePrincipale.Controls.Add(label_titreUsure)
            label_titreUsure.Parent = Panel_titreUsure
            label_titreUsure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label_titreUsure.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            label_titreUsure.Location = New System.Drawing.Point(4, 27)
            label_titreUsure.Name = "label_titreUsure_" & pLot
            label_titreUsure.Size = New System.Drawing.Size(64, 16)
            label_titreUsure.Text = "Usure (%)"
            label_titreUsure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            '
            'Panel secondaire liste des buses
            '
            Dim Panel_listeSecondaire As New Panel
            Panel_listeSecondaire.Name = "Panel_listeSecondaire_" & pLot
            Panel_listePrincipale.Controls.Add(Panel_listeSecondaire)
            Panel_listeSecondaire.Parent = Panel_listePrincipale
            Panel_listeSecondaire.AutoScroll = pnlModele_tabMesureSecondaire.AutoScroll
            Panel_listeSecondaire.BackColor = pnlModele_tabMesureSecondaire.BackColor
            Panel_listeSecondaire.Location = pnlModele_tabMesureSecondaire.Location
            Panel_listeSecondaire.Size = pnlModele_tabMesureSecondaire.Size
            Panel_listeSecondaire.Anchor = pnlModele_tabMesureSecondaire.Anchor
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.createControls_LotBuses ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    ''' <summary>
    ''' Ajouter un lot de buses
    ''' </summary>
    ''' <param name="pNbLotAAjouter">Nbre de Lots à ajouter</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub ajouterLotBuses(ByVal pNbLotAAjouter As Integer)
        Try



            ' On compte le nombre de catégories existantes
            Dim curNbTab As Integer = diagBuses_tab_categories.TabPages.Count()
            Dim nbCategories As Integer = pNbLotAAjouter + curNbTab
            curNbTab += 1 ''???


            ' On ajoute les onglets
            Dim nbCatMax As Integer = 50
            If nbCategories > nbCatMax Then
                nbCategories = nbCatMax
            End If
            'objInfos(9) = nbCategories
            'Parcours des nouveau Lots
            For i As Integer = curNbTab To nbCategories

                ' On créé un nouvel onglet pour notre tabControl
                Dim ongletCategorie As New TabPage
                ongletCategorie.Text = "Niveau n°" & i
                ongletCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                diagBuses_tab_categories.TabPages.Add(ongletCategorie)

                '=======================
                'Création des controles dans le nouvel onglet
                '=======================
                createControls_LotBuse(ongletCategorie, i)

                ' On charge les infos dans les combo
                loadReferentielBuses(i)

                'Ajout de la liste des buses
                m_DiagBuses.Liste.Add(New DiagnosticBuses())

                'l'écartToléré est fixé en fonction du paramétrage
                Dim cbxEcartTolere As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & i, diagBuses_tab_categories)
                cbxEcartTolere.Text = m_oParamdiag.ParamDiagCalc922.pctToleranceDebitNominal

            Next
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.ajouterLotBuses ERR : " & ex.Message.ToString)

        End Try
    End Sub
    Private Sub diagBuses_conf_ajouterNiveau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagBuses_conf_ajouterNiveau.Click
        Try

            Dim nbToAdd As Integer = 1

            ajouterLotBuses(nbToAdd)

            If diagBuses_conf_nbCategories.Text = "" Then
                diagBuses_conf_nbCategories.Text = 0
            End If
            Dim nbBuses As Integer = CInt(diagBuses_conf_nbCategories.Text())
            nbBuses += nbToAdd
            diagBuses_conf_nbCategories.Text() = nbBuses
        Catch ex As Exception
            CSDebug.dispError("diagBuses_conf_ajouterNiveau_Click ERR : " & ex.Message.ToString)

        End Try

    End Sub
    Private Sub diagBuses_conf_validNbCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagBuses_conf_validNbCategories.Click
        Try

            validNbCategories()
        Catch ex As Exception
            CSDebug.dispError("diagBuses_conf_validNbCategories_Click ERR : " & ex.Message.ToString)

        End Try

    End Sub

    ' Supprime les buses
    Private Sub deletNbBuses(ByVal lotId As Integer)
        Try
            Dim tmpPanel As Panel = CSForm.getControlByName("Panel_listeSecondaire_" & lotId, diagBuses_tab_categories)
            tmpPanel.Controls.Clear()
            'Suppression des buses dans la collection
            Dim oListbuses As DiagnosticBuses = m_DiagBuses.Liste.Item(lotId - 1)
            oListbuses.diagnosticBusesDetailList.Liste.Clear()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::deletNbBuses : " & ex.Message)
        End Try
    End Sub

    Private Function createControls_Buses(Panel_listeSecondaire As Panel, LotId As Integer, pNBuse As Integer, PositionY As Integer) As Boolean

        '
        'Panel value : "Numéro de buse"
        '
        Dim Panel_valueNumBuse As New Panel
        Panel_listeSecondaire.Controls.Add(Panel_valueNumBuse)
        Panel_valueNumBuse.Parent = Panel_listeSecondaire
        Panel_valueNumBuse.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
        Panel_valueNumBuse.Location = New System.Drawing.Point(PositionY, 0)
        Panel_valueNumBuse.Name = "Panel_valueNumBuse_" & LotId & "_" & pNBuse
        Panel_valueNumBuse.Size = New System.Drawing.Size(87, 40)
        '
        'Panel value : "Débit"
        '
        Dim Panel_valueDebit As New Panel
        Panel_listeSecondaire.Controls.Add(Panel_valueDebit)
        Panel_valueDebit.Parent = Panel_listeSecondaire
        Panel_valueDebit.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
        Panel_valueDebit.Location = New System.Drawing.Point(PositionY, 41)
        Panel_valueDebit.Name = "Panel_valueDebit_" & LotId & "_" & pNBuse
        Panel_valueDebit.Size = New System.Drawing.Size(87, 71)
        '
        'Panel value : "Usure"
        '
        Dim Panel_valueUsure As New Panel
        Panel_listeSecondaire.Controls.Add(Panel_valueUsure)
        Panel_valueUsure.Parent = Panel_listeSecondaire
        Panel_valueUsure.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
        Panel_valueUsure.Location = New System.Drawing.Point(PositionY, 113)
        Panel_valueUsure.Name = "Panel_valueUsure_" & LotId & "_" & pNBuse
        Panel_valueUsure.Size = New System.Drawing.Size(87, 71)
        Panel_valueUsure.TabStop = False

        '
        'Label value : "Numéro de buse"
        '
        Dim label_valueNumBuse As New Label
        Panel_listeSecondaire.Controls.Add(label_valueNumBuse)
        label_valueNumBuse.Parent = Panel_valueNumBuse
        label_valueNumBuse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        label_valueNumBuse.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
        label_valueNumBuse.Location = New System.Drawing.Point(29, 12)
        label_valueNumBuse.Name = "label_valueNumBuse_" & LotId & "_" & pNBuse
        label_valueNumBuse.Size = New System.Drawing.Size(28, 16)
        label_valueNumBuse.Text = pNBuse
        label_valueNumBuse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagBuses_mesureDebit_1_debit
        '
        Dim TEXTBox_mesureDebit_debit As New CRODIP_ControlLibrary.TBNumeric
        Panel_listeSecondaire.Controls.Add(TEXTBox_mesureDebit_debit)
        TEXTBox_mesureDebit_debit.Parent = Panel_valueDebit
        TEXTBox_mesureDebit_debit.Location = New System.Drawing.Point(15, 25)
        TEXTBox_mesureDebit_debit.Name = "diagBuses_mesureDebit_" & LotId & "_" & pNBuse & "_debit"
        TEXTBox_mesureDebit_debit.Size = New System.Drawing.Size(56, 20)
        TEXTBox_mesureDebit_debit.Text = ""
        AddHandler TEXTBox_mesureDebit_debit.Validated, AddressOf calcUsureBuse_Validated

        '
        'diagBuses_mesureDebit_1_usure
        '
        Dim TextBox_mesureDebit_usure As New CRODIP_ControlLibrary.TBNumeric
        Panel_listeSecondaire.Controls.Add(TextBox_mesureDebit_usure)
        TextBox_mesureDebit_usure.Parent = Panel_valueUsure
        TextBox_mesureDebit_usure.Location = New System.Drawing.Point(15, 25)
        TextBox_mesureDebit_usure.Name = "diagBuses_mesureDebit_" & LotId & "_" & pNBuse & "_usure"
        TextBox_mesureDebit_usure.Size = New System.Drawing.Size(56, 20)
        TextBox_mesureDebit_usure.Text = ""
        TextBox_mesureDebit_usure.BackColor = System.Drawing.SystemColors.Control
        TextBox_mesureDebit_usure.ForeColor = System.Drawing.Color.Black
        TextBox_mesureDebit_usure.TabStop = False
        TextBox_mesureDebit_usure.ReadOnly = True 'Le ReadOnly n'affecte pas les couleurs, à l'inverse du Enable

    End Function
    ' Valide le nombre de buses dans un niveau
    Private Sub validerNbBuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CSDebug.dispInfo("validerNbBuses_Click")
        ' On récupère le numéro du lot
        Dim lotId As Integer = CType(sender.Name.ToString.Replace("Button_valider_nbBuses_", ""), Integer)
        ' On récupère le nombre de buses pour ce lot
        Dim input_nbBuses As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
        If Not IsNumeric(input_nbBuses.Text) Then
            MsgBox("Vous devez saisir un nombre valide !")
            input_nbBuses.Focus()
            Exit Sub
        End If
        Try
            Dim nbBuses As Integer = CType(input_nbBuses.Text, Integer)
            valideNbBuses(lotId, nbBuses)
        Catch ex As Exception
            CSDebug.dispError("validerNbBuses_Click ERR : " & ex.Message.ToString)

        End Try

    End Sub
    Private Sub valideNbBuses(Lotid As Integer, nbBuses As Integer)
        deletNbBuses(Lotid)
        'Récupération de la liste des buses correspondant au Lot
        Dim oListbuses As DiagnosticBuses = m_DiagBuses.Liste.Item(Lotid - 1)

        If nbBuses > 100 Then
            nbBuses = 100
        End If
        ' On récupère le panel de la liste des buses
        Dim Panel_listeSecondaire As Panel = CSForm.getControlByName("Panel_listeSecondaire_" & Lotid, diagBuses_tab_categories)
        ' On ajoute dynamiquement les controles pour la saisie des buses
        Dim positionY As Integer = 1
        For x As Integer = 1 To nbBuses
            If x = 1 Then
                positionY = 1
            Else
                positionY = positionY + 88
            End If
            'création des controls d'une buses
            createControls_Buses(Panel_listeSecondaire, Lotid, x, positionY)
            'Ajout d'une buse dans la Liste
            oListbuses.diagnosticBusesDetailList.Liste.Add(New DiagnosticBusesDetail())
        Next
        checkIsOk(8)

    End Sub

    ' UsureReadOnly
    Private Sub usureBuseReadOnly_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    ' Calcul de l'usure d'une buse
    Private Sub calcUsureBuse_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CSDebug.dispInfo("calcUsureBuse_Validated")
        Try
            ' On récupère le lot et le numero de buse
            Dim infosIds As String() = sender.Name.ToString.Replace("diagBuses_mesureDebit_", "").Replace("_debit", "").Split("_")
            Dim lotId As Integer = infosIds(0)
            Dim buseId As Integer = infosIds(1)
            ' On calcul
            mutCalcDebitMoy(lotId)
            fillDebitNominalPourCalcul(lotId)
            mutCalcUsure1Buse(lotId, buseId)
            mutCalcIs1BuseUsee(lotId, buseId)
            mutCalcTotal()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::calcUsureBuse_TextChanged : " & ex.Message)
        End Try
    End Sub



    ' Changement debit nominal Pour Calcul
    Private Sub debitNominalPourCalcul_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Not m_bDuringLoad Then
                Dim lotId As Integer = CType(sender.name.replace("TextBox_debitNominal_", ""), Integer)
                mutCalcLot(lotId)
                mutCalcTotal()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::debitNominalPourCalcul_TextChanged : " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Calcul cu nbre de buses, le débit moyen et l'usure moyenne des buses TOUS lots confondus
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mutCalcTotal()
        mutCalcUsureMoyBuses()
        mutCalcNbBusesUsee()
        mutCalcDebitMoy()
    End Sub
    ' Changement debit nominal constructeur
    Private Sub DebitNominalCONSTructeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Dim lotId As Integer = CType(sender.name.replace("TextBox_debitNominalCONSTructeur_", ""), Integer)
            fillDebitNominalPourCalcul(lotId)
            Dim tbdebitNominal As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
            m_DiagBuses.Liste(lotId - 1).debitNominal = tbdebitNominal.Text
            'Recalcul de l'ensemble du lot 
            mutCalcLot(lotId)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::DebitNominalCONSTructeur_TextChanged : " & ex.Message)
        End Try
        'mutCalcNbBusesUsed()
        'mutCalcUsureMoyBuses()
    End Sub
    Private Sub ecartTolere_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim lotId As Integer = CType(sender.name.replace("ComboBox_ecartTolere_", ""), Integer)
            Dim ecartTolereTextBox As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)
            Dim ecartTolereValue As Decimal = CType(ecartTolereTextBox.Text, Decimal)
            m_DiagBuses.Liste(lotId - 1).ecartTolere = ecartTolereValue
            If sender.text <> "" Then
                mutCalcLot(lotId)
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::ecartTolere_SelectedIndexChanged ERR : " & ex.Message)

        End Try

    End Sub


    ' Changement pression de mesure
    Private Sub diagBuses_conf_pressionMesure_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPressionMesure.TextChanged
        Try
            LaDebitMoyenBuses.Text = "Debit moyen à " & tbPressionMesure.Text & " bars : "
            Dim debitBuses As Decimal
            Dim pressionMesureBuses As Decimal
            debitBuses = diagBuses_debitMoyen.DecimalValue
            pressionMesureBuses = tbPressionMesure.DecimalValue

            tbDebitMoyen3bars.Text = m_diagnostic.calDebitMoyen(debitBuses, pressionMesureBuses, 3)
            AfficheDebitNominalCONSTructeur()
            'help552_pressionMesure.Text = diagBuses_conf_pressionMesure.Text
            checkIsOk(8)

        Catch ex As Exception
            CSDebug.dispError("diagnostique::diagBuses_conf_pressionMesure_TextChanged ERR : " & ex.Message)

        End Try

    End Sub
    ''' <summary>
    ''' Affiche le débitNominalconstructures pour tous les lots
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AfficheDebitNominalCONSTructeur()
        If IsNumeric(diagBuses_conf_nbCategories.Text) And diagBuses_conf_nbCategories.Text <> "" Then
            Try
                'Récupération du nombre de lot
                Dim nbLot As Integer = Integer.Parse(diagBuses_conf_nbCategories.Text)
                For nLot As Integer = 1 To nbLot
                    'Affichage du debit nominal pour un lot
                    AfficheDebitNominalContructeur(nLot)
                Next
            Catch
            End Try


        End If
    End Sub

#End Region

#Region " Sauvegarde des infos buses "

    Private Sub addLvlBuses2(ByVal idDiagnostic As String, ByVal marque As String, ByVal nombre As String, ByVal genre As String, ByVal calibre As String, ByVal couleur As String, ByVal ecartTolere As String, ByVal debitMoyen As String, ByVal busesListDetail As DiagnosticBusesDetailList, ByVal lotId As String, ByVal debitNominal As String)

        Try

            ' On crée notre nouvelle buse
            Dim tmpBuse As New DiagnosticBuses
            tmpBuse.idDiagnostic = idDiagnostic
            tmpBuse.idLot = lotId
            tmpBuse.marque = marque
            tmpBuse.nombre = nombre
            tmpBuse.genre = genre
            tmpBuse.calibre = calibre
            tmpBuse.couleur = couleur
            tmpBuse.ecartTolere = ecartTolere
            tmpBuse.debitMoyen = debitMoyen
            tmpBuse.debitNominal = debitNominal
            tmpBuse.diagnosticBusesDetailList = New DiagnosticBusesDetailList

            ' On agrandi notre tableau
            'If diagnosticCourant.diagnosticBusesList Is Nothing Then
            '    diagnosticCourant.diagnosticBusesList = New DiagnosticBusesList
            'End If
            'If diagnosticCourant.diagnosticBusesList.diagnosticBuses Is Nothing Then
            '    ReDim diagnosticCourant.diagnosticBusesList.diagnosticBuses(0)
            'Else
            '    ReDim Preserve diagnosticCourant.diagnosticBusesList.diagnosticBuses(diagnosticCourant.diagnosticBusesList.diagnosticBuses.Length)
            'End If

            ' On ajoute le détail des mesures de buses au lot courant
            tmpBuse.diagnosticBusesDetailList = busesListDetail

            ' On l'ajoute au diag courant
            m_diagnostic.diagnosticBusesList.Liste.Add(tmpBuse)

        Catch ex As Exception
            CSDebug.dispError("diagnostique::addLvlBuses : " & ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Validation de l'onglet Buses
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValiderDiagnostiqueBuses() As Boolean
        'CSDebug.dispInfo("Diagnostique.SaveBuses")
        Dim oBanc As Banc
        Dim nbLots As Integer
        Try

            If buses_listBancs.SelectedItem IsNot Nothing Then
                oBanc = BancManager.getBancById(buses_listBancs.SelectedItem.id())
                If oBanc IsNot Nothing Then
                    m_diagnostic.controleBancMesureId = oBanc.id
                End If
            End If
            If Not String.IsNullOrEmpty(tbPressionMesure.Text) Then
                m_diagnostic.manometrePressionTravail = tbPressionMesure.Text
            End If
            '------------------------------------------------------
            '--- On boucle les lots
            '------------------------------------------------------
            Try
                nbLots = CType(diagBuses_conf_nbCategories.Text, Integer)
            Catch ex As Exception
                CSDebug.dispError("diagnostique::saveBuses : " & ex.Message)
                nbLots = 0
            End Try
            'Suppression des Buses existantes (elles sont toutes regénérées ici)
            m_diagnostic.diagnosticBusesList.Liste.Clear()
            For lotId As Integer = 1 To nbLots
                ' On récupère les contrôles
                Dim inputMarque As ComboBox = CSForm.getControlByName("ComboBox_marque_" & lotId, diagBuses_tab_categories)
                Dim inputGenre As ComboBox = CSForm.getControlByName("ComboBox_modele_" & lotId, diagBuses_tab_categories)
                Dim inputCouleur As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
                Dim inputCalibre As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_calibre_" & lotId, diagBuses_tab_categories)
                Dim inputNombre As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & lotId, diagBuses_tab_categories)
                Dim inputNombreUsees As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBusesUsees_" & lotId, diagBuses_tab_categories)
                Dim inputDebitMoy As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMoyen_" & lotId, diagBuses_tab_categories)
                Dim inputdebitNominalPourCalcul As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & lotId, diagBuses_tab_categories)
                Dim inputDebitNominal As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominal_" & lotId, diagBuses_tab_categories)
                Dim inputEcartTolere As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)
                Dim inputDebitMin As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMini_" & lotId, diagBuses_tab_categories)
                Dim inputDebitMax As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitMaxi_" & lotId, diagBuses_tab_categories)

                'Création de la Buse
                Dim tmpBuse As New DiagnosticBuses
                tmpBuse.idDiagnostic = m_diagnostic.id
                tmpBuse.idLot = lotId
                tmpBuse.marque = inputMarque.Text
                tmpBuse.nombre = inputNombre.Text
                tmpBuse.genre = inputGenre.Text
                tmpBuse.calibre = inputCalibre.Text
                tmpBuse.couleur = inputCouleur.Text
                tmpBuse.ecartTolere = inputEcartTolere.Text
                tmpBuse.debitMoyen = inputDebitMoy.Text
                tmpBuse.debitNominal = inputDebitNominal.Text
                tmpBuse.debitMax = inputDebitMax.Text
                tmpBuse.debitMin = inputDebitMin.Text
                tmpBuse.nombrebusesusees = inputNombreUsees.Text
                tmpBuse.Resultat = diagBuses_resultat.Text

                ' Pour le lot courant, on parcourt les buses
                Dim nbBuses As Integer = CInt(inputNombre.Text)
                For buseId As Integer = 1 To nbBuses
                    ' On récupère l'usure de la buse
                    Dim inputBuseUsure As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_usure", diagBuses_tab_categories)
                    Dim inputBuseDebit As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & lotId & "_" & buseId & "_debit", diagBuses_tab_categories)

                    ' On enregistre la mesure pour la buse en BDD
                    Dim detailBuse As DiagnosticBusesDetail = New DiagnosticBusesDetail
                    detailBuse.debit = inputBuseDebit.Text
                    detailBuse.ecart = inputBuseUsure.Text
                    detailBuse.idBuse = buseId
                    detailBuse.idLot = lotId
                    detailBuse.idDiagnostic = ""
                    detailBuse.usee = (inputBuseUsure.Tag = "NOK") 'Usée si elles sont NOK

                    tmpBuse.diagnosticBusesDetailList.Liste.Add(detailBuse)

                Next buseId
                m_diagnostic.diagnosticBusesList.Liste.Add(tmpBuse)


            Next lotId
            '------------------------------------------------------
            '--- FIN -- On boucle les lots
            '------------------------------------------------------
            'Récupération de la pression de mesure à 3 bars
            m_diagnostic.buseDebit = tbDebitMoyen3bars.Text
            m_diagnostic.buseDebitMoyenPM = GlobalsCRODIP.StringToDouble(diagBuses_debitMoyen.Text)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::ValiderDiagnostiqueBuses : " & ex.Message)
        End Try

    End Function

#End Region

#Region " Chargement référentiel buses "

    Private Sub refBuses_loadMarques(ByVal lotId As Integer)
        Try

            ' On récupère tous les contrôles
            Dim controlToPopulate As ComboBox = CSForm.getControlByName("ComboBox_marque_" & lotId, diagBuses_tab_categories)
            m_referentielBuses.getMarques()
            controlToPopulate.Items.AddRange(m_referentielBuses.getMarques().ToArray)
            '            ReferentielBuseManager.populateCombo("marque", controlToPopulate)

            Dim inputGenres As ComboBox = CSForm.getControlByName("ComboBox_modele_" & lotId, diagBuses_tab_categories)
            Dim inputCouleurs As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
            inputGenres.Enabled = False
            inputCouleurs.Enabled = False
        Catch ex As Exception
            CSDebug.dispError("diagnostique::refBuses_loadMarques ERR : " & ex.Message)

        End Try

    End Sub
    Private Sub refBuses_loadModeles(ByVal lotId As Integer, ByVal marque As String)
        Try

            ' On récupère tous les contrôles
            Dim controlToPopulate As ComboBox = CSForm.getControlByName("ComboBox_modele_" & lotId, diagBuses_tab_categories)
            If controlToPopulate IsNot Nothing Then
                controlToPopulate.Items.Clear()
                controlToPopulate.Items.AddRange(m_referentielBuses.getModeles(marque).ToArray())
                controlToPopulate.Enabled = True
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::refBuses_loadModeles ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub refBuses_loadCouleurs(ByVal lotId As Integer, ByVal marque As String, modele As String)
        Try

            ' On récupère tous les contrôles
            Dim cbxCouleur As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
            If cbxCouleur IsNot Nothing Then
                cbxCouleur.Items.Clear()
                cbxCouleur.Items.AddRange(m_referentielBuses.getCouleursBuseByMarqueModele(marque, modele).ToArray())
                cbxCouleur.Enabled = True
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::refBuses_loadCoulerus ERR : " & ex.Message)

        End Try

    End Sub
    Private Sub loadReferentielBuses(ByVal lotId As Integer)
        Try

            refBuses_loadMarques(lotId)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::loadReferentielBuses ERR : " & ex.Message)

        End Try
    End Sub

    Private Sub changeMarqueBuseSelected(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            ' On récupère les contrôles
            Dim cbxMarques As ComboBox = sender

            ' On récupère l'id du lot
            Dim lotId As Integer = CType(cbxMarques.Name.Replace("ComboBox_marque_", ""), Integer)

            m_DiagBuses.Liste(lotId - 1).marque = cbxMarques.Text
            ' On charge les genres et couleurs
            refBuses_loadModeles(lotId, cbxMarques.Text)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::changeMarqueBuseSelected ERR : " & ex.Message)

        End Try

    End Sub

    Private Sub changeModeleBuseSelected(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' On récupère l'id du lot
            Dim lotId As Integer = CType(sender.Name.Replace("ComboBox_modele_", ""), Integer)

            ' On récupère les controles
            Dim cbxMarque As ComboBox = CSForm.getControlByName("ComboBox_marque_" & lotId, diagBuses_tab_categories)
            Dim cbxModele As ComboBox = CSForm.getControlByName("ComboBox_modele_" & lotId, diagBuses_tab_categories)

            refBuses_loadCouleurs(lotId, cbxMarque.Text, cbxModele.Text)

        Catch ex As Exception
            CSDebug.dispError("changeModeleBuseSelected : " & ex.Message)
        End Try
    End Sub

    Private Sub changeCouleurBuseSelected(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' On récupère l'id du lot
        Dim lotId As Integer = CType(sender.Name.Replace("ComboBox_couleur_", ""), Integer)

        ' On récupère les controles
        Dim cbxMarque As ComboBox = CSForm.getControlByName("ComboBox_marque_" & lotId, diagBuses_tab_categories)
        Dim cbxModele As ComboBox = CSForm.getControlByName("ComboBox_modele_" & lotId, diagBuses_tab_categories)
        Dim cbxCouleur As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & lotId, diagBuses_tab_categories)
        Dim cbxEcart As ComboBox = CSForm.getControlByName("ComboBox_ecartTolere_" & lotId, diagBuses_tab_categories)

        Dim tbCalibre As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_calibre_" & lotId, diagBuses_tab_categories)
        Dim tbDebit As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & lotId, diagBuses_tab_categories)

        'Mise à jour du Calibre
        If tbCalibre IsNot Nothing Then
            tbCalibre.Text = m_referentielBuses.getCalibresBuse(cbxMarque.Text, cbxModele.Text, cbxCouleur.Text)(0)
        End If
        'Mise à jour du débit nominal constructeur
        AfficheDebitNominalContructeur(lotId)
        'Mise à jour de l'écart Toléré
        If cbxEcart IsNot Nothing Then
            cbxEcart.Text = m_referentielBuses.getToleranceBuse(cbxMarque.Text, cbxModele.Text, cbxCouleur.Text)(0)
        End If


    End Sub
    ''' <summary>
    ''' Affichage du débit nominal constructeur d'un lot
    ''' </summary>
    ''' <param name="LotId"></param>
    ''' <remarks></remarks>
    Private Sub AfficheDebitNominalContructeur(LotId As String)

        ' On récupère les controles
        Dim cbxMarque As ComboBox = CSForm.getControlByName("ComboBox_marque_" & LotId, diagBuses_tab_categories)
        Dim cbxModele As ComboBox = CSForm.getControlByName("ComboBox_modele_" & LotId, diagBuses_tab_categories)
        Dim cbxCouleur As ComboBox = CSForm.getControlByName("ComboBox_couleur_" & LotId, diagBuses_tab_categories)

        Dim tbDebit As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & LotId, diagBuses_tab_categories)

        'Mise à jour du débit nominal constructeur
        If tbDebit IsNot Nothing Then
            Select Case tbPressionMesure.Text
                Case "2"
                    tbDebit.Text = m_referentielBuses.getDebit2barBuse(cbxMarque.Text, cbxModele.Text, cbxCouleur.Text)(0)
                Case "3"
                    tbDebit.Text = m_referentielBuses.getDebit3barBuse(cbxMarque.Text, cbxModele.Text, cbxCouleur.Text)(0)
                Case "5"
                    tbDebit.Text = m_referentielBuses.getDebit5barBuse(cbxMarque.Text, cbxModele.Text, cbxCouleur.Text)(0)
                Case Else
                    tbDebit.Text = ""

            End Select
        End If
    End Sub

#End Region

#Region " Acquisition des données "
    Private Function GetBanc() As Banc
        Dim oReturn As Banc = Nothing

        If buses_listBancs.SelectedItem IsNot Nothing Then
            oReturn = BancManager.getBancById(buses_listBancs.SelectedItem.id())
        End If

        Return oReturn
    End Function

    Private Function CheckAcquisition(pBanc As Banc) As Boolean
        Debug.Assert(pBanc IsNot Nothing)
        Dim bReturn As Boolean
        Try

            Dim oModuleAcquisition As CRODIPAcquisition.ModuleAcq
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule(pBanc.ModuleAcquisition)

            'Récupération du nombre de niveau et du nombre de buses
            Dim nbNiveauDeclare As Integer = 0
            Dim nbBusesDeclare As Integer = 0
            If diagBuses_conf_nbCategories.Text <> "" And IsNumeric(diagBuses_conf_nbCategories.Text) Then
                nbNiveauDeclare = CInt(diagBuses_conf_nbCategories.Text)
            End If
            'Vérification du nombre de niveau en acquisition
            Dim nbNiveauAcquis As Integer = oModuleAcquisition.getNbNiveaux()
            bReturn = (nbNiveauAcquis = nbNiveauDeclare)
            If bReturn Then
                'Vérification du nombre de buses en acquisition
                'Boucle sur le nombre de niveau
                Dim tb As CRODIP_ControlLibrary.TBNumeric
                For nNiveau As Integer = 1 To nbNiveauDeclare
                    'Récupération du nombre de buses du niveau
                    nbBusesDeclare = -1
                    tb = CSForm.getControlByName("TextBox_nbBuses_" & nNiveau, Me)
                    If tb.Text <> "" And IsNumeric(tb.Text) Then
                        nbBusesDeclare = CInt(tb.Text)
                    End If
                    Dim nbBusesAcquis As Integer = oModuleAcquisition.getNbBuses(nNiveau)
                    bReturn = bReturn And (nbBusesDeclare = nbBusesAcquis)
                Next
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique.CheckAcquisition ERR:" & ex.Message)
            bReturn = False
        End Try

        Return bReturn

    End Function
    ''' <summary>
    ''' Fait l'acquisition des données de buses et les écrit dans le tableau
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub doAcquiring()
        Dim obanc As Banc
        obanc = GetBanc()
        If obanc Is Nothing Then
            Return
        End If

        Dim isok As Boolean
        'Récupération du nombre de niveau et du nombre de buses
        Dim nbNiveauDeclare As Integer = 0
        Dim nbBusesDeclare As Integer = 0
        If diagBuses_conf_nbCategories.Text <> "" And IsNumeric(diagBuses_conf_nbCategories.Text) Then
            nbNiveauDeclare = CInt(diagBuses_conf_nbCategories.Text)
        End If
        isok = CheckAcquisition(obanc)
        If isok Then
            Dim oModuleAcquisition As CRODIPAcquisition.ModuleAcq
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule(obanc.ModuleAcquisition)
            ' On récupère les buses de la table d'échange
            Dim lstValues As List(Of CRODIPAcquisition.AcquisitionValue) = oModuleAcquisition.getValues()
            For Each oValue As CRODIPAcquisition.AcquisitionValue In lstValues
                If oValue.NumBuse <> 0 Then
                    ' On transmet le tout au diag
                    Try


                        Dim x As Control
                        x = CSForm.getControlByName("diagBuses_mesureDebit_" & oValue.Niveau.ToString & "_" & oValue.NumBuse & "_debit", globFormDiagnostic)
                        If x IsNot Nothing Then
                            x.Text = oValue.Debit.ToString
                            mutCalcUsure1Buse(oValue.Niveau, oValue.NumBuse)
                            mutCalcIs1BuseUsee(oValue.Niveau, oValue.NumBuse)
                        End If
                        If oValue.DebitNominal <> -1 Then
                            'Debit Nominal constructeur
                            x = CSForm.getControlByName("TextBox_debitNominalCONSTructeur_" & oValue.Niveau, diagBuses_tab_categories)
                            If x IsNot Nothing Then
                                x.Text = oValue.DebitNominal
                            End If
                            'Debit Nominal pour Calcul
                            x = CSForm.getControlByName("TextBox_debitNominal_" & oValue.Niveau, diagBuses_tab_categories)
                            If x IsNot Nothing Then
                                x.Text = oValue.DebitNominal
                            End If
                        End If
                        If oValue.MarqueTypeFonctionement <> "" Then
                            Try
                                Dim tab As String() = oValue.MarqueTypeFonctionement.Split("-")
                                Dim strMarque As String = tab(0).Trim
                                Dim strModele As String = tab(1).Trim
                                Dim strFonction As String = tab(2).Trim

                                x = CSForm.getControlByName("ComboBox_marque_" & oValue.Niveau, diagBuses_tab_categories)
                                If x IsNot Nothing Then
                                    x.Text = strMarque
                                End If
                                x = CSForm.getControlByName("ComboBox_modele_" & oValue.Niveau, diagBuses_tab_categories)
                                If x IsNot Nothing Then
                                    x.Text = strModele
                                End If

                            Catch

                            End Try
                        End If
                        If oValue.Calibre <> "" Then
                            Try
                                Dim tab As String() = oValue.MarqueTypeFonctionement.Split("-")
                                Dim strCouleur As String = tab(0).Trim
                                Dim strCalibre As String = tab(1).Trim

                                x = CSForm.getControlByName("ComboBox_couleur_" & oValue.Niveau, diagBuses_tab_categories)
                                If x IsNot Nothing Then
                                    x.Text = strCouleur
                                End If
                                x = CSForm.getControlByName("TextBox_calibre_" & oValue.Niveau, diagBuses_tab_categories)
                                If x IsNot Nothing Then
                                    x.Text = strCalibre
                                End If

                            Catch

                            End Try
                        End If


                    Catch ex As Exception
                        CSDebug.dispError("diagnostique.doAcquiring ERR 1 : " & ex.Message)
                    End Try
                End If
            Next
            ' On vide la table d'échange
            oModuleAcquisition.clearResults()
            mutCalcDebitMoy()
            'Recalcul de l'usure des buses pour prendre en compte le debit nominal
            For Each oValue As CRODIPAcquisition.AcquisitionValue In lstValues
                mutCalcUsure1Buse(oValue.Niveau, oValue.NumBuse)
                mutCalcIs1BuseUsee(oValue.Niveau, oValue.NumBuse)
            Next

            mutCalcNbBusesUsee()
            mutCalcUsureMoyBuses()
        Else
            MsgBox("Le nombre de buses saisi et le nombre de buses acquises est différent. Veuillez vérifiez.")
        End If
    End Sub

#End Region

#End Region

#Region " Gestion des popups contenant les différents tableaux "

#Region " Tableau 8.1.1 "
    ''' <summary>
    ''' Affichage de la popup811
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub affichePopup811()
        popup_help_811.Visible = True
        popup_help_811.Top = (Me.Height / 2) - (popup_help_811.Height / 2)
        popup_help_811.Left = (Me.Width / 2) - (popup_help_811.Width / 2)
        If m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU Then
            help811_largeur.Enabled = False
            help811_fleche.Enabled = False
        End If
        popup_help_811.BringToFront()

    End Sub
    ' On cache / affiche la popup
    Private Sub ico_help_811_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_811.Click
        If popup_help_811.Visible = False Then
            affichePopup811()
        Else
            popup_help_811.Visible = False
        End If
    End Sub
    Private Sub help811_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help811_close.Click
        popup_help_811.Visible = False
    End Sub
    Private Sub help811_largeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help811_largeur.TextChanged
        If Not m_bDuringLoad Then
            calc_help_811()
        End If
    End Sub
    Private Sub help811_fleche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help811_fleche.TextChanged
        If Not m_bDuringLoad Then
            calc_help_811()
        End If
    End Sub
    Public Sub calc_help_811()

        Dim tmpLargeur As Double = 0
        Dim tmpFleche As Double = 0

        If help811_largeur.Text <> "" Then
            'Sauvegarde des valeurs dans le Diagnostic
            m_diagnostic.diagnosticHelp811.LargeurRampe = help811_largeur.Text
            m_diagnostic.diagnosticHelp811.Fleche = help811_fleche.Text
            tmpLargeur = GlobalsCRODIP.StringToDouble(help811_largeur.Text)
            tmpFleche = GlobalsCRODIP.StringToDouble(help811_fleche.Text)

            If tmpLargeur < 20 Then
                If tmpFleche <= 5 Then
                    ' OK
                    help811_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
                    help811_result.Text = "OK"
                    RadioButton_diagnostic_8111.Checked = False
                    RadioButton_diagnostic_8112.Checked = False
                    RadioButton_diagnostic_8110.Checked = True
                ElseIf tmpFleche <= 10 Then
                    ' FAIBLE
                    help811_result.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
                    help811_result.Text = "FAIBLE"
                    RadioButton_diagnostic_8111.Checked = True
                    RadioButton_diagnostic_8112.Checked = False
                    RadioButton_diagnostic_8110.Checked = False
                Else
                    ' IMPORTANTE
                    help811_result.ForeColor = System.Drawing.Color.Red
                    help811_result.Text = "IMPORTANTE"
                    RadioButton_diagnostic_8111.Checked = False
                    RadioButton_diagnostic_8112.Checked = True
                    RadioButton_diagnostic_8110.Checked = False
                End If
            Else
                If tmpFleche <= (0.005 * 0.5 * 100 * tmpLargeur) Then
                    ' OK
                    help811_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
                    help811_result.Text = "OK"
                    RadioButton_diagnostic_8111.Checked = False
                    RadioButton_diagnostic_8112.Checked = False
                    RadioButton_diagnostic_8110.Checked = True
                ElseIf tmpFleche <= (0.01 * 0.5 * 100 * tmpLargeur) Then
                    ' FAIBLE
                    help811_result.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
                    help811_result.Text = "FAIBLE"
                    RadioButton_diagnostic_8111.Checked = True
                    RadioButton_diagnostic_8112.Checked = False
                    RadioButton_diagnostic_8110.Checked = False
                Else
                    ' IMPORTANTE
                    help811_result.ForeColor = System.Drawing.Color.Red
                    help811_result.Text = "IMPORTANTE"
                    RadioButton_diagnostic_8111.Checked = False
                    RadioButton_diagnostic_8112.Checked = True
                    RadioButton_diagnostic_8110.Checked = False
                End If
            End If
        End If

    End Sub
#End Region
#Region " Tableau 8.3.1 "
    Private Sub affichePopup831(pMode831 As DiagnosticHelp831.ModeHelp831)
        m_PopupHelp831Mode = pMode831
        If m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU Then
            help831_ecartementReference.Enabled = False
            help831_ecartementMax.Enabled = False
            help831_ecartementMin.Enabled = False
            help831_ecart.Enabled = False
        End If
        If pMode831 = DiagnosticHelp831.ModeHelp831.Mode8312 Then
            lblPopup831.Text = "Irrégularité des espacements"
            'Fill the form
            help831_ecartementReference.Text = m_diagnostic.diagnosticHelp8312.Ecart_reference
            help831_ecartementMax.Text = m_diagnostic.diagnosticHelp8312.Ecart_Maxi
            help831_ecartementMin.Text = m_diagnostic.diagnosticHelp8312.Ecart_Mini
            help831_ecart.Text = m_diagnostic.diagnosticHelp8312.Ecart_pct
        Else
            lblPopup831.Text = "Irrégularité des groupes de buses"
            'Fill the form
            help831_ecartementReference.Text = m_diagnostic.diagnosticHelp8314.Ecart_reference
            help831_ecartementMax.Text = m_diagnostic.diagnosticHelp8314.Ecart_Maxi
            help831_ecartementMin.Text = m_diagnostic.diagnosticHelp8314.Ecart_Mini
            help831_ecart.Text = m_diagnostic.diagnosticHelp8314.Ecart_pct
        End If

        calc_help_831()

        popup_help_831.Visible = True
        popup_help_831.Top = (Me.Height / 2) - (popup_help_831.Height / 2)
        popup_help_831.Left = (Me.Width / 2) - (popup_help_831.Width / 2)
        popup_help_831.BringToFront()

    End Sub
    ' On cache / affiche la popup
    Private Sub ico_help_8312_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_8312.Click
        If popup_help_831.Visible = False Then
            affichePopup831(DiagnosticHelp831.ModeHelp831.Mode8312)
        Else
            popup_help_831.Visible = False
        End If
    End Sub
    Private Sub ico_help_8314_Click(sender As Object, e As EventArgs) Handles ico_help_8314.Click
        If popup_help_831.Visible = False Then
            affichePopup831(DiagnosticHelp831.ModeHelp831.Mode8314)
        Else
            popup_help_831.Visible = False
        End If
    End Sub
    Private Sub help831_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help831_close.Click
        'Sauvegarde des valeurs dans le diag
        If m_modeAffichage <> GlobalsCRODIP.DiagMode.CTRL_VISU Then
            If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                m_diagnostic.diagnosticHelp8312.Ecart_reference = help831_ecartementReference.Text
                m_diagnostic.diagnosticHelp8312.Ecart_Maxi = help831_ecartementMax.Text
                m_diagnostic.diagnosticHelp8312.Ecart_Mini = help831_ecartementMin.Text
                m_diagnostic.diagnosticHelp8312.Ecart_pct = help831_ecart.Text
            End If
            If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8314 Then
                m_diagnostic.diagnosticHelp8314.Ecart_reference = help831_ecartementReference.Text
                m_diagnostic.diagnosticHelp8314.Ecart_Maxi = help831_ecartementMax.Text
                m_diagnostic.diagnosticHelp8314.Ecart_Mini = help831_ecartementMin.Text
                m_diagnostic.diagnosticHelp8314.Ecart_pct = help831_ecart.Text
            End If
        End If
        popup_help_831.Visible = False
    End Sub
    Private Sub help831_ecartementReference_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help831_ecartementReference.TextChanged
        If Not m_bDuringLoad Then
            calc_help_831()
        End If
    End Sub
    Private Sub help831_ecartementMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help831_ecartementMax.TextChanged
        If Not m_bDuringLoad Then
            calc_help_831()
        End If
    End Sub
    Private Sub help831_ecartementMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help831_ecartementMin.TextChanged
        If Not m_bDuringLoad Then
            calc_help_831()
        End If
    End Sub
    Public Sub calc_help_831()

        Dim tmpEcartRef As Double = 0
        Dim tmpEcartMax As Double = 0
        Dim tmpEcartMin As Double = 0
        Dim tmpEcart As Double = 0
        Dim oldDuringLoad As Boolean

        Try
            tmpEcartRef = CType(help831_ecartementReference.Text.ToString.Replace(".", ","), Double)
            tmpEcartMax = CType(help831_ecartementMax.Text.ToString.Replace(".", ","), Double)
            tmpEcartMin = CType(help831_ecartementMin.Text.ToString.Replace(".", ","), Double)

            If tmpEcartRef > tmpEcartMax Or tmpEcartRef < tmpEcartMin Or tmpEcartMax < tmpEcartMin Then
                ' IRREGULARITE
                help831_result.ForeColor = System.Drawing.Color.Red
                help831_result.Text = "IRRÉGULARITÉ"
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                    RadioButton_diagnostic_8312.Checked = True
                    RadioButton_diagnostic_8310.Checked = False
                End If
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8314 Then
                    RadioButton_diagnostic_8314.Checked = True
                    RadioButton_diagnostic_8310.Checked = False
                End If

                Exit Sub
            End If

            Dim tmpEcart1 As Double = 0
            Dim tmpEcart2 As Double = 0
            If tmpEcartRef <> 0 Then
                tmpEcart1 = Math.Abs((tmpEcartMin - tmpEcartRef) * 100 / tmpEcartRef)
                tmpEcart2 = Math.Abs((tmpEcartMax - tmpEcartRef) * 100 / tmpEcartRef)
                tmpEcart = Math.Max(tmpEcart1, tmpEcart2)

                oldDuringLoad = m_bDuringLoad
                m_bDuringLoad = True
                help831_ecart.Text = Math.Round(tmpEcart, 2)
                m_bDuringLoad = oldDuringLoad
            End If
            If tmpEcart <= 5 Then
                ' OK
                help831_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
                help831_result.Text = "OK"
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                    RadioButton_diagnostic_8312.Checked = False
                    RadioButton_diagnostic_8310.Checked = True
                End If
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8314 Then
                    RadioButton_diagnostic_8314.Checked = False
                    RadioButton_diagnostic_8310.Checked = True
                End If
            Else
                ' IRREGULARITE 
                help831_result.ForeColor = System.Drawing.Color.Red
                help831_result.Text = "IRRÉGULARITÉ"
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                    RadioButton_diagnostic_8312.Checked = True
                    RadioButton_diagnostic_8310.Checked = False
                End If
                If m_PopupHelp831Mode = DiagnosticHelp831.ModeHelp831.Mode8314 Then
                    RadioButton_diagnostic_8314.Checked = True
                    RadioButton_diagnostic_8310.Checked = False
                End If
            End If
        Catch ex As Exception
            ''CSDebug.dispInfo("diagnostique::tableaux(8.3.1) : " & ex.Message.ToString)
        End Try

    End Sub
#End Region
#Region " Tableau 5.5.1  & 5.6.2.1"
    ' On cache / affiche la popup
    Private Sub ico_help_551_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_551.Click
        Dim odlg As New diagnostic_dlghelp551()
        odlg.setContexte(DiagnosticHelp551.Help551Mode.Mode551, m_diagnostic, "Vitesse d'avancement", m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU
                         )
        odlg.ShowDialog(Me)
        If odlg.DialogResult = Windows.Forms.DialogResult.OK Then
            'objInfos(10) = odlg.help551_m1_distance.Text
            'objInfos(11) = odlg.help551_m1_temps.Text
            'objInfos(10) = odlg.help551_m2_distance.Text
            'objInfos(11) = odlg.help551_m2_temps.Text
            'La Valeur ErreurMoyenne du Cinémomètre est soit 551 ou 5621
            m_diagnostic.syntheseErreurMoyenneCinemometre = m_diagnostic.diagnosticHelp551.ErreurMoyenne
            If m_diagnostic.diagnosticHelp551.Resultat = "OK" Then
                RadioButton_diagnostic_5512.Checked = False
                RadioButton_diagnostic_5510.Checked = True
            End If
            If m_diagnostic.diagnosticHelp551.Resultat = "IMPRECISION" Then
                RadioButton_diagnostic_5512.Checked = True
                RadioButton_diagnostic_5510.Checked = False
            End If
            ini571()
        End If
    End Sub

    Private Sub ico_help_5621_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_5621.Click
        Dim odlg As New diagnostic_dlghelp551()
        odlg.setContexte(DiagnosticHelp551.Help551Mode.Mode5621, m_diagnostic, "Vitesse de fonctionnement", m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU)
        odlg.ShowDialog(Me)
        If odlg.DialogResult = Windows.Forms.DialogResult.OK Then
            'objInfos(10) = odlg.help551_m1_distance.Text
            'objInfos(11) = odlg.help551_m1_temps.Text
            'objInfos(10) = odlg.help551_m2_distance.Text
            'objInfos(11) = odlg.help551_m2_temps.Text
            'La Valeur ErreurMoyenne du Cinémomètre est soit 551 ou 5621
            m_diagnostic.syntheseErreurMoyenneCinemometre = odlg.help551_erreurMoyenne.Text
            If m_diagnostic.diagnosticHelp5621.Resultat = "OK" Then
                RadioButton_diagnostic_5621.Checked = False
            End If
            If m_diagnostic.diagnosticHelp5621.Resultat = "IMPRECISION" Then
                RadioButton_diagnostic_5621.Checked = True
            End If


        End If
    End Sub

#End Region
#Region " Tableau 5.5.2 "

    ' On cache / affiche la popup
    Private Sub ico_help_552_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_552.Click
        If diagBuses_debitMoyen.Text <> "" And tbPressionMesure.Text <> "" Then
            Dim oDlg552 As New Diagnostic_dlghelp552()
            oDlg552.setContexte(Diagnostic_dlghelp552.Help552Mode.Mode552, m_diagnostic, tbDebitMoyen3bars.Text, tbPressionMesure.Text, (GlobalsCRODIP.DiagMode.CTRL_VISU = m_modeAffichage))
            oDlg552.ShowDialog(Me)
            If oDlg552.DialogResult = Windows.Forms.DialogResult.OK Then
                m_diagnostic.syntheseErreurDebitmetre = m_diagnostic.diagnosticHelp552.ErreurDebitMetre
                If m_diagnostic.diagnosticHelp552.Resultat.ToUpper() = "IMPRECISION" Then
                    RadioButton_diagnostic_5522.Checked = True
                    RadioButton_diagnostic_5520.Checked = False
                Else
                    RadioButton_diagnostic_5522.Checked = False
                    RadioButton_diagnostic_5520.Checked = True

                End If
                ini571()
            End If
        Else
            MsgBox("Vous devez d'abord compléter le tableau 9.2.2 de l'onglet ""Buses"" !")
        End If
    End Sub
#End Region

#End Region

#Region "============================================================================================="

#End Region

#Region " Globals "

#Region " - Manomètre de contrôle sélectionnés - "
    Private Sub manoTroncon_listManoControle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Si on selectionne un mano de contrôle, on doit le flagguer comme etant utilisé
        '        Dim tmpManoTroncon As ManometreControle = ManometreControleManager.getManometreControleByNumeroNational(manoTroncon_listManoControle.SelectedItem.id())
        '       arrManoUsed(0) = tmpManoTroncon
        m_diagnostic.controleManoControleNumNational = manoTroncon_listManoControle.SelectedItem.id()
    End Sub

    Private Sub buses_listBancs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buses_listBancs.SelectedIndexChanged
        ' Si on selectionne un Banc de Mesure, on doit le flagguer comme etant utilisé
        '        Dim tmpBanc As Banc
        If Not buses_listBancs.SelectedItem Is Nothing Then
            'tmpBanc = BancManager.getBancById(buses_listBancs.SelectedItem.id())
            m_diagnostic.controleBancMesureId = buses_listBancs.SelectedItem.id
            '            arrManoUsed(1) = tmpBanc
        Else
            '           arrManoUsed(1) = Nothing
        End If
        checkIsOk(8)
    End Sub
#End Region

#Region " Différences Rampe & ArboViti "

    Public Sub SetDiagnostic833Type()

        tab_833.Visible = True
        If m_oParamdiag.ParamDiagCalc833.Pression1 = 1.6D Then
            manopulveIsFaiblePression.Checked = True
            nup_niveaux.Value = 1
            nupTroncons.Value = 4
        End If
        If m_oParamdiag.ParamDiagCalc833.Pression1 = 5D Then
            manopulveIsFortePression.Checked = True
            nup_niveaux.Value = 1
            nupTroncons.Value = 2
        End If



    End Sub

#End Region

#Region " Actions sur les boutons "

    ' Onglet suivant
    Private Sub btn_diagnostic_suivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tab_diagnostique.SelectedIndex = tab_diagnostique.SelectedIndex() + 1
    End Sub

    ' Vérification du remplissage des onglets
    'Activation / Desactivation du bouton valider
    Public Function checkIsAllFilled() As Boolean
        Dim bReturn As Boolean
        '   forgotField = ""
        'Vérification des l'image associée aux onglets
        bReturn = True
        For nOnglet As Integer = 0 To tab_diagnostique.TabPages.Count - 1
            If tab_diagnostique.TabPages(nOnglet).ImageIndex = 3 Then
                bReturn = False
            End If
        Next
        btn_Valider.Enabled = bReturn
        Return bReturn
    End Function
    Private Sub btn_diagnostic_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Valider()
    End Sub
    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        btn_Valider.Enabled = False
        Dim bReturn As Boolean
        'CSDebug.dispInfo("Diagnostique.btn_diagnostic_valider_Click")
        ' On commence par vérifier que tout a été rempli (Normalement OK car sinon le bouton n'est pas Enabled)
        If checkIsAllFilled() Then
            'Valider
            validerDiagnostique()
            'Passage à la fenêtre suivante
            NextForm()
            bReturn = True
        Else
            MsgBox("Vous n'avez pas rempli la totalité du contrôle :" & vbNewLine)
            bReturn = False
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Validation du diagnostique (Récupération des infos => DiagCourant)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function validerDiagnostique() As Boolean
        Dim bReturn As Boolean
        Dim bOK As Boolean
        Dim nPression As Integer
        bOK = False
        Try
            '============================
            'Récupération de la Perte de charge Moyenne et Maxi dans le Tab833 (S'il est actif)
            'il faudrait trouver un moyerde déterminer si la saisie a été effectuée sans passer par le test du panel
            '===============================
            If pnl_833.Enabled Then
                nPression = 0
                For i As Integer = 1 To 4
                    SetCurrentPressionControls(i)
                    'Mémorisation des Pertes de charges Moyennes et Max si c'est la pression par défaut
                    If m_RelevePression833_Current.PressionManoPourCalculDefaut Then
                        nPression = i
                        bOK = True
                    End If

                Next
                'Par Protection, si on ne trouve pas de pression par défaut (on prend la plus grande)
                If Not bOK Then
                    nPression = 4
                End If
                SetCurrentPressionControls(nPression)
                m_diagnostic.synthesePerteChargeMoyenne = m_RelevePression833_Current.Result_PerteChargeMoyenne
                m_diagnostic.synthesePerteChargeMaxi = m_RelevePression833_Current.Result_PerteChargeMaxi
            Else
                m_diagnostic.synthesePerteChargeMoyenne = ""
                m_diagnostic.synthesePerteChargeMaxi = ""

            End If

            ' On enregistre les buses
            ValiderDiagnostiqueBuses()
            validerDiagnostiqueTab542()
            validerDiagnostiqueTab833()
            '
            '
            'Récupération pour l'opération de synthése
            'diagnosticCourant.syntheseErreurMoyenneCinemometre = help551_erreurMoyenne.Text


            m_diagnostic.ParamDiag = Me.m_oParamdiag

            '====================================================================================
            'Mise à jour du pulvérisateurCourant
            'il sera sauvegarde en même temps que le diagnostique
            '====================================================================================
            m_Pulverisateur.manometreNbniveaux = m_Niveaux
            m_Pulverisateur.manometreNbtroncons = m_Troncons
            'Pour le paramétrage des buses on prend le niveau 1
            Dim nLot As Integer = 1
            Dim oControl As Control
            oControl = CSForm.getControlByName("ComboBox_marque_" & nLot, Me)
            If oControl IsNot Nothing Then
                If Not String.IsNullOrEmpty(oControl.Text) Then
                    m_Pulverisateur.buseMarque = oControl.Text
                End If
            End If
            oControl = CSForm.getControlByName("ComboBox_modele_" & nLot, Me)
            If oControl IsNot Nothing Then
                If Not String.IsNullOrEmpty(oControl.Text) Then
                    m_Pulverisateur.buseModele = oControl.Text
                End If
            End If
            oControl = CSForm.getControlByName("TextBox_nbBuses_" & nLot, Me)
            If oControl IsNot Nothing Then
                If Not String.IsNullOrEmpty(oControl.Text) Then
                    m_Pulverisateur.nombreBuses = oControl.Text
                End If
            End If
            m_Pulverisateur.buseNbniveaux = diagBuses_conf_nbCategories.Text
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("diagnostique.valider ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overridable Sub NextForm()
        Dim ofrm As New frmdiagnostic_recap(m_modeAffichage, m_diagnostic, m_Pulverisateur, m_Exploit, agentCourant, Me)
        TryCast(Me.MdiParent, parentContener).DisplayForm(ofrm)
        Statusbar.clear()
    End Sub
    ' Annulation du diag
    Private Sub btn_diagnostic_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Annuler()
    End Sub

    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler
        Try

            If m_diagnostic.id <> "" Then
                '            accueil.ActiveForm.Show()
                '           Statusbar.clear()
                TryCast(Me.MdiParent, parentContener).ReturnToAccueil()
            Else
                Dim confirmCancel As MsgBoxResult = MsgBox("Êtes-vous sûr de vouloir annuler ce diagnostic ? Vous ne pourrez plus revenir en arrière !", MsgBoxStyle.YesNo)
                If confirmCancel = MsgBoxResult.Yes Then
                    CloseDiagnostic()
                    'accueil.ActiveForm.Show()
                    'Statusbar.clear()
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("btn_diagnostic_annuler_Click ERR " & ex.Message)
            Me.Close()
        End Try

    End Sub
    Private Sub CloseDiagnostic()
        ' On vide les infos de session
        diagnosticCourant = Nothing
        m_diagnostic = Nothing
        m_Pulverisateur = Nothing
        'Fermeture de fenpetres Filles de diag
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiParent.MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next

        ' On ferme le contrôle
        Statusbar.clear()

    End Sub

#End Region

#Region " Gestion des puces sur les onglets "


    Dim prevSelectedOnglet_tabNiveauBuses As Integer = -1
    Private Sub diagBuses_tab_categories_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagBuses_tab_categories.SelectedIndexChanged
        Try
            ' Placer la puce sur onglet courant
            If diagBuses_tab_categories.TabPages.Count > 0 Then
                If prevSelectedOnglet_tabNiveauBuses = -1 Then
                    prevSelectedOnglet_tabNiveauBuses = diagBuses_tab_categories.SelectedTab.TabIndex
                    diagBuses_tab_categories.SelectedTab.ImageIndex = 0
                Else
                    diagBuses_tab_categories.TabPages(prevSelectedOnglet_tabNiveauBuses).ImageIndex = -1
                    diagBuses_tab_categories.SelectedTab.ImageIndex = 0
                    prevSelectedOnglet_tabNiveauBuses = diagBuses_tab_categories.SelectedTab.TabIndex
                End If
            End If
        Catch ex As Exception
            CSDebug.dispWarn("diagBuses_tab_categories_SelectedIndexChanged : " & ex.Message)
        End Try
    End Sub


#End Region

#End Region

#Region " Checkbox "

#Region " Traitement des checkbox "
    Dim isCodeSpecial As Boolean = False

    Private Sub checkAnswer2(ByVal sender As CRODIP_ControlLibrary.CtrlDiag2, ByVal pOngletId As Integer)

        If Not m_bDuringLoad Then
            'Si l'objet n'a pas de nom on sort (Evnmt déclenché lors de la création du controle)
            If String.IsNullOrEmpty(sender.Name) Or sender.Name.ToUpper() = "CTRLDIAG2" Then
                Exit Sub
            End If

            checkAnswer(sender, sender.Categorie, pOngletId, sender.Cause)
        End If
    End Sub

    Private Sub checkAnswer(ByVal sender As System.Object, ByVal typeCheckbox As CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT, ByVal ongletId As Integer, Optional ByVal pCause As String = "")
        Try
            'Si l'objet n'a pas de nom on sort (Evnmt déclenché lors de la création du controle)
            If String.IsNullOrEmpty(sender.name) Then
                Exit Sub
            End If
            'Créationdu diagItem à partir du controle de saisie
            Dim curDiagnosticItem As New DiagnosticItem(sender)
            '' On récupère l'identifiant de la question/réponse
            'Dim tmp As Array = Split(sender.name, "_", -1)
            'Dim ItemCode As String
            'ItemCode = tmp(tmp.Length - 1)
            'Dim answ_GroupeId As String
            'Dim answ_titleId As String
            'Dim answ_groupBoxId As String
            'Dim answ_itemId As String
            'If ItemCode.StartsWith("10") Or ItemCode.StartsWith("11") Or ItemCode.StartsWith("12") And ItemCode.Length() > 4 Then
            '    answ_GroupeId = ItemCode.Substring(0, 2)
            '    answ_titleId = ItemCode.Substring(2, 1)
            '    answ_groupBoxId = ItemCode.Substring(3, 1)
            '    answ_itemId = ItemCode.Substring(4)
            'Else
            '    answ_GroupeId = ItemCode.Substring(0, 1)
            '    answ_titleId = ItemCode.Substring(1, 1)
            '    answ_groupBoxId = ItemCode.Substring(2, 1)
            '    answ_itemId = ItemCode.Substring(3)
            'End If
            ''On GlobalsCRODIP.CONSTruit l'item
            'Dim curDiagnosticItem As New DiagnosticItem
            'curDiagnosticItem.idDiagnostic = _diagnosticCourant.id
            'curDiagnosticItem.idItem = answ_GroupeId & answ_titleId & answ_groupBoxId
            'curDiagnosticItem.itemValue = answ_itemId
            'curDiagnosticItem.SetItemCodeEtat(typeCheckbox)
            'curDiagnosticItem.cause = pCause

            If sender.checked = True Then
                m_diagnostic.AdOrReplaceDiagItem(curDiagnosticItem)
            Else
                m_diagnostic.RemoveDiagItem(curDiagnosticItem)
            End If

            ' Mise a jour du flag de l'onglet suivant les checkbox cochées
            checkIsOk(ongletId)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::checkAnswer (" & sender.name & ") : " & ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Vérification de tous les onglets de la page
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub checkAllIsOk()
        Dim index As Integer = 0
        For Each oPage As TabPage In tab_diagnostique.TabPages
            index = index + 1
            checkIsOk(index)
        Next
    End Sub


    ' Mise a jour du flag de l'onglet suivant les checkbox cochées
    Protected Overridable Function checkIsOk(ByVal ongletId As Integer) As Boolean
        Dim bIsOk As Boolean = False
        Try
            If Not m_bDuringLoad Then
                Select Case ongletId
                    Case 1
                        'Pour L'onglet 1 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_etatGeneral").ImageIndex() = checkOnglet1()
                    Case 2
                        'Pour L'onglet 2 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_pompeCuve").ImageIndex() = checkOnglet2()
                    Case 3
                        'Pour L'onglet 3 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_flexiblesFiltres").ImageIndex() = checkOnglet3()
                    Case 4
                        'Pour L'onglet 4 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_jetsSoufflerie").ImageIndex() = checkOnglet4()
                    Case 5
                        'Pour L'onglet 5 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_mesureCommandesRegulation").ImageIndex() = checkOnglet5()
                    Case 6
                        'Pour L'onglet 6 , on vérifie directement les CheckBox
                        tab_diagnostique.TabPages("tabPage_diagnostique_rampes").ImageIndex() = checkOnglet6()
                    Case 7
                        'Pour L'onglet 7 , on vérifie directement les Labels
                        tab_diagnostique.TabPages("tabPage_diagnostique_manoTroncon").ImageIndex() = CheckOnglet7()

                    Case 8
                        'Pour L'onglet 8 
                        tab_diagnostique.TabPages("tabPage_diagnostique_buses").ImageIndex() = CheckOnglet8()
                    Case 9
                        'Pour L'onglet Accessoires
                        tab_diagnostique.TabPages("tabPage_diagnostique_accessoires").ImageIndex() = checkOnglet9()
                    Case Else
                        tab_diagnostique.TabPages(ongletId - 1).ImageIndex() = 2 ' Vert
                End Select
                checkIsAllFilled()
            End If
        Catch ex As Exception
            CSDebug.dispError("frmDiagnostique.checkIsOk ERR : " & ex.Message)
        End Try
        Return bIsOk
    End Function
#Region "Vérification des Onglets"
    Private Function checkOnglet9() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(9) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(9) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet9isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '9.1.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_9111.Checked Or RadioButton_diagnostic_9112.Checked Or RadioButton_diagnostic_9113.Checked Or RadioButton_diagnostic_9114.Checked Or RadioButton_diagnostic_9115.Checked Or RadioButton_diagnostic_9116.Checked)
    '    End If
    '    '9.1.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_9121.Checked Or RadioButton_diagnostic_9122.Checked Or RadioButton_diagnostic_9123.Checked)
    '    End If
    '    '9.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_9211.Checked Or RadioButton_diagnostic_9212.Checked Or RadioButton_diagnostic_9213.Checked)
    '    '9.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_9221.Checked Or RadioButton_diagnostic_9222.Checked Or RadioButton_diagnostic_9223.Checked)
    '    '10.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_10111.Checked Or RadioButton_diagnostic_10112.Checked Or RadioButton_diagnostic_10113.Checked Or RadioButton_diagnostic_10114.Checked Or RadioButton_diagnostic_10115.Checked Or RadioButton_diagnostic_10116.Checked Or RadioButton_diagnostic_10117.Checked Or RadioButton_diagnostic_10118.Checked)
    '    '10.1.2
    '    bReturn = bReturn And (RadioButton_diagnostic_10121.Checked Or RadioButton_diagnostic_10122.Checked Or RadioButton_diagnostic_10123.Checked)
    '    '10.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_10211.Checked Or RadioButton_diagnostic_10212.Checked Or RadioButton_diagnostic_10213.Checked Or RadioButton_diagnostic_10214.Checked)
    '    '10.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_10221.Checked Or RadioButton_diagnostic_10222.Checked Or RadioButton_diagnostic_10223.Checked Or RadioButton_diagnostic_10224.Checked)

    '    Return bReturn
    'End Function
    ''' Calcul l'état de l'onglet Mano/Tronçons
    ''' si 
    Protected Overridable Function CheckOnglet7() As Integer

        Dim iReturn As Integer = 3 'Etat initial = 3 Gris
        If CheckIfManoTronconsAreFilled() Then
            iReturn = 2 'OK = vert
            If manopulveResultat.Text.Trim().ToUpper() = "IMPORTANTE" Then
                iReturn = 0 'Rouge
            End If

            If lblP833DefautHeterogeneite.Text.Trim().ToUpper() <> "OK" And isTab833Enabled() Then
                iReturn = 0 'Rouge
            End If

            If lblp833DefautEcart.Text.Trim().ToUpper() <> "OK" And isTab833Enabled() Then
                iReturn = 0 'Rouge
            End If
        End If
        Return iReturn
    End Function

    ''' Calcul l'état de l'onglet Buses
    ''' si Tous les champs requis sont remplis
    '''     Test sur le label Résultat
    ''' =============================
    Protected Overridable Function CheckOnglet8() As Integer

        Dim iReturn As Integer = 3 'Etat initial = 3 Gris
        If CheckIfBusesAreFilled() Then
            iReturn = 2 'OK = vert
            If diagBuses_resultat.Text.Trim().ToUpper() <> "OK" And isTab922Enabled() Then
                iReturn = 0 'Rouge
            End If

        End If
        Return iReturn
    End Function

    Private Function checkOnglet6() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(6) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(6) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet6isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '8.1.1
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8111.Checked Or RadioButton_diagnostic_8112.Checked Or RadioButton_diagnostic_8113.Checked Or RadioButton_diagnostic_8114.Checked Or RadioButton_diagnostic_8115.Checked)
    '    End If
    '    '8.1.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8121.Checked Or RadioButton_diagnostic_8122.Checked Or RadioButton_diagnostic_8123.Checked)
    '    End If
    '    '8.1.3
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8131.Checked Or RadioButton_diagnostic_8132.Checked Or RadioButton_diagnostic_8133.Checked)
    '    End If
    '    '8.1.4 (IF NOT RAMPE)
    '    If Not typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8141.Checked Or RadioButton_diagnostic_8142.Checked Or RadioButton_diagnostic_8143.Checked)
    '    End If
    '    '8.1.5
    '    bReturn = bReturn And (RadioButton_diagnostic_8151.Checked Or RadioButton_diagnostic_8152.Checked Or RadioButton_diagnostic_8153.Checked)
    '    '8.1.6
    '    bReturn = bReturn And (RadioButton_diagnostic_8161.Checked Or RadioButton_diagnostic_8162.Checked Or RadioButton_diagnostic_8163.Checked)
    '    '8.2.1
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8211.Checked Or RadioButton_diagnostic_8212.Checked)
    '    End If
    '    '8.2.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8221.Checked Or RadioButton_diagnostic_8222.Checked Or RadioButton_diagnostic_8223.Checked)
    '    End If
    '    '8.2.3
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_8231.Checked Or RadioButton_diagnostic_8232.Checked Or RadioButton_diagnostic_8233.Checked Or RadioButton_diagnostic_8234.Checked Or RadioButton_diagnostic_8235.Checked)
    '    End If
    '    '8.3.1
    '    bReturn = bReturn And (RadioButton_diagnostic_8311.Checked Or RadioButton_diagnostic_8312.Checked Or RadioButton_diagnostic_8313.Checked Or RadioButton_diagnostic_8310.Checked)
    '    '8.3.2
    '    bReturn = bReturn And (RadioButton_diagnostic_8321.Checked Or RadioButton_diagnostic_8322.Checked Or RadioButton_diagnostic_8323.Checked Or RadioButton_diagnostic_8324.Checked)
    '    '8.3.3
    '    bReturn = bReturn And (RadioButton_diagnostic_8331.Checked Or RadioButton_diagnostic_8332.Checked Or RadioButton_diagnostic_8333.Checked Or RadioButton_diagnostic_8330.Checked)

    '    Return bReturn
    'End Function


    Private Function checkOnglet5() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(5) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(5) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet5isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '511
    '    bReturn = bReturn And (RadioButton_diagnostic_5111.Checked Or RadioButton_diagnostic_5112.Checked Or RadioButton_diagnostic_5113.Checked)
    '    '521
    '    bReturn = bReturn And (RadioButton_diagnostic_5211.Checked Or RadioButton_diagnostic_5212.Checked Or RadioButton_diagnostic_5213.Checked)
    '    '522
    '    bReturn = bReturn And (RadioButton_diagnostic_5221.Checked Or RadioButton_diagnostic_5222.Checked Or RadioButton_diagnostic_5223.Checked Or RadioButton_diagnostic_5224.Checked)
    '    '531
    '    bReturn = bReturn And (RadioButton_diagnostic_5311.Checked Or RadioButton_diagnostic_5312.Checked Or RadioButton_diagnostic_5313.Checked)
    '    '532
    '    bReturn = bReturn And (RadioButton_diagnostic_5321.Checked Or RadioButton_diagnostic_5322.Checked Or RadioButton_diagnostic_5323.Checked)
    '    '541
    '    bReturn = bReturn And (RadioButton_diagnostic_5411.Checked Or RadioButton_diagnostic_5412.Checked Or RadioButton_diagnostic_5413.Checked Or RadioButton_diagnostic_5414.Checked Or RadioButton_diagnostic_5415.Checked)
    '    '542
    '    bReturn = bReturn And (RadioButton_diagnostic_5421.Checked Or RadioButton_diagnostic_5422.Checked Or RadioButton_diagnostic_5423.Checked Or RadioButton_diagnostic_5424.Checked)
    '    '551
    '    bReturn = bReturn And (RadioButton_diagnostic_5511.Checked Or RadioButton_diagnostic_5512.Checked Or RadioButton_diagnostic_5513.Checked)
    '    '552
    '    bReturn = bReturn And (RadioButton_diagnostic_5521.Checked Or RadioButton_diagnostic_5522.Checked Or RadioButton_diagnostic_5523.Checked)
    '    '561
    '    bReturn = bReturn And (RadioButton_diagnostic_5611.Checked Or RadioButton_diagnostic_5612.Checked Or RadioButton_diagnostic_5613.Checked)
    '    '562
    '    bReturn = bReturn And (RadioButton_diagnostic_5621.Checked Or RadioButton_diagnostic_5622.Checked Or RadioButton_diagnostic_5623.Checked)

    '    Return bReturn
    'End Function


    Private Function checkOnglet4() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(4) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(4) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet4isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '9.1.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_9111.Checked Or RadioButton_diagnostic_9112.Checked Or RadioButton_diagnostic_9113.Checked Or RadioButton_diagnostic_9114.Checked Or RadioButton_diagnostic_9115.Checked Or RadioButton_diagnostic_9116.Checked)
    '    End If
    '    '9.1.2
    '    If typeControle = Pulverisateur.CATEGORIEPULVE_RAMPE Then
    '        bReturn = bReturn And (RadioButton_diagnostic_9121.Checked Or RadioButton_diagnostic_9122.Checked Or RadioButton_diagnostic_9123.Checked)
    '    End If
    '    '9.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_9211.Checked Or RadioButton_diagnostic_9212.Checked Or RadioButton_diagnostic_9213.Checked)
    '    '9.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_9221.Checked Or RadioButton_diagnostic_9222.Checked Or RadioButton_diagnostic_9223.Checked)
    '    '10.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_10111.Checked Or RadioButton_diagnostic_10112.Checked Or RadioButton_diagnostic_10113.Checked Or RadioButton_diagnostic_10114.Checked Or RadioButton_diagnostic_10115.Checked Or RadioButton_diagnostic_10116.Checked Or RadioButton_diagnostic_10117.Checked Or RadioButton_diagnostic_10118.Checked)
    '    '10.1.2
    '    bReturn = bReturn And (RadioButton_diagnostic_10121.Checked Or RadioButton_diagnostic_10122.Checked Or RadioButton_diagnostic_10123.Checked)
    '    '10.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_10211.Checked Or RadioButton_diagnostic_10212.Checked Or RadioButton_diagnostic_10213.Checked Or RadioButton_diagnostic_10214.Checked)
    '    '10.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_10221.Checked Or RadioButton_diagnostic_10222.Checked Or RadioButton_diagnostic_10223.Checked Or RadioButton_diagnostic_10224.Checked)

    '    Return bReturn
    'End Function


    Private Function checkOnglet3() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(3) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(3) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet3isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '6.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_6111.Checked Or RadioButton_diagnostic_6112.Checked Or RadioButton_diagnostic_6113.Checked Or RadioButton_diagnostic_6114.Checked)
    '    '7.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_7111.Checked Or RadioButton_diagnostic_7112.Checked Or RadioButton_diagnostic_7113.Checked Or RadioButton_diagnostic_7114.Checked Or RadioButton_diagnostic_7115.Checked Or RadioButton_diagnostic_7116.Checked)
    '    '7.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_7211.Checked Or RadioButton_diagnostic_7212.Checked Or RadioButton_diagnostic_7213.Checked Or RadioButton_diagnostic_7214.Checked Or RadioButton_diagnostic_7215.Checked Or RadioButton_diagnostic_7216.Checked)
    '    '7.3.1
    '    bReturn = bReturn And (RadioButton_diagnostic_7311.Checked Or RadioButton_diagnostic_7312.Checked Or RadioButton_diagnostic_7313.Checked Or RadioButton_diagnostic_7314.Checked Or RadioButton_diagnostic_7315.Checked)
    '    '7.4.1
    '    bReturn = bReturn And (RadioButton_diagnostic_7411.Checked Or RadioButton_diagnostic_7412.Checked Or RadioButton_diagnostic_7413.Checked Or RadioButton_diagnostic_7414.Checked Or RadioButton_diagnostic_7415.Checked Or RadioButton_diagnostic_7416.Checked)
    '    Return bReturn
    'End Function


    Private Function checkOnglet2() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(2) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(2) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet2isFilled() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = True
    '    '3.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_3111.Checked Or RadioButton_diagnostic_3112.Checked Or RadioButton_diagnostic_3113.Checked)
    '    '3.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_3211.Checked Or RadioButton_diagnostic_3212.Checked Or RadioButton_diagnostic_3213.Checked)
    '    '3.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_3221.Checked Or RadioButton_diagnostic_3222.Checked Or RadioButton_diagnostic_3223.Checked Or RadioButton_diagnostic_3224.Checked)
    '    '3.2.3
    '    bReturn = bReturn And (RadioButton_diagnostic_3231.Checked Or RadioButton_diagnostic_3232.Checked)
    '    '4.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_4111.Checked Or RadioButton_diagnostic_4112.Checked Or RadioButton_diagnostic_4113.Checked Or RadioButton_diagnostic_4114.Checked Or RadioButton_diagnostic_4115.Checked)
    '    '4.1.2
    '    bReturn = bReturn And (RadioButton_diagnostic_4121.Checked Or RadioButton_diagnostic_4122.Checked Or RadioButton_diagnostic_4123.Checked)
    '    '4.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_4211.Checked Or RadioButton_diagnostic_4212.Checked Or RadioButton_diagnostic_4213.Checked Or RadioButton_diagnostic_4214.Checked)
    '    '4.3.1
    '    bReturn = bReturn And (RadioButton_diagnostic_4311.Checked Or RadioButton_diagnostic_4312.Checked Or RadioButton_diagnostic_4313.Checked)
    '    Return bReturn
    'End Function


    Private Function checkOnglet1() As Integer
        Dim iReturn As Integer
        If Not CheckOngletIsFilled(1) Then
            iReturn = 3 'Gris
        Else
            If CheckOngletisError(1) Then
                iReturn = 0 'Rouge
            Else
                iReturn = 2 'Vert
            End If
        End If
        Return iReturn
    End Function
    'Private Function CheckOnglet1isFilled() As Boolean
    '    Dim bReturn As Boolean

    '    bReturn = True
    '    '2.1.1
    '    bReturn = bReturn And (RadioButton_diagnostic_2111.Checked Or RadioButton_diagnostic_2112.Checked Or RadioButton_diagnostic_2113.Checked)
    '    '2.1.2
    '    bReturn = bReturn And (RadioButton_diagnostic_2121.Checked Or RadioButton_diagnostic_2122.Checked Or RadioButton_diagnostic_2123.Checked)
    '    '3.1.3
    '    bReturn = bReturn And (RadioButton_diagnostic_2131.Checked Or RadioButton_diagnostic_2132.Checked Or RadioButton_diagnostic_2133.Checked)
    '    '2.2.1
    '    bReturn = bReturn And (RadioButton_diagnostic_2211.Checked Or RadioButton_diagnostic_2212.Checked Or RadioButton_diagnostic_2213.Checked Or RadioButton_diagnostic_2214.Checked)
    '    '2.2.2
    '    bReturn = bReturn And (RadioButton_diagnostic_2221.Checked Or RadioButton_diagnostic_2222.Checked Or RadioButton_diagnostic_2223.Checked)
    '    '2.2.3
    '    bReturn = bReturn And (RadioButton_diagnostic_2231.Checked Or RadioButton_diagnostic_2232.Checked Or RadioButton_diagnostic_2233.Checked)
    '    '2.2.4
    '    bReturn = bReturn And (RadioButton_diagnostic_2241.Checked Or RadioButton_diagnostic_2242.Checked Or RadioButton_diagnostic_2243.Checked)
    '    '2.2.5
    '    bReturn = bReturn And (RadioButton_diagnostic_2251.Checked Or RadioButton_diagnostic_2252.Checked Or RadioButton_diagnostic_2253.Checked)
    '    '2.4.1
    '    bReturn = bReturn And (RadioButton_diagnostic_2411.Checked Or RadioButton_diagnostic_2412.Checked Or RadioButton_diagnostic_2413.Checked Or RadioButton_diagnostic_2414.Checked Or RadioButton_diagnostic_2415.Checked)
    '    '2.5.1
    '    bReturn = bReturn And (RadioButton_diagnostic_2511.Checked Or RadioButton_diagnostic_2512.Checked Or RadioButton_diagnostic_2513.Checked)
    '    '2.5.2
    '    bReturn = bReturn And (RadioButton_diagnostic_2521.Checked Or RadioButton_diagnostic_2522.Checked Or RadioButton_diagnostic_2523.Checked)
    '    '2.3.1
    '    bReturn = bReturn And (RadioButton_diagnostic_2311.Checked Or RadioButton_diagnostic_2312.Checked Or RadioButton_diagnostic_2313.Checked Or RadioButton_diagnostic_2314.Checked Or RadioButton_diagnostic_2315.Checked Or RadioButton_diagnostic_2316.Checked Or RadioButton_diagnostic_2317.Checked Or RadioButton_diagnostic_2318.Checked Or RadioButton_diagnostic_2319.Checked Or RadioButton_diagnostic_2310.Checked)
    '    '2.3.2
    '    bReturn = bReturn And (RadioButton_diagnostic_2321.Checked Or RadioButton_diagnostic_2322.Checked Or RadioButton_diagnostic_2323.Checked Or RadioButton_diagnostic_2324.Checked Or RadioButton_diagnostic_2325.Checked Or RadioButton_diagnostic_2326.Checked Or RadioButton_diagnostic_2327.Checked Or RadioButton_diagnostic_2329.Checked Or RadioButton_diagnostic_2328.Checked)
    '    Return bReturn
    'End Function

    ''' <summary>
    ''' Vérifie si l'onglet eest en erreur
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckOngletisError(ByVal nOnglet As Integer) As Boolean
        Debug.Assert(LstCtrl IsNot Nothing)
        Debug.Assert(nOnglet > 0 And nOnglet <= LstCtrl.Count)

        Dim bReturn As Boolean = False
        Dim ogrp As List(Of CRODIP_ControlLibrary.CtrlDiag2)
        Dim octrl As CRODIP_ControlLibrary.CtrlDiag2
        Try

            bReturn = False
            'Parcours de la liste des controle de l'onglet demandé
            For Each ogrp In LstCtrl(nOnglet - 1)
                For Each octrl In ogrp
                    'Vérification de chaque controle isError Rend Vrai si le controle déclenche une CV
                    bReturn = bReturn Or octrl.isError()
                Next
            Next
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.CheckOngletisError ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Vérifie si l'onglet complet
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CheckOngletIsFilled(ByVal nOnglet As Integer) As Boolean
        Debug.Assert(LstCtrl IsNot Nothing, "Liste des Controles non initialisée")
        Debug.Assert(nOnglet > 0 And nOnglet <= LstCtrl.Count, "Onglet incorrect")

        Dim bReturn As Boolean = False
        Dim bGrp As Boolean = False

        Dim bGrpEnabled As Boolean = False
        Dim ogrp As List(Of CRODIP_ControlLibrary.CtrlDiag2)
        Dim octrl As CRODIP_ControlLibrary.CtrlDiag2
        Try

            bReturn = True
            'Parcours de la liste des controle de l'onglet demandé
            For Each ogrp In LstCtrl(nOnglet - 1)
                bGrp = False
                bGrpEnabled = False
                For Each octrl In ogrp
                    'S'il y a un controle Enabled dans le groupe => le Groupe est actif
                    If octrl.Enabled Then
                        bGrpEnabled = True
                    End If
                    'Si un controle est OK (Checked) alors le groupe est OK
                    If octrl.Enabled And octrl.Checked() Then
                        bGrp = True
                    End If
                Next
                If bGrpEnabled Then
                    'Cumul des check de controles , Si l'un est False => tout est false
                    bReturn = bReturn And bGrp
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.CheckOngletIsFilled ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region

#End Region

#Region " RadioButton's click "

#Region " RadioButton'w click Onglet 1 "

    Private Sub RadioButton_etatGeneral_dispositifAttelage_deformation_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_deformation_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_deformation_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_modifications_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_modifications_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 1)
        Else
            checkAnswer2(sender, 1)
        End If
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_modifications_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_corrosion_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_corrosion_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_dispositifAttelage_corrosion_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_deformations_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_deformations_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_deformations_majeureSupport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_deformations_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsPieces_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsPieces_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsPieces_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsSoudures_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsSoudures_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_lesionsSoudures_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_corrosion_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_corrosion_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_corrosion_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_jeuxArticulations_faible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_jeuxArticulations_important_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_chassis_jeuxArticulations_aucun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_transmission_antiDecrochage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_transmission_usureImportante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_transmission_pliuresExcessives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_transmission_fuiteFluide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_transmission_aucun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_montage_dissymetrie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_montage_pression_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_montage_aucun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_usure_endommages_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_usure_maximum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_pneumatiques_usure_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_pompe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_cuveBouille_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_circuitsCommande_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_conduitesBouille_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_jetsPulve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_appMesure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_dispIncorporation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_nbSupTrois_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMin_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_pompe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_cuveBouille_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_circuitsCommande_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_conduitesBouille_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_jetsPulve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_appMesure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_dispIncorporation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_etatGeneral_alertes_fuitesMaj_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub
#End Region

#Region " RadioButton's click Onglet 2 "

    Private Sub RadioButton_pompeCuve_pompe_fuiteHuile_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_fuiteHuile_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_fuiteHuile_aucune_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_pulsations_mineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 2)
        Else
            checkAnswer2(sender, 2)
            'If RadioButton_diagnostic_3211_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3211_1.Checked = False
            'End If
            'If RadioButton_diagnostic_3211_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3211_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_pulsations_majeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 2)
        Else
            checkAnswer2(sender, 2)
            'If RadioButton_diagnostic_3212_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3212_1.Checked = False
            'End If
            'If RadioButton_diagnostic_3212_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3212_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_diagnostic_3213_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_diagnostic_3221_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_diagnostic_3222_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_diagnostic_3223_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 2)
        Else
            checkAnswer2(sender, 2)
            'If RadioButton_diagnostic_3223_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3223_1.Checked = False
            'End If
            'If RadioButton_diagnostic_3223_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_3223_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_clocheAir_aucun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_pompe_debit_insuffisant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_diagnostic_3232_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_etat_fele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_etat_casse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_etat_perce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_adequation_inadapte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_adequation_mauvaisMaintien_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_bouchons_adequation_bonne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_indicNiveau_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_indicNiveau_etat_nonFonc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_indicNiveau_etat_mauvaiseLisibilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_indicNiveau_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_incProduit_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_incProduit_etat_nonFonc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

    Private Sub RadioButton_pompeCuve_cuve_incProduit_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)
    End Sub

#End Region

#Region " RadioButton's click Onglet 3 "
    Private Sub RadioButton_filtres_flexiblesCanalisations_etat_pliuresImportantes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_flexiblesCanalisations_etat_usureMineure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_flexiblesCanalisations_etat_usureMajeure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_flexiblesCanalisations_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_filtresAspiration_etat_absent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7111_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7111_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7111_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7111_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresAspiration_etat_nonIsolable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7112_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7112_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7112_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7112_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresAspiration_etat_nonDemontable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7113_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7113_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7113_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7113_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresAspiration_etat_defautJoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7114_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7114_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7114_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7114_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresAspiration_etat_elementFiltrantDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7115_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7115_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7115_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7115_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_diagnostic_7116_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_filtresRefoulement_etat_absent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7211_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7211_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7211_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7211_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresRefoulement_etat_nonIsolable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7212_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7212_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7212_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7212_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresRefoulement_etat_nonDemontable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7213_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7213_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7213_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7213_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresRefoulement_etat_defautJoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7214_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7214_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7214_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7214_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresRefoulement_etat_elementFiltrantDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7215_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7215_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7215_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7215_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_diagnostic_7216_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_filtresPulverisation_etat_absent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_filtresPulverisation_etat_nonDemontable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7312_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7312_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7312_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7312_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresPulverisation_etat_defautJoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7313_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7313_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7313_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7313_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresPulverisation_etat_elementFiltrantDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7314_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7314_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7314_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7314_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_diagnostic_7315_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub

    Private Sub RadioButton_filtres_filtresBuses_etat_absent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7411_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7411_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7411_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7411_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresBuses_etat_nonIsolable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7412_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7412_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7412_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7412_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresBuses_etat_nonDemontable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7413_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7413_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7413_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7413_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresBuses_etat_defautJoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7414_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7414_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7414_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7414_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_filtres_filtresBuses_etat_elementFiltrantDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            checkAnswer2(sender, 3)
        Else
            checkAnswer2(sender, 3)
            'If RadioButton_diagnostic_7415_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7415_1.Checked = False
            'End If
            'If RadioButton_diagnostic_7415_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_7415_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_diagnostic_7416_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 3)
    End Sub
#End Region

#Region " RadioButton's click Onglet 4 "
    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_heterogeneiteMarque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_heterogeneiteMateriau_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_heterogeneiteType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_heterogeneiteAngle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_heterogeneiteCalibre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub
    Private Sub RadioButton_diagnostic_9116_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_natureMontage_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_orientationMontage_heterogeneite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_orientationMontage_incorrecte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_orientationMontage_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_regularite_obstacleJets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_regularite_panacheHeterogene_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_jetsPulve_regularite_bonne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub



    Private Sub RadioButton_diagnostic_9223_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9220.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_caissonDeforme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_caissonPerfore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_caissonDesaxe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_redresseurAirDeforme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_redresseurAirCasse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_paleDeformee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_paleDeterioree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_fonctionnement_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_fonctionnement_fluxAirInsuffisant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_fonctionnement_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_gainesAdductionAir_malFixee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_gainesAdductionAir_nonEtanche_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_gainesAdductionAir_obstruee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_gainesAdductionAir_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_sortiesAir_malFixee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_sortiesAir_deterioree_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_sortiesAir_obstruee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub

    Private Sub RadioButton_jetsSoufflerie_soufflerie_sortiesAir_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 4)
    End Sub
#End Region

#Region " RadioButton's click Onglet 5 "
    Private Sub RadioButton_mesureCommandesRegulations_fermetureGeneralePulve_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5111.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermetureGeneralePulve_etat_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5112.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermetureGeneralePulve_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5110.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_etat_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5212.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5211.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5210.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_retoursCompensatoires_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5221.CheckedChanged
        If sender.Checked = True Then
            checkAnswer2(sender, 5)
        Else
            checkAnswer2(sender, 5)
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_retoursCompensatoires_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5222.CheckedChanged
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_retoursCompensatoires_mauvaisEquilibre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5223.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_fermeturePartiellePulve_retoursCompensatoires_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5220.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5311.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_etat_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5312.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5310.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_fonctionnement_faibleInstabilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5321.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_fonctionnement_forteInstabilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5322.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub
    Private Sub RadioButton_diagnostic_5323_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_5323.CheckedChanged
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_regulationPression_fonctionnement_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5320.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_etat_absence_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5411.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_etat_mauvaiseLisibilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5412.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_etat_plageMesureInadaptee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5413.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_etat_graduationsInadaptees_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5414.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5410.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_fonctionnement_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5421.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
        If RadioButton_diagnostic_5421.Checked Then
            disableTab542()
        Else
            enableTab542()
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_fonctionnement_imprecisionFaible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5422.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_fonctionnement_imprecisionImportante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5423.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurPression_fonctionnement_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5420.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_vitesseAvancement_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5511.CheckedChanged
        If sender.Checked = True Then
            checkAnswer2(sender, 5)
        Else
            checkAnswer2(sender, 5)
            'If RadioButton_diagnostic_5511_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5511_1.Checked = False
            'End If
            'If RadioButton_diagnostic_5511_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5511_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_vitesseAvancement_imprecision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5512.CheckedChanged
        If sender.Checked = True Then
            checkAnswer2(sender, 5)
        Else
            checkAnswer2(sender, 5)
            'If RadioButton_diagnostic_5512_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5512_1.Checked = False
            'End If
            'If RadioButton_diagnostic_5512_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5512_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_vitesseAvancement_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5510.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_debit_nonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5521.CheckedChanged
        If sender.Checked = True Then
            checkAnswer2(sender, 5)
        Else
            checkAnswer2(sender, 5)
            'If RadioButton_diagnostic_5521_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5521_1.Checked = False
            'End If
            'If RadioButton_diagnostic_5521_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5521_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_debit_imprecision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5522.CheckedChanged
        If sender.Checked = True Then
            checkAnswer2(sender, 5)
        Else
            checkAnswer2(sender, 5)
            'If RadioButton_diagnostic_5522_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5522_1.Checked = False
            'End If
            'If RadioButton_diagnostic_5522_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_5522_2.Checked = False
            'End If
        End If
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_indicateurRegulation_debit_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5520.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_autresIndicateurs_etat_nonFonctionnels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5611.CheckedChanged
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_autresIndicateurs_etat_mauvaiseLIsibilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5612.CheckedChanged
        checkAnswer2(sender, 5)
    End Sub

    Private Sub RadioButton_mesureCommandesRegulations_autresIndicateurs_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5610.CheckedChanged
        checkAnswer2(sender, 5)
    End Sub
#End Region

#Region " RadioButton's click Onglet 6 "
    Private Sub RadioButton_diagnostic_8141_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8141.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8142_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8142.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8143_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8140.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8151_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8151.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8152_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8152.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8153_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8150.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8111_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8111.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationVertical_courbureImportante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8112.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationVertical_defautParallelismeFaible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8113.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationVertical_defautParallelismeImportant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8114.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationVertical_aucunDeformation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8110.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationHorizontal_aucuneDeformation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8120.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationHorizontal_ecartPositionImportant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8122.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub
    Private Sub RadioButton_diagnostic_8123_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8123.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8124_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8124.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_rampes_structureRampe_deformationHorizontal_ecartPositionFaible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8121.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_protectionBuses_tronconsEscamotablesDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8131.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_protectionBuses_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8130.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_structureRampe_protectionBuses_contactAvecSolNonProtege_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8132.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_jeuxArticulations_jeuxImportant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8211.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_jeuxArticulations_jeuxFaibleOuNean_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8210.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_stabilite_stabilisationNonFonctionnel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8221.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_stabilite_bonneStabilite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8220.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_stabilite_mauvaisFonctionnement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8222.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_reglageHauteur_mauvaisFonctionnement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8233.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_reglageHauteur_inadapte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8234.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_reglageHauteur_impossible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8231.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_reglageHauteur_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8230.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_comportementRampe_reglageHauteur_mauvaisEtat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8232.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_deisposition_irregulariteEspacements_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8312.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_deisposition_dissymetrie_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8311.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_deisposition_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8310.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_deisposition_mauvaisAplomb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8313.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_etat_bon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8320.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_etat_casse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8322.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_etat_usure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8323.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_etat_felure_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8321.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_rampes_porteJets_fonctionnement_antigoutteDefectueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8331.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8334_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8330.CheckedChanged
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_8332_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8332.CheckedChanged
        checkAnswer2(sender, 6)
        If RadioButton_diagnostic_8332.Checked And
            (RadioButton_diagnostic_8332.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN Or
            RadioButton_diagnostic_8332.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX) Then
            disableTab833()
        Else
            enableTab833()
        End If

    End Sub
    Private Sub RadioButton_diagnostic_8333_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8333.CheckedChanged
        checkAnswer2(sender, 6)
        If RadioButton_diagnostic_8333.Checked And
            (RadioButton_diagnostic_8333.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN Or
            RadioButton_diagnostic_8333.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX) Then
            disableTab833()
        Else
            enableTab833()
        End If
    End Sub
#End Region

#End Region

#Region " Codes 1/2 Checkboxes "
    'IsCodeSpecial est activé pour inhiber le traitement de CheckAnswer
    'Il est reposition à False automatiquement
    'Il faut donc le positionner à True, modifier le Check du RB dépendant et déclencher le checkAnswer sur l'élement courant
    'Private Sub RadioButton_diagnostic_5511_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5511_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5511.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_5511_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5511_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5511.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_5512_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5512_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5512.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_5512_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5512_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5512.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_5521_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5521_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5521.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_5521_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5521_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5521.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_5522_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5522_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5522.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_5522_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5522_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5522.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 5, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_5611_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5611_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5611.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 5, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_5611_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5611_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_5611.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 5, "2")

    'End Sub

    'Private Sub RadioButton_diagnostic_3211_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3211_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3211.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 2, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_3211_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3211_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3211.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 2, "2")

    'End Sub

    'Private Sub RadioButton_diagnostic_3212_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3212_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3212.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 2, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_3212_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3212_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3212.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 2, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_3223_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3223_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3223.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 2, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_3223_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_3223_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_3223.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 2, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7111_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7111_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7111.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7111_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7111_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7111.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")

    'End Sub

    'Private Sub RadioButton_diagnostic_7112_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7112_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7112.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7112_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7112_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7112.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7113_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7113_1.CheckedChanged
    '    isCodeSpecial = True

    '    RadioButton_diagnostic_7113.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7113_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7113_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7113.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7114_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7114_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7114.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7114_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7114_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7114.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7115_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7115_1.CheckedChanged
    '    If sender.Checked <> RadioButton_diagnostic_7115.Checked Then
    '        isCodeSpecial = True
    '        RadioButton_diagnostic_7115.Checked = sender.Checked
    '    End If
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7115_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7115_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7115.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7211_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7211_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7211.Checked = sender.checked
    '    'If sender.checked = True Then
    '    '    RadioButton_diagnostic_7211.Checked = True
    '    'End If
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7211_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7211_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7211.Checked = sender.checked
    '    'If sender.checked = True Then
    '    '    RadioButton_diagnostic_7211.Checked = True
    '    'End If
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7212_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7212_1.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7212.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7212_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7212_2.CheckedChanged
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7212.Checked = sender.checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7213_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7213_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7213.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_7213_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7213_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7213.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7214_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7214_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7214.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7214_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7214_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7214.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")

    'End Sub

    'Private Sub RadioButton_diagnostic_7215_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7215_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7215.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_7215_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7215_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7215.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7311_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7311_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7311.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7311_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7311_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7311.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7312_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7312_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7312.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7312_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7312_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7312.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7313_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7313_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7313.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_7313_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7313_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7313.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7314_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7314_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7314.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_7314_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7314_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7314.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7411_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7411_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7411.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7411_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7411_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7411.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")

    'End Sub

    'Private Sub RadioButton_diagnostic_7412_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7412_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7412.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7412_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7412_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7412.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7413_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7413_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7413.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")

    'End Sub

    'Private Sub RadioButton_diagnostic_7413_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7413_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7413.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7414_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7414_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7414.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7414_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7414_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7414.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_7415_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7415_1.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7415.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_7415_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_7415_2.CheckedChanged

    '    isCodeSpecial = True
    '    RadioButton_diagnostic_7415.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MINEUR, 3, "2")
    'End Sub

    Private Sub RadioButton_diagnostic_9221_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9221.CheckedChanged
        If RadioButton_diagnostic_9221.Checked = False Then
            'Désactivation des checkBox _1 et _2
            'If RadioButton_diagnostic_9221_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_9221_1.Checked = False
            'End If
            'If RadioButton_diagnostic_9221_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_9221_2.Checked = False
            'End If
        End If
        checkAnswer2(sender, 4)
        If RadioButton_diagnostic_9221.Checked And
            (RadioButton_diagnostic_9221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN Or
             RadioButton_diagnostic_9221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX) Then
            disableTab922()
        Else
            enableTab922()
        End If

    End Sub
    'Private Sub RadioButton_diagnostic_9221_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9221_1.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab922()
    '    Else
    '        enableTab922()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_9221.Checked = sender.Checked

    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 4, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_9221_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9221_2.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab922()
    '    Else
    '        enableTab922()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_9221.Checked = sender.Checked
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 4, "2")
    'End Sub
    Private Sub RadioButton_diagnostic_9222_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9222.CheckedChanged
        'isCodeSpecial = False
        If RadioButton_diagnostic_9222.Checked = False Then
            'Désactivation des checkBox _1 et _2
            'If RadioButton_diagnostic_9222_1.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_9222_1.Checked = False
            'End If
            'If RadioButton_diagnostic_9222_2.Checked Then
            '    isCodeSpecial = True
            '    RadioButton_diagnostic_9222_2.Checked = False
            'End If
        End If
        checkAnswer2(sender, 4)
        If RadioButton_diagnostic_9222.Checked And
            (RadioButton_diagnostic_9222.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX Or
             RadioButton_diagnostic_9222.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN) Then
            disableTab922()
        Else
            enableTab922()
        End If
    End Sub

    'Private Sub RadioButton_diagnostic_9222_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9222_1.CheckedChanged
    '    If RadioButton_diagnostic_9222_1.Checked = True Then
    '        disableTab922()
    '    Else
    '        enableTab922()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_9222.Checked = RadioButton_diagnostic_9222_1.Checked
    '    isCodeSpecial = False
    '    checkAnswer(RadioButton_diagnostic_9222_1, CHK_DEFAUT_MAJEUR, 4, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_9222_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_9222_2.CheckedChanged
    '    If RadioButton_diagnostic_9222_2.Checked = True Then
    '        disableTab922()
    '    Else
    '        enableTab922()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_9222.Checked = RadioButton_diagnostic_9222_2.Checked
    '    isCodeSpecial = False
    '    checkAnswer(RadioButton_diagnostic_9222_2, CHK_DEFAUT_MAJEUR, 4, "2")
    'End Sub

    'Private Sub RadioButton_diagnostic_8332_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8332_1.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab833()
    '    Else
    '        enableTab833()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_8332.Checked = sender.checked
    '    isCodeSpecial = False
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 6, "1")
    'End Sub

    'Private Sub RadioButton_diagnostic_8332_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8332_2.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab833()
    '    Else
    '        enableTab833()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_8332.Checked = sender.checked
    '    isCodeSpecial = False
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 6, "2")
    'End Sub
    'Private Sub RadioButton_diagnostic_8333_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8333_1.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab833()
    '    Else
    '        enableTab833()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_8333.Checked = sender.checked
    '    isCodeSpecial = False
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 6, "1")


    'End Sub
    'Private Sub RadioButton_diagnostic_8333_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8333_2.CheckedChanged
    '    If sender.checked = True Then
    '        disableTab833()
    '    Else
    '        enableTab833()
    '    End If
    '    isCodeSpecial = True
    '    RadioButton_diagnostic_8333.Checked = sender.checked
    '    isCodeSpecial = False
    '    checkAnswer(sender, CHK_DEFAUT_MAJEUR, 6, "2")

    'End Sub


#Region " Traitements spécifiques "

    Public Sub disableTab542()
        '        diagBuses_tab_pressionTroncons_rampe.Enabled = False
        manopulveIsUseCalibrateur.Checked = False
        pnl542.Enabled = False
        checkIsOk(7)
    End Sub
    Public Sub enableTab542()
        '        diagBuses_tab_pressionTroncons_rampe.Enabled = False
        pnl542.Enabled = True
        checkIsOk(7)
    End Sub
    ' Traitement de l'activation / désactivation du tableau 8.3.3
    Public Sub disableTab833()
        '        diagBuses_tab_pressionTroncons_rampe.Enabled = False
        tab_833.Enabled = False
        pnl_833.Enabled = False
        checkIsOk(7)
    End Sub
    Public Sub enableTab833()
        '       diagBuses_tab_pressionTroncons_rampe.Enabled = True
        tab_833.Enabled = True
        pnl_833.Enabled = True
        checkIsOk(7)

    End Sub

    Public Function isTab833Enabled() As Boolean
        Return pnl_833.Enabled
    End Function

    ' Traitement de l'activation / désactivation du tableau 9.2.2
    Public Sub disableTab922()
        Panel922.Enabled = False
        checkIsOk(8)
    End Sub
    Public Sub enableTab922()
        Panel922.Enabled = True
        checkIsOk(8)
    End Sub

    Public Function isTab922Enabled() As Boolean
        Return Panel922.Enabled
    End Function
#End Region

#End Region

#End Region

#Region "============================================================================================="

#End Region

#Region " Debug "



    Private Sub btn_diagnostic_acquisitionDonnees_MouseClick(sender As Object, e As MouseEventArgs) Handles btn_diagnostic_acquisitionDonnees.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'Saise des données d'acquisition
            Dim odlg As Form = New dlgAquisition()
            odlg.Show()
        Else
            'transfert des données de l'acquisition
            doAcquiring()

        End If

    End Sub

    Private Sub Label54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles diagBuses_resultat.Click
        ' arrCheckboxes(8, 1) += 1
        checkIsOk(8)
    End Sub

    Private Sub pressionTronc_heterogeniteAlimentation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'arrCheckboxes(7, 1) += 1
        checkIsOk(7)
    End Sub

#End Region



    Private Sub tab_diagnostique_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tab_diagnostique.SelectedIndexChanged
        Select Case tab_diagnostique.SelectedIndex
            Case 6
                SetCurrentPressionControls()

        End Select
    End Sub

    Private Sub manopulveIsUseCalibrateur_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulveIsUseCalibrateur.CheckedChanged
        'CSDebug.dispInfo("manopulveIsUseCalibrateur_CheckedChanged_1")
        UtilisationDuCalibrateur(manopulveIsUseCalibrateur.Checked)
    End Sub
    Private Function UtilisationDuCalibrateur(ByVal pbUseCalibrateur As Boolean) As Boolean
        Dim bReturn As Boolean
        Try
            Dim bReadOnly As Boolean
            Dim color As System.Drawing.Color
            bReturn = True
            'Recopie des infos (Mano Pulvé) dans le tableau de saisie des pressions aux tronçons (s'il y a des valeurs)
            SetPressionControle542ToPressionManoPulve833(1, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(2, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(3, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(4, pbUseCalibrateur)
            If manopulveIsUseCalibrateur.Checked Then
                bReadOnly = False
                color = Drawing.Color.White
            Else
                bReadOnly = True
                color = System.Drawing.SystemColors.Control
            End If
            Label65.Enabled = Not bReadOnly
            manoTroncon_listManoControle.Enabled = Not bReadOnly

            manopulvePressionControle_1.ReadOnly = bReadOnly
            manopulvePressionControle_2.ReadOnly = bReadOnly
            manopulvePressionControle_3.ReadOnly = bReadOnly
            manopulvePressionControle_4.ReadOnly = bReadOnly
            manopulvePressionControle_1.BackColor = color
            manopulvePressionControle_2.BackColor = color
            manopulvePressionControle_3.BackColor = color
            manopulvePressionControle_4.BackColor = color

            RecalculerToutMano()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::UtilisationDuCalibrateur ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub RecalculerToutMano()
        'Recopie des valeurs 5.4.2 dans 8.3.3 si utilisation du calibrateur
        If manopulveIsUseCalibrateur.Checked Then
            SetPressionControle542ToPressionManoPulve833(1, manopulveIsUseCalibrateur.Checked)
            SetPressionControle542ToPressionManoPulve833(2, manopulveIsUseCalibrateur.Checked)
            SetPressionControle542ToPressionManoPulve833(3, manopulveIsUseCalibrateur.Checked)
            SetPressionControle542ToPressionManoPulve833(4, manopulveIsUseCalibrateur.Checked)
        End If
        If pnl_833.Enabled Then
            'Si pas d'utilisation du calibrateur , remontée des infos de 8.3.3 dans le tableau 5.42
            If Not manopulveIsUseCalibrateur.Checked Then
                'Si on n'utilise pas le calibrateur, on remonte la moyenne des pressions lues dans le tableau 5.4.2
                If Not String.IsNullOrEmpty(tbMoyenne1.Text) Then
                    manopulvePressionControle_1.Text = m_RelevePression833_P1.Result_Moyenne
                End If
                If Not String.IsNullOrEmpty(tbMoyenne2.Text) Then
                    manopulvePressionControle_2.Text = m_RelevePression833_P2.Result_Moyenne
                End If
                If Not String.IsNullOrEmpty(tbMoyenne3.Text) Then
                    manopulvePressionControle_3.Text = m_RelevePression833_P3.Result_Moyenne
                End If
                If Not String.IsNullOrEmpty(tbMoyenne4.Text) Then
                    manopulvePressionControle_4.Text = m_RelevePression833_P4.Result_Moyenne
                End If
                calcDefaut542()
            End If
        End If

    End Sub
    Private Sub validatePressionTronc(ByVal npression As Integer)
        'CSDebug.dispInfo("validatePressionTronc ( " & npression & ")")
        Dim pressionMano As Decimal
        Dim nNiveau As Integer
        Dim nTroncon As Integer

        'La validation n'est à faire que si le tableau est actif (L'activation des défauts 833 désactive le tableau)
        If pnl_833.Enabled And m_RelevePression833_Current IsNot Nothing Then

            'Affection des controles courants
            SetCurrentPressionControls(npression)

            m_tbPressionManoCurrent.Text = m_tbPressionManoCurrent.Text.Replace(".", ",")
            If IsNumeric(m_tbPressionManoCurrent.Text) Then
                pressionMano = CType(m_tbPressionManoCurrent.Text, Decimal)
                m_RelevePression833_Current.SetPressionMano(pressionMano)
                'parcours des colonnes du DataGridView pour récupérer le niveau et la colonne
                'on ne scrute pas la col0 qui correspond à une entete

                For ncol As Integer = 1 To m_dgvPressionCurrent.ColumnCount - 1
                    nNiveau = m_dgvPressionCurrent(ncol, ROW_NIVEAUX).Value
                    nTroncon = m_dgvPressionCurrent(ncol, ROW_TRONCONS).Value
                    'Reaffectation de la pression lue pour réinitialisé tous les calculs
                    If IsNumeric(m_dgvPressionCurrent(ncol, ROW_PRESSION).Value) Then
                        m_RelevePression833_Current.SetPressionLue(nNiveau, nTroncon, m_dgvPressionCurrent(ncol, ROW_PRESSION).Value)
                        'Affichage des résultats dans le datagridView courant
                        AfficheResultatNiveau(nNiveau)
                    End If
                Next

                'Affichage des defauts de la pression courante
                AfficheDefautHeterogeneite()
                AfficheDefautEcart()
                'ReAffection des controles courrants
                SetCurrentPressionControls()

            End If
        End If

    End Sub

    Private Sub AfficheDefautHeterogeneite()
        Try

            If Not m_RelevePression833_Current.GetNiveau(1) Is Nothing Then
                If m_RelevePression833_Current.Result_isDefautHeterogeneite Then
                    m_lblDefautHeterogeneite.Text = "DEFAUT"
                    m_lblDefautHeterogeneite.ForeColor = System.Drawing.Color.Red

                Else
                    m_lblDefautHeterogeneite.Text = "OK"
                    m_lblDefautHeterogeneite.ForeColor = System.Drawing.Color.Green
                End If
                AfficheDefautHeterogeneiteGeneral()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheDefautHeterogeneite ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub AfficheDefautEcart()
        Try

            If Not m_RelevePression833_Current.GetNiveau(1) Is Nothing Then
                If m_RelevePression833_Current.Result_isDefautEcart Then
                    m_lblDefautEcart.Text = "DEFAUT"
                    m_lblDefautEcart.ForeColor = System.Drawing.Color.Red

                Else
                    m_lblDefautEcart.Text = "OK"
                    m_lblDefautEcart.ForeColor = System.Drawing.Color.Green
                End If
                AfficheDefautEcartGeneral()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheDefautEcart ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub AfficheDefautEcartGeneral()
        Try

            Dim bDefaut As Boolean
            bDefaut = False
            If rbPression1.Checked And m_RelevePression833_P1.Result_isDefautEcart Then
                bDefaut = True
            End If
            If rbPression2.Checked And m_RelevePression833_P2.Result_isDefautEcart Then
                bDefaut = True
            End If
            If rbPression3.Checked And m_RelevePression833_P3.Result_isDefautEcart Then
                bDefaut = True
            End If
            If rbPression4.Checked And m_RelevePression833_P4.Result_isDefautEcart Then
                bDefaut = True
            End If
            If bDefaut Then
                lblp833DefautEcart.Text = "DEFAUT"
                lblp833DefautEcart.ForeColor = System.Drawing.Color.Red
                If Not m_bDuringLoad Then
                    'Pas de déclenchement pendant l'affichage d'un diag
                    RadioButton_diagnostic_8333.Checked = True
                    RadioButton_diagnostic_8330.Checked = False
                End If
            Else
                lblp833DefautEcart.Text = "OK"
                lblp833DefautEcart.ForeColor = System.Drawing.Color.Green
                RadioButton_diagnostic_8333.Checked = False
                If lblP833DefautHeterogeneite.Text = "OK" Then
                    If Not m_bDuringLoad Then
                        'Pas de déclenchement pendant l'affichage d'un diag
                        RadioButton_diagnostic_8330.Checked = True
                    End If
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheDefautEcartGeneral ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub AfficheDefautHeterogeneiteGeneral()
        Try

            Dim bDefaut As Boolean
            bDefaut = False
            If rbPression1.Checked And m_RelevePression833_P1.Result_isDefautHeterogeneite Then
                bDefaut = True
            End If
            If rbPression2.Checked And m_RelevePression833_P2.Result_isDefautHeterogeneite Then
                bDefaut = True
            End If
            If rbPression3.Checked And m_RelevePression833_P3.Result_isDefautHeterogeneite Then
                bDefaut = True
            End If
            If rbPression4.Checked And m_RelevePression833_P4.Result_isDefautHeterogeneite Then
                bDefaut = True
            End If
            If bDefaut Then
                lblP833DefautHeterogeneite.Text = "DEFAUT"
                lblP833DefautHeterogeneite.ForeColor = System.Drawing.Color.Red
                If Not m_bDuringLoad Then
                    'Pas de déclenchement pendant l'affichage d'un diag
                    RadioButton_diagnostic_8332.Checked = True
                    RadioButton_diagnostic_8330.Checked = False
                End If
            Else
                lblP833DefautHeterogeneite.Text = "OK"
                lblP833DefautHeterogeneite.ForeColor = System.Drawing.Color.Green
                'On ne modifie les défaut que s'il n'ont pas été fixés à la main
                '            If RadioButton_diagnostic_8332.CheckState = CheckState.Indeterminate Then
                RadioButton_diagnostic_8332.Checked = False
                'si le défaut d'écart est aussi à OK => on coche OK sans l'onglet Rampe
                If lblp833DefautEcart.Text = "OK" Then
                    If Not m_bDuringLoad Then
                        'Pas de déclenchement pendant l'affichage d'un diag
                        RadioButton_diagnostic_8330.Checked = True
                    End If
                End If
                'End If
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheDefautHeterogeneiteGeneral ERR : " & ex.Message)
        End Try
    End Sub
    Private Sub AfficheResultatNiveau(ByVal pNiveau As Integer)
        Try

            Dim nTroncon As Integer
            Dim nCol As Integer
            'Pour le defaut hétérogénéité => il faut regarder tous les tronçons
            'car le défaut est calculé sur la différence entre la pression d'un tronçon et la moyenne des autres tronçons
            For nTroncon = 1 To m_Troncons
                nCol = ((pNiveau - 1) * m_Troncons) + nTroncon
                If m_RelevePression833_Current.GetTroncon(pNiveau, nTroncon).isDefaultHeterogeneite(m_oParamdiag.ParamDiagCalc833) Then
                    'Ce troncon est en défaut
                    m_dgvPressionCurrent(nCol, ROW_HETERO_PCT).Style.ForeColor = System.Drawing.Color.Red
                Else
                    m_dgvPressionCurrent(nCol, ROW_HETERO_PCT).Style.ForeColor = System.Drawing.Color.Black
                End If

                nCol = ((pNiveau - 1) * m_Troncons) + nTroncon
                AfficheResultat833(nCol)
            Next

            'Affichage des moyennes de la pression courante
            m_tbMoyenneCurrent.Text = m_RelevePression833_Current.Result_Moyenne
            m_tbMoyEcartBarCurrent.Text = m_RelevePression833_Current.Result_EcartBars
            m_tbMoyEcartPctCurrent.Text = m_RelevePression833_Current.Result_EcartPct
            If m_RelevePression833_Current.Result_isDefautEcart() Then
                'Ce troncon est en défaut
                m_tbMoyEcartPctCurrent.BackColor = Color.Red
            Else
                m_tbMoyEcartPctCurrent.BackColor = Color.Green
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheResultatNiveau ERR : " & ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Affichage des résultats d'une colonne 
    ''' </summary>
    ''' <param name="ncol"></param>
    ''' <remarks></remarks>
    Private Sub AfficheResultat833(ByVal ncol As Integer)
        Dim nNiveau As Integer
        Dim nTroncon As Integer
        Try

            'Récupération du niveau et du troncon 
            nNiveau = m_dgvPressionCurrent(ncol, ROW_NIVEAUX).Value
            nTroncon = m_dgvPressionCurrent(ncol, ROW_TRONCONS).Value


            m_dgvPressionCurrent(ncol, ROW_ECART_BAR).Value = m_RelevePression833_Current.GetTroncon(nNiveau, nTroncon).EcartPression
            m_dgvPressionCurrent(ncol, ROW_ECART_PCT).Value = m_RelevePression833_Current.GetTroncon(nNiveau, nTroncon).EcartPressionpct
            m_dgvPressionCurrent(ncol, ROW_HETERO_BAR).Value = m_RelevePression833_Current.GetTroncon(nNiveau, nTroncon).EcartMoyenneAutresTroncons
            m_dgvPressionCurrent(ncol, ROW_HETERO_PCT).Value = m_RelevePression833_Current.GetTroncon(nNiveau, nTroncon).Heterogeneite
            m_dgvPressionCurrent(ncol, ROW_MOYENNE_ECART_AUTRE).Value = m_RelevePression833_Current.GetTroncon(nNiveau, nTroncon).MoyenneAutresTroncons
            m_dgvPressionCurrent(ncol, ROW_MOYENNE_PRESSION_LUE_TOUS).Value = m_RelevePression833_Current.GetNiveau(nNiveau).MoyenneTousTroncons
            m_dgvPressionCurrent(ncol, ROW_ECARTMOYEN_PCT).Value = m_RelevePression833_Current.GetNiveau(nNiveau).EcartMoyenneTousTroncons_pct
            m_dgvPressionCurrent(ncol, ROW_MOYENNE_ECART_TOUS).Value = m_RelevePression833_Current.GetNiveau(nNiveau).EcartMoyenneTousTroncons
        Catch ex As Exception
            CSDebug.dispError("diagnostique::AfficheResultat833 ERR : " & ex.Message)
        End Try

    End Sub
    Private Function SetCurrentPressionControls() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = SetCurrentPressionControls(tab_833.SelectedIndex + 1)
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("diagnostique::SetCurrentPressionControls ERR : " & ex.Message)
        End Try
        Return bReturn
    End Function
    Private Function SetCurrentPressionControls(ByVal nPression As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case nPression
                Case 1
                    m_dgvPressionCurrent = gdvPressions1
                    m_tbPressionManoCurrent = pressionTronc_5_pressionManoPulve
                    m_lblDefautEcart = pressionTronc_DefautEcart1
                    m_lblDefautHeterogeneite = pressionTronc_heterogeniteAlimentation1
                    m_RelevePression833_Current = m_RelevePression833_P1
                    m_tbMoyenneCurrent = tbMoyenne1
                    m_tbMoyEcartBarCurrent = tbMoyEcartbar1
                    m_tbMoyEcartPctCurrent = tbMoyEcartPct1
                Case 2
                    m_dgvPressionCurrent = gdvPressions2
                    m_tbPressionManoCurrent = pressionTronc_10_pressionManoPulve
                    m_lblDefautEcart = pressionTronc_DefautEcart2
                    m_lblDefautHeterogeneite = pressionTronc_heterogeniteAlimentation2
                    m_RelevePression833_Current = m_RelevePression833_P2
                    m_tbMoyenneCurrent = tbMoyenne2
                    m_tbMoyEcartBarCurrent = tbMoyEcartbar2
                    m_tbMoyEcartPctCurrent = tbMoyEcartPct2
                Case 3
                    m_dgvPressionCurrent = gdvPressions3
                    m_tbPressionManoCurrent = pressionTronc_15_pressionManoPulve
                    m_lblDefautEcart = pressionTronc_DefautEcart3
                    m_lblDefautHeterogeneite = pressionTronc_heterogeniteAlimentation3
                    m_RelevePression833_Current = m_RelevePression833_P3
                    m_tbMoyenneCurrent = tbMoyenne3
                    m_tbMoyEcartBarCurrent = tbMoyEcartbar3
                    m_tbMoyEcartPctCurrent = tbMoyEcartPct3
                Case 4
                    m_dgvPressionCurrent = gdvPressions4
                    m_tbPressionManoCurrent = pressionTronc_20_pressionManoPulve
                    m_lblDefautEcart = pressionTronc_DefautEcart4
                    m_lblDefautHeterogeneite = pressionTronc_heterogeniteAlimentation4
                    m_RelevePression833_Current = m_RelevePression833_P4
                    m_tbMoyenneCurrent = tbMoyenne4
                    m_tbMoyEcartBarCurrent = tbMoyEcartbar4
                    m_tbMoyEcartPctCurrent = tbMoyEcartPct4

            End Select

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("diagnostique::SetCurrentPressionControls ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Private Sub manopulveIsFaiblePression_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulveIsFaiblePression.CheckedChanged
        'CSDebug.dispInfo("manopulveIsFaiblePression_CheckedChanged_1")
        Try

            If manopulveIsFaiblePression.Checked Then
                setPressionsFaibles()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::manopulveIsFaiblePression_CheckedChanged_1 ERR : " & ex.Message)
        End Try
    End Sub
    Private Sub RAZManopulvePressionLues()
        manopulvePressionControle_1.Text = ""
        manopulvePressionControle_2.Text = ""
        manopulvePressionControle_3.Text = ""
        manopulvePressionControle_4.Text = ""

    End Sub
    Private Sub setPressionsFaibles()
        Try

            manopulvePressionPulve_1.Text = 1.6D
            manopulvePressionPulve_2.Text = 2
            manopulvePressionPulve_3.Text = 3
            manopulvePressionPulve_4.Text = 4
            manopulvePressionPulve_1.ReadOnly = True
            manopulvePressionPulve_2.ReadOnly = True
            manopulvePressionPulve_3.ReadOnly = True
            manopulvePressionPulve_4.ReadOnly = True
            AffichageEnteteOnglet()
            createRelevePression()
            RAZManopulvePressionLues()
            SetPressionControle542ToPressionManoPulve833(manopulveIsUseCalibrateur.Checked)
            SelectTableauMesurePourDefaut()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::setPressionsFaibles ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub setPressionsFortes()
        Try
            manopulvePressionPulve_1.Text = 5
            manopulvePressionPulve_2.Text = 10
            manopulvePressionPulve_3.Text = 15
            manopulvePressionPulve_4.Text = 20
            manopulvePressionPulve_1.ReadOnly = True
            manopulvePressionPulve_2.ReadOnly = True
            manopulvePressionPulve_3.ReadOnly = True
            manopulvePressionPulve_4.ReadOnly = True
            AffichageEnteteOnglet()
            createRelevePression()
            RAZManopulvePressionLues()
            SetPressionControle542ToPressionManoPulve833(manopulveIsUseCalibrateur.Checked)
            SelectTableauMesurePourDefaut()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::setPressionsFortes ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub AffichageEnteteOnglet()
        Try

            tab_833.TabPages(0).Text = manopulvePressionPulve_1.Text & " bars"
            tab_833.TabPages(1).Text = manopulvePressionPulve_2.Text & " bars"
            tab_833.TabPages(2).Text = manopulvePressionPulve_3.Text & " bars"
            tab_833.TabPages(3).Text = manopulvePressionPulve_4.Text & " bars"
        Catch ex As Exception
            CSDebug.dispError("diagnostique::AffichageEnteteOnglet ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub SetPressionControle542ToPressionManoPulve833(ByVal pbUseCalibrateur As Boolean)
        Try

            SetPressionControle542ToPressionManoPulve833(1, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(2, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(3, pbUseCalibrateur)
            SetPressionControle542ToPressionManoPulve833(4, pbUseCalibrateur)
            'Le tableau de mesure sera selectionné à chaque changement de valeur prédéfinies (Faible, Forte)
            SelectTableauMesurePourDefaut()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::SetPressionControle542ToPressionManoPulve833 ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub SetPressionControle542ToPressionManoPulve833(ByVal nMesure As Integer, ByVal pUseCalibrateur As Boolean)
        'CSDebug.dispInfo("SetPressionMano (" & nMesure & "," & pPression & ")")
        Try
            Dim strPression542 As String = ""
            'Détermination de la pression 542 à recopier
            If pUseCalibrateur Then
                Select Case nMesure
                    Case 1
                        strPression542 = manopulvePressionControle_1.Text
                    Case 2
                        strPression542 = manopulvePressionControle_2.Text
                    Case 3
                        strPression542 = manopulvePressionControle_3.Text
                    Case 4
                        strPression542 = manopulvePressionControle_4.Text
                End Select
            Else
                Select Case nMesure
                    Case 1
                        strPression542 = manopulvePressionPulve_1.Text
                    Case 2
                        strPression542 = manopulvePressionPulve_2.Text
                    Case 3
                        strPression542 = manopulvePressionPulve_3.Text
                    Case 4
                        strPression542 = manopulvePressionPulve_4.Text
                End Select

            End If
            'Recopie des infos dans le tableau 833 et recalcul des valeurs
            If Not String.IsNullOrEmpty(strPression542) Then
                If IsNumeric(strPression542) Then
                    Select Case nMesure
                        Case 1
                            pressionTronc_5_pressionManoPulve.Text = strPression542
                        Case 2
                            pressionTronc_10_pressionManoPulve.Text = strPression542
                        Case 3
                            pressionTronc_15_pressionManoPulve.Text = strPression542
                        Case 4
                            pressionTronc_20_pressionManoPulve.Text = strPression542
                    End Select
                    validatePressionTronc(nMesure)
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::SetPressionControle542ToPressionManoPulve833(detail) ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub SelectTableauMesurePourDefaut()
        Try

            rbPression1.Checked = False
            rbPression2.Checked = False
            rbPression3.Checked = False
            rbPression4.Checked = False
            setRelevePressionparDeFaut(1, False)
            setRelevePressionparDeFaut(2, False)
            setRelevePressionparDeFaut(3, False)
            setRelevePressionparDeFaut(4, False)

            'Il faut que les 4 valeurs soient remplies et corectes
            If String.IsNullOrEmpty(manopulvePressionPulve_1.Text) Or
                String.IsNullOrEmpty(manopulvePressionPulve_2.Text) Or
                String.IsNullOrEmpty(manopulvePressionPulve_3.Text) Or
                String.IsNullOrEmpty(manopulvePressionPulve_4.Text) Then
                Exit Sub
            Else
                If IsNumeric(manopulvePressionPulve_1.Text) And
                    IsNumeric(manopulvePressionPulve_2.Text) And
                    IsNumeric(manopulvePressionPulve_3.Text) And
                    IsNumeric(manopulvePressionPulve_4.Text) Then
                    'Les 4 valeurs sont coorectes
                    If m_oParamdiag.ParamDiagCalc833.PressionParDefaut = "1" Then
                        rbPression1.Checked = True
                        setRelevePressionparDeFaut(1, True)
                    Else
                        If m_oParamdiag.ParamDiagCalc833.PressionParDefaut = "2" Then
                            rbPression2.Checked = True
                            setRelevePressionparDeFaut(2, True)
                        Else
                            If m_oParamdiag.ParamDiagCalc833.PressionParDefaut = "3" Then
                                rbPression3.Checked = True
                                setRelevePressionparDeFaut(3, True)
                            Else
                                If m_oParamdiag.ParamDiagCalc833.PressionParDefaut = "4" Then
                                    rbPression4.Checked = True
                                    setRelevePressionparDeFaut(4, True)
                                Else
                                    'Par défaut on prend la dernière
                                    rbPression4.Checked = True
                                    setRelevePressionparDeFaut(4, True)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            tab_833.SelectedTab.ImageIndex = 0 'Affectation de la puce de l'onglet sélectionné (Bug la première fois il ne s'affiche automatiquement par le rb_chekedChange)

        Catch ex As Exception
            CSDebug.dispError("diagnostique::SelectTableauMesurePourDefaut ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub manopulveIsFortePression_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulveIsFortePression.CheckedChanged
        'CSDebug.dispInfo("manopulveIsFortePression_CheckedChanged_1")
        If manopulveIsFortePression.Checked Then
            setPressionsFortes()
        End If

    End Sub

    Private Sub manopulveIsSaisieManuelle_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulveIsSaisieManuelle.CheckedChanged
        'CSDebug.dispInfo("manopulveIsSaisieManuelle_CheckedChanged_1")
        If manopulveIsSaisieManuelle.Checked Then
            setPressionsManuelles()
        End If

    End Sub
    Private Sub setPressionsManuelles()
        Try

            manopulvePressionPulve_1.ReadOnly = False
            manopulvePressionPulve_2.ReadOnly = False
            manopulvePressionPulve_3.ReadOnly = False
            manopulvePressionPulve_4.ReadOnly = False
            'RAZManopulvePressionLues()
            SetPressionControle542ToPressionManoPulve833(manopulveIsUseCalibrateur.Checked)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::setPressionsManuelles ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub manopulvePressionPulve_1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_1.Validated
        Try

            'CSDebug.dispInfo("manopulvePressionPulve_1_Validated")
            manopulvePressionPulve_1.Text = manopulvePressionPulve_1.Text.Replace(".", ",")
            If IsNumeric(manopulvePressionPulve_1.Text) Then
                tab_833.TabPages(0).Text = manopulvePressionPulve_1.Text & " bars"
                SetPressionControle542ToPressionManoPulve833(1, manopulveIsUseCalibrateur.Checked)
                SelectTableauMesurePourDefaut()
                calcDefaut542()
                Me.GetNextControl(TryCast(sender, Control), True).Focus()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::manopulvePressionPulve_1_Validated ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub manopulvePressionPulve_2_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_2.Validated
        'CSDebug.dispInfo("manopulvePressionPulve_2_Validated")
        Try

            manopulvePressionPulve_2.Text = manopulvePressionPulve_2.Text.Replace(".", ",")
            If IsNumeric(manopulvePressionPulve_2.Text) Then
                tab_833.TabPages(1).Text = manopulvePressionPulve_2.Text & " bars"
                SetPressionControle542ToPressionManoPulve833(2, manopulveIsUseCalibrateur.Checked)
                SelectTableauMesurePourDefaut()
                calcDefaut542()
                Me.GetNextControl(TryCast(sender, Control), True).Focus()
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::manopulvePressionPulve_2_Validated ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub manopulvePressionPulve_3_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_3.Validated
        'CSDebug.dispInfo("manopulvePressionPulve_3_Validated")
        Try

            manopulvePressionPulve_3.Text = manopulvePressionPulve_3.Text.Replace(".", ",")
            If IsNumeric(manopulvePressionPulve_3.Text) Then
                tab_833.TabPages(2).Text = manopulvePressionPulve_3.Text & " bars"
                SetPressionControle542ToPressionManoPulve833(3, manopulveIsUseCalibrateur.Checked)
                SelectTableauMesurePourDefaut()
                calcDefaut542()
                Me.GetNextControl(TryCast(sender, Control), True).Focus()
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::manopulvePressionPulve_3_Validated ERR : " & ex.Message)
        End Try
    End Sub

    Private Sub manopulvePressionPulve_4_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_4.Validated
        'CSDebug.dispInfo("manopulvePressionPulve_4_Validated")
        Try

            manopulvePressionPulve_4.Text = manopulvePressionPulve_4.Text.Replace(".", ",")
            If IsNumeric(manopulvePressionPulve_4.Text) Then
                tab_833.TabPages(3).Text = manopulvePressionPulve_4.Text & " bars"
                SetPressionControle542ToPressionManoPulve833(4, manopulveIsUseCalibrateur.Checked)
                SelectTableauMesurePourDefaut()
                calcDefaut542()
                Me.GetNextControl(TryCast(sender, Control), True).Focus()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::manopulvePressionPulve_4_Validated ERR : " & ex.Message)
        End Try

    End Sub

    'Private Sub manopulvePressionPulve_5_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_5.Validated
    '    Try

    '        'CSDebug.dispInfo("manopulvePressionPulve_1_Validated")
    '        manopulvePressionPulve_5.Text = manopulvePressionPulve_5.Text.Replace(".", ",")
    '        If IsNumeric(manopulvePressionPulve_5.Text) Then
    '            tab_833.TabPages(0).Text = manopulvePressionPulve_5.Text & " bars"
    '            SetPressionControle542ToPressionManoPulve833(1, manopulveIsUseCalibrateur.Checked)
    '            SelectTableauMesurePourDefaut()
    '            calcDefaut542()
    '        End If
    '    Catch ex As Exception
    '        CSDebug.dispError("diagnostique::manopulvePressionPulve_5_Validated ERR : " & ex.Message)
    '    End Try

    'End Sub
    'Private Sub manopulvePressionPulve_6_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_6.Validated
    '    Try

    '        'CSDebug.dispInfo("manopulvePressionPulve_1_Validated")
    '        manopulvePressionPulve_6.Text = manopulvePressionPulve_6.Text.Replace(".", ",")
    '        If IsNumeric(manopulvePressionPulve_6.Text) Then
    '            tab_833.TabPages(1).Text = manopulvePressionPulve_6.Text & " bars"
    '            SetPressionControle542ToPressionManoPulve833(2, manopulveIsUseCalibrateur.Checked)
    '            SelectTableauMesurePourDefaut()
    '            calcDefaut542()
    '        End If
    '    Catch ex As Exception
    '        CSDebug.dispError("diagnostique::manopulvePressionPulve_6_Validated ERR : " & ex.Message)
    '    End Try

    'End Sub
    'Private Sub manopulvePressionPulve_7_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manopulvePressionPulve_7.Validated
    '    Try

    '        'CSDebug.dispInfo("manopulvePressionPulve_1_Validated")
    '        manopulvePressionPulve_7.Text = manopulvePressionPulve_7.Text.Replace(".", ",")
    '        If IsNumeric(manopulvePressionPulve_7.Text) Then
    '            tab_833.TabPages(2).Text = manopulvePressionPulve_7.Text & " bars"
    '            SetPressionControle542ToPressionManoPulve833(3, manopulveIsUseCalibrateur.Checked)
    '            SelectTableauMesurePourDefaut()
    '            calcDefaut542()
    '        End If
    '    Catch ex As Exception
    '        CSDebug.dispError("diagnostique::manopulvePressionPulve_7_Validated ERR : " & ex.Message)
    '    End Try

    'End Sub
    'Private Sub manopulvePressionPulve_8_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    '    'Try

    '    '    'CSDebug.dispInfo("manopulvePressionPulve_1_Validated")
    '    '    manopulvePressionPulve_8.Text = manopulvePressionPulve_8.Text.Replace(".", ",")
    '    '    If IsNumeric(manopulvePressionPulve_8.Text) Then
    '    '        tab_833.TabPages(3).Text = manopulvePressionPulve_8.Text & " bars"
    '    '        SetPressionControle542ToPressionManoPulve833(4, manopulveIsUseCalibrateur.Checked)
    '    '        SelectTableauMesurePourDefaut()
    '    '        calcDefaut542()
    '    '    End If
    '    'Catch ex As Exception
    '    '    CSDebug.dispError("diagnostique::manopulvePressionPulve_8_Validated ERR : " & ex.Message)
    '    'End Try

    'End Sub

    Private Sub manopulvePressionControle_1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles manopulvePressionControle_1.TextChanged
        If Not m_bDuringLoad Then
            validatemanopulvePressionControle(1)
        End If
    End Sub


    Private Sub manopulvePressionControle_2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles manopulvePressionControle_2.TextChanged
        If Not m_bDuringLoad Then
            validatemanopulvePressionControle(2)
        End If
    End Sub


    Private Sub manopulvePressionControle_3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles manopulvePressionControle_3.TextChanged
        If Not m_bDuringLoad Then
            validatemanopulvePressionControle(3)
        End If
    End Sub


    'Sur le manoPulvePressionControle 4 on valid à chaque frappe , car il se peut qu'il soit le dernier TB de la page. et 
    'le validated ne se déclenche que si un autre controle prend le focus , click sur un panel ne prend pas le focus
    Private Sub manopulvePressionControle_4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles manopulvePressionControle_4.TextChanged
        If Not m_bDuringLoad Then
            validatemanopulvePressionControle(4)
        End If
    End Sub


    Private Function validatemanopulvePressionControle(ByVal pPression As Integer) As Boolean
        'CSDebug.dispInfo("validatemanopulvePressionControle")
        Dim bReturn As Boolean
        Dim oldDuringLoad As Boolean
        bReturn = False
        Try
            Dim TB As CRODIP_ControlLibrary.TBNumeric = Nothing
            Select Case pPression
                Case 1
                    TB = manopulvePressionControle_1
                Case 2
                    TB = manopulvePressionControle_2
                Case 3
                    TB = manopulvePressionControle_3
                Case 4
                    TB = manopulvePressionControle_4
            End Select

            If TB IsNot Nothing Then
                oldDuringLoad = m_bDuringLoad
                m_bDuringLoad = True
                TB.Text = TB.Text.Replace(".", ",")
                m_bDuringLoad = oldDuringLoad
                If IsNumeric(TB.Text) Then
                    SetPressionControle542ToPressionManoPulve833(pPression, manopulveIsUseCalibrateur.Checked)
                    calcDefaut542()
                    bReturn = True
                Else
                    Dim imprecisionTextBox As New CRODIP_ControlLibrary.TBNumeric
                    Dim ecartTextBox As New CRODIP_ControlLibrary.TBNumeric()

                    Select Case pPression
                        Case 1
                            imprecisionTextBox = manopulvePressionImprecision_1
                            ecartTextBox = manopulvePressionEcart_1
                        Case 2
                            imprecisionTextBox = manopulvePressionImprecision_2
                            ecartTextBox = manopulvePressionEcart_2
                        Case 3
                            imprecisionTextBox = manopulvePressionImprecision_3
                            ecartTextBox = manopulvePressionEcart_3
                        Case 4
                            imprecisionTextBox = manopulvePressionImprecision_4
                            ecartTextBox = manopulvePressionEcart_4
                    End Select
                    imprecisionTextBox.Text = ""
                    ecartTextBox.Text = ""
                    imprecisionTextBox.BackColor = Color.LightGray
                End If
            End If
            checkIsOk(7)
        Catch ex As Exception
            CSDebug.dispError("diagnostique::validatemanopulvePressionControle ERR : " & ex.Message)
        End Try

        Return bReturn
    End Function



    Private Sub btnRecalculer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecalculer.Click
        'CSDebug.dispInfo("btnRecalculer_Click")
        RecalculerToutMano()

    End Sub

    Private Sub CreerNiveauxTroncons833()
        'CSDebug.dispInfo("CreerNiveauxTroncons833")
        Try
            designdgv(nup_niveaux.Value, nupTroncons.Value, 1)
            designdgv(nup_niveaux.Value, nupTroncons.Value, 2)
            designdgv(nup_niveaux.Value, nupTroncons.Value, 3)
            designdgv(nup_niveaux.Value, nupTroncons.Value, 4)
            'Affectation des mesures au tableau
            createRelevePression()
            init542()
            init833()
            'Initialisation des valeurs mémorisées
            If Not m_bDuringLoad Then
                Affiche542()
                Affiche833()
            End If

            'Vérification de la saisie de l'onglet 7
            checkIsOk(7)

        Catch ex As Exception
            CSDebug.dispError("diagnostique::CreerNiveauxTroncons833 ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub init833()
        tbMoyenne1.Text = ""
        tbMoyenne2.Text = ""
        tbMoyenne3.Text = ""
        tbMoyenne4.Text = ""
        tbMoyEcartbar1.Text = ""
        tbMoyEcartbar2.Text = ""
        tbMoyEcartbar3.Text = ""
        tbMoyEcartbar4.Text = ""
        tbMoyEcartPct1.Text = ""
        tbMoyEcartPct2.Text = ""
        tbMoyEcartPct3.Text = ""
        tbMoyEcartPct4.Text = ""
        tbMoyEcartPct1.BackColor = System.Drawing.SystemColors.Window
        tbMoyEcartPct2.BackColor = System.Drawing.SystemColors.Window
        tbMoyEcartPct3.BackColor = System.Drawing.SystemColors.Window
        tbMoyEcartPct4.BackColor = System.Drawing.SystemColors.Window
        pressionTronc_DefautEcart1.Text = ""
        pressionTronc_DefautEcart2.Text = ""
        pressionTronc_DefautEcart3.Text = ""
        pressionTronc_DefautEcart4.Text = ""
        pressionTronc_heterogeniteAlimentation1.Text = ""
        pressionTronc_heterogeniteAlimentation2.Text = ""
        pressionTronc_heterogeniteAlimentation3.Text = ""
        pressionTronc_heterogeniteAlimentation4.Text = ""

        lblp833DefautEcart.Text = ""
        lblP833DefautHeterogeneite.Text = ""

    End Sub
    Private Sub init542()
        manopulvePressionControle_1.Text = ""
        manopulvePressionControle_2.Text = ""
        manopulvePressionControle_3.Text = ""
        manopulvePressionControle_4.Text = ""
        manopulvePressionEcart_1.Text = ""
        manopulvePressionEcart_2.Text = ""
        manopulvePressionEcart_3.Text = ""
        manopulvePressionEcart_4.Text = ""
        Me.manopulvePressionEcart_1.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_2.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_3.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionEcart_4.BackColor = System.Drawing.SystemColors.Control
        manopulvePressionImprecision_1.Text = ""
        manopulvePressionImprecision_2.Text = ""
        manopulvePressionImprecision_3.Text = ""
        manopulvePressionImprecision_4.Text = ""
        Me.manopulvePressionImprecision_1.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_2.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_3.BackColor = System.Drawing.SystemColors.Control
        Me.manopulvePressionImprecision_4.BackColor = System.Drawing.SystemColors.Control

        manoPulveEcartMoyen.Text = ""
        manoPulveEcartMax.Text = ""
        manopulveResultat.Text = ""
        Me.manopulveResultat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))

    End Sub
    Private Sub nup_niveaux_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nup_niveaux.ValueChanged
        Affiche833Reset()
    End Sub
    Private Sub nupTroncons_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupTroncons.ValueChanged
        Affiche833Reset()
    End Sub
    ''' <summary>
    ''' reaffachiag du tableau 833 modificatino du nbre niveaux / Tronçons
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Affiche833Reset()
        Try
            If Not m_bDuringLoad Then
                'pour éviter trop de rafraischissement on cache le tab au début et on le montre à la fin
                tab_833.Hide()
                '                If nup_niveaux.Value > 0 And nupTroncons.Value > 0 Then
                Dim tabindex As Integer = tab_833.SelectedIndex
                validerDiagnostiqueTab542()
                validerDiagnostiqueTab833()
                CreerNiveauxTroncons833()
                tab_833.SelectedIndex = tabindex
                tab_833.Show()
                '            End If
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::Affiche833Reset ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub designdgv(ByVal pNbNiveaux As Integer, ByVal pNbTroncons As Integer, ByVal pNPression As Integer)
        Try

            Dim nbColTotal As Integer
            Dim colName As String
            Dim HeaderName As String
            Dim pdgvPression As DataGridView
            Select Case pNPression
                Case 1
                    pdgvPression = gdvPressions1
                Case 2
                    pdgvPression = gdvPressions2
                Case 3
                    pdgvPression = gdvPressions3
                Case 4
                    pdgvPression = gdvPressions4
                Case Else
                    pdgvPression = Nothing
                    Exit Sub
            End Select

            m_Niveaux = nup_niveaux.Value
            m_Troncons = nupTroncons.Value
            nbColTotal = pNbNiveaux * pNbTroncons + 1
            If nbColTotal < 30 Then
                pdgvPression.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Else
                pdgvPression.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            End If

            pdgvPression.Columns.Clear()

            pdgvPression.Columns.Add("entete", "")
            For i As Integer = 1 To pNbNiveaux
                For j As Integer = 1 To pNbTroncons
                    colName = "col" & i
                    If i = 1 And j = 1 Then
                        HeaderName = "Tronçons"
                    Else
                        HeaderName = i & "/" & j
                    End If
                    pdgvPression.Columns.Add(colName, HeaderName)
                Next j
            Next i

            Dim oHeaderStyle As DataGridViewCellStyle
            oHeaderStyle = New DataGridViewCellStyle()
            oHeaderStyle.BackColor = Color.LightGray
            oHeaderStyle.ForeColor = Color.FromArgb(2, 129, 198)
            oHeaderStyle.Font = New Font(pdgvPression.Font, FontStyle.Bold)
            oHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dim oStyleSeparator As DataGridViewCellStyle
            oStyleSeparator = New DataGridViewCellStyle()
            oStyleSeparator.BackColor = Color.Black
            oStyleSeparator.Font = New Font(pdgvPression.Font, FontStyle.Bold)
            oStyleSeparator.Alignment = DataGridViewContentAlignment.MiddleCenter
            pdgvPression.Rows.Add(ROW_NB)
            pdgvPression.Columns(0).ReadOnly = True
            pdgvPression(0, ROW_NIVEAUX).Value = "Niveaux"
            pdgvPression(0, ROW_TRONCONS).Value = "Tronçons"
            pdgvPression(0, ROW_PRESSION).Value = "Pression Lue"
            pdgvPression(0, ROW_ECART_BAR).Value = "Ecart (bars)"
            pdgvPression(0, ROW_ECART_PCT).Value = "Ecart (%)"
            pdgvPression(0, ROW_HETERO_PCT).Value = "Hétérogénéité %"
            pdgvPression(0, ROW_HETERO_BAR).Value = "Hétérogénéité bars"
            pdgvPression(0, ROW_MOYENNE_ECART_AUTRE).Value = "Moyenne Autres tronçons"
            pdgvPression(0, ROW_ECARTMOYEN_PCT).Value = "Ecart moyen (%)"
            pdgvPression(0, ROW_MOYENNE_PRESSION_LUE_TOUS).Value = "Moyenne Pression=>EP"
            pdgvPression(0, ROW_MOYENNE_ECART_TOUS).Value = "Moyenne Ecart=>EP"
            pdgvPression(0, ROW_NIVEAUX).Style = oHeaderStyle
            pdgvPression(0, ROW_TRONCONS).Style = oHeaderStyle
            pdgvPression(0, ROW_PRESSION).Style = oHeaderStyle
            pdgvPression(0, ROW_ECART_BAR).Style = oHeaderStyle
            pdgvPression(0, ROW_ECART_PCT).Style = oHeaderStyle
            pdgvPression(0, ROW_HETERO_BAR).Style = oHeaderStyle
            pdgvPression(0, ROW_HETERO_PCT).Style = oHeaderStyle
            pdgvPression(0, ROW_MOYENNE_ECART_AUTRE).Style = oHeaderStyle
            pdgvPression(0, ROW_ECARTMOYEN_PCT).Style = oHeaderStyle
            pdgvPression(0, ROW_MOYENNE_PRESSION_LUE_TOUS).Style = oHeaderStyle
            pdgvPression(0, ROW_MOYENNE_ECART_TOUS).Style = oHeaderStyle
            pdgvPression(0, ROW_SEPARATOR).Style = oStyleSeparator
            pdgvPression.Rows(ROW_SEPARATOR).Height = 1
            pdgvPression.Rows(ROW_NIVEAUX).ReadOnly = True
            pdgvPression.Rows(ROW_TRONCONS).ReadOnly = True
            pdgvPression.Rows(ROW_ECART_BAR).ReadOnly = True
            pdgvPression.Rows(ROW_ECART_PCT).ReadOnly = True
            pdgvPression.Rows(ROW_HETERO_BAR).ReadOnly = True
            pdgvPression.Rows(ROW_HETERO_PCT).ReadOnly = True
            pdgvPression.Rows(ROW_MOYENNE_ECART_AUTRE).ReadOnly = True
            pdgvPression.Rows(ROW_ECARTMOYEN_PCT).ReadOnly = True
            pdgvPression.Rows(ROW_MOYENNE_PRESSION_LUE_TOUS).ReadOnly = True
            pdgvPression.Rows(ROW_MOYENNE_ECART_TOUS).ReadOnly = True
            pdgvPression.Rows(ROW_SEPARATOR).ReadOnly = True
            pdgvPression.Rows(ROW_NIVEAUX).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_TRONCONS).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_ECART_BAR).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_ECART_PCT).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_HETERO_BAR).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_HETERO_PCT).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_MOYENNE_ECART_AUTRE).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_ECARTMOYEN_PCT).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_MOYENNE_PRESSION_LUE_TOUS).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_MOYENNE_ECART_TOUS).DefaultCellStyle.BackColor = Color.LightGray
            pdgvPression.Rows(ROW_SEPARATOR).DefaultCellStyle.BackColor = Color.Black
            Dim nCol As Integer
            nCol = 1
            For i As Integer = 1 To pNbNiveaux
                For j As Integer = 1 To pNbTroncons
                    pdgvPression(nCol, ROW_NIVEAUX).Value = i
                    pdgvPression(nCol, ROW_TRONCONS).Value = j
                    pdgvPression(nCol, ROW_NPRESSION).Value = pNPression
                    pdgvPression(nCol, ROW_NIVEAUX).Style = oHeaderStyle
                    pdgvPression(nCol, ROW_TRONCONS).Style = oHeaderStyle
                    nCol = nCol + 1
                Next j
            Next i
            Try

                pdgvPression.CurrentCell = pdgvPression(1, 2)
                pdgvPression.FirstDisplayedCell = pdgvPression(1, 2)
            Catch
            End Try
            'Suppressionde la Ligne Niveau si un seul niveau
            If pNbNiveaux = 1 Then
                pdgvPression.Rows(ROW_NIVEAUX).Visible = False
                pdgvPression.Height = 165
            Else
                pdgvPression.Height = 185
            End If
            If nbColTotal >= 30 Then
                pdgvPression.Height = pdgvPression.Height + SystemInformation.HorizontalScrollBarHeight
            End If
            'Supression des lignes communes
            pdgvPression.Rows(ROW_MOYENNE_PRESSION_LUE_TOUS).Visible = False
            pdgvPression.Rows(ROW_MOYENNE_ECART_TOUS).Visible = False
            pdgvPression.Rows(ROW_ECARTMOYEN_PCT).Visible = False
            pdgvPression.Rows(ROW_NPRESSION).Visible = False

        Catch ex As Exception
            CSDebug.dispError("diagnostique::designdgv ERR : " & ex.Message)
        End Try


    End Sub

    Private Sub createRelevePression()
        Try

            Dim pressionMano As Decimal
            pressionMano = CDec(m_oParamdiag.ParamDiagCalc833.Pression1)
            m_RelevePression833_P1 = New RelevePression833(nup_niveaux.Value, nupTroncons.Value, pressionMano, m_oParamdiag.ParamDiagCalc833)



            pressionMano = CDec(m_oParamdiag.ParamDiagCalc833.Pression2)
            m_RelevePression833_P2 = New RelevePression833(nup_niveaux.Value, nupTroncons.Value, pressionMano, m_oParamdiag.ParamDiagCalc833)

            pressionMano = CDec(m_oParamdiag.ParamDiagCalc833.Pression3)
            m_RelevePression833_P3 = New RelevePression833(nup_niveaux.Value, nupTroncons.Value, pressionMano, m_oParamdiag.ParamDiagCalc833)

            pressionMano = CDec(m_oParamdiag.ParamDiagCalc833.Pression4)
            m_RelevePression833_P4 = New RelevePression833(nup_niveaux.Value, nupTroncons.Value, pressionMano, m_oParamdiag.ParamDiagCalc833)

            SelectTableauMesurePourDefaut()
            SetCurrentPressionControls()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::createRelevePression ERR : " & ex.Message)
        End Try
    End Sub


    Private Sub gdvPressions1_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles gdvPressions1.CellPainting
        Try

            If e.RowIndex = ROW_NIVEAUX And e.ColumnIndex > 0 Then
                dgv_CellPainting(e, nupTroncons.Value)
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions1_CellPainting ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions1_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions1.CellEnter
        Try

            dgv_CellEnter()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions1_CellEnter ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions1_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions1.CellValueChanged
        'CSDebug.dispInfo("gdvPressions1_CellValueChanged")
        Try

            If e.RowIndex = ROW_PRESSION And e.ColumnIndex > 0 Then
                dgv_CellValueChanged()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions1_CellValueChanged ERR : " & ex.Message)
        End Try


    End Sub



    Private Sub gdvPressions2_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions2.CellEnter
        dgv_CellEnter()

    End Sub

    Private Sub gdvPressions2_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles gdvPressions2.CellPainting
        Try

            If e.RowIndex = ROW_NIVEAUX And e.ColumnIndex > 0 Then
                dgv_CellPainting(e, nupTroncons.Value)
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions2_CellPainting ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions2_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions2.CellValueChanged
        'CSDebug.dispInfo("gdvPressions2_CellValueChanged")
        Try

            If e.RowIndex = ROW_PRESSION And e.ColumnIndex > 0 Then
                dgv_CellValueChanged()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions2_CellValueChanged ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions3_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions3.CellEnter
        dgv_CellEnter()

    End Sub

    Private Sub gdvPressions3_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles gdvPressions3.CellPainting
        Try

            If e.RowIndex = ROW_NIVEAUX And e.ColumnIndex > 0 Then
                dgv_CellPainting(e, nupTroncons.Value)
            End If

        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions3_CellPainting ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions3_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions3.CellValueChanged
        'CSDebug.dispInfo("gdvPressions3_CellValueChanged")
        Try

            If e.RowIndex = ROW_PRESSION And e.ColumnIndex > 0 Then
                dgv_CellValueChanged()
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions3_CellValueChanged ERR : " & ex.Message)
        End Try

    End Sub


    Private Sub gdvPressions4_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions4.CellEnter
        dgv_CellEnter()

    End Sub

    Private Sub gdvPressions4_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles gdvPressions4.CellPainting
        Try

            'CSDebug.dispInfo("e.RowIndex" & e.RowIndex & ", e.columnIndex = " & e.ColumnIndex)
            If (e.RowIndex = ROW_NIVEAUX) And e.ColumnIndex > 0 Then
                dgv_CellPainting(e, nupTroncons.Value)
            End If
            '            e.Handled = True
        Catch ex As Exception
            CSDebug.dispError("diagnostique::gdvPressions4_CellPainting ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub gdvPressions4_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gdvPressions4.CellValueChanged
        'CSDebug.dispInfo("gdvPressions4_CellValueChanged")
        If e.RowIndex = ROW_PRESSION And e.ColumnIndex > 0 Then
            dgv_CellValueChanged()
        End If

    End Sub


    Private m_bCellPaint As Boolean = False
    Private m_bCellBounds As Rectangle
    Private Sub dgv_CellPainting(ByVal e As DataGridViewCellPaintingEventArgs, ByVal nbTroncons As Integer)

        Try
            'On ne fait ce Calcul pour si l'on n'a plus d'un niveau : BUG LOT3
            If nup_niveaux.Value > 1 Then
                If Not m_bCellPaint Then
                    m_bCellBounds = e.CellBounds
                    m_bCellPaint = True
                End If
                Dim gridBrush As Brush = New SolidBrush(m_dgvPressionCurrent.GridColor)
                Dim backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)
                Dim gridLinePen As Pen = New Pen(gridBrush)
                ' Clear cell 
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                'Bottom line drawing
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                'top line drawing
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Top)
                'Drawing Right line
                If e.ColumnIndex Mod nbTroncons = 0 Then
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)
                End If
                'Inserting text
                If e.ColumnIndex Mod nbTroncons = 0 Then
                    '                        e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X - (e.CellBounds.X / 4), e.CellBounds.Y + 5)
                    e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, m_bCellBounds.X + (e.CellBounds.X + e.CellBounds.Width - m_bCellBounds.X) / 2, e.CellBounds.Y)
                    m_bCellPaint = False
                End If
                e.Handled = True
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::dgv_CellPainting ERR : " & ex.Message)
        End Try

    End Sub
    Private Sub dgv_CellEnter()
        Dim iCol As Integer
        Dim irow As Integer
        Try
            If m_dgvPressionCurrent IsNot Nothing Then
                If m_dgvPressionCurrent.CurrentCell IsNot Nothing Then
                    iCol = m_dgvPressionCurrent.CurrentCell.ColumnIndex
                    irow = m_dgvPressionCurrent.CurrentCell.RowIndex
                    'Si la cellule sur laquelle on entre est 'ReadOnly' on relance un Tab
                    If (m_dgvPressionCurrent.Rows(irow).Cells(iCol).ReadOnly = True) Then
                        'If iCol = (m_dgvPressionCurrent.ColumnCount - 1) Then
                        'm_dgvPressionCurrent.CurrentCell = m_dgvPressionCurrent(1, ROW_PRESSION)
                        'Else
                        'SendKeys.Send("{Tab}")
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("dgv_CellEnter" & ex.Message)

        End Try

    End Sub
    Private Sub dgv_CellValueChanged()
        'CSDebug.dispInfo("dgv_CellValueChanged")
        Try

            Dim ncol As Integer
            Dim nNiveau As Integer
            Dim nTroncon As Integer
            Dim oNiveau As RelevePression833Niveau
            Dim nPression As Integer
            Dim strValue As String
            SetCurrentPressionControls()
            If m_dgvPressionCurrent IsNot Nothing And m_dgvPressionCurrent.CurrentCell.Value IsNot Nothing Then
                strValue = m_dgvPressionCurrent.CurrentCell.Value.ToString()

                strValue = strValue.ToString().Replace("?", ",")
                strValue = strValue.ToString().Replace(";", ".")
                m_dgvPressionCurrent.CurrentCell.Value = strValue.Replace(".", ",")
                ncol = m_dgvPressionCurrent.CurrentCell.ColumnIndex
                nNiveau = m_dgvPressionCurrent(ncol, ROW_NIVEAUX).Value
                nTroncon = m_dgvPressionCurrent(ncol, ROW_TRONCONS).Value
                nPression = m_dgvPressionCurrent(ncol, ROW_NPRESSION).Value
                oNiveau = m_RelevePression833_Current.GetNiveau(nNiveau)
                If Not IsNumeric(m_dgvPressionCurrent.CurrentCell.Value) Then
                    m_dgvPressionCurrent.CurrentCell.ErrorText = "Valeur Numérique"
                    m_dgvPressionCurrent.CurrentCell.Value = ""
                    oNiveau.SetPressionLue(nTroncon, -1)
                Else
                    m_dgvPressionCurrent.CurrentCell.ErrorText = ""
                    oNiveau.SetPressionLue(nTroncon, m_dgvPressionCurrent.CurrentCell.Value)
                End If
                'Vérification du défaut 'Ecart de pression' pour le Niveau
                If m_RelevePression833_Current.GetNiveau(nNiveau).isDefaultEcart(m_oParamdiag.ParamDiagCalc833) Then
                    'Ce troncon est en défaut
                    m_dgvPressionCurrent(ncol, ROW_ECARTMOYEN_PCT).Style.ForeColor = System.Drawing.Color.Red
                Else
                    m_dgvPressionCurrent(ncol, ROW_ECARTMOYEN_PCT).Style.ForeColor = System.Drawing.Color.Black
                End If

                AfficheResultatNiveau(nNiveau)

                'Affichage des defauts de la pression courante
                AfficheDefautHeterogeneite()
                AfficheDefautEcart()
                If pnl542.Enabled Then
                    If Not manopulveIsUseCalibrateur.Checked Then
                        If Not String.IsNullOrEmpty(m_tbMoyenneCurrent.Text) Then
                            'Si on n'utilise pas le calibrateur, on remonte la moyenne des pressions lues dans le tableau 5.4.2
                            ' TO DO : On pourrait remplacer ce selecteur pas l'utilisation d'une pression courante
                            Select Case nPression
                                Case 1
                                    manopulvePressionControle_1.Text = m_RelevePression833_P1.Result_Moyenne
                                Case 2
                                    manopulvePressionControle_2.Text = m_RelevePression833_P2.Result_Moyenne
                                Case 3
                                    manopulvePressionControle_3.Text = m_RelevePression833_P3.Result_Moyenne
                                Case 4
                                    manopulvePressionControle_4.Text = m_RelevePression833_P4.Result_Moyenne
                            End Select
                        End If
                    End If
                    calcDefaut542()
                End If
                'Vérification de la saisie de l'onglet 7
                checkIsOk(7)
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::dgv_CellValueChanged ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub rbPression1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPression1.CheckedChanged, RadioButton1.CheckedChanged
        'CSDebug.dispInfo("rbPression1_CheckedChanged")
        setRelevePressionparDeFaut(1, rbPression1.Checked)

    End Sub

    Private Sub rbPression2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPression2.CheckedChanged
        'CSDebug.dispInfo("RadioButton2_CheckedChanged")
        setRelevePressionparDeFaut(2, rbPression2.Checked)

    End Sub

    Private Sub rbPression3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPression3.CheckedChanged
        'CSDebug.dispInfo("rbPression3_CheckedChanged")
        setRelevePressionparDeFaut(3, rbPression3.Checked)
    End Sub
    Private Sub setRelevePressionparDeFaut(ByVal nPression As Integer, ByVal bValue As Boolean)
        Dim oReleve As RelevePression833 = Nothing
        Select Case nPression
            Case 1
                oReleve = m_RelevePression833_P1
            Case 2
                oReleve = m_RelevePression833_P2
            Case 3
                oReleve = m_RelevePression833_P3
            Case 4
                oReleve = m_RelevePression833_P4
        End Select
        If oReleve IsNot Nothing Then
            oReleve.PressionManoPourCalculDefaut = bValue
            'Affichage de l'onglet de la pression par défaut
            If bValue Then
                tab_833.SelectedTab = tab_833.TabPages(nPression - 1)
                tab833_changeTab() ' on ne sait pas pourquoi, mais l'evt Selectindex ne se déclence automatiquement
                AfficheDefautEcartGeneral()
                AfficheDefautHeterogeneiteGeneral()
            End If
        End If
        checkIsOk(7)

    End Sub
    Private Sub rbPression4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPression4.CheckedChanged
        'CSDebug.dispInfo("rbPression4_CheckedChanged")
        setRelevePressionparDeFaut(4, rbPression4.Checked)

    End Sub

    Private Sub RadioButton_diagnostic_2319_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        checkAnswer2(sender, 1)

    End Sub

    Private Sub RadioButton_diagnostic_2329_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 1)
    End Sub

    Private Sub RadioButton_diagnostic_8161_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8161.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8162_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8162.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_816_OK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_8160.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)
    End Sub

    Private Sub RadioButton_diagnostic_5621_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5621.CheckedChanged
        Try

            isCodeSpecial = False
            'If Not RadioButton_diagnostic_5621.ThreeState Then
            checkAnswer2(sender, 5)
            'End If
            'On met à jour le 5623 (OK) ssi les 5621 et 5622 ont été initialisés par l'utilisateur 
            'Le cas contraire n'est pas vrai
            If RadioButton_diagnostic_5621.Checked Then
                RadioButton_diagnostic_5620.Checked = False
            End If
            'If RadioButton_diagnostic_5621.CheckState <> CheckState.Indeterminate And RadioButton_diagnostic_5622.CheckState <> CheckState.Indeterminate Then
            'RadioButton_diagnostic_5623.Checked = Not (RadioButton_diagnostic_5621.Checked Or RadioButton_diagnostic_5622.Checked)
            'End If
            'Une fois que le check a éré activé , il n'est plus en 3 états 
            'If RadioButton_diagnostic_5621.CheckState <> CheckState.Indeterminate Then
            '    RadioButton_diagnostic_5621.ThreeState = False
            'End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::RadioButton_diagnostic_5621_CheckedChanged ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub RadioButton_diagnostic_5622_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5622.CheckedChanged
        Try

            isCodeSpecial = False
            checkAnswer2(sender, 5)
            ''On met à jour le 5623 (OK) ssi les 5621 et 5622 ont été initialisés par l'utilisateur
            'If RadioButton_diagnostic_5621.CheckState <> CheckState.Indeterminate And RadioButton_diagnostic_5622.CheckState <> CheckState.Indeterminate Then
            ' RadioButton_diagnostic_5623.Checked = Not (RadioButton_diagnostic_5621.Checked Or RadioButton_diagnostic_5622.Checked)
            'End If
            If RadioButton_diagnostic_5622.Checked Then
                RadioButton_diagnostic_5620.Checked = False
            End If
            'If RadioButton_diagnostic_5622.CheckState <> CheckState.Indeterminate Then
            '    RadioButton_diagnostic_5622.ThreeState = False
            'End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::RadioButton_diagnostic_5622_CheckedChanged ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub RadioButton_diagnostic_562_OK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_5620.CheckedChanged
        Try

            isCodeSpecial = False
            checkAnswer2(sender, 5)
            If RadioButton_diagnostic_5620.Checked Then
                RadioButton_diagnostic_5621.Checked = False
                RadioButton_diagnostic_5622.Checked = False
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::RadioButton_diagnostic_562_OK_CheckedChanged ERR : " & ex.Message)
        End Try
    End Sub


    Private Sub ico_help_5622_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ico_help_5622.Click
        Try

            If diagBuses_debitMoyen.Text <> "" And tbPressionMesure.Text <> "" Then
                Dim oDlg552 As New Diagnostic_dlghelp552()
                oDlg552.setContexte(Diagnostic_dlghelp552.Help552Mode.Mode5622, m_diagnostic, tbDebitMoyen3bars.Text, tbPressionMesure.Text, (GlobalsCRODIP.DiagMode.CTRL_VISU = m_modeAffichage))
                oDlg552.ShowDialog(Me)
                If oDlg552.DialogResult = Windows.Forms.DialogResult.OK Then
                    m_diagnostic.syntheseErreurDebitmetre = m_diagnostic.diagnosticHelp5622.ErreurDebitMetre
                    If m_diagnostic.diagnosticHelp5622.Resultat.ToUpper = "IMPRECISION" Then
                        RadioButton_diagnostic_5622.Checked = True
                        RadioButton_diagnostic_5620.Checked = False
                    Else
                        RadioButton_diagnostic_5622.Checked = False

                    End If
                End If
            Else
                MsgBox("Vous devez d'abord compléter le tableau 9.2.2 de l'onglet ""Buses"" !")
            End If
        Catch ex As Exception
            CSDebug.dispError("diagnostique::ico_help_5622_Click ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub ToolTip_diagnostic_numRadioButtons_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip_diagnostic_numRadioButtons.Popup

    End Sub


    'Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
    '    'Dim formDebug As New diag_debug(arrAnswers)
    '    'formDebug.ToutCocherenVert()

    '    Dim lst As New List(Of CRODIP_ControlLibrary.CtrlDiag2)
    '    Dim lstParam As New CRODIP_ControlLibrary.LstParamCtrlDiag()

    '    lst.Add(RadioButton_diagnostic_2111)
    '    lst.Add(RadioButton_diagnostic_2112)
    '    lst.Add(RadioButton_diagnostic_2113)
    '    lst.Add(RadioButton_diagnostic_2121)
    '    lst.Add(RadioButton_diagnostic_2122)
    '    lst.Add(RadioButton_diagnostic_2123)
    '    lst.Add(RadioButton_diagnostic_2131)
    '    lst.Add(RadioButton_diagnostic_2132)
    '    lst.Add(RadioButton_diagnostic_2133)

    '    lst.Add(RadioButton_diagnostic_2211)
    '    lst.Add(RadioButton_diagnostic_2212)
    '    lst.Add(RadioButton_diagnostic_2213)
    '    lst.Add(RadioButton_diagnostic_2214)
    '    lst.Add(RadioButton_diagnostic_2221)
    '    lst.Add(RadioButton_diagnostic_2222)
    '    lst.Add(RadioButton_diagnostic_2223)
    '    lst.Add(RadioButton_diagnostic_2231)
    '    lst.Add(RadioButton_diagnostic_2232)
    '    lst.Add(RadioButton_diagnostic_2233)
    '    lst.Add(RadioButton_diagnostic_2241)
    '    lst.Add(RadioButton_diagnostic_2242)
    '    lst.Add(RadioButton_diagnostic_2243)
    '    lst.Add(RadioButton_diagnostic_2251)
    '    lst.Add(RadioButton_diagnostic_2252)
    '    lst.Add(RadioButton_diagnostic_2253)

    '    lst.Add(RadioButton_diagnostic_2310)
    '    lst.Add(RadioButton_diagnostic_2311)
    '    lst.Add(RadioButton_diagnostic_2312)
    '    lst.Add(RadioButton_diagnostic_2313)
    '    lst.Add(RadioButton_diagnostic_2314)
    '    lst.Add(RadioButton_diagnostic_2315)
    '    lst.Add(RadioButton_diagnostic_2316)
    '    lst.Add(RadioButton_diagnostic_2317)
    '    lst.Add(RadioButton_diagnostic_2318)
    '    lst.Add(RadioButton_diagnostic_2319)
    '    '        lst.Add(RadioButton_diagnostic_2320)
    '    lst.Add(RadioButton_diagnostic_2321)
    '    lst.Add(RadioButton_diagnostic_2322)
    '    lst.Add(RadioButton_diagnostic_2323)
    '    lst.Add(RadioButton_diagnostic_2324)
    '    lst.Add(RadioButton_diagnostic_2325)
    '    lst.Add(RadioButton_diagnostic_2326)
    '    lst.Add(RadioButton_diagnostic_2327)
    '    lst.Add(RadioButton_diagnostic_2328)
    '    lst.Add(RadioButton_diagnostic_2329)

    '    lst.Add(RadioButton_diagnostic_2411)
    '    lst.Add(RadioButton_diagnostic_2412)
    '    lst.Add(RadioButton_diagnostic_2413)
    '    lst.Add(RadioButton_diagnostic_2414)
    '    lst.Add(RadioButton_diagnostic_2415)

    '    lst.Add(RadioButton_diagnostic_2511)
    '    lst.Add(RadioButton_diagnostic_2512)
    '    lst.Add(RadioButton_diagnostic_2513)
    '    lst.Add(RadioButton_diagnostic_2521)
    '    lst.add(RadioButton_diagnostic_2522)
    '    lst.Add(RadioButton_diagnostic_2523)

    '    lst.Add(RadioButton_diagnostic_3111)
    '    lst.Add(RadioButton_diagnostic_3112)
    '    lst.Add(RadioButton_diagnostic_3113)
    '    lst.Add(RadioButton_diagnostic_3211)
    '    lst.Add(RadioButton_diagnostic_3212)
    '    lst.Add(RadioButton_diagnostic_3213)
    '    lst.Add(RadioButton_diagnostic_3221)
    '    lst.Add(RadioButton_diagnostic_3222)
    '    lst.Add(RadioButton_diagnostic_3223)
    '    lst.Add(RadioButton_diagnostic_3224)
    '    lst.Add(RadioButton_diagnostic_3231)
    '    lst.Add(RadioButton_diagnostic_3232)

    '    lst.Add(RadioButton_diagnostic_4111)
    '    lst.Add(RadioButton_diagnostic_4112)
    '    lst.Add(RadioButton_diagnostic_4113)
    '    lst.Add(RadioButton_diagnostic_4114)
    '    lst.Add(RadioButton_diagnostic_4115)
    '    lst.Add(RadioButton_diagnostic_4121)
    '    lst.Add(RadioButton_diagnostic_4122)
    '    lst.Add(RadioButton_diagnostic_4123)

    '    lst.Add(RadioButton_diagnostic_4211)
    '    lst.Add(RadioButton_diagnostic_4212)
    '    lst.Add(RadioButton_diagnostic_4213)
    '    lst.Add(RadioButton_diagnostic_4214)
    '    lst.Add(RadioButton_diagnostic_4311)
    '    lst.Add(RadioButton_diagnostic_4312)
    '    lst.Add(RadioButton_diagnostic_4313)

    '    lst.Add(RadioButton_diagnostic_5111)
    '    lst.Add(RadioButton_diagnostic_5112)
    '    lst.Add(RadioButton_diagnostic_5113)
    '    lst.Add(RadioButton_diagnostic_5211)
    '    lst.Add(RadioButton_diagnostic_5212)
    '    lst.Add(RadioButton_diagnostic_5213)
    '    lst.Add(RadioButton_diagnostic_5221)
    '    lst.Add(RadioButton_diagnostic_5222)
    '    lst.Add(RadioButton_diagnostic_5223)
    '    lst.Add(RadioButton_diagnostic_5224)
    '    lst.Add(RadioButton_diagnostic_5311)
    '    lst.Add(RadioButton_diagnostic_5312)
    '    lst.Add(RadioButton_diagnostic_5313)
    '    lst.Add(RadioButton_diagnostic_5321)
    '    lst.Add(RadioButton_diagnostic_5322)
    '    lst.Add(RadioButton_diagnostic_5323)
    '    lst.Add(RadioButton_diagnostic_5411)
    '    lst.Add(RadioButton_diagnostic_5412)
    '    lst.Add(RadioButton_diagnostic_5413)
    '    lst.Add(RadioButton_diagnostic_5414)
    '    lst.Add(RadioButton_diagnostic_5415)
    '    lst.Add(RadioButton_diagnostic_5421)
    '    lst.Add(RadioButton_diagnostic_5422)
    '    lst.Add(RadioButton_diagnostic_5423)
    '    lst.Add(RadioButton_diagnostic_5424)

    '    lst.Add(RadioButton_diagnostic_5511)
    '    lst.Add(RadioButton_diagnostic_5512)
    '    lst.Add(RadioButton_diagnostic_5513)

    '    lst.Add(RadioButton_diagnostic_5521)
    '    lst.Add(RadioButton_diagnostic_5522)
    '    lst.Add(RadioButton_diagnostic_5523)
    '    lst.Add(RadioButton_diagnostic_5611)
    '    lst.Add(RadioButton_diagnostic_5612)
    '    lst.Add(RadioButton_diagnostic_5613)
    '    lst.Add(RadioButton_diagnostic_5621)
    '    lst.Add(RadioButton_diagnostic_5622)
    '    lst.Add(RadioButton_diagnostic_5623)


    '    lst.Add(RadioButton_diagnostic_6111)
    '    lst.Add(RadioButton_diagnostic_6112)
    '    lst.Add(RadioButton_diagnostic_6113)
    '    lst.Add(RadioButton_diagnostic_6114)

    '    lst.Add(RadioButton_diagnostic_7111)
    '    lst.Add(RadioButton_diagnostic_7112)
    '    lst.Add(RadioButton_diagnostic_7113)
    '    lst.Add(RadioButton_diagnostic_7114)
    '    lst.Add(RadioButton_diagnostic_7115)
    '    lst.Add(RadioButton_diagnostic_7116)
    '    lst.Add(RadioButton_diagnostic_7211)
    '    lst.Add(RadioButton_diagnostic_7212)
    '    lst.Add(RadioButton_diagnostic_7213)
    '    lst.Add(RadioButton_diagnostic_7214)
    '    lst.Add(RadioButton_diagnostic_7215)
    '    lst.Add(RadioButton_diagnostic_7216)
    '    lst.Add(RadioButton_diagnostic_7311)
    '    lst.Add(RadioButton_diagnostic_7312)
    '    lst.Add(RadioButton_diagnostic_7313)
    '    lst.Add(RadioButton_diagnostic_7314)
    '    lst.Add(RadioButton_diagnostic_7315)

    '    lst.Add(RadioButton_diagnostic_7411)
    '    lst.Add(RadioButton_diagnostic_7412)
    '    lst.add(RadioButton_diagnostic_7413)
    '    lst.Add(RadioButton_diagnostic_7414)
    '    lst.Add(RadioButton_diagnostic_7415)
    '    lst.Add(RadioButton_diagnostic_7416)

    '    lst.Add(RadioButton_diagnostic_8111)
    '    lst.Add(RadioButton_diagnostic_8112)
    '    lst.Add(RadioButton_diagnostic_8113)
    '    lst.Add(RadioButton_diagnostic_8114)
    '    lst.Add(RadioButton_diagnostic_8115)
    '    lst.Add(RadioButton_diagnostic_8121)
    '    lst.Add(RadioButton_diagnostic_8122)
    '    lst.Add(RadioButton_diagnostic_8123)
    '    lst.Add(RadioButton_diagnostic_8131)
    '    lst.Add(RadioButton_diagnostic_8132)
    '    lst.Add(RadioButton_diagnostic_8133)
    '    lst.Add(RadioButton_diagnostic_8141)
    '    lst.Add(RadioButton_diagnostic_8142)
    '    lst.Add(RadioButton_diagnostic_8143)
    '    lst.Add(RadioButton_diagnostic_8151)
    '    lst.Add(RadioButton_diagnostic_8152)
    '    lst.Add(RadioButton_diagnostic_8153)
    '    lst.Add(RadioButton_diagnostic_8161)
    '    lst.Add(RadioButton_diagnostic_8162)
    '    lst.Add(RadioButton_diagnostic_8163)
    '    lst.Add(RadioButton_diagnostic_8211)
    '    lst.Add(RadioButton_diagnostic_8212)
    '    lst.Add(RadioButton_diagnostic_8221)
    '    lst.Add(RadioButton_diagnostic_8222)
    '    lst.Add(RadioButton_diagnostic_8223)
    '    lst.Add(RadioButton_diagnostic_8231)
    '    lst.Add(RadioButton_diagnostic_8232)
    '    lst.Add(RadioButton_diagnostic_8233)
    '    lst.Add(RadioButton_diagnostic_8234)
    '    lst.Add(RadioButton_diagnostic_8235)

    '    lst.Add(RadioButton_diagnostic_8311)
    '    lst.Add(RadioButton_diagnostic_8312)
    '    lst.Add(RadioButton_diagnostic_8313)
    '    lst.Add(RadioButton_diagnostic_8314)
    '    lst.Add(RadioButton_diagnostic_8321)
    '    lst.Add(RadioButton_diagnostic_8322)
    '    lst.Add(RadioButton_diagnostic_8323)
    '    lst.Add(RadioButton_diagnostic_8324)

    '    lst.Add(RadioButton_diagnostic_8331)
    '    lst.Add(RadioButton_diagnostic_8332)
    '    lst.Add(RadioButton_diagnostic_8333)
    '    lst.Add(RadioButton_diagnostic_8334)


    '    lst.Add(RadioButton_diagnostic_9111)
    '    lst.Add(RadioButton_diagnostic_9112)
    '    lst.Add(RadioButton_diagnostic_9113)
    '    lst.Add(RadioButton_diagnostic_9114)
    '    lst.Add(RadioButton_diagnostic_9115)
    '    lst.Add(RadioButton_diagnostic_9116)
    '    lst.Add(RadioButton_diagnostic_9121)
    '    lst.Add(RadioButton_diagnostic_9122)
    '    lst.Add(RadioButton_diagnostic_9123)

    '    lst.Add(RadioButton_diagnostic_9211)
    '    lst.Add(RadioButton_diagnostic_9212)
    '    lst.Add(RadioButton_diagnostic_9213)
    '    lst.Add(RadioButton_diagnostic_9221)
    '    lst.Add(RadioButton_diagnostic_9222)
    '    lst.Add(RadioButton_diagnostic_9223)

    '    lst.Add(RadioButton_diagnostic_10111)
    '    lst.Add(RadioButton_diagnostic_10112)
    '    lst.Add(RadioButton_diagnostic_10113)
    '    lst.Add(RadioButton_diagnostic_10114)
    '    lst.Add(RadioButton_diagnostic_10115)
    '    lst.Add(RadioButton_diagnostic_10116)
    '    lst.Add(RadioButton_diagnostic_10117)
    '    lst.Add(RadioButton_diagnostic_10118)
    '    lst.Add(RadioButton_diagnostic_10121)
    '    lst.Add(RadioButton_diagnostic_10122)
    '    lst.Add(RadioButton_diagnostic_10123)

    '    lst.Add(RadioButton_diagnostic_10211)
    '    lst.Add(RadioButton_diagnostic_10212)
    '    lst.Add(RadioButton_diagnostic_10213)
    '    lst.Add(RadioButton_diagnostic_10214)
    '    lst.Add(RadioButton_diagnostic_10221)
    '    lst.Add(RadioButton_diagnostic_10222)
    '    lst.Add(RadioButton_diagnostic_10223)
    '    lst.Add(RadioButton_diagnostic_10224)


    '    Dim oParam As CRODIP_ControlLibrary.ParamCtrlDiag
    '    For Each octrl As CRODIP_ControlLibrary.CtrlDiag2 In lst

    '        oParam = New CRODIP_ControlLibrary.ParamCtrlDiag
    '        oParam.Code = octrl.Name.Replace("RadioButton_diagnostic_", "")
    '        If octrl.Libelle.IndexOf(" ") < 1 Then
    '            oParam.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
    '            oParam.Libelle = octrl.Libelle
    '        Else
    '            oParam.Code = octrl.Libelle.Substring(0, octrl.Libelle.IndexOf(" "))
    '            oParam.Libelle = octrl.Libelle.Substring(octrl.Libelle.IndexOf(" ")).Replace(" - ", "")
    '            oParam.DefaultCategorie = octrl.Categorie
    '        End If
    '        oParam.NiveauCauseMax = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
    '        lstParam.ListeParam.Add(oParam)
    '    Next

    '    lstParam.writeXml("./Paramdiag.xml")
    '    'Dim objStreamWriter As New StreamWriter(".\ParamDiag.xml")
    '    'Dim x As New XmlSerializer(olst.GetType)
    '    'x.Serialize(objStreamWriter, olst)
    '    'objStreamWriter.Close()


    'End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

        ToutCocherEnVert()

    End Sub

    Private Sub ToutCocherEnVert()

        Try
            For Each onglet As List(Of List(Of CRODIP_ControlLibrary.CtrlDiag2)) In LstCtrl
                For Each Groupe As List(Of CRODIP_ControlLibrary.CtrlDiag2) In onglet
                    For Each ctrl As CRODIP_ControlLibrary.CtrlDiag2 In Groupe
                        If ctrl.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK Then
                            ctrl.Checked = True
                        End If
                    Next

                Next

            Next
            '====================
            'Onglet Mano
            '====================
            manopulveIsUseCalibrateur.Checked = True
            manopulvePressionControle_1.Text = manopulvePressionPulve_1.Text
            manopulvePressionControle_2.Text = manopulvePressionPulve_2.Text
            manopulvePressionControle_3.Text = manopulvePressionPulve_3.Text
            manopulvePressionControle_4.Text = manopulvePressionPulve_4.Text

            Dim nPression As Decimal
            Dim nNiveau As Integer
            Dim nTroncon As Integer

            nPression = CDec(m_tbPressionManoCurrent.Text)
            For nCol As Integer = 1 To m_dgvPressionCurrent.Columns.Count - 1
                nNiveau = m_dgvPressionCurrent(nCol, ROW_NIVEAUX).Value
                nTroncon = m_dgvPressionCurrent(nCol, ROW_TRONCONS).Value

                m_RelevePression833_Current.SetPressionLue(nNiveau, nTroncon, nPression)
                m_dgvPressionCurrent(nCol, ROW_PRESSION).Value = nPression
                AfficheResultat833(nCol)
            Next
            checkIsOk(7)

            '===========================
            'Onglet Buses
            '===========================
            buses_listBancs.SelectedIndex = 0
            Dim nbNiveau As Integer = CInt(diagBuses_conf_nbCategories.Text)

            For nbLot As Integer = 1 To nbNiveau
                'Initialisation de la catégorie n
                'Nombre de buses
                Dim otb As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("TextBox_nbBuses_" & nbLot, Me)
                Dim nbBuses As Integer = CInt(otb.Text)

                For nBuse As Integer = 1 To nbBuses
                    Dim otb2 As CRODIP_ControlLibrary.TBNumeric = CSForm.getControlByName("diagBuses_mesureDebit_" & nbLot & "_" & nBuse & "_debit", Me)
                    otb2.Text = "1.0"
                    '                mutCalcUsure1Buse(nbLot, nBuse)
                Next nBuse
            Next nbLot
            mutCalcTotal()
        Catch ex As Exception
            CSDebug.dispError("ToutCocherEnVert ERR" & ex.Message)
        End Try

    End Sub
    '''
    ''' Lecture des paramètres d'affichage dans ParamDiag.xml
    '''
    Private Function LectureParametresAffichage(ByVal pFichierParametrage As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCtrl1 As Control
            Dim olst As New CRODIP_ControlLibrary.LstParamCtrlDiag()
            If olst.readXML(pFichierParametrage) Then
                'Parours de la liste des params lus
                For Each oParam As CRODIP_ControlLibrary.ParamCtrlDiag In olst.ListeParam
                    Dim strCode As String = oParam.Code
                    If Not strCode.StartsWith("1.") Then
                        'Exclusion des paramètes 'Préliminaires"
                        strCode = strCode.Replace(".", "") 'Remplace les codes par rien
                        If oParam.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_GROUPE Then
                            'C'est un Label ou un Group
                            oCtrl1 = CSForm.getControlByName("Label_diagnostic_" & strCode, Me)
                            If oCtrl1 IsNot Nothing Then
                                Dim oLbl As Label = TryCast(oCtrl1, Label)
                                If oLbl IsNot Nothing Then
                                    If oLbl.Image Is Nothing Then
                                        oLbl.Text = oParam.Code & " " & oParam.Libelle
                                    Else
                                        oLbl.Text = "     " & oParam.Code & " " & oParam.Libelle 'Décalage à cause de l'image !!!!
                                    End If
                                End If
                            Else
                                'Si ce n'est pas Label c'est peut-être un groupe
                                oCtrl1 = CSForm.getControlByName("GroupBox_diagnostic_" & strCode, Me)
                                If oCtrl1 IsNot Nothing Then
                                    Dim ogrp As GroupBox = TryCast(oCtrl1, GroupBox)
                                    If ogrp IsNot Nothing Then
                                        ogrp.Text = oParam.Code & " " & oParam.Libelle
                                        If Not oParam.Actif Then
                                            ogrp.Enabled = False
                                        End If
                                    End If
                                End If

                            End If

                        Else
                            oCtrl1 = CSForm.getControlByName("RadioButton_diagnostic_" & strCode, Me)
                            If oCtrl1 IsNot Nothing Then
                                If TypeOf oCtrl1 Is CRODIP_ControlLibrary.CtrlDiag2 Then
                                    oParam.Affecte(oCtrl1)
                                End If
                            End If
                        End If
                    End If

                Next
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.LectureParametresAffichage ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Private Sub Pctb_calc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pctb_calc.Click
        Dim ocalc As tool_Calculettelha
        ocalc = New tool_Calculettelha()
        ocalc.Show(Me)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim ocalc As tool_Calculettelha
        ocalc = New tool_Calculettelha()
        ocalc.Show(Me)

    End Sub


    Private Sub tab_833_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab_833.SelectedIndexChanged

        tab833_changeTab()

    End Sub
    ''' <summary>
    ''' changement de tabPage dans le Tableau 833 => Affichage de la puce pour différencier l'onglet Actif
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tab833_changeTab()
        Try

            SetCurrentPressionControls()
            'on suprimme la puce sur tous les onglets
            For Each oTab As TabPage In tab_833.TabPages
                oTab.ImageIndex = -1
            Next
            ' Placer la puce sur onglet courant
            tab_833.SelectedTab.ImageIndex = 0
            m_dgvPressionCurrent.Focus()

        Catch ex As Exception
            CSDebug.dispError("diagnostique::tab_833_TabIndexChanged ERR : " & ex.Message)
        End Try

    End Sub

    Private Sub RadioButton_diagnostic_4321_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4322_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4320_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4630_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4411_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4412_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4410_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4511_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4512_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4513_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4510_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4421_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4420_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4521_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4522_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4520_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4611_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4612_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4613_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4610_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4621_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4622_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4620_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4631_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4632_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4641_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4642_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4640_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4313_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4312_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub
    Private Sub RadioButton_diagnostic_4313_CheckedChanged_1(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4314_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4111_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4112_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4113_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4114_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4115_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4121_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4122_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4123_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4211_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4212_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4213_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4214_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_4311_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 2)

    End Sub

    Private Sub RadioButton_diagnostic_5711_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_5711.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)

    End Sub

    Private Sub RadioButton_diagnostic_5712_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_5712.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)

    End Sub

    Private Sub RadioButton_diagnostic_5710_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_5710.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 5)

    End Sub

    Private Sub RadioButton_diagnostic_8171_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8171.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8172_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8172.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub
    Private Sub RadioButton_diagnostic_8170_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8170.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8173_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8314_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8314.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_8334_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_8334.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 6)

    End Sub

    Private Sub RadioButton_diagnostic_11111_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11112_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11113_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11114_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11115_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11110_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11121_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11122_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11123_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11120_CheckedChanged(sender As Object, e As EventArgs)
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11211_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11111.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11212_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11112.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11213_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11113.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11210_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11110.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11221_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11121.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11222_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11122.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11223_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11123.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11220_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11120.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11231_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11131.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11232_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11132.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11233_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11133.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11230_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11130.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11241_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11141.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11242_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11142.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_11240_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_11140.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12111_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12111.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12112_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12112.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12113_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12113.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12110_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12110.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12121_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12121.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12122_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12122.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12123_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12123.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12120_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12120.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12131_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12131.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12132_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12132.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12130_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12130.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12211_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12211.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12212_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12212.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12213_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12213.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12210_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12210.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12221_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12221.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12311_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12311.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12313_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12313.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12312_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12312.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12314_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12314.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12315_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12315.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12316_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12316.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12317_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12317.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12318_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12318.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12310_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12310.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12321_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12321.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12322_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12322.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12323_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12323.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12324_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12324.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12320_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12320.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12220_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12220.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12411_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12411.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12412_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12412.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub RadioButton_diagnostic_12410_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton_diagnostic_12410.CheckedChanged
        isCodeSpecial = False
        checkAnswer2(sender, 9)

    End Sub

    Private Sub diagnostique_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

    End Sub

    Private Sub diagBuses_debitMoyen_TextChanged(sender As Object, e As EventArgs) Handles diagBuses_debitMoyen.TextChanged

        Dim debitBuses As Decimal
        Dim pressionMesureBuses As Decimal
        debitBuses = diagBuses_debitMoyen.DecimalValue
        pressionMesureBuses = tbPressionMesure.DecimalValue

        tbDebitMoyen3bars.Text = m_diagnostic.calDebitMoyen(debitBuses, pressionMesureBuses, 3)

    End Sub

    Private Sub frmDiagnostique_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            If m_diagnostic IsNot Nothing Then
                m_bDuringLoad = True
                Formload()
                m_bDuringLoad = False
                checkAllIsOk()
            End If
        End If

    End Sub

    Private Sub btn_Poursuivre_Click(sender As Object, e As EventArgs) Handles btn_Poursuivre.Click
        tab_diagnostique.SelectedIndex = tab_diagnostique.SelectedIndex() + 1
    End Sub

    Private Sub btn_Valider_Click(sender As Object, e As EventArgs) Handles btn_Valider.Click
        Valider()

    End Sub

    Private Sub btn_annuler_Click(sender As Object, e As EventArgs) Handles btn_annuler.Click
        Annuler()
    End Sub

    Private Sub ico_help_571_Click(sender As Object, e As EventArgs) Handles ico_help_571.Click
        Calc571()
    End Sub

    Private Sub Calc571()
        Dim ofrm As New diagnostic_dlghelp571()
        If String.IsNullOrEmpty(tbDebitMoyen3bars.Text) Or
            String.IsNullOrEmpty(diagBuses_debitMoyen.Text) Or
            String.IsNullOrEmpty(tbPressionMesure.Text) Then

            MsgBox("Il faut renseigner le tableau des buses et le calcul 551")

            Exit Sub
        End If
        ini571()
        ofrm.setContexte(diagnostic_dlghelp571.Calc571Mode.ModePRS, m_diagnostic.diagnosticHelp571, GlobalsCRODIP.DiagMode.CTRL_VISU = m_modeAffichage)
        If (ofrm.ShowDialog() = DialogResult.OK) Then
            m_diagnostic.diagnosticHelp571 = ofrm.getContexte()
            Select Case m_diagnostic.diagnosticHelp571.getResult()
                Case DiagnosticItem.EtatDiagItemOK
                    RadioButton_diagnostic_5710.Checked = True
                    RadioButton_diagnostic_5712.Checked = False
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMINEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5712.Checked = True
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5712.Checked = False
                    RadioButton_diagnostic_5712.Checked = True
            End Select
        End If

    End Sub
    Private Sub voir571()
        Dim ofrm As New diagnostic_dlghelp571()
        If String.IsNullOrEmpty(tbDebitMoyen3bars.Text) Or
            String.IsNullOrEmpty(diagBuses_debitMoyen.Text) Or
            String.IsNullOrEmpty(tbPressionMesure.Text) Or
            String.IsNullOrEmpty(m_diagnostic.syntheseErreurMoyenneCinemometre) Then

            MsgBox("Il faut renseigner le tableau des buses et le calcul 551")

            Exit Sub
        End If
        ini571()
        ofrm.setContexte(diagnostic_dlghelp571.Calc571Mode.ModeDEB,
                         m_diagnostic.diagnosticHelp571, GlobalsCRODIP.DiagMode.CTRL_VISU = m_modeAffichage)

        If (ofrm.ShowDialog() = DialogResult.OK) Then
            m_diagnostic.diagnosticHelp571 = ofrm.getContexte()
            Select Case m_diagnostic.diagnosticHelp571.getResult()
                Case DiagnosticItem.EtatDiagItemOK
                    RadioButton_diagnostic_5710.Checked = True
                    RadioButton_diagnostic_5711.Checked = False
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMINEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5711.Checked = True
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5711.Checked = False
                    RadioButton_diagnostic_5712.Checked = True
            End Select

        End If

    End Sub
    Private Sub ini571()
        If Not String.IsNullOrEmpty(tbDebitMoyen3bars.Text) Then
            m_diagnostic.diagnosticHelp571.DebitMesurePRS = tbDebitMoyen3bars.Text
        End If
        '        m_diagnosticCourant.diagnosticHelp571.DebitMesureVTS = diagBuses_debitMoyen.Text
        If Not String.IsNullOrEmpty(tbPressionMesure.Text) Then
            m_diagnostic.diagnosticHelp571.PressionMesurePRS = tbPressionMesure.Text
        End If
        If Not String.IsNullOrEmpty(m_diagnostic.syntheseErreurMoyenneCinemometre) Then

            m_diagnostic.diagnosticHelp571.ErreurVitessePRS = m_diagnostic.syntheseErreurMoyenneCinemometre
        End If
        If Not String.IsNullOrEmpty(m_diagnostic.syntheseErreurMoyenneCinemometre) Then
            m_diagnostic.diagnosticHelp571.erreurVitesseDEB = m_diagnostic.diagnosticHelp551.ErreurMoyenneSigned
        End If
        If m_diagnostic.diagnosticHelp552.ErreurDebitMetreSigned.HasValue Then
            m_diagnostic.diagnosticHelp571.erreurDebitDEB = m_diagnostic.diagnosticHelp552.ErreurDebitMetreSigned
        End If
        'Calcul Automatique du défaut 571 si on a la erreurVitesse et erreurDébit 
        If m_diagnostic.diagnosticHelp571.erreurDebitDEB.HasValue And m_diagnostic.diagnosticHelp571.erreurVitesseDEB.HasValue Then
            m_diagnostic.diagnosticHelp571.calcule()
            Select Case m_diagnostic.diagnosticHelp571.getResult()
                Case DiagnosticItem.EtatDiagItemOK
                    RadioButton_diagnostic_5710.Checked = True
                    RadioButton_diagnostic_5711.Checked = False
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMINEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5711.Checked = True
                    RadioButton_diagnostic_5712.Checked = False
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    RadioButton_diagnostic_5710.Checked = False
                    RadioButton_diagnostic_5711.Checked = False
                    RadioButton_diagnostic_5712.Checked = True
            End Select

        End If
        If Not String.IsNullOrEmpty(m_diagnostic.pulverisateurRegulation) Then
            m_diagnostic.diagnosticHelp571.Regulation = m_diagnostic.pulverisateurRegulation
            m_diagnostic.diagnosticHelp571.IsDPAE = m_Pulverisateur.pulverisateurRegulationIsDPAE
            m_diagnostic.diagnosticHelp571.IsDPAEDebit = m_Pulverisateur.pulverisateurRegulationIsDPAEDebit
            m_diagnostic.diagnosticHelp571.IsDPAEPression = m_Pulverisateur.pulverisateurRegulationIsDPAEPression
        End If

    End Sub
    Private Sub ico_oeil571_Click(sender As Object, e As EventArgs) Handles ico_oeil571.Click
        voir571()
    End Sub

    Private Sub ico_help_12123_Click(sender As Object, e As EventArgs) Handles ico_help_12123.Click
        calc12123()
    End Sub

    Private Function calc12123() As Boolean
        Dim bReturn As Boolean
        Try
            Dim ofrm As New diagnostic_dlghelp12123new()
            If String.IsNullOrEmpty(tbDebitMoyen3bars.Text) Or
                String.IsNullOrEmpty(diagBuses_debitMoyen.Text) Or
                String.IsNullOrEmpty(tbPressionMesure.Text) Then

                MsgBox("Il faut renseigner le tableau des buses 922")

                Exit Function
            End If
            If m_modeAffichage <> GlobalsCRODIP.DiagMode.CTRL_VISU Then
                ini12123()
            End If
            ofrm.setContexte(m_diagnostic.diagnosticHelp12123, m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU)
            If (ofrm.ShowDialog() = DialogResult.OK) Then
                If m_modeAffichage <> GlobalsCRODIP.DiagMode.CTRL_VISU Then
                    'Récupération des valeurs si on est en mode saie de controle
                    m_diagnostic.diagnosticHelp12123 = ofrm.getContexte()
                    Select Case m_diagnostic.diagnosticHelp12123.Resultat
                        Case DiagnosticItem.EtatDiagItemOK
                            RadioButton_diagnostic_12123.Checked = False
                        Case DiagnosticItem.EtatDiagItemMINEUR
                            RadioButton_diagnostic_12123.Checked = False
                        Case DiagnosticItem.EtatDiagItemMAJEUR
                            RadioButton_diagnostic_12123.Checked = True
                    End Select
                End If
            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmDiagnostique.calc12123 ERr" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub ini12123()
        Dim nBuses As Integer = 0
        For Each oBusList As DiagnosticBuses In m_DiagBuses.Liste
            nBuses = nBuses + oBusList.diagnosticBusesDetailList.Liste.Count
        Next
        For Each oPompe As DiagnosticHelp12123Pompe In m_diagnostic.diagnosticHelp12123.lstPompes
            oPompe.NbBuses = nBuses
            oPompe.debitMesure = diagBuses_debitMoyen.Text
            oPompe.PressionMesure = tbPressionMesure.Text
        Next

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub ico_help12323_Click(sender As Object, e As EventArgs) Handles ico_help12323.Click
        Dim odlg As New diagnostic_dlghelp551()
        odlg.setContexte(DiagnosticHelp551.Help551Mode.Mode12323, m_diagnostic, "Programmation de la vitesse", m_modeAffichage = GlobalsCRODIP.DiagMode.CTRL_VISU)
        odlg.ShowDialog(Me)
        If odlg.DialogResult = Windows.Forms.DialogResult.OK Then
            If m_diagnostic.diagnosticHelp12323.Resultat = "OK" Then
                RadioButton_diagnostic_12323.Checked = False
                RadioButton_diagnostic_12320.Checked = True
            End If
            If m_diagnostic.diagnosticHelp12323.Resultat = "IMPRECISION" Then
                RadioButton_diagnostic_12323.Checked = True
                RadioButton_diagnostic_12320.Checked = False
            End If
        End If

    End Sub

    Public Overridable Sub DisableControls()
        Dim tmpDiagnosticBuses As DiagnosticBuses


        CSForm.disableAllCheckBox(Me)
        CSForm.disableAllRadioButtons(Me)
        CSForm.disableAllTextBox(Me)
        CSForm.disableAllComboBox(Me)
        Me.btn_diagnostic_acquisitionDonnees.Enabled = False
        diagBuses_conf_ajouterNiveau.Enabled = False
        diagBuses_conf_validNbCategories.Enabled = False
        Dim curLvl As Integer
        curLvl = 1
        Dim tmpBtn_nbBusesValider As Label
        For Each tmpDiagnosticBuses In m_diagnostic.diagnosticBusesList.Liste
            ' Récupération des contrôles
            tmpBtn_nbBusesValider = CSForm.getControlByName("Button_valider_nbBuses_" & curLvl, diagBuses_tab_categories)
            curLvl += 1

            tmpBtn_nbBusesValider.Enabled = False
        Next

        gdvPressions1.Enabled = False
        gdvPressions2.Enabled = False
        gdvPressions3.Enabled = False
        gdvPressions4.Enabled = False

    End Sub

End Class