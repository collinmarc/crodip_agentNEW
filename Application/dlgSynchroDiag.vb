Imports System.Threading
Imports System.IO
Imports CRODIPWS
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class dlgSynchroDiag

    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents laStep As Label
    Friend WithEvents m_bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.laStep = New System.Windows.Forms.Label()
        Me.m_bgw = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Crodip_agent.Resources.logo_crodipIndigo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(178, 179)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(196, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 27)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Synchronisation d'un contrôle"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(194, 67)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(299, 23)
        Me.ProgressBar1.TabIndex = 9
        '
        'laStep
        '
        Me.laStep.AutoSize = True
        Me.laStep.ForeColor = System.Drawing.Color.White
        Me.laStep.Location = New System.Drawing.Point(200, 107)
        Me.laStep.Name = "laStep"
        Me.laStep.Size = New System.Drawing.Size(37, 13)
        Me.laStep.TabIndex = 11
        Me.laStep.Text = "laStep"
        '
        'm_bgw
        '
        Me.m_bgw.WorkerReportsProgress = True
        '
        'dlgSynchroDiag
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(498, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.laStep)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dlgSynchroDiag"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "splash"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Dim TimerSplash As New Timer


    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ' Date de build
        'GLOB_APPLI_NUMBUILD = CSSoftwareUpdate.getCurrentVersion
        'GLOB_APPLI_DATEBUILD = GlobalsCRODIP.GLOB_APPLI_BUILD.Substring(0, 8)

        ' Always on top
        Me.TopMost = True

    End Sub
    Private m_Agent As Agent
    Private m_Diag As Diagnostic
    Public Sub setContext(DiagnosticCourant As Diagnostic, agentCourant As Agent)
        m_Agent = agentCourant
        m_Diag = DiagnosticCourant


        m_bgw.RunWorkerAsync()


    End Sub

    Private Sub m_bgw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles m_bgw.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        laStep.Text = e.UserState
    End Sub

    Private Sub m_bgw_DoWork(sender As Object, e As DoWorkEventArgs) Handles m_bgw.DoWork

        ProgressBar1.Value = 0
        Dim osynchro As New Synchronisation(m_Agent)
        Dim oExploit As Exploitation = ExploitationManager.getExploitationById(m_Diag.proprietaireId)
        m_bgw.ReportProgress(10, "Lecture Exploitation")
        Dim oPulve As Pulverisateur = PulverisateurManager.getPulverisateurById(m_Diag.pulverisateurId)
        m_bgw.ReportProgress(20, "Lecture Pulverisateur")
        Dim olstExploit2Pulve As List(Of ExploitationTOPulverisateur) = ExploitationTOPulverisateurManager.getListByPulverisateurId(oPulve.id, True)
        m_bgw.ReportProgress(30, "Synchronisation Exploitation")
        osynchro.RunASCSynchroExploit(oExploit)
        m_bgw.ReportProgress(40, "Synchronisation Pulverisateur")
        osynchro.RunAscSynchroPulve(oPulve)
        For Each oExploit2Pulve As ExploitationTOPulverisateur In olstExploit2Pulve
            osynchro.RunAscSynchroExploit2Pulve(oExploit2Pulve)
        Next
        m_bgw.ReportProgress(60, "Synchronisation Contrôle")
        osynchro.runascSynchroDiag(m_Agent, m_Diag)
        m_bgw.ReportProgress(100, "Fin de synchronisation Contrôle")

    End Sub

    Private Sub m_bgw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles m_bgw.RunWorkerCompleted
        Me.Close()
    End Sub
End Class
