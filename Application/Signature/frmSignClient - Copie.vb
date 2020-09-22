Imports System.IO
Imports Gma.System.MouseKeyHook

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
    Private _bSignVide As Boolean
    Dim WithEvents m_GlobalHook As IKeyboardMouseEvents
    Public Property bSignVide() As Boolean
        Get
            Return _bSignVide
        End Get
        Set(ByVal value As Boolean)
            _bSignVide = value
            btnValider.Enabled = Not bSignVide
        End Set
    End Property

    Dim m_odiag As Diagnostic
    Dim m_Mode As SignMode
    Dim m_Agent As Agent

    Public Sub New(pDiag As Diagnostic, pSignMode As SignMode, pAgent As Agent)
        Me.New()
        Debug.Assert(pAgent IsNot Nothing)
        m_odiag = pDiag
        m_Mode = pSignMode
        m_Agent = pAgent
        bSignVide = True
    End Sub

    ''' <summary>
    ''' This handles the signature drawing events (drawing)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
    Private Sub MouveMoveExt(sender As Object, e As MouseEventExtArgs) Handles m_GlobalHook.MouseMove
        Dim Hs As Integer = Screen.FromControl(pctSignature).Bounds.Height 'HauteurEcran
        Dim Ws As Integer = Screen.FromControl(pctSignature).Bounds.Width 'LArgeurEcran
        Dim Hp As Integer = pctSignature.Bounds.Height 'Hauteur zone
        Dim Wp As Integer = pctSignature.Bounds.Width 'Largeur zone
        Dim Xp As Integer = (e.X / Ws) * Wp 'Psotionnement de la souris dans le Control
        Dim Yp As Integer = (e.Y / Hs) * Hp

        signature_MouseMove(sender, New MouseEventArgs(MouseButtons.Left, 1, Xp, Yp, 0))
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''On prend le dernier écran comme ecran de signature
        ''        Me.Location = System.Windows.Forms.Screen.AllScreens(Screen.AllScreens.Length - 1).WorkingArea.Location
        'Affichage de la fenêtre en grand
        Me.Width = Screen.FromControl(Me).Bounds.Width
        Me.Height = Screen.FromControl(Me).Bounds.Height / 2
        Me.Left = 0
        Me.Top = Screen.FromControl(Me).Bounds.Height / 4
        Me.TopMost = True

        Dim img As Image = Nothing
        Dim ms As MemoryStream
        Select Case m_Mode
            Case SignMode.RIAGENT
                Me.Text = "Signature Rapport Inspecteur"
                If m_odiag.SignRIAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIAgent)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                        img = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
                    End Try
                Else
                    If System.IO.File.Exists("config/" & m_Agent.nom & ".sign") Then
                        Using bmpTemp As New Bitmap("config/" & m_Agent.nom & ".sign")
                            img = New Bitmap(bmpTemp)
                        End Using
                        bSignVide = False
                    End If
                End If
            Case SignMode.RICLIENT
                Me.Text = "Signature Rapport CLIENT"
                If m_odiag.SignRIClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignRIClient)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                        img = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
                    End Try
                End If
            Case SignMode.CCAGENT
                Me.Text = "Signature Contrat AGENT"
                If m_odiag.SignCCAgent IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCAgent)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                        img = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
                    End Try
                Else
                    If System.IO.File.Exists("config/" & m_Agent.nom & ".sign") Then
                        Using bmpTemp As New Bitmap("config/" & m_Agent.nom & ".sign")
                            img = New Bitmap(bmpTemp)
                        End Using
                        bSignVide = False
                    End If
                End If
            Case SignMode.CCCLIENT
                Me.Text = "Signature Contrat CLIENT"
                If m_odiag.SignCCClient IsNot Nothing Then
                    Try
                        ms = New MemoryStream(m_odiag.SignCCClient)
                        img = Image.FromStream(ms)
                        bSignVide = False
                    Catch ex As Exception
                        img = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
                    End Try
                End If
        End Select
        'Using g As Graphics = Graphics.FromImage(img)
        '    g.Clear(Color.White)
        'End Using

        pctSignature.Image = img
        m_GlobalHook = Gma.System.MouseKeyHook.Hook.GlobalEvents()

    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        Dim ms2 As New MemoryStream
        Dim img2 As Image = Nothing
        pctSignature.Image.Save(ms2, Imaging.ImageFormat.Bmp)
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = ms2.ToArray()
                m_odiag.isSignRIClient = True
                m_odiag.dateSignRIClient = dtpDateSignature.Value
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = ms2.ToArray()
                m_odiag.isSignRIAgent = True
                m_odiag.dateSignRIAgent = dtpDateSignature.Value
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = ms2.ToArray()
                m_odiag.isSignCCClient = True
                m_odiag.dateSignCCClient = dtpDateSignature.Value
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = ms2.ToArray()
                m_odiag.isSignCCAgent = True
                m_odiag.dateSignCCAgent = dtpDateSignature.Value
        End Select
        If (m_Mode = SignMode.RIAGENT Or m_Mode = SignMode.CCAGENT) Then
            If MessageBox.Show("Voulez-vous conserver votre signature?", "Signature Agent", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If File.Exists("config/" & m_Agent.nom & ".sign") Then
                    File.Delete("config/" & m_Agent.nom & ".sign")
                End If
                pctSignature.Image.Save("config/" & m_Agent.nom & ".sign")
            End If
        End If
        If (img2 IsNot Nothing) Then
            img2.Dispose()
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim img As Bitmap = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
        Using g As Graphics = Graphics.FromImage(img)
            g.Clear(Color.White)
        End Using
        pctSignature.Image = img
        pctSignature.Invalidate()
        bSignVide = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        m_odiag.SignRIClient = Nothing
        Select Case m_Mode
            Case SignMode.RICLIENT
                m_odiag.SignRIClient = Nothing
                m_odiag.isSignRIClient = False
                m_odiag.dateSignRIClient = Nothing
            Case SignMode.RIAGENT
                m_odiag.SignRIAgent = Nothing
                m_odiag.isSignRIAgent = False
                m_odiag.dateSignRIAgent = Nothing
            Case SignMode.CCCLIENT
                m_odiag.SignCCClient = Nothing
                m_odiag.isSignCCClient = False
                m_odiag.dateSignCCClient = Nothing
            Case SignMode.CCAGENT
                m_odiag.SignCCAgent = Nothing
                m_odiag.isSignCCAgent = False
                m_odiag.dateSignCCAgent = Nothing
        End Select
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class