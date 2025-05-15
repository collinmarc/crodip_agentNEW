Imports System.Collections.Generic
Imports System.Data.Common
Imports CRODIPWS

Public Class ManometreEtalonManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As ManometreEtalon
        Dim oreturn As ManometreEtalon
        oreturn = RootWSGetById(Of ManometreEtalon)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pManometreEtalon As ManometreEtalon, ByRef pReturn As ManometreEtalon) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of ManometreEtalon)(pManometreEtalon, pReturn)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSManometreEtalon : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    Friend Shared Function getByKey(puid As Integer) As ManometreEtalon
        Dim oReturn As ManometreEtalon
        Try
            oReturn = getByuid(Of ManometreEtalon)("AgentManoEtalon", puid)
        Catch ex As Exception
            CSDebug.dispError("ManometreEtalonManager.GetByKey ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn

    End Function

    'Public Shared Function getWSManometreEtalonById(pAgent As Agent, ByVal manometreetalon_id As String) As ManometreEtalon
    '    Dim objManometreEtalon As New ManometreEtalon
    '    Try

    '        ' déclarations
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim objWSCrodip_response As New Object
    '        ' Appel au WS
    '        Dim codeResponse As Integer = objWSCrodip.GetManometreEtalon(pAgent.id, manometreetalon_id, objWSCrodip_response)
    '        Select Case codeResponse
    '            Case 0 ' OK
    '                ' construction de l'objet
    '                Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '                For Each objWSCrodip_responseItem In objWSCrodip_response
    '                    If (objWSCrodip_responseItem.InnerText() <> "") Then
    '                        objManometreEtalon.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
    '                    End If

    '                Next
    '            Case 1 ' NOK
    '                CSDebug.dispError("ManometreEtalonManager - Code 1 : Non-Trouvée")
    '            Case 9 ' BADREQUEST
    '                CSDebug.dispError("ManometreEtalonManager - Code 9 : Bad Request")
    '        End Select
    '    Catch ex As Exception
    '        CSDebug.dispError("ManometreEtalonManager - getWSManometreEtalonById : " & ex.Message)
    '    End Try
    '    Return objManometreEtalon

    'End Function

    'Public Shared Function sendWSManometreEtalon(pAgent As Agent, ByVal manometreetalon As ManometreEtalon) As Integer
    '    Try
    '        Dim updatedObject As New Object
    '        ' Appel au Web Service
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '        Dim info As String = ""
    '        Return objWSCrodip.SendManometreEtalon(manometreetalon, info, updatedObject)
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'Public Shared Function xml2object(ByVal arrXml As Object) As ManometreEtalon
    '    Dim objManometreEtalon As New ManometreEtalon

    '    For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
    '        If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
    '            objManometreEtalon.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
    '        End If
    '    Next

    '    Return objManometreEtalon
    'End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function FTO_getNewId(ByVal pAgent As Agent) As String
        ' déclarations
        Dim tmpObjectId As String = pAgent.uidstructure & "-" & pAgent.id & "-1"
        If pAgent.uidstructure <> 0 Then

            Dim bddCommande As DbCommand
            Dim oCSDB As New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT AgentManoEtalon.idCrodip FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational LIKE '" & pAgent.uidstructure & "-" & pAgent.id & "-%' ORDER BY AgentManoEtalon.idCrodip DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.uidstructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = pAgent.uidstructure & "-" & pAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("ManoEtalon - newId : " & ex.Message & vbNewLine)
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

    Public Shared Function save(ByVal objManometreEtalon As ManometreEtalon, Optional bSyncro As Boolean = False) As Boolean

        Dim paramsQuery As String = ""
        Dim oCsdb As CSDb = Nothing
        Dim bReturn As Boolean
        Try
            If objManometreEtalon.numeroNational <> "" Then
                oCsdb = New CSDb(True)


                ' On test si l'object existe ou non
                Dim existsObject As ManometreEtalon
                existsObject = ManometreEtalonManager.getManometreEtalonByidCrodip(objManometreEtalon.idCrodip)
                If existsObject.idCrodip = "" Or existsObject.idCrodip = "0" Then
                    ' Si il n'existe pas, on le crée
                    createManometreEtalon(objManometreEtalon.idCrodip)
                End If

                Dim bddCommande As DbCommand
                bddCommande = oCsdb.getConnection().CreateCommand()

                ' Initialisation de la requete
                paramsQuery = "numeroNational='" & objManometreEtalon.numeroNational & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSyncro Then
                    objManometreEtalon.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not objManometreEtalon.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , idCrodip='" & CSDb.secureString(objManometreEtalon.idCrodip) & "'"
                End If
                paramsQuery = paramsQuery & " , idStructure=" & objManometreEtalon.uidstructure & ""
                paramsQuery = paramsQuery & " , uidstructure=" & objManometreEtalon.uidStructure & ""
                If Not objManometreEtalon.marque Is Nothing Then
                    paramsQuery = paramsQuery & " , marque='" & CSDb.secureString(objManometreEtalon.marque) & "'"
                End If
                If Not objManometreEtalon.classe Is Nothing Then
                    paramsQuery = paramsQuery & " , classe='" & CSDb.secureString(objManometreEtalon.classe) & "'"
                End If
                If Not objManometreEtalon.incertitudeEtalon Is Nothing Then
                    paramsQuery = paramsQuery & " , incertitudeEtalon='" & CSDb.secureString(objManometreEtalon.incertitudeEtalon) & "'"
                End If
                If Not objManometreEtalon.type Is Nothing Then
                    paramsQuery = paramsQuery & " , type='" & CSDb.secureString(objManometreEtalon.type) & "'"
                End If
                If Not objManometreEtalon.fondEchelle Is Nothing Then
                    paramsQuery = paramsQuery & " , fondEchelle='" & CSDb.secureString(objManometreEtalon.fondEchelle) & "'"
                End If
                paramsQuery = paramsQuery & " , isSynchro=" & objManometreEtalon.isSynchro & ""
                If objManometreEtalon.dateDernierControle <> Nothing Then
                    paramsQuery = paramsQuery & " , dateDernierControle='" & CSDate.ToCRODIPString(objManometreEtalon.dateDernierControleS) & "'"
                End If
                paramsQuery = paramsQuery & " , etat=" & objManometreEtalon.etat & ""
                paramsQuery = paramsQuery & " , isUtilise=" & objManometreEtalon.isUtilise & ""
                paramsQuery = paramsQuery & " , isSupprime=" & objManometreEtalon.isSupprime & ""
                paramsQuery = paramsQuery & " , nbControles=" & objManometreEtalon.nbControles & ""
                paramsQuery = paramsQuery & " , nbControlesTotal=" & objManometreEtalon.nbControlesTotal & ""

                If Not objManometreEtalon.agentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & objManometreEtalon.agentSuppression & "'"
                End If
                If Not objManometreEtalon.raisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & objManometreEtalon.raisonSuppression & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreEtalon.dateSuppression) Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(objManometreEtalon.dateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & objManometreEtalon.jamaisServi & ""
                If objManometreEtalon.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(objManometreEtalon.DateActivation) & "'"
                End If
                paramsQuery = paramsQuery & objManometreEtalon.getRootQuery()
                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentManoEtalon SET " & paramsQuery & " WHERE idCrodip='" & objManometreEtalon.idCrodip & "'"
                bddCommande.ExecuteNonQuery()
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager.Save  Error : " & ex.Message.ToString() & paramsQuery)
            bReturn = False
        End Try
        If oCsdb IsNot Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objManometreEtalon As ManometreEtalon)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE AgentManoEtalon SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE numeroNational='" & objManometreEtalon.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub incNbControles(ByVal objManometreEtalon As ManometreEtalon)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE AgentManoEtalon SET nbControles=(nbControles+1), nbControlesTotal=(nbControlesTotal+1) WHERE AgentManoEtalon.numeroNational='" & objManometreEtalon.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager::incNbControles : " & ex.Message)
        End Try
    End Sub
    Public Shared Sub resetNbControles(ByVal objManometreEtalon As ManometreEtalon)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE AgentManoEtalon SET nbControles=0 WHERE numeroNational='" & objManometreEtalon.numeroNational & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager::resetNbControles : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getManometreEtalonByNumeroNational(ByVal pNumeroNational As String) As ManometreEtalon
        ' déclarations
        Dim tmpManometreEtalon As New ManometreEtalon
        Dim oCsdb As CSDb = Nothing
        If pNumeroNational <> "" Then
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational='" & pNumeroNational & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    tmpManometreEtalon.FillDR(tmpListProfils)
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("ManometreEtalonManager Error: " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        'on retourne le manometreetalon ou un objet vide en cas d'erreur
        Return tmpManometreEtalon
    End Function
    Public Shared Function getManometreEtalonByidCrodip(ByVal pIdCrodip As String) As ManometreEtalon
        ' déclarations
        Dim tmpManometreEtalon As New ManometreEtalon
        Dim oCsdb As CSDb = Nothing
        If pIdCrodip <> "" Then
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE AgentManoEtalon.idCrodip='" & pIdCrodip & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    tmpManometreEtalon.FillDR(tmpListProfils)
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("ManometreEtalonManager.getManometreEtalonByIdCrodip Error: ", ex)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        'on retourne le manometreetalon ou un objet vide en cas d'erreur
        Return tmpManometreEtalon
    End Function

    Public Shared Function getlstByAgent(ByVal pAgent As Agent, ByVal isShowAll As Boolean) As List(Of ManometreEtalon)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of ManometreEtalon)
        Dim sql As String
        If Not GlobalsCRODIP.GLOB_PARAM_GestiondesPools Then
            sql = "SELECT * FROM AgentManoEtalon MAT WHERE MAT.idStructure=" & pAgent.idStructure & " AND MAT.isSupprime=" & False & " "
        Else
            sql = "SELECT MAT.* FROM AgentManoEtalon MAT inner join PoolManoEtalon PA on MAT.uid = PA.uidmanoe WHERE PA.uidPool = " & pAgent.oPool.uid & " AND MAT.isSupprime=" & False & ""
        End If
        If Not isShowAll Then
            sql = sql & " AND MAT.etat=" & True & ""
        End If
        Dim sql2 As String
        'on prend d'abord Ceux qui ont servi
        sql2 = sql & " AND JamaisServi=" & False & ""
        '        sql2 = sql2 & " ORDER BY TypeTraca, numTraca"
        arrResponse = getListe(Of ManometreEtalon)(sql2)

        'puis ceux qui n'ont jamais servi
        sql2 = sql & " AND JamaisServi=" & True & ""
        '        sql2 = sql2 & " ORDER BY TypeTraca, numTraca"
        arrResponse.AddRange(getListe(Of ManometreEtalon)(sql2))

        Return arrResponse
    End Function

    Public Shared Function getlstByAgentJamaisServi(ByVal pAgent As Agent) As List(Of ManometreEtalon)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit être renseigné")
        Dim arrResponse As New List(Of ManometreEtalon)
        Dim sql As String
        If Not GlobalsCRODIP.GLOB_PARAM_GestiondesPools Then
            sql = "SELECT * FROM AgentManoEtalon MAT WHERE MAT.idStructure=" & pAgent.idStructure & " AND MAT.isSupprime=" & False & " AND MAT.jamaisServi = " & False & " "
        Else
            sql = "SELECT MAT.* FROM AgentManoEtalon MAT inner join PoolManoEtalon PA on MAT.uid = PA.uidmanoe WHERE PA.uidPool = " & pAgent.oPool.uid & " AND MAT.isSupprime=" & False & ""
        End If
        'If Not isShowAll Then
        '    sql = sql & " AND AgentManoControle.etat=" & True & ""
        'End If
        Dim sql2 As String
        'on prend d'abord Ceux qui ont servi
        'sql2 = sql & " AND AgentManoControle.JamaisServi=" & False & ""
        'arrResponse = getListe(Of ManometreControle)(sql2)

        'puis ceux qui n'ont jamais servi
        sql2 = sql & " AND JamaisServi=" & True & ""
        sql2 = sql2 & " ORDER BY TypeTraca, numTraca"
        arrResponse.AddRange(getListe(Of ManometreEtalon)(sql2))


        Return arrResponse
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
                bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE idStructure=" & pIdStructure & " AND isSupprime<>0 ORDER BY dateSuppression DESC"
                oDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreEtalon
                    oMano.FillDR(oDataReader)
                    colReturn.Add(oMano)
                End While
                oDataReader.Close()
            End If

        Catch ex As Exception
            CSDebug.dispError("ManometreEtalonManager.GetMateriel Error" & ex.Message)

        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return colReturn
    End Function

    Public Shared Function setUtilise(ByVal pAgent As Agent, ByVal objManometreEtalon As ManometreEtalon) As Boolean
        Dim bReturn As Boolean
        Try
            If Not objManometreEtalon.isUtilise Then
                CSDebug.dispInfo("ManometreEtalonManager.setUtilise() :  Creattion FV")
                objManometreEtalon.creerFicheViePremiereUtilisation(pAgent)
                objManometreEtalon.isUtilise = True
                CSDebug.dispInfo("ManometreEtalonManager.setUtilise() :  Save ManoE")
                save(objManometreEtalon)
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager.setUtilise() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#Region " - Suppression - "

    Public Shared Function delete(ByVal pNumeroNational As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pNumeroNational), " le paramètre pNumeroNational doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bddCommande.CommandText = "DELETE FROM FicheVieManometreEtalon WHERE idManometre='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager.delete (" & pNumeroNational.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

