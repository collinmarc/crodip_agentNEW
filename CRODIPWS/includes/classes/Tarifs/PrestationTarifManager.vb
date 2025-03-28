Imports System.Collections.Generic
Imports System.Data.Common

Public Class PrestationTarifManager
    Inherits RootManager
#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As PrestationTarif
        Dim oreturn As PrestationTarif
        oreturn = RootWSGetById(Of PrestationTarif)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As PrestationTarif, ByRef pobjOut As PrestationTarif) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of PrestationTarif)(pObjIn, pobjOut)
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager.WSSend ERR: ", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    ' OK
    'Public Shared Function getWSPrestationTarifById(ByVal PrestationTarif_id As Integer, ByVal PrestationTarif_idCategorie As Integer, pAgent As Agent) As Object
    '    Dim curObject As New PrestationTarif
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        'Dim codeResponse As Integer = objWSCrodip.GetPrestationTarif(pAgent.id, PrestationTarif_id, pAgent.idStructure, PrestationTarif_idCategorie, objWSCrodip_response)
    '        'Select Case codeResponse
    '        '    Case 0 ' OK
    '        '        ' construction de l'objet
    '        '        Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '        '        For Each objWSCrodip_responseItem In objWSCrodip_response
    '        '            Select Case objWSCrodip_responseItem.Name()
    '        '                Case "id"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
    '        '                    End If
    '        '                Case "idStructure"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.idStructure = CType(objWSCrodip_responseItem.InnerText(), Integer)
    '        '                    End If
    '        '                Case "idCategorie"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.idCategorie = CType(objWSCrodip_responseItem.InnerText(), Integer)
    '        '                    End If
    '        '                Case "description"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.description = CType(objWSCrodip_responseItem.InnerText(), String)
    '        '                    End If
    '        '                Case "tarifHT"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.tarifHT = CType(objWSCrodip_responseItem.InnerText().Replace(".", ","), Double)
    '        '                    End If
    '        '                Case "tarifTTC"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.tarifTTC = CType(objWSCrodip_responseItem.InnerText().Replace(".", ","), Double)
    '        '                    End If
    '        '                Case "tva"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.tva = CType(objWSCrodip_responseItem.InnerText().Replace(".", ","), Double)
    '        '                    End If
    '        '                Case "dateModificationCrodip"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
    '        '                    End If
    '        '                Case "dateModificationAgent"
    '        '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '        '                        curObject.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
    '        '                    End If
    '        '            End Select
    '        '        Next
    '        '    Case 1 ' NOK
    '        '        CSDebug.dispFatal("TarifsManager::getWSPrestationTarifById - Code 1 : Non-Trouvée")
    '        '    Case 9 ' BADREQUEST
    '        '        CSDebug.dispFatal("TarifsManager::getWSPrestationTarifById - Code 9 : Bad Request")
    '        'End Select
    '    Catch ex As Exception
    '        CSDebug.dispFatal("TarifsManager::getWSPrestationTarifById : " & ex.Message)
    '    End Try
    '    Return curObject
    'End Function

    '' OK
    'Public Shared Function sendWSPrestationTarif(ByVal curObject As PrestationTarif, pAgent As Agent, ByRef updatedObject As Object) As Integer
    '    Try
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
    '        '            'Return objWSCrodip.SendPrestationTarif(pAgent.id, curObject, updatedObject)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    '' OK
    'Public Shared Function xml2object(ByVal arrXml As Object) As PrestationTarif
    '    Dim newObject As New PrestationTarif
    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        Select Case tmpSerializeItem.LocalName()
    '            Case "id"
    '                newObject.id = CType(tmpSerializeItem.InnerText, Integer)
    '            Case "idStructure"
    '                newObject.idStructure = CType(tmpSerializeItem.InnerText, Integer)
    '            Case "idCategorie"
    '                newObject.idCategorie = CType(tmpSerializeItem.InnerText, Integer)
    '            Case "description"
    '                newObject.description = CType(tmpSerializeItem.InnerText, String)
    '            Case "tarifHT"
    '                newObject.tarifHT = CType(tmpSerializeItem.InnerText.ToString.Replace(".", ","), Double)
    '            Case "tarifTTC"
    '                newObject.tarifTTC = CType(tmpSerializeItem.InnerText.ToString.Replace(".", ","), Double)
    '            Case "tva"
    '                newObject.tva = CType(tmpSerializeItem.InnerText.ToString.Replace(".", ","), Double)
    '            Case "dateModificationAgent"
    '                newObject.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '            Case "dateModificationCrodip"
    '                newObject.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '        End Select
    '    Next
    '    Return newObject
    'End Function

