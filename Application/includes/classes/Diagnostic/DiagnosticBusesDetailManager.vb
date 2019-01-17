Public Class DiagnosticBusesDetailManager

#Region "Methodes Web Service"

    'ok
    Public Shared Function getWSDiagnosticBusesDetailById(ByVal diag_id As String) As DiagnosticBusesDetailList
        Dim objDiagnosticBusesDetailList As New DiagnosticBusesDetailList
        Dim objDiagnosticBusesDetail As New DiagnosticBusesDetail
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticBusesDetail(agentCourant.id, diag_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItemLst As System.Xml.XmlNode()
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItemLst In objWSCrodip_response
                        objDiagnosticBusesDetail = New DiagnosticBusesDetail
                        For Each objWSCrodip_responseItem In objWSCrodip_responseItemLst
                            objDiagnosticBusesDetail.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        Next
                        objDiagnosticBusesDetailList.Liste.Add(objDiagnosticBusesDetail)
                    Next
                Case 1 ' NOK
                    'CSDebug.dispError("DiagnosticBusesDetailManager::getWSDiagnosticBusesDetailById - Code 1 : Non-Trouvée[ " & diagnosticbusesdetail_id & "]")
                Case 9 ' BADREQUEST
                    'CSDebug.dispFatal("DiagnosticBusesDetailManager::getWSDiagnosticBusesDetailById - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesDetailManager::getWSDiagnosticBusesDetailById ERR: " & ex.Message)
        End Try
        Return objDiagnosticBusesDetailList

    End Function

    'ok
    Public Shared Function sendWSDiagnosticBusesDetail(pAgent As Agent, ByVal objDiagnosticBusesDetail As DiagnosticBusesDetailList, ByRef updatedObject As Object) As Integer
        Dim tmpArr(1)() As DiagnosticBusesDetail
        tmpArr(0) = objDiagnosticBusesDetail.Liste.ToArray()
        Try
            ' Appel au WS
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendDiagnosticBusesDetail(pAgent.id, tmpArr, updatedObject)
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticBusesDetailManager.sendWSDiagnosticBusesDetail ERR" & ex.Message & ":" & IIf(ex.InnerException IsNot Nothing, ex.InnerException.Message, ""))
            Return -1
        End Try
    End Function

    'ok
    Public Shared Function xml2object(ByVal arrXml As Object) As DiagnosticBusesDetail
        Dim objDiagnosticBusesDetail As New DiagnosticBusesDetail

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    objDiagnosticBusesDetail.id = CType(tmpSerializeItem.InnerText, Integer)
                Case "idDiagnostic"
                    objDiagnosticBusesDetail.idDiagnostic = CType(tmpSerializeItem.InnerText, String)
                Case "idBuse"
                    objDiagnosticBusesDetail.idBuse = CType(tmpSerializeItem.InnerText, Integer)
                Case "idLot"
                    objDiagnosticBusesDetail.idLot = CType(tmpSerializeItem.InnerText, String)
                Case "debit"
                    objDiagnosticBusesDetail.debit = CType(tmpSerializeItem.InnerText, String)
                Case "ecart"
                    objDiagnosticBusesDetail.ecart = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    objDiagnosticBusesDetail.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    objDiagnosticBusesDetail.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return objDiagnosticBusesDetail
    End Function

#End Region

#Region "Methodes Locales"

    ' ok
    Public Shared Sub save(ByVal objDiagnosticBusesDetail As DiagnosticBusesDetail, Optional bSyncro As Boolean = False)

        Try
            Dim oCSDb As New CSDb(True)
            Dim bddCommande As New OleDb.OleDbCommand
            Dim oDR As OleDb.OleDbDataReader
            Dim nEnr As Integer
            ' On test si la connexion est déjà ouverte ou non
            bddCommande.Connection = oCSDb.getConnection()

            'Test de l'existence de l'élement
            bddCommande.CommandText = "SELECT count(*) FROM DiagnosticBusesDetail WHERE id = " & objDiagnosticBusesDetail.id & " and idDiagnostic = '" & objDiagnosticBusesDetail.idDiagnostic & "'"
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
            If nEnr = 0 Then
                ' Initialisation de la requete
                Dim paramsQueryColomuns As String = "`idDiagnostic`"
                Dim paramsQuery As String = "'" & objDiagnosticBusesDetail.idDiagnostic & "'"
                paramsQueryColomuns = paramsQueryColomuns & " , `idBuse`"
                paramsQuery = paramsQuery & " , " & objDiagnosticBusesDetail.idBuse & ""
                paramsQueryColomuns = paramsQueryColomuns & " , `idLot`"
                paramsQuery = paramsQuery & " , " & objDiagnosticBusesDetail.idLot & ""

                ' Mise a jour de la date de derniere modification
                If Not bSyncro Then
                    objDiagnosticBusesDetail.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not objDiagnosticBusesDetail.debit Is Nothing And objDiagnosticBusesDetail.debit <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `debit`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBusesDetail.debit & "'"
                End If
                If Not objDiagnosticBusesDetail.ecart Is Nothing And objDiagnosticBusesDetail.ecart <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `ecart`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBusesDetail.ecart & "'"
                End If
                If Not objDiagnosticBusesDetail.dateModificationAgent Is Nothing And objDiagnosticBusesDetail.dateModificationAgent <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationAgent`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBusesDetail.dateModificationAgent & "'"
                End If
                If Not objDiagnosticBusesDetail.dateModificationCrodip Is Nothing And objDiagnosticBusesDetail.dateModificationCrodip <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `dateModificationCrodip`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticBusesDetail.dateModificationCrodip & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "INSERT INTO `DiagnosticBusesDetail` (" & paramsQueryColomuns & ") VALUES (" & paramsQuery & ")"
                bddCommande.ExecuteNonQuery()

                bddCommande.CommandText = "SELECT MAX(id) from DiagnosticBusesDEtail"
                oDR = bddCommande.ExecuteReader()
                If oDR.HasRows() Then
                    oDR.Read()
                    objDiagnosticBusesDetail.id = oDR.GetValue(0)
                End If
                oDR.Close()

            Else
                'Mise à jour de l'enregistrement
                Dim paramQuery As String
                objDiagnosticBusesDetail.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

                paramQuery = "id=" & objDiagnosticBusesDetail.id
                paramQuery = paramQuery & ",idDiagnostic = '" & objDiagnosticBusesDetail.idDiagnostic & "'"
                paramQuery = paramQuery & ",idBuse = " & objDiagnosticBusesDetail.idBuse & ""
                paramQuery = paramQuery & ",idLot = " & objDiagnosticBusesDetail.idLot & ""
                paramQuery = paramQuery & ",debit = '" & objDiagnosticBusesDetail.debit & "'"
                paramQuery = paramQuery & ",ecart = '" & objDiagnosticBusesDetail.ecart & "'"
                paramQuery = paramQuery & ",dateModificationAgent = '" & objDiagnosticBusesDetail.dateModificationAgent & "'"
                If Not String.IsNullOrEmpty(objDiagnosticBusesDetail.dateModificationCrodip) Then
                    paramQuery = paramQuery & ",dateModificationCrodip = '" & objDiagnosticBusesDetail.dateModificationCrodip & "'"
                End If

                bddCommande.CommandText = "UPDATE DiagnosticBusesDetail SET " & paramQuery & " WHERE id = " & objDiagnosticBusesDetail.id & " and idDiagnostic = '" & objDiagnosticBusesDetail.idDiagnostic & "'"
                bddCommande.ExecuteNonQuery()


            End If
            ' Test pour fermeture de connection BDD
            oCSDb.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticBusesDetailManager::save() : " & ex.Message.ToString)
        End Try

    End Sub

    ' ok
    Public Shared Sub setSynchro(ByVal objDiagnosticBusesDetail As DiagnosticBusesDetail)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `DiagnosticBusesDetail` SET `DiagnosticBusesDetail`.`dateModificationCrodip`='" & newDate & "',`DiagnosticBusesDetail`.`dateModificationAgent`='" & newDate & "' WHERE `DiagnosticBusesDetail`.`id`='" & objDiagnosticBusesDetail.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticBusesDetailManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' ok
    Public Shared Function getDiagnosticBusesDetailById(ByVal diagnosticbusesdetail_id As String, pidDiag As String) As DiagnosticBusesDetail
        Debug.Assert(Not String.IsNullOrEmpty(diagnosticbusesdetail_id))
        Debug.Assert(Not String.IsNullOrEmpty(pidDiag))
        ' déclarations
        Dim oCSDB As New CSDb(True)
        Dim tmpDiagnosticBusesDetail As DiagnosticBusesDetail
        If diagnosticbusesdetail_id <> "" Then

            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM DiagnosticBusesDetail WHERE DiagnosticBusesDetail.id=" & diagnosticbusesdetail_id & " and idDiagnostic = '" & pidDiag & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    tmpDiagnosticBusesDetail = New DiagnosticBusesDetail()
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpDiagnosticBusesDetail.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                End While
                tmpListProfils.Close()

            Catch ex As Exception ' On intercepte l'erreur
                MsgBox("DiagnosticBusesDetailManager::getDiagnosticBusesDetailById : " & ex.Message)
            End Try

            oCSDB.free()
        End If
        'on retourne le diagnosticbuses ou un objet vide en cas d'erreur
        Return tmpDiagnosticBusesDetail
    End Function

    Public Shared Function delete(ByVal diagnosticbuses_id As String, ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(diagnosticbuses_id))
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' déclarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)

            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticBusesDetail WHERE id=" & diagnosticbuses_id & " and idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception

            CSDebug.dispError("DiagnosticBusesDetailManager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ' ok
    Public Shared Function getUpdates() As DiagnosticBusesDetail()
        ' déclarations
        Dim arrItems(0) As DiagnosticBusesDetail
        Dim bddCommande As OleDb.OleDbCommand = Nothing
        Dim oCSdb As New CSDb(True)
        bddCommande.CommandText = "SELECT * FROM `DiagnosticBusesDetail` WHERE `DiagnosticBusesDetail`.`dateModificationAgent`<>`DiagnosticBusesDetail`.`dateModificationCrodip`"

        Try
            ' On récupère les résultats
            Dim oDR As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While oDR.Read()
                ' On rempli notre tableau
                Dim tmpDiagnosticBusesDetail As New DiagnosticBusesDetail
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    Select Case oDR.GetName(tmpColId)
                        Case "id"
                            tmpDiagnosticBusesDetail.id = oDR.Item(tmpColId)
                        Case "idDiagnostic"
                            tmpDiagnosticBusesDetail.idDiagnostic = oDR.Item(tmpColId).ToString()
                        Case "idBuse"
                            tmpDiagnosticBusesDetail.idBuse = oDR.Item(tmpColId)
                        Case "idLot"
                            tmpDiagnosticBusesDetail.idLot = oDR.Item(tmpColId).ToString()
                        Case "debit"
                            tmpDiagnosticBusesDetail.debit = oDR.Item(tmpColId).ToString()
                        Case "ecart"
                            tmpDiagnosticBusesDetail.ecart = oDR.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpDiagnosticBusesDetail.dateModificationAgent = CSDate.ToCRODIPString(oDR.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpDiagnosticBusesDetail.dateModificationCrodip = CSDate.ToCRODIPString(oDR.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpDiagnosticBusesDetail
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
            oDR.Close()
        Catch ex As Exception ' On intercepte l'erreur
            MsgBox("DiagnosticBusesDetailManager::getUpdates : " & ex.Message)
        End Try

        oCSdb.free()

        'on retourne les objet non synchro
        Return arrItems
    End Function

#End Region

End Class