Public Class RPInfosBuses

    Private _infosDescentes As Generic.List(Of String)
    Private _nbDescentes As Integer
    Public Sub New(pnbDescente As Integer)
        NbDescentes = pnbDescente
        _infosDescentes = New Generic.List(Of String)()
        For n As Integer = 1 To pnbDescente
            _infosDescentes.Add("Test" & n)
        Next
    End Sub
    Public Property NbDescentes() As Integer
        Get
            Return _nbDescentes
        End Get
        Set(ByVal value As Integer)
            _nbDescentes = value
        End Set
    End Property
    Public Property Infos(pNum As String) As String
        Get
            Return _infosDescentes(pNum - 1)
        End Get
        Set(ByVal value As String)
            _infosDescentes(pNum - 1) = value
        End Set
    End Property

    Public Property Infos1 As String
        Get
            Return Infos(1)
        End Get
        Set(ByVal value As String)
            Infos(1) = value
        End Set
    End Property
    Public Property Infos2 As String
        Get
            Return Infos(2)
        End Get
        Set(ByVal value As String)
            Infos(2) = value
        End Set
    End Property
    Public Property Infos3 As String
        Get
            Return Infos(3)
        End Get
        Set(ByVal value As String)
            Infos(3) = value
        End Set
    End Property
    Public Property Infos4 As String
        Get
            Return Infos(4)
        End Get
        Set(ByVal value As String)
            Infos(4) = value
        End Set
    End Property
    Public Property Infos5 As String
        Get
            Return Infos(5)
        End Get
        Set(ByVal value As String)
            Infos(5) = value
        End Set
    End Property
    Public Property Infos6 As String
        Get
            Return Infos(6)
        End Get
        Set(ByVal value As String)
            Infos(6) = value
        End Set
    End Property
    Public Property Infos7 As String
        Get
            Return Infos(7)
        End Get
        Set(ByVal value As String)
            Infos(7) = value
        End Set
    End Property
    Public Property Infos8 As String
        Get
            Return Infos(8)
        End Get
        Set(ByVal value As String)
            Infos(8) = value
        End Set
    End Property
    Public Property Infos9 As String
        Get
            Return Infos(9)
        End Get
        Set(ByVal value As String)
            Infos(9) = value
        End Set
    End Property
    Public Property Infos10 As String
        Get
            Return Infos(10)
        End Get
        Set(ByVal value As String)
            Infos(10) = value
        End Set
    End Property
End Class
