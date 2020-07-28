Public Class CSDebug

#Region " Methodes de log "

    Public Shared Function dispFatal(ByVal errorMsg As String) As Boolean
        Return displayMsg("[Fatal] - " & errorMsg)
    End Function

    Public Shared Function dispError(ByVal errorMsg As String) As Boolean
        Dim bReturn As Boolean
        Dim iLevel As Integer
        iLevel = My.Settings.debug_level
        bReturn = True
        If iLevel >= 1 Then
            bReturn = displayMsg("[Error] - " & errorMsg)
            'Dim curVersion As String = GLOB_APPLI_VERSION & GLOB_APPLI_BUILD & "-" & GLOB_APPLI_DATEBUILD
            'CSDebug.saveLog("error", agentCourant.id, errorMsg, curVersion)
        End If
        Return bReturn
    End Function
    Public Shared Function dispWarn(ByVal warnMsg As String) As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Dim iLevel As Integer
        iLevel = My.Settings.debug_level

        If iLevel >= 2 Then
            bReturn = displayMsg("[Warning] - " & warnMsg)
        End If
        Return bReturn
    End Function
    Public Shared Function dispInfo(ByVal infoMsg As String) As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Dim iLevel As Integer
        iLevel = My.Settings.debug_level

        If iLevel >= 3 Then
            bReturn = displayMsg("[Info] - " & infoMsg)
        End If
        Return bReturn
    End Function

#End Region

#Region " Divers "

    Public Shared Function var_dump(ByVal ar As Array) As String
        Dim rm As String = ""
        Dim i As Integer = 0
        If ar.GetType.IsArray = True Then
            rm &= "array(" & ar.Length & ") {" & vbCrLf
            For Each var As String In ar
                rm &= Space(2) & "[" & i & "]=>" & vbCrLf
                rm &= TypeName(var).Replace("()", "") & "(" & Len(var) & ") "
                If TypeName(var) = "array()" Then
                    Dim v() As String
                    v = var.Split("")
                    rm &= var_dump(v) & vbCrLf
                Else
                    rm &= Chr(34) & var & Chr(34) & vbCrLf
                End If
                i += 1
            Next
            rm &= "}"
        Else
            rm = "Error: Given array is not an array!!!"
            Throw New System.Exception("Given array is not an array!!!")
        End If
        Return rm
    End Function

#End Region

#Region " Private "

    Private Shared Function displayMsg(ByVal msg As String) As Boolean

        Dim timeString As String = ""
        timeString = timeString & "[" & Date.Now.ToShortDateString & "]"
        timeString = timeString & "[" & Date.Now.ToLongTimeString & "]"
        msg = timeString & "" & msg
        Dim strDebugType As String
        Dim bReturn As Boolean
        Try


            strDebugType = My.Settings.debug_type
            Select Case strDebugType

                Case "none"
                Case "console"
                    Console.Write(msg & vbNewLine)
                Case "msgbox"
                    MsgBox(msg)
                Case "file"
                    Dim strLogFile As String
                    strLogFile = Environment.CurrentDirectory & My.Settings.debug_filename
                    If Not CSFile.exists(strLogFile) Then
                        CSFile.create(strLogFile, msg)
                    Else
                        CSFile.append(strLogFile, msg)
                    End If

            End Select
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

#End Region

End Class
