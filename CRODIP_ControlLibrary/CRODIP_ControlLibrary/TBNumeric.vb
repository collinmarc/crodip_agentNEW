Public Class TBNumeric
    Inherits TextBox
    Private m_ForceBindingonTextChanged As Boolean = False
    Public ReadOnly Property DecimalValue As Decimal
        Get
            If Not String.IsNullOrEmpty(Text) And IsNumeric(Text) Then
                Try

                    Return CDec(Text)
                Catch ex As Exception
                    Return 0D
                End Try

            Else
                Return 0D
            End If
        End Get
    End Property
    Public Overrides Property Text As String
        Get
            Return (MyBase.Text.Replace(".", ","))
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    Public Property ForceBindingOnTextChanged() As Boolean
        Get
            Return m_ForceBindingonTextChanged
        End Get
        Set(value As Boolean)
            m_ForceBindingonTextChanged = value
        End Set
    End Property

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        MyBase.OnKeyPress(e)
        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        End If
        If e.KeyChar = "?" Then
            e.KeyChar = ","
        End If
        If e.KeyChar = ";" Then
            e.KeyChar = "."
        End If
        If e.KeyChar = "." Then
            e.KeyChar = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        End If
        If e.KeyChar = "," Then
            e.KeyChar = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        End If
        'Si c'est un ., on vérifie qu'il n'y a par d'autre . ou ,
        If e.KeyChar = "." Or e.KeyChar = "," Then
            If Not Text.Contains(".") And Not Text.Contains(",") Then
                e.Handled = False
            End If
        End If

    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        If m_ForceBindingonTextChanged Then
            Try
                MyBase.DataBindings("Text").WriteValue()
            Catch ex As Exception

            End Try

        End If
        MyBase.OnTextChanged(e)
    End Sub

End Class