#End Region

    Private Shared Function createManometreEtalon(ByVal pCrodipId As String) As Boolean
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Try
            Dim bddCommande As DbCommand
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentManoEtalon (idCrodip, aid) VALUES ('" & pCrodipId & "','" & pCrodipId & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("ManometreEtalonManager.createManometreEtalon error : " & ex.Message)
            bReturn = False
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Function getUpdates(ByVal agent As Agent) As ManometreEtalon()
        ' déclarations
        Dim arrItems(0) As ManometreEtalon
        Dim oCsdb As CSDb = Nothing
        Try
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            If agent.oPool Is Nothing Then
                bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE (AgentManoEtalon.dateModificationAgent>AgentManoEtalon.dateModificationCrodip or dateModificationCrodip is null) AND AgentManoEtalon.idStructure=" & agent.uidstructure
            Else
                bddCommande.CommandText = "SELECT * FROM AgentManoEtalon MAT inner join PoolManoEtalon PA on MAT.uid = PA.uidmanoe WHERE PA.uidPool = " & agent.oPool.uid & " and (MAT.dateModificationAgent>MAT.dateModificationCrodip or MAT.dateModificationCrodip is null)"
            End If

            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpManometreEtalon As New ManometreEtalon
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpManometreEtalon.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpManometreEtalon
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
            tmpListProfils.Close()

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - ManometreEtalonManager - getResult : " & ex.Message)
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
End Class
