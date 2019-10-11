'Public Class frmsignature

'    Dim _previous As Point = Nothing
'    Dim _pen As Pen = New Pen(Color.Black)
'    Dim drawing As Boolean = False
'    ''' <summary>
'    ''' This handles the signature drawing events (drawing)
'    ''' </summary>
'    ''' <param name="sender"></param>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    Private Sub signature_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseMove
'        If drawing = True Then
'            If pctSignature.Image Is Nothing Then
'                Dim bmp As Bitmap = New Bitmap(pctSignature.Width, pctSignature.Height)

'                Using g As Graphics = Graphics.FromImage(bmp)
'                    g.Clear(Color.White)
'                End Using

'                pctSignature.Image = bmp
'            End If

'            Using g As Graphics = Graphics.FromImage(pctSignature.Image)
'                g.DrawLine(_pen, _previous.X, _previous.Y, e.X, e.Y)
'            End Using
'            pctSignature.Invalidate()
'            _previous = New Point(e.X, e.Y)
'        End If
'    End Sub

'    ''' <summary>
'    ''' this indicates somebody is going to write a signature
'    ''' </summary>
'    ''' <param name="sender"></param>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    Private Sub signature_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseDown
'        _previous = New Point(e.X, e.Y)
'        drawing = True
'        signature_MouseMove(sender, e)

'    End Sub

'    ''' <summary>
'    ''' the signature is done.
'    ''' </summary>
'    ''' <param name="sender"></param>
'    ''' <param name="e"></param>
'    ''' <remarks></remarks>
'    Private Sub signature_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctSignature.MouseUp
'        _previous = Nothing
'        drawing = False
'    End Sub

'    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClear.Click
'        Using g As Graphics = Graphics.FromImage(pctSignature.Image)
'            g.Clear(Color.White)
'        End Using
'        pctSignature.Invalidate()
'    End Sub

'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

'        Me.Location = System.Windows.Forms.Screen.AllScreens(2).WorkingArea.Location


'        Dim bmp As Bitmap = New Bitmap(pctSignature.Width, pctSignature.Height)

'        Using g As Graphics = Graphics.FromImage(bmp)
'            g.Clear(Color.White)
'        End Using

'        pctSignature.Image = bmp
'    End Sub

'    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click
'        If System.IO.File.Exists("sign.bmp") Then
'            System.IO.File.Delete("sign.bmp")
'        End If
'        pctSignature.Image.Save("sign.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
'        Me.Close()
'    End Sub
'End Class