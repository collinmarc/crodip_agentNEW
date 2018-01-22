Module ReferentielPulverisateurManager

    Public Function getWSReferentielPulverisateur() As Boolean
        CSDebug.dispError("Erreur - ReferentielPulverisateurManager - getWSReferentielPulverisateurById : REFERENTIEL INUTILISE")
        Return False

        'Try
        '    ' déclarations
        '    Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
        '    Dim objWSCrodip_response As Object
        '    ' Appel au WS
        '    Dim codeResponse As Integer = objWSCrodip.GetReferentielPulverisateur(agentCourant.id, objWSCrodip_response)
        '    Select Case codeResponse
        '        Case 0 ' OK
        '            ' construction de l'objet
        '            For Each tmpSerializeItem As System.Xml.XmlText In objWSCrodip_response
        '                CSFile.write(GLOB_XML_MARQUES_PULVE.leFichier, tmpSerializeItem.InnerText)
        '            Next
        '            Return True
        '        Case 1 ' NOK
        '            CSDebug.dispError("Erreur - ReferentielPulverisateurManager - Code 1 : Non-Trouvée")
        '            Return False
        '        Case 9 ' BADREQUEST
        '            CSDebug.dispError("Erreur - ReferentielPulverisateurManager - Code 9 : Bad Request")
        '            Return False
        '    End Select
        'Catch ex As Exception
        '    CSDebug.dispError("Erreur - ReferentielPulverisateurManager - getWSReferentielPulverisateurById : " & ex.Message)
        '    Return False
        'End Try
    End Function
    ''' <summary>
    ''' Recupère le referentiel Types-Categories
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getWSReferentielPulverisateurTypesCategories() As Boolean
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object = Nothing
            Dim url As String
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetReferentielPulverisateurTypesCategories(agentCourant.id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    For Each tmpSerializeItem As System.Xml.XmlText In objWSCrodip_response
                        CSFile.write(GLOB_XML_TYPES_CATEGORIES_PULVE.Nomfichier, tmpSerializeItem.InnerText)
                    Next
                    Return True
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - getWSReferentielPulverisateurTypesCategories - Code 1 : Non-Trouvée")
                    Return False
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - getWSReferentielPulverisateurTypesCategories - Code 9 : Bad Request")
                    Return False
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - ReferentielPulverisateurManager - getWSReferentielPulverisateurTypesCategories : " & ex.Message)
            Return False
        End Try
    End Function 'getWSReferentielPulverisateurTypesCategories
    ''' <summary>
    ''' Recupère le referentiel Marques-Modèles
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getWSReferentielPulverisateurMarquesModeles() As Boolean
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object = Nothing
            Dim url As String
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetReferentielPulverisateurMarquesModeles(agentCourant.id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    For Each tmpSerializeItem As System.Xml.XmlText In objWSCrodip_response
                        CSFile.write(GLOB_XML_MARQUES_MODELES_PULVE.Nomfichier, tmpSerializeItem.InnerText)
                    Next
                    Return True
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - getWSReferentielPulverisateurMarquesModeles - Code 1 : Non-Trouvée")
                    Return False
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - getWSReferentielPulverisateurMarquesModeles - Code 9 : Bad Request")
                    Return False
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - ReferentielPulverisateurManager - getWSReferentielPulverisateurMarquesModeles : " & ex.Message)
            Return False
        End Try
    End Function 'getWSReferentielPulverisateurMarquesModeles
End Module