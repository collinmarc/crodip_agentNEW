Imports System.Collections.Generic
Imports System.Data.Common

Public Class FVBancManager

#Region "Methodes Web Service"

    Public Shared Function getWSFVBancById(ByVal fvbanc_id As String) As Object
        Dim oAgentFictif As New Agent()
        Dim objFVBanc As New FVBanc(oAgentFictif)
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetFVBanc(agentCourant.id, fvbanc_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        objFVBanc.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("FVBancManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("FVBancManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("FVBancManager - getWSFVBancById : " & ex.Message)
        End Try
        Return objFVBanc

    End Function

    Public Shared Function sendWSFVBanc(ByVal fvbanc As FVBanc, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendFVBanc(agentCourant.id, fvbanc, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As FVBanc
        Dim oagent As New Agent()
        Dim objFVBanc As New FVBanc(oagent)

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    objFVBanc.id = CType(tmpSerializeItem.InnerText, String)
                Case "idBancMesure"
                    objFVBanc.idBancMesure = CType(tmpSerializeItem.InnerText, String)
                Case "type"
                    objFVBanc.type = CType(tmpSerializeItem.InnerText, String)
                Case "auteur"
                    objFVBanc.auteur = CType(tmpSerializeItem.InnerText, String)
                Case "idAgentControleur"
                    objFVBanc.idAgentControleur = CType(tmpSerializeItem.InnerText, Integer)
                Case "caracteristiques"
                    objFVBanc.caracteristiques = CType(tmpSerializeItem.InnerText, String)
                Case "dateModif"
                    objFVBanc.dateModif = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "blocage"
                    objFVBanc.blocage = CType(tmpSerializeItem.InnerText, Boolean)
                Case "pressionControle"
                    objFVBanc.pressionControle = CType(tmpSerializeItem.InnerText, String)
                Case "valeursMesurees"
                    objFVBanc.valeursMesurees = CType(tmpSerializeItem.InnerText, String)
                Case "idManometreControle"
                    objFVBanc.idManometreControle = CType(tmpSerializeItem.InnerText, String)
                Case "idBuseEtalon"
                    objFVBanc.idBuseEtalon = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    objFVBanc.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    objFVBanc.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return objFVBanc
    End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function save(ByVal objFVBanc As FVBanc, Optional bSyncro As Boolean = False) As Boolean

        Dim bReturn As Boolean
        Try
            If objFVBanc.id = "" Then
                objFVBanc.id = getNewId(objFVBanc.idAgentControleur)
            End If

            ' On test si l'object existe ou non
            Dim existsObject As FVBanc
            existsObject = FVBancManager.getFVBancById(objFVBanc.id)
            ' L'Id du FV baanc est initialisé , l'idbanc de mesure est laissé à blanc
            If existsObject.id = "" Then
                ' Si il n'existe pas, on le crée
                bReturn = insert(objFVBanc, bSyncro)
            Else
                bReturn = update(objFVBanc, bSyncro)
            End If

        Catch ex As Exception
            CSDebug.dispError("FVBancManager.Save(" & objFVBanc.id & ")" & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function

    Private Shared Function insert(ByVal objFVBanc As FVBanc, bSynchro As Boolean) As Boolean
        '        Dim paramsQueryUpdate As String
        Dim paramsQuery_col As String = ""
        Dim paramsQuery As String = ""
        Dim oCSDb As New CSDb(True)
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try

            ' Initialisation de la requete
            '           paramsQueryUpdate = "`id`='" & objFVBanc.id & "',`idBancMesure`='" & CSDb.secureString(objFVBanc.idBancMesure) & "'"
            paramsQuery_col = "`id`,`idBancMesure`"
            paramsQuery = "'" & objFVBanc.id & "' , '" & CSDb.secureString(objFVBanc.idBancMesure) & "'"

            ' Mise a jour de la date de derniere modification
            objFVBanc.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

            If Not objFVBanc.type Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`type`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.type) & "'"
                '              paramsQueryUpdate = paramsQueryUpdate & ",`type`='" & CSDb.secureString(objFVBanc.type) & "'"
            End If
            If Not objFVBanc.auteur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`auteur`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.auteur) & "'"
                '             paramsQueryUpdate = paramsQueryUpdate & ",`auteur`='" & CSDb.secureString(objFVBanc.auteur) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`idAgentControleur`"
            paramsQuery = paramsQuery & " , " & objFVBanc.idAgentControleur & ""
            '        paramsQueryUpdate = paramsQueryUpdate & ",`idAgentControleur`=" & CSDb.secureString(objFVBanc.idAgentControleur) & ""
            If Not objFVBanc.caracteristiques Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`caracteristiques`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.caracteristiques) & "'"
                '           paramsQueryUpdate = paramsQueryUpdate & ",`caracteristiques`='" & CSDb.secureString(objFVBanc.caracteristiques) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`blocage`"
            If objFVBanc.blocage = False Then
                paramsQuery = paramsQuery & " , " & "0" & ""
                '          paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString("0") & ""
            Else
                paramsQuery = paramsQuery & " , " & "1" & ""
                '         paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString("1") & ""
            End If
            If Not objFVBanc.pressionControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`pressionControle`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.pressionControle) & "'"
                '        paramsQueryUpdate = paramsQueryUpdate & ",`pressionControle`='" & CSDb.secureString(objFVBanc.pressionControle) & "'"
            End If
            If Not objFVBanc.valeursMesurees Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`valeursMesurees`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.valeursMesurees) & "'"
                '       paramsQueryUpdate = paramsQueryUpdate & ",`valeursMesurees`='" & CSDb.secureString(objFVBanc.valeursMesurees) & "'"
            End If
            If Not objFVBanc.idManometreControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idManometreControle`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.idManometreControle) & "'"
                '      paramsQueryUpdate = paramsQueryUpdate & ",`idManometreControle`='" & CSDb.secureString(objFVBanc.idManometreControle) & "'"
            End If
            If Not objFVBanc.idBuseEtalon Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idBuseEtalon`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.idBuseEtalon) & "'"
                '     paramsQueryUpdate = paramsQueryUpdate & ",`idBuseEtalon`='" & CSDb.secureString(objFVBanc.idBuseEtalon) & "'"
            End If
            If Not objFVBanc.dateModif Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`dateModif`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.dateModif) & "'"
                '    paramsQueryUpdate = paramsQueryUpdate & ",`dateModif`='" & CSDb.secureString(objFVBanc.dateModif) & "'"
            End If
            If Not objFVBanc.dateModificationAgent Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`dateModificationAgent`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVBanc.dateModificationAgent) & "'"
                '   paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationAgent`='" & CSDb.secureString(objFVBanc.dateModificationAgent) & "'"
            End If
            If Not objFVBanc.dateModificationCrodip Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`dateModificationCrodip`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVBanc.dateModificationCrodip) & "'"
                '  paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & CSDb.secureString(objFVBanc.dateModificationCrodip) & "'"
            End If
            If Not objFVBanc.FVFileName Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`FVFileName`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.FVFileName) & "'"
                '  paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & CSDb.secureString(objFVBanc.dateModificationCrodip) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande = oCSDb.getConnection().CreateCommand
            bddCommande.CommandText = "INSERT INTO `FichevieBancMesure` (" & paramsQuery_col & ") VALUES (" & paramsQuery & ")"
            bddCommande.ExecuteNonQuery()
            oCSDb.free()
            bReturn = True

        Catch ex As Exception
            CSDebug.dispFatal("Err FVBancManager - insert : [" & paramsQuery_col & "," & paramsQuery & "]:" & ex.Message)
            oCSDb.free()
            bReturn = False
        End Try
        Return bReturn

    End Function
    Private Shared Function update(ByVal objFVBanc As FVBanc, Optional bSyncro As Boolean = False) As Boolean
        Dim paramsQueryUpdate As String = ""
        '        Dim paramsQuery_col As String
        '        Dim paramsQuery As String
        Dim CSDb As New CSDb(True)
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try

            ' Initialisation de la requete
            paramsQueryUpdate = "`id`='" & objFVBanc.id & "',`idBancMesure`='" & CSDb.secureString(objFVBanc.idBancMesure) & "'"
            '           paramsQuery_col = "`id`,`idBancMesure`"
            '          paramsQuery = "'" & objFVBanc.id & "' , '" & CSDb.secureString(objFVBanc.idBancMesure) & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSyncro Then
                objFVBanc.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not objFVBanc.type Is Nothing Then
                '    paramsQuery_col = paramsQuery_col & ",`type`"
                '   paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.type) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`type`='" & CSDb.secureString(objFVBanc.type) & "'"
            End If
            If Not objFVBanc.auteur Is Nothing Then
                '  paramsQuery_col = paramsQuery_col & ",`auteur`"
                ' paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.auteur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`auteur`='" & CSDb.secureString(objFVBanc.auteur) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",`idAgentControleur`"
            'paramsQuery = paramsQuery & " , " & objFVBanc.idAgentControleur & ""
            paramsQueryUpdate = paramsQueryUpdate & ",`idAgentControleur`=" & CSDb.secureString(objFVBanc.idAgentControleur) & ""
            If Not objFVBanc.caracteristiques Is Nothing Then
                '   paramsQuery_col = paramsQuery_col & ",`caracteristiques`"
                '  paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.caracteristiques) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`caracteristiques`='" & CSDb.secureString(objFVBanc.caracteristiques) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",`blocage`"
            If objFVBanc.blocage = False Then
                '   paramsQuery = paramsQuery & " , " & "0" & ""
                paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString("0") & ""
            Else
                '  paramsQuery = paramsQuery & " , " & "1" & ""
                paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString("1") & ""
            End If
            If Not objFVBanc.pressionControle Is Nothing Then
                ' paramsQuery_col = paramsQuery_col & ",`pressionControle`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.pressionControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`pressionControle`='" & CSDb.secureString(objFVBanc.pressionControle) & "'"
            End If
            If Not objFVBanc.valeursMesurees Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`valeursMesurees`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.valeursMesurees) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`valeursMesurees`='" & CSDb.secureString(objFVBanc.valeursMesurees) & "'"
            End If
            If Not objFVBanc.idManometreControle Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`idManometreControle`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.idManometreControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idManometreControle`='" & CSDb.secureString(objFVBanc.idManometreControle) & "'"
            End If
            If Not objFVBanc.idBuseEtalon Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`idBuseEtalon`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.idBuseEtalon) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idBuseEtalon`='" & CSDb.secureString(objFVBanc.idBuseEtalon) & "'"
            End If
            If Not objFVBanc.dateModif Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`dateModif`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(objFVBanc.dateModif) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModif`='" & CSDb.secureString(objFVBanc.dateModif) & "'"
            End If
            If Not objFVBanc.dateModificationAgent Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`dateModificationAgent`"
                'paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVBanc.dateModificationAgent) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationAgent`='" & CSDb.secureString(objFVBanc.dateModificationAgent) & "'"
            End If
            If Not objFVBanc.dateModificationCrodip Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`dateModificationCrodip`"
                'paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVBanc.dateModificationCrodip) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & CSDb.secureString(objFVBanc.dateModificationCrodip) & "'"
            End If
            If Not objFVBanc.FVFileName Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`FVFileName`"
                'paramsQuery = paramsQuery & " , '" & objFVBanc.FVFileName & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`FVFileName`='" & CSDb.secureString(objFVBanc.FVFileName) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande = CSDb.getConnection().CreateCommand()
            bddCommande.CommandText = "UPDATE `FichevieBancMesure` SET " & paramsQueryUpdate & " WHERE `FichevieBancMesure`.`id`='" & objFVBanc.id & "'"
            bddCommande.ExecuteNonQuery()
            CSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Err FVBancManager - update: [" & paramsQueryUpdate & "]:" & ex.Message)
            CSDb.free()
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function delete(ByVal pId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pId), " le paramètre ID doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM FicheVieBancMesure WHERE FicheVieBancMesure.id='" & pId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("FVBancManager.delete (" & pId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

    Private Shared Function getNewId(ByVal pIdAgent As String) As String
        ' déclarations
        Dim oAgent As Agent
        Dim tmpObjectId As String = ""
        oAgent = AgentManager.getAgentById(pIdAgent)
        If oAgent.id = pIdAgent Then
            If oAgent.idStructure <> 0 Then
                Dim bdd As New CSDb(True)

                Try
                    ' On récupère les résultats
                    Dim oDataReader As DbDataReader = bdd.getResult2s("SELECT `id` FROM `FichevieBancMesure` WHERE `id` LIKE '" & oAgent.idStructure & "-" & oAgent.id & "-%' ORDER BY `id` DESC")
                    ' Puis on les parcours
                    Dim newId As Integer = 0
                    While oDataReader.Read()
                        ' On récupère le dernier ID
                        Dim tmpId As Integer = 0
                        tmpObjectId = oDataReader.Item(0).ToString
                        Dim tab As String() = tmpObjectId.Split("-")
                        tmpId = CInt(tab(2))
                        If tmpId > newId Then
                            newId = tmpId
                        End If
                    End While
                    oDataReader.Close()
                    newId = newId + 1
                    tmpObjectId = oAgent.idStructure & "-" & oAgent.id & "-" & (newId + 1)
                Catch ex As Exception ' On intercepte l'erreur
                    CSDebug.dispError("FVBancManager.getnewId ERR : " & ex.Message)
                End Try

                bdd.free()

            End If
        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Sub setSynchro(ByVal objFVBanc As FVBanc)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `FichevieBancMesure` SET `FichevieBancMesure`.`dateModificationCrodip`='" & newDate & "',`FichevieBancMesure`.`dateModificationAgent`='" & newDate & "' WHERE `FichevieBancMesure`.`id`='" & objFVBanc.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("FVBancManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getFVBancById(ByVal fvbanc_id As String) As FVBanc
        ' déclarations
        Dim oCsDB As New CSDb(True)
        Dim tmpFVBanc As New FVBanc()
        If Not String.IsNullOrEmpty(fvbanc_id) Then

            Dim bddCommande As DbCommand
            bddCommande = oCsDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieBancMesure WHERE FichevieBancMesure.id='" & fvbanc_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        Select Case tmpListProfils.GetName(tmpColId)
                            Case "id"
                                tmpFVBanc.id = tmpListProfils.Item(tmpColId)
                            Case "idBancMesure"
                                tmpFVBanc.idBancMesure = tmpListProfils.Item(tmpColId).ToString()
                            Case "type"
                                tmpFVBanc.type = tmpListProfils.Item(tmpColId).ToString()
                            Case "auteur"
                                tmpFVBanc.auteur = tmpListProfils.Item(tmpColId).ToString()
                            Case "idAgentControleur"
                                tmpFVBanc.idAgentControleur = tmpListProfils.Item(tmpColId)
                            Case "caracteristiques"
                                tmpFVBanc.caracteristiques = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModif"
                                tmpFVBanc.dateModif = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "blocage"
                                tmpFVBanc.blocage = tmpListProfils.Item(tmpColId)
                            Case "pressionControle"
                                tmpFVBanc.pressionControle = tmpListProfils.Item(tmpColId).ToString()
                            Case "valeursMesurees"
                                tmpFVBanc.valeursMesurees = tmpListProfils.Item(tmpColId).ToString()
                            Case "idManometreControle"
                                tmpFVBanc.idManometreControle = tmpListProfils.Item(tmpColId).ToString()
                            Case "idBuseEtalon"
                                tmpFVBanc.idBuseEtalon = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpFVBanc.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpFVBanc.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("FVBancManager::getFVBancById() : " & ex.Message)
            End Try
            oCsDB.free()


        End If
        'on retourne le fvbanc ou un objet vide en cas d'erreur
        Return tmpFVBanc
    End Function

    Public Shared Function getUpdates(ByVal pAgent As Agent) As FVBanc()
        ' déclarations
        Dim arrItems(0) As FVBanc
        Dim bddCommande As DbCommand
        Dim oCsdb As CSDb = Nothing
        oCsdb = New CSDb(True)
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT `FichevieBancMesure`.* FROM `FichevieBancMesure` INNER JOIN `BancMesure` ON `FichevieBancMesure`.`idBancMesure` = `BancMesure`.`id` WHERE `FichevieBancMesure`.`dateModificationAgent`<>`FichevieBancMesure`.`dateModificationCrodip` AND `BancMesure`.`idStructure`=" & pAgent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpFVBanc As New FVBanc(pAgent)
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    tmpFVBanc.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpFVBanc
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("FVBancManager - getUpdates : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function
    ''' <summary>
    ''' Renvoie la Liste des Fiches de Vie pour un banc donné
    ''' </summary>
    ''' <param name="pBancId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getlstFVBancByBancId(ByVal pBancId As String) As System.Collections.Generic.List(Of FVBanc)
        Debug.Assert(Not String.IsNullOrEmpty(pBancId), "Id doit être renseigné")

        Dim lstFVBanc As New System.Collections.Generic.List(Of FVBanc)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieBancMesure WHERE FichevieBancMesure.idBancMesure='" & pBancId & "' ORDER BY dateModif ASC"
            Try

                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()

                    ' On rempli notre tableau
                    Dim AgentFictif As New Agent()
                    Dim tmpFVBanc As New FVBanc(AgentFictif)
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpFVBanc.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    lstFVBanc.Add(tmpFVBanc)
                End While
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispFatal("FVBancManager::getlstFVBancByBancId(): " & ex.Message)
            End Try
        Catch ex As Exception

        End Try
        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If

        Return lstFVBanc
    End Function
    Public Shared Function getLstFVBanc() As List(Of FVBanc)
        Dim lstResponse As New List(Of FVBanc)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        oCsdb = New CSDb(True)
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM FichevieBancMesure Where dateModif is not null"
        Try

            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()

                ' On rempli notre tableau
                Dim oFVBanc As New FVBanc(New Agent())
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    oFVBanc.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                    tmpColId = tmpColId + 1
                End While
                lstResponse.Add(oFVBanc)
            End While
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError("FVBancManager - getlstFVBanc ERR : " & ex.Message)
        End Try

        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If

        Return lstResponse
    End Function

#End Region

    Public Shared Function SendEtats(pFV As FVBanc) As Boolean
        Dim bReturn As Boolean
        Dim filePath As String
        If Not String.IsNullOrEmpty(pFV.FVFileName) Then
            filePath = GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE & "/" & pFV.FVFileName
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE, pFV.FVFileName)

            If My.Settings.SynchroEtatMode = "FTP" Then
                bReturn = SendFTPEtats(filePath)
            Else
                bReturn = SendHTTPEtats(filePath)
            End If
        End If
        Return bReturn
    End Function

    ''' <summary>
    ''' Envoie par FTP des Etats relatid à la fiche de fiche
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function SendFTPEtats(pFilePath As String) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = False
            Dim oCSftp As CSFTP = New CSFTP()
            If System.IO.File.Exists(pFilePath) Then
                bReturn = oCSftp.Upload(pFilePath, "FV/BC")
            End If
        Catch ex As Exception
            CSDebug.dispError("FVBancManager.SendFTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Friend Shared Function SendHTTPEtats(pFilePath As String) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim uri As New Uri(objWSCrodip.Url.Replace("/server", "") & My.Settings.SynchroEtatFVBancUrl)
            ' Dim uri As New Uri(objWSCrodip.Url & My.Settings.SynchroEtatFVBancUrl)
            'Pour le moment les infos d'autehtification ne sont pas utilisées par le Serveur
            Dim Credential As New System.Net.NetworkCredential(My.Settings.SynchroEtatFVBancUser, My.Settings.SynhcroEtatFVBancPwd)
            If System.IO.File.Exists(pFilePath) Then
                My.Computer.Network.UploadFile(pFilePath, uri, Credential, False, 100000)
                SynchronisationManager.LogSynchroElmt(pFilePath)
            End If
        Catch ex As Exception
            CSDebug.dispError("FVBancManager.SendHTTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


End Class
