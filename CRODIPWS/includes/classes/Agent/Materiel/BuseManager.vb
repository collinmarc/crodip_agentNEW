Imports System.Collections.Generic
Imports System.Data.Common

Public Class BuseManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As Buse
        Dim oreturn As Buse
        oreturn = RootWSGetById(Of Buse)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As Buse, ByRef pobjOut As Buse) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of Buse)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSBuse : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function
    'Public Shared Function getWSBuseById(pAgent As Agent, ByVal buse_id As String) As Buse
    '    Dim objBuse As New Buse
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetBuse(pAgent.id, buse_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '                        objBuse.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
    '                    End If
    '                Next
    '            Case 1 ' NOK
    '                CSDebug.dispError("Erreur - BuseManager - Code 1 : Non-Trouvée")
    '            Case 9 ' BADREQUEST
    '                CSDebug.dispError("Erreur - BuseManager - Code 9 : Bad Request")
    '        End Select
    '    Catch ex As Exception
    '        CSDebug.dispError("Erreur - BuseManager - getWSBuseById : " & ex.Message)
    '    End Try
    '    Return objBuse

    'End Function

    'Public Shared Function sendWSBuse(pAgent As Agent, ByVal buse As Buse) As Integer
    '    Try
    '        ' Appel au Web Service
    '        Dim UpdatedObject As New Object()
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim sinfo As String = ""
    '        Dim uid As Integer = 99
    '        Return objWSCrodip.SendBuse(buse, sinfo, uid)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'Public Shared Function xml2object(ByVal arrXml As Object) As Buse
    '    Dim objBuse As New Buse

    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
    '            objBuse.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
    '        End If
    '    Next

    '    Return objBuse
    'End Function
#End Region

#Region "Methodes Locales"
    ''' <summary>
    ''' Rend un nouveau numero national pour les buses (For test only !!!)
    ''' Les buses sont normalement créées sur le serveur
    ''' </summary>
    ''' <param name="agentCourant"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNewNumeroNationalforTestOnly(ByVal agentCourant As Agent) As String
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        ' déclarations
        Dim tmpObjectId As String = agentCourant.uidStructure & "-" & agentCourant.id & "-1"
        If agentCourant.uidStructure <> 0 Then

            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT numeroNational FROM AgentBuseEtalon WHERE AgentBuseEtalon.numeroNational LIKE '" & agentCourant.uidStructure & "-" & agentCourant.id & "-%' ORDER BY AgentBuseEtalon.numeroNational DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(agentCourant.uidStructure & "-" & agentCourant.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = agentCourant.uidStructure & "-" & agentCourant.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("BuseManager - newId : " & ex.Message & vbNewLine)
            End Try

            If Not oCsdb Is Nothing Then
                oCsdb.free()
            End If

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function


    Public Shared Function save(ByVal pBuse As Buse, Optional bSynchro As Boolean = False) As Boolean

        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try
            If pBuse.idCrodip <> "" Then


                ' On test si l'object existe ou non
                Dim existsObject As Buse
                existsObject = BuseManager.getBuseByIdCrodip(pBuse.idCrodip)
                If existsObject.idCrodip = "" Or existsObject.idCrodip = "0" Then
                    ' Si il n'existe pas, on le crée
                    createBuse(pBuse.idCrodip)
                End If

                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "numeroNational='" & pBuse.numeroNational & "'"

                ' Mise a jour de la date de derniere modification

                If Not bSynchro Then
                    pBuse.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                Else
                    pBuse.dateModificationAgent = pBuse.dateModificationCrodip
                End If

                paramsQuery = paramsQuery & " , idStructure=" & pBuse.uidstructure & ""
                paramsQuery = paramsQuery & " , uidStructure=" & pBuse.uidstructure & ""
                If Not pBuse.couleur Is Nothing Then
                    paramsQuery = paramsQuery & " , couleur='" & CSDb.secureString(pBuse.couleur) & "'"
                End If
                paramsQuery = paramsQuery & " , pressionEtalonnage='" & pBuse.pressionEtalonnage & "'"
                paramsQuery = paramsQuery & " , debitEtalonnage='" & pBuse.debitEtalonnage & "'"
                paramsQuery = paramsQuery & " , isSynchro=" & pBuse.isSynchro & ""
                If Not pBuse.dateAchat Is Nothing Then
                    paramsQuery = paramsQuery & " , dateAchat='" & CSDate.ToCRODIPString(pBuse.dateAchat) & "'"
                End If
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(pBuse.dateModificationAgent) & "'"
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(pBuse.dateModificationCrodip) & "'"
                paramsQuery = paramsQuery & " , etat=" & pBuse.etat & ""
                paramsQuery = paramsQuery & " , isSupprime=" & pBuse.isSupprime & ""
                paramsQuery = paramsQuery & " , isUtilise=" & pBuse.isUtilise & ""
                If Not pBuse.agentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & pBuse.agentSuppression & "'"
                End If
                If Not pBuse.raisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & pBuse.raisonSuppression & "'"
                End If
                If Not pBuse.dateSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(pBuse.dateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & pBuse.jamaisServi & ""
                If pBuse.dateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(pBuse.dateActivation) & "'"
                End If

                paramsQuery = paramsQuery & pBuse.getRootQuery()

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentBuseEtalon SET " & paramsQuery & " WHERE idCrodip='" & pBuse.idCrodip & "'"
                bddCommande.ExecuteNonQuery()

            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager - Save : [" & pBuse.numeroNational & "]" & ex.Message.ToString)
            bReturn = False
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objBuseEtalon As Buse)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE AgentBuseEtalon SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE numeroNational='" & objBuseEtalon.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getBuseByNumeroNational(ByVal buse_id As String) As Buse
        ' déclarations
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Dim tmpBuse As New Buse
        If buse_id <> "" Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE numeroNational='" & buse_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    tmpBuse.FillDR(tmpListProfils)
                End While
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("BuseManager Error: " & ex.Message)
            End Try


        End If
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        'on retourne le buse ou un objet vide en cas d'erreur
        Return tmpBuse
    End Function
    Public Shared Function getBuseByIdCrodip(ByVal pIdCrodip As String) As Buse
        ' déclarations
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Dim tmpBuse As New Buse
        If pIdCrodip <> "" Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idCrodip ='" & pIdCrodip & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    tmpBuse.FillDR(tmpListProfils)
                End While
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("BuseManager Error: " & ex.Message)
            End Try


        End If
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        'on retourne le buse ou un objet vide en cas d'erreur
        Return tmpBuse
    End Function

#Region " - Suppression - "
    ''' <summary>
    ''' Marque la buse comme étant utilisée
    ''' </summary>
    ''' <param name="objBuse"></param>
    ''' <remarks></remarks>
    Public Shared Sub setUtilise(ByVal objBuse As Buse)
        Try
            If Not BuseManager.isUsedBuse(objBuse.numeroNational) Then
                ' On met a jour en base
                Dim query As String = "UPDATE AgentBuseEtalon SET AgentBuseEtalon.dateModificationAgent='" & Date.Now.ToString & "' , AgentBuseEtalon.isUtilise=" & True & " WHERE AgentBuseEtalon.numeroNational='" & objBuse.numeroNational & "'"
                Dim bdd As New CSDb(True)
                bdd.Execute(query)
                bdd.free()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager.setUtilise() : " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Rend vrai si la buse est utilisée
    ''' </summary>
    ''' <param name="buse_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isUsedBuse(ByVal buse_id As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim query As String = "SELECT * FROM AgentBuseEtalon WHERE AgentBuseEtalon.isUtilise=" & False & " AND AgentBuseEtalon.numeroNational='" & buse_id & "'"
            Dim bdd As New CSDb(True)
            Dim dataResults As DbDataReader = bdd.getResult2s(query)
            bReturn = dataResults.HasRows
            dataResults.Close()
            bdd.free()

        Catch ex As Exception
            CSDebug.dispError("BuseManager.isUsedBuse() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Marque la buse comme étant supprimée
    ''' </summary>
    ''' <param name="buse_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SupprimerBuse(ByVal buse_id As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(buse_id), "L'id doit être renseigné")
        Dim bReturn As Boolean
        Try
            If Not isUsedBuse(buse_id) Then
                Dim query As String = "UPDATE AgentBuseEtalon SET AgentBuseEtalon.dateModificationAgent='" & Date.Now.ToString & "' , AgentBuseEtalon.isSupprime=" & True & " WHERE AgentBuseEtalon.numeroNational='" & buse_id & "'"
                Dim bdd As New CSDb(True)
                bdd.Execute(query)
                bdd.free()
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager.deleteBuse() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region
    ''' <summary>
    ''' Création d'un enr Buse avec son Id
    ''' </summary>
    ''' <param name="buse_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function createBuse(ByVal buse_id As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(buse_id), "l'Id doit être renseignée")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentBuseEtalon (idCrodip, aid) VALUES ('" & buse_id & "','" & buse_id & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True

        Catch ex As Exception
            CSDebug.dispFatal("BuseManager - createBuse ERR : " & ex.Message)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend une collection des matériels supprimés appartenant à la structure
    ''' </summary>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMaterielsSupprimes(ByVal pIdStructure As String) As Collection
        Dim colReturn As New Collection()
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim oDataReader As DbDataReader
        Try
            If pIdStructure <> "" Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idStructure=" & pIdStructure & " AND isSupprime<>0 ORDER BY dateSuppression DESC"
                oDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oBuse As New Buse
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDataReader.FieldCount()
                        If Not oDataReader.IsDBNull(tmpColId) Then
                            oBuse.Fill(oDataReader.GetName(tmpColId), oDataReader.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    colReturn.Add(oBuse)

                End While
            End If
        Catch ex As Exception
            CSDebug.dispError("BuseManager.GetMaterielSupprimes Error" & ex.Message)

        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return colReturn
    End Function

    Public Shared Function getUpdates(ByVal agent As Agent) As Buse()
        ' déclarations
        Dim arrItems(0) As Buse
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection.CreateCommand()
            If agent.oPool Is Nothing Then
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE (dateModificationAgent>dateModificationCrodip or dateModificationCrodip is null) AND idStructure=" & agent.uidstructure
            Else
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon MAT inner join PoolBuse PA on MAT.uid = PA.uidbuse WHERE PA.uidPool = " & agent.oPool.uid & " and (MAT.dateModificationAgent>MAT.dateModificationCrodip or MAT.dateModificationCrodip is null)"
            End If
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpBuse As New Buse
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpBuse.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpBuse
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - BuseManager - getResult : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function

#End Region
    Public Shared Function delete(ByVal pNumeroNational As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pNumeroNational), " le paramètre NumeroNational doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM AgentBuseEtalon WHERE numeroNational='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager.delete (" & pNumeroNational & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete
    Public Shared Function getBusesByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of Buse)

        Dim lstResponse As New List(Of Buse)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        If pIdStructure <> "" Then

            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            If isShowAll Then
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idStructure=" & pIdStructure & " AND jamaisServi=" & False & " AND AgentBuseEtalon.isSupprime=" & False & ""
            Else
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idStructure=" & pIdStructure & " AND jamaisServi=" & False & " AND AgentBuseEtalon.isSupprime=" & False & " AND etat=" & True & ""
            End If
            bddCommande.CommandText = bddCommande.CommandText & " ORDER BY idCrodip"
            Try

                ' On récupère les résultats
                Dim tmpListResults As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While tmpListResults.Read()

                    ' On rempli notre tableau
                    Dim tmpItem As New Buse
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListResults.FieldCount()
                        If Not tmpListResults.IsDBNull(tmpColId) Then
                            tmpItem.Fill(tmpListResults.GetName(tmpColId), tmpListResults.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    lstResponse.Add(tmpItem)
                End While
                tmpListResults.Close()
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("BuseManager.getBusesEtalonByStructureId ERR : " & ex.Message.ToString)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        Return lstResponse
    End Function

    Public Shared Function getBusesEtalonByStructureIdJamaisServi(ByVal pIdStructure As String) As List(Of Buse)
        Dim arrResponse As New List(Of Buse)
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        If pIdStructure <> "" Then

            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idStructure=" & pIdStructure & " AND jamaisServi=" & True & " AND isSupprime=" & False & ""
            Try

                ' On récupère les résultats
                Dim tmpListResults As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListResults.Read()

                    ' On rempli notre tableau
                    Dim tmpItem As New Buse
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListResults.FieldCount()
                        If Not tmpListResults.IsDBNull(tmpColId) Then
                            tmpItem.Fill(tmpListResults.GetName(tmpColId), tmpListResults.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    arrResponse.Add(tmpItem)
                End While
                tmpListResults.Close()
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("BuseManager.getBusesEtalonByStructureId ERR : " & ex.Message.ToString)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        Return arrResponse
    End Function
    Public Shared Function getlstByAgent(ByVal pAgent As Agent, ByVal isShowAll As Boolean) As List(Of Buse)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of Buse)
        Dim sql As String
        If pAgent.oPool Is Nothing Then
            sql = "SELECT * FROM AgentBuseEtalon MAT WHERE MAT.idStructure=" & pAgent.idStructure & " AND MAT.isSupprime=" & False & " "
        Else
            sql = "SELECT MAT.* FROM AgentBuseEtalon MAT inner join PoolBuse PA on MAT.uid = PA.uidBuse WHERE PA.uidPool = " & pAgent.oPool.uid & " AND MAT.isSupprime=" & False & ""
        End If
        If Not isShowAll Then
            sql = sql & " AND MAT.etat=" & True & ""
        End If
        Dim sql2 As String
        'on prend d'abord Ceux qui ont servi
        sql2 = sql & " AND JamaisServi=" & False & ""
        arrResponse = getListe(Of Buse)(sql2)

        'puis ceux qui n'ont jamais servi
        sql2 = sql & " AND JamaisServi=" & True & ""
        arrResponse.AddRange(getListe(Of Buse)(sql2))

        Return arrResponse
    End Function

End Class
