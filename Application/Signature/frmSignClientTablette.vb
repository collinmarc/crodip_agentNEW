Imports System.IO
Imports CRODIPWS
Imports Gma.System.MouseKeyHook


Public Class frmSignClientTablette
    Inherits frmSignClient

    Dim _previous As Point = Nothing
    Dim _pen As Pen = New Pen(Color.Black, 5)
    Dim drawing As Boolean = False
    Dim WithEvents m_GlobalHook As IKeyboardMouseEvents


    Public Sub New(pDiag As Diagnostic, pSignMode As SignMode, pAgent As Agent)
        MyBase.New(pDiag, pSignMode, pAgent)
        Debug.Assert(pAgent IsNot Nothing)
        InitializeComponent()
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
        Try

            Dim Hs As Integer = Screen.FromControl(pctSignature).Bounds.Height 'HauteurEcran
            Dim Ws As Integer = Screen.FromControl(pctSignature).Bounds.Width 'LArgeurEcran
            Dim Hp As Integer = pctSignature.Bounds.Height 'Hauteur zone
            Dim Wp As Integer = pctSignature.Bounds.Width 'Largeur zone
            Dim Xp As Integer = (e.X / Ws) * Wp 'Psotionnement de la souris dans le Control
            Dim Yp As Integer = (e.Y / Hs) * Hp

            signature_MouseMove(sender, New MouseEventArgs(MouseButtons.Left, 1, Xp, Yp, 0))
        Catch ex As Exception

        End Try
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

        pctSignatureWidth = pctSignature.Width
        pctSignatureHeight = pctSignature.Height
        SetImgSignature()

        pctSignature.Image = img
        m_GlobalHook = Gma.System.MouseKeyHook.Hook.GlobalEvents()

        ckConserverSignature.Visible = (m_Mode = SignMode.RIAGENT Or m_Mode = SignMode.CCAGENT)

    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles btnValider.Click

        RecupereSignature(pctSignature.Image, dtpDateSignature.Value)
        If ckConserverSignature.Checked Then
            Me.Conserverlasignature()
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim ImgClear As Bitmap = New Bitmap(Screen.FromControl(Me).Bounds.Width, Screen.FromControl(Me).Bounds.Height)
        Using g As Graphics = Graphics.FromImage(ImgClear)
            g.Clear(Color.White)
        End Using
        pctSignature.Image = ImgClear
        pctSignature.Invalidate()
        bSignVide = True
    End Sub

    Private Sub btnQuitter_Click(sender As Object, e As EventArgs) Handles btnQuitter.Click
        AnnuleSignature()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class