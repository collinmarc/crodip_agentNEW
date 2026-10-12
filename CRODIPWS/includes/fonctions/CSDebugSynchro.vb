
Imports System.Diagnostics
Public Class CSDebugSynchro
    Private Shared ReadOnly Log As New TraceSource("CSDebugSynchro")

#Region " Methodes de log "

    Public Shared Sub dispSynchro(ByVal errorMsg As String)
        Log.TraceInformation(errorMsg)
        Log.Flush()
    End Sub

#End Region

End Class