#End Region

#Region "Methodes Locales"

    ' OK
    Public Shared Function save(ByVal curObject As PrestationTarif, pAgent As Agent, Optional bSyncro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Try
            Dim dbLink As New CSDb(True)
            If curObject.getEtat <> Tarif.BDEtat.ETATNONE Then
                If curObject.getEtat = Tarif.BDEtat.ETATDELETED Then
                    If curObject.id <> 0 Then
                        dbLink.Execute("DELETE FROM PrestationTarif  WHERE id= " & curObject.id)
                    End If
                    curObject.setEtat(Tarif.BDEtat.ETATNONE)
                Else
                    If curObject.id = 0 Then
                        curObject.id = PrestationTarifManager.getNextId()
                    End If
                    If Not exists(curObject) Then
                        PrestationTarifManager.create(curObject)
                    End If

                    ' Mise a jour de la date de derniere modification
                    If Not bSyncro Then
                        curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                    End If

                    Dim paramsQuery As String = ""
                    paramsQuery = paramsQuery & "`description`='" & CSDb.secureString(curObject.description) & "'"
                    'If curObject.tarifHT <> 0 Then
                    paramsQuery = paramsQuery & " , `tarifHT`='" & CSDb.secureString(curObject.tarifHT) & "'"
                    'End If
                    'If curObject.tarifTTC <> 0 Then
                    paramsQuery = paramsQuery & " , `tarifTTC`='" & CSDb.secureString(curObject.tarifTTC) & "'"
                    'End If
                    paramsQuery = paramsQuery & " , `tva`='" & CSDb.secureString(curObject.tva) & "'"
                    paramsQuery = paramsQuery & " , uidstructure=" & curObject.uidstructure & ""
                    paramsQuery = paramsQuery & " , uidcategorie=" & curObject.uidcategorie & ""

                    paramsQuery = paramsQuery & curObject.getRootQuery()

                    '####################################################
                    '## Execution de la requete
                    dbLink.Execute("UPDATE `PrestationTarif` SET " & paramsQuery & " WHERE id=" & curObject.id & " AND idStructure = " & curObject.idStructure & " and idCategorie = " & curObject.idCategorie & "")

                    curObject.setEtat(Tarif.BDEtat.ETATNONE)
                End If
            End If
            dbLink.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PrestationTarifManager::save() : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Retourne le prochain id Disponible pour la Structure
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getNextId() As Integer
        Dim newId As Integer = 1
        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '####################################################
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT MAX(id)+1 as NEWID  FROM PrestationTarif")
            While tmpResults.Read()
                '# construction de l'objet
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId)
                        Case "NEWID"
                            If Not tmpResults.IsDBNull(tmpColId) Then
                                newId = tmpResults.Item(tmpColId)
                            Else
                                newId = 1
                            End If
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '###############################
            End While
            tmpResults.Close()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getNextId() : " & ex.Message.ToString)
        End Try
        Return newId
    End Function
    Private Shared Function create(pTarif As PrestationTarif) As Boolean
        Dim newId As Integer = 0
        Dim bReturn As Boolean
        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '####################################################
            '## Execution de la requete
            Dim oCmd As DbCommand
            oCmd = dbLink.getConnection().CreateCommand()
            oCmd.CommandText = "INSERT INTO PrestationTarif (id,idStructure,idCategorie) VALUES (" & pTarif.id & "," & pTarif.idStructure & "," & pTarif.idCategorie & ")"
            oCmd.ExecuteNonQuery()
            dbLink.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PrestationTarifManager::create() : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' OK
    Private Shared Function exists(ByVal curObject As PrestationTarif) As Boolean
        Dim bReturn As Boolean
        Dim dbLink As New CSDb(True)
        Try
            '## Préparation de la connexion
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE id=" & curObject.id & " AND idStructure=" & curObject.idStructure & " AND idCategorie=" & curObject.idCategorie & "")
            'tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE id=" & curObject.id & "")
            '################################################################
            bReturn = False
            If tmpResults.HasRows Then
                bReturn = True
            End If
            tmpResults.Close()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::exists() : " & ex.Message)
            bReturn = False
        End Try
        If dbLink IsNot Nothing Then
            dbLink.free()
        End If

        Return bReturn
    End Function

    ' 
    Public Shared Sub setSynchro(ByVal curObject As PrestationTarif)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE PrestationTarif SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id=" & curObject.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' OK
    Public Shared Sub delete(ByVal curObject As PrestationTarif)
        Try
            PrestationTarifManager.delete(curObject.id)
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::delete() : " & ex.Message)
        End Try
    End Sub
    Public Shared Sub delete(ByVal curObjectId As Integer)
        Try
            Dim bdd As New CSDb(True)
            bdd.Execute("DELETE FROM `PrestationTarif` WHERE `PrestationTarif`.`id`=" & curObjectId & "")
            bdd.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::delete() : " & ex.Message)
        End Try

    End Sub

    ' 
    Public Shared Function getByuId(ByVal idObject As Integer, pIdStructure As Integer) As PrestationTarif
        Debug.Assert(idObject > 0)
        Debug.Assert(pIdStructure > 0)
        Dim curObject As PrestationTarif = New PrestationTarif
        Try
            If idObject <> 0 Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim tmpResults As DbDataReader
                tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE uid=" & idObject)
                '################################################################
                Dim i As Integer = 0
                While tmpResults.Read()
                    '# construction de l'objet
                    Dim tmpObject As New PrestationTarif
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        Select Case tmpResults.GetName(tmpColId)
                            Case "id"
                                tmpObject.id = tmpResults.Item(tmpColId)
                            Case "idStructure"
                                tmpObject.idStructure = tmpResults.Item(tmpColId)
                            Case "idCategorie"
                                tmpObject.idCategorie = tmpResults.Item(tmpColId)
                            Case "description"
                                tmpObject.description = tmpResults.Item(tmpColId).ToString()
                            Case "tarifHT"
                                Try
                                    tmpObject.tarifHT = tmpResults.Item(tmpColId)
                                Catch ex As Exception
                                    tmpObject.tarifHT = 0
                                End Try
                            Case "tarifTTC"
                                Try

                                    tmpObject.tarifTTC = tmpResults.Item(tmpColId)
                                Catch ex As Exception
                                    tmpObject.tarifTTC = 0
                                End Try

                            Case "tva"
                                Try


                                    tmpObject.tva = tmpResults.Item(tmpColId)
                                Catch ex As Exception
                                    tmpObject.tva = 0

                                End Try

                            Case "dateModificationAgent"
                                tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    '# Ajout au tableau de résultats
                    curObject = tmpObject
                    curObject.setEtat(Tarif.BDEtat.ETATNONE)
                    '###############################
                End While
                '################################################################
                tmpResults.Close()
                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getById(" & idObject & ") : " & ex.Message)
        End Try
        Return curObject
    End Function

    ' 
    Public Shared Function getArrayByStructureId(ByVal idStructure As Integer) As PrestationTarif()
        Dim arrObjects(0) As PrestationTarif
        Try
            If idStructure <> 0 Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim oDR As DbDataReader
                oDR = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE idStructure=" & idStructure & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While oDR.Read()
                    '# construction de l'objet
                    Dim oNewTarif As New PrestationTarif
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDR.FieldCount()
                        While tmpColId < oDR.FieldCount()
                            If Not oDR.IsDBNull(tmpColId) Then
                                oNewTarif.Fill(oDR.GetName(tmpColId), oDR.GetValue(tmpColId))
                            End If

                            tmpColId = tmpColId + 1
                        End While
                        tmpColId = tmpColId + 1
                    End While
                    oNewTarif.setEtat(Tarif.BDEtat.ETATNONE)
                    '# Ajout au tableau de résultats
                    arrObjects(i) = oNewTarif
                    i += 1
                    ReDim Preserve arrObjects(i)
                    '###############################
                End While
                ReDim Preserve arrObjects(i - 1)
                '################################################################
                oDR.Close()
                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getArrayByStructureId(" & idStructure & ") : " & ex.Message)
        End Try
        Return arrObjects
    End Function

    ' 
    Public Shared Function getArrayByCategorieId(ByVal idCategorie As Integer) As PrestationTarif()
        Dim arrObjects(0) As PrestationTarif
        Try
            If idCategorie <> 0 Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim oDR As DbDataReader
                oDR = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE idCategorie=" & idCategorie & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While oDR.Read()
                    '# construction de l'objet
                    Dim oNewTarif As New PrestationTarif
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDR.FieldCount()
                        If Not oDR.IsDBNull(tmpColId) Then
                            oNewTarif.Fill(oDR.GetName(tmpColId), oDR.GetValue(tmpColId))
                        End If

                        tmpColId = tmpColId + 1
                    End While
                    oNewTarif.setEtat(Tarif.BDEtat.ETATNONE)
                    '# Ajout au tableau de résultats
                    arrObjects(i) = oNewTarif
                    i += 1
                    ReDim Preserve arrObjects(i)
                    '###############################
                End While
                ReDim Preserve arrObjects(i - 1)
                '################################################################
                oDR.Close()
                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getArrayByCategorieId(" & idCategorie & ") : " & ex.Message)
        End Try
        Return arrObjects
    End Function
    Public Shared Function getlstByCategorieId(ByVal idCategorie As Integer) As List(Of PrestationTarif)
        Dim lstReturn As New List(Of PrestationTarif)
        Try
            If idCategorie <> 0 Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim oDR As DbDataReader
                oDR = dbLink.getResult2s("SELECT * FROM `PrestationTarif` WHERE idCategorie=" & idCategorie & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While oDR.Read()
                    '# construction de l'objet
                    Dim oNewTarif As New PrestationTarif
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDR.FieldCount()
                        If Not oDR.IsDBNull(tmpColId) Then
                            oNewTarif.Fill(oDR.GetName(tmpColId), oDR.GetValue(tmpColId))
                        End If

                        tmpColId = tmpColId + 1
                    End While
                    oNewTarif.setEtat(Tarif.BDEtat.ETATNONE)
                    '# Ajout au tableau de résultats
                    lstReturn.Add(oNewTarif)
                    '###############################
                End While
                '################################################################
                oDR.Close()
                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getlstByCategorieId(" & idCategorie & ") : " & ex.Message)
        End Try
        Return lstReturn
    End Function

    ' 
    Public Shared Function getUpdates(pAgent As Agent) As PrestationTarif()
        Dim arrObjects(0) As PrestationTarif
        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM PrestationTarif WHERE PrestationTarif.idStructure=" & pAgent.uidStructure & " ORDER BY PrestationTarif.id")
            '################################################################
            Dim i As Integer = 0
            While tmpResults.Read()
                '# construction de l'objet
                Dim tmpObject As New PrestationTarif
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    If Not tmpResults.IsDBNull(tmpColId) Then
                        tmpObject.Fill(tmpResults.GetName(tmpColId), tmpResults.GetValue(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                '# Ajout au tableau de résultats
                arrObjects(i) = tmpObject
                i += 1
                ReDim Preserve arrObjects(i)
                '###############################
            End While
            ReDim Preserve arrObjects(i - 1)
            '################################################################
            tmpResults.Close()
            '' 110727 : arzur_c : On ferme la connexion
            dbLink.free()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationTarifManager::getUpdates() : " & ex.Message)
        End Try
        Return arrObjects
    End Function

#End Region

End Class