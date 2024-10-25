Imports CRODIPWS

Public Class EtatFDiagInfosComplementaires
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_COMPLEMENT
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)

        frmDiag = GetFrmFromParent(Of diagnostic_infosInspecteur)(pEtatFDiag)



    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form

        oReturn = New diagnostic_infosInspecteur()
        Dim oAgent As Agent = AgentManager.getAgentById(oDiag.inspecteurId)
        CType(oReturn, diagnostic_infosInspecteur).Setcontext(oDiag, oAgent)
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_BACK
            Case Crodip_agent.Action.ACTION_NEXT
                oReturn = Nothing
        End Select
        Return oReturn
    End Function

    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtComplement
    End Function

End Class
