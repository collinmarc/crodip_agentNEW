
Imports System.Xml.Serialization

<Serializable()>
Public Class RPInfosBuses

    Protected m_infosDescentes As Generic.List(Of String)
    Private _nbDescentes As Integer = 0
    Public Sub New(pnbDescente As Integer)
        m_infosDescentes = New Generic.List(Of String)()

        NbDescentes = pnbDescente
    End Sub
    Public Sub New()
        MyClass.New(0)
    End Sub
    Public Property NbDescentes() As Integer
        Get
            Return _nbDescentes
        End Get
        Set(ByVal value As Integer)
            If value > _nbDescentes Then
                For n As Integer = _nbDescentes To value - 1
                    m_infosDescentes.Add("")
                Next
            End If
            If value < _nbDescentes Then
                For n As Integer = _nbDescentes To value + 1 Step -1
                    m_infosDescentes.RemoveAt(n - 1)
                Next
            End If
            _nbDescentes = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos(pNum As String) As String
        Get
            If pNum <= NbDescentes Then
                Return m_infosDescentes(pNum - 1)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If pNum <= NbDescentes Then
                m_infosDescentes(pNum - 1) = value
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos1 As String
        Get
            Return Infos(1)
        End Get
        Set(ByVal value As String)
            Infos(1) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos2 As String
        Get
            Return Infos(2)
        End Get
        Set(ByVal value As String)
            Infos(2) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos3 As String
        Get
            Return Infos(3)
        End Get
        Set(ByVal value As String)
            Infos(3) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos4 As String
        Get
            Return Infos(4)
        End Get
        Set(ByVal value As String)
            Infos(4) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos5 As String
        Get
            Return Infos(5)
        End Get
        Set(ByVal value As String)
            Infos(5) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos6 As String
        Get
            Return Infos(6)
        End Get
        Set(ByVal value As String)
            Infos(6) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos7 As String
        Get
            Return Infos(7)
        End Get
        Set(ByVal value As String)
            Infos(7) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos8 As String
        Get
            Return Infos(8)
        End Get
        Set(ByVal value As String)
            Infos(8) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos9 As String
        Get
            Return Infos(9)
        End Get
        Set(ByVal value As String)
            Infos(9) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos10 As String
        Get
            Return Infos(10)
        End Get
        Set(ByVal value As String)
            Infos(10) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos11 As String
        Get
            Return Infos(11)
        End Get
        Set(ByVal value As String)
            Infos(11) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos12 As String
        Get
            Return Infos(12)
        End Get
        Set(ByVal value As String)
            Infos(12) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos13 As String
        Get
            Return Infos(13)
        End Get
        Set(ByVal value As String)
            Infos(13) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos14 As String
        Get
            Return Infos(14)
        End Get
        Set(ByVal value As String)
            Infos(14) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos15 As String
        Get
            Return Infos(15)
        End Get
        Set(ByVal value As String)
            Infos(15) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos16 As String
        Get
            Return Infos(16)
        End Get
        Set(ByVal value As String)
            Infos(16) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos17 As String
        Get
            Return Infos(17)
        End Get
        Set(ByVal value As String)
            Infos(17) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos18 As String
        Get
            Return Infos(18)
        End Get
        Set(ByVal value As String)
            Infos(18) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos19 As String
        Get
            Return Infos(19)
        End Get
        Set(ByVal value As String)
            Infos(19) = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Infos20 As String
        Get
            Return Infos(20)
        End Get
        Set(ByVal value As String)
            Infos(20) = value
        End Set
    End Property
End Class
