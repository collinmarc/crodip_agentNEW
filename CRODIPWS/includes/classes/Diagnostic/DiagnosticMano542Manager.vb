Imports System.Data.Common

Public Class DiagnosticMano542Manager

#Region "Methodes Web Service"

    ' o
    Public Shared Function WSGetList(ByVal puidDiag As String, paidDiag As String) As DiagnosticMano542List
        Dim objDiagnosticMano542List As New DiagnosticMano542List
        Dim objDiagnosticMano542 As New DiagnosticMano542
        Try

            ' d�clarations
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim objWSCrodip_response() As Object = Nothing
            Dim info As String = ""
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticMano542(puidDiag, paidDiag, info, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItems() As System.Xml.XmlNode
                    ' On boucle chaque item
                    Dim i As Integer = 0
                    For Each objWSCrodip_responseItems In objWSCrodip_response
                        objDiagnosticMano542 = New DiagnosticMano542
                        Dim objWSCrodip_responseItem As System.Xml.XmlElement
                        ' on boucle chaque colone de l'item
                        For Each objWSCrodip_responseItem In objWSCrodip_responseItems
                            If objWSCrodip_responseItem.InnerText() <> "" Then
                                objDiagnosticMano542.Fill(objWSCrodip_responseItem.Name, objWSCrodip_responseItem.InnerText())
                            End If
                        Next
                        objDiagnosticMano542List.Liste.Add(objDiagnosticMano542)
                    Next
                Case 1 ' NOK
                    'CSDebug.dispError("DiagnosticMano542Manager::getWSDiagnosticMano542ById - Code 1 : Non-Trouv�e [" & diagnosticMano542_id & "]")
                Case 9 ' BADREQUEST
                    'CSDebug.dispError("DiagnosticMano542Manager::getWSDiagnosticMano542ById - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("DiagnosticMano542Manager::getWSDiagnosticMano542ById : " & ex.Message)
        End Try
        Dim lst As List(Of DiagnosticMano542)
        lst = objDiagnosticMano542List.Liste.OrderBy(Function(d)
                                                         Return d.pressionControled
                                                     End Function).ToList
        objDiagnosticMano542List.Liste = lst
        Return objDiagnosticMano542List
    End Function

    ' o
    Public Shared Function WSSend(pdiag As Diagnostic) As Integer
        Dim nreturn As Integer = 99
        'Propagation des uid
        For Each oM542 In pdiag.diagnosticMano542List.Liste
            oM542.uiddiagnostic = pdiag.uid
            oM542.aiddiagnostic = pdiag.aid
        Next

        Dim tmpArr(1)() As DiagnosticMano542
        tmpArr(0) = pdiag.diagnosticMano542List.Liste.ToArray()
        Dim updatedObject() As Object = Nothing
        Try
            ' Appel au WS
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim rInfos As String = ""
            nreturn = objWSCrodip.SendDiagnosticMano542(tmpArr, rInfos)
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticMano542Manager.sendWSDiagnosticMano542 ERR", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    ' o
    Public Shared Function xml2object(ByVal arrXml As Object) As DiagnosticMano542
        Dim objDiagnosticMano542 As New DiagnosticMano542

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    objDiagnosticMano542.id = CType(tmpSerializeItem.InnerText, Integer)
                Case "idDiagnostic"
                    objDiagnosticMano542.idDiagnostic = CType(tmpSerializeItem.InnerText, String)
                Case "pressionPulve"
                    objDiagnosticMano542.pressionPulve = CType(tmpSerializeItem.InnerText, String)
                Case "pressionControle"
                    objDiagnosticMano542.pressionControle = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    objDiagnosticMano542.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    objDiagnosticMano542.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next

        Return objDiagnosticMano542
    End Function

#End Region

#Region "Methodes Locales"

    ' o
    Public Shared Function save(ByVal objDiagnosticMano542 As DiagnosticMano542, pCSDB As CSDb, Optional bSyncro As Boolean = False) As Boolean
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit �tre ouverte")

        Dim bReturn As Boolean
        Dim bddCommande As DbCommand
        Dim nEnr As Integer
        Try
            bddCommande = pCSDB.getConnection().CreateCommand()
            'Test de l'existence de l'�lement
            bddCommande.CommandText = "SELECT count(*) FROM DiagnosticMano542 WHERE id = " & objDiagnosticMano542.id & " and idDiagnostic = '" & objDiagnosticMano542.idDiagnostic & "'"
            nEnr = CInt(bddCommande.ExecuteScalar)
            ' Mise a jour de la date de derniere modification
            If Not bSyncro Then
                objDiagnosticMano542.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If
            If nEnr = 0 Then
                ' Initialisation de la requete
                Dim paramsQueryColomuns As String = "`idDiagnostic`"
                Dim paramsQuery As String = "'" & objDiagnosticMano542.idDiagnostic & "'"

                If Not objDiagnosticMano542.pressionPulve Is Nothing And objDiagnosticMano542.pressionPulve <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `pressionPulve`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticMano542.pressionPulve & "'"
                End If
                If Not objDiagnosticMano542.pressionControle Is Nothing And objDiagnosticMano542.pressionControle <> "" Then
                    paramsQueryColomuns = paramsQueryColomuns & " , `pressionControle`"
                    paramsQuery = paramsQuery & " , '" & objDiagnosticMano542.pressionControle & "'"
                End If

                paramsQueryColomuns = paramsQueryColomuns & " , uiddiagnostic "
                paramsQuery = paramsQuery & "," & objDiagnosticMano542.uiddiagnostic
                paramsQueryColomuns = paramsQueryColomuns & " , aiddiagnostic "
                paramsQuery = paramsQuery & ",'" & objDiagnosticMano542.aiddiagnostic & "'"
                paramsQueryColomuns = paramsQueryColomuns & " , uid "
                paramsQuery = paramsQuery & "," & objDiagnosticMano542.uid
                paramsQueryColomuns = paramsQueryColomuns & " , aid "
                paramsQuery = paramsQuery & ",'" & objDiagnosticMano542.aid & "'"
                If Not String.IsNullOrEmpty(objDiagnosticMano542.dateModificationCrodipS) Then
                    paramsQueryColomuns = paramsQueryColomuns & " , dateModificationCrodip "
                    paramsQuery = paramsQuery & ",'" & CSDate.ToCRODIPString((objDiagnosticMano542.dateModificationCrodip)) & "'"
                End If
                If Not String.IsNullOrEmpty(objDiagnosticMano542.dateModificationAgentS) Then
                    paramsQueryColomuns = paramsQueryColomuns & " , dateModificationAgent "
                    paramsQuery = paramsQuery & ",'" & CSDate.ToCRODIPString((objDiagnosticMano542.dateModificationAgent)) & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "INSERT INTO `DiagnosticMano542` (" & paramsQueryColomuns & ") VALUES (" & paramsQuery & ")"
                bddCommande.ExecuteNonQuery()
                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                    bddCommande.CommandText = "SELECT last_insert_rowid()"
                Else
                    bddCommande.CommandText = "SELECT MAX(id) from DiagnosticMano542"

                End If
                Dim nId As Integer = bddCommande.ExecuteScalar()
                objDiagnosticMano542.id = nId
                bddCommande.CommandText = "UPDATE DiagnosticMano542 Set aid = id where id = " & nId
                bddCommande.ExecuteNonQuery()

            Else
                'Mise � jour de l'enregistrement
                Dim paramQuery As String

                paramQuery = "id=" & objDiagnosticMano542.id
                paramQuery = paramQuery & ",idDiagnostic = '" & objDiagnosticMano542.idDiagnostic & "'"
                paramQuery = paramQuery & ",pressionPulve = '" & objDiagnosticMano542.pressionPulve & "'"
                paramQuery = paramQuery & ",pressionControle = '" & objDiagnosticMano542.pressionControle & "'"
                paramQuery = paramQuery & ",dateModificationAgent = '" & objDiagnosticMano542.dateModificationAgent & "'"
                If Not String.IsNullOrEmpty(objDiagnosticMano542.dateModificationCrodip) Then
                    paramQuery = paramQuery & ",dateModificationCrodip = '" & objDiagnosticMano542.dateModificationCrodip & "'"
                End If

                bddCommande.CommandText = "UPDATE DiagnosticMano542 SET " & paramQuery & " WHERE id = " & objDiagnosticMano542.id & " and idDiagnostic = '" & objDiagnosticMano542.idDiagnostic & "'"
                bddCommande.ExecuteNonQuery()

            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticMano542Manager::save() : " & ex.Message.ToString)
            bReturn = False
        End Try

    End Function

    ' o
    Public Shared Sub setSynchro(ByVal objDiagnosticMano542 As DiagnosticMano542)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE DiagnosticMano542 SET dateModificationCrodip='" & newDate & "', dateModificationAgent='" & newDate & "' WHERE id =" & objDiagnosticMano542.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticMano542Manager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' o
    Public Shared Function getDiagnosticMano542ById(ByVal diagnosticMano542_id As String, pIdDiagnostic As String) As DiagnosticMano542
        ' d�clarations
        Dim oCSDB As New CSDb(True)
        Dim tmpDiagnosticMano542 As New DiagnosticMano542
        If diagnosticMano542_id <> "" Then

            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM DiagnosticMano542 WHERE id=" & diagnosticMano542_id & " and idDiagnostic ='" & pIdDiagnostic & "'"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    tmpDiagnosticMano542.FillDR(tmpListProfils)
                End While
            Catch ex As Exception ' On intercepte l'erreur
                MsgBox("DiagnosticMano542Manager::getDiagnosticMano542ById : " & ex.Message)
            End Try
        End If
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        'on retourne le diagnosticbuses ou un objet vide en cas d'erreur
        Return tmpDiagnosticMano542
    End Function

    ' o
    Public Shared Function getDiagnosticMano542ByDiagnostic(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            'Recup�ration des infos de MAno542
            pDiagnostic.diagnosticMano542List.Liste.Clear()
            Dim nColId As Integer
            Dim oDR As DbDataReader
            Dim bddCommande3 As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande3.CommandText = "SELECT * FROM DiagnosticMano542 WHERE idDiagnostic='" & pDiagnostic.id & "'"
            oDR = bddCommande3.ExecuteReader
            Dim oDiagnosticMano542 As DiagnosticMano542
            While oDR.Read()
                oDiagnosticMano542 = New DiagnosticMano542()
                oDiagnosticMano542.FillDR(oDR)
                pDiagnostic.diagnosticMano542List.Liste.Add(oDiagnosticMano542)
            End While
            oDR.Close()


        Catch ex As Exception
            CSDebug.dispError("DiagnosticMAno542Manager.getDiagnosticMano542ByDiagnostic ERR" & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function delete(ByVal diagnosticMano542_id As String, ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(diagnosticMano542_id))
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' d�clarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticMano542 WHERE id=" & diagnosticMano542_id & " and idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticMano542Manager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function deleteByDiagnosticID(ByVal pidDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pidDiagnostic))
        ' d�clarations
        Dim bReturn As Boolean
        Try

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM DiagnosticMano542 WHERE  idDiagnostic = '" & pidDiagnostic & "'"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticMano542Manager.delete ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' o
    Public Shared Function getUpdates() As DiagnosticMano542()
        ' d�clarations
        Dim arrItems(0) As DiagnosticMano542
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `DiagnosticMano542` WHERE `DiagnosticMano542`.`dateModificationAgent`<>`DiagnosticMano542`.`dateModificationCrodip`"

        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpDiagnosticMano542 As New DiagnosticMano542
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpDiagnosticMano542.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.GetValue(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpDiagnosticMano542
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            MsgBox("DiagnosticMano542Manager::getUpdates : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function

#End Region

End Class