Imports CsvHelper.Configuration.Attributes

Public Class ValueITEQ
    Private _Jeu As String
    <Index(6)>
    Public Property Jeu() As String
        Get
            Return _Jeu
        End Get
        Set(ByVal value As String)
            _Jeu = value
        End Set
    End Property
    Private _NumeroBuse As String
    <Index(7)>
    Public Property NumeroBuse() As String
        Get
            Return _NumeroBuse
        End Get
        Set(ByVal value As String)
            _NumeroBuse = value
        End Set
    End Property
    Private _Debit As String
    <Index(8)>
    Public Property Debit() As String
        Get
            Return _Debit
        End Get
        Set(ByVal value As String)
            _Debit = value
        End Set
    End Property
    Private _Pression As String
    <Index(9)>
    Public Property Pression() As String
        Get
            Return _Pression
        End Get
        Set(ByVal value As String)
            _Pression = value
        End Set
    End Property
    Private _Ref As String
    <Index(1)>
    Public Property Ref() As String
        Get
            Return _Ref
        End Get
        Set(ByVal value As String)
            _Ref = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(pNum As String, pDebit As String, pPression As String, pRef As String)

        NumeroBuse = pNum
        Debit = pDebit
        Pression = pPression
        Ref = pRef
    End Sub


End Class