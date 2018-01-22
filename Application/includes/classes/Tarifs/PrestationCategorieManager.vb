Module PrestationCategorieManager

#Region "Methodes Web Service"

    ' OK
    Public Function getWSPrestationCategorieById(pAgent As Agent, ByVal PrestationCategorie_id As Integer) As Object
        Dim curObject As New PrestationCategorie
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetPrestationCategorie(pAgent.id, PrestationCategorie_id, pAgent.idStructure, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        Select Case objWSCrodip_responseItem.Name()
                            Case "id"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
                                End If
                            Case "idStructure"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.idStructure = CType(objWSCrodip_responseItem.InnerText(), Integer)
                                End If
                            Case "libelle"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.description = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                            Case "dateModificationCrodip"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                            Case "dateModificationAgent"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                        End Select
                    Next
                Case 1 ' NOK
                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById : " & ex.Message)
        End Try
        Return curObject
    End Function

    ' OK
    Public Function sendWSPrestationCategorie(ByVal curObject As PrestationCategorie, pAgent As Agent, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendPrestationCategorie(pAgent.id, curObject, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ' OK
    Public Function xml2object(ByVal arrXml As Object) As PrestationCategorie
        Dim newObject As New PrestationCategorie
        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    newObject.id = CType(tmpSerializeItem.InnerText, Integer)
                Case "idStructure"
                    newObject.idStructure = CType(tmpSerializeItem.InnerText, Integer)
                Case "libelle"
                    newObject.description = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    newObject.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    newObject.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next
        Return newObject
    End Function

#End Region

#Region "Methodes Locales"

    ' OK
    Public Function save(ByVal curObject As PrestationCategorie, pAgent As Agent, Optional bSyncro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Dim dbLink As CSDb = Nothing
        '## Préparation de la connexion
        Dim bddCommande As OleDb.OleDbCommand
        Try
            If curObject.getEtat() <> Tarif.BDEtat.ETATNONE Then
                If curObject.id = 0 Then
                    curObject.id = PrestationCategorieManager.getNextId()
                End If
                If curObject.id <> 0 Then
                    '####################################################
                    If Not PrestationCategorieManager.exists(curObject) Then
                        PrestationCategorieManager.create(curObject.id, pAgent)
                    End If
                    '####################################################
                    '## Préparation de la connexion
                    ' On test si la connexion est déjà ouverte ou non
                    dbLink = New CSDb(True)
                    bddCommande = dbLink.getConnection().CreateCommand()
                    '####################################################

                    ' Initialisation de la requete
                    ' Mise a jour de la date de derniere modification
                    If Not bSyncro Then
                        curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                    End If

                    Dim paramsQuery As String = ""

                    If Not curObject.description Is Nothing Then
                        paramsQuery = paramsQuery & " `libelle`='" & CSDb.secureString(curObject.description) & "'"
                    End If
                    If Not curObject.dateModificationAgent Is Nothing Then
                        paramsQuery = paramsQuery & " , `dateModificationAgent`='" & CSDate.mysql2access(curObject.dateModificationAgent) & "'"
                    End If
                    If Not curObject.dateModificationCrodip Is Nothing Then
                        paramsQuery = paramsQuery & " , `dateModificationCrodip`='" & CSDate.mysql2access(curObject.dateModificationCrodip) & "'"
                    End If

                    '####################################################
                    '## Execution de la requete
                    bddCommande.CommandText = "UPDATE `PrestationCategorie` SET " & paramsQuery & " WHERE id=" & curObject.id & " AND idStructure = " & curObject.idStructure
                    bddCommande.ExecuteNonQuery()
                End If
                bReturn = True

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::save() : " & ex.Message.ToString)
            bReturn = False
        End Try

        If Not dbLink Is Nothing Then
            ' Si non, on la configure et on l'ouvre
            dbLink.free()
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Retourne le prochain ID disposible pour la structure
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNextId() As Integer
        Dim iReturn As Integer = 1
        Dim dbLink As New CSDb(True)
        '## Préparation de la connexion
        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = dbLink.getConnection().CreateCommand()
        Try
            Dim tmpResults As System.Data.OleDb.OleDbDataReader
            bddCommande.CommandText = "SELECT MAX(Id)+1 as NEWID FROM PrestationCategorie "
            tmpResults = bddCommande.ExecuteReader()
            While tmpResults.Read()
                '# Construction de l'objet
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId).ToUpper().Trim
                        Case "NEWID".ToUpper().Trim()
                            If Not tmpResults.IsDBNull(tmpColId) Then
                                iReturn = tmpResults.Item(tmpColId)
                            Else
                                iReturn = 1
                            End If
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '###############################
            End While
            tmpResults.Close()

        Catch ex As Exception
            CSDebug.dispError("PrestationCategorieManager::getNextId() : " & ex.Message.ToString)
        End Try
        dbLink.free()
        Return iReturn

    End Function
    ''' <summary>
    ''' Création d'un enregistrement à vide
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function create(ByVal id As Integer, pAgent As Agent) As Boolean
        Debug.Assert(id <> 0)
        Dim bReturn As Boolean
        Dim dbLink As New CSDb(True)
        '## Préparation de la connexion
        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = dbLink.getConnection().CreateCommand()
        Try
            '####################################################
            '## Execution de la requete
            bddCommande.CommandText = "INSERT INTO `PrestationCategorie` (`id`,`idStructure`,`dateModificationAgent`) VALUES ('" & id & "','" & pAgent.idStructure & "','" & CSDate.mysql2access(Date.Now) & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PrestationCategorieManager::create() : " & ex.Message.ToString)
            bReturn = False
        End Try
        dbLink.free()
        Return bReturn
    End Function

    ''' <summary>
    ''' Vérification de l'existence d'une prestation
    ''' </summary>
    ''' <param name="curObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function exists(ByVal curObject As PrestationCategorie) As Boolean
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        Try
            '## Execution de la requete
            Dim tmpResults As System.Data.OleDb.OleDbDataReader
            bddCommande.CommandText = "SELECT * FROM `PrestationCategorie` WHERE id=" & curObject.id & " AND idStructure = " & curObject.idStructure
            tmpResults = bddCommande.ExecuteReader()
            '################################################################
            If tmpResults.HasRows() Then
                bReturn = True
            Else
                bReturn = False
            End If
            tmpResults.Close()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::exists() : " & ex.Message)
            bReturn = False
        End Try
        oCSDB.free()
        Return bReturn
    End Function

    ' OK
    Public Sub setSynchro(ByVal curObject As PrestationCategorie)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `PrestationCategorie` SET `PrestationCategorie`.`dateModificationCrodip`='" & newDate & "',`PrestationCategorie`.`dateModificationAgent`='" & newDate & "' WHERE `PrestationCategorie`.`id`='" & curObject.id & "'"
            dbLink.getResults()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' OK
    Public Sub delete(ByVal curObject As PrestationCategorie)
        Try
            PrestationCategorieManager.delete(curObject.id)
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::delete() : " & ex.Message)
        End Try

    End Sub
    Public Sub delete(ByVal curObjectId As Integer)
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand
        Try
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM `PrestationCategorie` WHERE `PrestationCategorie`.`id`=" & curObjectId & ""
            bddCommande.ExecuteNonQuery()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::delete() : " & ex.Message)
        End Try
        oCSDB.free()

    End Sub

    ' OK
    Public Function getArrayByStructureId(ByVal idStructure As Integer) As PrestationCategorie()
        Dim arrObjects(0) As PrestationCategorie
        Try
            If idStructure <> 0 Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim tmpResults As System.Data.OleDb.OleDbDataReader
                tmpResults = dbLink.getResults("SELECT * FROM `PrestationCategorie` WHERE idStructure=" & idStructure & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While tmpResults.Read()
                    '# Construction de l'objet
                    Dim tmpObject As New PrestationCategorie
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        Select Case tmpResults.GetName(tmpColId)
                            Case "id"
                                tmpObject.id = tmpResults.Item(tmpColId)
                            Case "idStructure"
                                tmpObject.idStructure = tmpResults.Item(tmpColId)
                            Case "libelle"
                                tmpObject.description = tmpResults.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    '# Ajout au tableau de résultats
                    tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                    arrObjects(i) = tmpObject
                    i += 1
                    ReDim Preserve arrObjects(i)
                    '###############################
                End While
                ReDim Preserve arrObjects(i - 1)
                '################################################################

                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getArrayByStructureId(" & idStructure & ") : " & ex.Message)
        End Try
        Return arrObjects
    End Function

    ' OK
    Public Function getCategoryById(ByVal idCategorie As Integer, pidStructure As Integer) As PrestationCategorie
        Dim oCategorie As New PrestationCategorie
        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As System.Data.OleDb.OleDbDataReader
            tmpResults = dbLink.getResults("SELECT * FROM `PrestationCategorie` WHERE id=" & idCategorie & " AND idStructure=" & pidStructure)
            '################################################################
            Dim i As Integer = 0
            While tmpResults.Read()
                '# Construction de l'objet
                Dim tmpObject As New PrestationCategorie
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId)
                        Case "id"
                            tmpObject.id = tmpResults.Item(tmpColId)
                        Case "idStructure"
                            tmpObject.idStructure = tmpResults.Item(tmpColId)
                        Case "libelle"
                            tmpObject.description = tmpResults.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '# Ajout au tableau de résultats
                tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                oCategorie = tmpObject
                '###############################
            End While
            tmpResults.Close()
            '################################################################

            '' 110727 : arzur_c : On ferme la connexion
            dbLink.free()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getCategoryById(" & idCategorie & ") : " & ex.Message)
        End Try
        Return oCategorie
    End Function
    ' OK
    Public Function getUpdates() As PrestationCategorie()
        Dim arrObjects(0) As PrestationCategorie
        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As System.Data.OleDb.OleDbDataReader
            tmpResults = dbLink.getResults("SELECT * FROM PrestationCategorie WHERE PrestationCategorie.idStructure=" & agentCourant.idStructure & " AND ( dateModificationAgent<>dateModificationCrodip OR dateModificationCrodip Is Null) ORDER BY PrestationCategorie.id")
            '################################################################
            Dim i As Integer = 0
            While tmpResults.Read()
                '# Construction de l'objet
                Dim tmpObject As New PrestationCategorie
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId)
                        Case "id"
                            tmpObject.id = tmpResults.Item(tmpColId)
                        Case "idStructure"
                            tmpObject.idStructure = tmpResults.Item(tmpColId)
                        Case "libelle"
                            tmpObject.description = tmpResults.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '# Ajout au tableau de résultats
                tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                arrObjects(i) = tmpObject
                i += 1
                ReDim Preserve arrObjects(i)
                '###############################
            End While
            ReDim Preserve arrObjects(i - 1)
            '################################################################
            '' 110727 : arzur_c : On ferme la connexion
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getUpdates() : " & ex.Message)
        End Try
        Return arrObjects
    End Function

#End Region

End Module