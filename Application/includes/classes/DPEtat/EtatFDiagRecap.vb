Imports CRODIPWS

Public Class EtatFDiagRecap
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_RECAP
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of frmdiagnostic_recap)(pEtatFDiag)
    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        Dim oAgent As Agent = AgentManager.getAgentById(oDiag.inspecteurId)
        oReturn = New frmdiagnostic_recap(DiagMode, oDiag, oPulve, oExploit, oAgent, Nothing)
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_BACKTOPRELIM
                oReturn = New EtatFDiagPreliminaire(Me)
            Case Crodip_agent.Action.ACTION_BACKTODEFAUTS
                oReturn = New EtatFDiagDefautsEtMesures(Me)
            Case Crodip_agent.Action.ACTION_NEXT
                Dim oStruct As [Structure] = StructureManager.getStructureById(oDiag.organismePresId)
                If oStruct.isFacturationActive Then
                    oReturn = New EtatFDiagFacture(Me)
                Else
                    oReturn = New EtatFDiagEnquete(Me)
                End If
            Case Crodip_agent.Action.ACTION_END
                oReturn = Nothing
        End Select
        Return oReturn
    End Function

    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtRecap

    End Function

End Class
