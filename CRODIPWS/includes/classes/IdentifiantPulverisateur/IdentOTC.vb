Public Class IdentOTC
    Private _IdentOTC As String
    Public Property IdentOTC() As String
        Get
            Return _IdentOTC
        End Get
        Set(ByVal value As String)
            _IdentOTC = value
        End Set
    End Property

End Class
