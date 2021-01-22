Imports CsvHelper.Configuration.Attributes

Public Class ValueERECA
    Private _Ref As String
    <Index(0)>
    Public Property Ref() As String
        Get
            Return _Ref
        End Get
        Set(ByVal value As String)
            _Ref = value
        End Set
    End Property
    Private _hv As String
    <Index(1)>
    Public Property HV() As String
        Get
            Return _hv
        End Get
        Set(ByVal value As String)
            _hv = value
        End Set
    End Property
    Private _MarqueType As String
    <Index(2)>
    Public Property MarqueType() As String
        Get
            Return _MarqueType
        End Get
        Set(ByVal value As String)
            _MarqueType = value
        End Set
    End Property
    Private _Calibre As String
    <Index(3)>
    Public Property Calibre() As String
        Get
            Return _Calibre
        End Get
        Set(ByVal value As String)
            _Calibre = value
        End Set
    End Property
    Private _PressionControle As String
    <Index(4)>
    Public Property PressionControle() As String
        Get
            Return _PressionControle
        End Get
        Set(ByVal value As String)
            _PressionControle = value
        End Set
    End Property
    Private _debitNominal As String
    <Index(5)>
    Public Property DebitNominal() As String
        Get
            Return _debitNominal
        End Get
        Set(ByVal value As String)
            _debitNominal = value
        End Set
    End Property
    Private _jeu As String
    <Index(6)>
    Public Property Jeu() As String
        Get
            Return _jeu
        End Get
        Set(ByVal value As String)
            _jeu = value
        End Set
    End Property
    Private _Troncon As String
    <Index(7)>
    Public Property Troncon() As String
        Get
            Return _Troncon
        End Get
        Set(ByVal value As String)
            _Troncon = value
        End Set
    End Property
    Private _Niveau As String
    <Index(8)>
    Public Property Niveau() As String
        Get
            Return _Niveau
        End Get
        Set(ByVal value As String)
            _Niveau = value
        End Set
    End Property
    Private _NumeroBuseTroncon As String
    <Index(9)>
    Public Property NumeroBuseTroncon() As String
        Get
            Return _NumeroBuseTroncon
        End Get
        Set(ByVal value As String)
            _NumeroBuseTroncon = value
        End Set
    End Property
    Private _NumeroBuse As String
    <Index(10)>
    Public Property NumeroBuse() As String
        Get
            Return _NumeroBuse
        End Get
        Set(ByVal value As String)
            _NumeroBuse = value
        End Set
    End Property
    Private _DebitMesure As String
    <Index(11)>
    Public Property DebitMesure() As String
        Get
            Return _DebitMesure
        End Get
        Set(ByVal value As String)
            _DebitMesure = value
        End Set
    End Property
    Private _PressionMesuree As String
    <Index(12)>
    Public Property PressionMesuree() As String
        Get
            Return _PressionMesuree
        End Get
        Set(ByVal value As String)
            _PressionMesuree = value
        End Set
    End Property

    Private _LR As String
    <Index(13)>
    Public Property LR() As String
        Get
            Return _LR
        End Get
        Set(ByVal value As String)
            _LR = value
        End Set
    End Property

    Private _DebEq3b As String
    <Index(14)>
    Public Property DebEq3b() As String
        Get
            Return _DebEq3b
        End Get
        Set(ByVal value As String)
            _DebEq3b = value
        End Set
    End Property




    Sub New()

    End Sub
    Sub New(pNum As String, pDebit As String, pPression As String, pRef As String)

        NumeroBuse = pNum
        DebitMesure = pDebit
        PressionMesuree = pPression
        Ref = pRef
    End Sub


End Class