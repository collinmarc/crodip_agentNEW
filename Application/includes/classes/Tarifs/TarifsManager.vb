'Module TarifsManager

'    Public Function getWSPrestationCategorieById(ByVal PrestationCategorie_id As Integer) As Object

'        Dim objPrestationCategorie As New objTarifCategorie
'        Try

'            ' déclarations
'            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
'            Dim objWSCrodip_response As new Object
'            ' Appel au WS
'            Dim codeResponse As Integer = objWSCrodip.GetPrestationCategorie(agentCourant.id, PrestationCategorie_id, agentCourant.idStructure, objWSCrodip_response)
'            Select Case codeResponse
'                Case 0 ' OK
'                    ' construction de l'objet
'                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
'                    For Each objWSCrodip_responseItem In objWSCrodip_response
'                        Select Case objWSCrodip_responseItem.Name()
'                            Case "id"
'                                If objWSCrodip_responseItem.InnerText() <> "" Then
'                                    objPrestationCategorie.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
'                                End If
'                            Case "idStructure"
'                                If objWSCrodip_responseItem.InnerText() <> "" Then
'                                    objPrestationCategorie.idStructure = CType(objWSCrodip_responseItem.InnerText(), String)
'                                End If
'                            Case "libelle"
'                                If objWSCrodip_responseItem.InnerText() <> "" Then
'                                    objPrestationCategorie.libelle = CType(objWSCrodip_responseItem.InnerText(), String)
'                                End If
'                            Case "dateModificationCrodip"
'                                If objWSCrodip_responseItem.InnerText() <> "" Then
'                                    objPrestationCategorie.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
'                                End If
'                            Case "dateModificationAgent"
'                                If objWSCrodip_responseItem.InnerText() <> "" Then
'                                    objPrestationCategorie.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
'                                End If
'                        End Select
'                    Next
'                Case 1 ' NOK
'                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 1 : Non-Trouvée")
'                Case 9 ' BADREQUEST
'                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 9 : Bad Request")
'            End Select
'        Catch ex As Exception
'            CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById : " & ex.Message)
'        End Try
'        Return objPrestationCategorie

'    End Function

'    '#####################################################################################################################################

'    ' Methode : OK
'    ' Récupère la liste des catégories d'un agent
'    Public Function getAgentCategories(ByVal param As String)
'        Dim arrCategories(0) As objTarifCategorie
'        If param <> "" Then

'            Dim bddCommande As OleDb.OleDbCommand
'            Dim oCSDB As New CSDb(True)
'            bddCommande = oCSDB.getConnection().CreateCommand()
'            bddCommande.CommandText = "SELECT * FROM PrestationCategorie WHERE PrestationCategorie.idStructure=" & param & ""
'            Try

'                ' On récupère les résultats
'                Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'                ' Puis on les parcours
'                Dim i As Integer = 0
'                While tmpListResults.Read()

'                    ' On rempli notre tableau
'                    Dim tmpItem As New objTarifCategorie
'                    Dim tmpColId As Integer = 0
'                    While tmpColId < tmpListResults.FieldCount()
'                        Select Case tmpListResults.GetName(tmpColId)
'                            Case "id"
'                                tmpItem.id = tmpListResults.Item(tmpColId)
'                            Case "idStructure"
'                                tmpItem.idStructure = tmpListResults.Item(tmpColId).ToString()
'                            Case "libelle"
'                                tmpItem.libelle = tmpListResults.Item(tmpColId).ToString()
'                            Case "dateModificationAgent"
'                                tmpItem.dateModificationAgent = tmpListResults.Item(tmpColId).ToString()
'                            Case "dateModificationCrodip"
'                                tmpItem.dateModificationCrodip = tmpListResults.Item(tmpColId).ToString()
'                        End Select
'                        tmpColId = tmpColId + 1
'                    End While
'                    arrCategories(i) = tmpItem
'                    i = i + 1
'                    ReDim Preserve arrCategories(i)
'                End While
'                ReDim Preserve arrCategories(i - 1)
'            Catch ex As Exception
'                ' On catch l'erreur
'                CSDebug.dispFatal("TarifsManager::getAgentCategories : " & ex.Message.ToString)
'            End Try
'            oCSDB.free()

'        End If
'        Return arrCategories
'    End Function

'    ' Methode : OK
'    ' Récupère la liste des préstations d'une catégorie
'    Public Function getCategoriePrestations(ByVal categorie_id As Integer)
'        Dim arrPrestations(0) As objTarifPrestation
'        If categorie_id <> 0 Then

'            Dim bddCommande As OleDb.OleDbCommand
'            Dim oCSDB As New CSDb(True)
'            bddCommande = oCSDB.getConnection().CreateCommand()
'            bddCommande.CommandText = "SELECT * FROM PrestationTarif WHERE PrestationTarif.idCategorie=" & categorie_id & ""
'            Try

