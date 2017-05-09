Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc833
    '          <!-- Hétérogénéité-->
    '     <limite8332>10</limite8332>
    '    <!-- Ecart-->
    '   <limite8333>10</limite8333>

    Private m_Limite8332 As String
    Private m_Limite8333 As String
    Private m_Pression1 As String
    Private m_Pression2 As String
    Private m_Pression3 As String
    Private m_Pression4 As String
    Private m_PressionDefaut As String

    Public Property limite8332 As String
        Get
            Return m_Limite8332
        End Get
        Set(value As String)
            m_Limite8332 = value.Replace(".", ",")
        End Set
    End Property

    Public Property limite8333 As String
        Get
            Return m_Limite8333
        End Get
        Set(value As String)
            m_Limite8333 = value.Replace(".", ",")
        End Set
    End Property
    Public Property Pression1 As String
        Get
            Return m_Pression1
        End Get
        Set(value As String)
            m_Pression1 = value.Replace(".", ",")
        End Set
    End Property
    Public Property Pression2 As String
        Get
            Return m_Pression2
        End Get
        Set(value As String)
            m_Pression2 = value.Replace(".", ",")
        End Set
    End Property
    Public Property Pression3 As String
        Get
            Return m_Pression3
        End Get
        Set(value As String)
            m_Pression3 = value.Replace(".", ",")
        End Set
    End Property
    Public Property Pression4 As String
        Get
            Return m_Pression4
        End Get
        Set(value As String)
            m_Pression4 = value.Replace(".", ",")
        End Set
    End Property
    Public Property PressionParDefaut As String
        Get
            Return m_PressionDefaut
        End Get
        Set(value As String)
            m_PressionDefaut = value.Replace(".", ",")
        End Set
    End Property

End Class
