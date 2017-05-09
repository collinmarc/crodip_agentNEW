Public Class Structuree

    Private _id As Integer
    Private _idCrodip As String
    Private _nom As String
    Private _type As String
    Private _nomResponsable As String
    Private _nomContact As String
    Private _prenomContact As String
    Private _adresse As String
    Private _codePostal As String
    Private _commune As String
    Private _codeInsee As String
    Private _telephoneFixe As String
    Private _telephonePortable As String
    Private _telephoneFax As String
    Private _eMail As String
    Private _commentaire As String
    Private _dateModificationCrodip As String
    Private _dateModificationAgent As String

    Sub New()
        _id = 0
        _idCrodip = ""
        nom = ""
    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
        End Set
    End Property

    Public Property idCrodip() As String
        Get
            Return _idCrodip
        End Get
        Set(ByVal Value As String)
            _idCrodip = Value
        End Set
    End Property

    Public Property nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal Value As String)
            _nom = Value
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

    Public Property nomResponsable() As String
        Get
            Return _nomResponsable
        End Get
        Set(ByVal Value As String)
            _nomResponsable = Value
        End Set
    End Property

    Public Property nomContact() As String
        Get
            Return _nomContact
        End Get
        Set(ByVal Value As String)
            _nomContact = Value
        End Set
    End Property

    Public Property prenomContact() As String
        Get
            Return _prenomContact
        End Get
        Set(ByVal Value As String)
            _prenomContact = Value
        End Set
    End Property

    Public Property adresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal Value As String)
            _adresse = Value
        End Set
    End Property

    Public Property codePostal() As String
        Get
            Return _codePostal
        End Get
        Set(ByVal Value As String)
            _codePostal = Value
        End Set
    End Property

    Public Property commune() As String
        Get
            Return _commune
        End Get
        Set(ByVal Value As String)
            _commune = Value
        End Set
    End Property

    Public Property codeInsee() As String
        Get
            Return _codeInsee
        End Get
        Set(ByVal Value As String)
            _codeInsee = Value
        End Set
    End Property

    Public Property telephoneFixe() As String
        Get
            Return _telephoneFixe
        End Get
        Set(ByVal Value As String)
            _telephoneFixe = Value
        End Set
    End Property

    Public Property telephonePortable() As String
        Get
            Return _telephonePortable
        End Get
        Set(ByVal Value As String)
            _telephonePortable = Value
        End Set
    End Property

    Public Property telephoneFax() As String
        Get
            Return _telephoneFax
        End Get
        Set(ByVal Value As String)
            _telephoneFax = Value
        End Set
    End Property

    Public Property eMail() As String
        Get
            Return _eMail
        End Get
        Set(ByVal Value As String)
            _eMail = Value
        End Set
    End Property

    Public Property commentaire() As String
        Get
            Return _commentaire
        End Get
        Set(ByVal Value As String)
            _commentaire = Value
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

    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

End Class
