Imports System.Collections.Generic
Imports System.Data.Common

Public Class PcManager
    Inherits RootManager
#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As Pc
        Dim oreturn As Pc
        oreturn = RootWSGetById(Of Pc)(p_uid, paid)
        Return oreturn
    End Function


    Public Shared Function WSSend(ByVal pAgentIn As Pc, ByRef pReturn As Pc) As Integer
        Dim codeResponse As Integer = 99
        codeResponse = RootWSSend(Of Pc)(pAgentIn, pReturn)
        Select Case codeResponse
            Case 2 ' UPDATE OK
            Case 4 ' CREATE OK
            Case 1 ' NOK
                CSDebug.dispError("SendWS - Code 1 : Erreur Base de données Serveur")
            Case 9 ' BADREQUEST
                CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
            Case 0 ' PAS DE MAJ
        End Select
        Return codeResponse
    End Function
#End Region
    Public Shared Function GetByuid(puid As Integer) As Pc
        Dim oReturn As Pc

        oReturn = getByKey(Of Pc)("Select * from AgentPC where uid = " & puid)
        Return oReturn
    End Function
    Public Shared Function Save(ByVal pObj As Pc, Optional bSynchro As Boolean = False) As Boolean

        Dim bReturn As Boolean

        Try
            bReturn = False
            create("AgentPC", pObj.uid)


            Dim paramsQuery As String
            paramsQuery = ""

            ' Mise a jour de la date de derniere modification
            If Not bSynchro Then
                pObj.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            paramsQuery = paramsQuery & " idPC='" & pObj.idPC & "'"
            paramsQuery = paramsQuery & ",libelle='" & pObj.libelle & "'"
            paramsQuery = paramsQuery & ",etat=" & pObj.etat
            paramsQuery = paramsQuery & ",AgentSuppression='" & pObj.agentSuppression & "'"
            paramsQuery = paramsQuery & ",RaisonSuppression='" & pObj.raisonSuppression & "'"
            paramsQuery = paramsQuery & ",dateSuppression='" & CSDate.ToCRODIPString(pObj.dateSuppression) & "'"
            paramsQuery = paramsQuery & ",isSupprime=" & pObj.isSupprime
            paramsQuery = paramsQuery & ",uidstructure=" & pObj.uidstructure
            paramsQuery = paramsQuery & ",idRegistre='" & pObj.idRegistre & "'"
            paramsQuery = paramsQuery & ",cleUtilisation='" & pObj.cleUtilisation & "'"
            paramsQuery = paramsQuery & ",marque='" & pObj.marque & "'"
            paramsQuery = paramsQuery & ",modele='" & pObj.modele & "'"
            paramsQuery = paramsQuery & ",systeme='" & pObj.systeme & "'"
            paramsQuery = paramsQuery & ",memoire='" & pObj.memoire & "'"
            paramsQuery = paramsQuery & ",disque='" & pObj.disque & "'"
            paramsQuery = paramsQuery & ",memo='" & pObj.memo & "'"
            paramsQuery = paramsQuery & ",owc_etat='" & pObj.owc_etat & "'"
            paramsQuery = paramsQuery & ",owc_folder='" & pObj.owc_folder & "'"
            paramsQuery = paramsQuery & ",owc_commun='" & pObj.owc_commun & "'"
            paramsQuery = paramsQuery & ",owc_parametres='" & pObj.owc_parametres & "'"
            paramsQuery = paramsQuery & ",owc_organismes='" & pObj.owc_organismes & "'"
            paramsQuery = paramsQuery & ",owc_user='" & pObj.owc_user & "'"
            paramsQuery = paramsQuery & ",owc_password='" & pObj.owc_password & "'"
            paramsQuery = paramsQuery & ",owc_version='" & pObj.owc_version & "'"
            paramsQuery = paramsQuery & ",isSecours='" & pObj.isSecours & "'"
            paramsQuery = paramsQuery & ",SignatureElect='" & pObj.signatureElect & "'"
            paramsQuery = paramsQuery & ",isSignElecActive='" & pObj.isSignElecActive & "'"
            paramsQuery = paramsQuery & ",modeSignature='" & pObj.modeSignature & "'"
            paramsQuery = paramsQuery & ",versionLogiciel='" & pObj.versionLogiciel & "'"
            paramsQuery = paramsQuery & ",isReinitialisationMode='" & pObj.isReinitialisationMode & "'"
            paramsQuery = paramsQuery & ",isMasterMode='" & pObj.isMasterMode & "'"
            paramsQuery = paramsQuery & ",isDownloadMetrologieMode='" & pObj.isDownloadMetrologieMode & "'"
            paramsQuery = paramsQuery & ",isDownloadTarificationMode='" & pObj.isDownloadTarificationMode & "'"
            paramsQuery = paramsQuery & ",isDownloadPulveExploitationMode='" & pObj.isDownloadPulveExploitationMode & "'"
            paramsQuery = paramsQuery & ",isDownloadIdentifiantPulveMode='" & pObj.isDownloadIdentifiantPulve & "'"


            bReturn = Update("AgentPC", pObj, paramsQuery)
        Catch ex As Exception
            CSDebug.dispFatal("PCManager.save ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function



#Region "Methodes Web Service"


#Region " - Suppression - "
    ''' <summary>
    ''' Marque la Pc comme étant utilisée
    ''' </summary>
    ''' <param name="objPc"></param>
    ''' <remarks></remarks>
    Public Shared Sub setUtilise(ByVal objPc As Pc)
        Try
            If Not PcManager.isUsedPc(objPc.numeroNational) Then
                ' On met a jour en base
                Dim query As String = "UPDATE AgentPc SET AgentPc.dateModificationAgent='" & Date.Now.ToString & "' , AgentPc.isUtilise=" & True & " WHERE AgentPc.numeroNational='" & objPc.numeroNational & "'"
                Dim bdd As New CSDb(True)
                bdd.Execute(query)
                bdd.free()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("PcManager.setUtilise() : " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Rend vrai si la Pc est utilisée
    ''' </summary>
    ''' <param name="Pc_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function isUsedPc(ByVal Pc_id As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim query As String = "SELECT * FROM AgentPc WHERE AgentPc.isUtilise=" & False & " AND AgentPc.numeroNational='" & Pc_id & "'"
            Dim bdd As New CSDb(True)
            Dim dataResults As DbDataReader = bdd.getResult2s(query)
            bReturn = dataResults.HasRows
            dataResults.Close()
            bdd.free()

        Catch ex As Exception
            CSDebug.dispError("PcManager.isUsedPc() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Marque la Pc comme étant supprimée
    ''' </summary>
    ''' <param name="Pc_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SupprimerPc(ByVal Pc_id As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(Pc_id), "L'id doit être renseigné")
        Dim bReturn As Boolean
        Try
            If Not isUsedPc(Pc_id) Then
                Dim query As String = "UPDATE AgentPc SET AgentPc.dateModificationAgent='" & Date.Now.ToString & "' , AgentPc.isSupprime=" & True & " WHERE AgentPc.numeroNational='" & Pc_id & "'"
                Dim bdd As New CSDb(True)
                bdd.Execute(query)
                bdd.free()
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispFatal("PcManager.deletePc() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region
    ''' <summary>
    ''' Création d'un enr Pc avec son Id
    ''' </summary>
    ''' <param name="Pc_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function createPc(ByVal Pc_id As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(Pc_id), "l'Id doit être renseignée")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentPc (idCrodip, aid) VALUES ('" & Pc_id & "','" & Pc_id & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True

        Catch ex As Exception
            CSDebug.dispFatal("PcManager - createPc ERR : " & ex.Message)
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
                bddCommande.CommandText = "SELECT * FROM AgentPc WHERE idStructure=" & pIdStructure & " AND isSupprime<>0 ORDER BY dateSuppression DESC"
                oDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oPc As New Pc
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDataReader.FieldCount()
                        If Not oDataReader.IsDBNull(tmpColId) Then
                            oPc.Fill(oDataReader.GetName(tmpColId), oDataReader.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    colReturn.Add(oPc)

                End While
            End If
        Catch ex As Exception
            CSDebug.dispError("PcManager.GetMaterielSupprimes Error" & ex.Message)

        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If
        Return colReturn
    End Function

    Public Shared Function getUpdates(ByVal agent As Agent) As Pc()
        ' déclarations
        Dim arrItems(0) As Pc
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentPc WHERE (dateModificationAgent>dateModificationCrodip or dateModificationCrodip is null) AND idStructure=" & agent.uidstructure

            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpPc As New Pc
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpPc.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpPc
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("Erreur - PcManager - getResult : " & ex.Message)
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
