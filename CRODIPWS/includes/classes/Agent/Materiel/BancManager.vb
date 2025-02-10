Imports System.Collections.Generic
Imports System.Data.Common
Public Class BancManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As Banc
        Dim oreturn As Banc
        oreturn = RootWSGetById(Of Banc)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As Banc, ByRef pobjOut As Banc) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of Banc)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSBanc : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    'Public Shared Function getWSBancById(poAgent As Agent, ByVal banc_id As String) As Banc
    '    Dim objBanc As New Banc
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        Dim bReturn As Boolean
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetBanc(poAgent.id, banc_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    If objWSCrodip_responseItem.InnerText() <> "" Then
    '                        bReturn = objBanc.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
    '                        Debug.Assert(bReturn) ' Must be true
    '                    End If
    '                Next
    '            Case 1 ' NOK
    '                CSDebug.dispError("Erreur - BancManager - Code 1 : Non-Trouvée (" & banc_id & ")")
    '            Case 9 ' BADREQUEST
    '                CSDebug.dispError("Erreur - BancManager - Code 9 : Bad Request (" & banc_id & ")")
    '        End Select
    '    Catch ex As Exception
    '        CSDebug.dispError("Erreur - BancManager - getWSBancById (" & banc_id & ") : " & ex.Message)
    '    End Try
    '    Return objBanc

    'End Function

    'Public Shared Function sendWSBanc(pAgent As Agent, ByVal banc As Banc) As Integer
    '    Try
    '        Dim updatedObject As New Object
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim sinfo As String
    '        Dim uid As Integer
    '        Return objWSCrodip.SendBanc(banc, sinfo, uid)
    '    Catch ex As Exception
    '        CSDebug.dispError("BancManager.sendWSBanc Error " & ex.Message)
    '        If ex.InnerException IsNot Nothing Then
    '            CSDebug.dispError("BancManager.sendWSBanc Error " & ex.InnerException.Message)
    '        End If
    '    End Try
    'End Function

    'Public Shared Function xml2object(ByVal arrXml As Object) As Banc
    '    Dim objBanc As New Banc

    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
    '            objBanc.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
    '        End If
    '    Next

    '    Return objBanc
    'End Function

#End Region

#Region "Methodes Locales"
    ''' Cette méthode n'est plus utilisée depuis la 2.5.4.3 , car les matériels sont créés sur le Serveur 
    Public Shared Function FTO_getNewId(ByVal pAgent As Agent) As String
        ' déclarations
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Dim tmpObjectId As String = pAgent.uidStructure & "-" & pAgent.id & "-1"
        If pAgent.uidStructure <> 0 Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT BancMesure.id FROM BancMesure WHERE BancMesure.id LIKE '" & pAgent.uidStructure & "-" & pAgent.id & "-%' ORDER BY BancMesure.id DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.uidStructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpListProfils.Close()
                tmpObjectId = pAgent.uidStructure & "-" & pAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("BancManager - getnewIdForTestOnly : " & ex.Message & vbNewLine)
            End Try

            ' Test pour fermeture de connection BDD
            If oCsdb IsNot Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        'on retourne le nouvel id
        Return tmpObjectId
    End Function

    Public Shared Function save(ByVal objBanc As Banc, Optional bsynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(objBanc.id), "L'Id doit être inititialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
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
                    oCsdb = New CSDb(True)
                    bddCommande = oCsdb.getConnection().CreateCommand()

                    ' Initialisation de la requete
                    Dim paramsQuery As String = "id='" & objBanc.idBancMesure & "'"

                    ' Mise a jour de la date de derniere modification
                    If Not bsynchro Then
                        objBanc.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                    End If

                    paramsQuery = paramsQuery & " , idStructure=" & objBanc.uidStructure & ""

                    If Not objBanc.marque Is Nothing Then
                        paramsQuery = paramsQuery & " , marque='" & CSDb.secureString(objBanc.marque) & "'"
                    End If
                    If Not objBanc.modele Is Nothing Then
                        paramsQuery = paramsQuery & " , modele='" & CSDb.secureString(objBanc.modele) & "'"
                    End If
                    If objBanc.dateDernierControleS IsNot Nothing Then
                        paramsQuery = paramsQuery & " , dateDernierControle='" & CSDate.ToCRODIPString(objBanc.dateDernierControleS) & "'"
                    End If
                    If Not objBanc.dateAchat Is Nothing Then
                        paramsQuery = paramsQuery & " , dateAchat='" & CSDate.ToCRODIPString(objBanc.dateAchat) & "'"
                    End If
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(objBanc.dateModificationAgent) & "'"
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(objBanc.dateModificationCrodip) & "'"
                    paramsQuery = paramsQuery & " , etat=" & objBanc.etat & ""
                    paramsQuery = paramsQuery & " , isUtilise=" & objBanc.isUtilise & ""
                    paramsQuery = paramsQuery & " , isSupprime=" & objBanc.isSupprime & ""
                    paramsQuery = paramsQuery & " , nbControles=" & objBanc.nbControles & ""
                    paramsQuery = paramsQuery & " , nbControlesTotal=" & objBanc.nbControlesTotal & ""
                    If Not objBanc.agentSuppression Is Nothing Then
                        paramsQuery = paramsQuery & " , agentSuppression='" & objBanc.agentSuppression & "'"
                    Else
                        paramsQuery = paramsQuery & " , agentSuppression=''"
                    End If
                    If Not objBanc.raisonSuppression Is Nothing Then
                        paramsQuery = paramsQuery & " , raisonSuppression='" & objBanc.raisonSuppression & "'"
                    Else
                        paramsQuery = paramsQuery & " , raisonSuppression=''"
                    End If
                    If objBanc.dateSuppression <> "" Then
                        paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(objBanc.dateSuppression) & "'"
                    Else
                        paramsQuery = paramsQuery & " , dateSuppression=''"
                    End If

                    paramsQuery = paramsQuery & " , jamaisServi=" & objBanc.jamaisServi & ""
                    If objBanc.DateActivation <> Nothing Then
                        paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(objBanc.DateActivation) & "'"
                    End If
                    paramsQuery = paramsQuery & " , ModuleAcquisition='" & objBanc.moduleAcquisition & "'"
                    paramsQuery = paramsQuery & " , uidstructure='" & objBanc.uidStructure & "'"

                    paramsQuery = paramsQuery & objBanc.getRootQuery()


                    ' On finalise la requete et en l'execute
                    bddCommande.CommandText = "UPDATE BancMesure SET " & paramsQuery & " WHERE id='" & objBanc.id & "'"
                    bddCommande.ExecuteNonQuery()
                    If GlobalsCRODIP.GLOB_PARAM_GestiondesPools Then

                        'Suppression des Pools avant insertion
                        clearlstPoolByBanc(objBanc.id)
                        'Insertion des Pools
                        objBanc.lstPools.ForEach(Sub(p)
                                                     insertPoolBanc(p.idCrodip, objBanc.id)
                                                 End Sub)
                    End If

                    bReturn = True
                    End If

                End If
        Catch ex As Exception
            CSDebug.dispError("Err BancManager - Save : " & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objBanc As Banc)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE BancMesure SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objBanc.id & "'"
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
        Dim bddCommande As DbCommand
        bddCommande = oCSdb.getConnection().CreateCommand()

        bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.id='" & banc_id & "'"
        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()
                ' On rempli notre tableau
                tmpBanc.FillDR(oDR)
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("BancManager Error: " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCSdb Is Nothing Then
            oCSdb.free()
        End If
        If GlobalsCRODIP.GLOB_PARAM_GestiondesPools Then
            'Charegement de la Liste des pools 
            tmpBanc.lstPools.AddRange(getlstPoolByBanc(tmpBanc.id))
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
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO BancMesure (id) VALUES ('" & pBancID & "')"
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
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM BancMesure WHERE (BancMesure.dateModificationAgent<>BancMesure.dateModificationCrodip or dateModificationCrodip is null) AND BancMesure.idStructure=" & agent.uidStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
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
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand = Nothing
        Dim oDataReader As DbDataReader
        Try
            If pIdStructure <> "" Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE idStructure=" & pIdStructure & " AND isSupprime<>0 ORDER BY dateSuppression DESC"
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

    Public Shared Function getBancByAgent(pAgent As Agent, Optional ByVal isShowAll As Boolean = False) As List(Of Banc)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of Banc)
        If GlobalsCRODIP.GLOB_PARAM_GestiondesPools Then
            'If agentCourant.oPool.idBanc <> "" Then
            '    BancCourant = BancManager.getBancById(agentCourant.oPool.idBanc)
            '    arrResponse.Add(BancCourant)
            'Else
            '    'S'il n'y a pas de banc affecté au pool on prend tout
            '    arrResponse = BancManager.getBancByStructureId(agentCourant.idStructure, True)
            'End If
            arrResponse = getBancByPoolId(pAgent.idCRODIPPool, isShowAll)
            'Charegement de la Liste des pools 
            arrResponse.ForEach(Sub(B)
                                    B.lstPools.AddRange(getlstPoolByBanc(B.id))
                                End Sub)

        Else
            arrResponse = BancManager.getBancByStructureId(pAgent.uidStructure, isShowAll)
        End If
        Return arrResponse
    End Function
    Private Shared Function getBancByPoolId(ByVal pIdCrodipPool As String, Optional ByVal isShowAll As Boolean = False) As List(Of Banc)
        Debug.Assert(Not String.IsNullOrEmpty(pIdCrodipPool), "L'IDPool doit être renseigné")
        Dim arrResponse As New List(Of Banc)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT BancMesure.* FROM BancMesure , PoolBanc WHERE BancMesure.id = PoolBanc.numeronationalBanc AND PoolBanc.idCRODIPPool = '" & pIdCrodipPool & "' AND BancMesure.isSupprime=" & False & " And BancMesure.jamaisServi = " & False & ""
        If Not isShowAll Then
            bddCommande.CommandText = bddCommande.CommandText & " AND BancMesure.etat=" & True
        End If
        bddCommande.CommandText = bddCommande.CommandText & " ORDER BY BancMesure.id"

        Try
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oBanc As New Banc
                If oBanc.FillDR(oDataReader) Then
                    arrResponse.Add(oBanc)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("BancManager.getBancByPoolId : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return arrResponse
    End Function

    '''
    ''' Récupération des bancs de la structure isSupprimé=False, JamaisServi = false
    ''' isShowall = TRUE => on ne regarde pas l'état, False seuls les bancs Etat = True sont retournés
    '''
    Public Shared Function getBancByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of Banc)
        Dim lstBanc As New List(Of Banc)
        Dim oCsDB As New CSDb(True)
        If pIdStructure <> "" Then

            Dim bddCommande As DbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est déjà ouverte ou non
            If isShowAll Then
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " "
            Else
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " AND BancMesure.etat=" & True & ""
            End If
            Try

                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On rempli notre tableau
                    Dim oBanc As New Banc
                    If oBanc.FillDR(oDataReader) Then
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

            Dim bddCommande As DbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est déjà ouverte ou non
            bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & True & " "
            Try

                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On rempli notre tableau
                    Dim oBanc As New Banc
                    If oBanc.FillDR(oDataReader) Then
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
    ''' <summary>
    ''' Charegement de la liste de Pool d'un Banc
    ''' </summary>
    ''' <param name="pnumeronationalBanc"></param>
    ''' <returns></returns>
    Private Shared Function getlstPoolByBanc(pnumeronationalBanc As String) As List(Of Pool)

        Dim oreturn As New List(Of Pool)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT Pool.* FROM Pool , PoolBanc WHERE Pool.idCrodip = PoolBanc.idCRODIPPool AND PoolBanc.numeronationalBanc = '" & pnumeronationalBanc & "'"

        Try
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit le Pool
                Dim oPool As New Pool
                If oPool.FillDR(oDataReader) Then
                    'et on l'ajoute à la collection
                    oreturn.Add(oPool)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("BancManager.getlstPoolByBanc : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return oreturn
    End Function
    Private Shared Function clearlstPoolByBanc(numeronationalBanc As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "DELETE FROM PoolBanc WHERE  PoolBanc.numeronationalBanc = '" & numeronationalBanc & "'"

        Try
            ' On récupère les résultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("BancManager.clearlstPoolByBanc : " & ex.Message)
            oreturn = False
        End Try


        Return oreturn
    End Function
    Private Shared Function insertPoolBanc(pIdPool As String, pnumeronational As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "insert into PoolBanc (idCRODIPPool, numeronationalBanc) values ( '" & pIdPool & "','" & pnumeronational & "')"

        Try
            ' On récupère les résultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("BancManager.addPoolBanc : " & ex.Message)
            oreturn = False
        End Try


        Return oreturn
    End Function
    Public Shared Function getLstPoolById(pItem As Banc) As Boolean

        ' déclarations
        Dim bReturn As Boolean = False
        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
        Dim objWSCrodip_response As New Object
        Debug.Assert("FONCTION BancManager.getlstPoolByID Non implémentée")
        '' Appel au WS
        'Dim codeResponse As Integer = objWSCrodip.GetlstPoolByBuseId(agentCourant.id, pBuse.idCrodip, objWSCrodip_response)
        'Select Case codeResponse
        '    Case 0 ' OK
        '        ' construction de l'objet
        '        Dim objWSCrodip_responseItem As System.Xml.XmlNode
        '        For Each objWSCrodip_responseItem In objWSCrodip_response
        '            If objWSCrodip_responseItem.InnerText() <> "" Then

        '            End If
        '        Next
        '        bReturn = True
        '    Case 1 ' NOK
        '        CSDebug.dispError("Erreur - BuseManager - Code 1 : Non-Trouvée")
        '    Case 9 ' BADREQUEST
        '        CSDebug.dispError("Erreur - BuseManager - Code 9 : Bad Request")
        'End Select


        Return bReturn
    End Function
End Class
