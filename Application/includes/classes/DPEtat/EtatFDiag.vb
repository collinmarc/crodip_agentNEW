Imports CRODIPWS

Public Enum EtatFenetre
    ETAT_DEPART = 0
    ETAT_EXPLOITATION = 10
    ETAT_PULVERISATEUR = 20
    ETAT_CONTEXTE = 30
    ETAT_CONTRAT = 40
    ETAT_PRELIMINAIRE = 50
    ETAT_DEFAUT = 60
    ETAT_RECAP = 70
    ETAT_FACT = 80
    ETAT_ENQUETE = 90
    ETAT_COMPLEMENT = 100
    ETAT_AUTRES = 110
End Enum
Public MustInherit Class EtatFDiag
    Private _Etat As EtatFenetre
    Public Property Etat() As EtatFenetre
        Get
            Return _Etat
        End Get
        Set(ByVal value As EtatFenetre)
            _Etat = value
        End Set
    End Property
    Private _Diag As Diagnostic
    Public Property oDiag() As Diagnostic
        Get
            Return _Diag
        End Get
        Set(ByVal value As Diagnostic)
            _Diag = value
        End Set
    End Property
    Private _exploitant As Exploitation
    Public Property oExploit() As Exploitation
        Get
            Return _exploitant
        End Get
        Set(ByVal value As Exploitation)
            _exploitant = value
        End Set
    End Property
    Private _Pulve As Pulverisateur
    Public Property oPulve() As Pulverisateur
        Get
            Return _Pulve
        End Get
        Set(ByVal value As Pulverisateur)
            _Pulve = value
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

    Public DiagMode As GlobalsCRODIP.DiagMode
    Public frmDiag As Form
    Public ShowDialog As Boolean = False

    Public MustOverride Function Action(pAction As ActionFDiag) As EtatFDiag



    Public Sub New()
        Etat = EtatFenetre.ETAT_DEPART
    End Sub
    Public Sub New(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pExploit As Exploitation, pAgent As Agent)
        oDiag = pDiag
        oExploit = pExploit
        oPulve = pPulve
        DiagMode = pDiagMode
        oAgent = pAgent
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        oDiag = pEtatFDiag.oDiag
        oExploit = pEtatFDiag.oExploit
        oPulve = pEtatFDiag.oPulve
        DiagMode = pEtatFDiag.DiagMode
        oAgent = pEtatFDiag.oAgent
    End Sub
    Protected Function GetFrmFromParent(Of T)(Optional pEtatOrigine As EtatFDiag = Nothing) As Form
        Dim oReturn As Form = Nothing
        If pEtatOrigine IsNot Nothing Then
            oReturn = rechercherfrmDiag(Of T)(pEtatOrigine)
        End If
        If oReturn Is Nothing Then
            oReturn = createFrmDiag()
        End If

        oReturn.DialogResult = DialogResult.OK
        Return oReturn
    End Function

    Protected Function rechercherfrmDiag(Of T)(pEtatOrigine As EtatFDiag) As Form
        Dim oReturn As Form = Nothing
        If pEtatOrigine.frmDiag IsNot Nothing Then
            'Recupération du Parent à partir de la fenête existante
            Dim oParent As parentContener
            If pEtatOrigine.frmDiag.MdiParent IsNot Nothing Then
                oParent = TryCast(pEtatOrigine.frmDiag.MdiParent, parentContener)
            Else
                oParent = TryCast(pEtatOrigine.frmDiag.Owner, parentContener)
            End If
            If oParent IsNot Nothing Then
                'Recherche de la fenêtre cible dans la liste des enfants du parent
                For Each oForm As Form In oParent.MdiChildren
                    If TypeOf oForm Is T Then
                        oReturn = oForm
                        Exit For
                    End If
                Next
            End If
        End If
        Return oReturn
    End Function

    Public MustOverride Function createFrmDiag() As Form
    Public MustOverride Function IsVisible() As Boolean

End Class
