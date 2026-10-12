
Public Class CSDebug

#Region " Methodes de log "

    Public Shared Sub dispFatal(ByVal errorMsg As String)
        My.Application.Log.WriteEntry(errorMsg, TraceEventType.Critical)

        displayMsg("[Fatal] - " & errorMsg)
        ' Dim curVersion As String = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
        'CSDebug.saveLog("fatal", agentCourant.id, errorMsg, curVersion)
        'MsgBox(errorMsg, MsgBoxStyle.Critical, "FATAL ERROR")
    End Sub
    Public Shared Sub dispError(ByVal errorMsg As String)
        My.Application.Log.WriteEntry(errorMsg, TraceEventType.Error)
        'If GlobalsCRODIP.GLOB_ENV_DEBUGLVL >= 1 Then
        displayMsg("[Error] - " & errorMsg)
        '   Dim curVersion As String = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
        '  CSDebug.saveLog("Error", agentCourant.id, errorMsg, curVersion)
        'End If
    End Sub
    Public Shared Sub dispWarn(ByVal warnMsg As String)
        My.Application.Log.WriteEntry(warnMsg, TraceEventType.Information)
        'If GlobalsCRODIP.GLOB_ENV_DEBUGLVL >= 2 Then
        displayMsg("[Warning] - " & warnMsg)
        ' Dim curVersion As String = GlobalsCRODIP.GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
        'CSDebug.saveLog("Warning", agentCourant.id, warnMsg, curVersion)
        'End If
    End Sub
    Public Shared Sub dispInfo(ByVal infoMsg As String)
        My.Application.Log.WriteEntry(infoMsg)
        'If GLOB_ENV_DEBUGLVL >= 3 Then
        displayMsg("[Info] - " & infoMsg)
        ' End If
    End Sub

    Public Shared Sub dispFatal(ByVal pErrorMsg As String, ex As Exception)
        Dim errorMessage As String
        errorMessage = pErrorMsg + ex.Message
        If ex.InnerException IsNot Nothing Then
            errorMessage = errorMessage + "," + ex.InnerException.Message
        End If
        dispFatal(errorMessage)
    End Sub
    Public Shared Sub dispError(ByVal pErrorMsg As String, ex As Exception)
        Dim errorMessage As String
        errorMessage = pErrorMsg + ex.Message
        If ex.InnerException IsNot Nothing Then
            errorMessage = errorMessage + "," + ex.InnerException.Message
        End If

#If DEBUG Then
        errorMessage = errorMessage & ", " & ex.StackTrace
#End If
        dispError(errorMessage)
    End Sub
    Public Shared Sub dispWarn(ByVal warnMsg As String, ex As Exception)
        Dim errorMessage As String
        errorMessage = warnMsg + ex.Message
        If ex.InnerException IsNot Nothing Then
            errorMessage = warnMsg + "," + ex.InnerException.Message
        End If
        dispWarn(errorMessage)
    End Sub
    Public Shared Sub dispInfo(ByVal infoMsg As String, ex As Exception)
        Dim errorMessage As String
        errorMessage = infoMsg + ex.Message
        If ex.InnerException IsNot Nothing Then
            errorMessage = infoMsg + "," + ex.InnerException.Message
        End If
        dispInfo(errorMessage)
    End Sub

#End Region


#Region " Private "

    Private Shared Sub displayMsg(ByVal msg As String)

        Dim timeString As String = ""
        timeString = timeString & "[" & Date.Now.ToShortDateString & "]"
        timeString = timeString & "[" & Date.Now.ToLongTimeString & "]"
        msg = timeString & "" & msg

        Trace.Write(msg & vbNewLine)

    End Sub

#End Region

End Class
