Imports System.Collections.Generic
Imports System.Data.Common

Public Class ManometreEtalonManager

#Region "Methodes Web Service"

    Public Shared Function getWSManometreEtalonById(pAgent As Agent, ByVal manometreetalon_id As String) As ManometreEtalon
        Dim objManometreEtalon As New ManometreEtalon
        Try

            ' d�clarations
            Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetManometreEtalon(pAgent.id, manometreetalon_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If (objWSCrodip_responseItem.InnerText() <> "") Then
                            objManometreEtalon.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If

                    Next
                Case 1 ' NOK
                    CSDebug.dispError("ManometreEtalonManager - Code 1 : Non-Trouv�e")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("ManometreEtalonManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("ManometreEtalonManager - getWSManometreEtalonById : " & ex.Message)
        End Try
        Return objManometreEtalon

    End Function

    Public Shared Function sendWSManometreEtalon(pAgent As Agent, ByVal manometreetalon As ManometreEtalon) As Integer
        Try
            Dim updatedObject As New Object
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
            Return objWSCrodip.SendManometreEtalon(pAgent.id, manometreetalon, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As ManometreEtalon
        Dim objManometreEtalon As New ManometreEtalon

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If Not String.IsNullOrEmpty(tmpSerializeItem.InnerText) Then
                objManometreEtalon.Fill(tmpSerializeItem.LocalName(), tmpSerializeItem.InnerText)
            End If
        Next

        Return objManometreEtalon
    End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function getNewNumeroNationalForTestOnly(ByVal pAgent As Agent) As String
        ' d�clarations
        Dim tmpObjectId As String = pAgent.idStructure & "-" & pAgent.id & "-1"
        If pAgent.idStructure <> 0 Then

            Dim bddCommande As DbCommand
            Dim oCSDB As New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT AgentManoEtalon.numeroNational FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational LIKE '" & pAgent.idStructure & "-" & pAgent.id & "-%' ORDER BY AgentManoEtalon.numeroNational DESC"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On r�cup�re le dernier ID
                    Dim tmpId As Integer = 0
                    tmpObjectId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpObjectId.Replace(pAgent.idStructure & "-" & pAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpObjectId = pAgent.idStructure & "-" & pAgent.id & "-" & (newId + 1)
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
                Dim existsObject As Object
                existsObject = ManometreEtalonManager.getManometreEtalonByNumeroNational(objManometreEtalon.numeroNational)
                If existsObject.numeroNational = "" Or existsObject.numeroNational = "0" Then
                    ' Si il n'existe pas, on le cr�e
                    createManometreEtalon(objManometreEtalon.numeroNational)
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
                paramsQuery = paramsQuery & " , idStructure=" & objManometreEtalon.idStructure & ""
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
                If Not String.IsNullOrEmpty(objManometreEtalon.dateModificationAgent) Then
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(objManometreEtalon.dateModificationAgent) & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreEtalon.dateModificationCrodip) Then
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(objManometreEtalon.dateModificationCrodip) & "'"
                End If
                paramsQuery = paramsQuery & " , etat=" & objManometreEtalon.etat & ""
                paramsQuery = paramsQuery & " , isUtilise=" & objManometreEtalon.isUtilise & ""
                paramsQuery = paramsQuery & " , isSupprime=" & objManometreEtalon.isSupprime & ""
                paramsQuery = paramsQuery & " , nbControles=" & objManometreEtalon.nbControles & ""
                paramsQuery = paramsQuery & " , nbControlesTotal=" & objManometreEtalon.nbControlesTotal & ""

                If Not objManometreEtalon.AgentSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , agentSuppression='" & objManometreEtalon.AgentSuppression & "'"
                End If
                If Not objManometreEtalon.RaisonSuppression Is Nothing Then
                    paramsQuery = paramsQuery & " , raisonSuppression='" & objManometreEtalon.RaisonSuppression & "'"
                End If
                If Not String.IsNullOrEmpty(objManometreEtalon.DateSuppression) Then
                    paramsQuery = paramsQuery & " , dateSuppression='" & CSDate.ToCRODIPString(objManometreEtalon.DateSuppression) & "'"
                End If
                paramsQuery = paramsQuery & " , jamaisServi=" & objManometreEtalon.JamaisServi & ""
                If objManometreEtalon.DateActivation <> Nothing Then
                    paramsQuery = paramsQuery & " , dateActivation='" & CSDate.ToCRODIPString(objManometreEtalon.DateActivation) & "'"
                End If
                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentManoEtalon SET " & paramsQuery & " WHERE numeroNational='" & objManometreEtalon.numeroNational & "'"
                bddCommande.ExecuteNonQuery()
                'Suppression des Pools avant insertion
                clearlstPoolByManoE(objManometreEtalon.numeroNational)
                'Insertion des Pools
                objManometreEtalon.lstPools.ForEach(Sub(p)
                                                        insertPoolManoE(p.idCrodip, objManometreEtalon.numeroNational)
                                                    End Sub)

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
            Dim newDate As String = Date.Now.ToString
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
        ' d�clarations
        Dim tmpManometreEtalon As New ManometreEtalon
        Dim oCsdb As CSDb = Nothing
        If pNumeroNational <> "" Then
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational='" & pNumeroNational & "'"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpManometreEtalon.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
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

    Public Shared Function getManometreEtalonByStructureId(ByVal pidStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreEtalon)
        Debug.Assert(Not String.IsNullOrEmpty(pidStructure), "L'Id doit �tre renseign�")
        ' d�clarations
        Dim tmpManometreEtalon As ManometreEtalon
        Dim lstManometreEtalon As New List(Of ManometreEtalon)
        Dim oCsdb As CSDb = Nothing
        oCsdb = New CSDb(True)
        Dim bddCommande As DbCommand
        bddCommande = oCsdb.getConnection().CreateCommand()
        If isShowAll Then
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE idStructure=" & pidStructure & " AND isSupprime=" & False
        Else
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE idStructure=" & pidStructure & " AND isSupprime=" & False & " AND etat=" & True & " And JamaisServi = " & False & ""
        End If
        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                tmpManometreEtalon = New ManometreEtalon()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpManometreEtalon.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                lstManometreEtalon.Add(tmpManometreEtalon)
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

        'on retourne le manometreetalon ou un objet vide en cas d'erreur
        Return lstManometreEtalon
    End Function

    Public Shared Function getManometreEtalonByStructureIdJamaisServi(ByVal pidStructure As String) As List(Of ManometreEtalon)
        Debug.Assert(Not String.IsNullOrEmpty(pidStructure), "L'Id doit �tre renseign�")
        ' d�clarations
        Dim tmpManometreEtalon As ManometreEtalon
        Dim lstManometreEtalon As New List(Of ManometreEtalon)
        Dim oCsdb As CSDb = Nothing
        oCsdb = New CSDb(True)
        Dim bddCommande As DbCommand
        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE idStructure=" & pidStructure & " AND  jamaisServi = " & True & ""
        Try
            ' On r�cup�re les r�sultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                tmpManometreEtalon = New ManometreEtalon()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpManometreEtalon.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                lstManometreEtalon.Add(tmpManometreEtalon)
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

        'on retourne le manometreetalon ou un objet vide en cas d'erreur
        Return lstManometreEtalon
    End Function

    ''' <summary>
    ''' Rend une collection des mat�riels supprim�s appartenant � la structure
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
                bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE idStructure=" & pIdStructure & " AND isSupprime=" & True & " ORDER BY dateSuppression DESC"
                oDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim i As Integer = 0
                While oDataReader.Read()

                    ' On remplit notre tableau
                    Dim oMano As New ManometreEtalon
                    Dim tmpColId As Integer = 0
                    While tmpColId < oDataReader.FieldCount()
                        If Not oDataReader.IsDBNull(tmpColId) Then
                            oMano.Fill(oDataReader.GetName(tmpColId), oDataReader.GetValue(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
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
        Debug.Assert(Not String.IsNullOrEmpty(pNumeroNational), " le param�tre pNumeroNational doit �tre initialis�")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM AgentManoEtalon WHERE AgentManoEtalon.numeroNational='" & pNumeroNational & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprim�e")
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

    Private Shared Function createManometreEtalon(ByVal manometreetalon_id As String) As Boolean
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Try
            Dim bddCommande As DbCommand
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Cr�ation
            bddCommande.CommandText = "INSERT INTO AgentManoEtalon (numeroNational) VALUES ('" & manometreetalon_id & "')"
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
        ' d�clarations
        Dim arrItems(0) As ManometreEtalon
        Dim oCsdb As CSDb = Nothing
        Try
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM AgentManoEtalon WHERE (AgentManoEtalon.dateModificationAgent<>AgentManoEtalon.dateModificationCrodip or dateModificationCrodip is null) AND AgentManoEtalon.idStructure=" & agent.idStructure

            ' On r�cup�re les r�sultats
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
    Public Shared Function getManometreEtalonByAgent(ByVal pAgent As Agent, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreEtalon)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit �tre renseign�")
        Dim arrResponse As New List(Of ManometreEtalon)
        If Not My.Settings.GestiondesPools Then
            arrResponse = getManometreEtalonByStructureId(pAgent.idStructure, isShowAll)
        Else
            arrResponse = getManoEtalonByPoolId(pAgent.idCRODIPPool, isShowAll)
            'Charegement de la Liste des pools du mano
            arrResponse.ForEach(Sub(M)
                                    M.lstPools.AddRange(getlstPoolByManoE(M.numeroNational))
                                End Sub)
        End If
        Return arrResponse
    End Function
    Public Shared Function getManometreEtalonByAgentJamaisServi(ByVal pAgent As Agent, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreEtalon)
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit �tre renseign�")
        Dim arrResponse As New List(Of ManometreEtalon)
        If Not My.Settings.GestiondesPools Then
            arrResponse = getManometreEtalonByStructureIdJamaisServi(pAgent.idStructure)
        Else
            arrResponse = getManoEtalonByPoolIdJamaisServi(pAgent.idCRODIPPool)
            'Charegement de la Liste des pools du mano
            arrResponse.ForEach(Sub(M)
                                    M.lstPools.AddRange(getlstPoolByManoE(M.numeroNational))
                                End Sub)
        End If
        Return arrResponse
    End Function
    Private Shared Function getManoEtalonByPoolId(ByVal pIdCrodipPool As String, Optional ByVal isShowAll As Boolean = False) As List(Of ManometreEtalon)
        Debug.Assert(Not String.IsNullOrEmpty(pIdCrodipPool), "L'IDPool doit �tre renseign�")
        Dim arrResponse As New List(Of ManometreEtalon)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoEtalon , PoolManoE WHERE AgentManoEtalon.numeronational = PoolManoE.numeronationalManoE AND PoolManoE.idCRODIPPool = '" & pIdCrodipPool & "' AND AgentManoEtalon.isSupprime=" & False & " And AgentManoEtalon.jamaisServi = " & False & ""
        If Not isShowAll Then
            bddCommande.CommandText = bddCommande.CommandText & " AND AgentManoEtalon.etat=" & True
        End If
        bddCommande.CommandText = bddCommande.CommandText & " ORDER BY AgentManoEtalon.idCrodip"

        Try
            ' On r�cup�re les r�sultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oMano As New ManometreEtalon
                If oMano.FillDR(oDataReader) Then
                    arrResponse.Add(oMano)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoEtalonManager.getManoControle : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return arrResponse
    End Function
    Private Shared Function getManoEtalonByPoolIdJamaisServi(ByVal pIdCrodipPool As String) As List(Of ManometreEtalon)
        Debug.Assert(Not String.IsNullOrEmpty(pIdCrodipPool), "L'IDPool doit �tre renseign�")
        Dim arrResponse As New List(Of ManometreEtalon)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM AgentManoEtalon , PoolManoE WHERE AgentManoEtalon.numeronational = PoolManoE.numeronationalManoE AND PoolManoE.idPool = '" & pIdCrodipPool & "' AND AgentManoEtalon.isSupprime=" & False & " And AgentManoEtalon.jamaisServi = " & True & ""
        bddCommande.CommandText = bddCommande.CommandText & " ORDER BY AgentManoEtalon.idCrodip"

        Try
            ' On r�cup�re les r�sultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit notre tableau
                Dim oMano As New ManometreEtalon
                If oMano.FillDR(oDataReader) Then
                    arrResponse.Add(oMano)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoEtalonManager.getManoEtalonByPoolIdJamaisServi : ", ex)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return arrResponse
    End Function
    ''' <summary>
    ''' Charegement de la liste de Pool d'un Mano 
    ''' </summary>
    ''' <param name="pnumeronationalManoE"></param>
    ''' <returns></returns>
    Private Shared Function getlstPoolByManoE(pnumeronationalManoE As String) As List(Of Pool)

        Dim oreturn As New List(Of Pool)

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT Pool.* FROM Pool , PoolManoE WHERE Pool.idCrodip = PoolManoE.idCRODIPPool AND PoolManoE.numeronationalManoE = '" & pnumeronationalManoE & "'"

        Try
            ' On r�cup�re les r�sultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            Dim i As Integer = 0
            While oDataReader.Read()

                ' On remplit le Pool
                Dim oPool As New Pool
                If oPool.FillDR(oDataReader) Then
                    'et on l'ajoute � la collection
                    oreturn.Add(oPool)
                End If
            End While
            oDataReader.Close()
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManometreEtalonManager.getlstPoolByManoE : " & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        Return oreturn
    End Function

    Private Shared Function clearlstPoolByManoE(numeronationalManoE As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "DELETE FROM PoolManoE WHERE  PoolManoE.numeronationalManoE = '" & numeronationalManoE & "'"

        Try
            ' On r�cup�re les r�sultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoEtalonManager.clearlstPoolByManoE : " & ex.Message)
            oreturn = False
        End Try


        Return oreturn
    End Function
    Private Shared Function insertPoolManoE(pIdPool As String, pnumeronationalManoE As String) As Boolean

        Dim oreturn As Boolean

        Dim oCsdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "insert into PoolManoE (idCRODIPPool, numeronationalManoE) vAlues ( '" & pIdPool & "','" & pnumeronationalManoE & "')"

        Try
            ' On r�cup�re les r�sultats
            bddCommande.ExecuteNonQuery()
            oCsdb.free()
            oreturn = True
        Catch ex As Exception
            ' On catch l'erreur
            CSDebug.dispError("ManoEtalonManager.addPoolManoE : ", ex)
            oreturn = False
        End Try


        Return oreturn
    End Function

    Public Shared Function getLstPoolById(pItem As ManometreEtalon) As Boolean

        ' d�clarations
        Dim bReturn As Boolean = False
        Dim objWSCrodip As WSCrodip.CrodipServer = WebServiceCRODIP.getWS()
        Dim objWSCrodip_response As New Object
        Debug.Assert("FONCTION ManometreEtalonManager.getlstPoolByID Non impl�ment�e")
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
        '        CSDebug.dispError("Erreur - BuseManager - Code 1 : Non-Trouv�e")
        '    Case 9 ' BADREQUEST
        '        CSDebug.dispError("Erreur - BuseManager - Code 9 : Bad Request")
        'End Select


        Return bReturn
    End Function
End Class
