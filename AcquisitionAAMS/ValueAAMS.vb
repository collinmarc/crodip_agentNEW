Imports CsvHelper.Configuration.Attributes

Public Class ValueAAMS
    Private _Numero As String
    <Index(0)>
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property
    Private _Debit As String
    <Index(1)>
    Public Property Debit() As String
        Get
            Return _Debit
        End Get
        Set(ByVal value As String)
            _Debit = value
        End Set
    End Property
    Private _Pression As String
    <Index(2)>
    Public Property Pression() As String
        Get
            Return _Pression
        End Get
        Set(ByVal value As String)
            _Pression = value
        End Set
    End Property
    Private _Ref As String
    <Index(3)>
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

        Numero = pNum
        Debit = pDebit
        Pression = pPression
        Ref = pRef
    End Sub


End Class