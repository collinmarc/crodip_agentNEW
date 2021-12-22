'Module DiagnosticFactureItemManager

'#Region "Methodes acces Web Service"

'    ' OK
'    'Public Function getWSDiagnosticFactureItemById(ByVal diagnostic_id As String) As Object
'    '    Dim curObject As New DiagnosticFactureItem
'    '    Try

'    '        ' déclarations
'    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
'    '        Dim objWSCrodip_response As Object
'    '        ' Appel au WS
'    '        Dim codeResponse As Integer = objWSCrodip.GetDiagnosticFactureItems(agentCourant.id, diagnostic_id, objWSCrodip_response)
'    '        Select Case codeResponse
'    '            Case 0 ' OK
'    '                ' construction de l'objet
'    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
'    '                For Each objWSCrodip_responseItem In objWSCrodip_response
'    '                    Select Case objWSCrodip_responseItem.Name()
'    '                        Case "id"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
'    '                            End If
'    '                        Case "idFacture"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.idFacture = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "libelle"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.libelle = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "prixUnitaire"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.prixUnitaire = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "qte"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.qte = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "tva"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.tva = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "prixTotal"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.prixTotal = CType(objWSCrodip_responseItem.InnerText(), String)
'    '                            End If
'    '                        Case "dateModificationAgent"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.dateModificationAgent = CSDate.access2mysql(CType(objWSCrodip_responseItem.InnerText(), String))
'    '                            End If
'    '                        Case "dateModificationCrodip"
'    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
'    '                                curObject.dateModificationCrodip = CSDate.access2mysql(CType(objWSCrodip_responseItem.InnerText(), String))
'    '                            End If
'    '                    End Select
'    '                Next
'    '            Case 1 ' NOK
'    '                CSDebug.dispFatal("DiagnosticFactureItemManager - Code 1 : Non-Trouvée")
'    '            Case 9 ' BADREQUEST
'    '                CSDebug.dispFatal("DiagnosticFactureItemManager - Code 9 : Bad Request")
'    '        End Select
'    '    Catch ex As Exception
'    '        CSDebug.dispFatal("DiagnosticFactureItemManager - getWSDiagnosticFactureItemById : " & ex.Message)
'    '    End Try
'    '    Return curObject

'    'End Function

'    '' OK
'    'Public Function sendWSDiagnosticFactureItem(ByVal objDiagnosticFactureItems As DiagnosticFactureItemList, ByRef updatedObject As Object)
'    '    Dim tmpArr(1)() As DiagnosticFactureItem
'    '    tmpArr(0) = objDiagnosticFactureItems.diagnosticFactureItem
'    '    Try
'    '        ' Appel au WS
'    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
'    '        Return objWSCrodip.SendDiagnosticFactureItems(agentCourant.id, tmpArr, updatedObject)
'    '    Catch ex As Exception
'    '        Return -1
'    '    End Try
'    'End Function

'    ' OK
'    Public Function xml2object(ByVal arrXml As Object) As DiagnosticFactureItem
'        Dim newObject As New DiagnosticFactureItem

'        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
'            Select Case tmpSerializeItem.LocalName()
'                Case "id"
'                    newObject.id = CType(tmpSerializeItem.InnerText, Integer)
'                Case "idFacture"
'                    newObject.idFacture = CType(tmpSerializeItem.InnerText, String)
'                Case "libelle"
'                    newObject.libelle = CType(tmpSerializeItem.InnerText, String)
'                Case "prixUnitaire"
'                    newObject.prixUnitaire = CType(tmpSerializeItem.InnerText, String)
'                Case "qte"
'                    newObject.qte = CType(tmpSerializeItem.InnerText, String)
'                Case "tva"
'                    newObject.tva = CType(tmpSerializeItem.InnerText, String)
'                Case "prixTotal"
'                    newObject.prixTotal = CType(tmpSerializeItem.InnerText, String)
'                Case "dateModificationCrodip"
'                    newObject.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
'                Case "dateModificationAgent"
'                    newObject.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
'            End Select
'        Next

'        Return newObject
'    End Function

'#End Region

'#Region "Methodes acces Local"

'    ' OK
'    Public Function getDiagnosticFactureItemById2(ByVal diagnosticitem_id As String) As DiagnosticFactureItem
'        ' déclarations
'        Dim tmpObject As New DiagnosticFactureItem
'        Dim oCSDB As New CSDb(True)
'        If diagnosticitem_id <> "" Then

'            Dim bddCommande As New OleDb.OleDbCommand
'            bddCommande.Connection = oCSDB.getConnection()
'            bddCommande.CommandText = "SELECT * FROM DiagnosticFactureItem WHERE DiagnosticFactureItem.id='" & diagnosticitem_id & "'"
'            Try
'                ' On récupère les résultats
'                Dim tmpResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
'                ' Puis on les parcours
'                While tmpResults.Read()
'                    ' On rempli notre tableau
'                    Dim tmpColId As Integer = 0
'                    While tmpColId < tmpResults.FieldCount()
'                        Select Case tmpResults.GetName(tmpColId)
'                            Case "id"
'                                tmpObject.id = tmpResults.Item(tmpColId).ToString()
'                            Case "idFacture"
'                                tmpObject.idFacture = tmpResults.Item(tmpColId).ToString()
'                            Case "libelle"
'                                tmpObject.libelle = tmpResults.Item(tmpColId).ToString()
'                            Case "prixUnitaire"
'                                tmpObject.prixUnitaire = tmpResults.Item(tmpColId).ToString()
'                            Case "qte"
'                                tmpObject.qte = tmpResults.Item(tmpColId).ToString()
'                            Case "tva"
'                                tmpObject.tva = tmpResults.Item(tmpColId).ToString()
'                            Case "prixTotal"
'                                tmpObject.prixTotal = tmpResults.Item(tmpColId).ToString()
'                            Case "dateModificationCrodip"
'                                tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
'                            Case "dateModificationAgent"
'                                tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
'                        End Select
'                        tmpColId = tmpColId + 1
'                    End While
'                End While
'            Catch ex As Exception ' On intercepte l'erreur
'                MsgBox("DiagnosticFactureItemManager Error: " & ex.Message)
'            End Try

