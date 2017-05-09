Public Class Commune

    Private m_Nom As String
    Private m_CodeInsee As String
    Private m_CodePostal As String

    Public Sub New(pNom As String, pCodeInsee As String, pCodePostal As String)
        Nom = pNom
        CodeInsee = pCodeInsee
        CodePostal = pCodePostal
    End Sub
    Public Property Nom As String
        Get
            Return m_Nom
        End Get
        Set(ByVal value As String)
            m_Nom = value
        End Set
    End Property

    Public Property CodePostal As String
        Get
            Return m_CodePostal
        End Get
        Set(ByVal value As String)
            m_CodePostal = value
        End Set
    End Property
    Public Property CodeInsee As String
        Get
            Return m_CodeInsee
        End Get
        Set(ByVal value As String)
            m_CodeInsee = value
        End Set
    End Property


End Class
