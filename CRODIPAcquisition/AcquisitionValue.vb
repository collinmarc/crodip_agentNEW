Public Interface IAcquisitionValue

End Interface
Public Class AcquisitionValue
    Implements IAcquisitionValue
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
    Public Property nBuse() As Integer
        Get
            Return m_NBuse
        End Get
        Set(ByVal value As Integer)
            m_NBuse = value
        End Set
    End Property
    Private m_value As Decimal
    Public Property Value() As Decimal
        Get
            Return m_value
        End Get
        Set(ByVal value As Decimal)
            m_value = value
        End Set
    End Property


    Public Sub New()
        Niveau = 0
        nBuse = 0
        Value = 0
    End Sub
    Public Sub New(pNiveau As Integer, pNbuse As Integer, pValue As Decimal)
        Niveau = pNiveau
        nBuse = pNbuse
        Value = pValue
    End Sub

End Class
