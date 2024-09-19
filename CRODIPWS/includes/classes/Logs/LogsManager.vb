Module LogsManager

#Region "Methodes Web Service"


#End Region

#Region "Methodes Locales"

    Public Sub deleteLogs(ByVal log As Logs)

        Try

            Dim bdd As New CSDb(True)
            bdd.Execute("DELETE FROM `Logs` WHERE `Logs`.`id`=" & log.id & "")
            bdd.free()

        Catch ex As Exception
            CSDebug.dispFatal("LogsManager - deletLogs : " & ex.Message)
        End Try

    End Sub



#End Region

End Module