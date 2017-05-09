Public Class AgentManager

#Region "Methodes acces Web Service"

    ' Methode OK
    Public Shared Function getWSAgentById(ByVal agent_id As String) As Agent
        Dim objAgent As New Agent
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetAgent(agent_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    '                    SynchronisationManager.LogSynchroElmt(objWSCrodip_response)
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If Not String.IsNullOrEmpty(objWSCrodip_responseItem.InnerText()) Then
                            objAgent.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    objAgent.id = -1
                    CSDebug.dispError("Erreur - AgentManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    objAgent.id = -1
                    CSDebug.dispError("Erreur - AgentManager - Code 9 : Bad Request")
                Case 3
                    objAgent.id = -1
                    CSDebug.dispError("Erreur - AgentManager - Code 3 : Pas de mise à jour")
            End Select
            ''' TODO pour test MCO
            '           objWSCrodip.sendWSAgent(objWSCrodip_response, Nothing)
        Catch ex As Exception
            CSDebug.dispError("AgentManager - getWSAgentById : " & ex.Message)
            objAgent = New Agent
        End Try
        Return objAgent

    End Function

    ' Methode OK
    Public Shared Function sendWSAgent(ByVal agent As Agent, ByRef updatedObject As Object)
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendAgent(agent, updatedObject)
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager::sendWSAgent : " & ex.Message)
            Return -1
        End Try
    End Function
    Public Shared Function sendWSAgent2(ByVal agent As Agent, ByRef updatedObject As Object)
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            '            Return objWSCrodip.SendAgent2(agent, updatedObject)
            '            Return objWSCrodip.SendAgent2(agent.id, agent.numeroNational, agent.motDePasse, agent.nom, agent.prenom, agent.idStructure, agent.telephonePortable, agent.eMail, agent.statut, "", agent.dateCreation, agent.dateDerniereConnexion, agent.dateDerniereSynchro, agent.dateModificationCrodip, agent.dateModificationAgent, agent.versionLogiciel, agent.commentaire, agent.cleActivation, agent.isActif, Nothing)

        Catch ex As Exception
            CSDebug.dispFatal("AgentManager::sendWSAgent : " & ex.Message)
            Console.WriteLine(ex.InnerException.Message)
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As Agent
        Dim objAgent As New Agent

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
                objAgent.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
            End If
        Next

        Return objAgent
    End Function

    ' Methode NOK
    'Public Shared Function getWSUpdates(ByVal agent_id As String, ByVal lastUpdateDateTime As String) As Object
    '    Dim objWSCrodip_response As Object
    '    Try
    '        ' déclarations
    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
    '        ' Appel au WS
    '        Dim isUpdateAvailable As Integer
    '        Dim isComplete As Integer
    '        objWSCrodip.UpdatesAvailable(agent_id, lastUpdateDateTime, isUpdateAvailable, isComplete, objWSCrodip_response)
    '    Catch ex As Exception
    '        'Return False
    '        objWSCrodip_response = -1
    '        CSDebug.dispFatal("AgentManager - getWSUpdates : " & ex.Message.ToString)
    '    End Try
    '    Return objWSCrodip_response
    'End Function

    'Public Shared Function setDateSynchroAgent(ByVal agent As Agent)
    '    Try
    '        ' déclarations
    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
    '        ' Appel au WS
    '        objWSCrodip.SetDateSynchroAgent(agent.id, CSDate.access2mysql(agent.dateDerniereSynchro))
    '    Catch ex As Exception
    '        CSDebug.dispFatal("AgentManager - setDateSynchroAgent : " & ex.Message.ToString)
    '    End Try
    'End Function

    'Public Shared Function updateDateSynchroAgent2(ByVal agent As Agent)
    '    Try
    '        ' déclarations
    '        Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
    '        ' Appel au WS
    '        Dim synchroDateTime As Object
    '        objWSCrodip.GetSynchroDateTime(synchroDateTime)
    '        agent.dateDerniereSynchro = synchroDateTime(0).InnerText()
    '    Catch ex As Exception
    '        CSDebug.dispFatal("AgentManager - setDateSynchroAgent : " & ex.Message.ToString)
    '    End Try
    '    Return agent
    'End Function

#End Region

#Region "Methodes acces Local"

    ''' <summary>
    ''' renvoie une liste d'agent
    ''' </summary>
    ''' <returns> Une Liste d'agent List(Of Agent) </returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentList() As AgentList
        ' déclarations
        Dim tmpAgent As New Agent
        Dim oCsDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim strSQL As String
        Dim oReturn As New AgentList()
        Dim objAgent As Agent
        Dim tmpColId As Integer

        Try
            oCsDb = New CSDb(True)

            bddCommande = oCsDb.getConnection().CreateCommand()
            strSQL = "SELECT Agent.id as id,"
            strSQL = strSQL & "Agent.numeronational as numeroNational, "
            strSQL = strSQL & "Agent.motDePasse as motDePasse, "
            strSQL = strSQL & "Agent.nom as nom, "
            strSQL = strSQL & "Agent.prenom as prenom, "
            strSQL = strSQL & "Agent.idStructure as idStructure, "
            strSQL = strSQL & "Agent.telephonePortable as telephonePortable, "
            strSQL = strSQL & "Agent.eMail as eMail, "
            strSQL = strSQL & "Agent.statut as statut, "
            strSQL = strSQL & "Agent.dateCreation as dateCreation, "
            strSQL = strSQL & "Agent.dateDerniereConnexion as dateDerniereConnexion, "
            strSQL = strSQL & "Agent.dateDerniereSynchro as dateDerniereSynchro, "
            strSQL = strSQL & "Agent.dateModificationAgent as dateModificationAgent, "
            strSQL = strSQL & "Agent.dateModificationCrodip as dateModificationCrodip, "
            strSQL = strSQL & "Agent.versionLogiciel as versionLogiciel, "
            strSQL = strSQL & "Agent.commentaire as commentaire, "
            strSQL = strSQL & "Agent.cleActivation as cleActivation, "
            strSQL = strSQL & "Agent.isActif as isActif, "
            strSQL = strSQL & "Agent.DroitsPulves as DroitsPulves, "
            strSQL = strSQL & "Structure.nom as structureNom "
            strSQL = strSQL & "FROM Agent LEFT JOIN Structure ON ( Agent.idStructure = Structure.id )"
            bddCommande.CommandText = strSQL
            ' On récupère les résultats
            Dim dataListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While dataListProfils.Read()
                ' On rempli notre tableau
                objAgent = New Agent
                tmpColId = 0
                While tmpColId < dataListProfils.FieldCount()
                    If Not dataListProfils.IsDBNull(tmpColId) Then
                        objAgent.Fill(dataListProfils.GetName(tmpColId), dataListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1

                End While
                oReturn.items.Add(objAgent)
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("AgentManager - getListAgent() Erreur : " & ex.Message)
        End Try
        If Not oCsDb Is Nothing Then
            oCsDb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return oReturn
    End Function
    ''' <summary>
    ''' renvoie un agent a partir de son Id
    ''' </summary>
    ''' <param name="pAgentID"> numéro national</param>
    ''' <returns> une instance de Agent, Agent.is = 0 si non trouvé</returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentById(ByVal pAgentID As Integer)
        ' déclarations
        Dim tmpAgent As New Agent
        Dim oCsDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand

        oCsDb = New CSDb(True)

        bddCommande = oCsDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Agent WHERE Agent.id=" & pAgentID & ""
        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpAgent.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("AgentManager - getAgentById(" & pAgentID & ") Erreur : " & ex.Message)
        End Try
        If Not oCsDb Is Nothing Then
            oCsDb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return tmpAgent
    End Function
    ' Methode OK
    ''' <summary>
    ''' renvoie un agent a partir de son numéro national
    ''' </summary>
    ''' <param name="pNumeroNational"> numéro national</param>
    ''' <returns> une instance de Agent, Agent.is = 0 si non trouvé</returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentByNumeroNational(ByVal pNumeroNational As String)
        ' déclarations
        Dim tmpAgent As New Agent
        Dim oCsDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand

        If pNumeroNational <> "" Then
            oCsDb = New CSDb(True)

            bddCommande = oCsDb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM Agent WHERE Agent.numeroNational='" & pNumeroNational & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpAgent.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                End While
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("AgentManager - getAgentByNumeroNational(" & pNumeroNational & ") Erreur : " & ex.Message)
            End Try
        End If
        If Not oCsDb Is Nothing Then
            oCsDb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return tmpAgent
    End Function

    ' Methode OK
    Public Shared Function createAgent(ByVal id As Integer, ByVal pNumeronational As String, ByVal pNom As String) As Agent
        Debug.Assert(Not String.IsNullOrEmpty(pNumeronational), " le paramètre NumeroNational doit être initialisé")
        Dim oCsdb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim oAgent As Agent
        Dim AgentID As Integer
        Dim oReader As OleDb.OleDbDataReader

        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()


            ' Création
            bddCommande.CommandText = "INSERT INTO Agent (id,numeroNational, nom) VALUES (" & id & ",'" & pNumeronational & "', '" & pNom & "')"
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oAgent = getAgentByNumeroNational(pNumeronational)
            oAgent.nom = pNom

        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.createAgent() : " & ex.Message)
            oAgent = Nothing
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return oAgent
    End Function
    ''' <summary>
    ''' Suppression d'un agent et de TOUS les élements
    ''' </summary>
    ''' <param name="pAgentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function delete(ByVal pAgentID As Integer) As Boolean
        Debug.Assert(pAgentID > 0, " le paramètre AgentID doit être initialisé")
        CSDebug.dispError("Suppression de l'agent " & pAgentID)
        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Dim oAgent As Agent
        Try
            oAgent = getAgentById(pAgentID)
            'on ne supprime pas d'element , uniquement si l'agent est le dernier de la base
            'If oAgent.id = pAgentID Then
            '    bReturn = oAgent.deleteSubItems()
            'End If


            oCSDb = New CSDb(True)

            bddCommande = oCSDb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM Agent WHERE Agent.id=" & pAgentID.ToString() & ""
            nResult = bddCommande.ExecuteNonQuery()
            oCSDb.free()

            oCSDb = New CSDb(True)
            bReturn = True
            'Vérification s'il reste des agents dans la structure
            nResult = oCSDb.getValue("SELECT count(*) FROM AGENT")
            CSDebug.dispInfo("Il reste " & nResult & " Agents")
            If nResult = 0 Then
                bReturn = oCSDb.RAZ_BASE_DONNEES()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.delete (" & pAgentID.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'delete
    ' Methode OK
    Public Shared Function save(ByVal agent As Agent, Optional bSynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(agent.numeroNational), "Agent.Numeronational doit être initialisé")

        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean
        Dim nResult As Integer

        Try
            bReturn = False
            If agent.isSupprime Then
                bReturn = delete(agent.id)

            Else
                If agent.numeroNational <> "" Then

                    oCSDb = New CSDb(True)

                    bddCommande = oCSDb.getConnection.CreateCommand()

                    Dim paramsQuery As String
                    paramsQuery = ""

                    ' Mise a jour de la date de derniere modification
                    If Not bSynchro Then
                        agent.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                    End If

                    paramsQuery = paramsQuery & " `Agent`.`id`=" & agent.id
                    If Not agent.numeroNational Is Nothing Then
                        paramsQuery = paramsQuery & ", `Agent`.`numeroNational`='" & oCSDb.secureString(agent.numeroNational) & "'"
                    End If
                    If Not agent.motDePasse Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`motDePasse`='" & oCSDb.secureString(agent.motDePasse) & "'"
                    End If
                    If Not agent.nom Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`nom`='" & oCSDb.secureString(agent.nom) & "'"
                    End If
                    If Not agent.prenom Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`prenom`='" & oCSDb.secureString(agent.prenom) & "'"
                    End If
                    paramsQuery = paramsQuery & " , `Agent`.`idStructure`=" & agent.idStructure & ""
                    If Not agent.telephonePortable Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`telephonePortable`='" & oCSDb.secureString(agent.telephonePortable) & "'"
                    End If
                    If Not agent.eMail Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`eMail`='" & oCSDb.secureString(agent.eMail) & "'"
                    End If
                    If Not agent.statut Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`statut`='" & oCSDb.secureString(agent.statut) & "'"
                    End If
                    If Not agent.dateCreation Is Nothing And agent.dateCreation <> "0000-00-00 00:00:00" Then
                        paramsQuery = paramsQuery & " , `Agent`.`dateCreation`='" & CSDate.mysql2access(agent.dateCreation) & "'"
                    End If
                    If Not agent.dateDerniereConnexion Is Nothing And agent.dateDerniereConnexion <> "0000-00-00 00:00:00" Then
                        paramsQuery = paramsQuery & " , `Agent`.`dateDerniereConnexion`='" & CSDate.mysql2access(agent.dateDerniereConnexion) & "'"
                    End If
                    If Not agent.dateDerniereSynchro Is Nothing And agent.dateDerniereSynchro <> "0000-00-00 00:00:00" Then
                        paramsQuery = paramsQuery & " , `Agent`.`dateDerniereSynchro`='" & CSDate.mysql2access(agent.dateDerniereSynchro) & "'"
                    End If
                    If Not agent.dateModificationAgent Is Nothing And agent.dateModificationAgent <> "0000-00-00 00:00:00" Then
                        paramsQuery = paramsQuery & " , `Agent`.`dateModificationAgent`='" & CSDate.mysql2access(agent.dateModificationAgent) & "'"
                    End If
                    If Not agent.dateModificationCrodip Is Nothing And agent.dateModificationCrodip <> "0000-00-00 00:00:00" Then
                        paramsQuery = paramsQuery & " , `Agent`.`dateModificationCrodip`='" & CSDate.mysql2access(agent.dateModificationCrodip) & "'"
                    End If
                    If Not agent.versionLogiciel Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`versionLogiciel`='" & oCSDb.secureString(agent.versionLogiciel) & "'"
                    End If
                    If Not agent.commentaire Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`commentaire`='" & oCSDb.secureString(agent.commentaire) & "'"
                    End If
                    If Not agent.cleActivation Is Nothing Then
                        paramsQuery = paramsQuery & " , `Agent`.`cleActivation`='" & oCSDb.secureString(agent.cleActivation) & "'"
                    End If
                    paramsQuery = paramsQuery & " , `Agent`.`isActif`=" & agent.isActif & ""
                    paramsQuery = paramsQuery & " , `Agent`.`DroitsPulves`='" & agent.DroitsPulves & "'"
                    paramsQuery = paramsQuery & " , `Agent`.`isGestionnaire`=" & agent.isGestionnaire & ""

                    bddCommande.CommandText = "UPDATE `Agent` SET " & paramsQuery & " WHERE `Agent`.`numeroNational`='" & agent.numeroNational & "'"
                    nResult = bddCommande.ExecuteNonQuery()
                    Debug.Assert(nResult = 1, "AgentManager.save: Erreur en update 0 ou  plus d'une ligne concernée")
                    bReturn = True
                End If
            End If
        Catch ex As Exception
            CSDebug.dispFatal("Err AgentManager - save : " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function

    Public Shared Function setSynchro(ByVal agent As Agent)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `Agent` SET `Agent`.`dateModificationCrodip`='" & CSDate.ToCRODIPString(newDate) & "',`Agent`.`dateModificationAgent`='" & CSDate.ToCRODIPString(newDate) & "' WHERE `Agent`.`id`=" & agent.id & ""
            dbLink.getResults()
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager::setSynchro : " & ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getUpdates(ByVal agent As Agent) As Agent()
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand

        ' déclarations
        Dim arrItems(0) As Agent

        oCSDB = New CSDb(True)
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `Agent` WHERE `Agent`.`dateModificationAgent`<>`Agent`.`dateModificationCrodip` AND `Agent`.`id`=" & agent.id

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpAgent As New Agent
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpAgent.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpAgent
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - AgentManager - getResult : " & ex.Message)
        End Try

        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems

    End Function

#End Region


End Class
