Imports System.Collections.Generic
Imports System.Data.Common

Public Class PrestationCategorieManager

#Region "Methodes Web Service"

    ' OK
    Public Shared Function getWSPrestationCategorieById(pAgent As Agent, ByVal PrestationCategorie_id As Integer) As Object
        Dim curObject As New PrestationCategorie
        Try

            ' d�clarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetPrestationCategorie(pAgent.id, PrestationCategorie_id, pAgent.idStructure, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        Select Case objWSCrodip_responseItem.Name()
                            Case "id"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.id = CType(objWSCrodip_responseItem.InnerText(), Integer)
                                End If
                            Case "idStructure"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.idStructure = CType(objWSCrodip_responseItem.InnerText(), Integer)
                                End If
                            Case "libelle"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.description = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                            Case "dateModificationCrodip"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                            Case "dateModificationAgent"
                                If objWSCrodip_responseItem.InnerText() <> "" Then
                                    curObject.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
                                End If
                        End Select
                    Next
                Case 1 ' NOK
                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 1 : Non-Trouv�e")
                Case 9 ' BADREQUEST
                    CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispFatal("TarifsManager::getWSPrestationCategorieById : " & ex.Message)
        End Try
        Return curObject
    End Function

    ' OK
    Public Shared Function sendWSPrestationCategorie(ByVal curObject As PrestationCategorie, pAgent As Agent, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendPrestationCategorie(pAgent.id, curObject, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    ' OK
    Public Shared Function xml2object(ByVal arrXml As Object) As PrestationCategorie
        Dim newObject As New PrestationCategorie
        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            Select Case tmpSerializeItem.LocalName()
                Case "id"
                    newObject.id = CType(tmpSerializeItem.InnerText, Integer)
                Case "idStructure"
                    newObject.idStructure = CType(tmpSerializeItem.InnerText, Integer)
                Case "libelle"
                    newObject.description = CType(tmpSerializeItem.InnerText, String)
                Case "dateModificationAgent"
                    newObject.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
                Case "dateModificationCrodip"
                    newObject.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
            End Select
        Next
        Return newObject
    End Function

#End Region

#Region "Methodes Locales"

    ' OK
    Public Shared Function save(ByVal curObject As PrestationCategorie, pAgent As Agent, Optional bSyncro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Dim dbLink As CSDb = Nothing
        '## Pr�paration de la connexion
        Try
            dbLink = New CSDb(True)
            If curObject.getEtat() <> Tarif.BDEtat.ETATNONE Then
                If curObject.id = 0 Then
                    curObject.id = PrestationCategorieManager.getNextId()
                End If
                If curObject.id <> 0 Then
                    If curObject.getEtat = Tarif.BDEtat.ETATDELETED Then
                        dbLink.Execute("DELETE FROM PrestationTarif  WHERE idCategorie= " & curObject.id)
                        dbLink.Execute("DELETE FROM PrestationCategorie  WHERE id= " & curObject.id)
                    Else
                        '####################################################
                        If Not PrestationCategorieManager.exists(curObject) Then
                            PrestationCategorieManager.create(curObject.id, pAgent)
                        End If
                        '####################################################
                        '####################################################

                        ' Initialisation de la requete
                        ' Mise a jour de la date de derniere modification
                        If Not bSyncro Then
                            curObject.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                        End If

                        Dim paramsQuery As String = ""

                        If Not curObject.description Is Nothing Then
                            paramsQuery = paramsQuery & " `libelle`='" & CSDb.secureString(curObject.description) & "'"
                        End If
                        If Not curObject.dateModificationAgent Is Nothing Then
                            paramsQuery = paramsQuery & " , `dateModificationAgent`='" & CSDate.TOCRODIPString(curObject.dateModificationAgent) & "'"
                        End If
                        If Not curObject.dateModificationCrodip Is Nothing Then
                            paramsQuery = paramsQuery & " , `dateModificationCrodip`='" & CSDate.TOCRODIPString(curObject.dateModificationCrodip) & "'"
                        End If

                        '####################################################
                        '## Execution de la requete
                        dbLink.Execute("UPDATE `PrestationCategorie` SET " & paramsQuery & " WHERE id=" & curObject.id & " AND idStructure = " & curObject.idStructure)
                        curObject.setEtat(Tarif.BDEtat.ETATNONE)
                    End If
                End If
                bReturn = True

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::save() : " & ex.Message.ToString)
            bReturn = False
        End Try

        If Not dbLink Is Nothing Then
            ' Si non, on la configure et on l'ouvre
            dbLink.free()
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Retourne le prochain ID disposible pour la structure
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNextId() As Integer
        Dim iReturn As Integer = 1
        Dim dbLink As New CSDb(True)
        '## Pr�paration de la connexion
        Dim bddCommande As DbCommand
        bddCommande = dbLink.getConnection().CreateCommand()
        Try
            Dim tmpResults As DbDataReader
            bddCommande.CommandText = "SELECT MAX(Id)+1 as NEWID FROM PrestationCategorie "
            tmpResults = bddCommande.ExecuteReader()
            While tmpResults.Read()
                '# construction de l'objet
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId).ToUpper().Trim
                        Case "NEWID".ToUpper().Trim()
                            If Not tmpResults.IsDBNull(tmpColId) Then
                                iReturn = tmpResults.Item(tmpColId)
                            Else
                                iReturn = 1
                            End If
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '###############################
            End While
            tmpResults.Close()

        Catch ex As Exception
            CSDebug.dispError("PrestationCategorieManager::getNextId() : " & ex.Message.ToString)
        End Try
        dbLink.free()
        Return iReturn

    End Function
    ''' <summary>
    ''' Cr�ation d'un enregistrement � vide
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function create(ByVal id As Integer, pAgent As Agent) As Boolean
        Debug.Assert(id <> 0)
        Dim bReturn As Boolean
        Dim dbLink As New CSDb(True)
        '## Pr�paration de la connexion
        Dim bddCommande As DbCommand
        bddCommande = dbLink.getConnection().CreateCommand()
        Try
            '####################################################
            '## Execution de la requete
            bddCommande.CommandText = "INSERT INTO `PrestationCategorie` (`id`,`idStructure`,`dateModificationAgent`) VALUES ('" & id & "','" & pAgent.idStructure & "','" & CSDate.TOCRODIPString(Date.Now) & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PrestationCategorieManager::create() : " & ex.Message.ToString)
            bReturn = False
        End Try
        dbLink.free()
        Return bReturn
    End Function

    ''' <summary>
    ''' V�rification de l'existence d'une prestation
    ''' </summary>
    ''' <param name="curObject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function exists(ByVal curObject As PrestationCategorie) As Boolean
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        Try
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            bddCommande.CommandText = "SELECT * FROM `PrestationCategorie` WHERE id=" & curObject.id & " AND idStructure = " & curObject.idStructure
            tmpResults = bddCommande.ExecuteReader()
            '################################################################
            If tmpResults.HasRows() Then
                bReturn = True
            Else
                bReturn = False
            End If
            tmpResults.Close()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::exists() : " & ex.Message)
            bReturn = False
        End Try
        oCSDB.free()
        Return bReturn
    End Function

    ' OK
    Public Shared Sub setSynchro(ByVal curObject As PrestationCategorie)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE PrestationCategorie SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id=" & curObject.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    ' OK
    Public Shared Sub delete(ByVal curObject As PrestationCategorie)
        Try
            PrestationCategorieManager.delete(curObject.id)
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::delete() : " & ex.Message)
        End Try

    End Sub
    Public Shared Sub delete(ByVal curObjectId As Integer)
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand
        Try
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE FROM `PrestationCategorie` WHERE `PrestationCategorie`.`id`=" & curObjectId & ""
            bddCommande.ExecuteNonQuery()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::delete() : " & ex.Message)
        End Try
        oCSDB.free()

    End Sub

    ' OK
    Public Shared Function getArrayByStructureId(ByVal idStructure As Integer) As PrestationCategorie()
        Dim arrObjects(0) As PrestationCategorie
        Try
            If idStructure <> 0 Then
                '## Pr�paration de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim tmpResults As DbDataReader
                tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationCategorie` WHERE idStructure=" & idStructure & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While tmpResults.Read()
                    '# construction de l'objet
                    Dim tmpObject As New PrestationCategorie
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        Select Case tmpResults.GetName(tmpColId)
                            Case "id"
                                tmpObject.id = tmpResults.Item(tmpColId)
                            Case "idStructure"
                                tmpObject.idStructure = tmpResults.Item(tmpColId)
                            Case "libelle"
                                tmpObject.description = tmpResults.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    '# Ajout au tableau de r�sultats
                    tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
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

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getArrayByStructureId(" & idStructure & ") : " & ex.Message)
        End Try
        Return arrObjects
    End Function
    Public Shared Function getlstByStructureId(ByVal idStructure As Integer) As List(Of PrestationCategorie)
        Dim lstReturn As New List(Of PrestationCategorie)
        Try
            If idStructure <> 0 Then
                '## Pr�paration de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim tmpResults As DbDataReader
                tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationCategorie` WHERE idStructure=" & idStructure & " ORDER BY id")
                '################################################################
                Dim i As Integer = 0
                While tmpResults.Read()
                    '# construction de l'objet
                    Dim tmpObject As New PrestationCategorie
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        Select Case tmpResults.GetName(tmpColId)
                            Case "id"
                                tmpObject.id = tmpResults.Item(tmpColId)
                            Case "idStructure"
                                tmpObject.idStructure = tmpResults.Item(tmpColId)
                            Case "libelle"
                                tmpObject.description = tmpResults.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    '# Ajout au tableau de r�sultats
                    tmpObject.setEtat(Tarif.BDEtat.ETATNONE)

                    lstReturn.Add(tmpObject)
                    '###############################
                End While
                '################################################################
                tmpResults.Close()
                '' 110727 : arzur_c : On ferme la connexion
                dbLink.free()

            End If
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getlstByStructureId(" & idStructure & ") : " & ex.Message)
        End Try
        Return lstReturn
    End Function

    ' OK
    Public Shared Function getCategoryById(ByVal idCategorie As Integer, pidStructure As Integer) As PrestationCategorie
        Dim oCategorie As New PrestationCategorie
        Try
            '## Pr�paration de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM `PrestationCategorie` WHERE id=" & idCategorie & " AND idStructure=" & pidStructure)
            '################################################################
            Dim i As Integer = 0
            While tmpResults.Read()
                '# construction de l'objet
                Dim tmpObject As New PrestationCategorie
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    Select Case tmpResults.GetName(tmpColId)
                        Case "id"
                            tmpObject.id = tmpResults.Item(tmpColId)
                        Case "idStructure"
                            tmpObject.idStructure = tmpResults.Item(tmpColId)
                        Case "libelle"
                            tmpObject.description = tmpResults.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '# Ajout au tableau de r�sultats
                tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                oCategorie = tmpObject
                '###############################
            End While
            tmpResults.Close()
            '################################################################

            '' 110727 : arzur_c : On ferme la connexion
            dbLink.free()

        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getCategoryById(" & idCategorie & ") : " & ex.Message)
        End Try
        Return oCategorie
    End Function
    ' OK
    Public Shared Function getUpdates() As PrestationCategorie()
        Dim arrObjects(0) As PrestationCategorie
        Try
            '## Pr�paration de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM PrestationCategorie WHERE PrestationCategorie.idStructure=" & agentCourant.idStructure & " AND ( dateModificationAgent<>dateModificationCrodip OR dateModificationCrodip Is Null) ORDER BY PrestationCategorie.id")
            '################################################################
            Dim i As Integer = 0
            While tmpResults.Read()
                '# construction de l'objet
                Dim tmpObject As New PrestationCategorie
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()

                    Select Case tmpResults.GetName(tmpColId)
                        Case "id"
                            tmpObject.id = tmpResults.Item(tmpColId)
                        Case "idStructure"
                            tmpObject.idStructure = tmpResults.Item(tmpColId)
                        Case "libelle"
                            tmpObject.description = tmpResults.Item(tmpColId).ToString()
                        Case "dateModificationAgent"
                            tmpObject.dateModificationAgent = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                        Case "dateModificationCrodip"
                            tmpObject.dateModificationCrodip = CSDate.ToCRODIPString(tmpResults.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                '# Ajout au tableau de r�sultats
                tmpObject.setEtat(Tarif.BDEtat.ETATNONE)
                arrObjects(i) = tmpObject
                i += 1
                ReDim Preserve arrObjects(i)
                '###############################
            End While
            ReDim Preserve arrObjects(i - 1)
            '################################################################
            '' 110727 : arzur_c : On ferme la connexion
            tmpResults.Close()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PrestationCategorieManager::getUpdates() : " & ex.Message)
        End Try
        Return arrObjects
    End Function

#End Region

End Class