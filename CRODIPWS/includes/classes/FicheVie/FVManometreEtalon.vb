Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(FVManometreEtalon))> _
Public Class FVManometreEtalon

    Private _id As String
    Private _idManometre As String
    Private _type As String
    Private _auteur As String
    Private _idAgentControleur As Integer
    Private _caracteristiques As String
    Private _dateModif As String
    Private _blocage As Boolean
    Private _idReetalonnage As String
    Private _nomLaboratoire As String
    Private _dateReetalonnage As String
    Private _pressionControle As String
    Private _valeursMesurees As String
    Private _idManometreControleur As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    Sub New()
    End Sub

    Sub New(ByVal pAgent As Agent)
        _id = FVManometreEtalonManager.getNewId(pAgent)
    End Sub

    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property

    Public Property idManometre() As String
        Get
            Return _idManometre
        End Get
        Set(ByVal Value As String)
            _idManometre = Value
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

    Public Property auteur() As String
        Get
            Return _auteur
        End Get
        Set(ByVal Value As String)
            _auteur = Value
        End Set
    End Property

    Public Property idAgentControleur() As Integer
        Get
            Return _idAgentControleur
        End Get
        Set(ByVal Value As Integer)
            _idAgentControleur = Value
        End Set
    End Property

    Public Property caracteristiques() As String
        Get
            Return _caracteristiques
        End Get
        Set(ByVal Value As String)
            _caracteristiques = Value
        End Set
    End Property

    Public Property dateModif() As String
        Get
            Return _dateModif
        End Get
        Set(ByVal Value As String)
            _dateModif = Value
        End Set
    End Property

    Public Property blocage() As Boolean
        Get
            Return _blocage
        End Get
        Set(ByVal Value As Boolean)
            _blocage = Value
        End Set
    End Property

    Public Property idReetalonnage() As String
        Get
            Return _idReetalonnage
        End Get
        Set(ByVal Value As String)
            _idReetalonnage = Value
        End Set
    End Property

    Public Property nomLaboratoire() As String
        Get
            Return _nomLaboratoire
        End Get
        Set(ByVal Value As String)
            _nomLaboratoire = Value
        End Set
    End Property

    Public Property dateReetalonnage() As String
        Get
            Return _dateReetalonnage
        End Get
        Set(ByVal Value As String)
            _dateReetalonnage = Value
        End Set
    End Property

    Public Property pressionControle() As String
        Get
            Return _pressionControle
        End Get
        Set(ByVal Value As String)
            _pressionControle = Value
        End Set
    End Property

    Public Property valeursMesurees() As String
        Get
            Return _valeursMesurees
        End Get
        Set(ByVal Value As String)
            _valeursMesurees = Value
        End Set
    End Property

    Public Property idManometreControleur() As String
        Get
            Return _idManometreControleur
        End Get
        Set(ByVal Value As String)
            _idManometreControleur = Value
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


End Class