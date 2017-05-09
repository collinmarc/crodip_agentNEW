Imports System.Collections.Generic
Public Class FVManometreEtalonManager

#Region "Methodes Web Service"

    Public Shared Function getWSFVManometreEtalonById(ByVal fvmanometrecontrole_id As String) As Object
        Dim objFVManometreEtalon As New FVManometreEtalon(New Agent())
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetFVManometreEtalon(agentCourant.id, fvmanometrecontrole_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        Select Case objWSCrodip_responseItem.Name()
                            Case "id"
                                objFVManometreEtalon.id = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "idManometre"
                                objFVManometreEtalon.idManometre = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "type"
                                objFVManometreEtalon.type = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "auteur"
                                objFVManometreEtalon.auteur = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "idAgentControleur"
                                objFVManometreEtalon.idAgentControleur = CType(objWSCrodip_responseItem.InnerText(), Integer)
                            Case "caracteristiques"
                                objFVManometreEtalon.caracteristiques = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "dateModif"
                                objFVManometreEtalon.dateModif = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "blocage"
                                objFVManometreEtalon.blocage = CType(objWSCrodip_responseItem.InnerText(), Boolean)
                            Case "idReetalonnage"
                                objFVManometreEtalon.idReetalonnage = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "nomLaboratoire"
                                objFVManometreEtalon.nomLaboratoire = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "dateReetalonnage"
                                objFVManometreEtalon.dateReetalonnage = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "pressionControle"
                                objFVManometreEtalon.pressionControle = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "valeursMesurees"
                                objFVManometreEtalon.valeursMesurees = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "idManometreControleur"
                                objFVManometreEtalon.idManometreControleur = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "dateModificationAgent"
                                objFVManometreEtalon.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
                            Case "dateModificationCrodip"
                                objFVManometreEtalon.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
                        End Select
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("FVManometreEtalonManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("FVManometreEtalonManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager - getWSFVManometreEtalonById : " & ex.Message)
        End Try
        Return objFVManometreEtalon

    End Function

    Public Shared Function sendWSFVManometreEtalon(ByVal fvmanometreetalon As FVManometreEtalon, ByRef updatedObject As Object)
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendFVManometreEtalon(agentCourant.id, fvmanometreetalon, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As FVManometreEtalon
        Dim objFVManometreEtalon As New FVManometreEtalon(New Agent())

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    objFVManometreEtalon.id = CType(tmpSerializeItem.InnerText, String)
                Case "idManometre"
                    objFVManometreEtalon.idManometre = CType(tmpSerializeItem.InnerText, String)
                Case "type"
                    objFVManometreEtalon.type = CType(tmpSerializeItem.InnerText, String)
                Case "auteur"
                    objFVManometreEtalon.auteur = CType(tmpSerializeItem.InnerText, String)
                Case "idAgentControleur"
                    objFVManometreEtalon.idAgentControleur = CType(tmpSerializeItem.InnerText, Integer)
                Case "caracteristiques"
                    objFVManometreEtalon.caracteristiques = CType(tmpSerializeItem.InnerText, String)
                Case "dateModif"
                    objFVManometreEtalon.dateModif = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "blocage"
                    objFVManometreEtalon.blocage = CType(tmpSerializeItem.InnerText, Boolean)
                Case "idReetalonnage"
                    objFVManometreEtalon.idReetalonnage = CType(tmpSerializeItem.InnerText, String)
                Case "nomLaboratoire"
                    objFVManometreEtalon.nomLaboratoire = CType(tmpSerializeItem.InnerText, String)
                Case "dateReetalonnage"
                    objFVManometreEtalon.dateReetalonnage = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "pressionControle"
                    objFVManometreEtalon.pressionControle = CType(tmpSerializeItem.InnerText, String)
                Case "valeursMesurees"
                    objFVManometreEtalon.valeursMesurees = CType(tmpSerializeItem.InnerText, String)
                Case "idManometreControleur"
                    objFVManometreEtalon.idManometreControleur = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    objFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    objFVManometreEtalon.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return objFVManometreEtalon
    End Function
#End Region

#Region "Methodes Locales"

    Public Shared Function save(ByVal objFVManometreEtalon As FVManometreEtalon, Optional bSyncro As Boolean = False) As Boolean
        Dim paramsQueryUpdate As String
        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean
        Try
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()

            ' Initialisation de la requete
            paramsQueryUpdate = "`id`='" & objFVManometreEtalon.id & "',`idManometre`='" & oCSDb.secureString(objFVManometreEtalon.idManometre) & "'"
            Dim paramsQuery_col As String = "`id`,`idManometre`"
            Dim paramsQuery As String = "'" & objFVManometreEtalon.id & "','" & objFVManometreEtalon.idManometre & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSyncro Then
                objFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not objFVManometreEtalon.type Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`type`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.type) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`type`='" & oCSDb.secureString(objFVManometreEtalon.type) & "'"
            End If
            If Not objFVManometreEtalon.auteur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`auteur`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.auteur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`auteur`='" & oCSDb.secureString(objFVManometreEtalon.auteur) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`idAgentControleur`"
            paramsQuery = paramsQuery & " , " & objFVManometreEtalon.idAgentControleur & ""
            paramsQueryUpdate = paramsQueryUpdate & ",`idAgentControleur`=" & oCSDb.secureString(objFVManometreEtalon.idAgentControleur) & ""
            If Not objFVManometreEtalon.caracteristiques Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`caracteristiques`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.caracteristiques) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`caracteristiques`='" & oCSDb.secureString(objFVManometreEtalon.caracteristiques) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`blocage`"
            paramsQuery = paramsQuery & " , " & objFVManometreEtalon.blocage & ""
            paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & oCSDb.secureString(objFVManometreEtalon.blocage) & ""
            If Not objFVManometreEtalon.idReetalonnage Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idReetalonnage`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.idReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idReetalonnage`='" & oCSDb.secureString(objFVManometreEtalon.idReetalonnage) & "'"
            End If
            If Not objFVManometreEtalon.nomLaboratoire Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`nomLaboratoire`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.nomLaboratoire) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`nomLaboratoire`='" & oCSDb.secureString(objFVManometreEtalon.nomLaboratoire) & "'"
            End If
            If Not objFVManometreEtalon.dateReetalonnage Is Nothing And objFVManometreEtalon.dateReetalonnage <> "" And objFVManometreEtalon.dateReetalonnage <> "0000-00-00 00:00:00" Then
                paramsQuery_col = paramsQuery_col & ",`dateReetalonnage`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.dateReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateReetalonnage`='" & oCSDb.secureString(objFVManometreEtalon.dateReetalonnage) & "'"
            End If
            If Not objFVManometreEtalon.pressionControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`pressionControle`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.pressionControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`pressionControle`='" & oCSDb.secureString(objFVManometreEtalon.pressionControle) & "'"
            End If
            If Not objFVManometreEtalon.valeursMesurees Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`valeursMesurees`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.valeursMesurees) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`valeursMesurees`='" & oCSDb.secureString(objFVManometreEtalon.valeursMesurees) & "'"
            End If
            If Not objFVManometreEtalon.idManometreControleur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idManometreControleur`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.idManometreControleur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idManometreControleur`='" & oCSDb.secureString(objFVManometreEtalon.idManometreControleur) & "'"
            End If
            If Not objFVManometreEtalon.dateModif Is Nothing And objFVManometreEtalon.dateModif <> "" Then
                paramsQuery_col = paramsQuery_col & ",`dateModif`"
                paramsQuery = paramsQuery & " , '" & oCSDb.secureString(objFVManometreEtalon.dateModif) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModif`='" & oCSDb.secureString(objFVManometreEtalon.dateModif) & "'"
            End If
            If Not objFVManometreEtalon.dateModificationAgent Is Nothing And objFVManometreEtalon.dateModificationAgent <> "" Then
                paramsQuery_col = paramsQuery_col & ",`dateModificationAgent`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVManometreEtalon.dateModificationAgent) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationAgent`='" & oCSDb.secureString(objFVManometreEtalon.dateModificationAgent) & "'"
            End If
            If Not objFVManometreEtalon.dateModificationCrodip Is Nothing And objFVManometreEtalon.dateModificationCrodip <> "" Then
                paramsQuery_col = paramsQuery_col & ",`dateModificationCrodip`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(objFVManometreEtalon.dateModificationCrodip) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & oCSDb.secureString(objFVManometreEtalon.dateModificationCrodip) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "INSERT INTO `FichevieManometreEtalon` (" & paramsQuery_col & ") VALUES (" & paramsQuery & ")"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Err FVManoEtalon - Save : " & ex.Message.ToString)
            bReturn = False
        End Try
        If oCSDb IsNot Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'save

    Public Shared Function getNewId(ByVal pAgent As Agent) As String
        ' déclarations
        Dim tmpObjectId As String = pAgent.idStructure & "-" & pAgent.id & "-1"
        If pAgent.idStructure <> 0 Then

            Try
                ' On récupère les résultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT `id` FROM `FichevieManometreEtalon` WHERE `id` LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY `id` DESC")
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.idStructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = pAgent.idStructure & "-" & pAgent.id & "-" & (newId + 1)
                bdd.free()
            Catch ex As Exception ' On intercepte l'erreur
                Console.Write("FVManometreEtalonManager - newId : " & ex.Message & vbNewLine)
            End Try

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Sub setSynchro(ByVal objFVManometreEtalon As FVManometreEtalon)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `FichevieManometreEtalon` SET `FichevieManometreEtalon`.`dateModificationCrodip`='" & newDate & "',`FichevieManometreEtalon`.`dateModificationAgent`='" & newDate & "' WHERE `FichevieManometreEtalon`.`id`='" & objFVManometreEtalon.id & "'"
            dbLink.getResults()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getFVManometreEtalonById(ByVal fvmanometreetalon_id As String) As FVManometreEtalon
        ' déclarations
        Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        If fvmanometreetalon_id <> "" Then
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreEtalon WHERE FichevieManometreEtalon.id='" & fvmanometreetalon_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        Select Case tmpListProfils.GetName(tmpColId)
                            Case "id"
                                tmpFVManometreEtalon.id = tmpListProfils.Item(tmpColId).ToString()
                            Case "idManometre"
                                tmpFVManometreEtalon.idManometre = tmpListProfils.Item(tmpColId).ToString()
                            Case "type"
                                tmpFVManometreEtalon.type = tmpListProfils.Item(tmpColId).ToString()
                            Case "auteur"
                                tmpFVManometreEtalon.auteur = tmpListProfils.Item(tmpColId).ToString()
                            Case "idAgentControleur"
                                tmpFVManometreEtalon.idAgentControleur = tmpListProfils.Item(tmpColId)
                            Case "caracteristiques"
                                tmpFVManometreEtalon.caracteristiques = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModif"
                                tmpFVManometreEtalon.dateModif = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "blocage"
                                tmpFVManometreEtalon.blocage = tmpListProfils.Item(tmpColId)
                            Case "idReetalonnage"
                                tmpFVManometreEtalon.idReetalonnage = tmpListProfils.Item(tmpColId).ToString()
                            Case "nomLaboratoire"
                                tmpFVManometreEtalon.nomLaboratoire = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateReetalonnage"
                                tmpFVManometreEtalon.dateReetalonnage = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "pressionControle"
                                tmpFVManometreEtalon.pressionControle = tmpListProfils.Item(tmpColId).ToString()
                            Case "valeursMesurees"
                                tmpFVManometreEtalon.valeursMesurees = tmpListProfils.Item(tmpColId).ToString()
                            Case "idManometreControleur"
                                tmpFVManometreEtalon.idManometreControleur = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpFVManometreEtalon.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("FVManometreEtalonManager Error: " & ex.Message)
            End Try

            If oCSDB IsNot Nothing Then
                oCSDB.free()
            End If

        End If
        'on retourne le fvmanometreetalon ou un objet vide en cas d'erreur
        Return tmpFVManometreEtalon
    End Function

    Private Shared Function createFVManometreEtalon(ByVal fvmanometreetalon_id As String) As Boolean
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean

        Try
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO `FichevieManometreEtalon` (`id`) VALUES ('" & fvmanometreetalon_id & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager error : " & ex.Message)
            bReturn = False
        End Try
        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function 'createFVManometreEtalon

    Public Shared Function getUpdates(ByVal agent As Agent) As FVManometreEtalon()
        ' déclarations
        Dim oCSDB As CSDb

        Dim arrItems(0) As FVManometreEtalon
        Dim bddCommande As OleDb.OleDbCommand

        oCSDB = New CSDb(True)
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT `FichevieManometreEtalon`.* FROM `FichevieManometreEtalon` INNER JOIN `AgentManoEtalon` ON `FichevieManometreEtalon`.`idManometre` = `AgentManoEtalon`.`idCrodip` WHERE `FichevieManometreEtalon`.`dateModificationAgent`<>`FichevieManometreEtalon`.`dateModificationCrodip` AND `AgentManoEtalon`.`idStructure`=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    Select Case tmpListProfils.GetName(tmpColId)
                        Case "id"
                            tmpFVManometreEtalon.id = tmpListProfils.Item(tmpColId).ToString()
                        Case "idManometre"
                            tmpFVManometreEtalon.idManometre = tmpListProfils.Item(tmpColId).ToString()
                        Case "type"
                            tmpFVManometreEtalon.type = tmpListProfils.Item(tmpColId).ToString()
                        Case "auteur"
                            tmpFVManometreEtalon.auteur = tmpListProfils.Item(tmpColId).ToString()
                        Case "idAgentControleur"
                            tmpFVManometreEtalon.idAgentControleur = tmpListProfils.Item(tmpColId)
                        Case "caracteristiques"
                            tmpFVManometreEtalon.caracteristiques = tmpListProfils.Item(tmpColId).ToString()
                        Case "dateModif"
                            tmpFVManometreEtalon.dateModif = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        Case "blocage"
                            tmpFVManometreEtalon.blocage = tmpListProfils.Item(tmpColId)
                        Case "idReetalonnage"
                            tmpFVManometreEtalon.idReetalonnage = tmpListProfils.Item(tmpColId).ToString()
                        Case "nomLaboratoire"
                            tmpFVManometreEtalon.nomLaboratoire = tmpListProfils.Item(tmpColId).ToString()
                        Case "dateReetalonnage"
                            tmpFVManometreEtalon.dateReetalonnage = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        Case "pressionControle"
                            tmpFVManometreEtalon.pressionControle = tmpListProfils.Item(tmpColId).ToString()
                        Case "valeursMesurees"
                            tmpFVManometreEtalon.valeursMesurees = tmpListProfils.Item(tmpColId).ToString()
                        Case "idManometreControleur"
                            tmpFVManometreEtalon.idManometreControleur = tmpListProfils.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpFVManometreEtalon.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpFVManometreEtalon
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
            tmpListProfils.Close()

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - FVManometreEtalonManager - getResult : " & ex.Message)
        End Try

        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function getArrFVManometreEtalon(ByVal param As String) As List(Of FVManometreEtalon)
        Dim lstResponse As New List(Of FVManometreEtalon)
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand


        If param <> "" Then
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreEtalon WHERE FichevieManometreEtalon.idManometre='" & param & "'"
            Try

                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()

                    ' On rempli notre tableau
                    Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        Select Case tmpListProfils.GetName(tmpColId)
                            Case "id"
                                tmpFVManometreEtalon.id = tmpListProfils.Item(tmpColId).ToString()
                            Case "idManometre"
                                tmpFVManometreEtalon.idManometre = tmpListProfils.Item(tmpColId).ToString()
                            Case "type"
                                tmpFVManometreEtalon.type = tmpListProfils.Item(tmpColId).ToString()
                            Case "auteur"
                                tmpFVManometreEtalon.auteur = tmpListProfils.Item(tmpColId).ToString()
                            Case "idAgentControleur"
                                tmpFVManometreEtalon.idAgentControleur = tmpListProfils.Item(tmpColId)
                            Case "caracteristiques"
                                tmpFVManometreEtalon.caracteristiques = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModif"
                                tmpFVManometreEtalon.dateModif = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "blocage"
                                tmpFVManometreEtalon.blocage = tmpListProfils.Item(tmpColId)
                            Case "idReetalonnage"
                                tmpFVManometreEtalon.idReetalonnage = tmpListProfils.Item(tmpColId).ToString()
                            Case "nomLaboratoire"
                                tmpFVManometreEtalon.nomLaboratoire = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateReetalonnage"
                                tmpFVManometreEtalon.dateReetalonnage = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "pressionControle"
                                tmpFVManometreEtalon.pressionControle = tmpListProfils.Item(tmpColId).ToString()
                            Case "valeursMesurees"
                                tmpFVManometreEtalon.valeursMesurees = tmpListProfils.Item(tmpColId).ToString()
                            Case "idManometreControleur"
                                tmpFVManometreEtalon.idManometreControleur = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpFVManometreEtalon.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    lstResponse.Add(tmpFVManometreEtalon)
                End While
                tmpListProfils.Close()
            Catch ex As Exception
                CSDebug.dispError("FVManometreEtalonManager.getArrFVManometreEtalon ERR : " & ex.Message)
            End Try

            If oCSDB IsNot Nothing Then
                oCSDB.free()
            End If

        End If
        Return lstResponse
    End Function 'getArrFVManometreEtalon

#End Region
    Public Shared Function delete(ByVal pId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pId), " le paramètre ID doit être initialisé")
        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCSDb = New CSDb(True)

            bddCommande = oCSDb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM FichevieManometreEtalon WHERE id='" & pId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager.delete (" & pId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'delete

End Class
