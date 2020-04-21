Imports System.IO
Public Enum SignMode As Integer
    CLIENT
    AGENT
End Enum
Public Class frmSignClient
    Dim _previous As Point = Nothing
    Dim _pen As Pen = New Pen(Color.Black)
    Dim drawing As Boolean = False

    Dim m_odiag As Diagnostic
    Dim m_Mode As SignMode

    Public Sub New(pDiag As Diagnostic, pSignMode As SignMode)
        Me.New()
        m_odiag = pDiag
        m_Mode = pSignMode
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

        If My.Settings.NumEcranSignature > Screen.AllScreens.Length Then
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Else
            Me.Location = System.Windows.Forms.Screen.AllScreens(My.Settings.NumEcranSignature - 1).WorkingArea.Location
        End If

        Dim img As Image = New Bitmap(pctSignature.Width, pctSignature.Height)
        Dim ms As MemoryStream
        If m_Mode = SignMode.AGENT Then
            Me.Text = "Signature AGENT"
            If m_odiag.SignAgent IsNot Nothing Then
                Try
                    ms = New MemoryStream(m_odiag.SignAgent)
                    img = Image.FromStream(ms)

                Catch ex As Exception
                    img = New Bitmap(pctSignature.Width, pctSignature.Height)
                End Try
            End If
        Else
            Me.Text = "Signature CLIENT"
            If m_odiag.SignClient IsNot Nothing Then
                Try
                    ms = New MemoryStream(m_odiag.SignClient)
                    img = Image.FromStream(ms)
                Catch ex As Exception
                    img = New Bitmap(pctSignature.Width, pctSignature.Height)
                End Try
            End If
        End If
        'Using g As Graphics = Graphics.FromImage(img)
        '    g.Clear(Color.White)
        'End Using

        pctSignature.Image = img
    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        Dim ms As New MemoryStream
        pctSignature.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        If m_Mode = SignMode.CLIENT Then
            m_odiag.SignClient = ms.ToArray()
            m_odiag.bSignClient = True
            m_odiag.dateSignClient = dtpDateSignature.Value
        Else
            m_odiag.SignAgent = ms.ToArray()
            m_odiag.bSignAgent = True
            m_odiag.dateSignAgent = dtpDateSignature.Value
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Using g As Graphics = Graphics.FromImage(pctSignature.Image)
            g.Clear(Color.White)
        End Using
        pctSignature.Invalidate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        m_odiag.SignClient = Nothing
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class