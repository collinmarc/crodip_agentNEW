Public Class RPDiagnosticManager
    Inherits DiagnosticManager

    Public Shared Function getRPDiagnosticById(ByVal pdiagnostic_id As String) As RPDiagnostic
        ' déclarations
        Dim oRPDiag As New RPDiagnostic
        oRPDiag.id = pdiagnostic_id
        If loadDiagnostic(oRPDiag) Then
            oRPDiag.oClientCourant = ExploitationManager.getExploitationById(oRPDiag.proprietaireId)
            oRPDiag.oPulverisateurCourant = PulverisateurManager.getPulverisateurById(oRPDiag.pulverisateurId)
            'on retourne le dIAGNOSTIC ou un objet vide en cas d'erreur
            Return oRPDiag
        Else
            Return New RPDiagnostic()
        End If
    End Function

End Class
