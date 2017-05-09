Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ReferentielManometre))> _
Public Class ReferentielManometre

    Private _id As Integer
    Private _marque As String
    Private _dateDerniereMAJ As String


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

    Public Property marque() As String
        Get
            Return _marque
        End Get
        Set(ByVal Value As String)
            _marque = Value
        End Set
    End Property

    Public Property dateDerniereMAJ() As String
        Get
            Return _dateDerniereMAJ
        End Get
        Set(ByVal Value As String)
            _dateDerniereMAJ = Value
        End Set
    End Property


End Class