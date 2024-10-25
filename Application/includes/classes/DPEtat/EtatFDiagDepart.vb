Imports CRODIPWS

Public Class EtatFDiagDepart
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_DEPART
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = Nothing
    End Sub
    Public Sub New(pDiagMode As GlobalsCRODIP.DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pExploit As Exploitation, pAgent As Agent)
        MyBase.New(pDiagMode, pDiag, pPulve, pExploit, pAgent)
        frmDiag = Nothing
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Return Nothing
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = New EtatFDiagExploitation(Me)
        End Select
        Return oReturn
    End Function
    Public Overrides Function IsVisible() As Boolean
        Return False
    End Function

End Class
