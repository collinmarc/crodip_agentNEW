Module ReferentielManometreManager

    Public Function getWSReferentielManometre() As Boolean
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As new Object 
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetReferentielManometre(agentCourant.id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    For Each tmpSerializeItem As System.Xml.XmlText In objWSCrodip_response
                        CSFile.write(Globals.GLOB_XML_MARQUES_MANO.Nomfichier, tmpSerializeItem.InnerText)
                    Next
                    Return True
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - ReferentielManometreManager - Code 1 : Non-Trouvée")
                    Return False
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - ReferentielManometreManager - Code 9 : Bad Request")
                    Return False
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - ReferentielManometreManager - getWSReferentielManometreById : " & ex.Message)
            Return False
        End Try
    End Function

End Module