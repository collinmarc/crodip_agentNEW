Imports System.Data.OleDb
Public Enum DBTYPE
    AGENT = 0
    ETAT = 1
    DAISY = 2
End Enum
#Region " Base de données locale "


#End Region
Public Class CSDb
    Public Const conf_bddUser As String = "Developpeur"
    Public conf_bddPass As String = "UmtU8Scb"
    Public conf_bddDLPath As String = "crodip_dasylab"
    ' Public conf_bddDLPass = "tRyQe8se"
    Public conf_bddPath As String = "crodip_agent"
    Public conf_bddPath_dev As String = "crodip_agent_dev"

    Public conf_bddEtatPath As String = "crodip_etats"
    Public conf_bddEtatPath_dev As String = "crodip_etats_dev"

    ' Parametres de connexion
    ' Connexion
    Private _dbConnection As OleDb.OleDbConnection
    Private _bddConnectString As String
    Private _dbName As String ' Nom de la base de données
    ' Query
    Private _queryString As String

    Sub New(Optional ByVal doConnect As Boolean = False, Optional pDBType As DBTYPE = DBTYPE.AGENT)
        _queryString = ""
        Select Case pDBType
            Case DBTYPE.AGENT
                If Globals.GLOB_ENV_DEBUG = True Then
                    _dbName = conf_bddPath_dev
                Else
                    _dbName = conf_bddPath
                End If
                _bddConnectString = getConnectString(_dbName)
            Case DBTYPE.ETAT
                _dbName = conf_bddEtatPath
                _bddConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & _dbName & ".mdb"
            Case DBTYPE.DAISY
                _dbName = conf_bddDLPath
                _bddConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & _dbName & ".mdb"
        End Select


        If _dbConnection Is Nothing Then
            _dbConnection = New OleDb.OleDbConnection
        End If
        _dbConnection.ConnectionString = _bddConnectString

        If doConnect = True Then
            If Not getInstance() Then
                CSDebug.dispFatal("CSDB.New ERR : impossible d'ouvrir la base : " & _bddConnectString)
            End If
        End If
    End Sub
    ''' <summary>
    ''' Rend la Chaine de connextion à la base de donnée en fonction de l'environnement
    ''' </summary>
    ''' <param name="pDBName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getbddPathName() As String
        Return ".\bdd\" & _dbName & ".mdb"
    End Function
    Public Function getConnectString(pDBName As String) As String
        Dim bReturn As String
        If Globals.GLOB_ENV_DEBUG = True Then
            bReturn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & pDBName & ".mdb;Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password="
        Else
            bReturn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & pDBName & ".mdb;Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password=" & conf_bddPass & ""
        End If
        Return bReturn
    End Function

    Protected Overrides Sub Finalize()
        Me.free()
        MyBase.Finalize()
        'Try
        '    ' Test pour fermeture de connection BDD
        '    If _dbConnection.State() <> 0 Then
        '        ' On ferme la connexion
        '        _dbConnection.Close()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    ''' <summary>
    ''' Déconnextion de la base de donnée si elle est connectée
    ''' </summary>
    Public Sub free()
        'Me.Finalize()
        Try
            ' Test pour fermeture de connection BDD
            While _dbConnection.State() <> System.Data.ConnectionState.Closed
                ' On ferme la connexion
                _dbConnection.Close()
                If _dbConnection.State <> System.Data.ConnectionState.Closed Then
                    pause(10)
                End If
            End While
        Catch ex As Exception
            'CSDebug.dispError("CSDB.Free ERR : " & ex.Message)
        End Try
    End Sub

    '############################################################
    '####################### Accesseurs #########################
    '############################################################


    Public Property queryString() As String
        Get
            Return _queryString
        End Get
        Set(ByVal Value As String)
            _queryString = Value
        End Set
    End Property

    '############################################################
    '################### Methodes publiques #####################
    '############################################################

    Public Function getInstance() As Boolean
        Dim bReturn As Boolean
        Try
            ' Test pour fermeture de connection BDD
            If _dbConnection.State() <> 0 Then
                ' On ferme la connexion
                _dbConnection.Close()
            End If
        Catch ex As Exception
            CSDebug.dispError("CSDb.getInstance1 ERR : " & ex.Message)
        End Try

        ' on essaie 10 fois la connexion
        Dim nTry As Integer
        Dim bOpen As Boolean
        bOpen = False
        For nTry = 1 To 10
            Try

                If _dbConnection.State() = 0 Then
                    ' Si non, on la configure et on l'ouvre
                    _dbConnection.ConnectionString = _bddConnectString
                    _dbConnection.Open()
                    bOpen = True
                    Exit For
                End If
            Catch ex As Exception
                CSDebug.dispError("CSDb.getInstance2 on " & _bddConnectString & ":" & ex.Message)
            End Try

        Next
        bReturn = bOpen
        Return bReturn
    End Function
    Public Function getConnection() As OleDbConnection
        Return _dbConnection
    End Function

    Public Function getValue(ByVal pQuery As String) As Object
        Dim _resultReader As System.Data.OleDb.OleDbDataReader
        Dim oCSdb As New CSDb(True)
        Dim oReturn As Object = Nothing
        Try
            _resultReader = oCSdb.getResults(pQuery)
            If _resultReader.HasRows Then
                _resultReader.Read()
                oReturn = _resultReader.GetValue(0)
            Else
                oReturn = Nothing
            End If
            _resultReader.Close()
            oCSdb.free()
        Catch ex As Exception
            CSDebug.dispFatal("CSDb::getValue : " & ex.Message.ToString & vbNewLine & "Query : " & _queryString)
        End Try
        Return oReturn
    End Function
    '''
    ''' Execution d'un requete sans retour
    Public Function Execute(ByVal pQuery As String) As Boolean
        _queryString = pQuery
        Return Execute()
    End Function
    '''
    ''' Execution d'un requete sans retour
    Public Function Execute() As Boolean
        Dim bReturn As Boolean
        Try
            Dim _dbCommande As System.Data.OleDb.OleDbCommand = getConnection().CreateCommand
            _dbCommande.CommandText = _queryString
            _dbCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("CSDb::Execute : " & ex.Message.ToString & vbNewLine & "Query : " & _queryString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function getResults() As System.Data.OleDb.OleDbDataReader
        Dim _resultReader As System.Data.OleDb.OleDbDataReader
        Try
            Dim _dbCommande As System.Data.OleDb.OleDbCommand = getConnection().CreateCommand
            _dbCommande.CommandText = _queryString
            _resultReader = _dbCommande.ExecuteReader
        Catch ex As Exception
            '            Me.free()
            CSDebug.dispFatal("CSDb::getResults : " & ex.Message.ToString & vbNewLine & "Query : " & _queryString)
            _resultReader = Nothing
            'CSDebug.dispInfo("Query : " & _queryString)
        End Try
        Return _resultReader
    End Function
    Public Function getResults(ByVal queryString As String) As OleDb.OleDbDataReader
        _queryString = queryString
        Return getResults()
    End Function

    Public Function RAZ_BASE_DONNEES() As Boolean
        Debug.Assert(getConnection().State = ConnectionState.Open, "La connexion doit être ouverte")
        Dim bReturn As Boolean
        Try
            CSDebug.dispError("VIDAGE DE LA BASE DE DONNEES !!!!!")
            Dim bddCommande As OleDbCommand
            bddCommande = getConnection().CreateCommand
            'Vidage conmplet de la base
            bddCommande.CommandText = "DELETE FROM Agent"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentBuseEtalon"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentManoControle"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentManoEtalon"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM BancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Controle_Regulier"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM ControleBancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM ControleManoMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Diagnostic"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticBuses"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticBusesDetail"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticFacture"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticFactureItem"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticItem"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticMano542"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM DiagnosticTroncons833"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Exploitation"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM ExploitationToPulverisateur"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieBancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieManometreControle"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieManometreEtalon"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Logs"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PrestationCategorie"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PrestationTarif"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Pulverisateur"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Structure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Synchronisation"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM IdentifiantPulverisateur"
            bddCommande.ExecuteNonQuery()
            'bddCommande.CommandText = "DELETE FROM VERSION"
            'bddCommande.ExecuteNonQuery()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("CSDB.RAZ_BASE_DONNEES ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    '############################################################
    '######################## Securite ##########################
    '############################################################
 
    Public Shared Function secureString(ByVal pString As String) As String
        Dim _secureString As String
        Try
            _secureString = ""
            If pString IsNot Nothing Then
                _secureString = pString.Replace("'", "''")
            End If
        Catch ex As Exception
            CSDebug.dispError("CSDb::secureString : " & ex.Message.ToString)
            _secureString = ""
        End Try
        Return _secureString
    End Function

    Public Function CompacteDataBase() As Boolean
        Dim bReturn As Boolean
        Try
            Dim jro As JRO.JetEngine
            jro = New JRO.JetEngine()
            Dim bdd2 As String = getConnectString(_dbName & "2")
            If System.IO.File.Exists("./bdd/" & _dbName & "2.mdb") Then
                System.IO.File.Delete("./bdd/" & _dbName & "2.mdb")
            End If
            jro.CompactDatabase(_bddConnectString, bdd2)
            If System.IO.File.Exists("./bdd/" & _dbName & ".mdb") Then
                System.IO.File.Delete("./bdd/" & _dbName & ".mdb")
            End If
            System.IO.File.Move("./bdd/" & _dbName & "2.mdb", "./bdd/" & _dbName & ".mdb")
            '            jro.CompactDatabase(bdd2, _bddConnectString)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispWarn("CSDB.CompateDatabase ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Shared Function ExecuteSQL(pSQL As String) As Boolean
        Dim breturn As Boolean

        breturn = False
        Dim oCsDB As New CSDb(True)
        Try
            oCsDB.Execute(pSQL)
            breturn = True
        Catch ex As Exception
            breturn = False
        End Try
        oCsDB.free()
    End Function


End Class