Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ManometreControle))>
Public Class Manometre
    Inherits Materiel

    Protected m_marque As String = ""
    Protected m_classe As String = ""
    Protected m_type As String = ""
    Protected m_fondEchelle As String = ""
    Protected m_isSynchro As Boolean = False
    Protected m_isUtilise As Boolean = False
    Protected m_nbControles As Integer = 0
    Protected m_nbControlesTotal As Integer = 0


    Sub New()
        _lstPools = New List(Of Pool)()
    End Sub
    Public Property idManometre() As String
        Get
            Return numeroNational
        End Get
        Set(ByVal value As String)
            numeroNational = value
        End Set
    End Property

    Public Property marque() As String
        Get
            Return m_marque
        End Get
        Set(ByVal Value As String)
            m_marque = Value
        End Set
    End Property

    Public Property classe() As String
        Get
            Return m_classe
        End Get
        Set(ByVal Value As String)
            m_classe = Value
        End Set
    End Property
    Public Property type() As String
        Get
            Return m_type
        End Get
        Set(ByVal Value As String)
            m_type = Value
        End Set
    End Property

    Public Property fondEchelle() As String
        Get
            Return m_fondEchelle
        End Get
        Set(ByVal Value As String)
            m_fondEchelle = Value
        End Set
    End Property

    <XmlIgnore>
    Public Property isSynchro() As Boolean
        Get
            Return m_isSynchro
        End Get
        Set(ByVal Value As Boolean)
            m_isSynchro = Value
        End Set
    End Property
    <XmlElement("isSynchro")>
    Public Property isSynchroWS() As Integer
        Get
            Return CInt(m_isSynchro)
        End Get
        Set(ByVal Value As Integer)
            m_isSynchro = CBool(Value)
        End Set
    End Property




    Public Property isUtilise() As Boolean
        Get
            Return m_isUtilise
        End Get
        Set(ByVal Value As Boolean)
            m_isUtilise = Value
        End Set
    End Property
    <XmlIgnore>
    Public Property nbControles() As Integer
        Get
            Return m_nbControles
        End Get
        Set(ByVal Value As Integer)
            m_nbControles = Value
        End Set
    End Property
    <XmlElement("nbControles")>
    Public Property nbControlesS() As String
        Get
            Return nbControles
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                nbControles = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property nbControlesTotal() As Integer
        Get
            Return m_nbControlesTotal
        End Get
        Set(ByVal Value As Integer)
            m_nbControlesTotal = Value
        End Set
    End Property
    <XmlElement("nbControlesTotal")>
    Public Property nbControlesTotalS() As String
        Get
            Return nbControlesTotal
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                nbControlesTotal = Value
            End If
        End Set
    End Property
    Private _lstPools As List(Of Pool)
    <XmlIgnore()>
    Public Property lstPools() As List(Of Pool)
        Get
            Return _lstPools
        End Get
        Set(ByVal value As List(Of Pool))
            _lstPools = value
        End Set
    End Property

    'Public Overridable ReadOnly Property Libelle() As String
    '    Get
    '        Return "Manomètre : " + idCrodip
    '    End Get
    'End Property

    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        Return False
    End Function

End Class