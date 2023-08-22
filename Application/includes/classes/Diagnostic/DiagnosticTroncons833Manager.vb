Imports System.Data.Common

Public Class DiagnosticTroncons833Manager

#Region "Methodes Web Service"

    ' o
    Public Shared Function getWSDiagnosticTroncons833ByDiagId(pAgentId As String, pDiagId As String) As DiagnosticTroncons833List
        Dim objDiagnosticTroncons833List As New DiagnosticTroncons833List
        Dim objDiagnosticTroncons833 As DiagnosticTroncons833
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response() As Object = Nothing
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticTroncons833(pAgentId, pDiagId, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItems() As System.Xml.XmlNode
                    ' On boucle chaque item
                    Dim i As Integer = 0
                    For Each objWSCrodip_responseItems In objWSCrodip_response
                        objDiagnosticTroncons833 = New DiagnosticTroncons833
                        Dim objWSCrodip_responseItem As System.Xml.XmlElement
                        ' on boucle chaque colone de l'item
                        For Each objWSCrodip_responseItem In objWSCrodip_responseItems
                            If objWSCrodip_responseItem.InnerText() <> "" Then
                                objDiagnosticTroncons833.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                            End If
                        Next
                        objDiagnosticTroncons833List.Liste.Add(objDiagnosticTroncons833)
                    Next
                Case 1 ' NOK
                    'CSDebug.dispError("DiagnosticTroncons833Manager::getWSDiagnosticTroncons833ById - Code 1 : Non-Trouvée[" & diagnosticTroncons833_id & "]")
                Case 9 ' BADREQUEST
                    'CSDebug.dispError("DiagnosticTroncons833Manager::getWSDiagnosticTroncons833ById - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("DiagnosticTroncons833Manager::getWSDiagnosticTroncons833ById : " & ex.Message)
        End Try
        Return objDiagnosticTroncons833List
    End Function

    ' o
    Public Shared Function sendWSDiagnosticTroncons833(pAgent As Agent, ByVal objDiagnosticTroncons833 As DiagnosticTroncons833List) As Integer
        Dim tmpArr(1)() As DiagnosticTroncons833
        tmpArr(0) = objDiagnosticTroncons833.Liste.ToArray()
        Dim updatedObject() As Object = Nothing
        Dim nreturn As Integer

        Try
            ' Appel au WS
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            'For Each odiag833 As DiagnosticTroncons833 In objDiagnosticTroncons833.Liste
            'on transmet la liste des diag 833
            nreturn = objWSCrodip.SendDiagnosticTroncons833(pAgent.id, tmpArr, updatedObject)

            'Next
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticTroncons833Manager.sendWSDiagnosticTroncons833 ERR" & ex.Message & ":" & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function


#End Region

#Region "Methodes Locales"

    ' o
    Public Shared Function save(ByVal objDiagnosticTroncons833 As DiagnosticTroncons833, pCSDB As CSDb, Optional bSynhcro As Boolean = False) As Boolean
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit être ouverte")

        Dim bddCommande As DbCommand
        Dim oDR As DbDataReader
        Dim nEnr As Integer
        Dim bReturn As Boolean
        Try
            bddCommande = pCSDB.getConnection().CreateCommand()
            'Test de l'existence de l'élement
            bddCommande.CommandText = "SELECT count(*) FROM DiagnosticTroncons833 WHERE id = " & objDiagnosticTroncons833.id & " and idDiagnostic = '" & objDiagnosticTroncons833.idDiagnostic & "'"
            oDR = bddCommande.ExecuteReader()
            If oDR.HasRows Then
                oDR.Read()
                Try
                    nEnr = CType(oDR.GetValue(0), Integer)
                Catch ex As Exception
                    nEnr = 0
                End Try
            End If
            oDR.Close()
            If Not bSynhcro Then
                ' Mise a jour de la date de derniere modification
                objDiagnosticTroncons833.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
            If nEnr = 0 Then
                ' Initialisation de la requete
                Dim paramsQueryColomuns As String = "`idDiagnostic`"
                Dim paramsQuery As String = "'" & objDiagnosticTroncons833.idDiagnostic & "'"


                If Not objDiagnosticTroncons833.idPression Is Nothing And objDiagnosticTroncons833.idPression <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `idPression`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticTroncons833.idPression & "'"
                End If
                If Not objDiagnosticTroncons833.idColumn Is Nothing And objDiagnosticTroncons833.idColumn <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `idColumn`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticTroncons833.idColumn & "'"
                End If
                If Not objDiagnosticTroncons833.pressionSortie Is Nothing And objDiagnosticTroncons833.pressionSortie <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `pressionSortie`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticTroncons833.pressionSortie & "'"
                End If
                If Not objDiagnosticTroncons833.dateModificationAgent Is Nothing And objDiagnosticTroncons833.dateModificationAgent <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationAgent`"
                    paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(objDiagnosticTroncons833.dateModificationAgent) & "'"
                End If
                If Not objDiagnosticTroncons833.dateModificationCrodip Is Nothing And objDiagnosticTroncons833.dateModificationCrodip <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationCrodip`"
                    paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(objDiagnosticTroncons833.dateModificationCrodip) & "'"
                End If
                If Not String.IsNullOrEmpty(objDiagnosticTroncons833.ManocId) Then
                    paramsQueryColomuns = paramsQueryColomuns & " , manoCId"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticTroncons833.ManocId & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "INSERT INTO `DiagnosticTroncons833` (" & paramsQueryColomuns & ") VALUES (" & paramsQuery & ")"
                bddCommande.ExecuteNonQuery()
                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                    bddCommande.CommandText = "SELECT last_insert_rowid() from DiagnosticTroncons833"
                Else
                    bddCommande.CommandText = "SELECT MAX(id) from DiagnosticTroncons833"
                End If

                Dim id As Integer = CInt(bddCommande.ExecuteScalar())
                objDiagnosticTroncons833.id = id
            Else

                'Mise à jour de l'enregistrement
                Dim paramQuery As String

                paramQuery = "id=" & objDiagnosticTroncons833.id
                paramQuery = paramQuery & ",idDiagnostic = '" & objDiagnosticTroncons833.idDiagnostic & "'"
                paramQuery = paramQuery & ",idPression = '" & objDiagnosticTroncons833.idPression & "'"
                paramQuery = paramQuery & ",idColumn = '" & objDiagnosticTroncons833.idColumn & "'"
                paramQuery = paramQuery & ",manoCId = '" & objDiagnosticTroncons833.ManocId & "'"
                paramQuery = paramQuery & ",pressionSortie = '" & objDiagnosticTroncons833.pressionSortie & "'"
                paramQuery = paramQuery & ",dateModificationAgent = '" & CSDate.ToCRODIPString(objDiagnosticTroncons833.dateModificationAgent) & "'"
                If Not String.IsNullOrEmpty(objDiagnosticTroncons833.dateModificationCrodip) Then
                    paramQuery = paramQuery & ",dateModificationCrodip = '" & CSDate.ToCRODIPString(objDiagnosticTroncons833.dateModificationCrodip) & "'"
                End If

                bddCommande.CommandText = "UPDATE DiagnosticTroncons833 SET " & paramQuery & " WHERE id = " & objDiagnosticTroncons833.id & " and idDiagnostic = '" & objDiagnosticTroncons833.idDiagnostic & "'"
                bddCommande.ExecuteNonQuery()

            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticTroncons833Manager::save() : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' o
    Public Shared Sub setSynchro(ByVal objDiagnosticTroncons833 As DiagnosticTroncons833)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE DiagnosticTroncons833 SET dateModificationCrodip='" & newDate & "', dateModificationAgent='" & newDate & "' WHERE id=" & objDiagnosticTroncons833.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticTroncons833Manager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' o
    Public Shared Function getDiagnosticTroncons833ById(ByVal diagnosticTroncons833_id As String, pIdDiagnostic As String) As DiagnosticTroncons833
        ' déclarations
        Dim oCSDB As New CSDb(True)
        Dim tmpDiagnosticTroncons833 As New DiagnosticTroncons833
        If diagnosticTroncons833_id <> "" Then

            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE DiagnosticTroncons833.id=" & diagnosticTroncons833_id & " and idDiagnostic = '" & pIdDiagnostic & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpDiagnosticTroncons833.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                End While
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("DiagnosticTroncons833Manager::getDiagnosticTroncons833ById : " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCSDB Is Nothing Then
                ' On ferme la connexion
                oCSDB.free()
            End If

        End If
        'on retourne le diagnosticbuses ou un objet vide en cas d'erreur
        Return tmpDiagnosticTroncons833
    End Function

    ''' Chargement des troncons833 dans le Diagnostic
    Public Shared Function getDiagnosticTroncons833ByDiagnostic(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As Boolean
        Debug.Assert(pDiagnostic IsNot Nothing)
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnostic.id))

        Dim bReturn As Boolean
        Try
            'Recupération des infos de Troncons833
            pDiagnostic.diagnosticTroncons833.Liste.Clear()
            Dim nColId As Integer
            Dim oDR As DbDataReader
            Dim bddCommande3 As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande3.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE idDiagnostic='" & pDiagnostic.id & "' ORDER BY id"
            oDR = bddCommande3.ExecuteReader
            Dim oDiagnosticTroncons833 As DiagnosticTroncons833
            While oDR.Read()
                oDiagnosticTroncons833 = New DiagnosticTroncons833()
                nColId = 0
                While nColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(nColId) Then
                        oDiagnosticTroncons833.Fill(oDR.GetName(nColId), oDR.GetValue(nColId))
                    End If
                    nColId = nColId + 1
                End While
                pDiagnostic.diagnosticTroncons833.Liste.Add(oDiagnosticTroncons833)
            End While
            oDR.Close()


        Catch ex As Exception
            CSDebug.dispError("DiagnosticTroncons833Manager.getDiagnosticTroncons833ByDiagnostic ERR" & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn
    End Function
    ' o
    Public Shared Function getUpdates() As DiagnosticTroncons833()
        ' déclarations
        Dim oCSDB As New CSDb(True)
        Dim arrItems(0) As DiagnosticTroncons833
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `DiagnosticTroncons833` WHERE `DiagnosticTroncons833`.`dateModificationAgent`<>`DiagnosticTroncons833`.`dateModificationCrodip`"

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpDiagnosticTroncons833 As New DiagnosticTroncons833
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpDiagnosticTroncons833.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.GetValue(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpDiagnosticTroncons833
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            MsgBox("DiagnosticTroncons833Manager::getUpdates : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function delete(ByVal diagnosticTroncons833_id As String, ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(diagnosticTroncons833_id))
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticTroncons833 WHERE id=" & diagnosticTroncons833_id & " and idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticTroncons833Manager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function deleteByDiagnosticID(ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticTroncons833 WHERE  idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticTroncons833Manager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region

End Class