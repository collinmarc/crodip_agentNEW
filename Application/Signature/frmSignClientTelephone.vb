Imports System.IO
Public Enum SignMode As Integer
    RICLIENT
    RIAGENT
    CCCLIENT
    CCAGENT
End Enum
Public Class frmSignClientTelephone
    Inherits frmSignClient
    Dim _previous As Point = Nothing
    Dim _pen As Pen = New Pen(Color.Black, 5)
    Dim drawing As Boolean = False

    Public Sub New(pDiag As Diagnostic, pSignMode As SignMode, pAgent As Agent)
        MyBase.New(pDiag, pSignMode, pAgent)
        Debug.Assert(pAgent IsNot Nothing)
    End Sub

    ''' <summary>
    ''' This handles the signature drawing events (drawing)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseMove
        If drawing = True Then
            If pctSignature.Image Is Nothing Then
                Dim bmp As Bitmap = New Bitmap(pctSignature.Width, pctSignature.Height)

                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(Color.White)
                End Using

                pctSignature.Image = bmp
            End If

            Using g As Graphics = Graphics.FromImage(pctSignature.Image)
                g.DrawLine(_pen, _previous.X, _previous.Y, e.X, e.Y)
            End Using
            pctSignature.Invalidate()
            _previous = New Point(e.X, e.Y)
        End If
    End Sub

    ''' <summary>
    ''' this indicates somebody is going to write a signature
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseDown
        _previous = New Point(e.X, e.Y)
        drawing = True
        bSignVide = False
        signature_MouseMove(sender, e)

    End Sub

    ''' <summary>
    ''' the signature is done.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseUp
        _previous = Nothing
        drawing = False
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''On prend le dernier écran comme ecran de signature
        Me.Location = System.Windows.Forms.Screen.AllScreens(Screen.AllScreens.Length - 1).WorkingArea.Location

        Me.WindowState = FormWindowState.Maximized

        pctSignatureWidth = pctSignature.Width
        pctSignatureHeight = pctSignatureHeight

        AfficheSignature()

        pctSignature.Image = img
    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        RecupereSignature(pctSignature.Image, dtpDateSignature.Value)

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Using g As Graphics = Graphics.FromImage(pctSignature.Image)
            g.Clear(Color.White)
        End Using
        pctSignature.Invalidate()
        bSignVide = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AnnuleSignature()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class