'                ' On récupère les résultats
'                Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'                ' Puis on les parcours
'                Dim i As Integer = 0
'                While tmpListResults.Read()

'                    ' On rempli notre tableau
'                    Dim tmpItem As New objTarifPrestation
'                    Dim tmpColId As Integer = 0
'                    While tmpColId < tmpListResults.FieldCount()
'                        Select Case tmpListResults.GetName(tmpColId)
'                            Case "id"
'                                tmpItem.id = tmpListResults.Item(tmpColId)
'                            Case "idCategorie"
'                                tmpItem.idCategorie = tmpListResults.Item(tmpColId)
'                            Case "idStructure"
'                                tmpItem.idStructure = tmpListResults.Item(tmpColId).ToString()
'                            Case "description"
'                                tmpItem.description = tmpListResults.Item(tmpColId).ToString()
'                            Case "tarifHT"
'                                tmpItem.tarifHT = tmpListResults.Item(tmpColId)
'                            Case "tarifTTC"
'                                tmpItem.tarifTTC = tmpListResults.Item(tmpColId)
'                            Case "tva"
'                                tmpItem.tva = tmpListResults.Item(tmpColId)
'                            Case "dateModificationAgent"
'                                tmpItem.dateModificationAgent = tmpListResults.Item(tmpColId).ToString()
'                            Case "dateModificationCrodip"
'                                tmpItem.dateModificationCrodip = tmpListResults.Item(tmpColId).ToString()
'                        End Select
'                        tmpColId = tmpColId + 1
'                    End While
'                    arrPrestations(i) = tmpItem
'                    i = i + 1
'                    ReDim Preserve arrPrestations(i)
'                End While
'                ReDim Preserve arrPrestations(i - 1)
'            Catch ex As Exception
'                CSDebug.dispError("TarifsManager.GetCategoriePrestation ERR " & ex.Message)
'            End Try
'            oCSDB.free()

'        End If
'        Return arrPrestations
'    End Function

'    ' Récupère une préstation
'    Public Function getPrestationById(ByVal prestation_id As Integer)
'        Dim objPrestation As New objTarifPrestation
'        If prestation_id <> 0 Then

'            Dim bddCommande As OleDb.OleDbCommand
'            Dim oCSDB As New CSDb(True)
'            bddCommande = oCSDB.getConnection().CreateCommand()
'            bddCommande.CommandText = "SELECT * FROM PrestationTarif WHERE PrestationTarif.id=" & prestation_id & ""
'            Try

'                ' On récupère les résultats
'                Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'                ' Puis on les parcours
'                Dim i As Integer = 0
'                While tmpListResults.Read()

'                    ' On rempli notre tableau
'                    Dim tmpColId As Integer = 0
'                    While tmpColId < tmpListResults.FieldCount()
'                        Select Case tmpListResults.GetName(tmpColId)
'                            Case "id"
'                                objPrestation.id = tmpListResults.Item(tmpColId)
'                            Case "idCategorie"
'                                objPrestation.idCategorie = tmpListResults.Item(tmpColId)
'                            Case "idStructure"
'                                objPrestation.idStructure = tmpListResults.Item(tmpColId).ToString()
'                            Case "description"
'                                objPrestation.description = tmpListResults.Item(tmpColId).ToString()
'                            Case "tarifHT"
'                                objPrestation.tarifHT = tmpListResults.Item(tmpColId)
'                            Case "tarifTTC"
'                                objPrestation.tarifTTC = tmpListResults.Item(tmpColId)
'                            Case "tva"
'                                objPrestation.tva = tmpListResults.Item(tmpColId)
'                            Case "dateModificationAgent"
'                                objPrestation.dateModificationAgent = tmpListResults.Item(tmpColId).ToString()
'                            Case "dateModificationCrodip"
'                                objPrestation.dateModificationCrodip = tmpListResults.Item(tmpColId).ToString()
'                        End Select
'                        tmpColId = tmpColId + 1
'                    End While

'                End While
'            Catch ex As Exception
'                CSDebug.dispError("TarifsManager.GetPrestationById ERR" & ex.Message)
'            End Try
'            oCSDB.free()

'        End If
'        Return objPrestation
'    End Function

'    ' Methode : OK
'    Public Function addAgentCategorie(ByVal structureId As String, ByVal categorieLibelle As String) As Boolean
'        Dim bReturn As Boolean
'        bReturn = False
'        If categorieLibelle <> "" Then

'            Dim CSDb As New CSDb

