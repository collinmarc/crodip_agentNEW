Public Class CSDb

    ' Parametres de connexion
    Private _dbHost As String
    Private _dbUser As String
    Private _dbPass As String
    Private _bddConnectString As String
    ' Connexion
    Private _dbPath As String
    Private _dbKeyPath As String
    Private Shared _dbConnection As OleDb.OleDbConnection
    Private _dbCommande As OleDb.OleDbCommand
    ' Query
    Private _queryString As String
    Private _resultReader As System.Data.OleDb.OleDbDataReader
    Private _isExchange As Boolean = False
    Sub New()

        _dbHost = ""
        _dbUser = "developpeur"
        _dbPass = "UmtU8Scb"
        _queryString = ""
#If DEBUG Then
        _dbPath = Environment.CurrentDirectory & "\bdd\crodip_agent_dev.mdb"
        _dbKeyPath = Environment.CurrentDirectory & "\bdd\crodip_agent_dev.mdw"
#Else
        _dbPath = Environment.CurrentDirectory & "\bdd\crodip_agent.mdb"
        _dbKeyPath = Environment.CurrentDirectory & "\bdd\crodip_agent.mdw"
#End If

        _bddConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _dbPath & ";Jet OLEDB:System Database=" & _dbKeyPath & ";User ID=" & _dbUser & ";Password=" & _dbPass & ";Jet OLEDB:Database Password=" & _dbPass & ""

        ' 110727 : arzur_c : mise en place d'un singleton pour la connexion
        If _dbConnection Is Nothing Then
            _dbConnection = New OleDb.OleDbConnection
        End If
        _dbConnection.ConnectionString = _bddConnectString

        _dbCommande = New OleDb.OleDbCommand
        'getInstance()
    End Sub

    '    Sub New()
    '        _queryString = ""
    '#If DEBUG Then
    '        _dbHost = ""
    '        _dbUser = "Developpeur"
    '        _dbPass = "UmtU8Scb"
    '        _dbPath = "F:\Mes documents\NewCo\CRODIP\Projets\TestCrodip\bin\Debug\bdd\crodip_agent_dev.mdb"
    '        _dbKeyPath = "F:\Mes documents\NewCo\CRODIP\Projets\TestCrodip\bin\Debug\bdd\crodip_agent_dev.mdw"
    '#Else
    '        _dbHost = ""
    '        _dbUser = "Developpeur"
    '        _dbPass = "UmtU8Scb"
    '        _dbPath = Environment.CurrentDirectory & "\bdd\crodip_agent.mdb"
    '        _dbKeyPath = Environment.CurrentDirectory & "\bdd\crodip_agent.mdw"
    '#End If
    '        _dbConnection = New OleDb.OleDbConnection
    '        _dbCommande = New OleDb.OleDbCommand
    '        'getInstance()
    '    End Sub
    Sub New(ByVal doConnect As Boolean)
        Me.new()
        If doConnect = True Then
            getInstance()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Me.free()
        MyBase.Finalize()
    End Sub
    Public Function free()
        Try
            ' Test pour fermeture de connection BDD
            If _dbConnection.State() <> 0 Then
                ' On ferme la connexion
                _dbConnection.Close()
            End If
        Catch ex As Exception

        End Try
    End Function

    '############################################################
    '####################### Accesseurs #########################
    '############################################################
    Public Property dbHost() As String
        Get
            Return _dbHost
        End Get
        Set(ByVal Value As String)
            _dbHost = Value
        End Set
    End Property

    Public Property dbUser() As String
        Get
            Return _dbUser
        End Get
        Set(ByVal Value As String)
            _dbUser = Value
        End Set
    End Property

    Public Property dbPass() As String
        Get
            Return _dbPass
        End Get
        Set(ByVal Value As String)
            _dbPass = Value
        End Set
    End Property

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
    Public Function getInstance()
        Try
            ' Test pour fermeture de connection BDD
            If _dbConnection.State() <> 0 Then
                ' On ferme la connexion
                _dbConnection.Close()
            End If
        Catch ex As Exception

        End Try

        ' On test si la connexion est déjà ouverte ou non
        If _dbConnection.State() = 0 Then
            ' Si non, on la configure et on l'ouvre
            '            _dbConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Me._dbPath & ";Jet OLEDB:System Database=" & Me._dbKeyPath & ";User ID=" & Me._dbUser & ";Password=" & Me._dbPass & ";Jet OLEDB:Database Password=" & Me._dbPass & ""
            _dbConnection.Open()
        End If
        _dbCommande.Connection = _dbConnection
    End Function
    Public Function getConnection() As OleDb.OleDbConnection
        Return _dbConnection
    End Function

    Public Function getResults() As System.Data.OleDb.OleDbDataReader
        Dim _resultReader As System.Data.OleDb.OleDbDataReader
        Try
            Dim _dbCommande As System.Data.OleDb.OleDbCommand = getConnection().CreateCommand
            _dbCommande.CommandText = _queryString
            _resultReader = _dbCommande.ExecuteReader
        Catch ex As Exception
            '            Me.free()
            CSDebug.dispError("CSDB.GetResults : " & ex.Message.ToString & vbNewLine & "Query : " & _queryString)
            _resultReader = Nothing
        End Try
        Return _resultReader
    End Function
    Public Function getResults(ByVal queryString As String) As System.Data.OleDb.OleDbDataReader
        _queryString = queryString
        Return getResults()
    End Function

    '############################################################
    '######################## Securite ##########################
    '############################################################
    Public Function secureQuery(ByVal query As String)
        Dim _secureQuery As String

        _secureQuery = query.Replace("'", "''")

        Return _secureQuery

    End Function

    Public Function secureString(ByVal query As String)
        Dim _secureQuery As String
        Try
            _secureQuery = query.Replace("'", "''")
        Catch ex As Exception
            CSDebug.dispFatal("Err 0x000015 : " & ex.Message.ToString)
        End Try
        Return _secureQuery
    End Function

End Class