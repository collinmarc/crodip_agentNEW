Public Class EtatFDiagContrat
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_CONTRAT
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of diagnostic_ContratCommercial)(pEtatFDiag)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As diagnostic_ContratCommercial
        oReturn = New diagnostic_ContratCommercial()
        oReturn.setContexte(Me.oDiag, Me.oExploit, Me.oAgent)
        oReturn.DialogResult = DialogResult.OK
        ShowDialog = False
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_NEXT
                oDiag.setPulverisateur(oPulve)
                oReturn = New EtatFDiagPreliminaire(Me)
        End Select
        Return oReturn
    End Function

    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtContrat
    End Function
End Class
