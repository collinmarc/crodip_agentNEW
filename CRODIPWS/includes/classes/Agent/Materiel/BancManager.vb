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

    '        ' d�clarations
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
    '                CSDebug.dispError("Erreur - BancManager - Code 1 : Non-Trouv�e (" & banc_id & ")")
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
    ''' Cette m�thode n'est plus utilis�e depuis la 2.5.4.3 , car les mat�riels sont cr��s sur le Serveur 
    Public Shared Function FTO_getNewId(ByVal pAgent As Agent) As String
        ' d�clarations
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand

        Dim tmpObjectId As String = pAgent.uidStructure & "-" & pAgent.id & "-1"
        If pAgent.uidStructure <> 0 Then
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT BancMesure.id FROM BancMesure WHERE BancMesure.id LIKE '" & pAgent.uidStructure & "-" & pAgent.id & "-%' ORDER BY BancMesure.id DESC"
            Try
                ' On r�cup�re les r�sultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On r�cup�re le dernier ID
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
        Debug.Assert(Not String.IsNullOrEmpty(objBanc.id), "L'Id doit �tre inititialis�")
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
                    ' Si il n'existe pas, on le cr�e
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
            Dim newDate As String = CSDate.ToCRODIPString(Date.Now)
            dbLink.queryString = "UPDATE BancMesure SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objBanc.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("BancManager::setSynchro : " & ex.Message)
        End Try
    End Sub


    Public Shared Function getBancById(ByVal banc_id As String) As Banc
        Debug.Assert(Not String.IsNullOrEmpty(banc_id), "L'Id doit �tre non null")
        ' d�clarations
        Dim tmpBanc As New Banc
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As DbCommand
        bddCommande = oCSdb.getConnection().CreateCommand()

        bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.id='" & banc_id & "'"
        Try
            ' On r�cup�re les r�sultats
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

        'on retourne le banc ou un objet vide en cas d'erreur
        Return tmpBanc
    End Function
    Public Shared Function getBancByuId(ByVal puid As String) As Banc
        Debug.Assert(Not String.IsNullOrEmpty(puid), "L'Id doit �tre non null")
        Dim oReturn As Banc
        Dim sql As String
        sql = "SELECT * FROM BancMesure WHERE BancMesure.uid=" & puid & ""
        oReturn = getBySQL(Of Banc)(sql)

        'on retourne le banc ou un objet vide en cas d'erreur
        Return oReturn
    End Function
#End Region
    '''
    ''' Marque l'utilisation du banc (Flag isUtilis�, date de dernier controle, cr�ation de la fiche de vie)
    '''
#Region " - Suppression - "
    '''
    ''' cr�ation d'un enregistrement bancMesure
    ''' L'ID doit �re initialis�
    '''
    Private Shared Function createBanc(ByVal pBancID As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pBancID))
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Cr�ation
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
        ' d�clarations
        Dim arrItems(0) As Banc
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM BancMesure WHERE (BancMesure.dateModificationAgent<>BancMesure.dateModificationCrodip or dateModificationCrodip is null) AND BancMesure.idStructure=" & agent.uidStructure

        Try
            ' On r�cup�re les r�sultats
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
        Debug.Assert(Not String.IsNullOrEmpty(pBancId), " le param�tre ID doit �tre initialis�")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM BancMesure WHERE BancMesure.id='" & pBancId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprim�e")
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
    ''' Rend une collection des mat�riels supprim�s appartenant � la structure
    ''' </summary>
    ''' <param name="pIdStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getMaterielsSupprimes(ByVal pIdStructure As String) As Collection
        Debug.Assert(Not String.IsNullOrEmpty(pIdStructure), "L'Id Structre doit �tre initialis�")
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
        Debug.Assert(Not pAgent Is Nothing, "L'agent Doit �tre renseign�")
        Dim lstReturn As New List(Of Banc)
        If pAgent.oPool IsNot Nothing Then
            Dim obanc As Banc = Nothing
            obanc = BancManager.getBancByuId(pAgent.oPool.uidbanc)
            If obanc IsNot Nothing Then
                lstReturn.Add(obanc)
            End If
        Else
            lstReturn = BancManager.getBancByStructureId(pAgent.uidstructure, isShowAll)
        End If
        Return lstReturn
    End Function

    '''
    ''' R�cup�ration des bancs de la structure isSupprim�=False, JamaisServi = false
    ''' isShowall = TRUE => on ne regarde pas l'�tat, False seuls les bancs Etat = True sont retourn�s
    '''
    Public Shared Function getBancByStructureId(ByVal pIdStructure As String, Optional ByVal isShowAll As Boolean = False) As List(Of Banc)
        Dim lstBanc As New List(Of Banc)
        Dim oCsDB As New CSDb(True)
        If pIdStructure <> "" Then

            Dim bddCommande As DbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est d�j� ouverte ou non
            If isShowAll Then
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " "
            Else
                bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & False & " AND BancMesure.etat=" & True & ""
            End If
            Try

                ' On r�cup�re les r�sultats
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
    ''' R�cup�ration des bancs de la structure isSupprim�=False, JamaisServi = false
    ''' isShowall = TRUE => on ne regarde pas l'�tat, False seuls les bancs Etat = True sont retourn�s
    '''
    Public Shared Function getBancByStructureIdJamaisServi(ByVal pIdStructure As String) As List(Of Banc)
        Dim lstBanc As New List(Of Banc)
        Dim oCsDB As New CSDb(True)
        If pIdStructure <> "" Then

            Dim bddCommande As DbCommand = oCsDB.getConnection().CreateCommand()
            ' On test si la connexion est d�j� ouverte ou non
            bddCommande.CommandText = "SELECT * FROM BancMesure WHERE BancMesure.idStructure=" & pIdStructure & " AND BancMesure.isSupprime=" & False & " AND BancMesure.JamaisServi=" & True & " "
            Try

                ' On r�cup�re les r�sultats
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
End Class
