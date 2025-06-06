Imports System.Collections.Generic
Imports System.Data.Common

Public Class FVManometreEtalonManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As FVManometreEtalon
        Dim oreturn As FVManometreEtalon
        oreturn = RootWSGetById(Of FVManometreEtalon)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As FVManometreEtalon, ByRef pobjOut As FVManometreEtalon) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of FVManometreEtalon)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("FVManometreEtalonManager.WSSend : ", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    'Public Shared Function getWSFVManometreEtalonById(pAgent As Agent, ByVal fvmanometrecontrole_id As String) As Object
    '    Dim objFVManometreEtalon As New FVManometreEtalon(New Agent())
    '    Try

    '        ' d�clarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetFVManometreEtalon(pAgent.id, fvmanometrecontrole_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    Select Case objWSCrodip_responseItem.Name()
    '                        Case "id"
    '                            objFVManometreEtalon.id = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "idManometre"
    '                            objFVManometreEtalon.idManometre = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "type"
    '                            objFVManometreEtalon.type = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "auteur"
    '                            objFVManometreEtalon.auteur = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "idAgentControleur"
    '                            objFVManometreEtalon.idAgentControleur = CType(objWSCrodip_responseItem.InnerText(), Integer)
    '                        Case "caracteristiques"
    '                            objFVManometreEtalon.caracteristiques = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "dateModif"
    '                            objFVManometreEtalon.dateModif = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "blocage"
    '                            objFVManometreEtalon.blocage = CType(objWSCrodip_responseItem.InnerText(), Boolean)
    '                        Case "idReetalonnage"
    '                            objFVManometreEtalon.idReetalonnage = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "nomLaboratoire"
    '                            objFVManometreEtalon.nomLaboratoire = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "dateReetalonnage"
    '                            objFVManometreEtalon.dateReetalonnage = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "pressionControle"
    '                            objFVManometreEtalon.pressionControle = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "valeursMesurees"
    '                            objFVManometreEtalon.valeursMesurees = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "idManometreControleur"
    '                            objFVManometreEtalon.idManometreControleur = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "dateModificationAgent"
    '                            objFVManometreEtalon.dateModificationAgent = CType(objWSCrodip_responseItem.InnerText(), String)
    '                        Case "dateModificationCrodip"
    '                            objFVManometreEtalon.dateModificationCrodip = CType(objWSCrodip_responseItem.InnerText(), String)
    '                    End Select
    '                Next
    '            Case 1 ' NOK
    '                CSDebug.dispError("FVManometreEtalonManager - Code 1 : Non-Trouv�e")
    '            Case 9 ' BADREQUEST
    '                CSDebug.dispError("FVManometreEtalonManager - Code 9 : Bad Request")
    '        End Select
    '    Catch ex As Exception
    '        CSDebug.dispError("FVManometreEtalonManager - getWSFVManometreEtalonById : " & ex.Message)
    '    End Try
    '    Return objFVManometreEtalon

    'End Function

    'Public Shared Function sendWSFVManometreEtalon(pAgent As Agent, ByVal fvmanometreetalon As FVManometreEtalon, ByRef updatedObject As Object) As Integer
    '    Try
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        '            'Return objWSCrodip.SendFVManometreEtalon(pAgent.id, fvmanometreetalon, updatedObject)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'Public Shared Function xml2object(ByVal arrXml As Object) As FVManometreEtalon
    '    Dim objFVManometreEtalon As New FVManometreEtalon(New Agent())

    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        Select Case tmpSerializeItem.LocalName()
    '            Case "id"
    '                objFVManometreEtalon.id = CType(tmpSerializeItem.InnerText, String)
    '            Case "idManometre"
    '                objFVManometreEtalon.idManometre = CType(tmpSerializeItem.InnerText, String)
    '            Case "type"
    '                objFVManometreEtalon.type = CType(tmpSerializeItem.InnerText, String)
    '            Case "auteur"
    '                objFVManometreEtalon.auteur = CType(tmpSerializeItem.InnerText, String)
    '            Case "idAgentControleur"
    '                objFVManometreEtalon.idAgentControleur = CType(tmpSerializeItem.InnerText, Integer)
    '            Case "caracteristiques"
    '                objFVManometreEtalon.caracteristiques = CType(tmpSerializeItem.InnerText, String)
    '            Case "dateModif"
    '                objFVManometreEtalon.dateModif = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '            Case "blocage"
    '                objFVManometreEtalon.blocage = CType(tmpSerializeItem.InnerText, Boolean)
    '            Case "idReetalonnage"
    '                objFVManometreEtalon.idReetalonnage = CType(tmpSerializeItem.InnerText, String)
    '            Case "nomLaboratoire"
    '                objFVManometreEtalon.nomLaboratoire = CType(tmpSerializeItem.InnerText, String)
    '            Case "dateReetalonnage"
    '                objFVManometreEtalon.dateReetalonnage = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '            Case "pressionControle"
    '                objFVManometreEtalon.pressionControle = CType(tmpSerializeItem.InnerText, String)
    '            Case "valeursMesurees"
    '                objFVManometreEtalon.valeursMesurees = CType(tmpSerializeItem.InnerText, String)
    '            Case "idManometreControleur"
    '                objFVManometreEtalon.idManometreControleur = CType(tmpSerializeItem.InnerText, String)
    '            Case "dateModificationAgent"
    '                objFVManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '            Case "dateModificationCrodip"
    '                objFVManometreEtalon.dateModificationCrodip = CSDate.ToCRODIPString(CType(tmpSerializeItem.InnerText, String))
    '        End Select
    '    Next

    '    Return objFVManometreEtalon
    'End Function
#End Region

#Region "Methodes Locales"

    Public Shared Function save(ByVal pobjFV As FVManometreEtalon, Optional bSyncro As Boolean = False) As Boolean
        Dim paramsQueryUpdate As String
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            If String.IsNullOrEmpty(pobjFV.aid) Then
                Dim oAgent As Agent = AgentManager.getAgentById(pobjFV.idAgentControleur)
                pobjFV.aid = getNewId(oAgent)
            End If
            ' Initialisation de la requete
            paramsQueryUpdate = "id='" & pobjFV.aid & "',idManometre='" & CSDb.secureString(pobjFV.idManometre) & "'"
            Dim paramsQuery_col As String = "id,idManometre"
            Dim paramsQuery As String = "'" & pobjFV.id & "','" & pobjFV.idManometre & "'"

            ' Mise a jour de la date de derniere modification
            If Not bSyncro Then
                pobjFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not pobjFV.type Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",type"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.type) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",type='" & CSDb.secureString(pobjFV.type) & "'"
            End If
            If Not pobjFV.auteur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",auteur"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.auteur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",auteur='" & CSDb.secureString(pobjFV.auteur) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",idAgentControleur"
            paramsQuery = paramsQuery & " , " & pobjFV.idAgentControleur & ""
            paramsQueryUpdate = paramsQueryUpdate & ",idAgentControleur=" & CSDb.secureString(pobjFV.idAgentControleur) & ""
            If Not pobjFV.caracteristiques Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",caracteristiques"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.caracteristiques) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",caracteristiques='" & CSDb.secureString(pobjFV.caracteristiques) & "'"
            End If
            paramsQuery_col = paramsQuery_col & ",blocage"
            paramsQuery = paramsQuery & " , " & pobjFV.blocage & ""
            paramsQueryUpdate = paramsQueryUpdate & ",blocage=" & CSDb.secureString(pobjFV.blocage) & ""
            If Not pobjFV.idReetalonnage Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",idReetalonnage"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",idReetalonnage='" & CSDb.secureString(pobjFV.idReetalonnage) & "'"
            End If
            If Not pobjFV.nomLaboratoire Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",nomLaboratoire"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",nomLaboratoire='" & CSDb.secureString(pobjFV.nomLaboratoire) & "'"
            End If
            If Not pobjFV.dateReetalonnage Is Nothing And pobjFV.dateReetalonnage <> "" And pobjFV.dateReetalonnage <> "0000-00-00 00:00:00" Then
                paramsQuery_col = paramsQuery_col & ",dateReetalonnage"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateReetalonnage) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateReetalonnage='" & CSDb.secureString(pobjFV.dateReetalonnage) & "'"
            End If
            If Not pobjFV.pressionControle Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",pressionControle"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.pressionControle) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",pressionControle='" & CSDb.secureString(pobjFV.pressionControle) & "'"
            End If
            If Not pobjFV.valeursMesurees Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",valeursMesurees"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",valeursMesurees='" & CSDb.secureString(pobjFV.valeursMesurees) & "'"
            End If
            If Not pobjFV.idManometreControleur Is Nothing Then
                paramsQuery_col = paramsQuery_col & ",idManometreControleur"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",idManometreControleur='" & CSDb.secureString(pobjFV.idManometreControleur) & "'"
            End If
            If Not pobjFV.dateModif Is Nothing And pobjFV.dateModif <> "" Then
                paramsQuery_col = paramsQuery_col & ",dateModif"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateModif) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateModif='" & CSDb.secureString(pobjFV.dateModif) & "'"
            End If
            If Not String.IsNullOrEmpty(pobjFV.dateModificationAgentS) Then
                paramsQuery_col = paramsQuery_col & ",dateModificationAgent"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateModificationAgent) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateModificationAgent='" & CSDb.secureString(pobjFV.dateModificationAgent) & "'"
            End If
            If Not String.IsNullOrEmpty(pobjFV.dateModificationCrodipS) Then
                paramsQuery_col = paramsQuery_col & ",dateModificationCrodip"
                paramsQuery = paramsQuery & " , '" & CSDate.ToCRODIPString(pobjFV.dateModificationCrodip) & "'"
                paramsQueryUpdate = paramsQueryUpdate & ",dateModificationCrodip='" & CSDb.secureString(pobjFV.dateModificationCrodip) & "'"
            End If

            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "INSERT INTO FichevieManometreEtalon (" & paramsQuery_col & ") VALUES (" & paramsQuery & ")"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManoEtalonManager.Save ERR: ", ex)
            bReturn = False
        End Try
        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'save

    Public Shared Function getNewId(ByVal pAgent As Agent) As String
        ' d�clarations
        Dim tmpObjectId As String = pAgent.uidStructure & "-" & pAgent.id & "-1"
        If pAgent.uidStructure <> 0 Then

            Try
                ' On r�cup�re les r�sultats
                Dim bdd As New CSDb(True)
                Dim tmpListProfils As DbDataReader = bdd.getResult2s("SELECT id FROM FichevieManometreEtalon WHERE id LIKE '" & pAgent.uidStructure & "-" & pAgent.id & "-%' ORDER BY id DESC")
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On r�cup�re le dernier ID
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
                CSDebug.dispError("FVManometreEtalonManager - newId : " & ex.Message & vbNewLine)
            End Try

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Sub setSynchro(ByVal objFVManometreEtalon As FVManometreEtalon)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE FichevieManometreEtalon SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objFVManometreEtalon.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getFVManometreEtalonById(ByVal fvmanometreetalon_id As String) As FVManometreEtalon
        ' d�clarations
        Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        If fvmanometreetalon_id <> "" Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreEtalon WHERE FichevieManometreEtalon.id='" & fvmanometreetalon_id & "'"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
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
                        End If
                        tmpColId = tmpColId + 1
                    End While
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("FVManometreEtalonManager Error: " & ex.Message)
            End Try

            If oCsdb IsNot Nothing Then
                oCsdb.free()
            End If

        End If
        'on retourne le fvmanometreetalon ou un objet vide en cas d'erreur
        Return tmpFVManometreEtalon
    End Function

    Private Shared Function createFVManometreEtalon(ByVal fvmanometreetalon_id As String) As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Cr�ation
            bddCommande.CommandText = "INSERT INTO FichevieManometreEtalon (id) VALUES ('" & fvmanometreetalon_id & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager error : " & ex.Message)
            bReturn = False
        End Try
        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'createFVManometreEtalon

    Public Shared Function getUpdates(ByVal agent As Agent) As FVManometreEtalon()
        ' d�clarations
        Dim oCsdb As CSDb = Nothing

        Dim arrItems(0) As FVManometreEtalon
        Dim bddCommande As DbCommand

        oCsdb = New CSDb(True)
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT FichevieManometreEtalon.* FROM FichevieManometreEtalon INNER JOIN AgentManoEtalon ON FichevieManometreEtalon.idManometre = AgentManoEtalon.idCrodip "
        bddCommande.CommandText = bddCommande.CommandText & " WHERE (FichevieManometreEtalon.dateModificationAgent>FichevieManometreEtalon.dateModificationCrodip  or FichevieManometreEtalon.dateModificationCrodip is null)"
        bddCommande.CommandText = bddCommande.CommandText & " AND AgentManoEtalon.idStructure=" & agent.uidStructure

        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
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
                    End If
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

        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function getArrFVManometreEtalon(ByVal pIdMano As String) As List(Of FVManometreEtalon)
        Dim lstResponse As New List(Of FVManometreEtalon)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand


        If pIdMano <> "" Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM FichevieManometreEtalon WHERE FichevieManometreEtalon.idManometre='" & pIdMano & "'"
            Try

                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()

                    ' On rempli notre tableau
                    Dim tmpFVManometreEtalon As New FVManometreEtalon(New Agent())
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
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
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    lstResponse.Add(tmpFVManometreEtalon)
                End While
                tmpListProfils.Close()
            Catch ex As Exception
                CSDebug.dispError("FVManometreEtalonManager.getArrFVManometreEtalon ERR : " & ex.Message)
            End Try

            If oCsdb IsNot Nothing Then
                oCsdb.free()
            End If

        End If
        Return lstResponse
    End Function 'getArrFVManometreEtalon

#End Region
    Public Shared Function delete(ByVal pId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pId), " le param�tre ID doit �tre initialis�")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM FichevieManometreEtalon WHERE id='" & pId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprim�e")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManometreEtalonManager.delete (" & pId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

End Class
