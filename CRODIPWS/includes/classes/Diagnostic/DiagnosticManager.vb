Imports System.Collections.Generic
Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Xml.Serialization

Public Class DiagnosticManager
    Inherits CrodipManager

#Region "Methodes acces Web Service"
    Public Shared Function WSgetById(puidagent As Integer, ByVal p_uid As Integer, paid As String) As Diagnostic
        Dim oreturn As Diagnostic = Nothing
        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Try
            Dim tXmlnodes As Xml.XmlNode()
            '' déclarations
            Dim typeT As Type = GetType(Diagnostic)
            Dim nomMethode As String = "Get" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            Dim codeResponse As Integer = 99 'Mehode non trouvée
            If methode IsNot Nothing Then
                Dim Params As Object() = {puidagent, p_uid, paid, tXmlnodes}
                codeResponse = methode.Invoke(objWSCrodip, Params)
                tXmlnodes = Params(3)
            End If
            Select Case codeResponse
                Case 0 ' OK
                    Dim ser As New XmlSerializer(GetType(Diagnostic))
                    Using reader As New StringReader(tXmlnodes(0).ParentNode.OuterXml)
                        oreturn = ser.Deserialize(reader)
                    End Using
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

    Public Shared Function WSSend(ByVal pObjIn As Diagnostic, ByRef pobjOut As Diagnostic) As Integer
        Dim oreturn As Diagnostic = Nothing
        Dim codeResponse As Integer = 99
        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Try
            Dim pInfo As String = ""
            Dim puid As Integer

            'Determination du Nom de la méthode : exemple SendManometreControle
            Dim typeT As Type = GetType(Diagnostic)
            Dim nomMethode As String = "Send" & typeT.Name
            Dim methode = objWSCrodip.GetType().GetMethod(nomMethode)
            If methode IsNot Nothing Then
                'Invocation de la méthode
                Dim serializer As New XmlSerializer(pObjIn.GetType())
                Using writer As New StringWriter()
                    serializer.Serialize(writer, pObjIn)
                    Dim xmlOutput As String = writer.ToString()
                    ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
                    CSDebug.dispTrace("WS-" & nomMethode & " Param = [" & xmlOutput & "]")
                End Using

                Dim Params As Object() = {pObjIn, pInfo, puid}
                codeResponse = methode.Invoke(objWSCrodip, Params)
                pInfo = DirectCast(Params(1), String)
                puid = DirectCast(Params(2), Integer)
                CSDebug.dispTrace("WS-" & nomMethode & " Return = codeReponse=" & codeResponse & "[ info=" & pInfo & ",uid=" & puid & "]")
            End If
            Select Case codeResponse
                Case 2 ' UPDATE OK
                    pobjOut = WSgetById(0, puid, CType(pObjIn, root).aid)
                Case 4 ' CREATE OK
                    pobjOut = WSgetById(0, puid, CType(pObjIn, root).aid)
                Case 1 ' NOK
                    CSDebug.dispError("SendWS - Code 1 : Erreur Base de données Serveur")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("SendWS - Code 9 : Mauvaise Requete")
                Case 0 ' PAS DE MAJ
            End Select
        Catch ex As Exception
            CSDebug.dispError("RootManager - sendWS : ", ex)
        Finally
        End Try
        Return codeResponse

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
        ''Récupération des PDFS avant Synhcro
        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.RIFileName)
        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.SMFileName)
        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.CCFileName)
        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.BLFileName)
        EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.ESFileName)
        If Not String.IsNullOrEmpty(pDiag.COPROFileName) Then
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC, pDiag.COPROFileName)
        End If
        For Each FileName As String In pDiag.FACTFileNames.Split(";")
            EtatCrodip.getPDFs(GlobalsCRODIP.CONST_PATH_EXP_FACTURE, FileName)
        Next
        bReturn = SendHTTPEtats(pDiag)
        Return bReturn
    End Function


    Friend Shared Function SendHTTPEtats(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim uri As New Uri(objWSCrodip.Url.Replace("/server", "") & My.Settings.SynchroEtatDiagUrl)
            Dim Credential As New System.Net.NetworkCredential(My.Settings.SynchroEtatDiagUser, My.Settings.SynhcroEtatDiagPwd)
            Dim filePath As String
            If Not String.IsNullOrEmpty(pDiag.RIFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.SMFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.CCFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.BLFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.BLFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.ESFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.ESFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.COPROFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.COPROFileName
                If System.IO.File.Exists(filePath) Then
                    My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                    SynchronisationManager.LogSynchroElmt(filePath)
                End If
            End If
            If Not String.IsNullOrEmpty(pDiag.FACTFileNames) Then
                For Each Filename As String In pDiag.FACTFileNames.Split(";")
                    filePath = GlobalsCRODIP.CONST_PATH_EXP_FACTURE & "/" & Filename
                    If System.IO.File.Exists(filePath) Then
                        My.Computer.Network.UploadFile(filePath, uri, Credential, False, 100000)
                        SynchronisationManager.LogSynchroElmt(filePath)
                    End If
                Next
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
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.RIFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = oCSftp.DownLoad(pDiag.RIFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/")
            End If
            If Not String.IsNullOrEmpty(pDiag.SMFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.SMFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = bReturn And oCSftp.DownLoad(pDiag.SMFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/")
            End If
            If Not String.IsNullOrEmpty(pDiag.CCFileName) Then
                filePath = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/" & pDiag.CCFileName
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                bReturn = bReturn And oCSftp.DownLoad(pDiag.CCFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & "/")
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.GetFTPEtats ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Shared Function GetWSEtat(pDiagId As String, pfileName As String, pDossierStockage As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim url As String = objWSCrodip.Url
            Dim Credential As New System.Net.NetworkCredential(My.Settings.SynchroEtatDiagUser, My.Settings.SynhcroEtatDiagPwd)
            Dim filePath As String
            filePath = pDossierStockage & "/" & pfileName
            If Not String.IsNullOrEmpty(pfileName) Then
                If System.IO.File.Exists(filePath) Then
                    System.IO.File.Delete(filePath)
                End If
                Dim uri As New Uri(WebServiceCRODIP.URL & "/../pdf/" & pfileName)
                '                My.Computer.Network.DownloadFile(uri, filePath, Credential, False, 100000, True)
                Using Wc As WebClient = New WebClient()
                    '                    Wc.Headers.Add("User-Agent:crodip")
                    '                   Wc.Headers.Add("User-password:crodip35")
                    Wc.Credentials = Credential
                    Wc.DownloadFile(uri, filePath)
                End Using
            End If
            bReturn = IO.File.Exists(filePath)
            'Recopie dans le Répertoire de stock
            If IO.File.Exists(filePath) Then
                System.IO.File.Copy(filePath, GlobalsCRODIP.CONST_STOCK_PDFS & "\" & filePath)
                bReturn = True
            End If

        Catch ex As Exception

            CSDebug.dispError("diagnosticManager.WSGetEtat ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsRI(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.RIFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)

        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsRI ERR : (" & WebServiceCRODIP.URL & "/../admin/diagnostic/get-pdf-view?id=" & pDiag.id & ")" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsSM(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.SMFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsSM ERR : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsCC(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.CCFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsRI ERR :", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsBL(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.BLFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsBL ERR :", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsES(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.ESFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsES ERR :", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsCOPRO(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            bReturn = GetWSEtat(pDiag.id, pDiag.COPROFileName, GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsCOPRO ERR :", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getWSEtatsFACTs(pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = True
            Dim filenames As String = pDiag.FACTFileNames
            Dim tab As String() = filenames.Split(";")
            For Each filename As String In tab
                bReturn = GetWSEtat(pDiag.id, filename, GlobalsCRODIP.CONST_PATH_EXP_FACTURE)
            Next
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.getWSEtatsFACTs ERR :", ex)
            bReturn = False
        End Try
        Return bReturn
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
                Dim bddCommande As DbCommand
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "SELECT * FROM Diagnostic WHERE Diagnostic.id='" & pdiag.id & "'"
                DebugStep = "2"
                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
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

                    LoadDiagnosticAttributes(oCsdb, pdiag)
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

    Protected Shared Function LoadDiagnosticAttributes(oCSDB As CSDb, pDiag As Diagnostic) As Boolean
        Dim DebugStep As String
        Dim bReturn As Boolean = True
        Try

            '########################################
            ' On récupère les items du diagnostic
            '########################################
            DiagnosticItemManager.getDiagnosticItemByDiagnosticId(oCSDB, pDiag)
            DebugStep = "8"

            '########################################
            ' On récupère les mesures help551
            '########################################
            pDiag.diagnosticHelp551 = DiagnosticHelp551Manager.getDiagnosticHelp551ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9"
            pDiag.diagnosticHelp5621 = DiagnosticHelp5621Manager.getDiagnosticHelp5621ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9.5621"
            pDiag.diagnosticHelp12323 = DiagnosticHelp551Manager.getDiagnosticHelp12323ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9.12323"

            '########################################
            ' On récupère les mesures help552
            '########################################
            pDiag.diagnosticHelp552 = DiagnosticHelp552Manager.getDiagnosticHelp552ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9.552"

            '########################################
            ' On récupère les mesures help5622
            '########################################
            pDiag.diagnosticHelp5622 = DiagnosticHelp5622Manager.getDiagnosticHelp5622ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9.5622"

            '########################################
            ' On récupère les mesures help811
            '########################################
            pDiag.diagnosticHelp811 = DiagnosticHelp811Manager.getDiagnosticHelp811ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9.811"
            '########################################
            ' On récupère les mesures help831
            '########################################
            pDiag.diagnosticHelp8312 = DiagnosticHelp831Manager.getDiagnosticHelp8312ByDiagnosticId(oCSDB, pDiag)
            pDiag.diagnosticHelp8314 = DiagnosticHelp831Manager.getDiagnosticHelp8314ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "8.831"
            '########################################
            ' On récupère les mesures help571
            '########################################
            pDiag.diagnosticHelp571 = DiagnosticHelp571Manager.getDiagnosticHelp571ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "8.831"
            '########################################
            ' On récupère les mesures help12123
            '########################################
            pDiag.diagnosticHelp12123 = DiagnosticHelp12123Manager.getDiagnosticHelp12123ByDiagnosticId(oCSDB, pDiag)
            DebugStep = "8.12123"
            '########################################
            ' On récupère les infosComplémentaires
            '########################################
            pDiag.diagnosticInfosComplementaires = DiagnosticInfosComplementaireManager.getDiagnosticInfosComplementairesByDiagnosticId(oCSDB, pDiag)
            DebugStep = "9."
            '#########################################################
            ' On récupère les diagnosticBuses et DiagnosticBusesDetail
            '#########################################################
            DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(oCSDB, pDiag)

            '#########################################################
            ' On récupère les diagnosticMano542
            '#########################################################

            Dim bddCommande5 As DbCommand
            bddCommande5 = oCSDB.getConnection().CreateCommand
            bddCommande5.CommandText = "SELECT * FROM DiagnosticMano542 WHERE DiagnosticMano542.idDiagnostic='" & pDiag.id & "' ORDER BY id"
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande5.ExecuteReader
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
            Dim bddCommande6 As DbCommand
            bddCommande6 = oCSDB.getConnection().CreateCommand
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
                'Calcul du numero de niveau et numero de trançon à partir de la col
                tmpDiagnosticTroncons833.CalcNiveauTroncons(pDiag.controleNbreTroncons)
                pDiag.diagnosticTroncons833.Liste.Add(tmpDiagnosticTroncons833)
            End While
            DebugStep = "22"
            oDataReader.Close()
            DebugStep = "23"




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
            Dim strSQL As String
            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                strSQL = " Diagnostic.controleDateFin >= '" & CSDate.ToCRODIPString(DateLimite) & "'"
            Else
                strSQL = " Diagnostic.controleDateFin >= #" & DateLimite.ToString("MM/dd/yyyy") & "#"

            End If
            'query = "SELECT DISTINCT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic,diagnosticItem WHERE diagnosticItem.idDiagnostic = Diagnostic.id and  Diagnostic.controleEtat='0' AND Diagnostic.pulverisateurId='" & pPulveId & "' AND Diagnostic.organismePresId=" & pStructureId & " AND " & strSQL
            query = "SELECT DISTINCT Diagnostic.id,Diagnostic.controleDateFin,Diagnostic.controleEtat FROM Diagnostic WHERE Diagnostic.controleEtat='0' AND Diagnostic.pulverisateurId='" & pPulveId & "' AND Diagnostic.organismePresId=" & pStructureId
            query = query & " AND " & strSQL
            If Not String.IsNullOrEmpty(pdiagnosticID) Then
                query = query & " AND Diagnostic.id LIKE '" & pdiagnosticID & "%'"
            End If
            query = query & " ORDER BY Diagnostic.controleDateFin DESC"
            Dim bdd As New CSDb(True)
            Dim dataResults As DbDataReader = bdd.getResult2s(query)
            Dim i As String = 0
            colDiag.Clear()
            While dataResults.Read()
                oDiag = New Diagnostic()
                oDiag.organismePresId = pStructureId
                oDiag.pulverisateurId = pPulveId
                oDiag.id = Trim(dataResults.Item(0).ToString)
                oDiag.controleDateFin = CSDate.ToCRODIPString(Trim(dataResults.Item(1).ToString))
                oDiag.controleEtat = dataResults.Item(2).ToString
                colDiag.Add(oDiag)
            End While
            dataResults.Close()
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
        Dim bddCommande As DbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Diagnostic  WHERE Pulverisateurid='" & pulverisateur_id & "' ORDER BY controleDateDebut DESC"
        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
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
    Public Shared Function getlstDiagnostic(pStructureID As String) As List(Of Diagnostic)
        ' déclarations
        Dim lstDiag As New List(Of Diagnostic)
        Dim bddCommande As DbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT ID,dateModificationAgent,dateModificationCrodip,dateSynchro, RIFileName,SMFileName,CCFileName, controleDateDebut FROM Diagnostic  WHERE OrganismePresId = " & pStructureID & ""
        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
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
        Dim bddCommande As DbCommand
        Dim oCSDb As New CSDb(True)
        bddCommande = oCSDb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Diagnostic  WHERE proprietaireId='" & exploitation_id & "' ORDER BY controleDateDebut DESC"
        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
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
        Dim bddCommande As DbCommand
        Dim oCsdb As New CSDb(True)
        ' On test si la connexion est déjà ouverte ou non
        bddCommande = oCsdb.getConnection().CreateCommand
        '        bddCommande.CommandText = "SELECT * FROM Diagnostic WHERE Diagnostic.dateModificationAgent<>Diagnostic.dateModificationCrodip AND Diagnostic.inspecteurId=" & agent.id
        bddCommande.CommandText = "Select Diagnostic.* From Diagnostic INNER Join Agent On Diagnostic.inspecteurId = Agent.Id Where Agent.idStructure = " & pAgent.uidStructure
        bddCommande.CommandText = bddCommande.CommandText & " AND (Diagnostic.dateModificationAgent<>Diagnostic.dateModificationCrodip OR Diagnostic.dateModificationCrodip is null)"
        Try
            ' On récupère les résultats
            Dim oDRDiagnostic As DbDataReader = bddCommande.ExecuteReader
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
                DiagnosticItemManager.getDiagnosticItemByDiagnosticId(oCsdb, oDiagnostic)

                '########################################
                ' On récupère les mesures help551
                '########################################
                oDiagnostic.diagnosticHelp551 = DiagnosticHelp551Manager.getDiagnosticHelp551ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp551.HasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp551AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help5621
                '########################################
                oDiagnostic.diagnosticHelp5621 = DiagnosticHelp5621Manager.getDiagnosticHelp5621ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp5621.HasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp5621AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help552
                '########################################
                oDiagnostic.diagnosticHelp552 = DiagnosticHelp552Manager.getDiagnosticHelp552ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp552.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp552AsDiagItem())
                End If
                ' On récupère les buses du diagnostic
                DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(oCsdb, oDiagnostic)

                '########################################
                ' On récupère les mesures help5622
                '########################################
                oDiagnostic.diagnosticHelp5622 = DiagnosticHelp5622Manager.getDiagnosticHelp5622ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp5622.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp5622AsDiagItem())
                End If

                '########################################
                ' On récupère les mesures help811
                '########################################
                oDiagnostic.diagnosticHelp811 = DiagnosticHelp811Manager.getDiagnosticHelp811ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp811.hasValue() Then
                    'Ajout de l'help dans la liste des diagItems
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp811AsDiagItem())
                End If
                '########################################
                ' On récupère les mesures help831
                '########################################
                oDiagnostic.diagnosticHelp8312 = DiagnosticHelp831Manager.getDiagnosticHelp8312ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp8312.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp8312AsDiagItem())
                End If
                oDiagnostic.diagnosticHelp8314 = DiagnosticHelp831Manager.getDiagnosticHelp8314ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp8314.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp8314AsDiagItem())
                End If
                oDiagnostic.diagnosticHelp571 = DiagnosticHelp571Manager.getDiagnosticHelp571ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp571.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp571.ConvertToDiagnosticItem())
                End If
                oDiagnostic.diagnosticHelp12123 = DiagnosticHelp12123Manager.getDiagnosticHelp12123ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp12123.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp12123.ConvertToDiagnosticItem())
                End If
                oDiagnostic.diagnosticHelp12323 = DiagnosticHelp551Manager.getDiagnosticHelp12323ByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticHelp12323.HasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticHelp12323.ConvertToDiagnosticItem())
                End If
                '########################################
                ' On récupère les infos complémentaire
                '########################################
                oDiagnostic.diagnosticInfosComplementaires = DiagnosticInfosComplementaireManager.getDiagnosticInfosComplementairesByDiagnosticId(oCsdb, oDiagnostic)
                If oDiagnostic.diagnosticInfosComplementaires.hasValue() Then
                    oDiagnostic.AdOrReplaceDiagItem(oDiagnostic.diagnosticInfosComplementairesAsDiagItem())
                End If

                '##################################################################################################################

                ' On récupère les mesures des mano
                Dim bddCommande5 As DbCommand
                bddCommande5 = oCsdb.getConnection().CreateCommand()
                bddCommande5.CommandText = "SELECT * FROM DiagnosticMano542 WHERE DiagnosticMano542.idDiagnostic='" & oDiagnostic.id & "'"
                ' On récupère les résultats
                Dim oDRDiagnosticMano542 As DbDataReader = bddCommande5.ExecuteReader
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
                Dim bddCommande6 As DbCommand
                bddCommande6 = oCsdb.getConnection().CreateCommand
                bddCommande6.CommandText = "SELECT * FROM DiagnosticTroncons833 WHERE DiagnosticTroncons833.idDiagnostic='" & oDiagnostic.id & "'"
                ' On récupère les résultats
                Dim oDRDiagnosticTroncon833 As DbDataReader = bddCommande6.ExecuteReader
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
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            bddCommande = oCsDB.getConnection().CreateCommand

            ' Création
            bddCommande.CommandText = "INSERT INTO Diagnostic (id) VALUES ('" & diagnostic_id & "')"
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

    Public Shared Function ExistDiagnostic(pdiagId As String) As Boolean
        Dim oCsDB As New CSDb(True)
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            bddCommande = oCsDB.getConnection().CreateCommand

            ' Création
            bddCommande.CommandText = "SELECT Count(*) FROM DIAGNOSTIC WHERE id= '" & pdiagId & "'"
            Dim nResult As Integer = bddCommande.ExecuteScalar()
            bReturn = (nResult > 0)
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
        If pAgent.oPool IsNot Nothing Then
            Return getNewIdNew(pAgent)
        Else
            Return getNewIdOLD(pAgent)
        End If
    End Function

    Public Shared Function getNewIdNew(pAgent As Agent) As String
        Debug.Assert(Not pAgent Is Nothing, "L'agent doit être renseigné")
        Debug.Assert(pAgent.id <> 0, "L'agent id doit être renseigné")
        Debug.Assert(pAgent.uidStructure <> 0, "La structure id doit être renseignée")
        Debug.Assert(pAgent.oPool IsNot Nothing, "Le pool doit être renseigné")
        ' déclarations
        Dim idStructure As String = StructureManager.getStructureById(pAgent.uidStructure).idCrodip
        Dim idPC As String
        idPC = pAgent.oPool.getAgentPC().idCrodip
        Dim Racine As String = idStructure & "-" & pAgent.numeroNational & "-" & idPC & "-"
        Dim nIndex As Integer = 1



        Dim oCSDb As New CSDb(True)
        Dim res As Object = oCSDb.getValue("SELECT MAX(CAST (REPLACE(Id,'" & Racine & "','') as INT)) as ID  from Diagnostic where id Like '" & Racine & "%'")
        oCSDb.free()
        If TypeOf res IsNot DBNull Then
            nIndex = CInt(res) + 1
        End If

        'on retourne le nouvel id
        Return Racine & nIndex
    End Function

    Public Shared Function getNewIdOLD(pAgent As Agent) As String
        Debug.Assert(Not pAgent Is Nothing, "L'agent doit être renseigné")
        Debug.Assert(pAgent.id <> 0, "L'agent id doit être renseigné")
        Debug.Assert(pAgent.uidStructure <> 0, "La structure id doit être renseignée")
        ' déclarations
        Dim tmpDiagnosticId As String = pAgent.uidStructure.ToString() & "-" & pAgent.id.ToString() & "-1"
        Dim oCSDb As New CSDb(True)
        If pAgent.uidStructure <> 0 Then

            ' On test si la table est vide

            Dim tmpNbDiag As Integer = CInt(oCSDb.getValue("SELECT count(*) as nbControles FROM Diagnostic WHERE Diagnostic.InspecteurID = " & pAgent.id & ""))

            ' Si la base est vide, on récupère le dernier incrément par WS
            'SELECT MAX(CAST (REPLACE(Id,'524-1182-','') as INT)) as ID  from Diagnostic where inspecteurId = 1182 ORDER BY ID DESC

            Dim bddCommande As DbCommand
            ' On test si la connexion est déjà ouverte ou non
            bddCommande = oCSDb.getConnection().CreateCommand
            bddCommande.CommandText = "SELECT id FROM Diagnostic WHERE InspecteurId = " & pAgent.id & " ORDER BY id DESC"
            Try
                ' On récupère les résultats
                Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
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
                tmpDiagnosticId = pAgent.uidStructure & "-" & pAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                tmpDiagnosticId = pAgent.uidStructure & "-" & pAgent.id & "-0"
                CSDebug.dispFatal("DiagnosticManager - newId (On récupère le dernier ID) : ", ex)
            End Try

            oCSDb.free()
        End If

        'on retourne le nouvel id
        Return tmpDiagnosticId
    End Function

    Public Shared Function UpdateFileNames(ByVal pDiag As Diagnostic) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiag.id))
        Dim bReturn As Boolean = False
        Try

            Dim oCSDb As New CSDb(True)

            Dim bddCommande As DbCommand
            ' On test si la connexion est déjà ouverte ou non
            bddCommande = oCSDb.getConnection().CreateCommand

            ' Initialisation de la requete
            Dim paramsQuery2 As String = "id='" & pDiag.id & "'"


            paramsQuery2 = paramsQuery2 & " , RIFileName='" & CSDb.secureString(pDiag.RIFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , SMFileName='" & CSDb.secureString(pDiag.SMFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , CCFileName='" & CSDb.secureString(pDiag.CCFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , BLFileName='" & CSDb.secureString(pDiag.BLFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , ESFileName='" & CSDb.secureString(pDiag.ESFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , COPROFileName='" & CSDb.secureString(pDiag.COPROFileName) & "'"
            paramsQuery2 = paramsQuery2 & " , FACTFileNames='" & CSDb.secureString(pDiag.FACTFileNames) & "'"


            ' On finalise la requete et en l'execute
            bddCommande.CommandText = "UPDATE Diagnostic SET " & paramsQuery2 & " WHERE id='" & pDiag.id & "'"

            bddCommande.ExecuteNonQuery()
            oCSDb.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager(" & pDiag.id & ")::updateFileNAmes : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function save(ByVal pDiag As Diagnostic, Optional bsyncro As Boolean = False) As Boolean
        'Debug.Assert(Not String.IsNullOrEmpty(objid))
        Dim bReturn As Boolean = False
        Dim bcreationDiag As Boolean
        Try
            bcreationDiag = False
            If pDiag.id <> "" Then

                Dim oCSDb As New CSDb(True)

                ' On test si le Diagnostic existe ou non
                Dim existsDiagnostic As Boolean
                existsDiagnostic = DiagnosticManager.ExistDiagnostic(pDiag.id)
                If Not existsDiagnostic Then
                    ' Si il n'existe pas, on le crée
                    createDiagnostic(pDiag.id)
                    bcreationDiag = True
                End If

                Dim bddCommande As DbCommand
                ' On test si la connexion est déjà ouverte ou non
                bddCommande = oCSDb.getConnection().CreateCommand

                ' Initialisation de la requete
                Dim paramsQuery As String = "id='" & pDiag.id & "'"
                Dim paramsQuery2 As String = "id='" & pDiag.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bsyncro Then
                    pDiag.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                paramsQuery = paramsQuery & " , organismePresId=" & pDiag.organismePresId & ""
                If Not pDiag.organismePresNumero Is Nothing And pDiag.organismePresNumero <> "" Then
                    paramsQuery = paramsQuery & " , organismePresNumero='" & CSDb.secureString(pDiag.organismePresNumero) & "'"
                End If
                If Not pDiag.organismePresNom Is Nothing And pDiag.organismePresNom <> "" Then
                    paramsQuery = paramsQuery & " , organismePresNom='" & CSDb.secureString(pDiag.organismePresNom) & "'"
                End If
                If Not pDiag.organismeInspNom Is Nothing And pDiag.organismeInspNom <> "" Then
                    paramsQuery = paramsQuery & " , organismeInspNom='" & CSDb.secureString(pDiag.organismeInspNom) & "'"
                End If
                If Not pDiag.organismeInspAgrement Is Nothing And pDiag.organismeInspAgrement <> "" Then
                    paramsQuery = paramsQuery & " , organismeInspAgrement='" & CSDb.secureString(pDiag.organismeInspAgrement) & "'"
                End If
                paramsQuery = paramsQuery & " , inspecteurId=" & pDiag.inspecteurId & ""
                If Not pDiag.inspecteurNom Is Nothing And pDiag.inspecteurNom <> "" Then
                    paramsQuery = paramsQuery & " , inspecteurNom='" & CSDb.secureString(pDiag.inspecteurNom) & "'"
                End If
                If Not pDiag.inspecteurPrenom Is Nothing And pDiag.inspecteurPrenom <> "" Then
                    paramsQuery = paramsQuery & " , inspecteurPrenom='" & CSDb.secureString(pDiag.inspecteurPrenom) & "'"
                End If
                'Organisme et inspecteur d'origine
                paramsQuery = paramsQuery & " , organismeOriginePresId=" & pDiag.organismeOriginePresId & ""
                If Not pDiag.organismeOriginePresNumero Is Nothing And pDiag.organismeOriginePresNumero <> "" Then
                    paramsQuery = paramsQuery & " , organismeOriginePresNumero='" & CSDb.secureString(pDiag.organismeOriginePresNumero) & "'"
                End If
                If Not pDiag.organismeOriginePresNom Is Nothing And pDiag.organismeOriginePresNom <> "" Then
                    paramsQuery = paramsQuery & " , organismeOriginePresNom='" & CSDb.secureString(pDiag.organismeOriginePresNom) & "'"
                End If
                If Not pDiag.organismeOrigineInspNom Is Nothing And pDiag.organismeOrigineInspNom <> "" Then
                    paramsQuery = paramsQuery & " , organismeOrigineInspNom='" & CSDb.secureString(pDiag.organismeOrigineInspNom) & "'"
                End If
                If Not pDiag.organismeOrigineInspAgrement Is Nothing And pDiag.organismeOrigineInspAgrement <> "" Then
                    paramsQuery = paramsQuery & " , organismeOrigineInspAgrement='" & CSDb.secureString(pDiag.organismeOrigineInspAgrement) & "'"
                End If
                paramsQuery = paramsQuery & " , inspecteurOrigineId=" & pDiag.inspecteurOrigineId & ""
                If Not pDiag.inspecteurOrigineNom Is Nothing And pDiag.inspecteurOrigineNom <> "" Then
                    paramsQuery = paramsQuery & " , inspecteurOrigineNom='" & CSDb.secureString(pDiag.inspecteurOrigineNom) & "'"
                End If
                If Not pDiag.inspecteurOriginePrenom Is Nothing And pDiag.inspecteurOriginePrenom <> "" Then
                    paramsQuery = paramsQuery & " , inspecteurOriginePrenom='" & CSDb.secureString(pDiag.inspecteurOriginePrenom) & "'"
                End If

                If Not pDiag.controleDateDebut Is Nothing And pDiag.controleDateDebut <> "" Then
                    paramsQuery = paramsQuery & " , controleDateDebut='" & CSDate.ToCRODIPString(pDiag.controleDateDebut) & "'"
                End If
                If Not pDiag.controleDateFin Is Nothing And pDiag.controleDateFin <> "" Then
                    paramsQuery = paramsQuery & " , controleDateFin='" & CSDate.ToCRODIPString(pDiag.controleDateFin) & "'"
                End If
                If Not pDiag.controleCommune Is Nothing And pDiag.controleCommune <> "" Then
                    paramsQuery = paramsQuery & " , controleCommune='" & CSDb.secureString(pDiag.controleCommune) & "'"
                End If
                If Not pDiag.controleCodePostal Is Nothing And pDiag.controleCodePostal <> "" Then
                    paramsQuery = paramsQuery & " , controleCodePostal='" & CSDb.secureString(pDiag.controleCodePostal) & "'"
                End If
                If Not pDiag.controleLieu Is Nothing And pDiag.controleLieu <> "" Then
                    paramsQuery = paramsQuery & " , controleLieu='" & CSDb.secureString(pDiag.controleLieu) & "'"
                End If
                If Not pDiag.controleTerritoire Is Nothing And pDiag.controleTerritoire <> "" Then
                    paramsQuery = paramsQuery & " , controleTerritoire='" & CSDb.secureString(pDiag.controleTerritoire) & "'"
                End If
                If Not pDiag.controleSite Is Nothing And pDiag.controleSite <> "" Then
                    paramsQuery = paramsQuery & " , controleSite='" & CSDb.secureString(pDiag.controleSite) & "'"
                End If
                If Not pDiag.controleNomSite Is Nothing And pDiag.controleNomSite <> "" Then
                    paramsQuery = paramsQuery & " , controleNomSite='" & CSDb.secureString(pDiag.controleNomSite) & "'"
                End If
                paramsQuery = paramsQuery & " , controleIsComplet=" & pDiag.controleIsComplet & ""
                paramsQuery = paramsQuery & " , controleIsPremierControle=" & pDiag.controleIsPremierControle & ""
                If Not pDiag.controleDateDernierControle Is Nothing And pDiag.controleDateDernierControle <> "" And pDiag.controleDateDernierControle <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , controleDateDernierControle='" & CSDate.ToCRODIPString(pDiag.controleDateDernierControle) & "'"
                End If
                paramsQuery = paramsQuery & " , controleIsSiteSecurise=" & pDiag.controleIsSiteSecurise & ""
                paramsQuery = paramsQuery & " , controleIsRecupResidus=" & pDiag.controleIsRecupResidus & ""
                If Not pDiag.controleEtat Is Nothing And pDiag.controleEtat <> "" Then
                    paramsQuery = paramsQuery & " , controleEtat='" & CSDb.secureString(pDiag.controleEtat) & "'"
                End If
                If Not pDiag.controleInfosConseils Is Nothing And pDiag.controleInfosConseils <> "" Then
                    paramsQuery = paramsQuery & " , controleInfosConseils='" & CSDb.secureString(pDiag.controleInfosConseils) & "'"
                End If
                If Not pDiag.controleTarif Is Nothing And pDiag.controleTarif <> "" Then
                    paramsQuery = paramsQuery & " , controleTarif='" & CSDb.secureString(pDiag.controleTarif) & "'"
                End If
                paramsQuery = paramsQuery & " , controleIsPulveRepare=" & pDiag.controleIsPulveRepare & ""
                paramsQuery = paramsQuery & " , controleIsPreControleProfessionel=" & pDiag.controleIsPreControleProfessionel & ""
                paramsQuery = paramsQuery & " , controleIsAutoControle=" & pDiag.controleIsAutoControle & ""
                If Not pDiag.proprietaireId Is Nothing And pDiag.proprietaireId <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireId='" & CSDb.secureString(pDiag.proprietaireId) & "'"
                End If
                If Not pDiag.proprietaireRaisonSociale Is Nothing And pDiag.proprietaireRaisonSociale <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireRaisonSociale='" & CSDb.secureString(pDiag.proprietaireRaisonSociale) & "'"
                End If
                If Not pDiag.proprietairePrenom Is Nothing And pDiag.proprietairePrenom <> "" Then
                    paramsQuery = paramsQuery & " , proprietairePrenom='" & CSDb.secureString(pDiag.proprietairePrenom) & "'"
                End If
                If Not pDiag.proprietaireNom Is Nothing And pDiag.proprietaireNom <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireNom='" & CSDb.secureString(pDiag.proprietaireNom) & "'"
                End If
                If Not pDiag.proprietaireCodeApe Is Nothing And pDiag.proprietaireCodeApe <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireCodeApe='" & CSDb.secureString(pDiag.proprietaireCodeApe) & "'"
                End If
                If Not pDiag.proprietaireNumeroSiren Is Nothing And pDiag.proprietaireNumeroSiren <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireNumeroSiren='" & CSDb.secureString(pDiag.proprietaireNumeroSiren) & "'"
                End If
                If Not pDiag.proprietaireCommune Is Nothing And pDiag.proprietaireCommune <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireCommune='" & CSDb.secureString(pDiag.proprietaireCommune) & "'"
                End If
                If Not pDiag.proprietaireCodePostal Is Nothing And pDiag.proprietaireCodePostal <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireCodePostal='" & CSDb.secureString(pDiag.proprietaireCodePostal) & "'"
                End If
                If Not pDiag.proprietaireAdresse Is Nothing And pDiag.proprietaireAdresse <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireAdresse='" & CSDb.secureString(pDiag.proprietaireAdresse) & "'"
                End If
                If Not pDiag.proprietaireEmail Is Nothing And pDiag.proprietaireEmail <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireEmail='" & CSDb.secureString(pDiag.proprietaireEmail) & "'"
                End If
                If Not pDiag.proprietaireTelephonePortable Is Nothing And pDiag.proprietaireTelephonePortable <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireTelephonePortable='" & CSDb.secureString(pDiag.proprietaireTelephonePortable) & "'"
                End If
                If Not pDiag.proprietaireTelephoneFixe Is Nothing And pDiag.proprietaireTelephoneFixe <> "" Then
                    paramsQuery = paramsQuery & " , proprietaireTelephoneFixe='" & CSDb.secureString(pDiag.proprietaireTelephoneFixe) & "'"
                End If
                If Not String.IsNullOrEmpty(pDiag.proprietaireRepresentant) Then
                    paramsQuery = paramsQuery & " , proprietaireRepresentant='" & CSDb.secureString(pDiag.proprietaireRepresentant) & "'"
                End If
                If Not pDiag.pulverisateurId Is Nothing And pDiag.pulverisateurId <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurId='" & CSDb.secureString(pDiag.pulverisateurId) & "'"
                End If
                If Not pDiag.pulverisateurMarque Is Nothing And pDiag.pulverisateurMarque <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurMarque='" & CSDb.secureString(pDiag.pulverisateurMarque) & "'"
                End If
                If Not pDiag.pulverisateurModele Is Nothing And pDiag.pulverisateurModele <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurModele='" & CSDb.secureString(pDiag.pulverisateurModele) & "'"
                End If
                If Not pDiag.pulverisateurType Is Nothing And pDiag.pulverisateurType <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurType='" & CSDb.secureString(pDiag.pulverisateurType) & "'"
                End If
                If Not pDiag.pulverisateurCapacite Is Nothing And pDiag.pulverisateurCapacite <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurCapacite='" & CSDb.secureString(pDiag.pulverisateurCapacite) & "'"
                End If
                If Not pDiag.pulverisateurLargeur Is Nothing And pDiag.pulverisateurLargeur <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurLargeur='" & CSDb.secureString(pDiag.pulverisateurLargeur) & "'"
                End If
                If Not pDiag.pulverisateurNbRangs Is Nothing And pDiag.pulverisateurNbRangs <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurNbRangs='" & CSDb.secureString(pDiag.pulverisateurNbRangs) & "'"
                End If
                If Not pDiag.pulverisateurLargeurPlantation Is Nothing And pDiag.pulverisateurLargeurPlantation <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurLargeurPlantation='" & CSDb.secureString(pDiag.pulverisateurLargeurPlantation) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisateurIsVentilateur=" & pDiag.pulverisateurIsVentilateur & ""
                paramsQuery = paramsQuery & " , pulverisateurIsDebrayage=" & pDiag.pulverisateurIsDebrayage & ""
                If Not pDiag.pulverisateurAnneeAchat Is Nothing And pDiag.pulverisateurAnneeAchat <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurAnneeAchat='" & CSDb.secureString(pDiag.pulverisateurAnneeAchat) & "'"
                End If
                If Not pDiag.pulverisateurSurface Is Nothing And pDiag.pulverisateurSurface <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurSurface='" & CSDb.secureString(pDiag.pulverisateurSurface) & "'"
                End If
                If Not pDiag.pulverisateurNbUtilisateurs Is Nothing And pDiag.pulverisateurNbUtilisateurs <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurNbUtilisateurs='" & CSDb.secureString(pDiag.pulverisateurNbUtilisateurs) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisateurIsCuveRincage=" & pDiag.pulverisateurIsCuveRincage & ""
                If Not pDiag.pulverisateurCapaciteCuveRincage Is Nothing And pDiag.pulverisateurCapaciteCuveRincage <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurCapaciteCuveRincage='" & CSDb.secureString(pDiag.pulverisateurCapaciteCuveRincage) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisateurIsRotobuse=" & pDiag.pulverisateurIsRotobuse & ""
                paramsQuery = paramsQuery & " , pulverisateurIsRinceBidon=" & pDiag.pulverisateurIsRinceBidon & ""
                paramsQuery = paramsQuery & " , pulverisateurIsBidonLaveMain=" & pDiag.pulverisateurIsBidonLaveMain & ""
                paramsQuery = paramsQuery & " , pulverisateurIsLanceLavageExterieur=" & pDiag.pulverisateurIsLanceLavageExterieur & ""
                paramsQuery = paramsQuery & " , pulverisateurIsCuveIncorporation=" & pDiag.pulverisateurIsCuveIncorporation & ""
                paramsQuery = paramsQuery & " , pulverisateurCategorie='" & CSDb.secureString(pDiag.pulverisateurCategorie) & "'"
                If Not pDiag.pulverisateurAttelage Is Nothing And pDiag.pulverisateurAttelage <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurAttelage='" & CSDb.secureString(pDiag.pulverisateurAttelage) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisateurRegulation='" & CSDb.secureString(pDiag.pulverisateurRegulation) & "'"
                paramsQuery = paramsQuery & " , pulverisateurRegulationOptions='" & CSDb.secureString(pDiag.pulverisateurRegulationOptions) & "'"
                paramsQuery = paramsQuery & " , pulverisateurPulverisation='" & CSDb.secureString(pDiag.pulverisateurPulverisation) & "'"
                If Not pDiag.pulverisateurAutresAccessoires Is Nothing And pDiag.pulverisateurAutresAccessoires <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurAutresAccessoires='" & CSDb.secureString(pDiag.pulverisateurAutresAccessoires) & "'"
                End If
                If Not pDiag.pulverisateurEmplacementIdentification Is Nothing And pDiag.pulverisateurEmplacementIdentification <> "" Then
                    paramsQuery = paramsQuery & " , pulverisateurEmplacementIdentification='" & CSDb.secureString(pDiag.pulverisateurEmplacementIdentification) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisateurModeUtilisation='" & CSDb.secureString(pDiag.pulverisateurModeUtilisation) & "'"
                paramsQuery = paramsQuery & " , pulverisateurNbreExploitants='" & CSDb.secureString(pDiag.pulverisateurNbreExploitants) & "'"
                If Not pDiag.buseMarque Is Nothing And pDiag.buseMarque <> "" Then
                    paramsQuery = paramsQuery & " , buseMarque='" & CSDb.secureString(pDiag.buseMarque) & "'"
                End If
                If Not pDiag.buseModele Is Nothing And pDiag.buseModele <> "" Then
                    paramsQuery = paramsQuery & " , buseModele='" & CSDb.secureString(pDiag.buseModele) & "'"
                End If
                If Not pDiag.buseCouleur Is Nothing And pDiag.buseCouleur <> "" Then
                    paramsQuery = paramsQuery & " , buseCouleur='" & CSDb.secureString(pDiag.buseCouleur) & "'"
                End If
                If Not pDiag.buseGenre Is Nothing And pDiag.buseGenre <> "" Then
                    paramsQuery = paramsQuery & " , buseGenre='" & CSDb.secureString(pDiag.buseGenre) & "'"
                End If
                If Not pDiag.buseCalibre Is Nothing And pDiag.buseCalibre <> "" Then
                    paramsQuery = paramsQuery & " , buseCalibre='" & CSDb.secureString(pDiag.buseCalibre) & "'"
                End If
                If Not pDiag.buseDebit Is Nothing And pDiag.buseDebit <> "" Then
                    paramsQuery = paramsQuery & " , buseDebit='" & CSDb.secureString(pDiag.buseDebit) & "'"
                End If
                If Not pDiag.buseDebit2bars Is Nothing And pDiag.buseDebit2bars <> "" Then
                    paramsQuery = paramsQuery & " , buseDebit2bars='" & CSDb.secureString(pDiag.buseDebit2bars) & "'"
                End If
                If Not pDiag.buseDebit3bars Is Nothing And pDiag.buseDebit3bars <> "" Then
                    paramsQuery = paramsQuery & " , buseDebit3bars='" & CSDb.secureString(pDiag.buseDebit3bars) & "'"
                End If
                If Not pDiag.buseAge Is Nothing And pDiag.buseAge <> "" Then
                    paramsQuery = paramsQuery & " , buseAge='" & CSDb.secureString(pDiag.buseAge) & "'"
                End If
                If Not pDiag.buseNbBuses Is Nothing And pDiag.buseNbBuses <> "" Then
                    paramsQuery = paramsQuery & " , buseNbBuses='" & CSDb.secureString(pDiag.buseNbBuses) & "'"
                End If
                If Not pDiag.buseType Is Nothing And pDiag.buseType <> "" Then
                    paramsQuery = paramsQuery & " , buseType='" & CSDb.secureString(pDiag.buseType) & "'"
                End If
                If Not pDiag.buseAngle Is Nothing And pDiag.buseAngle <> "" Then
                    paramsQuery = paramsQuery & " , buseAngle='" & CSDb.secureString(pDiag.buseAngle) & "'"
                End If
                paramsQuery = paramsQuery & " , buseFonctionnement='" & CSDb.secureString(pDiag.buseFonctionnement) & "'"
                '                paramsQuery = paramsQuery & " , buseFonctionnementIsStandard=" & objbuseFonctionnementIsStandard & ""
                '                paramsQuery = paramsQuery & " , buseFonctionnementIsPastilleChambre=" & objbuseFonctionnementIsPastilleChambre & ""
                '               paramsQuery = paramsQuery & " , buseFonctionnementIsInjectionAirLibre=" & objbuseFonctionnementIsInjectionAirLibre & ""
                '              paramsQuery = paramsQuery & " , buseFonctionnementIsInjectionAirForce=" & objbuseFonctionnementIsInjectionAirForce & ""
                paramsQuery = paramsQuery & " , buseIsISO=" & pDiag.buseIsISO & ""
                If Not pDiag.manometreMarque Is Nothing And pDiag.manometreMarque <> "" Then
                    paramsQuery = paramsQuery & " , manometreMarque='" & CSDb.secureString(pDiag.manometreMarque) & "'"
                End If
                If Not pDiag.manometreDiametre Is Nothing And pDiag.manometreDiametre <> "" Then
                    paramsQuery = paramsQuery & " , manometreDiametre='" & CSDb.secureString(pDiag.manometreDiametre) & "'"
                End If
                If Not pDiag.manometreType Is Nothing And pDiag.manometreType <> "" Then
                    paramsQuery = paramsQuery & " , manometreType='" & CSDb.secureString(pDiag.manometreType) & "'"
                End If
                If Not pDiag.manometreFondEchelle Is Nothing And pDiag.manometreFondEchelle <> "" Then
                    paramsQuery = paramsQuery & " , manometreFondEchelle='" & CSDb.secureString(pDiag.manometreFondEchelle) & "'"
                End If
                If Not pDiag.manometrePressionTravail Is Nothing And pDiag.manometrePressionTravail <> "" Then
                    paramsQuery = paramsQuery & " , manometrePressionTravail='" & CSDb.secureString(pDiag.manometrePressionTravail) & "'"
                End If
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsGrandeCulture=" & pDiag.exploitationTypeCultureIsGrandeCulture & ""
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsLegume=" & pDiag.exploitationTypeCultureIsLegume & ""
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsElevage=" & pDiag.exploitationTypeCultureIsElevage & ""
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsArboriculture=" & pDiag.exploitationTypeCultureIsArboriculture & ""
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsViticulture=" & pDiag.exploitationTypeCultureIsViticulture & ""
                paramsQuery = paramsQuery & " , exploitationTypeCultureIsAutres=" & pDiag.exploitationTypeCultureIsAutres & ""
                If Not pDiag.exploitationSau Is Nothing And pDiag.exploitationSau <> "" Then
                    paramsQuery = paramsQuery & " , exploitationSau='" & CSDb.secureString(pDiag.exploitationSau) & "'"
                End If
                If Not pDiag.dateModificationAgent Is Nothing And pDiag.dateModificationAgent <> "" Then
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(pDiag.dateModificationAgent) & "'"
                End If
                If Not pDiag.dateModificationCrodip Is Nothing And pDiag.dateModificationCrodip <> "" Then
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(pDiag.dateModificationCrodip) & "'"
                End If

                'On scinde la requete en 2 car elle est trop longue sinon
                If Not pDiag.dateSynchro Is Nothing And pDiag.dateSynchro <> "" Then
                    paramsQuery2 = paramsQuery2 & " , dateSynchro='" & CSDb.secureString(pDiag.dateSynchro) & "'"
                End If
                If Not pDiag.syntheseErreurMoyenneMano Is Nothing And pDiag.syntheseErreurMoyenneMano <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseErreurMoyenneMano='" & CSDb.secureString(pDiag.syntheseErreurMoyenneMano) & "'"
                End If
                If Not pDiag.syntheseErreurMaxiMano Is Nothing And pDiag.syntheseErreurMaxiMano <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseErreurMaxiMano='" & CSDb.secureString(pDiag.syntheseErreurMaxiMano) & "'"
                End If
                If Not pDiag.syntheseErreurDebitmetre Is Nothing And pDiag.syntheseErreurDebitmetre <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseErreurDebitmetre='" & CSDb.secureString(pDiag.syntheseErreurDebitmetre) & "'"
                End If
                If Not pDiag.syntheseErreurMoyenneCinemometre Is Nothing And pDiag.syntheseErreurMoyenneCinemometre <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseErreurMoyenneCinemometre='" & CSDb.secureString(pDiag.syntheseErreurMoyenneCinemometre) & "'"
                End If
                If Not pDiag.syntheseUsureMoyenneBuses Is Nothing And pDiag.syntheseUsureMoyenneBuses <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseUsureMoyenneBuses='" & CSDb.secureString(pDiag.syntheseUsureMoyenneBuses) & "'"
                End If
                If Not pDiag.syntheseNbBusesUsees Is Nothing And pDiag.syntheseNbBusesUsees <> "" Then
                    paramsQuery2 = paramsQuery2 & " , syntheseNbBusesUsees='" & CSDb.secureString(pDiag.syntheseNbBusesUsees) & "'"
                End If
                If Not pDiag.synthesePerteChargeMoyenne Is Nothing And pDiag.synthesePerteChargeMoyenne <> "" Then
                    paramsQuery2 = paramsQuery2 & " , synthesePerteChargeMoyenne='" & CSDb.secureString(pDiag.synthesePerteChargeMoyenne) & "'"
                End If
                If Not pDiag.synthesePerteChargeMaxi Is Nothing And pDiag.synthesePerteChargeMaxi <> "" Then
                    paramsQuery2 = paramsQuery2 & " , synthesePerteChargeMaxi='" & CSDb.secureString(pDiag.synthesePerteChargeMaxi) & "'"
                End If
                paramsQuery2 = paramsQuery2 & " , isSynchro=" & pDiag.isSynchro & ""
                paramsQuery2 = paramsQuery2 & " , isATGIP=" & pDiag.isATGIP & ""
                paramsQuery2 = paramsQuery2 & " , isTGIP=" & pDiag.isTGIP & ""
                paramsQuery2 = paramsQuery2 & " , isFacture=" & pDiag.isFacture & ""
                paramsQuery2 = paramsQuery2 & " , controleBancMesureId='" & pDiag.controleBancMesureId & "'"
                paramsQuery2 = paramsQuery2 & " , controleUseCalibrateur=" & pDiag.controleUseCalibrateur & ""
                paramsQuery2 = paramsQuery2 & " , controleNbreNiveaux='" & pDiag.controleNbreNiveaux & "'"
                paramsQuery2 = paramsQuery2 & " , controleNbreTroncons='" & pDiag.controleNbreTroncons & "'"
                paramsQuery2 = paramsQuery2 & " , controleManoControleNumNational='" & pDiag.controleManoControleNumNational & "'"
                paramsQuery2 = paramsQuery2 & " , controleInitialId='" & pDiag.controleInitialId & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurAncienId='" & pDiag.pulverisateurAncienId & "'"
                paramsQuery2 = paramsQuery2 & " , RIFileName='" & CSDb.secureString(pDiag.RIFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , SMFileName='" & CSDb.secureString(pDiag.SMFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , CCFileName='" & CSDb.secureString(pDiag.CCFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurCoupureAutoTroncons='" & CSDb.secureString(pDiag.pulverisateurCoupureAutoTroncons) & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurReglageAutoHauteur='" & CSDb.secureString(pDiag.pulverisateurReglageAutoHauteur) & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurRincagecircuit='" & CSDb.secureString(pDiag.pulverisateurRincagecircuit) & "'"
                paramsQuery2 = paramsQuery2 & " , typeDiagnostic='" & CSDb.secureString(pDiag.typeDiagnostic) & "'"
                paramsQuery2 = paramsQuery2 & " , codeInsee='" & CSDb.secureString(pDiag.codeInsee) & "'"
                paramsQuery2 = paramsQuery2 & " , commentaire='" & CSDb.secureString(Left(pDiag.commentaire, 255)) & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurNumNational='" & CSDb.secureString(pDiag.pulverisateurNumNational) & "'"
                paramsQuery2 = paramsQuery2 & " , pulverisateurNumChassis='" & CSDb.secureString(pDiag.pulverisateurNumChassis) & "'"
                paramsQuery2 = paramsQuery2 & " , origineDiag='" & CSDb.secureString(pDiag.origineDiag) & "'"
                paramsQuery2 = paramsQuery2 & " , isSignRIAgent=" & pDiag.isSignRIAgent & ""
                paramsQuery2 = paramsQuery2 & " , isSignRIClient=" & pDiag.isSignRIClient & ""
                paramsQuery2 = paramsQuery2 & " , isSignCCAgent=" & pDiag.isSignCCAgent & ""
                paramsQuery2 = paramsQuery2 & " , isSignCCClient=" & pDiag.isSignCCClient & ""
                If pDiag.dateSignRIAgent.HasValue Then
                    paramsQuery2 = paramsQuery2 & " , dateSignRIAgent='" & CSDate.ToCRODIPString(pDiag.dateSignRIAgent) & "'"
                End If
                If pDiag.dateSignRIClient.HasValue Then
                    paramsQuery2 = paramsQuery2 & " , dateSignRIClient='" & CSDate.ToCRODIPString(pDiag.dateSignRIClient) & "'"
                End If
                If pDiag.dateSignCCAgent.HasValue Then
                    paramsQuery2 = paramsQuery2 & " , dateSignCCAgent='" & CSDate.ToCRODIPString(pDiag.dateSignCCAgent) & "'"
                End If
                If pDiag.dateSignCCClient.HasValue Then
                    paramsQuery2 = paramsQuery2 & " , dateSignCCClient='" & CSDate.ToCRODIPString(pDiag.dateSignCCClient) & "'"
                End If
                paramsQuery2 = paramsQuery2 & " , isSupprime=" & pDiag.isSupprime & ""
                paramsQuery2 = paramsQuery2 & " , diagRemplacementId='" & pDiag.diagRemplacementId & "'"
                paramsQuery2 = paramsQuery2 & " , totalHT= @HT"
                paramsQuery2 = paramsQuery2 & " , totalTTC= @TTC"
                paramsQuery2 = paramsQuery2 & " , isCVImmediate=" & pDiag.isContrevisiteImmediate & ""
                paramsQuery2 = paramsQuery2 & " , isGratuit=" & pDiag.isGratuit & ""
                paramsQuery2 = paramsQuery2 & " , BLFileName='" & CSDb.secureString(pDiag.BLFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , ESFileName='" & CSDb.secureString(pDiag.ESFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , COPROFileName='" & CSDb.secureString(pDiag.COPROFileName) & "'"
                paramsQuery2 = paramsQuery2 & " , FACTFileNames='" & CSDb.secureString(pDiag.FACTFileNames) & "'"


                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE Diagnostic SET " & paramsQuery & " WHERE id='" & pDiag.id & "'"
                'CSDebug.dispInfo("DiagnosticManager::save (query) : " & bddCommande.CommandText)
                bddCommande.ExecuteNonQuery()
                bddCommande.CommandText = "UPDATE Diagnostic SET " & paramsQuery2 & " WHERE id='" & pDiag.id & "'"
                AddParameter(bddCommande, "@HT", pDiag.TotalHT, DbType.Currency)
                AddParameter(bddCommande, "@TTC", pDiag.TotalTTC, DbType.Currency)

                bddCommande.ExecuteNonQuery()

                If pDiag.SignRIAgent IsNot Nothing Then
                    bddCommande = oCSDb.getConnection().CreateCommand
                    bddCommande.CommandText = "UPDATE Diagnostic SET  signRIAgent=@sign WHERE id='" & pDiag.id & "'"
                    AddParameter(bddCommande, "@sign", pDiag.SignRIAgent, DbType.Binary)
                    bddCommande.ExecuteNonQuery()
                End If

                If pDiag.SignRIClient IsNot Nothing Then
                    bddCommande = oCSDb.getConnection().CreateCommand
                    bddCommande.CommandText = "UPDATE Diagnostic SET  signRIClient=@sign WHERE id='" & pDiag.id & "'"
                    AddParameter(bddCommande, "@sign", pDiag.SignRIClient, DbType.Binary)
                    bddCommande.ExecuteNonQuery()
                End If

                If pDiag.SignCCAgent IsNot Nothing Then
                    bddCommande = oCSDb.getConnection().CreateCommand
                    bddCommande.CommandText = "UPDATE Diagnostic SET  signCCAgent=@sign WHERE id='" & pDiag.id & "'"
                    AddParameter(bddCommande, "@sign", pDiag.SignCCAgent, DbType.Binary)

                    bddCommande.ExecuteNonQuery()
                End If

                If pDiag.SignCCClient IsNot Nothing Then
                    bddCommande = oCSDb.getConnection().CreateCommand
                    bddCommande.CommandText = "UPDATE Diagnostic SET  signCCClient=@sign WHERE id='" & pDiag.id & "'"
                    AddParameter(bddCommande, "@sign", pDiag.SignCCAgent, DbType.Binary)
                    bddCommande.ExecuteNonQuery()
                End If



                ' On enregistre les items du diag
                '                CSDebug.dispInfo("Sauvegarde des DiagItem")

                SaveDiagItems(oCSDb, pDiag, bcreationDiag, bsyncro)


                'Sauvegarde des Help 551 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp551 IsNot Nothing Then
                    If pDiag.diagnosticHelp551.HasValue() Then
                        pDiag.diagnosticHelp551.idDiag = pDiag.id
                        DiagnosticHelp551Manager.save(pDiag.diagnosticHelp551, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If
                'Sauvegarde des Help 12323 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp12323 IsNot Nothing Then
                    If pDiag.diagnosticHelp12323.HasValue() Then
                        pDiag.diagnosticHelp12323.idDiag = pDiag.id
                        DiagnosticHelp551Manager.save(pDiag.diagnosticHelp12323, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 5621 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp5621 IsNot Nothing Then
                    If pDiag.diagnosticHelp5621.HasValue() Then
                        pDiag.diagnosticHelp5621.idDiag = pDiag.id
                        DiagnosticHelp5621Manager.save(pDiag.diagnosticHelp5621, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 552 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp552 IsNot Nothing Then
                    If pDiag.diagnosticHelp552.hasValue() Then
                        pDiag.diagnosticHelp552.idDiag = pDiag.id
                        DiagnosticHelp552Manager.save(pDiag.diagnosticHelp552, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 5622 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp5622 IsNot Nothing Then
                    If pDiag.diagnosticHelp5622.hasValue() Then
                        pDiag.diagnosticHelp5622.idDiag = pDiag.id
                        DiagnosticHelp5622Manager.save(pDiag.diagnosticHelp5622, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 811 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp811 IsNot Nothing Then
                    If pDiag.diagnosticHelp811.hasValue() Then
                        pDiag.diagnosticHelp811.idDiag = pDiag.id
                        DiagnosticHelp811Manager.save(pDiag.diagnosticHelp811, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 831 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp8312 IsNot Nothing Then
                    If pDiag.diagnosticHelp8312.hasValue() Then
                        pDiag.diagnosticHelp8312.idDiag = pDiag.id
                        DiagnosticHelp831Manager.save(pDiag.diagnosticHelp8312, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If
                If pDiag.diagnosticHelp8314 IsNot Nothing Then
                    If pDiag.diagnosticHelp8314.hasValue() Then
                        pDiag.diagnosticHelp8314.idDiag = pDiag.id
                        DiagnosticHelp831Manager.save(pDiag.diagnosticHelp8314, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If

                'Sauvegarde des Help 571 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp571 IsNot Nothing Then
                    If pDiag.diagnosticHelp571.hasValue() Then
                        pDiag.diagnosticHelp571.idDiag = pDiag.id
                        DiagnosticHelp571Manager.save(pDiag.diagnosticHelp571, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If
                'Sauvegarde des Help 12123 (Si on a des valeurs pertinentes)
                If pDiag.diagnosticHelp12123 IsNot Nothing Then
                    If pDiag.diagnosticHelp12123.hasValue() Then
                        pDiag.diagnosticHelp12123.idDiag = pDiag.id
                        DiagnosticHelp12123Manager.save(pDiag.diagnosticHelp12123, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If
                'Sauvegarde des InfosComplementaires (Si on a des valeurs pertinentes)
                If pDiag.diagnosticInfosComplementaires IsNot Nothing Then
                    If pDiag.diagnosticInfosComplementaires.hasValue() Then
                        pDiag.diagnosticInfosComplementaires.idDiag = pDiag.id
                        DiagnosticInfosComplementaireManager.save(pDiag.diagnosticInfosComplementaires, pDiag.organismePresId, pDiag.inspecteurId, oCSDb)
                    End If
                End If
                ' On enregistre les buses
                'CSDebug.dispInfo("Sauvegarde des buses")
                '                oCSDb.getInstance()
                oCSDb.Execute("DELETE FROM diagnosticBusesDetail where idDiagnostic = '" & pDiag.id & "'")
                oCSDb.Execute("DELETE FROM diagnosticBuses where idDiagnostic = '" & pDiag.id & "'")
                '               oCSDB.free()
                If Not pDiag.diagnosticBusesList Is Nothing Then
                    If Not pDiag.diagnosticBusesList.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticBuses In pDiag.diagnosticBusesList.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = pDiag.id
                                DiagnosticBusesManager.save(tmpItemCheck, oCSDb, bsyncro)
                            End If
                        Next
                    End If
                End If

                oCSDb.Execute("DELETE FROM diagnosticMano542 where idDiagnostic = '" & pDiag.id & "'")
                ' On enregistre les mano 5.4.2
                'CSDebug.dispInfo("Sauvegarde des Mano542")
                If Not pDiag.diagnosticMano542List Is Nothing Then
                    If Not pDiag.diagnosticMano542List.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticMano542 In pDiag.diagnosticMano542List.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = pDiag.id
                                DiagnosticMano542Manager.save(tmpItemCheck, oCSDb, bsyncro)
                            End If
                        Next
                    End If
                End If

                oCSDb.Execute("DELETE FROM diagnosticTroncons833 where idDiagnostic = '" & pDiag.id & "'")
                ' On enregistre les tronçons 8.3.3
                'CSDebug.dispInfo("Sauvegarde des Tronçons833")
                If Not pDiag.diagnosticTroncons833 Is Nothing Then
                    If Not pDiag.diagnosticTroncons833.Liste Is Nothing Then
                        For Each tmpItemCheck As DiagnosticTroncons833 In pDiag.diagnosticTroncons833.Liste
                            If Not tmpItemCheck Is Nothing Then
                                tmpItemCheck.idDiagnostic = pDiag.id
                                'Par sécurité on recalcule les idPressions car certains diag on des id = 5,6,7,8
                                If tmpItemCheck.idPression > 4 Then
                                    tmpItemCheck.idPression = (tmpItemCheck.idPression Mod 4)
                                    If tmpItemCheck.idPression = 0 Then
                                        tmpItemCheck.idPression = 4
                                    End If
                                End If
                                DiagnosticTroncons833Manager.save(tmpItemCheck, oCSDb, bsyncro)
                            End If
                        Next
                    End If
                End If

                oCSDb.free()
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager(" & pDiag.id & ")::save : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function SaveDiagItems(pCSDB As CSDb, ByVal pDiagnostic As Diagnostic, ByVal bcreationDiag As Boolean, Optional bsynchro As Boolean = False) As Boolean
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit être ouverte")
        Dim bReturn As Boolean
        Dim oCmd As DbCommand
        Try
            oCmd = pCSDB.getConnection.CreateCommand()
            Dim tmpNewDiagItemId As String = ""
            'Pour accellérer la sauvegarde en création on récupère le nouvel id des diagItem et on l'incrémentera au fur et à mesure
            tmpNewDiagItemId = pDiagnostic.organismePresId & "-" & pDiagnostic.inspecteurId & "-1"
            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                tmpNewDiagItemId = DiagnosticItemManager.getNewId(pDiagnostic.organismePresId, pDiagnostic.inspecteurId) 'Calcul du nouvel Id
            End If
            oCmd.CommandText = "DELETE FROM diagnosticItem where idDiagnostic = '" & pDiagnostic.id & "'"
            oCmd.ExecuteNonQuery()


            oCmd.CommandText = "INSERT INTO diagnosticItem ("
            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                oCmd.CommandText = oCmd.CommandText & "id ,  "
            End If
            oCmd.CommandText = oCmd.CommandText & "idDiagnostic ,  "
            oCmd.CommandText = oCmd.CommandText & "idItem ,  "
            oCmd.CommandText = oCmd.CommandText & "itemValue ,  "
            oCmd.CommandText = oCmd.CommandText & "itemCodeEtat ,  "
            oCmd.CommandText = oCmd.CommandText & "cause ,  "
            oCmd.CommandText = oCmd.CommandText & "dateModificationAgent ,  "
            oCmd.CommandText = oCmd.CommandText & "dateModificationCrodip "
            oCmd.CommandText = oCmd.CommandText & " ) VALUES ( "
            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                oCmd.CommandText = oCmd.CommandText & " @ID, "
            End If
            oCmd.CommandText = oCmd.CommandText & " @idDiag,@idItem,@itemValue,@itemCodeEtat,@cause,@dateModificationAgent,@dateModificationCrodip"
            oCmd.CommandText = oCmd.CommandText & " ) "
            oCmd.Prepare()
            If Not pDiagnostic.diagnosticItemsLst Is Nothing Then
                If Not pDiagnostic.diagnosticItemsLst.items Is Nothing Then
                    For Each oDiagItem As DiagnosticItem In pDiagnostic.diagnosticItemsLst.items
                        If Not oDiagItem Is Nothing Then
                            oDiagItem.idDiagnostic = pDiagnostic.id
                            oCmd.Parameters.Clear()
                            Dim oParam As DbParameter
                            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                                oDiagItem.id = tmpNewDiagItemId
                                oParam = oCmd.CreateParameter()
                                With oParam
                                    If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                        .ParameterName = "@ID"
                                    End If
                                    .DbType = DbType.String
                                    .Value = oDiagItem.id
                                End With
                                oCmd.Parameters.Add(oParam)
                            End If

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@idDiag"
                                End If
                                .DbType = DbType.String
                                .Value = oDiagItem.idDiagnostic
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@idItem"
                                End If
                                .DbType = DbType.String
                                .Value = oDiagItem.idItem
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@itemValue"
                                End If
                                .DbType = DbType.String
                                .Value = oDiagItem.itemValue
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@itemCodeEtat"
                                End If
                                .DbType = DbType.String
                                If String.IsNullOrEmpty(oDiagItem.itemCodeEtat) Then
                                    .Value = ""
                                Else
                                    .Value = oDiagItem.itemCodeEtat

                                End If
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@cause"
                                End If
                                .DbType = DbType.String
                                .Value = oDiagItem.cause
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@dateModificationAgent"
                                End If
                                .DbType = DbType.DateTime
                                .Value = oDiagItem.dateModificationAgent
                            End With
                            oCmd.Parameters.Add(oParam)

                            oParam = oCmd.CreateParameter()
                            With oParam
                                If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                    .ParameterName = "@dateModificationCrodip"
                                End If
                                .DbType = DbType.DateTime
                                .Value = oDiagItem.dateModificationCrodip
                            End With
                            oCmd.Parameters.Add(oParam)

                            oCmd.ExecuteNonQuery()
                            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                                Dim oCmd2 As DbCommand = pCSDB.getConnection().CreateCommand()
                                oCmd2.CommandText = "SELECT last_insert_rowid()"
                                oDiagItem.id = CInt(oCmd2.ExecuteScalar())
                            Else
                                tmpNewDiagItemId = DiagnosticItemManager.incId(tmpNewDiagItemId)
                            End If
                        End If
                    Next
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticManager.SaveDiagItems (" & pDiagnostic.id & ") ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Sub setSynchro(ByVal objDiagnostic As Diagnostic)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE Diagnostic SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id='" & objDiagnostic.id & "'"
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
        Dim bddCommande As DbCommand
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

                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()
                bddCommande.CommandText = "DELETE from Diagnostic WHERE Diagnostic.id='" & pDiagnosticId & "'"
                nResult = bddCommande.ExecuteReader().RecordsAffected
                'Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticManager.delete(" & pDiagnosticId & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
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
