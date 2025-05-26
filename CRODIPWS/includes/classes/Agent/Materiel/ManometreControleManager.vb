Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.ServiceModel
Imports System.Xml.Serialization
Public Class ManometreControleManager
    Inherits RootManager

#Region "Methodes Web Service"

    Public Shared Function WSgetById(ByVal puid As Integer, paid As String) As ManometreControle
        Dim oreturn As ManometreControle
        oreturn = RootWSGetById(Of ManometreControle)(puid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pManometreControle As ManometreControle, ByRef pReturn As ManometreControle) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of ManometreControle)(pManometreControle, pReturn)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSManometreControle : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
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
                Dim existsObject As ManometreControle
                existsObject = ManometreControleManager.getManometreControleByidCrodip(objManometreControle.idCrodip)
                If existsObject.idCrodip = "" Or existsObject.idCrodip = "0" Then
                    ' Si il n'existe pas, on le crée
                    createManometreControle(objManometreControle.idCrodip)
                End If

                Dim bddCommande As DbCommand

                bddCommande = oCSDb.getConnection().CreateCommand()

                ' Mise a jour de la date de derniere modification
                If Not bSynhcro Then
                    objManometreControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If
                ' Initialisation de la requete
                Dim paramsQuery As String = "numeroNational='" & objManometreControle.numeroNational & "'"
                paramsQuery = paramsQuery & " , idStructure=" & objManometreControle.uidstructure & ""
                paramsQuery = paramsQuery & " , uidstructure=" & objManometreControle.uidstructure & ""
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

                If Not objManometreControle.agentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & objManometreControle.agentSuppression & "'"
                End If
                If Not objManometreControle.raisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & objManometreControle.raisonSuppression & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreControle.dateSuppression) Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(objManometreControle.dateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & objManometreControle.jamaisServi & ""
                If objManometreControle.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(objManometreControle.DateActivation) & "'"
                End If
                paramsQuery = paramsQuery & " , typeTraca='" & objManometreControle.typeTraca & "'"
                paramsQuery = paramsQuery & " , numTraca=" & objManometreControle.numTraca & ""
                paramsQuery = paramsQuery & " , typeRaccord='" & objManometreControle.typeRaccord & "'"

                paramsQuery = paramsQuery & objManometreControle.getRootQuery()
                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentManoControle SET " & paramsQuery & " WHERE idCrodip='" & objManometreControle.idCrodip & "'"
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
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
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
    ''' <param name="pNumNatMano">ID Mano (pas l'idCrodip)</param>
    ''' <returns></returns>
    Public Shared Function getManometreControleByNumeroNational(ByVal pNumNatMano As String) As ManometreControle
        ' déclarations
        Dim tmpManometreControle As New ManometreControle
        Dim oCSDB As New CSDb(True)
        If pNumNatMano <> "" Then

            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE numeroNational='" & pNumNatMano & "'"
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
    Friend Shared Function getByKey(puid As Integer) As ManometreControle
        Dim oReturn As ManometreControle
        Try
            oReturn = getByuid(Of ManometreControle)("AgentManoControle", puid)
        Catch ex As Exception
            CSDebug.dispError("ManometreControleManager.GetByKey ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn

    End Function

    Public Shared Function getManometreControleByidCrodip(ByVal pIdCrodip As String) As ManometreControle
        ' déclarations
        Dim tmpManometreControle As New ManometreControle
        Dim oCSDB As New CSDb(True)
        If pIdCrodip <> "" Then

            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE idCrodip='" & pIdCrodip & "'"
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
                CSDebug.dispFatal("ManometreControleManager.getByIdCrodip Error: " & ex.Message)
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
                bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE idStructure=" & pIdStructure & " AND isSupprime<>0  ORDER BY dateSuppression DESC"
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

    Private Shared Sub createManometreControle(ByVal pIdCrodip As String)
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentManoControle (idCrodip, aid) VALUES ('" & pIdCrodip & "', '" & pIdCrodip & "')"
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
        If agent.oPool Is Nothing Then
            bddCommande.CommandText = "SELECT * FROM AgentManoControle WHERE( AgentManoControle.dateModificationAgent>AgentManoControle.dateModificationCrodip or dateModificationCrodip is null) AND AgentManoControle.idStructure=" & agent.uidstructure
        Else
            bddCommande.CommandText = "SELECT * FROM AgentManoControle MAT inner join PoolManoControle PA on MAT.uid = PA.uidmanoc WHERE PA.uidPool = " & agent.oPool.uid & " and (MAT.dateModificationAgent>MAT.dateModificationCrodip or MAT.dateModificationCrodip is null)"
        End If

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

    Public Shared Function getlstByAgent(ByVal pAgent As Agent, ByVal isShowAll As Boolean, Optional pListByStructure As Boolean = False) As List(Of ManometreControle)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of ManometreControle)
        Dim sql As String
        If pListByStructure Then
            sql = "SELECT * FROM AgentManoControle MAT WHERE MAT.idStructure=" & pAgent.idStructure & " AND MAT.isSupprime=" & False & " "
        Else
            sql = "SELECT MAT.* FROM AgentManoControle MAT inner join PoolManoControle PA on MAT.uid = PA.uidmanoc WHERE PA.uidPool = " & pAgent.oPool.uid & " AND MAT.isSupprime=" & False & ""
        End If
        If Not isShowAll Then
            sql = sql & " AND MAT.etat=" & True & ""
        End If
        Dim sql2 As String
        'on prend d'abord Ceux qui ont servi
        sql2 = sql & " AND JamaisServi=" & False & ""
        sql2 = sql2 & " ORDER BY TypeTraca, numTraca"
        arrResponse = getListe(Of ManometreControle)(sql2)

        'puis ceux qui n'ont jamais servi
        sql2 = sql & " AND JamaisServi=" & True & ""
        sql2 = sql2 & " ORDER BY TypeTraca, numTraca"
        arrResponse.AddRange(getListe(Of ManometreControle)(sql2))

        Return arrResponse
    End Function

End Class
