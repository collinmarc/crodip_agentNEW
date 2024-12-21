Imports CRODIPWS

Public Class EtatFDiagFacture
    Inherits EtatFDiag

    Public Sub New()
        Etat = EtatFenetre.ETAT_FACT
    End Sub
    Public Sub New(pEtatFDiag As EtatFDiag)
        MyBase.New(pEtatFDiag)
        Dim oAgent As Agent = AgentManager.getAgentById(oDiag.inspecteurId)

        frmDiag = GetFrmFromParent(Of frmdiagnostic_facturationCoProp)(pEtatFDiag)

    End Sub
    Public Overrides Function createFrmDiag() As Form
        Dim oReturn As Form
        Dim oAgent As Agent = AgentManager.getAgentById(oDiag.inspecteurId)

        oReturn = New frmdiagnostic_facturationCoProp()
        CType(oReturn, frmdiagnostic_facturationCoProp).setContexte(oDiag, oAgent)
        oReturn.ControlBox = False
        oReturn.MinimizeBox = False
        oReturn.MaximizeBox = False
        Return oReturn
    End Function
    Public Overrides Function Action(pAction As ActionFDiag) As EtatFDiag
        Dim oReturn As EtatFDiag = Me
        Select Case pAction.CodeAction
            Case Crodip_agent.Action.ACTION_BACK
            Case Crodip_agent.Action.ACTION_NEXT
                Dim oStruct As [Structure] = StructureManager.getStructureById(oDiag.organismePresId)
                oReturn = New EtatFDiagEnquete(Me)

        End Select
        Return oReturn
    End Function
    Public Overrides Function IsVisible() As Boolean
        Return oDiag.bTrtFacture
    End Function


End Class
