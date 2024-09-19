Module CSVersion

    Public Function getWSVersion() As String()
        Dim result(2) As String

        Try
            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
                ' déclarations
                Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
                Dim objWSCrodip_response As new Object 
                ' Appel au WS
                Dim codeResponse As Integer = objWSCrodip.GetVersionLogicielAgent(objWSCrodip_response)
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
            End If
        Catch ex As Exception
            CSDebug.dispError("CSVersion::getWSVersion : " & ex.Message)
        End Try

        Return result
    End Function

End Module
