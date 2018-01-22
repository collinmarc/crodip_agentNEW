Imports NLog

Public Class CSDebug
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

#Region " Methodes de log "

    Public Shared Sub dispFatal(ByVal errorMsg As String)
        logger.Fatal(errorMsg)

        displayMsg("[Fatal] - " & errorMsg)
        ' Dim curVersion As String = GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
        'CSDebug.saveLog("fatal", agentCourant.id, errorMsg, curVersion)
        MsgBox(errorMsg, MsgBoxStyle.Critical, "FATAL ERROR")
    End Sub
    Public Shared Sub dispError(ByVal errorMsg As String)
        logger.Error(errorMsg)
        If GLOB_ENV_DEBUGLVL >= 1 Then
            displayMsg("[Error] - " & errorMsg)
            '   Dim curVersion As String = GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
            '  CSDebug.saveLog("Error", agentCourant.id, errorMsg, curVersion)
        End If
    End Sub
    Public Shared Sub dispWarn(ByVal warnMsg As String)
        logger.Warn(warnMsg)
        If GLOB_ENV_DEBUGLVL >= 2 Then
            displayMsg("[Warning] - " & warnMsg)
            ' Dim curVersion As String = GLOB_APPLI_VERSION & "-" & GLOB_APPLI_BUILD
            'CSDebug.saveLog("Warning", agentCourant.id, warnMsg, curVersion)
        End If
    End Sub
    Public Shared Sub dispInfo(ByVal infoMsg As String)
        logger.Info(infoMsg)
        If GLOB_ENV_DEBUGLVL >= 3 Then
            displayMsg("[Info] - " & infoMsg)
        End If
    End Sub


#End Region


#Region " Private "

    Private Shared Sub displayMsg(ByVal msg As String)

        Dim timeString As String = ""
        timeString = timeString & "[" & Date.Now.ToShortDateString & "]"
        timeString = timeString & "[" & Date.Now.ToLongTimeString & "]"
        msg = timeString & "" & msg

        Console.Write(msg & vbNewLine)
        Select Case GLOB_ENV_DEBUGTYPE

            Case "none"
            Case "console"
                Console.Write(msg & vbNewLine)
            Case "msgbox"
                MsgBox(msg)
            Case "file"
                Console.Write(msg & vbNewLine)
                If Not CSFile.exists(GLOB_ENV_DEBUGLOGFILE) Then
                    CSFile.create(GLOB_ENV_DEBUGLOGFILE, msg)
                Else
                    CSFile.append(GLOB_ENV_DEBUGLOGFILE, msg)
                End If

        End Select

    End Sub

#End Region

End Class
