Module Module1

    Sub Main()
        Dim target As UpdateInfo = New UpdateInfo()
        Dim actual As Boolean

        actual = target.majDatabase(".\updates.sql")
        If actual Then
            CSDebug.dispInfo("Mise a jour de la base de données OK")
            Console.WriteLine("Mise a jour de la base de données OK")
        Else
            CSDebug.dispInfo("Mise a jour de la base de données NOK")
            Console.WriteLine("Mise a jour de la base de données NOK")
        End If

    End Sub

End Module
