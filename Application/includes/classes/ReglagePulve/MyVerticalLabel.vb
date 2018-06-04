Imports System.Drawing

Public Class MyVerticalLabel
    Inherits System.Windows.Forms.Label
    Private _newText As String
    Public Property newText() As String
        Get
            Return _newText
        End Get
        Set(ByVal value As String)
            _newText = value
            Text = ""
        End Set
    End Property


    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim b As Brush = New SolidBrush(Me.ForeColor)
        e.Graphics.TranslateTransform(Me.Width / 2, Me.Height / 2)
        e.Graphics.RotateTransform(-90)
        e.Graphics.DrawString(newText, Me.Font, b, 0F, 0F)
        MyBase.OnPaint(e)

    End Sub
End Class
