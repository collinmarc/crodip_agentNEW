Imports System.IO
Public Enum SignMode As Integer
    RICLIENT
    RIAGENT
    CCCLIENT
    CCAGENT
End Enum
Public Class frmSignClient
    Dim _previous As Point = Nothing
    Dim _pen As Pen = New Pen(Color.Black, 5)
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

        ''On prend le servier écran comme ecran de signature
        Me.Location = System.Windows.Forms.Screen.AllScreens(Screen.AllScreens.Length - 1).WorkingArea.Location

        Dim img As Image
        Dim ms As MemoryStream
        Select Case m_Mode
            Case SignMode.RIAGENT
                Me.Text = "Signature Rapport AGENT"
                If m_odiag.SignRIAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIAgent)
                        img = Image.FromStream(ms)
                    Catch ex As Exception
                        img = New Bitmap(pctSignature.Width, pctSignature.Height)
                    End Try
                End If
            Case SignMode.RICLIENT
                Me.Text = "Signature Rapport CLIENT"
                If m_odiag.SignRIClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIClient)
                        img = Image.FromStream(ms)
                    Catch ex As Exception
                        img = New Bitmap(pctSignature.Width, pctSignature.Height)
                    End Try
                End If
            Case SignMode.CCAGENT
                Me.Text = "Signature Contrat AGENT"
                If m_odiag.SignRIAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCAgent)
                        img = Image.FromStream(ms)
                    Catch ex As Exception
                        img = New Bitmap(pctSignature.Width, pctSignature.Height)
                    End Try
                End If
            Case SignMode.CCCLIENT
                Me.Text = "Signature Contrat CLIENT"
                If m_odiag.SignRIClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCClient)
                        img = Image.FromStream(ms)
                    Catch ex As Exception
                        img = New Bitmap(pctSignature.Width, pctSignature.Height)
                    End Try
                End If
        End Select
        'Using g As Graphics = Graphics.FromImage(img)
        '    g.Clear(Color.White)
        'End Using

        pctSignature.Image = img
    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        Dim ms2 As New MemoryStream
        Dim img2 As Image = Nothing

        pctSignature.Image.Save(ms2, Imaging.ImageFormat.Bmp)
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = ms2.ToArray()
                m_odiag.bSignRIClient = True
                m_odiag.dateSignRIClient = dtpDateSignature.Value
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = ms2.ToArray()
                m_odiag.bSignRIAgent = True
                m_odiag.dateSignRIAgent = dtpDateSignature.Value
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = ms2.ToArray()
                m_odiag.bSignCCClient = True
                m_odiag.DateSignCCClient = dtpDateSignature.Value
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = ms2.ToArray()
                m_odiag.bSignCCAgent = True
                m_odiag.DateSignCCAgent = dtpDateSignature.Value
        End Select
        If (img2 IsNot Nothing) Then
            img2.Dispose()
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
        m_odiag.SignRIClient = Nothing
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = Nothing
                m_odiag.bSignRIClient = False
                m_odiag.dateSignRIClient = ""
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = Nothing
                m_odiag.bSignRIAgent = False
                m_odiag.dateSignRIAgent = ""
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = Nothing
                m_odiag.bSignCCClient = False
                m_odiag.DateSignCCClient = ""
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = Nothing
                m_odiag.bSignCCAgent = False
                m_odiag.DateSignCCAgent = ""
        End Select
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class