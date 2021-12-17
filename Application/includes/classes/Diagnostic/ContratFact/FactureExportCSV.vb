Public Class FactureExportCSV
    Private _idFacture As String
    Public Property idFacture() As String
        Get
            Return _idFacture
        End Get
        Set(ByVal value As String)
            _idFacture = value
        End Set
    End Property
    Private _DateFacture As Date
    Public Property DateFacture() As Date
        Get
            Return _DateFacture
        End Get
        Set(ByVal value As Date)
            _DateFacture = value
        End Set
    End Property
    Private _DateEcheance As Date
    Public Property DateEcheance() As Date
        Get
            Return _DateEcheance
        End Get
        Set(ByVal value As Date)
            _DateEcheance = value
        End Set
    End Property
    Private _commentaire As String
    Public Property commentaire() As String
        Get
            Return _commentaire
        End Get
        Set(ByVal value As String)
            _commentaire = value
        End Set
    End Property
    Private _modeReglement As String
    Public Property modereglement() As String
        Get
            Return _modeReglement
        End Get
        Set(ByVal value As String)
            _modeReglement = value
        End Set
    End Property
    Private _Reglee As Boolean
    Public Property Reglee() As Boolean
        Get
            Return _Reglee
        End Get
        Set(ByVal value As Boolean)
            _Reglee = value
        End Set
    End Property
    Private _refreglement As String
    Public Property refReglement() As String
        Get
            Return _refreglement
        End Get
        Set(ByVal value As String)
            _refreglement = value
        End Set
    End Property
    Private _TotalHT As Decimal
    Public Property totalHT() As Decimal
        Get
            Return _TotalHT
        End Get
        Set(ByVal value As Decimal)
            _TotalHT = value
        End Set
    End Property
    Private _txTVA As Decimal
    Public Property txTVA() As Decimal
        Get
            Return _txTVA
        End Get
        Set(ByVal value As Decimal)
            _txTVA = value
        End Set
    End Property
    Private _totalTVA As Decimal
    Public Property totalTVA() As Decimal
        Get
            Return _totalTVA
        End Get
        Set(ByVal value As Decimal)
            _totalTVA = value
        End Set
    End Property
    Private _TotalTTC As Decimal
    Public Property TotalTTC() As Decimal
        Get
            Return _TotalTTC
        End Get
        Set(ByVal value As Decimal)
            _TotalTTC = value
        End Set
    End Property
    Private _idDiag As String
    Public Property idDiag() As String
        Get
            Return _idDiag
        End Get
        Set(ByVal value As String)
            _idDiag = value
        End Set
    End Property
    Private _rsClient As String
    Public Property rsClient() As String
        Get
            Return _rsClient
        End Get
        Set(ByVal value As String)
            _rsClient = value
        End Set
    End Property
    Private _NomClient As String
    Public Property nomClient() As String
        Get
            Return _NomClient
        End Get
        Set(ByVal value As String)
            _NomClient = value
        End Set
    End Property
    Private _prenomclient As String
    Public Property PrenomClient() As String
        Get
            Return _prenomclient
        End Get
        Set(ByVal value As String)
            _prenomclient = value
        End Set
    End Property
    Private _adresseClient As String
    Public Property adresseClient() As String
        Get
            Return _adresseClient
        End Get
        Set(ByVal value As String)
            _adresseClient = value
        End Set
    End Property
    Private _cpclient As String
    Public Property cpClient() As String
        Get
            Return _cpclient
        End Get
        Set(ByVal value As String)
            _cpclient = value
        End Set
    End Property
    Private _communeClient As String
    Public Property CommuneClient() As String
        Get
            Return _communeClient
        End Get
        Set(ByVal value As String)
            _communeClient = value
        End Set
    End Property
    Private _TelFixeClient As String
    Public Property telFixeClient() As String
        Get
            Return _TelFixeClient
        End Get
        Set(ByVal value As String)
            _TelFixeClient = value
        End Set
    End Property
    Private _telPortClient As String
    Public Property telPortableClient() As String
        Get
            Return _telPortClient
        End Get
        Set(ByVal value As String)
            _telPortClient = value
        End Set
    End Property
    Private _mailClient As String
    Public Property mailClient() As String
        Get
            Return _mailClient
        End Get
        Set(ByVal value As String)
            _mailClient = value
        End Set
    End Property
    Private _categorieItem As String
    Public Property categorieItem() As String
        Get
            Return _categorieItem
        End Get
        Set(ByVal value As String)
            _categorieItem = value
        End Set
    End Property
    Private _prestationItem As String
    Public Property PrestationItem() As String
        Get
            Return _prestationItem
        End Get
        Set(ByVal value As String)
            _prestationItem = value
        End Set
    End Property
    Private _quantite As Decimal
    Public Property quantite() As Decimal
        Get
            Return _quantite
        End Get
        Set(ByVal value As Decimal)
            _quantite = value
        End Set
    End Property
    Private _pu As Decimal
    Public Property pu() As Decimal
        Get
            Return _pu
        End Get
        Set(ByVal value As Decimal)
            _pu = value
        End Set
    End Property
    Private _totalHtItem As Decimal
    Public Property totalHTItem() As Decimal
        Get
            Return _totalHtItem
        End Get
        Set(ByVal value As Decimal)
            _totalHtItem = value
        End Set
    End Property
    Private _totalTVAItem As Decimal
    Public Property totalTVAItem() As Decimal
        Get
            Return _totalTVAItem
        End Get
        Set(ByVal value As Decimal)
            _totalTVAItem = value
        End Set
    End Property
    Private _totalTTCItem As Decimal
    Public Property totalTTCItem() As Decimal
        Get
            Return _totalTTCItem
        End Get
        Set(ByVal value As Decimal)
            _totalTTCItem = value
        End Set
    End Property
    Private _TxTVAItem As Decimal
    Public Property txTVAItem() As Decimal
        Get
            Return _TxTVAItem
        End Get
        Set(ByVal value As Decimal)
            _TxTVAItem = value
        End Set
    End Property

End Class
