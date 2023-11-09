Imports System.Data.Common

Public Class DiagnosticBusesManager

#Region "Methodes Web Service"

    Public Shared Function getWSDiagnosticBusesByDiagId(pAgentId As String, ByVal diag_id As String) As DiagnosticBusesList
        Dim objDiagnosticBusesList As New DiagnosticBusesList
        Dim oDiagBuses As New DiagnosticBuses
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response() As Object = Nothing
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticBuses(pAgentId, diag_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem1 As System.Xml.XmlNode()
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem1 In objWSCrodip_response
                        oDiagBuses = New DiagnosticBuses()
                        For Each objWSCrodip_responseItem In objWSCrodip_responseItem1
                            Select Case objWSCrodip_responseItem.Name()
                                Case "id"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
                                    End If
                                Case "idDiagnostic"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.idDiagnostic = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "idLot"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.idLot = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "marque"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.marque = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "nombre"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.nombre = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "genre"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.genre = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "calibre"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.calibre = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "ecartTolere"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.ecartTolere = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "couleur"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.couleur = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "debitMoyen"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.debitMoyen = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "debitNominal"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.debitNominal = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                                Case "dateModificationAgent"
                                    If objWSCrodip_responseItem.InnerText() <> "" Then
                                        oDiagBuses.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
                                    End If
                            End Select
                        Next
                        objDiagnosticBusesList.Liste.Add(oDiagBuses)
                    Next
                Case 1 ' NOK
                    'CSDebug.dispError("Erreur - DiagnosticBusesManager - Code 1 : Non-Trouvée [" & diagnosticbuses_id & "]")
                Case 9 ' BADREQUEST
                    'CSDebug.dispError("Erreur - DiagnosticBusesManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesManager.getWSDiagnosticBusesById ERR : " & ex.Message)
        End Try

        ''Charegement des détails de buses (Tous les détails d'un diag)
        'Dim oListD As DiagnosticBusesDetailList
        'oListD = DiagnosticBusesDetailManager.getWSDiagnosticBusesDetailByDiagId(pAgentId, diag_id)
        ''Répartition des detail dans les buses
        'For Each oDiagBuses In objDiagnosticBusesList.Liste
        '    For Each oBuseDetail As DiagnosticBusesDetail In oListD.Liste
        '        If oBuseDetail.idLot = oDiagBuses.idLot Then
        '            'Si c'est le même lot attribution du detail à la buse
        '            oDiagBuses.diagnosticBusesDetailList.Liste.Add(oBuseDetail)
        '        End If
        '    Next
        'Next



        Return objDiagnosticBusesList

    End Function

    Public Shared Function sendWSDiagnosticBuses(pAgent As Agent, ByVal objDiagnosticBuses As DiagnosticBusesList) As Integer
        Dim tmpArr(1)() As DiagnosticBuses
        tmpArr(0) = objDiagnosticBuses.Liste.ToArray()
        Dim updatedObject() As Object = Nothing
        Try
            ' Appel au WS
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendDiagnosticBuses(pAgent.id, tmpArr, updatedObject)
        Catch ex As Exception
            Dim strMessExt As String = ""
            If (ex.InnerException IsNot Nothing) Then
                strMessExt = ex.InnerException.Message
            End If
            CSDebug.dispFatal("DiagnosticBusesManager.SendWSDiagnosticBuses ERR" & ex.Message & ":" & strMessExt)
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As DiagnosticBuses
        Dim objDiagnosticBuses As New DiagnosticBuses

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case Trim(tmpSerializeItem.LocalName()).ToUpper
                Case "id".ToUpper()
                    objDiagnosticBuses.id = CType(tmpSerializeItem.InnerText, Integer)
                Case "idDiagnostic".ToUpper()
                    objDiagnosticBuses.idDiagnostic = CType(tmpSerializeItem.InnerText, String)
                Case "idLot".ToUpper()
                    objDiagnosticBuses.idLot = CType(tmpSerializeItem.InnerText, String)
                Case "marque".ToUpper()
                    objDiagnosticBuses.marque = CType(tmpSerializeItem.InnerText, String)
                Case "nombre".ToUpper()
                    objDiagnosticBuses.nombre = CType(tmpSerializeItem.InnerText, String)
                Case "genre".ToUpper()
                    objDiagnosticBuses.genre = CType(tmpSerializeItem.InnerText, String)
                Case "calibre".ToUpper()
                    objDiagnosticBuses.calibre = CType(tmpSerializeItem.InnerText, String)
                Case "ecartTolere".ToUpper()
                    objDiagnosticBuses.ecartTolere = CType(tmpSerializeItem.InnerText, String)
                Case "couleur".ToUpper()
                    objDiagnosticBuses.couleur = CType(tmpSerializeItem.InnerText, String)
                Case "debitMoyen".ToUpper()
                    objDiagnosticBuses.debitMoyen = CType(tmpSerializeItem.InnerText, String)
                Case "debitNominal".ToUpper()
                    objDiagnosticBuses.debitNominal = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent".ToUpper()
                    objDiagnosticBuses.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return objDiagnosticBuses
    End Function

#End Region

#Region "Methodes Locales"

    'Public Function getNewId(ByVal structure_id As String)
    '    ' déclarations
    '    Dim tmpDiagnosticId As String = structure_id & "-" & agentCourant.id & "-1"
    '    If structure_id <> "" And structure_id <> "0" Then

    '        Dim bddCommande As New DbCommand
    '        ' On test si la connexion est déjà ouverte ou non
    '        If bddConnection.State() = 0 Then
    '            ' Si non, on la configure et on l'ouvre
    '            bddConnection.ConnectionString = bddConnectString
    '            bddConnection.Open()
    '        End If
    '        bddCommande.Connection = bddConnection
    '        bddCommande.CommandText = "SELECT `DiagnosticItem`.`id` FROM `DiagnosticItem` WHERE `DiagnosticItem`.`id` LIKE '" & structure_id & "-" & agentCourant.id & "-%' ORDER BY `DiagnosticItem`.`id` DESC"
    '        Try
    '            ' On récupère les résultats
    '            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
    '            ' Puis on les parcours
    '            Dim newId As Integer = 0
    '            While tmpListProfils.Read()
    '                ' On récupère le dernier ID
    '                Dim tmpId As Integer = 0
    '                tmpDiagnosticId = tmpListProfils.Item(0).ToString
    '                tmpId = CInt(tmpDiagnosticId.Replace(structure_id & "-" & agentCourant.id & "-", ""))
    '                If tmpId > newId Then
    '                    newId = tmpId
    '                End If
    '            End While
    '            tmpDiagnosticId = structure_id & "-" & agentCourant.id & "-" & (newId + 1)
    '        Catch ex As Exception ' On intercepte l'erreur
    '            Console.Write("DiagnosticManager - newId : " & ex.Message)
    '        End Try

    '        ' Test pour fermeture de connection BDD
    '        If bddConnection.State() <> 0 Then
    '            ' On ferme la connexion
    '            bddConnection.Close()
    '        End If

    '    End If
    '    'on retourne le nouvel id
    '    Return tmpDiagnosticId
    'End Function

    Public Shared Sub save(ByVal objDiagnosticBuses As DiagnosticBuses, pCSDB As CSDb, Optional bSyncro As Boolean = False)
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit être ouverte")

        Dim bddCommande As DbCommand
        bddCommande = pCSDB.getConnection().CreateCommand()
        Try
            Dim nEnr As Integer

            'Test de l'existence de l'élement
            bddCommande.CommandText = "SELECT count(*) FROM DiagnosticBuses WHERE id = " & objDiagnosticBuses.id & " and idDiagnostic = '" & objDiagnosticBuses.idDiagnostic & "'"
            nEnr = bddCommande.ExecuteScalar

            If Not bSyncro Then
                objDiagnosticBuses.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If nEnr = 0 Then
                'Création de l'enregistrement
                ' Initialisation de la requete
                Dim paramsQueryColomuns As String = "`idDiagnostic`,`idLot`"
                Dim paramsQuery As String = "'" & objDiagnosticBuses.idDiagnostic & "','" & objDiagnosticBuses.idLot & "'"

                ' Mise a jour de la date de derniere modification

                If Not objDiagnosticBuses.marque Is Nothing And objDiagnosticBuses.marque <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `marque`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.marque & "'"
                End If
                If Not objDiagnosticBuses.nombre Is Nothing And objDiagnosticBuses.nombre <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `nombre`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.nombre & "'"
                End If
                If Not objDiagnosticBuses.genre Is Nothing And objDiagnosticBuses.genre <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `genre`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.genre & "'"
                End If
                If Not objDiagnosticBuses.calibre Is Nothing And objDiagnosticBuses.calibre <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `calibre`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.calibre & "'"
                End If
                If Not objDiagnosticBuses.ecartTolere Is Nothing And objDiagnosticBuses.ecartTolere <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `ecartTolere`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.ecartTolere & "'"
                End If
                If Not objDiagnosticBuses.couleur Is Nothing And objDiagnosticBuses.couleur <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `couleur`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.couleur & "'"
                End If
                If Not objDiagnosticBuses.debitMoyen Is Nothing And objDiagnosticBuses.debitMoyen <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `debitMoyen`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.debitMoyen & "'"
                End If
                If Not objDiagnosticBuses.debitNominal Is Nothing And objDiagnosticBuses.debitNominal <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `debitNominal`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBuses.debitNominal & "'"
                End If
                If Not objDiagnosticBuses.dateModificationAgent Is Nothing And objDiagnosticBuses.dateModificationAgent <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationAgent`"
                    paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(objDiagnosticBuses.dateModificationAgent) & "'"
                End If
                If Not objDiagnosticBuses.dateModificationCrodip Is Nothing And objDiagnosticBuses.dateModificationCrodip <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationCrodip`"
                    paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(objDiagnosticBuses.dateModificationCrodip) & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "INSERT INTO `DiagnosticBuses` (" & paramsQueryColomuns & ") VALUES (" & paramsQuery & ")"
                bddCommande.ExecuteNonQuery()
                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                    bddCommande.CommandText = "SELECT last_insert_rowid() "
                Else
                    bddCommande.CommandText = "SELECT @@IDENTITY from DiagnosticBuses"
                End If
                objDiagnosticBuses.id = bddCommande.ExecuteScalar()
            Else
                'Mise à jour de l'enregistrement
                Dim paramQuery As String

                paramQuery = "id=" & objDiagnosticBuses.id
                paramQuery = paramQuery & ",idDiagnostic = '" & objDiagnosticBuses.idDiagnostic & "'"
                paramQuery = paramQuery & ",marque = '" & objDiagnosticBuses.marque & "'"
                paramQuery = paramQuery & ",nombre = '" & objDiagnosticBuses.nombre & "'"
                paramQuery = paramQuery & ",genre = '" & objDiagnosticBuses.genre & "'"
                paramQuery = paramQuery & ",calibre = '" & objDiagnosticBuses.calibre & "'"
                paramQuery = paramQuery & ",couleur = '" & objDiagnosticBuses.couleur & "'"
                paramQuery = paramQuery & ",debitMoyen = '" & objDiagnosticBuses.debitMoyen & "'"
                paramQuery = paramQuery & ",debitNominal = '" & objDiagnosticBuses.debitNominal & "'"
                paramQuery = paramQuery & ",dateModificationAgent = '" & objDiagnosticBuses.dateModificationAgent & "'"
                If Not String.IsNullOrEmpty(objDiagnosticBuses.dateModificationCrodip) Then
                    paramQuery = paramQuery & ",dateModificationCrodip = '" & objDiagnosticBuses.dateModificationCrodip & "'"
                End If
                paramQuery = paramQuery & ",idLot = '" & objDiagnosticBuses.idLot & "'"
                paramQuery = paramQuery & ",ecartTolere = '" & objDiagnosticBuses.ecartTolere & "'"

                bddCommande.CommandText = "UPDATE DiagnosticBuses SET " & paramQuery & " WHERE id = " & objDiagnosticBuses.id & " and idDiagnostic = '" & objDiagnosticBuses.idDiagnostic & "'"
                bddCommande.ExecuteNonQuery()

            End If

            'Suppression des Detail de Buses Précédentes
            bddCommande.CommandText = "DELETE FROM  DiagnosticBusesDetail WHERE idDiagnostic = '" & objDiagnosticBuses.idDiagnostic & "' and idLot= " & objDiagnosticBuses.idLot & ""
            bddCommande.ExecuteNonQuery()
            Dim SQL As String = "INSERT INTO DiagnosticBusesDetail ("
            SQL = SQL & " IdDiagnostic , "
            SQL = SQL & " IdBuse , "
            SQL = SQL & " IdLot , "
            SQL = SQL & " debit , "
            SQL = SQL & " ecart , "
            SQL = SQL & " dateModificationAgent , "
            SQL = SQL & " dateModificationCrodip  "
            SQL = SQL & " ) VALUES ("
            SQL = SQL & " @P1,@P2,@P3,@P4,@P5,@P6,@P7"
            SQL = SQL & " )"
            bddCommande.CommandText = SQL
            bddCommande.Prepare()
            If Not objDiagnosticBuses.diagnosticBusesDetailList Is Nothing Then
                If Not objDiagnosticBuses.diagnosticBusesDetailList.Liste Is Nothing Then
                    Dim i As Integer = 1
                    For Each oBDetail As DiagnosticBusesDetail In objDiagnosticBuses.diagnosticBusesDetailList.Liste
                        If Not oBDetail Is Nothing Then
                            bddCommande.CommandText = SQL
                            bddCommande.Prepare()
                            bddCommande.Parameters.Clear()
                            oBDetail.idDiagnostic = objDiagnosticBuses.idDiagnostic
                            oBDetail.idLot = objDiagnosticBuses.idLot
                            oBDetail.dateModificationAgent = DateTime.Now

                            Dim oParam As DbParameter
                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P1"
                                End If
                                .Value = oBDetail.idDiagnostic
                            End With
                            bddCommande.Parameters.Add(oParam)

                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P2"
                                End If
                                .Value = i
                            End With
                            bddCommande.Parameters.Add(oParam)

                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P3"
                                End If
                                .Value = oBDetail.idLot
                            End With
                            bddCommande.Parameters.Add(oParam)

                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P4"
                                End If
                                .Value = oBDetail.debit
                            End With
                            bddCommande.Parameters.Add(oParam)
                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P5"
                                End If
                                .Value = oBDetail.ecart
                            End With
                            bddCommande.Parameters.Add(oParam)
                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P6"
                                End If
                                .Value = oBDetail.dateModificationAgent
                            End With
                            bddCommande.Parameters.Add(oParam)
                            oParam = bddCommande.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@P7"
                                End If
                                .Value = oBDetail.dateModificationCrodip
                            End With
                            bddCommande.Parameters.Add(oParam)
                            Try
                                bddCommande.ExecuteNonQuery()
                            Catch ex As Exception
                                CSDebug.dispFatal("DiagBusesManager.save Details : " & ex.Message.ToString)
                            End Try
                            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                bddCommande.CommandText = "SELECT last_insert_rowid() "
                            Else
                                bddCommande.CommandText = "SELECT @@IDENTITY from DiagnosticBusesDetail"
                            End If
                            oBDetail.id = bddCommande.ExecuteScalar()
                        End If
                        i = i + 1
                    Next
                End If
            End If

        Catch ex As Exception
            CSDebug.dispFatal("DiagBusesManager.save : " & ex.Message.ToString)
        End Try

    End Sub

    Public Shared Sub setSynchro(ByVal objDiagnosticBuses As DiagnosticBuses)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As Date = Date.Now
            dbLink.queryString = "UPDATE DiagnosticBuses SET dateModificationCrodip='" & newDate & "' ,dateModificationAgent='" & newDate & "' WHERE id=" & objDiagnosticBuses.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticBusesManager::setSynchro : " & ex.Message)
        End Try
    End Sub
    Public Shared Function setDiagnosticNbreLotsBuses(pDiagnostic As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande3 As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande3.CommandText = "SELECT MAX(IDLOT) FROM DiagnosticBuses WHERE DiagnosticBuses.idDiagnostic='" & pDiagnostic.id & "'"
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande3.ExecuteReader
            If oDR.HasRows Then
                oDR.Read()
                If oDR.IsDBNull(0) Then
                    pDiagnostic.NbreLotsBuses = 0
                Else

                    pDiagnostic.NbreLotsBuses = CInt(oDR.Item(0))
                End If
            Else
                pDiagnostic.NbreLotsBuses = 1
            End If
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesManager.setDiagnosticNbreLotsBuses ERR" & ex.Message.ToString())
            bReturn = False
        End Try
        oCSDB.free()
        Return bReturn


    End Function

    Public Shared Function getDiagnosticBusesByDiagnostic(oCSDB As CSDb, pDiagnostic As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            pDiagnostic.diagnosticBusesList.Liste.Clear()
            'Récupération du nbre de Lots de Buses
            setDiagnosticNbreLotsBuses(pDiagnostic)

            'Pour Chaqun des lots 
            For nLot As Integer = 1 To pDiagnostic.NbreLotsBuses
                'Recupération des infos de Buses
                Dim nColId As Integer
                Dim bddCommande3 As DbCommand = oCSDB.getConnection().CreateCommand()
                bddCommande3.CommandText = "SELECT * FROM DiagnosticBuses WHERE DiagnosticBuses.idDiagnostic='" & pDiagnostic.id & "' AND IDLOT = '" & nLot & "'"
                Dim oDRDiagnosticBuses As DbDataReader = bddCommande3.ExecuteReader
                'Normalement on en a qu'un type de buse / Lot mais suite à un bug (synchro) il se peut qu'on en ait plusieurs
                '=> on cumule les infos dans le même objet
                Dim oDiagnosticBuses As New DiagnosticBuses
                While oDRDiagnosticBuses.Read()
                    nColId = 0
                    While nColId < oDRDiagnosticBuses.FieldCount()
                        If Not oDRDiagnosticBuses.IsDBNull(nColId) Then
                            oDiagnosticBuses.Fill(oDRDiagnosticBuses.GetName(nColId), oDRDiagnosticBuses.GetValue(nColId))
                        End If
                        nColId = nColId + 1
                    End While
                End While
                oDRDiagnosticBuses.Close()

                'On ajoute la buse dans la liste 
                pDiagnostic.diagnosticBusesList.Liste.Add(oDiagnosticBuses)

                'On va ensuite chercher les infos de mesure de ce Lot
                Dim bddCommande4 As DbCommand = oCSDB.getConnection().CreateCommand()
                bddCommande4.CommandText = "SELECT * FROM DiagnosticBusesDetail WHERE idDiagnostic='" & pDiagnostic.id & "' AND IDLOT = " & nLot & ""
                Dim oDRDiagBusesDetail As DbDataReader = bddCommande4.ExecuteReader
                Dim tmpBuseDetail As DiagnosticBusesDetail
                While oDRDiagBusesDetail.Read()
                    'Creation de l'objet BuseDetail pour recevoir la mesure
                    tmpBuseDetail = New DiagnosticBusesDetail()
                    ' On remplit L'object
                    nColId = 0
                    While nColId < oDRDiagBusesDetail.FieldCount()
                        If Not oDRDiagBusesDetail.IsDBNull(nColId) Then
                            tmpBuseDetail.Fill(oDRDiagBusesDetail.GetName(nColId), oDRDiagBusesDetail.GetValue(nColId))
                        End If
                        nColId = nColId + 1
                    End While
                    'On l'ajoute à la collection de mesures de la buse
                    oDiagnosticBuses.diagnosticBusesDetailList.Liste.Add(tmpBuseDetail)
                End While
                oDRDiagBusesDetail.Close()

            Next nLot


        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesManager.getDiagnosticBusesByDiagnosticId ERR" & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getDiagnosticBusesById(ByVal diagnosticbuses_id As Integer, ByVal pidDiagnostic As String) As DiagnosticBuses
        Debug.Assert(diagnosticbuses_id > 0)
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim oCSDB As New CSDb(True)
        Dim tmpDiagnosticBuses As New DiagnosticBuses
        If diagnosticbuses_id > 0 Then

            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM DiagnosticBuses WHERE DiagnosticBuses.id=" & diagnosticbuses_id & " and idDiagnostic = '" & pidDiagnostic & "'"
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
                                tmpDiagnosticBuses.id = tmpListProfils.Item(tmpColId)
                            Case "idDiagnostic"
                                tmpDiagnosticBuses.idDiagnostic = tmpListProfils.Item(tmpColId).ToString()
                            Case "idLot"
                                tmpDiagnosticBuses.idLot = tmpListProfils.Item(tmpColId).ToString()
                            Case "marque"
                                tmpDiagnosticBuses.marque = tmpListProfils.Item(tmpColId).ToString()
                            Case "nombre"
                                tmpDiagnosticBuses.nombre = tmpListProfils.Item(tmpColId).ToString()
                            Case "genre"
                                tmpDiagnosticBuses.genre = tmpListProfils.Item(tmpColId).ToString()
                            Case "calibre"
                                tmpDiagnosticBuses.calibre = tmpListProfils.Item(tmpColId).ToString()
                            Case "ecartTolere"
                                tmpDiagnosticBuses.ecartTolere = tmpListProfils.Item(tmpColId).ToString()
                            Case "couleur"
                                tmpDiagnosticBuses.couleur = tmpListProfils.Item(tmpColId).ToString()
                            Case "debitMoyen"
                                tmpDiagnosticBuses.debitMoyen = tmpListProfils.Item(tmpColId).ToString()
                            Case "debitNominal"
                                tmpDiagnosticBuses.debitNominal = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpDiagnosticBuses.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                End While
            Catch ex As Exception ' On intercepte l'erreur
                MsgBox("DiagnosticBusesManager Error: " & ex.Message)
            End Try
            oCSDB.free()

            'Cette méthode ne charge pas les BusesDetail, 
            'il faut passer par GetDiagnosticBusesByDiagnostic qui met à jour le diag
        End If
        'on retourne le diagnosticbuses ou un objet vide en cas d'erreur
        Return tmpDiagnosticBuses
    End Function

    Public Shared Function delete(ByVal diagnosticbuses_id As Integer, ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(diagnosticbuses_id))
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim bReturn As Boolean
        Dim oDiagBuses As DiagnosticBuses
        Try

            oDiagBuses = DiagnosticBusesManager.getDiagnosticBusesById(diagnosticbuses_id, pidDiagnostic)
            If oDiagBuses IsNot Nothing Then
                Dim oCSDB As New CSDb(True)
                Dim bddCommande As DbCommand
                bddCommande = oCSDB.getConnection().CreateCommand()
                bddCommande.CommandText = "DELETE FROM DiagnosticBusesDetail WHERE idLot=" & oDiagBuses.idLot & " and idDiagnostic = '" & pidDiagnostic & "'"
                bddCommande.ExecuteNonQuery()
                bddCommande.CommandText = "DELETE FROM DiagnosticBuses WHERE id=" & diagnosticbuses_id & " and idDiagnostic = '" & pidDiagnostic & "'"
                bddCommande.ExecuteNonQuery()
                oCSDB.free()
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesManager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function deleteByDiagnosticId(ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticBusesDetail WHERE  idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticBuses WHERE idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesManager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getUpdates() As DiagnosticBuses()
        ' déclarations
        Dim arrItems(0) As DiagnosticBuses
        Dim bddCommande As DbCommand
        Dim oCSDB As New CSDb(True)
        bddCommande = oCSDB.getConnection.CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `DiagnosticBuses` WHERE `DiagnosticBuses`.`dateModificationAgent`<>`DiagnosticBuses`.`dateModificationCrodip`"

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpDiagnosticBuses As New DiagnosticBuses
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    Select Case tmpListProfils.GetName(tmpColId)
                        Case "id"
                            tmpDiagnosticBuses.id = tmpListProfils.Item(tmpColId)
                        Case "idDiagnostic"
                            tmpDiagnosticBuses.idDiagnostic = tmpListProfils.Item(tmpColId).ToString()
                        Case "idLot"
                            tmpDiagnosticBuses.idLot = tmpListProfils.Item(tmpColId).ToString()
                        Case "marque"
                            tmpDiagnosticBuses.marque = tmpListProfils.Item(tmpColId).ToString()
                        Case "nombre"
                            tmpDiagnosticBuses.nombre = tmpListProfils.Item(tmpColId).ToString()
                        Case "genre"
                            tmpDiagnosticBuses.genre = tmpListProfils.Item(tmpColId).ToString()
                        Case "calibre"
                            tmpDiagnosticBuses.calibre = tmpListProfils.Item(tmpColId).ToString()
                        Case "ecartTolere"
                            tmpDiagnosticBuses.ecartTolere = tmpListProfils.Item(tmpColId).ToString()
                        Case "couleur"
                            tmpDiagnosticBuses.couleur = tmpListProfils.Item(tmpColId).ToString()
                        Case "debitMoyen"
                            tmpDiagnosticBuses.debitMoyen = tmpListProfils.Item(tmpColId).ToString()
                        Case "debitNominal"
                            tmpDiagnosticBuses.debitNominal = tmpListProfils.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpDiagnosticBuses.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpDiagnosticBuses
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("DiagnosticBuseManager.getUpdates ERR: " & ex.Message)
        End Try

        oCSDB.free()


        'on retourne les objet non synchro
        Return arrItems
    End Function

#End Region

End Class