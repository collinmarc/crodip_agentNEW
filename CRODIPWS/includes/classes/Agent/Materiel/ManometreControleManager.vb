Imports System.Collections.Generic
Imports System.Data.Common
Public Class ManometreControleManager

#Region "Methodes Web Service"

    Public Shared Function getWSManometreControleById(pAgent As Agent, ByVal manometrecontrole_id As String) As ManometreControle
        Dim objManometreControle As New ManometreControle
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
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
            Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
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
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT AgentManoControle.numeroNational FROM AgentManoControle WHERE AgentManoControle.numeroNational LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY AgentManoControle.numeroNational DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
                CSDebug.dispError("ManoControleManager - newId : " & ex.Message & vbNewLine)
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

                Dim bddCommande As DbCommand

                bddCommande = oCSDb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "numeroNational='" & objManometreControle.numeroNational & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSynhcro Then
                    objManometreControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not objManometreControle.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , idCrodip='" & CSDb.secureString(objManometreControle.idCrodip) & "'"
                End If
                paramsQuery = paramsQuery & " , idStructure=" & objManometreControle.idStructure & ""
                If Not objManometreControle.marque Is Nothing Then
                    paramsQuery = paramsQuery & " , marque='" & CSDb.secureString(objManometreControle.marque) & "'"
                End If
                If Not objManometreControle.classe Is Nothing Then
                    paramsQuery = paramsQuery & " , classe='" & CSDb.secureString(objManometreControle.classe) & "'"
                End If
                If Not objManometreControle.type Is Nothing Then
                    paramsQuery = paramsQuery & " , type='" & CSDb.secureString(objManometreControle.type) & "'"
                End If
                If Not objManometreControle.fondEchelle Is Nothing Then
                    paramsQuery = paramsQuery & " , fondEchelle='" & CSDb.secureString(objManometreControle.fondEchelle) & "'"
                End If
                paramsQuery = paramsQuery & " , etat=" & objManometreControle.etat & ""
                paramsQuery = paramsQuery & " , isSynchro=" & objManometreControle.isSynchro & ""
                If objManometreControle.dateDernierControleS <> Nothing Then
                    paramsQuery = paramsQuery & " , dateDernierControle='" & CSDate.ToCRODIPString(objManometreControle.dateDernierControle) & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreControle.dateModificationAgent) Then
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(objManometreControle.dateModificationAgent) & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreControle.dateModificationCrodip) Then
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(objManometreControle.dateModificationCrodip) & "'"
                End If
                If Not objManometreControle.resolution Is Nothing Then
                    paramsQuery = paramsQuery & " , resolution='" & CSDb.secureString(objManometreControle.resolution) & "'"
                End If
                paramsQuery = paramsQuery & " , bAjusteur=" & objManometreControle.bAjusteur & ""
                If Not objManometreControle.resolutionLecture Is Nothing Then
                    paramsQuery = paramsQuery & " , resolutionLecture='" & CSDb.secureString(objManometreControle.resolutionLecture) & "'"
                End If
                paramsQuery = paramsQuery & " , isUtilise=" & objManometreControle.isUtilise & ""
                paramsQuery = paramsQuery & " , isSupprime=" & objManometreControle.isSupprime & ""
                paramsQuery = paramsQuery & " , nbControles=" & objManometreControle.nbControles & ""
                paramsQuery = paramsQuery & " , nbControlesTotal=" & objManometreControle.nbControlesTotal & ""

                If Not objManometreControle.AgentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & objManometreControle.AgentSuppression & "'"
                End If
                If Not objManometreControle.RaisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & objManometreControle.RaisonSuppression & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreControle.DateSuppression) Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(objManometreControle.DateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & objManometreControle.JamaisServi & ""
                If objManometreControle.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(objManometreControle.DateActivation) & "'"
                End If
                paramsQuery = paramsQuery & " , typeTraca='" & objManometreControle.typeTraca & "'"
                paramsQuery = paramsQuery & " , numTraca=" & objManometreControle.numTraca & ""
                paramsQuery = paramsQuery & " , typeRaccord='" & objManometreControle.typeRaccord & "'"

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentManoControle SET " & paramsQuery & " WHERE numeroNational='" & objManometreControle.numeroNational & "'"
                bddCommande.ExecuteNonQuery()

                'Suppression des Pools avant insertion
                clearlstPoolByManoC(objManometreControle.numeroNational)
                'Insertion des Pools
                objManometreControle.lstPools.ForEach(Sub(p)
                                                          insertPoolManoC(p.idCrodip, objManometreControle.numeroNational)
                                                      End Sub)

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
            dbLink.queryString = "UPDATE AgentManoControle SET dateModificationCrodip='" & newDate & "', dateModificationAgent='" & newDate & "' WHERE numeroNational='" & objManometreControle.numeroNational & "'"
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
            dbLink.queryString = "UPDATE AgentManoControle SET nbControles=0 WHERE numeroNational='" & objManometreControle.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreControleManager::resetNbControles : " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Lecture du mano de controle avec son 'NumeroNational' (Son Id unique)
    ''' </summary>
    ''' <param name="pManoId">ID Mano (pas l'idCrodip)</param>
    ''' <returns></returns>
    Public Shared Function getManometreControleByNumeroNational(ByVal pManoId As String) As ManometreControle
        ' déclarations
        Dim tmpManometreControle As New ManometreControle
        Dim oCSDB As New CSDb(True)
        If pManoId <> "" Then

            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE numeroNational='" & pManoId & "'"
            Try
                ' On récupère les résultats
                Using tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
    ''' Lecture du mano de controle avec sa tracabilité
    ''' </summary>
    ''' <param name="pTraca">codeTraca ([BH]1-20)</param>
    ''' <returns></returns>
    Public Shared Function getManometreControleByTraca(pIdStructure As Integer, ByVal pTraca As String, Optional pShowAll As Boolean = False) As ManometreControle
        Debug.Assert(Not String.IsNullOrEmpty(pTraca), "Traca doit être de type [BH]{1-20}")
        Debug.Assert(pTraca.Length > 1, "Traca doit être de type [BH]{1-20}")
        ' déclarations
        Dim tmpManometreControle As New ManometreControle
        Dim oCSDB As New CSDb(True)
        If pTraca <> "" Then
            Dim typetraca As String = Left(pTraca, 1)
            Dim numtraca As String = Mid(pTraca, 2)

            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE idStructure = " & pIdStructure & " and typeTraca='" & typetraca & "' and numTraca='" & numtraca & "'"
            If Not pShowAll Then
                'Si on ne les veut pas tous, on ne prend que les Actifs (Par defaut)
                bddCommande.CommandText = bddCommande.CommandText & " and etat=" & True & ""
            End If
            Try
                ' On récupère les résultats
                Using oDR As DbDataReader = bddCommande.ExecuteReader
                    ' Puis on les parcours
                    While oDR.Read()
                        ' On rempli notre tableau
                        Dim tmpColId As Integer = 0
                        While tmpColId < oDR.FieldCount()
                            If Not oDR.IsDBNull(tmpColId) Then
                                tmpManometreControle.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                            End If
                            tmpColId = tmpColId + 1

                        End While
                    End While
                    oDR.Close()
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
        Dim bddCommande As DbCommand = Nothing
        Dim oDataReader As DbDataReader
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
                If oMano.FillDR(oDataReader) Then
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

    Private Shared Sub createManometreControle(ByVal pNumeroNational As String)
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentManoControle (numeroNational) VALUES ('" & pNumeroNational & "')"
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
        Dim bddCommande As DbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE( AgentManoControle.dateModificationAgent>AgentManoControle.dateModificationCrodip or dateModificationCrodip is null) AND AgentManoControle.idStructure=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
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
        If Not oCsdb Is Nothing Then
            oCsdb.free()
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
            Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.idStructure=" & pIdStructure & " AND AgentManoControle.isSupprime=" & False & " AND AgentManoControle.jamaisServi = " & False & " "
            If Not isShowAll Then
                bddCommande.CommandText = bddCommande.CommandText & " AND AgentManoControle.etat=" & True & ""
            End If
            bddCommande.CommandText = bddCommande.CommandText & " ORDER BY idCrodip"

            Try
                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreControle
                    If oMano.FillDR(oDataReader) Then
                        arrResponse.Add(oMano)
                    End If
                End While
                oDataReader.Close()
            Catch ex As Exception
                ' On catch l'erreur
                CSDebug.dispError("ManoControleManager.getManoControle : " & ex.Message)
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
            Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE AgentManoControle.idStructure=" & pIdStructure & " AND AgentManoControle.isSupprime=" & False & " AND AgentManoControle.jamaisServi = " & True & ""
            Try
                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreControle
                    If oMano.FillDR(oDataReader) Then
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
    Public Shared Function getManoControleByAgentJamaisServi(ByVal pAgent As Agent, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreControle)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)
        If Not My.Settings.GestiondesPools Then
            arrResponse = getManoControleByStructureIdJamaisServi(pAgent.idStructure)
        Else
            arrResponse = getManoControleByPoolIdJamaisServi(pAgent.idCRODIPPool)
            If arrResponse.Count = 0 Then
                arrResponse = getManoControleByStructureIdJamaisServi(pAgent.idStructure)
            End If
            'Charegement de la Liste des pools du mano
            arrResponse.ForEach(Sub(M)
                                    M.lstPools.AddRange(getlstPoolByManoC(M.numeroNational))
                                End Sub)
        End If
        Return arrResponse
    End Function

    Public Shared Function getManoControleByAgent(ByVal pAgent As Agent, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreControle)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)
        If Not My.Settings.GestiondesPools Then
            arrResponse = getManoControleByStructureId(pAgent.idStructure, isShowAll)
        Else
            arrResponse = getManoControleByPoolId(pAgent.idCRODIPPool, isShowAll)
            'Charegement de la Liste des pools du mano
            arrResponse.ForEach(Sub(M)
                                    M.lstPools.AddRange(getlstPoolByManoC(M.idCrodip))
                                End Sub)
        End If
        Return arrResponse
    End Function
    Private Shared Function getManoControleByPoolId(ByVal pIdCrodipPool As String, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(pIdCrodipPool), "L'IDPool doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoControle , PoolManoC WHERE AgentManoControle.numeronational = PoolManoc.numeronationalManoC AND PoolManoc.idCRODIPPool = '" & pIdCrodipPool & "' AND AgentManoControle.isSupprime=" & False & " And AgentManoControle.jamaisServi = " & False & ""
        If Not isShowAll Then
            bddCommande.CommandText = bddCommande.CommandText & " AND AgentManoControle.etat=" & True
        End If
        bddCommande.CommandText = bddCommande.CommandText & " ORDER BY AgentManoControle.idCrodip"

        Try
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oMano As New ManometreControle
                If oMano.FillDR(oDataReader) Then
                    arrResponse.Add(oMano)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoControleManager.getManoControle : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return arrResponse
    End Function
    Private Shared Function getManoControleByPoolIdJamaisServi(ByVal pIdCrodipPool As String) As List(Of ManometreControle)
        Debug.Assert(Not String.IsNullOrEmpty(pIdCrodipPool), "L'IDPool doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoControle , PoolManoC WHERE AgentManoControle.numeronational = PoolManoc.numeronationalManoC AND PoolManoc.idCRODIPPool = '" & pIdCrodipPool & "' AND AgentManoControle.isSupprime=" & False & " And AgentManoControle.jamaisServi = " & True & ""
        bddCommande.CommandText = bddCommande.CommandText & " ORDER BY AgentManoControle.idCrodip"

        Try
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oMano As New ManometreControle
                If oMano.FillDR(oDataReader) Then
                    arrResponse.Add(oMano)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoControleManager.getManoControle : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return arrResponse
    End Function
    ''' <summary>
    ''' Charegement de la liste de Pool d'un Mano de Controle
    ''' </summary>
    ''' <param name="pnumeronationalManoC"></param>
    ''' <returns></returns>
    Private Shared Function getlstPoolByManoC(pnumeronationalManoC As String) As List(Of Pool)

        Dim oreturn As New List(Of Pool)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT Pool.* FROM Pool , PoolManoC WHERE Pool.idCrodip = PoolManoc.idCRODIPPool AND PoolManoc.numeronationalManoc = '" & pnumeronationalManoC & "'"

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
            CSDebug.dispError("ManoControleManager.getlstPoolByManoC : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return oreturn
    End Function
    Private Shared Function clearlstPoolByManoC(numeronationalManoC As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "DELETE FROM PoolManoC WHERE  PoolManoc.numeronationalManoc = '" & numeronationalManoC & "'"

        Try
            ' On récupère les résultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoControleManager.clearlstPoolByManoC : " & ex.Message)
            oreturn = False
        End Try


        Return oreturn
    End Function
    Private Shared Function insertPoolManoC(pIdPool As String, pnumeronational As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "insert into PoolManoC (idCRODIPPool, numeronationalManoC) vAlues ( '" & pIdPool & "','" & pnumeronational & "')"

        Try
            ' On récupère les résultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoControleManager.addPoolManoC : " & ex.Message)
            oreturn = False
        End Try


        Return oreturn
    End Function

    Public Shared Function getLstPoolById(pBuse As ManometreControle) As Boolean

        ' déclarations
        Dim bReturn As Boolean = False
        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
        Dim objWSCrodip_response As New Object
        Debug.Assert("FONCTION ManoMetreControleManager.getlstPoolByID Non implémentée")
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
