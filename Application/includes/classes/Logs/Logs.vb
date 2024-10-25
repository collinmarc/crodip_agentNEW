Imports System.Web.Services
Imports System.Xml.Serialization
Imports CRODIPWS

<Serializable(), XmlInclude(GetType(Pulverisateur))> _
Public Class Logs

    Private _id As Integer
    Private _type As String
    Private _idInspecteur As String
    Private _dateLog As String
    Private _message As String
    Private _version As String

    Sub New()

    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property idInspecteur() As String
        Get
            Return _idInspecteur
        End Get
        Set(ByVal Value As String)
            _idInspecteur = Value
        End Set
    End Property

    Public Property dateLog() As String
        Get
            Return _dateLog
        End Get
        Set(ByVal Value As String)
            _dateLog = Value
        End Set
    End Property

    Public Property message() As String
        Get
            Return _message
        End Get
        Set(ByVal Value As String)
            _message = Value
        End Set
    End Property

    Public Property version() As String
        Get
            Return _version
        End Get
        Set(ByVal Value As String)
            _version = Value
        End Set
    End Property

End Class
