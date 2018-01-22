Module ReferentielTerritoireManager

    Public Function getWSReferentielTerritoire() As Object
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object = Nothing
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetReferentielTerritoire(agentCourant.id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    For Each tmpSerializeItem As System.Xml.XmlText In objWSCrodip_response
                        Dim tmpFileContent As String = "<?xml version=""1.0"" encoding=""ISO-8859-1""?>" & vbNewLine & "<root>" & vbNewLine & tmpSerializeItem.InnerText & vbNewLine & "</root>"
                        CSFile.write(GLOB_XML_TERRITOIRES.Nomfichier, tmpFileContent)
                    Next
                    Return True
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - ReferentielTerritoireManager - Code 1 : Non-Trouvée")
                    Return False
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - ReferentielTerritoireManager - Code 9 : Bad Request")
                    Return False
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - ReferentielTerritoireManager - getWSReferentielTerritoireById : " & ex.Message)
            Return False
        End Try
    End Function

End Module