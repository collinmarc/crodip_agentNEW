Module CSLogin
    Public Class objLogin
        Private _objCurAgent As New Agent

        Sub New(ByVal objCurAgent As Agent)
            _objCurAgent = objCurAgent
        End Sub

        Public Property objCurAgent() As Agent
            Get
                Return _objCurAgent
            End Get
            Set(ByVal Value As Agent)
                _objCurAgent = Value
            End Set
        End Property

        ' On test si password correspond à celui du login
        Public Function checkPassword(ByVal password As String) As Boolean
            Try
                If objCurAgent.motDePasse = password Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

    End Class
End Module