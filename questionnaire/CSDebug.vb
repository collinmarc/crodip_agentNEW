Public Class CSDebug

#Region " Methodes de log "

    Public Shared Sub dispFatal(ByVal errorMsg As String)
        displayMsg("[Fatal] - " & errorMsg)
        MsgBox(errorMsg, MsgBoxStyle.Critical, "FATAL ERROR")
    End Sub
    Public Shared Sub dispError(ByVal errorMsg As String)
        displayMsg("[Error] - " & errorMsg)
    End Sub
    Public Shared Sub dispWarn(ByVal warnMsg As String)
        displayMsg("[Warning] - " & warnMsg)
    End Sub
    Public Shared Sub dispInfo(ByVal infoMsg As String)
        displayMsg("[Info] - " & infoMsg)
    End Sub



#End Region


#Region " Private "

    Private Shared Sub displayMsg(ByVal msg As String)

        Dim timeString As String = ""
        timeString = timeString & "[" & Date.Now.ToShortDateString & "]"
        timeString = timeString & "[" & Date.Now.ToLongTimeString & "]"
        msg = timeString & "" & msg

        Console.Write(msg & vbNewLine)

    End Sub

#End Region

End Class
