Public Class EtatFDiagDefautsEtMesures
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_DEFAUT
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of FrmDiagnostique)(pEtatFDiag)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        oReturn = New FrmDiagnostique(DiagMode, oDiag, oPulve, oExploit)
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_END
                oReturn = Nothing
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = New EtatFDiagRecap(Me)
        End Select
        Return oReturn
    End Function

    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtDefauts
    End Function

End Class
