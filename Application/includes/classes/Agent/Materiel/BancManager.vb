Imports System.Collections.Generic
Public Class BancManager

#Region "Methodes Web Service"

    Public Shared Function getWSBancById(ByVal banc_id As String) As Object
        Dim objBanc As New Banc
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            Dim bReturn As Boolean
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetBanc(agentCourant.id, banc_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If objWSCrodip_responseItem.InnerText() <> "" Then
                            bReturn = objBanc.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                            Debug.Assert(bReturn) ' Must be true
                        End If
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - BancManager - Code 1 : Non-Trouvée (" & banc_id & ")")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - BancManager - Code 9 : Bad Request (" & banc_id & ")")
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - BancManager - getWSBancById (" & banc_id & ") : " & ex.Message)
        End Try
        Return objBanc

    End Function

    Public Shared Function sendWSBanc(ByVal banc As Banc, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendBanc(agentCourant.id, banc, updatedObject)
        Catch ex As Exception
            CSDebug.dispError("BancManager.sendWSBanc Error " & ex.InnerException.Message)
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As Banc
        Dim objBanc As New Banc

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
                objBanc.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
            End If
        Next

        Return objBanc
    End Function

#End Region

#Region "Methodes Locales"
    ''' Cette méthode n'est plus utilisée depuis la 2.5.4.3 , car les matériels sont créés sur le Serveur 
    Public Shared Function FTO_getNewId(ByVal pAgent As Agent) As String
        ' déclarations
        Dim oCSDb As CSDb = nothing
        Dim bddCommande As OleDb.OleDbCommand

        Dim tmpObjectId As String = pAgent.idStructure & "-" & pAgent.id & "-1"
        If pAgent.idStructure <> 0 Then
            oCSDb = New CSDb(True)
            bddCommande = oCSDb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT `BancMesure`.`id` FROM `BancMesure` WHERE `BancMesure`.`id` LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY `BancMesure`.`id` DESC"
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
                tmpListProfils.Close()
                tmpObjectId = pAgent.idStructure & "-" & pAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("BancManager - getnewIdForTestOnly : " & ex.Message & vbNewLine)
            End Try

            ' Test pour fermeture de connection BDD
            If oCSDb IsNot Nothing Then
                ' On ferme la connexion
                oCSDb.free()
            End If

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Function save(ByVal objBanc As Banc, Optional bsynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(objBanc.id), "L'Id doit être inititialisé")
        Dim oCSDb As CSDb = nothing
        Dim bddCommande As OleDb.OleDbCommand
        Dim bReturn As Boolean
        Try
            If objBanc.id <> "" Then

                bReturn = True
                ' On test si l'object existe ou non
                Dim existsObject As Object
                existsObject = BancManager.getBancById(objBanc.id)
                If existsObject.id = "" Or existsObject.id = "0" Then
                    ' Si il n'existe pas, on le crée
                    bReturn = createBanc(objBanc.id)
                End If

                If bReturn Then
                    oCSDb = New CSDb(True)
                    bddCommande = oCSDb.getConnection().CreateCommand()

                    ' Initialisation de la requete
                    Dim paramsQuery As String = "`BancMesure`.`id`='" & objBanc.id & "'"

                    ' Mise a jour de la date de derniere modification
                    If Not bsynchro Then
                        objBanc.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                    End If

                    paramsQuery = paramsQuery & " , `BancMesure`.`idStructure`=" & objBanc.idStructure & ""

                    If Not objBanc.marque Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`marque`='" & CSDb.secureString(objBanc.marque) & "'"
                    End If
                    If Not objBanc.modele Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`modele`='" & CSDb.secureString(objBanc.modele) & "'"
                    End If
                    If objBanc.dateDernierControle IsNot Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateDernierControle`='" & CSDate.mysql2access(objBanc.dateDernierControle) & "'"
                    End If
                    If Not objBanc.dateAchat Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateAchat`='" & CSDate.mysql2access(objBanc.dateAchat) & "'"
                    End If
                    If Not objBanc.dateModificationAgent Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateModificationAgent`='" & CSDate.mysql2access(objBanc.dateModificationAgent) & "'"
                    End If
                    If Not objBanc.dateModificationCrodip Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateModificationCrodip`='" & CSDate.mysql2access(objBanc.dateModificationCrodip) & "'"
                    End If
                    paramsQuery = paramsQuery & " , `BancMesure`.`etat`=" & objBanc.etat & ""
                    paramsQuery = paramsQuery & " , `BancMesure`.`isUtilise`=" & objBanc.isUtilise & ""
                    paramsQuery = paramsQuery & " , `BancMesure`.`isSupprime`=" & objBanc.isSupprime & ""
                    paramsQuery = paramsQuery & " , `BancMesure`.`nbControles`=" & objBanc.nbControles & ""
                    paramsQuery = paramsQuery & " , `BancMesure`.`nbControlesTotal`=" & objBanc.nbControlesTotal & ""
                    If Not objBanc.AgentSuppression Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`agentSuppression`='" & objBanc.AgentSuppression & "'"
                    End If
                    If Not objBanc.RaisonSuppression Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`raisonSuppression`='" & objBanc.RaisonSuppression & "'"
                    End If
                    If Not objBanc.DateSuppression Is Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateSuppression`='" & CSDate.mysql2access(objBanc.DateSuppression) & "'"
                    End If

                    paramsQuery = paramsQuery & " , `BancMesure`.`jamaisServi`=" & objBanc.JamaisServi & ""
                    If objBanc.DateActivation <> Nothing Then
                        paramsQuery = paramsQuery & " , `BancMesure`.`dateActivation`='" & CSDate.mysql2access(objBanc.DateActivation) & "'"
                    End If


                    ' On finalise la requete et en l'execute
                    bddCommande.CommandText = "UPDATE `BancMesure` SET " & paramsQuery & " WHERE `BancMesure`.`id`='" & objBanc.id & "'"
                    bddCommande.ExecuteNonQuery()
                    bReturn = True
                End If

            End If
        Catch ex As Exception
            CSDebug.dispError("Err BancManager - Save : " & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objBanc As Banc)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `BancMesure` SET `BancMesure`.`dateModificationCrodip`='" & newDate & "',`BancMesure`.`dateModificationAgent`='" & newDate & "' WHERE `BancMesure`.`id`='" & objBanc.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("BancManager::setSynchro : " & ex.Message)
        End Try
    End Sub


    Public Shared Function getBancById(ByVal banc_id As String) As Banc
        Debug.Assert(Not String.IsNullOrEmpty(banc_id), "L'Id doit être non null")
        ' déclarations
        Dim tmpBanc As New Banc
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = oCSdb.getConnection().CreateCommand()

        bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.id='" & banc_id & "'"
        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                tmpBanc.Fill(tmpListProfils)
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("BancManager Error: " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSdb Is Nothing Then
            oCSdb.free()
        End If

        'on retourne le banc ou un objet vide en cas d'erreur
        Return tmpBanc
    End Function
#End Region
    '''
    ''' Marque l'utilisation du banc (Flag isUtilisé, date de dernier controle, création de la fiche de vie)
    '''
#Region " - Suppression - "
    '''
    ''' création d'un enregistrement bancMesure
    ''' L'ID doit êre initialisé
    '''
    Private Shared Function createBanc(ByVal pBancID As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pBancID))
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO `BancMesure` (`id`) VALUES ('" & pBancID & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("BancManager.createBanc error : " & ex.Message)
            bReturn = False
        End Try
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function 'CreateBanc

    Public Shared Function getUpdates(ByVal agent As Agent) As Banc()
        Debug.Assert(agent IsNot Nothing)
        ' déclarations
        Dim arrItems(0) As Banc
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM `BancMesure` WHERE `BancMesure`.`dateModificationAgent`<>`BancMesure`.`dateModificationCrodip` AND `BancMesure`.`idStructure`=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpBanc As New Banc
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpBanc.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpBanc
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - BancManager - getResult : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If

        'on retourne les objet non synchro
        Return arrItems
    End Function 'GetUpdates

#End Region

    Public Shared Function delete(ByVal pBancId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pBancId), " le paramètre ID doit être initialisé")
        Dim oCSDb As CSDb = nothing
        Dim bddCommande As OleDb.OleDbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCSDb = New CSDb(True)

            bddCommande = oCSDb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM BancMesure WHERE BancMesure.id='" & pBancId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bddCommande.CommandText = "DELETE FROM FicheVieBancMesure WHERE idBancMesure='" & pBancId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM controle_regulier WHERE CTRG_MatID='" & pBancId & "' and CTRG_TYPE = 'BANC'"
            nResult = bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM controleBancMesure WHERE idBanc='" & pBancId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("BancManager.delete (" & pBancId.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCSDb Is Nothing Then
            oCSDb.free()
        End If
        Return bReturn
    End Function 'delete

    ''' <summary>
    ''' Rend une collection des matériels supprimés appartenant à la structure
    ''' </summary>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMaterielsSupprimes(ByVal pIdStructure As String) As Collection
        Debug.Assert(Not String.IsNullOrEmpty(pIdStructure), "L'Id Structre doit être initialisé")
        Dim colReturn As New Collection()
        Dim oCSDb As CSDb = nothing
        Dim bddCommande As OleDb.OleDbCommand = Nothing
        Dim oDataReader As System.Data.OleDb.OleDbDataReader
        Try
            If pIdStructure <> "" Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE idStructure=" & pIdStructure & " AND isSupprime=" & True & " ORDER BY dateSuppression DESC"
            End If
            oDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oBanc As New Banc
                Dim tmpColId As Integer = 0
                While tmpColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(tmpColId) Then
                        oBanc.Fill(oDataReader.GetName(tmpColId), oDataReader.GetValue(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                colReturn.Add(oBanc)
                i = i + 1
            End While

        Catch ex As Exception
            CSDebug.dispError("BancManager.GetMaterielSupprimes Error" & ex.Message)

        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return colReturn
    End Function 'GetMatereilSupprimes
    '''
    ''' Récupération des bancs de la structure isSupprimé=False, JamaisServi = false
    ''' isShowall = TRUE => on ne regarde pas l'état, False seuls les bancs Etat = True sont retournés
    '''
    Public Shared Function getBancByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of Banc)
        Dim lstBanc As New List(Of Banc)
        Dim oCsDB As New CSDb(True)
        If pIdStructure <> "" Then

            Dim bddCommande As OleDb.OleDbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est déjà ouverte ou non
            If isShowAll Then
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " "
            Else
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " AND BancMesure.etat=" & True & ""
            End If
            Try

                ' On récupère les résultats
                Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On rempli notre tableau
                    Dim oBanc As New Banc
                    If oBanc.Fill(oDataReader) Then
                        lstBanc.Add(oBanc)
                        i = i + 1
                    End If

                End While
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("AgentManager.getBanc : " & ex.Message)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCsDB Is Nothing Then
                ' On ferme la connexion
                oCsDB.free()
            End If

        End If
        Return lstBanc
    End Function

    '''
    ''' Récupération des bancs de la structure isSupprimé=False, JamaisServi = false
    ''' isShowall = TRUE => on ne regarde pas l'état, False seuls les bancs Etat = True sont retournés
    '''
    Public Shared Function getBancByStructureIdJamaisServi(ByVal pIdStructure As String) As List(Of Banc)
        Dim lstBanc As New List(Of Banc)
        Dim oCsDB As New CSDb(True)
        If pIdStructure <> "" Then

            Dim bddCommande As OleDb.OleDbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est déjà ouverte ou non
            bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & True & " "
            Try

                ' On récupère les résultats
                Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On rempli notre tableau
                    Dim oBanc As New Banc
                    If oBanc.Fill(oDataReader) Then
                        lstBanc.Add(oBanc)
                        i = i + 1
                    End If

                End While
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("BancManager.getBancByStructureIdJamaisServi : " & ex.Message)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCsDB Is Nothing Then
                ' On ferme la connexion
                oCsDB.free()
            End If

        End If
        Return lstBanc
    End Function
End Class
