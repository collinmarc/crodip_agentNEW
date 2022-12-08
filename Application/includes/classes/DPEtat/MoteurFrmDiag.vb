Public Class MoteurFrmDiag

    Public oEtat As EtatFDiag
    Public Sub New()
        oEtat = New EtatFDiagPreliminaire()
    End Sub

    Public Sub Action(pAction As ActionFDiag)
        oEtat = oEtat.Action(pAction)
    End Sub

End Class
