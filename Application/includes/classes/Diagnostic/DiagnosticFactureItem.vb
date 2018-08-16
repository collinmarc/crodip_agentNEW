Imports System.Web.Services
Imports System.Xml.Serialization

Public Class DiagnosticFactureItem

    Private _id As Integer
    Private _idFacture As String
    Private _libelle As String
    Private _prixUnitaire As String
    Private _qte As String
    Private _tva As String
    Private _prixTotal As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    '############################################################################

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

    Public Property idFacture() As String
        Get
            Return _idFacture
        End Get
        Set(ByVal Value As String)
            _idFacture = Value
        End Set
    End Property

    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal Value As String)
            _libelle = Value
        End Set
    End Property

    Public Property prixUnitaire() As String
        Get
            Return _prixUnitaire
        End Get
        Set(ByVal Value As String)
            _prixUnitaire = Value
            calcultTotal()
        End Set
    End Property

    Public Property qte() As String
        Get
            Return _qte
        End Get
        Set(ByVal Value As String)
            _qte = Value
            calcultTotal()
        End Set
    End Property

    Public Property tva() As String
        Get
            Return _tva
        End Get
        Set(ByVal Value As String)
            _tva = Value
            calcultTotal()
        End Set
    End Property

    Public Property prixTotal() As String
        Get
            Return _prixTotal
        End Get
        Set(ByVal Value As String)
            _prixTotal = Value
        End Set
    End Property

    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property


    Private Sub calcultTotal()
        prixTotal = qte * prixUnitaire * (1 + (tva / 100))
    End Sub
End Class
