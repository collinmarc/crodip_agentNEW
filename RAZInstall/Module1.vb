Imports Crodip_agent
Module Module1

    Sub Main()
        Try

            GlobalsCRODIP.Init()
            AgentPCManager.RAZInstall()
            CSDebug.dispInfo("information d'installation Réinitialisée")
            CSDebug.dispInfo("Tapez sur une touche pour continuer")
        Catch ex As Exception
            CSDebug.dispError("RAZInstall ERR", ex)

        End Try

        Console.ReadLine()
    End Sub

End Module
