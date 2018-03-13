Public Class RPDiagnosticManager
    Inherits DiagnosticManager

    Public Shared Function getRPDiagnosticById(ByVal diagnostic_id As String) As RPDiagnostic
        ' déclarations
        Dim oRPDiag As New RPDiagnostic
        If loadDiagnostic(oRPDiag) Then
            'on retourne le dIAGNOSTIC ou un objet vide en cas d'erreur
            Return oRPDiag
        Else
            Return New Diagnostic()
        End If
    End Function

End Class
