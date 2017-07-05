Public Class parentContener
    Inherits Form
    Implements IObservateur

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Public WithEvents parentContener_statusBar As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItem_aide_apropos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents notify_connexionStatus_nok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_ok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_wait As System.Windows.Forms.NotifyIcon
    Friend WithEvents statusBar_img_loader As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem_aide_debug As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem_aide_debug_exportLogs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheckupdates As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem_aide_debug_exportSynchro As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(parentContener))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuCheckupdates = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_apropos = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_debug = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_debug_exportLogs = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_debug_exportSynchro = New System.Windows.Forms.MenuItem()
        Me.parentContener_statusBar = New System.Windows.Forms.StatusBar()
        Me.notify_connexionStatus_nok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_ok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_wait = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.statusBar_img_loader = New System.Windows.Forms.PictureBox()
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem4, Me.MenuItem3, Me.mnuCheckupdates, Me.MenuItem7, Me.MenuItem_aide_apropos, Me.MenuItem_aide_debug})
        Me.MenuItem1.Text = "?"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Déconnexion"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.Text = "Quitter"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'mnuCheckupdates
        '
        Me.mnuCheckupdates.Index = 3
        Me.mnuCheckupdates.Text = "Vérifier les mises à jour"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.Text = "-"
        '
        'MenuItem_aide_apropos
        '
        Me.MenuItem_aide_apropos.Index = 5
        Me.MenuItem_aide_apropos.Text = "A Propos ?"
        '
        'MenuItem_aide_debug
        '
        Me.MenuItem_aide_debug.Index = 6
        Me.MenuItem_aide_debug.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_aide_debug_exportLogs, Me.MenuItem_aide_debug_exportSynchro})
        Me.MenuItem_aide_debug.Text = "Debug"
        '
        'MenuItem_aide_debug_exportLogs
        '
        Me.MenuItem_aide_debug_exportLogs.Index = 0
        Me.MenuItem_aide_debug_exportLogs.Text = "Extraire le fichier de logs"
        '
        'MenuItem_aide_debug_exportSynchro
        '
        Me.MenuItem_aide_debug_exportSynchro.Index = 1
        Me.MenuItem_aide_debug_exportSynchro.Text = "Extraire la trace de synchronisation"
        '
        'parentContener_statusBar
        '
        Me.parentContener_statusBar.Location = New System.Drawing.Point(0, 684)
        Me.parentContener_statusBar.Name = "parentContener_statusBar"
        Me.parentContener_statusBar.Size = New System.Drawing.Size(1012, 22)
        Me.parentContener_statusBar.TabIndex = 1
        '
        'notify_connexionStatus_nok
        '
        Me.notify_connexionStatus_nok.Icon = CType(resources.GetObject("notify_connexionStatus_nok.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_nok.Text = "Logiciel Agent Crodip: Hors Ligne !"
        Me.notify_connexionStatus_nok.Visible = True
        '
        'notify_connexionStatus_ok
        '
        Me.notify_connexionStatus_ok.Icon = CType(resources.GetObject("notify_connexionStatus_ok.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_ok.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'notify_connexionStatus_wait
        '
        Me.notify_connexionStatus_wait.Icon = CType(resources.GetObject("notify_connexionStatus_wait.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_wait.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'statusBar_img_loader
        '
        Me.statusBar_img_loader.Image = CType(resources.GetObject("statusBar_img_loader.Image"), System.Drawing.Image)
        Me.statusBar_img_loader.Location = New System.Drawing.Point(6, 688)
        Me.statusBar_img_loader.Name = "statusBar_img_loader"
        Me.statusBar_img_loader.Size = New System.Drawing.Size(16, 16)
        Me.statusBar_img_loader.TabIndex = 13
        Me.statusBar_img_loader.TabStop = False
        Me.statusBar_img_loader.Visible = False
        '
        'parentContener
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1012, 706)
        Me.Controls.Add(Me.statusBar_img_loader)
        Me.Controls.Add(Me.parentContener_statusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "parentContener"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip"
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '
    Private m_col As New Collection()
    Private m_nStep As Integer = 0
    Private splashScreen As New splash
    Private m_bCloseByUpdate As Boolean = False

    Public Function loadSplash()
        If GLOB_ENV_SHOWSPLASH Then
            splashScreen.Show()
        End If
    End Function
    Public Function unloadSplash()
        If GLOB_ENV_SHOWSPLASH Then
            splashScreen.Close()
        End If
    End Function

    Private Sub parentContener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        config_vars.Init()
        ' Dim oPulve As New Pulverisateur()
        globFormParent = Me
        Load_CRODIPINDIGO()
    End Sub
    Protected Overridable Sub Load_CRODIPINDIGO()
        loadSplash()
        Application.CurrentCulture = New System.Globalization.CultureInfo("fr-FR")
        CSEnvironnement.createFolders()
        CSEnvironnement.Renamefiles()
        'Vérification de la version de la base de données
        If Not DBVersionManagerManager.checkVersion(My.Settings.DBVersionExpected) Then
            MsgBox("Votre base de données n'est pas à jour, contactez le CRODIP pour effectuer la mise à jour.", MsgBoxStyle.OkOnly, "ERREUR SUR BASE DE DONNEES")
            m_bCloseByUpdate = True
            Me.Close()
        End If
        ' Mises a jour
        If CSSoftwareUpdate.checkMAJ Then
            Dim doMAJ As MsgBoxResult = MsgBox("Une mise à jour est disponible.", MsgBoxStyle.OkOnly, "Mise à jour disponible !")
            If doMAJ = MsgBoxResult.Ok Then
                CSSoftwareUpdate.runUpdater(False)
                m_bCloseByUpdate = True
                CSEnvironnement.delPid()
                Close()
                Exit Sub
            End If
        End If

        ' Initialisation du boot
        Try
            CSBoot.init()
            Statusbar.display("Démarrage en cours...", True)
        Catch ex As Exception
            CSDebug.dispError("parentContener::CSBoot.init()" & ex.Message)
        End Try

        ' Chargement du formulaire de login
        Try
            Dim loginMDIChild As New login
            loginMDIChild.Text = "Connexion"
            Statusbar.clear()
            DisplayForm(loginMDIChild)
        Catch ex As Exception
            ' CSDebug.dispError("parentContener::load" & ex.Message)
        End Try

        unloadSplash()
    End Sub

    Private Sub parentContener_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not m_bCloseByUpdate Then
            Dim Title As String = "Logiciel Crodip/Agent"

            Dim Var = MsgBox("Etes-vous sûr de vouloir fermer le logiciel ?", vbInformation + vbYesNo, Title)
            If Var = vbNo Then
                e.Cancel = True
            Else
                CSEnvironnement.delPid()
            End If
        Else
            CSEnvironnement.delPid()
        End If
    End Sub

#Region " Menu "

    Private Sub MenuItem_aide_apropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_aide_apropos.Click
        Dim formApropos As New apropos
        formApropos.ShowDialog()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        ' On ferme toutes les fenetres ouvertes
        Dim form As Form
        For Each form In Me.MdiChildren
            form.Close()
        Next

        ' On affiche l'écran de connexion
        Dim loginMDIChild As New login
        loginMDIChild.Text = "Connexion"

        DisplayForm(loginMDIChild)
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Me.Close()
    End Sub

    ' Vérification des mises à jour
    Private Sub mnuCheckupdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckupdates.Click
        If CSSoftwareUpdate.checkMAJ Then
            Dim doMAJ As MsgBoxResult = MsgBox("Une mise à jour est disponible. Souhaitez-vous la récupérer maintenant ?", MsgBoxStyle.YesNo, "Mise à jour disponible !")
            If doMAJ = MsgBoxResult.Yes Then
                CSSoftwareUpdate.runUpdater(False)
            End If
        Else
            MsgBox("Aucune mise à jour n'est disponible.")
        End If
    End Sub

#End Region

#Region " Events "

    Private Sub notify_connexionStatus_nok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notify_connexionStatus_nok.Click
        ' On ferme toutes les fenetres ouvertes
        Dim form As Form
        For Each form In Me.MdiChildren
            form.Close()
        Next
    End Sub

#End Region

    Private Sub MenuItem_aide_debug_exportLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_aide_debug_exportLogs.Click

        If CSFile.exists(GLOB_ENV_DEBUGLOGFILE) Then
            CSFile.open(GLOB_ENV_DEBUGLOGFILE)
        Else
            MsgBox("Aucun log d'erreur n'a été enregistré pour le moment.")
        End If

    End Sub


    Public Sub ReturnToAccueil()
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                '                ofrmAccueil.LoadListeExploitation()
                '                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Public Sub DisplayForm(oFrm As Form)

        oFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        oFrm.ControlBox = False
        oFrm.MaximizeBox = False
        oFrm.MinimizeBox = False
        oFrm.ShowIcon = True
        oFrm.ShowInTaskbar = True
        oFrm.Icon = Crodip_agent.Resources.Transparent
        oFrm.WindowState = FormWindowState.Maximized
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Public Sub Notice(pMsg As String) Implements IObservateur.Notice
        parentContener_statusBar.Text = "        " & pMsg
        parentContener_statusBar.Refresh()
    End Sub

    Private Sub MenuItem_aide_debug_exportSynchro_Click(sender As Object, e As EventArgs) Handles MenuItem_aide_debug_exportSynchro.Click
        If CSFile.exists(GLOB_ENV_SYNCHROLOGFILE) Then
            CSFile.open(GLOB_ENV_SYNCHROLOGFILE)
        Else
            MsgBox("Aucun trace de Synchronisationn'a été enregistrée pour le moment.")
        End If

    End Sub

    Private Sub parentContener_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Control) Then
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub parentContener_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate

    End Sub

    Private Sub parentContener_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        CSDebug.dispError(e.Control)
    End Sub
End Class
