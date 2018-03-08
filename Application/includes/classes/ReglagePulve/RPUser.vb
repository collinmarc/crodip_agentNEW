Public Class RPUser
    Private _Code As String
    Private _PasswordCrypted As String
    Private _dateExp As Long

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
    Public Property DateExpCrypted As Long
        Get
            Return _dateExp
        End Get
        Set(value As Long)
            _dateExp = value
        End Set
    End Property
    Public Sub setDateExp(pValue As Date)

        DateExpCrypted = pValue.Ticks
    End Sub

    Public Function TestDateExp(pDate As Date) As Boolean
        Dim oDateExp As Date
        oDateExp = New Date(DateExpCrypted)
        Return pDate.Ticks < DateExpCrypted
    End Function

    Private Function Crypt(pValue As String) As String
        pValue = CSCrypt.encode(pValue, "sha256")
        Return pValue
    End Function


End Class
