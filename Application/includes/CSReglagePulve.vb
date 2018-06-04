Public Class CSReglagePulve

    Public Shared Function Execute(pDiagIad As String, pAgentId As String) As Boolean
        Dim bReturn As Boolean
        Dim Switches As String = pDiagIad & " " & pAgentId
        Dim startinfo As New System.Diagnostics.ProcessStartInfo
        Dim Proc As New System.Diagnostics.Process

        startinfo.FileName = "ReglagePulve.exe"
        startinfo.UseShellExecute = True
        startinfo.Arguments = Switches
        startinfo.WorkingDirectory = Environment.CurrentDirectory
        Proc.StartInfo = startinfo

        Try
            Proc.Start()
            bReturn = True
        Catch e As Exception
            CSDebug.dispError("CSReglagePulve.Execute ERR" & e.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
