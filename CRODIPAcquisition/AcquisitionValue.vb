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

    Public Sub New()
        Niveau = 0
        NumBuse = 0
        Debit = 0
        Pression = 0
    End Sub
    Public Sub New(pNiveau As Integer, pNbuse As Integer, pValue As Decimal, pPression As Decimal)
        Niveau = pNiveau
        NumBuse = pNbuse
        Debit = pValue
        Pression = pPression
    End Sub

End Class
