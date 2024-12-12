Imports System.Collections.Generic
Imports System.Data.Common

Public Class AutoTestManager
    Inherits RootManager
#Region "WebsServices"
    Public Shared Function WSgetById(ByVal p_uid As Integer, paid As String) As AutoTest
        Dim oreturn As AutoTest
        oreturn = RootWSGetById(Of AutoTest)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As AutoTest, ByRef pobjOut As AutoTest) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of AutoTest)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("AutoTestManager.WSSend : ", ex)
            nreturn = -1
        End Try
        Return nreturn
    End Function
    Public Shared Function WSSendList(pAgent As Agent) As Integer
        Dim bReturn As Integer

        Try
            bReturn = 0
            Dim oCol As List(Of AutoTest)
            oCol = getcolControlesReguliers(pAgent, , , , True)
            If Not oCol Is Nothing Then
                If oCol.Count > 0 Then
                    Dim ArrObject(oCol.Count) As AutoTest
                    Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
                    For Each obj As AutoTest In oCol
                        Dim pInfo As String = ""
                        Dim puid As Integer
                        Dim response As Integer = objWSCrodip.SendAutoTest(obj, pInfo, puid)
                        Select Case response
                            Case 0, 2, 4
                                obj = WSgetById(puid, "")
                                AutoTestManager.save(obj, True)
                                bReturn = response
                            Case Else
                        End Select

                        obj.uid = puid
                    Next
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("AutoTestManager.WSSendList : ", ex)
            bReturn = -1
        End Try
        Return bReturn

    End Function
    'Public Shared Function sendWSControlesReguliers(ByVal pAgent As Agent) As Boolean
    '    Dim bReturn As Boolean

    '    Try
    '        Dim oCol As List(Of AutoTest)
    '        oCol = getcolControlesReguliers(pAgent, , , , True)
    '        If Not oCol Is Nothing Then
    '            If oCol.Count > 0 Then
    '                Dim ArrObject(oCol.Count) As AutoTest
    '                Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '                Dim i As Integer
    '                i = 0
    '                For Each obj As AutoTest In oCol
    '                    ArrObject(i) = obj
    '                    i = i + 1
    '                Next
    '                Dim info As String = ""
    '                Dim uid As String = ""
    '                Dim response As Integer = objWSCrodip.SendAutoTest(ArrObject, info, uid)
    '                If response = 0 Or response = 2 Or (GlobalsCRODIP.GLOB_ENV_DEBUG And response = 9) Then
    '                    'Mise à jour de la date de synchro (date Modification CRODIP)
    '                    For Each obj As AutoTest In oCol
    '                        obj.dateModificationCrodip = CSDate.ToCRODIPString(Now())
    '                        saveSynchro(obj)
    '                    Next

    '                End If
    '            End If
    '        End If
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("sendWSControleRegulier : " & ex.Message & ex.InnerException.InnerException.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function

#End Region

#Region "Methodes Locales"

    Public Shared Function getById(ByVal pAgent As Agent, ByVal idControle As Integer) As AutoTest
        Debug.Assert(idControle <> 0)
        Dim oReturn As AutoTest = Nothing
        Dim dbLink As CSDb
        dbLink = New CSDb(True)
        Try
            '## Préparation de la connexion
            '## Execution de la requete
            Dim tmpResults As DbDataReader
            tmpResults = dbLink.getResult2s("SELECT * FROM `Controle_Regulier` WHERE ctrg_id=" & idControle & "")
            '################################################################
            Dim i As Integer = 0
            If tmpResults.HasRows Then
                While tmpResults.Read()
                    oReturn = New AutoTest(pAgent)
                    '# construction de l'objet
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpResults.FieldCount()
                        If Not tmpResults.IsDBNull(tmpColId) Then
                            oReturn.Fill(tmpResults.GetName(tmpColId), tmpResults.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    '###############################
                End While
            End If

            '################################################################
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager::getById(" & idControle & ") : " & ex.Message)
            oReturn = Nothing
        End Try
        If Not dbLink Is Nothing Then
            dbLink.free()
        End If
        Return oReturn
    End Function
    Private Shared Function create(ByVal pAgent As Agent) As AutoTest
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim oCtrlRegulier As New AutoTest(pAgent)
        Try
            Dim sqlQuery As String
            Dim id As Integer
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()
            sqlQuery = "SELECT MAX(CTRG_ID) as ctrg_id FROM CONTROLE_REGULIER "
            bddCommande.CommandText = sqlQuery
            Dim obj = bddCommande.ExecuteScalar()
            If IsNumeric(obj) Then
                id = CInt(obj)
            Else
                id = 0
            End If
            oCtrlRegulier.Id = id + 1


            ' Création
            bddCommande.CommandText = "INSERT INTO Controle_Regulier (CTRG_ID) VALUES(" & oCtrlRegulier.Id & ")"
            bddCommande.ExecuteNonQuery()

            Catch ex As Exception
                CSDebug.dispFatal("AutoTestManager - create : " & ex.Message)
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If

        Return oCtrlRegulier
    End Function
    Public Shared Function save(ByVal pCtrlRegulier As AutoTest, Optional bSyncro As Boolean = False) As Boolean
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing

        Try
            bReturn = True
            'Si l'ID n'est pas initialisé => le controle n'a pas été créé
            If Not exists(pCtrlRegulier) Then
                Dim oTemp As AutoTest
                Dim oAgent As Agent
                oAgent = AgentManager.getAgentById(pCtrlRegulier.NumAgent)
                oTemp = create(oAgent)
                If oTemp.Id = -1 Then
                    CSDebug.dispError("ControleRegulierManager.save ERROR : Impossible de créer un nouveau controle")
                    bReturn = False
                Else
                    pCtrlRegulier.setId(oTemp.Id)
                    bReturn = True
                End If
            End If
            If bReturn Then

                If Not bSyncro Then
                    pCtrlRegulier.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                Dim paramsQuery As String
                paramsQuery = ""
                paramsQuery = paramsQuery & " CTRG_date='" & CSDate.ToCRODIPString(pCtrlRegulier.dateControle).Substring(0, 10) & "'  "
                paramsQuery = paramsQuery & " , CTRG_STRUCTUREID=" & pCtrlRegulier.uidstructure & "  "
                paramsQuery = paramsQuery & " , uidstructure=" & pCtrlRegulier.uidstructure & "  "
                paramsQuery = paramsQuery & " , CTRG_TYPE='" & pCtrlRegulier.type & "'  "
                paramsQuery = paramsQuery & " , CTRG_MATID='" & pCtrlRegulier.idMateriel & "'  "
                paramsQuery = paramsQuery & " , CTRG_ETAT=" & pCtrlRegulier.etat & " "
                paramsQuery = paramsQuery & " , CTRG_NUMAGENT='" & pCtrlRegulier.NumAgent & "' "
                paramsQuery = paramsQuery & " , aidagent='" & pCtrlRegulier.aidagent & "' "
                paramsQuery = paramsQuery & " , uidagent='" & pCtrlRegulier.uidagent & "' "
                paramsQuery = paramsQuery & " , uidmateriel='" & pCtrlRegulier.uidmateriel & "' "
                paramsQuery = paramsQuery & pCtrlRegulier.getRootQuery()

                ' On finalise la requete et en l'execute
                oCsdb = New CSDb(True)
                Dim bddCommande As DbCommand
                bddCommande = oCsdb.getConnection().CreateCommand
                Dim strQuery As String
                strQuery = "Update CONTROLE_REGULIER set " & paramsQuery & " WHERE "
                If pCtrlRegulier.Id > 0 Then
                    strQuery = strQuery & " CTRG_ID=" & pCtrlRegulier.Id & ""
                Else
                    strQuery = strQuery & " CTRG_date='" & CSDate.ToCRODIPString(pCtrlRegulier.dateControle).Substring(0, 10) & "'"
                    strQuery = strQuery & " AND CTRG_STRUCTUREID=" & pCtrlRegulier.uidstructure & "  "
                    strQuery = strQuery & " AND CTRG_TYPE='" & pCtrlRegulier.type & "'  "
                    strQuery = strQuery & " AND CTRG_MATID='" & pCtrlRegulier.IdMateriel & "'  "

                End If
                bddCommande.CommandText = strQuery
                bddCommande.ExecuteNonQuery()
                oCsdb.free()
            End If
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager.save ERROR" & ex.Message)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function
    Private Shared Function exists(pCtrlRegulier As AutoTest) As Boolean
        Dim breturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim cmd As DbCommand
            Dim sqlQuery As String
            breturn = True

            cmd = oCSDB.getConnection().CreateCommand()
            sqlQuery = "SELECT Count(*) from CONTROLE_REGULIER where "
            sqlQuery = sqlQuery & " CTRG_date='" & CSDate.ToCRODIPString(pCtrlRegulier.dateControle).Substring(0, 10) & "'"
            sqlQuery = sqlQuery & " AND CTRG_STRUCTUREID=" & pCtrlRegulier.uidstructure & "  "
            sqlQuery = sqlQuery & " AND CTRG_TYPE='" & pCtrlRegulier.type & "'  "
            sqlQuery = sqlQuery & " AND CTRG_MATID='" & pCtrlRegulier.IdMateriel & "'  "

            cmd.CommandText = sqlQuery

            Dim obj
            obj = cmd.ExecuteScalar()
            If IsNumeric(obj) Then
                Dim n As Integer
                n = CInt(obj)
                breturn = (n > 0)
            Else
                breturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("AutoTestManager .exists ERR", ex)
            breturn = False
        End Try
        If oCSDB IsNot Nothing Then
            oCSDB.free()
        End If
        Return breturn
    End Function

    Public Shared Function saveSynchro(ByVal pCtrlRegulier As AutoTest) As Boolean
        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing

        Try
            bReturn = True
            'Si l'ID n'est pas initialisé => le controle n'a pas été créé
            If pCtrlRegulier.Id = -1 Then
                bReturn = False
            End If
            If bReturn Then


                Dim paramsQuery As String
                paramsQuery = ""
                paramsQuery = paramsQuery & " dateModificationCrodip='" & CSDate.ToCRODIPString(pCtrlRegulier.dateModificationCrodip) & "'"

                ' On finalise la requete et en l'execute
                oCsdb = New CSDb(True)
                Dim bddCommande As DbCommand
                bddCommande = oCsdb.getConnection().CreateCommand

                bddCommande.CommandText = "Update CONTROLE_REGULIER set " & paramsQuery & " WHERE CTRG_ID=" & pCtrlRegulier.Id & ""
                bddCommande.ExecuteNonQuery()
                oCsdb.free()
            End If
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager.saveSynchro ERROR" & ex.Message)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function
    Public Shared Function delete(ByVal curObject As AutoTest) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = AutoTestManager.delete(curObject.Id)
        Catch ex As Exception
            CSDebug.dispFatal("ControleManoManager::delete() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function delete(ByVal pIdControle As Integer) As Boolean
        Dim bReturn As Boolean

        Try
            Dim bdd As New CSDb(True)
            bdd.Execute("DELETE FROM `Controle_Regulier` WHERE `ctrg_id`=" & pIdControle & "")
            bdd.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("ControleManoManager::delete() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Rend une collection contenant les controle reguliers effectués
    ''' </summary>
    ''' <param name="idStructure"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getcolControlesReguliers(ByVal pAgent As Agent, Optional ByVal pTypeMateriels As String = "TOUS", Optional ByVal pDateDeb As String = "JJ/MM/AAAA", Optional ByVal pDateFin As String = "JJ/MM/AAAA", Optional ByVal pSynchro As Boolean = False) As List(Of AutoTest)
        Dim ocolReturn As New List(Of AutoTest)
        Try
            If Not pAgent Is Nothing Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim oDBReader As DbDataReader
                Dim sqlQuery As String
                sqlQuery = "SELECT * FROM CONTROLE_REGULIER WHERE CTRG_NUMAGENT='" & pAgent.id & "' "
                If Not (pTypeMateriels = "TOUS" Or String.IsNullOrEmpty(pTypeMateriels)) Then
                    sqlQuery = sqlQuery & " AND CTRG_TYPE = '" & pTypeMateriels & "' "
                End If
                If pDateDeb <> "JJ/MM/AAAA" Then
                    sqlQuery = sqlQuery & " AND CTRG_date >='" & CSDate.ToCRODIPString(pDateDeb).Substring(0, 10) & "'"
                End If
                If pDateFin <> "JJ/MM/AAAA" Then
                    sqlQuery = sqlQuery & " AND CTRG_date <='" & CSDate.ToCRODIPString(pDateFin).Substring(0, 10) & "'"
                End If
                If pSynchro Then
                    sqlQuery = sqlQuery & " AND ( dateModificationAgent > dateModificationCrodip  or dateModificationCrodip is null)"
                End If
                oDBReader = dbLink.getResult2s(sqlQuery & " ORDER BY CTRG_ID")

                '################################################################
                Dim i As Integer = 0
                While oDBReader.Read()
                    '# construction de l'objet
                    'Dim tmpObject As New ControleMano(pAgent)
                    Dim tmpColId As Integer = 0
                    Dim oDBCtrl As New AutoTest(pAgent)
                    oDBCtrl.FillDR(oDBReader)
                    ocolReturn.Add(oDBCtrl)
                End While
                oDBReader.Close()
                dbLink.free()
            End If
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager::getcolControlesReguliers(" & pAgent.numeroNational & ") : " & ex.Message)
            ocolReturn = Nothing
        End Try
        Return ocolReturn
    End Function
    ''' <summary>
    ''' Création des controles
    ''' </summary>
    ''' <param name="pTypeMateriels"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateControlesReguliers(ByVal pAgent As Agent, ByVal pDateControle As Date, Optional ByVal pTypeMateriels As String = "TOUS") As List(Of AutoTest)
        Dim bReturn As Boolean
        Dim oCtrlRegulier As AutoTest
        Dim oColReturn As New List(Of AutoTest)
        Try
            If pTypeMateriels.ToUpper() = "BANC" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrBanc As System.Collections.Generic.List(Of Banc)
                ' On récupère les bancs de l'agent
                arrBanc = BancManager.getBancByAgent(pAgent, False)
                For Each oBanc As Banc In arrBanc
                    oCtrlRegulier = New AutoTest(pAgent, oBanc)
                    oCtrlRegulier.dateControle = pDateControle
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
            If pTypeMateriels.ToUpper() = "MANOC" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrManoC As List(Of ManometreControle)
                ' On récupère les Mano de Controle  de la structure
                arrManoC = ManometreControleManager.getManoControleByAgent(pAgent, False)
                For Each oManoC As ManometreControle In arrManoC
                    oCtrlRegulier = New AutoTest(pAgent, oManoC)
                    oCtrlRegulier.dateControle = pDateControle
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
            'If pTypeMateriels = "MANOE" Or pTypeMateriels.ToUpper() = "TOUS" Then
            '    Dim arrManoE As ManometreEtalon()
            '    ' On récupère les Mano de Etalons  de l'agent
            '    arrManoE = AgentManager.getManoEtalon(pIdStructure, True)
            '    For Each oManoE As ManometreEtalon In arrManoE
            '        oCtrlRegulier = New ControleRegulier(oManoE)
            '        oCtrlRegulier.DateControle = pDateControle
            '        oColReturn.Add(oCtrlRegulier)
            '    Next
            'End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager.CreateControlesReguliers Error " & ex.Message)
            bReturn = False
        End Try

        Return oColReturn
    End Function

    ''' <summary>
    ''' Export des controlesReguliers au format CSV
    ''' </summary>
    ''' <param name="pTypeMateriels"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExportAsCSV(ByVal dDeb As String, ByVal dFin As String, ByVal pAgent As Agent, ByVal pCSVFile As String, Optional ByVal pTypeMateriels As String = "TOUS") As Boolean
        Dim bReturn As Boolean
        Dim oCtrlRegulier As AutoTest
        Dim oCol As List(Of AutoTest)
        Try
            If System.IO.File.Exists(pCSVFile) Then
                System.IO.File.Delete(pCSVFile)
            End If
            Dim oFile As System.IO.StreamWriter
            oFile = System.IO.File.CreateText(pCSVFile)

            oCol = AutoTestManager.getcolControlesReguliers(pAgent, pTypeMateriels, dDeb, dFin)
            oFile.WriteLine("ID;DateControle;IDStructure;NumAgent;type;IdMateriel;etat;dateModifAgent;dateModifCrodip")
            Dim strLine As String
            For Each oCtrlRegulier In oCol
                strLine = oCtrlRegulier.Id & ";" & oCtrlRegulier.dateControle.ToString("d") & ";" & oCtrlRegulier.IdStructure & ";" & oCtrlRegulier.NumAgent & ";" & oCtrlRegulier.TypeLibelle & ";" & oCtrlRegulier.idMateriel & ";" & oCtrlRegulier.etat & ";" & oCtrlRegulier.dateModificationAgent & ";" & oCtrlRegulier.dateModificationCrodip
                oFile.WriteLine(strLine)
            Next
            oFile.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager.ExportAsCSV Error " & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function
#End Region

    'Public Shared Function sendWSControlesReguliers(ByVal pAgent As Agent) As Boolean
    '    Dim bReturn As Boolean

    '    Try
    '        Dim oCol As List(Of AutoTest)
    '        oCol = getcolControlesReguliers(pAgent, , , , True)
    '        If Not oCol Is Nothing Then
    '            If oCol.Count > 0 Then
    '                Dim ArrObject(oCol.Count) As AutoTest
    '                Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
    '                Dim i As Integer
    '                i = 0
    '                For Each obj As AutoTest In oCol
    '                    ArrObject(i) = obj
    '                    i = i + 1
    '                Next
    '                Dim info As String = ""
    '                Dim uid As String = ""
    '                Dim response As Integer = objWSCrodip.SendAutoTest(ArrObject, info, uid)
    '                If response = 0 Or response = 2 Or (GlobalsCRODIP.GLOB_ENV_DEBUG And response = 9) Then
    '                    'Mise à jour de la date de synchro (date Modification CRODIP)
    '                    For Each obj As AutoTest In oCol
    '                        obj.dateModificationCrodip = CSDate.ToCRODIPString(Now())
    '                        saveSynchro(obj)
    '                    Next

    '                End If
    '            End If
    '        End If
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("sendWSControleRegulier : " & ex.Message & ex.InnerException.InnerException.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function
    ''Public Shared Function sendWS2ControlesReguliers(ByVal pAgent As Agent) As Boolean
    '    Dim bReturn As Boolean

    '    Try
    '        Dim oCol As Collection
    '        oCol = getcolControlesReguliers(pAgent, , , , True)
    '        If Not oCol Is Nothing Then
    '            Dim ArrObject(oCol.Count) As AutoTest
    '            Dim objWSCrodip As WSCrodip2.CrodipServerClient = WebServiceCRODIP.getWS2()
    '            Dim i As Integer
    '            i = 0
    '            For Each obj As AutoTest In oCol
    '                ArrObject(i) = obj
    '                i = i + 1
    '            Next
    '            objWSCrodip.SendAutoTest(ArrObject)
    '        End If
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("sendWSManometreControle : " & ex.Message & ex.InnerException.InnerException.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function

End Class
