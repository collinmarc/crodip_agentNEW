Public Class FeuillePeda
    Private _oDiag As Diagnostic
    Public Property oDiag() As Diagnostic
        Get
            Return _oDiag
        End Get
        Set(ByVal value As Diagnostic)
            _oDiag = value
        End Set
    End Property
    Private _infos As String
    Public Property Infos() As String
        Get
            Return _infos
        End Get
        Set(ByVal value As String)
            _infos = value
        End Set
    End Property
    Private _conseil As String
    Public Property Conseils() As String
        Get
            Return _conseil
        End Get
        Set(ByVal value As String)
            _conseil = value
        End Set
    End Property

    Public Sub New(pDiag As Diagnostic)
        oDiag = pDiag
    End Sub





End Class
