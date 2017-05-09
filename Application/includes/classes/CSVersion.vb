Module CSVersion

    Public Function getWSVersion()
        Dim result(2) As String

        Try
            ' déclarations
            CSDebug.dispInfo("getWSVersion - Declaration")
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            CSDebug.dispInfo("getWSVersion - Apres instanciation")
            Dim objWSCrodip_response As Object
            ' Appel au WS
            CSDebug.dispInfo("getWSVersion - On envoi la requete")
            Dim codeResponse As Integer = objWSCrodip.GetVersionLogicielAgent(objWSCrodip_response)
            CSDebug.dispInfo("getWSVersion - On l'a bien reçue (" & codeResponse & ")")
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    result(0) = objWSCrodip_response(0).innertext
                    result(1) = objWSCrodip_response(1).innertext
                    result(2) = objWSCrodip_response(2).innertext
                Case 1 ' NOK
                    CSDebug.dispError("CSVersion::getWSVersion - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("CSVersion::getWSVersion - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("CSVersion::getWSVersion : " & ex.Message)
        End Try

        Return result
    End Function

End Module
