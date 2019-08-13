'Public Interface IAcquisitionValue

'End Interface
Public Class AcquisitionValue
    ' Implements IAcquisitionValue
    Private m_nNiveau As Integer
    Public Property Niveau() As Integer
        Get
            Return m_nNiveau
        End Get
        Set(ByVal value As Integer)
            m_nNiveau = value
        End Set
    End Property
    Private m_NBuse As Integer
    Public Property NumBuse() As Integer
        Get
            Return m_NBuse
        End Get
        Set(ByVal value As Integer)
            m_NBuse = value
        End Set
    End Property
    Private m_debit As Decimal
    Public Property Debit() As Decimal
        Get
            Return m_debit
        End Get
        Set(ByVal value As Decimal)
            m_debit = value
        End Set
    End Property

    Private m_Pression As Decimal
    Public Property Pression() As Decimal
        Get
            Return m_Pression
        End Get
        Set(ByVal value As Decimal)
            m_Pression = value
        End Set
    End Property
    Private _Ref As String
    Public Property Ref() As String
        Get
            Return _Ref
        End Get
        Set(ByVal value As String)
            _Ref = value
        End Set
    End Property
    Private _HV As String
    Public Property HV() As String
        Get
            Return _HV
        End Get
        Set(ByVal value As String)
            _HV = value
        End Set
    End Property
    Private _MarqueTypeFct As String
    Public Property MarqueTypeFonctionement() As String
        Get
            Return _MarqueTypeFct
        End Get
        Set(ByVal value As String)
            _MarqueTypeFct = value
        End Set
    End Property
    Private _Calibre As String
    Public Property Calibre() As String
        Get
            Return _Calibre
        End Get
        Set(ByVal value As String)
            _Calibre = value
        End Set
    End Property
    Private _PressionCtrl As Decimal
    Public Property PressionCtrl() As Decimal
        Get
            Return _PressionCtrl
        End Get
        Set(ByVal value As Decimal)
            _PressionCtrl = value
        End Set
    End Property
    Private _Debitnominal As Decimal
    Public Property DebitNominal() As Decimal
        Get
            Return _Debitnominal
        End Get
        Set(ByVal value As Decimal)
            _Debitnominal = value
        End Set
    End Property
    Public Sub New()
        Niveau = 0
        NumBuse = 0
        Debit = 0
        Pression = 0
        Ref = ""
        HV = ""
        MarqueTypeFonctionement = ""
        Calibre = ""
        MarqueTypeFonctionement = ""
        PressionCtrl = -1
        DebitNominal = -1
    End Sub
    Public Sub New(pNiveau As Integer, pNbuse As Integer, pValue As Decimal, pPression As Decimal)
        Niveau = pNiveau
        NumBuse = pNbuse
        Debit = pValue
        Pression = pPression
    End Sub

End Class
