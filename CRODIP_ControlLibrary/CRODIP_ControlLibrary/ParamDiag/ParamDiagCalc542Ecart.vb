Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc542Ecart
    Public Const ECARTVALEUR As String = "VALEUR"
    Public Const ECARTPCT As String = "%_PRESSION_REELLE"
    Private m_typeValeur As String
    Private m_mini As String
    Private m_maxi As String
    Private m_Imprecision As Integer

    Public Sub New()

    End Sub
    Public Sub New(pType As String, pMini As String, pMaxi As String, pImprecision As Integer)
        m_typeValeur = pType
        m_mini = pMini
        m_maxi = pMaxi
        m_Imprecision = pImprecision
    End Sub
    <XmlAttribute("TypeValeur")>
    Public Property typeValeur As String
        Get
            Return m_typeValeur
        End Get
        Set(value As String)
            m_typeValeur = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property isTypeValeur As Boolean
        Get
            Return m_typeValeur = ECARTVALEUR
        End Get
        Set(value As Boolean)
            If value = True Then
                m_typeValeur = ECARTVALEUR
            Else
                m_typeValeur = ECARTPCT
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property isTypePourcentage As Boolean
        Get
            Return m_typeValeur = ECARTPCT
        End Get
        Set(value As Boolean)
            If value = True Then
                m_typeValeur = ECARTPCT
            Else
                m_typeValeur = ECARTVALEUR
            End If
        End Set
    End Property
    <XmlAttribute("Mini")>
    Public Property Mini As String
        Get
            Return m_mini
        End Get
        Set(value As String)
            m_mini = value.Replace(".", ",")
        End Set
    End Property
        <XmlAttribute("Maxi")>
    Public Property Maxi As String
        Get
            Return m_maxi
        End Get
        Set(value As String)
            m_maxi = value.Replace(".", ",")
        End Set
    End Property
    <XmlAttribute("Imprecision")>
    Public Property Imprecision As Integer
        Get
            Return m_Imprecision
        End Get
        Set(value As Integer)
            m_Imprecision = value
        End Set
    End Property




End Class
