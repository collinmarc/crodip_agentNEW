Imports System.Data.Common
Imports System.IO
Imports System.Xml.Serialization
Imports CRODIPWS

Public Class AgentManager
    Inherits RootManager
#Region "Methodes acces Web Service"
    'Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As Agent
    '    Dim oreturn As Agent
    '    oreturn = RootWSGetById(Of Agent)(p_uid, paid)
    '    Return oreturn
    'End Function

    Public Shared Function WSgetByNumeroNational(ByVal pIdProfileAgent As String, pbLoadPools As Boolean) As Agent
        Dim oreturn As Agent
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Try
            Dim tXmlnodes As Object
            Dim lstPools As Object
            '' d�clarations
            Dim typeT As Type = GetType(Agent)
            Dim nomMethode As String = "Get" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            Dim codeResponse As Integer = 99 'Mehode non trouv�e
            Dim pInfo As String = ""
            codeResponse = objWSCrodip.GetAgent(pIdProfileAgent, pInfo, tXmlnodes, lstPools)
            Select Case codeResponse
                Case 0, 4, 3 ' OK
                    Dim ser As New XmlSerializer(GetType(Agent))
                    Using reader As New StringReader(tXmlnodes(0).ParentNode.OuterXml)
                        oreturn = ser.Deserialize(reader)
                    End Using
                    If pbLoadPools Then
                        Dim Ser2 As New XmlSerializer(GetType(availablePools))
                        Dim nItems As Integer = lstPools.Length
                        For n As Integer = 0 To nItems - 1
                            Using reader As New StringReader(lstPools(n)(0).ParentNode.outerXml)
                                Dim oPoolAgent As PoolAgent
                                oPoolAgent = Ser2.Deserialize(reader)
                                PoolAgentManager.Save(oPoolAgent)
                                'Lecture du Pool en base ou en WS
                                Dim oPool As Pool
                                oPool = PoolManager.getPoolByuid(oPoolAgent.uidpool)
                                If oPool IsNot Nothing Then
                                    oreturn.oPool = oPool
                                Else
                                    oPool = PoolManager.WSgetById(oPoolAgent.uidpool, "")
                                    PoolManager.Save(oPool)
                                    oreturn.oPool = oPool
                                End If
                                'Dim lst As New List(Of AgentPc)
                                ''                                lst = AgentPcManager.WSgetlstByPoolId(oPool.uid)
                                'For Each oAgentPC In lst
                                '    AgentPcManager.Save(oAgentPC)
                                'Next
                            End Using
                        Next n
                    End If

                Case 1 ' NOK
                    CSDebug.dispError("AgentManager:WSGetByNumeroNational - Code 1 : Non-Trouv�e")
                Case 5 ' SERVICE DESACTIVE
                    CSDebug.dispError("AgentManager:WSGetByNumeroNational - Code 5 : Service D�sactiv�")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("AgentManager:WSGetByNumeroNational - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("AgentManager:WSGetByNumeroNational ERR : ", ex)
        Finally
        End Try
        Return oreturn


    End Function

    Public Shared Function getByKey(puid As Integer) As Agent
        Dim oReturn As Agent
        Try
            oReturn = getByuid(Of Agent)("Agent", puid)
        Catch ex As Exception
            CSDebug.dispError("AgentManager.GetByKey ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Shared Function WSSend(ByVal pAgentIn As Agent, ByRef pReturn As Agent) As Integer
        Dim oreturn As Agent = Nothing
        Dim codeResponse As Integer = 99
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Try
            Dim pInfo As String = ""
            Dim puid As Integer

            'Determination du Nom de la m�thode : exemple SendManometreControle
            Dim typeT As Type = GetType(Agent)
            Dim nomMethode As String = "Send" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            If methode IsNot Nothing Then
                'Invocation de la m�thode
                Dim serializer As New XmlSerializer(pAgentIn.GetType())
                Using writer As New StringWriter()
                    serializer.Serialize(writer, pAgentIn)
                    Dim xmlOutput As String = writer.ToString()
                    ' Vous pouvez maintenant v�rifier ou envoyer cette cha�ne s�rialis�e
                    'CSDebug.dispTrace("WS-" & nomMethode & " Param = [" & xmlOutput & "]")
                End Using

                Dim Params As Object() = {pAgentIn, pInfo}
                codeResponse = methode.Invoke(objWSCrodip, Params)
                pInfo = DirectCast(Params(1), String)
                '                puid = DirectCast(Params(2), Integer)
                'CSDebug.dispTrace("WS-" & nomMethode & " Return = codeReponse=" & codeResponse & "[ info=" & pInfo & ",uid=" & puid & "]")
            End If
            Select Case codeResponse
                Case 2 ' UPDATE OK
                    pReturn = WSgetByNumeroNational(pAgentIn.numeroNational, False)
                Case 4 ' CREATE OK
                    pReturn = WSgetByNumeroNational(pAgentIn.numeroNational, False)
                Case 1 ' NOK
                    CSDebug.dispError("SendWS - Code 1 : Erreur Base de donn�es Serveur")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
                Case 0 ' PAS DE MAJ
            End Select
        Catch ex As Exception
            CSDebug.dispError("RootManager - sendWS : ", ex)
        Finally
        End Try
        Return codeResponse
    End Function

    'Public Shared Function RESTlogin(pAgent As Agent) As Boolean
    '    Return RootManager.RESTConnect(pAgent)
    'End Function
    ' Methode OK
    'Public Shared Function getWSAgentById(ByVal agent_id As String) As Agent
    '    Dim objAgent As New Agent
    '    Try

    '        ' d�clarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        'Dim codeResponse As Integer = objWSCrodip.GetAgent(agent_id, objWSCrodip_response)
    '        Dim codeResponse As Integer
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                '                    SynchronisationManager.LogSynchroElmt(objWSCrodip_response)
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    If Not String.IsNullOrEmpty(objWSCrodip_responseItem.InnerText()) Then
    '                        objAgent.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
    '                    End If
    '                Next
    '            Case 1 ' NOK
    '                objAgent.id = -1
    '                CSDebug.dispError("Erreur - AgentManager - Code 1 : Non-Trouv�e")
    '            Case 9 ' BADREQUEST
    '                objAgent.id = -1
    '                CSDebug.dispError("Erreur - AgentManager - Code 9 : Bad Request")
    '            Case 3
    '                objAgent.id = -1
    '                CSDebug.dispError("Erreur - AgentManager - Code 3 : Pas de mise � jour")
    '        End Select
    '        ''' TODO pour test MCO
    '        '           objWSCrodip.sendWSAgent(objWSCrodip_response, Nothing)
    '    Catch ex As Exception
    '        CSDebug.dispError("AgentManager - getWSAgentById : " & ex.Message)
    '        objAgent = New Agent
    '    End Try
    '    Return objAgent

    'End Function

    ''test   
    ''Re test
    '' Methode OK
    'Public Shared Function sendWSAgent(ByVal agent As Agent, ByRef updatedObject As Object) As Integer
    '    Try
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Return objWSCrodip.SendAgent(agent, updatedObject)
    '    Catch ex As Exception
    '        CSDebug.dispFatal("AgentManager::sendWSAgent : " & ex.Message)
    '        Return -1
    '    End Try
    'End Function

    'Public Shared Function xml2object(ByVal arrXml As Object) As Agent
    '    Dim objAgent As New Agent

    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
    '            objAgent.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
    '        End If
    '    Next

    '    Return objAgent
    'End Function

    ' Methode NOK
    'Public Shared Function getWSUpdates(ByVal agent_id As String, ByVal lastUpdateDateTime As String) As Object
    '    Dim objWSCrodip_response As Object
    '    Try
    '        ' d�clarations
    '        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
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
    '        ' d�clarations
    '        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
    '        ' Appel au WS
    '        objWSCrodip.SetDateSynchroAgent(agent.id, CSDate.access2mysql(agent.dateDerniereSynchro))
    '    Catch ex As Exception
    '        CSDebug.dispFatal("AgentManager - setDateSynchroAgent : " & ex.Message.ToString)
    '    End Try
    'End Function

    'Public Shared Function updateDateSynchroAgent2(ByVal agent As Agent)
    '    Try
    '        ' d�clarations
    '        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
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
    ''' renvoie une liste d'agent pour une structure
    ''' </summary>
    ''' <returns> Une Liste d'agent List(Of Agent) </returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentList(pIdStructure As String) As AgentList
        ' d�clarations
        Dim tmpAgent As New Agent
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim strSQL As String
        Dim oReturn As New AgentList()
        Dim objAgent As Agent
        Dim tmpColId As Integer

        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection().CreateCommand()
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
            strSQL = strSQL & "Agent.droitsPulves as droitsPulves, "
            strSQL = strSQL & "Agent.isGestionnaire as isGestionnaire, "
            strSQL = strSQL & "Agent.signatureElect as signatureElect, "
            strSQL = strSQL & "Structure.nom as structureNom "
            strSQL = strSQL & "FROM Agent LEFT JOIN Structure ON ( Agent.idStructure = Structure.id ) "
            strSQL = strSQL & "WHERE  Agent.idStructure = " & pIdStructure
            bddCommande.CommandText = strSQL
            ' On r�cup�re les r�sultats
            Dim dataListProfils As DbDataReader = bddCommande.ExecuteReader
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return oReturn
    End Function
    ''' <summary>
    ''' renvoie une liste d'agent pour un Pool
    ''' </summary>
    ''' <returns> Une Liste d'agent List(Of Agent) </returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentListByPool(puidPool As Integer) As AgentList
        ' d�clarations
        Dim tmpAgent As New Agent
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim strSQL As String
        Dim oReturn As New AgentList()
        Dim objAgent As Agent
        Dim tmpColId As Integer

        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection().CreateCommand()
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
            strSQL = strSQL & "Agent.droitsPulves as droitsPulves, "
            strSQL = strSQL & "Agent.isGestionnaire as isGestionnaire, "
            strSQL = strSQL & "Agent.signatureElect as signatureElect, "
            strSQL = strSQL & "Structure.nom as structureNom "
            strSQL = strSQL & "FROM Agent LEFT JOIN PoolAgent ON ( PoolAgent.uidAgent = Agent.uid ) "
            strSQL = strSQL & "WHERE PoolAgent.uidPool = " & puidPool
            bddCommande.CommandText = strSQL
            ' On r�cup�re les r�sultats
            Dim dataListProfils As DbDataReader = bddCommande.ExecuteReader
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return oReturn
    End Function
    ''' <summary>
    ''' renvoie un agent a partir de son Id
    ''' </summary>
    ''' <param name="pAgentID"> num�ro national</param>
    ''' <returns> une instance de Agent, Agent.is = 0 si non trouv�</returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentById(ByVal pAgentID As Integer) As Agent
        ' d�clarations
        Dim tmpAgent As New Agent
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        oCsdb = New CSDb(True)

        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Agent WHERE Agent.id=" & pAgentID & ""
        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return tmpAgent
    End Function

    ' Methode OK
    ''' <summary>
    ''' renvoie un agent a partir de son num�ro national
    ''' </summary>
    ''' <param name="pNumeroNational"> num�ro national</param>
    ''' <returns> une instance de Agent, Agent.is = 0 si non trouv�</returns>
    ''' <remarks></remarks>
    Public Shared Function getAgentByNumeroNational(ByVal pNumeroNational As String) As Agent
        ' d�clarations
        Dim tmpAgent As New Agent
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As Common.DbCommand

        If pNumeroNational <> "" Then
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM Agent WHERE Agent.numeroNational='" & pNumeroNational & "'"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return tmpAgent
    End Function

    ''' <summary>
    ''' insertion d'un agent en base
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="pNumeronational"></param>
    ''' <param name="pNom"></param>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    Private Shared Sub createAgent(ByVal id As Integer, ByVal pNumeronational As String, ByVal pNom As String, pIdStructure As Integer, puidStructure As Integer)
        Debug.Assert(Not String.IsNullOrEmpty(pNumeronational), " le param�tre NumeroNational doit �tre initialis�")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()


            ' Cr�ation
            bddCommande.CommandText = "INSERT INTO Agent (id,numeroNational, nom, idStructure, uidstructure) VALUES (" & id & ",'" & pNumeronational & "', '" & pNom & "'," & pIdStructure & "," & puidStructure & " )"
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            'oAgent = getAgentByNumeroNational(pNumeronational)
            'oAgent.nom = pNom
            'oAgent.dateDerniereSynchro = "01/01/1970"
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.createAgent() : " & ex.Message)
            If Not oCsdb Is Nothing Then
                oCsdb.free()
            End If
        End Try
    End Sub
    ''' <summary>
    ''' Suppression d'un agent et de TOUS les �lements
    ''' </summary>
    ''' <param name="pAgentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function delete(ByVal pAgentID As Integer) As Boolean
        Debug.Assert(pAgentID > 0, " le param�tre AgentID doit �tre initialis�")
        CSDebug.dispError("Suppression de l'agent " & pAgentID)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Dim oAgent As Agent
        Try
            oAgent = getAgentById(pAgentID)
            'on ne supprime pas d'element , uniquement si l'agent est le dernier de la base
            'If oAgent.id = pAgentID Then
            '    bReturn = oAgent.deleteSubItems()
            'End If


            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM Agent WHERE Agent.id=" & pAgentID.ToString() & ""
            nResult = bddCommande.ExecuteNonQuery()
            oCsdb.free()

            oCsdb = New CSDb(True)
            bReturn = True
            'V�rification s'il reste des agents dans la structure
            nResult = oCsdb.getValue("SELECT count(*) FROM AGENT")
            CSDebug.dispInfo("Il reste " & nResult & " Agents")
            If nResult = 0 Then
                bReturn = oCsdb.RAZ_BASE_DONNEES()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager.delete (" & pAgentID.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete
    ' Methode OK
    Public Shared Function save(ByVal agent As Agent, Optional bSynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(agent.numeroNational), "Agent.Numeronational doit �tre initialis�")

        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim nResult As Integer

        Try
            bReturn = False
            If agent.isSupprime Then
                bReturn = delete(agent.id)

            Else

                oCsdb = New CSDb(True)

                bddCommande = oCsdb.getConnection.CreateCommand()
                bddCommande.CommandText = "SELECT count(*) From Agent WHERE numeroNational = '" & agent.numeroNational & "'"
                Dim nb As Integer = bddCommande.ExecuteScalar()
                If nb = 0 Then
                    oCsdb.free()
                    createAgent(agent.id, agent.numeroNational, agent.nom, agent.idStructure, agent.uidstructure)
                    oCsdb = New CSDb(True)
                    bddCommande = oCsdb.getConnection.CreateCommand()
                End If

                Dim paramsQuery As String
                paramsQuery = ""

                ' Mise a jour de la date de derniere modification
                If Not bSynchro Then
                    agent.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                paramsQuery = paramsQuery & " id=" & agent.id
                paramsQuery = paramsQuery & " ,uid=" & agent.uid
                paramsQuery = paramsQuery & " ,aid='" & agent.aid & "'"
                paramsQuery = paramsQuery & " ,idstructure=" & agent.idStructure
                paramsQuery = paramsQuery & " ,uidstructure=" & agent.uidstructure
                If Not agent.numeroNational Is Nothing Then
                    paramsQuery = paramsQuery & ", numeroNational='" & CSDb.secureString(agent.numeroNational) & "'"
                End If
                If Not agent.motDePasse Is Nothing Then
                    paramsQuery = paramsQuery & " , motDePasse='" & CSDb.secureString(agent.motDePasse) & "'"
                End If
                If Not agent.nom Is Nothing Then
                    paramsQuery = paramsQuery & " , nom='" & CSDb.secureString(agent.nom) & "'"
                End If
                If Not agent.prenom Is Nothing Then
                    paramsQuery = paramsQuery & " , prenom='" & CSDb.secureString(agent.prenom) & "'"
                End If
                If Not agent.telephonePortable Is Nothing Then
                    paramsQuery = paramsQuery & " , telephonePortable='" & CSDb.secureString(agent.telephonePortable) & "'"
                End If
                If Not agent.eMail Is Nothing Then
                    paramsQuery = paramsQuery & " , eMail='" & CSDb.secureString(agent.eMail) & "'"
                End If
                If Not agent.statut Is Nothing Then
                    paramsQuery = paramsQuery & " , statut='" & CSDb.secureString(agent.statut) & "'"
                End If
                If Not agent.dateCreation Is Nothing And agent.dateCreation <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , dateCreation='" & CSDate.ToCRODIPString(agent.dateCreation) & "'"
                End If
                If Not agent.dateDerniereConnexion Is Nothing And agent.dateDerniereConnexion <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , dateDerniereConnexion='" & CSDate.ToCRODIPString(agent.dateDerniereConnexion) & "'"
                End If
                If Not agent.dateDerniereSynchro <> DateTime.MinValue Then
                    paramsQuery = paramsQuery & " , dateDerniereSynchro='" & CSDate.ToCRODIPString(agent.dateDerniereSynchro) & "'"
                End If
                If Not agent.versionLogiciel Is Nothing Then
                    paramsQuery = paramsQuery & " , versionLogiciel='" & CSDb.secureString(agent.versionLogiciel) & "'"
                End If
                If Not agent.commentaire Is Nothing Then
                    paramsQuery = paramsQuery & " , commentaire='" & CSDb.secureString(agent.commentaire) & "'"
                End If
                If Not agent.cleActivation Is Nothing Then
                    paramsQuery = paramsQuery & " , cleActivation='" & CSDb.secureString(agent.cleActivation) & "'"
                End If
                paramsQuery = paramsQuery & " , isActif=" & agent.isActif & ""
                paramsQuery = paramsQuery & " , droitsPulves='" & agent.DroitsPulves & "'"
                paramsQuery = paramsQuery & " , isGestionnaire=" & agent.isGestionnaire & ""
                paramsQuery = paramsQuery & " , signatureElect=" & agent.isSignElecActive & ""
                paramsQuery = paramsQuery & " , signatureElect=" & agent.isSignElecActive & ""
                If agent.oPool IsNot Nothing Then
                    paramsQuery = paramsQuery & " , uidpool=" & agent.oPool.uid & ""
                End If
                If agent.oPCcourant IsNot Nothing Then
                    paramsQuery = paramsQuery & " , uidpc=" & agent.oPCcourant.uid & ""
                End If

                paramsQuery = paramsQuery & agent.getRootQuery()

                bddCommande.CommandText = "UPDATE Agent SET " & paramsQuery & " WHERE numeroNational='" & agent.numeroNational & "'"
                nResult = bddCommande.ExecuteNonQuery()
                Debug.Assert(nResult = 1, "AgentManager.save: Erreur en update 0 ou  plus d'une ligne concern�e")
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispFatal("Err AgentManager - save : " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal agent As Agent)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE Agent SET dateModificationCrodip='" & CSDate.ToCRODIPString(newDate) & "',dateModificationAgent='" & CSDate.ToCRODIPString(newDate) & "' WHERE id=" & agent.id & ""
            dbLink.Execute()
        Catch ex As Exception
            CSDebug.dispFatal("AgentManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getUpdates(ByVal agent As Agent) As Agent()
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        ' d�clarations
        Dim arrItems(0) As Agent

        oCsdb = New CSDb(True)
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Agent WHERE (dateModificationAgent>dateModificationCrodip Or dateModificationCrodip is null) AND isGestionnaire <>1 and isActif = 1 AND idStructure=" & agent.uidstructure

        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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

        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems

    End Function

#End Region


End Class
