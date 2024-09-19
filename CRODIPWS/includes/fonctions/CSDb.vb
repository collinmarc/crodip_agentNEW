Imports System.Data.Common
Imports Microsoft.Data.Sqlite
'Imports System.Data.OleDb

Public Class CSDb
    Public Enum EnumDBTYPE
        MSACCESS = 0
        SQLITE = 1
    End Enum

    Public Const conf_bddUser As String = "Developpeur"
    Public conf_bddPass As String = "UmtU8Scb"
    Public conf_bddDLPath As String = "crodip_dasylab"
    ' Public conf_bddDLPass = "tRyQe8se"
    Public conf_bddPath As String = ""
    Public conf_bddPath_dev As String = ""

    Public conf_bddEtatPath As String = "crodip_etats"
    Public conf_bddEtatPath_dev As String = "crodip_etats_dev"

    Protected DBextension As String = ".mdb"
    ' Parametres de connexion
    ' Connexion
    Protected Shared _dbConnection As DbConnection = Nothing
    Protected _bddConnectString As String
    Protected _dbName As String ' Nom de la base de données
    ' Query
    Private _queryString As String
    Public Shared _DBTYPE As CSDb.EnumDBTYPE = CSDb.EnumDBTYPE.SQLITE

    Sub New(Optional ByVal doConnect As Boolean = False, Optional pdbPath As String = "", Optional pdbExtension As String = "")
        If _dbConnection Is Nothing Then
            _queryString = ""
            If _DBTYPE = EnumDBTYPE.MSACCESS Then
                If pdbPath = "" Then
                    conf_bddPath = My.Settings.DB
                Else
                    conf_bddPath = pdbPath
                End If

                If pdbExtension = "" Then
                    DBextension = My.Settings.DBExtension
                Else
                    DBextension = pdbExtension
                End If
                If conf_bddPath = "" Then
                    conf_bddPath = "cropdip_agent"
                End If
                conf_bddPath_dev = conf_bddPath & "_dev"

                If GlobalsCRODIP.GLOB_ENV_DEBUG = True Then
                    _dbName = conf_bddPath_dev
                Else
                    _dbName = conf_bddPath
                End If
            Else
                _dbName = My.Settings.DB
                DBextension = My.Settings.DBExtension
            End If

            _bddConnectString = getConnectString(_dbName, _DBTYPE)


            If _dbConnection Is Nothing Then
                Select Case _DBTYPE
                    Case EnumDBTYPE.MSACCESS
                        _dbConnection = New OleDb.OleDbConnection
                        _dbConnection.ConnectionString = _bddConnectString
                    Case EnumDBTYPE.SQLITE
                        _dbConnection = New Microsoft.Data.Sqlite.SqliteConnection()
                        Dim oBuider As New Microsoft.Data.Sqlite.SqliteConnectionStringBuilder()
                        oBuider.DataSource = "bdd/" & My.Settings.DB & My.Settings.DBExtension
                        oBuider.Pooling = True
                        _dbConnection.ConnectionString = oBuider.ConnectionString
                End Select
            End If


        End If

        If doConnect = True Then
            If Not getInstance() Then
                CSDebug.dispFatal("CSDB.New ERR : impossible d'ouvrir la base : " & _bddConnectString)
            End If
        End If
    End Sub

    Public Function IsLocked() As Boolean
        Dim bReturn As Boolean = False

        Try

            Dim oCmd As Microsoft.Data.Sqlite.SqliteCommand
            oCmd = _dbConnection.CreateCommand()
            oCmd.CommandText = "BEGIN EXCLUSIVE"
            oCmd.CommandTimeout = 1
            oCmd.ExecuteNonQuery()

            oCmd = _dbConnection.CreateCommand()
            oCmd.CommandText = "COMMIT"
            oCmd.CommandTimeout = 1
            oCmd.ExecuteNonQuery()
            bReturn = False
        Catch ex As Microsoft.Data.Sqlite.SqliteException
            bReturn = True

        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend la Chaine de connextion à la base de donnée en fonction de l'environnement
    ''' </summary>
    ''' <param name="pDBName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getbddPathName() As String
        Return ".\bdd\" & _dbName & DBextension
    End Function
    Public Function getConnectString(pDBName As String, pdbType As EnumDBTYPE) As String
        Dim bReturn As String = ""
        Select Case pdbType
            Case EnumDBTYPE.MSACCESS
                If GlobalsCRODIP.GLOB_ENV_DEBUG = True Then
                    If DBextension = ".accdb" Then
                        bReturn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\bdd\" & pDBName & DBextension & ";User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;Jet OLEDB:Database Password="
                    Else
                        bReturn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\bdd\" & pDBName & DBextension & ";Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password="
                    End If

                Else
                    If DBextension = ".accdb" Then
                        bReturn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\bdd\" & pDBName & DBextension & ";User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;Jet OLEDB:Database Password=" & conf_bddPass & ""
                    Else
                        bReturn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=.\bdd\" & pDBName & DBextension & ";User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:System Database=.\bdd\" & pDBName & ".mdw;Jet OLEDB:Database Password=" & conf_bddPass & ""
                    End If
                End If
            Case EnumDBTYPE.SQLITE
                bReturn = "Data Source=.\bdd\" & pDBName & ".db3;Pooling=true"
        End Select

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
        nInstance = nInstance - 1
        If nInstance <= 0 Then
            Try
                '' Test pour fermeture de connection BDD
                'While _dbConnection.State() <> System.Data.ConnectionState.Closed
                '    ' On ferme la connexion
                '    _dbConnection.Close()
                '    If _dbConnection.State <> System.Data.ConnectionState.Closed Then
                '        pause(10)
                '    End If
                'End While
                'nInstance = 0
            Catch ex As Exception
                'CSDebug.dispError("CSDB.Free ERR : " & ex.Message)
            End Try
            nInstance = 0

        End If
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
    Protected Shared nInstance As Integer = 0
    Public ReadOnly Property nbInstances() As String
        Get
            Return nInstance
        End Get
    End Property
    Public Function getInstance() As Boolean
        Dim bReturn As Boolean
        'Try
        '    ' Test pour fermeture de connection BDD
        '    If _dbConnection.State <> ConnectionState.Closed Then
        '        free()
        '    End If
        'Catch ex As Exception
        '    CSDebug.dispError("CSDb.getInstance1 ERR : " & ex.Message)
        'End Try
        bReturn = True
        If nInstance = 0 Then
            ' on essaie 10 fois la connexion
            Dim nTry As Integer
            For nTry = 1 To 10
                Try

                    ' Si non, on la configure et on l'ouvre
                    _dbConnection.Open()
                    If _DBTYPE = EnumDBTYPE.SQLITE Then
                        If IsLocked() Then
                            CSDebug.dispFatal("CSDB.GetInstance DB is Locked")
                        End If
                    End If
                    Exit For
                Catch ex As Exception
                    CSDebug.dispError("CSDb.getInstance2 on " & _dbConnection.ConnectionString & ":", ex)
                    bReturn = False
                End Try
            Next
        End If
        nInstance = nInstance + 1
        Return bReturn
    End Function
    Public Function getConnection() As DbConnection
        Return _dbConnection
    End Function
    Public Shared Sub resetConnection()
        If _dbConnection IsNot Nothing Then
            _dbConnection.Close()
        End If
        _dbConnection = Nothing
        nInstance = 0
    End Sub


    Public Function getValue(ByVal pQuery As String) As Object
        Dim bBDFermee As Boolean = isClose()
        If bBDFermee Then
            getInstance()
        End If
        Dim oReturn As Object = Nothing
        Try
            Dim oCmd As DbCommand
            oCmd = getConnection().CreateCommand
            oCmd.CommandText = pQuery
            oReturn = oCmd.ExecuteScalar()
            If bBDFermee Then
                free()
            End If
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
            Dim _dbCommande As DbCommand = getConnection().CreateCommand
            _dbCommande.CommandText = _queryString
            _dbCommande.ExecuteNonQuery()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("CSDb::Execute : " & ex.Message.ToString & vbNewLine & "Query : " & _queryString)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function getResult2s() As DbDataReader
        Dim _resultReader As DbDataReader
        Try
            Dim _dbCommande As DbCommand = getConnection().CreateCommand
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
    Public Function getResult2s(ByVal queryString As String) As DbDataReader
        _queryString = queryString
        Return getResult2s()
    End Function
    Public Function getLastId() As Integer
        Dim bddCommande As DbCommand
        Dim nReturn As Integer
        Try

            bddCommande = getConnection().CreateCommand
            If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
                bddCommande.CommandText = "SELECT last_insert_rowid()"
            Else
                bddCommande.CommandText = "SELECT @@identity"

            End If
            nReturn = CInt(bddCommande.ExecuteScalar())
        Catch ex As Exception
            CSDebug.dispError("CSDB.getLastId ERR", ex)
            nReturn = -1
        End Try
        Return nReturn
    End Function
    Public Function RAZ_BASE_DONNEES() As Boolean
        Debug.Assert(getConnection().State = ConnectionState.Open, "La connexion doit être ouverte")
        Dim bReturn As Boolean
        Try
            CSDebug.dispError("VIDAGE DE LA BASE DE DONNEES !!!!!")

            Dim bddCommande As DbCommand
            bddCommande = getConnection().CreateCommand
            'Vidage conmplet de la base
            bddCommande.CommandText = "DELETE FROM facture"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM factureItem"
            bddCommande.ExecuteNonQuery()

            bddCommande.CommandText = "DELETE FROM ControleBancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM ControleManoMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieBancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieManometreControle"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM FicheVieManometreEtalon"
            bddCommande.ExecuteNonQuery()

            bddCommande.CommandText = "DELETE FROM PoolBuse"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PoolManoC"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PoolManoE"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentBuseEtalon"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentManoControle"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM AgentManoEtalon"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM BancMesure"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PoolBanc"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Controle_Regulier"
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
            bddCommande.CommandText = "DELETE FROM Diagnostic"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM ExploitationToPulverisateur"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Exploitation"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Pulverisateur"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM IdentifiantPulverisateur"
            bddCommande.ExecuteNonQuery()

            bddCommande.CommandText = "DELETE FROM PrestationTarif"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM PrestationCategorie"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Synchronisation"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Agent"
            bddCommande.ExecuteNonQuery()

            bddCommande.CommandText = "DELETE FROM AgentPC"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Pool"
            bddCommande.ExecuteNonQuery()
            bddCommande.CommandText = "DELETE FROM Structure"
            bddCommande.ExecuteNonQuery()
            'bddCommande.CommandText = "DELETE FROM VERSION"
            'bddCommande.ExecuteNonQuery()
            _dbConnection.Close()
            nInstance = 0
            getInstance()
            bddCommande = getConnection().CreateCommand
            bddCommande.CommandText = "VACUUM"
            bddCommande.ExecuteNonQuery()

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
        '    Dim bReturn As Boolean
        '    Try
        '        Dim jro As JRO.JetEngine
        '        jro = New JRO.JetEngine()
        '        Dim bdd2 As String = getConnectString(_dbName & "2", EnumDBTYPE.MSACCESS)
        '        If System.IO.File.Exists("./bdd/" & _dbName & "2" & DBextension) Then
        '            System.IO.File.Delete("./bdd/" & _dbName & "2" & DBextension)
        '        End If
        '        jro.CompactDatabase(_bddConnectString, bdd2)
        '        If System.IO.File.Exists("./bdd/" & _dbName & DBextension) Then
        '            System.IO.File.Delete("./bdd/" & _dbName & DBextension)
        '        End If
        '        System.IO.File.Move("./bdd/" & _dbName & "2" & DBextension, "./bdd/" & _dbName & DBextension)
        '        bReturn = True
        '    Catch ex As Exception
        '        CSDebug.dispWarn("CSDB.CompateDatabase ERR" & ex.Message)
        '        bReturn = False
        '    End Try
        '    Return bReturn
    End Function

    Public Function isOpen() As Boolean
        Return (getConnection().State = ConnectionState.Open)
    End Function
    Public Function isClose() As Boolean
        Return (getConnection().State = ConnectionState.Closed)
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