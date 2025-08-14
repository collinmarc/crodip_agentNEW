Public Class Annomalie
    Private _critere As String
    Public Property critere() As String
        Get
            Return _critere
        End Get
        Set(ByVal value As String)
            _critere = value
        End Set
    End Property
    Private _valeurAgent As String
    Public Property valeurAgent() As String
        Get
            Return _valeurAgent
        End Get
        Set(ByVal value As String)
            _valeurAgent = value
        End Set
    End Property
    Private _valeurOTC As String
    Public Property valeurOTC() As String
        Get
            Return _valeurOTC
        End Get
        Set(ByVal value As String)
            _valeurOTC = value
        End Set
    End Property
    Private _bValeurAgentOK As Boolean = False
    Public Property bValeurAgentOK() As Boolean
        Get
            Return _bValeurAgentOK
        End Get
        Set(ByVal value As Boolean)
            _bValeurAgentOK = value
        End Set
    End Property
    Private _bValeurOTCOK As Boolean = False
    Public Property bvaleurOTCOK() As Boolean
        Get
            Return _bValeurOTCOK
        End Get
        Set(ByVal value As Boolean)
            _bValeurOTCOK = value
        End Set
    End Property
End Class
