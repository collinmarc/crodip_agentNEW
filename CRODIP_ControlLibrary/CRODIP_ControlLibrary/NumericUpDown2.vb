Public Class NumericUpDown2
    Inherits NumericUpDown

    Public Sub New()
    End Sub
    Private newPropertyValue As String
    Public ReadOnly Property tb() As Control
        Get
            Return Controls(1)
        End Get
    End Property
    Public ReadOnly Property upDown() As Control
        Get
            Return Controls(0)
        End Get
    End Property
End Class
