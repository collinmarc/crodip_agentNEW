Public Class EtatFDiagPreliminaire
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_PRELIMINAIRE
    End Sub
    Public Sub New(pEtatFDiagOrigine As EtatFDiag)
        MyBase.New(pEtatFDiagOrigine)
        frmDiag = GetFrmFromParent(Of controle_preliminaire)(pEtatFDiagOrigine)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        oReturn = New controle_preliminaire(DiagMode, oDiag, oPulve, oExploit)
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_BACK
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = New EtatFDiagDefautsEtMesures(Me)
            Case Crodip_agent.Action.ACTION_RECAP
                oReturn = New EtatFDiagRecap(Me)
        End Select
        Return oReturn
    End Function

End Class
