Imports System.Collections.Generic
Public Class ManometreControleManager

#Region "Methodes Web Service"

    Public Shared Function getWSManometreControleById(pAgent As Agent, ByVal manometrecontrole_id As String) As ManometreControle
        Dim objManometreControle As New ManometreControle
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetManometreControle(pAgent.id, manometrecontrole_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If Not String.IsNullOrEmpty(objWSCrodip_responseItem.InnerText()) Then
                            objManometreControle.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("ManometreControleManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("ManometreControleManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("ManometreControleManager - getWSManometreControleById : " & ex.Message)
        End Try
        Return objManometreControle

    End Function

    Public Shared Function sendWSManometreControle(pAgent As Agent, ByVal manometrecontrole As ManometreControle, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendManometreControle(pAgent.id, manometrecontrole, updatedObject)
        Catch ex As Exception
            CSDebug.dispFatal("sendWSManometreControle : " & ex.Message)
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As ManometreControle
        Dim objManometreControle As New ManometreControle

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
                objManometreControle.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
            End If
        Next

        Return objManometreControle
    End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function FTO_getNewNumeroNational(ByVal pAgent As Agent) As String
        ' déclarations
        Dim tmpObjectId As String = pAgent.idStructure & "-" & pAgent.id & "-1"
        If pAgent.idStructure <> 0 Then

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT `AgentManoControle`.`numeroNational` FROM `AgentManoControle` WHERE `AgentManoControle`.`numeroNational` LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY `AgentManoControle`.`numeroNational` DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.idStructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = pAgent.idStructure & "-" & pAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                Console.Write("ManoControleManager - newId : " & ex.Message & vbNewLine)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCSDB Is Nothing Then
                ' On ferme la connexion
                oCSDB.free()
            End If

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Function save(ByVal objManometreControle As ManometreControle, Optional bSynhcro As Boolean = False) As Boolean


        Dim oCSDb As New CSDb(True)
        Dim bReturn As Boolean

        Try
            If objManometreControle.numeroNational <> "" Then


                ' On test si l'object existe ou non
                Dim existsObject As Object
                existsObject = ManometreControleManager.getManometreControleByNumeroNational(objManometreControle.numeroNational)
                If existsObject.numeroNational = "" Or existsObject.numeroNational = "0" Then
                    ' Si il n'existe pas, on le crée
                    createManometreControle(objManometreControle.numeroNational)
                End If

                Dim bddCommande As OleDb.OleDbCommand

                bddCommande = oCSDb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "`AgentManoControle`.`numeroNational`='" & objManometreControle.numeroNational & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSynhcro Then
                    objManometreControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not objManometreControle.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`idCrodip`='" & CSDb.secureString(objManometreControle.idCrodip) & "'"
                End If
                paramsQuery = paramsQuery & " , `AgentManoControle`.`idStructure`=" & objManometreControle.idStructure & ""
                If Not objManometreControle.marque Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`marque`='" & CSDb.secureString(objManometreControle.marque) & "'"
                End If
                If Not objManometreControle.classe Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`classe`='" & CSDb.secureString(objManometreControle.classe) & "'"
                End If
                If Not objManometreControle.type Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`type`='" & CSDb.secureString(objManometreControle.type) & "'"
                End If
                If Not objManometreControle.fondEchelle Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`fondEchelle`='" & CSDb.secureString(objManometreControle.fondEchelle) & "'"
                End If
                paramsQuery = paramsQuery & " , `AgentManoControle`.`etat`=" & objManometreControle.etat & ""
                paramsQuery = paramsQuery & " , `AgentManoControle`.`isSynchro`=" & objManometreControle.isSynchro & ""
                If objManometreControle.dateDernierControleS <> Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`dateDernierControle`='" & CSDate.mysql2access(objManometreControle.dateDernierControleS) & "'"
                End If
                If Not objManometreControle.dateModificationAgent Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`dateModificationAgent`='" & CSDate.mysql2access(objManometreControle.dateModificationAgent) & "'"
                End If
                If Not objManometreControle.dateModificationCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`dateModificationCrodip`='" & CSDate.mysql2access(objManometreControle.dateModificationCrodip) & "'"
                End If
                If Not objManometreControle.resolution Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`resolution`='" & CSDb.secureString(objManometreControle.resolution) & "'"
                End If
                paramsQuery = paramsQuery & " , `AgentManoControle`.`isUtilise`=" & objManometreControle.isUtilise & ""
                paramsQuery = paramsQuery & " , `AgentManoControle`.`isSupprime`=" & objManometreControle.isSupprime & ""
                paramsQuery = paramsQuery & " , `AgentManoControle`.`nbControles`=" & objManometreControle.nbControles & ""
                paramsQuery = paramsQuery & " , `AgentManoControle`.`nbControlesTotal`=" & objManometreControle.nbControlesTotal & ""

                If Not objManometreControle.agentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`agentSuppression`='" & objManometreControle.agentSuppression & "'"
                End If
                If Not objManometreControle.raisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`raisonSuppression`='" & objManometreControle.raisonSuppression & "'"
                End If
                If Not objManometreControle.dateSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`dateSuppression`='" & CSDate.mysql2access(objManometreControle.dateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , `AgentManoControle`.`jamaisServi`=" & objManometreControle.jamaisServi & ""
                If objManometreControle.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , `AgentManoControle`.`dateActivation`='" & CSDate.mysql2access(objManometreControle.DateActivation) & "'"
                End If

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE `AgentManoControle` SET " & paramsQuery & " WHERE `AgentManoControle`.`numeroNational`='" & objManometreControle.numeroNational & "'"
                bddCommande.ExecuteNonQuery()
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager - Save : " & ex.Message.ToString)
            bReturn = False
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSDb Is Nothing Then
            ' On ferme la connexion
            oCSDb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objManometreControle As ManometreControle)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `AgentManoControle` SET `AgentManoControle`.`dateModificationCrodip`='" & newDate & "',`AgentManoControle`.`dateModificationAgent`='" & newDate & "' WHERE `AgentManoControle`.`numeroNational`='" & objManometreControle.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub resetNbControles(ByVal objManometreControle As ManometreControle)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `AgentManoControle` SET `AgentManoControle`.`nbControles`=0 WHERE `AgentManoControle`.`numeroNational`='" & objManometreControle.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager::resetNbControles : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getManometreControleByNumeroNational(ByVal pNumeroNational As String) As ManometreControle
        ' déclarations
        Dim tmpManometreControle As New ManometreControle
        Dim oCSDB As New CSDb(True)
        If pNumeroNational <> "" Then

            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.numeroNational='" & pNumeroNational & "'"
            Try
                ' On récupère les résultats
                Using tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                    ' Puis on les parcours
                    While tmpListProfils.Read()
                        ' On rempli notre tableau
                        Dim tmpColId As Integer = 0
                        While tmpColId < tmpListProfils.FieldCount()
                            If Not tmpListProfils.IsDBNull(tmpColId) Then
                                tmpManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                            End If
                            tmpColId = tmpColId + 1

                        End While
                    End While
                    tmpListProfils.Close()
                End Using
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("ManometreControleManager Error: " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCSDB Is Nothing Then
                ' On ferme la connexion
                oCSDB.free()
            End If

        End If
        'on retourne le manometrecontrole ou un objet vide en cas d'erreur
        Return tmpManometreControle
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
        Dim bddCommande As OleDb.OleDbCommand = Nothing
        Dim oDataReader As System.Data.OleDb.OleDbDataReader
        Try
            If pIdStructure <> "" Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE idStructure=" & pIdStructure & " AND isSupprime=" & True & " ORDER BY dateSuppression DESC"
            End If
            oDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oMano As New ManometreControle
                If oMano.Fill(oDataReader) Then
                    colReturn.Add(oMano)
                End If
            End While
            oDataReader.Close()

        Catch ex As Exception
            CSDebug.dispError("ManometreControleManager.GetMaterielSupprimes Error" & ex.Message)

        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return colReturn
    End Function

#End Region

    Private Shared Sub createManometreControle(ByVal manometrecontrole_id As String)
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO `AgentManoControle` (`numeroNational`) VALUES ('" & manometrecontrole_id & "')"
            bddCommande.ExecuteNonQuery()

        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager error : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If
    End Sub

    Public Shared Function getUpdates(ByVal agent As Agent) As ManometreControle()
        ' déclarations
        Dim arrItems(0) As ManometreControle
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `AgentManoControle` WHERE `AgentManoControle`.`dateModificationAgent`>`AgentManoControle`.`dateModificationCrodip` AND `AgentManoControle`.`idStructure`=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpManometreControle As New ManometreControle
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpManometreControle.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpManometreControle
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
            tmpListProfils.Close()

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - ManometreControleManager - getResult : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function
#Region " - Suppression - "
    Public Shared Function delete(ByVal pNumeroNational As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pNumeroNational), " le paramètre pID doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As OleDb.OleDbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCSDb = New CSDb(True)

            bddCommande = oCSDb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM AgentManoControle WHERE AgentManoControle.numeroNational='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bddCommande.CommandText = "DELETE FROM FicheVieManometreControle WHERE idManometre='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager.delete (" & pNumeroNational.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'delete

#End Region
    '''
    ''' Rend la liste des Manomètres de controle d'une structure
    ''' isShowAll = FALSE => seulment les Mano etat OK, FALSE => Tous les Manos
    '''
    Public Shared Function getManoControleByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(pIdStructure), "L'ID Structure doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)
        If pIdStructure <> "" Then
            Dim oCsdb As New CSDb(True)
            Dim bddCommande As OleDb.OleDbCommand = oCsdb.getConnection().CreateCommand()
            If isShowAll Then
                bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.idStructure=" & pIdStructure & " AND AgentManoControle.isSupprime=" & False & " And AgentManoControle.jamaisServi = " & False & ""
            Else
                bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.idStructure=" & pIdStructure & " AND AgentManoControle.isSupprime=" & False & " AND AgentManoControle.jamaisServi = " & False & " AND AgentManoControle.etat=" & True & ""
            End If
            bddCommande.CommandText = bddCommande.CommandText & " ORDER BY idCrodip"

            Try
                ' On récupère les résultats
                Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreControle
                    If oMano.Fill(oDataReader) Then
                        arrResponse.Add(oMano)
                    End If
                End While
                oDataReader.Close()
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("AgentManager.getManoControle : " & ex.Message)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        Return arrResponse
    End Function
    '''
    ''' Rend la liste des Manomètres de controle d'une structure
    ''' isShowAll = FALSE => seulment les Mano etat OK, FALSE => Tous les Manos
    '''
    Public Shared Function getManoControleByStructureIdJamaisServi(ByVal pIdStructure As String) As List(Of ManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(pIdStructure), "L'ID Structure doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)
        If pIdStructure <> "" Then
            Dim oCsdb As New CSDb(True)
            Dim bddCommande As OleDb.OleDbCommand = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.idStructure=" & pIdStructure & " AND AgentManoControle.isSupprime=" & False & " AND AgentManoControle.jamaisServi = " & True & ""
            Try
                ' On récupère les résultats
                Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreControle
                    If oMano.Fill(oDataReader) Then
                        arrResponse.Add(oMano)
                    End If
                End While
                oDataReader.Close()
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("AgentManager.getManoControle : " & ex.Message)
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