'            ' Test pour fermeture de connection BDD
'            If Not oCSDB Is Nothing Then
'                ' On ferme la connexion
'                oCSDB.free()
'            End If

'        End If
'        'on retourne le diagnosticitem ou un objet vide en cas d'erreur
'        Return tmpObject
'    End Function

'    ' OK
'    Public Sub save2(ByVal curObject As DiagnosticFactureItem, Optional bSyncro As Boolean = False)
'        Dim oCSDB As New CSDb(True)
'        Try
'            If curObject.id <> "" Then

'                Dim dbLink As New CSDb

'                ' On test si le DiagnosticItem existe ou non
'                Dim existsDiagnosticItem As Object
'                existsDiagnosticItem = DiagnosticFactureItemManager.getDiagnosticFactureItemById2(curObject.id)
'                If existsDiagnosticItem.id = "" Then
'                    ' Si il n'existe pas, on le crée
'                    createDiagnosticFactureItem(curObject.id)
'                End If

'                Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()

'                ' Initialisation de la requete
'                Dim paramsQuery As String = "`DiagnosticFactureItem`.`id`='" & curObject.id & "'"

'                ' Mise a jour de la date de derniere modification
'                If Not bSyncro Then
'                    curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
'                End If

'                If Not curObject.idFacture Is Nothing Then
'                    paramsQuery = paramsQuery & " , `idFacture`='" & CSDb.secureString(curObject.idFacture) & "'"
'                End If
'                If Not curObject.libelle Is Nothing Then
'                    paramsQuery = paramsQuery & " , `libelle`='" & CSDb.secureString(curObject.libelle) & "'"
'                End If
'                If Not curObject.prixUnitaire Is Nothing Then
'                    paramsQuery = paramsQuery & " , `prixUnitaire`='" & CSDb.secureString(curObject.prixUnitaire) & "'"
'                End If
'                If Not curObject.qte Is Nothing Then
'                    paramsQuery = paramsQuery & " , `qte`='" & CSDb.secureString(curObject.qte) & "'"
'                End If
'                If Not curObject.tva Is Nothing Then
'                    paramsQuery = paramsQuery & " , `tva`='" & CSDb.secureString(curObject.tva) & "'"
'                End If
'                If Not curObject.prixTotal Is Nothing Then
'                    paramsQuery = paramsQuery & " , `prixTotal`='" & CSDb.secureString(curObject.prixTotal) & "'"
'                End If
'                If Not curObject.dateModificationAgent Is Nothing Then
'                    paramsQuery = paramsQuery & " , `dateModificationAgent`='" & CSDate.mysql2access(CSDb.secureString(curObject.dateModificationAgent)) & "'"
'                End If
'                If Not curObject.dateModificationCrodip Is Nothing Then
'                    paramsQuery = paramsQuery & " , `dateModificationCrodip`='" & CSDate.mysql2access(CSDb.secureString(curObject.dateModificationCrodip)) & "'"
'                End If

'                ' On finalise la requete et en l'execute
'                bddCommande.CommandText = "UPDATE `DiagnosticFactureItem` SET " & paramsQuery & " WHERE `DiagnosticFactureItem`.`id`='" & curObject.id & "'"
'                bddCommande.ExecuteNonQuery()
'                ' Test pour fermeture de connection BDD


'            End If
'        Catch ex As Exception
'            Console.Write("Erreur DiagnosticFactureItemManager - save" & ex.Message.ToString)
'        End Try

'        If Not oCSDB Is Nothing Then
'            oCSDB.free()
'        End If
'    End Sub

'    ' OK
'    Public Sub setSynchro(ByVal curObject As DiagnosticFactureItem)
'        Try
'            Dim dbLink As New CSDb(True)
'            Dim newDate As String = Date.Now.ToString
'            dbLink.queryString = "UPDATE `DiagnosticFactureItem` SET `DiagnosticFactureItem`.`dateModificationCrodip`='" & newDate & "',`DiagnosticFactureItem`.`dateModificationAgent`='" & newDate & "' WHERE `DiagnosticFactureItem`.`id`='" & curObject.id & "'"
'            dbLink.Execute()
'            dbLink.free()
'        Catch ex As Exception
'            CSDebug.dispFatal("DiagnosticFactureItemManager::setSynchro : " & ex.Message)
'        End Try
'    End Sub

'    ' OK
'    Private Sub createDiagnosticFactureItem(ByVal diagnosticitem_id As String)
'        Dim oCSDB As New CSDb(True)
'        Try
'            Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection.CreateCommand()

'            ' Création
'            bddCommande.CommandText = "INSERT INTO `DiagnosticFactureItem` (`id`) VALUES ('" & diagnosticitem_id & "')"
'            bddCommande.ExecuteNonQuery()

'        Catch ex As Exception
'            MsgBox("DiagnosticFactureItemManager error : " & ex.Message)
'        End Try
'        If Not oCSDB Is Nothing Then
'            oCSDB.free()
'        End If
'    End Sub

'#End Region

'End Module
