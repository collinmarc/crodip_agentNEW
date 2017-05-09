Public Class UserReglagePulve
    Private _Code As String
    Private _PasswordCrypted As String
    Private _dateExp As String

    Public Property Code As String
        Get
            Return _Code
        End Get
        Set(value As String)
            _Code = value
        End Set
    End Property

    Public Property PasswordCrypted As String
        Get
            Return _PasswordCrypted
        End Get
        Set(value As String)
            _PasswordCrypted = value
        End Set
    End Property

    Public Sub setPassword(pValue As String)
        _PasswordCrypted = Crypt(pValue)
    End Sub
    Public Function TestPassword(pValue As String) As Boolean
        Return (Crypt(pValue) = _PasswordCrypted)
    End Function
    Public Property DateExpCrypted As String
        Get
            Return _dateExp
        End Get
        Set(value As String)
            _dateExp = value
        End Set
    End Property
    Public Sub setDateExp(pValue As Date)

        DateExpCrypted = Crypt(pValue.ToShortDateString())
    End Sub

    Public Function TestDateExp(pDate As Date) As Boolean
        Return (Crypt(pDate.ToShortDateString()) = DateExpCrypted)
    End Function

    Private Function Crypt(pValue As String) As String
        'pValue = CSCrypt.encode(pValue, "sha256")
        Return pValue
    End Function
    Private Function DecCrypt(pValue As String) As String
        Return pValue
    End Function


End Class