'            Dim bddCommande As OleDb.OleDbCommand
'            Dim oCSDB As New CSDb(True)
'            bddCommande = oCSDB.getConnection().CreateCommand()
'            bddCommande.CommandText = "INSERT INTO PrestationCategorie (`idStructure`,`libelle`) VALUES (" & structureId & ",'" & CSDb.secureString(categorieLibelle) & "')"
'            Try
'                ' On execute
'                Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'                tmpListResults.Read()
'                bReturn = True
'            Catch ex As Exception
'                CSDebug.dispError("TarifsManager.AddAgentCateorie ERR" & ex.Message)
'                bReturn = False
'            End Try
'            oCSDB.free()
'        Else
'            bReturn = False
'        End If
'        Return bReturn
'    End Function
'    'Public Function savePrestation(ByVal prestationId As Integer, ByVal prestationTarifHT As Double, ByVal prestationTarifTTC As Double, ByVal prestationTVA As Double)
'    '    If prestationId <> 0 Then

'    '        Dim bddCommande As New OleDb.OleDbCommand
'    '        ' On test si la connexion est déjà ouverte ou non
'    '        If bddConnection.State() = 0 Then
'    '            ' Si non, on la configure et on l'ouvre
'    '            bddConnection.ConnectionString = bddConnectString
'    '            bddConnection.Open()
'    '        End If
'    '        bddCommande.Connection = bddConnection
'    '        bddCommande.CommandText = "UPDATE `PrestationTarif` SET `PrestationTarif`.`tarifHT`='" & prestationTarifHT & "',`PrestationTarif`.`tarifTTC`='" & prestationTarifTTC & "',`PrestationTarif`.`tva`='" & prestationTVA & "' WHERE `PrestationTarif`.`id`=" & prestationId
'    '        Try
'    '            ' On execute
'    '            Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'    '            tmpListResults.Read()
'    '        Catch ex As Exception
'    '            ' On catch l'erreur
'    '            CSDebug.dispFatal("TarifManager - Save : " & ex.Message)
'    '            Return False
'    '        End Try
'    '        ' Test pour fermeture de connection BDD
'    '        If bddConnection.State() <> 0 Then
'    '            ' On ferme la connexion
'    '            bddConnection.Close()
'    '        End If
'    '        Return True
'    '    Else
'    '        Return False
'    '    End If
'    'End Function

'    ' Methode : OK
'    'Public Function removeAgentCategorie(ByVal categorieId As Integer)
'    '    If categorieId <> 0 Then

'    '        Dim bddCommande As New OleDb.OleDbCommand
'    '        ' On test si la connexion est déjà ouverte ou non
'    '        If bddConnection.State() = 0 Then
'    '            ' Si non, on la configure et on l'ouvre
'    '            bddConnection.ConnectionString = bddConnectString
'    '            bddConnection.Open()
'    '        End If
'    '        bddCommande.Connection = bddConnection
'    '        bddCommande.CommandText = "DELETE FROM PrestationTarif WHERE idCategorie=" & categorieId
'    '        Try
'    '            ' On execute
'    '            Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'    '            tmpListResults.Read()
'    '        Catch ex As Exception
'    '            ' On catch l'erreur
'    '            Return False
'    '        End Try
'    '        bddConnection.Close()
'    '        bddConnection.ConnectionString = bddConnectString
'    '        bddConnection.Open()
'    '        bddCommande.CommandText = "DELETE FROM PrestationCategorie WHERE id=" & categorieId
'    '        Try
'    '            ' On execute
'    '            Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'    '            tmpListResults.Read()
'    '        Catch ex As Exception
'    '            ' On catch l'erreur
'    '            Return False
'    '        End Try
'    '        ' Test pour fermeture de connection BDD
'    '        If bddConnection.State() <> 0 Then
'    '            ' On ferme la connexion
'    '            bddConnection.Close()
'    '        End If
'    '        Return True
'    '    Else
'    '        Return False
'    '    End If
'    'End Function
'    ' Methode : OK
'    'Public Function removeCategoriePrestation(ByVal prestationId As Integer)
'    '    If prestationId <> 0 Then

'    '        Dim bddCommande As New OleDb.OleDbCommand
'    '        ' On test si la connexion est déjà ouverte ou non
'    '        If bddConnection.State() = 0 Then
'    '            ' Si non, on la configure et on l'ouvre
'    '            bddConnection.ConnectionString = bddConnectString
'    '            bddConnection.Open()
'    '        End If
'    '        bddCommande.Connection = bddConnection
'    '        bddCommande.CommandText = "DELETE FROM PrestationTarif WHERE id=" & prestationId
'    '        Try
'    '            ' On execute
'    '            Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'    '            tmpListResults.Read()
'    '        Catch ex As Exception
'    '            ' On catch l'erreur
'    '            Return False
'    '        End Try
'    '        ' Test pour fermeture de connection BDD
'    '        If bddConnection.State() <> 0 Then
'    '            ' On ferme la connexion
'    '            bddConnection.Close()
'    '        End If
'    '        Return True
'    '    Else
'    '        Return False
'    '    End If
'    'End Function

'End Module
