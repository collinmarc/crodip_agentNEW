Imports System.Data.Common

Public Class DiagnosticTroncons833Manager
    Inherits RootManager
#Region "Methodes Web Service"

    ' o
    Public Shared Function WSGetList(puidDiag As String, paidDiag As String) As DiagnosticTroncons833List
        Dim objDiagnosticTroncons833List As New DiagnosticTroncons833List
        Dim objDiagnosticTroncons833 As DiagnosticTroncons833
        Try

            ' déclarations
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim objWSCrodip_response() As Object = Nothing
            Dim info As String = ""
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticTroncons833(puidDiag, paidDiag, info, objWSCrodip_response)
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
            CSDebug.dispError("DiagnosticTroncons833Manager::WSGetList : ", ex)
        End Try
        Dim lst As List(Of DiagnosticTroncons833)
        lst = objDiagnosticTroncons833List.Liste.OrderBy(Function(d)
                                                             Return d.idPression
                                                         End Function).ToList
        objDiagnosticTroncons833List.Liste = lst
        Return objDiagnosticTroncons833List
    End Function

    ' o
    Public Shared Function WSSend(pdiag As Diagnostic) As Integer
        Dim nReturn As Integer = 99
        'Propagation des uid
        For Each oT833 In pdiag.diagnosticTroncons833.Liste
            oT833.uiddiagnostic = pdiag.uid
            oT833.aiddiagnostic = pdiag.aid
        Next

        Dim tmpArr(1)() As DiagnosticTroncons833
        tmpArr(0) = pdiag.diagnosticTroncons833.Liste.ToArray()
        Dim updatedObject() As Object = Nothing
        Try
            ' Appel au WS
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim rInfos As String = ""
            nReturn = objWSCrodip.SendDiagnosticTroncons833(tmpArr, rInfos)
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticTroncons833Manager.sendWS ERR", ex)
            nReturn = -1
        End Try
        Return nReturn
    End Function


#End Region

#Region "Methodes Locales"

    ' o
    Public Shared Function save(ByVal objDiagnosticTroncons833 As DiagnosticTroncons833, pCSDB As CSDb, Optional bSynhcro As Boolean = False) As Boolean
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit être ouverte")

        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            bddCommande = pCSDB.getConnection().CreateCommand()
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
            If Not String.IsNullOrEmpty(objDiagnosticTroncons833.ManocId) Then
                paramsQueryColomuns = paramsQueryColomuns & " , manoCId"
                paramsQuery = paramsQuery & " , '" & objDiagnosticTroncons833.ManocId & "'"
            End If

            paramsQueryColomuns = paramsQueryColomuns & " , uiddiagnostic "
            paramsQuery = paramsQuery & "," & objDiagnosticTroncons833.uiddiagnostic
            paramsQueryColomuns = paramsQueryColomuns & " , aiddiagnostic "
            paramsQuery = paramsQuery & ",'" & objDiagnosticTroncons833.aiddiagnostic & "'"
            paramsQueryColomuns = paramsQueryColomuns & " , uid "
            paramsQuery = paramsQuery & "," & objDiagnosticTroncons833.uid
            paramsQueryColomuns = paramsQueryColomuns & " , aid "
            paramsQuery = paramsQuery & ",'" & objDiagnosticTroncons833.aid & "'"
            If Not String.IsNullOrEmpty(objDiagnosticTroncons833.dateModificationCrodipS) Then
                paramsQueryColomuns = paramsQueryColomuns & " , dateModificationCrodip "
                paramsQuery = paramsQuery & ",'" & CSDate.ToCRODIPString((objDiagnosticTroncons833.dateModificationCrodip)) & "'"
            End If
            If Not String.IsNullOrEmpty(objDiagnosticTroncons833.dateModificationAgentS) Then
                paramsQueryColomuns = paramsQueryColomuns & " , dateModificationAgent "
                paramsQuery = paramsQuery & ",'" & CSDate.ToCRODIPString((objDiagnosticTroncons833.dateModificationAgent)) & "'"
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
            CSDb.ExecuteSQL("UPDATE DiagnosticTroncons833 Set aid = id where id = " & id)

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticTroncons833Manager::save() : ", ex)
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
                    tmpDiagnosticTroncons833.FillDR(tmpListProfils)
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
            Dim oDR As DbDataReader
            Dim bddCommande3 As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande3.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE idDiagnostic='" & pDiagnostic.id & "' ORDER BY id"
            oDR = bddCommande3.ExecuteReader
            Dim oDiagnosticTroncons833 As DiagnosticTroncons833
            While oDR.Read()
                oDiagnosticTroncons833 = New DiagnosticTroncons833()
                oDiagnosticTroncons833.FillDR(oDR)
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