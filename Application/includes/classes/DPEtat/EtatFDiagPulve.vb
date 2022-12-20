Public Class EtatFDiagPulve
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_PULVERISATEUR
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of ajout_pulve2)(pEtatFDiag)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        oReturn = New ajout_pulve2()
        CType(oReturn, ajout_pulve2).setContexte(ajout_pulve2.MODE.VERIF, oAgent, oPulve, oExploit, oDiag)
        oReturn.DialogResult = DialogResult.OK
        ShowDialog = True
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = New EtatFDiagContexte(Me)
        End Select
        Return oReturn
    End Function
    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtPulverisateur
    End Function

End Class
