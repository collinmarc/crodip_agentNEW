Public Class ControleRegulierManager


#Region "Methodes Locales"

    Public Shared Function getById(ByVal idControle As Integer) As ControleRegulier
        Debug.Assert(idControle <> 0)
        Dim oReturn As ControleRegulier
        Dim dbLink As CSDb
        Try
            '## Préparation de la connexion
            dbLink = New CSDb(True)
            '## Execution de la requete
            Dim tmpResults As System.Data.OleDb.OleDbDataReader
            tmpResults = dbLink.getResults("SELECT * FROM `Controle_Regulier` WHERE ctrg_id=" & idControle & "")
            '################################################################
            Dim i As Integer = 0
            If tmpResults.HasRows Then
                oReturn = New ControleRegulier()
            End If
            While tmpResults.Read()
                '# Construction de l'objet
                Dim tmpColId As Integer = 0
                While tmpColId < tmpResults.FieldCount()
                    If Not tmpResults.IsDBNull(tmpColId) Then
                        oReturn.Fill(tmpResults.GetName(tmpColId), tmpResults.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                '###############################
            End While
            '################################################################
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("ControleRegulierManager::getById(" & idControle & ") : " & ex.Message)
            oReturn = Nothing
        End Try
        If Not dbLink Is Nothing Then
            dbLink.free()
        End If
        Return oReturn
    End Function
    Private Shared Function create() As ControleRegulier
        Dim oCSDB As CSDb
        Dim bddCommande As OleDb.OleDbCommand
        Dim oCtrlRegulier As New ControleRegulier()
        Try
            oCSDB = New CSDb(True)
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO Controle_Regulier (CTRG_date) VALUES(NULL)"
            bddCommande.ExecuteNonQuery()

            '## Execution de la requete
            Dim oDBReader As System.Data.OleDb.OleDbDataReader
            Dim sqlQuery As String
            sqlQuery = "SELECT MAX(CTRG_ID) as ctrg_id FROM CONTROLE_REGULIER "
            oDBReader = oCSDB.getResults(sqlQuery)

            '################################################################
            Dim i As Integer = 0
            oDBReader.Read()
            If oDBReader.HasRows Then
                Dim tmpColId As Integer = 0
                If Not oDBReader.IsDBNull(tmpColId) Then
                    oCtrlRegulier.setId(oDBReader.GetInt32(tmpColId))
                End If
            End If

        Catch ex As Exception
            CSDebug.dispFatal("ControleregulierManager - create : " & ex.Message)
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If

        Return oCtrlRegulier
    End Function
    Public Shared Function save(ByVal pCtrlRegulier As ControleRegulier) As Boolean
        Dim bReturn As Boolean
        Dim oCSDB As CSDb

        Try
            'Si l'ID n'est pas initialisé => le controle n'a pas été créé
            If pCtrlRegulier.Id = -1 Then
                Dim oTemp As ControleRegulier
                oTemp = create()
                If oTemp.Id = -1 Then
                    CSDebug.dispError("ControleRegulierManager.save ERROR : Impossible de créer un nouveau controle")
                    bReturn = False
                Else
                    pCtrlRegulier.setId(oTemp.Id)
                    bReturn = True
                End If
            End If
            If bReturn Then
                Dim paramsQuery As String
                paramsQuery = ""
                paramsQuery = paramsQuery & " CTRG_date='" & CSDate.mysql2access(pCtrlRegulier.DateControle) & "'  "
                paramsQuery = paramsQuery & " , CTRG_STRUCTUREID=" & pCtrlRegulier.IdStructure & "  "
                paramsQuery = paramsQuery & " , CTRG_TYPE='" & pCtrlRegulier.Type & "'  "
                paramsQuery = paramsQuery & " , CTRG_MATID='" & pCtrlRegulier.IdMateriel & "'  "
                paramsQuery = paramsQuery & " , CTRG_ETAT=" & pCtrlRegulier.Etat & " "
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.mysql2access(pCtrlRegulier.dateModificationAgent) & "'"
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.mysql2access(pCtrlRegulier.dateModificationCrodip) & "'"

                ' On finalise la requete et en l'execute
                oCSDB = New CSDb(True)
                Dim bddCommande As OleDb.OleDbCommand
                bddCommande = oCSDB.getConnection().CreateCommand

                bddCommande.CommandText = "Update CONTROLE_REGULIER set " & paramsQuery & " WHERE CTRG_ID=" & pCtrlRegulier.Id & ""
                bddCommande.ExecuteNonQuery()
                oCSDB.free()
            End If
        Catch ex As Exception
            CSDebug.dispError("ControleRegulierManager.save ERROR" & ex.Message)
            bReturn = False
        End Try
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function

    Public Shared Function delete(ByVal curObject As ControleRegulier) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = ControleRegulierManager.delete(curObject.Id)
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
            bdd.getResults("DELETE FROM `Controle_Regulier` WHERE `ctrg_id`=" & pIdControle & "")
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
    Public Shared Function getcolControlesReguliers(ByVal idStructure As String, Optional ByVal pTypeMateriels As String = "TOUS", Optional pDateDeb As String = "JJ/MM/AAAA", Optional pDateFin As String = "JJ/MM/AAAA") As Collection
        Dim ocolReturn As New Collection
        Try
            If Not idStructure Is Nothing Then
                '## Préparation de la connexion
                Dim dbLink As New CSDb(True)
                '## Execution de la requete
                Dim oDBReader As System.Data.OleDb.OleDbDataReader
                Dim sqlQuery As String
                sqlQuery = "SELECT * FROM CONTROLE_REGULIER WHERE CTRG_STRUCTUREID=" & idStructure & " "
                If Not (pTypeMateriels = "TOUS" Or String.IsNullOrEmpty(pTypeMateriels)) Then
                    sqlQuery = sqlQuery & " AND CTRG_TYPE = '" & pTypeMateriels & "' "
                End If
                If pDateDeb <> "JJ/MM/AAAA" Then
                    sqlQuery = sqlQuery & " AND CTRG_date >=#" & access2mysql(pDateDeb) & "#"
                End If
                If pDateFin <> "JJ/MM/AAAA" Then
                    sqlQuery = sqlQuery & " AND CTRG_date <=#" & access2mysql(pDateFin) & "#"
                End If
                oDBReader = dbLink.getResults(sqlQuery & " ORDER BY CTRG_ID")

                '################################################################
                Dim i As Integer = 0
                While oDBReader.Read()
                    '# Construction de l'objet
                    Dim tmpObject As New ControleMano
                    Dim tmpColId As Integer = 0
                    Dim oDBCtrl As New ControleRegulier()
                    oDBCtrl.Fill(oDBReader)
                    ocolReturn.Add(oDBCtrl)
                End While
                dbLink.free()
            End If
        Catch ex As Exception
            CSDebug.dispFatal("ControleRegulierManager::getcolControlesReguliers(" & idStructure & ") : " & ex.Message)
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
    Public Shared Function CreateControlesReguliers(pIdStructure As String, Optional ByVal pTypeMateriels As String = "TOUS") As Collection
        Dim bReturn As Boolean
        Dim oCtrlRegulier As ControleRegulier
        Dim oColReturn As Collection = New Collection()
        Try
            If pTypeMateriels.ToUpper() = "BANC" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrBanc As Banc()
                ' On récupère les bancs de l'agent
                arrBanc = AgentManager.getBanc(pIdStructure, True)
                For Each oBanc As Banc In arrBanc
                    oCtrlRegulier = New ControleRegulier(oBanc)
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
            If pTypeMateriels.ToUpper() = "MANOC" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrManoC As ManometreControle()
                ' On récupère les Mano de Controle  de l'agent
                arrManoC = AgentManager.getManoControle(pIdStructure, True)
                For Each oManoC As ManometreControle In arrManoC
                    oCtrlRegulier = New ControleRegulier(oManoC)
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
            If pTypeMateriels = "MANOE" Or pTypeMateriels.ToUpper() = "TOUS" Then
                Dim arrManoE As ManometreEtalon()
                ' On récupère les Mano de Etalons  de l'agent
                arrManoE = AgentManager.getManoEtalon(pIdStructure, True)
                For Each oManoE As ManometreEtalon In arrManoE
                    oCtrlRegulier = New ControleRegulier(oManoE)
                    oColReturn.Add(oCtrlRegulier)
                Next
            End If
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
    Public Shared Function ExportAsCSV(dDeb As String, dFin As String, pIdStructure As String, pCSVFile As String, Optional pTypeMateriels As String = "TOUS") As Boolean
        Dim bReturn As Boolean
        Dim oCtrlRegulier As ControleRegulier
        Dim oCol As Collection
        Try
            If System.IO.File.Exists(pCSVFile) Then
                System.IO.File.Delete(pCSVFile)
            End If
            Dim oFile As System.IO.StreamWriter
            oFile = System.IO.File.CreateText(pCSVFile)

            oCol = ControleRegulierManager.getcolControlesReguliers(pIdStructure, pTypeMateriels, dDeb, dFin)
            oFile.WriteLine("ID;DateControle;IDStructure;type;IdMateriel;etat;dateModifAgent;dateModifCrodip")
            Dim strLine As String
            For Each oCtrlRegulier In oCol
                strLine = oCtrlRegulier.Id & ";" & oCtrlRegulier.DateControle & ";" & oCtrlRegulier.IdStructure & ";" & oCtrlRegulier.Type & ";" & oCtrlRegulier.IdMateriel & ";" & oCtrlRegulier.Etat & ";" & oCtrlRegulier.dateModificationAgent & ";" & oCtrlRegulier.dateModificationCrodip
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
