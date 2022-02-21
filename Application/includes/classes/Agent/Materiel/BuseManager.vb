Imports System.Collections.Generic
Imports System.Data.Common

Public Class BuseManager

#Region "Methodes Web Service"
    Public Shared Function getWSBuseById(ByVal buse_id As String) As Buse
        Dim objBuse As New Buse
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetBuse(agentCourant.id, buse_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If objWSCrodip_responseItem.InnerText() <> "" Then
                            objBuse.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - BuseManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - BuseManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - BuseManager - getWSBuseById : " & ex.Message)
        End Try
        Return objBuse

    End Function

    Public Shared Function sendWSBuse(ByVal buse As Buse) As Integer
        Try
            ' Appel au Web Service
            Dim UpdatedObject As New Object()
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendBuse(agentCourant.id, buse, UpdatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As Buse
        Dim objBuse As New Buse

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
                objBuse.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
            End If
        Next

        Return objBuse
    End Function
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
        Dim tmpObjectId As String = agentCourant.idStructure & "-" & agentCourant.id & "-1"
        If agentCourant.idStructure <> 0 Then

            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT numeroNational FROM AgentBuseEtalon WHERE AgentBuseEtalon.numeroNational LIKE '" & agentCourant.idStructure & "-" & agentCourant.id & "-%' ORDER BY AgentBuseEtalon.numeroNational DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(agentCourant.idStructure & "-" & agentCourant.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = agentCourant.idStructure & "-" & agentCourant.id & "-" & (newId + 1)
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


    Public Shared Function save(ByVal objBuseEtalon As Buse, Optional bSynchro As Boolean = False) As Boolean

        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean

        Try
            If objBuseEtalon.numeroNational <> "" Then


                ' On test si l'object existe ou non
                Dim existsObject As Object
                existsObject = BuseManager.getBuseByNumeroNational(objBuseEtalon.numeroNational)
                If existsObject.numeroNational = "" Or existsObject.numeroNational = "0" Then
                    ' Si il n'existe pas, on le crée
                    createBuse(objBuseEtalon.numeroNational)
                End If

                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "numeroNational='" & objBuseEtalon.numeroNational & "'"

                ' Mise a jour de la date de derniere modification

                If Not bSynchro Then
                    objBuseEtalon.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                Else
                    objBuseEtalon.dateModificationAgent = objBuseEtalon.dateModificationCrodip
                End If

                If Not objBuseEtalon.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , idCrodip='" & objBuseEtalon.idCrodip & "'"

                End If
                paramsQuery = paramsQuery & " , idStructure=" & objBuseEtalon.idStructure & ""
                If Not objBuseEtalon.couleur Is Nothing Then
                    paramsQuery = paramsQuery & " , couleur='" & CSDb.secureString(objBuseEtalon.couleur) & "'"
                End If
                paramsQuery = paramsQuery & " , pressionEtalonnage='" & objBuseEtalon.pressionEtalonnage & "'"
                paramsQuery = paramsQuery & " , debitEtalonnage='" & objBuseEtalon.debitEtalonnage & "'"
                paramsQuery = paramsQuery & " , isSynchro=" & objBuseEtalon.isSynchro & ""
                If Not objBuseEtalon.dateAchat Is Nothing Then
                    paramsQuery = paramsQuery & " , dateAchat='" & CSDate.mysql2access(objBuseEtalon.dateAchat) & "'"
                End If
                If Not objBuseEtalon.dateModificationAgent Is Nothing Then
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.mysql2access(objBuseEtalon.dateModificationAgent) & "'"
                End If
                If Not objBuseEtalon.dateModificationCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.mysql2access(objBuseEtalon.dateModificationCrodip) & "'"
                End If
                paramsQuery = paramsQuery & " , etat=" & objBuseEtalon.etat & ""
                paramsQuery = paramsQuery & " , isSupprime=" & objBuseEtalon.isSupprime & ""
                paramsQuery = paramsQuery & " , isUtilise=" & objBuseEtalon.isUtilise & ""
                If Not objBuseEtalon.AgentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & objBuseEtalon.AgentSuppression & "'"
                End If
                If Not objBuseEtalon.RaisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & objBuseEtalon.RaisonSuppression & "'"
                End If
                If Not objBuseEtalon.DateSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.mysql2access(objBuseEtalon.DateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & objBuseEtalon.JamaisServi & ""
                If objBuseEtalon.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.mysql2access(objBuseEtalon.DateActivation) & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentBuseEtalon SET " & paramsQuery & " WHERE numeroNational='" & objBuseEtalon.numeroNational & "'"
                bddCommande.ExecuteNonQuery()

            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("BuseManager - Save : [" & objBuseEtalon.numeroNational & "]" & ex.Message.ToString)
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
            Dim newDate As String = Date.Now.ToString
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
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpBuse.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
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
            bddCommande.CommandText = "INSERT INTO AgentBuseEtalon (numeroNational) VALUES ('" & buse_id & "')"
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
                bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE idStructure=" & pIdStructure & " AND isSupprime=" & True & " ORDER BY dateSuppression DESC"
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
            bddCommande.CommandText = "SELECT * FROM AgentBuseEtalon WHERE dateModificationAgent<>dateModificationCrodip AND idStructure=" & agent.idStructure

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
    Public Shared Function getBusesEtalonByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of Buse)

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
End Class
