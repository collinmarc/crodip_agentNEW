Public Class EtatFDiagContexte
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_CONTEXTE
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of diagnostic_contexte)(pEtatFDiag)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        oReturn = New diagnostic_contexte(Me.DiagMode, oDiag, oPulve, oExploit, False)
        oReturn.DialogResult = DialogResult.OK
        ShowDialog = True
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = New EtatFDiagContrat(Me)
        End Select
        Return oReturn
    End Function
    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtContexte
    End Function

End Class
