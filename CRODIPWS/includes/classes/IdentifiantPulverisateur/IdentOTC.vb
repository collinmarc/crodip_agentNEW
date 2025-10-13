Public Class IdentifiantOTC
    Private _IdentOTC As String
    Public Sub New()

    End Sub
    Public Sub New(pIdent As String)
        identifiant = pIdent
    End Sub
    Public Property identifiant() As String
        Get
            Return _IdentOTC
        End Get
        Set(ByVal value As String)
            _IdentOTC = value
        End Set
    End Property
    Private _chargement As String
    Public Property chargement() As String
        Get
            Return _chargement
        End Get
        Set(ByVal value As String)
            _chargement = value
        End Set
    End Property
    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    Private _active As String
    Public Property active() As String
        Get
            Return _active
        End Get
        Set(ByVal value As String)
            _active = value
        End Set
    End Property
End Class
