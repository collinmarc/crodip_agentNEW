Public Class EtatFDiagEnquete
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_ENQUETE
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        frmDiag = GetFrmFromParent(Of diagnostic_satisfaction)(pEtatFDiag)
    End Sub

    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        oReturn = New diagnostic_satisfaction()
        Dim oAgent As Agent = AgentManager.getAgentById(oDiag.inspecteurId)
        CType(oReturn, diagnostic_satisfaction).Setcontext(oDiag, oAgent)
        Return oReturn
    End Function

    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_BACK
            Case Crodip_agent.Action.ACTION_NEXT
                Dim oStruct As Structuree = StructureManager.getStructureById(oDiag.organismePresId)
                oReturn = New EtatFDiagInfosComplementaires(Me)

        End Select
        Return oReturn
    End Function


End Class
