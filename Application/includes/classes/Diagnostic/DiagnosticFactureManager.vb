Module DiagnosticFactureManager

#Region "Methodes acces Web Service"

    'OK
    'Public Function getWSDiagnosticFactureById(ByVal diagnostic_id As String) As Object
    '    Dim curObject As New DiagnosticFacture
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As Object
    '        If GLOB_ENV_WS = "dev" Then
    '            objWSCrodip = New WSCrodip1.CrodipServer
    '        Else
    '            objWSCrodip = New WSCrodip_prod.CrodipServer
    '        End If
    '        Dim objWSCrodip_response As Object
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetDiagnosticFacture(agentCourant.id, diagnostic_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    Select Case objWSCrodip_responseItem.Name()
    '                        Case "id"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.id = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "factureReference"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.factureReference = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "factureDate"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.factureDate = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "factureTotal"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.factureTotal = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganisme"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganisme = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeAdresse"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeAdresse = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeCpVille"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeCpVille = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeTelFax"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeTelFax = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeSiren"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeSiren = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeTva"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeTva = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "emetteurOrganismeRcs"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.emetteurOrganismeRcs = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "recepteurRaisonSociale"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.recepteurRaisonSociale = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "recepteurProprio"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.recepteurProprio = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "recepteurCpVille"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.recepteurCpVille = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "dateModificationAgent"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                        Case "dateModificationCrodip"
    '                            If objWSCrodip_responseItem.InnerText() <> "" Then
    '                                curObject.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
    '                            End If
    '                    End Select
    '                Next
    '            Case 1 ' NOK
    '                MsgBox("Erreur - DiagnosticFactureManager - Code 1 : Non-Trouvée")
    '            Case 9 ' BADREQUEST
    '                MsgBox("Erreur - DiagnosticFactureManager - Code 9 : Bad Request")
    '        End Select
    '    Catch ex As Exception
    '        MsgBox("Erreur - DiagnosticFactureManager - getWSDiagnosticById : " & ex.Message)
    '    End Try
    '    Return curObject

    'End Function

    'OK
    'Public Function sendWSDiagnosticFacture(ByVal diagnostic As DiagnosticFacture, ByRef updatedObject As Object)
    '    Try
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
    '        Return objWSCrodip.SendDiagnosticFacture(agentCourant.id, diagnostic, updatedObject)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'OK
    Public Function xml2object(ByVal arrXml As Object) As DiagnosticFacture
        Dim newObject As New DiagnosticFacture

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    newObject.id = CType(tmpSerializeItem.InnerText, String)
                Case "factureReference"
                    newObject.factureReference = CType(tmpSerializeItem.InnerText, String)
                Case "factureDate"
                    newObject.factureDate = CType(tmpSerializeItem.InnerText, String)
                Case "factureTotal"
                    newObject.factureTotal = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganisme"
                    newObject.emetteurOrganisme = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeAdresse"
                    newObject.emetteurOrganismeAdresse = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeCpVille"
                    newObject.emetteurOrganismeCpVille = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeTelFax"
                    newObject.emetteurOrganismeTelFax = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeSiren"
                    newObject.emetteurOrganismeSiren = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeTva"
                    newObject.emetteurOrganismeTva = CType(tmpSerializeItem.InnerText, String)
                Case "emetteurOrganismeRcs"
                    newObject.emetteurOrganismeRcs = CType(tmpSerializeItem.InnerText, String)
                Case "recepteurRaisonSociale"
                    newObject.recepteurRaisonSociale = CType(tmpSerializeItem.InnerText, String)
                Case "recepteurProprio"
                    newObject.recepteurProprio = CType(tmpSerializeItem.InnerText, String)
                Case "recepteurCpVille"
                    newObject.recepteurCpVille = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    newObject.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    newObject.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return newObject
    End Function

#End Region

#Region "Methodes acces Local"

    'OK
    Public Function getDiagnosticFactureById(ByVal diagnostic_id As String)
        ' déclarations
        Dim tmpObject As New DiagnosticFacture
        If diagnostic_id <> "" Then

            Dim bddCommande As New OleDb.OleDbCommand
            Dim oCSdb As New CSDb(True)
            ' On test si la connexion est déjà ouverte ou non
            bddCommande.Connection = oCSdb.getConnection()
            bddCommande.CommandText = "SELECT * FROM DiagnosticFacture WHERE DiagnosticFacture.id='" & diagnostic_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpResults.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        If tmpResults.Item(tmpColId).GetType.ToString <> "System.DBNull" Then
                            Select Case tmpResults.GetName(tmpColId)
                                Case "id"
                                    tmpObject.id = tmpResults.Item(tmpColId).ToString()
                                Case "factureReference"
                                    tmpObject.factureReference = tmpResults.Item(tmpColId).ToString()
                                Case "factureDate"
                                    tmpObject.factureDate = tmpResults.Item(tmpColId).ToString()
                                Case "factureTotal"
                                    tmpObject.factureTotal = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganisme"
                                    tmpObject.emetteurOrganisme = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeAdresse"
                                    tmpObject.emetteurOrganismeAdresse = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeCpVille"
                                    tmpObject.emetteurOrganismeCpVille = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeTelFax"
                                    tmpObject.emetteurOrganismeTelFax = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeSiren"
                                    tmpObject.emetteurOrganismeSiren = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeTva"
                                    tmpObject.emetteurOrganismeTva = tmpResults.Item(tmpColId).ToString()
                                Case "emetteurOrganismeRcs"
                                    tmpObject.emetteurOrganismeRcs = tmpResults.Item(tmpColId).ToString()
                                Case "recepteurRaisonSociale"
                                    tmpObject.recepteurRaisonSociale = tmpResults.Item(tmpColId).ToString()
                                Case "recepteurProprio"
                                    tmpObject.recepteurProprio = tmpResults.Item(tmpColId).ToString()
                                Case "recepteurCpVille"
                                    tmpObject.recepteurCpVille = tmpResults.Item(tmpColId).ToString()
                                Case "dateModificationAgent"
                                    tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                                Case "dateModificationCrodip"
                                    tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                            End Select
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    '##################################################################################################################

                    ' On récupère les items de la facture
                    Dim bddCommande2 As New OleDb.OleDbCommand
                    bddCommande2.Connection = oCSdb.getConnection()
                    bddCommande2.CommandText = "SELECT * FROM DiagnosticFactureItem WHERE DiagnosticFactureItem.idFacture='" & tmpObject.id & "'"
                    ' On récupère les résultats
                    Dim tmpListItems As System.Data.OleDb.OleDbDataReader = bddCommande2.ExecuteReader
                    ' Puis on les parcours
                    Dim i As Integer = 0
                    Dim tmpDiagnosticFactureItemsList As New DiagnosticFactureItemList
                    While tmpListItems.Read()
                        Dim tmpItem As New DiagnosticFactureItem
                        ' On rempli notre tableau
                        tmpColId = 0
                        While tmpColId < tmpListItems.FieldCount()
                            Select Case tmpListItems.GetName(tmpColId)
                                Case "id"
                                    tmpItem.id = tmpListItems.Item(tmpColId).ToString()
                                Case "idFacture"
                                    tmpItem.idFacture = tmpListItems.Item(tmpColId).ToString()
                                Case "libelle"
                                    tmpItem.libelle = tmpListItems.Item(tmpColId).ToString()
                                Case "prixUnitaire"
                                    tmpItem.prixUnitaire = tmpListItems.Item(tmpColId).ToString()
                                Case "qte"
                                    tmpItem.qte = tmpListItems.Item(tmpColId).ToString()
                                Case "tva"
                                    tmpItem.tva = tmpListItems.Item(tmpColId).ToString()
                                Case "prixTotal"
                                    tmpItem.prixTotal = tmpListItems.Item(tmpColId).ToString()
                                Case "dateModificationCrodip"
                                    tmpItem.dateModificationCrodip = CSDate.ToCRODIPString(tmpListItems.Item(tmpColId).ToString())
                                Case "dateModificationAgent"
                                    tmpItem.dateModificationAgent = CSDate.ToCRODIPString(tmpListItems.Item(tmpColId).ToString())
                            End Select
                            tmpColId = tmpColId + 1
                        End While
                        If tmpDiagnosticFactureItemsList.diagnosticFactureItem Is Nothing Then
                            ReDim Preserve tmpDiagnosticFactureItemsList.diagnosticFactureItem(0)
                        End If
                        tmpDiagnosticFactureItemsList.diagnosticFactureItem(i) = tmpItem
                        i = i + 1
                        ReDim Preserve tmpDiagnosticFactureItemsList.diagnosticFactureItem(i)
                    End While
                    ReDim Preserve tmpDiagnosticFactureItemsList.diagnosticFactureItem(i - 1)
                    ' On ajoute les item a la facture
                    tmpObject.diagnosticFactureItems = tmpDiagnosticFactureItemsList
                    ' Test pour fermeture de connection BDD
                    tmpListItems.Close()
                End While
                tmpResults.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("Erreur - DiagnosticFactureManager - getDiagnosticFactureById : " & ex.Message)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCSdb Is Nothing Then
                ' On ferme la connexion
                oCSdb.free()
            End If

        End If

        'on retourne le client ou un objet vide en cas d'erreur
        Return tmpObject
    End Function

    Public Function getNewId() As String
        ' déclarations
        Dim tmpObjectId As String = agentCourant.idStructure & "-" & agentCourant.id & "-1"
        If agentCourant.idStructure <> 0 Then

            Try
                ' On récupère les résultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT `id` FROM `DiagnosticFacture` WHERE `id` LIKE '" & agentCourant.idStructure & "-" & agentCourant.id & "-%' ORDER BY `id` DESC")
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(agentCourant.idStructure & "-" & agentCourant.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = agentCourant.idStructure & "-" & agentCourant.id & "-" & (newId + 1)
                bdd.free()
            Catch ex As Exception ' On intercepte l'erreur
                Console.Write("DiagnosticFactureManager - newId : " & ex.Message & vbNewLine)
            End Try

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    '
    Public Function getNewReference(pAgent As Agent) As String
        ' déclarations
        Dim tmpObjectIdBase As String = "FA" & Format(Date.Now, "yyyy") & pAgent.numeroNational
        Dim tmpObjectId As String = tmpObjectIdBase & "000001"
        If pAgent.idStructure <> 0 Then

            Try
                ' On récupère les résultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT `factureReference` FROM `DiagnosticFacture` WHERE `factureReference` LIKE '" & tmpObjectIdBase & "%' ORDER BY `factureReference` DESC")
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(tmpObjectIdBase, ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = (newId + 1)
                tmpObjectId = tmpObjectIdBase & New String("0", 6 - tmpObjectId.Length) & tmpObjectId
                bdd.free()
            Catch ex As Exception ' On intercepte l'erreur
                Console.Write("DiagnosticFactureManager - getNewReference : " & ex.Message & vbNewLine)
            End Try

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    ' Recupère toutes les factures non synchronisé (dateModificationAgent / dateModificationCrodip) 
    Public Function getUpdates(ByVal agent As Agent)

        ' déclarations
        Dim arrItems(0) As DiagnosticFacture
        Dim bddCommande As New OleDb.OleDbCommand
        Dim oCSsb As New CSDb(True)
        ' On test si la connexion est déjà ouverte ou non
        bddCommande.Connection = oCSsb.getConnection()
        bddCommande.CommandText = "SELECT * FROM `DiagnosticFacture` WHERE `DiagnosticFacture`.`dateModificationAgent`<>`DiagnosticFacture`.`dateModificationCrodip` AND `DiagnosticFacture`.`inspecteurId`=" & agent.id

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpObject As New DiagnosticFacture
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    Select Case tmpListProfils.GetName(tmpColId)
                        Case "id"
                            tmpObject = DiagnosticFactureManager.getDiagnosticFactureById(tmpListProfils.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '##################################################################################################################

                'On ajoute notre facture aux résultats
                arrItems(i) = tmpObject
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("DiagnosticFactureManager.getUpdates : " & ex.Message)
            ReDim arrItems(0)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSsb Is Nothing Then
            ' On ferme la connexion
            oCSsb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems

    End Function

    ' OK
    Private Function createDiagnosticFacture(ByVal diagnostic_id As String)
        Try
            Dim oCSDB As New CSDb(True)
            Dim bddCommande As New OleDb.OleDbCommand
            ' On test si la connexion est déjà ouverte ou non
            bddCommande.Connection = oCSDB.getConnection()

            ' Création
            bddCommande.CommandText = "INSERT INTO `DiagnosticFacture` (`id`) VALUES ('" & diagnostic_id & "')"
            bddCommande.ExecuteNonQuery()

            ' Test pour fermeture de connection BDD
            oCSDB.free()
        Catch ex As Exception
            MsgBox("DiagnosticFactureManager error : " & ex.Message)
        End Try
    End Function

    ' TODO : SAVE DES ITEM EN MEME TEMPS
    Public Sub save(ByVal curObject As DiagnosticFacture, Optional bSyncro As Boolean = False)

        Dim oCSDB As New CSDb(True)
        Try
            If curObject.id <> "" Then


                ' On test si le Diagnostic existe ou non
                Dim existsDiagnostic As Object
                existsDiagnostic = DiagnosticFactureManager.getDiagnosticFactureById(curObject.id)
                If existsDiagnostic.id = "" Then
                    ' Si il n'existe pas, on le crée
                    createDiagnosticFacture(curObject.id)
                End If

                Dim bddCommande As New OleDb.OleDbCommand
                ' On test si la connexion est déjà ouverte ou non
                bddCommande.Connection = oCSDB.getConnection()

                ' Initialisation de la requete
                Dim paramsQuery As String = "`DiagnosticFacture`.`id`='" & curObject.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSyncro Then
                    curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not curObject.factureReference Is Nothing Then
                    paramsQuery = paramsQuery & " , `factureReference`='" & oCSDB.secureString(curObject.factureReference) & "'"
                End If
                If Not curObject.factureDate Is Nothing Then
                    paramsQuery = paramsQuery & " , `factureDate`='" & oCSDB.secureString(curObject.factureDate) & "'"
                End If
                If Not curObject.factureTotal Is Nothing Then
                    paramsQuery = paramsQuery & " , `factureTotal`='" & oCSDB.secureString(curObject.factureTotal) & "'"
                End If
                If Not curObject.emetteurOrganisme Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganisme`='" & oCSDB.secureString(curObject.emetteurOrganisme) & "'"
                End If
                If Not curObject.emetteurOrganismeAdresse Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeAdresse`='" & oCSDB.secureString(curObject.emetteurOrganismeAdresse) & "'"
                End If
                If Not curObject.emetteurOrganismeCpVille Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeCpVille`='" & oCSDB.secureString(curObject.emetteurOrganismeCpVille) & "'"
                End If
                If Not curObject.emetteurOrganismeTelFax Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeTelFax`='" & oCSDB.secureString(curObject.emetteurOrganismeTelFax) & "'"
                End If
                If Not curObject.emetteurOrganismeSiren Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeSiren`='" & oCSDB.secureString(curObject.emetteurOrganismeSiren) & "'"
                End If
                If Not curObject.emetteurOrganismeTva Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeTva`='" & oCSDB.secureString(curObject.emetteurOrganismeTva) & "'"
                End If
                If Not curObject.emetteurOrganismeRcs Is Nothing Then
                    paramsQuery = paramsQuery & " , `emetteurOrganismeRcs`='" & oCSDB.secureString(curObject.emetteurOrganismeRcs) & "'"
                End If
                If Not curObject.recepteurRaisonSociale Is Nothing Then
                    paramsQuery = paramsQuery & " , `recepteurRaisonSociale`='" & oCSDB.secureString(curObject.recepteurRaisonSociale) & "'"
                End If
                If Not curObject.recepteurProprio Is Nothing Then
                    paramsQuery = paramsQuery & " , `recepteurProprio`='" & oCSDB.secureString(curObject.recepteurProprio) & "'"
                End If
                If Not curObject.recepteurCpVille Is Nothing Then
                    paramsQuery = paramsQuery & " , `recepteurCpVille`='" & oCSDB.secureString(curObject.recepteurCpVille) & "'"
                End If
                If Not curObject.dateModificationAgent Is Nothing Then
                    paramsQuery = paramsQuery & " , `dateModificationAgent`='" & oCSDB.secureString(curObject.dateModificationAgent) & "'"
                End If
                If Not curObject.dateModificationCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , `dateModificationCrodip`='" & oCSDB.secureString(curObject.dateModificationCrodip) & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE `DiagnosticFacture` SET " & paramsQuery & " WHERE `DiagnosticFacture`.`id`='" & curObject.id & "'"
                CSDebug.dispInfo("DiagnosticFactureManager::save (query) : " & bddCommande.CommandText)
                bddCommande.ExecuteNonQuery()

                ' On enregistre les items de la facture
                If Not curObject.diagnosticFactureItems Is Nothing Then
                    If Not curObject.diagnosticFactureItems.diagnosticFactureItem Is Nothing Then
                        Dim i As Integer = 0
                        For Each tmpItemCheck As DiagnosticFactureItem In curObject.diagnosticFactureItems.diagnosticFactureItem
                            If Not tmpItemCheck Is Nothing Then
                                'Dim tmpNewDiagItemId As String = DiagnosticFactureItemManager.getNewId(agentCourant.idStructure)
                                'tmpItemCheck.id = tmpNewDiagItemId
                                'tmpItemCheck.idFacture = curObject.id
                                'DiagnosticFactureItemManager.save(tmpItemCheck)
                            End If
                            i = i + 1
                        Next
                    End If
                End If

            End If
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticFactureManager(" & curObject.id & ")::save : " & ex.Message.ToString)
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
    End Sub

    ' OK
    Public Function setSynchro(ByVal objDiagnostic As DiagnosticFacture)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `DiagnosticFacture` SET `DiagnosticFacture`.`dateModificationCrodip`='" & newDate & "',`DiagnosticFacture`.`dateModificationAgent`='" & newDate & "' WHERE `DiagnosticFacture`.`id`='" & objDiagnostic.id & "'"
            dbLink.getResults()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticFactureManager::setSynchro : " & ex.Message)
        End Try
    End Function

#End Region

End Module
