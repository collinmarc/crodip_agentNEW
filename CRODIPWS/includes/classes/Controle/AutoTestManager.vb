Imports System.Collections.Generic
Imports System.Data.Common

Public Class AutoTestManager
    Inherits RootManager

#Region "Methodes Web Service"

    Public Shared Function getWSAutoTestById(pAgent As Agent, ByVal pmanometre_uid As Integer) As AutoTest
        Dim oreturn As AutoTest
        oreturn = getWSByKey(Of AutoTest)(pmanometre_uid, "")
        Return oreturn
    End Function

    Public Shared Function SendWSAutoTest(pAgent As Agent, ByVal pobj As AutoTest, ByRef pReturn As AutoTest) As Integer
        Dim nreturn As Integer
        Try
            nreturn = SendWS(Of AutoTest)(pobj, pReturn)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSAutoTest : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function
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
            oCsdb = New CSDb(True)
            bddCommande = oCsdb.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO Controle_Regulier (CTRG_date) VALUES(NULL)"
            bddCommande.ExecuteNonQuery()

            '## Execution de la requete
            Dim oDBReader As DbDataReader
            Dim sqlQuery As String
            sqlQuery = "SELECT MAX(CTRG_ID) as ctrg_id FROM CONTROLE_REGULIER "
            oDBReader = oCsdb.getResult2s(sqlQuery)

            '################################################################
            Dim i As Integer = 0
            oDBReader.Read()
            If oDBReader.HasRows Then
                Dim tmpColId As Integer = 0
                If Not oDBReader.IsDBNull(tmpColId) Then
                    oCtrlRegulier.setId(oDBReader.GetInt32(tmpColId))
                End If
            End If
            oDBReader.Close()

        Catch ex As Exception
            CSDebug.dispFatal("ControleregulierManager - create : " & ex.Message)
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
            If pCtrlRegulier.Id = -1 Then
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
                paramsQuery = paramsQuery & " CTRG_date='" & CSDate.ToCRODIPString(pCtrlRegulier.DateControle).Substring(0, 10) & "'  "
                paramsQuery = paramsQuery & " , CTRG_STRUCTUREID=" & pCtrlRegulier.IdStructure & "  "
                paramsQuery = paramsQuery & " , CTRG_TYPE='" & pCtrlRegulier.Type & "'  "
                paramsQuery = paramsQuery & " , CTRG_MATID='" & pCtrlRegulier.IdMateriel & "'  "
                paramsQuery = paramsQuery & " , CTRG_ETAT=" & pCtrlRegulier.Etat & " "
                paramsQuery = paramsQuery & " , CTRG_NUMAGENT='" & pCtrlRegulier.NumAgent & "' "
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.TOCRODIPString(pCtrlRegulier.dateModificationAgent) & "'"
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.TOCRODIPString(pCtrlRegulier.dateModificationCrodip) & "'"

                ' On finalise la requete et en l'execute
                oCsdb = New CSDb(True)
                Dim bddCommande As DbCommand
                bddCommande = oCsdb.getConnection().CreateCommand

                bddCommande.CommandText = "Update CONTROLE_REGULIER set " & paramsQuery & " WHERE CTRG_ID=" & pCtrlRegulier.Id & ""
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
                paramsQuery = paramsQuery & " dateModificationCrodip='" & CSDate.TOCRODIPString(pCtrlRegulier.dateModificationCrodip) & "'"

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
                sqlQuery = "SELECT * FROM CONTROLE_REGULIER WHERE CTRG_NUMAGENT='" & pAgent.uid & "' "
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
                    oDBCtrl.Fill(oDBReader)
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
                    oCtrlRegulier.DateControle = pDateControle
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
            If pTypeMateriels.ToUpper() = "MANOC" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrManoC As List(Of ManometreControle)
                ' On récupère les Mano de Controle  de la structure
                arrManoC = ManometreControleManager.getManoControleByAgent(pAgent, False)
                For Each oManoC As ManometreControle In arrManoC
                    oCtrlRegulier = New AutoTest(pAgent, oManoC)
                    oCtrlRegulier.DateControle = pDateControle
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
                strLine = oCtrlRegulier.Id & ";" & oCtrlRegulier.DateControle.ToString("d") & ";" & oCtrlRegulier.IdStructure & ";" & oCtrlRegulier.NumAgent & ";" & oCtrlRegulier.TypeLibelle & ";" & oCtrlRegulier.IdMateriel & ";" & oCtrlRegulier.Etat & ";" & oCtrlRegulier.dateModificationAgent & ";" & oCtrlRegulier.dateModificationCrodip
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


End Class
