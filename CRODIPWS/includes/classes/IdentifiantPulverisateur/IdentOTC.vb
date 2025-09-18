Public Class IdentifiantOTC
    Private _IdentOTC As String
    Public Sub New()

    End Sub
    Public Sub New(pIdent As String)
        IdentOTC = pIdent
    End Sub

    Public Property IdentOTC() As String
        Get
            Return _IdentOTC
        End Get
        Set(ByVal value As String)
            _IdentOTC = value
        End Set
    End Property

End Class
