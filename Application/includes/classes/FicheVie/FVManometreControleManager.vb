Imports System.Collections.Generic
Public Class FVManometreControleManager

#Region "Methodes Web Service"

    Public Shared Function getWSFVManometreControleById(ByVal fvmanometrecontrole_id As String) As Object
        Dim objFVManometreControle As New FVManometreControle()
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetFVManometreControle(agentCourant.id, fvmanometrecontrole_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        objFVManometreControle.Fill(objWSCrodip_responseItem.Name, objWSCrodip_responseItem.InnerText)
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("FVManometreControleManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("FVManometreControleManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("FVManometreControleManager - getWSFVManometreControleById : " & ex.Message)
        End Try
        Return objFVManometreControle

    End Function

    Public Shared Function sendWSFVManometreControle(ByVal fvmanometrecontrole As FVManometreControle, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendFVManometreControle(agentCourant.id, fvmanometrecontrole, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Envoie par FTP des Etats relatid à la fiche de fiche
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SendFTPEtats(pFV As FVManometreControle) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = False
            Dim oCSftp As CSFTP = New CSFTP()
            Dim filePath As String
            If Not String.IsNullOrEmpty(pFV.FVFileName) Then
                filePath = CONST_PATH_EXP & "/" & pFV.FVFileName
                If System.IO.File.Exists(filePath) Then
                    bReturn = oCSftp.Upload(filePath, "FV/MC")
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("FvManometreControleManager.SendFTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function save(ByVal objFVManometreControle As FVManometreControle, Optional bSyncro As Boolean = False) As Boolean
        'Dim paramsQueryUpdate As String
        Dim oCSDb As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean

        Try

            ' On test si l'object existe ou non
            Dim existsObject As FVManometreControle
            existsObject = FVManometreControleManager.getFVManometreControleById(objFVManometreControle.id)
            ' L'Id du FV baanc est initialisé , l'idbanc de mesure est laissé à blanc
            If existsObject.id <> objFVManometreControle.id Then
                ' Si il n'existe pas, on le crée
                bReturn = insert(objFVManometreControle, bSyncro)
            Else
                bReturn = update(objFVManometreControle, bSyncro)
            End If
        Catch ex As Exception
            CSDebug.dispError("FVManometreControleManager.save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Shared Function insert(ByVal pobjFV As FVManometreControle, bSynchro As Boolean) As Boolean
        '        Dim paramsQueryUpdate As String
        Dim paramsQuery_col As String
        Dim paramsQuery As String
        Dim oCSDb As New CSDb(True)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim bReturn As Boolean

        Try
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()

            ' Initialisation de la requete
            'paramsQueryUpdate = "`id`='" & objFVManometreControle.id & "',`idManometre`='" & CSDb.secureString(objFVManometreControle.idManometre) & "'"
            paramsQuery_col = "`id`,`idManometre`"
            paramsQuery = "'" & pobjFV.id & "' , '" & pobjFV.idManometre & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pobjFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not pobjFV.type Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`type`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.type) & "'"
                '  paramsQueryUpdate = paramsQueryUpdate & ",`type`='" & CSDb.secureString(objFVManometreControle.type) & "'"
            End If
            If Not pobjFV.auteur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`auteur`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.auteur) & "'"
                '   paramsQueryUpdate = paramsQueryUpdate & ",`auteur`='" & CSDb.secureString(objFVManometreControle.auteur) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`idAgentControleur`"
            paramsQuery = paramsQuery & " , " & pobjFV.idAgentControleur & ""
            'paramsQueryUpdate = paramsQueryUpdate & ",`idAgentControleur`=" & CSDb.secureString(objFVManometreControle.idAgentControleur) & ""
            If Not pobjFV.caracteristiques Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`caracteristiques`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.caracteristiques) & "'"
                '   paramsQueryUpdate = paramsQueryUpdate & ",`caracteristiques`='" & CSDb.secureString(objFVManometreControle.caracteristiques) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",`blocage`"
            paramsQuery = paramsQuery & " , " & pobjFV.blocage & ""
            'paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString(objFVManometreControle.blocage) & ""
            If Not pobjFV.idReetalonnage Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idReetalonnage`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`idReetalonnage`='" & CSDb.secureString(objFVManometreControle.idReetalonnage) & "'"
            End If
            If Not pobjFV.nomLaboratoire Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`nomLaboratoire`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`nomLaboratoire`='" & CSDb.secureString(objFVManometreControle.nomLaboratoire) & "'"
            End If
            If Not pobjFV.dateReetalonnage Is Nothing And pobjFV.dateReetalonnage <> "" And pobjFV.dateReetalonnage <> "0000-00-00 00:00:00" Then
                paramsQuery_col = paramsQuery_col & ",`dateReetalonnage`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`dateReetalonnage`='" & CSDb.secureString(objFVManometreControle.dateReetalonnage) & "'"
            End If
            If Not pobjFV.pressionControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`pressionControle`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.pressionControle) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`pressionControle`='" & CSDb.secureString(objFVManometreControle.pressionControle) & "'"
            End If
            If Not pobjFV.valeursMesurees Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`valeursMesurees`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`valeursMesurees`='" & CSDb.secureString(objFVManometreControle.valeursMesurees) & "'"
            End If
            If Not pobjFV.idManometreControleur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`idManometreControleur`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`idManometreControleur`='" & CSDb.secureString(objFVManometreControle.idManometreControleur) & "'"
            End If
            If Not pobjFV.dateModif Is Nothing And pobjFV.dateModif <> "" Then
                paramsQuery_col = paramsQuery_col & ",`dateModif`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(pobjFV.dateModif) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`dateModif`='" & CSDb.secureString(objFVManometreControle.dateModif) & "'"
            End If
            If Not pobjFV.dateModificationAgent Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`dateModificationAgent`"
                paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(pobjFV.dateModificationAgent) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationAgent`='" & CSDb.secureString(objFVManometreControle.dateModificationAgent) & "'"
            End If
            If Not pobjFV.dateModificationCrodip Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",`FVFileName`"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.FVFileName) & "'"
                ' paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & CSDb.secureString(objFVManometreControle.dateModificationCrodip) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "INSERT INTO `FichevieManometreControle` (" & paramsQuery_col & ") VALUES (" & paramsQuery & ")"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManoControleManager.Insert ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        If oCSDb IsNot Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'Insert
    Private Shared Function update(ByVal pobjFV As FVManometreControle, bSynchro As Boolean) As Boolean
        '        Dim paramsQueryUpdate As String
        Dim paramsQueryUpdate As String
        Dim oCSDb As New CSDb(True)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim bReturn As Boolean

        Try
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()

            ' Initialisation de la requete
            paramsQueryUpdate = "`id`='" & pobjFV.id & "',`idManometre`='" & CSDb.secureString(pobjFV.idManometre) & "'"
            'paramsQuery_col = "`id`,`idManometre`"
            'paramsQuery = "'" & pobjFV.id & "' , '" & pobjFV.idManometre & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pobjFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not pobjFV.type Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`type`"
                ' paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.type) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`type`='" & CSDb.secureString(pobjFV.type) & "'"
            End If
            If Not pobjFV.auteur Is Nothing Then
                '  paramsQuery_col = paramsQuery_col & ",`auteur`"
                '   paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.auteur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`auteur`='" & CSDb.secureString(pobjFV.auteur) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",`idAgentControleur`"
            'paramsQuery = paramsQuery & " , " & pobjFV.idAgentControleur & ""
            paramsQueryUpdate = paramsQueryUpdate & ",`idAgentControleur`=" & CSDb.secureString(pobjFV.idAgentControleur) & ""
            If Not pobjFV.caracteristiques Is Nothing Then
                '  paramsQuery_col = paramsQuery_col & ",`caracteristiques`"
                '   paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.caracteristiques) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`caracteristiques`='" & CSDb.secureString(pobjFV.caracteristiques) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",`blocage`"
            'paramsQuery = paramsQuery & " , " & pobjFV.blocage & ""
            paramsQueryUpdate = paramsQueryUpdate & ",`blocage`=" & CSDb.secureString(pobjFV.blocage) & ""
            If Not pobjFV.idReetalonnage Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`idReetalonnage`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idReetalonnage`='" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
            End If
            If Not pobjFV.nomLaboratoire Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`nomLaboratoire`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`nomLaboratoire`='" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
            End If
            If Not pobjFV.dateReetalonnage Is Nothing And pobjFV.dateReetalonnage <> "" And pobjFV.dateReetalonnage <> "0000-00-00 00:00:00" Then
                'paramsQuery_col = paramsQuery_col & ",`dateReetalonnage`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateReetalonnage`='" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
            End If
            If Not pobjFV.pressionControle Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`pressionControle`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.pressionControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`pressionControle`='" & CSDb.secureString(pobjFV.pressionControle) & "'"
            End If
            If Not pobjFV.valeursMesurees Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`valeursMesurees`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`valeursMesurees`='" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
            End If
            If Not pobjFV.idManometreControleur Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`idManometreControleur`"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`idManometreControleur`='" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
            End If
            If Not pobjFV.dateModif Is Nothing And pobjFV.dateModif <> "" Then
                'paramsQuery_col = paramsQuery_col & ",`dateModif`"
                'paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(pobjFV.dateModif) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModif`='" & CSDb.secureString(pobjFV.dateModif) & "'"
            End If
            If Not pobjFV.dateModificationAgent Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`dateModificationAgent`"
                'paramsQuery = paramsQuery & " , '" & CSDate.mysql2access(pobjFV.dateModificationAgent) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationAgent`='" & CSDb.secureString(pobjFV.dateModificationAgent) & "'"
            End If
            If Not pobjFV.dateModificationCrodip Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`FVFileName`"
                'paramsQuery = paramsQuery & " , '" & pobjFV.FVFileName & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`dateModificationCrodip`='" & CSDb.secureString(pobjFV.dateModificationCrodip) & "'"
            End If
            If Not pobjFV.FVFileName Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",`FVFileName`"
                'paramsQuery = paramsQuery & " , '" & pobjFV.FVFileName & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",`FVFileName`='" & CSDb.secureString(pobjFV.FVFileName) & "'"
            End If

            ' On finalise la requete et en l'execute
            ' On finalise la requete et en l'execute
            bddCommande.Connection = oCSDb.getConnection()
            bddCommande.CommandText = "UPDATE `FichevieManometreControle` SET " & paramsQueryUpdate & " WHERE `FichevieManometreControle`.`id`='" & pobjFV.id & "'"
            bddCommande.ExecuteNonQuery()
            oCSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManoControleManager.update ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        If oCSDb IsNot Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'Insert

    Public Shared Function getNewId(ByVal pAgent As Agent) As String
        ' déclarations
        Dim tmpObjectId As String = pAgent.idStructure & "-" & pAgent.id & "-1"
        If pAgent.idStructure <> 0 Then

            Try
                ' On récupère les résultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT `id` FROM `FichevieManometreControle` WHERE `id` LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY `id` DESC")
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
                Console.Write("FVManometreControleManager - newId : " & ex.Message & vbNewLine)
            End Try

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Function setSynchro(ByVal objFVManometreControle As FVManometreControle) As Boolean
        Dim bReturn As Boolean

        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `FichevieManometreControle` SET `FichevieManometreControle`.`dateModificationCrodip`='" & newDate & "',`FichevieManometreControle`.`dateModificationAgent`='" & newDate & "' WHERE `FichevieManometreControle`.`id`='" & objFVManometreControle.id & "'"
            dbLink.getResults()
            dbLink.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("FVManometreControleManager::setSynchro : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getFVManometreControleById(ByVal fvmanometrecontrole_id As String) As FVManometreControle
        Debug.Assert(Not String.IsNullOrEmpty(fvmanometrecontrole_id), "Id doit être initialisé")
        ' déclarations
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand

        Dim tmpFVManometreControle As New FVManometreControle(New Agent)
        oCSDB = New CSDb(True)
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM FichevieManometreControle WHERE FichevieManometreControle.id='" & fvmanometrecontrole_id & "'"
        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    tmpColId = tmpColId + 1
                End While
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("FVManometreControleManager Error: " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If oCSDB IsNot Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If

        'on retourne le fvmanometrecontrole ou un objet vide en cas d'erreur
        Return tmpFVManometreControle
    End Function

    '''
    ''' Rend les fiches de vie des mano de la structure qui ont été modifiées depuis la dateCrodip
    Public Shared Function getUpdates(ByVal agent As Agent) As FVManometreControle()
        ' déclarations
        Dim oCSDB As CSDb
        Dim arrItems(0) As FVManometreControle
        Dim bddCommande As OleDb.OleDbCommand


        Try
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT `FichevieManometreControle`.* FROM `FichevieManometreControle` INNER JOIN `AgentManoControle` ON `FichevieManometreControle`.`idManometre` = `AgentManoControle`.`idCrodip` WHERE `FichevieManometreControle`.`dateModificationAgent`<>`FichevieManometreControle`.`dateModificationCrodip` AND `AgentManoControle`.`idStructure`=" & agent.idStructure
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpFVManometreControle As New FVManometreControle(agent)
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpFVManometreControle
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("FVManometreControleManager - getUpdates ERR : " & ex.Message)
        End Try

        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If
        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function getLstFVManometreControle(ByVal pIdManometre As String) As List(Of FVManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(pIdManometre), "L'ID doit êtr initialisé")
        Dim lstResponse As New List(Of FVManometreControle)
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand

        If pIdManometre <> "" Then
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreControle WHERE FichevieManometreControle.idManometre='" & pIdManometre & "'"
            Try

                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()

                    ' On rempli notre tableau
                    Dim tmpFVManometreControle As New FVManometreControle(New Agent())
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        tmpColId = tmpColId + 1
                    End While
                    lstResponse.Add(tmpFVManometreControle)
                End While
                tmpListProfils.Close()
            Catch ex As Exception
                CSDebug.dispError("FVManometreControleManager - getArrFVManometreControle ERR : " & ex.Message)
            End Try

            If oCSDB IsNot Nothing Then
                oCSDB.free()
            End If

        End If
        Return lstResponse
    End Function

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
            bddCommande.CommandText = "DELETE FROM FichevieManometreControle WHERE id='" & pId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("FVManometreControleManager.delete (" & pId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'delete

End Class
