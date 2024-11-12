Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>

Public Class DiagnosticItemManager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0


#Region "Methodes acces Web Service"
    Public Shared Function WSGetList(puidDiag As Integer, paidDiag As String) As DiagnosticItemList
        Dim oreturn As New DiagnosticItemList
        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Try
            Dim tXmlnodes As Object()
            Dim objWSCrodip_response() As Object = Nothing
            '' déclarations
            Dim codeResponse As Integer = 99 'Mehode non trouvée
            codeResponse = objWSCrodip.GetDiagnosticItems(puidDiag, paidDiag, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK

                    Dim oDiagItem As DiagnosticItem
                    For Each oNode In objWSCrodip_response
                        ' construction de l'objet
                        Dim objWSCrodip_responseItem1 As System.Xml.XmlNode()
                        Dim objWSCrodip_responseItem As System.Xml.XmlNode
                        For Each objWSCrodip_responseItem1 In objWSCrodip_response
                            oDiagItem = New DiagnosticItem()
                            For Each objWSCrodip_responseItem In objWSCrodip_responseItem1
                                oDiagItem.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                            Next
                            'spécifique au diagItem car c'est un dictionnaire
                            oreturn.AddOrReplace(oDiagItem)
                        Next
                    Next

                Case 1 ' NOK
                    CSDebug.dispError("getWSByKey - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("getWSByKey - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("RootManager - getWSbyKey : ", ex)
        Finally
        End Try
        Return oreturn


    End Function

    '''
    ''' Récupération des diagnosicItems par Id de diag
    ''' Le WS rend une collection qui est ajoutée au diagnistic courant
    'Public Shared Function getWSDiagnosticItemsByDiagnosticId(ByVal pAgent As Agent, ByVal diagnostic_id As String) As Diagnostic
    '    Debug.Assert(pAgent IsNot Nothing)
    '    Debug.Assert(Not String.IsNullOrEmpty(pAgent.id))
    '    Debug.Assert(Not String.IsNullOrEmpty(diagnostic_id))

    '    Dim objDiagnosticItem As DiagnosticItem
    '    Dim objWSCrodip As WSCRODIP.CrodipServer
    '    Dim objWSCrodip_response() As Object = Nothing
    '    Dim oDiag As Diagnostic = Nothing
    '    '        Dim oLst As List(Of DiagnosticItem)
    '    Try

    '        ' déclarations
    '        objWSCrodip = WebServiceCRODIP.getWS()
    '        oDiag = DiagnosticManager.getDiagnosticById(diagnostic_id)
    '        If oDiag.id = diagnostic_id Then
    '            'Création de la liste temporaire
    '            '               oLst = New List(Of DiagnosticItem)
    '            ' Appel au WS
    '            Dim objWSCrodip_responseItem As System.Xml.XmlNode
    '            Dim objWSCrodip_responseItem2 As System.Xml.XmlNode()
    '            Dim codeResponse As Integer = objWSCrodip.GetDiagnosticItems(pAgent.id, diagnostic_id, objWSCrodip_response)
    '            Select Case codeResponse
    '                Case 0 ' OK
    '                    'Parcours de la collection des DiagItem
    '                    For Each objWSCrodip_responseItem2 In objWSCrodip_response
    '                        'Création du DiagItem
    '                        objDiagnosticItem = New DiagnosticItem()
    '                        For Each objWSCrodip_responseItem In objWSCrodip_responseItem2
    '                            'Initialisation du diag
    '                            objDiagnosticItem.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
    '                        Next
    '                        'Ajout dans la collection temporaire
    '                        oDiag.AdOrReplaceDiagItem(objDiagnosticItem)
    '                    Next
    '                Case 1 ' NOK
    '                    'CSDebug.dispError("DiagnosticItemManager - Code 1 : Non-Trouvée")
    '                Case 9 ' BADREQUEST
    '                    'CSDebug.dispError("DiagnosticItemManager - Code 9 : Bad Request")
    '            End Select
    '        End If
    '    Catch ex As Exception
    '        CSDebug.dispError("DiagnosticItemManager - getWSDiagnosticItemById : " & ex.Message)
    '    End Try
    '    Return oDiag

    'End Function

    Public Shared Function WSSend(pAgent As Agent, ByVal objDiagnosticItems As DiagnosticItemList) As Integer
        Dim tmpArr(1)() As DiagnosticItem
        tmpArr(0) = objDiagnosticItems.items
        Dim CodeResponse As Integer
        Try

            ' Appel au WS
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim pinfos As String = ""
            CodeResponse = objWSCrodip.SendDiagnosticItems(tmpArr, pinfos)
            Select Case CodeResponse
                Case 0, 2, 4 ' OK

                Case -1 ' Appel incortect
                    CSDebug.dispError("WSSend - Code -1 : Appel incorrect")
                Case 1 ' NOK
                    CSDebug.dispError("WSSend - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("WSSend - Code 9 : Bad Request")
            End Select

        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager.sendWSDiagnosticItem ERR", ex)
            CodeResponse = -1
        End Try
        Return CodeResponse
    End Function


#End Region

#Region "Methodes acces Local"


    Public Shared Function getDiagnosticItemByDiagnosticId(oCSDB As CSDb, pDiagnostic As Diagnostic) As Boolean
        ' On récupère les items du diagnostic
        Dim bReturn As Boolean
        Dim bddCommande2 As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            ' récupération du fichier de config associé au Pulvé
            Dim oPulve As Pulverisateur
            oPulve = PulverisateurManager.getPulverisateurById(pDiagnostic.pulverisateurId)
            Dim sFichierConfig As String = oPulve.getParamDiag().fichierConfig
            '' Chargement de la liste des Défauts pour ce Type de pulvé
            Dim olst As New CRODIP_ControlLibrary.LstParamCtrlDiag()
            olst.readXML(My.Settings.RepertoireParametres & "/" & sFichierConfig)

            bddCommande2.CommandText = "SELECT * FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' AND  DiagnosticItem.idItem <> '" & DiagnosticInfosComplementaires.DIAGITEM_ID & "' AND DiagnosticItem.idItem not Like 'h%' And ItemCodeEtat <> 'B' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande2.ExecuteReader
            ' Puis on les parcours
            Dim nColId As Integer
            While oDRDiagnosticItem.Read()
                Dim oDiagnosticItem As New DiagnosticItem
                ' On rempli notre tableau
                nColId = 0
                While nColId < oDRDiagnosticItem.FieldCount()
                    If Not oDRDiagnosticItem.IsDBNull(nColId) Then
                        oDiagnosticItem.Fill(oDRDiagnosticItem.GetName(nColId), oDRDiagnosticItem.Item(nColId))
                    End If
                    nColId = nColId + 1
                End While
                'Les libellés n'étant pas strocké en BDD, on les récupère dans le fichier de config
                Dim oParamctrlDiag As CRODIP_ControlLibrary.ParamCtrlDiag = olst.FindDiagItem(oDiagnosticItem.getItemCode())
                If oParamctrlDiag IsNot Nothing Then
                    oDiagnosticItem.LibelleCourt = oParamctrlDiag.Libelle
                    oDiagnosticItem.LibelleLong = oParamctrlDiag.LibelleLong
                End If
                'Transformation du code du DiagItem 2319 en 2310 pour le Lot3
                If oDiagnosticItem.idItem = 231 And oDiagnosticItem.itemValue = 9 And oDiagnosticItem.itemCodeEtat = "B" Then
                    oDiagnosticItem.itemValue = 0
                End If
                pDiagnostic.AdOrReplaceDiagItem(oDiagnosticItem)
            End While
            oDRDiagnosticItem.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager::getDiagnosticItemByDiagnosticId : " & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function
    Public Shared Function existsDiagnosticItemById(ByVal pCsdb As CSDb, ByVal diagnosticitem_id As String, ByVal pIdDiagnostic As String) As Boolean
        ' déclarations
        Dim tmpDiagnosticItem As New DiagnosticItem
        Dim bReturn As Boolean
        bReturn = False
        If diagnosticitem_id <> "" Then
            Dim nEnr As Integer
            Dim bddCommande As DbCommand
            bddCommande = pCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT count(*) FROM DiagnosticItem WHERE DiagnosticItem.id='" & diagnosticitem_id & "' AND idDiagnostic = '" & pIdDiagnostic & "'"
            Try
                ' On récupère les résultats
                nEnr = bddCommande.ExecuteScalar
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("DiagnosticItemManager.ExistsDiagnosticItem Error: " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            'If Not oCsdb Is Nothing Then
            '    ' On ferme la connexion
            '    oCsdb.free()
            'End If
            bReturn = (nEnr > 0)
        End If
        Return bReturn
    End Function
    Public Shared Function getDiagnosticItemById(ByVal diagnosticitem_id As String, ByVal pIdDiagnostic As String) As DiagnosticItem
        ' déclarations
        Dim tmpDiagnosticItem As New DiagnosticItem
        If diagnosticitem_id <> "" Then
            Dim oCsdb As CSDb = Nothing
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT * FROM DiagnosticItem WHERE DiagnosticItem.id='" & diagnosticitem_id & "' AND idDiagnostic = '" & pIdDiagnostic & "'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpDiagnosticItem.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1

                    End While
                End While
                tmpListProfils.Close()
            Catch ex As Exception ' On intercepte l'erreur
                MsgBox("DiagnosticItemManager Error: " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        'on retourne le diagnosticitem ou un objet vide en cas d'erreur
        Return tmpDiagnosticItem
    End Function
    Public Shared Function incId(pOldId As String) As String
        Dim tmpId As String()
        Dim newId As String
        Dim nId As Integer
        tmpId = pOldId.Split("-")
        Try
            If String.IsNullOrEmpty(tmpId(2)) Then
                nId = 0
            Else
                nId = CInt(tmpId(2))
            End If
        Catch ex As Exception
            nId = 0
        End Try
        newId = tmpId(0) & "-" & tmpId(1) & "-" & (nId + 1).ToString()
        Return newId
    End Function

    Public Shared Function getNewId(ByVal structure_id As String, Agent_id As String) As String
        ' déclarations
        Dim tmpDiagnosticId As String = structure_id & "-" & Agent_id & "-"
        If structure_id <> "" And structure_id <> "0" Then
            Dim oCsdb As New CSDb(True)
            Dim bddCommande As DbCommand
            Dim newId As Integer = 0
            Dim strDiagItemId As String
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT DiagnosticItem.id as N FROM DiagnosticItem WHERE idDiagnostic LIKE '" & tmpDiagnosticId & "%'"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                'On est obligé de les parcourir car c'est une clé alpha num !!!!!
                While tmpListProfils.Read()
                    strDiagItemId = tmpListProfils.GetString(0)
                    strDiagItemId = strDiagItemId.Replace(tmpDiagnosticId, "")
                    If Not String.IsNullOrEmpty(strDiagItemId) And IsNumeric(strDiagItemId) Then
                        If CInt(strDiagItemId) > newId Then
                            newId = CInt(strDiagItemId)
                        End If
                    End If
                End While
                tmpListProfils.Close()

            Catch ex As Exception ' On intercepte l'erreur
                newId = 0
            End Try
            tmpDiagnosticId = structure_id & "-" & Agent_id & "-" & (newId + 1)

            ' Test pour fermeture de connection BDD
            oCsdb.free()

        End If
        'on retourne le nouvel id
        Return tmpDiagnosticId
    End Function
    '''
    ''' Sauvegarde d'un diagnosticItem individuel
    ''' Paramètres :
    Public Shared Function save(ByVal pCsDb As CSDb, ByVal pDiagIt As DiagnosticItem, Optional bSyncro As Boolean = False) As Boolean
        Debug.Assert(pCsDb.isOpen(), "La Connection Doit être ouverte")

        Dim breturn As Boolean
        Try
            breturn = False
            '            If pDiagIt.id <> "" Then


            ' On test si le DiagnosticItem existe ou non
            Dim existsDiagnosticItem As Boolean
            existsDiagnosticItem = DiagnosticItemManager.existsDiagnosticItemById(pCsDb, pDiagIt.id, pDiagIt.idDiagnostic)

            If Not existsDiagnosticItem Then
                ' Si il n'existe pas, on le crée
                create(pDiagIt)
            Else

                'Dim oCSDb As New CSDb(True)
                Dim bddCommande As DbCommand
                bddCommande = pCsDb.getConnection().CreateCommand

                ' Initialisation de la requete
                Dim paramsQuery As String = "id='" & pDiagIt.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSyncro Then
                    pDiagIt.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not pDiagIt.idDiagnostic Is Nothing And pDiagIt.idDiagnostic <> "" Then
                    paramsQuery = paramsQuery & " , idDiagnostic='" & CSDb.secureString(pDiagIt.idDiagnostic) & "'"
                End If
                If Not pDiagIt.idItem Is Nothing And pDiagIt.idItem <> "" Then
                    paramsQuery = paramsQuery & " , idItem='" & CSDb.secureString(pDiagIt.idItem) & "'"
                End If
                If Not pDiagIt.itemValue Is Nothing And pDiagIt.itemValue <> "" Then
                    paramsQuery = paramsQuery & " , itemValue='" & CSDb.secureString(pDiagIt.itemValue) & "'"
                End If
                If Not pDiagIt.itemCodeEtat Is Nothing And pDiagIt.itemCodeEtat <> "" Then
                    paramsQuery = paramsQuery & " , itemCodeEtat='" & CSDb.secureString(pDiagIt.itemCodeEtat) & "'"
                End If
                'paramsQuery = paramsQuery & " , isItemCode1=" & objisItemCode1 & ""
                'paramsQuery = paramsQuery & " , isItemCode2=" & objisItemCode2 & ""
                paramsQuery = paramsQuery & " , cause='" & pDiagIt.cause & "'"
                paramsQuery = paramsQuery & " , uiddiagnostic=" & pDiagIt.uiddiagnostic & ""
                paramsQuery = paramsQuery & " , aiddiagnostic='" & pDiagIt.aiddiagnostic & "'"
                paramsQuery = paramsQuery & pDiagIt.getRootQuery()

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE DiagnosticItem SET " & paramsQuery & " WHERE id='" & pDiagIt.id & "' and idDiagnostic = '" & pDiagIt.idDiagnostic & "'"
                bddCommande.ExecuteNonQuery()
                ' Test pour fermeture de connection BDD
                'If Not oCSDb Is Nothing Then
                ' On ferme la connexion
                ' oCSDb.free()
            End If
            'End If
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticItemManager" & pDiagIt.idDiagnostic & " - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    '''
    ''' Sauvegarde d'un diagnosticItem
    ''' Paramètres :
    ''' pbForceCreate : Ne controle pas l'existence préalable de l'élément , Force la création immédiatement (Gain de temps)
    Public Shared Function create(ByVal pDiagnosticItem As DiagnosticItem) As Boolean

        Dim breturn As Boolean
        Dim sDebugStep As String = "0"
        Dim oCSDb As New CSDb(True)
        Dim bddCommande As DbCommand
        Try
            breturn = False
            sDebugStep = "1"

            ' On test si le DiagnosticItem existe ou non

            bddCommande = oCSDb.getConnection().CreateCommand()
            sDebugStep = "2"

            Dim paramsQueryColomuns As String = ""
            Dim paramsQuery As String = ""
            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                paramsQueryColomuns = paramsQueryColomuns & "id , "
                paramsQuery = paramsQuery & "'" & pDiagnosticItem.id & " , '"
            End If


            sDebugStep = "3"
            ' Mise a jour de la date de derniere modification
            pDiagnosticItem.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

            If Not pDiagnosticItem.idDiagnostic Is Nothing And pDiagnosticItem.idDiagnostic <> "" Then
                paramsQueryColomuns = paramsQueryColomuns & "  idDiagnostic"
                paramsQuery = paramsQuery & " '" & pDiagnosticItem.idDiagnostic & "'"
            End If
            If Not pDiagnosticItem.idItem Is Nothing And pDiagnosticItem.idItem <> "" Then
                paramsQueryColomuns = paramsQueryColomuns & " , idItem"
                paramsQuery = paramsQuery & " , '" & pDiagnosticItem.idItem & "'"
            End If
            If Not pDiagnosticItem.itemValue Is Nothing And pDiagnosticItem.itemValue <> "" Then
                paramsQueryColomuns = paramsQueryColomuns & " , itemValue"
                paramsQuery = paramsQuery & " , '" & CSDb.secureString(pDiagnosticItem.itemValue) & "'"
            End If
            If Not pDiagnosticItem.itemCodeEtat Is Nothing And pDiagnosticItem.itemCodeEtat <> "" Then
                paramsQueryColomuns = paramsQueryColomuns & " , itemCodeEtat"
                paramsQuery = paramsQuery & " , '" & pDiagnosticItem.itemCodeEtat & "'"
            End If
            'paramsQueryColomuns = paramsQueryColomuns & " , isItemCode1"
            'paramsQuery = paramsQuery & " , " & objDiagnosticItem.isItemCode1 & ""
            'paramsQueryColomuns = paramsQueryColomuns & " , isItemCode2"
            'paramsQuery = paramsQuery & " , " & objDiagnosticItem.isItemCode2 & ""
            paramsQueryColomuns = paramsQueryColomuns & " , cause"
            paramsQuery = paramsQuery & " , '" & pDiagnosticItem.cause & "'"

            If Not String.IsNullOrEmpty(pDiagnosticItem.dateModificationAgentS) Then
                paramsQueryColomuns = paramsQueryColomuns & " , dateModificationAgent"
                paramsQuery = paramsQuery & " , '" & pDiagnosticItem.dateModificationAgent & "'"
            End If
            If Not String.IsNullOrEmpty(pDiagnosticItem.dateModificationCrodip) Then
                paramsQueryColomuns = paramsQueryColomuns & " , dateModificationCrodip"
                paramsQuery = paramsQuery & " , '" & pDiagnosticItem.dateModificationCrodip & "'"
            End If
            sDebugStep = "4"
            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "INSERT INTO DiagnosticItem (" & paramsQueryColomuns & ") VALUES (" & paramsQuery & ")"
            bddCommande.ExecuteNonQuery()
            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                bddCommande.CommandText = "SELECT last_insert_rowid()"
            Else
                bddCommande.CommandText = "SELECT @@identity"

            End If
            pDiagnosticItem.id = CInt(bddCommande.ExecuteScalar())
            CSDb.ExecuteSQL("UPDATE DiagnosticTroncons833 Set aid = id where id = " & pDiagnosticItem.id)
            sDebugStep = "5"
            ' Test pour fermeture de connection BDD
            If Not oCSDb Is Nothing Then
                ' On ferme la connexion
                oCSDb.free()
            End If
            sDebugStep = "6"
            breturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager.Create ERR" & sDebugStep & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function
    Public Shared Sub setSynchro(ByVal objDiagnosticItem As DiagnosticItem)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE DiagnosticItem SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objDiagnosticItem.id & "' AND idDiagnostic = '" & objDiagnosticItem.idDiagnostic & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Private Shared Sub createDiagnosticItem2(ByVal diagnosticitem_id As String, ByVal pIdDiagnostic As String)
        Try
            Dim bddCommande As DbCommand
            Dim oCSdb As New CSDb(True)
            bddCommande = oCSdb.getConnection().CreateCommand

            ' Création
            bddCommande.CommandText = "INSERT INTO DiagnosticItem (id, idDiagnostic) VALUES ('" & diagnosticitem_id & "','" & pIdDiagnostic & "')"
            bddCommande.ExecuteNonQuery()

            ' Test pour fermeture de connection BDD
            If Not oCSdb Is Nothing Then
                ' On ferme la connexion
                oCSdb.free()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager.createDiagnosticItem error : " & ex.Message)
        End Try
    End Sub

    Public Shared Function deleteByDiagnosticID(ByVal pDiagnosticId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticId), "Diagnostic.id doit être inialisé")
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE from DiagnosticItem WHERE idDiagnostic='" & pDiagnosticId & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager.deleteByDiagnosticID(" & pDiagnosticId & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'deleteByDiagnosticID

    Public Shared Function delete(ByVal pDiagnosticItemId As String, pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticItemId), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Try
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "DELETE from DiagnosticItem WHERE id='" & pDiagnosticItemId & "' and idDiagnostic = '" & pIdDiagnostic & "'"
            nResult = bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticItemManager.delete(" & pDiagnosticItemId & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
