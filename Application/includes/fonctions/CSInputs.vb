Module CSInputs
    Public Function inputForceNumeric(ByVal sender As Object, ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        If Not IsNumeric(Chr(KeyAscii)) Then
            If KeyAscii = 8 Or (KeyAscii = 44 And InStr(sender.text, ",") = 0) Then
                ' on fait rien
            Else
                e.Handled = True
            End If
        End If
    End Function
End Module
