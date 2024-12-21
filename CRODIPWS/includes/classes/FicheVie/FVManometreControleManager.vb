Imports System.Collections.Generic
Imports System.Data.Common

Public Class FVManometreControleManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As FVManometreControle
        Dim oreturn As FVManometreControle
        oreturn = RootWSGetById(Of FVManometreControle)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As FVManometreControle, ByRef pobjOut As FVManometreControle) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of FVManometreControle)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("FVManometreControleManager.WSSend : ", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function


    'Public Shared Function getWSFVManometreControleById(pAgent As Agent, ByVal fvmanometrecontrole_id As String) As Object
    '    Dim objFVManometreControle As New FVManometreControle()
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetFVManometreControle(pAgent.id, fvmanometrecontrole_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    objFVManometreControle.Fill(objWSCrodip_responseItem.Name, objWSCrodip_responseItem.InnerText)
    '                Next
    '            Case 1 ' NOK
    '                CSDebug.dispError("FVManometreControleManager - Code 1 : Non-Trouvée")
    '            Case 9 ' BADREQUEST
    '                CSDebug.dispError("FVManometreControleManager - Code 9 : Bad Request")
    '        End Select
    '    Catch ex As Exception
    '        CSDebug.dispError("FVManometreControleManager - getWSFVManometreControleById : " & ex.Message)
    '    End Try
    '    Return objFVManometreControle

    'End Function

    'Public Shared Function sendWSFVManometreControle(pAgent As Agent, ByVal fvmanometrecontrole As FVManometreControle, ByRef updatedObject As Object) As Integer
    '    Try
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        'Return objWSCrodip.SendFVManometreControle(pAgent.id, fvmanometrecontrole, updatedObject)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function
    'Public Shared Function SendEtats(pFV As FVManometreControle) As Boolean
    '    Dim bReturn As Boolean
    '    Dim filePath As String
    '    If Not String.IsNullOrEmpty(pFV.FVFileName) Then
    '        filePath = GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE & "/" & pFV.FVFileName
    '        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE, pFV.FVFileName)
    '        bReturn = SendHTTPEtats(filePath)
    '    End If
    '    Return bReturn
    'End Function
    Public Shared Function SendEtats(pFV As FVManometreControle) As Boolean
        Dim bReturn As Boolean
        Dim filePath As String
        If Not String.IsNullOrEmpty(pFV.FVFileName) Then
            filePath = GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE & "/" & pFV.FVFileName
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE, pFV.FVFileName)

            bReturn = SendHTTPEtats(filePath)
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Envoie par FTP des Etats relatid à la fiche de fiche
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Shared Function SendFTPEtats(filePath As String) As Boolean
    '    Dim bReturn As Boolean
    '    Try
    '        bReturn = False
    '        Dim oCSftp As CSFTP = New CSFTP()
    '        If System.IO.File.Exists(filePath) Then
    '            bReturn = oCSftp.Upload(filePath, "FV/MC")
    '        End If
    '    Catch ex As Exception
    '        CSDebug.dispError("FvManometreControleManager.SendFTPEtats ERR : " & ex.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function
    Friend Shared Function SendHTTPEtats(filePath As String) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim uri As New Uri(objWSCrodip.Url.Replace("/server", "") & GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVManoUrl)
            'Pour le moment les infos d'autehtification ne sont pas utilisées par le Serveur
            Dim Credential As New System.Net.NetworkCredential(GlobalsCRODIP.GLOB_PARAM_SynchroEtatFVBancUser, GlobalsCRODIP.GLOB_PARAM_SynchroEtatDiagPwd)
            If System.IO.File.Exists(filePath) Then
                My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                SynchronisationManager.LogSynchroElmt(filePath)
            End If
        Catch ex As Exception
            CSDebug.dispError("FvManometreControleManager.SendHTTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


#End Region

#Region "Methodes Locales"

    Public Shared Function save(pAgent As Agent, ByVal objFVManometreControle As FVManometreControle, Optional bSyncro As Boolean = False) As Boolean
        'Dim paramsQueryUpdate As String
        Dim oCsdb As CSDb = Nothing
        Dim bReturn As Boolean

        Try

            ' On test si l'object existe ou non
            Dim existsObject As FVManometreControle
            existsObject = FVManometreControleManager.getFVManometreControleById(objFVManometreControle.id)
            ' L'Id du FV baanc est initialisé , l'idbanc de mesure est laissé à blanc
            If existsObject.id <> objFVManometreControle.id Then
                ' Si il n'existe pas, on le crée
                bReturn = insert(pAgent, objFVManometreControle, bSyncro)
            Else
                bReturn = update(objFVManometreControle, bSyncro)
            End If
        Catch ex As Exception
            CSDebug.dispError("FVManometreControleManager.save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Shared Function insert(pAgent As Agent, ByVal pobjFV As FVManometreControle, bSynchro As Boolean) As Boolean
        '        Dim paramsQueryUpdate As String
        Dim paramsQuery_col As String
        Dim paramsQuery As String
        Dim oCSDb As New CSDb(True)
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()
            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pobjFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
            Dim oAgent As Agent = AgentManager.getAgentById(pobjFV.idAgentControleur)
            If oAgent.id = 0 Then
                oAgent = pAgent
            End If
            If oAgent.idStructure = 0 Then
                oAgent.idStructure = pAgent.idStructure
            End If
            pobjFV.id = getNewId(oAgent)

            ' Initialisation de la requete
            'paramsQueryUpdate = "id='" & objFVManometreControle.id & "',idManometre='" & CSDb.secureString(objFVManometreControle.idManometre) & "'"
            paramsQuery_col = "id,idManometre"
            paramsQuery = "'" & pobjFV.id & "' , '" & pobjFV.idManometre & "'"
            paramsQuery_col = paramsQuery_col & ",aid,uid,uidstructure,uidmanometre"
            paramsQuery = paramsQuery & ",'" & pobjFV.aid & "' , " & pobjFV.uid & "," & pobjFV.uidstructure & "," & pobjFV.uidmanometre
            paramsQuery_col = paramsQuery_col & ",uidagentcontroleur"
            paramsQuery = paramsQuery & "," & pobjFV.uidagentcontroleur


            If Not pobjFV.type Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",type"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.type) & "'"
                '  paramsQueryUpdate = paramsQueryUpdate & ",type='" & CSDb.secureString(objFVManometreControle.type) & "'"
            End If
            If Not pobjFV.auteur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",auteur"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.auteur) & "'"
                '   paramsQueryUpdate = paramsQueryUpdate & ",auteur='" & CSDb.secureString(objFVManometreControle.auteur) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",idAgentControleur"
            paramsQuery = paramsQuery & " , " & pobjFV.idAgentControleur & ""
            'paramsQueryUpdate = paramsQueryUpdate & ",idAgentControleur=" & CSDb.secureString(objFVManometreControle.idAgentControleur) & ""
            If Not pobjFV.caracteristiques Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",caracteristiques"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.caracteristiques) & "'"
                '   paramsQueryUpdate = paramsQueryUpdate & ",caracteristiques='" & CSDb.secureString(objFVManometreControle.caracteristiques) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",blocage"
            paramsQuery = paramsQuery & " , " & pobjFV.blocage & ""
            'paramsQueryUpdate = paramsQueryUpdate & ",blocage=" & CSDb.secureString(objFVManometreControle.blocage) & ""
            If Not pobjFV.idReetalonnage Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",idReetalonnage"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",idReetalonnage='" & CSDb.secureString(objFVManometreControle.idReetalonnage) & "'"
            End If
            If Not pobjFV.nomLaboratoire Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",nomLaboratoire"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",nomLaboratoire='" & CSDb.secureString(objFVManometreControle.nomLaboratoire) & "'"
            End If
            If Not pobjFV.dateReetalonnage Is Nothing And pobjFV.dateReetalonnage <> "" And pobjFV.dateReetalonnage <> "0000-00-00 00:00:00" Then
                paramsQuery_col = paramsQuery_col & ",dateReetalonnage"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateReetalonnage) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",dateReetalonnage='" & CSDb.secureString(objFVManometreControle.dateReetalonnage) & "'"
            End If
            If Not pobjFV.pressionControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",pressionControle"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.pressionControle) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",pressionControle='" & CSDb.secureString(objFVManometreControle.pressionControle) & "'"
            End If
            If Not pobjFV.valeursMesurees Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",valeursMesurees"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",valeursMesurees='" & CSDb.secureString(objFVManometreControle.valeursMesurees) & "'"
            End If
            If Not pobjFV.idManometreControleur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",idManometreControleur"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",idManometreControleur='" & CSDb.secureString(objFVManometreControle.idManometreControleur) & "'"
            End If
            If Not pobjFV.dateModif Is Nothing And pobjFV.dateModif <> "" Then
                paramsQuery_col = paramsQuery_col & ",dateModif"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateModif) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",dateModif='" & CSDb.secureString(objFVManometreControle.dateModif) & "'"
            End If
            If pobjFV.dateModificationAgentS <> "" Then
                paramsQuery_col = paramsQuery_col & ",dateModificationAgent"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateModificationAgent) & "'"
                'paramsQueryUpdate = paramsQueryUpdate & ",dateModificationAgent='" & CSDb.secureString(objFVManometreControle.dateModificationAgent) & "'"
            End If
            If pobjFV.dateModificationCrodipS <> "" Then
                paramsQuery_col = paramsQuery_col & ",FVFileName"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.FVFileName) & "'"
                ' paramsQueryUpdate = paramsQueryUpdate & ",dateModificationCrodip='" & CSDb.secureString(objFVManometreControle.dateModificationCrodip) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "INSERT INTO FichevieManometreControle (" & paramsQuery_col & ") VALUES (" & paramsQuery & ")"
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
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()

            ' Initialisation de la requete
            paramsQueryUpdate = "id='" & pobjFV.id & "',idManometre='" & CSDb.secureString(pobjFV.idManometre) & "'"
            'paramsQuery_col = "id,idManometre"
            'paramsQuery = "'" & pobjFV.id & "' , '" & pobjFV.idManometre & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pobjFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not pobjFV.type Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",type"
                ' paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.type) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",type='" & CSDb.secureString(pobjFV.type) & "'"
            End If
            If Not pobjFV.auteur Is Nothing Then
                '  paramsQuery_col = paramsQuery_col & ",auteur"
                '   paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.auteur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",auteur='" & CSDb.secureString(pobjFV.auteur) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",idAgentControleur"
            'paramsQuery = paramsQuery & " , " & pobjFV.idAgentControleur & ""
            paramsQueryUpdate = paramsQueryUpdate & ",idAgentControleur=" & CSDb.secureString(pobjFV.idAgentControleur) & ""
            If Not pobjFV.caracteristiques Is Nothing Then
                '  paramsQuery_col = paramsQuery_col & ",caracteristiques"
                '   paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.caracteristiques) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",caracteristiques='" & CSDb.secureString(pobjFV.caracteristiques) & "'"
            End If
            'paramsQuery_col = paramsQuery_col & ",blocage"
            'paramsQuery = paramsQuery & " , " & pobjFV.blocage & ""
            paramsQueryUpdate = paramsQueryUpdate & ",blocage=" & CSDb.secureString(pobjFV.blocage) & ""
            If Not pobjFV.idReetalonnage Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",idReetalonnage"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",idReetalonnage='" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
            End If
            If Not pobjFV.nomLaboratoire Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",nomLaboratoire"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",nomLaboratoire='" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
            End If
            If Not pobjFV.dateReetalonnage Is Nothing And pobjFV.dateReetalonnage <> "" And pobjFV.dateReetalonnage <> "0000-00-00 00:00:00" Then
                'paramsQuery_col = paramsQuery_col & ",dateReetalonnage"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateReetalonnage='" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
            End If
            If Not pobjFV.pressionControle Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",pressionControle"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.pressionControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",pressionControle='" & CSDb.secureString(pobjFV.pressionControle) & "'"
            End If
            If Not pobjFV.valeursMesurees Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",valeursMesurees"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",valeursMesurees='" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
            End If
            If Not pobjFV.idManometreControleur Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",idManometreControleur"
                'paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",idManometreControleur='" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
            End If
            If Not pobjFV.dateModif Is Nothing And pobjFV.dateModif <> "" Then
                'paramsQuery_col = paramsQuery_col & ",dateModif"
                'paramsQuery = paramsQuery & " , '" & CSDate.TOCRODIPString(pobjFV.dateModif) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateModif='" & CSDate.ToCRODIPString(pobjFV.dateModif) & "'"
            End If
            If Not pobjFV.FVFileName Is Nothing Then
                'paramsQuery_col = paramsQuery_col & ",FVFileName"
                'paramsQuery = paramsQuery & " , '" & pobjFV.FVFileName & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",FVFileName='" & CSDb.secureString(pobjFV.FVFileName) & "'"
            End If
            paramsQueryUpdate = paramsQueryUpdate & pobjFV.getRootQuery()
            paramsQueryUpdate = paramsQueryUpdate & ",uidstructure=" & pobjFV.uidstructure
            paramsQueryUpdate = paramsQueryUpdate & ",uidmanometre=" & pobjFV.uidmanometre
            paramsQueryUpdate = paramsQueryUpdate & ",uidagentcontroleur=" & pobjFV.uidagentcontroleur

            ' On finalise la requete et en l'execute
            bddCommande.Connection = oCSDb.getConnection()
            bddCommande.CommandText = "UPDATE FichevieManometreControle SET " & paramsQueryUpdate & " WHERE FichevieManometreControle.id='" & pobjFV.id & "'"
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
        Dim tmpObjectId As String = pAgent.uidStructure & "-" & pAgent.id & "-1"
        If pAgent.uidStructure <> 0 Then

            Try
                ' On récupère les résultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As DbDataReader = bdd.getResult2s("SELECT id FROM FichevieManometreControle WHERE id LIKE '" & pAgent.uidStructure & "-" & pAgent.id & "-%' ORDER BY id DESC")
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.uidStructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpListProfils.Close()
                tmpObjectId = pAgent.uidStructure & "-" & pAgent.id & "-" & (newId + 1)
                bdd.free()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("FVManometreControleManager - newId : " & ex.Message & vbNewLine)
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
            dbLink.queryString = "UPDATE FichevieManometreControle SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objFVManometreControle.id & "'"
            dbLink.Execute()
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
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Dim tmpFVManometreControle As New FVManometreControle(New Agent)
        oCsdb = New CSDb(True)
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM FichevieManometreControle WHERE FichevieManometreControle.id='" & fvmanometrecontrole_id & "'"
        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("FVManometreControleManager Error: " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If oCsdb IsNot Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        'on retourne le fvmanometrecontrole ou un objet vide en cas d'erreur
        Return tmpFVManometreControle
    End Function

    '''
    ''' Rend les fiches de vie des mano de la structure qui ont été modifiées depuis la dateCrodip
    Public Shared Function getUpdates(ByVal agent As Agent) As FVManometreControle()
        ' déclarations
        Dim oCsdb As CSDb = Nothing
        Dim arrItems(0) As FVManometreControle
        Dim bddCommande As DbCommand


        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT FichevieManometreControle.* FROM FichevieManometreControle INNER JOIN AgentManoControle ON FichevieManometreControle.idManometre = AgentManoControle.idCrodip "
            bddCommande.CommandText = bddCommande.CommandText & " WHERE (FichevieManometreControle.dateModificationAgent<>FichevieManometreControle.dateModificationCrodip or FichevieManometreControle.dateModificationCrodip is null ) "
            bddCommande.CommandText = bddCommande.CommandText & " AND AgentManoControle.idStructure=" & agent.uidStructure
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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

        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If
        'on retourne les objet non synchro
        Return arrItems
    End Function

    'Public Shared Function getLstFVManometreControle(ByVal pIdManometre As String) As List(Of FVManometreControle)
    '    Debug.Assert(Not String.IsNullOrEmpty(pIdManometre), "L'ID doit êtr initialisé")
    '    Dim lstResponse As New List(Of FVManometreControle)
    '    Dim oCsdb As CSDb = Nothing
    '    Dim bddCommande As DbCommand

    '    If pIdManometre <> "" Then
    '        oCsdb = New CSDb(True)
    '        bddCommande = oCsdb.getConnection().CreateCommand()
    '        bddCommande.CommandText = "SELECT * FROM FichevieManometreControle WHERE FichevieManometreControle.idManometre='" & pIdManometre & "' ORDER BY dateModif DESC"
    '        Try

    '            On récupère les résultats
    '            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
    '            Puis on les parcours
    '            While tmpListProfils.Read()

    '                On rempli notre tableau
    '                Dim tmpFVManometreControle As New FVManometreControle(New Agent())
    '                Dim tmpColId As Integer = 0
    '                While tmpColId < tmpListProfils.FieldCount()
    '                    If Not tmpListProfils.IsDBNull(tmpColId) Then
    '                        tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
    '                    End If
    '                    tmpColId = tmpColId + 1
    '                End While
    '                lstResponse.Add(tmpFVManometreControle)
    '            End While
    '            tmpListProfils.Close()
    '        Catch ex As Exception
    '            CSDebug.dispError("FVManometreControleManager - getArrFVManometreControle ERR : " & ex.Message)
    '        End Try

    '        If oCsdb IsNot Nothing Then
    '            oCsdb.free()
    '        End If

    '    End If
    '    Return lstResponse
    'End Function
    Public Shared Function getLstFVManometreControleByuid(ByVal puid As String) As List(Of FVManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(puid), "L'UID doit êtr initialisé")
        Dim lstResponse As New List(Of FVManometreControle)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        If puid <> "" Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreControle WHERE FichevieManometreControle.uidManometre='" & puid & "' ORDER BY dateModif DESC"
            Try

                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()

                    ' On rempli notre tableau
                    Dim tmpFVManometreControle As New FVManometreControle(New Agent())
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpFVManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    lstResponse.Add(tmpFVManometreControle)
                End While
                tmpListProfils.Close()
            Catch ex As Exception
                CSDebug.dispError("FVManometreControleManager.getLstFVManometreControleByuid ERR : ", ex)
            End Try

            If oCsdb IsNot Nothing Then
                oCsdb.free()
            End If

        End If
        Return lstResponse
    End Function

#End Region
    Public Shared Function delete(ByVal pId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pId), " le paramètre ID doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM FichevieManometreControle WHERE id='" & pId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("FVManometreControleManager.delete (" & pId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

End Class
