Imports System.Collections.Generic
Imports System.Data.Common

Public Class IdentifiantPulverisateurManager

    Public Shared Function Save(ByVal pIdent As IdentifiantPulverisateur, Optional pSynchro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Try
            'Si c'est une sauvegarde de Synchro
            'la date de modif Agent = Date de modif Crodip
            If pSynchro Then
                pIdent.dateModificationAgent = pIdent.dateModificationCrodip
            Else
                pIdent.dateModificationAgent = CSDate.ToCRODIPString(Date.Now)
            End If
            If Not exists(pIdent.id) Then
                bReturn = Insert(pIdent)
            Else
                bReturn = Update(pIdent)
            End If

        Catch ex As Exception
            CSDebug.dispFatal("IdentifiantPulverisateurManager Save ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function exists(ByVal pId As Long) As Boolean
        Dim bReturn As Boolean

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM IdentifiantPulverisateur WHERE id=" & pId & "")
            bReturn = tmpResults.HasRows
            tmpResults.Close()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("IdentifiantPulverisateurManager::exists() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend le nobre de publvérisateur par numéro national
    ''' </summary>
    ''' <param name="numeroNational">Numéro complet</param>
    ''' <returns>Nbre de pulvé</returns>
    ''' <remarks></remarks>

    Public Shared Function getNextId() As Integer
        Dim bdd As CSDb
        Dim returnVal As Integer
        bdd = New CSDb(True)
        Try
            Dim dataResults As DbDataReader = bdd.getResult2s("SELECT Max(id)+1 AS Id FROM IdentifiantPulverisateur ")
            While dataResults.Read()
                returnVal = dataResults.GetInt32(0)
            End While
            dataResults.Close()
        Catch ex As Exception
            returnVal = 0
        End Try
        bdd.free()
        Return returnVal
    End Function
    ''' <summary>
    ''' Insertion d'un IdentifiantPulveristaeur dans la base
    ''' Si Synchro par de mise à jour de la date de modif Agent
    ''' </summary>
    ''' <param name="pIdent"></param>
    ''' <param name="pSynchro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Private Shared Function Insert(pIdent As IdentifiantPulverisateur) As Boolean
        Dim bReturn As Boolean
        Try
            Dim strQuery As String
            strQuery = "insert into identifiantPulverisateur (id,  idStructure ,  numeroNational ,  etat ,  dateUtilisation ,  libelle ,  idCRODIPPOOL, dateModificationAgent ,  dateModificationCrodip )"
            strQuery = strQuery & " VALUES ("
            strQuery = strQuery & pIdent.id & "," & pIdent.idStructure & ",'" & CSDb.secureString(pIdent.numeroNational) & "','" & CSDb.secureString(pIdent.etat) & "','" & CSDate.ToCRODIPString(pIdent.dateUtilisation) & "','" & CSDb.secureString(pIdent.libelle) & "','" & pIdent.idCRODIPPool & "' , '" & CSDate.ToCRODIPString(pIdent.dateModificationAgent) & "','" & CSDate.ToCRODIPString(pIdent.dateModificationCrodip) & "'"
            strQuery = strQuery & " )"


            Dim oCSDb As New CSDb(True)
            bReturn = oCSDb.Execute(strQuery)

            oCSDb.free()

        Catch ex As Exception
            CSDebug.dispFatal("IDentifiantPulveristeurManager.save ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'Insert
    ''' <summary>
    ''' Mise à jour d'un IdentifiantPulvaristeur dans la BD
    ''' Si Synhcro => Pas de mise à jour de la date de modif Agent
    ''' </summary>
    ''' <param name="pIdent"></param>
    ''' <param name="pSynchro"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function Update(pIdent As IdentifiantPulverisateur) As Boolean
        Dim bReturn As Boolean
        Try
            Dim strQuery As String
            strQuery = "Update identifiantPulverisateur SET "
            strQuery = strQuery & "  idStructure =" & pIdent.idStructure & ","
            strQuery = strQuery & "  numeroNational ='" & CSDb.secureString(pIdent.numeroNational) & "',"
            strQuery = strQuery & "  etat = '" & CSDb.secureString(pIdent.etat) & "'" & ","
            strQuery = strQuery & "  dateUtilisation ='" & CSDate.ToCRODIPString(pIdent.dateUtilisation) & "'" & ","
            strQuery = strQuery & "  libelle ='" & CSDb.secureString(pIdent.libelle) & "'" & ","
            strQuery = strQuery & "  idCrodipPool ='" & CSDb.secureString(pIdent.idCRODIPPool) & "'" & ","
            strQuery = strQuery & "  dateModificationAgent ='" & CSDate.ToCRODIPString(pIdent.dateModificationAgent) & "'" & ","
            strQuery = strQuery & "  dateModificationCrodip = '" & CSDate.ToCRODIPString(pIdent.dateModificationCrodip) & "'"

            strQuery = strQuery & "WHERE id = " & pIdent.id


            Dim oCSDb As New CSDb(True)
            bReturn = oCSDb.Execute(strQuery)

            oCSDb.free()

        Catch ex As Exception
            CSDebug.dispFatal("IDentifiantPulveristeurManager.Update ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'Update
    ''' <summary>
    ''' Chargement d'un IdentifiantPulverisateur à partir de son ID
    ''' </summary>
    ''' <param name="pId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Load(ByVal pId As Long) As IdentifiantPulverisateur
        Dim bReturn As New IdentifiantPulverisateur()

        Try
            '## Préparation de la connexion
            Dim dbLink As New CSDb(True)
            '## Execution de la requete
            Dim oDataReader As DbDataReader
            oDataReader = dbLink.getResult2s("SELECT * FROM IdentifiantPulverisateur WHERE id=" & pId & "")
            While oDataReader.Read()
                ' On rempli notre Object
                Dim tmpColId As Integer = 0
                While tmpColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(tmpColId) Then
                        bReturn.Fill(oDataReader.GetName(tmpColId), oDataReader.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End While
            oDataReader.Close()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("IDentifiantPulveristeurManager::Load() : " & ex.Message)
            bReturn = New IdentifiantPulverisateur()
        End Try
        Return bReturn
    End Function 'Load
    ''' <summary>
    ''' Suppression d'un identifiant Pulverisateur à partir de son Id
    ''' </summary>
    ''' <param name="pIdent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Delete(ByVal pIdent As IdentifiantPulverisateur) As Boolean
        Dim bReturn As Boolean
        Try

            If exists(pIdent.id) Then
                Dim strQuery As String
                strQuery = "DELETE from identifiantPulverisateur "
                strQuery = strQuery & "WHERE id = " & pIdent.id
                Dim oCSDb As New CSDb(True)
                bReturn = oCSDb.Execute(strQuery)
                oCSDb.free()
            End If

        Catch ex As Exception
            CSDebug.dispFatal("IdentifiantPulverisateurManager.Delete ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'Delete
    ''' <summary>
    ''' Récupéraration d'un identifiantPulverisateur par WS à partir de son ID
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <param name="pId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getWSIdentifiantPulverisateurById(pAgent As Agent, ByVal pId As String) As IdentifiantPulverisateur
        Dim objIdent As New IdentifiantPulverisateur
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            objWSCrodip.Timeout = 10000
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetIdentifiantPulverisateur(pAgent.id, pId, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If objWSCrodip_responseItem.InnerText() <> "" Then
                            objIdent.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - PulverisateurManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - PulverisateurManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("IDentifiantPulveristeurManager.getWSIdentifiantPulverisateurById (" & pId & "): " & ex.Message)
            objIdent = Nothing
        End Try
        Return objIdent

    End Function 'getWSIdentifiantPulverisateurById
    ''' <summary>
    ''' Envoie d'un identifiant Pulveristaeur par WS
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <param name="pIdentPulve"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function sendWSIdentifiantPulverisateur(pAgent As Agent, ByVal pIdentPulve As IdentifiantPulverisateur) As Boolean
        Dim bReturn As Boolean
        Try

            ' déclarations
            'Dim objWSCrodip2 As WSCRODIP2.CrodipServer = WSCrodip.getWS2(True)
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            objWSCrodip.Timeout = 10000
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            'Dim rq As WSCrodip2.SendIdentifiantPulverisateurRequest
            'Dim oWSIdentificateurPulve As New WSCrodip2.IdentifiantPulverisateur()
            'oWSIdentificateurPulve.id = pIdentPulve.id
            'oWSIdentificateurPulve.idStructure = pIdentPulve.idStructure
            'oWSIdentificateurPulve.libelle = pIdentPulve.libelle
            'oWSIdentificateurPulve.numeroNational = pIdentPulve.numeroNational
            'oWSIdentificateurPulve.etat = pIdentPulve.etat
            'oWSIdentificateurPulve.dateUtilisation = pIdentPulve.dateUtilisation
            'oWSIdentificateurPulve.dateModificationCrodip = pIdentPulve.dateModificationCrodip
            'oWSIdentificateurPulve.dateModificationAgent = pIdentPulve.dateModificationAgent
            'SynchronisationManager.LogSynchroElmt(oWSIdentificateurPulve)

            'rq = New WSCrodip2.SendIdentifiantPulverisateurRequest(pAgent.id, oWSIdentificateurPulve)
            'Dim codeResponse As Integer = objWSCrodip.SendIdentifiantPulverisateur(pAgent.id, pIdentPulve)
            Dim codeResponse As Integer = objWSCrodip.SendIdentifiantPulverisateur(pAgent.id, pIdentPulve, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                Case 1 ' NOK
                    CSDebug.dispError("sendWSIdentifiantPulverisateurr - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("sendWSIdentifiantPulverisateur - Code 9 : Bad Request")
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulverisateurManager.SendWSIdentifiantPulverisateur (" & pIdentPulve.ToString() & ") ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function 'SendWSIndentifiantPulverisateur
    ''' <summary>
    ''' Renvoie un tableau d'elements à synchroniser
    ''' </summary>
    ''' <param name="agent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getUpdates(ByVal agent As Agent) As IdentifiantPulverisateur()
        ' déclarations
        Dim arrItems(0) As IdentifiantPulverisateur
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCSdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM IdentifiantPulverisateur WHERE (dateModificationAgent<>dateModificationCrodip  or dateModificationCrodip is null)"
        bddCommande.CommandText = bddCommande.CommandText & " AND idStructure=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While oDR.Read()
                ' On rempli notre tableau
                Dim oIdentPulve As New IdentifiantPulverisateur
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(tmpColId) Then
                        oIdentPulve.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = oIdentPulve
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)
            oDR.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("IdentifiantPulverisateurManager.getUpdates ERR : " & ex.Message)
        End Try

        oCSdb.free()
        'on retourne les objet non synchro
        Return arrItems
    End Function ' getUpdates
    ''' <summary>
    ''' Mise à jour des dates de modif (Agent et Synchro) à égalité 
    ''' </summary>
    ''' <param name="pIdentPulve"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function setSynchro(pIdentPulve As IdentifiantPulverisateur) As Boolean
        Dim bReturn As Boolean
        Try
            pIdentPulve.dateModificationCrodip = pIdentPulve.dateModificationAgent
            Save(pIdentPulve, True)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("IDentifiantPulverisateurManager.SetSynhcro ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getListe(pAgent As Agent) As List(Of IdentifiantPulverisateur)
        Debug.Assert(pAgent IsNot Nothing, "L'agent doit être renseigné")
        Dim olst As New List(Of IdentifiantPulverisateur)

        If String.IsNullOrEmpty(pAgent.idCRODIPPool) Then
            olst = getListeByStructure(pAgent.idStructure)
        Else
            olst = getListeByPool(pAgent.idCRODIPPool)
        End If

        Return olst

    End Function
    ''' <summary>
    ''' Rend la Liste des identifiants pour une structure donnée
    ''' </summary>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getListeByStructure(pIdStructure As Integer) As List(Of IdentifiantPulverisateur)
        Dim olst As New List(Of IdentifiantPulverisateur)
        Dim oCSDB As New CSDb(True)
        Try
            Dim oDR As DbDataReader
            oDR = oCSDB.getResult2s("SELECT * FROM IDENTIFIANTPULVERISATEUR WHERE IDSTRUCTURE = " & pIdStructure & " ORDER BY NUMERONATIONAL")
            While oDR.Read()
                Dim oIdentPulve As New IdentifiantPulverisateur
                Dim nColId As Integer = 0
                While nColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(nColId) Then
                        oIdentPulve.Fill(oDR.GetName(nColId), oDR.Item(nColId))
                    End If
                    nColId = nColId + 1
                End While
                olst.Add(oIdentPulve)
            End While
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulveristaeurManager.getListe ERR" & ex.Message)
        End Try
        Return olst
    End Function
    Private Shared Function getListeByPool(pIdCrodipPool As String) As List(Of IdentifiantPulverisateur)
        Dim olst As New List(Of IdentifiantPulverisateur)
        Dim oCSDB As New CSDb(True)
        Try
            Dim oDR As DbDataReader
            oDR = oCSDB.getResult2s("SELECT * FROM IDENTIFIANTPULVERISATEUR WHERE IDCRODIPPOOL = '" & pIdCrodipPool & "' ORDER BY NUMERONATIONAL")
            While oDR.Read()
                Dim oIdentPulve As New IdentifiantPulverisateur
                Dim nColId As Integer = 0
                While nColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(nColId) Then
                        oIdentPulve.Fill(oDR.GetName(nColId), oDR.Item(nColId))
                    End If
                    nColId = nColId + 1
                End While
                olst.Add(oIdentPulve)
            End While
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulveristaeurManager.getListeByPool ERR" & ex.Message)
        End Try
        Return olst
    End Function
    Public Shared Function getListeInutilise(pAgent As Agent) As List(Of IdentifiantPulverisateur)
        Debug.Assert(pAgent IsNot Nothing, "L'agent doit être renseigné")
        Dim olst As New List(Of IdentifiantPulverisateur)

        If String.IsNullOrEmpty(pAgent.idCRODIPPool) Then
            olst = getListeInutiliseByStructure(pAgent.idStructure)
        Else
            olst = getListeInutiliseByPool(pAgent.idCRODIPPool)
        End If

        Return olst

    End Function

    ''' <summary>
    ''' Rend la liste des Identifiants Pulvés Utilisables
    ''' </summary>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getListeInutiliseByStructure(pIdStructure As Integer) As List(Of IdentifiantPulverisateur)
        Dim olst As New List(Of IdentifiantPulverisateur)
        Try
            Dim olstAll As List(Of IdentifiantPulverisateur) = getListeByStructure(pIdStructure)
            For Each oIdentPulve As IdentifiantPulverisateur In olstAll
                If oIdentPulve.isEtatINUTILISE Then
                    olst.Add(oIdentPulve)
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulveristaeurManager.getListeInitulise ERR" & ex.Message)
        End Try
        Return olst
    End Function
    Private Shared Function getListeInutiliseByPool(pIdCrodipPool As String) As List(Of IdentifiantPulverisateur)
        Dim olst As New List(Of IdentifiantPulverisateur)
        Try
            Dim olstAll As List(Of IdentifiantPulverisateur) = getListeByPool(pIdCrodipPool)
            For Each oIdentPulve As IdentifiantPulverisateur In olstAll
                If oIdentPulve.isEtatINUTILISE Then
                    olst.Add(oIdentPulve)
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("IdentifiantPulveristaeurManager.getListeInitulise ERR" & ex.Message)
        End Try
        Return olst
    End Function
    ''' <summary>
    ''' Déclare l'identidiant Pulve comme été utilisé
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <param name="pNumeroNational"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function setIdentifiantPulveUtilise(pAgent As Agent, pNumeroNational As String) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = False
            Dim olst As List(Of IdentifiantPulverisateur) = getListeByStructure(pAgent.idStructure)
            For Each oIdentPulve As IdentifiantPulverisateur In olst
                If oIdentPulve.numeroNational = pNumeroNational Then
                    If Not oIdentPulve.isEtatUTILISE Then
                        oIdentPulve.SetEtatUTILISE()
                        oIdentPulve.dateUtilisation = CSDate.ToCRODIPString(Date.Now, "yyyy-MM-dd")
                        bReturn = Save(oIdentPulve)
                    End If
                End If
            Next
        Catch ex As Exception
            CSDebug.dispError("IDentifiantPulverisateurManager.setIdentifiantPulveUtilise ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function


End Class
