Public Class CSFile
    Public Shared Function open(ByVal fileName As String) As Boolean
        Dim breturn As Boolean
        Try
            Dim monProcess As New Process
            monProcess.StartInfo.FileName = fileName
            monProcess.StartInfo.Verb = "Open"
            monProcess.StartInfo.CreateNoWindow = True
            monProcess.Start()
            breturn = True
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::open : " & ex.Message)
            breturn = False
        End Try
        Return breturn
    End Function

End Class
