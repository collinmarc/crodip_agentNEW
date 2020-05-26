Imports System.Data.OleDb
Imports System.Collections.Generic
Public Class DiagnosticManager


#Region "Methodes acces Web Service"

    Public Shared Function getWSDiagnosticById(ByVal pAgentID As Integer, ByVal diagnostic_id As String) As Diagnostic
        Dim objDiagnostic As New Diagnostic
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As new Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetDiagnostic(pAgentID, diagnostic_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If objWSCrodip_responseItem.InnerText() <> "" Then
                            objDiagnostic.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    'MsgBox("Erreur - DiagnosticManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    'MsgBox("Erreur - DiagnosticManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            MsgBox("Erreur - DiagnosticManager - getWSDiagnosticById : " & ex.Message)
        End Try
        Return objDiagnostic

    End Function

    Public Shared Function sendWSDiagnostic(pAgent As Agent, ByVal diagnostic As Diagnostic, ByRef updatedObject As Object) As Integer
        Try
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendDiagnostic(pAgent.id, diagnostic, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function
    ''' <summary>
    ''' envoi des Etats rattachés au diag au serveur
    ''' Envoi par FTP, si cela ne fonctionne pas
    ''' envoi par HTTP
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    Public Shared Function SendEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        If My.Settings.SynchroEtatMode = "FTP" Then
            bReturn = SendFTPEtats(pDiag)
        Else
            bReturn = SendHTTPEtats(pDiag)
        End If
        Return bReturn
    End Function

    ''' <summary>
    ''' Envoie par FTP des Etats relatid au diag
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function SendFTPEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim oCSftp As CSFTP = New CSFTP()
            Dim filePath As String
            If Not String.IsNullOrEmpty(pDiag.RIFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    bReturn = oCSftp.Upload(filePath)
                    bReturn = oCSftp.FileExists(pDiag.RIFileName)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.SMFileName
                If System.IO.File.Exists(filePath) Then
                    SynchronisationManager.LogSynchroElmt(filePath)
                    bReturn = bReturn And oCSftp.Upload(filePath)
                    bReturn = bReturn And oCSftp.FileExists(pDiag.SMFileName)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.CCFileName
                If System.IO.File.Exists(filePath) Then
                    SynchronisationManager.LogSynchroElmt(filePath)
                    bReturn = bReturn And oCSftp.Upload(filePath)
                    bReturn = bReturn And oCSftp.FileExists(pDiag.CCFileName)
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.SendFTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Friend Shared Function SendHTTPEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim uri As New Uri(objWSCrodip.Url.Replace("/server", "") & My.Settings.SynchroEtatDiagUrl)
            Dim Credential As New System.Net.NetworkCredential(My.Settings.SynchroEtatDiagUser, My.Settings.SynhcroEtatDiagPwd)
            Dim filePath As String
            If Not String.IsNullOrEmpty(pDiag.RIFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.SMFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.CCFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.SendHTTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Recupère par FTP les Etats relatid au diag
    ''' </summary>
    ''' <param name="pDiag"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getFTPEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim oCSftp As CSFTP = New CSFTP()
            Dim filePath As String
            If Not String.IsNullOrEmpty(pDiag.RIFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = oCSftp.DownLoad(pDiag.RIFileName, Globals.CONST_PATH_EXP & "/")
            End If
            If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.SMFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = bReturn And oCSftp.DownLoad(pDiag.SMFileName, Globals.CONST_PATH_EXP & "/")
            End If
            If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.CCFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = bReturn And oCSftp.DownLoad(pDiag.CCFileName, Globals.CONST_PATH_EXP & "/")
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.GetFTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Friend Shared Function getHTTPEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim url As String = objWSCrodip.Url
            Dim Credential As New System.Net.NetworkCredential("crodip", "crodip35")
            Dim filePath As String
            If Not String.IsNullOrEmpty(pDiag.RIFileName) Then
                filePath = Globals.CONST_PATH_EXP & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                Dim uri As New Uri("http://admin-pp.crodip.fr/admin/diagnostic/get-pdf-view?id=" & pDiag.id)
                'My.Computer.Network.DownloadFile(uri, filePath, Credential, False, 100000, True)
                My.Computer.Network.DownloadFile(uri, filePath, "crodip", "crodip35")
            End If
            'If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
            '    filePath = Globals.CONST_PATH_EXP & "/" & pDiag.SMFileName
            '    If System.IO.File.Exists(filePath) Then
            '        System.IO.File.Delete(filePath)
            '    End If
            '    My.Computer.Network.DownloadFile(New Uri(url & "/pdf/" & pDiag.RIFileName), filePath, "crodip", "crodip35")
            'End If
            'If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
            '    filePath = Globals.CONST_PATH_EXP & "/" & pDiag.CCFileName
            '    If System.IO.File.Exists(filePath) Then
            '        System.IO.File.Delete(filePath)
            '    End If
            '    My.Computer.Network.DownloadFile(objWSCrodip.Url + "/pdf/" & pDiag.RIFileName, filePath, "crodip", "crodip35")
            'End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.GetHTTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function xml2object(ByVal arrXml As Object) As Diagnostic
        Dim objDiagnostic As New Diagnostic

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            objDiagnostic.Fill(tmpSerializeItem.LocalName, tmpSerializeItem.InnerText)
        Next

        Return objDiagnostic
    End Function

    Public Shared Function getWSDiagnosticIncrement(ByVal agent As Agent, ByRef curIncrement As String) As Object
        Dim objWSCrodip_response As Object
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim tmpCurIncrement As Object = Nothing
            ' Appel au WS
            'curIncrement = objWSCrodip.GetIncrementDiagnostic(agent.id.ToString, objWSCrodip_response)
            objWSCrodip_response = objWSCrodip.GetIncrementDiagnostic(agent.id.ToString, tmpCurIncrement)
            curIncrement = objWSCrodip_response(0).value.ToString
        Catch ex As Exception
            'Return False
            objWSCrodip_response = -1
            curIncrement = "0"
            CSDebug.dispFatal("DiagnosticManager - getWSDiagnosticIncrement : " & ex.Message.ToString)
        End Try
        Return objWSCrodip_response
    End Function

#End Region

#Region "Methodes acces Local"

    Public Shared Function getDiagnosticById(ByVal diagnostic_id As String) As Diagnostic
        ' déclarations
        Dim tmpDiagnostic As New Diagnostic
        tmpDiagnostic.id = diagnostic_id
        If loadDiagnostic(tmpDiagnostic) Then
            'on retourne le dIAGNOSTIC ou un objet vide en cas d'erreur
            Return tmpDiagnostic
        Else
            Return New Diagnostic()
        End If
    End Function
    Protected Shared Function loadDiagnostic(ByVal pdiag As Diagnostic) As Boolean
        ' déclarations
        Dim DebugStep As String
        Dim bReturn As Boolean = True
        Dim oCsdb As CSDb = Nothing
        Try


            If pdiag.id <> "" Then
                oCsdb = New CSDb(True)
                DebugStep = "1"
                Dim bddCommande As OleDb.OleDbCommand
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM Diagnostic WHERE Diagnostic.id='" & pdiag.id & "'"
                DebugStep = "2"
                ' On récupère les résultats
                Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                DebugStep = "3"
                If oDataReader.HasRows() Then
                    oDataReader.Read()
                    ' On remplit notre tableau
                    Dim nColId As Integer = 0
                    While nColId < oDataReader.FieldCount()
                        If Not oDataReader.IsDBNull(nColId) Then
                            pdiag.Fill(oDataReader.GetName(nColId), oDataReader.Item(nColId))
                        End If
                        nColId = nColId + 1
                    End While
                    DebugStep = "4"
                    DebugStep = "5"

                    LoadDiagnosticAttributes(pdiag)
                    bReturn = True
                Else
                    bReturn = False
                End If


            End If
        Catch ex As Exception
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        'on retourne le dIAGNOSTIC ou un objet vide en cas d'erreur
        Return bReturn
    End Function

    Protected Shared Function LoadDiagnosticAttributes(pDiag As Diagnostic) As Boolean
        Dim DebugStep As String
        Dim oCsdb As CSDb = Nothing
        Dim bReturn As Boolean = True
        Try

            oCsdb = New CSDb(True)
            '########################################
            ' On récupère les items du diagnostic
            '########################################
            DiagnosticItemManager.getDiagnosticItemByDiagnosticId(pDiag)
            DebugStep = "8"

            '########################################
            ' On récupère les mesures help551
            '########################################
            pDiag.diagnosticHelp551 = DiagnosticHelp551Manager.getDiagnosticHelp551ByDiagnosticId(pDiag)
            DebugStep = "9"
            pDiag.diagnosticHelp5621 = DiagnosticHelp5621Manager.getDiagnosticHelp5621ByDiagnosticId(pDiag)
            DebugStep = "9.5621"
            pDiag.diagnosticHelp12323 = DiagnosticHelp551Manager.getDiagnosticHelp12323ByDiagnosticId(pDiag)
            DebugStep = "9.12323"

            '########################################
            ' On récupère les mesures help552
            '########################################
            pDiag.diagnosticHelp552 = DiagnosticHelp552Manager.getDiagnosticHelp552ByDiagnosticId(pDiag)
            DebugStep = "9.552"

            '########################################
            ' On récupère les mesures help5622
            '########################################
            pDiag.diagnosticHelp5622 = DiagnosticHelp5622Manager.getDiagnosticHelp5622ByDiagnosticId(pDiag)
            DebugStep = "9.5622"

            '########################################
            ' On récupère les mesures help811
            '########################################
            pDiag.diagnosticHelp811 = DiagnosticHelp811Manager.getDiagnosticHelp811ByDiagnosticId(pDiag)
            DebugStep = "9.811"
            '########################################
            ' On récupère les mesures help831
            '########################################
            pDiag.diagnosticHelp8312 = DiagnosticHelp831Manager.getDiagnosticHelp8312ByDiagnosticId(pDiag)
            pDiag.diagnosticHelp8314 = DiagnosticHelp831Manager.getDiagnosticHelp8314ByDiagnosticId(pDiag)
            DebugStep = "8.831"
            '########################################
            ' On récupère les mesures help571
            '########################################
            pDiag.diagnosticHelp571 = DiagnosticHelp571Manager.getDiagnosticHelp571ByDiagnosticId(pDiag)
            DebugStep = "8.831"
            '########################################
            ' On récupère les mesures help12123
            '########################################
            pDiag.diagnosticHelp12123 = DiagnosticHelp12123Manager.getDiagnosticHelp12123ByDiagnosticId(pDiag)
            DebugStep = "8.12123"
            '########################################
            ' On récupère les infosComplémentaires
            '########################################
            pDiag.diagnosticInfosComplementaires = DiagnosticInfosComplementaireManager.getDiagnosticInfosComplementairesByDiagnosticId(pDiag)
            DebugStep = "9."
            '#########################################################
            ' On récupère les diagnosticBuses et DiagnosticBusesDetail
            '#########################################################
            DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(pDiag)

            '#########################################################
            ' On récupère les diagnosticMano542
            '#########################################################

            Dim bddCommande5 As New OleDb.OleDbCommand
            bddCommande5.Connection = oCsdb.getConnection()
            bddCommande5.CommandText = "SELECT * FROM DiagnosticMano542 WHERE DiagnosticMano542.idDiagnostic='" & pDiag.id & "' ORDER BY id"
            ' On récupère les résultats
            Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande5.ExecuteReader
            DebugStep = "18"
            ' Puis on les parcours
            Dim nColId As Integer
            Dim tmpDiagnosticMano542List As New DiagnosticMano542List
            While oDataReader.Read()
                Dim tmpDiagnosticMano542 As New DiagnosticMano542
                ' On rempli notre tableau
                nColId = 0
                While nColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(nColId) Then
                        tmpDiagnosticMano542.Fill(oDataReader.GetName(nColId), oDataReader.GetValue(nColId))
                    End If
                    nColId = nColId + 1
                End While
                pDiag.diagnosticMano542List.Liste.Add(tmpDiagnosticMano542)
            End While
            DebugStep = "19"
            ' Test pour fermeture de connection BDD
            oDataReader.Close()
            DebugStep = "20"
            '#########################################################
            ' On récupère les diagnosticPressions833
            '#########################################################
            ' On récupère les pressions aux tronçons
            Dim bddCommande6 As New OleDb.OleDbCommand
            bddCommande6.Connection = oCsdb.getConnection()
            bddCommande6.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE DiagnosticTroncons833.idDiagnostic='" & pDiag.id & "'"
            ' On récupère les résultats
            oDataReader = bddCommande6.ExecuteReader
            ' Puis on les parcours
            DebugStep = "21"
            'Dim tmpDiagnosticTroncons833List As New DiagnosticTroncons833List
            'Dim tmpArrDiagnosticTroncons833(0) As DiagnosticTroncons833
            Dim l As Integer = 0
            While oDataReader.Read()
                Dim tmpDiagnosticTroncons833 As New DiagnosticTroncons833
                ' On rempli notre tableau
                nColId = 0
                While nColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(nColId) Then
                        tmpDiagnosticTroncons833.Fill(oDataReader.GetName(nColId), oDataReader.GetValue(nColId))
                    End If
                    nColId = nColId + 1
                End While
                pDiag.diagnosticTroncons833.Liste.Add(tmpDiagnosticTroncons833)
            End While
            DebugStep = "22"
            oDataReader.Close()
            DebugStep = "23"

            If oCsdb IsNot Nothing Then
                oCsdb.free()
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.LoadDiagnosticAttributes ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Retourne une liste de diagnostics pour une contre visite
    ''' ControleEtat = 0, Date de fin de controle moins de 4 mois
    ''' </summary>
    ''' <param name="pdiagnosticID">Racine du diagnosticID </param>
    ''' <returns>Collection de diag (DiagID, DateFinControle, ControleEtat)</returns>
    ''' <remarks></remarks>
    Public Shared Function getDiagnosticPourContreVisite(ByVal pPulveId As String, ByVal pStructureId As String, Optional ByVal pdiagnosticID As String = "", Optional pDateRef As Date? = Nothing) As List(Of Diagnostic)
        Dim colDiag As List(Of Diagnostic) = New List(Of Diagnostic)()
        Try
            Dim oDiag As Diagnostic
            Dim query As String
            If pDateRef Is Nothing Then
                pDateRef = Date.Today()
            End If
            'Calcul de la date limite (aujourd'hui - 4 mois)
            Dim DateLimite As DateTime = DateAdd(DateInterval.Month, -4, pDateRef.Value)

            '#9628 : on ne prend que les diagnostic de moins de 4 mois qui ont des diagnostic items
            '18/09/2013 : Retour 2.5.3 avant diffusion : on prend tous les diag de moins de 4 mois qu'ils ait des diagitems ou pas
            'car pendant les 4 premiers mois de la version, il y a des diags eligibles qui n'ont pas de diagitems , car synchronisé 
            'avant la 2.5.3
            '#5762 : Réactivation du Controle
            '            Dim strSQL As String = " DATEDIFF('m',Diagnostic.controleDateFin, NOW())<4"
            Dim strSQL As String = " Diagnostic.controleDateFin >= #" & DateLimite.ToString("MM/dd/yyyy") & "#"
            'query = "SELECT DISTINCT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic,diagnosticItem WHERE diagnosticItem.idDiagnostic = Diagnostic.id and  Diagnostic.controleEtat='0' AND Diagnostic.pulverisateurId='" & pPulveId & "' AND Diagnostic.organismePresId=" & pStructureId & " AND " & strSQL
            query = "SELECT DISTINCT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic WHERE Diagnostic.controleEtat='0' AND Diagnostic.pulverisateurId='" & pPulveId & "' AND Diagnostic.organismePresId=" & pStructureId & " AND " & strSQL
            If Not String.IsNullOrEmpty(pdiagnosticID) Then
                query = query & " AND Diagnostic.id LIKE '" & pdiagnosticID & "%'"
            End If
            query = query & " ORDER BY Diagnostic.controleDateFin DESC"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            Dim i As String = 0
            colDiag.Clear()
            While dataResults.Read()
                oDiag = New Diagnostic()
                oDiag.organismePresId = pStructureId
                oDiag.pulverisateurId = pPulveId
                oDiag.id = Trim(dataResults.Item(0).ToString)
                oDiag.controleDateFin = CSDate.mysql2access(Trim(dataResults.Item(1).ToString))
                oDiag.controleEtat = dataResults.Item(2).ToString
                colDiag.Add(oDiag)
            End While
            bdd.free()
            bdd = Nothing
        Catch ex As Exception
            CSDebug.dispError("Liste des CV - searchDiagnostic : " & ex.Message)
        End Try
        Return colDiag
    End Function
    ''' <summary>
    ''' Rend une liste de Diagnostic par pulvérisateur triée par date de début de controle descendant
    ''' </summary>
    ''' <param name="pulverisateur_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getlstDiagnosticByPulveId(ByVal pulverisateur_id As String) As List(Of Diagnostic)
        Debug.Assert(Not String.IsNullOrEmpty(pulverisateur_id))
        ' déclarations
        Dim lstDiag As New List(Of Diagnostic)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Diagnostic  WHERE Pulverisateurid='" & pulverisateur_id & "' ORDER BY controleDateDebut DESC"
        Try
            ' On récupère les résultats
            Dim oDR As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()
                ' On initialise un diag
                Dim oDiagnostic As New Diagnostic
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(tmpColId) Then
                        oDiagnostic.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                'On l'ajoute à la liste
                lstDiag.Add(oDiagnostic)
            End While
            oDR.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("DiagnosticManager.getDiagnosticByPulveId ERR:" & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        oCSDb.free()
        'on retourne la liste des diagnostic
        Return lstDiag
    End Function
    Public Shared Function getlstDiagnostic() As List(Of Diagnostic)
        ' déclarations
        Dim lstDiag As New List(Of Diagnostic)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT ID,dateModificationAgent,dateModificationCrodip,dateSynchro, RIFileName,SMFileName,CCFileName FROM Diagnostic"
        Try
            ' On récupère les résultats
            Dim oDR As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()
                ' On initialise un diag
                Dim oDiagnostic As New Diagnostic
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(tmpColId) Then
                        oDiagnostic.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                'On l'ajoute à la liste
                lstDiag.Add(oDiagnostic)
            End While
            oDR.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("DiagnosticManager.getlstDiagnostic ERR:" & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        oCSDb.free()
        'on retourne la liste des diagnostic
        Return lstDiag
    End Function
    ''' <summary>
    ''' Rend une liste de Diagnostic par exploitation triée par date de début de controle descendant
    ''' </summary>
    ''' <param name="Exploitation_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getlstDiagnosticByExploitationId(ByVal exploitation_id As String) As List(Of Diagnostic)
        Debug.Assert(Not String.IsNullOrEmpty(exploitation_id))
        ' déclarations
        Dim lstDiag As New List(Of Diagnostic)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Diagnostic  WHERE proprietaireId='" & exploitation_id & "' ORDER BY controleDateDebut DESC"
        Try
            ' On récupère les résultats
            Dim oDR As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()
                ' On initialise un diag
                Dim oDiagnostic As New Diagnostic
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    If Not oDR.IsDBNull(tmpColId) Then
                        oDiagnostic.Fill(oDR.GetName(tmpColId), oDR.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                'On l'ajoute à la liste
                lstDiag.Add(oDiagnostic)
            End While
            oDR.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("DiagnosticManager.getDiagnosticByExploitationId ERR:" & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        oCSDb.free()
        'on retourne la liste des diagnostic
        Return lstDiag
    End Function

    ' Recupère tous les diagnostics non synchronisé (dateModificationAgent / dateModificationCrodip) 
    Public Shared Function getUpdates(ByVal pAgent As Agent) As Diagnostic()

        ' déclarations
        Dim arrItems(0) As Diagnostic
        Dim bddCommande As New OleDb.OleDbCommand
        Dim oCsdb As New CSDb(True)
        ' On test si la connexion est déjà ouverte ou non
        bddCommande.Connection = oCsdb.getConnection()
        '        bddCommande.CommandText = "SELECT * FROM `Diagnostic` WHERE `Diagnostic`.`dateModificationAgent`<>`Diagnostic`.`dateModificationCrodip` AND `Diagnostic`.`inspecteurId`=" & agent.id
        bddCommande.CommandText = "Select Diagnostic.* From Diagnostic INNER Join Agent On Diagnostic.inspecteurId = Agent.Id Where Agent.idStructure = " & pAgent.idStructure
        bddCommande.CommandText = bddCommande.CommandText & " AND Diagnostic.dateModificationAgent<>Diagnostic.dateModificationCrodip"
        Try
            ' On récupère les résultats
            Dim oDRDiagnostic As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While oDRDiagnostic.Read()
                ' On remplit notre tableau
                Dim oDiagnostic As New Diagnostic
                Dim nColId As Integer = 0
                While nColId < oDRDiagnostic.FieldCount()
                    'Chargement des données dans le Diagnostic
                    If Not oDRDiagnostic.IsDBNull(nColId) Then
                        oDiagnostic.Fill(oDRDiagnostic.GetName(nColId), oDRDiagnostic.Item(nColId))
                    End If
                    nColId = nColId + 1
                End While

                ' If oDiagnostic.controleDateFin >= DateAdd(DateInterval.Month, -4, Date.Today) Then
                ' On récupère les items du diagnostic
                DiagnosticItemManager.getDiagnosticItemByDiagnosticId(oDiagnostic)

                '########################################
                ' On récupère les mesures help551
                '########################################
                oDiagnostic.diagnosticHelp551 = DiagnosticHelp551Manager.getDiagnosticHelp551ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp551.HasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp551AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help5621
                '########################################
                oDiagnostic.diagnosticHelp5621 = DiagnosticHelp5621Manager.getDiagnosticHelp5621ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp5621.HasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp5621AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help552
                '########################################
                oDiagnostic.diagnosticHelp552 = DiagnosticHelp552Manager.getDiagnosticHelp552ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp552.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp552AsDiagItem())
                End If
                ' On récupère les buses du diagnostic
                DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(oDiagnostic)

                '########################################
                ' On récupère les mesures help5622
                '########################################
                oDiagnostic.diagnosticHelp5622 = DiagnosticHelp5622Manager.getDiagnosticHelp5622ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp5622.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp5622AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help811
                '########################################
                oDiagnostic.diagnosticHelp811 = DiagnosticHelp811Manager.getDiagnosticHelp811ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp811.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp811AsDiagItem())
                End If
                '########################################
                ' On récupère les mesures help831
                '########################################
                oDiagnostic.diagnosticHelp8312 = DiagnosticHelp831Manager.getDiagnosticHelp8312ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp8312.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp8312AsDiagItem())
                End If
                oDiagnostic.diagnosticHelp8314 = DiagnosticHelp831Manager.getDiagnosticHelp8314ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp8314.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp8314AsDiagItem())
                End If
                oDiagnostic.diagnosticHelp571 = DiagnosticHelp571Manager.getDiagnosticHelp571ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp571.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp571.ConvertToDiagnosticItem())
                End If
                oDiagnostic.diagnosticHelp12123 = DiagnosticHelp12123Manager.getDiagnosticHelp12123ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp12123.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp12123.ConvertToDiagnosticItem())
                End If
                oDiagnostic.diagnosticHelp12323 = DiagnosticHelp551Manager.getDiagnosticHelp12323ByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticHelp12323.HasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp12323.ConvertToDiagnosticItem())
                End If
                '########################################
                ' On récupère les infos complémentaire
                '########################################
                oDiagnostic.diagnosticInfosComplementaires = DiagnosticInfosComplementaireManager.getDiagnosticInfosComplementairesByDiagnosticId(oDiagnostic)
                If oDiagnostic.diagnosticInfosComplementaires.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticInfosComplementairesAsDiagItem())
                End If

                '##################################################################################################################

                ' On récupère les mesures des mano
                Dim bddCommande5 As New OleDb.OleDbCommand
                bddCommande5.Connection = oCsdb.getConnection()
                bddCommande5.CommandText = "SELECT * FROM DiagnosticMano542 WHERE DiagnosticMano542.idDiagnostic='" & oDiagnostic.id & "'"
                ' On récupère les résultats
                Dim oDRDiagnosticMano542 As System.Data.OleDb.OleDbDataReader = bddCommande5.ExecuteReader
                ' Puis on les parcours
                Dim tmpDiagnosticMano542List As New DiagnosticMano542List
                While oDRDiagnosticMano542.Read()
                    Dim tmpDiagnosticMano542 As New DiagnosticMano542
                    ' On rempli notre tableau
                    nColId = 0
                    While nColId < oDRDiagnosticMano542.FieldCount()
                        Select Case oDRDiagnosticMano542.GetName(nColId)
                            Case "id"
                                tmpDiagnosticMano542.id = oDRDiagnosticMano542.Item(nColId)
                            Case "idDiagnostic"
                                tmpDiagnosticMano542.idDiagnostic = oDRDiagnosticMano542.Item(nColId).ToString()
                            Case "pressionPulve"
                                tmpDiagnosticMano542.pressionPulve = oDRDiagnosticMano542.Item(nColId).ToString()
                            Case "pressionControle"
                                tmpDiagnosticMano542.pressionControle = oDRDiagnosticMano542.Item(nColId).ToString()
                            Case "dateModificationCrodip"
                                tmpDiagnosticMano542.dateModificationCrodip = CSDate.ToCRODIPString(oDRDiagnosticMano542.Item(nColId).ToString())
                            Case "dateModificationAgent"
                                tmpDiagnosticMano542.dateModificationAgent = CSDate.ToCRODIPString(oDRDiagnosticMano542.Item(nColId).ToString())
                        End Select
                        nColId = nColId + 1
                    End While
                    oDiagnostic.diagnosticMano542List.Liste.Add(tmpDiagnosticMano542)
                End While
                ' Test pour fermeture de connection BDD
                oDRDiagnosticMano542.Close()

                '##################################################################################################################

                ' On récupère les pressions aux tronçons
                Dim bddCommande6 As New OleDb.OleDbCommand
                bddCommande6.Connection = oCsdb.getConnection()
                bddCommande6.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE DiagnosticTroncons833.idDiagnostic='" & oDiagnostic.id & "'"
                ' On récupère les résultats
                Dim oDRDiagnosticTroncon833 As System.Data.OleDb.OleDbDataReader = bddCommande6.ExecuteReader
                ' Puis on les parcours
                Dim tmpDiagnosticTroncons833List As New DiagnosticTroncons833List
                While oDRDiagnosticTroncon833.Read()
                    Dim tmpDiagnosticTroncons833 As New DiagnosticTroncons833
                    ' On rempli notre tableau
                    nColId = 0
                    While nColId < oDRDiagnosticTroncon833.FieldCount()
                        If Not oDRDiagnosticTroncon833.IsDBNull(nColId) Then
                            tmpDiagnosticTroncons833.Fill(oDRDiagnosticTroncon833.GetName(nColId), oDRDiagnosticTroncon833.GetValue(nColId))
                        End If
                        nColId = nColId + 1
                    End While
                    oDiagnostic.diagnosticTroncons833.Liste.Add(tmpDiagnosticTroncons833)
                End While
                ' Test pour fermeture de connection BDD
                oDRDiagnosticTroncon833.Close()

                '##################################################################################################################
                'End If Test sur Date de Fin controle
                'On ajoute notre diag aux résultats
                arrItems(i) = oDiagnostic
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            oDRDiagnostic.Close()
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("Erreur - DiagnosticManager - getUpdates : " & ex.Message)
            ReDim arrItems(0)
        End Try

        ' Test pour fermeture de connection BDD
        If Not oCsdb Is Nothing Then
            ' On ferme la connexion
            oCsdb.free()
        End If

        'on retourne les objet non synchro
        Return arrItems

    End Function


    Private Shared Function createDiagnostic(ByVal diagnostic_id As String) As Boolean
        Dim oCsDB As New CSDb(True)
        Dim bddCommande As New OleDb.OleDbCommand
        Dim bReturn As Boolean
        Try
            bddCommande.Connection = oCsDB.getConnection()

            ' Création
            bddCommande.CommandText = "INSERT INTO `Diagnostic` (`id`) VALUES ('" & diagnostic_id & "')"
            bddCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            MsgBox("DiagnosticManager error : " & ex.Message)
            bReturn = False
        End Try
        If Not oCsDB Is Nothing Then
            oCsDB.free()
        End If
        Return bReturn
    End Function

    Public Shared Function getNewId(pAgent As Agent) As String
        Debug.Assert(Not pAgent Is Nothing, "L'agent doit être renseigné")
        Debug.Assert(pAgent.id <> 0, "L'agent id doit être renseigné")
        Debug.Assert(pAgent.idStructure <> 0, "La structure id doit être renseignée")
        ' déclarations
        Dim tmpDiagnosticId As String = pAgent.idStructure.ToString() & "-" & pAgent.id.ToString() & "-1"
        Dim oCSDb As New CSDb(True)
        If pAgent.idStructure <> 0 Then

            ' On test si la table est vide
            Dim tmpNbDiagResult As System.Data.OleDb.OleDbDataReader = oCSDb.getResult2s("SELECT count(*) as nbControles FROM `Diagnostic` WHERE `Diagnostic`.`InspecteurID` = " & pAgent.id & "")
            Dim tmpNbDiag As Integer = 0
            While tmpNbDiagResult.Read()
                tmpNbDiag = tmpNbDiagResult.GetInt32(0)
            End While

            ' Si la base est vide, on récupère le dernier incrément par WS
            If tmpNbDiag < 1 Then
                Dim curIncrement As String = ""
                Try
                    DiagnosticManager.getWSDiagnosticIncrement(pAgent, curIncrement)
                    tmpDiagnosticId = pAgent.idStructure.ToString() & "-" & pAgent.id.ToString() & "-" & curIncrement
                Catch ex As Exception
                    CSDebug.dispFatal("DiagnosticManager - newId (getWSDiagnosticIncrement) : " & ex.Message)
                End Try
            Else ' Sinon on le calcul en local
                Dim bddCommande As New OleDb.OleDbCommand
                ' On test si la connexion est déjà ouverte ou non
                bddCommande.Connection = oCSDb.getConnection()
                bddCommande.CommandText = "SELECT id FROM Diagnostic WHERE InspecteurId = " & pAgent.id & " ORDER BY id DESC"
                Try
                    ' On récupère les résultats
                    Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                    ' Puis on les parcours
                    Dim newId As Integer = 0
                    While oDataReader.Read()
                        ' On récupère le dernier ID
                        'Récupéer lID à l'aide d'un split
                        Dim tmpId As Integer = 0
                        Dim tabId As String()
                        tmpDiagnosticId = oDataReader.Item(0).ToString
                        tabId = tmpDiagnosticId.Split("-")
                        If IsNumeric(tabId(2)) Then
                            tmpId = CInt(tabId(2))
                        Else
                            tmpId = 1
                        End If
                        If tmpId > newId Then
                            newId = tmpId
                        End If
                    End While
                    tmpDiagnosticId = pAgent.idStructure & "-" & pAgent.id & "-" & (newId + 1)
                Catch ex As Exception ' On intercepte l'erreur
                    tmpDiagnosticId = pAgent.idStructure & "-" & pAgent.id & "-0"
                    CSDebug.dispFatal("DiagnosticManager - newId (On récupère le dernier ID) : " & ex.Message)
                End Try

                ' Test pour fermeture de connection BDD
                If Not oCSDb Is Nothing Then
                    ' On ferme la connexion
                    oCSDb.free()
                End If
            End If

        End If
        'on retourne le nouvel id
        Return tmpDiagnosticId
    End Function

    Public Shared Function save(ByVal objDiagnostic As Diagnostic, Optional bsyncro As Boolean = False) As Boolean
        'Debug.Assert(Not String.IsNullOrEmpty(objDiagnostic.id))
        Dim bReturn As Boolean = False
        Dim bcreationDiag As Boolean
        Try
            bcreationDiag = False
            If objDiagnostic.id <> "" Then

                Dim CSDb As New CSDb(True)

                ' On test si le Diagnostic existe ou non
                Dim existsDiagnostic As Object
                existsDiagnostic = DiagnosticManager.getDiagnosticById(objDiagnostic.id)
                If existsDiagnostic.id = "" Then
                    ' Si il n'existe pas, on le crée
                    createDiagnostic(objDiagnostic.id)
                    bcreationDiag = True
                End If

                Dim bddCommande As New OleDb.OleDbCommand
                ' On test si la connexion est déjà ouverte ou non
                bddCommande.Connection = CSDb.getConnection()

                ' Initialisation de la requete
                Dim paramsQuery As String = "Diagnostic.id='" & objDiagnostic.id & "'"
                Dim paramsQuery2 As String = "Diagnostic.id='" & objDiagnostic.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bsyncro Then
                    objDiagnostic.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                paramsQuery = paramsQuery & " , Diagnostic.organismePresId=" & objDiagnostic.organismePresId & ""
                If Not objDiagnostic.organismePresNumero Is Nothing And objDiagnostic.organismePresNumero <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismePresNumero='" & CSDb.secureString(objDiagnostic.organismePresNumero) & "'"
                End If
                If Not objDiagnostic.organismePresNom Is Nothing And objDiagnostic.organismePresNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismePresNom='" & CSDb.secureString(objDiagnostic.organismePresNom) & "'"
                End If
                If Not objDiagnostic.organismeInspNom Is Nothing And objDiagnostic.organismeInspNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeInspNom='" & CSDb.secureString(objDiagnostic.organismeInspNom) & "'"
                End If
                If Not objDiagnostic.organismeInspAgrement Is Nothing And objDiagnostic.organismeInspAgrement <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeInspAgrement='" & CSDb.secureString(objDiagnostic.organismeInspAgrement) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.inspecteurId=" & objDiagnostic.inspecteurId & ""
                If Not objDiagnostic.inspecteurNom Is Nothing And objDiagnostic.inspecteurNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.inspecteurNom='" & CSDb.secureString(objDiagnostic.inspecteurNom) & "'"
                End If
                If Not objDiagnostic.inspecteurPrenom Is Nothing And objDiagnostic.inspecteurPrenom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.inspecteurPrenom='" & CSDb.secureString(objDiagnostic.inspecteurPrenom) & "'"
                End If
                'Organisme et inspecteur d'origine
                paramsQuery = paramsQuery & " , Diagnostic.organismeOriginePresId=" & objDiagnostic.organismeOriginePresId & ""
                If Not objDiagnostic.organismeOriginePresNumero Is Nothing And objDiagnostic.organismeOriginePresNumero <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeOriginePresNumero='" & CSDb.secureString(objDiagnostic.organismeOriginePresNumero) & "'"
                End If
                If Not objDiagnostic.organismeOriginePresNom Is Nothing And objDiagnostic.organismeOriginePresNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeOriginePresNom='" & CSDb.secureString(objDiagnostic.organismeOriginePresNom) & "'"
                End If
                If Not objDiagnostic.organismeOrigineInspNom Is Nothing And objDiagnostic.organismeOrigineInspNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeOrigineInspNom='" & CSDb.secureString(objDiagnostic.organismeOrigineInspNom) & "'"
                End If
                If Not objDiagnostic.organismeOrigineInspAgrement Is Nothing And objDiagnostic.organismeOrigineInspAgrement <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.organismeOrigineInspAgrement='" & CSDb.secureString(objDiagnostic.organismeOrigineInspAgrement) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.inspecteurOrigineId=" & objDiagnostic.inspecteurOrigineId & ""
                If Not objDiagnostic.inspecteurOrigineNom Is Nothing And objDiagnostic.inspecteurOrigineNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.inspecteurOrigineNom='" & CSDb.secureString(objDiagnostic.inspecteurOrigineNom) & "'"
                End If
                If Not objDiagnostic.inspecteurOriginePrenom Is Nothing And objDiagnostic.inspecteurOriginePrenom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.inspecteurOriginePrenom='" & CSDb.secureString(objDiagnostic.inspecteurOriginePrenom) & "'"
                End If

                If Not objDiagnostic.controleDateDebut Is Nothing And objDiagnostic.controleDateDebut <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleDateDebut='" & CSDb.secureString(objDiagnostic.controleDateDebut) & "'"
                End If
                If Not objDiagnostic.controleDateFin Is Nothing And objDiagnostic.controleDateFin <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleDateFin='" & CSDb.secureString(objDiagnostic.controleDateFin) & "'"
                End If
                If Not objDiagnostic.controleCommune Is Nothing And objDiagnostic.controleCommune <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleCommune='" & CSDb.secureString(objDiagnostic.controleCommune) & "'"
                End If
                If Not objDiagnostic.controleCodePostal Is Nothing And objDiagnostic.controleCodePostal <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleCodePostal='" & CSDb.secureString(objDiagnostic.controleCodePostal) & "'"
                End If
                If Not objDiagnostic.controleLieu Is Nothing And objDiagnostic.controleLieu <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleLieu='" & CSDb.secureString(objDiagnostic.controleLieu) & "'"
                End If
                If Not objDiagnostic.controleTerritoire Is Nothing And objDiagnostic.controleTerritoire <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleTerritoire='" & CSDb.secureString(objDiagnostic.controleTerritoire) & "'"
                End If
                If Not objDiagnostic.controleSite Is Nothing And objDiagnostic.controleSite <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleSite='" & CSDb.secureString(objDiagnostic.controleSite) & "'"
                End If
                If Not objDiagnostic.controleNomSite Is Nothing And objDiagnostic.controleNomSite <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleNomSite='" & CSDb.secureString(objDiagnostic.controleNomSite) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.controleIsComplet=" & objDiagnostic.controleIsComplet & ""
                paramsQuery = paramsQuery & " , Diagnostic.controleIsPremierControle=" & objDiagnostic.controleIsPremierControle & ""
                If Not objDiagnostic.controleDateDernierControle Is Nothing And objDiagnostic.controleDateDernierControle <> "" And objDiagnostic.controleDateDernierControle <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleDateDernierControle='" & CSDb.secureString(objDiagnostic.controleDateDernierControle) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.controleIsSiteSecurise=" & objDiagnostic.controleIsSiteSecurise & ""
                paramsQuery = paramsQuery & " , Diagnostic.controleIsRecupResidus=" & objDiagnostic.controleIsRecupResidus & ""
                If Not objDiagnostic.controleEtat Is Nothing And objDiagnostic.controleEtat <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleEtat='" & CSDb.secureString(objDiagnostic.controleEtat) & "'"
                End If
                If Not objDiagnostic.controleInfosConseils Is Nothing And objDiagnostic.controleInfosConseils <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleInfosConseils='" & CSDb.secureString(objDiagnostic.controleInfosConseils) & "'"
                End If
                If Not objDiagnostic.controleTarif Is Nothing And objDiagnostic.controleTarif <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.controleTarif='" & CSDb.secureString(objDiagnostic.controleTarif) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.controleIsPulveRepare=" & objDiagnostic.controleIsPulveRepare & ""
                paramsQuery = paramsQuery & " , Diagnostic.controleIsPreControleProfessionel=" & objDiagnostic.controleIsPreControleProfessionel & ""
                paramsQuery = paramsQuery & " , Diagnostic.controleIsAutoControle=" & objDiagnostic.controleIsAutoControle & ""
                If Not objDiagnostic.proprietaireId Is Nothing And objDiagnostic.proprietaireId <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireId='" & CSDb.secureString(objDiagnostic.proprietaireId) & "'"
                End If
                If Not objDiagnostic.proprietaireRaisonSociale Is Nothing And objDiagnostic.proprietaireRaisonSociale <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireRaisonSociale='" & CSDb.secureString(objDiagnostic.proprietaireRaisonSociale) & "'"
                End If
                If Not objDiagnostic.proprietairePrenom Is Nothing And objDiagnostic.proprietairePrenom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietairePrenom='" & CSDb.secureString(objDiagnostic.proprietairePrenom) & "'"
                End If
                If Not objDiagnostic.proprietaireNom Is Nothing And objDiagnostic.proprietaireNom <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireNom='" & CSDb.secureString(objDiagnostic.proprietaireNom) & "'"
                End If
                If Not objDiagnostic.proprietaireCodeApe Is Nothing And objDiagnostic.proprietaireCodeApe <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireCodeApe='" & CSDb.secureString(objDiagnostic.proprietaireCodeApe) & "'"
                End If
                If Not objDiagnostic.proprietaireNumeroSiren Is Nothing And objDiagnostic.proprietaireNumeroSiren <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireNumeroSiren='" & CSDb.secureString(objDiagnostic.proprietaireNumeroSiren) & "'"
                End If
                If Not objDiagnostic.proprietaireCommune Is Nothing And objDiagnostic.proprietaireCommune <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireCommune='" & CSDb.secureString(objDiagnostic.proprietaireCommune) & "'"
                End If
                If Not objDiagnostic.proprietaireCodePostal Is Nothing And objDiagnostic.proprietaireCodePostal <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireCodePostal='" & CSDb.secureString(objDiagnostic.proprietaireCodePostal) & "'"
                End If
                If Not objDiagnostic.proprietaireAdresse Is Nothing And objDiagnostic.proprietaireAdresse <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireAdresse='" & CSDb.secureString(objDiagnostic.proprietaireAdresse) & "'"
                End If
                If Not objDiagnostic.proprietaireEmail Is Nothing And objDiagnostic.proprietaireEmail <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireEmail='" & CSDb.secureString(objDiagnostic.proprietaireEmail) & "'"
                End If
                If Not objDiagnostic.proprietaireTelephonePortable Is Nothing And objDiagnostic.proprietaireTelephonePortable <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireTelephonePortable='" & CSDb.secureString(objDiagnostic.proprietaireTelephonePortable) & "'"
                End If
                If Not objDiagnostic.proprietaireTelephoneFixe Is Nothing And objDiagnostic.proprietaireTelephoneFixe <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireTelephoneFixe='" & CSDb.secureString(objDiagnostic.proprietaireTelephoneFixe) & "'"
                End If
                If Not String.IsNullOrEmpty(objDiagnostic.proprietaireRepresentant) Then
                    paramsQuery = paramsQuery & " , Diagnostic.proprietaireRepresentant='" & CSDb.secureString(objDiagnostic.proprietaireRepresentant) & "'"
                End If
                If Not objDiagnostic.pulverisateurId Is Nothing And objDiagnostic.pulverisateurId <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurId='" & CSDb.secureString(objDiagnostic.pulverisateurId) & "'"
                End If
                If Not objDiagnostic.pulverisateurMarque Is Nothing And objDiagnostic.pulverisateurMarque <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurMarque='" & CSDb.secureString(objDiagnostic.pulverisateurMarque) & "'"
                End If
                If Not objDiagnostic.pulverisateurModele Is Nothing And objDiagnostic.pulverisateurModele <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurModele='" & CSDb.secureString(objDiagnostic.pulverisateurModele) & "'"
                End If
                If Not objDiagnostic.pulverisateurType Is Nothing And objDiagnostic.pulverisateurType <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurType='" & CSDb.secureString(objDiagnostic.pulverisateurType) & "'"
                End If
                If Not objDiagnostic.pulverisateurCapacite Is Nothing And objDiagnostic.pulverisateurCapacite <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurCapacite='" & CSDb.secureString(objDiagnostic.pulverisateurCapacite) & "'"
                End If
                If Not objDiagnostic.pulverisateurLargeur Is Nothing And objDiagnostic.pulverisateurLargeur <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurLargeur='" & CSDb.secureString(objDiagnostic.pulverisateurLargeur) & "'"
                End If
                If Not objDiagnostic.pulverisateurNbRangs Is Nothing And objDiagnostic.pulverisateurNbRangs <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurNbRangs='" & CSDb.secureString(objDiagnostic.pulverisateurNbRangs) & "'"
                End If
                If Not objDiagnostic.pulverisateurLargeurPlantation Is Nothing And objDiagnostic.pulverisateurLargeurPlantation <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurLargeurPlantation='" & CSDb.secureString(objDiagnostic.pulverisateurLargeurPlantation) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsVentilateur=" & objDiagnostic.pulverisateurIsVentilateur & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsDebrayage=" & objDiagnostic.pulverisateurIsDebrayage & ""
                If Not objDiagnostic.pulverisateurAnneeAchat Is Nothing And objDiagnostic.pulverisateurAnneeAchat <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurAnneeAchat='" & CSDb.secureString(objDiagnostic.pulverisateurAnneeAchat) & "'"
                End If
                If Not objDiagnostic.pulverisateurSurface Is Nothing And objDiagnostic.pulverisateurSurface <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurSurface='" & CSDb.secureString(objDiagnostic.pulverisateurSurface) & "'"
                End If
                If Not objDiagnostic.pulverisateurNbUtilisateurs Is Nothing And objDiagnostic.pulverisateurNbUtilisateurs <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurNbUtilisateurs='" & CSDb.secureString(objDiagnostic.pulverisateurNbUtilisateurs) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsCuveRincage=" & objDiagnostic.pulverisateurIsCuveRincage & ""
                If Not objDiagnostic.pulverisateurCapaciteCuveRincage Is Nothing And objDiagnostic.pulverisateurCapaciteCuveRincage <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurCapaciteCuveRincage='" & CSDb.secureString(objDiagnostic.pulverisateurCapaciteCuveRincage) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsRotobuse=" & objDiagnostic.pulverisateurIsRotobuse & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsRinceBidon=" & objDiagnostic.pulverisateurIsRinceBidon & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsBidonLaveMain=" & objDiagnostic.pulverisateurIsBidonLaveMain & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsLanceLavageExterieur=" & objDiagnostic.pulverisateurIsLanceLavageExterieur & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurIsCuveIncorporation=" & objDiagnostic.pulverisateurIsCuveIncorporation & ""
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurCategorie='" & CSDb.secureString(objDiagnostic.pulverisateurCategorie) & "'"
                If Not objDiagnostic.pulverisateurAttelage Is Nothing And objDiagnostic.pulverisateurAttelage <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurAttelage='" & CSDb.secureString(objDiagnostic.pulverisateurAttelage) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurRegulation='" & CSDb.secureString(objDiagnostic.pulverisateurRegulation) & "'"
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurRegulationOptions='" & CSDb.secureString(objDiagnostic.pulverisateurRegulationOptions) & "'"
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurPulverisation='" & CSDb.secureString(objDiagnostic.pulverisateurPulverisation) & "'"
                If Not objDiagnostic.pulverisateurAutresAccessoires Is Nothing And objDiagnostic.pulverisateurAutresAccessoires <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurAutresAccessoires='" & CSDb.secureString(objDiagnostic.pulverisateurAutresAccessoires) & "'"
                End If
                If Not objDiagnostic.pulverisateurEmplacementIdentification Is Nothing And objDiagnostic.pulverisateurEmplacementIdentification <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.pulverisateurEmplacementIdentification='" & CSDb.secureString(objDiagnostic.pulverisateurEmplacementIdentification) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurModeUtilisation='" & CSDb.secureString(objDiagnostic.pulverisateurModeUtilisation) & "'"
                paramsQuery = paramsQuery & " , Diagnostic.pulverisateurNbreExploitants='" & CSDb.secureString(objDiagnostic.pulverisateurNbreExploitants) & "'"
                If Not objDiagnostic.buseMarque Is Nothing And objDiagnostic.buseMarque <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseMarque='" & CSDb.secureString(objDiagnostic.buseMarque) & "'"
                End If
                If Not objDiagnostic.buseModele Is Nothing And objDiagnostic.buseModele <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseModele='" & CSDb.secureString(objDiagnostic.buseModele) & "'"
                End If
                If Not objDiagnostic.buseCouleur Is Nothing And objDiagnostic.buseCouleur <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseCouleur='" & CSDb.secureString(objDiagnostic.buseCouleur) & "'"
                End If
                If Not objDiagnostic.buseGenre Is Nothing And objDiagnostic.buseGenre <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseGenre='" & CSDb.secureString(objDiagnostic.buseGenre) & "'"
                End If
                If Not objDiagnostic.buseCalibre Is Nothing And objDiagnostic.buseCalibre <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseCalibre='" & CSDb.secureString(objDiagnostic.buseCalibre) & "'"
                End If
                If Not objDiagnostic.buseDebit Is Nothing And objDiagnostic.buseDebit <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseDebit='" & CSDb.secureString(objDiagnostic.buseDebit) & "'"
                End If
                If Not objDiagnostic.buseDebit2bars Is Nothing And objDiagnostic.buseDebit2bars <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseDebit2bars='" & CSDb.secureString(objDiagnostic.buseDebit2bars) & "'"
                End If
                If Not objDiagnostic.buseDebit3bars Is Nothing And objDiagnostic.buseDebit3bars <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseDebit3bars='" & CSDb.secureString(objDiagnostic.buseDebit3bars) & "'"
                End If
                If Not objDiagnostic.buseAge Is Nothing And objDiagnostic.buseAge <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseAge='" & CSDb.secureString(objDiagnostic.buseAge) & "'"
                End If
                If Not objDiagnostic.buseNbBuses Is Nothing And objDiagnostic.buseNbBuses <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseNbBuses='" & CSDb.secureString(objDiagnostic.buseNbBuses) & "'"
                End If
                If Not objDiagnostic.buseType Is Nothing And objDiagnostic.buseType <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseType='" & CSDb.secureString(objDiagnostic.buseType) & "'"
                End If
                If Not objDiagnostic.buseAngle Is Nothing And objDiagnostic.buseAngle <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.buseAngle='" & CSDb.secureString(objDiagnostic.buseAngle) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.buseFonctionnement='" & CSDb.secureString(objDiagnostic.buseFonctionnement) & "'"
                '                paramsQuery = paramsQuery & " , Diagnostic.buseFonctionnementIsStandard=" & objDiagnostic.buseFonctionnementIsStandard & ""
                '                paramsQuery = paramsQuery & " , Diagnostic.buseFonctionnementIsPastilleChambre=" & objDiagnostic.buseFonctionnementIsPastilleChambre & ""
                '               paramsQuery = paramsQuery & " , Diagnostic.buseFonctionnementIsInjectionAirLibre=" & objDiagnostic.buseFonctionnementIsInjectionAirLibre & ""
                '              paramsQuery = paramsQuery & " , Diagnostic.buseFonctionnementIsInjectionAirForce=" & objDiagnostic.buseFonctionnementIsInjectionAirForce & ""
                paramsQuery = paramsQuery & " , Diagnostic.buseIsISO=" & objDiagnostic.buseIsISO & ""
                If Not objDiagnostic.manometreMarque Is Nothing And objDiagnostic.manometreMarque <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.manometreMarque='" & CSDb.secureString(objDiagnostic.manometreMarque) & "'"
                End If
                If Not objDiagnostic.manometreDiametre Is Nothing And objDiagnostic.manometreDiametre <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.manometreDiametre='" & CSDb.secureString(objDiagnostic.manometreDiametre) & "'"
                End If
                If Not objDiagnostic.manometreType Is Nothing And objDiagnostic.manometreType <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.manometreType='" & CSDb.secureString(objDiagnostic.manometreType) & "'"
                End If
                If Not objDiagnostic.manometreFondEchelle Is Nothing And objDiagnostic.manometreFondEchelle <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.manometreFondEchelle='" & CSDb.secureString(objDiagnostic.manometreFondEchelle) & "'"
                End If
                If Not objDiagnostic.manometrePressionTravail Is Nothing And objDiagnostic.manometrePressionTravail <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.manometrePressionTravail='" & CSDb.secureString(objDiagnostic.manometrePressionTravail) & "'"
                End If
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsGrandeCulture=" & objDiagnostic.exploitationTypeCultureIsGrandeCulture & ""
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsLegume=" & objDiagnostic.exploitationTypeCultureIsLegume & ""
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsElevage=" & objDiagnostic.exploitationTypeCultureIsElevage & ""
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsArboriculture=" & objDiagnostic.exploitationTypeCultureIsArboriculture & ""
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsViticulture=" & objDiagnostic.exploitationTypeCultureIsViticulture & ""
                paramsQuery = paramsQuery & " , Diagnostic.exploitationTypeCultureIsAutres=" & objDiagnostic.exploitationTypeCultureIsAutres & ""
                If Not objDiagnostic.exploitationSau Is Nothing And objDiagnostic.exploitationSau <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.exploitationSau='" & CSDb.secureString(objDiagnostic.exploitationSau) & "'"
                End If
                If Not objDiagnostic.dateModificationAgent Is Nothing And objDiagnostic.dateModificationAgent <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.dateModificationAgent='" & CSDb.secureString(objDiagnostic.dateModificationAgent) & "'"
                End If
                If Not objDiagnostic.dateModificationCrodip Is Nothing And objDiagnostic.dateModificationCrodip <> "" Then
                    paramsQuery = paramsQuery & " , Diagnostic.dateModificationCrodip='" & CSDb.secureString(objDiagnostic.dateModificationCrodip) & "'"
                End If

                'On scinde la requete en 2 car elle est trop longue sinon
                If Not objDiagnostic.dateSynchro Is Nothing And objDiagnostic.dateSynchro <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.dateSynchro='" & CSDb.secureString(objDiagnostic.dateSynchro) & "'"
                End If
                If Not objDiagnostic.syntheseErreurMoyenneMano Is Nothing And objDiagnostic.syntheseErreurMoyenneMano <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseErreurMoyenneMano='" & CSDb.secureString(objDiagnostic.syntheseErreurMoyenneMano) & "'"
                End If
                If Not objDiagnostic.syntheseErreurMaxiMano Is Nothing And objDiagnostic.syntheseErreurMaxiMano <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseErreurMaxiMano='" & CSDb.secureString(objDiagnostic.syntheseErreurMaxiMano) & "'"
                End If
                If Not objDiagnostic.syntheseErreurDebitmetre Is Nothing And objDiagnostic.syntheseErreurDebitmetre <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseErreurDebitmetre='" & CSDb.secureString(objDiagnostic.syntheseErreurDebitmetre) & "'"
                End If
                If Not objDiagnostic.syntheseErreurMoyenneCinemometre Is Nothing And objDiagnostic.syntheseErreurMoyenneCinemometre <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseErreurMoyenneCinemometre='" & CSDb.secureString(objDiagnostic.syntheseErreurMoyenneCinemometre) & "'"
                End If
                If Not objDiagnostic.syntheseUsureMoyenneBuses Is Nothing And objDiagnostic.syntheseUsureMoyenneBuses <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseUsureMoyenneBuses='" & CSDb.secureString(objDiagnostic.syntheseUsureMoyenneBuses) & "'"
                End If
                If Not objDiagnostic.syntheseNbBusesUsees Is Nothing And objDiagnostic.syntheseNbBusesUsees <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.syntheseNbBusesUsees='" & CSDb.secureString(objDiagnostic.syntheseNbBusesUsees) & "'"
                End If
                If Not objDiagnostic.synthesePerteChargeMoyenne Is Nothing And objDiagnostic.synthesePerteChargeMoyenne <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.synthesePerteChargeMoyenne='" & CSDb.secureString(objDiagnostic.synthesePerteChargeMoyenne) & "'"
                End If
                If Not objDiagnostic.synthesePerteChargeMaxi Is Nothing And objDiagnostic.synthesePerteChargeMaxi <> "" Then
                    paramsQuery2 = paramsQuery2 & " , Diagnostic.synthesePerteChargeMaxi='" & CSDb.secureString(objDiagnostic.synthesePerteChargeMaxi) & "'"
                End If
                paramsQuery2 = paramsQuery2 & " , Diagnostic.isSynchro=" & objDiagnostic.isSynchro & ""
                paramsQuery2 = paramsQuery2 & " , Diagnostic.isATGIP=" & objDiagnostic.isATGIP & ""
                paramsQuery2 = paramsQuery2 & " , Diagnostic.isTGIP=" & objDiagnostic.isTGIP & ""
                paramsQuery2 = paramsQuery2 & " , Diagnostic.isFacture=" & objDiagnostic.isFacture & ""
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleBancMesureId='" & objDiagnostic.controleBancMesureId & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleUseCalibrateur=" & objDiagnostic.controleUseCalibrateur & ""
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleNbreNiveaux='" & objDiagnostic.controleNbreNiveaux & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleNbreTroncons='" & objDiagnostic.controleNbreTroncons & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleManoControleNumNational='" & objDiagnostic.controleManoControleNumNational & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.controleInitialId='" & objDiagnostic.controleInitialId & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurAncienId='" & objDiagnostic.pulverisateurAncienId & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.RIFileName='" & CSDb.secureString(objDiagnostic.RIFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.SMFileName='" & CSDb.secureString(objDiagnostic.SMFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.CCFileName='" & CSDb.secureString(objDiagnostic.CCFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurCoupureAutoTroncons='" & CSDb.secureString(objDiagnostic.pulverisateurCoupureAutoTroncons) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurReglageAutoHauteur='" & CSDb.secureString(objDiagnostic.pulverisateurReglageAutoHauteur) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurRincagecircuit='" & CSDb.secureString(objDiagnostic.pulverisateurRincagecircuit) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.typeDiagnostic='" & CSDb.secureString(objDiagnostic.typeDiagnostic) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.codeInsee='" & CSDb.secureString(objDiagnostic.codeInsee) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.commentaire='" & CSDb.secureString(objDiagnostic.Commentaire) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurNumNational='" & CSDb.secureString(objDiagnostic.pulverisateurNumNational) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.pulverisateurNumChassis='" & CSDb.secureString(objDiagnostic.pulverisateurNumChassis) & "'"
                paramsQuery2 = paramsQuery2 & " , Diagnostic.OrigineDiag='" & CSDb.secureString(objDiagnostic.origineDiag) & "'"

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE Diagnostic SET " & paramsQuery & " WHERE Diagnostic.id='" & objDiagnostic.id & "'"
                'CSDebug.dispInfo("DiagnosticManager::save (query) : " & bddCommande.CommandText)
                bddCommande.ExecuteNonQuery()
                bddCommande.CommandText = "UPDATE Diagnostic SET " & paramsQuery2 & " WHERE Diagnostic.id='" & objDiagnostic.id & "'"
                'CSDebug.dispInfo("DiagnosticManager::save (query) : " & bddCommande.CommandText)
                bddCommande.ExecuteNonQuery()

                CSDb.free()

                ' On enregistre les items du diag
                '                CSDebug.dispInfo("Sauvegarde des DiagItem")

                SaveDiagItems(objDiagnostic, bcreationDiag)


                'Sauvegarde des Help 551 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp551.HasValue() Then
                    objDiagnostic.diagnosticHelp551.idDiag = objDiagnostic.id
                    DiagnosticHelp551Manager.save(objDiagnostic.diagnosticHelp551, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If
                'Sauvegarde des Help 12323 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp12323.HasValue() Then
                    objDiagnostic.diagnosticHelp12323.idDiag = objDiagnostic.id
                    DiagnosticHelp551Manager.save(objDiagnostic.diagnosticHelp12323, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 5621 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp5621.HasValue() Then
                    objDiagnostic.diagnosticHelp5621.idDiag = objDiagnostic.id
                    DiagnosticHelp5621Manager.save(objDiagnostic.diagnosticHelp5621, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 552 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp552.hasValue() Then
                    objDiagnostic.diagnosticHelp552.idDiag = objDiagnostic.id
                    DiagnosticHelp552Manager.save(objDiagnostic.diagnosticHelp552, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 5622 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp5622.hasValue() Then
                    objDiagnostic.diagnosticHelp5622.idDiag = objDiagnostic.id
                    DiagnosticHelp5622Manager.save(objDiagnostic.diagnosticHelp5622, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 811 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp811.hasValue() Then
                    objDiagnostic.diagnosticHelp811.idDiag = objDiagnostic.id
                    DiagnosticHelp811Manager.save(objDiagnostic.diagnosticHelp811, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 831 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp8312.hasValue() Then
                    objDiagnostic.diagnosticHelp8312.idDiag = objDiagnostic.id
                    DiagnosticHelp831Manager.save(objDiagnostic.diagnosticHelp8312, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If
                If objDiagnostic.diagnosticHelp8314.hasValue() Then
                    objDiagnostic.diagnosticHelp8314.idDiag = objDiagnostic.id
                    DiagnosticHelp831Manager.save(objDiagnostic.diagnosticHelp8314, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                'Sauvegarde des Help 571 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp571.hasValue() Then
                    objDiagnostic.diagnosticHelp571.idDiag = objDiagnostic.id
                    DiagnosticHelp571Manager.save(objDiagnostic.diagnosticHelp571, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If
                'Sauvegarde des Help 12123 (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticHelp12123.hasValue() Then
                    objDiagnostic.diagnosticHelp12123.idDiag = objDiagnostic.id
                    DiagnosticHelp12123Manager.save(objDiagnostic.diagnosticHelp12123, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If
                'Sauvegarde des InfosComplementaires (Si on a des valeurs pertinentes)
                If objDiagnostic.diagnosticInfosComplementaires.hasValue() Then
                    objDiagnostic.diagnosticInfosComplementaires.idDiag = objDiagnostic.id
                    DiagnosticInfosComplementaireManager.save(objDiagnostic.diagnosticInfosComplementaires, objDiagnostic.organismePresId, objDiagnostic.inspecteurId)
                End If

                ' On enregistre les buses
                'CSDebug.dispInfo("Sauvegarde des buses")
                If Not objDiagnostic.diagnosticBusesList Is Nothing Then
                    If Not objDiagnostic.diagnosticBusesList.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticBuses In objDiagnostic.diagnosticBusesList.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = objDiagnostic.id
                                DiagnosticBusesManager.save(tmpItemCheck)
                            End If
                        Next
                    End If
                End If

                ' On enregistre les mano 5.4.2
                'CSDebug.dispInfo("Sauvegarde des Mano542")
                If Not objDiagnostic.diagnosticMano542List Is Nothing Then
                    If Not objDiagnostic.diagnosticMano542List.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticMano542 In objDiagnostic.diagnosticMano542List.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = objDiagnostic.id
                                DiagnosticMano542Manager.save(tmpItemCheck)
                            End If
                        Next
                    End If
                End If

                ' On enregistre les tronçons 8.3.3
                'CSDebug.dispInfo("Sauvegarde des Tronçons833")
                If Not objDiagnostic.diagnosticTroncons833 Is Nothing Then
                    If Not objDiagnostic.diagnosticTroncons833.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticTroncons833 In objDiagnostic.diagnosticTroncons833.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = objDiagnostic.id
                                'Par sécurité on recalcule les idPressions car certains diag on des id = 5,6,7,8
                                If tmpItemCheck.idPression > 4 Then
                                    tmpItemCheck.idPression = (tmpItemCheck.idPression Mod 4)
                                    If tmpItemCheck.idPression = 0 Then
                                        tmpItemCheck.idPression = 4
                                    End If
                                End If
                                DiagnosticTroncons833Manager.save(tmpItemCheck, bsyncro)
                            End If
                        Next
                    End If
                End If

            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager(" & objDiagnostic.id & ")::save : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function SaveDiagItems(ByVal pDiagnostic As Diagnostic, ByVal bcreationDiag As Boolean, Optional bsynchro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCsdb As New CSDb(True)
            Dim tmpNewDiagItemId As String = ""
            'Pour accellérer la sauvegarde en création on récupère le nouvel id des diagItem et on l'incrémentera au fur et à mesure
            If bcreationDiag Then
                tmpNewDiagItemId = DiagnosticItemManager.getNewId(pDiagnostic.organismePresId, pDiagnostic.inspecteurId)
            End If
            If Not pDiagnostic.diagnosticItemsLst Is Nothing Then
                If Not pDiagnostic.diagnosticItemsLst.items Is Nothing Then
                    For Each tmpItemCheck As DiagnosticItem In pDiagnostic.diagnosticItemsLst.items
                        If Not tmpItemCheck Is Nothing Then
                            tmpItemCheck.idDiagnostic = pDiagnostic.id
                            If bcreationDiag Then
                                tmpItemCheck.id = tmpNewDiagItemId
                                DiagnosticItemManager.create(tmpItemCheck)
                                tmpNewDiagItemId = DiagnosticItemManager.incId(tmpNewDiagItemId)
                            Else
                                'Si on est en upgrade de diag il ne faut pas forcement créer des DiagItem
                                DiagnosticItemManager.save(oCsdb, tmpItemCheck, bsynchro)
                            End If
                        End If
                    Next
                End If
            End If
            oCsdb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.SaveDiagItems ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Sub setSynchro(ByVal objDiagnostic As Diagnostic)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `Diagnostic` SET `Diagnostic`.`dateModificationCrodip`='" & newDate & "',`Diagnostic`.`dateModificationAgent`='" & newDate & "' WHERE `Diagnostic`.`id`='" & objDiagnostic.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager::setSynchro : " & ex.Message)
        End Try
    End Sub


#End Region
    Public Shared Function delete(ByVal pDiagnosticId As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticId), "Diagnostic.id doit être inialisé")
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As OleDbCommand
        Dim nResult As Integer
        bReturn = False
        Try
            ' On test si le Diagnostic existe ou non
            Dim existsDiagnostic As Diagnostic
            existsDiagnostic = DiagnosticManager.getDiagnosticById(pDiagnosticId)
            If Not String.IsNullOrEmpty(existsDiagnostic.id) Then

                'Suppression des SubItems
                DiagnosticBusesManager.deleteByDiagnosticId(pDiagnosticId)
                DiagnosticMano542Manager.deleteByDiagnosticID(pDiagnosticId)
                DiagnosticTroncons833Manager.deleteByDiagnosticID(pDiagnosticId)
                DiagnosticItemManager.deleteByDiagnosticID(pDiagnosticId)

                'Les DiagHelp551 sont supprimés en même temps que les diagItems

                oCsDb = New CSDb(True)
                bddCommande = oCsDb.getConnection().CreateCommand()
                bddCommande.CommandText = "DELETE from Diagnostic WHERE Diagnostic.id='" & pDiagnosticId & "'"
                nResult = bddCommande.ExecuteReader().RecordsAffected
                'Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager.delete(" & pDiagnosticId & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsDb Is Nothing Then
            oCsDb.free()
        End If
        Return bReturn
    End Function 'delete
    Public Shared Function getCount(ByVal pAgent As Agent) As Integer
        Debug.Assert(pAgent IsNot Nothing)
        ' déclarations
        Dim nDiag As Integer = 0
        Dim oCSDb As New CSDb(True)
        Try
            nDiag = oCSDb.getValue("Select count(*) from Diagnostic Where InspecteurId=" & pAgent.id)
        Catch ex As Exception ' On intercepte l'erreur
            nDiag = 0
            CSDebug.dispError("DiagnosticManager.getDiagnosticByPulveId ERR:" & ex.Message)
        End Try
        ' Test pour fermeture de connection BDD
        oCSDb.free()
        Return nDiag
    End Function

End Class
