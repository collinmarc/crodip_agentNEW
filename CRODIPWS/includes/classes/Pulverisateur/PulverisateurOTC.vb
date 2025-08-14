Imports System.Xml.Serialization

Public Class PulverisateurOTC
    Private _isEmpty As Boolean = True
    <XmlIgnore()>
    Public Property isEmpty() As Boolean
        Get
            Return _isEmpty
        End Get
        Set(ByVal value As Boolean)
            _isEmpty = value
        End Set
    End Property
    Private _Annee As String
    Public Property Année() As String
        Get
            Return _Annee
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Annee = value
        End Set
    End Property
    Private _Attellage As String
    Public Property Attelage() As String
        Get
            Return _Attellage
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Attellage = value
        End Set
    End Property
    Private _categorie As String
    Public Property Catégorie() As String
        Get
            Return _categorie
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _categorie = value
        End Set
    End Property

    Private _Fonctionnement As String
    Public Property Fonctionnement() As String
        Get
            _isEmpty = False
            Return _Fonctionnement
        End Get
        Set(ByVal value As String)
            _Fonctionnement = value
        End Set
    End Property
    Private _Largeur As String
    Public Property Largeur() As String
        Get
            Return _Largeur
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Largeur = value
        End Set
    End Property
    Private _Marque As String
    Public Property Marque() As String
        Get
            Return _Marque
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Marque = value
        End Set
    End Property
    Private _Type As String
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Type = value
        End Set
    End Property
    Private _Volume As String
    Public Property Volume() As String
        Get
            Return _Volume
        End Get
        Set(ByVal value As String)
            _isEmpty = False
            _Volume = value
        End Set
    End Property

End Class
